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
            this.DataContext = this.MainWindow.EdytowanaOsoba;
            InitializeComponent();
        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            this.MainWindow.addItemToList();
            this.Close();
        }
    }
}
