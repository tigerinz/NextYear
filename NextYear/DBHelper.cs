using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
/********************************* 
* 类名：DBHelper 
* 功能描述：提供基本数据访问功能 
* ******************************/
namespace COM
{
    public static class DBHelper
    {


        //数据库连接属性 
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                return connection;
                
            }
        }

        /// <summary>
        /// 测试数据库连接，并out错误信息
        /// </summary>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public static Boolean ConnectionTest(out String ExceptionMessage)
        {
            ExceptionMessage = "";
            try
            {
                SqlConnection conn = Connection;
            }
            catch (Exception e)
            {
                ExceptionMessage = e.Message;

                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取ConnectionString里的参数，返回sqlConnectionStringBuilder
        /// </summary>
        /// <returns></returns>
        public static SqlConnectionStringBuilder GetSqlConnectionStringBuilder() 
        {
            string connectionString = "";
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
          //  string connString = System.Configuration.ConfigurationManager.AppSettings["ConnString"];
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connectionString);          
            return sb;
        }
        /// <summary>
        /// 设置ConnectionString
        /// </summary>
        /// <param name="sb"></param>
        public static void SetConnectionString(SqlConnectionStringBuilder sb)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load("kncx.exe.config");
            //XmlNode root = doc.SelectSingleNode("configuration");
            //XmlNode node = root.SelectSingleNode("connectionStrings/add[@name='ConnectionString']");
            //XmlElement el = node as XmlElement;
            //el.SetAttribute("connectionString", sb.ConnectionString);
            //doc.Save("kncx.exe.config");

            XmlDocument doc = new XmlDocument();
            doc.Load("..//..//app.config");
            XmlNode root = doc.SelectSingleNode("configuration");
            XmlNode node = root.SelectSingleNode("connectionStrings/add[@name='ConnectionString']");
            XmlElement el = node as XmlElement;
            el.SetAttribute("connectionString", sb.ConnectionString);
            doc.Save("..//..//app.config");


        }

        /// <summary> 
        /// 执行无参SQL语句 
        /// </summary> 
        public static int ExecuteCommand(string safeSql)
        {
            using(SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {
                int result = cmd.ExecuteNonQuery();
                return result;

            }
        }
        /// <summary> 
        /// 执行带参SQL语句 
        /// </summary> 
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            using(SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// 执行无参存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteStoredProcedure(String sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 执行有参存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteStoredProcedure(String sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行有参存储过程,返回数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataTable GetDataSetStoredProcedure(String sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(values);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
        }

        /// <summary> 
        /// 执行无参SQL语句，并返回第一个结果 
        /// </summary> 
        public static object GetScalar(string safeSql)
        {
            using(SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {

               return cmd.ExecuteScalar();

            }
        }
        /// <summary> 
        /// 执行有参SQL语句，并返回第一个结果 
        /// </summary> 
        public static object GetScalar(string sql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteScalar();
            }
        }
        ///  }<summary> 
        /// 执行无参SQL语句，并返回SqlDataReader 
        /// </summary> 
        public static SqlDataReader GetReader(string safeSql)
        {
            using(SqlCommand cmd = new SqlCommand(safeSql, Connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;

            }
        }
        /// <summary> 
        /// 执行有参SQL语句，并返回SqlDataReader 
        /// </summary> 
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            using(SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.Parameters.AddRange(values);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
                    
            }
        }
        /// <summary> 
        /// 执行无参SQL语句，并返回DataTable 
        /// </summary> 
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                   // adapter.FillSchema(ds, SchemaType.Mapped);
                    return ds.Tables[0];
            

        }
        /// <summary> 
        /// 执行有参SQL语句，并返回DataTable 
        /// </summary> 
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            
                cmd.Parameters.AddRange(values);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                adapter.FillSchema(ds, SchemaType.Mapped);
                return ds.Tables[0];

            
        }

        //--------------------------------------------------------------
        /// <summary>
        /// 通过表主键查找对应DataRow
        /// </summary>
        /// <param name="table"></param>
        /// <param name="pkValue"></param>
        /// <returns></returns>
        public static DataRow FindDataRowInPrimaryKeyColumn(DataTable table, String pkValue)
        {
            // Find the number pkValue in the primary key 
            // column of the table.
            DataRow foundRow = table.Rows.Find(pkValue);

            // Print the value of column 1 of the found row.
            return foundRow;

        }

        public static Object FromDBNull(Object obj)
        {
            if (DBNull.Value == obj)
            {
                return null;
            }
            else
            {
                return obj;
            }
        }
        /// <summary>
        /// null -> dbnull.value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Object ToDBNull(Object obj)
        {
            if (null == obj)
            {
                return DBNull.Value;
            }
           return obj; 
        }
        /// <summary>
        /// "" null ->dbnull.value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Object ToDBNull2(Object obj)
        {
            if (obj.ToString() == "")
            {
                return DBNull.Value;
            }
            if (null == obj)
            {
                return DBNull.Value;
            }
            return obj;
        }
        //-------------------------------------other --------------------------------------------------
        /// <summary>
        /// 拼接多个like
        /// </summary>
        /// <param name="word">要匹配的字段</param>
        /// <param name="str">数组</param>
        /// <returns>(word like 'str[0]%' or word like 'str[1]%' or ...)</returns>

        public static String SplitJoinSqlLike(String word, String[] str)
        {
            String result = "( ";
            foreach (String s in str)
            {
                result += word + " like '" + s + "%' or ";
            }
            result = result.Substring(0, result.Length - 3);
            result += " ) ";
            return result;
        }

        /// <summary>
        /// 把whereOtherSql List 拼接成String
        /// </summary>
        /// <param name="whereOtherSql">List</param>
        /// <returns>String</returns>
        public static String ListWhereSqlToString(List<String> whereOtherSql)
        {
            if (whereOtherSql.Count == 0)
                return "";
            return " where " + JionListWithAnd(whereOtherSql);
        }

        public static String JionListWithAnd(List<String> list)
        {
            String reslut = "";

            foreach (String s in list)
            {
                reslut += " and " + s;
            }
            return reslut.Remove(0, 4);
        }
    
    }
}