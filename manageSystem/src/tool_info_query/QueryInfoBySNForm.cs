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
    public partial class QueryInfoBySNForm : Form
    {
        public QueryInfoBySNForm()
        {
            InitializeComponent();
        }

        private void QueryInfoBySNForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            if (this.textBox1.Text != "")
            {
                toolsInfo.SerialNum = this.textBox1.Text;
            }
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { toolsInfo.SerialNum });
            Console.WriteLine(reader);
            if (!reader.HasRows)
            {
                label11.ForeColor = Color.Red;
                label11.Text = "查询失败，该记录不存在！";
            }
            this.setTextBox(reader);
            label11.ForeColor = Color.Green;
            label11.Text = "查询成功！";
            db.CloseConnection();
        }

        private void setTextBox(SQLiteDataReader reader)
        {
            if (reader.Read())
            {
                this.textBox1.Text = reader.GetString(reader.GetOrdinal("SerialNum"));
                this.textBox2.Text = reader.GetString(reader.GetOrdinal("Model"));
                this.textBox3.Text = reader.GetString(reader.GetOrdinal("Workstation"));
                this.textBox4.Text = reader.GetString(reader.GetOrdinal("Torque"));
                this.textBox5.Text = reader.GetString(reader.GetOrdinal("Status"));
                this.textBox6.Text = reader.GetString(reader.GetOrdinal("QualityAssureDate"));
                this.textBox7.Text = "";
                this.textBox8.Text = reader.GetString(reader.GetOrdinal("MaintainContractStyle"));
                this.textBox9.Text = reader.GetString(reader.GetOrdinal("MaintainContractData"));
                this.textBox10.Text = reader.GetString(reader.GetOrdinal("Remark"));
                this.textBox11.Text = "";
                this.textBox12.Text = reader.GetString(reader.GetOrdinal("RepairList"));
            }
        }

        private ToolsInfo getTextBox()
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
            toolsInfo.RepairList = this.textBox10.Text;
            return toolsInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.button3.Text == "保存")
            {
                SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
                db.UpdateValuesByStruct("ToolsInfo", this.getTextBox(), new string[] { "SerialNum" }, new string[] { this.textBox1.Text });
                label11.ForeColor = Color.Green;
                this.label11.Text = "修改成功";
                this.button3.Text = "修改";
                db.CloseConnection();
            }
            this.button3.Text = "保存";
        }
    }
}
