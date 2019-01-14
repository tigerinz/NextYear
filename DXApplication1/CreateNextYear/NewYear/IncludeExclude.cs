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

namespace CreateNextYear.NewYear
{
    public partial class IncludeExclude : DevExpress.XtraEditors.XtraForm
    {
        public IncludeExclude()
        {
            InitializeComponent();
        }

        private void sBtnOK_Click(object sender, EventArgs e)
        {
            if (mEditInclude.Text.Trim().Length > 0)
            {
                MyAppContext.includeAccount = mEditInclude.Text.Trim().Split(',');
            }
            if (mEditExclude.Text.Trim().Length > 0)
            {
                MyAppContext.excludeAccount = mEditExclude.Text.Trim().Split(',');
            }
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void sBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}