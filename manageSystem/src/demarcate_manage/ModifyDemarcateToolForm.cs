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
        }

        public ModifyDemarcateToolForm(DemarcateTools tools)
        {
            demarcateTools = tools;
            InitializeComponent();
            dtDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtDemarcateDate.CustomFormat = "yyyy-MM-dd";
        }

        private void ModifyDemarcateToolForm_Load(object sender, EventArgs e)
        {
            cbSerialNum.Text = demarcateTools.SerialNum;
            cbCycle.Text = demarcateTools.Cycle.ToString();
            dtDemarcateDate.Text = demarcateTools.LastTime;
            cycle = cbCycle.Text.Trim();
            lastTime = dtDemarcateDate.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {           
            if(cycle == cbCycle.Text.Trim() && lastTime == dtDemarcateDate.Text.Trim())
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            try
            {
                demarcateTools.SerialNum = cbSerialNum.Text.Trim();
                demarcateTools.Cycle = int.Parse(cbCycle.Text.Trim());
                demarcateTools.LastTime = dtDemarcateDate.Text.Trim();
                demarcateTools.NextTime = Convert.ToDateTime(dtDemarcateDate.Text.Trim()).AddDays(demarcateTools.Cycle).ToString("yyyy-MM-dd");
                int affected = demarcateRecordManage.UpdateOneDemarcateTool(demarcateTools);
                if(affected < 1)
                {
                    Console.WriteLine($"数据更新失败，影响行数：{affected}");
                    throw new Exception("数据更新失败");
                }
                affected = toolsInfoManage.UpdateCycleInToolsInfo(cbSerialNum.Text.Trim(), Convert.ToInt32(cbCycle.Text.Trim()));
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
