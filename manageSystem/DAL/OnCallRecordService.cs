using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;

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
    }
}
