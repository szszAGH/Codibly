using System;
using System.Collections.Generic;

namespace MailsService.DbModel
{
    public partial class Types
    {
        public Types()
        {
            Address = new HashSet<Address>();
        }

        public int IdType { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
