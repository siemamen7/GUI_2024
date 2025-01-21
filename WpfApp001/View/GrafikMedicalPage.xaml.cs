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
    public partial class GrafikMedicalPage : Page
    {
        public GrafikMedicalPage()
        {
            InitializeComponent();

            // Populate the DataGrid with example data
            TimetableGrid.ItemsSource = new List<TimetableEntry>
            {
                new TimetableEntry
                {
                    Time = "08:00 - 09:00",
                    Monday = "Check-ups",
                    Tuesday = "Surgery Prep",
                    Wednesday = "Consultations",
                    Thursday = "Vaccinations",
                    Friday = "Ward Rounds",
                    Saturday = "Emergency Duty",
                    Sunday = "Off Duty"
                },
                new TimetableEntry
                {
                    Time = "09:00 - 10:00",
                    Monday = "Team Meeting",
                    Tuesday = "Minor Surgery",
                    Wednesday = "Patient Monitoring",
                    Thursday = "Immunization",
                    Friday = "Discharge Planning",
                    Saturday = "Clinic Hours",
                    Sunday = "Off Duty"
                },
                new TimetableEntry
                {
                    Time = "10:00 - 11:00",
                    Monday = "Ward Visits",
                    Tuesday = "Outpatient Surgery",
                    Wednesday = "Therapy Sessions",
                    Thursday = "Check-ups",
                    Friday = "Patient Feedback",
                    Saturday = "Emergency Duty",
                    Sunday = "Off Duty"
                },
                new TimetableEntry
                {
                    Time = "11:00 - 12:00",
                    Monday = "Admin Work",
                    Tuesday = "Diagnostic Imaging",
                    Wednesday = "Case Study Review",
                    Thursday = "Team Meeting",
                    Friday = "Rounds",
                    Saturday = "Clinic Hours",
                    Sunday = "Off Duty"
                }
            };
        }
    }

    public class TimetableEntry
    {
        public string Time { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}
