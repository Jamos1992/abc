using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using BLL;
using System.Drawing;
using manageSystem.src.tool_info_input;

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
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());
            //textBox2.AutoCompleteCustomSource.AddRange(list.ToArray());
            //textBox3.AutoCompleteCustomSource.AddRange(list.ToArray());
            //textBox4.AutoCompleteCustomSource.AddRange(list.ToArray());
            //textBox5.AutoCompleteCustomSource.AddRange(list.ToArray());
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
            comboBox.Items.AddRange(toolsInfoManage.GetSerialNumHintFromDb(str).ToArray());
        }

        private ToolsInfo getOneInput(TextBox txtBox, ComboBox comboBox)
        {
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfoBySerialAndModel(comboBox.Text.Trim(),txtBox.Text.Trim());
            if(toolsInfo == null)
            {
                MessageBox.Show("序列号:" + comboBox.Text + ", " + "型号:" + txtBox.Text + ", " + "记录不存在!");
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
                            MessageBox.Show(txtBox.Name + comboBox.Name);
                            if (txtBox.Text != "" && comboBox.Text != "")
                            {
                                ktls.Add(getOneInput(txtBox as TextBox, comboBox as ComboBox));
                            }
                            MessageBox.Show("this is " + i.ToString());
                        }
                    }
                }
            }
            
            //if (textBox1.Text != "" && comboBox1.Text != "")
            //{
            //    ktls.Add(this.getOneInput(textBox1, comboBox1));
            //}
            //if (textBox2.Text != "" && comboBox2.Text != "")
            //{
            //    ktls.Add(this.getOneInput(textBox2, comboBox2));
            //}
            //if (textBox3.Text != "" && comboBox3.Text != "")
            //{
            //    ktls.Add(this.getOneInput(textBox3, comboBox3));
            //}
            //if (textBox4.Text != "" && comboBox4.Text != "")
            //{
            //    ktls.Add(this.getOneInput(textBox4, comboBox4));
            //}
            //if (textBox5.Text != "" && comboBox5.Text != "")
            //{
            //    ktls.Add(this.getOneInput(textBox5, comboBox5));
            //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定导出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)){
                    return;
                }
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = toolsInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, getTextBox());
                MessageBox.Show(msg);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            setComboBoxList(textBox1.Text, comboBox1);
        }

        //private void comboBox2_DropDown(object sender, EventArgs e)
        //{
        //    this.comboBox2.Items.Clear();
        //    setComboBoxList(textBox2.Text, comboBox2);
        //}

        //private void comboBox3_DropDown(object sender, EventArgs e)
        //{
        //    this.comboBox3.Items.Clear();
        //    setComboBoxList(textBox3.Text, comboBox3);
        //}

        //private void comboBox4_DropDown(object sender, EventArgs e)
        //{
        //    this.comboBox4.Items.Clear();
        //    setComboBoxList(textBox4.Text, comboBox4);
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            addTimes++;
            string txtName = "modelBox";
            string comboName = "serialBox";
            Label modelLabel = new Label();
            modelLabel.Text = label1.Text;
            modelLabel.Location = new Point(label1.Location.X, label1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(modelLabel);

            TextBox modelBox = new TextBox();
            modelBox.Name = txtName + addTimes;
            modelBox.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(modelBox);
            modelBox.BringToFront();
            modelBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            modelBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            modelBox.AutoCompleteCustomSource.AddRange(toolsInfoManage.GetModelHintFromDb().ToArray());

            Label serialLabel = new Label();
            serialLabel.Text = label2.Text;
            serialLabel.Location = new Point(label2.Location.X, label2.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(serialLabel);

            ComboBox serialBox = new ComboBox();
            serialBox.Name = comboName + addTimes;
            serialBox.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 30 * (addTimes - 1));
            panel1.Controls.Add(serialBox);
            serialBox.BringToFront();
            //serialBox.DropDown += new EventHandler(serialBox_DropDown);
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("请输入工具序列号, 再进行查询！"); 
                return;
            }
            if (isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定查询？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
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
            dataGridView1.Columns["SerialNum"].HeaderText = "工具序列号";
            dataGridView1.Columns["Model"].HeaderText = "工具型号";
            dataGridView1.Columns["Category"].HeaderText = "工具类别";
            dataGridView1.Columns["Name"].HeaderText = "工具名称";
            dataGridView1.Columns["TorqueMin"].HeaderText = "标定扭矩下限";
            dataGridView1.Columns["TorqueMax"].HeaderText = "标定扭矩上限";
            dataGridView1.Columns["Accuracy"].HeaderText = "精度";
            dataGridView1.Columns["Section"].HeaderText = "工段";
            dataGridView1.Columns["Workstation"].HeaderText = "工位";
            dataGridView1.Columns["DemarcateCycle"].HeaderText = "标定周期";
            dataGridView1.Columns["Status"].HeaderText = "工具状态";
            dataGridView1.Columns["QualityAssureDate"].HeaderText = "质保期至";
            dataGridView1.Columns["MaintainContractStyle"].HeaderText = "保养合同类型";
            dataGridView1.Columns["MaintainContractDate"].HeaderText = "保养合同至";
            dataGridView1.Columns["RepairTimes"].HeaderText = "累计维修次数";
            dataGridView1.Columns["ChangeRecord"].HeaderText = "更改记录";
            dataGridView1.Columns["Remark"].HeaderText = "备注信息";
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.Columns[0].FillWeight = 6;
            dataGridView1.Columns[1].FillWeight = 6;
            dataGridView1.Columns[2].FillWeight = 6;
            dataGridView1.Columns[3].FillWeight = 6;
            dataGridView1.Columns[4].FillWeight = 6;
            dataGridView1.Columns[5].FillWeight = 6;
            dataGridView1.Columns[6].FillWeight = 6;
            dataGridView1.Columns[7].FillWeight = 6;
            dataGridView1.Columns[8].FillWeight = 6;
            dataGridView1.Columns[9].FillWeight = 6;
            dataGridView1.Columns[10].FillWeight = 6;
            dataGridView1.Columns[11].FillWeight = 6;
            dataGridView1.Columns[12].FillWeight = 6;
            dataGridView1.Columns[13].FillWeight = 6;
            dataGridView1.Columns[14].FillWeight = 6;
            dataGridView1.Columns[15].FillWeight = 6;
            dataGridView1.Columns[16].FillWeight = 6;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = false;
            dataGridView1.Columns[4].ReadOnly = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsDetailForm toolsDetailForm = new ToolsDetailForm(GetOneToolsInfoFromGrid());
            toolsDetailForm.ShowDialog();
        }

        private ToolsInfo[] GetToolsInfoFromGrid()
        {
            List<ToolsInfo> ktls = new List<ToolsInfo>();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环
            {
                ktls.Add(new ToolsInfo
                {
                    SerialNum = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Model = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Name = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    TorqueMin = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                    TorqueMax = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                    Accuracy = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                    Section = dataGridView1.Rows[i].Cells[7].Value.ToString(),
                    Workstation = dataGridView1.Rows[i].Cells[8].Value.ToString(),
                    DemarcateCycle = int.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()),
                    Status = dataGridView1.Rows[i].Cells[10].Value.ToString(),
                    QualityAssureDate = dataGridView1.Rows[i].Cells[11].Value.ToString(),
                    MaintainContractStyle = dataGridView1.Rows[i].Cells[12].Value.ToString(),
                    MaintainContractDate = dataGridView1.Rows[i].Cells[13].Value.ToString(),
                    RepairTimes = int.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString()),
                    ChangeRecord = dataGridView1.Rows[i].Cells[15].Value.ToString(),
                    Remark = dataGridView1.Rows[i].Cells[16].Value.ToString()
                });
            }
            return ktls.ToArray();
        }

        private ToolsInfo GetOneToolsInfoFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new ToolsInfo
            {
                SerialNum = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                Model = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                Category = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                Name = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                TorqueMin = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()),
                TorqueMax = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()),
                Accuracy = int.Parse(dataGridView1.SelectedRows[0].Cells[6].Value.ToString()),
                Section = dataGridView1.SelectedRows[0].Cells[7].Value.ToString(),
                Workstation = dataGridView1.SelectedRows[0].Cells[8].Value.ToString(),
                DemarcateCycle = int.Parse(dataGridView1.SelectedRows[0].Cells[9].Value.ToString()),
                Status = dataGridView1.SelectedRows[0].Cells[10].Value.ToString(),
                QualityAssureDate = dataGridView1.SelectedRows[0].Cells[11].Value.ToString(),
                MaintainContractStyle = dataGridView1.SelectedRows[0].Cells[12].Value.ToString(),
                MaintainContractDate = dataGridView1.SelectedRows[0].Cells[13].Value.ToString(),
                RepairTimes = int.Parse(dataGridView1.SelectedRows[0].Cells[14].Value.ToString()),
                ChangeRecord = dataGridView1.SelectedRows[0].Cells[15].Value.ToString(),
                Remark = dataGridView1.SelectedRows[0].Cells[16].Value.ToString()
            };
        }
    }
}
