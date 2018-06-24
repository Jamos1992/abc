namespace manageSystem.src.maintain_manage
{
    partial class MaintainRegisterForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintainRegisterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDemarcateDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSerialNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDataView = new System.Windows.Forms.TabControl();
            this.tabNotInPlan = new System.Windows.Forms.TabPage();
            this.dgvNotInPlan = new System.Windows.Forms.DataGridView();
            this.tabInPlan = new System.Windows.Forms.TabPage();
            this.dgvInPlan = new System.Windows.Forms.DataGridView();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.nudTimes = new System.Windows.Forms.NumericUpDown();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActionCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ToolSerialNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolModelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolWorkstationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CycleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDataView.SuspendLayout();
            this.tabNotInPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotInPlan)).BeginInit();
            this.tabInPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabDataView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 422);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.nudTimes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dtpDemarcateDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCycle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSerialNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 57);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养登记信息";
            // 
            // dtpDemarcateDate
            // 
            this.dtpDemarcateDate.Font = new System.Drawing.Font("宋体", 10F);
            this.dtpDemarcateDate.Location = new System.Drawing.Point(415, 22);
            this.dtpDemarcateDate.Name = "dtpDemarcateDate";
            this.dtpDemarcateDate.Size = new System.Drawing.Size(106, 23);
            this.dtpDemarcateDate.TabIndex = 5;
            this.dtpDemarcateDate.DropDown += new System.EventHandler(this.dtpDemarcateDate_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(333, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "保养起始日期";
            // 
            // cmbCycle
            // 
            this.cmbCycle.Font = new System.Drawing.Font("宋体", 10F);
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Location = new System.Drawing.Point(256, 23);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(64, 21);
            this.cmbCycle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(197, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "保养周期";
            // 
            // cmbSerialNum
            // 
            this.cmbSerialNum.Font = new System.Drawing.Font("宋体", 10F);
            this.cmbSerialNum.FormattingEnabled = true;
            this.cmbSerialNum.Location = new System.Drawing.Point(76, 23);
            this.cmbSerialNum.Name = "cmbSerialNum";
            this.cmbSerialNum.Size = new System.Drawing.Size(109, 21);
            this.cmbSerialNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工具序列号";
            // 
            // tabDataView
            // 
            this.tabDataView.Controls.Add(this.tabNotInPlan);
            this.tabDataView.Controls.Add(this.tabInPlan);
            this.tabDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataView.Location = new System.Drawing.Point(3, 66);
            this.tabDataView.Name = "tabDataView";
            this.tabDataView.SelectedIndex = 0;
            this.tabDataView.Size = new System.Drawing.Size(800, 353);
            this.tabDataView.TabIndex = 8;
            this.tabDataView.SelectedIndexChanged += new System.EventHandler(this.tabDataView_SelectedIndexChanged);
            // 
            // tabNotInPlan
            // 
            this.tabNotInPlan.Controls.Add(this.dgvNotInPlan);
            this.tabNotInPlan.Location = new System.Drawing.Point(4, 22);
            this.tabNotInPlan.Name = "tabNotInPlan";
            this.tabNotInPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotInPlan.Size = new System.Drawing.Size(792, 327);
            this.tabNotInPlan.TabIndex = 0;
            this.tabNotInPlan.Text = "未进入保养计划";
            this.tabNotInPlan.UseVisualStyleBackColor = true;
            // 
            // dgvNotInPlan
            // 
            this.dgvNotInPlan.AllowUserToAddRows = false;
            this.dgvNotInPlan.AllowUserToDeleteRows = false;
            this.dgvNotInPlan.AllowUserToOrderColumns = true;
            this.dgvNotInPlan.AllowUserToResizeRows = false;
            this.dgvNotInPlan.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotInPlan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNotInPlan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotInPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotInPlan.ColumnHeadersHeight = 30;
            this.dgvNotInPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNotInPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCol,
            this.SerialNumCol,
            this.ModelCol,
            this.CategoryCol,
            this.ActionCol});
            this.dgvNotInPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotInPlan.GridColor = System.Drawing.Color.Silver;
            this.dgvNotInPlan.Location = new System.Drawing.Point(3, 3);
            this.dgvNotInPlan.MultiSelect = false;
            this.dgvNotInPlan.Name = "dgvNotInPlan";
            this.dgvNotInPlan.RowHeadersVisible = false;
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvNotInPlan.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotInPlan.RowTemplate.Height = 30;
            this.dgvNotInPlan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotInPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotInPlan.Size = new System.Drawing.Size(786, 321);
            this.dgvNotInPlan.TabIndex = 9;
            // 
            // tabInPlan
            // 
            this.tabInPlan.Controls.Add(this.dgvInPlan);
            this.tabInPlan.Location = new System.Drawing.Point(4, 22);
            this.tabInPlan.Name = "tabInPlan";
            this.tabInPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabInPlan.Size = new System.Drawing.Size(792, 327);
            this.tabInPlan.TabIndex = 1;
            this.tabInPlan.Text = "保养计划中";
            this.tabInPlan.UseVisualStyleBackColor = true;
            // 
            // dgvInPlan
            // 
            this.dgvInPlan.AllowUserToAddRows = false;
            this.dgvInPlan.AllowUserToDeleteRows = false;
            this.dgvInPlan.AllowUserToOrderColumns = true;
            this.dgvInPlan.AllowUserToResizeRows = false;
            this.dgvInPlan.BackgroundColor = System.Drawing.Color.White;
            this.dgvInPlan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInPlan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInPlan.ColumnHeadersHeight = 30;
            this.dgvInPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.ToolSerialNameCol,
            this.ToolModelCol,
            this.ToolWorkstationCol,
            this.CycleCol,
            this.NextTimeCol,
            this.dataGridViewButtonColumn1});
            this.dgvInPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInPlan.GridColor = System.Drawing.Color.Silver;
            this.dgvInPlan.Location = new System.Drawing.Point(3, 3);
            this.dgvInPlan.MultiSelect = false;
            this.dgvInPlan.Name = "dgvInPlan";
            this.dgvInPlan.RowHeadersVisible = false;
            this.dgvInPlan.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvInPlan.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvInPlan.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dgvInPlan.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvInPlan.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvInPlan.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInPlan.RowTemplate.Height = 30;
            this.dgvInPlan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInPlan.Size = new System.Drawing.Size(786, 321);
            this.dgvInPlan.TabIndex = 9;
            this.dgvInPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInPlan_CellContentClick);
            // 
            // IDCol
            // 
            this.IDCol.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.IDCol.HeaderText = "编号";
            this.IDCol.Name = "IDCol";
            this.IDCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IDCol.Width = 40;
            // 
            // SerialNumCol
            // 
            this.SerialNumCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SerialNumCol.DataPropertyName = "SerialNum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SerialNumCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.SerialNumCol.HeaderText = "工具序列号";
            this.SerialNumCol.Name = "SerialNumCol";
            this.SerialNumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ModelCol
            // 
            this.ModelCol.DataPropertyName = "Model";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ModelCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.ModelCol.HeaderText = "工具型号";
            this.ModelCol.Name = "ModelCol";
            this.ModelCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelCol.Width = 200;
            // 
            // CategoryCol
            // 
            this.CategoryCol.DataPropertyName = "Workstation";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CategoryCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.CategoryCol.HeaderText = "工位号";
            this.CategoryCol.Name = "CategoryCol";
            this.CategoryCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryCol.Width = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(532, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "次数";
            // 
            // nudTimes
            // 
            this.nudTimes.Location = new System.Drawing.Point(567, 23);
            this.nudTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimes.Name = "nudTimes";
            this.nudTimes.Size = new System.Drawing.Size(49, 21);
            this.nudTimes.TabIndex = 8;
            this.nudTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(726, 22);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "   删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(652, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "   添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn2.HeaderText = "操作";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "保养完成";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 80;
            // 
            // ActionCol
            // 
            this.ActionCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActionCol.HeaderText = "操作";
            this.ActionCol.Name = "ActionCol";
            this.ActionCol.Text = "加入保养";
            this.ActionCol.UseColumnTextForButtonValue = true;
            this.ActionCol.Width = 120;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "0";
            this.dataGridViewCheckBoxColumn1.HeaderText = "全选";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "1";
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // ToolSerialNameCol
            // 
            this.ToolSerialNameCol.DataPropertyName = "ToolSerialName";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ToolSerialNameCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.ToolSerialNameCol.HeaderText = "工具序列号";
            this.ToolSerialNameCol.Name = "ToolSerialNameCol";
            this.ToolSerialNameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToolSerialNameCol.Width = 150;
            // 
            // ToolModelCol
            // 
            this.ToolModelCol.DataPropertyName = "ToolModel";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ToolModelCol.DefaultCellStyle = dataGridViewCellStyle8;
            this.ToolModelCol.HeaderText = "工具型号";
            this.ToolModelCol.Name = "ToolModelCol";
            this.ToolModelCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToolModelCol.Width = 150;
            // 
            // ToolWorkstationCol
            // 
            this.ToolWorkstationCol.DataPropertyName = "ToolWorkstation";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ToolWorkstationCol.DefaultCellStyle = dataGridViewCellStyle9;
            this.ToolWorkstationCol.HeaderText = "工位号";
            this.ToolWorkstationCol.Name = "ToolWorkstationCol";
            this.ToolWorkstationCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToolWorkstationCol.Width = 130;
            // 
            // CycleCol
            // 
            this.CycleCol.DataPropertyName = "Cycle";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CycleCol.DefaultCellStyle = dataGridViewCellStyle10;
            this.CycleCol.HeaderText = "周期";
            this.CycleCol.Name = "CycleCol";
            this.CycleCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CycleCol.Width = 80;
            // 
            // NextTimeCol
            // 
            this.NextTimeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NextTimeCol.DataPropertyName = "NextTime";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NextTimeCol.DefaultCellStyle = dataGridViewCellStyle11;
            this.NextTimeCol.HeaderText = "下次保养时间";
            this.NextTimeCol.Name = "NextTimeCol";
            this.NextTimeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "修改";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 80;
            // 
            // MaintainRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaintainRegisterForm";
            this.Text = "MaintainForm";
            this.Load += new System.EventHandler(this.MaintainRegisterForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDataView.ResumeLayout(false);
            this.tabNotInPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotInPlan)).EndInit();
            this.tabInPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpDemarcateDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSerialNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabDataView;
        private System.Windows.Forms.TabPage tabNotInPlan;
        private System.Windows.Forms.DataGridView dgvNotInPlan;
        private System.Windows.Forms.TabPage tabInPlan;
        private System.Windows.Forms.DataGridView dgvInPlan;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryCol;
        private System.Windows.Forms.DataGridViewButtonColumn ActionCol;
        private System.Windows.Forms.NumericUpDown nudTimes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolSerialNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolModelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolWorkstationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CycleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextTimeCol;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}