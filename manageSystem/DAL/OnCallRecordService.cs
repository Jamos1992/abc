using System.Collections.Generic;
using System.Data.SQLite;
using Model;
using System.Configuration;
using Util;
using System;
using System.Reflection;

namespace DAL
{
    public class OnCallRecordService
    {
        public int AddOnCallRecord(OnCallRecord onCallRecord)
        {
            return SQLHelper.InsertValuesByStruct("OnCallRecord", onCallRecord);
        }

        public OnCallRecord getOneOnCallRecord()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("OnCallRecord");
            OnCallRecord onCallRecord = new OnCallRecord();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    onCallRecord.CallTime = Convert.ToDateTime(reader["CallTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                    onCallRecord.ArriveTime = Convert.ToDateTime(reader["ArriveTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                    onCallRecord.ToolSection = reader["ToolSection"].ToString();
                    onCallRecord.ToolWorkstation = reader["ToolWorkstation"].ToString();
                    onCallRecord.FaultToolName = reader["FaultToolName"].ToString();
                    onCallRecord.FaultReason = reader["FaultReason"].ToString();
                    onCallRecord.Detail = reader["Detail"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOneOnCallRecord failed, error message is: {ex.Message}");
                }

            }
            if (reader != null) reader.Close();
            return onCallRecord;
        }

        public List<OnCallRecord> getAllOnCallRecord()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("OnCallRecord");
            List<OnCallRecord> list = new List<OnCallRecord>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new OnCallRecord
                    {
                        CallTime = Convert.ToDateTime(reader["CallTime"].ToString()).ToString("yyyy-MM-dd HH:mm"),
                        ArriveTime = Convert.ToDateTime(reader["ArriveTime"].ToString()).ToString("yyyy-MM-dd HH:mm"),
                        ToolSection = reader["ToolSection"].ToString(),
                        ToolWorkstation = reader["ToolWorkstation"].ToString(),
                        FaultToolName = reader["FaultToolName"].ToString(),
                        FaultReason = reader["FaultReason"].ToString(),
                        Detail = reader["Detail"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllOnCallRecord failed, error message is: {ex.Message}");
                }   
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<OnCallRecord> getOnCallRecordBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<OnCallRecord> list = new List<OnCallRecord>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new OnCallRecord
                    {
                        CallTime = Convert.ToDateTime(reader["CallTime"].ToString()).ToString("yyyy-MM-dd HH:mm"),
                        ArriveTime = Convert.ToDateTime(reader["ArriveTime"].ToString()).ToString("yyyy-MM-dd HH:mm"),
                        ToolSection = reader["ToolSection"].ToString(),
                        ToolWorkstation = reader["ToolWorkstation"].ToString(),
                        FaultToolName = reader["FaultToolName"].ToString(),
                        FaultReason = reader["FaultReason"].ToString(),
                        Detail = reader["Detail"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOnCallRecordBySql failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public int UpdateOnCallRecord(OnCallRecord onCallRecord)
        {
            return SQLHelper.UpdateValuesByStruct("OnCallRecord", onCallRecord, new string[] { "ToolWorkstation" }, new string[] { onCallRecord.ToolWorkstation });
        }

        //excel operation
        public int CreateOnCallRecordExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ExcelDeclare.CreateOnCallRecordExcelSql);
        }

        public int InsertOnCallRecord2ExcelTable(string filePath, object obj)
        {
            string sql = ExcelDeclare.InsertOnCallRecordExcelSql;
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
