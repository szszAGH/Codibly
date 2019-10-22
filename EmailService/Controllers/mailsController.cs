using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailsService.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mailsController : ControllerBase
    {
        //private readonly ServicesContext servicesContext;

        //public mailsController(ServicesContext context)
        //{
        //    servicesContext = context;
        //}

        //As a user, I can create a new email without sending it
        //As a user, I can define one or many recipients
        //As a user, I can define the sender  
        //(OPTIONAL) As a user, I can define the priority of the email
        //(OPTIONAL) As a user, I can add attachments to the email
        [HttpPost]
        public void Post(Mail mail)
        {

        }

        //As a user, I can check the status of the email(pending, sent)
        [HttpGet("status/{id}")]
        public Status GetStatus(long id)
        {
            return new Status();
        }

        //As a user, I can see details of the email
        [HttpGet("details/{id}")]
        public Mail GetDetails(long id)
        {
            return new Mail();
            
        }

        //As a user, I can see all email in the system
        [HttpGet]
        public IEnumerable<Mail> Get()
        {
            return new Mail[] { new Mail(), new Mail() };
        }

        //As a user, I can send all pending email using company SMTP account
        [HttpPut]
        public void Put()
        {

        }
    }
}
