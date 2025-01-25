using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp001.EntityFramework;

namespace WpfApp001.Storage
{
    internal class Storage
    {
        public ObservableCollection<Leczenium>? Leczenia { get; set; }

        public ObservableCollection<Leki>? Lekis { get; set; }

        public ObservableCollection<Pacjenci>? Pacjencis { get; set; }

        public ObservableCollection<Pomieszczenium>? Pomieszczenia { get; set; }

        public ObservableCollection<Pracownicy>? Pracownicies { get; set; }

        public ObservableCollection<SpecPrac>? SpecPracs { get; set; }

        public ObservableCollection<Specjalizacje>? Specjalizacjes { get; set; }

        public ObservableCollection<TypyPom>? TypyPoms { get; set; }

        public ObservableCollection<TypyWyd>? TypyWyds { get; set; }

        public ObservableCollection<Urlopy>? Urlopies { get; set; }

        public ObservableCollection<Uzytkownicy>? Uzytkownicies { get; set; }

        public ObservableCollection<WydPacj>? WydPacjs { get; set; }

        public ObservableCollection<WydPrac>? WydPracs { get; set; }

        public ObservableCollection<Wydarzenium>? Wydarzenia { get; set; }

        public ObservableCollection<Zabiegi>? Zabiegis { get; set; }


        public Storage()
        {
            using (var context = new szpitalContext())
            {
                Leczenia = new ObservableCollection<Leczenium>(context.Leczenia.ToList());
                Lekis = new ObservableCollection<Leki>(context.Lekis.ToList());
                Pacjencis = new ObservableCollection<Pacjenci>(context.Pacjencis.ToList());
                Pomieszczenia = new ObservableCollection<Pomieszczenium>(context.Pomieszczenia.ToList());
                Pracownicies = new ObservableCollection<Pracownicy>(context.Pracownicies.ToList());
                SpecPracs = new ObservableCollection<SpecPrac>(context.SpecPracs.ToList());
                Specjalizacjes = new ObservableCollection<Specjalizacje>(context.Specjalizacjes.ToList());
                TypyPoms = new ObservableCollection<TypyPom>(context.TypyPoms.ToList());
                TypyWyds = new ObservableCollection<TypyWyd>(context.TypyWyds.ToList());
                Urlopies = new ObservableCollection<Urlopy>(context.Urlopies.ToList());
                Uzytkownicies = new ObservableCollection<Uzytkownicy>(context.Uzytkownicies.ToList());
                WydPacjs = new ObservableCollection<WydPacj>(context.WydPacjs.ToList());
                WydPracs = new ObservableCollection<WydPrac>(context.WydPracs.ToList());
                Wydarzenia = new ObservableCollection<Wydarzenium>(context.Wydarzenia.ToList());
                Zabiegis = new ObservableCollection<Zabiegi>(context.Zabiegis.ToList());
            }

        }



    }
}
