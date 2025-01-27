using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace WpfApp001.View
{

    public partial class UserCard : Page, INotifyPropertyChanged
    {
        public UserCard()
        {
            InitializeComponent();

            dynamic currentUser = Application.Current.Properties["LoggedInEmployee"];
            CurrentUserName = $"{currentUser.Imie} {currentUser.Nazwisko}";
            if (currentUser.IdFunkcjiNavigation != null)
            {
                CurrentUserPosition = currentUser.IdFunkcjiNavigation.Nazwa;
            }
            else
            {
                CurrentUserPosition = "Brak przypisanej funkcji";
            }

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Update every second
            };
            timer.Tick += (s, e) => CurrentDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            timer.Start();

            // data context
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _currentUserName;
        private string _currentUserPosition;
        private string _currentDateTime;

        public string CurrentUserName
        {
            get => _currentUserName;
            set { _currentUserName = value; OnPropertyChanged(); }
        }

        public string CurrentUserPosition
        {
            get => _currentUserPosition;
            set { _currentUserPosition = value; OnPropertyChanged(); }
        }

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set { _currentDateTime = value; OnPropertyChanged(); }
        }
        
    }
}