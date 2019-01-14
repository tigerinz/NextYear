namespace CreateNextYear
{
    partial class RibbonForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonForm1));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            this.bsNewYear = new DevExpress.XtraBars.BarSubItem();
            this.bbiNewGL = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewWA = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewFA = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bsCheck = new DevExpress.XtraBars.BarSubItem();
            this.bbiCheckAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCheckGL = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCheckWA = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCheckFA = new DevExpress.XtraBars.BarButtonItem();
            this.bsCarryForward = new DevExpress.XtraBars.BarSubItem();
            this.bbiCarryAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCarryGL = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCarryWA = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCarryFA = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewYear = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLog = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSelect,
            this.bsNewYear,
            this.bbiNewGL,
            this.bbiNewWA,
            this.bbiNewFA,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.bsCheck,
            this.bbiCheckGL,
            this.bbiCheckWA,
            this.bbiCheckFA,
            this.bsCarryForward,
            this.bbiCarryGL,
            this.bbiCarryWA,
            this.bbiCarryFA,
            this.bbiNewYear,
            this.bbiLog,
            this.bbiCheckAll,
            this.bbiCarryAll,
            this.barButtonItem4,
            this.barButtonItem5,
            this.ribbonGalleryBarItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 28;
            this.ribbon.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(803, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiSelect
            // 
            this.bbiSelect.Caption = "查询";
            this.bbiSelect.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSelect.Glyph")));
            this.bbiSelect.Id = 1;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSelect_ItemClick);
            // 
            // bsNewYear
            // 
            this.bsNewYear.Caption = "新建";
            this.bsNewYear.Glyph = ((System.Drawing.Image)(resources.GetObject("bsNewYear.Glyph")));
            this.bsNewYear.Id = 5;
            this.bsNewYear.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewGL),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewWA),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewFA)});
            this.bsNewYear.Name = "bsNewYear";
            this.bsNewYear.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiNewGL
            // 
            this.bbiNewGL.Caption = "总账";
            this.bbiNewGL.Id = 6;
            this.bbiNewGL.Name = "bbiNewGL";
            // 
            // bbiNewWA
            // 
            this.bbiNewWA.Caption = "工资";
            this.bbiNewWA.Id = 7;
            this.bbiNewWA.Name = "bbiNewWA";
            // 
            // bbiNewFA
            // 
            this.bbiNewFA.Caption = "固定资产";
            this.bbiNewFA.Id = 8;
            this.bbiNewFA.Name = "bbiNewFA";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "总账";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "工资";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "固定资产";
            this.barButtonItem3.Id = 12;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // bsCheck
            // 
            this.bsCheck.Caption = "检查";
            this.bsCheck.Glyph = ((System.Drawing.Image)(resources.GetObject("bsCheck.Glyph")));
            this.bsCheck.Id = 13;
            this.bsCheck.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckGL),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckWA),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckFA)});
            this.bsCheck.Name = "bsCheck";
            this.bsCheck.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiCheckAll
            // 
            this.bbiCheckAll.Caption = "全部";
            this.bbiCheckAll.Id = 23;
            this.bbiCheckAll.Name = "bbiCheckAll";
            this.bbiCheckAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCheckAll_ItemClick);
            // 
            // bbiCheckGL
            // 
            this.bbiCheckGL.Caption = "总账";
            this.bbiCheckGL.Id = 14;
            this.bbiCheckGL.Name = "bbiCheckGL";
            this.bbiCheckGL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCheckGL_ItemClick);
            // 
            // bbiCheckWA
            // 
            this.bbiCheckWA.Caption = "工资";
            this.bbiCheckWA.Id = 15;
            this.bbiCheckWA.Name = "bbiCheckWA";
            this.bbiCheckWA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCheckWA_ItemClick);
            // 
            // bbiCheckFA
            // 
            this.bbiCheckFA.Caption = "固定资产";
            this.bbiCheckFA.Id = 16;
            this.bbiCheckFA.Name = "bbiCheckFA";
            this.bbiCheckFA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCheckFA_ItemClick);
            // 
            // bsCarryForward
            // 
            this.bsCarryForward.Caption = "年结";
            this.bsCarryForward.Glyph = ((System.Drawing.Image)(resources.GetObject("bsCarryForward.Glyph")));
            this.bsCarryForward.Id = 17;
            this.bsCarryForward.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCarryAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCarryGL),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCarryWA),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCarryFA)});
            this.bsCarryForward.Name = "bsCarryForward";
            this.bsCarryForward.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiCarryAll
            // 
            this.bbiCarryAll.Caption = "全部";
            this.bbiCarryAll.Id = 24;
            this.bbiCarryAll.Name = "bbiCarryAll";
            this.bbiCarryAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCarryAll_ItemClick);
            // 
            // bbiCarryGL
            // 
            this.bbiCarryGL.Caption = "总账";
            this.bbiCarryGL.Id = 18;
            this.bbiCarryGL.Name = "bbiCarryGL";
            this.bbiCarryGL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCarryGL_ItemClick);
            // 
            // bbiCarryWA
            // 
            this.bbiCarryWA.Caption = "工资";
            this.bbiCarryWA.Id = 19;
            this.bbiCarryWA.Name = "bbiCarryWA";
            this.bbiCarryWA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCarryWA_ItemClick);
            // 
            // bbiCarryFA
            // 
            this.bbiCarryFA.Caption = "固定资产";
            this.bbiCarryFA.Id = 20;
            this.bbiCarryFA.Name = "bbiCarryFA";
            this.bbiCarryFA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCarryFA_ItemClick);
            // 
            // bbiNewYear
            // 
            this.bbiNewYear.Caption = "新年度";
            this.bbiNewYear.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiNewYear.Glyph")));
            this.bbiNewYear.Id = 21;
            this.bbiNewYear.Name = "bbiNewYear";
            this.bbiNewYear.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiNewYear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNewYear_ItemClick);
            // 
            // bbiLog
            // 
            this.bbiLog.Caption = "操作日志";
            this.bbiLog.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiLog.Glyph")));
            this.bbiLog.Id = 22;
            this.bbiLog.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiLog.LargeGlyph")));
            this.bbiLog.Name = "bbiLog";
            this.bbiLog.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLog_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "数据库批量执行sql";
            this.barButtonItem4.Id = 25;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup7});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "年结";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSelect);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "账套";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiNewYear);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "新年度";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bsCheck);
            this.ribbonPageGroup2.ItemLinks.Add(this.bsCarryForward);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "年结检查";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bbiLog);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "日志";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "工具";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "ribbonPageGroup6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(803, 31);
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "结转";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "inclue";
            this.barButtonItem5.Id = 26;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 27;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // RibbonForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "RibbonForm1";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "RibbonForm1";
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiSelect;

        private DevExpress.XtraBars.BarSubItem bsNewYear;
        private DevExpress.XtraBars.BarButtonItem bbiNewGL;
        private DevExpress.XtraBars.BarButtonItem bbiNewWA;
        private DevExpress.XtraBars.BarButtonItem bbiNewFA;

        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem bsCheck;
        private DevExpress.XtraBars.BarButtonItem bbiCheckGL;
        private DevExpress.XtraBars.BarButtonItem bbiCheckWA;
        private DevExpress.XtraBars.BarButtonItem bbiCheckFA;
        private DevExpress.XtraBars.BarSubItem bsCarryForward;
        private DevExpress.XtraBars.BarButtonItem bbiCarryGL;
        private DevExpress.XtraBars.BarButtonItem bbiCarryWA;
        private DevExpress.XtraBars.BarButtonItem bbiCarryFA;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem bbiNewYear;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem bbiLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem bbiCheckAll;
        private DevExpress.XtraBars.BarButtonItem bbiCarryAll;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
    }
}