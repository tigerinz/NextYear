using COM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CreateNextYear
{
   public class CreateNextYearDAL
    {
        #region ImportTables
        string[] tables = new string[] {
            "ReportData",
            "AA_columndic",
            "AA_columnset",
            "Accessaries",
            "AccInformation",
            "Ap_AlarmSet",
            "Ap_BillAge",
            "Ap_CtrlCode",
            "AP_DispSet",
            "Ap_InputCode",
            "Ap_InvCode",
            "Ap_Lock",
            "ap_Midexch",
            "Ap_MyTableSet ",
            "Ap_SStyleCode ",
            "Ap_VouchType",
            "Ap_YWBillAge",
            "Ar_BadAge ",
            "Bank",
            "BI_NB_Account ",
            "BI_NB_Option",
            "BI_NB_UserAuthority ",
            "BI_NB_VisibleField",
            "CellData_LRB",
            "CellData_SYZQY",
            "CellData_XJLL ",
            "CellData_ZCFZ ",
            "code",
            "CostObj ",
            "Customer",
            "CustomerClass ",
            "Dep_Auth",
            "Department",
            "DistrictClass ",
            "dsign ",
            "dsigns",
            "ExpenseItem ",
            "FA_Departments",
            "fitem ",
            "fitemgrademode",
            "fitemstructure",
            "fitemstrumode ",
            "foreigncurrency ",
            "GL_bage ",
            "GL_bautotran",
            "GL_bdigest",
            "GL_bfreq",
            "GL_blreq",
            "GL_bmulti ",
            "GL_btext",
            "GL_mcodeauth",
            "GL_mcodeused",
            "GL_mitemused",
            "GL_mybooktype ",
            "GL_myoutput ",
            "GradeDef",
            "Inventory ",
            "Inventory_1 ",
            "Inventory_2 ",
            "InventoryClass",
            "InvoiceItem ",
            "InvoiceItem_",
            "InvoiceItem_Ap",
            "InvoiceItem_ApPRN ",
            "InvoiceItem_PRN ",
            "InvoiceItem_sal ",
            "InvoiceItem_salPRN",
            "InvoiceItema",
            "InvoiceItemaPRN ",
            "KCHSItem",
            "KCHSItemPRN ",
            "MC_MessageTemplate",
            "MC_MessageTemplateAttach",
            "MC_MessageTemplateToList",
            "MC_MyAccount",
            "MC_SendTime ",
            "PayCondition",
            "Person",
            "PersonMSG ",
            "po",
            "poPRN ",
            "Position",
            "PrintDef",
            "PrintEx ",
            "ProductStructure",
            "ProductStructures ",
            "PS",
            "PSPRN ",
            "PurchaseType",
            "Rd_Style",
            "Rpt_FldDEF",
            "Rpt_FltDEF",
            "Rpt_Folder",
            "Rpt_GlbDef",
            "RPT_GrpDef",
            "RPT_ItmDef",
            "Rpt_RelDEF",
            "SaleType",
            "SettleStyle ",
            "ShippingChoice",
            "T_Rpt_FldDEF",
            "T_Rpt_FltDEF",
            "T_Rpt_Folder",
            "T_Rpt_GlbDEF",
            "T_Rpt_Property",
            "TAX_SB_NSSB_BJ_FB1",
            "TAX_SB_NSSB_BJ_FB2",
            "TAX_SB_NSSB_BJ_FB3",
            "TAX_SB_NSSB_BJ_GDZC ",
            "TAX_SB_NSSB_BJ_ZB ",
            "TAX_SB_NSSB_SH_FB1",
            "TAX_SB_NSSB_SH_FB2",
            "TAX_SB_NSSB_SH_FB3",
            "TAX_SB_NSSB_SH_FB4",
            "TAX_SB_NSSB_SH_GDZC ",
            "TAX_SB_NSSB_SH_YGZ_FB1",
            "TAX_SB_NSSB_SH_YGZ_FB2",
            "TAX_SB_NSSB_SH_ZB ",
            "TAX_SB_XGM_BJ_FB1 ",
            "TAX_SB_XGM_BJ_ZB",
            "TAX_SB_XGM_SH_FB1 ",
            "TAX_SB_XGM_SH_ZB",
            "ua_CloudCategory",
            "ua_CloundFin",
            "ua_CloundFinCode",
            "ufdts_datadel ",
            "ufdts_datalog ",
            "UserDef ",
            "UserDefine",
            "Vendor",
            "VendorClass ",
            "Vouchers",
            "VouchFormat ",
            "VouchFormats",
            "VouchList ",
            "VouchType ",
            "WareAuth",
            "Warehouse ",
            "WareHouseWarnInfo ",
            "wastage ",
            "VoucherNumber",
            "VoucherPrefabricate",
            "VoucherContrapose",
            "VoucherHistory"



            };
        #endregion
        String ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        StringBuilder CmdSb = new StringBuilder();

        public string BatchImportTables(UA_AccountEntity acc)
        {
            string ret = "";
            foreach (string tableName in tables)
            {
                ret+=ImportOneTable(acc, tableName)+Environment.NewLine;
            }
            return ret;
        }
        private  string ImportOneTable(UA_AccountEntity acc, string tableName)
        {
            string ret = "";
            //table not exists out
            if (!this.IsTableExists(acc, tableName, ref ret))
                return ret;

            //no data out
            if (!this.IsTableHasRows(acc, tableName, ref ret))
                return ret; 

            try
            {
                //select source table to datatable
                DataTable table = DBHelper.GetDataSet("select * from  " + acc.SourceDB + ".." + tableName);
                //clear target table
                DBHelper.ExecuteCommand("delete from " + acc.TargerDB + ".." + tableName);
                //import target table
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(ConnStr, SqlBulkCopyOptions.UseInternalTransaction))
                {

                    sqlBulkCopy.DestinationTableName = acc.TargerDB + ".." + tableName;
                    sqlBulkCopy.WriteToServer(table);
                }

            }
            catch (Exception e)
            {

                return ret +=tableName + ":导入失败！" + e.Message;
            }
            return ret += tableName + ":导入成功;";
        }
        public bool isNewYearExists(UA_AccountEntity acc,ref string logStr)
        {
            //如果不存在指定年度数据库//如果有上一年数据库
            if (acc.Newyear > acc.Maxyear && acc.Newyear - acc.Maxyear == 1)
            {
                return false;
            }
            logStr +="isDataBaseExists:false";
            return true;
        }
        public bool IsTableHasRows(UA_AccountEntity source, string tableName,ref string logStr)
        {
            string cmd = string.Format("select count(*) from {0}..{1}", source.SourceDB, tableName);

            int count = (int)DBHelper.GetScalar("select count(*) from " + source.SourceDB + ".." + tableName);
            if (count <= 0)
            {
                logStr += "IsTableHasRows:";
                logStr += "**" + tableName + ":没有数据。**";
                return false;
            }
            return true;
        }
        public bool IsTableExists(UA_AccountEntity target, string tableName,ref string logStr)
        {
            int count = (int)DBHelper.GetScalar("SELECT  count(*) FROM " + target.TargerDB + "..SysObjects WHERE name ='" + tableName + "' AND xtype='U'");
            if (count <= 0)
            {
                logStr += "IsTableExists";
                logStr += "**" + tableName + ":表不存在。**";
                return false;
            }
            return true;
        }

        public string GetMaxYear(UA_AccountEntity acc)
        {
            string cmd = "SELECT MAX(iyear) FROM UFSystem..UA_period WHERE bisdelete = 0 and cAcc_Id = @cAcc_Id";
            Object maxyear =DBHelper.GetScalar(cmd,new SqlParameter[] { new SqlParameter("cAcc_Id", acc.Cacc_id) });
            acc.Maxyear = Convert.ToInt32( maxyear);
            return cmd + ",@cAcc_Id=" + acc.Cacc_id;
        }
        // private string GetAccountPath(UA_AccountEntity source)
        //{
        //    return source.Cacc_path;
        //}
        private string RestoreDB(UA_AccountEntity source)
        {
            return "RESTORE DATABASE " +source.TargerDB+" "+
                           "FROM  DISK = N'" + source.Cacc_path + "ufmodel.bak'                         " +
                           "WITH  FILE = 1,  NOUNLOAD ,  STATS = 10,  RECOVERY ,  REPLACE ,      " +
                           "MOVE N'UFModel' TO N'" + source.Cacc_path + "\\ZT" + source.Cacc_id + "\\" + source.Newyear + "\\UFDATA.MDF',        " +
                           "MOVE N'UFModel_log' TO N'" + source.Cacc_path + "\\ZT" + source.Cacc_id + "\\" + source.Newyear + "\\UFDATA.LDF'   ";
            //DBHelper.ExecuteCommand(cmd);
            //   CmdSb.AppendLine(cmd).AppendLine("go");
        }
        private string AddMemoColumn(UA_AccountEntity target)
        {
            return "if not exists (select count(*) from " + target.TargerDB + "..syscolumns where id = object_id(N' " + target.TargerDB + "..ProductStructures') and name = 'cMemo') " +
                         "alter table " + target.TargerDB + "..ProductStructures"+" add cMemo varchar(200) null";
            //DBHelper.ExecuteCommand(cmd);
            //CmdSb.AppendLine(cmd).AppendLine("go");
        }

        private string DeleteMC_(UA_AccountEntity target)
        {
            return "DELETE FROM " + target.TargerDB + "..MC_MyAccount;" +
                "DELETE FROM " + target.TargerDB + "..MC_SendTime;" +
                "DELETE FROM " + target.TargerDB + "..MC_MessageTemplateToList;" +
                "DELETE FROM " + target.TargerDB + "..MC_MessageTemplateAttach;" +
                "DELETE FROM " + target.TargerDB + "..MC_MessageTemplate";
            //string[] sqls = new string[]
            //{
            //    "DELETE FROM "+target.TargerDB+"..MC_MyAccount",
            //    "DELETE FROM "+target.TargerDB+"..MC_SendTime",
            //    "DELETE FROM "+target.TargerDB+"..MC_MessageTemplateToList",
            //    "DELETE FROM "+target.TargerDB+"..MC_MessageTemplateAttach",
            //    "DELETE FROM "+target.TargerDB+"..MC_MessageTemplate"
            //};
            //foreach (string str in sqls)
            //{
            //    //DBHelper.ExecuteCommand(str);
            //    CmdSb.AppendLine(str).AppendLine("go");
            //}

        }

        private string CreateNewCalendar(UA_AccountEntity target)
        {
            return
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",1,'" + target.Newyear + "-01-01','" + target.Newyear + "-01-31',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",2,'" + target.Newyear + "-02-01','" + target.Newyear + "-02-28',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",3,'" + target.Newyear + "-03-01','" + target.Newyear + "-03-31',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",4,'" + target.Newyear + "-04-01','" + target.Newyear + "-04-30',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",5,'" + target.Newyear + "-05-01','" + target.Newyear + "-05-31',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",6,'" + target.Newyear + "-06-01','" + target.Newyear + "-06-30',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",7,'" + target.Newyear + "-07-01','" + target.Newyear + "-07-31',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",8,'" + target.Newyear + "-08-01','" + target.Newyear + "-08-31',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",9,'" + target.Newyear + "-09-01','" + target.Newyear + "-09-30',0) " +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",10,'" + target.Newyear + "-10-01','" + target.Newyear + "-10-31',0)" +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",11,'" + target.Newyear + "-11-01','" + target.Newyear + "-11-30',0)" +
                "INSERT INTO UFSystem..UA_Period VALUES('" + target.Cacc_id + "'," + target.Newyear + ",12,'" + target.Newyear + "-12-01','" + target.Newyear + "-12-31',0)";

            //string[] sqls = new string[]
            //{
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",1,'"+target.Newyear+"-01-01','"+target.Newyear+"-01-31',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",2,'"+target.Newyear+"-02-01','"+target.Newyear+"-02-28',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",3,'"+target.Newyear+"-03-01','"+target.Newyear+"-03-31',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",4,'"+target.Newyear+"-04-01','"+target.Newyear+"-04-30',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",5,'"+target.Newyear+"-05-01','"+target.Newyear+"-05-31',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",6,'"+target.Newyear+"-06-01','"+target.Newyear+"-06-30',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",7,'"+target.Newyear+"-07-01','"+target.Newyear+"-07-31',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",8,'"+target.Newyear+"-08-01','"+target.Newyear+"-08-31',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",9,'"+target.Newyear+"-09-01','"+target.Newyear+"-09-30',0) "+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",10,'"+target.Newyear+"-10-01','"+target.Newyear+"-10-31',0)"+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",11,'"+target.Newyear+"-11-01','"+target.Newyear+"-11-30',0)"+
            //    "INSERT INTO UFSystem..UA_Period VALUES('"+target.Cacc_id+"',"+target.Newyear+",12,'"+target.Newyear+"-12-01','"+target.Newyear+"-12-31',0)"
            //};
            //foreach (string str in sqls)
            //{
            //    //DBHelper.ExecuteCommand(str);
            //    CmdSb.AppendLine(str).AppendLine("go");
            //}
        }

        private string ImportHoldAuth(UA_AccountEntity target)
        {
            // string lastYear = Convert.ToInt32(target.Newyear) - 1 + "";
            return "insert into UFSystem..UA_HoldAuth(cAcc_Id, iYear, cUser_Id, cAuth_Id) " +
  " select cAcc_Id, " + target.Newyear + ",cUser_Id,cAuth_Id from UFSystem..UA_HoldAuth where iyear = " + target.Maxyear + " and cAcc_Id='" + target.Cacc_id + "'";
            // DBHelper.ExecuteCommand(cmd);
            //CmdSb.AppendLine(cmd).AppendLine("go");
        }

        private string CloseLastYearWA(UA_AccountEntity source)
        {

            return "UPDATE UFSystem..UA_Account_Sub SET bClosing = 0 " +
                " WHERE cAcc_Id = '" + source.Cacc_id + "' AND iYear = " + source.Maxyear + " AND(bIsDelete = 0 OR bIsDelete IS NULL) AND cSub_Id<> 'WA'";
            //  DBHelper.ExecuteCommand(cmd);
            //CmdSb.AppendLine(cmd).AppendLine("go");

        }



        public string CreateNewDBSQL(UA_AccountEntity acc)
        {
            CmdSb.Length = 0;
            CmdSb.AppendLine(RestoreDB(acc)).AppendLine(";").
                AppendLine(AddMemoColumn(acc)).AppendLine(";").
                AppendLine(DeleteMC_(acc)).AppendLine(";");
            DBHelper.ExecuteCommand(CmdSb.ToString());
            return CmdSb.ToString();
            // BatchImportTables(source, target);

        }
        public string ModifyNewDBSQL(UA_AccountEntity acc)
        {
            CmdSb.Length = 0;
            CmdSb.AppendLine(CreateNewCalendar(acc)).AppendLine(";");
            CmdSb.AppendLine(ImportHoldAuth(acc)).AppendLine(";");
            //have wa sub
            //    if (acc.Subs.IndexOf("WA") >= 0)
            //    {
            //        CmdSb.AppendLine(CloseLastYearWA(acc)).AppendLine("go");            }
            //}
            DBHelper.ExecuteCommand(CmdSb.ToString());
            return CmdSb.ToString();

            //public List<string> GetSubs(UA_AccountEntity source)
            //{
            //    List<string> subs = new List<string>();
            //    string cmd = "select cSub_Id from ufsystem..UA_Account_sub where iyear = '9999' and cAcc_Id = '" + source.Cacc_id + "'";
            //    SqlDataReader reader = DBHelper.GetReader(cmd);
            //    while (reader.Read())
            //    {
            //        subs.Add(reader["cSub_Id"] + "");
            //    }
            //    reader.Close();
            //    return subs;
            //}
        }
    }
}
