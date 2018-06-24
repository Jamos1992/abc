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
    public partial class ModifyMaintainForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private MaintainInfo maintainInfo = new MaintainInfo();
        private string cycle;
        private string lastTime;
        public ModifyMaintainForm()
        {
            InitializeComponent();
        }
        public ModifyMaintainForm(MaintainInfo tools)
        {
            maintainInfo = tools;
            InitializeComponent();
            dtpMaintainDate.Format = DateTimePickerFormat.Custom;
            dtpMaintainDate.CustomFormat = "yyyy-MM-dd";
        }

        private void ModifyDemarcateToolForm_Load(object sender, EventArgs e)
        {
            cmbSerialNum.Text = maintainInfo.ToolSerialName;
            cmbCycle.Text = maintainInfo.Cycle.ToString();
            dtpMaintainDate.Text = maintainInfo.LastTime;
            cycle = cmbCycle.Text.Trim();
            lastTime = dtpMaintainDate.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cycle == cmbCycle.Text.Trim() && lastTime == dtpMaintainDate.Text.Trim())
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            try
            {
                maintainInfo.ToolSerialName = cmbSerialNum.Text.Trim();
                maintainInfo.Cycle = int.Parse(cmbCycle.Text.Trim());
                maintainInfo.LastTime = dtpMaintainDate.Text.Trim();
                maintainInfo.NextTime = Convert.ToDateTime(dtpMaintainDate.Text.Trim()).AddDays(maintainInfo.Cycle).ToString("yyyy-MM-dd");
                int affected = maintainInfoManage.UpdateOneMaintainInfo(maintainInfo);
                if (affected < 1)
                {
                    Console.WriteLine($"数据更新失败，影响行数：{affected}");
                    throw new Exception("数据更新失败");
                }
                //affected = toolsInfoManage.UpdateCycleInToolsInfo(cmbSerialNum.Text.Trim(), Convert.ToInt32(cmbCycle.Text.Trim()));
                //if (affected < 1)
                //{
                //    Console.WriteLine("更新工具的周期失败");
                //}
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败，原因：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
