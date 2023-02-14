// Name: Vance Brender-A-Brandis
// Date: 2/14/23
// Description: Code for the .xaml main window functionality. 

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

        // On button click, reads all entries in the Assets table from Database1 and inserts the data into three seperate Text Blocks
        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            // The query essentially means to select data from the Assets table
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();

            // Used to read data rows from a data source
            OleDbDataReader read = cmd.ExecuteReader();
            string dataEmployeeID = "";
            string dataAssetID = "";
            string dataAssetDescription = "";

            // Reads the data from each column of the Assets table ([0][1][2]) and concatenates it into the appropriate string variable
            while (read.Read())
            {
                dataEmployeeID += read[0].ToString() + "\n";
                dataAssetID += read[1].ToString() + "\n";
                dataAssetDescription += read[2].ToString() + "\n";
            }

            Employee_ID.Text = dataEmployeeID;
            Asset_Data.Text = dataAssetID;
            Asset_Description.Text = dataAssetDescription;

            // Closes the connection to the Database after reading is finished
            cn.Close();
        }

        // On button click, reads all entries in the Employees table from Database1 and inserts the data into three seperate Text Blocks
        private void See_Employees_Click(object sender, RoutedEventArgs e)
        {
            // The query is for selecting all data from the Employees table
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();

            // Same as in the assets button code, is used to read data rows from a data source
            OleDbDataReader read = cmd.ExecuteReader();
            string dataEmployeeID = "";
            string dataEmployeeFirstName = "";
            string dataEmployeeLastName = "";

            // Reads the data from each column of the Employees table ([0][1][2]) and concatenates it to the appropriate strings
            while (read.Read())
            {
                dataEmployeeID += read[0].ToString() + "\n";
                dataEmployeeFirstName += read[1].ToString() + "\n";
                dataEmployeeLastName += read[2].ToString() + "\n";
            }

            Employee_ID1.Text = dataEmployeeID;
            Employee_First_Name.Text = dataEmployeeFirstName;
            Employee_Last_Name.Text = dataEmployeeLastName;

            // Closes the connection after the Database data reading is finished
            cn.Close();
        }
    }
}
