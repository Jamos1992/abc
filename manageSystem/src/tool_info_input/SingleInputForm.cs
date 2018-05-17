﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class SingleInputForm : Form
    {
        public SingleInputForm()
        {
            InitializeComponent();
        }

        private void inputAllData()
        {
            ToolsInfo toolsInfo = this.getAllInput();
            if (toolsInfo.SerialNum == "" || toolsInfo.Model == "" || toolsInfo.Workstation == "")
            {
                MessageBox.Show("录入失败，请输入工具序列号、型号及工位信息！");
                return;
            }
            if (string.Compare(toolsInfo.MaintainContractDateStart, toolsInfo.MaintainContractDateEnd) > 0)
            {
                MessageBox.Show("参数输入有误，保养起始日期应小于保养终止日期");
                return;
            }
            try
            {
                SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
                db.InsertValuesByStruct("ToolsInfo",toolsInfo);
            }
            catch
            {
                return;
            }
            MessageBox.Show("数据录入成功！");            
            return;
        }

        private void clearAllInputText()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateTimePicker))
                {
                    c.Text = "";
                }
            }
            this.setDateTimePickerEmpty();
        }

        private ToolsInfo getAllInput()
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.Model = this.comboBox1.Text;
            toolsInfo.SerialNum = this.textBox2.Text;
            toolsInfo.Workstation = this.textBox3.Text;
            toolsInfo.Torque = this.textBox4.Text;
            toolsInfo.Status = this.comboBox2.Text;
            toolsInfo.QualityAssureDate = this.dateTimePicker1.Text;
            toolsInfo.MaintainContractStyle = this.textBox7.Text;
            toolsInfo.MaintainContractDateStart = this.dateTimePicker2.Text;
            toolsInfo.MaintainContractDateEnd = this.dateTimePicker3.Text;
            toolsInfo.Remark = this.textBox9.Text;
            toolsInfo.RepairList = "";
            toolsInfo.MaintainInfo = "";
            toolsInfo.RepoSpareTool = "";
            return toolsInfo;
        }

        private void SingleInputForm_Load(object sender, EventArgs e)
        {
            this.setDateTimePickerEmpty();
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
            this.setDateTimePickerNormal(dateTimePicker1);
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            this.setDateTimePickerNormal(dateTimePicker2);
        }

        private void dateTimePicker3_DropDown(object sender, EventArgs e)
        {
            this.setDateTimePickerNormal(dateTimePicker3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.inputAllData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.clearAllInputText();
        }
    }
}
