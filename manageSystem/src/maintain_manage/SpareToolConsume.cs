using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace manageSystem.src.maintain_manage
{
    class Error
    {
        public string msg;
        public int num;
    }

    class SpareToolConsume
    {
        private SqLiteHelper db;

        public SpareToolConsume()
        {
            db = new SqLiteHelper(Declare.DbConnectionString);
        }

        #region 更新备件数据库
        public Error UpdateRepoSpareToolDb(MaintainManageInfo maintainManageInfo)
        {
            //确保所有的备件信息都是正确的！
            if (maintainManageInfo.UsedRepoSpareToolInfo == null) return null;
            foreach (var item in maintainManageInfo.UsedRepoSpareToolInfo)
            {
                Error error = caculateSpareToolNum(item.Key, item.Value);
                if (error.msg != null) return error;
            }
            //在上一步确认后，再进行更新数据库操作，因为这个操作应该是原子的
            foreach(var item in maintainManageInfo.UsedRepoSpareToolInfo)
            {
                Error error = updateRepoSpareToolDb(item.Key,item.Value, caculateSpareToolNum(item.Key, item.Value).num);
                if (error.msg != null) return error;
            }
            return null;
        }
        #endregion

        #region 更新维修数据库
        public Error UpdateMaintainManageInfo(MaintainManageInfo maintainManageInfo)
        {
            string usedRepoSpareToolInfo = ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
            string usedOtherSpareToolInfo = ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            string sql = "update MaintainManageInfo set UsedRepoSpareToolInfo='" + usedRepoSpareToolInfo + "', UsedOtherSpareToolInfo='" + usedOtherSpareToolInfo + "', Status='" + maintainManageInfo.Status +"' where ToolSerialName='" + maintainManageInfo.ToolSerialName + "'";
            SQLiteDataReader reader = db.UpdateTableBySql(sql);
//            if (reader == null || !reader.HasRows) return new Error { msg = "更新失败" };
            return null;
        }
        #endregion

        #region 数据库中获取挂起信息
        public MaintainManageInfo GetSuspendInfoFromDb(string serialNum)
        {
            string sql = "select * from MaintainManageInfo where ToolSerialName='" + serialNum + "'";
            SQLiteDataReader reader = db.ReadTableBySql(sql);
            if (reader == null || !reader.HasRows) return null;
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            try
            {
                if (reader.Read())
                {
                    maintainManageInfo.ToolModeName = reader["ToolModeName"].ToString();
                    maintainManageInfo.ToolSerialName = reader["ToolSerialName"].ToString();
                    maintainManageInfo.UsedRepoSpareToolInfo = ConvertStr2Dic(reader["UsedRepoSpareToolInfo"].ToString());
                    maintainManageInfo.UsedOtherSpareToolInfo = ConvertStr2Dic(reader["UsedOtherSpareToolInfo"].ToString());
                }                
            }
            catch
            {
                Console.WriteLine("GetSuspendInfoFromDb fail");
                return null;
            }
            return maintainManageInfo;
        }
        //把string类型的字符串（以逗号分隔），转化为dic。
        #endregion

        private Error caculateSpareToolNum(string key,int value)
        {
            string sql = "select Num from RepoSpareTool where SpareToolModel='" + key + "'";
            SQLiteDataReader reader = db.ReadTableBySql(sql);
            if (reader == null || !reader.HasRows) return new Error { msg="数据库中不包含型号为："+key +"的备件信息" };
            int numInDb = reader.GetInt32(reader.GetOrdinal("Num"));
            if (numInDb < value) return new Error { msg = "数据库中型号为：" + key + "的备件个数不足"+value.ToString()+"个" };
            return new Error { num = numInDb };
        }

        private Error updateRepoSpareToolDb(string key, int value,int numInDb)
        {
            numInDb = numInDb - value;
            string sql = "update RepoSpareTool set Num=" + numInDb.ToString() + "where SpareToolModel='" + key + "'";
            SQLiteDataReader read = db.UpdateTableBySql(sql);
            if (read == null || !read.HasRows) return new Error { msg = "更新数据库中型号为：" + key + "的备件信息失败" };
            return null; 

        }

        public Dictionary<string,int> ConvertStr2Dic(string str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] kvList = str.Split(',');
            foreach(string kv in kvList)
            {
                string[] kvPair = kv.Split(':');
                if(kvPair.Length < 2)
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
