using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem.src
{
    public partial class EmailAddressManageForm : Form
    {
        public EmailAddressManageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            EmailAddress emailAddress = new EmailAddress();
            emailAddress.EmailAddr = this.textBox1.Text;
            try
            {
                db.InsertValuesByStruct("EmailAddress", emailAddress);
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
            SQLiteDataReader reader = db.ReadTable("EmailAddress", new string[] { "*"},new string[] { "EmailAddr"},new string[] { "like"},new string[] { this.textBox1.Text});
            if (!reader.HasRows)
            {
                MessageBox.Show("邮箱地址不存在！");
            }
            dataGridView1.DataSource = reader;
        }
    }
}
