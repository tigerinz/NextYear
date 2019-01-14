using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BatchDBExecSql.Tool
{
    public partial class ExecSQL : DevExpress.XtraEditors.XtraForm
    {
        public List<string> DBs;
        public ExecSQL()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string sql = "";

            FileStream fs = new FileStream(txtFilePath1.Text, FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr = new StreamReader(fs);
                    string str = sr.ReadToEnd();
                    
                    FileStream fs2 = new FileStream(txtFilePath2.Text, FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr2 = new StreamReader(fs2);
                    string str2 = sr2.ReadToEnd();

                    fs.Dispose();
                    sr.Dispose();
                    fs2.Dispose();
                    sr2.Dispose();
              //  sql = string.Format(txtSql.Text, item);
                    sql = sql + str+str2;
                    string[] sqls = sql.Split('$');

            foreach (var item in DBs)
            {

                string connectionstr = string.Format("Data Source=server;Initial Catalog={0};User ID=sa;Password=sa;", item);
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {


                  //  Regex r = new Regex("/ngo/n",RegexOptions.IgnoreCase);
                    //sql = sql.Replace(" go ", "!");
                    //sql = sql.Replace(" GO ", "!");
                  //  sql = r.Replace(sql, "!");
                   // MessageBox.Show(sql);

                    conn.Open();
                    foreach (string s in sqls)
                    {
                      //  MessageBox.Show(s);

                        using (SqlCommand cmd = new SqlCommand(s, conn))
                        {
                         
                            cmd.CommandTimeout = 180;
                            cmd.ExecuteNonQuery();
                        }
                    }


                }
            }
            MessageBox.Show("全部完成！");
        }

        private void txtSql_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
               // string file = 
                txtFilePath1.Text = fileDialog.FileName;
              //  MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOutFile_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in DBs)
            {
               // StringBuilder sb = new StringBuilder();
                string sql = string.Format(txtSql.Text, item);

                FileStream fs = new FileStream(txtFilePath1.Text, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader sr = new StreamReader(fs);
                string str = sr.ReadToEnd();
                sql = sql + str;
                sql = sql.Replace("go", ";");
                sql = sql.Replace("GO", ";");
                sb.AppendLine(sql);
            }
            StreamWriter sw = new StreamWriter(@"/sqlFile");
          //  sw.Write()
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // string file = 
                txtFilePath2.Text = fileDialog.FileName;
                //  MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}