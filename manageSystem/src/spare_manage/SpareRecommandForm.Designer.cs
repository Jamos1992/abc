namespace manageSystem.src.spare_manage
{
    partial class SpareRecommandForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpareRecommandForm));
            this.tabCRecommand = new System.Windows.Forms.TabControl();
            this.tabPSeaon = new System.Windows.Forms.TabPage();
            this.tabPHalfYear = new System.Windows.Forms.TabPage();
            this.tabPManual = new System.Windows.Forms.TabPage();
            this.dataVSeaon = new System.Windows.Forms.DataGridView();
            this.dataVHalfYear = new System.Windows.Forms.DataGridView();
            this.dataVRegister = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSerialNum = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CategoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SpareToolModelCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.NumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolsModelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num2Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OperationCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabCRecommand.SuspendLayout();
            this.tabPSeaon.SuspendLayout();
            this.tabPHalfYear.SuspendLayout();
            this.tabPManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVSeaon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVHalfYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVRegister)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCRecommand
            // 
            this.tabCRecommand.Controls.Add(this.tabPSeaon);
            this.tabCRecommand.Controls.Add(this.tabPHalfYear);
            this.tabCRecommand.Controls.Add(this.tabPManual);
            this.tabCRecommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCRecommand.Location = new System.Drawing.Point(0, 0);
            this.tabCRecommand.Name = "tabCRecommand";
            this.tabCRecommand.SelectedIndex = 0;
            this.tabCRecommand.Size = new System.Drawing.Size(806, 422);
            this.tabCRecommand.TabIndex = 0;
            // 
            // tabPSeaon
            // 
            this.tabPSeaon.Controls.Add(this.dataVSeaon);
            this.tabPSeaon.Location = new System.Drawing.Point(4, 22);
            this.tabPSeaon.Name = "tabPSeaon";
            this.tabPSeaon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPSeaon.Size = new System.Drawing.Size(798, 396);
            this.tabPSeaon.TabIndex = 0;
            this.tabPSeaon.Text = "近三个月消耗总量排行";
            this.tabPSeaon.UseVisualStyleBackColor = true;
            // 
            // tabPHalfYear
            // 
            this.tabPHalfYear.Controls.Add(this.dataVHalfYear);
            this.tabPHalfYear.Location = new System.Drawing.Point(4, 22);
            this.tabPHalfYear.Name = "tabPHalfYear";
            this.tabPHalfYear.Padding = new System.Windows.Forms.Padding(3);
            this.tabPHalfYear.Size = new System.Drawing.Size(798, 396);
            this.tabPHalfYear.TabIndex = 1;
            this.tabPHalfYear.Text = "近半年消耗比例排行";
            this.tabPHalfYear.UseVisualStyleBackColor = true;
            // 
            // tabPManual
            // 
            this.tabPManual.Controls.Add(this.dataVRegister);
            this.tabPManual.Controls.Add(this.groupBox1);
            this.tabPManual.Location = new System.Drawing.Point(4, 22);
            this.tabPManual.Name = "tabPManual";
            this.tabPManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPManual.Size = new System.Drawing.Size(798, 396);
            this.tabPManual.TabIndex = 2;
            this.tabPManual.Text = "手动登记";
            this.tabPManual.UseVisualStyleBackColor = true;
            // 
            // dataVSeaon
            // 
            this.dataVSeaon.AllowUserToAddRows = false;
            this.dataVSeaon.AllowUserToDeleteRows = false;
            this.dataVSeaon.AllowUserToOrderColumns = true;
            this.dataVSeaon.AllowUserToResizeRows = false;
            this.dataVSeaon.BackgroundColor = System.Drawing.Color.White;
            this.dataVSeaon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataVSeaon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVSeaon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataVSeaon.ColumnHeadersHeight = 30;
            this.dataVSeaon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataVSeaon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckCol,
            this.SpareToolModelCol,
            this.NumCol});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVSeaon.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataVSeaon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVSeaon.GridColor = System.Drawing.Color.Silver;
            this.dataVSeaon.Location = new System.Drawing.Point(3, 3);
            this.dataVSeaon.MultiSelect = false;
            this.dataVSeaon.Name = "dataVSeaon";
            this.dataVSeaon.RowHeadersVisible = false;
            this.dataVSeaon.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataVSeaon.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVSeaon.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataVSeaon.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dataVSeaon.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVSeaon.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVSeaon.RowTemplate.Height = 30;
            this.dataVSeaon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVSeaon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataVSeaon.Size = new System.Drawing.Size(792, 390);
            this.dataVSeaon.TabIndex = 80;
            // 
            // dataVHalfYear
            // 
            this.dataVHalfYear.AllowUserToAddRows = false;
            this.dataVHalfYear.AllowUserToDeleteRows = false;
            this.dataVHalfYear.AllowUserToOrderColumns = true;
            this.dataVHalfYear.AllowUserToResizeRows = false;
            this.dataVHalfYear.BackgroundColor = System.Drawing.Color.White;
            this.dataVHalfYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataVHalfYear.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVHalfYear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataVHalfYear.ColumnHeadersHeight = 30;
            this.dataVHalfYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataVHalfYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.CategoryCol,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVHalfYear.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataVHalfYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVHalfYear.GridColor = System.Drawing.Color.Silver;
            this.dataVHalfYear.Location = new System.Drawing.Point(3, 3);
            this.dataVHalfYear.MultiSelect = false;
            this.dataVHalfYear.Name = "dataVHalfYear";
            this.dataVHalfYear.RowHeadersVisible = false;
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVHalfYear.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVHalfYear.RowTemplate.Height = 30;
            this.dataVHalfYear.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVHalfYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataVHalfYear.Size = new System.Drawing.Size(792, 390);
            this.dataVHalfYear.TabIndex = 81;
            // 
            // dataVRegister
            // 
            this.dataVRegister.AllowUserToAddRows = false;
            this.dataVRegister.AllowUserToDeleteRows = false;
            this.dataVRegister.AllowUserToOrderColumns = true;
            this.dataVRegister.AllowUserToResizeRows = false;
            this.dataVRegister.BackgroundColor = System.Drawing.Color.White;
            this.dataVRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataVRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataVRegister.ColumnHeadersHeight = 30;
            this.dataVRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataVRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewLinkColumn2,
            this.ToolsModelCol,
            this.Num2Col,
            this.OperationCol});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVRegister.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataVRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVRegister.GridColor = System.Drawing.Color.Silver;
            this.dataVRegister.Location = new System.Drawing.Point(3, 63);
            this.dataVRegister.MultiSelect = false;
            this.dataVRegister.Name = "dataVRegister";
            this.dataVRegister.RowHeadersVisible = false;
            this.dataVRegister.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataVRegister.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVRegister.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataVRegister.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dataVRegister.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataVRegister.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVRegister.RowTemplate.Height = 30;
            this.dataVRegister.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataVRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataVRegister.Size = new System.Drawing.Size(792, 330);
            this.dataVRegister.TabIndex = 81;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSerialNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 60);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手动登记";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "备件型号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtModel
            // 
            this.txtModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtModel.Location = new System.Drawing.Point(71, 25);
            this.txtModel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(129, 21);
            this.txtModel.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(224, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "*工具序列号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSerialNum
            // 
            this.cmbSerialNum.FormattingEnabled = true;
            this.cmbSerialNum.Location = new System.Drawing.Point(301, 25);
            this.cmbSerialNum.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.cmbSerialNum.Name = "cmbSerialNum";
            this.cmbSerialNum.Size = new System.Drawing.Size(129, 20);
            this.cmbSerialNum.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(464, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "*数量";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(506, 25);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown1.TabIndex = 22;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "0";
            this.dataGridViewCheckBoxColumn1.HeaderText = "全选";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "1";
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // CategoryCol
            // 
            this.CategoryCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryCol.DataPropertyName = "Category";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CategoryCol.DefaultCellStyle = dataGridViewCellStyle19;
            this.CategoryCol.HeaderText = "工具类型";
            this.CategoryCol.Name = "CategoryCol";
            this.CategoryCol.ReadOnly = true;
            this.CategoryCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoryCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NextTime";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn1.HeaderText = "6个月内维修比例";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // CheckCol
            // 
            this.CheckCol.FalseValue = "0";
            this.CheckCol.HeaderText = "全选";
            this.CheckCol.Name = "CheckCol";
            this.CheckCol.TrueValue = "1";
            this.CheckCol.Visible = false;
            this.CheckCol.Width = 40;
            // 
            // SpareToolModelCol
            // 
            this.SpareToolModelCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SpareToolModelCol.DataPropertyName = "SpareToolModel";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SpareToolModelCol.DefaultCellStyle = dataGridViewCellStyle15;
            this.SpareToolModelCol.HeaderText = "备件型号";
            this.SpareToolModelCol.Name = "SpareToolModelCol";
            this.SpareToolModelCol.ReadOnly = true;
            this.SpareToolModelCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NumCol
            // 
            this.NumCol.DataPropertyName = "Num";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NumCol.DefaultCellStyle = dataGridViewCellStyle16;
            this.NumCol.HeaderText = "数量";
            this.NumCol.Name = "NumCol";
            this.NumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumCol.Width = 250;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.FalseValue = "0";
            this.dataGridViewCheckBoxColumn2.HeaderText = "全选";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.TrueValue = "1";
            this.dataGridViewCheckBoxColumn2.Visible = false;
            this.dataGridViewCheckBoxColumn2.Width = 40;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn2.DataPropertyName = "SpareToolModel";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewLinkColumn2.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewLinkColumn2.HeaderText = "备件型号";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToolsModelCol
            // 
            this.ToolsModelCol.DataPropertyName = "ToolsModel";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ToolsModelCol.DefaultCellStyle = dataGridViewCellStyle24;
            this.ToolsModelCol.HeaderText = "工具型号";
            this.ToolsModelCol.Name = "ToolsModelCol";
            this.ToolsModelCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToolsModelCol.Width = 200;
            // 
            // Num2Col
            // 
            this.Num2Col.DataPropertyName = "Num";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Num2Col.DefaultCellStyle = dataGridViewCellStyle25;
            this.Num2Col.HeaderText = "数量";
            this.Num2Col.Name = "Num2Col";
            this.Num2Col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // OperationCol
            // 
            this.OperationCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OperationCol.HeaderText = "操作";
            this.OperationCol.Name = "OperationCol";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(678, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 15, 3, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 21);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "   登记";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // SpareRecommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 422);
            this.Controls.Add(this.tabCRecommand);
            this.Name = "SpareRecommandForm";
            this.Text = "SpareRecommandForm";
            this.Load += new System.EventHandler(this.SpareRecommandForm_Load);
            this.tabCRecommand.ResumeLayout(false);
            this.tabPSeaon.ResumeLayout(false);
            this.tabPHalfYear.ResumeLayout(false);
            this.tabPManual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataVSeaon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVHalfYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVRegister)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCRecommand;
        private System.Windows.Forms.TabPage tabPSeaon;
        private System.Windows.Forms.TabPage tabPHalfYear;
        private System.Windows.Forms.TabPage tabPManual;
        private System.Windows.Forms.DataGridView dataVSeaon;
        private System.Windows.Forms.DataGridView dataVHalfYear;
        private System.Windows.Forms.DataGridView dataVRegister;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSerialNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckCol;
        private System.Windows.Forms.DataGridViewLinkColumn SpareToolModelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolsModelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num2Col;
        private System.Windows.Forms.DataGridViewButtonColumn OperationCol;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}