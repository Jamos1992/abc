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
            MinimizeBox = false;
            MaximizeBox = false;
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
                SerialNum = txtSerialNum.Text.Trim(),
                Model = cmbModel.Text.Trim(),
                Category = cmbCategory.Text.Trim(),
                Name = cmbName.Text.Trim(),
                TorqueMin = txtTorqueMin.Text == "" ? 0 : double.Parse(txtTorqueMin.Text.Trim()),
                TorqueMax = txtTorqueMax.Text == "" ? 0 : double.Parse(txtTorqueMax.Text.Trim()),
                Accuracy = txtAccuracy.Text == "" ? 0 : double.Parse(txtAccuracy.Text.Trim()),
                Section = cmbSection.Text.Trim(),
                DemarcateCycle = int.Parse(nudCycle.Value.ToString()),
                Workstation = cmbWorkstation.Text.Trim(),
                Status = cmbStatus.Text.Trim(),
                QualityAssureDate = dtpQuality.Text.Trim(),
                MaintainContractStyle = cmbContractStyle.Text.Trim(),
                MaintainContractDate = dtpMaintain.Text.Trim(),
                RepairTimes = int.Parse(nudRepairTime.Value.ToString()),
                Remark = txtRemark.Text.Trim()
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

        private void dtpQuality_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dtpQuality);
        }
        private void dtpMaintain_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dtpMaintain);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msg = toolsInfoManage.InputOneToolsInfo(getAllInput());
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox || c is NumericUpDown)
                {
                    c.Text = "";
                }
                if(c is ComboBox)
                {
                    c.Text = "";
                    (c as ComboBox).SelectedIndex = -1;
                }
                if(c is DateTimePicker)
                {
                    setDateTimePickerEmpty();
                }
            }
        }
    }
}
