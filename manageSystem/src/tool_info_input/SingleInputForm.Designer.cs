namespace manageSystem
{
    partial class SingleInputForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.torqueMaxBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modelBox = new System.Windows.Forms.ComboBox();
            this.qualityBox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.maintainBox = new System.Windows.Forms.DateTimePicker();
            this.remarkBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.torqueMinBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.sectionBox = new System.Windows.Forms.ComboBox();
            this.workstationBox = new System.Windows.Forms.ComboBox();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.serialNumBox = new System.Windows.Forms.TextBox();
            this.accuracyBox = new System.Windows.Forms.TextBox();
            this.cycleBox = new System.Windows.Forms.NumericUpDown();
            this.repairTimeBox = new System.Windows.Forms.NumericUpDown();
            this.cbContractStyle = new System.Windows.Forms.ComboBox();
            this.importExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cycleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairTimeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(236, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 28);
            this.button1.TabIndex = 40;
            this.button1.Text = "录入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "备注信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "保养合同类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "质保期至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "累计维修次数";
            // 
            // torqueMaxBox
            // 
            this.torqueMaxBox.Location = new System.Drawing.Point(160, 164);
            this.torqueMaxBox.Name = "torqueMaxBox";
            this.torqueMaxBox.Size = new System.Drawing.Size(123, 21);
            this.torqueMaxBox.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "*工位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "*工具型号";
            // 
            // modelBox
            // 
            this.modelBox.FormattingEnabled = true;
            this.modelBox.Location = new System.Drawing.Point(416, 50);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(123, 20);
            this.modelBox.TabIndex = 42;
            // 
            // qualityBox
            // 
            this.qualityBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.qualityBox.Location = new System.Drawing.Point(416, 299);
            this.qualityBox.Name = "qualityBox";
            this.qualityBox.Size = new System.Drawing.Size(123, 21);
            this.qualityBox.TabIndex = 44;
            this.qualityBox.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "保养合同至";
            // 
            // maintainBox
            // 
            this.maintainBox.Location = new System.Drawing.Point(416, 330);
            this.maintainBox.Name = "maintainBox";
            this.maintainBox.Size = new System.Drawing.Size(123, 21);
            this.maintainBox.TabIndex = 48;
            this.maintainBox.DropDown += new System.EventHandler(this.dateTimePicker3_DropDown);
            // 
            // remarkBox
            // 
            this.remarkBox.Location = new System.Drawing.Point(416, 364);
            this.remarkBox.Name = "remarkBox";
            this.remarkBox.Size = new System.Drawing.Size(123, 21);
            this.remarkBox.TabIndex = 39;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 429);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 44);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(331, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 28);
            this.button3.TabIndex = 52;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(550, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 28);
            this.button2.TabIndex = 51;
            this.button2.Text = "从excel导入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // torqueMinBox
            // 
            this.torqueMinBox.Location = new System.Drawing.Point(160, 136);
            this.torqueMinBox.Name = "torqueMinBox";
            this.torqueMinBox.Size = new System.Drawing.Size(123, 21);
            this.torqueMinBox.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "*序列号";
            // 
            // categoryBox
            // 
            this.categoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Items.AddRange(new object[] {
            "动力工具",
            "手动工具",
            "其他工具"});
            this.categoryBox.Location = new System.Drawing.Point(160, 78);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(123, 20);
            this.categoryBox.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 53;
            this.label11.Text = "*工具类别";
            // 
            // nameBox
            // 
            this.nameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Items.AddRange(new object[] {
            "电池枪",
            "电动枪",
            "定值扳手",
            "滚压枪",
            "脉冲枪",
            "铆钉枪",
            "气动枪",
            "四轴拧紧机",
            "半轴拔出力工装",
            "电池滚压枪"});
            this.nameBox.Location = new System.Drawing.Point(416, 77);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(123, 20);
            this.nameBox.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(344, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "*工具名称";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "*标定扭矩下限(Nm)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 12);
            this.label14.TabIndex = 59;
            this.label14.Text = "*标定扭矩上限(Nm)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(356, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 61;
            this.label15.Text = "*精度(%)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(112, 231);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 63;
            this.label16.Text = "*工段";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(327, 230);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 65;
            this.label17.Text = "*标定周期(天)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(87, 302);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 67;
            this.label18.Text = "*工具状态";
            // 
            // sectionBox
            // 
            this.sectionBox.FormattingEnabled = true;
            this.sectionBox.Items.AddRange(new object[] {
            "其它",
            "仓库备用选项"});
            this.sectionBox.Location = new System.Drawing.Point(160, 227);
            this.sectionBox.Name = "sectionBox";
            this.sectionBox.Size = new System.Drawing.Size(123, 20);
            this.sectionBox.TabIndex = 71;
            // 
            // workstationBox
            // 
            this.workstationBox.FormattingEnabled = true;
            this.workstationBox.Items.AddRange(new object[] {
            "其它",
            "仓库备用选项"});
            this.workstationBox.Location = new System.Drawing.Point(160, 253);
            this.workstationBox.Name = "workstationBox";
            this.workstationBox.Size = new System.Drawing.Size(123, 20);
            this.workstationBox.TabIndex = 72;
            // 
            // statusBox
            // 
            this.statusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Items.AddRange(new object[] {
            "在线使用",
            "备用工具",
            "在修工具",
            "在保养工具",
            "备注"});
            this.statusBox.Location = new System.Drawing.Point(160, 299);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(123, 20);
            this.statusBox.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(0, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(643, 1);
            this.label7.TabIndex = 74;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(0, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 17);
            this.label20.TabIndex = 75;
            this.label20.Text = "工具基本信息";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(0, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 17);
            this.label21.TabIndex = 77;
            this.label21.Text = "工艺扭矩和转角信息";
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(0, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(643, 1);
            this.label22.TabIndex = 76;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(0, 194);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 17);
            this.label23.TabIndex = 79;
            this.label23.Text = "现场使用信息";
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(0, 213);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(643, 1);
            this.label24.TabIndex = 78;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(0, 266);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 17);
            this.label25.TabIndex = 81;
            this.label25.Text = "其它信息";
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Location = new System.Drawing.Point(0, 285);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(643, 1);
            this.label26.TabIndex = 80;
            // 
            // serialNumBox
            // 
            this.serialNumBox.Location = new System.Drawing.Point(160, 50);
            this.serialNumBox.Name = "serialNumBox";
            this.serialNumBox.Size = new System.Drawing.Size(123, 21);
            this.serialNumBox.TabIndex = 82;
            // 
            // accuracyBox
            // 
            this.accuracyBox.Location = new System.Drawing.Point(416, 136);
            this.accuracyBox.Name = "accuracyBox";
            this.accuracyBox.Size = new System.Drawing.Size(123, 21);
            this.accuracyBox.TabIndex = 83;
            // 
            // cycleBox
            // 
            this.cycleBox.Location = new System.Drawing.Point(416, 226);
            this.cycleBox.Name = "cycleBox";
            this.cycleBox.Size = new System.Drawing.Size(123, 21);
            this.cycleBox.TabIndex = 85;
            // 
            // repairTimeBox
            // 
            this.repairTimeBox.Location = new System.Drawing.Point(161, 362);
            this.repairTimeBox.Name = "repairTimeBox";
            this.repairTimeBox.Size = new System.Drawing.Size(123, 21);
            this.repairTimeBox.TabIndex = 86;
            // 
            // cbContractStyle
            // 
            this.cbContractStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContractStyle.FormattingEnabled = true;
            this.cbContractStyle.Items.AddRange(new object[] {
            "Basic Care",
            "Smart Care",
            "Peace of Mind",
            "其它"});
            this.cbContractStyle.Location = new System.Drawing.Point(160, 331);
            this.cbContractStyle.Name = "cbContractStyle";
            this.cbContractStyle.Size = new System.Drawing.Size(123, 20);
            this.cbContractStyle.TabIndex = 87;
            // 
            // importExcelFile
            // 
            this.importExcelFile.FileName = "openFileDialog1";
            // 
            // SingleInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(649, 473);
            this.Controls.Add(this.cbContractStyle);
            this.Controls.Add(this.repairTimeBox);
            this.Controls.Add(this.cycleBox);
            this.Controls.Add(this.accuracyBox);
            this.Controls.Add(this.serialNumBox);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.workstationBox);
            this.Controls.Add(this.sectionBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.torqueMinBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.maintainBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qualityBox);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.remarkBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.torqueMaxBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SingleInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单条信息录入";
            this.Load += new System.EventHandler(this.SingleInputForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cycleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairTimeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox torqueMaxBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modelBox;
        private System.Windows.Forms.DateTimePicker qualityBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker maintainBox;
        private System.Windows.Forms.TextBox remarkBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox torqueMinBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox nameBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox sectionBox;
        private System.Windows.Forms.ComboBox workstationBox;
        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox serialNumBox;
        private System.Windows.Forms.TextBox accuracyBox;
        private System.Windows.Forms.NumericUpDown cycleBox;
        private System.Windows.Forms.NumericUpDown repairTimeBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbContractStyle;
        private System.Windows.Forms.OpenFileDialog importExcelFile;
    }
}