﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderService.DbModel;
using SenderService.Logic;

namespace SenderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private Worker worker;

        private readonly DatabaseMailContext databaseMailContext;

        public SenderController(DatabaseMailContext context)
        {
            databaseMailContext = context;

            string host = "";
            string user = "";
            string password = "";

            worker = new Worker(host, new NetworkCredential(user, password));
        }

        [HttpPost]
        public void Post([FromQuery] ReceiveMail receiveMail)
        {
            worker.AddMail(receiveMail);
        }
    }
}
