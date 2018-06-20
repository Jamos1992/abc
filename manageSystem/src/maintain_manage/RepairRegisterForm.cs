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
            setDateTimePickerEmpty(dtpSendTime);
            setComboBoxItems();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void setComboBoxItems()
        {
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            if (list == null) return;
            txtModel.AutoCompleteCustomSource.AddRange(list.ToArray());
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
            setDateTimePickerNormal(dtpSendTime);
        }

        private MaintainManageInfo getAllInput()
        {
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolModeName = txtModel.Text;
            maintainManageInfo.ToolSerialName =  cboSerialNum.Text;
            maintainManageInfo.SendFixTime = dtpSendTime.Text;
            maintainManageInfo.Detail = rtxtDetail.Text;
            maintainManageInfo.Status = "待维修";
            maintainManageInfo.UsedOtherSpareToolInfo = null;
            maintainManageInfo.UsedRepoSpareToolInfo = null;
            maintainManageInfo.State = "0";
            return maintainManageInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!toolsInfoManage.IsToolExistInDb(cboSerialNum.Text.Trim()))
            {
                MessageBox.Show($"序列号为{cboSerialNum.Text.Trim()}的工具不在仓库中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            setDateTimePickerEmpty(dtpSendTime);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {          
            cboSerialNum.Items.Clear();
            setComboBoxList(txtModel.Text, cboSerialNum);
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
