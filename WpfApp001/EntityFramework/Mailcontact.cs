using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Mailcontact
{
    public int MailContactId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mailmessage> Mailmessages { get; set; } = new List<Mailmessage>();
}
