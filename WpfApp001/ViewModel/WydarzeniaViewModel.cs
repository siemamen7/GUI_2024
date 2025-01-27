using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp001.Data;
using WpfApp001.EntityFramework;

namespace WpfApp001.ViewModel
{
    public class WydarzeniaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Wydarzenium>? AllEvents { get; set; }
        public ObservableCollection<Wydarzenium>? FilteredEvents { get; set; }
        public ObservableCollection<WeekItem> Weeks { get; set; }


        public ICommand SearchCommand { get; }

        private WeekItem _selectedWeek;
        private string _selectedDay;
        private string _selectedHour;

        public WeekItem SelectedWeek
        {
            get => _selectedWeek;
            set
            {
                _selectedWeek = value;
                OnPropertyChanged(nameof(SelectedWeek));
                ApplyFilters();
            }
        }

        public string SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged(nameof(SelectedDay));
                ApplyFilters();
            }
        }

        public string SelectedHour
        {
            get => _selectedHour;
            set
            {
                _selectedHour = value;
                OnPropertyChanged(nameof(SelectedHour));
                ApplyFilters();
            }
        }

        public WydarzeniaViewModel()
        {
            AllEvents = new ObservableCollection<Wydarzenium>(Storage.Instance.Wydarzenia);
            FilteredEvents = new ObservableCollection<Wydarzenium>(AllEvents);

            SearchCommand = new RelayCommand(_ => ApplyFilters());

            Weeks = new ObservableCollection<WeekItem>
            {
            new WeekItem { DisplayText = "1 - 7.12.2024", StartDate = new DateTime(2024, 12, 1) },
            new WeekItem { DisplayText = "8 - 14.12.2024", StartDate = new DateTime(2024, 12, 8) },
            new WeekItem { DisplayText = "15 - 21.12.2024", StartDate = new DateTime(2024, 12, 15) },
            new WeekItem { DisplayText = "22 - 28.12.2024", StartDate = new DateTime(2024, 12, 22) },
            new WeekItem { DisplayText = "29 - 4.01.2025", StartDate = new DateTime(2024, 12, 29) },
            new WeekItem { DisplayText = "5 - 11.01.2025", StartDate = new DateTime(2025, 1, 5) }
            };
        }

        private void ApplyFilters()
        {
            var filtered = AllEvents.Where(e =>
            {
                bool matchesWeek = SelectedWeek == null ||
                    (e.DataICzas >= SelectedWeek.StartDate && e.DataICzas < SelectedWeek.StartDate.AddDays(7));
                bool matchesDay = string.IsNullOrEmpty(SelectedDay) || MatchDay(e, SelectedDay);
                bool matchesHour = string.IsNullOrEmpty(SelectedHour) || MatchHour(e, SelectedHour);

                return matchesWeek && matchesDay && matchesHour;
            });

            FilteredEvents.Clear();
            foreach (var ev in filtered)
            {
                FilteredEvents.Add(ev);
            }
        }

        private bool MatchWeek(Wydarzenium ev, string week)
        {
            
            return true;
        }
        private bool MatchDay(Wydarzenium ev, string day)
        {
            return ev.DataICzas.ToString("dddd").Equals(day, StringComparison.InvariantCultureIgnoreCase);
        }
        private bool MatchHour(Wydarzenium ev, string hour)
        {
            return ev.DataICzas.ToString("HH:mm").Equals(hour);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
