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
    public partial class SubSysView : Form
    {
        public SubSysView()
        {
            InitializeComponent();
        }

        private void SubSysView_Load(object sender, EventArgs e)
        {
            String ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (DataContext dc = new DataContext(ConnStr))
            {
                Table<UA_Account_subEntity> ua_subs = dc.GetTable<UA_Account_subEntity>();
                var query = from sub in ua_subs
                            where sub.Iyear == "9999" && sub.Csub_id!="KJ"
                            orderby sub.Cacc_id
                            select sub;
             //   var q = query.AsEnumerable().ToList();
                uA_Account_subEntityDataGridView.DataSource = query;
            }
        }
    }
}
