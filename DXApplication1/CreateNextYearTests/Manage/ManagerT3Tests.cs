using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateNextYear.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CreateNextYear.Manage.Tests
{
    [TestClass()]
    public class ManagerT3Tests
    {
        [TestMethod()]
        public void GetLastFlagAllTest()
        {
            ManagerT3 t3 = new ManagerT3();
            List<int> list = t3.GetLastFlagAll("003", "2016");
            Console.Write(list.ToString());
            Assert.AreEqual(list, null);
        }

        [TestMethod()]
        public void GetLastFlag_GLTest()
        {
            ManagerT3 t3 = new ManagerT3();
            int flag = t3.GetLastFlag_GL("003", "2016");
            Assert.AreEqual(flag, 6);
        }

        [TestMethod()]
        public void GetLastFlag_FATest()
        {
            ManagerT3 t3 = new ManagerT3();
            int flag = t3.GetLastFlag_GL("004", "2016");
            Assert.AreEqual(flag, 10);
        }

        [TestMethod()]
        public void testThread()
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerAsync();
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker work = sender as BackgroundWorker;
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine("for---------------------------{0}---------------", i);
                work.ReportProgress((int)MyAppContext.operateResult.运行中, i);

                //if (i%2==0)
                //     work.ReportProgress((int)MyAppContext.operateResult.成功,i);
                //   else
                //      work.ReportProgress((int)MyAppContext.operateResult.错误,i);

            }
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("write---------------------------{0}---------------", e.ProgressPercentage + "," + e.UserState);
        }

        [TestMethod()]
        public void CreateNewYearTest()
        {
            ManagerT3 t3 = new ManagerT3();
            Account acc = new Account();
            acc.cAcc_Id = "007";
            acc.cAcc_Path = @"c:\UFSMART\Admin\";
            bool i = t3.CreateNewYear(acc, "2017", "2016");
            Assert.AreEqual(i, true);
        }

        [TestMethod()]
        public void CarryForwardWATest()
        {
            ManagerT3 t3 = new ManagerT3();
            //bool b = t3.CarryForwardWA("006", "2016", "2017");
            //Assert.AreEqual(b, true);
        }

        [TestMethod()]
        public void CarryForwardGLTest()
        {
            ManagerT3 t3 = new ManagerT3();
            //bool b = t3.CarryForwardGL("006", "2016", "2017");
            //Assert.AreEqual(b, true);
        }

        [TestMethod()]
        public void CarryForwardFATest()
        {
            ManagerT3 t3 = new ManagerT3();
            //bool b = t3.CarryForwardFA("006", "2016", "2017");
            //Assert.AreEqual(b, true);
        }

        [TestMethod()]
        public void IsSubSysUsedTest()
        {
            ManagerT3 t3 = new ManagerT3();
            //bool b = t3.IsSubSysUsed("006", "2016", "WA");
            //Assert.AreEqual(b, true);
        }
    }
}