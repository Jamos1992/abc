using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manageSystem
{
    class Declare
    {
        public static string DbConnectionString = @"data source=d:\workspace\manageSystem\database\storehouse.db";
        public static string CreateExcelString = "CREATE TABLE 工具信息 ([序列号] VarChar,[型号] VarChar,[工位信息] VarChar,[扭矩信息] VarChar,[工具当前状态] VarChar,[质保期] VarChar,[仓库中备件] VarChar,[保养合同类型] VarChar,[保养合同起始] VarChar,[保养合同终止] VarChar,[备注信息] VarChar,[保养信息] VarChar,[维修记录] VarChar)";
        public static string CreateOnCallRecordExcelString = "CREATE TABLE 巡线记录 ([客户呼叫时间] VarChar,[达到现场时间] VarChar,[故障工具] VarChar,[故障原因] VarChar,[备注] VarChar)";
        public static string CreatRepoSpareToolExcelString = "CREATE TABLE 仓库备件 ([备件型号] VarChar,[个数] Integer,[入库时间] VarChar,[备件序列号] VarChar)";
        public static string EmailAddrFrom = "fsr_123@163.com";
        public static string EmailAddrPasswd = "fsr18942523093";

        //工具维修状态
        public static string Repairing = "待维修";
        public static string RepairFinished = "已完成";
        public static string Suspend = "挂起";
    }
}
