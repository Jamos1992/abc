using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace manageSystem.src.demarcate_manage
{
    public partial class QRCodePrintForm : Form
    {
        private DemarcateRecords demarcateRecords = new DemarcateRecords();
        public QRCodePrintForm()
        {
            InitializeComponent();
            this.printDocument1.OriginAtMargins = true;//启用页边距
            this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 300);
        }

        public QRCodePrintForm(DemarcateRecords records)
        {
            demarcateRecords = records;
            InitializeComponent();
            this.printDocument1.OriginAtMargins = true;//启用页边距
            this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 300);
        }

        //打印设置
        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }

        //打印预览
        private void btnPrePrint_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        //打印内容的设置
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////打印内容 为 整个Form
            //Image myFormImage;
            //myFormImage = new Bitmap(this.Width, this.Height);
            //Graphics g = Graphics.FromImage(myFormImage);
            //g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //e.Graphics.DrawImage(myFormImage, 0, 0);

            ////打印内容 为 局部的 this.groupBox1
            Bitmap _NewBitmap = new Bitmap((int)(panel1.Width * 1.25), (int)(panel1.Height * 1.25));
            panel1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);

            //打印内容 为 自定义文本内容 
            //Font font = new Font("宋体", 12);
            //Brush bru = Brushes.Blue;
            //for (int i = 1; i <= 5; i++)
            //{
            //    e.Graphics.DrawString("Hello world ", font, bru, i * 20, i * 20);
            //}
            //e.Graphics.DrawString("工具序列号：", new Font(new FontFamily("黑体"), 8), Brushes.Black, 0, 0);
            //e.Graphics.DrawString("工位：", new Font(new FontFamily("黑体"), 8), Brushes.Black, 9, 55);
            //e.Graphics.DrawString("下次标定日期：", new Font(new FontFamily("黑体"), 8), Brushes.Black, 9, 85);
        }
    }
}
