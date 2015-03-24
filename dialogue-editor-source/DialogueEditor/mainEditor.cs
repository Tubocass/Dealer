using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace DialogueEditor {  
    //Deals with event handling for GUI
    public partial class mainEditor : Form {

        public mainEditor() {
            InitializeComponent();
            NonDesignerInitialization();
        }
        private void NonDesignerInitialization() {
            currentFilePath = null;
            leftPanelNodeDisplay.DisplayingPageControlPanel = false;
        }
        private void mainEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (!Data.Instance.IsAllDataSaved()) {
                DialogResult messageResult = MessageBox.Show(
                    unsavedDataText, unsavedDataCaption, MessageBoxButtons.YesNoCancel);
                if (messageResult == DialogResult.Cancel) {
                    e.Cancel = true;
                }
                else if (messageResult == DialogResult.Yes) {
                    if (currentFilePath == null) {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                            Data.Instance.SaveFile(saveFileDialog.FileName);
                        } else {
                            e.Cancel = true;
                        }
                    }
                    else {
                        Data.Instance.SaveFile(currentFilePath);
                    }
                }
            }
        }
        private void mainEditor_Load(object sender, EventArgs e) {
            NewFile();
        }
        //
        // TOP TOOL-STRIP DROP-DOWN MENU: FILE
        //
        private string currentFilePath = null;
        private string unsavedDataCaption = "Unsaved Data";
        private string unsavedDataText = "Do you wish to save changes to the current file?";
        private string illegalNodeIDsCaption = "Illegal Node IDs Detected";
        private string illegalNodeIDsText = "In order to edit your file, Dialogue Editor will need"+
                "to update the file's node IDs. Do you wish to proceed?";
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            if ((Data.Instance.IsAllDataSaved()) && (currentFilePath != null)) {
                fileSaveTopMenuButton.Enabled = false;
            }
            else {
                fileSaveTopMenuButton.Enabled = true;
            }
        }
        private void fileNewTopMenuButton_Click(object sender, EventArgs e){
            if (Data.Instance.IsAllDataSaved()) {
                NewFile();
            }
            else {
                DialogResult result = MessageBox.Show(unsavedDataText, 
                    unsavedDataCaption, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        Data.Instance.SaveFile(saveFileDialog.FileName);
                        Data.Instance.Clear();
                        UpdateNodeEditPanels();
                        this.Text = "Dialogue Editor";
                        currentFilePath = null;
                    }
                }
                else if (result == DialogResult.No) {
                    NewFile();
                }
            }
        }
        private void NewFile() {
            Data.Instance.Clear();
            Node newRoot = Data.Instance.AddNode();
            NodeEditPanel.RootNodePanel = new NodeEditPanel(newRoot);
            Data.Instance.ForceSaved();
            UpdateNodeEditPanels();
            this.Text = "Dialogue Editor";
            currentFilePath = null;
        }
        private void fileOpenTopMenuButton_Click(object sender, EventArgs e) {
            rightPanelTabControl.Select();  //Select() used to avoid bug in System.Drawing when 
                                            //TextBox is desposed while it is selected in preparation 
                                            //for opening file
            if (!Data.Instance.IsAllDataSaved()) {
                DialogResult result = MessageBox.Show(unsavedDataText, 
                    unsavedDataCaption, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) {
                    if (currentFilePath == null) {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                            Data.Instance.SaveFile(saveFileDialog.FileName);
                        }
                    }
                    else {
                        Data.Instance.SaveFile(currentFilePath);
                    }
                }
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                Data.Instance.LoadFile(openFileDialog.FileName);
                if (Data.Instance.AreIDsIllegal()) {
                    if (MessageBox.Show(illegalNodeIDsText, illegalNodeIDsCaption, 
                        MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        Data.Instance.AssignLegalIDs();
                        this.Text = "Dialogue Editor - " + openFileDialog.FileName;
                        currentFilePath = openFileDialog.FileName;
                    }
                    else {
                        Data.Instance.Clear();
                    }
                }
                else {
                    this.Text = openFileDialog.FileName + " - Dialogue Editor";
                    currentFilePath = openFileDialog.FileName;
                }
                UpdateNodeEditPanels();
            }
        }
        private void fileSaveTopMenuButton_Click(object sender, EventArgs e){
            if (!Data.Instance.IsAllDataSaved()) {
                if (currentFilePath == null) {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {  
                        Data.Instance.SaveFile(saveFileDialog.FileName);
                        this.Text = saveFileDialog.FileName + " - Dialogue Editor";
                        currentFilePath = saveFileDialog.FileName;
                    }
                } 
                else {
                    Data.Instance.SaveFile(currentFilePath);
                }
                fileSaveTopMenuButton.Enabled = true;
            }
            else {
                fileSaveTopMenuButton.Enabled = false;
                SystemSounds.Beep.Play();
            }
        }
        private void fileSaveAsMenuTopButton_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {  
                Data.Instance.SaveFile(saveFileDialog.FileName);
                this.Text = saveFileDialog.FileName + " - Dialogue Editor";
                currentFilePath = saveFileDialog.FileName;
            }
        }
        private void fileExitTopMenuButton_Click(object sender, EventArgs e) {
            if (Data.Instance.IsAllDataSaved()) { 
                Application.Exit();
            } else {
                DialogResult messageResult = MessageBox.Show(
                    unsavedDataText, unsavedDataCaption, MessageBoxButtons.YesNoCancel);
                if (messageResult == DialogResult.No) {
                    Application.Exit();
                }
                else if (messageResult == DialogResult.Yes) {
                    if (currentFilePath == null) {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                            Data.Instance.SaveFile(saveFileDialog.FileName);
                            Application.Exit();
                        }
                    }
                    else {
                        Data.Instance.SaveFile(currentFilePath);
                        Application.Exit();
                    }
                }
            }
        }
        private void rightPanelTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateNodeEditPanels();
        }
        public void UpdateNodeEditPanels() {
            leftPanelNodeDisplay.Clear();
            leftPanelNodeDisplay.AddObject(NodeEditPanel.RootNodePanel.DisplayedNode);
            if (rightPanelTabControl.SelectedTab == nodesRalativeToRootTab) {
                nodesRelativeToRootPanel.UpdateNodeList();
            }
            else if (rightPanelTabControl.SelectedTab == listNodesTab) {
                listNodesPanel.UpdateNodesList();
            }
        }
        //
        // LEFT FLOW LAYOUT PANEL
        //
        /// <summary>
        /// Adds a NodeEditPanel to the root node FlowLayoutPanel.
        /// </summary>
        public void AddNodeEditPanelAsRoot(Choice targetingChoice) {
            NodeEditPanel newNodeEditPanel = new NodeEditPanel(Data.Instance.AddNode());
            targetingChoice.Target = newNodeEditPanel.DisplayedNode.ID;
            NodeEditPanel.RootNodePanel = newNodeEditPanel;
            UpdateNodeEditPanels();
        }
        //
        // RIGHT FLOW LAYOUT PANEL
        //
        /// <summary>
        /// Adds a new Node and ensures that the corrosponding NodeEditPanel is created in the active TabPage.
        /// </summary>
        public void AddNodeEditPanel(Choice targetingChoice) {
            Node newNode = Data.Instance.AddNode();
            targetingChoice.Target = newNode.ID;
            UpdateNodeEditPanels();
        }
        private void addNodeMenuButton_Click(object sender, EventArgs e) {
            NodeEditPanel.RootNodePanel = new NodeEditPanel(Data.Instance.AddNode());
            UpdateNodeEditPanels();
        }
    }
}