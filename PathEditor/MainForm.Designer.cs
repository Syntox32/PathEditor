namespace PathEditor
{
    partial class MainForm
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
            this.btnApply = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAutoBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.menuItemInvalidate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(311, 275);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(12, 59);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(447, 210);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.menuItemSwitch});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(471, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBackup,
            this.menuItemLoad,
            this.menuItemInvalidate,
            this.menuItemAutoBackup});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuItemBackup
            // 
            this.menuItemBackup.Name = "menuItemBackup";
            this.menuItemBackup.Size = new System.Drawing.Size(211, 22);
            this.menuItemBackup.Text = "Backup";
            this.menuItemBackup.Click += new System.EventHandler(this.menuItemBackup_Click);
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Name = "menuItemLoad";
            this.menuItemLoad.Size = new System.Drawing.Size(211, 22);
            this.menuItemLoad.Text = "Load backup";
            this.menuItemLoad.Click += new System.EventHandler(this.menuItemLoad_Click);
            // 
            // menuItemAutoBackup
            // 
            this.menuItemAutoBackup.Checked = true;
            this.menuItemAutoBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemAutoBackup.Name = "menuItemAutoBackup";
            this.menuItemAutoBackup.Size = new System.Drawing.Size(211, 22);
            this.menuItemAutoBackup.Text = "Auto backup before apply";
            this.menuItemAutoBackup.Click += new System.EventHandler(this.menuItemAutoBackup_Click);
            // 
            // menuItemSwitch
            // 
            this.menuItemSwitch.Name = "menuItemSwitch";
            this.menuItemSwitch.Size = new System.Drawing.Size(94, 20);
            this.menuItemSwitch.Text = "Switch to User";
            this.menuItemSwitch.Click += new System.EventHandler(this.menuItemSwitch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd.Location = new System.Drawing.Point(93, 32);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(323, 20);
            this.txtAdd.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(422, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // menuItemInvalidate
            // 
            this.menuItemInvalidate.Name = "menuItemInvalidate";
            this.menuItemInvalidate.Size = new System.Drawing.Size(211, 22);
            this.menuItemInvalidate.Text = "Invalidate paths";
            this.menuItemInvalidate.Click += new System.EventHandler(this.menuItemInvalidate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 305);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Path Editor";
            this.Load += new System.EventHandler(this.LoadMain);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemSwitch;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackup;
        private System.Windows.Forms.ToolStripMenuItem menuItemAutoBackup;
        private System.Windows.Forms.ToolStripMenuItem menuItemInvalidate;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoad;
    }
}

