using System;

namespace MailSender
{
    public class MailServiceException : Exception
    {
        public MailServiceException(string message):base(message){}
    }
}