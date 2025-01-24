using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class SpecPrac
{
    public int Id { get; set; }

    public int IdPracownicy { get; set; }

    public int IdSpecjalizacje { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pracownicy IdPracownicyNavigation { get; set; } = null!;

    public virtual Specjalizacje IdSpecjalizacjeNavigation { get; set; } = null!;
}
