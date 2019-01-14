using COM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextYear
{
    class DAL
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
        //log
        public List<string> Log_success ;
        public List<string> Log_fault ;
        public List<string> Log_notExists;
        public List<string> Log_notHasRows;
        public void BatchImportTables(Account source, Account target) {
            //init log
            Log_success = new List<string>();
            Log_fault = new List<string>();
            Log_notExists = new List<string>();
            Log_notHasRows = new List<string>();

            foreach (string tableName in tables)
            {
                this.ImportOneTable(source, target, tableName);
            }
        }
        private void ImportOneTable(Account source,Account target,string tableName)

        {
            //table not exists out
            if (!this.IsTableExists(target,tableName)) return;
            
            //no data out
            if (!this.IsTableHasRows(source, tableName)) return ;

            try
            {
                //select source table to datatable
                DataTable table = DBHelper.GetDataSet("select * from  " + source.GetAccountDB() + ".." + tableName);
                //clear target table
                DBHelper.ExecuteCommand("delete from " + target.GetAccountDB() + ".." + tableName);
                //import target table
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(DBHelper.GetSqlConnectionStringBuilder().ConnectionString,
                    SqlBulkCopyOptions.UseInternalTransaction))
                {
                    
                    sqlBulkCopy.DestinationTableName =target.GetAccountDB()+".."+tableName;
                    sqlBulkCopy.WriteToServer(table);
                }

            }
            catch (Exception e)
            {

                Log_fault.Add(tableName + ":导入失败！"+e.Message);
            }
            Log_success.Add(tableName + ":导入成功;");
        }
        private bool IsTableHasRows(Account source,string tableName)
        {
            int count = (int)DBHelper.GetScalar("select count(*) from " + source.GetAccountDB() + ".." + tableName);
            if (count <= 0)
            {
                Log_notHasRows.Add(tableName + ":没有数据。");
                return false;
            }
            return true;
        }
        private bool IsTableExists(Account target,string tableName)
        {
            int count = (int)DBHelper.GetScalar("SELECT  count(*) FROM "+target.GetAccountDB()+"..SysObjects WHERE ID = object_id(N'"+tableName+"') AND OBJECTPROPERTY(ID, 'IsTable')=1");
            if (count <= 0)
            {
                Log_notExists.Add(tableName + ":表不存在。");
                return false;
            }
            return true;
        }

        public string GetMaxYear(Account source)
        {
            return DBHelper.GetScalar("SELECT MAX(iyear) FROM UFSystem..UA_period WHERE bisdelete = 0 and cAcc_Id = @cAcc_Id",
                    new SqlParameter[] { new SqlParameter("cAcc_Id", source.AccountId) }) + "";
        }
        private string GetAccountPath(Account source)
        {
            return DBHelper.GetScalar("SELECT cAcc_Path,cTradeKind FROM UFSystem..UA_Account WHERE cAcc_Id=@cAcc_Id",
                    new SqlParameter[] { new SqlParameter("cAcc_Id", source.AccountId) }) + "";
        }
        public void RestoreDB(Account source,Account target)
        {
            string AccountPath = GetAccountPath(source);
            string cmd =   "RESTORE DATABASE @targetDB"+
                           "FROM  DISK = N'"+ AccountPath+"ufmodel.bak'                         "+
                           "WITH  FILE = 1,  NOUNLOAD ,  STATS = 10,  RECOVERY ,  REPLACE ,      "+
                           "MOVE N'UFModel' TO N'"+ AccountPath + "\\ZT"+target.AccountId+"\\"+target.Year+"\\UFDATA.MDF',        "+
                           "MOVE N'UFModel_log' TO N'" + AccountPath + "\\ZT" + target.AccountId + "\\" + target.Year + "\\UFDATA.LDF'   ";
            DBHelper.ExecuteCommand(cmd);
        }
        public void AddMemoColumn(Account target)
        {
            string cmd = "if not exists (select * from "+target.GetAccountDB()+ "..syscolumns where id = object_id(N' " + target.GetAccountDB() + "..ProductStructures') and name = 'cMemo') "+
                         "alter table ProductStructures add cMemo varchar(200) null;";
            DBHelper.ExecuteCommand(cmd);
        }

        public void DeleteMC_(Account target)
        {
            string[] sqls = new string[] 
            {
                "DELETE FROM "+target.GetAccountDB()+"..MC_MyAccount",
                "DELETE FROM "+target.GetAccountDB()+"..MC_SendTime",
                "DELETE FROM "+target.GetAccountDB()+"..MC_MessageTemplateToList",
                "DELETE FROM "+target.GetAccountDB()+"..MC_MessageTemplateAttach",
                "DELETE FROM "+target.GetAccountDB()+"..MC_MessageTemplate"
            };
            foreach (string  str in sqls)
            {
                DBHelper.ExecuteCommand(str);
            }
        }

        public void CreateNewCalendar(Account target)
        {
            string[] sqls = new string[]
            {
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",1,'"+target.Year+"-01-01','"+target.Year+"-01-31',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",2,'"+target.Year+"-02-01','"+target.Year+"-02-28',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",3,'"+target.Year+"-03-01','"+target.Year+"-03-31',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",4,'"+target.Year+"-04-01','"+target.Year+"-04-30',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",5,'"+target.Year+"-05-01','"+target.Year+"-05-31',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",6,'"+target.Year+"-06-01','"+target.Year+"-06-30',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",7,'"+target.Year+"-07-01','"+target.Year+"-07-31',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",8,'"+target.Year+"-08-01','"+target.Year+"-08-31',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",9,'"+target.Year+"-09-01','"+target.Year+"-09-30',0) "+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",10,'"+target.Year+"-10-01','"+target.Year+"-10-31',0)"+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",11,'"+target.Year+"-11-01','"+target.Year+"-11-30',0)"+
                "INSERT INTO UFSystem..UA_Period VALUES('"+target.AccountId+"',"+target.Year+",12,'"+target.Year+"-12-01','"+target.Year+"-12-31',0)"
            };
            foreach (string str in sqls)
            {
                DBHelper.ExecuteCommand(str);
            }
        }

        public void ImportHoldAuth(Account target)
        {
            string lastYear = Convert.ToInt32(target.Year) - 1 + "";
            string cmd = "insert into UFSystem..UA_HoldAuth(cAcc_Id, iYear, cUser_Id, cAuth_Id)"+ 
  "select cAcc_Id, "+target.Year+",cUser_Id,cAuth_Id from UFSystem..UA_HoldAuth where iyear = "+ lastYear + " and cAcc_Id='"+target.AccountId+"'";
            DBHelper.ExecuteCommand(cmd);
        }

        public void CloseLastYearWA(Account source)
        {

            string cmd = "UPDATE UFSystem..UA_Account_Sub SET bClosing = 0 "+
                " WHERE cAcc_Id = '"+source.AccountId+"' AND iYear = "+source.Year+" AND(bIsDelete = 0 OR bIsDelete IS NULL) AND cSub_Id<> 'WA'";
            DBHelper.ExecuteCommand(cmd);
        }

        public List<string> GetSubs(Account source)
        {
            List<string> subs = new List<string>();
            string cmd = "select cSub_Id from ufsystem..UA_Account_sub where iyear = '9999' and cAcc_Id = '"+source.AccountId+"'";
            SqlDataReader reader = DBHelper.GetReader(cmd);
            while (reader.Read())
            {
                subs.Add(reader["cSub_Id"]+"");
            }
            reader.Close();
            return subs;
        }
    }
}
