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

namespace manageSystem.src.demarcate_manage
{
    public partial class ModifyDemarcateToolForm : Form
    {
        private DemarcateTools demarcateTools = new DemarcateTools();
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private string cycle;
        private string lastTime;
        public ModifyDemarcateToolForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        public ModifyDemarcateToolForm(DemarcateTools tools)
        {
            demarcateTools = tools;
            InitializeComponent();
            dtpDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtpDemarcateDate.CustomFormat = "yyyy-MM-dd";
        }

        private void ModifyDemarcateToolForm_Load(object sender, EventArgs e)
        {
            cmbSerialNum.Text = demarcateTools.SerialNum;
            cmbCycle.Text = demarcateTools.Cycle.ToString();
            dtpDemarcateDate.Text = demarcateTools.LastTime;
            cycle = cmbCycle.Text.Trim();
            lastTime = dtpDemarcateDate.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {           
            if(cycle == cmbCycle.Text.Trim() && lastTime == dtpDemarcateDate.Text.Trim())
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            try
            {
                demarcateTools.SerialNum = cmbSerialNum.Text.Trim();
                demarcateTools.Cycle = int.Parse(cmbCycle.Text.Trim());
                demarcateTools.LastTime = dtpDemarcateDate.Text.Trim();
                demarcateTools.NextTime = Convert.ToDateTime(dtpDemarcateDate.Text.Trim()).AddDays(demarcateTools.Cycle).ToString("yyyy-MM-dd");
                int affected = demarcateRecordManage.UpdateOneDemarcateTool(demarcateTools);
                if(affected < 1)
                {
                    Console.WriteLine($"数据更新失败，影响行数：{affected}");
                    throw new Exception("数据更新失败");
                }
                affected = toolsInfoManage.UpdateCycleInToolsInfo(cmbSerialNum.Text.Trim(), Convert.ToInt32(cmbCycle.Text.Trim()));
                if(affected < 1)
                {
                    Console.WriteLine("更新工具的周期失败");
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
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
