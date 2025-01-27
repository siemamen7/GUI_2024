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
using WpfApp001.Data;

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for AdminPomieszczeniaPage.xaml
    /// </summary>
    public partial class AdminPomieszczeniaPage : Page
    {
        public AdminPomieszczeniaPage()
        {
            InitializeComponent();
            PomieszczeniaDataGrid.ItemsSource = Storage.Instance.Pomieszczenia;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string roomNameFilter = FirstNameTextBox.Text.ToLower();
            string typeFilter = ((ComboBoxItem)TypCB.SelectedItem)?.Content.ToString().ToLower();
            string dostepnoscFilter = ((ComboBoxItem)DostepnoscCB.SelectedItem)?.Content.ToString().ToLower();

            var filteredRooms = Storage.Instance.Pomieszczenia
                .Where(room =>
                    (string.IsNullOrEmpty(roomNameFilter) || room.Nazwa.ToLower().Contains(roomNameFilter)) &&
                    (string.IsNullOrEmpty(typeFilter) || room.IdTypyPomNavigation.Nazwa.ToLower().Contains(typeFilter)) &&
                    (string.IsNullOrEmpty(dostepnoscFilter) || room.Dostepnosc.ToLower().Contains(dostepnoscFilter))
                ).ToList();

            PomieszczeniaDataGrid.ItemsSource = null;
            PomieszczeniaDataGrid.ItemsSource = filteredRooms;
        }
    }
}
