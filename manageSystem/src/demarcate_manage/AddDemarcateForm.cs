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
    public partial class AddDemarcateForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        public AddDemarcateForm()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AutoGenerateColumns = false;
            dtDemarcateDate.Format = DateTimePickerFormat.Custom;
            dtDemarcateDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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
                //MessageBox.Show("数据不存在", "提示信息");
                return;
            }   
            dataGridView1.DataSource = list;
            //dataGridView1.Columns["SerialNum"].HeaderText = "工具序列号";
            //dataGridView1.Columns["Cycle"].HeaderText = "标定周期";
            //dataGridView1.Columns["LastTime"].HeaderText = "起始/上次标定时间";
            //dataGridView1.Columns["Status"].HeaderText = "标定状态";
            //dataGridView1.Columns[0].FillWeight = 25;
            //dataGridView1.Columns[1].FillWeight = 25;
            //dataGridView1.Columns[2].FillWeight = 25;
            //dataGridView1.Columns[3].FillWeight = 25;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    }
}
