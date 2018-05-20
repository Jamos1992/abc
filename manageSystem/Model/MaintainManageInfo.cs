using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MaintainManageInfo
    {
        public string ToolModeName { get; set; }                    //工具型号
        public string ToolSerialName { get; set; }                  //工具序列号
        public string SendFixTime { get; set; }                     //送修时间
        public string SuspendTime { get; set; }                     //挂起时间
        public string FinishFixTime { get; set; }                   //维修完成时间
        public string Detail { get; set; }                          //送修描述
        public string Status { get; set; }                          //工具维修状态
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
}
