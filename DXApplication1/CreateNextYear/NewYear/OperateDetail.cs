using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CreateNextYear.Manage;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;

namespace CreateNextYear.NewYear
{
    public partial class OperateDetail : DevExpress.XtraEditors.XtraForm
    {

        InterfaceT3 t3 = new ManagerT3();
        string operateType;

        List<Account> accs=new List<Account>();
        List<UA_Account_sub> acc_subs = new List<UA_Account_sub>();

        string checkYear;
        //create year
        string newYear;
        /// <summary>
        /// arg for backgroundWork
        /// </summary>
        class bwArg
        {
            public Account account { get; set; }
            public int LastFlag_GL { get; set; }
            public int LastFlag_FA { get; set; }
            public int LastFlag_WA { get; set; }
            public string Message { get; set; }
        }
       BackgroundWorker bw = new BackgroundWorker();
        public OperateDetail(string operateType)
        {
            this.operateType = operateType;
            InitializeComponent();

            this.Text = operateType;
            //init backgroundWorker
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.DoWork += Bw_DoWork;
        }

        private void OperateDetail_Load(object sender, EventArgs e)
        {
            List<Account> accounts = getAccsForDataSource();
            switch (operateType)
            {
                case "CreateNewYear":
                    accs = accounts;
                    // CreateNewYear();
                    break;
                case "CheckAll":
                    accs = accounts;
                    break;
                case "CheckGL":
                     accs = accounts.Where(x => x.GL == 1).ToList() ;
                    break;
                case "CheckWA":
                     accs= accounts.Where(x => x.WA == 1).ToList() ;
                    break;
                case "CheckFA":
                     accs= accounts.Where(x => x.FA == 1).ToList() ;
                    break;
                case "CarryForwardAll":
                    accs = accounts;
                    break;
                case "CarryForwardGL":
                    accs = accounts.Where(x => x.GL == 1).ToList();
                    break;

                case "CarryForwardWA":
                    accs = accounts.Where(x => x.WA == 1).ToList();

                    break;
                case "CarryForwardFA":
                     accs= accounts.Where(x => x.FA == 1).ToList() ;
                    break;
            }
            this.gridControl1.DataSource = accs;   
        }


   

        private void button1_Click(object sender, EventArgs e)
        {
            if (operateType==MyAppContext.opertateType.CheckWA.ToString()
                || operateType==MyAppContext.opertateType.CheckGL.ToString()
                || operateType==MyAppContext.opertateType.CheckFA.ToString()
                || operateType==MyAppContext.opertateType.CheckAll.ToString())
            {
                checkYear= textBox1.Text.Trim();
            }
            else
            {
                newYear = textBox1.Text.Trim();
            }

            bw.RunWorkerAsync();

        }

        #region backGroundWorker
        //--------------------------backGroundWorker
        /// <summary>
        /// thread logic things
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
             BackgroundWorker work = sender as BackgroundWorker;
            acc_subs = t3.getAccount_Subs();
            switch (operateType)
            {
                case "CreateNewYear":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        bool isSuccess = t3.CreateNewYear(acc,newYear,Convert.ToInt32(newYear)-1+"");
                        if (isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);
                    }
                    break;
                case "CheckAll":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };
                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        //get module is used in checkyear
                        int isGLModuleUsed = GetModuleIsUsedInCheckyear(acc, "GL");
                        int isFAModuleUsed = GetModuleIsUsedInCheckyear(acc, "FA");
                        int isWAModuleUsed = GetModuleIsUsedInCheckyear(acc, "WA");
                        //default last falg is -1
                        arg.LastFlag_GL = -1;
                        arg.LastFlag_FA = -1;
                        arg.LastFlag_WA = -1;
                        //if module is used get last flag
                        if (1==isGLModuleUsed)
                        {
                            arg.LastFlag_GL = t3.GetLastFlag_GL(acc.cAcc_Id, checkYear);
                        }
                        if (1==isFAModuleUsed)
                        {
                            arg.LastFlag_FA= t3.GetLastFlag_FA(acc.cAcc_Id, checkYear);
                        }
                        if (1 == isWAModuleUsed)
                        {
                            arg.LastFlag_WA = t3.GetLastFlag_WA(acc.cAcc_Id, checkYear);
                        }
                        //on-off 
                        bool isSuccess = true;
                        // if module is used but lastflag is not real last month
                        //trun off the on-off then UI set failer
                        if (true==isSuccess&& 1==isGLModuleUsed&& 12>arg.LastFlag_GL)
                        {
                            isSuccess = false;
                        }
                        else if (true == isSuccess && 1 == isFAModuleUsed && 12 > arg.LastFlag_FA)
                        {
                            isSuccess = false;
                        }
                        else if (true == isSuccess && 1 == isWAModuleUsed && 11 > arg.LastFlag_WA)
                        {
                            isSuccess = false;
                        }


                        if (isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);

                    }
                    break;
                case "CheckGL":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account=acc};
                        work.ReportProgress((int)MyAppContext.operateResult.运行中,arg);
                        //if not used subModule
                        if (0== GetModuleIsUsedInCheckyear(acc, "GL"))
                        {
                            arg.LastFlag_GL = -1;
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                            continue;
                        }
                            arg.LastFlag_GL= t3.GetLastFlag_GL(acc.cAcc_Id, checkYear);
                        if (12 == arg.LastFlag_GL)
                        { 
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);

                    }
                    break;
                case "CheckWA":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account=acc};
                        work.ReportProgress((int)MyAppContext.operateResult.运行中,arg);
                        //if not used subModule
                        if (0 == GetModuleIsUsedInCheckyear(acc,"WA"))
                        {
                            arg.LastFlag_WA = -1;
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                            continue;
                        }
                        arg.LastFlag_WA = t3.GetLastFlag_WA(acc.cAcc_Id, checkYear);

                        if ( 11 == arg.LastFlag_WA)
                            work.ReportProgress((int)MyAppContext.operateResult.成功,arg);
                        else
                            work.ReportProgress((int)MyAppContext.operateResult.错误,arg);

                    }
                    break;
                case "CheckFA":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中,arg);
                        //if not used subModule
                        if (0 == GetModuleIsUsedInCheckyear(acc,"FA"))
                        {
                            arg.LastFlag_FA = -1;
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                            continue;
                        }
                        arg.LastFlag_FA = t3.GetLastFlag_FA(acc.cAcc_Id, checkYear);
                        if (12 ==arg.LastFlag_FA)
                            work.ReportProgress((int)MyAppContext.operateResult.成功,arg);
                        else
                            work.ReportProgress((int)MyAppContext.operateResult.错误,arg);

                    }
                    break;
                case "CarryForwardGL":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        bool isGLUsed = t3.IsSubSysUsed(acc, Convert.ToInt32(newYear) - 1 + "","GL");
                        bool isSuccess = t3.CarryForwardGL(acc, Convert.ToInt32(newYear) - 1 + "", newYear);
                        if (isGLUsed&& isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                        {
                            if (!isGLUsed)
                                arg.Message = "工资未启用！";
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);
                        }
                    }
                    break;
                case "CarryForwardWA":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        bool isWAUsed = t3.IsSubSysUsed(acc, Convert.ToInt32(newYear) - 1 + "","WA");
                        bool isSuccess = t3.CarryForwardWA(acc, Convert.ToInt32(newYear) - 1 + "", newYear);
                        
                        if (isWAUsed && isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                        {
                            if (!isWAUsed)
                            {
                            arg.Message = "工资未启用！";

                            }
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);
                        }
                    }
                    break;

                case "CarryForwardFA":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        bool isFAUsed = t3.IsSubSysUsed(acc, Convert.ToInt32(newYear) - 1 + "", "FA");
                        bool isSuccess = t3.CarryForwardFA(acc, Convert.ToInt32(newYear) - 1 + "", newYear);
                        if (isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                        {
                            if (!isFAUsed)
                            arg.Message = "固定资产未启用！";
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);
                        }
                    }
                    break;
                case "CarryForwardAll":
                    foreach (Account acc in accs)
                    {
                        bwArg arg = new bwArg() { account = acc };

                        work.ReportProgress((int)MyAppContext.operateResult.运行中, arg);
                        bool isFAUsed = t3.IsSubSysUsed(acc, Convert.ToInt32(newYear) - 1 + "", "FA");
                        bool isSuccess = t3.CarryForwardFA(acc, Convert.ToInt32(newYear) - 1 + "", newYear);
                        if (isSuccess)
                        {
                            work.ReportProgress((int)MyAppContext.operateResult.成功, arg);
                        }
                        else
                        {
                            if (!isFAUsed)
                                arg.Message = "固定资产未启用！";
                            work.ReportProgress((int)MyAppContext.operateResult.错误, arg);
                        }
                    }
                    break;
            
            
            }
        }
        /// <summary>
        /// get the report progress result and effect to UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bwArg arg =e.UserState as bwArg;
            switch (operateType)
            {
                case "CreateNewYear":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = string.Format("新建年度账成功！");
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = string.Format("新建年度账失败！");
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);

                            break;
                    }
                    break;
                case "CheckAll":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = string.Format("总账:{0},固定资产：{1},工资：{2}", arg.LastFlag_GL, arg.LastFlag_FA, arg.LastFlag_WA);
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result =string.Format( "总账:{0},固定资产：{1},工资：{2}" ,arg.LastFlag_GL,arg.LastFlag_FA,arg.LastFlag_WA);
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;

                    }
                    break;
                case "CheckGL":

                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "总账结账月份:" + arg.LastFlag_GL;
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "总账结账月份:" + arg.LastFlag_GL;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    
                    }
                            break;
                case "CheckWA":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "工资结账月份:" + arg.LastFlag_WA;
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "工资结账月份:" + arg.LastFlag_WA;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;
                case "CheckFA":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "固定资产结账月份:" + arg.LastFlag_FA;
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "固定资产结账月份:" + arg.LastFlag_FA;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;
                case "CarryForwardGL":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "结转总账成功";
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "结转总账失败"+arg.Message;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;
                case "CarryForwardWA":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "结转工资成功";
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "结转工资失败"+arg.Message;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;

                case "CarryForwardFA":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "结转固定资产成功";
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "结转固定资产失败"+arg.Message;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;
                case "CarryForwardAll":
                    switch (e.ProgressPercentage)
                    {
                        case (int)MyAppContext.operateResult.运行中:
                            arg.account.result = MyAppContext.operateResult.运行中.ToString();
                            arg.account.image = imageCollection1.Images[0];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.成功:
                            arg.account.result = "结转账套成功";
                            arg.account.image = imageCollection1.Images[1];
                            UpdataUI(arg.account);
                            break;
                        case (int)MyAppContext.operateResult.错误:
                            arg.account.result = "结转账套失败"+arg.Message;
                            arg.account.image = imageCollection1.Images[2];
                            UpdataUI(arg.account);
                            break;
                    }
                    break;
            }
         
        }
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("runcompleted!");
            //TestThread();          
        }
        //-------------------backGroundWork end
        #endregion
        private List<Account> getAccsForDataSource()
        {

            return (from acc in t3.GetAccountsAndSub()
                                  from id in MyAppContext.accNo
                                  where acc.cAcc_Id == id
                                  orderby acc.cAcc_Id
                                  select new Account
                                  {
                                      cAcc_Id = acc.cAcc_Id,
                                      cAcc_Name = acc.cAcc_Name,
                                      cAcc_Path = acc.cAcc_Path,
                                      iYear = acc.iYear,
                                      iMonth = acc.iMonth,
                                      cAcc_Master = acc.cAcc_Master,
                                      cUnitName = acc.cUnitName,
                                      cTradeKind = acc.cTradeKind,
                                      GL = acc.GL,
                                      FA = acc.FA,
                                      WA = acc.WA,
                                      IA = acc.IA,
                                      GX=acc.GX,
                                      image = imageCollection1.Images[3],
                                      result = "等待"
                                  }).ToList();
        }
        private int GetModuleIsUsedInCheckyear(Account acc,string subModule)
        {
            //get subModule with checkyear is used
            return acc_subs.Where(x => x.cAcc_Id == acc.cAcc_Id && x.cSub_Id == subModule && x.iYear.ToString() == this.checkYear).Count();
        }

        private void UpdataUI(Account acc)
        {
            switch (operateType)
            {
                case "CreateNewYear":
                    // CreateNewYear();
                    break;
                case "CheckAll":
                    break;
                case "CheckGL":

                    break;
                case "CheckWA":

                    break;
                case "CheckFA":

                    break;
                case "CarryForwardGL": break;
                case "CarryForwardWA": break;
                case "CarryForwardFA": break;
                case "CarryForwardAll":
                    break;
            }
            meRunResult.Text += "当前运行："+acc.cAcc_Id +"；状态为:"+acc.result+"\r\n";
            gridControl1.RefreshDataSource();
        }






    }
}