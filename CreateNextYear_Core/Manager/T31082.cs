﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Infrastructure;
using SQLDryAlive.Core;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace CreateNextYear_Core.Manager
{
    public delegate void LogDelegate(string message);
    public class T31082 : ICreateNextYear
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LogDelegate logDelegate;
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
                    Talk(string.Format("{0},{1} error carry forward module is not define",acc.cAcc_Id,module));
                    break;
            }

            SQLRepositoryManage sqlRepositoryManage = new SQLRepositoryManage();
            List<SqlSentence> sqlSentences = sqlRepositoryManage.GetAliveSqlSentences(@"template\CarryOver"+module, param);
            foreach (var sentence in sqlSentences)
            {
                ADONetHelper.ExecuteCommand(sentence.ALiveSQL);
            }

            Talk(string.Format("carry {0}.{1} is over", acc.cAcc_Id, module));

        }

        public void CarryForwardSingleAccountManyModules(UA_Account acc, string[] modules)
        {
            Talk("Carry Forward Single Account Many Module begin");
            foreach (string module in modules)
            {
                CarryForwardSingleAccountSingleModule(acc, module);
            }
            Talk("Carry Forward Single Account Many Module over");

        }
        [Obsolete("use CarryForwardManyAccountsManyModules")]
        public void CarryForwardManyAccountsManyModules(List<UA_Account>list, string[] modules)
        {
            Talk("Carry Forward Many Account Many Module begin");
            foreach (UA_Account acc in list)
            {
                CarryForwardSingleAccountManyModules(acc, modules);
            }
            Talk("Carry Forward Many Account Many Module over");

        }

        public void CarryForwardManyAccountsManyModules(List<UA_Account> list)
        {
            Talk("Carry Forward Many Account Many Module begin");
            Dictionary<string,string[]> accountmodules= GetManyAccountHasUseModules(list.Select(e => e.cAcc_Id).ToList(), setting.allowModules);

            foreach (UA_Account acc in list)
            {
                string[] modules = accountmodules[acc.cAcc_Id];
                CarryForwardSingleAccountManyModules(acc, modules);
            }
            Talk("Carry Forward Many Account Many Module over");

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
        //    msTools.ExcuteSQLtemplateTask(@"template\CarryOverFA", CarryForWardFATask);
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
        //    msTools.ExcuteSQLtemplateTask(@"template\CarryOverGL", CarryForWardGLTask);
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
        //    msTools.ExcuteSQLtemplateTask(@"template\CarryOverWA", CarryForWardWATask);
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
        public void CheckLastFlagManyAccountsManyModules(List<string> accountCodes, string checkYear, List<string> allowModules)
        {
            List<string> list = new List<string>();
            Dictionary<string, List<UA_Account_sub>> accountSubs = new Dictionary<string, List<UA_Account_sub>>();
            using (CreateNextYearDbContext context = new CreateNextYearDbContext())
            {
                accountSubs = context.UA_Account_sub
                     .Where(e => accountCodes.Contains(e.cAcc_Id) && e.iYear.ToString() == checkYear && allowModules.Contains(e.cSub_Id))
                     .GroupBy(x => x.cAcc_Id)
                     .ToDictionary(x => x.First().cAcc_Id, y => new List<UA_Account_sub>(y));
            }

            foreach (var accCode in accountSubs.Keys)
            {
                String message ="";
                List<UA_Account_sub> accsubs = accountSubs[accCode];
                //set  modules name and period
                string gl = "", fa = "", wa = "";
                int glPeriod = 0, faPeriod = 0, waPeriod = 0;
                foreach (UA_Account_sub accSub in accountSubs[accCode])
                {
                    switch (accSub.cSub_Id)
                    {
                        case "GL":
                            gl = "GL"; glPeriod = accSub.iModiPeri;
                            break;
                        case "FA":
                            fa = "FA"; faPeriod = accSub.iModiPeri;
                            break;
                        case "WA":
                            wa= "WA"; waPeriod = accSub.iModiPeri;
                            break;
                        default:
                            break;
                    }
                }
               
                //module only one gl
                log.Debug(string.Format("{0},{1},{2}", accCode, accsubs.Count(),gl+glPeriod+fa+faPeriod+wa+waPeriod));
                if (accsubs.Count() == 1)
                {
                    //int iModiPeri = accountSubs[accCode].First().iModiPeri;
                    if (glPeriod < 12)
                        message += string.Format("GL,{0},[未完成],", glPeriod);
                       // log.Debug( string.Format("{0},GL,{1},[未完成],",accCode, iModiPeri));
                   // else
                       // message += string.Format("GL,{0},,", glPeriod);
                        //log.Debug(string.Format("{0},GL,{1},,", accCode, iModiPeri));

                }
                //modules ==2 gl+fa/wa 
                else if (accsubs.Count() > 1)
                {
 
                    if (wa=="WA"&& waPeriod<11&& glPeriod<=waPeriod)
                        message += string.Format("WA,{0},[未完成],", waPeriod);
                       // log.Debug(string.Format("{0},WA,{1},[未完成],", accCode, waPeriod));
                   // else if (wa == "WA" && waPeriod == 11)
                     //   message += string.Format("WA,{0},,", waPeriod);
                      //  log.Debug(string.Format("{0},WA,{1},,", accCode, waPeriod));
                     if (fa == "FA" && faPeriod < 12)
                        message += string.Format("FA,{0},[未完成],", faPeriod);
                      //  log.Debug(string.Format("{0},FA,{1},[未完成],", accCode, faPeriod));
                   // else if (fa == "FA" && faPeriod == 12)
                   //     message += string.Format("FA,{0},,", faPeriod);
                       // log.Debug(string.Format("{0},FA,{1},,", accCode, faPeriod));
                     if ((wa==""&&gl=="GL"&& glPeriod<12) ||(wa=="wa"&& gl == "GL" && glPeriod < 11) )
                        message += string.Format("GL,{0},[未完成],", glPeriod);
                       // log.Debug(string.Format("{0},GL,{1},[未完成],", accCode, glPeriod));
                  //  else
                   //     message += string.Format("GL,{0},,", glPeriod);
                       // log.Debug(string.Format("{0},GL,{1},,", accCode, glPeriod));

                }

                //else if (accsubs.Count() == 3)
                //{
                //    if (wa == "WA" && waPeriod < 11)
                //        message += string.Format("WA,{0},[未完成],", waPeriod);
                //    if (fa == "FA" && faPeriod < 12)
                //        message += string.Format("FA,{0},[未完成],", faPeriod);
                //    if (gl == "GL" && glPeriod < 11)
                //        message += string.Format("GL,{0},[未完成],", glPeriod);
                //}
                if (message != "")
                {
                    message = accCode + ","+message;
                  log.Debug(message);
                }
            }
            //foreach (string accountCode in accountCodes)
            //{
            //    Dictionary<string, int> flag = this.GetSingleAccountManyModuleLastFlag(accountCode, checkYear, modules);
            //    String message = accountCode+",";
            //    foreach (var module in flag.Keys)
            //    {
            //        int lastflag = flag[module];
            //        //if ((module == "WA" && lastflag > 0 && lastflag < 11)||
            //        //    (module == "FA" && lastflag > 0 && lastflag < 12)||
            //        //    (module == "GL" && lastflag > 0 && lastflag < 11)
            //        //    )
            //        //{

            //        //}
            //        if (module=="WA" && lastflag > 0 && lastflag < 11 )
            //        {
            //            message += string.Format("WA,{0},[未完成],", lastflag);
            //        }
            //        else if (module == "FA" && lastflag > 0 && lastflag < 12)
            //        {
            //            message += string.Format("FA,{0},[未完成],", lastflag);
            //        }
            //        else if (module == "GL" && lastflag > 0 && lastflag < 11)
            //        {
            //            message += string.Format("GL,{0},[未完成],", lastflag);
            //        }
            //        else
            //        {
            //            message += string.Format("{0},{1},,",module, lastflag);
            //        }
            //    }
            //    // set dictonary key and value (Flag and month) to a string 
            //   // string flagText = string.Join("  ", flag.Select(kvp => string.Join(":", kvp.Key, kvp.Value)));
            //    //string message = string.Format("{0}    {1}", accountCode, flagText);
            //    list.Add(message);
            //    log.Debug(message);
            //}

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
                Talk("create floder failed:" + floderPath);
                return false;
            }

            param.ParamNameValues= GetSqlSentenceParamNameValues(acc);
            param.ParamNameValues.Add("{ufmodelPath}", string.Format("{0}ufmodel.bak", accPath));
            param.ParamNameValues.Add("{mdfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.MDF", accPath, acc.cAcc_Id, setting.newYear));
            param.ParamNameValues.Add("{ldfPath}", string.Format("{0}ZT{1}\\{2}\\UFDATA.LDF", accPath, acc.cAcc_Id, setting.newYear));

            param.SqlSentenceQueue =setting.createNewYearDbSentencesQueue;
            
            SQLRepositoryManage sqlRepositoryManage = new SQLRepositoryManage();
            List<SqlSentence> sqlSentences = sqlRepositoryManage.GetAliveSqlSentences(@"template\RDB", param);
            foreach (var sentence in sqlSentences)
            {
              //  Talk("AdoNetHelper executeCommand:" + sentence.Name + ",aliveSql:" + sentence.ALiveSQL);
                ADONetHelper.ExecuteCommand(sentence.ALiveSQL);
              //  Talk("AdoNetHelper executeCommand:" + sentence.Name + "  over");
            }
            bool isDBExist = ADONetHelper.isDBisExist(param.ParamNameValues["{newYearDB}"]) == 1;
            Talk(string.Format("create {0} database {1}", acc.cAcc_Id, isDBExist));
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
        /// <summary>
        /// get account on old year turn on modules
        /// </summary>
        /// <param name="account">ua_account</param>
        /// <returns></returns>
        public Dictionary<string,int> GetSingleAccountHasModules(string accountCode,string[] voidCarryFowradModules)
        {
           // Dictionary<string,int> result = new Dictionary<string, int>();
            Dictionary<string,int> accountSub =new Dictionary<string, int>();

            using (CreateNextYearDbContext context = new CreateNextYearDbContext())
            {
                accountSub = context.UA_Account_sub
                    .Where(e => e.cAcc_Id == accountCode && e.iYear == Convert.ToInt32(setting.oldYear) && voidCarryFowradModules.Contains(e.cSub_Id))
                    .ToDictionary(e =>e.cSub_Id,e=>Convert.ToInt32(e.iModiPeri));
            }
            //Dictionary<string, string[]> able = new Dictionary<string, string[]>();
            //List<string> unable = new List<string>();

            ////module=1 GL,
            //if (accountSub.Count == 1)
            //{
            //    if (accountSub.ContainsKey("GL") && accountSub["GL"] == 12)
            //        able.Add(accountCode, new string[] { "GL" });
            //    else
            //        unable.Add(string.Format("{0},GL,{1},,", accountCode, accountSub["GL"]));
            //}
            ////module>2
            //else
            //{

            //    foreach (var module in accountSub.Keys)
            //   {
            //        int iModiPeri = accountSub[module];
            //        switch (module)
            //        {
            //            case "GL":
            //                if (iModiPeri==12)
            //                    able.Add(accountCode, new string[] { module });
            //                break;
            //            case "FA":
            //                if(iModiPeri==12)
            //                    able.Add(accountCode, new string[] { module });
            //                break;
            //            case "WA":
            //                break;
            //            default:
            //                break;
            //        }
            //        if (module=="GL"&& iModiPeri==12)
            //        {
            //            able.Add(accountCode, new string[] { module });
            //        }
            //        else (module == "GL" && iModiPeri == 12)
            //        {

            //        }
            //    }
            //}
            return accountSub;
        }

        /// <summary>
        /// get array accounts  on old year turn on modules which is allow in setting
        /// </summary>
        /// <param name="accountCodes"></param>
        /// <param name="allowModules"></param>
        /// <returns></returns>
        public Dictionary<string,string[]> GetManyAccountHasUseModules(List<string> accountCodes,List<string> allowModules)
        {
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            using (CreateNextYearDbContext context = new CreateNextYearDbContext())
            {
                result = context.UA_Account_sub
                    .Where(e =>accountCodes.Contains(e.cAcc_Id)&& e.iYear.ToString() == setting.oldYear && allowModules.Contains(e.cSub_Id))
                    .GroupBy(e=>e.cAcc_Id)
                    .ToDictionary(x=>x.First().cAcc_Id,y=>y.Select(e=>e.cSub_Id).ToArray());
            }
            return result;
        }
        /// <summary>
        /// get account on old year trun on module which can able carryfowrad new year
        /// </summary>
        /// <param name="moduleAndPeriod"></param>
        /// <returns></returns>
        //public List<string> GetAccountCarryFowradAbleModule(Dictionary<string, int> moduleAndPeriod)
        //{
        //    List<string> able = new List<string>();
        //    List<string> unable = new List<string>();
        //    if (moduleAndPeriod.Count() == 1)
        //    {
        //        if (moduleAndPeriod["GL"] == 12)
        //            able.Add()
        //    }
        //    foreach (var item in moduleAndPeriod)
        //    {
        //        i
        //    }


        //}

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

        public void Talk(string message)
        {
            logDelegate(message);
        }
    }
}
