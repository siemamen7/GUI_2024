using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Zabiegi
{
    public int Id { get; set; }

    public int IdPacjenci { get; set; }

    public string Nazwa { get; set; } = null!;

    public DateOnly DataZabiegu { get; set; }

    public string? Opis { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pacjenci IdPacjenciNavigation { get; set; } = null!;
}
