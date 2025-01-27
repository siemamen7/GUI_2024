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
using WpfApp001.EntityFramework;

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for AdminPacjenciPage.xaml
    /// </summary>
    public partial class AdminPacjenciPage : Page
    {
        public AdminPacjenciPage()
        {
            InitializeComponent();
            var filteredPatients = Storage.Instance.Pacjencis
                .Where(p => p.Dis == 0)
                .ToList();
            dataGrid.ItemsSource = filteredPatients;
        }

        private void DodajPacjentaButton_Click(object sender, RoutedEventArgs e)
        {
            var addPatientWindow = new AddPatientWindow(this);
            addPatientWindow.ShowDialog();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string firstNameFilter = FirstNameTextBox.Text.ToLower();
            string lastNameFilter = LastNameTextBox.Text.ToLower();
            string positionFilter = PeselTextBox.Text.ToLower();

            var filteredPacjenci = Storage.Instance.Pacjencis
                .Where(pacjent =>
                    (string.IsNullOrEmpty(firstNameFilter) || pacjent.Imie.ToLower().Contains(firstNameFilter)) &&
                    (string.IsNullOrEmpty(lastNameFilter) || pacjent.Nazwisko.ToLower().Contains(lastNameFilter)) &&
                    (string.IsNullOrEmpty(positionFilter) || pacjent.Pesel.ToLower().Contains(positionFilter))
                ).ToList();

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = filteredPacjenci;
        }

        private void DeletePatient(Pacjenci patient)
        {
            if (patient != null)
            {
                var result = MessageBox.Show($"Czy chcesz usunąć następującego pacjenta z bazy?\n{patient.Imie}\n{patient.Nazwisko}\n{patient.Pesel}",
                                             "Potwierdź usunięcie",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var newPatient = new Pacjenci()
                    {
                        Id = patient.Id,
                        Imie = patient.Imie,
                        Nazwisko = patient.Nazwisko,
                        Pesel = patient.Pesel,
                        DataUrodzenia = patient.DataUrodzenia,
                        DataZgonu = patient.DataZgonu,
                        Informacje = patient.Informacje,
                        Dis = 1
                    };
                    Storage.Instance.UpdateElement(patient);
                    var filteredPatients = Storage.Instance.Pacjencis
                        .Where(p => p.Dis == 0)
                        .ToList();
                    dataGrid.ItemsSource = filteredPatients;
                }
            }
        }

    }
}
