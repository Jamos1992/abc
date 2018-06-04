using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateOperationForm : Form
    {
        public DemarcateOperationForm()
        {
            InitializeComponent();
        }

        private void DemarcateOperationForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(Brushes.White, ClientRectangle);
            Pen p = new Pen(Color.Black, 5);
            p.StartCap = LineCap.Custom;
            p.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(p, 30, 30, 80, 30);
            p.Dispose();
        }
    }
}
