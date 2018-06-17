using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateHintForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private List<DemarcateTools> demarcateToolList = new List<DemarcateTools>();
        public DemarcateHintForm()
        {
            InitializeComponent();
        }

        private void DemarcateHintForm_Load(object sender, EventArgs e)
        {
            demarcateToolList = demarcateRecordManage.GetAllDemarcateTools();
            List<DemarcateTools> unFinisnedList = new List<DemarcateTools>();
            List<DemarcateTools> todayList = new List<DemarcateTools>();
            List<DemarcateTools> weekList = new List<DemarcateTools>();
            foreach (DemarcateTools tool in demarcateToolList)
            {
                if(Convert.ToDateTime(tool.NextTime) < DateTime.Now)
                {
                    unFinisnedList.Add(tool);
                }else if(Convert.ToDateTime(tool.NextTime) == DateTime.Now)
                {
                    todayList.Add(tool);
                }else if(Convert.ToDateTime(tool.NextTime) >= DateTime.Now.AddDays(-int.Parse(DateTime.Now.DayOfWeek.ToString())) 
                    && Convert.ToDateTime(tool.NextTime) <= DateTime.Now.AddDays(7-int.Parse(DateTime.Now.DayOfWeek.ToString())))
                {
                    weekList.Add(tool);
                }
            }
            MessageBox.Show("111");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = unFinisnedList;
        }
    }
}
