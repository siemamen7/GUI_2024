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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }




        private void MoveTODO(object sender, RoutedEventArgs e)
        {
            // Navigate back to Page1
            var login = (this.FindName("LoginTextBox") as TextBox)?.Text;
            var password = (this.FindName("PasswordBox") as PasswordBox)?.Password;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Proszę wprowadzić login i hasło.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Authenticate(login, password);
        }
        private void Authenticate(string login, string password)
        {
            var users = Storage.Instance.Uzytkownicies;

            if (users == null || users.Count == 0)
            {
                MessageBox.Show("Brak użytkowników w systemie, zgłoś błąd administratorowi.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = users.FirstOrDefault(x => x.Login == login && x.Medyczny == (int)Application.Current.Properties["UserType"]);
            if (user == null)
            {
                MessageBox.Show("Użytkownik nie istnieje.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(user.Haslo != password)
            {
                MessageBox.Show("Nieprawidłowe hasło.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var associatedEmployee = Storage.Instance.Pracownicies?.FirstOrDefault(x => x.Id == user.IdPracownika);
            if (associatedEmployee != null)
            {
                Application.Current.Properties["LoggedInEmployee"] = associatedEmployee;

            }
            else
            {
                MessageBox.Show("Nie znaleziono pracownika powiązanego z użytkownikiem. Zgłoś administratorowi błąd w bazie danych.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if ((int)Application.Current.Properties["UserType"] == 1)
            {
                NavigationService.Navigate(new Uri("View/MedicalUserPanel.xaml", UriKind.Relative));
            }
            else if ((int)Application.Current.Properties["UserType"] == 0)
            {
                NavigationService.Navigate(new Uri("View/AdministrationUserPanel.xaml", UriKind.Relative));
            }

        }
    }

}
