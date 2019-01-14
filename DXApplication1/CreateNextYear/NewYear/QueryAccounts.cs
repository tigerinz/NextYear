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
using System.Data.Linq;
using CreateNextYear.Manage;

namespace CreateNextYear.NewYear
{
    public partial class QueryAccounts : DevExpress.XtraEditors.XtraForm
    {
        InterfaceT3 t3 = new ManagerT3();
        public QueryAccounts()
        {
            InitializeComponent();
        }

        private void QueryAccounts_Load(object sender, EventArgs e)
        {
            this.gridAccount.DataSource = t3.GetAccountsAndSub();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName=="GL"|| e.Column.FieldName == "FA" || e.Column.FieldName == "WA" || e.Column.FieldName == "IA" || e.Column.FieldName == "GX")
            {
                if (e.Value.ToString().Trim()=="1")
                {
                    e.DisplayText = "已启用";
                    
                }
                else
                {
                    e.DisplayText = "未启用";
                }
            }
        }
    }
}