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
    /// Interaction logic for DodawanieWindow.xaml
    /// </summary>
    public partial class DodawanieWindow : Window
    {
        private MainWindow MainWindow;

        public DodawanieWindow(MainWindow window)
        {
            this.MainWindow = window;
            this.DataContext = this.MainWindow.EdytowanyPilkarz;
            InitializeComponent();
        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            this.MainWindow.addItemToList();
            this.Close();
            string connectionString = "Server = localhost; Database = Pilkarze; Integrated Security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("UserInsert", connection);
            connection.Open();
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id.Text;
            adapter.SelectCommand.Parameters.Add("@Imie", SqlDbType.VarChar, (50)).Value = imie.Text;
            adapter.SelectCommand.Parameters.Add("@Nazwisko", SqlDbType.VarChar, (50)).Value = nazwisko.Text;
            adapter.SelectCommand.Parameters.Add("@Wiek", SqlDbType.VarChar, (50)).Value = wiek.Text;
            adapter.SelectCommand.Parameters.Add("@Pozycja", SqlDbType.VarChar, (50)).Value = pozycja.Text;
            adapter.SelectCommand.Parameters.Add("@Cena", SqlDbType.VarChar, (50)).Value = cena.Text;
            adapter.SelectCommand.Parameters.Add("@Klub", SqlDbType.VarChar, (50)).Value = klub.Text;
            adapter.SelectCommand.Parameters.Add("@Reprezentacja", SqlDbType.VarChar, (50)).Value = reprezentacja.Text;
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Dodano pomyślnie..");
        }
    }
}
