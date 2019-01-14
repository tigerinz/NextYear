using BatchDBExecSql.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchDBExecSql
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChooseDataBase chooseDBs = new ChooseDataBase();

            if (chooseDBs.ShowDialog() == DialogResult.OK)
            {
                ExecSQL execSql = new ExecSQL();
                execSql.DBs = chooseDBs.DBs;
                chooseDBs.Close();
                execSql.ShowDialog();

            }
        }
    }
}
