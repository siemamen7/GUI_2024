using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Pracownicy
{
    public int Id { get; set; }

    public string? Tytul { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public DateOnly DataZatrudnienia { get; set; }

    public DateOnly? DataKoncaUmowy { get; set; }

    public byte Medyczny { get; set; }

    public byte Dis { get; set; }

    public virtual ICollection<SpecPrac> SpecPracs { get; set; } = new List<SpecPrac>();

    public virtual ICollection<Urlopy> Urlopies { get; set; } = new List<Urlopy>();

    public virtual ICollection<Uzytkownicy> Uzytkownicies { get; set; } = new List<Uzytkownicy>();

    public virtual ICollection<WydPrac> WydPracs { get; set; } = new List<WydPrac>();
}
