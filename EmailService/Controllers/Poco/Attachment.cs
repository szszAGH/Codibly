using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MailsService.Controllers
{
    public class AttachmentMail
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
    }
}
