using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class WydPacj
{
    public int Id { get; set; }

    public int IdPacjenci { get; set; }

    public int IdWydarzenia { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pacjenci IdPacjenciNavigation { get; set; } = null!;

    public virtual Wydarzenium IdWydarzeniaNavigation { get; set; } = null!;
}
