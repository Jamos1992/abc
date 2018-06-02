using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Data;
using BLL;

namespace manageSystem.src
{
    public partial class EmailAddressManageForm : Form
    {
        private EmailManage emailManage = new EmailManage();
        public EmailAddressManageForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(emailManage.AddEmailAddress(textBox1.Text.Trim()));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = emailManage.SearchEmailAddress(textBox1.Text.Trim());
            dataGridView1.Columns["EmailAddr"].HeaderText = "邮箱地址";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].FillWeight = 20;
            dataGridView1.Columns[1].FillWeight = 80;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int iCount = dataGridView1.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("Delete Data Fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("是否删除选中的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)  //循环遍历所有行  
                    {
                        if (true == this.dataGridView1.Rows[i].Selected)//当前行处于选中状态，则将其删除  
                        {
                            string emailAddr = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            Console.WriteLine("email is {0}", emailAddr);
                            int affectRow = emailManage.DeleteEmailAddress(emailAddr);
                            if (affectRow < 1)
                            {
                                MessageBox.Show("删除失败！");
                            }
                            break;
                        }
                    }       
                    //删除任意行数据后，应该刷新dataGridView表格，使索引值从上至下按大小顺序排序
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
