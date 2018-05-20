using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Model;

namespace manageSystem.src.on_call_record
{
    public partial class AddRecordForm : Form
    {
        public AddRecordForm()
        {
            InitializeComponent();
        }

        private void AddRecordForm_Load(object sender, EventArgs e)
        {
            setDateTimePickerEmpty(dateTimePicker1);
            setDateTimePickerEmpty(dateTimePicker2);
        }
        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }
        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Text =="" || dateTimePicker2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("提交失败，请填写必填项！");
                return;
            }
            if(String.Compare(dateTimePicker1.Text,dateTimePicker2.Text) > 0)
            {
                MessageBox.Show("输入的时间有误，请检查后提交！");
                return;
            }
            int affectedRow = new OnCallRecordService().AddOnCallRecord(getAllInput());
            if(affectedRow < 1)
            {
                MessageBox.Show("添加失败，数据库操作失败！");
                return;
            }
            MessageBox.Show("添加成功！");
        }

        private OnCallRecord getAllInput()
        {
            OnCallRecord onCallRecord = new OnCallRecord();
            onCallRecord.CallTime = dateTimePicker1.Text;
            onCallRecord.ArriveTime = dateTimePicker2.Text;
            onCallRecord.FaultToolName = textBox1.Text;
            onCallRecord.FaultReason = comboBox1.Text;
            onCallRecord.Detail = richTextBox1.Text;
            return onCallRecord;
        }
    }
}
