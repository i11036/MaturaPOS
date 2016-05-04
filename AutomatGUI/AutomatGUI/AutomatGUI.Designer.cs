namespace AutomatGUI
{
    partial class AutomatGUI
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
            this.automatPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAutomatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.automatStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // automatPanel
            // 
            this.automatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.automatPanel.Location = new System.Drawing.Point(0, 27);
            this.automatPanel.Name = "automatPanel";
            this.automatPanel.Size = new System.Drawing.Size(510, 283);
            this.automatPanel.TabIndex = 0;
            this.automatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.automatPanel_Paint);
            this.automatPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.automatPanel_MouseDown);
            this.automatPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.automatPanel_MouseMove);
            this.automatPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.automatPanel_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.stateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(510, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAutomatToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.checkInputToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newAutomatToolStripMenuItem
            // 
            this.newAutomatToolStripMenuItem.Name = "newAutomatToolStripMenuItem";
            this.newAutomatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.newAutomatToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.newAutomatToolStripMenuItem.Text = "New";
            this.newAutomatToolStripMenuItem.Click += new System.EventHandler(this.newAutomatToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStateToolStripMenuItem,
            this.newPathToolStripMenuItem});
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.stateToolStripMenuItem.Text = "Edit";
            // 
            // newStateToolStripMenuItem
            // 
            this.newStateToolStripMenuItem.Name = "newStateToolStripMenuItem";
            this.newStateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newStateToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newStateToolStripMenuItem.Text = "New State";
            this.newStateToolStripMenuItem.Click += new System.EventHandler(this.newStateToolStripMenuItem_Click);
            // 
            // newPathToolStripMenuItem
            // 
            this.newPathToolStripMenuItem.Name = "newPathToolStripMenuItem";
            this.newPathToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.newPathToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newPathToolStripMenuItem.Text = "New Path";
            this.newPathToolStripMenuItem.Click += new System.EventHandler(this.newPathToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automatStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(510, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // automatStatusLabel
            // 
            this.automatStatusLabel.Name = "automatStatusLabel";
            this.automatStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // checkInputToolStripMenuItem
            // 
            this.checkInputToolStripMenuItem.Name = "checkInputToolStripMenuItem";
            this.checkInputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.checkInputToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.checkInputToolStripMenuItem.Text = "Check Input";
            this.checkInputToolStripMenuItem.Click += new System.EventHandler(this.checkInputToolStripMenuItem_Click);
            // 
            // AutomatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 335);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.automatPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AutomatGUI";
            this.Text = "Automat GUI";
            this.Load += new System.EventHandler(this.AutomatGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel automatPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAutomatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPathToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel automatStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkInputToolStripMenuItem;
    }
}

