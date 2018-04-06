using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using manageSystem.src.tool_KPI_manage;
using manageSystem.src.maintain_manage;
using System.Data.SQLite;

namespace manageSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            //db.CreateTable("table1", new string[] { "ID", "Name", "Age", "Email" }, new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });
            ////插入两条数据
            //db.InsertValues("table1", new string[] { "1", "张三", "22", "Zhang@163.com" });
            //db.InsertValues("table1", new string[] { "2", "李四", "25", "Li4@163.com" });
            //SQLiteDataReader reader = db.ReadFullTable("table1");
            //while (reader.Read())
            //{
            //    //读取ID
            //    Log("" + reader.GetInt32(reader.GetOrdinal("ID")));
            //    //读取Name
            //    Log("" + reader.GetString(reader.GetOrdinal("Name")));
            //    //读取Age
            //    Log("" + reader.GetInt32(reader.GetOrdinal("Age")));
            //    //读取Email
            //    Log(reader.GetString(reader.GetOrdinal("Email")));
            //}

        }

        static void Log(string s)
        {
            Console.WriteLine("" + s);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoInputForm iif = new InfoInputForm();
            //this.Hide();
            if (iif.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueryInfoForm qif = new QueryInfoForm();
            if (qif.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpareManageForm smf = new SpareManageForm();
            smf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolKPIManageForm tkmf = new ToolKPIManageForm();
            tkmf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RepairAndMaintainForm rmf = new RepairAndMaintainForm();
            rmf.Show();
        }
    }
}
