using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Infrastructure;
using MSSQLHelper;



namespace CreateNextYear_Core.Manager
{
    public delegate void LogDelegate(string message);
    public class T31082 : ICreateNextYear
    {

        
        public LogDelegate logDelegate;
        private string oldYear {get;set;}

        private string newYear { get; set; }

  


        public T31082(string connectionString, string oldyear,string newyear)
        {
            this.oldYear = oldyear;
            this.newYear = newyear;
            ADONetHelper.connectionString = connectionString;
            //ADONetHelper.connectionStringName = "CreateNextYear.Properties.Settings.UFSystemConnectionString";
            // ADONetHelper.connectionString = "Data Source=192.168.0.100;Initial Catalog=UFSystem;User ID=sa;Password=sa;Encrypt=False;TrustServerCertificate=True";
        }
        //  public bool CarryForwardAll(Account acc, string oldYear, string newYear)
        #region carryForward
        public bool CarryForwardAll(string accountCode)
        {

            bool isGLSuccess=  this.CarryForwardGL(accountCode);
            bool isFASuccess = this.CarryForwardFA(accountCode);
            bool isWASuccess =  this.CarryForwardWA(accountCode);
            return isGLSuccess && isFASuccess &&isWASuccess;
        }

       // public bool CarryForwardFA(Account acc, string oldYear, string newYear)
        public bool CarryForwardFA(string accountCode)
        {
            bool result = false;
            string newYearDB = UFDBName(accountCode, newYear);
            string oldYearDB = UFDBName(accountCode, oldYear);

            Dictionary<string, string[]> CarryForWardFATask = new Dictionary<string, string[]>();

            string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
            CarryForWardFATask["DeleteInsertAccInformation"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_AssetAttached"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_AssetTypes"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Depreciations"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Origins"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Status"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Items"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertCREATEUNIQUEfa_ItemsManual"] = newOldyearDB;
            //CarryForWardFATask["CreateViewfa_Q_Cards"] = newOldyearDB;           
            CarryForWardFATask["DeleteInsertfa_ItemsOfModel"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_ItemsOfQuery"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Models"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Cards"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_CardsSheets"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Control"] = newOldyearDB;
            CarryForWardFATask["Deletefa_DeprList"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_DeprTransactions"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_DeprVoucherMain"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_DeprVouchers"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_DeprVouchers_pre"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Dictionary"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_EvaluateMain"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_EvaluateVouchers"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Objects"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_QueryFilters"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Querys"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Total"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Vouchers"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_WorkLoad"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_ZWVouchers"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_JKItemSet"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_JKSet"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_VtsObject"] = newOldyearDB;
            CarryForWardFATask["UPDATEAccInformation"] = new string[] {newYearDB, newYear };
            CarryForWardFATask["UPDATEfa_DeprTransactions1"] = new string[] { newYearDB };
            CarryForWardFATask["UPDATEfa_DeprTransactions2"] = new string[] { newYearDB };
            CarryForWardFATask["UPDATEfa_DeprTransactions3"] = new string[] { newYearDB };
            CarryForWardFATask["UPDATEfa_DeprTransactions4"] = new string[] { newYearDB };
            CarryForWardFATask["UPDATEfa_WorkLoad"] = new string[] { newYearDB };
            
            CarryForWardFATask["DeleteInsertfa_DeprVoucherMain"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_DeprVouchers"] = newOldyearDB;
            CarryForWardFATask["DeleteInsertfa_Control"] = newOldyearDB;
            CarryForWardFATask["DeleteUPDATEfa_Total"] = new string[] { newYearDB };
            CarryForWardFATask["UPDATEfa_EvaluateMainfa_EvaluateVouchersfa_Cardsfa_JKSet"] = new string[] { newYearDB } ;
            

            MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
            msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverFA", CarryForWardFATask);
            result = true;
            return result;
        }

       // public bool CarryForwardGL(Account acc, string oldYear, string newYear)
        public bool CarryForwardGL(string accountCode)
        {
            bool result = false;
            string newYearDB = UFDBName(accountCode, newYear);
            string oldYearDB = UFDBName(accountCode, oldYear);

            Dictionary<string, string[]> CarryForWardGLTask = new Dictionary<string, string[]>();

            string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
            CarryForWardGLTask["DeleteInsertGL_bmultiGroup"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertgl_accsum"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertgl_accass"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertgl_accvouch"] = new string[] { newYearDB, oldYearDB, oldYear };
            CarryForWardGLTask["DeleteInsertrp_bankrecp"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertrp_cheque"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertbi_nb_payment"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_QYSDS_YDSB_A"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_QYSDS_YDSB_B"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB1"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB1_SWITCH"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB2"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB2_SWITCH"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB3"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XGM_SH_NEW"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XGM_SWITCH"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_CZZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_DM"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_FB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_JCXMHZ"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_JCXMMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_JR"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_SHYYSSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_YDJZY"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_YSYJCXMMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YYS_FB7"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_BQZYKCSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_JYXSMXB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_ZBMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQZYDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQZYDJSEJSB_MX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_SCJYQKB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_ZBMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQZYKCSEJSB_FB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQZYKCSEJSB_MXB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_XSMXB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_ZBMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQZYKCSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQZYKCSEJSB_MXB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_SCJYQKB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_ZBMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_BQDSDJSEJSB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_SCJYQKB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_ZB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_ZBMX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SSFX_CWZBFXB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_TaxWarning_Qysds"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_TaxWarning_Sfl"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_ZDJSZBB"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_ObtainFinancia_Instance"] = newOldyearDB;
           // CarryForWardGLTask["DeleteInsertTAX_TAXID"] = new string[] { newYearDB,oldYearDB,oldYear,newYear};
            CarryForWardGLTask["DeleteInsertTAX_NSRXX"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_SZXM"] = newOldyearDB;
            CarryForWardGLTask["DeleteInsertTAX_YJSZ"] = newOldyearDB;

            MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
            msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverGL", CarryForWardGLTask);
            result = true;
            return result;
        }
        /// <summary>
        ///   carry forword wa
        /// </summary>
        /// <param name="accountCode">string accvouch Number</param>
        /// <param name="oldYear">string old year</param>
        /// <param name="newYear">string new year</param>
        /// <returns></returns>
        //public bool CarryForwardWA(Account acc, string oldYear, string newYear)
        public bool CarryForwardWA(string accountCode)
        {
            bool result = false;
            string newYearDB = this.UFDBName(accountCode, newYear);
            string oldYearDB = this.UFDBName(accountCode, oldYear);

            Dictionary<string, string[]> CarryForWardWATask = new Dictionary<string, string[]>();

            string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
            CarryForWardWATask["DeleteInsertWA_account"] = newOldyearDB;
            CarryForWardWATask["Insert WA_Authority"] = newOldyearDB;
            CarryForWardWATask["Alter WA_BankName"] = new string[] { newYearDB };
            CarryForWardWATask["Delete WA_Bank,WA_Bank_set,WA_BankPar,WA_BankTop,WA_BankName"] =new string[] { newYearDB };
            CarryForWardWATask["Insert WA_BankName"] = newOldyearDB;
            CarryForWardWATask["Delete wa_psn,WA_Grade"] = new string[] { newYearDB };
            CarryForWardWATask["Insert WA_Grade"] = newOldyearDB;
            CarryForWardWATask["Delete WA_GZItem,WA_GZtblSet"] = new string[] { newYearDB };
            CarryForWardWATask["Insert WA_GZtblSet"] = newOldyearDB;
            CarryForWardWATask["Insert WA_GZItem"] = newOldyearDB;
            CarryForWardWATask["Insert WA_Dept"] = newOldyearDB;
            CarryForWardWATask["Delete,Insert WA_PsnMsg"] = newOldyearDB;
            CarryForWardWATask["Alter,Insert WA_Psn"] = newOldyearDB;
            CarryForWardWATask["Alter,Insert WA_Bank"] = newOldyearDB;
            CarryForWardWATask["Insert WA_Bank_Set"] = newOldyearDB;
            CarryForWardWATask["Insert WA_BankPar"] = newOldyearDB;
            CarryForWardWATask["Insert WA_BankTop"] = newOldyearDB;
            CarryForWardWATask["Insert WA_FilterExpList"] = newOldyearDB;
            CarryForWardWATask["Delete,Insert WA_FilterName"] = newOldyearDB;
            CarryForWardWATask["Insert WA_Formula"] = newOldyearDB;
            CarryForWardWATask["Insert WA_FT_Sum"] = newOldyearDB;
            CarryForWardWATask["Insert WA_FTName"] = newOldyearDB;
            CarryForWardWATask["Insert WA_GZsumComCfg"] = newOldyearDB;
            CarryForWardWATask["Insert WA_FTInfo"] = newOldyearDB;
            CarryForWardWATask["Insert WA_FTDept"] = newOldyearDB;
            CarryForWardWATask["DeleteInsertWA_GZBNameWA_GZBItemDept"] = newOldyearDB;
            CarryForWardWATask["Insert WA_GZBItemGrd"] = newOldyearDB;
            CarryForWardWATask["Insert WA_GZBItemTitle"] = newOldyearDB;
            CarryForWardWATask["Insert WA_tblRCsetP"] = newOldyearDB;
            CarryForWardWATask["Insert WA_tblRCsetM"] = newOldyearDB;
           // CarryForWardWATask["ALTER WA_GZData"] = new string[] { newYearDB};
            CarryForWardWATask["Insert,Update WA_GZData"] = new string[] { newYearDB,oldYearDB,newYear };
            CarryForWardWATask["ALTER WA_GZHZB"] = new string[] { newYearDB };
            CarryForWardWATask["Insert WA_SDS_p"] = newOldyearDB;
            CarryForWardWATask["Insert WA_SDS_SL"] = newOldyearDB;
            CarryForWardWATask["Insert WA_SelectMoney"] = newOldyearDB;
            CarryForWardWATask["Insert WA_JKSet"] = newOldyearDB;
            CarryForWardWATask["Insert WA_JKItemSet"] = newOldyearDB;
            CarryForWardWATask["Insert WA_RatePayItems"] = newOldyearDB;
            CarryForWardWATask["Insert WA_State"] = newOldyearDB;
            CarryForWardWATask["Update WA_account"] = new string[] { newYearDB,newYear };
            CarryForWardWATask["DELETE WA_GZData"] = new string[] { newYearDB };
            CarryForWardWATask["UPDATE GL_mend"] = new string[] { oldYearDB };
            CarryForWardWATask["UPDATE OldYear WA_account"] = new string[] { oldYearDB };

            MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
            msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverWA", CarryForWardWATask);
            result = true;
            return result;
        }

        #endregion

        #region get last flag
        /// <summary>
        /// list order gl,fa,wa
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="checkYear"></param>
        /// <returns></returns>
        public Dictionary<string,int> GetLastFlagAll(string accountCode, string checkYear)
        {
            Dictionary<string, int> flag_all =new Dictionary<string, int>();
            flag_all.Add("总账",GetLastFlag_GL(accountCode, checkYear));
            flag_all.Add("固定资产",GetLastFlag_FA(accountCode, checkYear));
            flag_all.Add("工资",GetLastFlag_WA(accountCode, checkYear));
            return flag_all;
        }


        public int GetLastFlag_FA(string accountCode, string checkYear)
        {
            int lastFlag_FA = 0;
            string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag_FA=1", this.UFDBName(accountCode, checkYear));
            lastFlag_FA = Convert.ToInt32(ADONetHelper.GetScalar(sql));
            return lastFlag_FA;
        }

        public int GetLastFlag_GL(string accountCode, string checkYear)
        {
            int lastFlag_GL = 0;
            string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag=1", this.UFDBName(accountCode, checkYear));
            lastFlag_GL=Convert.ToInt32( ADONetHelper.GetScalar(sql));
            return lastFlag_GL;
        }

        public int GetLastFlag_WA(string accountCode, string checkYear)
        {
            int lastFlag_WA = 0;
            string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag_WA=1", this.UFDBName(accountCode, checkYear));
            lastFlag_WA = Convert.ToInt32(ADONetHelper.GetScalar(sql));
            //using (DataClassesDataContext dc = new DataClassesDataContext())
            //{

            //    var reslut = dc.ExecuteQuery<int>(@"select max(iperiod) from {0}..gl_mend where bflag_WA=1", this.JoinDBName(accNo, checkYear));
            //    if (null != reslut)
            //        lastFlag_WA = reslut.First<int>();
            //}
            return lastFlag_WA;
        }

        #endregion

        #region  List option
        public List<string> GetLastFlagAll(List<string> accountCodes, string checkYear)
        {
            List<string> list = new List<string>();
            foreach (string accountCode in accountCodes)
            {
                Dictionary<string, int> flag = this.GetLastFlagAll(accountCode, checkYear);
                // set dictonary key and value (Flag and month) to a string 
                string flagText = string.Join("  ", flag.Select(kvp => string.Join(":", kvp.Key, kvp.Value)));
                string message = string.Format("{0}    {1}", accountCode, flagText);
                list.Add(message);
                logOut(message);
            }
            return list;
        }
        public List<string> CarryForwardAll(List<string> accountCodes)
        {
            List<string> list = new List<string>();
            foreach (var accountCode in accountCodes)
            {
                bool isGLSuccess = this.CarryForwardGL(accountCode);
                bool isFASuccess = this.CarryForwardFA(accountCode);
                bool isWASuccess = this.CarryForwardWA(accountCode);
                string message = string.Format("总账:{0}    固定资产{1}  工资{2}", isGLSuccess, isFASuccess, isWASuccess);
                logOut(message);
                list.Add(message);
            }
            return list;
        }

        public List<string> CreateNewYear(List<UA_Account> accounts)
        {
            List<string> list = new List<string>();
            foreach (var account in accounts)
            {
              bool isCreated=  CreateNewYear(account);
                string message = string.Format("{0}=>{1}", account.cAcc_Id, isCreated);
                list.Add(message);
                logOut(message);
            }
            return list;
        }
        #endregion
        /// <summary>
        ///  restore data from admin\ufmodel.bak and modify new db
        /// </summary>
        /// <param name="acc">Account</param>
        /// <param name="newYear">2001</param>
        /// <param name="accPath">c;\ufsmart\admin\</param>
        /// <returns></returns>
        // public bool CreateNewYear(Account acc, string newYear, string oldYear)
        public bool CreateNewYear(UA_Account acc)
        {
            string accPath = acc.cAcc_Path;
            if (!accPath.EndsWith("\\"))
            {
                accPath += "\\";
            }

            // string newYearDB = string.Format("UFDATA_{0}_{1}", acc.cAcc_Id, newYear);
            string newYearDB = UFDBName( acc.cAcc_Id, newYear);
            // string oldYearDB = string.Format("UFDATA_{0}_{1}", acc.cAcc_Id, oldYear);
            string oldYearDB = UFDBName(acc.cAcc_Id, oldYear);
            string floderPath = accPath + "ZT" + acc.cAcc_Id + "\\" + newYear;
            //create newyear db file
            IOHelper.IOTools ioTools = new IOHelper.IOTools();
            bool isFlodExist = ioTools.CreateFold(floderPath);
            if (!isFlodExist)
            {
                return false;
            }
            //restoreDB
            //new sql task
            Dictionary<string, string[]> restoreDBTask = new Dictionary<string, string[]>();
            string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
            restoreDBTask["restoreDB"] = new string[]
            {
                newYearDB,
                string.Format("{0}ufmodel.bak",accPath),
                string.Format("{0}ZT{1}\\{2}\\UFDATA.MDF",accPath,acc.cAcc_Id,newYear),
                string.Format("{0}ZT{1}\\{2}\\UFDATA.LDF",accPath,acc.cAcc_Id,newYear)
            };
            restoreDBTask["AddMemo"] = new string[] { newYearDB };
            restoreDBTask["DeleteMCs"] = new string[] { newYearDB };
            restoreDBTask["DeleteInsertFitem"] = newOldyearDB;
            restoreDBTask["DeleteInsertForeigncurrency"] = newOldyearDB;
            restoreDBTask["DeleteInsertCode"] = newOldyearDB;
            restoreDBTask["DeleteInsertDsign"] = newOldyearDB;
            restoreDBTask["DeleteInsertDsigns"] = newOldyearDB;
            restoreDBTask["DeleteInsertAccInformation"] = newOldyearDB;
            restoreDBTask["DeleteInsertBank"] = newOldyearDB;
            restoreDBTask["DeleteInsertCostObj"] = newOldyearDB;
            restoreDBTask["DeleteInsertDistrictClass"] = newOldyearDB;
            restoreDBTask["DeleteInsertCustomerClass"] = newOldyearDB;
            restoreDBTask["DeleteInsertCustomer"] = newOldyearDB;
            restoreDBTask["DeleteInsertDepartment"] = newOldyearDB;
            restoreDBTask["DeleteInsertExpenseItem"] = newOldyearDB;
            restoreDBTask["DeleteInsertGradeDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertInventoryClass"] = newOldyearDB;
            restoreDBTask["DeleteInsertInventory"] = newOldyearDB;
            restoreDBTask["DeleteInsertWarehouse"] = newOldyearDB;

            restoreDBTask["DeleteInsertPayCondition"] = newOldyearDB;
            restoreDBTask["DeleteInsertPerson"] = newOldyearDB;
            restoreDBTask["DeleteInsertProductStructure"] = newOldyearDB;
            restoreDBTask["DeleteInsertProductStructures"] = newOldyearDB;
            restoreDBTask["DeleteInsertRd_Style"] = newOldyearDB;
            restoreDBTask["DeleteInsertPurchaseType"] = newOldyearDB;
            restoreDBTask["DeleteInsertSaleType"] = newOldyearDB;
            restoreDBTask["DeleteInsertSettleStyle"] = newOldyearDB;
            restoreDBTask["DeleteInsertShippingChoice"] = newOldyearDB;
            restoreDBTask["DeleteInsertVendorClass"] = newOldyearDB;
            restoreDBTask["DeleteInsertVendor"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_bdigest"] = newOldyearDB;
            restoreDBTask["DeleteInsertUserDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertUserDefine"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_btext"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_mcodeauth"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_mcodeused"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_mitemused"] = newOldyearDB;
            restoreDBTask["DeleteInsertap_Midexch"] = newOldyearDB;
            restoreDBTask["DeleteInsertap_Midexch"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_sal"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItema"] = newOldyearDB;
            restoreDBTask["DeleteInsertPrintEx"] = newOldyearDB;
            restoreDBTask["DeleteInsertPrintDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertRpt_FldDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertRpt_FltDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertRpt_Folder"] = newOldyearDB;
            restoreDBTask["DeleteInsertRpt_GlbDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertRpt_RelDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertVouchers"] = newOldyearDB;
            restoreDBTask["DeleteInsertVouchFormat"] = newOldyearDB;
            restoreDBTask["DeleteInsertVouchFormats"] = newOldyearDB;
            restoreDBTask["DeleteInsertVouchList"] = newOldyearDB;
            restoreDBTask["DeleteInsertVouchType"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_MyTableSet"] = newOldyearDB;
            restoreDBTask["DeleteInsertAP_DispSet"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_InputCode"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_SStyleCode"] = newOldyearDB;
            restoreDBTask["DeleteInsertDep_Auth"] = newOldyearDB;
            restoreDBTask["DeleteInsertAr_BadAge"] = newOldyearDB;
            restoreDBTask["DeleteInsertAccessaries"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_VouchType"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_InvCode"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_Lock"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_CtrlCode"] = newOldyearDB;
            restoreDBTask["DeleteInsertfitemgrademode"] = newOldyearDB;
            restoreDBTask["DeleteInsertfitemstructure"] = newOldyearDB;
            restoreDBTask["DeleteInsertfitemstrumode"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_AlarmSet"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_BillAge"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_bage"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_bautotran"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_bfreq"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_bmulti"] = newOldyearDB;
            restoreDBTask["DeleteInsertFA_Departments"] = newOldyearDB;
            restoreDBTask["DeleteInsertRPT_GrpDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertRPT_ItmDef"] = newOldyearDB;
            restoreDBTask["DeleteInsertWareAuth"] = newOldyearDB;
            restoreDBTask["DeleteInsertPosition"] = newOldyearDB;
            restoreDBTask["DeleteInsertPersonMSG"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_mybooktype"] = newOldyearDB;
            restoreDBTask["DeleteInsertAp_YWBillAge"] = newOldyearDB;
            restoreDBTask["DeleteInsertwastage"] = newOldyearDB;
            restoreDBTask["DeleteInsertT_Rpt_Folder"] = newOldyearDB;
            restoreDBTask["DeleteInsertT_Rpt_GlbDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertT_Rpt_FldDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertT_Rpt_FltDEF"] = newOldyearDB;
            restoreDBTask["DeleteInsertT_Rpt_Property"] = newOldyearDB;
            restoreDBTask["DeleteInsertAccountPeriod"] = newOldyearDB;
            restoreDBTask["DeleteInsertBI_NB_Account"] = newOldyearDB;
            restoreDBTask["DeleteInsertMC_MessageTemplate"] = newOldyearDB;
            restoreDBTask["DeleteInsertBI_NB_Option"] = newOldyearDB;
            restoreDBTask["DeleteInsertMC_MessageTemplateAttach"] = newOldyearDB;
            restoreDBTask["DeleteInsertMC_MessageTemplateToList"] = newOldyearDB;
            restoreDBTask["DeleteInsertBI_NB_UserAuthority"] = newOldyearDB;
            restoreDBTask["DeleteInsertBI_NB_VisibleField"] = newOldyearDB;
            restoreDBTask["DeleteInsertAA_columndic"] = newOldyearDB;
            restoreDBTask["DeleteInsertAA_columnset"] = newOldyearDB;
            restoreDBTask["DeleteInsertMC_SendTime"] = newOldyearDB;
            restoreDBTask["DeleteInsertMC_MyAccount"] = newOldyearDB;
            restoreDBTask["DeleteInsertWareHouseWarnInfo"] = newOldyearDB;
            restoreDBTask["DeleteInsertGL_blreq"] = newOldyearDB;
            restoreDBTask["DeleteInsertufdts_datalog"] = newOldyearDB;
            restoreDBTask["DeleteInsertufdts_datadel"] = newOldyearDB;
            restoreDBTask["UpdateWarehouse"] = newOldyearDB;
            restoreDBTask["DeleteInsertInventory_1"] = newOldyearDB;
            restoreDBTask["DeleteInsertInventory_2"] = newOldyearDB;

            restoreDBTask["DeleteInsertInvoiceItem_"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_Ap"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_sal"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItema"] = newOldyearDB;
            restoreDBTask["DeleteInsertKCHSItem"] = newOldyearDB;
            restoreDBTask["DeleteInsertpo"] = newOldyearDB;
            restoreDBTask["DeleteInsertPS"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_PRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_ApPRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItem_salPRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertInvoiceItemaPRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertKCHSItemPRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertpoPRN"] = newOldyearDB;
            restoreDBTask["DeleteInsertVoucherNumber"] = newOldyearDB;
            restoreDBTask["DeleteInsertVoucherPrefabricate"] = newOldyearDB;
            restoreDBTask["DeleteInsertVoucherContrapose"] = newOldyearDB;
            restoreDBTask["DeleteInsertVoucherHistory"] = newOldyearDB;
            restoreDBTask["UpdateUA_Period"] = new string[] { acc.cAcc_Id, newYear};
            restoreDBTask["DeleteInsertUA_HoldAuth"] = new string[] { acc.cAcc_Id, newYear,oldYear };
            restoreDBTask["UpdataUA_Account_Sub"] = new string[] { acc.cAcc_Id, oldYear};
            restoreDBTask["Updatagl_mend"] = new string[] { oldYearDB};

            MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
            // msTools.ExcuteSQLTemlpateTask("restoreDB.xml", restoreDBTask);
            msTools.ExcuteSQLTemlpateTask(@"temlpate\RDB", restoreDBTask);
            return ADONetHelper.isDBisExist(newYearDB) == 1 ? true : false ;
        }


        public bool IsSubSysUsed(string accountCode,string subSysName)
        {
            bool result = false;
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {
                var acc_subs = from accSub in dc.UA_Account_sub
                               where accSub.cAcc_Id == accountCode
                               && accSub.iYear.ToString().Equals(oldYear)
                               && accSub.cSub_Id == subSysName
                               select accSub;
                if (acc_subs.Count()>0)
                {
                    result = true;
                }
            }
            return result;
        }

        //public List<Account> GetAccountsAndSub()
        //{
            
        //    List<Account> aa = null; 
        //    using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
        //    {

        //        List<UA_Account> acc = this.getAccounts();
        //        List<UA_Account_sub> acc_subs = this.getAccount_Subs();

        //         aa = (from a in acc
        //               select new Account
        //                 {
        //                     cAcc_Id=    a.cAcc_Id,
        //                     cAcc_Name=  a.cAcc_Name,
        //                     cAcc_Path=  a.cAcc_Path,
        //                     iYear=      a.iYear,
        //                     iMonth=     a.iMonth,
        //                     cAcc_Master=a.cAcc_Master,
        //                     cUnitName=  a.cUnitName,
        //                     cTradeKind = a.cTradeKind,
        //                     GL = acc_subs.Where(x => x.cAcc_Id == a.cAcc_Id && x.iYear==9999 && x.cSub_Id == "GL").Count(),
        //                     FA = acc_subs.Where(x => x.cAcc_Id == a.cAcc_Id && x.iYear==9999 && x.cSub_Id == "FA").Count(),
        //                     WA = acc_subs.Where(x => x.cAcc_Id == a.cAcc_Id && x.iYear==9999 && x.cSub_Id == "WA").Count(),
        //                     IA = acc_subs.Where(x => x.cAcc_Id == a.cAcc_Id && x.iYear==9999 && x.cSub_Id == "IA").Count(),
        //                     GX = acc_subs.Where(x => x.cAcc_Id == a.cAcc_Id && x.iYear == 9999 && x.cSub_Id == "GX").Count(),


        //               }).ToList();
                         

        //    }
        //    return aa;
        //}

        private string UFDBName(string accountCode, string year)
        {
            return string.Format("UFDATA_{0}_{1}", accountCode, year);
        }

        public List<UA_Account> getAccounts()
        {
           // List<UA_Account> acc = new List<UA_Account>();
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {

               return   dc.UA_Account.ToList();
            }
           // return acc;
            }

        public List<UA_Account_sub> getAccount_Subs()
        {
          //  List<UA_Account_sub> acc_subs = new List<UA_Account_sub>();
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {
              return  dc.UA_Account_sub.ToList();
            }
            //return acc_subs;
        }

        public void logOut(string message)
        {
            logDelegate(message);
        }
    }
}
