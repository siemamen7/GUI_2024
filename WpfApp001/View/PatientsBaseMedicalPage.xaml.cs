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
using WpfApp001.EntityFramework;

namespace WpfApp001.View
{
    public partial class PatientsBaseMedicalPage : Page
    {
        public PatientsBaseMedicalPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Storage.Instance.Pacjencis;
        }

    }
}



