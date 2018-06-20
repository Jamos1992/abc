using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class OnCallRecordManage
    {
        private OnCallRecordService onCallRecordService = new OnCallRecordService();

        public int AddOnCallRecord(OnCallRecord onCallRecord)
        {
            return onCallRecordService.AddOnCallRecord(onCallRecord);
        }
        public List<OnCallRecord> GetAllOnCallRecords()
        {
            return onCallRecordService.getAllOnCallRecord();
        }

        public List<OnCallRecord> GetOnCallRecordBySql(string sql)
        {
            return onCallRecordService.getOnCallRecordBySql(sql);
        }

        public string ModifyOneRecord(OnCallRecord onCallRecord)
        {
            if(onCallRecord.CallTime == "" || onCallRecord.ArriveTime == "" || onCallRecord.ToolWorkstation == "")
            {
                return "保存失败，请补全信息";
            }
            int affectedRow = onCallRecordService.UpdateOnCallRecord(onCallRecord);
            if(affectedRow < 1)
            {
                return "保存失败，数据库操作失败";
            }
            return "保存成功";
        }

        public string ExportSingleData2Excel(string filePath, OnCallRecord onCallRecord)
        {
            int affected = onCallRecordService.CreateOnCallRecordExcelTable(filePath);
            if (affected < 1) return "创建导出文件失败";
            affected = onCallRecordService.InsertOnCallRecord2ExcelTable(filePath, onCallRecord);
            if (affected < 1) return "导出数据失败";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, OnCallRecord[] onCallRecords)
        {
            int i = 0;
            foreach (OnCallRecord onCallRecord in onCallRecords)
            {
                if (onCallRecord == null)
                {
                    continue;
                }
                if (i == 0)
                {
                    string result = ExportSingleData2Excel(filePath, onCallRecord);
                    if (result.Contains("失败"))
                    {
                        return result;
                    }
                }
                else
                {
                    int affected = onCallRecordService.InsertOnCallRecord2ExcelTable(filePath, onCallRecord);
                    if (affected < 1) return "导出数据失败";
                }
            }
            return "导出数据成功";
        }
    }
}
