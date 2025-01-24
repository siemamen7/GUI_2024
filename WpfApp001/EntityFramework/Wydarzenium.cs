using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Wydarzenium
{
    public int Id { get; set; }

    public int IdTypyWyd { get; set; }

    public DateTime DataICzas { get; set; }

    public int? IdPomieszczenia { get; set; }

    public string? Opis { get; set; }

    public sbyte Dis { get; set; }

    public virtual Pomieszczenium? IdPomieszczeniaNavigation { get; set; }

    public virtual TypyWyd IdTypyWydNavigation { get; set; } = null!;

    public virtual ICollection<WydPacj> WydPacjs { get; set; } = new List<WydPacj>();

    public virtual ICollection<WydPrac> WydPracs { get; set; } = new List<WydPrac>();
}
