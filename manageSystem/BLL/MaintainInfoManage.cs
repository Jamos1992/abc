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
        private RepoSpareToolService repoSpareToolService = new RepoSpareToolService();
        public static string Repairing = MaintainManageInfoService.Repairing;
        public static string RepairFinished = MaintainManageInfoService.RepairFinished;
        public static string Suspend = MaintainManageInfoService.Suspend;
        public List<OutputStruct> GetAllBreakTools()
        {
            return maintainManageInfoService.getAllBreakTools();
        }

        public List<OutputStruct> GetAllBreakToolsBySql(string sql)
        {
            return maintainManageInfoService.getBreakToolsBySql(sql);
        }

        public MaintainManageInfo GetOneBreakToolFromDb(string serialNum)
        {
            return maintainManageInfoService.getOneBreakToolFromDb(serialNum);
        }

        public List<string> GetSerialNameHintFromDb()
        {
            List<string> recordList = new List<string>();
            List<OutputStruct> list = maintainManageInfoService.getAllBreakTools();
            foreach (OutputStruct outputStruct in list)
            {
                recordList.Add(outputStruct.ToolSerialName);
            }
            return recordList;
        }

        public int UpdateBreakToolStatus(MaintainManageInfo maintainManageInfo)
        {
            return maintainManageInfoService.UpdateMaintainStatus(maintainManageInfo);
        }

        public string UpdateBreakToolInfo(MaintainManageInfo maintainManageInfo)
        {
            if (!new MaintainManageInfoService().IsNotFinishBreakToolExist(maintainManageInfo))
            {
                return "名称为" + maintainManageInfo.ToolSerialName + "的工具不存在！";
            }
            if (maintainManageInfo.UsedRepoSpareToolInfo == null)
            {
                maintainManageInfoService.UpdateMaintainStatus(maintainManageInfo);
                return "未使用任何零件";
            }
            foreach (var item in maintainManageInfo.UsedRepoSpareToolInfo)
            {
                RepoSpareTool repoSpareTool = repoSpareToolService.getOneRepoSpareToolFromDb(item.Key);
                if (repoSpareTool == null)
                {
                    return "数据库中不包含型号为：" + item.Key + "的备件信息";
                }
                if (repoSpareTool.Num < item.Value)
                {
                    return "数据库中型号为：" + item.Key + "的备件个数不足" + item.Value.ToString() + "个";
                }
            }
            try
            {
                maintainManageInfoService.UpdateMaintainManageInfo(maintainManageInfo);
                if (maintainManageInfo.Status != "挂起")
                {
                    foreach (var item in maintainManageInfo.UsedRepoSpareToolInfo)
                    {
                        RepoSpareTool repoSpareTool = repoSpareToolService.getOneRepoSpareToolFromDb(item.Key);
                        int num = repoSpareTool.Num - item.Value;
                        Console.WriteLine("num is {0}", num);
                        int affectedRow = repoSpareToolService.updateRepoSpareToolNum(num, item.Key);
                        if (affectedRow < 1)
                        {
                            return "更新数据库失败！";
                        }
                    }
                }
                return "挂起";
            }
            catch
            {
                return "error";
            }
        }

        public string RegisterBreakTool(MaintainManageInfo maintainManageInfo)
        {
            if (maintainManageInfo.ToolModeName == "" || maintainManageInfo.ToolSerialName == "" || maintainManageInfo.SendFixTime == "" || maintainManageInfo.Detail == "")
            {
                return "录入失败，请补全所有信息！";
            }
            try
            {
                if (maintainManageInfoService.IsNotFinishBreakToolExist(maintainManageInfo))
                {
                    return "登记失败，该工具已经在维修中！";
                }
                int affected = maintainManageInfoService.AddMaintainManageInfo(maintainManageInfo);
                if (affected < 1)
                {
                    return "录入失败！";
                }
                return "数据录入成功！";
            }
            catch
            {
                return "error";
            }
        }

        //excel operation
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
