using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairManageForm : Form
    {
        public static string ToolSerialName;
        public RepairManageForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private MaintainManageInfo[] GetMaintainManageInfoFromGrid()
        {
            MaintainManageInfo[] maintainManageInfo = new MaintainManageInfo[] { };
            List<MaintainManageInfo> ktls = maintainManageInfo.ToList();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                ktls.Add(new MaintainManageInfo
                {
                    ToolModeName = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    ToolSerialName = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    SendFixTime = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Status = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    Detail = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                });
            }
            return ktls.ToArray();
        }
        private void BindData2Grid(SQLiteDataReader reader)
        {
            BindingSource Bs = new BindingSource();
            Bs.DataSource = reader;
            dataGridView1.DataSource = Bs;
            dataGridView1.Columns["ToolModeName"].HeaderText = "工具型号";
            dataGridView1.Columns["ToolSerialName"].HeaderText = "工具序列号";
            dataGridView1.Columns["SendFixTime"].HeaderText = "工具送修时间";
            dataGridView1.Columns["Status"].HeaderText = "维修状态";
            dataGridView1.Columns["Detail"].HeaderText = "备注";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].FillWeight = 20;
            dataGridView1.Columns[1].FillWeight = 20;
            dataGridView1.Columns[2].FillWeight = 20;
            dataGridView1.Columns[3].FillWeight = 20;
            dataGridView1.Columns[4].FillWeight = 20;
            //dataGridView1.Columns[2].ReadOnly = false;
            //dataGridView1.Columns[3].ReadOnly = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
        }

        private void RepairManageForm_Load(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadFullTable("MaintainManageInfo");
            if (reader == null || !reader.HasRows) return;
            BindData2Grid(reader);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = null;
            string sql = "select * from MaintainManageInfo where";
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                reader = db.ReadFullTable("MaintainManageInfo");
                if (reader == null) return;
            }
            else
            {
                if (radioButton1.Checked) sql += " Status='" + Declare.Repairing + "'";
                if (radioButton2.Checked) sql += " Status='" + Declare.Suspend + "'";
                if (radioButton3.Checked) sql += " Status='" + Declare.RepairFinished + "'";
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
                foreach (MaintainManageInfo maintainManageInfo in GetMaintainManageInfoFromGrid())
                {
                    if (maintainManageInfo == null)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        if (excel.CreateAndSaveRepoSpareToolToExcel(maintainManageInfo, saveFileDialog1.FileName))
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
                        if (excel.SaveDataTableToExcel(maintainManageInfo, saveFileDialog1.FileName))
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

        private void gotoRepair_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepairOperatorForm repairOperatorForm = new RepairOperatorForm();
            if (repairOperatorForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
            ToolSerialName = getSerialNumFromGrid();
        }

        private string getSerialNumFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
