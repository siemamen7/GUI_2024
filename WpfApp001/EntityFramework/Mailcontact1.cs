using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Mailcontact1
{
    public int MailContactId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mailmessage1> Mailmessage1s { get; set; } = new List<Mailmessage1>();
}
