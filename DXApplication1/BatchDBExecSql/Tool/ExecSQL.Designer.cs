namespace BatchDBExecSql.Tool
{
    partial class ExecSQL
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOutFile = new System.Windows.Forms.Button();
            this.txtFilePath1 = new System.Windows.Forms.TextBox();
            this.bntOpen1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.txtFilePath2 = new System.Windows.Forms.TextBox();
            this.btnOpen2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilePath2);
            this.panel1.Controls.Add(this.btnOpen2);
            this.panel1.Controls.Add(this.btnOutFile);
            this.panel1.Controls.Add(this.txtFilePath1);
            this.panel1.Controls.Add(this.bntOpen1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnExec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 89);
            this.panel1.TabIndex = 0;
            // 
            // btnOutFile
            // 
            this.btnOutFile.Location = new System.Drawing.Point(246, 59);
            this.btnOutFile.Name = "btnOutFile";
            this.btnOutFile.Size = new System.Drawing.Size(75, 23);
            this.btnOutFile.TabIndex = 4;
            this.btnOutFile.Text = "导出文件";
            this.btnOutFile.UseVisualStyleBackColor = true;
            this.btnOutFile.Click += new System.EventHandler(this.btnOutFile_Click);
            // 
            // txtFilePath1
            // 
            this.txtFilePath1.Location = new System.Drawing.Point(3, 3);
            this.txtFilePath1.Name = "txtFilePath1";
            this.txtFilePath1.Size = new System.Drawing.Size(201, 22);
            this.txtFilePath1.TabIndex = 3;
            // 
            // bntOpen1
            // 
            this.bntOpen1.Location = new System.Drawing.Point(228, 3);
            this.bntOpen1.Name = "bntOpen1";
            this.bntOpen1.Size = new System.Drawing.Size(75, 23);
            this.bntOpen1.TabIndex = 2;
            this.bntOpen1.Text = "打开";
            this.bntOpen1.UseVisualStyleBackColor = true;
            this.bntOpen1.Click += new System.EventHandler(this.bntOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(46, 59);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 0;
            this.btnExec.Text = "执行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Location = new System.Drawing.Point(0, 0);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(353, 253);
            this.txtSql.TabIndex = 1;
            this.txtSql.TextChanged += new System.EventHandler(this.txtSql_TextChanged);
            // 
            // txtFilePath2
            // 
            this.txtFilePath2.Location = new System.Drawing.Point(3, 32);
            this.txtFilePath2.Name = "txtFilePath2";
            this.txtFilePath2.Size = new System.Drawing.Size(201, 22);
            this.txtFilePath2.TabIndex = 6;
            // 
            // btnOpen2
            // 
            this.btnOpen2.Location = new System.Drawing.Point(228, 32);
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Size = new System.Drawing.Size(75, 23);
            this.btnOpen2.TabIndex = 5;
            this.btnOpen2.Text = "打开";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // ExecSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 342);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.panel1);
            this.Name = "ExecSQL";
            this.Text = "ExecSQL";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TextBox txtFilePath1;
        private System.Windows.Forms.Button bntOpen1;
        private System.Windows.Forms.Button btnOutFile;
        private System.Windows.Forms.TextBox txtFilePath2;
        private System.Windows.Forms.Button btnOpen2;
    }
}