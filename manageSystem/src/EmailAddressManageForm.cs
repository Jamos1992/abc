using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Data;

namespace manageSystem.src
{
    public partial class EmailAddressManageForm : Form
    {
        public EmailAddressManageForm()
        {
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";// 定义正则表达式
            Match m = Regex.Match(textBox1.Text, pattern);// 匹配正则表达式
            if (!m.Success)
            {
                MessageBox.Show("邮箱地址格式有误！");
                return;
            }

            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            string queryString = "INSERT INTO EmailAddress VALUES(null," + "'" + this.textBox1.Text + "')";
            try
            {
                db.ExecuteQuery(queryString);
                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("添加失败！");
                return;
            }
            MessageBox.Show("添加成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("EmailAddress", new string[] { "*"},new string[] { "EmailAddr"},new string[] { "like"},new string[] { "'%"+this.textBox1.Text+"%'"});
            if (reader == null || !reader.HasRows)
            {
                MessageBox.Show("邮箱地址不存在！");
                return;
            }
            BindingSource Bs = new BindingSource();
            Bs.DataSource = reader;
            dataGridView1.DataSource = Bs;
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
                            MessageBox.Show("删除失败！!");
                            string emailAddr = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            Console.WriteLine("email is {0}", emailAddr);
                            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
                            SQLiteDataReader reader = db.DeleteValuesAND("EmailAddress", new string[] { "EmailAddr" }, new string[] { emailAddr }, new string[] { "=" });
                            if (reader==null || !reader.HasRows)
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
            //DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            //drv.Row.Delete();

            //SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
    }
}
