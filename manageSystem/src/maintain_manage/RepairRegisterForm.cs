using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairRegisterForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();

        public RepairRegisterForm()
        {
            InitializeComponent();
            setDateTimePickerEmpty(dateTimePicker1);
            setComboBoxItems();
        }
        private void setComboBoxItems()
        {
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            if (list == null) return;
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());
        }

        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private MaintainManageInfo getAllInput()
        {
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolModeName = textBox1.Text;
            maintainManageInfo.ToolSerialName =  comboBox1.Text;
            maintainManageInfo.SendFixTime = dateTimePicker1.Text;
            maintainManageInfo.Detail = richTextBox1.Text;
            maintainManageInfo.Status = "待维修";
            maintainManageInfo.UsedOtherSpareToolInfo = null;
            maintainManageInfo.UsedRepoSpareToolInfo = null;
            maintainManageInfo.State = "0";
            return maintainManageInfo;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            string msg = maintainInfoManage.RegisterBreakTool(maintainManageInfo);
            MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            setDateTimePickerEmpty(dateTimePicker1);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {          
            comboBox1.Items.Clear();
            setComboBoxList(textBox1.Text, comboBox1);
        }
        private void setComboBoxList(string str, ComboBox comboBox)
        {
            List<string> list = toolsInfoManage.GetSerialNumHintFromDb(str);
            if (list == null) return;
            comboBox.Items.AddRange(list.ToArray());
        }
    }
}
