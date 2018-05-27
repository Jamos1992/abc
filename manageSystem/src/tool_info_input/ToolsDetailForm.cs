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

namespace manageSystem.src.tool_info_input
{
    public partial class ToolsDetailForm : Form
    {
        private ToolsInfo toolsInfo;
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public ToolsDetailForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        public ToolsDetailForm(ToolsInfo info)
        {
            InitializeComponent();
            toolsInfo = info;
        }

        private void ToolsDetailForm_Load(object sender, EventArgs e)
        {
            serialNumBox.Text = toolsInfo.SerialNum;
            modelBox.Text = toolsInfo.Model;
            categoryBox.Text = toolsInfo.Category;
            nameBox.Text = toolsInfo.Name;
            torqueMinBox.Text = toolsInfo.TorqueMin.ToString();
            torqueMaxBox.Text = toolsInfo.TorqueMax.ToString();
            accuracyBox.Text = toolsInfo.Accuracy.ToString();
            sectionBox.Text = toolsInfo.Section;
            cycleBox.Value = toolsInfo.DemarcateCycle;
            workstationBox.Text = toolsInfo.Workstation;
            statusBox.Text = toolsInfo.Status;
            qualityBox.Text = toolsInfo.QualityAssureDate;
            contractBox.Text = toolsInfo.MaintainContractStyle;
            maintainBox.Text = toolsInfo.MaintainContractDate;
            repairTimeBox.Value = toolsInfo.RepairTimes;
            repairBox.Text = toolsInfo.ChangeRecord;
            remarkBox.Text = toolsInfo.Remark;
            //allBoxReadOnly();
        }

        private void allBoxReadOnly()
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox || c is ComboBox || c is DateTimePicker || c is NumericUpDown)
                {
                    c.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = toolsInfoManage.UpdateOneToolsInfo(getAllInput());
            if (msg.Contains("失败"))
            {
                MessageBox.Show(msg);
                return;
            }     
            DialogResult = DialogResult.OK;
            Close();
        }

        private ToolsInfo getAllInput()
        {
            return new ToolsInfo()
            {
                SerialNum = serialNumBox.Text.Trim(),
                Model = modelBox.Text.Trim(),
                Category = categoryBox.Text.Trim(),
                Name = nameBox.Text.Trim(),
                TorqueMin = torqueMinBox.Text == "" ? 0 : int.Parse(torqueMinBox.Text.Trim()),
                TorqueMax = torqueMaxBox.Text == "" ? 0 : int.Parse(torqueMaxBox.Text.Trim()),
                Accuracy = accuracyBox.Text == "" ? 0 : int.Parse(accuracyBox.Text.Trim()),
                Section = sectionBox.Text.Trim(),
                DemarcateCycle = int.Parse(cycleBox.Value.ToString()),
                Workstation = workstationBox.Text.Trim(),
                Status = statusBox.Text.Trim(),
                QualityAssureDate = qualityBox.Text.Trim(),
                MaintainContractStyle = contractBox.Text.Trim(),
                MaintainContractDate = maintainBox.Text.Trim(),
                RepairTimes = int.Parse(repairTimeBox.Value.ToString()),
                ChangeRecord = repairBox.Text.Trim(),
                Remark = remarkBox.Text.Trim()
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
