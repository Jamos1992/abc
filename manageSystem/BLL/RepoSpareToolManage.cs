using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class RepoSpareToolManage
    {
        private RepoSpareToolService repoSpareToolService = new RepoSpareToolService();

        public RepoSpareTool QueryOneRepoSpare(string repoModel)
        {
            return repoSpareToolService.getOneRepoSpareToolFromDb(repoModel);
        }
        public List<string> GetSpareModelHintFromDb()
        {
            List<string> recordList = new List<string>();
            List<RepoSpareTool> list = repoSpareToolService.getAllRepoSpareTools();
            foreach (RepoSpareTool repoSpareTool in list)
            {
                recordList.Add(repoSpareTool.SpareToolModel);
            }
            return recordList;
        }

        public string ExportSingleData2Excel(string filePath, RepoSpareTool repoSpareTool)
        {
            int affected = repoSpareToolService.CreatRepoSpareToolExcelTable(filePath);
            if (affected < 1) return "创建导出文件失败";
            affected = repoSpareToolService.InsertRepoSpareTool2ExcelTable(filePath, repoSpareTool);
            if (affected < 1) return "导出数据失败";
            return "导出数据成功";
        }

        public string ExportBatchData2Excel(string filePath, RepoSpareTool[] repoSpareTools)
        {
            int i = 0;
            foreach (RepoSpareTool repoSpareTool in repoSpareTools)
            {
                if (repoSpareTool == null)
                {
                    continue;
                }
                if (i == 0)
                {
                    string result = ExportSingleData2Excel(filePath, repoSpareTool);
                    if (result.Contains("失败"))
                    {
                        return result;
                    }
                }
                else
                {
                    int affected = repoSpareToolService.InsertRepoSpareTool2ExcelTable(filePath, repoSpareTool);
                    if (affected < 1) return "导出数据失败";
                }
            }
            return "导出数据成功";
        }
    }
}
