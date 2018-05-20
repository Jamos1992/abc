using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Data.SQLite;
using System.Net;
using System.Configuration;
using Model;

namespace DAL
{
    public class EmailAddressService
    {
        private static string EmailAddrFrom = ConfigurationManager.AppSettings["EmailAddrFrom"];
        private static string EmailAddrPasswd = ConfigurationManager.AppSettings["EmailAddrPasswd"];
        public void SendEmail()
        {
            List<EmailAddress> list = getAllEmailAddrFromDb();
            if(list == null)
            {
                return;
            }
            foreach (EmailAddress email in list)
            {
                sendSingleEmail(email.EmailAddr);
            }
        }

        public List<EmailAddress> getAllEmailAddrFromDb()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("EmailAddress");
            List<EmailAddress> list = new List<EmailAddress>();
            while (reader.Read())
            {
                list.Add(new EmailAddress
                {
                    EmailAddr = reader["EmailAddr"].ToString(),
                    ID = (int)reader["ID"]
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public void sendSingleEmail(string toAddr)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(EmailAddrFrom);
            mailMessage.To.Add(new MailAddress(toAddr));
            mailMessage.Subject = "发送邮件测试";
            mailMessage.Body = "这是我发的第一封邮件";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.163.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(EmailAddrFrom, EmailAddrPasswd);
            try
            {
                client.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message, "发送邮件出错");
                //MessageBox.Show("发送邮件出错,错误原因：" + ex.Message);
                return;
            }
            Console.WriteLine("发送成功");
            //MessageBox.Show("发送邮件成功,邮箱地址：" + toAddr);
        }
    }
}
