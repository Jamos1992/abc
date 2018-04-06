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
    public partial class BatchInputForm : Form
    {
        public BatchInputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private ToolsInfo getAllInput()
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.SerialNum = this.textBox1.Text;
            toolsInfo.Model = this.textBox2.Text;
            toolsInfo.Workstation = this.textBox3.Text;
            toolsInfo.Torque = this.textBox4.Text;
            toolsInfo.Status = this.textBox5.Text;
            toolsInfo.QualityAssureDate = this.textBox6.Text;
            toolsInfo.MaintainContractStyle = this.textBox7.Text;
            toolsInfo.MaintainContractData = this.textBox8.Text;
            toolsInfo.Remark = this.textBox9.Text;
            toolsInfo.RepairList = "";
            return toolsInfo;
        }
    }
}
