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
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private OnCallRecordManage onCallRecordManage = new OnCallRecordManage();
        private static string EmailAddrFrom = EmailAddressService.EmailAddrFrom;
        private static string EmailAddrPasswd = EmailAddressService.EmailAddrPasswd;
        public void SendEmail()
        {
            List<EmailAddress> list = emailAddressService.getAllEmailAddrFromDb();
            if (list == null)
            {
                return;
            }
            EmailContent emailContent = GetEmailContent();
            foreach (EmailAddress email in list)
            { 
                sendSingleEmail(email.EmailAddr,emailContent);
            }
        }

        private EmailContent GetEmailContent()
        {
            int iNowOfWeek = (int)DateTime.Now.DayOfWeek;
            if (iNowOfWeek == 0)
            {
                iNowOfWeek = 7;
            }
            DateTime lastWeekMonday = DateTime.Now.AddDays(1 - iNowOfWeek - 7).Date;
            DateTime lastWeekSunday = DateTime.Now.AddDays(0 - iNowOfWeek).Date;
            EmailContent emailContent = new EmailContent();
            emailContent.Monday = lastWeekMonday.ToString("yyyy-MM-dd");
            emailContent.Sunday = lastWeekSunday.ToString("yyyy-MM-dd");
            string sql = $"select * from DemarcateTools where NextTime>='{emailContent.Monday}' and NextTime<='{emailContent.Sunday}'";
            List<DemarcateTools> list = demarcateRecordManage.GetDemarcateToolsBySql(sql);
            if (list == null) emailContent.DemarcateWeekUnFinished = 0;
            else emailContent.DemarcateWeekUnFinished = list.Count;
            sql = $"select * from DemarcateHistory where DemarcateTime>='{emailContent.Monday}' and DemarcateTime<='{emailContent.Sunday}'";
            List<DemarcateHistory> demarcateHistories = demarcateRecordManage.GetDemarcateHistoryBySql(sql);
            if (demarcateHistories == null) emailContent.DemarcateWeekFinished = 0;
            else emailContent.DemarcateWeekFinished = demarcateHistories.Count;
            emailContent.DemarcateWeekPlan = emailContent.DemarcateWeekUnFinished + emailContent.DemarcateWeekUnFinished;
            sql = $"select * from OnCallRecord where CallTime>='{emailContent.Monday}' and CallTime<='{emailContent.Sunday}'";
            List<OnCallRecord> onCallRecords = onCallRecordManage.GetOnCallRecordBySql(sql);
            if (onCallRecords == null) emailContent.OnCallRecords = new OnCallRecord[] { };
            else emailContent.OnCallRecords = onCallRecords.ToArray();
            sql = $"select * from MaintainManageInfo where SendFixTime>='{DateTime.Now.AddDays(0-30).ToString("yyyy-MM-dd")}' and SendFixTime<='{DateTime.Now.ToString("yyyy-MM-dd")}'";
            List<OutputStruct> maintainManageInfos = maintainInfoManage.GetBreakToolBySql(sql);
            if (maintainManageInfos == null) emailContent.MonthRepairRecord = 0;
            else emailContent.MonthRepairRecord = maintainManageInfos.Count;
            sql = $"select * from MaintainManageInfo where SendFixTime>='{DateTime.Now.AddDays(0 - 30).ToString("yyyy-MM-dd")}' and SendFixTime<='{DateTime.Now.ToString("yyyy-MM-dd")}' and State='1'";
            List<OutputStruct> outputStructs = maintainInfoManage.GetBreakToolBySql(sql);
            if(maintainManageInfos == null) emailContent.MonthRepairFinsihed = 0;
            else emailContent.MonthRepairFinsihed = maintainManageInfos.Count;
            List<SpareToolUseHistory> spareToolUseHistories = repoSpareToolManage.GetSpareToolUseHistoryByDays(30);
            if (spareToolUseHistories == null) emailContent.MonthSpareUsed = 0;
            else
            {
                foreach(SpareToolUseHistory sp in spareToolUseHistories)
                {
                    emailContent.MonthSpareUsed += sp.Num;
                }
            }
            return emailContent;
        }
        private void sendSingleEmail(string toAddr, EmailContent emailContent)
        {
            string onCallRecord = string.Empty;
            if (emailContent.OnCallRecords.Length >0)
            {
                foreach (OnCallRecord oncall in emailContent.OnCallRecords)
                {
                    onCallRecord += $"On-Call原因：{oncall.FaultReason}	时间:{oncall.CallTime}\n";
                }                    
            }
            string spareToolUse = string.Empty;
            List<SpareToolUseHistory> list = repoSpareToolManage.GetSpareToolUseHistoryByDays(30);
            if(list != null)
            {
                foreach(SpareToolUseHistory spareToolUsedHistory in list)
                {
                    spareToolUse += $"备件序列号:{spareToolUsedHistory.SpareToolModel} 	消耗日期:{spareToolUsedHistory.UseTime}\n";
                }
            }           
            string body = $@"发自***工厂：
        上周{DateTime.Now.Date.AddDays(0-7).ToString("MM月dd日")}至{DateTime.Now.Date.AddDays(0-1).ToString("MM月dd日")},
        校准计划完成{emailContent.DemarcateWeekPlan}把工具，实际完成{emailContent.DemarcateWeekFinished}把工具校准。{emailContent.DemarcateWeekUnFinished}把工具在校准计划内，但未能按时完成。
        近一周内发生现场On-Call {emailContent.OnCallRecords.Length}次，记录如下：
        {onCallRecord}
        近一个月内进入维修状态工具{emailContent.MonthRepairRecord}把，其中维修完成{emailContent.MonthRepairFinsihed}把。消耗备件{emailContent.MonthSpareUsed}个，消耗记录列表：
        {spareToolUse}
        ";

            //保养计划完成{ emailContent.MonthRepairRecord}
            //把工具，实际完成{ emailContent.MonthRepairFinsihed}
            //把工具保养。{ emailContent.MonthSpareUsed}
            //把工具在保养计划内，但未能按时完成。
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(EmailAddrFrom);
            mailMessage.To.Add(new MailAddress(toAddr));
            mailMessage.Subject = "Desoutter工具管理系统自动发送";
            mailMessage.Body = body;
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
