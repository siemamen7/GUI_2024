using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class TypyWyd
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public int? IdWymaganejSpec { get; set; }

    public int? IdWymaganegoPom { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pomieszczenium? IdWymaganegoPomNavigation { get; set; }

    public virtual Specjalizacje? IdWymaganejSpecNavigation { get; set; }

    public virtual ICollection<Wydarzenium> Wydarzenia { get; set; } = new List<Wydarzenium>();
}
