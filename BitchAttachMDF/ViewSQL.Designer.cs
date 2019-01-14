namespace BitchAttachMDF
{
    partial class ViewSQL
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
            this.txtViewSQL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtViewSQL
            // 
            this.txtViewSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtViewSQL.Location = new System.Drawing.Point(0, 0);
            this.txtViewSQL.Multiline = true;
            this.txtViewSQL.Name = "txtViewSQL";
            this.txtViewSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtViewSQL.Size = new System.Drawing.Size(675, 379);
            this.txtViewSQL.TabIndex = 0;
            // 
            // ViewSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 379);
            this.Controls.Add(this.txtViewSQL);
            this.Name = "ViewSQL";
            this.Text = "ViewSQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtViewSQL;
    }
}