using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace manageSystem.src.maintain_manage
{
    public partial class AddSpareToolForm : Form
    {
        public event setTextValue setFormTextValue;
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        public AddSpareToolForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            setRepoSpareHint();
        }

        private void setRepoSpareHint()
        {
            List<string> list = repoSpareToolManage.GetSpareModelHintFromDb();
            if (list == null) return;
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int num = (int)numericUpDown1.Value;
            if(num == 0)
            {
                MessageBox.Show("数量必须大于0");
                return;
            }
            setFormTextValue(textBox1.Text,num);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public delegate void setTextValue(string textValue, int num);
}
