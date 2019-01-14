namespace CreateNextYear
{
    partial class AttachDB
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
            this.butFilder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.butAttach = new System.Windows.Forms.Button();
            this.txtView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butFilder
            // 
            this.butFilder.Location = new System.Drawing.Point(558, 44);
            this.butFilder.Name = "butFilder";
            this.butFilder.Size = new System.Drawing.Size(31, 23);
            this.butFilder.TabIndex = 0;
            this.butFilder.Text = "选";
            this.butFilder.UseVisualStyleBackColor = true;
            this.butFilder.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(59, 44);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(481, 21);
            this.txtSource.TabIndex = 2;
            // 
            // butAttach
            // 
            this.butAttach.Location = new System.Drawing.Point(104, 85);
            this.butAttach.Name = "butAttach";
            this.butAttach.Size = new System.Drawing.Size(75, 23);
            this.butAttach.TabIndex = 3;
            this.butAttach.Text = "AttachDB";
            this.butAttach.UseVisualStyleBackColor = true;
            this.butAttach.Click += new System.EventHandler(this.butAttach_Click);
            // 
            // txtView
            // 
            this.txtView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtView.Location = new System.Drawing.Point(0, 114);
            this.txtView.Multiline = true;
            this.txtView.Name = "txtView";
            this.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtView.Size = new System.Drawing.Size(715, 294);
            this.txtView.TabIndex = 4;
            // 
            // AttachDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 408);
            this.Controls.Add(this.txtView);
            this.Controls.Add(this.butAttach);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butFilder);
            this.Name = "AttachDB";
            this.Text = "AttachDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butFilder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button butAttach;
        private System.Windows.Forms.TextBox txtView;
    }
}