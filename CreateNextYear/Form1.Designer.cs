namespace CreateNextYear
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createNextYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subSysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carryOverWAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carryOverGL12MonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNextYearToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createNextYearToolStripMenuItem
            // 
            this.createNextYearToolStripMenuItem.Name = "createNextYearToolStripMenuItem";
            this.createNextYearToolStripMenuItem.Size = new System.Drawing.Size(111, 21);
            this.createNextYearToolStripMenuItem.Text = "CreateNextYear";
            this.createNextYearToolStripMenuItem.Click += new System.EventHandler(this.createNextYearToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subSysToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // subSysToolStripMenuItem
            // 
            this.subSysToolStripMenuItem.Name = "subSysToolStripMenuItem";
            this.subSysToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.subSysToolStripMenuItem.Text = "SubSys";
            this.subSysToolStripMenuItem.Click += new System.EventHandler(this.subSysToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carryOverWAToolStripMenuItem,
            this.carryOverGL12MonthToolStripMenuItem,
            this.bitchToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // carryOverWAToolStripMenuItem
            // 
            this.carryOverWAToolStripMenuItem.Name = "carryOverWAToolStripMenuItem";
            this.carryOverWAToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.carryOverWAToolStripMenuItem.Text = "CarryOverWA";
            this.carryOverWAToolStripMenuItem.Click += new System.EventHandler(this.carryOverWAToolStripMenuItem_Click);
            // 
            // carryOverGL12MonthToolStripMenuItem
            // 
            this.carryOverGL12MonthToolStripMenuItem.Name = "carryOverGL12MonthToolStripMenuItem";
            this.carryOverGL12MonthToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.carryOverGL12MonthToolStripMenuItem.Text = "CarryOverGL12Month";
            this.carryOverGL12MonthToolStripMenuItem.Click += new System.EventHandler(this.carryOverGL12MonthToolStripMenuItem_Click);
            // 
            // bitchToolStripMenuItem
            // 
            this.bitchToolStripMenuItem.Name = "bitchToolStripMenuItem";
            this.bitchToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bitchToolStripMenuItem.Text = "bitchAttachDB";
            this.bitchToolStripMenuItem.Click += new System.EventHandler(this.bitchToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 459);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createNextYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subSysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carryOverWAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carryOverGL12MonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitchToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

