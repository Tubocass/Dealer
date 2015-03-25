using System.Windows.Forms;

namespace DialogueEditor
{
    partial class NodeEditPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
            this.nodeHeaderLabel = new System.Windows.Forms.Label();
            this.nodeHeadPanel = new System.Windows.Forms.Panel();
            this.npcTextLabel = new System.Windows.Forms.Label();
            this.npcTextPanel = new System.Windows.Forms.Panel();
            this.npcTextBox = new System.Windows.Forms.TextBox();
            this.choicesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.choicesFlowLayoutPanelWidthGuide = new System.Windows.Forms.Panel();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.addChoiceButton = new System.Windows.Forms.Button();
            this.makeNodeRootButton = new System.Windows.Forms.Button();
            this.minimiseNodeButton = new System.Windows.Forms.Button();
            this.deleteNodeButton = new System.Windows.Forms.Button();
            this.nodeHeadPanel.SuspendLayout();
            this.npcTextPanel.SuspendLayout();
            this.choicesFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeHeaderLabel
            // 
            this.nodeHeaderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.nodeHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeHeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.nodeHeaderLabel.Margin = new System.Windows.Forms.Padding(3);
            this.nodeHeaderLabel.Name = "nodeHeaderLabel";
            this.nodeHeaderLabel.Padding = new System.Windows.Forms.Padding(3);
            this.nodeHeaderLabel.Size = new System.Drawing.Size(662, 20);
            this.nodeHeaderLabel.TabIndex = 0;
            this.nodeHeaderLabel.Text = "\"Root Node\" + NodeID || \"Node\" + NodeID";
            // 
            // nodeHeadPanel
            // 
            this.nodeHeadPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nodeHeadPanel.Controls.Add(this.makeNodeRootButton);
            this.nodeHeadPanel.Controls.Add(this.minimiseNodeButton);
            this.nodeHeadPanel.Controls.Add(this.deleteNodeButton);
            this.nodeHeadPanel.Controls.Add(this.nodeHeaderLabel);
            this.nodeHeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nodeHeadPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeHeadPanel.Location = new System.Drawing.Point(0, 0);
            this.nodeHeadPanel.Name = "nodeHeadPanel";
            this.nodeHeadPanel.Size = new System.Drawing.Size(662, 20);
            this.nodeHeadPanel.TabIndex = 1;
            // 
            // npcTextLabel
            // 
            this.npcTextLabel.AutoSize = true;
            this.npcTextLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.npcTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcTextLabel.Location = new System.Drawing.Point(3, 3);
            this.npcTextLabel.Margin = new System.Windows.Forms.Padding(0);
            this.npcTextLabel.Name = "npcTextLabel";
            this.npcTextLabel.Padding = new System.Windows.Forms.Padding(1);
            this.npcTextLabel.Size = new System.Drawing.Size(42, 38);
            this.npcTextLabel.TabIndex = 2;
            this.npcTextLabel.Text = "NPC\r\nText:";
            // 
            // npcTextPanel
            // 
            this.npcTextPanel.AutoSize = true;
            this.npcTextPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.npcTextPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.npcTextPanel.Controls.Add(this.npcTextBox);
            this.npcTextPanel.Controls.Add(this.npcTextLabel);
            this.npcTextPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.npcTextPanel.Location = new System.Drawing.Point(0, 20);
            this.npcTextPanel.Name = "npcTextPanel";
            this.npcTextPanel.Padding = new System.Windows.Forms.Padding(3);
            this.npcTextPanel.Size = new System.Drawing.Size(662, 44);
            this.npcTextPanel.TabIndex = 3;
            // 
            // npcTextBox
            // 
            this.npcTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.npcTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcTextBox.Location = new System.Drawing.Point(45, 3);
            this.npcTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.npcTextBox.MinimumSize = new System.Drawing.Size(0, 38);
            this.npcTextBox.Multiline = true;
            this.npcTextBox.Name = "npcTextBox";
            this.npcTextBox.Size = new System.Drawing.Size(614, 38);
            this.npcTextBox.TabIndex = 3;
            this.npcTextBox.TextChanged += new System.EventHandler(this.npcTextBox_TextChanged);
            this.npcTextBox.Enter += new System.EventHandler(this.npcTextBox_Enter);
            this.npcTextBox.Leave += new System.EventHandler(this.npcTextBox_Leave);
            // 
            // choicesFlowLayoutPanel
            // 
            this.choicesFlowLayoutPanel.AutoSize = true;
            this.choicesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.choicesFlowLayoutPanel.Controls.Add(this.choicesFlowLayoutPanelWidthGuide);
            this.choicesFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.choicesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.choicesFlowLayoutPanel.Location = new System.Drawing.Point(0, 64);
            this.choicesFlowLayoutPanel.MinimumSize = new System.Drawing.Size(0, 2);
            this.choicesFlowLayoutPanel.Name = "choicesFlowLayoutPanel";
            this.choicesFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.choicesFlowLayoutPanel.Size = new System.Drawing.Size(662, 6);
            this.choicesFlowLayoutPanel.TabIndex = 5;
            this.choicesFlowLayoutPanel.WrapContents = false;
            this.choicesFlowLayoutPanel.SizeChanged += new System.EventHandler(this.ChoicesFlowLayoutPanel_SizeChanged);
            this.choicesFlowLayoutPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.choicesFlowLayoutPanel_ControlAdded);
            this.choicesFlowLayoutPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.choicesFlowLayoutPanel_ControlRemoved);
            // 
            // choicesFlowLayoutPanelWidthGuide
            // 
            this.choicesFlowLayoutPanelWidthGuide.Location = new System.Drawing.Point(0, 3);
            this.choicesFlowLayoutPanelWidthGuide.Margin = new System.Windows.Forms.Padding(0);
            this.choicesFlowLayoutPanelWidthGuide.Name = "choicesFlowLayoutPanelWidthGuide";
            this.choicesFlowLayoutPanelWidthGuide.Size = new System.Drawing.Size(500, 0);
            this.choicesFlowLayoutPanelWidthGuide.TabIndex = 0;
            // 
            // toolTips
            // 
            this.toolTips.AutoPopDelay = 15000;
            this.toolTips.InitialDelay = 500;
            this.toolTips.ReshowDelay = 100;
            // 
            // addChoiceButton
            // 
            this.addChoiceButton.BackColor = System.Drawing.Color.Honeydew;
            this.addChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addChoiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.addChoiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addChoiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.addChoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addChoiceButton.Image = global::DialogueEditor.Properties.Resources.AddChoiceButton2;
            this.addChoiceButton.Location = new System.Drawing.Point(0, 70);
            this.addChoiceButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.addChoiceButton.Name = "addChoiceButton";
            this.addChoiceButton.Size = new System.Drawing.Size(662, 14);
            this.addChoiceButton.TabIndex = 6;
            this.toolTips.SetToolTip(this.addChoiceButton, "Add a New Choice to This Node");
            this.addChoiceButton.UseVisualStyleBackColor = false;
            this.addChoiceButton.Click += new System.EventHandler(this.addChoiceButton_Click);
            // 
            // makeNodeRootButton
            // 
            this.makeNodeRootButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.makeNodeRootButton.BackgroundImage = global::DialogueEditor.Properties.Resources.MakeNodeRootButton1;
            this.makeNodeRootButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.makeNodeRootButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.makeNodeRootButton.Location = new System.Drawing.Point(602, 0);
            this.makeNodeRootButton.Name = "makeNodeRootButton";
            this.makeNodeRootButton.Size = new System.Drawing.Size(20, 20);
            this.makeNodeRootButton.TabIndex = 5;
            this.toolTips.SetToolTip(this.makeNodeRootButton, "Make This Node the Root Node");
            this.makeNodeRootButton.UseVisualStyleBackColor = false;
            this.makeNodeRootButton.Click += new System.EventHandler(this.makeNodeRootButton_Click);
            // 
            // minimiseNodeButton
            // 
            this.minimiseNodeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.minimiseNodeButton.BackgroundImage = global::DialogueEditor.Properties.Resources.MinimiseButton1;
            this.minimiseNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimiseNodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimiseNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimiseNodeButton.Location = new System.Drawing.Point(622, 0);
            this.minimiseNodeButton.Name = "minimiseNodeButton";
            this.minimiseNodeButton.Size = new System.Drawing.Size(20, 20);
            this.minimiseNodeButton.TabIndex = 4;
            this.toolTips.SetToolTip(this.minimiseNodeButton, "Minimise Node");
            this.minimiseNodeButton.UseVisualStyleBackColor = false;
            this.minimiseNodeButton.Click += new System.EventHandler(this.minimiseButton_Click);
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.BackColor = System.Drawing.Color.Red;
            this.deleteNodeButton.BackgroundImage = global::DialogueEditor.Properties.Resources.DeleteButton1;
            this.deleteNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deleteNodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteNodeButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.deleteNodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.deleteNodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.deleteNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteNodeButton.Location = new System.Drawing.Point(642, 0);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(20, 20);
            this.deleteNodeButton.TabIndex = 1;
            this.toolTips.SetToolTip(this.deleteNodeButton, "Delete Node");
            this.deleteNodeButton.UseVisualStyleBackColor = false;
            this.deleteNodeButton.Click += new System.EventHandler(this.deleteNodeButton_Click);
            // 
            // NodeEditPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.addChoiceButton);
            this.Controls.Add(this.choicesFlowLayoutPanel);
            this.Controls.Add(this.npcTextPanel);
            this.Controls.Add(this.nodeHeadPanel);
            this.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Name = "NodeEditPanel";
            this.Size = new System.Drawing.Size(662, 114);
            this.Load += new System.EventHandler(this.NodeEditPanel_Load);
            this.nodeHeadPanel.ResumeLayout(false);
            this.npcTextPanel.ResumeLayout(false);
            this.npcTextPanel.PerformLayout();
            this.choicesFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nodeHeaderLabel;
        private System.Windows.Forms.Panel nodeHeadPanel;
        private System.Windows.Forms.Button deleteNodeButton;
        private System.Windows.Forms.Label npcTextLabel;
        private System.Windows.Forms.Panel npcTextPanel;
        private System.Windows.Forms.TextBox npcTextBox;
        private System.Windows.Forms.FlowLayoutPanel choicesFlowLayoutPanel;
        private System.Windows.Forms.Button addChoiceButton;
        private System.Windows.Forms.Panel choicesFlowLayoutPanelWidthGuide;
        private System.Windows.Forms.Button minimiseNodeButton;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button makeNodeRootButton;


    }
}
