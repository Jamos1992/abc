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
        }

        private void CreateToolsInfoDb()
        {
            string[] toolsInfoFeildName = new string[] { "SerialNum", "Model", "Category", "Name", "TorqueMin", "TorqueMax", "Accuracy", "Section", "Workstation", "DemarcateCycle", "Status", "QualityAssureDate", "MaintainContractStyle", "MaintainContractDate", "RepairTimes", "ChangeRecord", "Remark" };
            string[] toolsInfoFeildType = new string[] { "VARCHAR(255) PRIMARY KEY", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "Integer", "Integer", "Integer", "VARCHAR(255)", "VARCHAR(255)", "Integer", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" , "VARCHAR(255)", "Integer", "VARCHAR(255)", "VARCHAR(255)" };
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
            string[] repoSpareToolName = new string[] { "SpareToolModel", "Num", "Time" };
            string[] repoSpareToolType = new string[] { "VARCHAR(255) PRIMARY KEY", "INTEGER", "DATETIME" };
            SQLHelper.CreateTable("RepoSpareTool", repoSpareToolName, repoSpareToolType);
        }

        private void CreateOnCallRecord()
        {
            string[] onCallRecordName = new string[] { "CallTime", "ArriveTime", "FaultToolName", "FaultReason", "Detail" };
            string[] onCallRecordType = new string[] { "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLHelper.CreateTable("OnCallRecord", onCallRecordName, onCallRecordType);
        }

        private void CreateMaintainManageInfo()
        {
            string[] MaintainManageInfoName = new string[] { "ToolSerialName", "ToolModeName", "SendFixTime", "SuspendTime", "FinishFixTime", "Detail", "Status", "UsedRepoSpareToolInfo", "UsedOtherSpareToolInfo","State" };
            string[] MaintainManageInfoType = new string[] { "VARCHAR(255)", "VARCHAR(255)", "DATETIME", "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLHelper.CreateTable("MaintainManageInfo", MaintainManageInfoName, MaintainManageInfoType);
        }
    }
}
