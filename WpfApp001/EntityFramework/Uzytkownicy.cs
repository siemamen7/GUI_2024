using System;
using System.Collections.Generic;

namespace WpfApp001.EntityFramework;

public partial class Uzytkownicy
{
    public int Id { get; set; }

    public int IdPracownika { get; set; }

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public sbyte Medyczny { get; set; }

    public byte Dis { get; set; }

    public virtual Pracownicy IdPracownikaNavigation { get; set; } = null!;

    public virtual ICollection<Mailmessage> MailmessageReceivers { get; set; } = new List<Mailmessage>();

    public virtual ICollection<Mailmessage> MailmessageSenders { get; set; } = new List<Mailmessage>();
}
