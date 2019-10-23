using System;
using System.Collections.Generic;

namespace MailsService.DbModel
{
    public partial class Attachment
    {
        public long Id { get; set; }
        public long IdMail { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }

        public virtual Mail IdMailNavigation { get; set; }
    }
}
