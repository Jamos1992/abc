using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace manageSystem.src.spare_manage
{
    public partial class SpareRecommandForm : Form
    {
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public SpareRecommandForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void SpareRecommandForm_Load(object sender, EventArgs e)
        {
            List<SpareToolUseHistory> list = repoSpareToolManage.GetSpareToolUseHistoryByDays(90);
            if (list != null) dataVSeaon.DataSource = list;

            List<HalfYear> halfYears = getTopThreeRepair();
            if (halfYears != null) dataVHalfYear.DataSource = list;
        }

        private List<HalfYear> getTopThreeRepair()
        {
            List<HalfYear> halfYearList = new List<HalfYear>();
            List<OutputStruct> outputStructs = maintainInfoManage.GetBreakToolBySql($"select distinct ToolModeName from RepairHistory");
            if (outputStructs != null)
            {
                foreach (OutputStruct o in outputStructs)
                {
                    int total = 0;
                    int breakNum = 0;
                    double partion = 0;
                    List<ToolsInfo> toolsInfos = toolsInfoManage.QueryToolsInfoBySql($"select * from ToolsInfo where Model='{o.ToolModeName}'");
                    if (toolsInfos != null) total = toolsInfos.Count;

                    List<OutputStruct> outs = maintainInfoManage.GetBreakToolBySql($"select * from RepairHistory where ToolModeName='{o.ToolModeName}'");
                    if (outs != null) breakNum = outs.Count;

                    if (total > 0) partion = breakNum / total;
                    halfYearList.Add(new HalfYear
                    {
                        ModelName = o.ToolModeName,
                        partion = partion.ToString()
                    });
                }
            }
            halfYearList.Sort();
            return halfYearList;
        }


    }

    public class HalfYear
    {
        public string ModelName { get; set; }               //型号
        public string partion { get; set; }                 //比例
    }
}
