using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;
using System.Configuration;

namespace DAL
{
    public class MaintainManageInfoService
    {
        private static string status = ConfigurationManager.AppSettings["RepairFinished"];
        public bool IsNotFinishBreakToolExist(MaintainManageInfo maintainManageInfo)
        {
            string sql = "select * from MaintainManageInfo where ToolSerialName='" + maintainManageInfo.ToolSerialName + "' and Status!='" + status + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            if (reader != null && reader.HasRows)
            {
                //MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！");
                reader.Close();
                return true;
            }
            return false;
        }
        public int AddRepoSpareTool(MaintainManageInfo maintainManageInfo)
        {
            return SQLHelper.InsertValuesByStruct("MaintainManageInfo", maintainManageInfo);
        }

        public int UpdateMaintainManageInfo(MaintainManageInfo maintainManageInfo)
        {
            string usedRepoSpareToolInfo = ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
            string usedOtherSpareToolInfo = ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            string sql = "update MaintainManageInfo set UsedRepoSpareToolInfo='" + usedRepoSpareToolInfo + "', UsedOtherSpareToolInfo='" + usedOtherSpareToolInfo + "', Status='" + maintainManageInfo.Status + "' where ToolSerialName='" + maintainManageInfo.ToolSerialName + "'";
            return SQLHelper.UpdateTableBySql(sql);
        }

        public MaintainManageInfo getOneBreakToolFromDb(string toolSerialName)
        {
            string sql = "select * from MaintainManageInfo where ToolSerialName='" + toolSerialName + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            MaintainManageInfo maintainManage = new MaintainManageInfo();
            while (reader.Read())
            {
                maintainManage.ToolSerialName = reader["ToolSerialName"].ToString();
                maintainManage.ToolModeName = reader["ToolModeName"].ToString();
                maintainManage.SendFixTime = reader["SendFixTime"].ToString();
                maintainManage.SuspendTime = reader["SuspendTime"].ToString();
                maintainManage.FinishFixTime = reader["FinishFixTime"].ToString();
                maintainManage.Status = reader["Status"].ToString();
                maintainManage.Detail = reader["Detail"].ToString();
                maintainManage.UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString());
                maintainManage.UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString());
            }
            if (reader != null) reader.Close();
            return maintainManage;
        }

        public List<MaintainManageInfo> getAllBreakTools()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("MaintainManageInfo");
            List<MaintainManageInfo> list = new List<MaintainManageInfo>();
            while (reader.Read())
            {
                list.Add(new MaintainManageInfo
                {
                    ToolSerialName = reader["ToolSerialName"].ToString(),
                    ToolModeName = reader["ToolModeName"].ToString(),
                    SendFixTime = reader["SendFixTime"].ToString(),
                    SuspendTime = reader["SuspendTime"].ToString(),
                    FinishFixTime = reader["FinishFixTime"].ToString(),
                    Status = reader["Status"].ToString(),
                    Detail = reader["Detail"].ToString(),
                    UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString()),
                    UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString())
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<MaintainManageInfo> getBreakToolsBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<MaintainManageInfo> list = new List<MaintainManageInfo>();
            while (reader.Read())
            {
                list.Add(new MaintainManageInfo
                {
                    ToolSerialName = reader["ToolSerialName"].ToString(),
                    ToolModeName = reader["ToolModeName"].ToString(),
                    SendFixTime = reader["SendFixTime"].ToString(),
                    SuspendTime = reader["SuspendTime"].ToString(),
                    FinishFixTime = reader["FinishFixTime"].ToString(),
                    Status = reader["Status"].ToString(),
                    Detail = reader["Detail"].ToString(),
                    UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString()),
                    UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString())
                });

            }
            if (reader != null) reader.Close();
            return list;
        }

        public Dictionary<string, int> ConvertStr2Dic(string str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] kvList = str.Split(',');
            foreach (string kv in kvList)
            {
                string[] kvPair = kv.Split(':');
                if (kvPair.Length < 2)
                {
                    return null;
                }
                dic.Add(kvPair[0], int.Parse(kvPair[1]));
            }
            return dic;
        }

        public string ConvertDic2Str(Dictionary<string, int> dic)
        {
            if (dic == null) return "";
            List<string> kvList = new List<string>();
            foreach (var item in dic)
            {
                string kvPair = string.Join(":", new string[] { item.Key, item.Value.ToString() });
                kvList.Add(kvPair);
            }
            return string.Join(",", kvList.ToArray());
        }
    }
}
