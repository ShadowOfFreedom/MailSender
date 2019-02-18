using System;

namespace MailSender
{
    public class IncorrectSenderException : Exception
    {
        public IncorrectSenderException(string message) :base(message){}
    }
}