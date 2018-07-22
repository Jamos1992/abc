using System.Collections.Generic;
using System.Data.SQLite;
using Model;
using System.Configuration;
using Util;
using System;
using System.Reflection;

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
                if (maintainManageInfo.Status == MaintainDeclare.Suspend)
                    sql = $"update MaintainManageInfo set UsedRepoSpareToolInfo='{usedRepoSpareToolInfo}', UsedOtherSpareToolInfo='{usedOtherSpareToolInfo}', Status='{maintainManageInfo.Status}', SuspendTime='{maintainManageInfo.SuspendTime}' where ToolSerialName='{maintainManageInfo.ToolSerialName}' and State='0'";
                else
                    sql = $"update MaintainManageInfo set UsedRepoSpareToolInfo='{usedRepoSpareToolInfo}', UsedOtherSpareToolInfo='{usedOtherSpareToolInfo}', Status='{maintainManageInfo.Status}', FinishFixTime='{maintainManageInfo.FinishFixTime}' where ToolSerialName='{maintainManageInfo.ToolSerialName }' and State='0'";
            }
            else
            {
                if (maintainManageInfo.Status == MaintainDeclare.Suspend)
                    sql = $"update MaintainManageInfo set UsedRepoSpareToolInfo='{usedRepoSpareToolInfo}', UsedOtherSpareToolInfo='{usedOtherSpareToolInfo}', Status='{maintainManageInfo.Status}', SuspendTime='{maintainManageInfo.SuspendTime}', State='{maintainManageInfo.State}' where ToolSerialName='{maintainManageInfo.ToolSerialName}' and State='0'";
                else
                    sql = $"update MaintainManageInfo set UsedRepoSpareToolInfo='{usedRepoSpareToolInfo}', UsedOtherSpareToolInfo='{usedOtherSpareToolInfo}', Status='{maintainManageInfo.Status}', FinishFixTime='{maintainManageInfo.FinishFixTime}', State='{maintainManageInfo.State}' where ToolSerialName='{maintainManageInfo.ToolSerialName}' and State='0'";
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
                try
                {
                    maintainManage.ToolSerialName = reader["ToolSerialName"].ToString();
                    maintainManage.ToolModeName = reader["ToolModeName"].ToString();
                    maintainManage.SendFixTime = Convert.ToDateTime(reader["SendFixTime"].ToString()).ToString("yyyy-MM-dd");
                    maintainManage.Status = reader["Status"].ToString();
                    maintainManage.Detail = reader["Detail"].ToString();
                    maintainManage.UsedRepoSpareToolInfo = commonService.ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString());
                    maintainManage.UsedOtherSpareToolInfo = commonService.ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOneBreakToolFromDb failed, error message is: {ex.Message}");
                }
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
                try
                {
                    list.Add(new OutputStruct
                    {
                        ToolSerialName = reader["ToolSerialName"].ToString(),
                        ToolModeName = reader["ToolModeName"].ToString(),
                        SendFixTime = Convert.ToDateTime(reader["SendFixTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString(),
                        Detail = reader["Detail"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllBreakTools failed, error message is: {ex.Message}");
                }
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
                try
                {
                    list.Add(new OutputStruct
                    {
                        ToolSerialName = reader["ToolSerialName"].ToString(),
                        ToolModeName = reader["ToolModeName"].ToString(),
                        SendFixTime = Convert.ToDateTime(reader["SendFixTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString(),
                        Detail = reader["Detail"].ToString(),
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getBreakToolsBySql failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public int DeleteOneRegisterTools(string serialNum)
        {
            return SQLHelper.DeleteValuesAND("MaintainManageInfo", new string[] { "ToolSerialName" }, new string[] { serialNum }, new string[] { "=" });
        }

        //保养
        public int InsertOneMaintainTool(MaintainInfo maintainInfo)
        {
           return SQLHelper.InsertValuesByStruct("MaintainInfo", maintainInfo);
        }

        public int InsertOneRepairHistory(RepairHistory repairHistory)
        {
            return SQLHelper.InsertValuesByStruct("RepairHistory", repairHistory);
        }

        public int updateOneMaintainTool(MaintainInfo maintainInfo)
        {
            string sql = $"update MaintainInfo set Cycle={maintainInfo.Cycle}, LastTime='{maintainInfo.LastTime}', NextTime='{maintainInfo.NextTime}' where ToolSerialName='{maintainInfo.ToolSerialName}'";
            return SQLHelper.UpdateTableBySql(sql);
        }

        public List<MaintainInfo> QueryMaintainBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<MaintainInfo> list = new List<MaintainInfo>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new MaintainInfo
                    {
                        ToolSerialName = reader["ToolSerialName"].ToString(),
                        ToolModel = reader["ToolModeName"].ToString(),
                        ToolWorkstation = reader["ToolWorkstation"].ToString(),
                        Cycle = Convert.ToInt32(reader["Cycle"].ToString()),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"QueryOneMaintainBySql failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        //excel operation
        public int CreateMaintainManageInfoExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ExcelDeclare.CreateMaintainManageInfoExcelSql);
        }

        public int InsertMaintainManageInfo2ExcelTable(string filePath, object obj)
        {
            string sql = ExcelDeclare.InsertMaintainManageInfoExcelSql;
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            int i = 0;
            foreach (PropertyInfo pinfo in propertys)
            {
                if (i == 0)
                {
                    sql += " values(" + "'" + pinfo.GetValue(obj, null) + "'";
                }
                else
                {
                    sql += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                }
                i++;
            }
            sql += ")";
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }
    }
}
