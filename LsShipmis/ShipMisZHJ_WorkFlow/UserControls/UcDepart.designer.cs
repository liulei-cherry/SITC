namespace ShipMisZHJ_WorkFlow.UserControls
{
    partial class UcDepart
    {
        /// <summary> 
        /// 必需的设计器变量。.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。.
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要.
        /// 使用代码编辑器修改此方法的内容。.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("中海油服");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDepart));
            this.trvDepart = new System.Windows.Forms.TreeView();
            this.imgLstMain = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // trvDepart
            // 
            this.trvDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDepart.HideSelection = false;
            this.trvDepart.ImageIndex = 0;
            this.trvDepart.ImageList = this.imgLstMain;
            this.trvDepart.LabelEdit = true;
            this.trvDepart.Location = new System.Drawing.Point(0, 0);
            this.trvDepart.Name = "trvDepart";
            treeNode1.Name = "tvRootNode";
            treeNode1.Tag = "root";
            treeNode1.Text = "中海油服";
            this.trvDepart.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvDepart.SelectedImageIndex = 0;
            this.trvDepart.Size = new System.Drawing.Size(202, 260);
            this.trvDepart.TabIndex = 1;
            this.trvDepart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDepart_AfterSelect);
            // 
            // imgLstMain
            // 
            this.imgLstMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMain.ImageStream")));
            this.imgLstMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMain.Images.SetKeyName(0, "");
            this.imgLstMain.Images.SetKeyName(1, "ship.jpg");
            this.imgLstMain.Images.SetKeyName(2, "building.jpg");
            this.imgLstMain.Images.SetKeyName(3, "File.gif");
            this.imgLstMain.Images.SetKeyName(4, "addItem.gif");
            this.imgLstMain.Images.SetKeyName(5, "delItem.gif");
            this.imgLstMain.Images.SetKeyName(6, "post.gif");
            this.imgLstMain.Images.SetKeyName(7, "Open.gif");
            // 
            // UcDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trvDepart);
            this.Name = "UcDepart";
            this.Size = new System.Drawing.Size(202, 260);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDepart;
        private System.Windows.Forms.ImageList imgLstMain;
    }
}
