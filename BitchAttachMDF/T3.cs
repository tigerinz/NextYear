using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitchAttachMDF
{
    public partial class T3 : Form
    {
        public T3()
        {
            InitializeComponent();
        }

        private void butFilder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdSource = new FolderBrowserDialog();
            if (fbdSource.ShowDialog() != DialogResult.OK)
                return;
            this.txtSource.Text = fbdSource.SelectedPath;
        }

        private void butAttach_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(txtSource.Text.Trim());
            FileInfo[] files = dir.GetFiles("*.mdf", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                //    txtView.Text += "DirectoryName:" + file.DirectoryName + Environment.NewLine;
                //    txtView.Text += "Directory.Name:" + file.Directory.Name + Environment.NewLine;
                //    txtView.Text += "FullName:" + file.FullName + Environment.NewLine;
                //    txtView.Text += "Name:" + file.Name + Environment.NewLine;
                //    txtView.Text += Environment.NewLine;

                ////DirectoryName: G:\Admin\ZT001\2018
                ////Directory.Name:2018
                ////FullName: G:\Admin\ZT001\2018\UFDATA.MDF
                //// Name:UFDATA.MDF

                string DBName = "UFDATA_" + file.Directory.Parent.Name.Substring(2) + "_" + file.Directory.Name;
                string MDFDir = file.DirectoryName + "\\";
             //   txtView.Text += "--" + DBName + Environment.NewLine;
            //    txtView.Text += AttachDBStr(DBName, MDFDir) + ";" + Environment.NewLine;
            //txtView.Text += Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(txtSource.Text.Trim());
            FileInfo[] files = dir.GetFiles("*.mdf", SearchOption.AllDirectories);
            List<UfDBFile> fs = (from f in files
                     let startIndex = (f.Name.IndexOf("_") == -1 ? 0 : f.Name.IndexOf("_")) + 1
                     let s = f.Name.Substring(startIndex)
                     orderby s
                     select new UfDBFile
                     {
                         isChoosed = true,
                         DBFileName = f.Name,
                         fullDBFileName = f.FullName,
                         DBDirName=f.DirectoryName,
                         DBFileDir = f.Directory
                     }).ToList();

            dataGridView1.DataSource = fs;
        }

        private void AllCheck_Click(object sender, EventArgs e)
        {
            
            List<UfDBFile> files = dataGridView1.DataSource as List<UfDBFile>;
            if (files == null) return;

            foreach (var f in files)
            {
                f.isChoosed = true;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = files;
        }

        private void UnCheck_Click(object sender, EventArgs e)
        {
            List<UfDBFile> files = dataGridView1.DataSource as List<UfDBFile>;
            if (files == null) return;
            foreach (var f in files)
            {
                f.isChoosed = false;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = files;
        }

        private void butViewSQL_Click(object sender, EventArgs e)
        {
            ViewSQL viewSql = new ViewSQL();

            List<UfDBFile> files = dataGridView1.DataSource as List<UfDBFile>;
            if (files == null) return;
            foreach (var f in files)
            {
                string DBName = f.DBFileName;
                string MDFDir = f.DBDirName + "\\"+f.DBFileName;
                string LogDir = f.DBDirName + "\\" + f.DBFileName.Insert(f.DBFileName.IndexOf("."),"_log");

                viewSql.txtViewSQL.Text += "--" + DBName + Environment.NewLine;
                viewSql.txtViewSQL.Text += AttachDBStr(DBName, MDFDir,LogDir) + ";" + Environment.NewLine;
                viewSql.txtViewSQL.Text += "go" + Environment.NewLine;
            }
            viewSql.Show();
        }
        private string AttachDBStr(string DBName, string MDFDir)
        {
            //string sql =
            //    @"EXEC sp_attach_db @dbname = N'{0}', 
            //        @filename1 =
            //    N'{1}UFDATA.MDF', 
            //        @filename2 =
            //    N'{1}UFDATA.LDF'";
            //return string.Format(sql, DBName, MDFDir);
           return this.AttachDBStr(DBName, MDFDir + "UFDATA.MDF", MDFDir + "UFDATA.LDF");

        }
        private string AttachDBStr(string DBName, string MDFDir,string LogDir)
        {
            string sql =
                @"EXEC sp_attach_db @dbname = N'{0}', 
                    @filename1 =
                N'{1}', 
                    @filename2 =
                N'{2}'";
            return string.Format(sql, DBName, MDFDir,LogDir);
        }
    }
}
