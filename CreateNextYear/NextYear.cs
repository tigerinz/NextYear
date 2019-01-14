using COM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace CreateNextYear
{
    public partial class NextYear : Form
    {
       String ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public NextYear()
        {
            InitializeComponent();
        }

        private void NextYear_Load(object sender, EventArgs e)
        {
            using (DataContext dc = new DataContext(ConnStr))
            {
                dc.ObjectTrackingEnabled = false;

                var account = dc.GetTable<UA_AccountEntity>();
                var q = from acc in account
                        orderby acc.Cacc_id
                        select acc;
                uA_AccountEntityDataGridView.DataSource = q.AsEnumerable().ToList();
            }
            numYear.Value = DateTime.Now.Year;
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

        private void create_Click(object sender, EventArgs e)
        {
            MessageBox.Show("start");
            
            var choosed = from acc in getAccountsListFromDataGridView()
                          where acc.IsChoose == true
                          select acc;
            CreateNextYearService createNewYearService = new CreateNextYearService();
            createNewYearService.CreateNextYear(choosed.ToList< UA_AccountEntity>(), (int)numYear.Value);
            MessageBox.Show("over");
        }

        private List<UA_AccountEntity> getAccountsListFromDataGridView()
        {
           return uA_AccountEntityDataGridView.DataSource as List<UA_AccountEntity>;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("start");
            string ret = "";
            CreateNextYearService cnys = new CreateNextYearService();

            var choosed = from acc in getAccountsListFromDataGridView()
                          where acc.IsChoose == true
                          select acc;
            foreach (var acc in choosed)
            {
                int count = (int)DBHelper.GetScalar("SELECT  count(*) FROM UFDATA_" + acc.Cacc_id + "_2015..SysObjects WHERE name ='gl_mend'");
                if (count <= 0)
                {
                }
                ret += "UPDATE UFDATA_" + acc.Cacc_id + "_2015..gl_mend SET bflag=1 WHERE iperiod>1"+Environment.NewLine;
                DBHelper.ExecuteCommand("UPDATE UFDATA_"+acc.Cacc_id+"_2015..gl_mend SET bflag=1 WHERE iperiod>1");
            }
            cnys.WriterLogToDisk(Environment.CurrentDirectory+"\\CarryOverGL12Month.txt", ret);
            MessageBox.Show("--------over--------------");
        }
    }
}
