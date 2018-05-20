using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SQLite;

namespace DAL
{
    public class RepoSpareToolService
    {

        public bool IsRepoSpareToolExist(string spareToolModel)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("RepoSpareTool", new string[] { "*" }, new string[] { "SpareToolModel" }, new string[] { "=" }, new string[] { spareToolModel });
            if (reader != null && reader.HasRows)
            {
                //MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！");
                reader.Close();
                return true;
            }
            return false;
        }
        public int AddRepoSpareTool(RepoSpareTool repoSpareTool)
        {
            return SQLHelper.InsertValuesByStruct("RepoSpareTool", repoSpareTool);
        }

        public int updateRepoSpareToolNum(int num, string spareToolModel)
        {
            string sql = "update RepoSpareTool set Num=" + num.ToString() + "where SpareToolModel='" + spareToolModel + "'";
            return SQLHelper.UpdateTableBySql(sql);
        }

        public RepoSpareTool getOneRepoSpareToolFromDb(string spareToolModel)
        {
            string sql = "select * from RepoSpareTool where SpareToolModel='" + spareToolModel + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            RepoSpareTool repoSpareTool = new RepoSpareTool();
            while (reader.Read())
            {
                repoSpareTool.SpareToolModel = reader["SpareToolModel"].ToString();
                repoSpareTool.Num = (int)reader["Num"];
                repoSpareTool.Time = reader["Time"].ToString();
            }
            if (reader != null) reader.Close();
            return repoSpareTool;
        }

        public List<RepoSpareTool> getAllRepoSpareTools()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("RepoSpareTool");
            List<RepoSpareTool> list = new List<RepoSpareTool>();
            while (reader.Read())
            {
                list.Add(new RepoSpareTool
                {
                    SpareToolModel = reader["SpareToolModel"].ToString(),
                    Num = (int)reader["Num"],
                    Time = reader["Time"].ToString()
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<RepoSpareTool> getRepoSpareToolBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<RepoSpareTool> list = new List<RepoSpareTool>();
            while (reader.Read())
            {
                list.Add(new RepoSpareTool
                {
                    SpareToolModel = reader["SpareToolModel"].ToString(),
                    Num = (int)reader["Num"],
                    Time = reader["Time"].ToString()
                });

            }
            if (reader != null) reader.Close();
            return list;
        }
    }
}
