using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateNextYear_Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateNextYear_Core.Enities;
using System.IO;
using Newtonsoft.Json;
using SQLDryAlive.Core;

namespace NewYearTests
{
    [TestClass()]
    public class T31082Tests
    {
        [TestMethod()]
        public void CreateSingleAccountNewYearTest()
        {
            Setting setting = GetSetting();
            var list = setting.createNewYearDbSentencesQueue.Select(e => new { name = e }).ToList();
           var aa = list.GroupBy(e=>e.name).Where(x => x.Count() > 1).ToList();
            T31082 t31082 = new T31082(setting);
            bool iscreated = t31082.CreateSingleAccountNewYear(getAccount());
            Assert.AreEqual(true, iscreated);
        }

        [TestMethod()]
        public void DifferentBettwenXmlAndSettingWithCreateNewYear()
        {
            Setting setting = GetSetting();
            SqlSentenceManagerParam param = GetSqlSentenceManageParam(setting);
            param.SqlSentenceQueue = setting.createNewYearDbSentencesQueue;
            SQLRepositoryManage manage = new SQLRepositoryManage();
            Dictionary<string, string[]> different = manage.CheckUpXmlSqlSentenceAndSqlSentenceManagerParam(@"temlpate\RDB", param);
            Assert.AreEqual(true, different["paraNameSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(false, different["paraNameXmlExceptSetting"].Count() >= 0);
            Assert.AreEqual(true, different["sentenceSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(false, different["sentenceXmlExceptSetting"].Count() >= 0);
        }
        [TestMethod()]
        public void DifferentBettwenXmlAndSettingWithCarryForwardGL()
        {
            Setting setting = GetSetting();
            SqlSentenceManagerParam param = GetSqlSentenceManageParam(setting);
            param.SqlSentenceQueue = setting.carryForwardGL;
            SQLRepositoryManage manage = new SQLRepositoryManage();
            Dictionary<string, string[]> different = manage.CheckUpXmlSqlSentenceAndSqlSentenceManagerParam(@"temlpate\CarryOverGL", param);
            Assert.AreEqual(true, different["paraNameSettingExceptXml"].Count()>=0);
            Assert.AreEqual(true, different["paraNameXmlExceptSetting"].Count()==0);
            Assert.AreEqual(true, different["sentenceSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(true, different["sentenceXmlExceptSetting"].Count() == 0);
            Assert.AreEqual(true, different["sentenceDistinct"].Count() == 0);
        }

        [TestMethod()]
        public void DifferentBettwenXmlAndSettingWithCarryForwardFA()
        {
            Setting setting = GetSetting();
            SqlSentenceManagerParam param = GetSqlSentenceManageParam(setting);
            param.SqlSentenceQueue = setting.carryForwardFA;
            SQLRepositoryManage manage = new SQLRepositoryManage();
            Dictionary<string, string[]> different = manage.CheckUpXmlSqlSentenceAndSqlSentenceManagerParam(@"temlpate\CarryOverFA", param);
            Assert.AreEqual(true, different["paraNameSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(true, different["paraNameXmlExceptSetting"].Count() == 0);
            Assert.AreEqual(true, different["sentenceSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(true, different["sentenceXmlExceptSetting"].Count() == 0);
            Assert.AreEqual(true, different["sentenceDistinct"].Count() == 0);
        }

        [TestMethod()]
        public void DifferentBettwenXmlAndSettingWithCarryForwardWA()
        {
            Setting setting = GetSetting();
            SqlSentenceManagerParam param = GetSqlSentenceManageParam(setting);
            param.SqlSentenceQueue = setting.carryForwardWA;
            SQLRepositoryManage manage = new SQLRepositoryManage();
            Dictionary<string, string[]> different = manage.CheckUpXmlSqlSentenceAndSqlSentenceManagerParam(@"temlpate\CarryOverWA", param);
            Assert.AreEqual(true, different["paraNameSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(true, different["paraNameXmlExceptSetting"].Count() == 0);
            Assert.AreEqual(true, different["sentenceSettingExceptXml"].Count() >= 0);
            Assert.AreEqual(true, different["sentenceXmlExceptSetting"].Count() == 0);
            Assert.AreEqual(true, different["sentenceDistinct"].Count() == 0);

        }
  
        private SqlSentenceManagerParam GetSqlSentenceManageParam(Setting setting)
        {
            SqlSentenceManagerParam param = new SqlSentenceManagerParam();
            UA_Account acc = getAccount();
            param.ParamNameValues = new Dictionary<string, string>();
            param.ParamNameValues.Add("{ufmodelPath}", string.Format("{0}ufmodel.bak", acc.cAcc_Path + "\\"));
            param.ParamNameValues.Add("{mdfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.MDF", acc.cAcc_Path + "\\", acc.cAcc_Id, setting.newYear));
            param.ParamNameValues.Add("{ldfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.LDF", acc.cAcc_Path + "\\", acc.cAcc_Id, setting.newYear));
            param.ParamNameValues.Add("{cAcc_Id}", acc.cAcc_Id);
            param.ParamNameValues.Add("{newYear}", setting.newYear);
            param.ParamNameValues.Add("{oldYear}", setting.oldYear);
            param.ParamNameValues.Add("{newYearDB}", string.Format("UFDATA_{0}_{1}", acc.cAcc_Id, setting.newYear));
            param.ParamNameValues.Add("{oldYearDB}", string.Format("UFDATA_{0}_{1}", acc.cAcc_Id, setting.oldYear));

            
            return param;
        }

        [TestMethod()]
        public void GetManyAccountHasModulesTest()
        {
            Setting setting = GetSetting();
            T31082 t31082 = new T31082(setting);
            Dictionary<string,string[]> modules= t31082.GetManyAccountHasUseModules(new List<string> { "096" }, setting.allowModules);
            Assert.AreEqual(modules[modules.Keys.First()].Count(), 3);
            Assert.AreEqual(modules.Keys.First(), "096");

        }

        private  Setting GetSetting()
        {
            string file = File.ReadAllText("setting.js");
            return JsonConvert.DeserializeObject<Setting>(file);
        }
        private UA_Account getAccount()
        {
            return new UA_Account
            {
                cAcc_Id = "003",
                cAcc_Name = "aa",
                cAcc_Path = @"c:\ufdata\admin\"
            };
        }
    }
}