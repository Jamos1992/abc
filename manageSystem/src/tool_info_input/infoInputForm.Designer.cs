﻿namespace manageSystem
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("单条录入");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("批量录入");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("信息录入", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("单条查询");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("批量查询");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("信息查询", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            CCWin.SkinControl.Animation animation11 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoInputForm));
            this.treeviewInput = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.skinAnimator1 = new CCWin.SkinControl.SkinAnimator(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeviewInput
            // 
            this.skinAnimator1.SetDecoration(this.treeviewInput, CCWin.SkinControl.DecorationType.None);
            this.treeviewInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeviewInput.ImageIndex = 0;
            this.treeviewInput.ImageList = this.imageList1;
            this.treeviewInput.LabelEdit = true;
            this.treeviewInput.Location = new System.Drawing.Point(0, 0);
            this.treeviewInput.Name = "treeviewInput";
            treeNode1.Name = "节点1";
            treeNode1.Text = "单条录入";
            treeNode2.Name = "节点2";
            treeNode2.Text = "批量录入";
            treeNode3.Name = "节点0";
            treeNode3.Text = "信息录入";
            treeNode4.Name = "节点4";
            treeNode4.Text = "单条查询";
            treeNode5.Name = "节点5";
            treeNode5.Text = "批量查询";
            treeNode6.Name = "节点3";
            treeNode6.Text = "信息查询";
            this.treeviewInput.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeviewInput.SelectedImageIndex = 0;
            this.treeviewInput.Size = new System.Drawing.Size(169, 404);
            this.treeviewInput.TabIndex = 0;
            this.treeviewInput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeviewInput_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "google_custom_search.png");
            // 
            // splitContainer1
            // 
            this.skinAnimator1.SetDecoration(this.splitContainer1, CCWin.SkinControl.DecorationType.None);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.treeviewInput);
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel1, CCWin.SkinControl.DecorationType.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel2, CCWin.SkinControl.DecorationType.None);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 1;
            // 
            // skinAnimator1
            // 
            this.skinAnimator1.AnimationType = CCWin.SkinControl.AnimationType.Custom;
            this.skinAnimator1.Cursor = null;
            animation11.AnimateOnlyDifferences = true;
            animation11.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.BlindCoeff")));
            animation11.LeafCoeff = 0F;
            animation11.MaxTime = 1F;
            animation11.MinTime = 0F;
            animation11.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.MosaicCoeff")));
            animation11.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation11.MosaicShift")));
            animation11.MosaicSize = 0;
            animation11.Padding = new System.Windows.Forms.Padding(0);
            animation11.RotateCoeff = 0F;
            animation11.RotateLimit = 0F;
            animation11.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.ScaleCoeff")));
            animation11.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.SlideCoeff")));
            animation11.TimeCoeff = 0F;
            animation11.TransparencyCoeff = 0F;
            this.skinAnimator1.DefaultAnimation = animation11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.skinAnimator1.SetDecoration(this.panel1, CCWin.SkinControl.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 213);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label1, CCWin.SkinControl.DecorationType.None);
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinAnimator1.SetDecoration(this.richTextBox1, CCWin.SkinControl.DecorationType.None);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(167, 211);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "\n操作说明：\n1、在表格内填入工具所有信息\n2、点击\"录入\"存盘\n3、点击\"清空\"删除所有表格内容";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.skinAnimator1.SetDecoration(this.tableLayoutPanel1, CCWin.SkinControl.DecorationType.None);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.skinAnimator1.SetDecoration(this.label2, CCWin.SkinControl.DecorationType.None);
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
            this.Controls.Add(this.splitContainer1);
            this.skinAnimator1.SetDecoration(this, CCWin.SkinControl.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InfoInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工具信息录入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoInputForm_FormClosing);
            this.Load += new System.EventHandler(this.InfoInputForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeviewInput;
        private CCWin.SkinControl.SkinAnimator skinAnimator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
    }
}