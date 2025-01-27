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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp001.Data;
using WpfApp001.EntityFramework;
using WpfApp001.ViewModel;

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for AdminPracownicyPage.xaml
    /// </summary>
    public partial class AdminPracownicyPage : Page
    {
        public AdminPracownicyPage()
        {
            InitializeComponent();
            EmployeesDataGrid.ItemsSource = Storage.Instance.Pracownicies;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string firstNameFilter = FirstNameTextBox.Text.ToLower();
            string lastNameFilter = LastNameTextBox.Text.ToLower();
            string positionFilter = ((ComboBoxItem)PositionComboBox.SelectedItem)?.Content.ToString().ToLower();

            var filteredEmployees = Storage.Instance.Pracownicies
                .Where(employee =>
                    (string.IsNullOrEmpty(firstNameFilter) || employee.Imie.ToLower().Contains(firstNameFilter)) &&
                    (string.IsNullOrEmpty(lastNameFilter) || employee.Nazwisko.ToLower().Contains(lastNameFilter)) &&
                    (string.IsNullOrEmpty(positionFilter) || employee.IdFunkcjiNavigation.Nazwa.ToLower().Contains(positionFilter))
                ).ToList();

            EmployeesDataGrid.ItemsSource = null;
            EmployeesDataGrid.ItemsSource = filteredEmployees;
        }

    }
}
