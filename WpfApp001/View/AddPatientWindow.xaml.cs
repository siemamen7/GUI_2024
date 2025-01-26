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
        public AddPatientWindow()
        {
            InitializeComponent();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            // Validate user input (e.g., check if fields are not empty)
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PeselTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Create a new patient object using the input values
            var newPatient = new Pacjenci
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Pesel = PeselTextBox.Text,
                DataUrodzenia = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)), // Example default
                DataRejestracji = DateOnly.FromDateTime(DateTime.Now),
                Dis = 0 // Ensure the patient is active
            };

            // Add the new patient to the database
            Storage.Instance.UpdateElement(newPatient);

            // Clear the input fields after adding
            ImieTextBox.Text = "";
            NazwiskoTextBox.Text = "";
            PeselTextBox.Text = "";

            // Refresh the DataGrid
            //RefreshDataGrid();
        }
    }
}
