using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DemarcateTools
    {
        public string SerialNum { get; set; }               //待标定的序列号
        public int Cycle { get; set; }                      //标定周期
        public string LastTime { get; set; }                //上次标定时间或起始时间
        public string NextTime { get; set; }                //下次标定时间
        public string Status { get; set; }                  //标定状态
    }

    public class DemarcateRecords
    {
        public string DemarcateNum { get; set; }            //标定序列号
        public string SerialNum { get; set; }               //工具的序列号
        public string WorkStation { get; set; }             //工位
        public string Validity { get; set; }                //有效期
        public string Examinant { get; set; }               //检查员
        public string CheckTime { get; set; }               //标定时间
    }

    public class DemarcateHistory
    {
        public string DemarcateNum { get; set; }            //标定序列号，primary key
        public string SerialNum { get; set; }               //工具的序列号
        public int Cycle { get; set; }                      //周期
        public string LastTime { get; set; }                //上次标定时间
        public string DemarcateTime { get; set; }           //标定时间      
        public string NextTime { get; set; }                //有效期
        public string CheckMan { get; set; }                //检查员
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

    public class DemarcateData
    {
        public string Order { get; set; }                   //标定组别
        public string Date { get; set; }                    //标定日期
        public string Time { get; set; }                    //标定时间
        public string Torque { get; set; }                  //扭矩
        public string Angle { get; set; }                   //角度
    }
}
