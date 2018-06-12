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
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private List<ToolsInfo> toolsInfoList = new List<ToolsInfo>();
        public DemarcateHistoryForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void DemarcateHistoryForm_Load(object sender, EventArgs e)
        {
            toolsInfoList = demarcateRecordManage.GetallDemarcateToolsWithInfo();
            dataGridView1.DataSource = toolsInfoList;
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ToolsInfo> list = new List<ToolsInfo>();
            if (txtWorkstation.Text == "" && txtSerialNum.Text == "" && txtModel.Text == "")
            {
                list = demarcateRecordManage.GetallDemarcateToolsWithInfo();
            }
            else
            {
                string sql = "select * from ToolsInfo, DemarcateTools where ToolsInfo.SerialNum = DemarcateTools.SerialNum";
                if (txtWorkstation.Text != "")
                {
                    sql += " and Workstation like '%" + txtWorkstation.Text.Trim() + "%'";
                }
                if (txtModel.Text != "")
                {
                    sql += " and Model like '%" + txtModel.Text.Trim() + "%'";
                }
                if(txtSerialNum.Text != "")
                {
                    sql += " and DemarcateTools.SerialNum like '%" + txtSerialNum.Text.Trim() + "%'";
                }
                list = demarcateRecordManage.GetallDemarcateToolsWithInfoBySql(sql);
            }
            if (list == null)
            {
                dataGridView1.DataSource = new List<RepoSpareTool>();
                MessageBox.Show("记录不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BindData2Grid(list);
        }

        private void BindData2Grid(List<ToolsInfo> list)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    SingleHistoryForm singleHistoryForm = new SingleHistoryForm();
                    singleHistoryForm.Text = "工具" + getSerialNumFromGrid() + "的历史标定记录";
                    singleHistoryForm.ShowDialog();
                }
            }
        }

        private string getSerialNumFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return "";
            return dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }


}
