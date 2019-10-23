using System;
using System.Collections.Generic;

namespace MailsService.DbModel
{
    public partial class Priority
    {
        public Priority()
        {
            Mail = new HashSet<Mail>();
        }

        public int IdPriority { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Mail> Mail { get; set; }
    }
}
