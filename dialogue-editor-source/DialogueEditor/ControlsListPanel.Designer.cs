namespace DialogueEditor
{
    partial class ControlsListPanel
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
            System.Windows.Forms.Label nodesPerPageLabel;
            System.Windows.Forms.Label pagesLabel;
            System.Windows.Forms.Panel pagePanel;
            System.Windows.Forms.Panel postPageNumberPanel;
            System.Windows.Forms.Panel setPageNumberButtonPanel;
            System.Windows.Forms.Panel pageNumberPanel;
            System.Windows.Forms.Panel prePageNumberPanel;
            this.toLastPageButton = new System.Windows.Forms.Button();
            this.forwardOnePageButton = new System.Windows.Forms.Button();
            this.setPageNumberButton = new System.Windows.Forms.Button();
            this.pageNumberTextBox = new System.Windows.Forms.TextBox();
            this.backOnePageButton = new System.Windows.Forms.Button();
            this.toFirstPageButton = new System.Windows.Forms.Button();
            this.scrollBar = new System.Windows.Forms.VScrollBar();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.widthGuide = new System.Windows.Forms.Panel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.pagesOptionsPanel = new System.Windows.Forms.Panel();
            this.nodesPerPageNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            nodesPerPageLabel = new System.Windows.Forms.Label();
            pagesLabel = new System.Windows.Forms.Label();
            pagePanel = new System.Windows.Forms.Panel();
            postPageNumberPanel = new System.Windows.Forms.Panel();
            setPageNumberButtonPanel = new System.Windows.Forms.Panel();
            pageNumberPanel = new System.Windows.Forms.Panel();
            prePageNumberPanel = new System.Windows.Forms.Panel();
            pagePanel.SuspendLayout();
            postPageNumberPanel.SuspendLayout();
            setPageNumberButtonPanel.SuspendLayout();
            pageNumberPanel.SuspendLayout();
            prePageNumberPanel.SuspendLayout();
            this.flowPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.pagesOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesPerPageNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nodesPerPageLabel
            // 
            nodesPerPageLabel.AutoSize = true;
            nodesPerPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nodesPerPageLabel.Location = new System.Drawing.Point(3, 3);
            nodesPerPageLabel.Name = "nodesPerPageLabel";
            nodesPerPageLabel.Size = new System.Drawing.Size(98, 15);
            nodesPerPageLabel.TabIndex = 1;
            nodesPerPageLabel.Text = "Nodes per page:";
            // 
            // pagesLabel
            // 
            pagesLabel.AutoSize = true;
            pagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pagesLabel.Location = new System.Drawing.Point(4, 3);
            pagesLabel.Name = "pagesLabel";
            pagesLabel.Size = new System.Drawing.Size(39, 15);
            pagesLabel.TabIndex = 2;
            pagesLabel.Text = "Page:";
            // 
            // pagePanel
            // 
            pagePanel.Controls.Add(postPageNumberPanel);
            pagePanel.Controls.Add(setPageNumberButtonPanel);
            pagePanel.Controls.Add(pageNumberPanel);
            pagePanel.Controls.Add(prePageNumberPanel);
            pagePanel.Location = new System.Drawing.Point(144, 0);
            pagePanel.Name = "pagePanel";
            pagePanel.Size = new System.Drawing.Size(360, 25);
            pagePanel.TabIndex = 4;
            // 
            // postPageNumberPanel
            // 
            postPageNumberPanel.Controls.Add(this.toLastPageButton);
            postPageNumberPanel.Controls.Add(this.forwardOnePageButton);
            postPageNumberPanel.Dock = System.Windows.Forms.DockStyle.Left;
            postPageNumberPanel.Location = new System.Drawing.Point(154, 0);
            postPageNumberPanel.Name = "postPageNumberPanel";
            postPageNumberPanel.Size = new System.Drawing.Size(48, 25);
            postPageNumberPanel.TabIndex = 7;
            // 
            // toLastPageButton
            // 
            this.toLastPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toLastPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLastPageButton.Location = new System.Drawing.Point(21, 1);
            this.toLastPageButton.Name = "toLastPageButton";
            this.toLastPageButton.Size = new System.Drawing.Size(26, 23);
            this.toLastPageButton.TabIndex = 2;
            this.toLastPageButton.Text = ">|";
            this.toolTip.SetToolTip(this.toLastPageButton, "Last Page");
            this.toLastPageButton.UseVisualStyleBackColor = true;
            this.toLastPageButton.Click += new System.EventHandler(this.toLastPageButton_Click);
            // 
            // forwardOnePageButton
            // 
            this.forwardOnePageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.forwardOnePageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardOnePageButton.Location = new System.Drawing.Point(2, 1);
            this.forwardOnePageButton.Name = "forwardOnePageButton";
            this.forwardOnePageButton.Size = new System.Drawing.Size(19, 23);
            this.forwardOnePageButton.TabIndex = 1;
            this.forwardOnePageButton.Text = ">";
            this.toolTip.SetToolTip(this.forwardOnePageButton, "Forward One Page");
            this.forwardOnePageButton.UseVisualStyleBackColor = true;
            this.forwardOnePageButton.Click += new System.EventHandler(this.forwardOnePageButton_Click);
            // 
            // setPageNumberButtonPanel
            // 
            setPageNumberButtonPanel.AutoSize = true;
            setPageNumberButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            setPageNumberButtonPanel.Controls.Add(this.setPageNumberButton);
            setPageNumberButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            setPageNumberButtonPanel.Location = new System.Drawing.Point(117, 0);
            setPageNumberButtonPanel.Name = "setPageNumberButtonPanel";
            setPageNumberButtonPanel.Size = new System.Drawing.Size(37, 25);
            setPageNumberButtonPanel.TabIndex = 6;
            // 
            // setPageNumberButton
            // 
            this.setPageNumberButton.BackColor = System.Drawing.Color.Honeydew;
            this.setPageNumberButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setPageNumberButton.Location = new System.Drawing.Point(1, 1);
            this.setPageNumberButton.Name = "setPageNumberButton";
            this.setPageNumberButton.Size = new System.Drawing.Size(33, 23);
            this.setPageNumberButton.TabIndex = 1;
            this.setPageNumberButton.Text = "Go";
            this.toolTip.SetToolTip(this.setPageNumberButton, "Try to Go to Specified Page");
            this.setPageNumberButton.UseVisualStyleBackColor = false;
            this.setPageNumberButton.Visible = false;
            this.setPageNumberButton.Click += new System.EventHandler(this.setPageNumberButton_Click);
            // 
            // pageNumberPanel
            // 
            pageNumberPanel.AutoSize = true;
            pageNumberPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pageNumberPanel.Controls.Add(this.pageNumberTextBox);
            pageNumberPanel.Dock = System.Windows.Forms.DockStyle.Left;
            pageNumberPanel.Location = new System.Drawing.Point(93, 0);
            pageNumberPanel.Name = "pageNumberPanel";
            pageNumberPanel.Size = new System.Drawing.Size(24, 25);
            pageNumberPanel.TabIndex = 5;
            // 
            // pageNumberTextBox
            // 
            this.pageNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageNumberTextBox.Location = new System.Drawing.Point(3, 1);
            this.pageNumberTextBox.MaxLength = 9;
            this.pageNumberTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.pageNumberTextBox.Name = "pageNumberTextBox";
            this.pageNumberTextBox.Size = new System.Drawing.Size(18, 22);
            this.pageNumberTextBox.TabIndex = 3;
            this.pageNumberTextBox.Text = "1";
            this.pageNumberTextBox.TextChanged += new System.EventHandler(this.pageNumberTextBox_TextChanged);
            this.pageNumberTextBox.Enter += new System.EventHandler(this.pageNumberTextBox_Enter);
            this.pageNumberTextBox.Leave += new System.EventHandler(this.pageNumberTextBox_Leave);
            // 
            // prePageNumberPanel
            // 
            prePageNumberPanel.Controls.Add(pagesLabel);
            prePageNumberPanel.Controls.Add(this.backOnePageButton);
            prePageNumberPanel.Controls.Add(this.toFirstPageButton);
            prePageNumberPanel.Dock = System.Windows.Forms.DockStyle.Left;
            prePageNumberPanel.Location = new System.Drawing.Point(0, 0);
            prePageNumberPanel.Name = "prePageNumberPanel";
            prePageNumberPanel.Size = new System.Drawing.Size(93, 25);
            prePageNumberPanel.TabIndex = 4;
            // 
            // backOnePageButton
            // 
            this.backOnePageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backOnePageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOnePageButton.Location = new System.Drawing.Point(73, 1);
            this.backOnePageButton.Name = "backOnePageButton";
            this.backOnePageButton.Size = new System.Drawing.Size(19, 23);
            this.backOnePageButton.TabIndex = 1;
            this.backOnePageButton.Text = "<";
            this.toolTip.SetToolTip(this.backOnePageButton, "Back One Page");
            this.backOnePageButton.UseVisualStyleBackColor = true;
            this.backOnePageButton.Click += new System.EventHandler(this.backOnePageButton_Click);
            // 
            // toFirstPageButton
            // 
            this.toFirstPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toFirstPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toFirstPageButton.Location = new System.Drawing.Point(47, 1);
            this.toFirstPageButton.Name = "toFirstPageButton";
            this.toFirstPageButton.Size = new System.Drawing.Size(26, 23);
            this.toFirstPageButton.TabIndex = 1;
            this.toFirstPageButton.Text = "|<";
            this.toolTip.SetToolTip(this.toFirstPageButton, "First Page");
            this.toFirstPageButton.UseVisualStyleBackColor = true;
            this.toFirstPageButton.Click += new System.EventHandler(this.toFirstPageButton_Click);
            // 
            // scrollBar
            // 
            this.scrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollBar.Location = new System.Drawing.Point(828, 0);
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(17, 523);
            this.scrollBar.TabIndex = 0;
            this.scrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBar_Scroll);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoSize = true;
            this.flowPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowPanel.Controls.Add(this.widthGuide);
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(1, 0);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(700, 4096);
            this.flowPanel.TabIndex = 1;
            this.flowPanel.WrapContents = false;
            // 
            // widthGuide
            // 
            this.widthGuide.Location = new System.Drawing.Point(0, 0);
            this.widthGuide.Margin = new System.Windows.Forms.Padding(0);
            this.widthGuide.Name = "widthGuide";
            this.widthGuide.Size = new System.Drawing.Size(700, 1);
            this.widthGuide.TabIndex = 0;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.flowPanel);
            this.listPanel.Controls.Add(this.scrollBar);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.Location = new System.Drawing.Point(0, 0);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(845, 523);
            this.listPanel.TabIndex = 2;
            this.listPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.listPanel_Layout);
            // 
            // pagesOptionsPanel
            // 
            this.pagesOptionsPanel.Controls.Add(pagePanel);
            this.pagesOptionsPanel.Controls.Add(nodesPerPageLabel);
            this.pagesOptionsPanel.Controls.Add(this.nodesPerPageNumUpDown);
            this.pagesOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagesOptionsPanel.Location = new System.Drawing.Point(0, 523);
            this.pagesOptionsPanel.Name = "pagesOptionsPanel";
            this.pagesOptionsPanel.Size = new System.Drawing.Size(845, 25);
            this.pagesOptionsPanel.TabIndex = 1;
            // 
            // nodesPerPageNumUpDown
            // 
            this.nodesPerPageNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodesPerPageNumUpDown.Location = new System.Drawing.Point(103, 2);
            this.nodesPerPageNumUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nodesPerPageNumUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nodesPerPageNumUpDown.Name = "nodesPerPageNumUpDown";
            this.nodesPerPageNumUpDown.Size = new System.Drawing.Size(35, 21);
            this.nodesPerPageNumUpDown.TabIndex = 1;
            this.nodesPerPageNumUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nodesPerPageNumUpDown.ValueChanged += new System.EventHandler(this.nodesPerPageNumUpDown_ValueChanged);
            // 
            // ControlsListPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.pagesOptionsPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlsListPanel";
            this.Size = new System.Drawing.Size(845, 548);
            pagePanel.ResumeLayout(false);
            pagePanel.PerformLayout();
            postPageNumberPanel.ResumeLayout(false);
            setPageNumberButtonPanel.ResumeLayout(false);
            pageNumberPanel.ResumeLayout(false);
            pageNumberPanel.PerformLayout();
            prePageNumberPanel.ResumeLayout(false);
            prePageNumberPanel.PerformLayout();
            this.flowPanel.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.pagesOptionsPanel.ResumeLayout(false);
            this.pagesOptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesPerPageNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrollBar;
        private System.Windows.Forms.Panel widthGuide;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Panel pagesOptionsPanel;
        private System.Windows.Forms.NumericUpDown nodesPerPageNumUpDown;
        private System.Windows.Forms.TextBox pageNumberTextBox;
        private System.Windows.Forms.Button toFirstPageButton;
        private System.Windows.Forms.Button backOnePageButton;
        private System.Windows.Forms.Button setPageNumberButton;
        private System.Windows.Forms.Button forwardOnePageButton;
        private System.Windows.Forms.Button toLastPageButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
