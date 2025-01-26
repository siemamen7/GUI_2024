using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows; 
using WpfApp001.Data;
using WpfApp001.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WpfApp001.ViewModel
{
    internal class UserCardViewModel : INotifyPropertyChanged
    {
        private string _currentDateTime;
        private string _currentUserName;
        private string _currentUserPosition;
        private System.Timers.Timer _timer;

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUserName
        {
            get => _currentUserName;
            set
            {
                _currentUserName = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUserPosition
        {
            get => _currentUserPosition;
            set
            {
                _currentUserPosition = value;
                OnPropertyChanged();
            }
        }

        public UserCardViewModel()
        {
            _timer = new System.Timers.Timer(1000); // Timer updates every second
            _timer.Elapsed += (s, e) => UpdateDateTime();
            _timer.Start();

            // Initialize the properties
            UpdateDateTime();
            InitializeUserInfo();
        }

        private void UpdateDateTime()
        {
            // Format as year-month-day hour:minute (yyyy-MM-dd HH:mm)
            CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        private void InitializeUserInfo()
        {

            if (Application.Current.Properties["LoggedInEmployee"] is Pracownicy loggedInEmployee)
            {

                var storage = Storage.Instance;
                var currentUser = storage.Uzytkownicies?.FirstOrDefault(u => u.IdPracownika == loggedInEmployee.Id);

                if (currentUser != null)
                {

                    CurrentUserName = $"{loggedInEmployee.Imie} {loggedInEmployee.Nazwisko}";

                    var specPrac = storage.SpecPracs?.FirstOrDefault(sp => sp.IdPracownicy == loggedInEmployee.Id);

                    if (specPrac != null)
                    {
                        var specjalizacja = storage.Specjalizacjes?.FirstOrDefault(s => s.Id == specPrac.IdSpecjalizacje);

                        if (specjalizacja != null)
                        {
                            // Set the user's position (specialization name)
                            CurrentUserPosition = specjalizacja.Nazwa;
                        }
                        else
                        {
                            // Handle the case where the specialization is not found
                            CurrentUserPosition = "Unknown Position";
                        }
                    }
                    else
                    {
                        // Handle the case where no specialization is found for the employee
                        CurrentUserPosition = "Unknown Position";
                    }
                }
                else
                {
                    // Handle the case where the associated Uzytkownicy entity is not found
                    CurrentUserName = "Unknown User";
                    CurrentUserPosition = "Unknown Position";
                }
            }
            else
            {
                // Handle the case where no user is logged in
                CurrentUserName = "Unknown User";
                CurrentUserPosition = "Unknown Position";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}