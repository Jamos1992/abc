using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ToolsInfo toolsInfo = this.getAllInput();
            if (toolsInfo.SerialNum == "" || toolsInfo.Model == "")
            {
                this.label11.ForeColor = Color.Red;
                this.label11.Text = "录入失败，请输入工具序列号和型号";
                return;

            }
            try
            {
                SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
                db.InsertValuesByStruct("ToolsInfo",toolsInfo);
            }
            catch
            {
                this.label11.ForeColor = Color.Red;
                this.label11.Text = "录入失败，数据库操作失败";
                return;
            }
            MessageBox.Show("数据录入成功！");
            this.label11.Text = "录入成功!";
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateTimePicker))
                {
                    c.Text = "";
                }               
            }
            return;
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
            toolsInfo.MaintainContractDate = this.textBox8.Text;
            toolsInfo.Remark = this.textBox9.Text;
            toolsInfo.RepairList = "";
            toolsInfo.MaintainInfo = "";
            toolsInfo.RepoSpareTool = "";
            return toolsInfo;
        }
    }
}
