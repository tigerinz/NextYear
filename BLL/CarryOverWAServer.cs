using CreateNextYear;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CarryOverWAServer
    {
        CreateNextYearDAL createNewYearDal = new CreateNextYearDAL();
        CarryOverWADAL carryOverWADal = new CarryOverWADAL();
        public void CarryOverWA(List<UA_AccountEntity> accounts,int newYear)
        {
            string currentDirectory = Environment.CurrentDirectory+"\\WA";
            foreach (UA_AccountEntity acc in accounts)
            {
                string log = CreateOneAccount(acc, newYear);
                string filePath = currentDirectory + "\\" + acc.Cacc_id + "_" + acc.Newyear + ".txt";
                WriterLogToDisk(filePath, log);

            }
        }

        private string CreateOneAccount(UA_AccountEntity acc, int newyear)
        {
            StringBuilder sb = new StringBuilder();
            Log log = new Log();
            string getMaxYear = createNewYearDal.GetMaxYear(acc);
            if (acc.Maxyear != newyear)
                return acc.Maxyear + "！=" + newyear;
               acc.Maxyear= acc.Maxyear - 1;
            log.setLogPart(sb, "createNewYearDal.GetMaxYear", getMaxYear);
            acc.Newyear = newyear;

           // string isNewYearExists = "";
          //  if (!createNewYearDal.isNewYearExists(acc, ref isNewYearExists))
          //      return log.setLogPart(sb, "createNewYearDal.isNewYearExists is false", isNewYearExists).ToString();

            string batchImportWATables= carryOverWADal.BatchImportWATables(acc);
            string modfiyWATables = carryOverWADal.ModfiyWATables(acc);

            log.setLogPart(sb, "carryOverWADal.BatchImportWATables", batchImportWATables)
                .setLogPart(sb, "carryOverWA.ModfiyWATables", modfiyWATables);


            return sb.ToString();
        }

        private void WriterLogToDisk(string path, string log)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(log);
                    sw.Flush();

                }
            }
        }
    }
}
