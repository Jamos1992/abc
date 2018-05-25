using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class MaintainInfoManage
    {
        private MaintainManageInfoService maintainManageInfoService = new MaintainManageInfoService();
        public static string Repairing = MaintainManageInfoService.Repairing;
        public static string RepairFinished = MaintainManageInfoService.RepairFinished;
        public static string Suspend = MaintainManageInfoService.Suspend;
        public List<MaintainManageInfo> GetAllBreakTools()
        {
            return maintainManageInfoService.getAllBreakTools();
        }

        public List<MaintainManageInfo> GetAllBreakToolsBySql(string sql)
        {
            return maintainManageInfoService.getBreakToolsBySql(sql);
        }

        public string ExportSingleData2Excel(string filePath, MaintainManageInfo maintainManageInfo)
        {
            OutputStruct outputStruct = new OutputStruct()
            {
                ToolModeName = maintainManageInfo.ToolModeName,
                ToolSerialName = maintainManageInfo.ToolSerialName,
                SendFixTime = maintainManageInfo.SendFixTime,
                Status = maintainManageInfo.Status,
                Detail = maintainManageInfo.Detail
            };
            
            int affected = maintainManageInfoService.CreateMaintainManageInfoExcelTable(filePath);
            if (affected < 1) return "创建导出文件失败";
            affected = maintainManageInfoService.InsertMaintainManageInfo2ExcelTable(filePath, outputStruct);
            if (affected < 1) return "导出数据失败";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, MaintainManageInfo[] maintainManageInfos)
        {
            int i = 0;            
            foreach (MaintainManageInfo maintainManageInfo in maintainManageInfos)
            {
                if (maintainManageInfo == null)
                {
                    continue;
                }
                if (i == 0)
                {
                    string result = ExportSingleData2Excel(filePath, maintainManageInfo);
                    if (result.Contains("失败"))
                    {
                        return result;
                    }
                }
                else
                {
                    int affected = maintainManageInfoService.InsertMaintainManageInfo2ExcelTable(filePath, maintainManageInfo);
                    if (affected < 1) return "导出数据失败";
                }
            }
            return "导出数据成功";
        }
    }
}
