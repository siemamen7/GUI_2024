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

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for AdministrationUserPanel.xaml
    /// </summary>
    public partial class AdministrationUserPanel : Page
    {
        public AdministrationUserPanel()
        {
            InitializeComponent();
        }

        private void GoToGrafikiButton_Click(object sender, RoutedEventArgs e)
        {

            AdminUserMainFrame.Source = new Uri("AdminGrafikiPage.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = new Uri("AdminInterfaceGrafiki.xaml", UriKind.Relative);
        }

        private void GoToPomieszczeniaButton_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMainFrame.Source = new Uri("AdminPomieszczeniaPage.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = new Uri("AdminInterfacePomieszczenia.xaml", UriKind.Relative);

        }

        private void GoToPracownicyButton_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMainFrame.Source = new Uri("AdminPracownicyPage.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = new Uri("AdminInterfacePracownicy.xaml", UriKind.Relative);

        }

        private void GoToPacjenciButton_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMainFrame.Source = new Uri("AdminPacjenciPage.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = new Uri("AdminInterfacePacjenci.xaml", UriKind.Relative);

        }

        private void GoToUrlopyButton_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMainFrame.Source = new Uri("AdminUrlopyPage.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = new Uri("AdminInterfaceUrlopy.xaml", UriKind.Relative);

        }

        private void GoToMailButton_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMainFrame.Source = new Uri("Mail_Frame.xaml", UriKind.Relative);
            AdminUserBarFrame.Source = null;

        }
    }
}
