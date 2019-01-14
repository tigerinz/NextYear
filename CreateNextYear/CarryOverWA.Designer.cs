namespace CreateNextYear
{
    partial class CarryOverWA
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.createNextYear = new System.Windows.Forms.Button();
            this.UnCheck = new System.Windows.Forms.Button();
            this.AllCheck = new System.Windows.Forms.Button();
            this.uA_AccountEntityDataGridView = new System.Windows.Forms.DataGridView();
            this.uA_AccountEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.isChooseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isysidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caccidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caccnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caccpathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iyearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imonthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caccmasterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccurcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccurnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitabbreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitaddrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitzapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunittelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitfaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunittaxnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunitlpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfinkindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfintypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctradekindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newyearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxyearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targerDBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountEntityDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numYear);
            this.panel1.Controls.Add(this.createNextYear);
            this.panel1.Controls.Add(this.UnCheck);
            this.panel1.Controls.Add(this.AllCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 70);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "NewYear:";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(521, 15);
            this.numYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 21);
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // createNextYear
            // 
            this.createNextYear.Location = new System.Drawing.Point(659, 14);
            this.createNextYear.Name = "createNextYear";
            this.createNextYear.Size = new System.Drawing.Size(121, 23);
            this.createNextYear.TabIndex = 2;
            this.createNextYear.Text = "CreateNextYear";
            this.createNextYear.UseVisualStyleBackColor = true;
            this.createNextYear.Click += new System.EventHandler(this.createNextYear_Click);
            // 
            // UnCheck
            // 
            this.UnCheck.Location = new System.Drawing.Point(108, 14);
            this.UnCheck.Name = "UnCheck";
            this.UnCheck.Size = new System.Drawing.Size(75, 23);
            this.UnCheck.TabIndex = 1;
            this.UnCheck.Text = "全不选";
            this.UnCheck.UseVisualStyleBackColor = true;
            this.UnCheck.Click += new System.EventHandler(this.UnCheck_Click);
            // 
            // AllCheck
            // 
            this.AllCheck.Location = new System.Drawing.Point(3, 14);
            this.AllCheck.Name = "AllCheck";
            this.AllCheck.Size = new System.Drawing.Size(75, 23);
            this.AllCheck.TabIndex = 0;
            this.AllCheck.Text = "全选";
            this.AllCheck.UseVisualStyleBackColor = true;
            this.AllCheck.Click += new System.EventHandler(this.AllCheck_Click);
            // 
            // uA_AccountEntityDataGridView
            // 
            this.uA_AccountEntityDataGridView.AllowUserToAddRows = false;
            this.uA_AccountEntityDataGridView.AllowUserToDeleteRows = false;
            this.uA_AccountEntityDataGridView.AutoGenerateColumns = false;
            this.uA_AccountEntityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.uA_AccountEntityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uA_AccountEntityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isChooseDataGridViewCheckBoxColumn,
            this.isysidDataGridViewTextBoxColumn,
            this.caccidDataGridViewTextBoxColumn,
            this.caccnameDataGridViewTextBoxColumn,
            this.caccpathDataGridViewTextBoxColumn,
            this.iyearDataGridViewTextBoxColumn,
            this.imonthDataGridViewTextBoxColumn,
            this.caccmasterDataGridViewTextBoxColumn,
            this.ccurcodeDataGridViewTextBoxColumn,
            this.ccurnameDataGridViewTextBoxColumn,
            this.cunitnameDataGridViewTextBoxColumn,
            this.cunitabbreDataGridViewTextBoxColumn,
            this.cunitaddrDataGridViewTextBoxColumn,
            this.cunitzapDataGridViewTextBoxColumn,
            this.cunittelDataGridViewTextBoxColumn,
            this.cunitfaxDataGridViewTextBoxColumn,
            this.cunitemailDataGridViewTextBoxColumn,
            this.cunittaxnoDataGridViewTextBoxColumn,
            this.cunitlpDataGridViewTextBoxColumn,
            this.cfinkindDataGridViewTextBoxColumn,
            this.cfintypeDataGridViewTextBoxColumn,
            this.centtypeDataGridViewTextBoxColumn,
            this.ctradekindDataGridViewTextBoxColumn,
            this.newyearDataGridViewTextBoxColumn,
            this.maxyearDataGridViewTextBoxColumn,
            this.sourceDBDataGridViewTextBoxColumn,
            this.targerDBDataGridViewTextBoxColumn});
            this.uA_AccountEntityDataGridView.DataSource = this.uA_AccountEntityBindingSource;
            this.uA_AccountEntityDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uA_AccountEntityDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uA_AccountEntityDataGridView.Name = "uA_AccountEntityDataGridView";
            this.uA_AccountEntityDataGridView.RowHeadersVisible = false;
            this.uA_AccountEntityDataGridView.RowTemplate.Height = 23;
            this.uA_AccountEntityDataGridView.Size = new System.Drawing.Size(842, 293);
            this.uA_AccountEntityDataGridView.TabIndex = 3;
            // 
            // uA_AccountEntityBindingSource
            // 
            this.uA_AccountEntityBindingSource.AllowNew = true;
            this.uA_AccountEntityBindingSource.DataSource = typeof(CreateNextYear.UA_AccountEntity);
            // 
            // isChooseDataGridViewCheckBoxColumn
            // 
            this.isChooseDataGridViewCheckBoxColumn.DataPropertyName = "IsChoose";
            this.isChooseDataGridViewCheckBoxColumn.HeaderText = "IsChoose";
            this.isChooseDataGridViewCheckBoxColumn.Name = "isChooseDataGridViewCheckBoxColumn";
            this.isChooseDataGridViewCheckBoxColumn.Width = 59;
            // 
            // isysidDataGridViewTextBoxColumn
            // 
            this.isysidDataGridViewTextBoxColumn.DataPropertyName = "Isysid";
            this.isysidDataGridViewTextBoxColumn.HeaderText = "Isysid";
            this.isysidDataGridViewTextBoxColumn.Name = "isysidDataGridViewTextBoxColumn";
            this.isysidDataGridViewTextBoxColumn.Width = 66;
            // 
            // caccidDataGridViewTextBoxColumn
            // 
            this.caccidDataGridViewTextBoxColumn.DataPropertyName = "Cacc_id";
            this.caccidDataGridViewTextBoxColumn.HeaderText = "Cacc_id";
            this.caccidDataGridViewTextBoxColumn.Name = "caccidDataGridViewTextBoxColumn";
            this.caccidDataGridViewTextBoxColumn.Width = 72;
            // 
            // caccnameDataGridViewTextBoxColumn
            // 
            this.caccnameDataGridViewTextBoxColumn.DataPropertyName = "Cacc_name";
            this.caccnameDataGridViewTextBoxColumn.HeaderText = "Cacc_name";
            this.caccnameDataGridViewTextBoxColumn.Name = "caccnameDataGridViewTextBoxColumn";
            this.caccnameDataGridViewTextBoxColumn.Width = 84;
            // 
            // caccpathDataGridViewTextBoxColumn
            // 
            this.caccpathDataGridViewTextBoxColumn.DataPropertyName = "Cacc_path";
            this.caccpathDataGridViewTextBoxColumn.HeaderText = "Cacc_path";
            this.caccpathDataGridViewTextBoxColumn.Name = "caccpathDataGridViewTextBoxColumn";
            this.caccpathDataGridViewTextBoxColumn.Width = 84;
            // 
            // iyearDataGridViewTextBoxColumn
            // 
            this.iyearDataGridViewTextBoxColumn.DataPropertyName = "Iyear";
            this.iyearDataGridViewTextBoxColumn.HeaderText = "Iyear";
            this.iyearDataGridViewTextBoxColumn.Name = "iyearDataGridViewTextBoxColumn";
            this.iyearDataGridViewTextBoxColumn.Width = 60;
            // 
            // imonthDataGridViewTextBoxColumn
            // 
            this.imonthDataGridViewTextBoxColumn.DataPropertyName = "Imonth";
            this.imonthDataGridViewTextBoxColumn.HeaderText = "Imonth";
            this.imonthDataGridViewTextBoxColumn.Name = "imonthDataGridViewTextBoxColumn";
            this.imonthDataGridViewTextBoxColumn.Width = 66;
            // 
            // caccmasterDataGridViewTextBoxColumn
            // 
            this.caccmasterDataGridViewTextBoxColumn.DataPropertyName = "Cacc_master";
            this.caccmasterDataGridViewTextBoxColumn.HeaderText = "Cacc_master";
            this.caccmasterDataGridViewTextBoxColumn.Name = "caccmasterDataGridViewTextBoxColumn";
            this.caccmasterDataGridViewTextBoxColumn.Width = 96;
            // 
            // ccurcodeDataGridViewTextBoxColumn
            // 
            this.ccurcodeDataGridViewTextBoxColumn.DataPropertyName = "Ccurcode";
            this.ccurcodeDataGridViewTextBoxColumn.HeaderText = "Ccurcode";
            this.ccurcodeDataGridViewTextBoxColumn.Name = "ccurcodeDataGridViewTextBoxColumn";
            this.ccurcodeDataGridViewTextBoxColumn.Width = 78;
            // 
            // ccurnameDataGridViewTextBoxColumn
            // 
            this.ccurnameDataGridViewTextBoxColumn.DataPropertyName = "Ccurname";
            this.ccurnameDataGridViewTextBoxColumn.HeaderText = "Ccurname";
            this.ccurnameDataGridViewTextBoxColumn.Name = "ccurnameDataGridViewTextBoxColumn";
            this.ccurnameDataGridViewTextBoxColumn.Width = 78;
            // 
            // cunitnameDataGridViewTextBoxColumn
            // 
            this.cunitnameDataGridViewTextBoxColumn.DataPropertyName = "Cunitname";
            this.cunitnameDataGridViewTextBoxColumn.HeaderText = "Cunitname";
            this.cunitnameDataGridViewTextBoxColumn.Name = "cunitnameDataGridViewTextBoxColumn";
            this.cunitnameDataGridViewTextBoxColumn.Width = 84;
            // 
            // cunitabbreDataGridViewTextBoxColumn
            // 
            this.cunitabbreDataGridViewTextBoxColumn.DataPropertyName = "Cunitabbre";
            this.cunitabbreDataGridViewTextBoxColumn.HeaderText = "Cunitabbre";
            this.cunitabbreDataGridViewTextBoxColumn.Name = "cunitabbreDataGridViewTextBoxColumn";
            this.cunitabbreDataGridViewTextBoxColumn.Width = 90;
            // 
            // cunitaddrDataGridViewTextBoxColumn
            // 
            this.cunitaddrDataGridViewTextBoxColumn.DataPropertyName = "Cunitaddr";
            this.cunitaddrDataGridViewTextBoxColumn.HeaderText = "Cunitaddr";
            this.cunitaddrDataGridViewTextBoxColumn.Name = "cunitaddrDataGridViewTextBoxColumn";
            this.cunitaddrDataGridViewTextBoxColumn.Width = 84;
            // 
            // cunitzapDataGridViewTextBoxColumn
            // 
            this.cunitzapDataGridViewTextBoxColumn.DataPropertyName = "Cunitzap";
            this.cunitzapDataGridViewTextBoxColumn.HeaderText = "Cunitzap";
            this.cunitzapDataGridViewTextBoxColumn.Name = "cunitzapDataGridViewTextBoxColumn";
            this.cunitzapDataGridViewTextBoxColumn.Width = 78;
            // 
            // cunittelDataGridViewTextBoxColumn
            // 
            this.cunittelDataGridViewTextBoxColumn.DataPropertyName = "Cunittel";
            this.cunittelDataGridViewTextBoxColumn.HeaderText = "Cunittel";
            this.cunittelDataGridViewTextBoxColumn.Name = "cunittelDataGridViewTextBoxColumn";
            this.cunittelDataGridViewTextBoxColumn.Width = 78;
            // 
            // cunitfaxDataGridViewTextBoxColumn
            // 
            this.cunitfaxDataGridViewTextBoxColumn.DataPropertyName = "Cunitfax";
            this.cunitfaxDataGridViewTextBoxColumn.HeaderText = "Cunitfax";
            this.cunitfaxDataGridViewTextBoxColumn.Name = "cunitfaxDataGridViewTextBoxColumn";
            this.cunitfaxDataGridViewTextBoxColumn.Width = 78;
            // 
            // cunitemailDataGridViewTextBoxColumn
            // 
            this.cunitemailDataGridViewTextBoxColumn.DataPropertyName = "Cunitemail";
            this.cunitemailDataGridViewTextBoxColumn.HeaderText = "Cunitemail";
            this.cunitemailDataGridViewTextBoxColumn.Name = "cunitemailDataGridViewTextBoxColumn";
            this.cunitemailDataGridViewTextBoxColumn.Width = 90;
            // 
            // cunittaxnoDataGridViewTextBoxColumn
            // 
            this.cunittaxnoDataGridViewTextBoxColumn.DataPropertyName = "Cunittaxno";
            this.cunittaxnoDataGridViewTextBoxColumn.HeaderText = "Cunittaxno";
            this.cunittaxnoDataGridViewTextBoxColumn.Name = "cunittaxnoDataGridViewTextBoxColumn";
            this.cunittaxnoDataGridViewTextBoxColumn.Width = 90;
            // 
            // cunitlpDataGridViewTextBoxColumn
            // 
            this.cunitlpDataGridViewTextBoxColumn.DataPropertyName = "Cunitlp";
            this.cunitlpDataGridViewTextBoxColumn.HeaderText = "Cunitlp";
            this.cunitlpDataGridViewTextBoxColumn.Name = "cunitlpDataGridViewTextBoxColumn";
            this.cunitlpDataGridViewTextBoxColumn.Width = 72;
            // 
            // cfinkindDataGridViewTextBoxColumn
            // 
            this.cfinkindDataGridViewTextBoxColumn.DataPropertyName = "Cfinkind";
            this.cfinkindDataGridViewTextBoxColumn.HeaderText = "Cfinkind";
            this.cfinkindDataGridViewTextBoxColumn.Name = "cfinkindDataGridViewTextBoxColumn";
            this.cfinkindDataGridViewTextBoxColumn.Width = 78;
            // 
            // cfintypeDataGridViewTextBoxColumn
            // 
            this.cfintypeDataGridViewTextBoxColumn.DataPropertyName = "Cfintype";
            this.cfintypeDataGridViewTextBoxColumn.HeaderText = "Cfintype";
            this.cfintypeDataGridViewTextBoxColumn.Name = "cfintypeDataGridViewTextBoxColumn";
            this.cfintypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // centtypeDataGridViewTextBoxColumn
            // 
            this.centtypeDataGridViewTextBoxColumn.DataPropertyName = "Centtype";
            this.centtypeDataGridViewTextBoxColumn.HeaderText = "Centtype";
            this.centtypeDataGridViewTextBoxColumn.Name = "centtypeDataGridViewTextBoxColumn";
            this.centtypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // ctradekindDataGridViewTextBoxColumn
            // 
            this.ctradekindDataGridViewTextBoxColumn.DataPropertyName = "Ctradekind";
            this.ctradekindDataGridViewTextBoxColumn.HeaderText = "Ctradekind";
            this.ctradekindDataGridViewTextBoxColumn.Name = "ctradekindDataGridViewTextBoxColumn";
            this.ctradekindDataGridViewTextBoxColumn.Width = 90;
            // 
            // newyearDataGridViewTextBoxColumn
            // 
            this.newyearDataGridViewTextBoxColumn.DataPropertyName = "Newyear";
            this.newyearDataGridViewTextBoxColumn.HeaderText = "Newyear";
            this.newyearDataGridViewTextBoxColumn.Name = "newyearDataGridViewTextBoxColumn";
            this.newyearDataGridViewTextBoxColumn.Width = 72;
            // 
            // maxyearDataGridViewTextBoxColumn
            // 
            this.maxyearDataGridViewTextBoxColumn.DataPropertyName = "Maxyear";
            this.maxyearDataGridViewTextBoxColumn.HeaderText = "Maxyear";
            this.maxyearDataGridViewTextBoxColumn.Name = "maxyearDataGridViewTextBoxColumn";
            this.maxyearDataGridViewTextBoxColumn.Width = 72;
            // 
            // sourceDBDataGridViewTextBoxColumn
            // 
            this.sourceDBDataGridViewTextBoxColumn.DataPropertyName = "SourceDB";
            this.sourceDBDataGridViewTextBoxColumn.HeaderText = "SourceDB";
            this.sourceDBDataGridViewTextBoxColumn.Name = "sourceDBDataGridViewTextBoxColumn";
            this.sourceDBDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceDBDataGridViewTextBoxColumn.Width = 78;
            // 
            // targerDBDataGridViewTextBoxColumn
            // 
            this.targerDBDataGridViewTextBoxColumn.DataPropertyName = "TargerDB";
            this.targerDBDataGridViewTextBoxColumn.HeaderText = "TargerDB";
            this.targerDBDataGridViewTextBoxColumn.Name = "targerDBDataGridViewTextBoxColumn";
            this.targerDBDataGridViewTextBoxColumn.ReadOnly = true;
            this.targerDBDataGridViewTextBoxColumn.Width = 78;
            // 
            // CarryOverWA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 363);
            this.Controls.Add(this.uA_AccountEntityDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "CarryOverWA";
            this.Text = "CarryOverWA";
            this.Load += new System.EventHandler(this.CarryOverWA_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountEntityDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountEntityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Button createNextYear;
        private System.Windows.Forms.Button UnCheck;
        private System.Windows.Forms.Button AllCheck;
        private System.Windows.Forms.DataGridView uA_AccountEntityDataGridView;
        private System.Windows.Forms.BindingSource uA_AccountEntityBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChooseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isysidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caccidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caccnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caccpathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iyearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imonthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caccmasterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccurcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccurnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitabbreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitaddrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitzapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunittelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitfaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitemailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunittaxnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunitlpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfinkindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfintypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctradekindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newyearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxyearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targerDBDataGridViewTextBoxColumn;
    }
}