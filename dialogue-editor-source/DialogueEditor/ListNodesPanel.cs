using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DialogueEditor {
    public partial class ListNodesPanel : UserControl {
        
        private IComparer<Node>[] comparers;

        public ListNodesPanel() {
            InitializeComponent();
            NonDesignerInnitialisation();
        }
        private void NonDesignerInnitialisation() {
            this.Dock = DockStyle.Fill;
            listDropDownList.SelectedIndex = 0;
            orderByDropDownList.SelectedIndex = 0;
            numberOfNodesNumUpDown.Enabled = false;
            comparers = new IComparer<Node>[3];
            comparers[0] = new CompareNodesByID();
            comparers[1] = new CompareNodesByNPCText();
            comparers[2] = new CompareNodesByChoiceCount();
        }
        public void UpdateNodesList() {
            List<Node> nodes = new List<Node>();
            nodes.AddRange(Data.Instance.Nodes);
            nodes.Remove(NodeEditPanel.RootNodePanel.DisplayedNode);
            nodes.Sort((IComparer<Node>) comparers[orderByDropDownList.SelectedIndex]);
            if ((listDropDownList.SelectedIndex == 1)
                && (nodes.Count > numberOfNodesNumUpDown.Value)) {
                nodes.RemoveRange((int)numberOfNodesNumUpDown.Value, nodes.Count - 
                    (int)numberOfNodesNumUpDown.Value);
            }
            nodesDisplayPanel.Clear();
            nodesDisplayPanel.AddObjects(nodes.ToArray());
        }
        private void listDropDownList_SelectionChangeCommitted(object sender, EventArgs e) {
            if (listDropDownList.SelectedIndex == 1) numberOfNodesNumUpDown.Enabled = true;
            else numberOfNodesNumUpDown.Enabled = false;
            UpdateNodesList();
        }
        private void orderByDropDownList_SelectionChangeCommitted(object sender, EventArgs e) {
            UpdateNodesList();
        }
        private void numberOfNodesNumUpDown_ValueChanged(object sender, EventArgs e) {
            UpdateNodesList();
        }
    }
    public class CompareNodesByID : IComparer<Node> {
        public int Compare (Node n1, Node n2) {
            if (n1 == null) {
               if (n2 == null) return 0;
                else return -1;
            }
            else {
                if (n2 == null) return 1;
                if (Base64.ConvertFrom(n1.ID) > Base64.ConvertFrom(n2.ID)) return 1;
                else if (Base64.ConvertFrom(n1.ID) == Base64.ConvertFrom(n2.ID)) return 0;
                else return -1;
            }
        }
    }
    public class CompareNodesByNPCText : IComparer<Node> {
        public int Compare (Node n1, Node n2) {
            if (n1 == null) {
               if (n2 == null) return 0;
               else return -1;
            }
            else {
                if (n2 == null) return 1;
                int comparisonResult = n1.NPC.CompareTo(n2.NPC);
                if (comparisonResult > 0) return 1;
                else if (comparisonResult == 0) return 0;
                else return -1;
            }
        }
    }
    public class CompareNodesByChoiceCount : IComparer<Node> {
        public int Compare (Node n1, Node n2) {
            if (n1 == null) {
                if (n2 == null) return 0;
                else return -1;
}
            else {
                if (n2 == null) return 1;
                if (n1.Choices.Count < n2.Choices.Count) return 1;
                else if (n1.Choices.Count == n2.Choices.Count) return 0;
                else return -1;
            }
        }
    }
}
