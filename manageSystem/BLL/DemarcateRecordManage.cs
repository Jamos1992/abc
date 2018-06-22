using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using Util;

namespace BLL
{
    public class DemarcateRecordManage
    {
        private DemarcateRecordService demarcateRecordService = new DemarcateRecordService();

        public bool IsDemarcateToolExist(string serialNum)
        {
            return demarcateRecordService.IsToolExistInDemarcateTools(serialNum);
        }

        public string AddOneDemarcateTool(DemarcateTools demarcateTools)
        {
            try
            {
                if (demarcateRecordService.IsToolExistInDemarcateTools(demarcateTools.SerialNum))
                {
                    return "记录已经存在！";
                }
                int affectedRow = demarcateRecordService.InsertDemarcateTools2Db(demarcateTools);
                if (affectedRow < 1)
                {
                    return "添加数据库失败，数据库操作失败";
                }
                return "提交成功";
            }
            catch
            {
                return "error";
            }   
        }

        public List<DemarcateTools> GetAllDemarcateTools()
        {
            return demarcateRecordService.GetAllDemarcateTools();
        }

        public List<ToolsInfo> GetallDemarcateToolsWithInfo()
        {
            string sql = $"select * from ToolsInfo,DemarcateTools where ToolsInfo.SerialNum = DemarcateTools.SerialNum and DemarcateTools.Status!='{DemarcateStatusDeclare.OffGrade}'";
            return demarcateRecordService.GetAllDemarcateToolsBySql(sql);
        }

        public List<ToolsInfo> GetallDemarcateToolsWithInfoBySql(string sql)
        {
            return demarcateRecordService.GetAllDemarcateToolsBySql(sql);
        }

        public DemarcateTools getOneDemarcateToolBySerialNum(string serialNum)
        {
            return demarcateRecordService.GetOneDemarcateTool(serialNum);
        }

        public int DeleteOneDemarcateTools(DemarcateTools demarcateTools)
        {
            return demarcateRecordService.DeleteOneDemarcateTools(demarcateTools);
        }

        public int UpdateOneDemarcateTool(DemarcateTools demarcateTools)
        {
            return demarcateRecordService.UpdateOneDemarcateTools(demarcateTools);
        }

        public int UpdateOneDemarcateToolBySql(string sql)
        {
            return demarcateRecordService.UpdateOneDemarcateToolBySql(sql);
        }

        public int AddDemarcateHistory(DemarcateHistory demarcateHistory)
        {
            return demarcateRecordService.InsertDemarcateHistory(demarcateHistory);
        }

        public List<DemarcateHistory> GetAllDemarcateHistories()
        {
            List<DemarcateHistory> demarcateHistories = new List<DemarcateHistory>();
            List<DemarcateTools> toolList = GetAllDemarcateTools();
            if(toolList == null)
            {
                return null;
            }
            foreach(DemarcateTools tool in toolList)
            {
                List<DemarcateHistory> demarcateHistoryList = GetDemarcateHistoriesBySerial(tool.SerialNum);
                if (demarcateHistoryList != null)
                {
                    demarcateHistories.AddRange(demarcateHistoryList);
                }
            }
            if (demarcateHistories.Count == 0) return null;
            return demarcateHistories;
        }

        public List<DemarcateHistory> GetDemarcateHistoriesBySerial(string serialNum)
        {
            return demarcateRecordService.GetDemarcateHistoriesBySerial(serialNum);
        }

        //excel operation
        public string ExportSingleData2Excel(string filePath, DemarcateHistory demarcateHistory)
        {
            int affected = 0;
            try
            {
                affected = demarcateRecordService.CreateDemarcateHistoryExcelTable(filePath);
                //if (affected < 1) return "创建导出文件失败";
            }catch(Exception ex)
            {
                Console.WriteLine($"CreateMaintainManageInfoExcelTable fail: {ex.Message}");
            }           
            affected = demarcateRecordService.InsertDemarcateHistory2ExcelTable(filePath, demarcateHistory);
            if (affected < 1) return "导出数据失败1";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, DemarcateHistory[] DemarcateHistories)
        {
            int i = 0;
            foreach (DemarcateHistory demarcateHistory in DemarcateHistories)
            {
                if (demarcateHistory == null)
                {
                    continue;
                }
                if (i == 0)
                {
                    string result = ExportSingleData2Excel(filePath, demarcateHistory);
                    if (result.Contains("失败"))
                    {
                        return result;
                    }
                }
                else
                {
                    int affected = demarcateRecordService.InsertDemarcateHistory2ExcelTable(filePath, demarcateHistory);
                    if (affected < 1) return "导出数据失败2";
                }
                i++;
            }
            return "导出数据成功";
        }
    }
}
