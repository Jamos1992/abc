using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ToolsInfo
    {
        public string SerialNum { get; set; }                        //序列号
        public string Model { get; set; }                            //型号
        public string Category { get; set; }                         //类别
        public string Name { get; set; }                             //名称
        public double TorqueMin { get; set; }                           //扭矩下限
        public double TorqueMax { get; set; }                           //扭矩上限
        public double Accuracy { get; set; }                            //精度
        public string Section { get; set; }                          //工段
        public string Workstation { get; set; }                      //工位
        public int DemarcateCycle { get; set; }                      //标定周期
        public string Status { get; set; }                           //工具状态
        public string QualityAssureDate { get; set; }                //质保期至
        public string MaintainContractStyle { get; set; }            //保养合同类型
        public string MaintainContractDate { get; set; }             //保养合同至
        public int RepairTimes { get; set; }                         //累计维修次数
        public string Remark { get; set; }                           //备注信息

    }
}
