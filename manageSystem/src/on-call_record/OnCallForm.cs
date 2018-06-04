using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace manageSystem.src.on_call_record
{
    public partial class OnCallForm : Form
    {
        private OnCallRecordManage onCallRecordManage = new OnCallRecordManage();
        public OnCallForm()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddRecordForm addRecordForm = new AddRecordForm();
            if (addRecordForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnCallForm toolsInfo = new OnCallForm();
            List<OnCallRecord> list = new List<OnCallRecord>();           
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                list = onCallRecordManage.GetAllOnCallRecords();
            }
            else
            {
                string sql = "select * from OnCallRecord where 1=1";
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
                list = onCallRecordManage.GetOnCallRecordBySql(sql);
            }
            if (list == null)
            {
                dataGridView1.DataSource = new List<OnCallRecord>();
                MessageBox.Show("记录不存在！");
                return;
            }
            BindData2Grid(list);
        }

        private void BindData2Grid(List<OnCallRecord> list)
        {
            dataGridView1.DataSource = list;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
        }
        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker2);
        }

        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }

        private void OnCallForm_Load(object sender, EventArgs e)
        {
            setDateTimePickerEmpty(dateTimePicker1);
            setDateTimePickerEmpty(dateTimePicker2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control c in groupBox1.Controls)
            {
                if(c is DateTimePicker || c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = onCallRecordManage.ExportBatchData2Excel(saveFileDialog1.FileName, GetOnCallRecordsFromGrid());
                MessageBox.Show(msg);
            }

        }

        private OnCallRecord[] GetOnCallRecordsFromGrid()
        {
            List<OnCallRecord> ktls = new List<OnCallRecord>();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                ktls.Add(new OnCallRecord {
                    CallTime = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    ArriveTime = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    FaultToolName = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    FaultReason = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    Detail = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                });
            }
            return ktls.ToArray();
        }
    }
}
