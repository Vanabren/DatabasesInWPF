using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Http.Headers;
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

namespace DatabasesInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database1.accdb");
        }

        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string dataEmployeeID = "";
            string dataAssetID = "";
            string dataAssetDescription = "";

            while (read.Read())
            {
                dataEmployeeID += read[0].ToString() + "\n";
                dataAssetID += read[1].ToString() + "\n";
                dataAssetDescription += read[2].ToString() + "\n";
            }

            Employee_ID.Text = dataEmployeeID;
            Asset_Data.Text = dataAssetID;
            Asset_Description.Text = dataAssetDescription;

            cn.Close();
        }
    }
}
