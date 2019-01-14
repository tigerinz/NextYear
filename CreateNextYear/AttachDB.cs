using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateNextYear
{
    public partial class AttachDB : Form
    {
        public AttachDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdSource = new FolderBrowserDialog();
            if (fbdSource.ShowDialog() == DialogResult.OK)
            {
                this.txtSource.SelectedText = fbdSource.SelectedPath;
            }
        }

        private void butAttach_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(txtSource.Text.Trim());
            FileInfo[] files= dir.GetFiles("*.mdf",SearchOption.AllDirectories);
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

                    string DBName = "UFDATA_" + file.Directory.Parent.Name.Substring(2) + "_"+file.Directory.Name;
                string MDFDir = file.DirectoryName + "\\";
                txtView.Text += "--" + DBName + Environment.NewLine;
                txtView.Text += AttachDBStr(DBName, MDFDir) + ";" + Environment.NewLine;
                txtView.Text += Environment.NewLine;
            }
        }


        private string AttachDBStr(string DBName,string MDFDir)
        {
            string sql =
                @"EXEC sp_attach_db @dbname = N'{0}', 
                    @filename1 =
                N'{1}UFDATA.MDF', 
                    @filename2 =
                N'{1}UFDATA.LDF'";
            return string.Format(sql, DBName, MDFDir);

        }
    }
}
