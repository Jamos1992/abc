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
            
            string body = $@"发自***工厂：

            上周* 月*日至 * 月 * 日，
	        校准计划完成{}把工具，实际完成{}把工具校准。{}把工具在校准计划内，但未能按时完成。
	        保养计划完成{}把工具，实际完成{}把工具保养。{}把工具在保养计划内，但未能按时完成。
	        近一周内发生现场On-Call {}次，记录如下：
            {}

            近一个月内进入维修状态工具* 把，其中维修完成* 把。消耗备件* 个，消耗记录列表：
		    备件序列号1 消耗日期1
            {}
            ";
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(EmailAddrFrom);
            mailMessage.To.Add(new MailAddress(toAddr));
            mailMessage.Subject = "Desoutter工具管理系统自动发送";
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
