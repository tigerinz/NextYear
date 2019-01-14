using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateNextYear
{
    public partial class CarryOverWA : Form
    {
        String ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public CarryOverWA()
        {
            InitializeComponent();
        }

        private void createNextYear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("start");

            var choosed = from acc in getAccountsListFromDataGridView()
                          where acc.IsChoose == true
                          select acc;
            CarryOverWAServer carryOverWASer = new CarryOverWAServer();
            carryOverWASer.CarryOverWA(choosed.ToList<UA_AccountEntity>(), (int)numYear.Value);
            MessageBox.Show("----------------over---------");
        }

        private void CarryOverWA_Load(object sender, EventArgs e)
        {
            using (DataContext dc = new DataContext(ConnStr))
            {
                dc.ObjectTrackingEnabled = false;

                var account = dc.GetTable<UA_AccountEntity>();
                var q = from acc in account
                        from sub in acc.Ua_Account_subs
                        where acc.Cacc_id == sub.Cacc_id && sub.Csub_id=="WA" && sub.Iyear=="9999"
                        orderby acc.Cacc_id
                        select acc;
                uA_AccountEntityDataGridView.DataSource = q.AsEnumerable().ToList();
            }
            numYear.Value = DateTime.Now.Year;
        }

        private List<UA_AccountEntity> getAccountsListFromDataGridView()
        {
            return uA_AccountEntityDataGridView.DataSource as List<UA_AccountEntity>;
        }

        private void AllCheck_Click(object sender, EventArgs e)
        {
            List<UA_AccountEntity> accounts = getAccountsListFromDataGridView();
            foreach (var account in accounts)
            {
                account.IsChoose = true;
            }
            uA_AccountEntityDataGridView.DataSource = null;
            uA_AccountEntityDataGridView.DataSource = accounts;
        }

        private void UnCheck_Click(object sender, EventArgs e)
        {
            List<UA_AccountEntity> accounts = getAccountsListFromDataGridView();
            foreach (var account in getAccountsListFromDataGridView())
            {
                account.IsChoose = false;
            }
            uA_AccountEntityDataGridView.DataSource = null;
            uA_AccountEntityDataGridView.DataSource = accounts;
        }
    }
}
