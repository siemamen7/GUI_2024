using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;  

namespace WpfApp001.ViewModel
{
    internal class UserCardViewModel : INotifyPropertyChanged
    {
        private string _currentDateTime;
        private System.Timers.Timer _timer;  // This is now explicitly using System.Timers.Timer

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }

        public UserCardViewModel()
        {
            _timer = new System.Timers.Timer(1000); // Timer updates every second
            _timer.Elapsed += (s, e) => UpdateDateTime();
            _timer.Start();

            // Initialize the property
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            // Format as year-month-day hour:minute (yyyy-MM-dd HH:mm)
            CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
