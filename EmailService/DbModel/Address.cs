using System;
using System.Collections.Generic;

namespace MailsService.DbModel
{
    public partial class Address
    {
        public long Id { get; set; }
        public long IdMail { get; set; }
        public int IdType { get; set; }
        public string Address1 { get; set; }

        public virtual Mail IdMailNavigation { get; set; }
        public virtual Types IdTypeNavigation { get; set; }
    }
}
