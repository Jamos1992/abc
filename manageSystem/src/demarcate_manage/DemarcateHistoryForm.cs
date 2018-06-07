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
    public partial class DemarcateHistoryForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private List<ToolsInfo> toolsInfoList = new List<ToolsInfo>();
        public DemarcateHistoryForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void DemarcateHistoryForm_Load(object sender, EventArgs e)
        {
            toolsInfoList = toolsInfoManage.GetAllToolsInfoFromDb();
            dataGridView1.DataSource = toolsInfoList;
            dataGridView1.ClearSelection();
        }
    }


}
