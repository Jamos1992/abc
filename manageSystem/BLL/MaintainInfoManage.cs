using DAL;
using Model;
using System;
using System.Collections.Generic;
using Util;

namespace BLL
{
    public class MaintainInfoManage
    {
        private MaintainManageInfoService maintainManageInfoService = new MaintainManageInfoService();
        private RepoSpareToolService repoSpareToolService = new RepoSpareToolService();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
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

        public List<OutputStruct> GetBreakToolBySql(string sql)
        {
            return maintainManageInfoService.getBreakToolsBySql(sql);
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
                if (maintainManageInfo.Status != MaintainDeclare.Suspend)
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
                        SpareToolUseHistory spareToolUseHistory = new SpareToolUseHistory();
                        spareToolUseHistory.SpareToolModel = item.Key;
                        spareToolUseHistory.Num = item.Value;
                        spareToolUseHistory.UseTime = DateTime.Now.ToString("yyyy-MM-dd");
                        affectedRow = repoSpareToolManage.InsertSpareUseHistory(spareToolUseHistory);
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
            if (maintainManageInfo.ToolSerialName == "" || maintainManageInfo.SendFixTime == "" || maintainManageInfo.Detail == "")
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

        public int DeleteOneRegisterTools(string serialNum)
        {
            return maintainManageInfoService.DeleteOneRegisterTools(serialNum);
        }

        //保养
        public int InsertOneMaintainInfo(MaintainInfo maintainInfo)
        {
            return maintainManageInfoService.InsertOneMaintainTool(maintainInfo);
        }
        
        public int UpdateOneMaintainInfo(MaintainInfo maintainInfo)
        {
            return maintainManageInfoService.updateOneMaintainTool(maintainInfo);
        }

        public List<MaintainInfo> QueryOneMaintainBySerial(string serial)
        {
            string sql = $"select * from MaintainInfo where ToolSerialName='{serial}'";
            return maintainManageInfoService.QueryMaintainBySql(sql);
        }

        public List<MaintainInfo> QueryAllMaintainInfo()
        {
            string sql = $"select * from MaintainInfo";
            return maintainManageInfoService.QueryMaintainBySql(sql);
        }

        public List<ToolsInfo> QueryAllMaintainNotInPlan()
        {
            string sql = $"select * from ToolsInfo where SerialNum not in (select ToolSerialName from MaintainInfo)";
            return toolsInfoManage.QueryToolsInfoBySql(sql);
        }

        //excel operation
        public string ExportSingleData2Excel(string filePath, OutputStruct maintainManageInfo)
        {
            OutputStruct outputStruct = new OutputStruct()
            {
                ToolModeName = maintainManageInfo.ToolModeName,
                ToolSerialName = maintainManageInfo.ToolSerialName,
                SendFixTime = maintainManageInfo.SendFixTime,
                Status = maintainManageInfo.Status,
                Detail = maintainManageInfo.Detail
            };
            int affected = 0;
            try
            {
                affected = maintainManageInfoService.CreateMaintainManageInfoExcelTable(filePath);
                //if (affected < 1) return "创建导出文件失败";
            }
            catch(Exception ex)
            {
                Console.WriteLine($"CreateMaintainManageInfoExcelTable fail: {ex.Message}");
            }
            
            affected = maintainManageInfoService.InsertMaintainManageInfo2ExcelTable(filePath, outputStruct);
            if (affected < 1) return "导出数据失败";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, OutputStruct[] maintainManageInfos)
        {
            int i = 0;            
            foreach (OutputStruct maintainManageInfo in maintainManageInfos)
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
                i++;
            }
            return "导出数据成功";
        }
    }
}
