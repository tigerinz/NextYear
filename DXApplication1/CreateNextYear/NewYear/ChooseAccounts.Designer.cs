namespace CreateNextYear.NewYear
{
    partial class ChooseAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAccounts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uA_AccountGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcAcc_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcTradeKind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcAcc_Master = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sbCanale = new DevExpress.XtraEditors.SimpleButton();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uA_AccountGridControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 462);
            this.panel1.TabIndex = 0;
            // 
            // uA_AccountGridControl
            // 
            this.uA_AccountGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uA_AccountGridControl.Location = new System.Drawing.Point(0, 0);
            this.uA_AccountGridControl.MainView = this.gridView1;
            this.uA_AccountGridControl.Name = "uA_AccountGridControl";
            this.uA_AccountGridControl.Size = new System.Drawing.Size(802, 462);
            this.uA_AccountGridControl.TabIndex = 0;
            this.uA_AccountGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcAcc_Id,
            this.colcAcc_Name,
            this.colcUnitName,
            this.coliMonth,
            this.coliYear,
            this.colcTradeKind,
            this.colcAcc_Path,
            this.colcAcc_Master});
            this.gridView1.GridControl = this.uA_AccountGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colcAcc_Id
            // 
            this.colcAcc_Id.Caption = "账套号";
            this.colcAcc_Id.FieldName = "cAcc_Id";
            this.colcAcc_Id.Name = "colcAcc_Id";
            this.colcAcc_Id.Visible = true;
            this.colcAcc_Id.VisibleIndex = 1;
            // 
            // colcAcc_Name
            // 
            this.colcAcc_Name.Caption = "帐套名称";
            this.colcAcc_Name.FieldName = "cAcc_Name";
            this.colcAcc_Name.Name = "colcAcc_Name";
            this.colcAcc_Name.Visible = true;
            this.colcAcc_Name.VisibleIndex = 3;
            // 
            // colcUnitName
            // 
            this.colcUnitName.Caption = "名称";
            this.colcUnitName.FieldName = "cUnitName";
            this.colcUnitName.Name = "colcUnitName";
            this.colcUnitName.Visible = true;
            this.colcUnitName.VisibleIndex = 8;
            // 
            // coliMonth
            // 
            this.coliMonth.Caption = "月";
            this.coliMonth.FieldName = "iMonth";
            this.coliMonth.Name = "coliMonth";
            this.coliMonth.Visible = true;
            this.coliMonth.VisibleIndex = 6;
            // 
            // coliYear
            // 
            this.coliYear.Caption = "年";
            this.coliYear.FieldName = "iYear";
            this.coliYear.Name = "coliYear";
            this.coliYear.Visible = true;
            this.coliYear.VisibleIndex = 7;
            // 
            // colcTradeKind
            // 
            this.colcTradeKind.Caption = "类型";
            this.colcTradeKind.FieldName = "cTradeKind";
            this.colcTradeKind.Name = "colcTradeKind";
            this.colcTradeKind.Visible = true;
            this.colcTradeKind.VisibleIndex = 5;
            // 
            // colcAcc_Path
            // 
            this.colcAcc_Path.Caption = "路径";
            this.colcAcc_Path.FieldName = "cAcc_Path";
            this.colcAcc_Path.Name = "colcAcc_Path";
            this.colcAcc_Path.Visible = true;
            this.colcAcc_Path.VisibleIndex = 4;
            // 
            // colcAcc_Master
            // 
            this.colcAcc_Master.Caption = "创建人";
            this.colcAcc_Master.FieldName = "cAcc_Master";
            this.colcAcc_Master.Name = "colcAcc_Master";
            this.colcAcc_Master.Visible = true;
            this.colcAcc_Master.VisibleIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sbCanale);
            this.panel2.Controls.Add(this.sbOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 379);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 83);
            this.panel2.TabIndex = 1;
            // 
            // sbCanale
            // 
            this.sbCanale.Image = ((System.Drawing.Image)(resources.GetObject("sbCanale.Image")));
            this.sbCanale.Location = new System.Drawing.Point(419, 33);
            this.sbCanale.Name = "sbCanale";
            this.sbCanale.Size = new System.Drawing.Size(75, 35);
            this.sbCanale.TabIndex = 1;
            this.sbCanale.Text = "取消";
            this.sbCanale.Click += new System.EventHandler(this.sbCanale_Click);
            // 
            // sbOK
            // 
            this.sbOK.Image = ((System.Drawing.Image)(resources.GetObject("sbOK.Image")));
            this.sbOK.Location = new System.Drawing.Point(306, 33);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 35);
            this.sbOK.TabIndex = 0;
            this.sbOK.Text = "确定";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // ChooseAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChooseAccounts";
            this.Text = "ChooseAccounts";
            this.Load += new System.EventHandler(this.ChooseAccounts_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uA_AccountGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton sbCanale;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraGrid.GridControl uA_AccountGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn coliMonth;
        private DevExpress.XtraGrid.Columns.GridColumn coliYear;
        private DevExpress.XtraGrid.Columns.GridColumn colcTradeKind;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Path;
        private DevExpress.XtraGrid.Columns.GridColumn colcAcc_Master;
    }
}