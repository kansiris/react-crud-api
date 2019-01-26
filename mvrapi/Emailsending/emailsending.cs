using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace mvrapi.Emailsending
{
    public class emailsending
    {
        public class EmailModel
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }

        public void Email_myvillage(string txtto, string txtmessage, string subj, HttpPostedFileBase fileUploader)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("maaaahwanamtest@gmail.com");
            Msg.To.Add(txtto);
            //ExbDetails ex = new ExbDetails();
            if (fileUploader != null)
            {
                string fileName = Path.GetFileName(fileUploader.FileName);
                Msg.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

            }
            Msg.Body = txtmessage;
            Msg.Subject = subj;
            Msg.IsBodyHtml = true;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ("smtp.gmail.com").ToString();
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ("maaaahwanamtest@gmail.com").ToString();
            NetworkCred.Password = ("maaaahwanamtest").ToString();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(Msg);



        }
     
    }
}