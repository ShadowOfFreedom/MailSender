using System;

namespace MailSender
{
    public class IncorrectRecipientException : Exception
    {
        public IncorrectRecipientException(string message) :base(message){}
    }
}