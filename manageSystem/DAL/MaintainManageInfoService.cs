using System.Collections.Generic;
using System.Data.SQLite;
using Model;
using System.Configuration;
using Util;

namespace DAL
{
    public class MaintainManageInfoService
    {
        private CommonService commonService = new CommonService();
        public bool IsNotFinishBreakToolExist(MaintainManageInfo maintainManageInfo)
        {
            string sql = "select * from MaintainManageInfo where ToolSerialName='" + maintainManageInfo.ToolSerialName + "' and Status!='" + MaintainDeclare.RepairFinished + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            if (reader != null && reader.HasRows)
            {
                //MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！");
                reader.Close();
                return true;
            }
            return false;
        }
        public int AddMaintainManageInfo(MaintainManageInfo maintainManageInfo)
        {
            return SQLHelper.InsertValuesByStruct("MaintainManageInfo", maintainManageInfo);
        }

        public int UpdateMaintainManageInfo(MaintainManageInfo maintainManageInfo)
        {
            string usedRepoSpareToolInfo = commonService.ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
            string usedOtherSpareToolInfo = commonService.ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            string sql;
            if (maintainManageInfo.State == "0")
            {
                sql = "update MaintainManageInfo set UsedRepoSpareToolInfo='" + usedRepoSpareToolInfo + "', UsedOtherSpareToolInfo='" + usedOtherSpareToolInfo + "', Status='" + maintainManageInfo.Status + "' where ToolSerialName='" + maintainManageInfo.ToolSerialName + "' and State='0'";
            }
            else
            {
                sql = "update MaintainManageInfo set UsedRepoSpareToolInfo='" + usedRepoSpareToolInfo + "', UsedOtherSpareToolInfo='" + usedOtherSpareToolInfo + "', Status='" + maintainManageInfo.Status + "', State='" + maintainManageInfo.State + "' where ToolSerialName='" + maintainManageInfo.ToolSerialName + "' and State='0'";
            }
            
            return SQLHelper.UpdateTableBySql(sql);
        }

        public int UpdateMaintainStatus(MaintainManageInfo maintainManageInfo)
        {
            string sql = "update MaintainManageInfo set Status='" + maintainManageInfo.Status + "' where ToolSerialName='" + maintainManageInfo.ToolSerialName + "' and State='0'";
            return SQLHelper.UpdateTableBySql(sql);
        }

        public MaintainManageInfo getOneBreakToolFromDb(string toolSerialName)
        {
            string sql = "select * from MaintainManageInfo where ToolSerialName='" + toolSerialName + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            MaintainManageInfo maintainManage = new MaintainManageInfo();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                maintainManage.ToolSerialName = reader["ToolSerialName"].ToString();
                maintainManage.ToolModeName = reader["ToolModeName"].ToString();
                maintainManage.SendFixTime = reader["SendFixTime"].ToString();
                maintainManage.SuspendTime = reader["SuspendTime"].ToString();
                maintainManage.FinishFixTime = reader["FinishFixTime"].ToString();
                maintainManage.Status = reader["Status"].ToString();
                maintainManage.Detail = reader["Detail"].ToString();
                maintainManage.UsedRepoSpareToolInfo = commonService.ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString());
                maintainManage.UsedOtherSpareToolInfo = commonService.ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString());
            }
            if (reader != null) reader.Close();
            return maintainManage;
        }

        public List<OutputStruct> getAllBreakTools()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("MaintainManageInfo");
            List<OutputStruct> list = new List<OutputStruct>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                list.Add(new OutputStruct
                {
                    ToolSerialName = reader["ToolSerialName"].ToString(),
                    ToolModeName = reader["ToolModeName"].ToString(),
                    SendFixTime = reader["SendFixTime"].ToString(),
                    //SuspendTime = reader["SuspendTime"].ToString(),
                    //FinishFixTime = reader["FinishFixTime"].ToString(),
                    Status = reader["Status"].ToString(),
                    Detail = reader["Detail"].ToString(),
                    //UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString()),
                    //UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString())
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<OutputStruct> getBreakToolsBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<OutputStruct> list = new List<OutputStruct>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                list.Add(new OutputStruct
                {
                    ToolSerialName = reader["ToolSerialName"].ToString(),
                    ToolModeName = reader["ToolModeName"].ToString(),
                    SendFixTime = reader["SendFixTime"].ToString(),
                    //SuspendTime = reader["SuspendTime"].ToString(),
                    //FinishFixTime = reader["FinishFixTime"].ToString(),
                    Status = reader["Status"].ToString(),
                    Detail = reader["Detail"].ToString(),
                    //UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString()),
                    //UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString())
                });

            }
            if (reader != null) reader.Close();
            return list;
        }

        public int DeleteOneRegisterTools(string serialNum)
        {
            return SQLHelper.DeleteValuesAND("MaintainManageInfo", new string[] { "ToolSerialName" }, new string[] { serialNum }, new string[] { "=" });
        }

        //excel operation
        public int CreateMaintainManageInfoExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ExcelDeclare.CreatMaintainManageInfoExcelSql);
        }

        public int InsertMaintainManageInfo2ExcelTable(string filePath, object obj)
        {
            string sql = "insert into 工具维修信息(工具型号,工具序列号,送修时间,工具维修状态,送修描述)";
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }
    }
}
