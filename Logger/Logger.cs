using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger
    {
        public string FileName { get; set; } = "Logs.txt";
        public static string directory { get; set; }

        public Logger()
        {
            SetDirectory();
        }

        public void Log(string text)
        {
            try
            {
                CreateDirectory();
                File.AppendAllText(
                    Path.Combine(directory, FileName),
                    $"Date: {DateTime.Now} | Info: {text}{Environment.NewLine}");

            }
            catch (DirectoryNotFoundException directoryNotFoundExceptione)
            {
               Log(directoryNotFoundExceptione.Message, "Errors.txt");
            }
        }

        public void Log(string text, string errorFileName)
        {
            try
            {
                CreateDirectory();
                File.AppendAllText(
                    Path.Combine(directory, errorFileName),
                    $"Date: {DateTime.Now} | Info: {text}");

            }
            catch (DirectoryNotFoundException directoryNotFoundExceptione)
            {
                throw;
            }
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }


        private static void SetDirectory()
        {
            try
            {
                directory = System.Configuration.ConfigurationManager.AppSettings["dir"];
            }
            catch (FileNotFoundException fileNotFoundExceptione)
            {

            }
            catch (Exception e)
            {
                throw;
            }
        }

        
    }
}
