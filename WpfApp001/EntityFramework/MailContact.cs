using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp001.EntityFramework
{
    public class MailContact
    {
        [Key]
        public int MailContactId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<MailMessage> Messages { get; set; } = new List<MailMessage>();
    }
}
