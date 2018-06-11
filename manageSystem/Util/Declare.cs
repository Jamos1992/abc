using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class MaintainDeclare
    {
        public static string Repairing = "待维修";
        public static string RepairFinished = "已完成";
        public static string Suspend = "挂起";
    }
    public class ExcelDeclare
    {
        public static string CreateToolsInfoExcelSql = @"CREATE TABLE 工具信息 ([工具序列号] VarChar,[工具型号] VarChar,[工具类别] VarChar,[工具名称] VarChar,[标定扭矩下限] Integer,[标定扭矩上限] Integer,[精度] Integer,[工段] VarChar,[工位] VarChar,[标定周期] Integer,[工具状态] VarChar,[质保期至] VarChar,[保养合同类型] VarChar,[保养合同至] VarChar,[累计维修次数] Integer,[备注信息] VarChar)";
        public static string CreateOnCallRecordExcelSql = @"CREATE TABLE 巡线记录 ([客户呼叫时间] VarChar,[达到现场时间] VarChar,[工段] VarChar,[工位] VarChar,[故障工具] VarChar,[故障原因] VarChar,[备注] VarChar)";
        public static string CreatRepoSpareToolExcelSql = @"CREATE TABLE 仓库备件 ([备件型号] VarChar,[个数] Integer,[入库时间] VarChar,[备件序列号] VarChar)";
        public static string CreatMaintainManageInfoExcelSql = @"CREATE TABLE 工具维修信息 ([工具型号] VarChar,[工具序列号] Integer,[送修时间] VarChar,[工具维修状态] VarChar,[送修描述] VarChar)";
    }
}
