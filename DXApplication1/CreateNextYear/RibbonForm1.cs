using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CreateNextYear.NewYear;
using CreateNextYear.Tool;

namespace CreateNextYear
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryAccounts selectAccs = new QueryAccounts();
            selectAccs.MdiParent = this;
            selectAccs.Show();
        }

        private void bbiNewYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CreateNewYear.ToString());
        }

        private static void ChooseAccountsAndshowOperate(string operateType)
        {
           // ChooseAcc chooseAccs = new ChooseAcc();
           ChooseAccounts chooseAccs = new ChooseAccounts();
            //chooseAccs.Show();
            if (chooseAccs.ShowDialog() == DialogResult.OK)
            {
                chooseAccs.Close();
                OperateDetail operateDetial = new OperateDetail(operateType);
                operateDetial.ShowDialog();
            }
        }

        private void bbiLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            LogManage logManage = new LogManage();
            logManage.MdiParent = this;
            logManage.Show();
        }

        private void bbiCheckAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CheckAll.ToString());
        }

        private void bbiCheckGL_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CheckGL.ToString());

        }

        private void bbiCheckWA_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CheckWA.ToString());

        }

        private void bbiCheckFA_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CheckFA.ToString());

        }


        private void bbiCarryGL_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CarryForwardGL.ToString());

        }

        private void bbiCarryWA_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CarryForwardWA.ToString());

        }

        private void bbiCarryFA_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CarryForwardFA.ToString());

        }

        private void bbiCarryAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChooseAccountsAndshowOperate(MyAppContext.opertateType.CarryForwardAll.ToString());

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

                       ChooseDataBase chooseDBs = new ChooseDataBase();

            if (chooseDBs.ShowDialog() == DialogResult.OK)
            {
                chooseDBs.Close();
   
              //  operateDetial.ShowDialog();
            }
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

            IncludeExclude includExclude = new IncludeExclude();

            if (includExclude.ShowDialog() == DialogResult.OK)
            {
                includExclude.Close();

                //  operateDetial.ShowDialog();
            }
        }
    }
}