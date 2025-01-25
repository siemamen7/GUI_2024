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
    /// Interaction logic for StartupPanel.xaml
    /// </summary>
    public partial class StartupPanel : Page
    {
        public StartupPanel()
        {
            InitializeComponent();
            var storage = Storage.Instance;
        }

        private void MoveTODO(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/LoginPage.xaml", UriKind.Relative));
        }


    }

}
