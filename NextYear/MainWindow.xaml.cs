using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NextYear
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        private void CreateNewYear_Click(object sender, RoutedEventArgs e)
        {
            Account source = new Account() { AccountId = "003", Year = "2015" };
            Account target = new Account() { AccountId = "003", Year = "2016" };

            DAL query = new DAL();
            query.BatchImportTables(source, target);
            //query.ImportOneTable(source, target, "Ap_InputCode");
            //listView.Items.Add("success");
            //foreach (string item in query.Log_success)
            //{
            //    listView.Items.Add(item);

            //}
            //listView.Items.Add("fault");

            //foreach (string item in query.Log_fault)
            //{
            //    listView.Items.Add(item);

            //}
        }

        private void QueryAccounts1_Click(object sender, RoutedEventArgs e)
        {
            selectAccounts sa = new selectAccounts();
            sa.Show();
        }
    }
}
