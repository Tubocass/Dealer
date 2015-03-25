using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DialogueEditor {
    public partial class NodesRelativeToRootPanel : UserControl {
        public NodesRelativeToRootPanel() {
            InitializeComponent();
            NonDesignerInitialisation();
        }
        private void NonDesignerInitialisation() {
            this.Dock = DockStyle.Fill;
            treeDirectionComboBox.SelectedIndex = 0;
        }
        ///<summary>
        /// Updates the contents in accordance with current data.
        ///</summary>
        public void UpdateNodeList() {
            if (NodeEditPanel.RootNodePanel != null) {
                nodesDisplayPanel.Clear();
                if (treeDirectionComboBox.SelectedIndex == 0) {
                    nodesDisplayPanel.Clear();
                    nodesDisplayPanel.AddObjects(TraverseForwardTree());
                }
                else {
                    nodesDisplayPanel.Clear();
                    nodesDisplayPanel.AddObjects(TraverseBackwardTree());
                }
            }
        }
        private object[] TraverseForwardTree() {
            bool[] nodesAlreadyListed  = new bool[Data.Instance.GetGreatestID()];
            nodesAlreadyListed[Base64.ConvertFrom(
                NodeEditPanel.RootNodePanel.DisplayedNode.ID)] = true;
            List<object> treeObjects = new List<object>(Data.Instance.GetGreatestID());
            List<Node> previousDepthNodes = new List<Node>();
            List<Node> currentDepthNodes = new List<Node>();
            previousDepthNodes.Add(NodeEditPanel.RootNodePanel.DisplayedNode);
            int nodeEditPanelsAdded = 0;
            for (int currentDepth = 1; currentDepth <= maxDepthNumericUpDown.Value; currentDepth ++){
                foreach (Node n in previousDepthNodes) {
                    foreach (Choice c in n.Choices) {
                        if (!nodesAlreadyListed[Base64.ConvertFrom(c.Target)]) {
                            Node childNode = Data.Instance.GetNodeByID(c.Target);
                            if (childNode != null) {
                                nodesAlreadyListed[Base64.ConvertFrom(c.Target)] = true;
                                currentDepthNodes.Add(childNode);
                            }
                        }
                    }
                }
                if (currentDepthNodes.Count == 0) {
                    return treeObjects.ToArray();
                }
                treeObjects.Add("Depth: " + currentDepth);
                foreach (Node n in currentDepthNodes) {
                    treeObjects.Add(n);
                    nodeEditPanelsAdded ++;
                    if (nodeEditPanelsAdded == maxNumberNodesNumericUpDown.Value) {
                        return treeObjects.ToArray();
                    }
                }
                previousDepthNodes = currentDepthNodes;
                currentDepthNodes = new List<Node>();
            }
            return treeObjects.ToArray();
        }
        private object[] TraverseBackwardTree() {
            bool[] nodesAlreadyListed  = new bool[Data.Instance.GetGreatestID()];
            nodesAlreadyListed[Base64.ConvertFrom(
                NodeEditPanel.RootNodePanel.DisplayedNode.ID)] = true;
            List<object> treeObjects = new List<object>(Data.Instance.GetGreatestID());
            List<Node> previousDepthNodes = new List<Node>();
            List<Node> currentDepthNodes = new List<Node>();
            previousDepthNodes.Add(NodeEditPanel.RootNodePanel.DisplayedNode);
            int nodeEditPanelsAdded = 0;
            for (int currentDepth = 1; currentDepth <= maxDepthNumericUpDown.Value; currentDepth ++){
                foreach (Node n in previousDepthNodes) {
                    currentDepthNodes.AddRange(Data.Instance.GetTargetingNodes(n));
                }
                if (currentDepthNodes.Count == 0) {
                    return treeObjects.ToArray();
                }
                treeObjects.Add("Depth: " + currentDepth.ToString());
                foreach (Node n in currentDepthNodes) {
                    treeObjects.Add(n);
                    nodeEditPanelsAdded ++;
                    if (nodeEditPanelsAdded == maxNumberNodesNumericUpDown.Value) {
                        return treeObjects.ToArray();
                    }
                }
                previousDepthNodes = currentDepthNodes;
                currentDepthNodes = new List<Node>();
            }
            return treeObjects.ToArray();
        }

        private void treeDirectionComboBox_SelectedValueChanged(object sender, EventArgs e) {
            UpdateNodeList();
        }
        private void maxDepthNumericUpDown_ValueChanged(object sender, EventArgs e) {
            UpdateNodeList();
        }
        private void maxNumberNodesNumericUpDown_ValueChanged(object sender, EventArgs e) {
            UpdateNodeList();
        }
    }
}
