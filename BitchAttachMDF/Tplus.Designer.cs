namespace BitchAttachMDF
{
    partial class Tplus
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
            this.butBatchAttach = new System.Windows.Forms.Button();
            this.butViewSQL = new System.Windows.Forms.Button();
            this.UnCheck = new System.Windows.Forms.Button();
            this.AllCheck = new System.Windows.Forms.Button();
            this.dgvUFDBFiles = new System.Windows.Forms.DataGridView();
            this.butShowInDataGridView = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSelectFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUFDBFiles)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // butBatchAttach
            // 
            this.butBatchAttach.Location = new System.Drawing.Point(405, 14);
            this.butBatchAttach.Name = "butBatchAttach";
            this.butBatchAttach.Size = new System.Drawing.Size(75, 23);
            this.butBatchAttach.TabIndex = 26;
            this.butBatchAttach.Text = "BitchAttach";
            this.butBatchAttach.UseVisualStyleBackColor = true;
            this.butBatchAttach.Click += new System.EventHandler(this.butBatchAttach_Click);
            // 
            // butViewSQL
            // 
            this.butViewSQL.Location = new System.Drawing.Point(263, 14);
            this.butViewSQL.Name = "butViewSQL";
            this.butViewSQL.Size = new System.Drawing.Size(101, 23);
            this.butViewSQL.TabIndex = 25;
            this.butViewSQL.Text = "ViewTplusSQL";
            this.butViewSQL.UseVisualStyleBackColor = true;
            this.butViewSQL.Click += new System.EventHandler(this.butViewSQL_Click);
            // 
            // UnCheck
            // 
            this.UnCheck.Location = new System.Drawing.Point(145, 14);
            this.UnCheck.Name = "UnCheck";
            this.UnCheck.Size = new System.Drawing.Size(75, 23);
            this.UnCheck.TabIndex = 24;
            this.UnCheck.Text = "none";
            this.UnCheck.UseVisualStyleBackColor = true;
            this.UnCheck.Click += new System.EventHandler(this.UnCheck_Click);
            // 
            // AllCheck
            // 
            this.AllCheck.Location = new System.Drawing.Point(24, 14);
            this.AllCheck.Name = "AllCheck";
            this.AllCheck.Size = new System.Drawing.Size(75, 23);
            this.AllCheck.TabIndex = 23;
            this.AllCheck.Text = "all";
            this.AllCheck.UseVisualStyleBackColor = true;
            this.AllCheck.Click += new System.EventHandler(this.AllCheck_Click);
            // 
            // dgvUFDBFiles
            // 
            this.dgvUFDBFiles.AllowUserToAddRows = false;
            this.dgvUFDBFiles.AllowUserToDeleteRows = false;
            this.dgvUFDBFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUFDBFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUFDBFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvUFDBFiles.Name = "dgvUFDBFiles";
            this.dgvUFDBFiles.RowTemplate.Height = 23;
            this.dgvUFDBFiles.Size = new System.Drawing.Size(775, 384);
            this.dgvUFDBFiles.TabIndex = 22;
            // 
            // butShowInDataGridView
            // 
            this.butShowInDataGridView.Location = new System.Drawing.Point(614, 10);
            this.butShowInDataGridView.Name = "butShowInDataGridView";
            this.butShowInDataGridView.Size = new System.Drawing.Size(75, 23);
            this.butShowInDataGridView.TabIndex = 21;
            this.butShowInDataGridView.Text = "show";
            this.butShowInDataGridView.UseVisualStyleBackColor = true;
            this.butShowInDataGridView.Click += new System.EventHandler(this.butShow_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(98, 10);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(461, 21);
            this.txtSource.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "源";
            // 
            // butSelectFolder
            // 
            this.butSelectFolder.Location = new System.Drawing.Point(577, 10);
            this.butSelectFolder.Name = "butSelectFolder";
            this.butSelectFolder.Size = new System.Drawing.Size(31, 23);
            this.butSelectFolder.TabIndex = 17;
            this.butSelectFolder.Text = "选";
            this.butSelectFolder.UseVisualStyleBackColor = true;
            this.butSelectFolder.Click += new System.EventHandler(this.butFilder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butBatchAttach);
            this.panel1.Controls.Add(this.AllCheck);
            this.panel1.Controls.Add(this.UnCheck);
            this.panel1.Controls.Add(this.butViewSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 58);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvUFDBFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 384);
            this.panel2.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butShowInDataGridView);
            this.panel3.Controls.Add(this.butSelectFolder);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSource);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 40);
            this.panel3.TabIndex = 0;
            // 
            // Tplus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Tplus";
            this.Text = "T_";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUFDBFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butBatchAttach;
        private System.Windows.Forms.Button butViewSQL;
        private System.Windows.Forms.Button UnCheck;
        private System.Windows.Forms.Button AllCheck;
        private System.Windows.Forms.DataGridView dgvUFDBFiles;
        private System.Windows.Forms.Button butShowInDataGridView;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSelectFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}