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
            if (toolsInfo.SerialNum == "" || toolsInfo.Model == "" || toolsInfo.Workstation == "")
            {
                return "录入失败，请输入工具序列号、型号及工位信息！";
            }
            if (string.Compare(toolsInfo.MaintainContractDateStart, toolsInfo.MaintainContractDateEnd) > 0)
            {
                return "参数输入有误，保养起始日期应小于保养终止日期";
            }
            int affectedRow = toolsInfoService.AddTools(toolsInfo);
            if (affectedRow < 1)
            {
                return "录入失败，数据库操作失败！";
            }
            return "数据录入成功！";
        }

        public ToolsInfo QueryOneToolsInfo(string serialNum)
        {
            return toolsInfoService.getOneToolsInfoBySerial(serialNum);
        }

        public int UpdateOneToolsInfo(ToolsInfo toolsInfo,string serialNum)
        {
            return toolsInfoService.updateToolsInfo(toolsInfo, serialNum);
        }

        public List<string> GetModelHintFromDb()
        {
            List<string> recordList = new List<string>();
            List<ToolsInfo> list = toolsInfoService.getAllToolsInfo();
            foreach (ToolsInfo toolsInfo in list)
            {
                recordList.Add(toolsInfo.Model);
            }
            return recordList;
        }

        public List<string> GetSerialNumHintFromDb(string model)
        {
            List<string> recordList = new List<string>();
            List<ToolsInfo> list = toolsInfoService.getAllToolsInfoByModel(model);
            foreach (ToolsInfo toolsInfo in list)
            {
                recordList.Add(toolsInfo.Model);
            }
            return recordList;
        }

        public ToolsInfo QueryOneToolsInfoBySerialAndModel(string serial,string model)
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


    }
}
