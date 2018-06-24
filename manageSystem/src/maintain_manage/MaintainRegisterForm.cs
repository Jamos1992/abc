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

namespace manageSystem.src.maintain_manage
{
    public partial class MaintainRegisterForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public MaintainRegisterForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            setDateTimePickerEmpty(dtpDemarcateDate);
            dgvInPlan.AutoGenerateColumns = false;
            dgvNotInPlan.AutoGenerateColumns = false;
        }

        private void setDateTimePickerEmpty(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = " ";
        }

        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!toolsInfoManage.IsToolExistInDb(cmbSerialNum.Text.Trim()))
            {
                MessageBox.Show($"不存在序列号为{cmbSerialNum.Text.Trim()}的工具！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MaintainInfo maintainInfo = getAllInput();
            if (maintainInfo == null)
            {
                MessageBox.Show("请输入所有的必填信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int affected = maintainInfoManage.InsertOneMaintainInfo(maintainInfo);
            if(affected < 1)
            {
                MessageBox.Show("添加保养信息失败，原因：系统错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            refreshDateGridInPlan();
            refreshDataGridNotInPlan();
        }

        private void refreshDateGridInPlan()
        {
            List<MaintainInfo> maintainInfoList = maintainInfoManage.QueryAllMaintainInfo();
            if(maintainInfoList == null)
            {
                return;
            }
            dgvInPlan.DataSource = null;
            dgvInPlan.DataSource = maintainInfoList;
        }

        private void refreshDataGridNotInPlan()
        {
            List<ToolsInfo> toolsInfoList = maintainInfoManage.QueryAllMaintainNotInPlan();
            List<NotInPlanStruct> notInPlanStructList = new List<NotInPlanStruct>();
            if (toolsInfoList == null)
            {
                return;
            }
            int i = 0;
            foreach(ToolsInfo tool in toolsInfoList)
            {
                i++;
                notInPlanStructList.Add(new NotInPlanStruct
                {
                    ID = i,
                    SerialNum = tool.SerialNum,
                    Model = tool.Model,
                    Workstation = tool.Workstation
                });
            }
            dgvNotInPlan.DataSource = null;
            dgvNotInPlan.DataSource = notInPlanStructList;
        }

        private void dtpDemarcateDate_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dtpDemarcateDate);
        }

        private MaintainInfo getAllInput()
        {
            if (cmbSerialNum.Text.Trim() == "" || cmbCycle.Text.Trim() == "" || dtpDemarcateDate.Text.Trim() == "")
            {                
                return null;
            }
            return new MaintainInfo
            {
                ToolSerialName = cmbSerialNum.Text.Trim(),
                ToolModel = toolsInfoManage.QueryOneToolsInfo(cmbSerialNum.Text.Trim()).Model,
                ToolWorkstation = toolsInfoManage.QueryOneToolsInfo(cmbSerialNum.Text.Trim()).Workstation,
                Cycle = int.Parse(cmbCycle.Text.Trim()),
                LastTime = dtpDemarcateDate.Text,
                NextTime = Convert.ToDateTime(dtpDemarcateDate.Text).AddDays(int.Parse(cmbCycle.Text.Trim())).ToString("yyyy-MM-dd"),
                Status = ""
            };
        }

        private void MaintainRegisterForm_Load(object sender, EventArgs e)
        {
            refreshDateGridInPlan();
            refreshDataGridNotInPlan();
            if (tabDataView.SelectedIndex == 0) btnDel.Enabled = false;
        }

        private void tabDataView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabDataView.SelectedIndex == 0)
            {
                btnDel.Enabled = false;
            }
            else
            {
                btnDel.Enabled = true;
            }
        }

        private void dgvInPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInPlan.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dgvInPlan.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    MaintainInfo maintainInfo = getOneMaintainInfoFromGrid();
                    if (maintainInfo == null) return;
                    ModifyMaintainForm modifyMaintainForm = new ModifyMaintainForm(maintainInfo);
                    if (modifyMaintainForm.ShowDialog() == DialogResult.OK)
                    {
                        refreshDataGridNotInPlan();
                        refreshDateGridInPlan();
                    }
                }
            }
        }

        private MaintainInfo getOneMaintainInfoFromGrid()
        {
            if(dgvInPlan.SelectedRows.Count == 0)
            {
                return null;
            }
            List<MaintainInfo> maintainInfoList = maintainInfoManage.QueryOneMaintainBySerial(dgvInPlan.SelectedRows[0].Cells["ToolSerialNameCol"].Value.ToString());
            if (maintainInfoList == null)
            {
                MessageBox.Show("系统出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            if(maintainInfoList.Count >= 1)
            {
                return new MaintainInfo
                {
                    ToolSerialName =maintainInfoList[0].ToolSerialName,
                    Cycle = maintainInfoList[0].Cycle,
                    LastTime = maintainInfoList[0].LastTime
                };
            }
            return null;
        }
    }

    public class NotInPlanStruct
    {
        public int ID { get; set; }
        public string SerialNum { get; set; }
        public string Model { get; set; }
        public string Workstation { get; set; }
    }
}
