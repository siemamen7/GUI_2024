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
    public partial class PatientsBaseMedicalPage : Page
    {
        public PatientsBaseMedicalPage()
        {
            InitializeComponent();

            //// Przykładowe dane medyczne
            //var osoby = new List<Osoba>
            //{
            //    new Osoba
            //    {
            //        Imie = "Jan",
            //        Nazwisko = "Kowalski",
            //        Pesel = "12345678901",
            //        DataUrodzenia = new DateTime(1980, 5, 15),
            //        Informacje = "Choroby przewlekłe: Cukrzyca typu 2. Alergie: Brak. Przeszłość medyczna: Operacja usunięcia wyrostka robaczkowego w 2005 roku."
            //    },
            //    new Osoba
            //    {
            //        Imie = "Anna",
            //        Nazwisko = "Nowak",
            //        Pesel = "98765432109",
            //        DataUrodzenia = new DateTime(1990, 8, 22),
            //        Informacje = "Choroby przewlekłe: Astma oskrzelowa. Alergie: Pyłki roślin. Przeszłość medyczna: Leczenie na nawracające infekcje dróg oddechowych."
            //    },
            //    new Osoba
            //    {
            //        Imie = "Marek",
            //        Nazwisko = "Wiśniewski",
            //        Pesel = "19283746501",
            //        DataUrodzenia = new DateTime(1985, 11, 3),
            //        Informacje = "Choroby przewlekłe: Nadciśnienie tętnicze. Alergie: Brak. Przeszłość medyczna: Zawał serca w 2019 roku, obecnie stosuje leczenie kardiologiczne."
            //    },
            //    new Osoba
            //    {
            //        Imie = "Katarzyna",
            //        Nazwisko = "Zielińska",
            //        Pesel = "11223344556",
            //        DataUrodzenia = new DateTime(1992, 1, 10),
            //        Informacje = "Choroby przewlekłe: Zespół jelita drażliwego. Alergie: Mleko krowie. Przeszłość medyczna: Leczenie psychiatryczne z powodu depresji w 2021 roku."
            //    },
            //    new Osoba
            //    {
            //        Imie = "Piotr",
            //        Nazwisko = "Wójcik",
            //        Pesel = "56473829104",
            //        DataUrodzenia = new DateTime(1978, 12, 30),
            //        Informacje = "Choroby przewlekłe: Reumatoidalne zapalenie stawów. Alergie: Penicylina. Przeszłość medyczna: Operacja stawu biodrowego w 2015 roku."
            //    }
            //};

            //// Przypisanie danych do DataGrid
            //dataGrid.ItemsSource = osoby;
        }
    }

    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Informacje { get; set; }
    }
}
