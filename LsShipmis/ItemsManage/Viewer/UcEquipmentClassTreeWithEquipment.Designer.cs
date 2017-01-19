namespace ItemsManage.Viewer
{
    partial class UcEquipmentClassTreeWithEquipment
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcEquipmentClassTreeWithEquipment));
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mShowAllClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mShowAllClass,
            this.toolStripSeparator3,
            this.mSelectAll,
            this.mClearAll,
            this.toolStripSeparator1,
            this.mEdit,
            this.mDelete,
            this.toolStripSeparator2,
            this.mRefresh});
            this.rightClickMenu.Name = "contextMenuStrip1";
            this.rightClickMenu.Size = new System.Drawing.Size(214, 154);
            this.rightClickMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // mShowAllClass
            // 
            this.mShowAllClass.Checked = true;
            this.mShowAllClass.CheckOnClick = true;
            this.mShowAllClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mShowAllClass.Name = "mShowAllClass";
            this.mShowAllClass.Size = new System.Drawing.Size(213, 22);
            this.mShowAllClass.Text = "显示所有设备分类";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // mSelectAll
            // 
            this.mSelectAll.Name = "mSelectAll";
            this.mSelectAll.Size = new System.Drawing.Size(213, 22);
            this.mSelectAll.Text = "全选下级设备";
            // 
            // mClearAll
            // 
            this.mClearAll.Name = "mClearAll";
            this.mClearAll.Size = new System.Drawing.Size(213, 22);
            this.mClearAll.Text = "全清下级设备";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // mEdit
            // 
            this.mEdit.Name = "mEdit";
            this.mEdit.Size = new System.Drawing.Size(213, 22);
            this.mEdit.Text = "编辑(Edit)";
            this.mEdit.ToolTipText = "只可以编辑分类部分(only the Equipment Class Define Items CAN be Edited)";
            // 
            // mDelete
            // 
            this.mDelete.Name = "mDelete";
            this.mDelete.Size = new System.Drawing.Size(213, 22);
            this.mDelete.Text = "删除(Delete or Remove)";
            this.mDelete.ToolTipText = "最低级分类可以被删除,设备只能移除与分类的关联关系\r\n(This operation can Delete an Equipment Class Definiti" +
                "on OR  the RELATIONSHIP between the Equipment and it\'s Class!)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // mRefresh
            // 
            this.mRefresh.Name = "mRefresh";
            this.mRefresh.Size = new System.Drawing.Size(213, 22);
            this.mRefresh.Text = "刷新(Refresh)";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ship");
            this.imageList.Images.SetKeyName(1, "EquipClass");
            this.imageList.Images.SetKeyName(2, "equipment");
            this.imageList.Images.SetKeyName(3, "open");
            this.imageList.Images.SetKeyName(4, "equipwithpic");
            // 
            // UcEquipmentClassTreeWithEquipment
            // 
            this.ContextMenuStrip = this.rightClickMenu;
            this.ImageIndex = 0;
            this.ImageList = this.imageList;
            this.SelectedImageIndex = 0;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UcEquipmentClassTreeWithEquipment_MouseUp);
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.UcEquipmentClassTreeWithEquipment_AfterSelect);
            this.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.UcEquipmentClassTreeWithEquipment_BeforeCheck);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem mEdit;
        private System.Windows.Forms.ToolStripMenuItem mDelete;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem mRefresh;
        private System.Windows.Forms.ToolStripMenuItem mSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mShowAllClass;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
