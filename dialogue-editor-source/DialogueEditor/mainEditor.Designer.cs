using i00SpellCheck;

namespace DialogueEditor
{
    partial class mainEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainEditor));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanelNodeDisplay = new DialogueEditor.ControlsListPanel();
            this.rightPanelTabControl = new System.Windows.Forms.TabControl();
            this.nodesRalativeToRootTab = new System.Windows.Forms.TabPage();
            this.nodesRelativeToRootPanel = new DialogueEditor.NodesRelativeToRootPanel();
            this.searchForNodesTab = new System.Windows.Forms.TabPage();
            this.searchForNodesPanel = new DialogueEditor.SearchForNodesPanel();
            this.listNodesTab = new System.Windows.Forms.TabPage();
            this.listNodesPanel = new DialogueEditor.ListNodesPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fileTopStripMenuDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNewTopMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenTopMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveTopMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsTopMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitTopMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.addTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNodeMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.debugSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.rightPanelTabControl.SuspendLayout();
            this.nodesRalativeToRootTab.SuspendLayout();
            this.searchForNodesTab.SuspendLayout();
            this.listNodesTab.SuspendLayout();
            this.topMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.leftPanelNodeDisplay);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer.Panel2.Controls.Add(this.rightPanelTabControl);
            // 
            // leftPanelNodeDisplay
            // 
            this.leftPanelNodeDisplay.DisplayingPageControlPanel = true;
            resources.ApplyResources(this.leftPanelNodeDisplay, "leftPanelNodeDisplay");
            this.leftPanelNodeDisplay.Name = "leftPanelNodeDisplay";
            // 
            // rightPanelTabControl
            // 
            this.rightPanelTabControl.Controls.Add(this.nodesRalativeToRootTab);
            this.rightPanelTabControl.Controls.Add(this.searchForNodesTab);
            this.rightPanelTabControl.Controls.Add(this.listNodesTab);
            resources.ApplyResources(this.rightPanelTabControl, "rightPanelTabControl");
            this.rightPanelTabControl.Name = "rightPanelTabControl";
            this.rightPanelTabControl.SelectedIndex = 0;
            this.rightPanelTabControl.SelectedIndexChanged += new System.EventHandler(this.rightPanelTabControl_SelectedIndexChanged);
            // 
            // nodesRalativeToRootTab
            // 
            this.nodesRalativeToRootTab.Controls.Add(this.nodesRelativeToRootPanel);
            resources.ApplyResources(this.nodesRalativeToRootTab, "nodesRalativeToRootTab");
            this.nodesRalativeToRootTab.Name = "nodesRalativeToRootTab";
            this.nodesRalativeToRootTab.UseVisualStyleBackColor = true;
            // 
            // nodesRelativeToRootPanel
            // 
            resources.ApplyResources(this.nodesRelativeToRootPanel, "nodesRelativeToRootPanel");
            this.nodesRelativeToRootPanel.Name = "nodesRelativeToRootPanel";
            // 
            // searchForNodesTab
            // 
            this.searchForNodesTab.Controls.Add(this.searchForNodesPanel);
            resources.ApplyResources(this.searchForNodesTab, "searchForNodesTab");
            this.searchForNodesTab.Name = "searchForNodesTab";
            this.searchForNodesTab.UseVisualStyleBackColor = true;
            // 
            // searchForNodesPanel
            // 
            resources.ApplyResources(this.searchForNodesPanel, "searchForNodesPanel");
            this.searchForNodesPanel.Name = "searchForNodesPanel";
            // 
            // listNodesTab
            // 
            this.listNodesTab.Controls.Add(this.listNodesPanel);
            resources.ApplyResources(this.listNodesTab, "listNodesTab");
            this.listNodesTab.Name = "listNodesTab";
            this.listNodesTab.UseVisualStyleBackColor = true;
            // 
            // listNodesPanel
            // 
            resources.ApplyResources(this.listNodesPanel, "listNodesPanel");
            this.listNodesPanel.Name = "listNodesPanel";
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // fileTopStripMenuDropDown
            // 
            this.fileTopStripMenuDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewTopMenuButton,
            this.fileOpenTopMenuButton,
            this.fileSaveTopMenuButton,
            this.fileSaveAsTopMenuButton,
            this.toolStripSeparator1,
            this.fileExitTopMenuButton});
            this.fileTopStripMenuDropDown.Name = "fileTopStripMenuDropDown";
            resources.ApplyResources(this.fileTopStripMenuDropDown, "fileTopStripMenuDropDown");
            this.fileTopStripMenuDropDown.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // fileNewTopMenuButton
            // 
            this.fileNewTopMenuButton.Name = "fileNewTopMenuButton";
            resources.ApplyResources(this.fileNewTopMenuButton, "fileNewTopMenuButton");
            this.fileNewTopMenuButton.Click += new System.EventHandler(this.fileNewTopMenuButton_Click);
            // 
            // fileOpenTopMenuButton
            // 
            this.fileOpenTopMenuButton.Name = "fileOpenTopMenuButton";
            resources.ApplyResources(this.fileOpenTopMenuButton, "fileOpenTopMenuButton");
            this.fileOpenTopMenuButton.Click += new System.EventHandler(this.fileOpenTopMenuButton_Click);
            // 
            // fileSaveTopMenuButton
            // 
            this.fileSaveTopMenuButton.Name = "fileSaveTopMenuButton";
            resources.ApplyResources(this.fileSaveTopMenuButton, "fileSaveTopMenuButton");
            this.fileSaveTopMenuButton.Click += new System.EventHandler(this.fileSaveTopMenuButton_Click);
            // 
            // fileSaveAsTopMenuButton
            // 
            this.fileSaveAsTopMenuButton.Name = "fileSaveAsTopMenuButton";
            resources.ApplyResources(this.fileSaveAsTopMenuButton, "fileSaveAsTopMenuButton");
            this.fileSaveAsTopMenuButton.Click += new System.EventHandler(this.fileSaveAsMenuTopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // fileExitTopMenuButton
            // 
            this.fileExitTopMenuButton.Name = "fileExitTopMenuButton";
            resources.ApplyResources(this.fileExitTopMenuButton, "fileExitTopMenuButton");
            this.fileExitTopMenuButton.Click += new System.EventHandler(this.fileExitTopMenuButton_Click);
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTopStripMenuDropDown,
            this.addTopToolStripMenuItem});
            this.topMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.topMenuStrip, "topMenuStrip");
            this.topMenuStrip.Name = "topMenuStrip";
            // 
            // addTopToolStripMenuItem
            // 
            this.addTopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeMenuButton});
            this.addTopToolStripMenuItem.Name = "addTopToolStripMenuItem";
            resources.ApplyResources(this.addTopToolStripMenuItem, "addTopToolStripMenuItem");
            // 
            // addNodeMenuButton
            // 
            this.addNodeMenuButton.Name = "addNodeMenuButton";
            resources.ApplyResources(this.addNodeMenuButton, "addNodeMenuButton");
            this.addNodeMenuButton.Click += new System.EventHandler(this.addNodeMenuButton_Click);
            // 
            // mainEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.topMenuStrip);
            this.MainMenuStrip = this.topMenuStrip;
            this.Name = "mainEditor";
            this.TransparencyKey = System.Drawing.Color.Aqua;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainEditor_FormClosing);
            this.Load += new System.EventHandler(this.mainEditor_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.rightPanelTabControl.ResumeLayout(false);
            this.nodesRalativeToRootTab.ResumeLayout(false);
            this.searchForNodesTab.ResumeLayout(false);
            this.listNodesTab.ResumeLayout(false);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem fileTopStripMenuDropDown;
        private System.Windows.Forms.ToolStripMenuItem fileOpenTopMenuButton;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsTopMenuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileExitTopMenuButton;
        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileNewTopMenuButton;
        private System.Windows.Forms.ToolStripMenuItem fileSaveTopMenuButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ControlsListPanel leftPanelNodeDisplay;
        private System.Windows.Forms.SaveFileDialog debugSaveFileDialog;
        private System.Windows.Forms.TabControl rightPanelTabControl;
        private System.Windows.Forms.TabPage nodesRalativeToRootTab;
        private System.Windows.Forms.TabPage searchForNodesTab;
        private NodesRelativeToRootPanel nodesRelativeToRootPanel;
        private SearchForNodesPanel searchForNodesPanel;
        private System.Windows.Forms.TabPage listNodesTab;
        private ListNodesPanel listNodesPanel;
        private System.Windows.Forms.ToolStripMenuItem addTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNodeMenuButton;
    }
}

