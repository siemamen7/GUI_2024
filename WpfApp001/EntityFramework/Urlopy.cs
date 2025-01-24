using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Urlopy
{
    public int Id { get; set; }

    public int IdPracownicy { get; set; }

    public string TypUrlopu { get; set; } = null!;

    public DateOnly DataRozpoczecia { get; set; }

    public DateOnly? DataZakonczenia { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pracownicy IdPracownicyNavigation { get; set; } = null!;
}
