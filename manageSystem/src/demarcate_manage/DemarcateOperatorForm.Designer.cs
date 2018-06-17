namespace manageSystem.src.demarcate_manage
{
    partial class DemarcateOperatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemarcateOperatorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanInput = new System.Windows.Forms.Button();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbStep = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLastStep = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheckMan = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "串口参数设置";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton2.Text = "重新标定";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 362);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCheckMan);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnScanInput);
            this.panel2.Controls.Add(this.txtSerialNum);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 284);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(222, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "(直接输入，或点击“扫码输入”后用扫码枪扫描二维码)";
            // 
            // btnScanInput
            // 
            this.btnScanInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScanInput.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnScanInput.Image = ((System.Drawing.Image)(resources.GetObject("btnScanInput.Image")));
            this.btnScanInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanInput.Location = new System.Drawing.Point(446, 111);
            this.btnScanInput.Name = "btnScanInput";
            this.btnScanInput.Size = new System.Drawing.Size(82, 23);
            this.btnScanInput.TabIndex = 2;
            this.btnScanInput.Text = "   扫码输入";
            this.btnScanInput.UseVisualStyleBackColor = true;
            this.btnScanInput.Click += new System.EventHandler(this.btnScanInput_Click);
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(298, 112);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(125, 21);
            this.txtSerialNum.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "工具序列号：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbStep);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 66);
            this.panel1.TabIndex = 0;
            // 
            // gbStep
            // 
            this.gbStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStep.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbStep.Location = new System.Drawing.Point(0, 0);
            this.gbStep.Name = "gbStep";
            this.gbStep.Size = new System.Drawing.Size(800, 66);
            this.gbStep.TabIndex = 6;
            this.gbStep.TabStop = false;
            this.gbStep.Text = "标定流程";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLastStep);
            this.panel3.Controls.Add(this.btnNextStep);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 387);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 35);
            this.panel3.TabIndex = 10;
            // 
            // btnLastStep
            // 
            this.btnLastStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLastStep.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLastStep.Location = new System.Drawing.Point(12, 6);
            this.btnLastStep.Name = "btnLastStep";
            this.btnLastStep.Size = new System.Drawing.Size(75, 23);
            this.btnLastStep.TabIndex = 0;
            this.btnLastStep.Text = "上一步";
            this.btnLastStep.Click += new System.EventHandler(this.btnLastStep_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNextStep.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNextStep.Location = new System.Drawing.Point(719, 6);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(75, 23);
            this.btnNextStep.TabIndex = 1;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "标定检查员：";
            // 
            // txtCheckMan
            // 
            this.txtCheckMan.Location = new System.Drawing.Point(298, 70);
            this.txtCheckMan.Name = "txtCheckMan";
            this.txtCheckMan.Size = new System.Drawing.Size(125, 21);
            this.txtCheckMan.TabIndex = 5;
            // 
            // DemarcateOperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Name = "DemarcateOperatorForm";
            this.Text = "DemarcateOperatorForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DemarcateOperatorForm_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLastStep;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnScanInput;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheckMan;
        private System.Windows.Forms.Label label2;
    }
}