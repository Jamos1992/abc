﻿using System;
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
        public static string InsertToolsInfoExcelSql = "INSERT INTO 工具信息 (工具序列号,工具型号,工具类别,工具名称,标定扭矩下限,标定扭矩上限,精度,工段,工位,标定周期,工具状态,质保期至,保养合同类型,保养合同至,累计维修次数,备注信息)";

        public static string CreateOnCallRecordExcelSql = @"CREATE TABLE 巡线记录 ([客户呼叫时间] VarChar,[达到现场时间] VarChar,[工段] VarChar,[工位] VarChar,[故障工具] VarChar,[故障原因] VarChar,[备注] VarChar)";
        public static string InsertOnCallRecordExcelSql = "INSERT INTO 巡线记录 (客户呼叫时间,达到现场时间,工段,工位,故障工具,故障原因,备注)";

        public static string CreateRepoSpareToolExcelSql = @"CREATE TABLE 仓库备件 ([备件型号] VarChar,[个数] Integer,[入库时间] VarChar)";
        public static string InsertRepoSpareToolsExcelSql = "INSERT INTO 仓库备件(备件型号,个数,入库时间)";

        public static string CreateMaintainManageInfoExcelSql = @"CREATE TABLE 工具维修信息 ([工具型号] VarChar,[工具序列号] VarChar,[送修时间] VarChar,[工具维修状态] VarChar,[送修描述] VarChar)";
        public static string InsertMaintainManageInfoExcelSql = "INSERT INTO 工具维修信息(工具型号,工具序列号,送修时间,工具维修状态,送修描述)";

        public static string CreateDemarcateHistoryExcelSql = @"CREATE TABLE 工具标定记录 ([标定序列号] VarChar,[工具序列号] VarChar,[标定周期] Integer,[上次标定时间] VarChar,[标定时间] VarChar,[有效期] VarChar,[检查员] VarChar,[工具型号] VarChar,[工具类别] VarChar,[工具名称] VarChar,[标定扭矩下限] Integer,[标定扭矩上限] Integer,[精度] Integer,[工段] VarChar,[工位] VarChar,[工具状态] VarChar,[质保期至] VarChar,[保养合同类型] VarChar,[保养合同至] VarChar,[累计维修次数] Integer,[备注信息] VarChar)";
        public static string InsertDemarcateHistoryExcelSql = "INSERT INTO 工具标定记录(标定序列号,工具序列号,标定周期,上次标定时间,标定时间,有效期,检查员,工具型号,工具类别,工具名称,标定扭矩下限,标定扭矩上限,精度,工段,工位,工具状态,质保期至,保养合同类型,保养合同至,累计维修次数,备注信息)";
    }

    public class DemarcateStatusDeclare
    {
        public static string Normal = "正常";
        public static string Abnormal = "逾期未标定";
        public static string OffGrade = "标定不合格";
    }
}
