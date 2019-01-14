using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CreateNextYear.Tool
{
    public partial class ChooseDataBase : DevExpress.XtraEditors.XtraForm
    {
        public ChooseDataBase()
        {
            InitializeComponent();
        }

        private void gridControlDB_Click(object sender, EventArgs e)
        {

        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                MessageBox.Show("请选择！");
            }
            List<string> dbs = new List<string>();
            foreach (int item in gridView1.GetSelectedRows())
            {
                dbs.Add(gridView1.GetRowCellValue(item, "DBName").ToString());
            }
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bntExecSQL_Click(object sender, EventArgs e)
        {
            DataTable result = ADONetHelper.GetDataSet(txtChooseDBSQL.Text.Trim());
            gridControlDB.DataSource = result;

        }
    }
}