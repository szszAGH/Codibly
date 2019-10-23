using System;
using System.Collections.Generic;

namespace MailsService.DbModel
{
    public partial class Mail
    {
        public Mail()
        {
            Address = new HashSet<Address>();
            Attachment = new HashSet<Attachment>();
        }

        public long IdMail { get; set; }
        public int IdPriority { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }

        public virtual Priority IdPriorityNavigation { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
