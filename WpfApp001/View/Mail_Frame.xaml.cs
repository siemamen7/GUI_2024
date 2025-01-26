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
using WpfApp001.ViewModel;

namespace WpfApp001.View
{
    public partial class Mail_Frame : Page
    {
        public Mail_Frame()
        {
            InitializeComponent();
            DataContext = new MailFrameViewModel();
        }
    }
}
