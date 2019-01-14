using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace CreateNextYear
{
    public class CreateNextYearService
    {
        CreateNextYearDAL createNewYearDal = new CreateNextYearDAL();


        public void CreateNextYear(List<UA_AccountEntity> accounts, int newyear)
        {
            string currentDirectory = Environment.CurrentDirectory;
            foreach (UA_AccountEntity acc in accounts)
            {
                string log =CreateOneAccount(acc, newyear);
                string filePath= currentDirectory+"\\"+ acc.Cacc_id + "_" + acc.Newyear + ".txt";
                WriterLogToDisk(filePath, log);

            }
           
        }

        private string CreateOneAccount(UA_AccountEntity acc, int newyear)
        {
            StringBuilder sb = new StringBuilder();
            Log log = new Log();
            string getMaxYear = createNewYearDal.GetMaxYear(acc);

            log.setLogPart(sb, "createNewYearDal.GetMaxYear", getMaxYear);
            acc.Newyear = newyear;

            string isNewYearExists = "";
            if (createNewYearDal.isNewYearExists(acc, ref isNewYearExists))
                return log.setLogPart(sb, "createNewYearDal.isNewYearExists",isNewYearExists).ToString();

            string greateNewYearFloder = CreateNewYearFloder(acc);
            string greateNewDBSQL = createNewYearDal.CreateNewDBSQL(acc);
            string batchImportTables = createNewYearDal.BatchImportTables(acc);
            string modifyNewDBSQL = createNewYearDal.ModifyNewDBSQL(acc);

            log.setLogPart(sb, "CreateNewYearFloder", greateNewYearFloder)
                .setLogPart(sb, "createNewYearDal.CreateNewDBSQL", greateNewDBSQL)
                .setLogPart(sb, "createNewYearDal.BatchImportTable", batchImportTables)
                .setLogPart(sb, "createNewYearDal.ModifyNewDBSQL", modifyNewDBSQL);

            return sb.ToString();
        }

        private string CreateNewYearFloder(UA_AccountEntity acc)
        {
            string newYearFloder = acc.Cacc_path + "ZT" + acc.Cacc_id + "\\" + acc.Newyear;

            if (!Directory.Exists(newYearFloder))
            {
                Directory.CreateDirectory(newYearFloder);
                return newYearFloder + "文件夹创建成功！";
            }
            return newYearFloder + "文件夹已存在！";
        }

        public void WriterLogToDisk(string path, string log)
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
