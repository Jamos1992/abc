using System.Collections.Generic;
using System.Data.SQLite;
using Model;
using System.Configuration;

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
                onCallRecord.CallTime = reader["CallTime"].ToString();
                onCallRecord.ArriveTime = reader["ArriveTime"].ToString();
                onCallRecord.FaultToolName = reader["FaultToolName"].ToString();
                onCallRecord.FaultReason = reader["FaultReason"].ToString();
                onCallRecord.Detail = reader["Detail"].ToString();
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
                list.Add(new OnCallRecord
                {
                    CallTime = reader["CallTime"].ToString(),
                    ArriveTime = reader["ArriveTime"].ToString(),
                    FaultToolName = reader["FaultToolName"].ToString(),
                    FaultReason = reader["FaultReason"].ToString(),
                    Detail = reader["Detail"].ToString()
                });
                
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
                list.Add(new OnCallRecord
                {
                    CallTime = reader["CallTime"].ToString(),
                    ArriveTime = reader["ArriveTime"].ToString(),
                    FaultToolName = reader["FaultToolName"].ToString(),
                    FaultReason = reader["FaultReason"].ToString(),
                    Detail = reader["Detail"].ToString()
                });

            }
            if (reader != null) reader.Close();
            return list;
        }

        //excel operation
        public int CreateOnCallRecordExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ConfigurationManager.AppSettings["CreateOnCallRecordExcelString"]);
        }

        public int InsertOnCallRecord2ExcelTable(string filePath, object obj)
        {
            string sql = "insert into 巡线记录(客户呼叫时间,达到现场时间,故障工具,故障原因,备注)";
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }
    }
}
