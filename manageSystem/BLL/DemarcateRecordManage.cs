using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

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
            string sql = "select * from ToolsInfo,DemarcateTools where ToolsInfo.SerialNum = DemarcateTools.SerialNum";
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
    }
}
