using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem
{
    public partial class QueryRepoSpareForm : Form
    {
        public QueryRepoSpareForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryOneRecord(textBox1, textBox7, textBox13);
            queryOneRecord(textBox2, textBox8, textBox14);
            queryOneRecord(textBox3, textBox9, textBox15);
            queryOneRecord(textBox4, textBox10, textBox16);
            queryOneRecord(textBox5, textBox11, textBox17);
            queryOneRecord(textBox6, textBox12, textBox18);
        }

        private void queryOneRecord(TextBox txtBox1, TextBox txtBox2, TextBox txtBox3)
        {
            if (txtBox1.Text == "")
            {
                txtBox2.Text = "";
                txtBox3.Text = "";
                return;
            }
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("RepoSpareTool", new string[] { "*" }, new string[] { "SpareToolModel" }, new string[] { "=" }, new string[] { txtBox1.Text });
            if (!reader.HasRows)
            {
                txtBox2.Text = "0";
                txtBox3.Text = "null";
                return;
            }
            txtBox2.Text = reader.GetValues().Get("Num").ToString();
            txtBox3.Text = reader.GetValues().Get("Time").ToString();
        }
    }
}
