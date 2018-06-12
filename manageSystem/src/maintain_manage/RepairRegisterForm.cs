using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairRegisterForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private List<MaintainManageInfo> maintainManageInfoList = new List<MaintainManageInfo>();

        public RepairRegisterForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            setDateTimePickerEmpty(dateTimePicker1);
            setComboBoxItems();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void setComboBoxItems()
        {
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            if (list == null) return;
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());
        }

        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private MaintainManageInfo getAllInput()
        {
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolModeName = textBox1.Text;
            maintainManageInfo.ToolSerialName =  comboBox1.Text;
            maintainManageInfo.SendFixTime = dateTimePicker1.Text;
            maintainManageInfo.Detail = richTextBox1.Text;
            maintainManageInfo.Status = "待维修";
            maintainManageInfo.UsedOtherSpareToolInfo = null;
            maintainManageInfo.UsedRepoSpareToolInfo = null;
            maintainManageInfo.State = "0";
            return maintainManageInfo;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            string msg = maintainInfoManage.RegisterBreakTool(maintainManageInfo);
            if (msg.Contains("成功"))
            {
                maintainManageInfoList.Add(maintainManageInfo);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = maintainManageInfoList;
                return;
            }
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            setDateTimePickerEmpty(dateTimePicker1);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {          
            comboBox1.Items.Clear();
            setComboBoxList(textBox1.Text, comboBox1);
        }
        private void setComboBoxList(string str, ComboBox comboBox)
        {
            List<string> list = toolsInfoManage.GetSerialNumHintFromDb(str);
            if (list == null) return;
            comboBox.Items.AddRange(list.ToArray());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    try
                    {
                        string serialNum = dataGridView1.Rows[e.RowIndex].Cells["SerialNumCol"].Value.ToString();

                        int affectedRow = maintainInfoManage.DeleteOneRegisterTools(serialNum);
                        if(affectedRow < 1)
                        {
                            throw new Exception("删除记录失败");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MaintainManageInfo maintainManageInfo = GetOneToolsInfoFromGrid();
                    for (int i = maintainManageInfoList.Count - 1; i >= 0; i--)
                    {
                        if (maintainManageInfoList[i].ToolSerialName == maintainManageInfo.ToolSerialName)
                        {
                            maintainManageInfoList.Remove(maintainManageInfoList[i]);
                        }
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = maintainManageInfoList;
                }
            }
        }

        private MaintainManageInfo GetOneToolsInfoFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new MaintainManageInfo
            {
                ToolSerialName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                ToolModeName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                SendFixTime = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                Detail = dataGridView1.SelectedRows[0].Cells[3].Value.ToString()
            };
        }
    }
}
