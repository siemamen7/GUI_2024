using System;
using System.Windows;
using System.Windows.Navigation;

namespace WpfApp001
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Navigate to the MedicalUserPanel.xaml page
            MainFrame.Navigate(new Uri("View/StartupPanel.xaml", UriKind.Relative));
        }
    }
}