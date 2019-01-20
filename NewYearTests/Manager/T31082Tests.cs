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
            bool iscreated= t31082.CreateSingleAccountNewYear(new UA_Account
            {
                cAcc_Id = "003",
                cAcc_Name = "aa",
                cAcc_Path = @"c:\ufdata\admin\"
            });
            Assert.AreEqual(true, iscreated);
        }

        private  Setting GetSetting()
        {
            string file = File.ReadAllText("setting.js");
            return JsonConvert.DeserializeObject<Setting>(file);
        }
    }
}