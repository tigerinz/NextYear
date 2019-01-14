namespace BitchAttachMDF
{
    partial class T3
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
            this.butT3 = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butFilder = new System.Windows.Forms.Button();
            this.butShow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UnCheck = new System.Windows.Forms.Button();
            this.AllCheck = new System.Windows.Forms.Button();
            this.butViewSQL = new System.Windows.Forms.Button();
            this.butBatchAttach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // butT3
            // 
            this.butT3.Location = new System.Drawing.Point(238, 331);
            this.butT3.Name = "butT3";
            this.butT3.Size = new System.Drawing.Size(75, 23);
            this.butT3.TabIndex = 8;
            this.butT3.Text = "ViewT3SQL";
            this.butT3.UseVisualStyleBackColor = true;
            this.butT3.Click += new System.EventHandler(this.butAttach_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(86, 22);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(461, 21);
            this.txtSource.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "源";
            // 
            // butFilder
            // 
            this.butFilder.Location = new System.Drawing.Point(565, 22);
            this.butFilder.Name = "butFilder";
            this.butFilder.Size = new System.Drawing.Size(31, 23);
            this.butFilder.TabIndex = 5;
            this.butFilder.Text = "选";
            this.butFilder.UseVisualStyleBackColor = true;
            this.butFilder.Click += new System.EventHandler(this.butFilder_Click);
            // 
            // butShow
            // 
            this.butShow.Location = new System.Drawing.Point(602, 22);
            this.butShow.Name = "butShow";
            this.butShow.Size = new System.Drawing.Size(75, 23);
            this.butShow.TabIndex = 10;
            this.butShow.Text = "show";
            this.butShow.UseVisualStyleBackColor = true;
            this.butShow.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(656, 255);
            this.dataGridView1.TabIndex = 11;
            // 
            // UnCheck
            // 
            this.UnCheck.Location = new System.Drawing.Point(132, 331);
            this.UnCheck.Name = "UnCheck";
            this.UnCheck.Size = new System.Drawing.Size(75, 23);
            this.UnCheck.TabIndex = 13;
            this.UnCheck.Text = "none";
            this.UnCheck.UseVisualStyleBackColor = true;
            this.UnCheck.Click += new System.EventHandler(this.UnCheck_Click);
            // 
            // AllCheck
            // 
            this.AllCheck.Location = new System.Drawing.Point(27, 331);
            this.AllCheck.Name = "AllCheck";
            this.AllCheck.Size = new System.Drawing.Size(75, 23);
            this.AllCheck.TabIndex = 12;
            this.AllCheck.Text = "all";
            this.AllCheck.UseVisualStyleBackColor = true;
            this.AllCheck.Click += new System.EventHandler(this.AllCheck_Click);
            // 
            // butViewSQL
            // 
            this.butViewSQL.Location = new System.Drawing.Point(319, 331);
            this.butViewSQL.Name = "butViewSQL";
            this.butViewSQL.Size = new System.Drawing.Size(101, 23);
            this.butViewSQL.TabIndex = 14;
            this.butViewSQL.Text = "ViewTplusSQL";
            this.butViewSQL.UseVisualStyleBackColor = true;
            this.butViewSQL.Click += new System.EventHandler(this.butViewSQL_Click);
            // 
            // butBatchAttach
            // 
            this.butBatchAttach.Location = new System.Drawing.Point(345, 408);
            this.butBatchAttach.Name = "butBatchAttach";
            this.butBatchAttach.Size = new System.Drawing.Size(75, 23);
            this.butBatchAttach.TabIndex = 15;
            this.butBatchAttach.Text = "BitchAttach";
            this.butBatchAttach.UseVisualStyleBackColor = true;
            // 
            // T3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 443);
            this.Controls.Add(this.butBatchAttach);
            this.Controls.Add(this.butViewSQL);
            this.Controls.Add(this.UnCheck);
            this.Controls.Add(this.AllCheck);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butShow);
            this.Controls.Add(this.butT3);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butFilder);
            this.Name = "T3";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butT3;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butFilder;
        private System.Windows.Forms.Button butShow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UnCheck;
        private System.Windows.Forms.Button AllCheck;
        private System.Windows.Forms.Button butViewSQL;
        private System.Windows.Forms.Button butBatchAttach;
    }
}

