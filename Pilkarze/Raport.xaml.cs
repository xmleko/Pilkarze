using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;


namespace Pilkarze
{
    /// <summary>
    /// Logika interakcji dla klasy Raport.xaml
    /// </summary>
    public partial class Raport : Window
    {
        public Raport()
        {
            InitializeComponent();
        }

        private void Button_Click_Raport(object sender, RoutedEventArgs e)
        {
          //  ReportDataSource wyswietl = new ReportDataSource("DataSet1", Wyswietl());
        }

        private DataTable Wyswietl()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server = localhost; Database = Pilkarze; Integrated Security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Pilkarze", connection);
            SqlDataReader rd = cmd.ExecuteReader();
            dataTable.Load(rd);
            return dataTable;
        }
    }
}
