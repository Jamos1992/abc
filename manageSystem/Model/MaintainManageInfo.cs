using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MaintainManageInfo
    {
        public string ToolSerialName { get; set; }                  //工具序列号
        public string ToolModeName { get; set; }                    //工具型号
        public string SendFixTime { get; set; }                     //送修时间
        public string SuspendTime { get; set; }                     //挂起时间
        public string FinishFixTime { get; set; }                   //维修完成时间
        public string Detail { get; set; }                          //送修描述
        public string Status { get; set; }                          //工具维修状态 
        public Dictionary<string, int> UsedRepoSpareToolInfo { get; set; }        //消耗仓库备件的信息
        public Dictionary<string, int> UsedOtherSpareToolInfo { get; set; }       //消耗其他备件的信息
        public string State { get; set; }                              //维修标识
    }

    public class RepairHistory
    {
        public string ToolSerialName { get; set; }                  //工具序列号
        public string ToolModeName { get; set; }                    //工具型号
        public string SendFixTime { get; set; }                     //送修时间
        public string FinishFixTime { get; set; }                   //维修完成时间
        public string Detail { get; set; }                          //送修描述
        public Dictionary<string, int> UsedRepoSpareToolInfo { get; set; }        //消耗仓库备件的信息
        public Dictionary<string, int> UsedOtherSpareToolInfo { get; set; }       //消耗其他备件的信息
    }
    public class OutputStruct
    {
        public string ToolModeName { get; set; }                    //工具型号
        public string ToolSerialName { get; set; }                  //工具序列号
        public string SendFixTime { get; set; }                     //送修时间
        public string Detail { get; set; }                          //送修描述
        public string Status { get; set; }                          //工具维修状态
    }

    public class MaintainInfo
    {
        public string ToolSerialName { get; set; }                  //工具序列号
        public string ToolModel { get; set; }                       //工具型号
        public string ToolWorkstation { get; set; }                 //工位号
        public int Cycle { get; set; }                              //周期
        public string LastTime { get; set; }                        //保养起始日期
        public string NextTime { get; set; }                        //下次保养日期
        public string Status { get; set; }                          //工具保养状态
        public int Times { get; set; }                              //次数
    }
}
