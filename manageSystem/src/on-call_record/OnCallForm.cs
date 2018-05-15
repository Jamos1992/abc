using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem.src.on_call_record
{
    public partial class OnCallForm : Form
    {
        public OnCallForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddRecordForm addRecordForm = new AddRecordForm();
            if (addRecordForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnCallForm toolsInfo = new OnCallForm();
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = null;
            string sql = "select * from OnCallRecord where 1=1";
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                reader = db.ReadFullTable("OnCallRecord");
                if (reader == null) return;
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "") sql += " and CallTime>'" + dateTimePicker1.Text + "' and CallTime<'" + dateTimePicker2.Text + "'";
                    else MessageBox.Show("时间选择不对，请重新选择");
                }
                if (checkBox2.Checked)
                {
                    if (comboBox1.Text != "") sql += " and FaultReason='" + comboBox1.Text + "'";
                    else MessageBox.Show("故障原因未选择");
                }
                reader = db.ReadTableBySql(sql);
            }
            if (reader == null || !reader.HasRows)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("记录不存在！");
                return;
            }
            BindData2Grid(reader);
        }

        private void BindData2Grid(SQLiteDataReader reader)
        {
            BindingSource Bs = new BindingSource();
            Bs.DataSource = reader;
            dataGridView1.DataSource = Bs;
            dataGridView1.Columns["CallTime"].HeaderText = "客户呼叫时间";
            dataGridView1.Columns["ArriveTime"].HeaderText = "达到现场时间";
            dataGridView1.Columns["FaultReason"].HeaderText = "故障原因";
            dataGridView1.Columns["Detail"].HeaderText = "详细内容";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].FillWeight = 20;
            dataGridView1.Columns[1].FillWeight = 20;
            dataGridView1.Columns[2].FillWeight = 20;
            dataGridView1.Columns[3].FillWeight = 40;
            dataGridView1.ClearSelection();
        }
    }
}
