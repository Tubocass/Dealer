using System;
using System.Windows.Forms;
using System.Drawing;
using i00SpellCheck;

namespace DialogueEditor {
    public partial class ChoiceEditPanel : UserControl {

        private Choice displayedChoice;
        private NodeEditPanel parentNodePanel;
        private mainEditor containingForm;
        private bool isMinimised = false;
        private bool hasTarget = false;

        public ChoiceEditPanel (Choice c) {
            InitializeComponent();
            NonDesignerInnitialization();
            displayedChoice = c;

        }
        private void NonDesignerInnitialization() {
            this.Dock = DockStyle.Top;
            this.AutoSize = true;
        }
        public Choice DisplayedChoice {
            get {return displayedChoice;}
            set {displayedChoice = value;
                InnitiliseForNewChoice();}
        }
        private void InnitiliseForNewChoice() {
            if (displayedChoice.Target != "") {
                hasTarget = true;
            }
            else hasTarget = false;
            parentNodePanel = (NodeEditPanel) this.Parent.Parent;
            containingForm = (mainEditor) this.TopLevelControl;
            playerTextBox.Text = displayedChoice.Player;
            if (hasTarget) targetNodeIDValueTextBox.Text = displayedChoice.Target;
            UpdateTargetPanel();
        }
        private void ChoiceEditPanel_Load(object sender, EventArgs e){
            InnitiliseForNewChoice();
        }
        private void ChoiceEditPanel_Enter(object sender, EventArgs e) {
            if (Data.Instance.GetNodeByID(displayedChoice.Target) == null) {
                hasTarget = false;
                displayedChoice.Target = "";
                targetNodeIDValueTextBox.Text = "null";
                UpdateTargetPanel();
            }
        }
        private void ChoiceEditPanel_Leave(object sender, EventArgs e) {
            targetNodeIDTextBoxFeedback.Text = "";
        }
        //
        //CHOICE HEADER
        //
        /// <summary>
        /// Sets the number that is displayed in the ChoiceEditPanel's header.
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber (int number) {
            ChoiceNumberLabel.Text = "Choice " + number;
        }
        private void deleteChoiceButton_Click(object sender, EventArgs e) {
            parentNodePanel.DisplayedNode.Choices.Remove(displayedChoice);
            this.Dispose();
        }
        private void minimiseChoiceButton_Click(object sender, EventArgs e){
            isMinimised = !isMinimised;
            if (isMinimised) {
                playerTextPanel.Visible = false;
                targetNodePanel.Visible = false;
                minimiseChoiceButton.BackgroundImage = global :: DialogueEditor.Properties.Resources.MaximiseButton2;
                toolTips.SetToolTip (minimiseChoiceButton, "Maximise Choice");
            }
            else {
                playerTextPanel.Visible = true;
                targetNodePanel.Visible = true;
                minimiseChoiceButton.BackgroundImage = global :: DialogueEditor.Properties.Resources.MinimiseButton2;
                toolTips.SetToolTip (minimiseChoiceButton, "Minimise Choice");
            }
        }
        //
        // PLAYER TEXT BOX
        //
        private void ResizePlayerTextBox() {
            if (playerTextBox.Text != "") {
                TextFormatFlags formatFlags = TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
                playerTextBox.Height = TextRenderer.MeasureText(playerTextBox.Text, playerTextBox.Font,
                    playerTextBox.ClientSize, formatFlags).Height + 6;
            }
        }
        private void playerTextBox_TextChanged(object sender, EventArgs e) {
            ResizePlayerTextBox();
            displayedChoice.Player = playerTextBox.Text;
        }
        private void playerTextBox_Enter(object sender, EventArgs e) {
            playerTextBox.EnableSpellCheck();
        }
        private void playerTextBox_Leave(object sender, EventArgs e) {
            playerTextBox.DisableSpellCheck();
        }
        private void ChoiceEditPanel_SizeChanged(object sender, EventArgs e) {
            ResizePlayerTextBox();
        }
        //
        // TARGET PANEL
        //
        private void makeTargetNewRootNode_Click(object sender, EventArgs e) {
            containingForm.AddNodeEditPanelAsRoot(displayedChoice);
            targetNodeIDValueTextBox.Text = displayedChoice.Target;
            hasTarget = true;
            UpdateTargetPanel();
        }
        private void makeTargetNewNodeButton_Click(object sender, EventArgs e) {
            containingForm.AddNodeEditPanel(displayedChoice);
            targetNodeIDValueTextBox.Text = displayedChoice.Target;
            hasTarget = true;
            UpdateTargetPanel();
        }
        private void UpdateTargetPanel() {
            if (hasTarget) {
                makeTargetNewNodeButton.Visible = false;
                makeTargetNewRootNodeButton.Visible = false;
            }
            else {
                makeTargetNewNodeButton.Visible = true;
                makeTargetNewRootNodeButton.Visible = true;
            }
        }
        private void targetNodeIDValueTextBox_Leave(object sender, EventArgs e)  {
            if (displayedChoice.Target == "") {
                targetNodeIDValueTextBox.Text = "null";
            } else {
                targetNodeIDValueTextBox.Text = displayedChoice.Target;
            }
            targetNodeIDTextBoxFeedback.Text = "";
        }
        private void targetNodeIDValueTextBox_TextChanged(object sender, EventArgs e) {
            if (TargetNodeIDValueIsValid()){
                if (targetNodeIDValueTextBox.Text == "null") {
                    displayedChoice.Target = "";
                } else {
                    displayedChoice.Target = targetNodeIDValueTextBox.Text;
                }
                targetNodeIDTextBoxFeedback.Text = "";
            }
        }
        private bool TargetNodeIDValueIsValid() {
            if (targetNodeIDValueTextBox.Text == "null") {
                return true; 
            } else if (Data.Instance.GetNodeByID(targetNodeIDValueTextBox.Text) == null) {
                targetNodeIDTextBoxFeedback.Text = "You haven't entered a valid ID.";
                return false;
            } else if (targetNodeIDValueTextBox.Text == parentNodePanel.DisplayedNode.ID) {
                targetNodeIDTextBoxFeedback.Text = "Choice can't target its containing Node.";
                return false;
            }
            else {
                return true;
            }
        }
    }
}
