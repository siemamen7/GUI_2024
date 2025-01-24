using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Pomieszczenium
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public int IdTypyPom { get; set; }

    public string Dostepnosc { get; set; } = null!;

    public string? Komentarz { get; set; }

    public sbyte Dis { get; set; }

    public virtual TypyPom IdTypyPomNavigation { get; set; } = null!;

    public virtual ICollection<TypyWyd> TypyWyds { get; set; } = new List<TypyWyd>();

    public virtual ICollection<Wydarzenium> Wydarzenia { get; set; } = new List<Wydarzenium>();
}
