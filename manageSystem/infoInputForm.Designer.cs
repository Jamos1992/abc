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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("手动单条录入");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("手动批量录入");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("控制器导入");
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
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
            treeNode1.Name = "节点2";
            treeNode1.Text = "手动单条录入";
            treeNode2.Name = "节点3";
            treeNode2.Text = "手动批量录入";
            treeNode3.Name = "节点4";
            treeNode3.Text = "控制器导入";
            this.treeviewInput.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeviewInput.Size = new System.Drawing.Size(169, 404);
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 1;
            // 
            // skinAnimator1
            // 
            this.skinAnimator1.AnimationType = CCWin.SkinControl.AnimationType.Custom;
            this.skinAnimator1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.skinAnimator1.DefaultAnimation = animation1;
            // 
            // InfoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
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