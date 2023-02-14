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
        // creates a connection variable for later use in connecting to a database
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();

            // creates a new connection to the Database1.accdb database
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database1.accdb");
        }

        // On button click, 
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

        private void See_Employees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string dataEmployeeID = "";
            string dataEmployeeFirstName = "";
            string dataEmployeeLastName = "";

            while (read.Read())
            {
                dataEmployeeID += read[0].ToString() + "\n";
                dataEmployeeFirstName += read[1].ToString() + "\n";
                dataEmployeeLastName += read[2].ToString() + "\n";
            }

            Employee_ID1.Text = dataEmployeeID;
            Employee_First_Name.Text = dataEmployeeFirstName;
            Employee_Last_Name.Text = dataEmployeeLastName;

            cn.Close();
        }
    }
}
