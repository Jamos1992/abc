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
        public string MaintainContractStyle { get; set; }            //保养合同类型
        public string MaintainContractData { get; set; }             //保养合同起止
        public string Remark { get; set; }                           //备注信息
        public string RepairList { get; set; }                       //维修记录
    }
}
