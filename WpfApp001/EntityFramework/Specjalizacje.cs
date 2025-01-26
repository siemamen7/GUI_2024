using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Specjalizacje
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public sbyte Dis { get; set; }

    public virtual ICollection<SpecPrac> SpecPracs { get; set; } = new List<SpecPrac>();

    public virtual ICollection<TypyWyd> TypyWyds { get; set; } = new List<TypyWyd>();
}
