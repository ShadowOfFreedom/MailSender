using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MailSender
{
    public class MailModel
    {
        [EmailAddress]
        public List<string> MailTo { get; } = new List<string>();
        [EmailAddress(ErrorMessage = "xxx")]
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
            StringBuilder valid = new StringBuilder();
            foreach (var s in temp)
            {
                if (!validation.IsValid(s))
                    valid.Append($"{s} ");
            }
            if (!string.IsNullOrEmpty(valid.ToString()))
            {
                throw new IncorrectRecipientException($"Incorrect recipient address for line: {valid}");
            }
            MailTo.AddRange(temp);
            MailTo.Remove(string.Empty);
        }
    }
}
