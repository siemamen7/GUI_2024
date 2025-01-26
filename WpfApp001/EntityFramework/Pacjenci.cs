using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Pacjenci
{
    public int Id { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public DateOnly? DataZgonu { get; set; }

    public DateOnly DataRejestracji { get; set; }

    public string? Informacje { get; set; }

    public sbyte Dis { get; set; }

    public virtual ICollection<WydPacj> WydPacjs { get; set; } = new List<WydPacj>();
}
