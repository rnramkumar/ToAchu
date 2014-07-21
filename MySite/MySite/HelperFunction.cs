using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Globalization;
using System.Net.Mail;
using System.IO;

using System.Text;

namespace Easyway
{
    public class HelperFunction
    {


        public static string FormatDate(string strDateToBeFormatted, string strFormatDate)
        {
            DateTime v_dtmDateToFormat;
            CultureInfo v_objDateTimeFormat;

            try
            {
                v_objDateTimeFormat = new CultureInfo("en-US", true);
                v_dtmDateToFormat = DateTime.Parse(strDateToBeFormatted, v_objDateTimeFormat, DateTimeStyles.NoCurrentDateDefault);
                return v_dtmDateToFormat.ToString(strFormatDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ErrorHandle(Exception exceptionMessage)
        {
            StringBuilder strBuild = new StringBuilder();
            
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;


                if (!Directory.Exists(baseDir + "/logs"))
                {
                    Directory.CreateDirectory(baseDir + "/logs");
                }

                string filePath = baseDir + "/logs/" + "LogFile.txt";

                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                else
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            string val = DateTime.Now.ToString();
                            //streamWriter.WriteLine(DateTime.Now.ToShortDateString());

                            strBuild.Append("=================");
                            strBuild.Append("\n");
                            strBuild.Append(DateTime.Now.ToShortDateString());
                            strBuild.Append("\t");
                            strBuild.Append(exceptionMessage.GetBaseException());
                            strBuild.Append("\t");
                            strBuild.Append(exceptionMessage.Message);
                            strBuild.Append("\t");
                            strBuild.Append(exceptionMessage.StackTrace);
                            strBuild.Append("\n");
                            strBuild.Append("=================");
                            streamWriter.WriteLine(strBuild.ToString());

       
                        }
                    }
                }
            
        }

        public static void SendMailFriend(string fromEmail,string toEmail,string subject,string body)
        {

               MailMessage message = new MailMessage();

               MailAddress mailFrom = new MailAddress(fromEmail);
               MailAddress mailTo = new MailAddress(toEmail);

               message.From = mailFrom;

               message.To.Add(mailTo);

                message.Subject = subject;

                message.Body = body;

                message.IsBodyHtml = true;

               // message.CC = "";//CCList;

                //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SmtpServer"];

                //SmtpMail.Send(message);

                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Send(message);
          }
        public static void SendMail(string toEmail, string subject, string body)
        {

            MailMessage message = new MailMessage();

            MailAddress mailFrom = new MailAddress("easyway2buy@gmail.com");
            MailAddress mailTo = new MailAddress(toEmail);

            message.From = mailFrom;

            message.To.Add(mailTo);

            message.Subject = subject;

            message.Body = body;

            message.IsBodyHtml = true;

            // message.CC = "";//CCList;

            //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SmtpServer"];

            //SmtpMail.Send(message);

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Send(message);
        }


    }
}
