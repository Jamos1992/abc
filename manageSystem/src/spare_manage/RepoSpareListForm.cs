using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem.src.spare_manage
{
    public partial class RepoSpareListForm : Form
    {
        public RepoSpareListForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            setDateTimePickerEmpty(dateTimePicker1);
            setDateTimePickerEmpty(dateTimePicker2);
        }
        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }
        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
            //dateTimePicker.ShowUpDown = true;
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = null;
            string sql = "select * from RepoSpareTool where 1=1";
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                reader = db.ReadFullTable("RepoSpareTool");
                if (reader == null) return;
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "") sql += " and Time>'" + dateTimePicker1.Text + "' and Time<'" + dateTimePicker2.Text + "'";
                    else MessageBox.Show("时间选择不对，请重新选择");
                }
                if (checkBox2.Checked)
                {
                    if (comboBox1.Text != "") sql += " and SpareToolModel='" + comboBox1.Text + "'";
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

        private void RepoSpareListForm_Load(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadFullTable("RepoSpareTool");
            if (reader == null || !reader.HasRows) return;
            BindData2Grid(reader);
        }

        private void BindData2Grid(SQLiteDataReader reader)
        {
            BindingSource Bs = new BindingSource();
            Bs.DataSource = reader;
            dataGridView1.DataSource = Bs;
            dataGridView1.Columns["SpareToolModel"].HeaderText = "仓库备件型号";
            dataGridView1.Columns["Num"].HeaderText = "个数";
            dataGridView1.Columns["Time"].HeaderText = "入库时间";
//            dataGridView1.Columns["SerialNum"].HeaderText = "备件序列号";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].FillWeight = 30;
            dataGridView1.Columns[1].FillWeight = 30;
            dataGridView1.Columns[2].FillWeight = 40;
//            dataGridView1.Columns[3].FillWeight = 25;
            //dataGridView1.Columns[2].ReadOnly = false;
            //dataGridView1.Columns[3].ReadOnly = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is DateTimePicker || c is ComboBox)
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
                ExcelOperator excel = new ExcelOperator();
                int i = 0;
                foreach (RepoSpareTool repoSpareTool in GetRepoSpareToolFromGrid())
                {
                    if (repoSpareTool == null)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        if (excel.CreateAndSaveRepoSpareToolToExcel(repoSpareTool, saveFileDialog1.FileName))
                        {
                            i++;
                            MessageBox.Show("导出Excel成功！");
                        }
                        else
                        {
                            MessageBox.Show("导出Excel失败！");
                            break;
                        }
                    }
                    else
                    {
                        if (excel.SaveDataTableToExcel(repoSpareTool, saveFileDialog1.FileName))
                        {
                            MessageBox.Show("导出Excel成功！");
                        }
                        else
                        {
                            MessageBox.Show("导出Excel失败！");
                            break;
                        }
                    }

                }
            }
        }

        private RepoSpareTool[] GetRepoSpareToolFromGrid()
        {
            RepoSpareTool[] repoSpareTool = new RepoSpareTool[] { };
            List<RepoSpareTool> ktls = repoSpareTool.ToList();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                ktls.Add(new RepoSpareTool
                {
                    SpareToolModel = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Num = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()),
                    Time = dataGridView1.Rows[i].Cells[2].Value.ToString(),
//                    SerialNum = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                });
            }
            return ktls.ToArray();
        }
    }
}
