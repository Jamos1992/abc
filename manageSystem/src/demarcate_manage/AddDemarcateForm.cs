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
        public AddDemarcateForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtDemarcateDate.CustomFormat = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbSerialNum.Text == "" || cbCycle.Text == "" || dtDemarcateDate.Text == "")
            {
                MessageBox.Show("请填写工具序列号、标定周期和标定日期","提示信息");
                return;
            }
            string msg = demarcateRecordManage.AddOneDemarcateTool(getAllInput());
            if(msg != "提交成功")
            {
                MessageBox.Show(msg);
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
                NextTime = Convert.ToDateTime(dtDemarcateDate.Text.Trim()).AddDays(Convert.ToInt32(cbCycle.Text.Trim())).ToString("yyyy-MM-dd HH:mm:ss"),
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
    }
}
