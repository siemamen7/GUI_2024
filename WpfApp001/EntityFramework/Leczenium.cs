using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Leczenium
{
    public int Id { get; set; }

    public int IdPacjenci { get; set; }

    public DateOnly DataRozpoczecia { get; set; }

    public DateOnly? DataZakonczenia { get; set; }

    public string Opis { get; set; } = null!;

    public sbyte Dis { get; set; }

    public virtual Pacjenci IdPacjenciNavigation { get; set; } = null!;
}
