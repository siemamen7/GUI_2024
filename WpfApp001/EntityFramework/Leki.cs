using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Leki
{
    public int Id { get; set; }

    public int IdLeczenia { get; set; }

    public string Nazwa { get; set; } = null!;

    public sbyte Dis { get; set; }
}
