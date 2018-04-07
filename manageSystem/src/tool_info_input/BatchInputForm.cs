using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

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
            ToolsInfo[] toolsInfos = new ToolsInfo[] { };
            List<ToolsInfo> ktls = toolsInfos.ToList();
            if (textBox1.Text != null && textBox2.Text != null)
            {
                ktls.Add(this.getOneInput(textBox1, textBox2));
            }
            if (textBox3.Text != null && textBox4.Text != null)
            {
                ktls.Add(this.getOneInput(textBox3, textBox4));
            }
            if (textBox5.Text != null && textBox6.Text != null)
            {
                ktls.Add(this.getOneInput(textBox5, textBox6));
            }
            if (textBox7.Text != null && textBox8.Text != null)
            {
                ktls.Add(this.getOneInput(textBox7, textBox8));
            }
            if (textBox9.Text != null && textBox10.Text != null)
            {
                ktls.Add(this.getOneInput(textBox9, textBox10));
            }
            toolsInfos = ktls.ToArray();

        }

        private ToolsInfo getOneInput(TextBox txtBox1,TextBox txtBox2)
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.Model = txtBox1.Text;
            toolsInfo.SerialNum = txtBox2.Text;            
            toolsInfo.Workstation = "";
            toolsInfo.Torque = "";
            toolsInfo.Status = "";
            toolsInfo.QualityAssureDate = "";
            toolsInfo.MaintainContractStyle = "";
            toolsInfo.MaintainContractDate = "";
            toolsInfo.Remark = "";
            toolsInfo.RepairList = "";
            return toolsInfo;
        }

        private void InsertValue2Db(ToolsInfo[] toolsInfos)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            foreach(ToolsInfo toolsInfo in toolsInfos)
            {
                try
                {
                    SQLiteDataReader reader = db.InsertValuesByStruct("ToolsInfo", toolsInfo);
                }
                catch
                {
                    MessageBox.Show("插入数据失败！");
                }
            }            
        }
    }
}
