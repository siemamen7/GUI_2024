using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Mailmessage
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string Content { get; set; } = null!;

    public sbyte Dis { get; set; }

    public virtual Uzytkownicy Receiver { get; set; } = null!;

    public virtual Uzytkownicy Sender { get; set; } = null!;
}
