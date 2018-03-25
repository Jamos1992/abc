using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class InfoInputForm : Form
    {
        public InfoInputForm()
        {
            InitializeComponent();
        }

        private void InfoInputForm_Load(object sender, EventArgs e)
        {
            this.treeviewInput.ExpandAll();
        }

        private void InfoInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void treeviewInput_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // lablHint.Text = treeviewInput.SelectedNode.Text;
            this.splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Text)
            {
                case "单条增删":
                    SingleInputForm sim = new SingleInputForm();
                    sim.Text = e.Node.Text;
                    sim.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(sim);
                    sim.Show();
                    break;

                case "批量录入":
                    BatchInputForm bim = new BatchInputForm();
                    bim.Text = e.Node.Text;
                    bim.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(bim);
                    bim.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
