namespace ShipMisZHJ_WorkFlow.Forms
{
    partial class FrmWorkFlowObj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowObj));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucDataGridView = new CommonViewer.UcDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
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
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnClose});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = this.bdNgMoveFirstItem;
            this.bdNgMain.MoveLastItem = this.bdNgMoveLastItem;
            this.bdNgMain.MoveNextItem = this.bdNgMoveNextItem;
            this.bdNgMain.MovePreviousItem = this.bdNgMovePreviousItem;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = this.bdNgPositionItem;
            this.bdNgMain.Size = new System.Drawing.Size(588, 25);
            this.bdNgMain.TabIndex = 48;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // bdNgCountItem
            // 
            this.bdNgCountItem.Name = "bdNgCountItem";
            this.bdNgCountItem.Size = new System.Drawing.Size(31, 22);
            this.bdNgCountItem.Text = "/ {0}";
            this.bdNgCountItem.ToolTipText = "总项数";
            this.bdNgCountItem.Visible = false;
            // 
            // bdNgMoveFirstItem
            // 
            this.bdNgMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveFirstItem.Image")));
            this.bdNgMoveFirstItem.Name = "bdNgMoveFirstItem";
            this.bdNgMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveFirstItem.Text = "移到第一条记录";
            this.bdNgMoveFirstItem.Visible = false;
            // 
            // bdNgMovePreviousItem
            // 
            this.bdNgMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMovePreviousItem.Image")));
            this.bdNgMovePreviousItem.Name = "bdNgMovePreviousItem";
            this.bdNgMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMovePreviousItem.Text = "移到上一条记录";
            this.bdNgMovePreviousItem.Visible = false;
            // 
            // bdNgSeparator
            // 
            this.bdNgSeparator.Name = "bdNgSeparator";
            this.bdNgSeparator.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator.Visible = false;
            // 
            // bdNgPositionItem
            // 
            this.bdNgPositionItem.AccessibleName = "位置";
            this.bdNgPositionItem.AutoSize = false;
            this.bdNgPositionItem.Name = "bdNgPositionItem";
            this.bdNgPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bdNgPositionItem.Text = "0";
            this.bdNgPositionItem.ToolTipText = "当前位置";
            this.bdNgPositionItem.Visible = false;
            // 
            // bdNgSeparator1
            // 
            this.bdNgSeparator1.Name = "bdNgSeparator1";
            this.bdNgSeparator1.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator1.Visible = false;
            // 
            // bdNgMoveNextItem
            // 
            this.bdNgMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveNextItem.Image")));
            this.bdNgMoveNextItem.Name = "bdNgMoveNextItem";
            this.bdNgMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveNextItem.Text = "移到下一条记录";
            this.bdNgMoveNextItem.Visible = false;
            // 
            // bdNgMoveLastItem
            // 
            this.bdNgMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveLastItem.Image")));
            this.bdNgMoveLastItem.Name = "bdNgMoveLastItem";
            this.bdNgMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveLastItem.Text = "移到最后一条记录";
            this.bdNgMoveLastItem.Visible = false;
            // 
            // bdNgSeparator2
            // 
            this.bdNgSeparator2.Name = "bdNgSeparator2";
            this.bdNgSeparator2.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator2.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeftAutoMirrorImage = true;
            this.btnAdd.Size = new System.Drawing.Size(67, 22);
            this.btnAdd.Text = "新添(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 22);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeftAutoMirrorImage = true;
            this.btnDelete.Size = new System.Drawing.Size(68, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.ToolTipText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 296);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // ucDataGridView
            // 
            this.ucDataGridView.AllowUserToAddRows = false;
            this.ucDataGridView.AllowUserToDeleteRows = false;
            this.ucDataGridView.AllowUserToOrderColumns = true;
            this.ucDataGridView.AutoFit = true;
            this.ucDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ucDataGridView.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ucDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView.EnableHeadersVisualStyles = false;
            this.ucDataGridView.ExportColorToExcel = false;
            this.ucDataGridView.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.Footer")));
            this.ucDataGridView.GridColor = System.Drawing.Color.SteelBlue;
            this.ucDataGridView.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.Header")));
            this.ucDataGridView.LoadedFinish = false;
            this.ucDataGridView.Location = new System.Drawing.Point(3, 28);
            this.ucDataGridView.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.MergeColumnNames")));
            this.ucDataGridView.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.MergeRowColumn")));
            this.ucDataGridView.Name = "ucDataGridView";
            this.ucDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ucDataGridView.RowHeadersWidth = 25;
            this.ucDataGridView.RowTemplate.Height = 23;
            this.ucDataGridView.ShowRowNumber = true;
            this.ucDataGridView.Size = new System.Drawing.Size(582, 265);
            this.ucDataGridView.TabIndex = 0;
            this.ucDataGridView.Title = "";
            // 
            // FrmWorkFlowObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowObj";
            this.Text = "流程对象定义";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWorkFlowObj_FormClosed);
            this.Load += new System.EventHandler(this.FrmWorkFlowObj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonViewer.UcDataGridView ucDataGridView;
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
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}