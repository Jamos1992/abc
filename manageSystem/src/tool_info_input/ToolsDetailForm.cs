using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace manageSystem.src.tool_info_input
{
    public partial class ToolsDetailForm : Form
    {
        private ToolsInfo toolsInfo;
        public ToolsDetailForm()
        {
            InitializeComponent();
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
            allBoxReadOnly();
        }

        private void allBoxReadOnly()
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    (c as TextBox).ReadOnly = true;
                }
                if(c is ComboBox)
                {
                    (c as ComboBox).DropDownStyle = ComboBoxStyle.Simple;
                    (c as ComboBox).Enabled = false;
                }
            }
        }
    }
}
