using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderService.Logic;

namespace SenderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private Worker worker;


        public SenderController()
        {
            string host = "";
            string user = "";
            string password = "";

            worker = new Worker(host, new NetworkCredential(user, password));
        }
        


        //[HttpPost]
        //public void Post([FromQuery] string EmailTo, [FromQuery] string EmailTo, [FromQuery] string EmailCc, [FromQuery] string Titel, [FromQuery] string Body)
        //{

        //   // worker.AddMail(EmailTo,  EmailCc, [FromQuery] string Titel, [FromQuery] string Body)

        //}


        //// GET: api/Sender
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Sender/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Sender
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Sender/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
