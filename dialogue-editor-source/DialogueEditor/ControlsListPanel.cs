using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace DialogueEditor {

    public partial class ControlsListPanel : UserControl {
        private List<object> allObjects;
        private List<Node> nodes;
        private List<Control> currentPageControls;
        private int pageNumber = 1;
        private bool pageNumberTextBoxInFocus = false;
        private bool displayingPageControlPanel = true;

        public ControlsListPanel() {
            InitializeComponent();
            NonDesignerInnitialisation();
        }
        private void NonDesignerInnitialisation() {
            this.Dock = DockStyle.Fill;
            allObjects = new List<object>();
            nodes = new List<Node>();
            currentPageControls = new List<Control>();
        }
        /// <summary>
        /// Clears NodesDisplayPanel of all Controls.
        /// </summary>
        public void Clear() {
            allObjects.Clear();
            nodes.Clear();
        }
        /// <summary>
        /// Adds an object to be displayed by the ControlsListPanel. Nodes are displayed as NodeEditPanels, 
        /// strings as Windows.Forms.Labels
        /// </summary>
        /// <param name="control"></param>
        public void AddObject(object item) {
            allObjects.Add(item);
            if (item is Node) {
                nodes.Add((Node)item);
            }
            UpdateControlsDisplay();
        }
        /// <summary>
        /// Adds objects to be displayed by the ControlsListPanel. Nodes are displayed as NodeEditPanels, 
        /// strings as Windows.Forms.Labels
        /// </summary>
        /// <param name="items"></param>
        public void AddObjects(object[] items) {
            allObjects.AddRange(items);
            foreach (object obj in items) {
                if (obj is Node) {
                    nodes.Add((Node)obj);
                }
            }
            UpdateControlsDisplay();
        }
        private void UpdateControlsDisplay() {
            for (int i = currentPageControls.Count - 1; i > 0; i --) {
                currentPageControls[i].Dispose();
            }
            currentPageControls.Clear();
            if (nodes.Count > 0) {
                Node startingNode = nodes[(pageNumber - 1) * (int)nodesPerPageNumUpDown.Value];
                bool lookingForNode = true;
                int objectIndex = 0;
                int index = 0;
                while ((lookingForNode) && (index < allObjects.Count)) {
                    if (allObjects[index] == startingNode) {
                        objectIndex = index;
                        lookingForNode = false;
                    }
                    index ++;
                }
                if (objectIndex == 1) {
                    currentPageControls.Add(GenerateHeading((string)allObjects[0]));
                }
                int nodeCounter =  0;
                while ((nodeCounter < (int)nodesPerPageNumUpDown.Value) &&
                       (objectIndex < allObjects.Count)) {
                    if (allObjects[objectIndex] is Node) {
                        if (((Node)allObjects[objectIndex] == NodeEditPanel.RootNodePanel.DisplayedNode)
                        && (!displayingPageControlPanel)) {
                            currentPageControls.Add(NodeEditPanel.RootNodePanel);
                        } else {
                            NodeEditPanel nodeEditPanel = new NodeEditPanel((Node)allObjects[objectIndex]);
                            currentPageControls.Add(nodeEditPanel);
                        }
                        nodeCounter ++;
                    } else if (allObjects[objectIndex] is string) {
                        currentPageControls.Add(GenerateHeading((string)allObjects[objectIndex]));

                    }
                    objectIndex ++;
                }
            }
            flowPanel.Controls.Clear();
            flowPanel.Controls.Add(widthGuide);
            flowPanel.Controls.AddRange(currentPageControls.ToArray());
        }
        Label GenerateHeading(string text) {
            Label heading = new Label();
            heading.Size = new Size(100,22);
            heading.Margin = new Padding(0,0,0,2);
            heading.Text = text;
            heading.Font = new Font("Arial Black", 10);
            heading.TextAlign = ContentAlignment.MiddleCenter;
            heading.BackColor = Color.White;
            heading.Dock = DockStyle.Top;
            return heading;
        }
        //
        // LAYOUT
        //
        private bool customLayoutEnabled = true;
        /// <summary>
        /// Sets whether this Control carries out custom layout logic.
        /// </summary>
        public bool CustomLayoutEnabled {
            set {customLayoutEnabled = value;
                if (value) CustomLayout();}
            private get {return customLayoutEnabled;}
        }
        private void CustomLayout() {
            if (CustomLayoutEnabled) {
                scrollBarHideLogic();
                int controlsWidth = (scrollBar.Visible)? listPanel.Width - scrollBar.Width : 
                    listPanel.Width;
                widthGuide.Width = controlsWidth - 1;
                flowPanel.Width = controlsWidth - 1;
                UpdateScrollBar();
            }
        }
        private void listPanel_Layout(object sender, LayoutEventArgs e) {
            CustomLayout();
        }
        //
        // SCROLL BAR
        //
        private void UpdateScrollBar() {
            if (scrollBar.Visible) {
                int bottomControlIndex = flowPanel.Controls.Count - 1;
                if (bottomControlIndex > -1) {
                    int controlsBottom = flowPanel.Controls[bottomControlIndex].Bottom +
                        flowPanel.Controls[bottomControlIndex].Margin.Bottom;
                    scrollBar.LargeChange = listPanel.Height;
                    scrollBar.SmallChange = scrollBar.LargeChange / 40;
                    scrollBar.Maximum = controlsBottom;
                }
            }
        }
        private void scrollBarHideLogic() {
            int bottomControlIndex = flowPanel.Controls.Count - 1;
            if (bottomControlIndex > -1) {
                if (flowPanel.Controls[bottomControlIndex].Bottom + 
                    flowPanel.Controls[bottomControlIndex].Margin.Bottom > 
                    listPanel.Height)
                {
                    scrollBar.Visible = true;
                }
                else {
                    scrollBar.Visible = false;
                    flowPanel.Location = new Point(flowPanel.Location.X, 0);
                }
            }
        }
        private void scrollBar_Scroll(object sender, ScrollEventArgs e) {
            flowPanel.Location = new Point (flowPanel.Location.X,
                (int)-(((double)scrollBar.Value / (double)scrollBar.Maximum) * 
                (double)scrollBar.Maximum));
        }
        //
        // PAGE CONTROL PANEL
        //
        public bool DisplayingPageControlPanel {
            get {return displayingPageControlPanel;}
            set {displayingPageControlPanel = value;
                if (displayingPageControlPanel) {
                    pagesOptionsPanel.Visible = true;
                } else {
                    pagesOptionsPanel.Visible = false;
                }
            }
        }

        private void toFirstPageButton_Click(object sender, EventArgs e) {
            if (pageNumber != 1) {
                pageNumber = 1;
                pageNumberTextBox.Text = "1";
                UpdateControlsDisplay();
                pageNumberTextBox.Text = pageNumber.ToString();
            }
        }
        private void backOnePageButton_Click(object sender, EventArgs e) {
            if (pageNumber > 1) {
                pageNumber --;
                UpdateControlsDisplay();
                pageNumberTextBox.Text = pageNumber.ToString();
            }
        }
        private void forwardOnePageButton_Click(object sender, EventArgs e) {
            int numberofPages = nodes.Count / (int) nodesPerPageNumUpDown.Value;
            if (nodes.Count % (int) nodesPerPageNumUpDown.Value > 0) numberofPages ++;
            if (pageNumber < numberofPages) {
                pageNumber ++;
                UpdateControlsDisplay();
                pageNumberTextBox.Text = pageNumber.ToString();
            }
        }
        private void toLastPageButton_Click(object sender, EventArgs e) {
            int lastPage = nodes.Count / (int) nodesPerPageNumUpDown.Value;
            if (nodes.Count % (int) nodesPerPageNumUpDown.Value > 0) lastPage ++;
            if (pageNumber != lastPage) {
                pageNumber = lastPage;
                UpdateControlsDisplay();
                pageNumberTextBox.Text = pageNumber.ToString();
            }
        }
        private void pageNumberTextBox_Enter(object sender, EventArgs e) {
            pageNumberTextBoxInFocus = true;
        }
        private void pageNumberTextBox_Leave(object sender, EventArgs e) {
            pageNumberTextBoxInFocus = false;
            //setPageNumberButton.Visible = false;
            //pageNumberTextBox.Text = pageNumber.ToString();
        }
        private void pageNumberTextBox_TextChanged(object sender, EventArgs e) {
            if (pageNumberTextBoxInFocus) {
                setPageNumberButton.Visible = true;
            }
        }
        private void setPageNumberButton_Click(object sender, EventArgs e) {
            int parsedValue;
            if (Int32.TryParse(pageNumberTextBox.Text, out parsedValue)) {
                pageNumber = parsedValue;
                UpdateControlsDisplay();
                pageNumberTextBox.Text = pageNumber.ToString();
            } else {
                pageNumberTextBox.Text = pageNumber.ToString();
            }
            setPageNumberButton.Visible = false;
        }
        private void nodesPerPageNumUpDown_ValueChanged(object sender, EventArgs e) {
            UpdateControlsDisplay();
        }
    }
}