namespace CreateNextYear
{
    partial class SubSysView
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
            this.components = new System.ComponentModel.Container();
            this.uA_Account_subEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uA_Account_subEntityDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uA_Account_subEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_Account_subEntityDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uA_Account_subEntityBindingSource
            // 
            this.uA_Account_subEntityBindingSource.DataSource = typeof(CreateNextYear.UA_Account_subEntity);
            // 
            // uA_Account_subEntityDataGridView
            // 
            this.uA_Account_subEntityDataGridView.AllowUserToAddRows = false;
            this.uA_Account_subEntityDataGridView.AllowUserToDeleteRows = false;
            this.uA_Account_subEntityDataGridView.AutoGenerateColumns = false;
            this.uA_Account_subEntityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uA_Account_subEntityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.uA_Account_subEntityDataGridView.DataSource = this.uA_Account_subEntityBindingSource;
            this.uA_Account_subEntityDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uA_Account_subEntityDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uA_Account_subEntityDataGridView.Name = "uA_Account_subEntityDataGridView";
            this.uA_Account_subEntityDataGridView.ReadOnly = true;
            this.uA_Account_subEntityDataGridView.RowTemplate.Height = 23;
            this.uA_Account_subEntityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uA_Account_subEntityDataGridView.Size = new System.Drawing.Size(719, 359);
            this.uA_Account_subEntityDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cacc_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cacc_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Iyear";
            this.dataGridViewTextBoxColumn2.HeaderText = "Iyear";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Csub_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "Csub_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Bisdelete";
            this.dataGridViewTextBoxColumn4.HeaderText = "Bisdelete";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Bclosing";
            this.dataGridViewTextBoxColumn5.HeaderText = "Bclosing";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Imodiperi";
            this.dataGridViewTextBoxColumn6.HeaderText = "Imodiperi";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Dsubsysused";
            this.dataGridViewTextBoxColumn7.HeaderText = "Dsubsysused";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // SubSysView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 359);
            this.Controls.Add(this.uA_Account_subEntityDataGridView);
            this.Name = "SubSysView";
            this.Text = "SubSysView";
            this.Load += new System.EventHandler(this.SubSysView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uA_Account_subEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_Account_subEntityDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource uA_Account_subEntityBindingSource;
        private System.Windows.Forms.DataGridView uA_Account_subEntityDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}