using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;

namespace DAL
{
    public class ToolsInfoService
    {

        public bool IsToolExist(ToolsInfo toolsInfo)
        {
            return getOneToolsInfoBySerial(toolsInfo.SerialNum) != null;
        }
        public int AddTools(ToolsInfo toolsInfo)
        {
            return SQLHelper.InsertValuesByStruct("ToolsInfo", toolsInfo);
        }

        public ToolsInfo getOneToolsInfoBySerial(string SerialNum)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { SerialNum });
            ToolsInfo toolsInfo = new ToolsInfo();
            while (reader.Read())
            {
                toolsInfo.SerialNum = reader["SerialNum"].ToString();
                toolsInfo.Model = reader["Model"].ToString();
                toolsInfo.Torque = reader["Torque"].ToString();
                toolsInfo.Status = reader["Status"].ToString();
                toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                toolsInfo.RepoSpareTool = reader["RepoSpareTool"].ToString();
                toolsInfo.MaintainContractDateStart = reader["MaintainContractDateStart"].ToString();
                toolsInfo.MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString();
                toolsInfo.Remark = reader["Reader"].ToString();
                toolsInfo.MaintainInfo = reader["MaintainInfo"].ToString();
                toolsInfo.RepairList = reader["RepairList"].ToString();
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public ToolsInfo getOneToolsInfoBySerialAndModel(string SerialNum,string Model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum", "Model" }, new string[] { "=","=" }, new string[] { SerialNum,Model });
            ToolsInfo toolsInfo = new ToolsInfo();
            while (reader.Read())
            {
                toolsInfo.SerialNum = reader["SerialNum"].ToString();
                toolsInfo.Model = reader["Model"].ToString();
                toolsInfo.Torque = reader["Torque"].ToString();
                toolsInfo.Status = reader["Status"].ToString();
                toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                toolsInfo.RepoSpareTool = reader["RepoSpareTool"].ToString();
                toolsInfo.MaintainContractDateStart = reader["MaintainContractDateStart"].ToString();
                toolsInfo.MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString();
                toolsInfo.Remark = reader["Reader"].ToString();
                toolsInfo.MaintainInfo = reader["MaintainInfo"].ToString();
                toolsInfo.RepairList = reader["RepairList"].ToString();
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public int updateToolsInfo(ToolsInfo toolsInfo,string SerialNum)
        {
            return SQLHelper.UpdateValuesByStruct("ToolsInfo", toolsInfo, new string[] { "SerialNum" }, new string[] { SerialNum });
        }

        public List<ToolsInfo> getAllToolsInfo()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("ToolsInfo");
            List<ToolsInfo> list = new List<ToolsInfo>();
            while (reader.Read())
            {
                list.Add(new ToolsInfo
                {
                    SerialNum = reader["SerialNum"].ToString(),
                    Model = reader["Model"].ToString(),
                    Torque = reader["Torque"].ToString(),
                    Status = reader["Status"].ToString(),
                    QualityAssureDate = reader["QualityAssureDate"].ToString(),
                    RepoSpareTool = reader["RepoSpareTool"].ToString(),
                    MaintainContractDateStart = reader["MaintainContractDateStart"].ToString(),
                    MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString(),
                    Remark = reader["Reader"].ToString(),
                    MaintainInfo = reader["MaintainInfo"].ToString(),
                    RepairList = reader["RepairList"].ToString(),
                });   
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<ToolsInfo> getAllToolsInfoByModel(string model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql("select * from ToolsInfo where Model='" + model + "'");
            List<ToolsInfo> list = new List<ToolsInfo>();
            while (reader.Read())
            {
                list.Add(new ToolsInfo
                {
                    SerialNum = reader["SerialNum"].ToString(),
                    Model = reader["Model"].ToString(),
                    Torque = reader["Torque"].ToString(),
                    Status = reader["Status"].ToString(),
                    QualityAssureDate = reader["QualityAssureDate"].ToString(),
                    RepoSpareTool = reader["RepoSpareTool"].ToString(),
                    MaintainContractDateStart = reader["MaintainContractDateStart"].ToString(),
                    MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString(),
                    Remark = reader["Reader"].ToString(),
                    MaintainInfo = reader["MaintainInfo"].ToString(),
                    RepairList = reader["RepairList"].ToString(),
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

    }
}
