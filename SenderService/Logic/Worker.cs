using Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SenderService.Logic
{
    public class Worker
    {
        private ConcurrentQueue<ReceiveMail> mailQueue = new ConcurrentQueue<ReceiveMail>();

        private SmtpClient client;

        public Worker(string host, NetworkCredential networkCredential)
        {
            client = new SmtpClient(host);
            client.UseDefaultCredentials = false;
            client.Credentials = networkCredential;

            //mailQueue.
        }

        public void AddMail(ReceiveMail receiveMail)
        {
            mailQueue.Enqueue(receiveMail);
        }

        //public void AddMail(long id)
        //{
        //    mailIdQueue.Enqueue(id);
        //}

        //public void AddMail(string EmailFrom, string EmailTo, string EmailCc, string Subject, string Body)
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress(EmailFrom);
        //    mailMessage.To.Add(EmailTo);
        //    mailMessage.CC.Add(EmailCc);

        //    mailMessage.Body = Body;
        //    mailMessage.Subject = Subject;

        //    //Attachment tt = new Attachment()

        //    //mailMessage.Attachments.Add( )

        //    mailQueue.Enqueue(mailMessage);
        //}

        private void Run()
        {



            new NotImplementedException();






        }

    }
}
