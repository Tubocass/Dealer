namespace DialogueEditor
{
    partial class NodesRelativeToRootPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolTip toolTip;
            System.Windows.Forms.Panel optionsPanel;
            this.treeDirectionLabel = new System.Windows.Forms.Label();
            this.maxDepthLabel = new System.Windows.Forms.Label();
            this.maxNumberNodesLabel = new System.Windows.Forms.Label();
            this.maxNodesPanel = new System.Windows.Forms.Panel();
            this.maxNumberNodesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxDepthPanel = new System.Windows.Forms.Panel();
            this.maxDepthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.treeDirectionPanel = new System.Windows.Forms.Panel();
            this.treeDirectionComboBox = new System.Windows.Forms.ComboBox();
            this.nodesDisplayPanel = new DialogueEditor.ControlsListPanel();
            toolTip = new System.Windows.Forms.ToolTip(this.components);
            optionsPanel = new System.Windows.Forms.Panel();
            optionsPanel.SuspendLayout();
            this.maxNodesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumberNodesNumericUpDown)).BeginInit();
            this.maxDepthPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthNumericUpDown)).BeginInit();
            this.treeDirectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 15000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            // 
            // treeDirectionLabel
            // 
            this.treeDirectionLabel.AutoSize = true;
            this.treeDirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDirectionLabel.Location = new System.Drawing.Point(3, 3);
            this.treeDirectionLabel.Name = "treeDirectionLabel";
            this.treeDirectionLabel.Size = new System.Drawing.Size(87, 15);
            this.treeDirectionLabel.TabIndex = 1;
            this.treeDirectionLabel.Text = "Tree Direction:";
            toolTip.SetToolTip(this.treeDirectionLabel, "The direction, relative to the root node, in which tree traversal is carried out." +
        "");
            // 
            // maxDepthLabel
            // 
            this.maxDepthLabel.AutoSize = true;
            this.maxDepthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDepthLabel.Location = new System.Drawing.Point(4, 3);
            this.maxDepthLabel.Name = "maxDepthLabel";
            this.maxDepthLabel.Size = new System.Drawing.Size(102, 15);
            this.maxDepthLabel.TabIndex = 3;
            this.maxDepthLabel.Text = "Maximum Depth:";
            toolTip.SetToolTip(this.maxDepthLabel, "The maximum possible depth of the tree derived from the graph.");
            // 
            // maxNumberNodesLabel
            // 
            this.maxNumberNodesLabel.AutoSize = true;
            this.maxNumberNodesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNumberNodesLabel.Location = new System.Drawing.Point(3, 3);
            this.maxNumberNodesLabel.Name = "maxNumberNodesLabel";
            this.maxNumberNodesLabel.Size = new System.Drawing.Size(115, 15);
            this.maxNumberNodesLabel.TabIndex = 0;
            this.maxNumberNodesLabel.Text = "Maximum # Nodes:";
            toolTip.SetToolTip(this.maxNumberNodesLabel, "The maximum number of nodes that will be displayed.");
            // 
            // optionsPanel
            // 
            optionsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            optionsPanel.Controls.Add(this.maxNodesPanel);
            optionsPanel.Controls.Add(this.maxDepthPanel);
            optionsPanel.Controls.Add(this.treeDirectionPanel);
            optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            optionsPanel.Location = new System.Drawing.Point(0, 0);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new System.Drawing.Size(505, 27);
            optionsPanel.TabIndex = 0;
            // 
            // maxNodesPanel
            // 
            this.maxNodesPanel.Controls.Add(this.maxNumberNodesNumericUpDown);
            this.maxNodesPanel.Controls.Add(this.maxNumberNodesLabel);
            this.maxNodesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.maxNodesPanel.Location = new System.Drawing.Point(318, 0);
            this.maxNodesPanel.Name = "maxNodesPanel";
            this.maxNodesPanel.Size = new System.Drawing.Size(165, 27);
            this.maxNodesPanel.TabIndex = 6;
            // 
            // maxNumberNodesNumericUpDown
            // 
            this.maxNumberNodesNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNumberNodesNumericUpDown.Location = new System.Drawing.Point(120, 3);
            this.maxNumberNodesNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.maxNumberNodesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxNumberNodesNumericUpDown.Name = "maxNumberNodesNumericUpDown";
            this.maxNumberNodesNumericUpDown.Size = new System.Drawing.Size(42, 21);
            this.maxNumberNodesNumericUpDown.TabIndex = 1;
            this.maxNumberNodesNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxNumberNodesNumericUpDown.ValueChanged += new System.EventHandler(this.maxNumberNodesNumericUpDown_ValueChanged);
            // 
            // maxDepthPanel
            // 
            this.maxDepthPanel.Controls.Add(this.maxDepthLabel);
            this.maxDepthPanel.Controls.Add(this.maxDepthNumericUpDown);
            this.maxDepthPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.maxDepthPanel.Location = new System.Drawing.Point(171, 0);
            this.maxDepthPanel.Name = "maxDepthPanel";
            this.maxDepthPanel.Size = new System.Drawing.Size(147, 27);
            this.maxDepthPanel.TabIndex = 5;
            // 
            // maxDepthNumericUpDown
            // 
            this.maxDepthNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDepthNumericUpDown.Location = new System.Drawing.Point(108, 3);
            this.maxDepthNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maxDepthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDepthNumericUpDown.Name = "maxDepthNumericUpDown";
            this.maxDepthNumericUpDown.Size = new System.Drawing.Size(35, 21);
            this.maxDepthNumericUpDown.TabIndex = 2;
            this.maxDepthNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxDepthNumericUpDown.ValueChanged += new System.EventHandler(this.maxDepthNumericUpDown_ValueChanged);
            // 
            // treeDirectionPanel
            // 
            this.treeDirectionPanel.Controls.Add(this.treeDirectionLabel);
            this.treeDirectionPanel.Controls.Add(this.treeDirectionComboBox);
            this.treeDirectionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeDirectionPanel.Location = new System.Drawing.Point(0, 0);
            this.treeDirectionPanel.Name = "treeDirectionPanel";
            this.treeDirectionPanel.Size = new System.Drawing.Size(171, 27);
            this.treeDirectionPanel.TabIndex = 4;
            // 
            // treeDirectionComboBox
            // 
            this.treeDirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.treeDirectionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.treeDirectionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDirectionComboBox.FormattingEnabled = true;
            this.treeDirectionComboBox.Items.AddRange(new object[] {
            "Forward",
            "Backward"});
            this.treeDirectionComboBox.Location = new System.Drawing.Point(93, 3);
            this.treeDirectionComboBox.Name = "treeDirectionComboBox";
            this.treeDirectionComboBox.Size = new System.Drawing.Size(75, 21);
            this.treeDirectionComboBox.TabIndex = 0;
            this.treeDirectionComboBox.SelectedValueChanged += new System.EventHandler(this.treeDirectionComboBox_SelectedValueChanged);
            // 
            // nodesDisplayPanel
            // 
            this.nodesDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesDisplayPanel.Location = new System.Drawing.Point(0, 27);
            this.nodesDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.nodesDisplayPanel.Name = "nodesDisplayPanel";
            this.nodesDisplayPanel.Size = new System.Drawing.Size(505, 455);
            this.nodesDisplayPanel.TabIndex = 2;
            // 
            // NodesRelativeToRootPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.nodesDisplayPanel);
            this.Controls.Add(optionsPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NodesRelativeToRootPanel";
            this.Size = new System.Drawing.Size(505, 482);
            optionsPanel.ResumeLayout(false);
            this.maxNodesPanel.ResumeLayout(false);
            this.maxNodesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumberNodesNumericUpDown)).EndInit();
            this.maxDepthPanel.ResumeLayout(false);
            this.maxDepthPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthNumericUpDown)).EndInit();
            this.treeDirectionPanel.ResumeLayout(false);
            this.treeDirectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsListPanel nodesDisplayPanel;
        private System.Windows.Forms.ComboBox treeDirectionComboBox;
        private System.Windows.Forms.Label treeDirectionLabel;
        private System.Windows.Forms.Label maxDepthLabel;
        private System.Windows.Forms.NumericUpDown maxDepthNumericUpDown;
        private System.Windows.Forms.Panel maxDepthPanel;
        private System.Windows.Forms.Panel treeDirectionPanel;
        private System.Windows.Forms.Panel maxNodesPanel;
        private System.Windows.Forms.Label maxNumberNodesLabel;
        private System.Windows.Forms.NumericUpDown maxNumberNodesNumericUpDown;
    }
}
