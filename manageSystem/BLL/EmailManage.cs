using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace BLL
{
    public class EmailManage
    {
        private EmailAddressService emailAddressService = new EmailAddressService();
        private static string EmailAddrFrom = EmailAddressService.EmailAddrFrom;
        private static string EmailAddrPasswd = EmailAddressService.EmailAddrPasswd;
        public void SendEmail()
        {
            List<EmailAddress> list = emailAddressService.getAllEmailAddrFromDb();
            if (list == null)
            {
                return;
            }
            foreach (EmailAddress email in list)
            {
                sendSingleEmail(email.EmailAddr);
            }
        }

        private void sendSingleEmail(string toAddr)
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

        public string AddEmailAddress(string addr)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";// 定义正则表达式
            Match m = Regex.Match(addr, pattern);// 匹配正则表达式
            if (!m.Success)
            {
                return "邮箱地址格式有误！";
            }
            int affectedRow = emailAddressService.InsertEmailAddress(addr);
            if(affectedRow < 1)
            {
                return "添加邮箱失败！";
            }
            return "添加邮箱成功！";
        }

        public List<EmailAddress> SearchEmailAddress(string addr)
        {
            return emailAddressService.GetEmailAddresses(addr);
        }

        public int DeleteEmailAddress(string addr)
        {
            return emailAddressService.DeleteEmailAddress(addr);
        }
    }
}
