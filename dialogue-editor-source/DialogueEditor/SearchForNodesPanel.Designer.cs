namespace DialogueEditor
{
    partial class SearchForNodesPanel
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
            System.Windows.Forms.Label searchInLabel;
            System.Windows.Forms.Label patternLabel;
            System.Windows.Forms.Panel optionsPanel;
            this.wholeWordCheckBox = new System.Windows.Forms.CheckBox();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.patternTextBox = new System.Windows.Forms.TextBox();
            this.lookInDropDownList = new System.Windows.Forms.ComboBox();
            this.nodesDisplayPanel = new DialogueEditor.ControlsListPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            searchInLabel = new System.Windows.Forms.Label();
            patternLabel = new System.Windows.Forms.Label();
            optionsPanel = new System.Windows.Forms.Panel();
            optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchInLabel
            // 
            searchInLabel.AutoSize = true;
            searchInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            searchInLabel.Location = new System.Drawing.Point(4, 5);
            searchInLabel.Name = "searchInLabel";
            searchInLabel.Size = new System.Drawing.Size(47, 15);
            searchInLabel.TabIndex = 6;
            searchInLabel.Text = "Look in";
            this.toolTip.SetToolTip(searchInLabel, "The data items in each node that will be searched for the query string");
            // 
            // patternLabel
            // 
            patternLabel.AutoSize = true;
            patternLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            patternLabel.Location = new System.Drawing.Point(4, 29);
            patternLabel.Name = "patternLabel";
            patternLabel.Size = new System.Drawing.Size(49, 15);
            patternLabel.TabIndex = 1;
            patternLabel.Text = "Pattern:";
            this.toolTip.SetToolTip(patternLabel, "Enter a search pattern");
            // 
            // optionsPanel
            // 
            optionsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            optionsPanel.Controls.Add(searchInLabel);
            optionsPanel.Controls.Add(this.wholeWordCheckBox);
            optionsPanel.Controls.Add(this.matchCaseCheckBox);
            optionsPanel.Controls.Add(this.searchButton);
            optionsPanel.Controls.Add(this.patternTextBox);
            optionsPanel.Controls.Add(patternLabel);
            optionsPanel.Controls.Add(this.lookInDropDownList);
            optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            optionsPanel.Location = new System.Drawing.Point(0, 0);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new System.Drawing.Size(496, 52);
            optionsPanel.TabIndex = 0;
            // 
            // wholeWordCheckBox
            // 
            this.wholeWordCheckBox.AutoSize = true;
            this.wholeWordCheckBox.Location = new System.Drawing.Point(367, 5);
            this.wholeWordCheckBox.Name = "wholeWordCheckBox";
            this.wholeWordCheckBox.Size = new System.Drawing.Size(113, 17);
            this.wholeWordCheckBox.TabIndex = 5;
            this.wholeWordCheckBox.Text = "Match whole word";
            this.wholeWordCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Checked = true;
            this.matchCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(271, 5);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(82, 17);
            this.matchCaseCheckBox.TabIndex = 4;
            this.matchCaseCheckBox.Text = "Match case";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Location = new System.Drawing.Point(423, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(69, 21);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // patternTextBox
            // 
            this.patternTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternTextBox.Location = new System.Drawing.Point(55, 28);
            this.patternTextBox.Name = "patternTextBox";
            this.patternTextBox.Size = new System.Drawing.Size(363, 20);
            this.patternTextBox.TabIndex = 2;
            // 
            // lookInDropDownList
            // 
            this.lookInDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lookInDropDownList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lookInDropDownList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookInDropDownList.FormattingEnabled = true;
            this.lookInDropDownList.Items.AddRange(new object[] {
            "NPC text",
            "User Text",
            "Both player and NPC text"});
            this.lookInDropDownList.Location = new System.Drawing.Point(55, 3);
            this.lookInDropDownList.Name = "lookInDropDownList";
            this.lookInDropDownList.Size = new System.Drawing.Size(175, 21);
            this.lookInDropDownList.TabIndex = 0;
            // 
            // nodesDisplayPanel
            // 
            this.nodesDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesDisplayPanel.Location = new System.Drawing.Point(0, 52);
            this.nodesDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.nodesDisplayPanel.Name = "nodesDisplayPanel";
            this.nodesDisplayPanel.Size = new System.Drawing.Size(496, 430);
            this.nodesDisplayPanel.TabIndex = 1;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 15000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // SearchForNodesPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.nodesDisplayPanel);
            this.Controls.Add(optionsPanel);
            this.Name = "SearchForNodesPanel";
            this.Size = new System.Drawing.Size(496, 482);
            optionsPanel.ResumeLayout(false);
            optionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsListPanel nodesDisplayPanel;
        private System.Windows.Forms.ComboBox lookInDropDownList;
        private System.Windows.Forms.TextBox patternTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox wholeWordCheckBox;
        private System.Windows.Forms.CheckBox matchCaseCheckBox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
