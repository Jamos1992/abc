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
            string[] toolsInfoFeildName = new string[] { "SerialNum", "Model", "Workstation", "Torque", "Status", "QualityAssureDate", "RepoSpareTool", "MaintainContractStyle", "MaintainContractDateStart", "MaintainContractDateEnd", "Remark", "MaintainInfo", "RepairList" };
            string[] toolsInfoFeildType = new string[] { "VARCHAR(255) PRIMARY KEY", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "TEXT", "VARCHAR(255)", "VARCHAR(255)", "TEXT", "TEXT", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLiteDataReader reader = SQLHelper.CreateTable("ToolsInfo", toolsInfoFeildName, toolsInfoFeildType);
            if (reader != null) reader.Close();
        }

        private void CreateEmailAddrDb()
        {
            string[] emailAddrName = new string[] { "ID", "EmailAddr" };
            string[] emailAddrType = new string[] { "INTEGER PRIMARY KEY AUTOINCREMENT", "VARCHAR(255) UNIQUE" };
            SQLiteDataReader reader = SQLHelper.CreateTable("EmailAddress", emailAddrName, emailAddrType);
            if (reader != null) reader.Close();
        }

        private void CreateRepoSpareToolDb()
        {
            string[] repoSpareToolName = new string[] { "SpareToolModel", "Num", "Time" };
            string[] repoSpareToolType = new string[] { "VARCHAR(255) PRIMARY KEY", "INTEGER", "DATETIME" };
            SQLiteDataReader reader = SQLHelper.CreateTable("RepoSpareTool", repoSpareToolName, repoSpareToolType);
            if (reader != null) reader.Close();
        }

        private void CreateOnCallRecord()
        {
            string[] onCallRecordName = new string[] { "CallTime", "ArriveTime", "FaultToolName", "FaultReason", "Detail" };
            string[] onCallRecordType = new string[] { "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLiteDataReader reader = SQLHelper.CreateTable("OnCallRecord", onCallRecordName, onCallRecordType);
            if (reader != null) reader.Close();
        }

        private void CreateMaintainManageInfo()
        {
            string[] MaintainManageInfoName = new string[] { "ToolSerialName", "ToolModeName", "SendFixTime", "SuspendTime", "FinishFixTime", "Detail", "Status", "UsedRepoSpareToolInfo", "UsedOtherSpareToolInfo" };
            string[] MaintainManageInfoType = new string[] { "VARCHAR(255)", "VARCHAR(255)", "DATETIME", "DATETIME", "DATETIME", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            SQLiteDataReader reader = SQLHelper.CreateTable("MaintainManageInfo", MaintainManageInfoName, MaintainManageInfoType);
            if (reader != null) reader.Close();
        }
    }
}
