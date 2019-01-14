namespace CreateNextYear.NewYear
{
    partial class QueryAccounts
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcAcc_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Master = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcTradeKind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAccount = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcAcc_Id,
            this.colcAcc_Name,
            this.colcAcc_Path,
            this.coliYear,
            this.coliMonth,
            this.colcAcc_Master,
            this.colcUnitName,
            this.colcTradeKind,
            this.colGL,
            this.colFA,
            this.colWA,
            this.colIA,
            this.colGX});
            this.gridView1.GridControl = this.gridAccount;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colcAcc_Id
            // 
            this.colcAcc_Id.Caption = "账套号";
            this.colcAcc_Id.FieldName = "cAcc_Id";
            this.colcAcc_Id.Name = "colcAcc_Id";
            this.colcAcc_Id.OptionsColumn.ReadOnly = true;
            this.colcAcc_Id.Visible = true;
            this.colcAcc_Id.VisibleIndex = 0;
            // 
            // colcAcc_Name
            // 
            this.colcAcc_Name.Caption = "帐套名称";
            this.colcAcc_Name.FieldName = "cAcc_Name";
            this.colcAcc_Name.Name = "colcAcc_Name";
            this.colcAcc_Name.Visible = true;
            this.colcAcc_Name.VisibleIndex = 1;
            // 
            // colcAcc_Path
            // 
            this.colcAcc_Path.Caption = "路径";
            this.colcAcc_Path.FieldName = "cAcc_Path";
            this.colcAcc_Path.Name = "colcAcc_Path";
            this.colcAcc_Path.Visible = true;
            this.colcAcc_Path.VisibleIndex = 2;
            // 
            // coliYear
            // 
            this.coliYear.Caption = "年";
            this.coliYear.FieldName = "iYear";
            this.coliYear.Name = "coliYear";
            this.coliYear.Visible = true;
            this.coliYear.VisibleIndex = 3;
            // 
            // coliMonth
            // 
            this.coliMonth.Caption = "月";
            this.coliMonth.FieldName = "iMonth";
            this.coliMonth.Name = "coliMonth";
            this.coliMonth.Visible = true;
            this.coliMonth.VisibleIndex = 4;
            // 
            // colcAcc_Master
            // 
            this.colcAcc_Master.Caption = "创建人";
            this.colcAcc_Master.FieldName = "cAcc_Master";
            this.colcAcc_Master.Name = "colcAcc_Master";
            this.colcAcc_Master.Visible = true;
            this.colcAcc_Master.VisibleIndex = 5;
            // 
            // colcUnitName
            // 
            this.colcUnitName.Caption = "名称";
            this.colcUnitName.FieldName = "cUnitName";
            this.colcUnitName.Name = "colcUnitName";
            this.colcUnitName.Visible = true;
            this.colcUnitName.VisibleIndex = 6;
            // 
            // colcTradeKind
            // 
            this.colcTradeKind.Caption = "类型";
            this.colcTradeKind.FieldName = "cTradeKind";
            this.colcTradeKind.Name = "colcTradeKind";
            this.colcTradeKind.Visible = true;
            this.colcTradeKind.VisibleIndex = 7;
            // 
            // colGL
            // 
            this.colGL.Caption = "总账";
            this.colGL.FieldName = "GL";
            this.colGL.Name = "colGL";
            this.colGL.Visible = true;
            this.colGL.VisibleIndex = 8;
            // 
            // colFA
            // 
            this.colFA.Caption = "固定资产";
            this.colFA.FieldName = "FA";
            this.colFA.Name = "colFA";
            this.colFA.Visible = true;
            this.colFA.VisibleIndex = 9;
            // 
            // colWA
            // 
            this.colWA.Caption = "工资";
            this.colWA.FieldName = "WA";
            this.colWA.Name = "colWA";
            this.colWA.Visible = true;
            this.colWA.VisibleIndex = 10;
            // 
            // colIA
            // 
            this.colIA.Caption = "核算";
            this.colIA.FieldName = "IA";
            this.colIA.Name = "colIA";
            this.colIA.Visible = true;
            this.colIA.VisibleIndex = 11;
            // 
            // colGX
            // 
            this.colGX.Caption = "购销存";
            this.colGX.FieldName = "GX";
            this.colGX.Name = "colGX";
            this.colGX.Visible = true;
            this.colGX.VisibleIndex = 12;
            // 
            // gridAccount
            // 
            this.gridAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccount.Location = new System.Drawing.Point(0, 0);
            this.gridAccount.MainView = this.gridView1;
            this.gridAccount.Name = "gridAccount";
            this.gridAccount.Size = new System.Drawing.Size(812, 397);
            this.gridAccount.TabIndex = 0;
            this.gridAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // QueryAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 397);
            this.Controls.Add(this.gridAccount);
            this.Name = "QueryAccounts";
            this.Text = "QueryAccounts";
            this.Load += new System.EventHandler(this.QueryAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Path;
        private DevExpress.XtraGrid.Columns.GridColumn coliYear;
        private DevExpress.XtraGrid.Columns.GridColumn coliMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Master;
        private DevExpress.XtraGrid.Columns.GridColumn colcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colcTradeKind;
        private DevExpress.XtraGrid.GridControl gridAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colGL;
        private DevExpress.XtraGrid.Columns.GridColumn colFA;
        private DevExpress.XtraGrid.Columns.GridColumn colWA;
        private DevExpress.XtraGrid.Columns.GridColumn colIA;
        private DevExpress.XtraGrid.Columns.GridColumn colGX;
    }
}