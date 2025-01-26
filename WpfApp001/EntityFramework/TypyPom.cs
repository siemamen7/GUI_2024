using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class TypyPom
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public sbyte Dis { get; set; }

    public virtual ICollection<Pomieszczenium> Pomieszczenia { get; set; } = new List<Pomieszczenium>();
}
