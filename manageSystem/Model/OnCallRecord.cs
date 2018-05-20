using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class OnCallRecord
    {
        public string CallTime { get; set; }                        //呼叫时间
        public string ArriveTime { get; set; }                      //到达时间
        public string FaultToolName { get; set; }                   //故障工具
        public string FaultReason { get; set; }                     //故障原因
        public string Detail { get; set; }                          //详细原因
    }
}
