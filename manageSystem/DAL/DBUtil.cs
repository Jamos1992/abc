using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DAL
{
    public class DBUtil
    {
        public DBUtil()
        {

        }
        public void CeateAllTable()
        {
            CreateToolsInfoDb();
            CreateEmailAddrDb();
            CreateRepoSpareToolDb();
            CreateOnCallRecord();
            CreateMaintainManageInfo();
            CreateDemarcateTools();
            CreateDemarcateHistory();
            CreateMaintainInfo();
            CreateCheckManList();
            CreateSpareToolUseHistory();
            CreateRepairHistory();
        }

        private void CreateToolsInfoDb()
        {
            string[] toolsInfoFeildName = new string[] { "SerialNum", "Model", "Category", "Name", "TorqueMin", "TorqueMax", "Accuracy", "Section", "Workstation", "DemarcateCycle", "Status", "QualityAssureDate", "MaintainContractStyle", "MaintainContractDate", "RepairTimes", "Remark" };
            string[] toolsInfoFeildType = new string[] { "VARCHAR(255) PRIMARY KEY", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "DOUBLE", "DOUBLE", "DOUBLE", "VARCHAR(255)", "VARCHAR(255)", "Integer", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" , "VARCHAR(255)", "Integer", "VARCHAR(255)" };
            SQLHelper.CreateTable("ToolsInfo", toolsInfoFeildName, toolsInfoFeildType);
        }

        private void CreateEmailAddrDb()
        {
            string[] emailAddrName = new string[] { "ID", "EmailAddr" };
            string[] emailAddrType = new string[] { "INTEGER PRIMARY KEY AUTOINCREMENT", "VARCHAR(255) UNIQUE" };
            SQLHelper.CreateTable("EmailAddress", emailAddrName, emailAddrType);
        }

        private void CreateRepoSpareToolDb()
        {
            string[] repoSpareToolName = new string[] { "SpareToolModel", "Num", "AddTime" };
            string[] repoSpareToolType = new string[] { "VARCHAR(255) PRIMARY KEY", "INTEGER", "DATETIME" };
            SQLHelper.CreateTable("RepoSpareTool", repoSpareToolName, repoSpareToolType);
        }

        private void CreateOnCallRecord()
        {
            string[] onCallRecordName = new string[] { "CallTime", "ArriveTime", "ToolSection", "ToolWorkStation", "FaultToolName", "FaultReason", "Detail" };
            string[] onCallRecordType = new string[] { "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLHelper.CreateTable("OnCallRecord", onCallRecordName, onCallRecordType);
        }

        //维修信息的数据表，包含历史数据
        private void CreateMaintainManageInfo()
        {
            string[] MaintainManageInfoName = new string[] { "ToolSerialName", "ToolModeName", "SendFixTime", "SuspendTime", "FinishFixTime", "Detail", "Status", "UsedRepoSpareToolInfo", "UsedOtherSpareToolInfo","State" };
            string[] MaintainManageInfoType = new string[] { "VARCHAR(255)", "VARCHAR(255)", "DATETIME", "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLHelper.CreateTable("MaintainManageInfo", MaintainManageInfoName, MaintainManageInfoType);
        }

        //保养
        private void CreateMaintainInfo()
        {
            string[] MaintainInfoName = new string[] { "ToolSerialName", "ToolModeName", "ToolWorkstation", "Cycle","LastTime", "NextTime", "Status" };
            string[] MaintainInfoType = new string[] { "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "INTERGER", "DATETIME", "DATETIME", "VARCHAR(255)" };
            SQLHelper.CreateTable("MaintainInfo", MaintainInfoName, MaintainInfoType);
        }

        //标定记录登记的数据表，暂不含历史记录
        private void CreateDemarcateTools()
        {
            string[] DemarcateToolsName = new string[] { "SerialNum", "Cycle", "LastTime", "NextTime", "Status"};
            string[] DemarcateToolsType = new string[] { "VARCHAR(255)", "Integer", "DATETIME", "DATETIME", "VARCHAR(255)" };
            SQLHelper.CreateTable("DemarcateTools", DemarcateToolsName, DemarcateToolsType);
        }

        //标定完成的历史记录信息数据表，应该包含标定的登记信息（除状态和上次标定时间）以及标定序列号、标定时间、有效期、检查员
        private void CreateDemarcateHistory()
        {
            string[] DemarcateHistoryName = new string[] { "DemarcateNum", "SerialNum", "Cycle", "LastTime", "DemarcateTime", "NextTime", "CheckMan" };
            string[] DemarcateHistoryType = new string[] { "VARCHAR(255) PRIMARY KEY", "VARCHAR(255)", "Integer", "DATETIME", "DATETIME", "DATETIME", "VARCHAR(255)" };
            SQLHelper.CreateTable("DemarcateHistory", DemarcateHistoryName, DemarcateHistoryType);
        }

        private void CreateCheckManList()
        {
            string[] CheckManName = new string[] { "Name" };
            string[] CheckManType = new string[] { "VARCHAR(255) PRIMARY KEY" };
            SQLHelper.CreateTable("CheckMan", CheckManName, CheckManType);
        }

        private void CreateSpareToolUseHistory()
        {
            string[] SpareToolUseHistoryName = new string[] { "SpareToolModel", "Num", "UseTime" };
            string[] SpareToolUseHistoryType = new string[] { "VARCHAR(255) PRIMARY KEY", "INTEGER", "DATETIME" };
            SQLHelper.CreateTable("SpareToolUseHistory", SpareToolUseHistoryName, SpareToolUseHistoryType);
        }

        private void CreateRepairHistory()
        {
            string[] RepairHistoryName = new string[] { "ToolSerialName", "ToolModeName", "SendFixTime", "FinishFixTime", "Detail","UsedRepoSpareToolInfo", "UsedOtherSpareToolInfo"};
            string[] RepairHistoryType = new string[] { "VARCHAR(255)", "VARCHAR(255)", "DATETIME", "DATETIME", "VARCHAR(255)","VARCHAR(255)", "VARCHAR(255)"};
            SQLHelper.CreateTable("RepairHistory", RepairHistoryName, RepairHistoryType);
        }
    }
}
