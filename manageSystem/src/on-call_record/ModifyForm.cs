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

namespace manageSystem.src.on_call_record
{
    public partial class ModifyForm : Form
    {
        private OnCallRecord onCallRecord;
        private OnCallRecordManage onCallRecordManage = new OnCallRecordManage();
        public ModifyForm()
        {
            InitializeComponent();
        }

        public ModifyForm(OnCallRecord record)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            onCallRecord = record;
        }
        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = onCallRecord.CallTime;
            dateTimePicker2.Text = onCallRecord.ArriveTime;
            comboBox3.Text = onCallRecord.ToolSection;
            comboBox2.Text = onCallRecord.ToolWorkstation;
            textBox1.Text = onCallRecord.FaultToolName;
            comboBox1.Text = onCallRecord.FaultReason;
            richTextBox1.Text = onCallRecord.Detail;
            setDateTimePickerNormal(dateTimePicker1);
            setDateTimePickerNormal(dateTimePicker2);
        }

        private OnCallRecord getAllInput()
        {
            return new OnCallRecord
            {
                CallTime = dateTimePicker1.Text.Trim(),
                ArriveTime = dateTimePicker2.Text.Trim(),
                ToolSection = comboBox3.Text.Trim(),
                ToolWorkstation = comboBox2.Text.Trim(),
                FaultToolName = textBox1.Text.Trim(),
                FaultReason = comboBox1.Text.Trim(),
                Detail = richTextBox1.Text.Trim()
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = onCallRecordManage.ModifyOneRecord(getAllInput());
            if (msg.Contains("失败"))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
