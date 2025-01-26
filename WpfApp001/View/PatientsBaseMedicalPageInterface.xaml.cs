using System.Windows;
using System.Windows.Controls;

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for PatientsBaseMedicalPageInterface.xaml
    /// </summary>
    public partial class PatientsBaseMedicalPageInterface : Page
    {
        public PatientsBaseMedicalPageInterface()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from the text boxes
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string pesel = PeselTextBox.Text;

            // Implement search logic here
            //MessageBox.Show($"Szukaj clicked!\nImię: {firstName}\nNazwisko: {lastName}\nPESEL: {pesel}");
        }

        private void PeselTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
