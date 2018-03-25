namespace manageSystem
{
    partial class InfoInputForm
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
            this.components = new System.ComponentModel.Container();
            CCWin.SkinControl.Animation animation2 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoInputForm));
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("单条增删");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("批量录入");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("手动更改工具信息", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("控制器导入工具信息");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("工具信息录入", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            this.skinAnimator1 = new CCWin.SkinControl.SkinAnimator(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinAnimator1
            // 
            this.skinAnimator1.AnimationType = CCWin.SkinControl.AnimationType.Custom;
            this.skinAnimator1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.skinAnimator1.DefaultAnimation = animation2;
            // 
            // treeView1
            // 
            this.skinAnimator1.SetDecoration(this.treeView1, CCWin.SkinControl.DecorationType.None);
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode6.Name = "节点2";
            treeNode6.Text = "单条增删";
            treeNode7.Name = "节点3";
            treeNode7.Text = "批量录入";
            treeNode8.Name = "节点1";
            treeNode8.Text = "手动更改工具信息";
            treeNode9.Name = "节点4";
            treeNode9.Text = "控制器导入工具信息";
            treeNode10.Name = "节点0";
            treeNode10.Text = "工具信息录入";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(169, 358);
            this.treeView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.skinAnimator1.SetDecoration(this.splitContainer1, CCWin.SkinControl.DecorationType.None);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel1, CCWin.SkinControl.DecorationType.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox7);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.textBox8);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.textBox9);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.textBox5);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.textBox6);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.textBox4);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel2, CCWin.SkinControl.DecorationType.None);
            this.splitContainer1.Size = new System.Drawing.Size(800, 358);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label1, CCWin.SkinControl.DecorationType.None);
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手动更改工具信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label2, CCWin.SkinControl.DecorationType.None);
            this.label2.Location = new System.Drawing.Point(44, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "*工具型号";
            // 
            // textBox1
            // 
            this.skinAnimator1.SetDecoration(this.textBox1, CCWin.SkinControl.DecorationType.None);
            this.textBox1.Location = new System.Drawing.Point(116, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.skinAnimator1.SetDecoration(this.textBox2, CCWin.SkinControl.DecorationType.None);
            this.textBox2.Location = new System.Drawing.Point(116, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label3, CCWin.SkinControl.DecorationType.None);
            this.label3.Location = new System.Drawing.Point(56, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "*序列号";
            // 
            // textBox3
            // 
            this.skinAnimator1.SetDecoration(this.textBox3, CCWin.SkinControl.DecorationType.None);
            this.textBox3.Location = new System.Drawing.Point(116, 237);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label4, CCWin.SkinControl.DecorationType.None);
            this.label4.Location = new System.Drawing.Point(50, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "扭矩信息";
            // 
            // textBox4
            // 
            this.skinAnimator1.SetDecoration(this.textBox4, CCWin.SkinControl.DecorationType.None);
            this.textBox4.Location = new System.Drawing.Point(116, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label5, CCWin.SkinControl.DecorationType.None);
            this.label5.Location = new System.Drawing.Point(50, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "工位信息";
            // 
            // textBox5
            // 
            this.skinAnimator1.SetDecoration(this.textBox5, CCWin.SkinControl.DecorationType.None);
            this.textBox5.Location = new System.Drawing.Point(420, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label6, CCWin.SkinControl.DecorationType.None);
            this.label6.Location = new System.Drawing.Point(354, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "质保期至";
            // 
            // textBox6
            // 
            this.skinAnimator1.SetDecoration(this.textBox6, CCWin.SkinControl.DecorationType.None);
            this.textBox6.Location = new System.Drawing.Point(116, 286);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label7, CCWin.SkinControl.DecorationType.None);
            this.label7.Location = new System.Drawing.Point(26, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "工位当前状态";
            // 
            // textBox7
            // 
            this.skinAnimator1.SetDecoration(this.textBox7, CCWin.SkinControl.DecorationType.None);
            this.textBox7.Location = new System.Drawing.Point(420, 237);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label8, CCWin.SkinControl.DecorationType.None);
            this.label8.Location = new System.Drawing.Point(362, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "备注信息";
            // 
            // textBox8
            // 
            this.skinAnimator1.SetDecoration(this.textBox8, CCWin.SkinControl.DecorationType.None);
            this.textBox8.Location = new System.Drawing.Point(420, 190);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 21);
            this.textBox8.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label9, CCWin.SkinControl.DecorationType.None);
            this.label9.Location = new System.Drawing.Point(337, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "保养合同起止";
            // 
            // textBox9
            // 
            this.skinAnimator1.SetDecoration(this.textBox9, CCWin.SkinControl.DecorationType.None);
            this.textBox9.Location = new System.Drawing.Point(420, 140);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 21);
            this.textBox9.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label10, CCWin.SkinControl.DecorationType.None);
            this.label10.Location = new System.Drawing.Point(338, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "保养合同类型";
            // 
            // button1
            // 
            this.skinAnimator1.SetDecoration(this.button1, CCWin.SkinControl.DecorationType.None);
            this.button1.Location = new System.Drawing.Point(356, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "录入";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label11, CCWin.SkinControl.DecorationType.None);
            this.label11.Location = new System.Drawing.Point(472, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "录入状态";
            // 
            // InfoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 358);
            this.Controls.Add(this.splitContainer1);
            this.skinAnimator1.SetDecoration(this, CCWin.SkinControl.DecorationType.None);
            this.Name = "InfoInputForm";
            this.Text = "工具信息录入";
            this.Load += new System.EventHandler(this.InfoInputForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinAnimator skinAnimator1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}