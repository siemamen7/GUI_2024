using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp001.Classes
{
    internal static class Update
    {

        private static string connectionString = "Server=projekt-interfejsy.mysql.database.azure.com;Database=szpital;Uid=szczuras;Pwd=Interfejsy123;SslMode=Required;";
        public static void UpdatePacjenci()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("Connection Open!");
            }

        }
    }
}
