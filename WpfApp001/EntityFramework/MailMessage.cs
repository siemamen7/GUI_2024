using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp001.EntityFramework
{
    public class MailMessage
    {
        [Key]
        public int MailMessageId { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("MailContact")]
        public int MailContactId { get; set; }

        public MailContact MailContact { get; set; }
    }
}
