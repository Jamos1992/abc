using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EmailAddress
    {
        public int? ID { get; set; }                                 //ID
        public string EmailAddr { get; set; }                        //邮件地址
    }

    public class EmailContent
    {
        public string Monday { get; set; }                          //发件起始日期
        public string Sunday { get; set; }                          //发件终止日期
        public int DemarcateWeekPlan { get; set; }                  //计划完成的标定工具
        public int DemarcateWeekFinished { get; set; }              //已完成的标定  
        public int DemarcateWeekUnFinished { get; set; }         //未完成的标定
        public OnCallRecord[] OnCallRecords { get; set; }           //oncall次数
        public int MonthRepairRecord { get; set; }                  //近一月维修记录
        public int MonthRepairFinsihed { get; set; }                //维修完成
        public int MonthSpareUsed { get; set; }                     //消耗的备件数 
    }
}
