using COM;
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
    public partial class Tplus : Form
    {
        public Tplus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// choose db folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butFilder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdSource = new FolderBrowserDialog();
            if (fbdSource.ShowDialog() != DialogResult.OK)
                return;
            this.txtSource.Text = fbdSource.SelectedPath;
        }
        /// <summary>
        /// view uf db files in datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butShow_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(txtSource.Text.Trim());
            FileInfo[] files = dir.GetFiles("*.mdf", SearchOption.AllDirectories);
            List<UfDBFile> fs = (from f in files
                                 let startIndex = (f.Name.IndexOf("_") == -1 ? 0 : f.Name.IndexOf("_")) + 1
                                 let s = (f.Name.Substring(startIndex)).Replace(".mdf", "")
                                 orderby s
                                 select new UfDBFile
                                 {
                                     isChoosed = true,
                                     DBFileName = f.Name.Replace(".mdf",""),
                                     fullDBFileName = f.FullName,
                                     DBDirName = f.DirectoryName,
                                     DBFileDir = f.Directory
                                 }).ToList();

            dgvUFDBFiles.DataSource = fs;
        }
        /// <summary>
        /// check all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCheck_Click(object sender, EventArgs e)
        {
            int rows = dgvUFDBFiles.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                dgvUFDBFiles[0, i].Value = true;
            }

        }
        /// <summary>
        /// none check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnCheck_Click(object sender, EventArgs e)
        {
            int rows = dgvUFDBFiles.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                dgvUFDBFiles[0, i].Value = false;
            }

        }
  
        /// <summary>
        /// view the sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butViewSQL_Click(object sender, EventArgs e)
        {
            ViewSQL viewSql = new ViewSQL();

            List<UfDBFile> files = dgvUFDBFiles.DataSource as List<UfDBFile>;
            if (files == null) return;
            foreach (var f in files)
            {
                if (!f.isChoosed) continue;
                string DBName = f.DBFileName;
                string MDFDir = f.fullDBFileName;
                string LogDir = (f.fullDBFileName.Insert(f.fullDBFileName.IndexOf("."), "_log")).Replace(".mdf",".ldf");

                viewSql.txtViewSQL.Text += "--" + DBName + Environment.NewLine;
                viewSql.txtViewSQL.Text += AttachDBStr(DBName, MDFDir, LogDir) + ";" + Environment.NewLine;
                viewSql.txtViewSQL.Text += "go" + Environment.NewLine;
            }
            viewSql.Show();
        }

        /// <summary>
        /// execute cmd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butBatchAttach_Click(object sender, EventArgs e)
        {
            List<UfDBFile> files = dgvUFDBFiles.DataSource as List<UfDBFile>;
            if (files == null) return;
            foreach (var f in files)
            {
                if (!f.isChoosed) continue;
                string DBName = f.DBFileName;
                string MDFDir = f.fullDBFileName;
                string LogDir = (f.fullDBFileName.Insert(f.fullDBFileName.IndexOf("."), "_log")).Replace(".mdf", ".ldf");

                string cmd = AttachDBStr(DBName, MDFDir, LogDir);
                DBHelper.ExecuteCommand(cmd);
            }
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
        private string AttachDBStr(string DBName, string MDFDir, string LogDir)
        {
            string sql =
                @"EXEC sp_attach_db @dbname = N'{0}', 
                    @filename1 =
                N'{1}', 
                    @filename2 =
                N'{2}'";
            return string.Format(sql, DBName, MDFDir, LogDir);
        }
    }
    }
