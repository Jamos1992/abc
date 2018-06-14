using System.Collections.Generic;
using Model;
using System.Data.SQLite;
using System.Configuration;
using Util;
using System;

namespace DAL
{
    public class RepoSpareToolService
    {

        public bool IsRepoSpareToolExist(string spareToolModel)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("RepoSpareTool", new string[] { "*" }, new string[] { "SpareToolModel" }, new string[] { "=" }, new string[] { $"'{spareToolModel}'" });
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
            string sql = "update RepoSpareTool set Num=" + num.ToString() + " where SpareToolModel='" + spareToolModel + "'";
            return SQLHelper.UpdateTableBySql(sql);
        }

        public RepoSpareTool getOneRepoSpareToolFromDb(string spareToolModel)
        {
            string sql = "select * from RepoSpareTool where SpareToolModel='" + spareToolModel + "'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            RepoSpareTool repoSpareTool = new RepoSpareTool();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    repoSpareTool.SpareToolModel = reader["SpareToolModel"].ToString();
                    repoSpareTool.Num = reader["Num"].ToString() != "" ? int.Parse(reader["Num"].ToString()) : 0;
                    repoSpareTool.AddTime = Convert.ToDateTime(reader["Time"].ToString()).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOneRepoSpareToolFromDb failed, error message is: {ex.Message}");
                }                
            }
            if (reader != null) reader.Close();
            return repoSpareTool;
        }

        public List<RepoSpareTool> getAllRepoSpareTools()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("RepoSpareTool");
            List<RepoSpareTool> list = new List<RepoSpareTool>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new RepoSpareTool
                    {
                        SpareToolModel = reader["SpareToolModel"].ToString(),
                        Num = reader["Num"].ToString() != "" ? int.Parse(reader["Num"].ToString()) : 0,
                        AddTime = Convert.ToDateTime(reader["Time"].ToString()).ToString("yyyy-MM-dd")
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllRepoSpareTools failed, error message is: {ex.Message}");
                }    
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<RepoSpareTool> getRepoSpareToolBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<RepoSpareTool> list = new List<RepoSpareTool>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new RepoSpareTool
                    {
                        SpareToolModel = reader["SpareToolModel"].ToString(),
                        Num = reader["Num"].ToString() != "" ? int.Parse(reader["Num"].ToString()) : 0,
                        AddTime = Convert.ToDateTime(reader["Time"].ToString()).ToString("yyyy-MM-dd")
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getRepoSpareToolBySql failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        //excel operation
        public int CreatRepoSpareToolExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ExcelDeclare.CreateRepoSpareToolExcelSql);
        }

        public int InsertRepoSpareTool2ExcelTable(string filePath, object obj)
        {
            string sql = ExcelDeclare.InsertRepoSpareToolsExcelSql;
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }
    }
}
