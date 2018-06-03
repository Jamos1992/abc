using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Model;
using BLL;

namespace manageSystem.src.spare_manage
{
    public partial class RepoSpareListForm : Form
    {
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        public RepoSpareListForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
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
            List<RepoSpareTool> list = new List<RepoSpareTool>();            
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                list = new RepoSpareToolService().getAllRepoSpareTools();
            }
            else
            {
                string sql = "select * from RepoSpareTool where 1=1";
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
                list = new RepoSpareToolService().getRepoSpareToolBySql(sql);
            }
            if (list == null)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("记录不存在！");
                return;
            }
            BindData2Grid(list);
        }

        private void RepoSpareListForm_Load(object sender, EventArgs e)
        {
            setDateTimePickerEmpty(dateTimePicker1);
            setDateTimePickerEmpty(dateTimePicker2);
            List<RepoSpareTool> list = new RepoSpareToolService().getAllRepoSpareTools();
            if (list == null) return;
            BindData2Grid(list);
        }

        private void BindData2Grid(List<RepoSpareTool> list)
        {
            dataGridView1.DataSource = list;
            //dataGridView1.Columns["SpareToolModel"].HeaderText = "仓库备件型号";
            //dataGridView1.Columns["Num"].HeaderText = "个数";
            //dataGridView1.Columns["Time"].HeaderText = "入库时间";
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Columns[0].FillWeight = 30;
            //dataGridView1.Columns[1].FillWeight = 30;
            //dataGridView1.Columns[2].FillWeight = 40;
            //dataGridView1.ReadOnly = true;
            //dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
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
                string msg = repoSpareToolManage.ExportBatchData2Excel(saveFileDialog1.FileName, GetRepoSpareToolFromGrid());
                MessageBox.Show(msg);
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
                    SpareToolModel = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Num = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                    Time = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                });
            }
            return ktls.ToArray();
        }
    }
}
