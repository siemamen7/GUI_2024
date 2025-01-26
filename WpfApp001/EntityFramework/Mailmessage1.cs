using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Mailmessage1
{
    public int MailMessageId { get; set; }

    public string Sender { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int MailContactId { get; set; }

    public virtual Mailcontact1 MailContact { get; set; } = null!;
}
