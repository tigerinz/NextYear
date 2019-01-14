using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BatchDBExecSql
{
    public partial class ChooseDataBase : DevExpress.XtraEditors.XtraForm
    {
        public List<string> DBs;
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
             DBs = new List<string>();
            foreach (int item in gridView1.GetSelectedRows())
            {
                DBs.Add(gridView1.GetRowCellValue(item, "DBName").ToString());
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bntExecSQL_Click(object sender, EventArgs e)
        {
            ADONetHelper.connectionStringName = "UFSystemConnectionString";
            DataTable result = ADONetHelper.GetDataSet(txtChooseDBSQL.Text.Trim());
            gridControlDB.DataSource = result;

        }

        private void ChooseDataBase_Load(object sender, EventArgs e)
        {

        }
    }
}