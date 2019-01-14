using COM;
using CreateNextYear;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016WAProblem
{
    public partial class Form1 : Form
    {
        public static StringBuilder log = new StringBuilder();
        private const string WA_GZData = "WA_GZData";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            using (DataContext dc = new DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                var account = dc.GetTable<UA_AccountEntity>();
                var q = from acc in account
                        orderby acc.Cacc_id
                        select acc;
                uA_AccountEntityDataGridView.DataSource = q.AsEnumerable().ToList();
            }


        }

        private void butAll_Click(object sender, EventArgs e)
            
        {
            int rows = uA_AccountEntityDataGridView.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                uA_AccountEntityDataGridView[0, i].Value = true;
            }
        }

        private void butUnChoose_Click(object sender, EventArgs e)
        {
            int rows = uA_AccountEntityDataGridView.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                uA_AccountEntityDataGridView[0, i].Value = false;
            }
        }

        private void butReverse_Click(object sender, EventArgs e)
        {
            int rows = uA_AccountEntityDataGridView.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                bool b = (bool)uA_AccountEntityDataGridView[0, i].Value;
                uA_AccountEntityDataGridView[0, i].Value = !b;
            }
        }

        private void butWA_Click(object sender, EventArgs e)
        {
            List<UA_AccountEntity> accounts = (from acc in uA_AccountEntityDataGridView.DataSource as List<UA_AccountEntity>
                                              where acc.IsChoose == true
                                              select acc).ToList();

            if (accounts == null) return;
            foreach (var acc in accounts)
            {
                log.AppendLine("-----------------------" + acc.Cacc_id + "------------------");
                acc.Maxyear = 2015;
                acc.Newyear = 2016;

                if (DBWAHasRows(acc, WA_GZData)) continue;
                

                List<string> oldColumns =  GetOldWAColumns(acc,WA_GZData);
                DorpColumnWA_GZDataF_8(acc, oldColumns);
                AddExceptColumns(acc,  oldColumns);

                string columnsStr = "";
                if (oldColumns.Count>0)
                columnsStr = string.Join(",", oldColumns);

                InsertUpdataWAData(acc, columnsStr);

                WriterLogToDisk(Environment.CurrentDirectory + "\\" + acc.Cacc_id + "WAProblem.txt", log.ToString());
                log.Clear();
            }

        }

        private  bool DBWAHasRows(UA_AccountEntity acc, string tableName)
        {
            bool SourcehasRows = false;
            bool TargerhasRows = false;
            string sql = "select * from {0}..{1}";
            string cmdS = string.Format(sql, acc.SourceDB,tableName);
            string cmdT = string.Format(sql, acc.TargerDB,tableName);
            log.AppendLine(cmdS);
            SqlDataReader sdr= DBHelper.GetReader(cmdS);

            SourcehasRows = sdr.HasRows;
            sdr.Close();

            log.AppendLine(cmdT);
            SqlDataReader sdrt = DBHelper.GetReader(cmdT);

            TargerhasRows = sdrt.HasRows;
            sdrt.Close();


            //与 都为True时 返回True 否则为false
            return SourcehasRows & TargerhasRows;
        }

        private  void InsertUpdataWAData(UA_AccountEntity acc, string oldColumnsStr)
        {
           // string columnsStr="";
            //  if (oldColumnsStr=)
            //     columnsStr = ","+string.Join(",", exceptWAColumns);
            //SELECT[cGZGradeNum], [cPsn_Num], [cPsn_Name], [cDept_Num], [iPsnGrd_id], [iYear], [iMonth], [iAccMonth], [bDCBZ], [bTFBZ], [cPreDeptNum], [F_1], [F_2], [F_3], [F_4], [F_5], [F_6],[F_7]{2}
            string sql = @"insert into {0}..WA_GZData 
                     SELECT {2} 
                     FROM {1}..WA_GZData where imonth =12;
                     update {0}..WA_GZData set imonth=1,iAccMonth=1,iyear=2016";
            string cmd = string.Format(sql, acc.TargerDB, acc.SourceDB, oldColumnsStr);
            log.AppendLine(cmd);
            try
            {
            DBHelper.ExecuteCommand(cmd);

            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message +"-------"+acc.Cacc_id+"------------");
            }
        }

        /// <summary>
        /// 添加新表不存在的字段
        /// </summary>
        /// <param name="acc"></param>
        private void AddExceptColumns(UA_AccountEntity acc , List<string> oldColumns)
        {
            
            List<string> newColumns = GetNewWAColumns(acc,WA_GZData);

            // List<string> oldColumnsSort =new List<string>( oldColumns);
            List<string> exceptWAColumns = newColumns.Except(oldColumns).ToList();
            foreach (var column in exceptWAColumns)
            {
                string sql = @"alter table {0}..WA_GZData add {1} numeric(18,2)";
                string cmd = String.Format(sql, acc.TargerDB, column);
                log.AppendLine(cmd);
                DBHelper.ExecuteCommand(cmd);
            }
        }

        private static void DorpColumnWA_GZDataF_8(UA_AccountEntity acc , List<string> oldColumns)
        {
            if (!oldColumns.Contains("F_8")) return;
            string sqlDrop = @"alter table {0}..WA_GZData drop column {1}";
            string cmdDrop = String.Format(sqlDrop, acc.TargerDB, "F_8");
            log.AppendLine(cmdDrop);

            DBHelper.ExecuteCommand(cmdDrop);

        }

        /// <summary>
        /// 得到老数据库WA_GZData的所有字段
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        private List<string> GetOldWAColumns(UA_AccountEntity acc, string tableName)
        {
          return  GetTableColumns(acc.SourceDB, tableName);
           
        }

        /// <summary>
        /// 得到新数据库WA_GZData的所有字段
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        private List<string> GetNewWAColumns(UA_AccountEntity acc,string tableName)
        {
            return GetTableColumns(acc.TargerDB, tableName);

        }
        /// <summary>
        /// 得到指定数据库，指定表的字段
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static List<string> GetTableColumns(string DB,string tableName)
        {
            string sql = @"select name from {0}..syscolumns where id=(select id from {0}..sysobjects
                     where name='{1}')";
            string cmd = String.Format(sql, DB,tableName);
            log.AppendLine(cmd);
            SqlDataReader columnReader = DBHelper.GetReader(cmd);
            if (!columnReader.HasRows) return null;
            List<string> columns = new List<string>();
            while (columnReader.Read())
            {
                columns.Add(columnReader[0].ToString().Trim());
            }
            columnReader.Close();
            columns.Sort();
            return columns;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBHelper.Connection.Close();
        }
    }
}
