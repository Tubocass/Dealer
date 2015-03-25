using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DialogueEditor {
    public partial class SearchForNodesPanel : UserControl {
        public SearchForNodesPanel() {
            InitializeComponent();
            NonDesignerInitialisation();
        }
        private void NonDesignerInitialisation() {
            this.Dock = DockStyle.Fill;
            lookInDropDownList.SelectedIndex = 2;
        }
        public void UpdateNodeList() {
            nodesDisplayPanel.Clear();
            NodeSearchLookIn lookIn;
            if (lookInDropDownList.SelectedIndex == 0) {
                lookIn = NodeSearchLookIn.NPCText;
            }
            else if (lookInDropDownList.SelectedIndex == 1) {
                lookIn = NodeSearchLookIn.PlayerText;
            }
            else {
                lookIn = NodeSearchLookIn.Both;
            }
            List<Node> foundNodes = Data.Instance.GetNodesByStringSearch(patternTextBox.Text,
                                    lookIn, matchCaseCheckBox.Checked, wholeWordCheckBox.Checked);
  
            nodesDisplayPanel.AddObjects(foundNodes.ToArray());
        }
        private void searchButton_Click(object sender, EventArgs e) {
            if (patternTextBox.Text != "") {
                UpdateNodeList();
            }
        }
    }
}
