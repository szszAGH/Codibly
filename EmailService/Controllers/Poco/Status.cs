using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailsService.Controllers
{
    public class Status
    {
        public long Id { get; set; }
        public MailStatus status { get; set; }
    }
}
