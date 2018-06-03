using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class SingleInputForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public SingleInputForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            importExcelFile.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            importExcelFile.FileName = "";
        }
        private void SingleInputForm_Load(object sender, EventArgs e)
        {
            setDateTimePickerEmpty();
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
                MaintainContractStyle = cbContractStyle.Text.Trim(),
                MaintainContractDate = maintainBox.Text.Trim(),
                RepairTimes = int.Parse(repairTimeBox.Value.ToString()),
                Remark = remarkBox.Text.Trim()
            };
        }

        private void setDateTimePickerEmpty()
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(DateTimePicker))
                {
                    (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
                    (c as DateTimePicker).CustomFormat = " ";
                }
                
            }            
        }
        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(qualityBox);
        }
        private void dateTimePicker3_DropDown(object sender, EventArgs e)
        {
            this.setDateTimePickerNormal(maintainBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = toolsInfoManage.InputOneToolsInfo(getAllInput());
            MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is ComboBox || c is DateTimePicker)
                {
                    c.Text = "";
                }
            }
            setDateTimePickerEmpty();
            if(importExcelFile.ShowDialog() == DialogResult.OK)
            {
                string msg = toolsInfoManage.ImportBatchTools2Db(importExcelFile.FileName);
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
