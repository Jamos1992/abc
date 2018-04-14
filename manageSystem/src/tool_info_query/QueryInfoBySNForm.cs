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
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            this.button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            ToolsInfo toolsInfo = new ToolsInfo();
            if (this.textBox1.Text == "")
            {
                label11.ForeColor = Color.Red;
                label11.Text = "查询失败，请输入查询序列号！";
                clearTextBox4Query();
                this.button3.Enabled = false;
                return;
            }
            toolsInfo.SerialNum = this.textBox1.Text;
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { toolsInfo.SerialNum });
            Console.WriteLine(reader);
            if (!reader.HasRows)
            {
                label11.ForeColor = Color.Red;
                label11.Text = "查询失败，该记录不存在！";
                this.button3.Enabled = false;
                clearTextBox4Query();
                return;
            }
            this.setTextBox(reader);
            label11.ForeColor = Color.Green;
            label11.Text = "查询成功！";
            changeTextBoxReadOnly();
            this.button3.Enabled = true;
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
                this.textBox7.Text = reader.GetString(reader.GetOrdinal("RepoSpareTool"));
                this.textBox8.Text = reader.GetString(reader.GetOrdinal("MaintainContractStyle"));
                this.textBox9.Text = reader.GetString(reader.GetOrdinal("MaintainContractData"));
                this.textBox10.Text = reader.GetString(reader.GetOrdinal("Remark"));
                this.textBox11.Text = reader.GetString(reader.GetOrdinal("MaintainInfo"));
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
            toolsInfo.MaintainContractDate = this.textBox8.Text;
            toolsInfo.Remark = this.textBox9.Text;
            toolsInfo.RepairList = this.textBox10.Text;
            return toolsInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeTextBoxWrite();
            if (this.button3.Text == "保存")
            {
                SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
                try
                {
                    db.UpdateValuesByStruct("ToolsInfo", this.getTextBox(), new string[] { "SerialNum" }, new string[] { this.textBox1.Text });
                }
                catch(Exception ex)
                {
                    label11.ForeColor = Color.Red;
                    this.label11.Text = "修改失败";
                    MessageBox.Show("修改失败,原因：{0}",ex.Message);
                    return;
                }
                this.button3.Text = "修改";
                label11.ForeColor = Color.Green;
                this.label11.Text = "修改成功!";
                clearTextBox();
                this.button1.Enabled = true;
                db.CloseConnection();
                return;
            }
            this.button3.Text = "保存";
            this.button1.Enabled = false;
        }

        private bool isTextBoxNull()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Text != "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void clearTextBox()
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = "";
                }
            }
        }

        private void clearTextBox4Query()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    if (c != textBox1)
                    {
                        c.Text = "";
                    }                       
                }
            }
        }

        private void changeTextBoxReadOnly()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    if (c != textBox1)
                    {
                        txtBox.ReadOnly = true;
                    }   
                }
            }
        }

        private void changeTextBoxWrite()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    txtBox.ReadOnly = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.isTextBoxNull()){
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelOperator excel = new ExcelOperator();
                if (excel.CreateAndSaveDateToExcel(this.getTextBox(),saveFileDialog1.FileName))
                {
                    label11.ForeColor = Color.Green;
                    label11.Text = "导出Excel成功！";
                    MessageBox.Show("导出Excel成功！");
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    label11.Text = "导出Excel失败！";
                    MessageBox.Show("导出Excel失败！");
                }
            }
        }
    }
}
