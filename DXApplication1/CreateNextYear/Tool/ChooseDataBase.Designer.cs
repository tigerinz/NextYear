namespace CreateNextYear.Tool
{
    partial class ChooseDataBase
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
            this.txtChooseDBSQL = new System.Windows.Forms.TextBox();
            this.bntExecSQL = new System.Windows.Forms.Button();
            this.gridControlDB = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDBName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bntOK = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtChooseDBSQL
            // 
            this.txtChooseDBSQL.Location = new System.Drawing.Point(12, 12);
            this.txtChooseDBSQL.Multiline = true;
            this.txtChooseDBSQL.Name = "txtChooseDBSQL";
            this.txtChooseDBSQL.Size = new System.Drawing.Size(918, 70);
            this.txtChooseDBSQL.TabIndex = 0;
            this.txtChooseDBSQL.Text = "Select name as DBName From master.dbo.sysdatabases";
            // 
            // bntExecSQL
            // 
            this.bntExecSQL.Location = new System.Drawing.Point(936, 12);
            this.bntExecSQL.Name = "bntExecSQL";
            this.bntExecSQL.Size = new System.Drawing.Size(60, 70);
            this.bntExecSQL.TabIndex = 1;
            this.bntExecSQL.Text = "执行";
            this.bntExecSQL.UseVisualStyleBackColor = true;
            this.bntExecSQL.Click += new System.EventHandler(this.bntExecSQL_Click);
            // 
            // gridControlDB
            // 
            this.gridControlDB.Location = new System.Drawing.Point(12, 88);
            this.gridControlDB.MainView = this.gridView1;
            this.gridControlDB.Name = "gridControlDB";
            this.gridControlDB.Size = new System.Drawing.Size(984, 565);
            this.gridControlDB.TabIndex = 2;
            this.gridControlDB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlDB.Click += new System.EventHandler(this.gridControlDB_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDBName});
            this.gridView1.GridControl = this.gridControlDB;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // gridColumnDBName
            // 
            this.gridColumnDBName.Caption = "数据库";
            this.gridColumnDBName.FieldName = "DBName";
            this.gridColumnDBName.Name = "gridColumnDBName";
            this.gridColumnDBName.Visible = true;
            this.gridColumnDBName.VisibleIndex = 1;
            // 
            // bntOK
            // 
            this.bntOK.Location = new System.Drawing.Point(296, 683);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(75, 23);
            this.bntOK.TabIndex = 3;
            this.bntOK.Text = "确定";
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.Location = new System.Drawing.Point(430, 683);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(75, 23);
            this.bntCancel.TabIndex = 4;
            this.bntCancel.Text = "取消";
            this.bntCancel.UseVisualStyleBackColor = true;
            this.bntCancel.Click += new System.EventHandler(this.bntCancel_Click);
            // 
            // ChooseDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.gridControlDB);
            this.Controls.Add(this.bntExecSQL);
            this.Controls.Add(this.txtChooseDBSQL);
            this.Name = "ChooseDataBase";
            this.Text = "ChooseDataBase";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChooseDBSQL;
        private System.Windows.Forms.Button bntExecSQL;
        private DevExpress.XtraGrid.GridControl gridControlDB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDBName;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button bntCancel;
    }
}