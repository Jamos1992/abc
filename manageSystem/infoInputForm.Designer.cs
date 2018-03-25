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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("单条增删");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("批量录入");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("手动更改工具信息", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("控制器导入工具信息");
            CCWin.SkinControl.Animation animation2 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoInputForm));
            this.treeviewInput = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.skinAnimator1 = new CCWin.SkinControl.SkinAnimator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeviewInput
            // 
            this.skinAnimator1.SetDecoration(this.treeviewInput, CCWin.SkinControl.DecorationType.None);
            this.treeviewInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeviewInput.Location = new System.Drawing.Point(0, 0);
            this.treeviewInput.Name = "treeviewInput";
            treeNode5.Name = "节点2";
            treeNode5.Text = "单条增删";
            treeNode6.Name = "节点3";
            treeNode6.Text = "批量录入";
            treeNode7.Name = "节点1";
            treeNode7.Text = "手动更改工具信息";
            treeNode8.Name = "节点4";
            treeNode8.Text = "控制器导入工具信息";
            this.treeviewInput.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeviewInput.Size = new System.Drawing.Size(169, 358);
            this.treeviewInput.TabIndex = 0;
            this.treeviewInput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeviewInput_AfterSelect);
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
            this.splitContainer1.Panel1.Controls.Add(this.treeviewInput);
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel1, CCWin.SkinControl.DecorationType.None);
            // 
            // splitContainer1.Panel2
            // 
            this.skinAnimator1.SetDecoration(this.splitContainer1.Panel2, CCWin.SkinControl.DecorationType.None);
            this.splitContainer1.Size = new System.Drawing.Size(800, 358);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 1;
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
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.skinAnimator1.DefaultAnimation = animation2;
            // 
            // InfoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 358);
            this.Controls.Add(this.splitContainer1);
            this.skinAnimator1.SetDecoration(this, CCWin.SkinControl.DecorationType.None);
            this.Name = "InfoInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工具信息录入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoInputForm_FormClosing);
            this.Load += new System.EventHandler(this.InfoInputForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeviewInput;
        private CCWin.SkinControl.SkinAnimator skinAnimator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}