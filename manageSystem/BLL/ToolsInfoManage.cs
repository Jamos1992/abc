using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ToolsInfoManage
    {
        private ToolsInfoService toolsInfoService = new ToolsInfoService();
        public string InputOneToolsInfo(ToolsInfo toolsInfo)
        {
            if (toolsInfo.SerialNum == "" || toolsInfo.Model == "" || toolsInfo.Workstation == "" || toolsInfo.Section == "")
            {
                return "录入失败，请输入工具序列号、型号及工位信息！";
            }
            if (IsToolExistInDb(toolsInfo.SerialNum))
            {
                return "录入失败，该序列号已经存在！";
            }
            int affectedRow = toolsInfoService.AddTools(toolsInfo);
            if (affectedRow < 1)
            {
                return "录入失败，数据库操作失败！";
            }
            return "数据录入成功！";
        }

        public string UpdateOneToolsInfo(ToolsInfo toolsInfo)
        {
            if (toolsInfo.SerialNum == "" || toolsInfo.Model == "")
            {
                return "保存失败，请输入工具序列号、型号！";
            }
            int affectedRow = toolsInfoService.updateToolsInfo(toolsInfo);
            if(affectedRow < 1)
            {
                return "保存失败！";
            }
            return "保存成功";
        }

        public bool IsToolExistInDb(string serialNum)
        {
            return QueryOneToolsInfo(serialNum) != null;
        }

        public ToolsInfo QueryOneToolsInfo(string serialNum)
        {
            return toolsInfoService.getOneToolsInfoBySerial(serialNum);
        }

        public List<string> GetModelHintFromDb()
        {
            List<string> recordList = new List<string>();
            List<ToolsInfo> list = toolsInfoService.getAllToolsInfo();
            if(list == null)
            {
                return null;
            }
            foreach (ToolsInfo toolsInfo in list)
            {
                recordList.Add(toolsInfo.Model);
            }
            return recordList;
        }

        public List<ToolsInfo> GetAllToolsInfoFromDb()
        {
            return toolsInfoService.getAllToolsInfo();
        }

        public List<string> GetSectionHintFromDb()
        {
            return toolsInfoService.getAllSection();
        }

        public List<string> GetWorkstationHintFromDb(string section)
        {
            return toolsInfoService.getAllWorkstationBySection(section);
        }

        public List<string> GetSerialNumHintByWorkstationFromDb(string workstation)
        {
            return toolsInfoService.getAllSerilaNumByWorkstation(workstation);
        }

        public List<string> GetSerialNumHintFromDb(string model)
        {
            List<string> recordList = new List<string>();
            List<ToolsInfo> list = toolsInfoService.getAllToolsInfoByModel(model);
            if (list == null) return null;
            foreach (ToolsInfo toolsInfo in list)
            {
                recordList.Add(toolsInfo.SerialNum);
            }
            return recordList;
        }

        public List<ToolsInfo> QueryToolsInfoBySql(string sql)
        {
            return toolsInfoService.getAllToolsInfoBySql(sql);
        }

        public ToolsInfo QueryOneToolsInfoBySerialAndModel(string serial, string model)
        {
            if (string.IsNullOrEmpty(serial))
            {
                return null;
            }
            if (string.IsNullOrEmpty(model))
            {
                return toolsInfoService.getOneToolsInfoBySerial(serial);
            }
            return toolsInfoService.getOneToolsInfoBySerialAndModel(serial, model);
        }

        public string ExportSingleData2Excel(string filePath, ToolsInfo toolsInfo)
        {
            int affected = 0;
            try
            {
                affected = toolsInfoService.CreateToolsInfoExcelTable(filePath);
                Console.WriteLine("affected is {0}", affected);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"CreateToolsInfoExcelTable fail: {ex.Message}");
            }
            
            //if (affected < 1) return "创建导出文件失败";
            affected = toolsInfoService.InsertToolsInfo2ExcelTable(filePath, toolsInfo);
            if (affected < 1) return "导出数据失败";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, ToolsInfo[] toolsInfos)
        {
            int i = 0;
            foreach (ToolsInfo toolsInfo in toolsInfos)
            {
                if (toolsInfo == null)
                {
                    continue;
                }
                if (i == 0)
                {
                    string result = ExportSingleData2Excel(filePath, toolsInfo);
                    if (result.Contains("失败"))
                    {
                        return result;
                    }
                }
                else
                {
                    int affected = toolsInfoService.InsertToolsInfo2ExcelTable(filePath, toolsInfo);
                    if (affected < 1) return "导出数据失败";
                }
                i++;
            }
            return "导出数据成功";
        }

        public int GetToolsInfoCount(string filePath)
        {
            List<ToolsInfo> list = toolsInfoService.getAllToolsFromExcel(filePath);
            if (list == null) return 0;
            return list.Count;
        }

        public List<ToolsInfo> GetAllTools(string filePath)
        {
            return toolsInfoService.getAllToolsFromExcel(filePath);
        }

        public string ImportBatchTools2Db(string filePath)
        {
            List<ToolsInfo> list = GetAllTools(filePath);
            if (list == null) return "excel中不存在工具信息！";
            int totalCount = list.Count;
            int failCount = 0;
            int rowNum = 0;
            List<int> failRowNum = new List<int>();
            foreach(ToolsInfo toolsInfo in list)
            {
                rowNum++;
                string msg = InputOneToolsInfo(toolsInfo);
                if (msg.Contains("失败"))
                {
                    failCount++;
                    failRowNum.Add(rowNum);
                    Console.WriteLine(toolsInfo);
                    continue;
                }
            }
            string result = "工具总条数：" + totalCount.ToString() + ", 成功条数：" +
                (totalCount - failCount).ToString() + ", 失败条数：" + failCount.ToString() +
                "。\n\n";
            if(failCount > 0)
            {
                result += "失败的行数包括：";
                foreach (int num in failRowNum)
                {
                    result += "第" + num.ToString() + "行 ";
                }     
            }
            return result;
        }

        public int UpdateCycleInToolsInfo(string serialNum,int cycle)
        {
            return toolsInfoService.UpdateCycleInToolsInfo(serialNum, cycle);
        }
    }
}
