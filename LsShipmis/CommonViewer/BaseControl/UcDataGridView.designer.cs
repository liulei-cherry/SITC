namespace CommonViewer
{
    partial class UcDataGridView
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
            if (this._ColHeaderTreeView != null)
            {
                this._ColHeaderTreeView.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            NAR(objApp_Late);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDataGridView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspMnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMnuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tspMnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMnuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMnuSetColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.imgLstMain = new System.Windows.Forms.ImageList(this.components);
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMnuAdd,
            this.tspMnuEdit,
            this.tspMnuDel,
            this.tspSeparator,
            this.tspMnuSearch,
            this.tspMnuOutput,
            this.tspMnuSetColumn});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(157, 142);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // tspMnuAdd
            // 
            this.tspMnuAdd.Name = "tspMnuAdd";
            this.tspMnuAdd.Size = new System.Drawing.Size(156, 22);
            this.tspMnuAdd.Text = "添加数据(&A)…";
            // 
            // tspMnuEdit
            // 
            this.tspMnuEdit.Name = "tspMnuEdit";
            this.tspMnuEdit.Size = new System.Drawing.Size(156, 22);
            this.tspMnuEdit.Text = "修改数据(&E)…";
            // 
            // tspMnuDel
            // 
            this.tspMnuDel.Name = "tspMnuDel";
            this.tspMnuDel.Size = new System.Drawing.Size(156, 22);
            this.tspMnuDel.Text = "删除数据(&D)";
            // 
            // tspSeparator
            // 
            this.tspSeparator.Name = "tspSeparator";
            this.tspSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // tspMnuSearch
            // 
            this.tspMnuSearch.Name = "tspMnuSearch";
            this.tspMnuSearch.Size = new System.Drawing.Size(156, 22);
            this.tspMnuSearch.Text = "信息搜索(&S)…";
            // 
            // tspMnuOutput
            // 
            this.tspMnuOutput.Name = "tspMnuOutput";
            this.tspMnuOutput.Size = new System.Drawing.Size(156, 22);
            this.tspMnuOutput.Text = "导出为Excel(&E)";
            // 
            // tspMnuSetColumn
            // 
            this.tspMnuSetColumn.Name = "tspMnuSetColumn";
            this.tspMnuSetColumn.Size = new System.Drawing.Size(156, 22);
            this.tspMnuSetColumn.Text = "显示列设置";
            // 
            // imgLstMain
            // 
            this.imgLstMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMain.ImageStream")));
            this.imgLstMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMain.Images.SetKeyName(0, "addItem.gif");
            this.imgLstMain.Images.SetKeyName(1, "updatestock.gif");
            this.imgLstMain.Images.SetKeyName(2, "delItem.gif");
            this.imgLstMain.Images.SetKeyName(3, "search1.png");
            this.imgLstMain.Images.SetKeyName(4, "filter.gif");
            this.imgLstMain.Images.SetKeyName(5, "Excel.GIF");
            // 
            // UcDataGridView
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ContextMenuStrip = this.ctxMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RowHeadersWidth = 30;
            this.RowTemplate.Height = 23;
            this.Size = new System.Drawing.Size(400, 250);
            this.DataSourceChanged += new System.EventHandler(this.UcDataGridView_DataSourceChanged);
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem tspMnuAdd;
        private System.Windows.Forms.ToolStripMenuItem tspMnuDel;
        private System.Windows.Forms.ToolStripMenuItem tspMnuEdit;
        private System.Windows.Forms.ToolStripMenuItem tspMnuSearch;
        private System.Windows.Forms.ImageList imgLstMain;
        private System.Windows.Forms.ToolStripMenuItem tspMnuOutput;
        private System.Windows.Forms.ToolStripSeparator tspSeparator;
        private System.Windows.Forms.ToolStripMenuItem tspMnuSetColumn;

    }
}
