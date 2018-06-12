namespace manageSystem.src.demarcate_manage
{
    partial class QRCodePrintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRCodePrintForm));
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnSetPrint = new System.Windows.Forms.Button();
            this.btnPrePrint = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialName = new System.Windows.Forms.TextBox();
            this.txtWorkstation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCheckman = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDemarNum = new System.Windows.Forms.TextBox();
            this.picQRcode = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRcode)).BeginInit();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // btnSetPrint
            // 
            this.btnSetPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetPrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSetPrint.Location = new System.Drawing.Point(67, 261);
            this.btnSetPrint.Name = "btnSetPrint";
            this.btnSetPrint.Size = new System.Drawing.Size(75, 23);
            this.btnSetPrint.TabIndex = 0;
            this.btnSetPrint.Text = "打印设置";
            this.btnSetPrint.UseVisualStyleBackColor = true;
            this.btnSetPrint.Click += new System.EventHandler(this.btnSetPrint_Click);
            // 
            // btnPrePrint
            // 
            this.btnPrePrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrePrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrePrint.Location = new System.Drawing.Point(177, 261);
            this.btnPrePrint.Name = "btnPrePrint";
            this.btnPrePrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrePrint.TabIndex = 1;
            this.btnPrePrint.Text = "打印预览";
            this.btnPrePrint.UseVisualStyleBackColor = true;
            this.btnPrePrint.Click += new System.EventHandler(this.btnPrePrint_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrint.Location = new System.Drawing.Point(283, 261);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "工具序列号：";
            // 
            // txtSerialName
            // 
            this.txtSerialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialName.Location = new System.Drawing.Point(96, 63);
            this.txtSerialName.Name = "txtSerialName";
            this.txtSerialName.Size = new System.Drawing.Size(100, 21);
            this.txtSerialName.TabIndex = 6;
            // 
            // txtWorkstation
            // 
            this.txtWorkstation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkstation.Location = new System.Drawing.Point(96, 95);
            this.txtWorkstation.Name = "txtWorkstation";
            this.txtWorkstation.Size = new System.Drawing.Size(100, 21);
            this.txtWorkstation.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "工 位 信 息：";
            // 
            // txtValid
            // 
            this.txtValid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValid.Location = new System.Drawing.Point(96, 129);
            this.txtValid.Name = "txtValid";
            this.txtValid.Size = new System.Drawing.Size(100, 21);
            this.txtValid.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(13, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "标定有效期：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 240);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标签信息";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtCheckman);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDemarNum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtWorkstation);
            this.panel1.Controls.Add(this.txtSerialName);
            this.panel1.Controls.Add(this.picQRcode);
            this.panel1.Controls.Add(this.txtValid);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 220);
            this.panel1.TabIndex = 11;
            // 
            // txtCheckman
            // 
            this.txtCheckman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckman.Location = new System.Drawing.Point(96, 163);
            this.txtCheckman.Name = "txtCheckman";
            this.txtCheckman.Size = new System.Drawing.Size(100, 21);
            this.txtCheckman.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(13, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "检   查   员：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "标定序列号：";
            // 
            // txtDemarNum
            // 
            this.txtDemarNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDemarNum.Location = new System.Drawing.Point(96, 31);
            this.txtDemarNum.Name = "txtDemarNum";
            this.txtDemarNum.Size = new System.Drawing.Size(100, 21);
            this.txtDemarNum.TabIndex = 12;
            // 
            // picQRcode
            // 
            this.picQRcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRcode.Location = new System.Drawing.Point(229, 34);
            this.picQRcode.Name = "picQRcode";
            this.picQRcode.Size = new System.Drawing.Size(151, 145);
            this.picQRcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQRcode.TabIndex = 3;
            this.picQRcode.TabStop = false;
            // 
            // QRCodePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 293);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrePrint);
            this.Controls.Add(this.btnSetPrint);
            this.Controls.Add(this.groupBox1);
            this.Name = "QRCodePrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标签打印";
            this.Load += new System.EventHandler(this.QRCodePrintForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btnSetPrint;
        private System.Windows.Forms.Button btnPrePrint;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox picQRcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerialName;
        private System.Windows.Forms.TextBox txtWorkstation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCheckman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDemarNum;
    }
}