using System.Windows.Forms;
namespace DialogueEditor
{
    partial class ChoiceEditPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.  
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)  {
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
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.targetNodeIDValueTextBox = new System.Windows.Forms.TextBox();
            this.makeTargetNewRootNodeButton = new System.Windows.Forms.Button();
            this.makeTargetNewNodeButton = new System.Windows.Forms.Button();
            this.minimiseChoiceButton = new System.Windows.Forms.Button();
            this.deleteChoiceButton = new System.Windows.Forms.Button();
            this.choiceHeaderPanel = new System.Windows.Forms.Panel();
            this.ChoiceNumberLabel = new System.Windows.Forms.Label();
            this.playerTextPanel = new System.Windows.Forms.Panel();
            this.playerTextBox = new System.Windows.Forms.TextBox();
            this.playerTextLabel = new System.Windows.Forms.Label();
            this.targetNodePanel = new System.Windows.Forms.Panel();
            this.targetNodeIDTextBoxFeedback = new System.Windows.Forms.Label();
            this.targetNodeIDLabel = new System.Windows.Forms.Label();
            this.choiceHeaderPanel.SuspendLayout();
            this.playerTextPanel.SuspendLayout();
            this.targetNodePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTips
            // 
            this.toolTips.AutoPopDelay = 15000;
            this.toolTips.InitialDelay = 500;
            this.toolTips.ReshowDelay = 100;
            // 
            // targetNodeIDValueTextBox
            // 
            this.targetNodeIDValueTextBox.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetNodeIDValueTextBox.Location = new System.Drawing.Point(96, 1);
            this.targetNodeIDValueTextBox.MaxLength = 6;
            this.targetNodeIDValueTextBox.Name = "targetNodeIDValueTextBox";
            this.targetNodeIDValueTextBox.Size = new System.Drawing.Size(48, 21);
            this.targetNodeIDValueTextBox.TabIndex = 5;
            this.targetNodeIDValueTextBox.Text = "null";
            this.targetNodeIDValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTips.SetToolTip(this.targetNodeIDValueTextBox, "Displays and Sets the Target Node\'s ID.");
            this.targetNodeIDValueTextBox.TextChanged += new System.EventHandler(this.targetNodeIDValueTextBox_TextChanged);
            this.targetNodeIDValueTextBox.Leave += new System.EventHandler(this.targetNodeIDValueTextBox_Leave);
            // 
            // makeTargetNewRootNodeButton
            // 
            this.makeTargetNewRootNodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.makeTargetNewRootNodeButton.BackgroundImage = global::DialogueEditor.Properties.Resources.AddTargetAsRootNodeButton;
            this.makeTargetNewRootNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.makeTargetNewRootNodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.makeTargetNewRootNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.makeTargetNewRootNodeButton.Location = new System.Drawing.Point(398, 0);
            this.makeTargetNewRootNodeButton.Name = "makeTargetNewRootNodeButton";
            this.makeTargetNewRootNodeButton.Size = new System.Drawing.Size(40, 20);
            this.makeTargetNewRootNodeButton.TabIndex = 3;
            this.toolTips.SetToolTip(this.makeTargetNewRootNodeButton, "Set Target to New Node and Make That The Root Node");
            this.makeTargetNewRootNodeButton.UseVisualStyleBackColor = false;
            this.makeTargetNewRootNodeButton.Click += new System.EventHandler(this.makeTargetNewRootNode_Click);
            // 
            // makeTargetNewNodeButton
            // 
            this.makeTargetNewNodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.makeTargetNewNodeButton.BackgroundImage = global::DialogueEditor.Properties.Resources.AddTargetNodeButton;
            this.makeTargetNewNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.makeTargetNewNodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.makeTargetNewNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.makeTargetNewNodeButton.Location = new System.Drawing.Point(438, 0);
            this.makeTargetNewNodeButton.Name = "makeTargetNewNodeButton";
            this.makeTargetNewNodeButton.Size = new System.Drawing.Size(40, 20);
            this.makeTargetNewNodeButton.TabIndex = 2;
            this.toolTips.SetToolTip(this.makeTargetNewNodeButton, "Set Target To New Node");
            this.makeTargetNewNodeButton.UseVisualStyleBackColor = false;
            this.makeTargetNewNodeButton.Click += new System.EventHandler(this.makeTargetNewNodeButton_Click);
            // 
            // minimiseChoiceButton
            // 
            this.minimiseChoiceButton.BackColor = System.Drawing.Color.SteelBlue;
            this.minimiseChoiceButton.BackgroundImage = global::DialogueEditor.Properties.Resources.MinimiseButton2;
            this.minimiseChoiceButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.minimiseChoiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.minimiseChoiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.minimiseChoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimiseChoiceButton.Location = new System.Drawing.Point(16, 0);
            this.minimiseChoiceButton.Name = "minimiseChoiceButton";
            this.minimiseChoiceButton.Size = new System.Drawing.Size(16, 16);
            this.minimiseChoiceButton.TabIndex = 2;
            this.minimiseChoiceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTips.SetToolTip(this.minimiseChoiceButton, "Minimise choice");
            this.minimiseChoiceButton.UseVisualStyleBackColor = false;
            this.minimiseChoiceButton.Click += new System.EventHandler(this.minimiseChoiceButton_Click);
            // 
            // deleteChoiceButton
            // 
            this.deleteChoiceButton.BackColor = System.Drawing.Color.Red;
            this.deleteChoiceButton.BackgroundImage = global::DialogueEditor.Properties.Resources.DeleteButton2;
            this.deleteChoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteChoiceButton.Location = new System.Drawing.Point(0, 0);
            this.deleteChoiceButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteChoiceButton.Name = "deleteChoiceButton";
            this.deleteChoiceButton.Size = new System.Drawing.Size(16, 16);
            this.deleteChoiceButton.TabIndex = 1;
            this.toolTips.SetToolTip(this.deleteChoiceButton, "Delete choice");
            this.deleteChoiceButton.UseVisualStyleBackColor = false;
            this.deleteChoiceButton.Click += new System.EventHandler(this.deleteChoiceButton_Click);
            // 
            // choiceHeaderPanel
            // 
            this.choiceHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.choiceHeaderPanel.Controls.Add(this.minimiseChoiceButton);
            this.choiceHeaderPanel.Controls.Add(this.deleteChoiceButton);
            this.choiceHeaderPanel.Controls.Add(this.ChoiceNumberLabel);
            this.choiceHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.choiceHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.choiceHeaderPanel.Name = "choiceHeaderPanel";
            this.choiceHeaderPanel.Size = new System.Drawing.Size(478, 16);
            this.choiceHeaderPanel.TabIndex = 0;
            // 
            // ChoiceNumberLabel
            // 
            this.ChoiceNumberLabel.AutoSize = true;
            this.ChoiceNumberLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChoiceNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceNumberLabel.Location = new System.Drawing.Point(317, 0);
            this.ChoiceNumberLabel.Name = "ChoiceNumberLabel";
            this.ChoiceNumberLabel.Size = new System.Drawing.Size(161, 16);
            this.ChoiceNumberLabel.TabIndex = 0;
            this.ChoiceNumberLabel.Text = "\"Choice\" + choiceNumber";
            // 
            // playerTextPanel
            // 
            this.playerTextPanel.AutoSize = true;
            this.playerTextPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerTextPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.playerTextPanel.Controls.Add(this.playerTextBox);
            this.playerTextPanel.Controls.Add(this.playerTextLabel);
            this.playerTextPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.playerTextPanel.Location = new System.Drawing.Point(0, 16);
            this.playerTextPanel.Name = "playerTextPanel";
            this.playerTextPanel.Padding = new System.Windows.Forms.Padding(2);
            this.playerTextPanel.Size = new System.Drawing.Size(478, 42);
            this.playerTextPanel.TabIndex = 1;
            // 
            // playerTextBox
            // 
            this.playerTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.playerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTextBox.Location = new System.Drawing.Point(51, 2);
            this.playerTextBox.MinimumSize = new System.Drawing.Size(4, 38);
            this.playerTextBox.Multiline = true;
            this.playerTextBox.Name = "playerTextBox";
            this.playerTextBox.Size = new System.Drawing.Size(425, 38);
            this.playerTextBox.TabIndex = 1;
            this.playerTextBox.TextChanged += new System.EventHandler(this.playerTextBox_TextChanged);
            this.playerTextBox.Enter += new System.EventHandler(this.playerTextBox_Enter);
            this.playerTextBox.Leave += new System.EventHandler(this.playerTextBox_Leave);
            // 
            // playerTextLabel
            // 
            this.playerTextLabel.AutoSize = true;
            this.playerTextLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTextLabel.Location = new System.Drawing.Point(2, 2);
            this.playerTextLabel.Margin = new System.Windows.Forms.Padding(0);
            this.playerTextLabel.Name = "playerTextLabel";
            this.playerTextLabel.Size = new System.Drawing.Size(49, 36);
            this.playerTextLabel.TabIndex = 0;
            this.playerTextLabel.Text = "Player\r\nText";
            // 
            // targetNodePanel
            // 
            this.targetNodePanel.Controls.Add(this.targetNodeIDTextBoxFeedback);
            this.targetNodePanel.Controls.Add(this.targetNodeIDValueTextBox);
            this.targetNodePanel.Controls.Add(this.makeTargetNewRootNodeButton);
            this.targetNodePanel.Controls.Add(this.makeTargetNewNodeButton);
            this.targetNodePanel.Controls.Add(this.targetNodeIDLabel);
            this.targetNodePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.targetNodePanel.Location = new System.Drawing.Point(0, 58);
            this.targetNodePanel.Name = "targetNodePanel";
            this.targetNodePanel.Size = new System.Drawing.Size(478, 20);
            this.targetNodePanel.TabIndex = 2;
            // 
            // targetNodeIDTextBoxFeedback
            // 
            this.targetNodeIDTextBoxFeedback.AutoSize = true;
            this.targetNodeIDTextBoxFeedback.ForeColor = System.Drawing.Color.DarkRed;
            this.targetNodeIDTextBoxFeedback.Location = new System.Drawing.Point(147, 4);
            this.targetNodeIDTextBoxFeedback.Name = "targetNodeIDTextBoxFeedback";
            this.targetNodeIDTextBoxFeedback.Size = new System.Drawing.Size(0, 13);
            this.targetNodeIDTextBoxFeedback.TabIndex = 6;
            // 
            // targetNodeIDLabel
            // 
            this.targetNodeIDLabel.AutoSize = true;
            this.targetNodeIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetNodeIDLabel.Location = new System.Drawing.Point(2, 1);
            this.targetNodeIDLabel.Name = "targetNodeIDLabel";
            this.targetNodeIDLabel.Size = new System.Drawing.Size(93, 15);
            this.targetNodeIDLabel.TabIndex = 0;
            this.targetNodeIDLabel.Text = "Target Node ID:";
            // 
            // ChoiceEditPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.targetNodePanel);
            this.Controls.Add(this.playerTextPanel);
            this.Controls.Add(this.choiceHeaderPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "ChoiceEditPanel";
            this.Size = new System.Drawing.Size(478, 96);
            this.Load += new System.EventHandler(this.ChoiceEditPanel_Load);
            this.SizeChanged += new System.EventHandler(this.ChoiceEditPanel_SizeChanged);
            this.Enter += new System.EventHandler(this.ChoiceEditPanel_Enter);
            this.Leave += new System.EventHandler(this.ChoiceEditPanel_Leave);
            this.choiceHeaderPanel.ResumeLayout(false);
            this.choiceHeaderPanel.PerformLayout();
            this.playerTextPanel.ResumeLayout(false);
            this.playerTextPanel.PerformLayout();
            this.targetNodePanel.ResumeLayout(false);
            this.targetNodePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel choiceHeaderPanel;
        private System.Windows.Forms.Label ChoiceNumberLabel;
        private System.Windows.Forms.Button deleteChoiceButton;
        private System.Windows.Forms.Panel playerTextPanel;
        private System.Windows.Forms.Label playerTextLabel;
        private System.Windows.Forms.TextBox playerTextBox;
        private System.Windows.Forms.Panel targetNodePanel;
        private System.Windows.Forms.Label targetNodeIDLabel;
        private System.Windows.Forms.Button minimiseChoiceButton;
        private System.Windows.Forms.Button makeTargetNewRootNodeButton;
        private System.Windows.Forms.Button makeTargetNewNodeButton;
        private System.Windows.Forms.TextBox targetNodeIDValueTextBox;
        private System.Windows.Forms.Label targetNodeIDTextBoxFeedback;
        private System.Windows.Forms.ToolTip toolTips;
    }
}
