using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSender
{
    public class MailModel
    {
        public List<string> MailTo { get; } = new List<string>();
        public string MailFrom { get; }
        public string Title { get; }
        public string Body { get; }

//        public MailModel()
//        {
//            MailTo = new List<string>();
//        }
//
//        public MailModel(List<string> mailTo, string mailFrom, string title = "", string body = "")
//        {
//            MailTo = mailTo;
//            MailFrom = mailFrom;
//            Title = title;
//            Body = body;
//        }

        public MailModel(string mailTo, string mailFrom, string title = "", string body = "")
        {
            SetMailTo(mailTo);
            var validation = new EmailAddressAttribute();
            if (!validation.IsValid(mailFrom))
            {
                throw new IncorrectSenderException("Incorrect sender address");
            }
            MailFrom = mailFrom;
            Title = title;
            Body = body;
        }

        private void SetMailTo(string emails)
        {
            var temp = emails.Split(';');
            var validation = new EmailAddressAttribute();
            foreach (var s in temp)
            {
                if(!validation.IsValid(s))
                    throw new IncorrectRecipientException("Incorrect recipient address");
            }
            MailTo.AddRange(temp);
            MailTo.Remove(string.Empty);
        }
    }
}
