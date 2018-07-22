using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace manageSystem.src
{
    public partial class WorkerListForm : Form
    {
        private CheckManManage checkManManage = new CheckManManage();
        public WorkerListForm()
        {
            InitializeComponent();
        }

        private void WorkerListForm_Load(object sender, EventArgs e)
        {
            List<CheckMan> checkManList = checkManManage.GetAllName();
            if (checkManList == null) return;
            dataGridView1.DataSource = checkManList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    if(MessageBox.Show("确定要删除该驻场人员吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    CheckMan checkMan = getOneCheckManFromGrid();
                    try
                    {
                        int affected = checkManManage.DeleteOneWorker(checkMan.Name);
                        if(affected < 1)
                        {
                            MessageBox.Show("删除失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        WorkerListForm_Load(null, null);
                    }catch(Exception ex)
                    {
                        Console.WriteLine("失败"+ex.Message);
                    }
                                    
                }
            }
        }

        private CheckMan getOneCheckManFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new CheckMan
            {
                Name = dataGridView1.SelectedRows[0].Cells["NameCol"].Value.ToString()
            };
        }
    }
}
