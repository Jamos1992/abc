using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SQLite;

namespace DAL
{
    public class CheckManService
    {
        public int InsertCheckMan(string name)
        {
            string sql = $"INSERT INTO CheckMan VALUES('{name}')";
            return SQLHelper.InsertTableBySql(sql);
        }

        public int DeleteOneWorker(string name)
        {
            string sql = $"delete from CheckMan where Name='{name}'";
            return SQLHelper.ExecuteNonQuery(sql);
        }

        public CheckMan GetCheckManByName(string name)
        {
            string sql = $"select * from CheckMan where Name='{name}'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            CheckMan checkMan = new CheckMan();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    checkMan.Name = reader["Name"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetCheckManByName failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return checkMan;
        }

        public List<CheckMan> GetAllCheckMan()
        {
            List<CheckMan> list = new List<CheckMan>();
            SQLiteDataReader reader = SQLHelper.ReadFullTable("CheckMan");
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new CheckMan
                    {
                        Name = reader["Name"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetAllCheckMan failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }
    }
}
