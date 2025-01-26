using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class WydPrac
{
    public int Id { get; set; }

    public int IdWydarzenia { get; set; }

    public int IdPracownicy { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pracownicy IdPracownicyNavigation { get; set; } = null!;

    public virtual Wydarzenium IdWydarzeniaNavigation { get; set; } = null!;
}
