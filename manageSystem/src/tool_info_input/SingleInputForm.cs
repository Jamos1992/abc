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

namespace manageSystem
{
    public partial class SingleInputForm : Form
    {
        public SingleInputForm()
        {
            InitializeComponent();
        }
        private void SingleInputForm_Load(object sender, EventArgs e)
        {
            this.setDateTimePickerEmpty();
        }

        private ToolsInfo getAllInput()
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.Model = comboBox1.Text.Trim();
            toolsInfo.SerialNum = textBox2.Text.Trim();
            toolsInfo.Workstation = textBox3.Text.Trim();
            toolsInfo.Torque = textBox4.Text.Trim();
            toolsInfo.Status = comboBox2.Text.Trim();
            toolsInfo.QualityAssureDate = dateTimePicker1.Text.Trim();
            toolsInfo.MaintainContractStyle = textBox7.Text.Trim();
            toolsInfo.MaintainContractDateStart = dateTimePicker2.Text.Trim();
            toolsInfo.MaintainContractDateEnd = dateTimePicker3.Text.Trim();
            toolsInfo.Remark = textBox9.Text.Trim();
            toolsInfo.RepairList = "";
            toolsInfo.MaintainInfo = "";
            toolsInfo.RepoSpareTool = "";
            return toolsInfo;
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
            ToolsInfo toolsInfo = getAllInput();
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
            int affectedRow = new ToolsInfoService().AddTools(toolsInfo);
            if (affectedRow < 1)
            {
                MessageBox.Show("录入失败，数据库操作失败！");
                return;
            }
            MessageBox.Show("数据录入成功！");
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
        }
    }
}
