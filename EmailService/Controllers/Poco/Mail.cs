using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailsService.Controllers
{
    public class Mail
    {
        public string Sender { get; set; }

        public string[] To { get; set; }

        public string[] Cc { get; set; }

        public string[] Bcc { get; set; }

        public string Titel { get; set; }

        public string Body { get; set; }

        public Priority PriorityEmail { get; set; }

        public AttachmentMail[] Attachments { get; set; }        
    }
}
