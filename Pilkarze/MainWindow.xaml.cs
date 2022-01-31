using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;


namespace Pilkarze
{
    public partial class MainWindow : Window
    {
            private ObservableCollection<Pilkarz> pilkarze;
            public Pilkarz EdytowanyPilkarz;

            public MainWindow()
            {
                InitializeComponent();


                string connectionString = "Server = localhost; Database = Pilkarze; Integrated Security = SSPI";
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("selectPilkarze", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter pilkarz = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                pilkarz.Fill(dataTable);

                pilkarze = new ObservableCollection<Pilkarz>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Pilkarz osoba = new Pilkarz();
                    osoba.Id = (int)row["Id"];
                    osoba.Imie = (string)row["Imie"];
                    osoba.Nazwisko = (string)row["Nazwisko"];
                    osoba.Wiek = (string)row["Wiek"];
                    osoba.Pozycja = (string)row["Pozycja"];
                    osoba.Cena = (string)row["Cena"];
                    osoba.Klub = (string)row["Klub"];
                    osoba.Reprezentacja = (string)row["Reprezentacja"];
                    pilkarze.Add(osoba);
                }

                lvpilkarze.ItemsSource = pilkarze;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvpilkarze.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));
            }

            private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
            {
                EdytowanyPilkarz = new Pilkarz();
                DodawanieWindow DodawanieWin = new DodawanieWindow(this);
                DodawanieWin.Show();
            }

            private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
            {
                EdytowanyPilkarz = (Pilkarz)lvpilkarze.SelectedItem;
                if (EdytowanyPilkarz == null)
                    return;
                EdycjaWindow EdycjaWin = new EdycjaWindow(this);
                EdycjaWin.Show();
            }

            private void Button_Click_Usun(object sender, RoutedEventArgs e)
            {
                Pilkarz UsuwanyPilkarz = (Pilkarz)lvpilkarze.SelectedItem;
                if (UsuwanyPilkarz == null)
                    return;

                pilkarze.Remove(UsuwanyPilkarz);

            //    string connectionString = "Server = localhost; Database = Pilkarze; Integrated Security = SSPI";
           //    SqlConnection connection = new SqlConnection(connectionString);
             //   SqlDataAdapter adapter = new SqlDataAdapter("UserDelete", connection);
           //     connection.Open();
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id.Text
             //   adapter.SelectCommand.ExecuteNonQuery();
             //   connection.Close();
            //    MessageBox.Show("Usunięto pomyślnie..");
        }

            private void Button_Click_Raport(object sender, RoutedEventArgs e)
            {
                Raport raports = new Raport();
                raports.Show();
            }

        public void addItemToList()
            {
                this.pilkarze.Add(EdytowanyPilkarz);
            }
    }
}
