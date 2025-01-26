using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp001.Data;

namespace WpfApp001.Utility
{
    static class Functions
    {
        /// <summary>
        /// Odświeża podany DataGrid
        /// </summary>
        /// <param name="grid"></param>
        /// DataGrid do odświeżenia
        public static void RefreshDataGrid(DataGrid grid)
        {
            var patients = Storage.Instance.Pacjencis;
            grid.ItemsSource = null;
            grid.ItemsSource = patients;
        }
    }
}
