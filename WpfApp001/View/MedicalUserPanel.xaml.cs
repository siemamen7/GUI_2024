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
    /// Interaction logic for MedicalUserPanel.xaml
    /// </summary>
    public partial class MedicalUserPanel : Page
    {
        public MedicalUserPanel()
        {
            InitializeComponent();
        }
        private void OnGrafikButtonClick(object sender, RoutedEventArgs e)
        {
            
            MedicalUserMainFrame.Source = new Uri("GrafikMedicalPage.xaml", UriKind.Relative);
        }

        private void OnBazaPacjentowButtonClick(object sender, RoutedEventArgs e)
        {
            
            MedicalUserMainFrame.Source = new Uri("PatientsBaseMedicalPage.xaml", UriKind.Relative);
        }

        private void OnBazaPracownikowButtonClick(object sender, RoutedEventArgs e)
        {
            
            MedicalUserMainFrame.Source = new Uri("CoWorkersMedicalPage.xaml", UriKind.Relative);
        }

        private void OnMailButtonClick(object sender, RoutedEventArgs e)
        {

            MedicalUserMainFrame.Source = new Uri("Mail_Frame.xaml", UriKind.Relative);
        }
        private void MoveTODO(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/StartupPanel.xaml", UriKind.Relative));
        }

    }
}
