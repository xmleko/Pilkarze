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
            private ObservableCollection<Osoba> osoby;
            public Osoba EdytowanaOsoba;

            public MainWindow()
            {
                InitializeComponent();


                string connectionString = "Server = localhost\\SQLEXPRESS; Database = Pilkarze; Integrated Security = SSPI";
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("selectPilkarze", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                sda.Fill(dataTable);

                osoby = new ObservableCollection<Osoba>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Osoba osoba = new Osoba();
                    osoba.Id = (int)row["Id"];
                    osoba.Imie = (string)row["Imie"];
                    osoba.Nazwisko = (string)row["Nazwisko"];
                    osoba.Wiek = (string)row["Wiek"];
                    osoba.Pozycja = (string)row["Pozycja"];
                    osoba.Cena = (string)row["Cena"];
                    osoba.Klub = (string)row["Klub"];
                    osoba.Reprezentacja = (string)row["Reprezentacja"];
                    osoby.Add(osoba);
                }

                lvOsoby.ItemsSource = osoby;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvOsoby.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));
            }

            private void Button_Click_Zapisz(object sender, RoutedEventArgs e)
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Osoba>));
                using (Stream s = File.Create("c:/msppro/osoby.xml"))
                    xs.Serialize(s, osoby);
                MessageBox.Show("Dane zostały zapisane.");
            }

            private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
            {
                EdytowanaOsoba = new Osoba();
                DodawanieWindow DodawanieWin = new DodawanieWindow(this);
                DodawanieWin.Show();
            }

            private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
            {
                EdytowanaOsoba = (Osoba)lvOsoby.SelectedItem;
                if (EdytowanaOsoba == null)
                    return;
                EdycjaWindow EdycjaWin = new EdycjaWindow(this);
                EdycjaWin.Show();
            }

            private void Button_Click_Usun(object sender, RoutedEventArgs e)
            {
                Osoba UsuwanaOsoba = (Osoba)lvOsoby.SelectedItem;
                if (UsuwanaOsoba == null)
                    return;

                osoby.Remove(UsuwanaOsoba);
            }

            public void addItemToList()
            {
                this.osoby.Add(EdytowanaOsoba);
            }

    }
}
