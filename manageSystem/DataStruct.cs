﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manageSystem
{
    class ToolsInfo
    {
        public string SerialNum { get; set; }                        //序列号
        public string Model { get; set; }                            //型号
        public string Workstation { get; set; }                      //工位信息
        public string Torque { get; set; }                           //扭矩信息
        public string Status { get; set; }                           //工具当前状态
        public string QualityAssureDate { get; set; }                //质保期
        public string RepoSpareTool { get; set; }                    //仓库中备件
        public string MaintainContractStyle { get; set; }            //保养合同类型
        public string MaintainContractDateStart { get; set; }        //保养合同起始
        public string MaintainContractDateEnd { get; set; }          //保养合同终止
        public string Remark { get; set; }                           //备注信息
        public string MaintainInfo { get; set; }                     //保养信息
        public string RepairList { get; set; }                       //维修记录
    }

    class EmailAddress
    {
        public int? ID { get; set; }                                 //ID
        public string EmailAddr { get; set; }                        //邮件地址
    }

    class RepoSpareTool
    {
        public string SpareToolModel { get; set; }                  //备件型号
        public int Num { get; set; }                                //备件数量
        public string Time { get; set; }                          //入库时间
        public string SerialNum { get; set; }                       //工具序列号
    }

    class OnCallRecord
    {
        public string CallTime { get; set; }                        //呼叫时间
        public string ArriveTime { get; set; }                      //到达时间
        public string FaultToolName { get; set; }                   //故障工具
        public string FaultReason { get; set; }                     //故障原因
        public string Detail { get; set; }                          //详细原因
    }

    class MaintainManageInfo
    {
        public string ToolModeName { get; set; }                    //工具型号
        public string ToolSerialName { get; set; }                  //工具序列号
        public string SendFixTime { get; set; }                     //送修时间
        public string Detail { get; set; }                          //送修描述
        public string Status { get; set; }                          //工具维修状态
    }
}
