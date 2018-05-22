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

namespace manageSystem
{
    public partial class SingleInputForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
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
            return new ToolsInfo()
            {
                Model = comboBox1.Text.Trim(),
                SerialNum = textBox2.Text.Trim(),
                Workstation = textBox3.Text.Trim(),
                Torque = textBox4.Text.Trim(),
                Status = comboBox2.Text.Trim(),
                QualityAssureDate = dateTimePicker1.Text.Trim(),
                MaintainContractStyle = textBox7.Text.Trim(),
                MaintainContractDateStart = dateTimePicker2.Text.Trim(),
                MaintainContractDateEnd = dateTimePicker3.Text.Trim(),
                Remark = textBox9.Text.Trim(),
                RepairList = "",
                MaintainInfo = "",
                RepoSpareTool = ""
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
        }
    }
}
