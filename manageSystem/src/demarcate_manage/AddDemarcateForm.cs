using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace manageSystem.src.demarcate_manage
{
    public partial class AddDemarcateForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public AddDemarcateForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = false;
            dtDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtDemarcateDate.CustomFormat = " ";
        }

        private bool isToolsExist(string serialNum)
        {
            return toolsInfoManage.IsToolExistInDb(serialNum);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbSerialNum.Text == "" || cbCycle.Text == "" || dtDemarcateDate.Text == "")
            {
                MessageBox.Show("请填写工具序列号、标定周期和标定日期", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!isToolsExist(cbSerialNum.Text.Trim()))
            {
                MessageBox.Show($"序列号为{cbSerialNum.Text.Trim()}的工具不在仓库中", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string msg = demarcateRecordManage.AddOneDemarcateTool(getAllInput());
            if (msg != "提交成功")
            {
                MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            refreshDataViewGrid();
        }

        private DemarcateTools getAllInput()
        {
            return new DemarcateTools
            {
                SerialNum = cbSerialNum.Text.Trim(),
                Cycle = Convert.ToInt32(cbCycle.Text.Trim()),
                LastTime = dtDemarcateDate.Text.Trim(),
                NextTime = Convert.ToDateTime(dtDemarcateDate.Text.Trim()).AddDays(Convert.ToInt32(cbCycle.Text.Trim())).ToString("yyyy-MM-dd"),
                Status = "未标定"
            };
        }

        private void refreshDataViewGrid()
        {
            List<DemarcateTools> list = demarcateRecordManage.GetAllDemarcateTools();
            if (list == null)
            {
                dataGridView1.DataSource = new List<DemarcateTools>();
                dataGridView1.ClearSelection();
                //MessageBox.Show("数据不存在", "提示信息");
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            dataGridView1.ClearSelection();
        }

        private void AddDemarcateForm_Load(object sender, EventArgs e)
        {
            refreshDataViewGrid();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QRCodePrintForm qRCodePrintForm = new QRCodePrintForm();
            if (qRCodePrintForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private DemarcateRecords getDataFromGrid()
        {
            return null;
        }

        private void dtDemarcateDate_DropDown(object sender, EventArgs e)
        {
            dtDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtDemarcateDate.CustomFormat = "yyyy-MM-dd";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int errDelTimes = 0;
            DemarcateTools[] demarcateTools = getDemarcateToolsFromGrid();
            if (dataGridView1.Rows.Count == 0 || demarcateTools.Length == 0)
            {
                MessageBox.Show("无法删除，尚未选择删除的对象", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确认要删除选择的记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DemarcateTools tool in demarcateTools)
                {
                    int affected = demarcateRecordManage.DeleteOneDemarcateTools(tool);
                    if (affected < 1)
                    {
                        errDelTimes++;
                        Console.WriteLine($"{tool.SerialNum}工具的标定记录删除失败");
                    }
                }
                refreshDataViewGrid();
                if (errDelTimes > 0)
                {
                    MessageBox.Show($"有{errDelTimes}条记录删除失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private DemarcateTools[] getDemarcateToolsFromGrid()
        {
            List<DemarcateTools> ktls = new List<DemarcateTools>();
            int row = dataGridView1.Rows.Count;//得到总行数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue))
                {
                    ktls.Add(new DemarcateTools
                    {
                        SerialNum = dataGridView1.Rows[i].Cells["SerialNumCol"].Value.ToString(),
                        Cycle = int.Parse(dataGridView1.Rows[i].Cells["CycleCol"].Value.ToString()),
                        LastTime = dataGridView1.Rows[i].Cells["LastTimeCol"].Value.ToString(),
                        NextTime = dataGridView1.Rows[i].Cells["NextTimeCol"].Value.ToString(),
                        Status = dataGridView1.Rows[i].Cells["StatusCol"].Value.ToString()
                    });
                }
            }
            return ktls.ToArray();
        }

        private DemarcateTools getOneDemarcateToolFromGrid()
        {
            return new DemarcateTools
            {
                SerialNum = dataGridView1.SelectedRows[0].Cells["SerialNumCol"].Value.ToString(),
                Cycle = int.Parse(dataGridView1.SelectedRows[0].Cells["CycleCol"].Value.ToString()),
                LastTime = dataGridView1.SelectedRows[0].Cells["LastTimeCol"].Value.ToString(),
                NextTime = dataGridView1.SelectedRows[0].Cells["NextTimeCol"].Value.ToString(),
                Status = dataGridView1.SelectedRows[0].Cells["StatusCol"].Value.ToString()
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    DemarcateTools demarcateTools = getOneDemarcateToolFromGrid();
                    ModifyDemarcateToolForm modifyDemarcateToolForm = new ModifyDemarcateToolForm(demarcateTools);
                    modifyDemarcateToolForm.Text = "修改";
                    if(modifyDemarcateToolForm.ShowDialog() == DialogResult.OK)
                    {
                        refreshDataViewGrid();
                    }
                }
            }
        }
    }
}
