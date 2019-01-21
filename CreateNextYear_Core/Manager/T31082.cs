using System;
using System.Collections.Generic;
using System.Linq;
using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Infrastructure;
using SQLDryAlive.Core;



[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace CreateNextYear_Core.Manager
{

    public class T31082 : ICreateNextYear
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //private string oldYear {get;set;}

        //private string newYear { get; set; }

        private Setting setting { get; set; }
  


        public T31082(Setting setting)
        {
            this.setting = setting;
            //this.oldYear = oldyear;
            //this.newYear = newyear;
            ADONetHelper.connectionString = setting.connectionString;

            //ADONetHelper.connectionStringName = "CreateNextYear.Properties.Settings.UFSystemConnectionString";
            // ADONetHelper.connectionString = "Data Source=192.168.0.100;Initial Catalog=UFSystem;User ID=sa;Password=sa;Encrypt=False;TrustServerCertificate=True";
        }
        //  public bool CarryForwardAll(Account acc, string oldYear, string newYear)
        #region carryForward
        //public bool CarryForwardAll(string accountCode)
        //{

        //    bool isGLSuccess = this.CarryForwardGL(accountCode);
        //    bool isFASuccess = this.CarryForwardFA(accountCode);
        //    bool isWASuccess = this.CarryForwardWA(accountCode);
        //    return isGLSuccess && isFASuccess && isWASuccess;
        //}
        /// <summary>
        /// carry forward ua_account by module
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="module"></param>
        public void CarryForwardSingleAccountSingleModule(UA_Account acc,string module)
        {
            SqlSentenceManagerParam param = new SqlSentenceManagerParam();
            param.ParamNameValues = GetSqlSentenceParamNameValues(acc);
            switch (module)
            {
                case "GL":
                    param.SqlSentenceQueue = setting.carryForwardGL;
                    break;
                case "FA":
                    param.SqlSentenceQueue = setting.carryForwardFA;
                    break;
                case "WA":
                    param.SqlSentenceQueue = setting.carryForwardWA;
                    break;

                default:
                    log.Info(" error carry forward module is not define");
                    break;
            }

            SQLRepositoryManage sqlRepositoryManage = new SQLRepositoryManage();
            List<SqlSentence> sqlSentences = sqlRepositoryManage.GetAliveSqlSentences(@"temlpate\CarryOver"+module, param);
            foreach (var sentence in sqlSentences)
            {
                
                ADONetHelper.ExecuteCommand(sentence.ALiveSQL);
             
            }

            log.Info(string.Format("carry {0}.{1} is over", acc.cAcc_Id, module));

        }

        public void CarryForwardSingleAccountManyModules(UA_Account acc, string[] modules)
        {
            log.Info("Carry Forward Single Account Many Module begin");
            foreach (string module in modules)
            {
                CarryForwardSingleAccountSingleModule(acc, module);
            }
            log.Info("Carry Forward Single Account Many Module over");

        }

        public void CarryForwardManyAccountsManyModules(List<UA_Account>list, string[] modules)
        {
            log.Info("Carry Forward Many Account Many Module begin");
            foreach (UA_Account acc in list)
            {
                CarryForwardSingleAccountManyModules(acc, modules);
            }
            log.Info("Carry Forward Many Account Many Module over");

        }
        // public bool CarryForwardFA(Account acc, string oldYear, string newYear)
        //public bool CarryForwardFA(string accountCode)
        //{
        //    bool result = false;
        //    string newYearDB = UFDBName(accountCode, setting.newYear);
        //    string oldYearDB = UFDBName(accountCode, setting.oldYear);

        //    Dictionary<string, string[]> CarryForWardFATask = new Dictionary<string, string[]>();

        //    string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
        //    CarryForWardFATask["DeleteInsertAccInformation"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_AssetAttached"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_AssetTypes"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Depreciations"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Origins"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Status"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Items"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertCREATEUNIQUEfa_ItemsManual"] = newOldyearDB;
        //    //CarryForWardFATask["CreateViewfa_Q_Cards"] = newOldyearDB;           
        //    CarryForWardFATask["DeleteInsertfa_ItemsOfModel"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_ItemsOfQuery"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Models"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Cards"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_CardsSheets"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Control"] = newOldyearDB;
        //    CarryForWardFATask["Deletefa_DeprList"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_DeprTransactions"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_DeprVoucherMain"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_DeprVouchers"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_DeprVouchers_pre"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Dictionary"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_EvaluateMain"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_EvaluateVouchers"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Objects"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_QueryFilters"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Querys"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Total"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Vouchers"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_WorkLoad"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_ZWVouchers"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_JKItemSet"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_JKSet"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_VtsObject"] = newOldyearDB;
        //    CarryForWardFATask["UPDATEAccInformation"] = new string[] {newYearDB, newYear };
        //    CarryForWardFATask["UPDATEfa_DeprTransactions1"] = new string[] { newYearDB };
        //    CarryForWardFATask["UPDATEfa_DeprTransactions2"] = new string[] { newYearDB };
        //    CarryForWardFATask["UPDATEfa_DeprTransactions3"] = new string[] { newYearDB };
        //    CarryForWardFATask["UPDATEfa_DeprTransactions4"] = new string[] { newYearDB };
        //    CarryForWardFATask["UPDATEfa_WorkLoad"] = new string[] { newYearDB };
            
        //    CarryForWardFATask["DeleteInsertfa_DeprVoucherMain"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_DeprVouchers"] = newOldyearDB;
        //    CarryForWardFATask["DeleteInsertfa_Control"] = newOldyearDB;
        //    CarryForWardFATask["DeleteUPDATEfa_Total"] = new string[] { newYearDB };
        //    CarryForWardFATask["UPDATEfa_EvaluateMainfa_EvaluateVouchersfa_Cardsfa_JKSet"] = new string[] { newYearDB } ;
            

        //    MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
        //    msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverFA", CarryForWardFATask);
        //    result = true;
        //    return result;
        //}

       // public bool CarryForwardGL(Account acc, string oldYear, string newYear)
        //public bool CarryForwardGL(string accountCode)
        //{
        //    bool result = false;
        //    string newYearDB = UFDBName(accountCode, newYear);
        //    string oldYearDB = UFDBName(accountCode, oldYear);

        //    Dictionary<string, string[]> CarryForWardGLTask = new Dictionary<string, string[]>();

        //    string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
        //    CarryForWardGLTask["DeleteInsertGL_bmultiGroup"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertgl_accsum"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertgl_accass"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertgl_accvouch"] = new string[] { newYearDB, oldYearDB, oldYear };
        //    CarryForWardGLTask["DeleteInsertrp_bankrecp"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertrp_cheque"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertbi_nb_payment"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_QYSDS_YDSB_A"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_QYSDS_YDSB_B"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB1"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB1_SWITCH"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB2"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB2_SWITCH"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SB_NSSB_NEW_FB3"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XGM_SH_NEW"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XGM_SWITCH"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_CZZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_DM"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_FB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_JCXMHZ"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_JCXMMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_JR"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_SHYYSSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_YDJZY"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_YSYJCXMMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YYS_FB7"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_BQZYKCSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_JYXSMXB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_YAN_ZBMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQZYDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_BQZYDJSEJSB_MX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_SCJYQKB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_JIU_ZBMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQZYKCSEJSB_FB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_BQZYKCSEJSB_MXB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_XSMXB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_CPY_ZBMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQZYKCSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_BQZYKCSEJSB_MXB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_SCJYQKB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_QTXFP_ZBMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_BQDSDJSEJSB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_SCJYQKB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_ZB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_XFS_XQC_ZBMX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SSFX_CWZBFXB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_TaxWarning_Qysds"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_TaxWarning_Sfl"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_ZDJSZBB"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_ObtainFinancia_Instance"] = newOldyearDB;
        //   // CarryForWardGLTask["DeleteInsertTAX_TAXID"] = new string[] { newYearDB,oldYearDB,oldYear,newYear};
        //    CarryForWardGLTask["DeleteInsertTAX_NSRXX"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_SZXM"] = newOldyearDB;
        //    CarryForWardGLTask["DeleteInsertTAX_YJSZ"] = newOldyearDB;

        //    MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
        //    msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverGL", CarryForWardGLTask);
        //    result = true;
        //    return result;
        //}
        /// <summary>
        ///   carry forword wa
        /// </summary>
        /// <param name="accountCode">string accvouch Number</param>
        /// <param name="oldYear">string old year</param>
        /// <param name="newYear">string new year</param>
        /// <returns></returns>
        //public bool CarryForwardWA(Account acc, string oldYear, string newYear)
        //public bool CarryForwardWA(string accountCode)
        //{
        //    bool result = false;
        //    string newYearDB = this.UFDBName(accountCode, newYear);
        //    string oldYearDB = this.UFDBName(accountCode, oldYear);

        //    Dictionary<string, string[]> CarryForWardWATask = new Dictionary<string, string[]>();

        //    string[] newOldyearDB = new string[] { newYearDB, oldYearDB };
        //    CarryForWardWATask["DeleteInsertWA_account"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_Authority"] = newOldyearDB;
        //    CarryForWardWATask["Alter WA_BankName"] = new string[] { newYearDB };
        //    CarryForWardWATask["Delete WA_Bank,WA_Bank_set,WA_BankPar,WA_BankTop,WA_BankName"] =new string[] { newYearDB };
        //    CarryForWardWATask["Insert WA_BankName"] = newOldyearDB;
        //    CarryForWardWATask["Delete wa_psn,WA_Grade"] = new string[] { newYearDB };
        //    CarryForWardWATask["Insert WA_Grade"] = newOldyearDB;
        //    CarryForWardWATask["Delete WA_GZItem,WA_GZtblSet"] = new string[] { newYearDB };
        //    CarryForWardWATask["Insert WA_GZtblSet"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_GZItem"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_Dept"] = newOldyearDB;
        //    CarryForWardWATask["Delete,Insert WA_PsnMsg"] = newOldyearDB;
        //    CarryForWardWATask["Alter,Insert WA_Psn"] = newOldyearDB;
        //    CarryForWardWATask["Alter,Insert WA_Bank"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_Bank_Set"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_BankPar"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_BankTop"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_FilterExpList"] = newOldyearDB;
        //    CarryForWardWATask["Delete,Insert WA_FilterName"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_Formula"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_FT_Sum"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_FTName"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_GZsumComCfg"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_FTInfo"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_FTDept"] = newOldyearDB;
        //    CarryForWardWATask["DeleteInsertWA_GZBNameWA_GZBItemDept"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_GZBItemGrd"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_GZBItemTitle"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_tblRCsetP"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_tblRCsetM"] = newOldyearDB;
        //   // CarryForWardWATask["ALTER WA_GZData"] = new string[] { newYearDB};
        //    CarryForWardWATask["Insert,Update WA_GZData"] = new string[] { newYearDB,oldYearDB,newYear };
        //    CarryForWardWATask["ALTER WA_GZHZB"] = new string[] { newYearDB };
        //    CarryForWardWATask["Insert WA_SDS_p"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_SDS_SL"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_SelectMoney"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_JKSet"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_JKItemSet"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_RatePayItems"] = newOldyearDB;
        //    CarryForWardWATask["Insert WA_State"] = newOldyearDB;
        //    CarryForWardWATask["Update WA_account"] = new string[] { newYearDB,newYear };
        //    CarryForWardWATask["DELETE WA_GZData"] = new string[] { newYearDB };
        //    CarryForWardWATask["UPDATE GL_mend"] = new string[] { oldYearDB };
        //    CarryForWardWATask["UPDATE OldYear WA_account"] = new string[] { oldYearDB };

        //    MSSQLHelper.MSSQLTools msTools = new MSSQLTools();
        //    msTools.ExcuteSQLTemlpateTask(@"temlpate\CarryOverWA", CarryForWardWATask);
        //    result = true;
        //    return result;
        //}

        #endregion

        #region get last flag
        /// <summary>
        /// list order gl,fa,wa
        /// </summary>
        /// <param name="accountCode">accountCode</param>
        /// <param name="checkYear">old</param>
        /// <param name="modules">GL,FA,WA...</param>
        /// <returns></returns>
        public Dictionary<string,int> GetSingleAccountManyModuleLastFlag(string accountCode, string checkYear,string[] modules)
        {
            Dictionary<string, int> flag_all =new Dictionary<string, int>();
            foreach (var module in modules)
            {
                flag_all.Add(module, GetSingleModuleLastFlag(accountCode, checkYear, module));

            }
            //flag_all.Add("固定资产", GetSingleModuleLastFlag(accountCode, checkYear,"FA"));
           // flag_all.Add("工资", GetSingleModuleLastFlag(accountCode, checkYear,"WA"));
            return flag_all;
        }


        //public int GetLastFlag_FA(string accountCode, string checkYear)
        //{
        //    int lastFlag_FA = 0;
        //    string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag_FA=1", this.UFDBName(accountCode, checkYear));
        //    lastFlag_FA = Convert.ToInt32(ADONetHelper.GetScalar(sql));
        //    return lastFlag_FA;
        //}

        //public int GetLastFlag_GL(string accountCode, string checkYear)
        //{
        //    int lastFlag_GL = 0;
        //    string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag=1", this.UFDBName(accountCode, checkYear));
        //    lastFlag_GL=Convert.ToInt32( ADONetHelper.GetScalar(sql));
        //    return lastFlag_GL;
        //}

        //public int GetLastFlag_WA(string accountCode, string checkYear)
        //{
        //    int lastFlag_WA = 0;
        //    string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag_WA=1", this.UFDBName(accountCode, checkYear));
        //    lastFlag_WA = Convert.ToInt32(ADONetHelper.GetScalar(sql));
        //    //using (DataClassesDataContext dc = new DataClassesDataContext())
        //    //{

        //    //    var reslut = dc.ExecuteQuery<int>(@"select max(iperiod) from {0}..gl_mend where bflag_WA=1", this.JoinDBName(accNo, checkYear));
        //    //    if (null != reslut)
        //    //        lastFlag_WA = reslut.First<int>();
        //    //}
        //    return lastFlag_WA;
        //}
        public int GetSingleModuleLastFlag(string accountCode, string checkYear,string Module)
        {
            string moduleFlag = "";
            if ("GL"!=Module)
            {
                moduleFlag = "_" + Module; ;
            }
            int lastFlag = 0;
            string sql = string.Format(@"select isnull(max(iperiod),0) from {0}..gl_mend where bflag{1}=1", this.UFDBName(accountCode, checkYear), moduleFlag);
           // logOut(string.Format("GetSingleModuleLastFlag {0} {1}", Module,sql));
            lastFlag = Convert.ToInt32(ADONetHelper.GetScalar(sql));
            //logOut(string.Format("GetSingleModuleLastFlag:{0} getScalar is over", Module));

            //using (DataClassesDataContext dc = new DataClassesDataContext())
            //{

            //    var reslut = dc.ExecuteQuery<int>(@"select max(iperiod) from {0}..gl_mend where bflag_WA=1", this.JoinDBName(accNo, checkYear));
            //    if (null != reslut)
            //        lastFlag_WA = reslut.First<int>();
            //}
            return lastFlag;
        }

        #endregion

        #region  List option
        /// <summary>
        /// log out all account list every modules  close month
        /// </summary>
        /// <param name="accountCodes"></param>
        /// <param name="checkYear"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public List<string> GetManyAccountManyModuleLastFlag(List<string> accountCodes, string checkYear, string[] modules)
        {
            List<string> list = new List<string>();
            foreach (string accountCode in accountCodes)
            {
                Dictionary<string, int> flag = this.GetSingleAccountManyModuleLastFlag(accountCode, checkYear,modules);
                // set dictonary key and value (Flag and month) to a string 
                string flagText = string.Join("  ", flag.Select(kvp => string.Join(":", kvp.Key, kvp.Value)));
                string message = string.Format("{0}    {1}", accountCode, flagText);
                list.Add(message);
                log.Info(message);
            }
            return list;
        }
        /// <summary>
        /// check all account list while module is not close right
        /// </summary>
        /// <param name="accountCodes">account code list</param>
        /// <param name="checkYear"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public List<string> CheckLastFlagManyAccountsManyModules(List<string> accountCodes, string checkYear, string[] modules)
        {

            List<string> list = new List<string>();
            foreach (string accountCode in accountCodes)
            {
                Dictionary<string, int> flag = this.GetSingleAccountManyModuleLastFlag(accountCode, checkYear, modules);
                String message = accountCode;
                foreach (var module in flag.Keys)
                {
                    int lastflag = flag[module];
                    //if ((module == "WA" && lastflag > 0 && lastflag < 11)||
                    //    (module == "FA" && lastflag > 0 && lastflag < 12)||
                    //    (module == "GL" && lastflag > 0 && lastflag < 11)
                    //    )
                    //{

                    //}
                    if (module=="WA" && lastflag > 0 && lastflag < 11 )
                    {
                        message += string.Format(" 工资   {0}[未完成] ", lastflag);
                    }
                    else if (module == "FA" && lastflag > 0 && lastflag < 12)
                    {
                        message += string.Format(" 固定资产   {0}[未完成] ", lastflag);
                    }
                    else if (module == "GL" && lastflag > 0 && lastflag < 11)
                    {
                        message += string.Format(" 总账   {0}[未完成] ", lastflag);
                    }
                    else
                    {
                        message += string.Format("{0}   {1}",module, lastflag);
                    }
                }
                // set dictonary key and value (Flag and month) to a string 
               // string flagText = string.Join("  ", flag.Select(kvp => string.Join(":", kvp.Key, kvp.Value)));
                //string message = string.Format("{0}    {1}", accountCode, flagText);
                list.Add(message);
                log.Info(message);
            }
            return list;
        }
        //public List<string> CarryForwardAll(List<string> accountCodes)
        //{
        //    List<string> list = new List<string>();
        //    foreach (var accountCode in accountCodes)
        //    {
        //        bool isGLSuccess = this.CarryForwardGL(accountCode);
        //        bool isFASuccess = this.CarryForwardFA(accountCode);
        //        bool isWASuccess = this.CarryForwardWA(accountCode);
        //        string message = string.Format("总账:{0}    固定资产{1}  工资{2}", isGLSuccess, isFASuccess, isWASuccess);
        //        logOut(message);
        //        list.Add(message);
        //    }
        //    return list;
        //}

        public List<string> CreateManyAccountsNewYear(List<UA_Account> accounts)
        {
            List<string> list = new List<string>();
            foreach (var account in accounts)
            {
              bool isCreated=  CreateSingleAccountNewYear(account);
                string message = string.Format("{0}=>{1}", account.cAcc_Id, isCreated);
                list.Add(message);
               // logOut(message);
            }
            return list;
        }
        #endregion
        /// <summary>
        ///  restore data from copy file admin\ufmodel.bak and modify new db
        /// </summary>
        /// <param name="acc">UA_Account</param>
        /// <returns>bool ture is created ,false not created</returns>
        // public bool CreateNewYear(Account acc, string newYear, string oldYear)
        public bool CreateSingleAccountNewYear(UA_Account acc)
        {
            SqlSentenceManagerParam param = new SqlSentenceManagerParam();
            string accPath = acc.cAcc_Path;
            if (!accPath.EndsWith("\\"))
            {
                accPath += "\\";
            }

            string floderPath = accPath + "ZT" + acc.cAcc_Id + "\\" + setting.newYear;
            //create newyear db file
            IOHelper.IOTools ioTools = new IOHelper.IOTools();
            bool isFlodExist = ioTools.CreateFold(floderPath);
            if (!isFlodExist)
            {
                log.Info("create floder failed:" + floderPath);
                return false;
            }

            param.ParamNameValues= GetSqlSentenceParamNameValues(acc);
            param.ParamNameValues.Add("{ufmodelPath}", string.Format("{0}ufmodel.bak", accPath));
            param.ParamNameValues.Add("{mdfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.MDF", accPath, acc.cAcc_Id, setting.newYear));
            param.ParamNameValues.Add("{ldfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.LDF", accPath, acc.cAcc_Id, setting.newYear));

            param.SqlSentenceQueue =setting.createNewYearDbSentencesQueue;
            
            SQLRepositoryManage sqlRepositoryManage = new SQLRepositoryManage();
            List<SqlSentence> sqlSentences = sqlRepositoryManage.GetAliveSqlSentences(@"temlpate\RDB", param);
            foreach (var sentence in sqlSentences)
            {
                log.Info("AdoNetHelper executeCommand:" + sentence.Name + ",aliveSql:" + sentence.ALiveSQL);
                ADONetHelper.ExecuteCommand(sentence.ALiveSQL);
                log.Info("AdoNetHelper executeCommand:" + sentence.Name + "  over");
            }
            bool isDBExist = ADONetHelper.isDBisExist(param.ParamNameValues["{newYearDB}"]) == 1;
            log.Info(string.Format("create {0} database {1}", acc.cAcc_Id, isDBExist));
            return isDBExist;
        }
        /// <summary>
        /// 常用 sqlStentenceParam 的参数键值对
        /// </summary>
        /// <param name="acc">ua_account</param>
        /// <returns></returns>
        private Dictionary<string,string> GetSqlSentenceParamNameValues(UA_Account acc)
        {
            Dictionary<string, string> ParamNameValues = new Dictionary<string, string>();
            ParamNameValues.Add("{cAcc_Id}", acc.cAcc_Id);
            ParamNameValues.Add("{newYear}", setting.newYear);
            ParamNameValues.Add("{oldYear}", setting.oldYear);
            ParamNameValues.Add("{newYearDB}", UFDBName(acc.cAcc_Id, setting.newYear));
            ParamNameValues.Add("{oldYearDB}", UFDBName(acc.cAcc_Id, setting.oldYear));
            return ParamNameValues;
        }

        public bool IsSubSysUsed(string accountCode,string subSysName)
        {
            bool result = false;
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {
                var acc_subs = from accSub in dc.UA_Account_sub
                               where accSub.cAcc_Id == accountCode
                               && accSub.iYear.ToString().Equals(setting.oldYear)
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

        public List<UA_Account> GetAccounts()
        {
           // List<UA_Account> acc = new List<UA_Account>();
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {

               return   dc.UA_Account.ToList();
            }
           // return acc;
            }

        public List<UA_Account_sub> GetAccount_Subs()
        {
          //  List<UA_Account_sub> acc_subs = new List<UA_Account_sub>();
            using (CreateNextYearDbContext dc = new CreateNextYearDbContext())
            {
              return  dc.UA_Account_sub.ToList();
            }
            //return acc_subs;
        }


    }
}
