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
using WpfApp001.Data;
using WpfApp001.EntityFramework;

namespace WpfApp001.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        private AdminPacjenciPage _parentPage;
        public AddPatientWindow(AdminPacjenciPage parentPage)
        {
            InitializeComponent();
            _parentPage = parentPage;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzanie wejścia
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PeselTextBox.Text) ||
                DataUrodzeniaDP.SelectedDate == null)
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
                return;
            }

            // tworzenie nowego pacjenta
            var newPatient = new Pacjenci
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Pesel = PeselTextBox.Text,
                DataUrodzenia = DateOnly.FromDateTime(DataUrodzeniaDP.SelectedDate.Value),
                DataRejestracji = DateOnly.FromDateTime(DateTime.Now),
                Dis = 0 // aktywny
            };

            Storage.Instance.UpdateElement(newPatient);

            _parentPage.dataGrid.ItemsSource = null;
            _parentPage.dataGrid.ItemsSource = Storage.Instance.Pacjencis;

            this.Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
