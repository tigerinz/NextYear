//============================================================
// Producnt name:		BoBoARTS.CodeMad
// Version: 			1.0
// Coded by:			Shen Bo (bo.shen@jb-aptech.com.cn)
// Auto generated at: 	2015-12-20 12:38:21
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using kncx.DAL;
using kncx.Models;

namespace kncx.BLL
{

    public  partial class UA_AccountService
    {
        UA_AccountDAL ua_accountdal = new UA_AccountDAL();
    
        public  UA_Account AddUA_Account(UA_Account uA_Account)
        {
        
            return ua_accountdal.AddUA_Account(uA_Account);
        }

        public  void DeleteUA_Account(UA_Account uA_Account)
        {
            ua_accountdal.DeleteUA_Account(uA_Account);
        }

        public  void DeleteUA_AccountById(string cAcc_Id)
        {
            ua_accountdal.DeleteUA_AccountById(cAcc_Id);
        }

		public  void ModifyUA_Account(UA_Account uA_Account)
        {
            ua_accountdal.ModifyUA_Account(uA_Account);
        }
        
        public  IList<UA_Account> GetAllUA_Accounts()
        {
            return ua_accountdal.GetAllUA_Accounts();
        }

        public  UA_Account GetUA_AccountByCAcc_Id(string cAcc_Id)
        {
            return ua_accountdal.GetUA_AccountByCAcc_Id(cAcc_Id);
        }

    }
}
