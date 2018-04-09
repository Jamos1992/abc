using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Data.SQLite;
using System.Net;
using System.Windows.Forms;

namespace manageSystem
{
    class Email
    {
        public void SendEmail()
        {
            SQLiteDataReader reader = this.getEmailAddrFromDb();
            if (!reader.HasRows)
            {
                MessageBox.Show("发送邮件出错");
                return;
            }
            while (reader.Read())
            {
                string emailAddress = reader.GetString(reader.GetOrdinal("EmailAddr"));
                Console.WriteLine("email is {0}", emailAddress);
                sendSingleEmail(emailAddress);
            }
        }

        public SQLiteDataReader getEmailAddrFromDb()
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadFullTable("EmailAddress");
            return reader;
        }

        public void sendSingleEmail(string toAddr)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(Declare.EmailAddrFrom);
            mailMessage.To.Add(new MailAddress(toAddr));
            mailMessage.Subject = "发送邮件测试";
            mailMessage.Body = "这是我发的第一封邮件";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.163.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(Declare.EmailAddrFrom, Declare.EmailAddrPasswd);
            try
            {
                client.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message, "发送邮件出错");
                MessageBox.Show("发送邮件出错,错误原因："+ ex.Message);
                return;
            }
            Console.WriteLine("发送成功");
            MessageBox.Show("发送邮件成功,邮箱地址：" + toAddr);
        }
    }
}
