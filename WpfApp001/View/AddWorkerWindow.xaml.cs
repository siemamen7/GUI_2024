using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        public AddWorkerWindow()
        {
            InitializeComponent();
            DataContext = Storage.Instance;
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzanie wejścia
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PeselTextBox.Text) ||
                DataUrodzeniaDP.SelectedDate == null ||
                TypPracownikaCB.SelectedIndex <= -1)
            {
                MessageBox.Show("Proszę wypełnić wszystkie wymagane pola.");
                return;
            }

            string typPracownika = TypPracownikaCB.Text;

            // tworzenie nowego pracownika
            var newWorker = new Pracownicy 
            {
                Id = 0,
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Pesel = PeselTextBox.Text,
                DataUrodzenia = DateOnly.FromDateTime(DataUrodzeniaDP.SelectedDate.Value),
                Telefon = TelefonTextBox.Text,
                Email = EmailTextBox.Text,
                IdFunkcji = (int)TypPracownikaCB.SelectedValue,
                Medyczny = (byte)(typPracownika == "Admin" ? 0 : 1),
                Dis = 0 // aktywny
            };

            Storage.Instance.UpdateElement(newWorker);
            this.Close();

        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
