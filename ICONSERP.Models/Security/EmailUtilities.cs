using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ICONSERP.Models.Security
{
    public class EmailUtilities
    {
        public bool SendEmail1(string toEmail, string subject, string body, List<string> attachmentsPaths, string userEmail, string password, string smtpName, int sMTPPort, params string[] otherEmails)
        {
            try
            {
                string To = toEmail;
                using (MailMessage mm = new MailMessage("tatera.site@gmail.com", To))
                {
                    mm.Subject = subject;
                    mm.Body = body;
                    mm.IsBodyHtml = false;
                    if (otherEmails.Length > 0)
                    {
                        foreach (string email in otherEmails)
                        {
                            MailAddress CC = new MailAddress(email);
                            mm.CC.Add(CC);
                        }
                    }
                    if (attachmentsPaths != null && attachmentsPaths.Count > 0)
                    {
                        //foreach (var path in attachmentsPaths)
                        //{
                        //    string attachmentPath = HttpContext.Current.Server.MapPath("~/") + path;
                        //    Attachment attachment = new Attachment(attachmentPath);
                        //    attachment.Name = path;
                        //    mm.Attachments.Add(attachment);
                        //}
                    }
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = smtpName;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(userEmail, password);
                        smtp.Timeout = 60000000;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = sMTPPort;
                        smtp.Send(mm);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }


        public bool SendEmail(string toEmail, string subject, string body, List<string> attachmentsPaths, string userEmail, string password, string smtpName, int sMTPPort, params string[] otherEmails)
        {
            try
            {

                var mail = new MailMessage(userEmail, toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                var client = new SmtpClient
                {
                    EnableSsl = true,
                    Port = sMTPPort,

                    //DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Host = smtpName,
                    Credentials = new NetworkCredential(userEmail, password)

                    //Credentials = new NetworkCredential("tatera.site@gmail.com", "zlkohwoewugbvcpr")
                    //System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                    //    contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                };
                if (attachmentsPaths != null && attachmentsPaths.Count > 0)
                {
                    foreach (var path in attachmentsPaths)
                    {
                        //        string attachmentPath = HttpContext.Current.Server.MapPath("~/") + "PDF/" + path;
                        // Attachment attachment = new Attachment(attachmentPath);
                        //   attachment.Name = path;
                        //   mail.Attachments.Add(attachment);
                    }
                }
                client.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"not Valid Email :{toEmail}");

                //return false;
            }
        }
    }
}
