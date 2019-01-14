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
using CreateNextYear.Manage;

namespace CreateNextYear.NewYear
{
    public partial class ChooseAccounts : DevExpress.XtraEditors.XtraForm
    {
        InterfaceT3 t3 = new ManagerT3();
        public ChooseAccounts()
        {
            InitializeComponent();
        }

        private void ChooseAccounts_Load(object sender, EventArgs e)
        {
                   
            if (MyAppContext.includeAccount!=null&& MyAppContext.includeAccount.Length>0)
            {
            var reslut = from c in t3.GetAccountsAndSub()
                         where MyAppContext.includeAccount.Contains(c.cAcc_Id)
                         select c;
                uA_AccountGridControl.DataSource = reslut;

            }
            else
            {
                var reslut = t3.GetAccountsAndSub();
            uA_AccountGridControl.DataSource = reslut;
            }
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount<=0)
            {
                MessageBox.Show("请选择！");
            }
            MyAppContext.accNo = new List<string>();
            foreach (int item in gridView1.GetSelectedRows())
            {
                MyAppContext.accNo.Add(gridView1.GetRowCellValue(item, "cAcc_Id").ToString());
            }
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void sbCanale_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}