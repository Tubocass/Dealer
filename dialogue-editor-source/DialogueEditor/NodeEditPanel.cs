using System;
using System.Windows.Forms;
using System.Collections.Generic;
using i00SpellCheck;

namespace DialogueEditor {

    public partial class NodeEditPanel : UserControl {
        private Node displayedNode;
        private static NodeEditPanel rootNodePanel = null;
        private mainEditor containingForm;
        private bool isMinimised;
        private bool isRootNodePanel;
        private Stack<ChoiceEditPanel> choiceEditPanels = new Stack<ChoiceEditPanel>();
        /// <summary>
        /// Sets and gets the root NodeEditPanel; ensures that there is only ever one.
        /// </summary>
        public static NodeEditPanel RootNodePanel {
            set {
                if (rootNodePanel == null) {
                    rootNodePanel = value;
                    rootNodePanel.IsRootNodePanel = true;
                }
                else {
                    rootNodePanel.IsRootNodePanel = false;
                    rootNodePanel = value;
                    rootNodePanel.IsRootNodePanel = true;
                }
            }
            get {
                return rootNodePanel;
            }
        }
        public NodeEditPanel(Node n) {
            InitializeComponent();
            NonDesignerInnitialization();
            SetForNewNode(n);
        }
        private void SetForNewNode(Node n) {
            displayedNode = n;
            npcTextBox.Text = n.NPC;
            if (RootNodePanel != null) {
                if (n == RootNodePanel.DisplayedNode) isRootNodePanel = true;
                else isRootNodePanel = false;
            }
            foreach (Control c in choicesFlowLayoutPanel.Controls) {
                if (c is ChoiceEditPanel) choiceEditPanels.Push((ChoiceEditPanel)c);
            }
            choicesFlowLayoutPanel.Controls.Clear();
            choicesFlowLayoutPanel.Controls.Add(choicesFlowLayoutPanelWidthGuide);
            foreach (Choice c in n.Choices) {
                if (choiceEditPanels.Count > 0) {
                    ChoiceEditPanel reusedPanel = choiceEditPanels.Pop();
                    choicesFlowLayoutPanel.Controls.Add(reusedPanel);
                    reusedPanel.DisplayedChoice = c;
                } else {
                    choicesFlowLayoutPanel.Controls.Add(new ChoiceEditPanel(c));
                }
            }
        }
        public Node DisplayedNode{
            get{return displayedNode;} 
            set{SetForNewNode(value);}
        }

        private void NonDesignerInnitialization() {
            this.Dock = DockStyle.Top;
            this.AutoSize = true;
        }
        public bool IsRootNodePanel {
            get {return isRootNodePanel;}
            set {isRootNodePanel = value;
            UpdateHeader();}
        }
        private void NodeEditPanel_Load(object sender, EventArgs e) {
            containingForm = (mainEditor) this.TopLevelControl;
            UpdateHeader();
            RenumberChoiceEditPanels();
        }
        private void UpdateHeader() {
            if (isRootNodePanel) {
                nodeHeaderLabel.Text = "Root Node (ID: " + DisplayedNode.ID + ")";
                deleteNodeButton.Visible = false;
                minimiseNodeButton.Visible = false;
                makeNodeRootButton.Visible = false;
            } else {
                nodeHeaderLabel.Text = "Node (ID: " + DisplayedNode.ID + ")";
                deleteNodeButton.Visible = true;
                minimiseNodeButton.Visible = true;
                makeNodeRootButton.Visible = true;
            }
        }
        //
        // HEADER
        //
        private void deleteNodeButton_Click(object sender, EventArgs e) {
            Data.Instance.RemoveNode(this.DisplayedNode.ID);
            this.Dispose();
            containingForm.UpdateNodeEditPanels();
        }      
        private void minimiseButton_Click(object sender, EventArgs e) {
            isMinimised = !isMinimised;
            if (isMinimised) {
                npcTextPanel.Visible = false;
                choicesFlowLayoutPanel.Visible = false;
                addChoiceButton.Visible = false;
                minimiseNodeButton.BackgroundImage = global :: DialogueEditor.Properties.Resources.MaximiseButton1;
                toolTips.SetToolTip (minimiseNodeButton, "Maximise Choice");
            }
            else {
                npcTextPanel.Visible = true;
                choicesFlowLayoutPanel.Visible = true;
                addChoiceButton.Visible = true;
                minimiseNodeButton.BackgroundImage = global :: DialogueEditor.Properties.Resources.MinimiseButton1;
                toolTips.SetToolTip (minimiseNodeButton, "Minimise Choice");
            }            
        }
        //
        // NPC TEXT BOX
        //
        public void ResizeNPCTextBox () {
            if (npcTextBox.Text != "") {
                TextFormatFlags formatFlags = TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
                npcTextBox.Height = TextRenderer.MeasureText(npcTextBox.Text, npcTextBox.Font,
                    npcTextBox.ClientSize, formatFlags).Height + 6;
            }
        }
        private void npcTextBox_Enter(object sender, EventArgs e) {
            npcTextBox.EnableSpellCheck();
        }
        private void npcTextBox_Leave(object sender, EventArgs e) {
            npcTextBox.DisableSpellCheck();
        }
        private void npcTextBox_TextChanged(object sender, EventArgs e) {
            ResizeNPCTextBox();
            DisplayedNode.NPC = npcTextBox.Text;
        }
        //
        // CHOICE EDIT PANEL
        //
        private void addChoiceButton_Click(object sender, EventArgs e) {
            Choice choiceTemp = new Choice();
            DisplayedNode.Choices.Add(choiceTemp);
            ChoiceEditPanel choicePanelTemp = new ChoiceEditPanel(choiceTemp);
            choicesFlowLayoutPanel.Controls.Add(choicePanelTemp);
        }
        private void ChoicesFlowLayoutPanel_SizeChanged(object sender, EventArgs e) {
            choicesFlowLayoutPanelWidthGuide.Width = choicesFlowLayoutPanel.Width;
            ResizeNPCTextBox();
        }
        private void choicesFlowLayoutPanel_ControlRemoved(object sender, ControlEventArgs e) {
            RenumberChoiceEditPanels();
        }

        private void choicesFlowLayoutPanel_ControlAdded(object sender, ControlEventArgs e) {
            RenumberChoiceEditPanels();
        }
        private void RenumberChoiceEditPanels() {
            if (choicesFlowLayoutPanel.Controls.Count > 1) {
                ChoiceEditPanel[] choicePanelTemp = new ChoiceEditPanel
                    [choicesFlowLayoutPanel.Controls.Count - 1];
                int index = 0;
                foreach (Control c in choicesFlowLayoutPanel.Controls) {
                    if (c is ChoiceEditPanel) { 
                        choicePanelTemp[index] = (ChoiceEditPanel)c;
                        index ++;
                    }
                }
                for (index = 0; index < choicePanelTemp.Length; index ++) {
                        choicePanelTemp[index].SetNumber(index);
                }
            }
        }
        private void makeNodeRootButton_Click(object sender, EventArgs e) {
            RootNodePanel = new NodeEditPanel(this.displayedNode);
            containingForm.UpdateNodeEditPanels();
            Dispose();
        }
    }
}
