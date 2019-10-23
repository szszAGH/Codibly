namespace Contract
{
    public class ReceiveMail
    {
        public string Sender { get; set; }

        public string[] To { get; set; }

        public string[] Cc { get; set; }

        public string[] Bcc { get; set; }

        public string Titel { get; set; }

        public string Body { get; set; }

        public SendPriority PriorityEmail { get; set; }

        public AttachmentMail[] Attachments { get; set; }        
    }
}
