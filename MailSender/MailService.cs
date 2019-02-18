using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    public static class MailService
    {
        /// <summary>
        /// Add to App.config file following lines in appSettings with tags add:
        ///     key = "smtpClient" value="[string]", 
        ///     key = "defaultCredentials" value="[true|false]",
        ///     key = "networkCredential" value="[string]",
        ///     key = "password" value="[string]",
        ///     key = "enableSsl" value="[true|false]",
        ///     key = "port" value="[int]"
        ///     key = "dir" value="[path to folder for loggs]"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Send(MailModel model)
        {

            Logger.Logger logger = new Logger.Logger();
            logger.Log($"attempt to send an e - mail to {model.MailTo}");

            try
            {

                var message = new MailMessage();
                message.From = new MailAddress(model.MailFrom, model.MailFrom);
                model.MailTo.ForEach(m => message.To.Add(new MailAddress(m)));
                message.Subject = model.Title;
                message.Body = model.Body;


                try
                {
                    var smtp = new SmtpClient(ConfigurationManager.AppSettings["smtpClient"]);
                    smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["defaultCredentials"]);
                    smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["networkCredential"], ConfigurationManager.AppSettings["networkCredential"]);
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

                    smtp.Send(message);
                }
                catch (Exception e)
                {
                    throw new MailServiceException($"Something went wrong.{Environment.NewLine}Can't send e-mail.{Environment.NewLine}Try check if you have an internet connection, or check if you have set the proper values to app.config file");
                }

                logger.Log("Mail sent successfully");
                return true;
            }
            catch (Exception)
            {
                logger.Log($"unsuccessful sending an e-mail");
                return false;
            }
        }

    }
}
