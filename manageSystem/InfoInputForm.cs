﻿using System;
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
            //this.treeView1.
            this.splitContainer1.Panel2.Hide();
        }
    }
}
