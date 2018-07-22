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
        public SpareRecommandForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void SpareRecommandForm_Load(object sender, EventArgs e)
        {
            List<SpareToolUseHistory> list = repoSpareToolManage.GetSpareToolUseHistoryByDays(90);
            if (list == null) return;
            dataVSeaon.DataSource = list;

            maintainInfoManage.GetBreakToolBySql("")
        }

        private List<HalfYear> getTopThreeRepair()
        {
             
        }


    }

    public class HalfYear
    {
        public string ModelName { get; set; }               //型号
        public string partion { get; set; }                    //比例
    }
}
