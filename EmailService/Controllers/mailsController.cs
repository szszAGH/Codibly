using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract;
using MailsService.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MailsService.Clients.Sender.Api;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mailsController : ControllerBase
    {
        private readonly DatabaseMailContext databaseMailContext;

        public mailsController(DatabaseMailContext context)
        {
            databaseMailContext = context;
        }

        //As a user, I can create a new email without sending it
        //As a user, I can define one or many recipients
        //As a user, I can define the sender  
        //(OPTIONAL) As a user, I can define the priority of the email
        //(OPTIONAL) As a user, I can add attachments to the email
        [HttpPost]
        public void Post(ReceiveMail mail)
        {
            Mail tempMail = new Mail();
            tempMail.Titel = mail.Titel;
            tempMail.Body = mail.Body;
            tempMail.IdPriority = (int)mail.PriorityEmail;
            databaseMailContext.Mail.Add(tempMail);

            Address sender = new Address();
            sender.IdMail = tempMail.IdMail;
            sender.Address1 = mail.Sender;
            sender.IdType = (int)SendTypes.Sender;
            databaseMailContext.Address.Add(sender);

            if (mail.To != null)
            {
                foreach (var item in mail.To)
                {
                    Address To = new Address();
                    To.IdMail = tempMail.IdMail;
                    To.Address1 = item;
                    To.IdType = (int)SendTypes.To;
                    databaseMailContext.Address.Add(To);
                }
            }

            if (mail.Cc != null)
            {
                foreach (var item in mail.Cc)
                {
                    Address Cc = new Address();
                    Cc.IdMail = tempMail.IdMail;
                    Cc.Address1 = item;
                    Cc.IdType = (int)SendTypes.Cc;
                    databaseMailContext.Address.Add(Cc);
                }
            }

            if (mail.Bcc != null)
            {
                foreach (var item in mail.Bcc)
                {
                    Address Bcc = new Address();
                    Bcc.IdMail = tempMail.IdMail;
                    Bcc.Address1 = item;
                    Bcc.IdType = (int)SendTypes.Bcc;
                    databaseMailContext.Address.Add(Bcc);
                }
            }

            if (mail.Attachments != null)
            {
                foreach (var item in mail.Attachments)
                {
                    Attachment attachment = new Attachment();
                    attachment.IdMail = tempMail.IdMail;
                    attachment.Name = item.Name;
                    attachment.Content = item.Content;

                    databaseMailContext.Attachment.Add(attachment);
                }
            }

            Status status = new Status();
            status.IdMail = tempMail.IdMail;
            status.Status1 = (int)MailStatus.Pending;

            databaseMailContext.SaveChanges();
        }

        //As a user, I can check the status of the email(pending, sent)
        [HttpGet("status/{id}")]
        public SendStatus GetStatus(long id)
        {
            Status tempResult = null;
            SendStatus status = new SendStatus();

            tempResult = databaseMailContext.Status.First<Status>(s => s.IdMail == id);

            status.Id = tempResult.IdMail;
            status.status = (MailStatus)tempResult.Status1;

            return status;
        }

        //As a user, I can see details of the email
        [HttpGet("details/{id}")]
        public ReceiveMail GetDetails(long id)
        {
            ReceiveMail result;
            Mail mail = databaseMailContext.Mail.First<Mail>(m => m.IdMail == id);

            result = fillReceiveMail(mail);

            return result;
        }

        private ReceiveMail fillReceiveMail(Mail mail)
        {
            ReceiveMail receiveMail = new ReceiveMail();
            string sender = string.Empty;
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            List<AttachmentMail> attachmentMail = new List<AttachmentMail>();

            IQueryable<Address> address = databaseMailContext.Address.Where(a => a.IdMail == mail.IdMail);
            foreach (var item in address)
            {
                switch (item.IdType)
                {
                    case 0: //sender adress
                        sender = item.Address1;
                        break;
                    case 1: //to adress
                        to.Add(item.Address1);
                        break;
                    case 2: //cc adress
                        cc.Add(item.Address1);
                        break;
                    case 3: //bcc adress
                        bcc.Add(item.Address1);
                        break;
                }
            }

            IQueryable<Attachment> attachments = databaseMailContext.Attachment.Where(aa => aa.IdMail == mail.IdMail);

            foreach (var item in attachments)
            {
                AttachmentMail tempAttachment = new AttachmentMail();
                tempAttachment.Name = item.Name;
                tempAttachment.Content = item.Content;

                attachmentMail.Add(tempAttachment);
            }

            receiveMail.Sender = sender;
            receiveMail.Titel = mail.Titel;
            receiveMail.Body = mail.Body;

            receiveMail.To = to.ToArray();
            receiveMail.Cc = cc.ToArray();
            receiveMail.Bcc = bcc.ToArray();
            receiveMail.Attachments = attachmentMail.ToArray();

            return receiveMail;
        }

        //As a user, I can see all email in the system
        [HttpGet]
        public IEnumerable<ReceiveMail> Get()
        {
            List<ReceiveMail> result = new List<ReceiveMail>();

            IQueryable<Mail> mails = databaseMailContext.Mail;

            foreach (var item in mails)
                result.Add(fillReceiveMail(item));

            return result.ToArray();
        }

        //As a user, I can send all pending email using company SMTP account
        [HttpPut]
        public void Put()
        {
            IQueryable<Status> statuses = databaseMailContext.Status.Where(s => s.Status1 == (int)MailStatus.Pending);

            foreach (var item in statuses)
            {
                Mail mail = databaseMailContext.Mail.SingleOrDefault(m => m.IdMail == item.IdMail);
                ReceiveMail temp = fillReceiveMail(mail);

                SenderApi senderApi = new SenderApi("http://127.0.0.1:5001");
                senderApi.SenderPost(temp.Sender, new List<string>(temp.To), new List<string>(temp.Cc), new List<string>(temp.Bcc), temp.Titel, temp.Body, (int)temp.PriorityEmail);               
            }
        }
    }
}
