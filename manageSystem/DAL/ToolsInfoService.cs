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
        public int AddTools(ToolsInfo toolsInfo)
        {
            return SQLHelper.InsertValuesByStruct("ToolsInfo", toolsInfo);
        }

        public ToolsInfo getOneToolsInfo(string SerialNum)
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

        public int updateToolsInfo(ToolsInfo toolsInfo,string SerialNum)
        {
            return SQLHelper.UpdateValuesByStruct("ToolsInfo", toolsInfo, new string[] { "SerialNum" }, new string[] { SerialNum });
        }

    }
}
