using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Funkcje
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public sbyte Dis { get; set; }

    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();

    public virtual ICollection<TypyWyd> TypyWyds { get; set; } = new List<TypyWyd>();
}
