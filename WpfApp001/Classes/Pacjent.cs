using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp001.Classes
{
    internal class Pacjent
    {
		public Pacjent(int id, string imie, string nazwisko, string pesel,
			string dataUrodzenia, string dataZgonu, string dataRejestracji)
			=> (Id, Imie, Nazwisko, Pesel, DataUrodzenia, DataZgonu, DataRejestracji)
			= (id, imie, nazwisko, pesel, dataUrodzenia, dataZgonu, dataRejestracji);

        public required int Id { get; init; }
        public required string Imie { get; init; }
        public required string Nazwisko { get; init; }
        public required string Pesel { get; init; }
        public required string DataUrodzenia { get; init; }
        public required string DataZgonu { get; init; }
        public required string DataRejestracji { get; init; }

    }
}
