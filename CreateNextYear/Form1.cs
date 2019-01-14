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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createNextYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NextYear().ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void subSysToolStripMenuItem_Click(object sender, EventArgs e)
        {
             new SubSysView().Show();

        }

        private void carryOverWAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CarryOverWA().Show();
        }

        private void carryOverGL12MonthToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AttachDB().Show();
        }

       
    }
}
