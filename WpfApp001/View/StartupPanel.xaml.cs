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
//using WpfApp001.Classes;

namespace WpfApp001.View
{
    /// <summary>
    /// Interaction logic for StartupPanel.xaml
    /// </summary>
    public partial class StartupPanel : Page
    {
        public StartupPanel()
        {
            InitializeComponent();
            var storage = Storage.Instance;
        }

        private void MoveToUser(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["UserType"] = 1;
            NavigationService.Navigate(new Uri("View/LoginPage.xaml", UriKind.Relative));
            
        }
        private void MoveToAdmin(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["UserType"] = 0;
            NavigationService.Navigate(new Uri("View/LoginPage.xaml", UriKind.Relative));
        }


    }

}
