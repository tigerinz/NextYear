//============================================================
// Producnt name:		BoBoARTS.CodeMad
// Version: 			1.0
// Coded by:			Shen Bo (bo.shen@jb-aptech.com.cn)
// Auto generated at: 	2015-12-20 12:38:24
//============================================================

using System;
using COM;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using kncx.Models;

namespace kncx.DAL
{
	public  partial class UA_AccountDAL
	{
        public  UA_Account AddUA_Account(UA_Account uA_Account)
		{
            string sql =
				"INSERT [UA_Account] (iSysID, cAcc_Name, cAcc_Path, iYear, iMonth, cAcc_Master, cCurCode, cCurName, cUnitName, cUnitAbbre, cUnitAddr, cUnitZap, cUnitTel, cUnitFax, cUnitEMail, cUnitTaxNo, cUnitLP, cFinKind, cFinType, cEntType, cTradeKind)" +
				" VALUES (@iSysID, @cAcc_Name, @cAcc_Path, @iYear, @iMonth, @cAcc_Master, @cCurCode, @cCurName, @cUnitName, @cUnitAbbre, @cUnitAddr, @cUnitZap, @cUnitTel, @cUnitFax, @cUnitEMail, @cUnitTaxNo, @cUnitLP, @cFinKind, @cFinType, @cEntType, @cTradeKind)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ISysID", uA_Account.ISysID),
					new SqlParameter("@CAcc_Name", uA_Account.CAcc_Name),
					new SqlParameter("@CAcc_Path", uA_Account.CAcc_Path),
					new SqlParameter("@IYear", uA_Account.IYear),
					new SqlParameter("@IMonth", uA_Account.IMonth),
					new SqlParameter("@CAcc_Master", uA_Account.CAcc_Master),
					new SqlParameter("@CCurCode", uA_Account.CCurCode),
					new SqlParameter("@CCurName", uA_Account.CCurName),
					new SqlParameter("@CUnitName", uA_Account.CUnitName),
					new SqlParameter("@CUnitAbbre", uA_Account.CUnitAbbre),
					new SqlParameter("@CUnitAddr", uA_Account.CUnitAddr),
					new SqlParameter("@CUnitZap", uA_Account.CUnitZap),
					new SqlParameter("@CUnitTel", uA_Account.CUnitTel),
					new SqlParameter("@CUnitFax", uA_Account.CUnitFax),
					new SqlParameter("@CUnitEMail", uA_Account.CUnitEMail),
					new SqlParameter("@CUnitTaxNo", uA_Account.CUnitTaxNo),
					new SqlParameter("@CUnitLP", uA_Account.CUnitLP),
					new SqlParameter("@CFinKind", uA_Account.CFinKind),
					new SqlParameter("@CFinType", uA_Account.CFinType),
					new SqlParameter("@CEntType", uA_Account.CEntType),
					new SqlParameter("@CTradeKind", uA_Account.CTradeKind)
				};
				
                int newId = DBHelper.GetScalar(sql, para);
				return GetUA_AccountByCAcc_Id(newId);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public  void DeleteUA_Account(UA_Account uA_Account)
		{
			DeleteUA_AccountByCAcc_Id( uA_Account.CAcc_Id );
		}

        public  void DeleteUA_AccountByCAcc_Id(String cAcc_Id)
		{
            string sql = "DELETE [UA_Account] WHERE CAcc_Id = @CAcc_Id";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@cAcc_Id", cAcc_Id)
				};
			
                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
				throw e;
            }
		}
		
        public  void DeleteUA_AccountByCAcc_Id(String cAcc_Id)
		{
            string sql = "DELETE [UA_Account] WHERE CAcc_Id = @CAcc_Id";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CAcc_Id", cAcc_Id)
				};
			
                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
				throw e;
            }
		}
		
        public  void ModifyUA_Account(UA_Account uA_Account)
        {
            string sql =
                "UPDATE [UA_Account] " +
                "SET " +
	                "iSysID = @iSysID, " +
	                "cAcc_Name = @cAcc_Name, " +
	                "cAcc_Path = @cAcc_Path, " +
	                "iYear = @iYear, " +
	                "iMonth = @iMonth, " +
	                "cAcc_Master = @cAcc_Master, " +
	                "cCurCode = @cCurCode, " +
	                "cCurName = @cCurName, " +
	                "cUnitName = @cUnitName, " +
	                "cUnitAbbre = @cUnitAbbre, " +
	                "cUnitAddr = @cUnitAddr, " +
	                "cUnitZap = @cUnitZap, " +
	                "cUnitTel = @cUnitTel, " +
	                "cUnitFax = @cUnitFax, " +
	                "cUnitEMail = @cUnitEMail, " +
	                "cUnitTaxNo = @cUnitTaxNo, " +
	                "cUnitLP = @cUnitLP, " +
	                "cFinKind = @cFinKind, " +
	                "cFinType = @cFinType, " +
	                "cEntType = @cEntType, " +
	                "cTradeKind = @cTradeKind " +
                "WHERE cAcc_Id = @cAcc_Id";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@cAcc_Id", uA_Account.CAcc_Id),
					new SqlParameter("@ISysID", uA_Account.ISysID),
					new SqlParameter("@CAcc_Name", uA_Account.CAcc_Name),
					new SqlParameter("@CAcc_Path", uA_Account.CAcc_Path),
					new SqlParameter("@IYear", uA_Account.IYear),
					new SqlParameter("@IMonth", uA_Account.IMonth),
					new SqlParameter("@CAcc_Master", uA_Account.CAcc_Master),
					new SqlParameter("@CCurCode", uA_Account.CCurCode),
					new SqlParameter("@CCurName", uA_Account.CCurName),
					new SqlParameter("@CUnitName", uA_Account.CUnitName),
					new SqlParameter("@CUnitAbbre", uA_Account.CUnitAbbre),
					new SqlParameter("@CUnitAddr", uA_Account.CUnitAddr),
					new SqlParameter("@CUnitZap", uA_Account.CUnitZap),
					new SqlParameter("@CUnitTel", uA_Account.CUnitTel),
					new SqlParameter("@CUnitFax", uA_Account.CUnitFax),
					new SqlParameter("@CUnitEMail", uA_Account.CUnitEMail),
					new SqlParameter("@CUnitTaxNo", uA_Account.CUnitTaxNo),
					new SqlParameter("@CUnitLP", uA_Account.CUnitLP),
					new SqlParameter("@CFinKind", uA_Account.CFinKind),
					new SqlParameter("@CFinType", uA_Account.CFinType),
					new SqlParameter("@CEntType", uA_Account.CEntType),
					new SqlParameter("@CTradeKind", uA_Account.CTradeKind)
				};

				DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		

        public  IList<UA_Account> GetAllUA_Accounts()
        {
            string sqlAll = "SELECT * FROM [UA_Account]";
			return GetUA_AccountsBySql( sqlAll );
        }
		
        public  UA_Account GetUA_AccountByCAcc_Id(String cAcc_Id)
        {
            string sql = "SELECT * FROM [UA_Account] WHERE CAcc_Id = @CAcc_Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@CAcc_Id", cAcc_Id));
                if (reader.Read())
                {
                    UA_Account uA_Account = new UA_Account();

					uA_Account.ISysID = Convert.ToString(DBHelper.FromDBNull(reader["ISysID"]));
					uA_Account.CAcc_Id = Convert.ToString(DBHelper.FromDBNull(reader["CAcc_Id"]));
					uA_Account.CAcc_Name = Convert.ToString(DBHelper.FromDBNull(reader["CAcc_Name"]));
					uA_Account.CAcc_Path = Convert.ToString(DBHelper.FromDBNull(reader["CAcc_Path"]));
					uA_Account.IYear = Convert.ToShort(DBHelper.FromDBNull(reader["IYear"]));
					uA_Account.IMonth = Convert.ToShort(DBHelper.FromDBNull(reader["IMonth"]));
					uA_Account.CAcc_Master = Convert.ToString(DBHelper.FromDBNull(reader["CAcc_Master"]));
					uA_Account.CCurCode = Convert.ToString(DBHelper.FromDBNull(reader["CCurCode"]));
					uA_Account.CCurName = Convert.ToString(DBHelper.FromDBNull(reader["CCurName"]));
					uA_Account.CUnitName = Convert.ToString(DBHelper.FromDBNull(reader["CUnitName"]));
					uA_Account.CUnitAbbre = Convert.ToString(DBHelper.FromDBNull(reader["CUnitAbbre"]));
					uA_Account.CUnitAddr = Convert.ToString(DBHelper.FromDBNull(reader["CUnitAddr"]));
					uA_Account.CUnitZap = Convert.ToString(DBHelper.FromDBNull(reader["CUnitZap"]));
					uA_Account.CUnitTel = Convert.ToString(DBHelper.FromDBNull(reader["CUnitTel"]));
					uA_Account.CUnitFax = Convert.ToString(DBHelper.FromDBNull(reader["CUnitFax"]));
					uA_Account.CUnitEMail = Convert.ToString(DBHelper.FromDBNull(reader["CUnitEMail"]));
					uA_Account.CUnitTaxNo = Convert.ToString(DBHelper.FromDBNull(reader["CUnitTaxNo"]));
					uA_Account.CUnitLP = Convert.ToString(DBHelper.FromDBNull(reader["CUnitLP"]));
					uA_Account.CFinKind = Convert.ToString(DBHelper.FromDBNull(reader["CFinKind"]));
					uA_Account.CFinType = Convert.ToString(DBHelper.FromDBNull(reader["CFinType"]));
					uA_Account.CEntType = Convert.ToString(DBHelper.FromDBNull(reader["CEntType"]));
					uA_Account.CTradeKind = Convert.ToString(DBHelper.FromDBNull(reader["CTradeKind"]));

                    reader.Close();
					
                    return uA_Account;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
		
        public  UA_Account GetUA_AccountByCAcc_Id(String cAcc_Id)
        {
            string sql = "SELECT * FROM [UA_Account] WHERE cAcc_Id = @cAcc_Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@cAcc_Id", cAcc_Id));
                if (reader.Read())
                {
                    UA_Account uA_Account = new UA_Account();

					uA_Account.ISysID = Convert.ToString(DBHelper.FromDBNull(reader["iSysID"]));
					uA_Account.CAcc_Id = Convert.ToString(DBHelper.FromDBNull(reader["cAcc_Id"]));
					uA_Account.CAcc_Name = Convert.ToString(DBHelper.FromDBNull(reader["cAcc_Name"]));
					uA_Account.CAcc_Path = Convert.ToString(DBHelper.FromDBNull(reader["cAcc_Path"]));
					uA_Account.IYear = Convert.ToShort(DBHelper.FromDBNull(reader["iYear"]));
					uA_Account.IMonth = Convert.ToShort(DBHelper.FromDBNull(reader["iMonth"]));
					uA_Account.CAcc_Master = Convert.ToString(DBHelper.FromDBNull(reader["cAcc_Master"]));
					uA_Account.CCurCode = Convert.ToString(DBHelper.FromDBNull(reader["cCurCode"]));
					uA_Account.CCurName = Convert.ToString(DBHelper.FromDBNull(reader["cCurName"]));
					uA_Account.CUnitName = Convert.ToString(DBHelper.FromDBNull(reader["cUnitName"]));
					uA_Account.CUnitAbbre = Convert.ToString(DBHelper.FromDBNull(reader["cUnitAbbre"]));
					uA_Account.CUnitAddr = Convert.ToString(DBHelper.FromDBNull(reader["cUnitAddr"]));
					uA_Account.CUnitZap = Convert.ToString(DBHelper.FromDBNull(reader["cUnitZap"]));
					uA_Account.CUnitTel = Convert.ToString(DBHelper.FromDBNull(reader["cUnitTel"]));
					uA_Account.CUnitFax = Convert.ToString(DBHelper.FromDBNull(reader["cUnitFax"]));
					uA_Account.CUnitEMail = Convert.ToString(DBHelper.FromDBNull(reader["cUnitEMail"]));
					uA_Account.CUnitTaxNo = Convert.ToString(DBHelper.FromDBNull(reader["cUnitTaxNo"]));
					uA_Account.CUnitLP = Convert.ToString(DBHelper.FromDBNull(reader["cUnitLP"]));
					uA_Account.CFinKind = Convert.ToString(DBHelper.FromDBNull(reader["cFinKind"]));
					uA_Account.CFinType = Convert.ToString(DBHelper.FromDBNull(reader["cFinType"]));
					uA_Account.CEntType = Convert.ToString(DBHelper.FromDBNull(reader["cEntType"]));
					uA_Account.CTradeKind = Convert.ToString(DBHelper.FromDBNull(reader["cTradeKind"]));

                    reader.Close();

                    return uA_Account;
                }
                else
                {
					reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
		
		
		
		
        private  IList<UA_Account> GetUA_AccountsBySql( string safeSql )
        {
            List<UA_Account> list = new List<UA_Account>();

			try
			{
				DataTable table = DBHelper.GetDataSet( safeSql );
				
				foreach (DataRow row in table.Rows)
				{
					UA_Account uA_Account = new UA_Account();
					
					uA_Account.ISysID = Convert.ToString(DBHelper.FromDBNull(row["iSysID"]));
					uA_Account.CAcc_Id = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Id"]));
					uA_Account.CAcc_Name = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Name"]));
					uA_Account.CAcc_Path = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Path"]));
					uA_Account.IYear = Convert.ToShort(DBHelper.FromDBNull(row["iYear"]));
					uA_Account.IMonth = Convert.ToShort(DBHelper.FromDBNull(row["iMonth"]));
					uA_Account.CAcc_Master = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Master"]));
					uA_Account.CCurCode = Convert.ToString(DBHelper.FromDBNull(row["cCurCode"]));
					uA_Account.CCurName = Convert.ToString(DBHelper.FromDBNull(row["cCurName"]));
					uA_Account.CUnitName = Convert.ToString(DBHelper.FromDBNull(row["cUnitName"]));
					uA_Account.CUnitAbbre = Convert.ToString(DBHelper.FromDBNull(row["cUnitAbbre"]));
					uA_Account.CUnitAddr = Convert.ToString(DBHelper.FromDBNull(row["cUnitAddr"]));
					uA_Account.CUnitZap = Convert.ToString(DBHelper.FromDBNull(row["cUnitZap"]));
					uA_Account.CUnitTel = Convert.ToString(DBHelper.FromDBNull(row["cUnitTel"]));
					uA_Account.CUnitFax = Convert.ToString(DBHelper.FromDBNull(row["cUnitFax"]));
					uA_Account.CUnitEMail = Convert.ToString(DBHelper.FromDBNull(row["cUnitEMail"]));
					uA_Account.CUnitTaxNo = Convert.ToString(DBHelper.FromDBNull(row["cUnitTaxNo"]));
					uA_Account.CUnitLP = Convert.ToString(DBHelper.FromDBNull(row["cUnitLP"]));
					uA_Account.CFinKind = Convert.ToString(DBHelper.FromDBNull(row["cFinKind"]));
					uA_Account.CFinType = Convert.ToString(DBHelper.FromDBNull(row["cFinType"]));
					uA_Account.CEntType = Convert.ToString(DBHelper.FromDBNull(row["cEntType"]));
					uA_Account.CTradeKind = Convert.ToString(DBHelper.FromDBNull(row["cTradeKind"]));
	
					list.Add(uA_Account);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
		
        private  IList<UA_Account> GetUA_AccountsBySql( string sql, params SqlParameter[] values )
        {
            List<UA_Account> list = new List<UA_Account>();

			try
			{
				DataTable table = DBHelper.GetDataSet( sql, values );
				
				foreach (DataRow row in table.Rows)
				{
					UA_Account uA_Account = new UA_Account();
					
					uA_Account.ISysID = Convert.ToString(DBHelper.FromDBNull(row["iSysID"]));
					uA_Account.CAcc_Id = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Id"]));
					uA_Account.CAcc_Name = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Name"]));
					uA_Account.CAcc_Path = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Path"]));
					uA_Account.IYear = Convert.ToShort(DBHelper.FromDBNull(row["iYear"]));
					uA_Account.IMonth = Convert.ToShort(DBHelper.FromDBNull(row["iMonth"]));
					uA_Account.CAcc_Master = Convert.ToString(DBHelper.FromDBNull(row["cAcc_Master"]));
					uA_Account.CCurCode = Convert.ToString(DBHelper.FromDBNull(row["cCurCode"]));
					uA_Account.CCurName = Convert.ToString(DBHelper.FromDBNull(row["cCurName"]));
					uA_Account.CUnitName = Convert.ToString(DBHelper.FromDBNull(row["cUnitName"]));
					uA_Account.CUnitAbbre = Convert.ToString(DBHelper.FromDBNull(row["cUnitAbbre"]));
					uA_Account.CUnitAddr = Convert.ToString(DBHelper.FromDBNull(row["cUnitAddr"]));
					uA_Account.CUnitZap = Convert.ToString(DBHelper.FromDBNull(row["cUnitZap"]));
					uA_Account.CUnitTel = Convert.ToString(DBHelper.FromDBNull(row["cUnitTel"]));
					uA_Account.CUnitFax = Convert.ToString(DBHelper.FromDBNull(row["cUnitFax"]));
					uA_Account.CUnitEMail = Convert.ToString(DBHelper.FromDBNull(row["cUnitEMail"]));
					uA_Account.CUnitTaxNo = Convert.ToString(DBHelper.FromDBNull(row["cUnitTaxNo"]));
					uA_Account.CUnitLP = Convert.ToString(DBHelper.FromDBNull(row["cUnitLP"]));
					uA_Account.CFinKind = Convert.ToString(DBHelper.FromDBNull(row["cFinKind"]));
					uA_Account.CFinType = Convert.ToString(DBHelper.FromDBNull(row["cFinType"]));
					uA_Account.CEntType = Convert.ToString(DBHelper.FromDBNull(row["cEntType"]));
					uA_Account.CTradeKind = Convert.ToString(DBHelper.FromDBNull(row["cTradeKind"]));
	
					list.Add(uA_Account);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
			
        }
		
	}
}
