namespace ShipMisZHJ_WorkFlow.Forms
{
    partial class FrmPosiSelect
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosiSelect));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bdNgMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdNgCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bdNgMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bdNgSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bdNgClose = new System.Windows.Forms.ToolStripButton();
            this.dgvPost = new System.Windows.Forms.DataGridView();
            this.ucDepart = new ShipMisZHJ_WorkFlow.UserControls.UcDepart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.26316F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.73684F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucDepart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvPost, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.888631F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.11137F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 431);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
            this.tableLayoutPanel1.SetColumnSpan(this.bdNgMain, 2);
            this.bdNgMain.CountItem = this.bdNgCountItem;
            this.bdNgMain.DeleteItem = null;
            this.bdNgMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bdNgMoveFirstItem,
            this.bdNgMovePreviousItem,
            this.bdNgSeparator,
            this.bdNgPositionItem,
            this.bdNgCountItem,
            this.bdNgSeparator1,
            this.bdNgMoveNextItem,
            this.bdNgMoveLastItem,
            this.bdNgSeparator2,
            this.toolStripButton1,
            this.bdNgClose});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = this.bdNgMoveFirstItem;
            this.bdNgMain.MoveLastItem = this.bdNgMoveLastItem;
            this.bdNgMain.MoveNextItem = this.bdNgMoveNextItem;
            this.bdNgMain.MovePreviousItem = this.bdNgMovePreviousItem;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = this.bdNgPositionItem;
            this.bdNgMain.Size = new System.Drawing.Size(760, 25);
            this.bdNgMain.TabIndex = 11;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // bdNgCountItem
            // 
            this.bdNgCountItem.Name = "bdNgCountItem";
            this.bdNgCountItem.Size = new System.Drawing.Size(35, 22);
            this.bdNgCountItem.Text = "/ {0}";
            this.bdNgCountItem.ToolTipText = "总项数";
            // 
            // bdNgMoveFirstItem
            // 
            this.bdNgMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveFirstItem.Image")));
            this.bdNgMoveFirstItem.Name = "bdNgMoveFirstItem";
            this.bdNgMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveFirstItem.Text = "移到第一条记录";
            // 
            // bdNgMovePreviousItem
            // 
            this.bdNgMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMovePreviousItem.Image")));
            this.bdNgMovePreviousItem.Name = "bdNgMovePreviousItem";
            this.bdNgMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMovePreviousItem.Text = "移到上一条记录";
            // 
            // bdNgSeparator
            // 
            this.bdNgSeparator.Name = "bdNgSeparator";
            this.bdNgSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bdNgPositionItem
            // 
            this.bdNgPositionItem.AccessibleName = "位置";
            this.bdNgPositionItem.AutoSize = false;
            this.bdNgPositionItem.Name = "bdNgPositionItem";
            this.bdNgPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bdNgPositionItem.Text = "0";
            this.bdNgPositionItem.ToolTipText = "当前位置";
            // 
            // bdNgSeparator1
            // 
            this.bdNgSeparator1.Name = "bdNgSeparator1";
            this.bdNgSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bdNgMoveNextItem
            // 
            this.bdNgMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveNextItem.Image")));
            this.bdNgMoveNextItem.Name = "bdNgMoveNextItem";
            this.bdNgMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveNextItem.Text = "移到下一条记录";
            // 
            // bdNgMoveLastItem
            // 
            this.bdNgMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveLastItem.Image")));
            this.bdNgMoveLastItem.Name = "bdNgMoveLastItem";
            this.bdNgMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveLastItem.Text = "移到最后一条记录";
            // 
            // bdNgSeparator2
            // 
            this.bdNgSeparator2.Name = "bdNgSeparator2";
            this.bdNgSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton1.Text = "选择(&S)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // bdNgClose
            // 
            this.bdNgClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgClose.Name = "bdNgClose";
            this.bdNgClose.Size = new System.Drawing.Size(51, 22);
            this.bdNgClose.Text = "关闭(&C)";
            this.bdNgClose.ToolTipText = "关闭";
            this.bdNgClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // dgvPost
            // 
            this.dgvPost.AllowUserToAddRows = false;
            this.dgvPost.AllowUserToDeleteRows = false;
            this.dgvPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPost.Location = new System.Drawing.Point(271, 36);
            this.dgvPost.Name = "dgvPost";
            this.dgvPost.ReadOnly = true;
            this.dgvPost.RowTemplate.Height = 23;
            this.dgvPost.Size = new System.Drawing.Size(486, 392);
            this.dgvPost.TabIndex = 12;
            this.dgvPost.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellDoubleClick);
            // 
            // ucDepart
            // 
            this.ucDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepart.Location = new System.Drawing.Point(3, 36);
            this.ucDepart.Name = "ucDepart";
            this.ucDepart.OperationType = 1;
            this.ucDepart.Size = new System.Drawing.Size(262, 392);
            this.ucDepart.TabIndex = 0;
            // 
            // FrmPosiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPosiSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择审核岗位";
            this.Load += new System.EventHandler(this.FrmPosiSelect_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShipMisZHJ_WorkFlow.UserControls.UcDepart ucDepart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingNavigator bdNgMain;
        private System.Windows.Forms.ToolStripLabel bdNgCountItem;
        private System.Windows.Forms.ToolStripButton bdNgMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bdNgMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator;
        private System.Windows.Forms.ToolStripTextBox bdNgPositionItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator1;
        private System.Windows.Forms.ToolStripButton bdNgMoveNextItem;
        private System.Windows.Forms.ToolStripButton bdNgMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator2;
        private System.Windows.Forms.ToolStripButton bdNgClose;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgvPost;
    }
}