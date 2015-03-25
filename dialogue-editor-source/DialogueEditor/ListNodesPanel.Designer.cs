namespace DialogueEditor
{
    partial class ListNodesPanel
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
            System.Windows.Forms.Label orderByLabel;
            System.Windows.Forms.Label listLabel;
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.numberOfNodesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.listDropDownList = new System.Windows.Forms.ComboBox();
            this.orderByDropDownList = new System.Windows.Forms.ComboBox();
            this.nodesDisplayPanel = new DialogueEditor.ControlsListPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            orderByLabel = new System.Windows.Forms.Label();
            listLabel = new System.Windows.Forms.Label();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfNodesNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // orderByLabel
            // 
            orderByLabel.AutoSize = true;
            orderByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            orderByLabel.Location = new System.Drawing.Point(3, 4);
            orderByLabel.Name = "orderByLabel";
            orderByLabel.Size = new System.Drawing.Size(56, 15);
            orderByLabel.TabIndex = 0;
            orderByLabel.Text = "Order by:";
            this.toolTip.SetToolTip(orderByLabel, "How the nodes will be ordered");
            // 
            // listLabel
            // 
            listLabel.AutoSize = true;
            listLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listLabel.Location = new System.Drawing.Point(209, 4);
            listLabel.Name = "listLabel";
            listLabel.Size = new System.Drawing.Size(29, 15);
            listLabel.TabIndex = 2;
            listLabel.Text = "List:";
            this.toolTip.SetToolTip(listLabel, "Number of nodes to list");
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.optionsPanel.Controls.Add(this.numberOfNodesNumUpDown);
            this.optionsPanel.Controls.Add(this.listDropDownList);
            this.optionsPanel.Controls.Add(listLabel);
            this.optionsPanel.Controls.Add(this.orderByDropDownList);
            this.optionsPanel.Controls.Add(orderByLabel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(496, 27);
            this.optionsPanel.TabIndex = 0;
            // 
            // numberOfNodesNumUpDown
            // 
            this.numberOfNodesNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfNodesNumUpDown.Location = new System.Drawing.Point(402, 3);
            this.numberOfNodesNumUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numberOfNodesNumUpDown.Name = "numberOfNodesNumUpDown";
            this.numberOfNodesNumUpDown.Size = new System.Drawing.Size(57, 21);
            this.numberOfNodesNumUpDown.TabIndex = 4;
            this.toolTip.SetToolTip(this.numberOfNodesNumUpDown, "Specify maximum number of nodes to list");
            this.numberOfNodesNumUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numberOfNodesNumUpDown.ValueChanged += new System.EventHandler(this.numberOfNodesNumUpDown_ValueChanged);
            // 
            // listDropDownList
            // 
            this.listDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listDropDownList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listDropDownList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDropDownList.FormattingEnabled = true;
            this.listDropDownList.Items.AddRange(new object[] {
            "All Nodes",
            "Specific number of nodes:"});
            this.listDropDownList.Location = new System.Drawing.Point(242, 3);
            this.listDropDownList.Name = "listDropDownList";
            this.listDropDownList.Size = new System.Drawing.Size(154, 21);
            this.listDropDownList.TabIndex = 3;
            this.listDropDownList.SelectionChangeCommitted += new System.EventHandler(this.listDropDownList_SelectionChangeCommitted);
            // 
            // orderByDropDownList
            // 
            this.orderByDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderByDropDownList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderByDropDownList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderByDropDownList.FormattingEnabled = true;
            this.orderByDropDownList.Items.AddRange(new object[] {
            "Node ID (Base 64)",
            "NPC Text (Alphabetical)",
            "Number of Choices"});
            this.orderByDropDownList.Location = new System.Drawing.Point(63, 3);
            this.orderByDropDownList.Name = "orderByDropDownList";
            this.orderByDropDownList.Size = new System.Drawing.Size(142, 21);
            this.orderByDropDownList.TabIndex = 1;
            this.orderByDropDownList.SelectionChangeCommitted += new System.EventHandler(this.orderByDropDownList_SelectionChangeCommitted);
            // 
            // nodesDisplayPanel
            // 
            this.nodesDisplayPanel.DisplayingPageControlPanel = true;
            this.nodesDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesDisplayPanel.Location = new System.Drawing.Point(0, 27);
            this.nodesDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.nodesDisplayPanel.Name = "nodesDisplayPanel";
            this.nodesDisplayPanel.Size = new System.Drawing.Size(496, 471);
            this.nodesDisplayPanel.TabIndex = 1;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 15000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // ListNodesPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.nodesDisplayPanel);
            this.Controls.Add(this.optionsPanel);
            this.Name = "ListNodesPanel";
            this.Size = new System.Drawing.Size(496, 498);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfNodesNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel optionsPanel;
        private ControlsListPanel nodesDisplayPanel;
        private System.Windows.Forms.ComboBox orderByDropDownList;
        private System.Windows.Forms.ComboBox listDropDownList;
        private System.Windows.Forms.NumericUpDown numberOfNodesNumUpDown;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
