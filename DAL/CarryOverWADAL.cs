using COM;
using CreateNextYear;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
   public  class CarryOverWADAL
    {
        #region tables
                    //"WA_BankName",
        //            "WA_Bank",
            //"WA_Bank_set",
            //"WA_BankPar",
            //"WA_BankTop",
        string[] tables = new string[] {
            "WA_account",
            "WA_Auth",
            "WA_Authority",
            "wa_psn",
            "WA_GZItem",
            "WA_Formula",
            "WA_FT_Sum",
            "WA_Dept",
            "WA_PsnMsg",
            "WA_FilterExpList",
            "WA_FilterName",
            "WA_FTName",
            "WA_GZsumComCfg",
            "WA_FTInfo",
            "WA_FTDept",
            "WA_GZBName",
            "WA_GZBItemDept",
            "WA_GZBItemGrd",
            "WA_GZBItemTitle",
            "WA_tblRCsetP",
            "WA_tblRCsetM",
            "WA_GZData",
            "WA_Grade",
            "WA_GZHZB",
            "WA_SDS_p",
            "WA_SDS_SL",
            "WA_SelectMoney",
            "WA_JKItemSet",
            "WA_RatePayItems",
            "WA_State",
             "WA_GZtblSet"
        };
        #endregion
        CreateNextYearDAL createNextYearDal = new CreateNextYearDAL();
        String ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public string BatchImportWATables(UA_AccountEntity acc)
        {
            string ret = "";
            this.DeleteAllTable(acc);
            foreach (string tableName in tables)
            {
                string s1="", s2="";
                //table not exists out
                if (!createNextYearDal.IsTableExists(acc, tableName, ref s1))
                {
                    ret+=s1;
                    continue;
                }

                //no data out
                if (!createNextYearDal.IsTableHasRows(acc, tableName, ref s2))
                {
                     ret += s2 ;
                    continue;
                }


                ret += ImportOneTable(acc, tableName) + Environment.NewLine;
            }
            return ret;
        }
        private string DeleteAllTable(UA_AccountEntity acc)
        {
                string ret = "";
            foreach (string tableName in tables)
            {
                //table not exists out
                string s1 = "", s2 = "";
                //table not exists out
                if (!createNextYearDal.IsTableExists(acc, tableName, ref s1))
                {
                    ret += s1;
                    continue;
                }

                //no data out
                if (!createNextYearDal.IsTableHasRows(acc, tableName, ref s2))
                {
                    ret += s2;
                    continue;
                }
                string s = "delete from " + acc.TargerDB + ".." + tableName;
                DBHelper.ExecuteCommand(s);
                ret += s;
            }
            return ret;
        }
        
        public string ImportOneTable(UA_AccountEntity acc, string tableName)
        {
            string ret = "";
            try
            {

                //select source table to datatable
                DataTable table = DBHelper.GetDataSet("select * from  " + acc.SourceDB + ".." + tableName);

                //clear target table
                if (tableName == "WA_GZData")
                {
                    AddWA_GZDataColumn(acc);
                    table = null;
                    table = DBHelper.GetDataSet("select * from  " + acc.SourceDB + ".." + tableName + " where imonth=12");
                    foreach (DataRow item in table.Rows)
                    {
                        item["imonth"] = 1;
                    }
                   
                }
                if (tableName == "WA_GZHZB")
                    AddWA_GZHZBColumn(acc);
                if (tableName == "WA_GZtblSet")
                    DBHelper.ExecuteCommand("use " + acc.TargerDB + ";DBCC CHECKIDENT(WA_GZtblSet,RESEED,0)");
                
                //import target table
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(ConnStr, SqlBulkCopyOptions.UseInternalTransaction))
                {

                    sqlBulkCopy.DestinationTableName = acc.TargerDB + ".." + tableName;
                    sqlBulkCopy.WriteToServer(table);
                }

            }
            catch (Exception e)
            {

                return ret += tableName + ":导入失败！" + e.Message;
            }
            return ret += tableName + ":导入成功;";
        }

        public string AddWA_GZDataColumn(UA_AccountEntity acc)
        {
            string cmd =
                @" ALTER TABLE {0}..WA_GZData ADD F_7 numeric(18,2);
                 ALTER TABLE {0}..WA_GZData ADD F_8 numeric(18,2)";
            cmd = string.Format(cmd, acc.TargerDB);
            DBHelper.ExecuteCommand(cmd);
            return cmd;
        }
        public string AddWA_GZHZBColumn(UA_AccountEntity acc)
        {
            string cmd =
                @" ALTER TABLE {0}..WA_GZHZB ADD FG_7 numeric(18,2);
                 ALTER TABLE {0}..WA_GZHZB ADD FG_8 numeric(18,2)";
            cmd = string.Format(cmd, acc.TargerDB);
            DBHelper.ExecuteCommand(cmd);
            return cmd;
        }
        public string ModfiyWATables(UA_AccountEntity acc)
        {
            //{0}:ufdata_001_2016
            //{1}:ufdata_001_2015
            //{2};2016
            //{3}:2015
            string cmd =
                @"Update {0}..WA_GZData SET iMonth=1,iYear={2},iAccMonth=1;
                    Update {0}..WA_GZData SET F_5=F_4;
                    Update {0}..WA_GZData SET F_4=0,F_6 = 0;

                    UPDATE {1}..WA_State SET bCalBZ=1,bSumBZ=1;
                    UPDATE {0}..WA_State SET bCalBZ=0,bSumBZ=0;

                    UPDATE {1}..GL_mend SET bflag_WA=1 WHERE iperiod<=12;

                    UPDATE {1}..WA_account SET iLastMonth=12,iLastYear={3};
                    UPDATE {0}..WA_account SET iLastMonth=0,iLastYear={2}";
            string sourceDB = "ufdata_" + acc.Cacc_id + "_" + (acc.Newyear - 1);
            cmd = string.Format(cmd, acc.TargerDB, sourceDB, acc.Newyear, acc.Maxyear-1);
            DBHelper.ExecuteCommand(cmd);
            return cmd;
        }
    }
}
