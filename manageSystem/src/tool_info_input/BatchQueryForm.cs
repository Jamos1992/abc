using BLL;
using manageSystem.src.tool_info_input;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class BatchQueryForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();

        private int addTimes = 1;
        public BatchQueryForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InitTextBoxHint();
        }
        private void InitTextBoxHint()
        {
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            if (list == null) return;
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());
        }

        private bool isTextBoxNull()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    if (c.Text != "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void setComboBoxList(string str,ComboBox comboBox)
        {
            List<string> list = toolsInfoManage.GetSerialNumHintFromDb(str);
            if (list == null) return;
            comboBox.Items.AddRange(list.ToArray());
        }

        private ToolsInfo getOneInput(TextBox txtBox, ComboBox comboBox)
        {
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfoBySerialAndModel(comboBox.Text.Trim(),txtBox.Text.Trim());
            if(toolsInfo == null)
            {
                MessageBox.Show("序列号:" + comboBox.Text + ", " + "型号:" + txtBox.Text + ", " + "记录不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return toolsInfo;
        }

        private ToolsInfo[] getTextBox()
        {
            ToolsInfo[] toolsInfos = new ToolsInfo[] { };
            List<ToolsInfo> ktls = toolsInfos.ToList();
            for(int i =1; i <= addTimes; i++)
            {
                foreach (Control txtBox in panel1.Controls)
                {
                    foreach (Control comboBox in panel1.Controls)
                    {
                        if (txtBox is TextBox && txtBox.Name.Contains(i.ToString()) && comboBox is ComboBox && comboBox.Name.Contains(i.ToString()))
                        {
                            if (txtBox.Text != "" && comboBox.Text != "")
                            {
                                ktls.Add(getOneInput(txtBox as TextBox, comboBox as ComboBox));
                            }
                        }
                    }
                }
            }
            toolsInfos = ktls.ToArray();
            return toolsInfos;
        }

        private bool isInputConflict()
        {
            List<string> inputList = new List<string>();
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    string a = inputList.Find(s => s == c.Text);
                    Console.WriteLine("a is ", a);
                    if (inputList.Find(s=> s==c.Text) != null)
                    {
                        return true;
                    }
                    if (c.Text != "") inputList.Add(c.Text);
                }
            }
            return false;
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("没有记录可以导出,请先查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定导出？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)){
                    return;
                }
            }
            ToolsInfo[] toolsInfos = GetToolsInfoFromGrid();
            if (toolsInfos.Length == 0)
            {
                MessageBox.Show("没有记录可以导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //string msg = toolsInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, getTextBox());   
                string msg = toolsInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, toolsInfos);
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            setComboBoxList(textBox1.Text, comboBox1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Height += 30;
            dataGridView1.Height -= 30;
            addTimes++;
            string txtName = "modelBox";
            string comboName = "serialBox";
            Label modelLabel = new Label();
            modelLabel.Text = label1.Text;
            modelLabel.ForeColor = Color.Black;
            modelLabel.Location = new Point(label1.Location.X, label1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(modelLabel);

            TextBox modelBox = new TextBox();
            modelBox.Name = txtName + addTimes;
            modelBox.Font = textBox1.Font;
            modelBox.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(modelBox);
            modelBox.BringToFront();
            modelBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            modelBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            if(list != null)
            {
                modelBox.AutoCompleteCustomSource.AddRange(list.ToArray());
            }

            Label serialLabel = new Label();
            serialLabel.Text = label2.Text;
            serialLabel.ForeColor = Color.Black;
            serialLabel.Location = new Point(label2.Location.X, label2.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(serialLabel);

            ComboBox serialBox = new ComboBox();
            serialBox.Name = comboName + addTimes;
            serialBox.Font = comboBox1.Font;
            serialBox.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(serialBox);
            serialBox.BringToFront();
            serialBox.DropDown += new EventHandler((object obj, EventArgs ex) =>
            {
                foreach (Control txtBox in panel1.Controls)
                {
                    foreach (Control comboBox in panel1.Controls)
                    {
                        if (txtBox is TextBox && txtBox.Name.Contains(addTimes.ToString()) && comboBox is ComboBox && comboBox.Name.Contains(addTimes.ToString()))
                        {
                            //MessageBox.Show(txtBox.Name.ToString()+comboBox.Name.ToString());
                            (comboBox as ComboBox).Items.Clear();
                            setComboBoxList(txtBox.Text.Trim(), comboBox as ComboBox);
                            //Console.WriteLine("aaaaa {0}");
                        }
                    }
                }
            });
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("请输入工具序列号, 再进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }
            if (isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定查询？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    return;
                }
            }
            List<ToolsInfo> list = new List<ToolsInfo>();
            foreach(ToolsInfo toolsInfo in getTextBox())
            {
                list.Add(toolsInfo);
            }
            dataGridView1.DataSource = list;
            dataGridView1.ClearSelection();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsDetailForm toolsDetailForm = new ToolsDetailForm(GetOneToolsInfoFromGrid());
            if(toolsDetailForm.ShowDialog() == DialogResult.OK)
            {
                Show(); 
            }
            //toolsDetailForm.ShowDialog();
        }

        private ToolsInfo[] GetToolsInfoFromGrid()
        {
            List<ToolsInfo> ktls = new List<ToolsInfo>();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue))
                {
                    ktls.Add(new ToolsInfo
                    {
                        SerialNum = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Model = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        Category = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        TorqueMin = double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                        TorqueMax = double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                        Accuracy = double.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()),
                        Section = dataGridView1.Rows[i].Cells[8].Value.ToString(),
                        Workstation = dataGridView1.Rows[i].Cells[9].Value.ToString(),
                        DemarcateCycle = int.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()),
                        Status = dataGridView1.Rows[i].Cells[11].Value.ToString(),
                        QualityAssureDate = dataGridView1.Rows[i].Cells[12].Value.ToString(),
                        MaintainContractStyle = dataGridView1.Rows[i].Cells[13].Value.ToString(),
                        MaintainContractDate = dataGridView1.Rows[i].Cells[14].Value.ToString(),
                        RepairTimes = int.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString()),
                        Remark = dataGridView1.Rows[i].Cells[16].Value.ToString()
                    });
                }                
            }
            return ktls.ToArray();
        }

        private ToolsInfo GetOneToolsInfoFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new ToolsInfo
            {
                SerialNum = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                Model = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                Category = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                Name = dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                TorqueMin = double.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()),
                TorqueMax = double.Parse(dataGridView1.SelectedRows[0].Cells[6].Value.ToString()),
                Accuracy = double.Parse(dataGridView1.SelectedRows[0].Cells[7].Value.ToString()),
                Section = dataGridView1.SelectedRows[0].Cells[8].Value.ToString(),
                Workstation = dataGridView1.SelectedRows[0].Cells[9].Value.ToString(),
                DemarcateCycle = int.Parse(dataGridView1.SelectedRows[0].Cells[10].Value.ToString()),
                Status = dataGridView1.SelectedRows[0].Cells[11].Value.ToString(),
                QualityAssureDate = dataGridView1.SelectedRows[0].Cells[12].Value.ToString(),
                MaintainContractStyle = dataGridView1.SelectedRows[0].Cells[13].Value.ToString(),
                MaintainContractDate = dataGridView1.SelectedRows[0].Cells[14].Value.ToString(),
                RepairTimes = int.Parse(dataGridView1.SelectedRows[0].Cells[15].Value.ToString()),
                Remark = dataGridView1.SelectedRows[0].Cells[16].Value.ToString()
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    ToolsDetailForm toolsDetailForm = new ToolsDetailForm(GetOneToolsInfoFromGrid());
                    if (toolsDetailForm.ShowDialog() == DialogResult.OK)
                    {
                        Show();
                    }
                }
            }
        }
    }
}
