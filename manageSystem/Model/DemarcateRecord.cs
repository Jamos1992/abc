﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DemarcateTools
    {
        public string SerialNum { get; set; }               //待标定的序列号
        public int Cycle { get; set; }                   //标定周期
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
}