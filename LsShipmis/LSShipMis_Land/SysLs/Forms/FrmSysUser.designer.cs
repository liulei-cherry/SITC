namespace LSShipMis_Land.SysLs.Forms
{
    partial class FrmSysUser
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要.
        /// 使用代码编辑器修改此方法的内容。.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bdNgMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.addNew = new System.Windows.Forms.ToolStripButton();
            this.bdNgDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bdNgNewItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgCancelItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.bdNgClose = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUser = new CommonViewer.UcDataGridView(this.components); 
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 466);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
            this.bdNgMain.CountItem = null;
            this.bdNgMain.DeleteItem = null;
            this.bdNgMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNew,
            this.bdNgDeleteItem,
            this.toolStripButton1,
            this.bdNgNewItem,
            this.bdNgCancelItem,
            this.toolStripButton3,
            this.bdNgClose,
            this.bdNgSeparator3});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = null;
            this.bdNgMain.MoveLastItem = null;
            this.bdNgMain.MoveNextItem = null;
            this.bdNgMain.MovePreviousItem = null;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = null;
            this.bdNgMain.Size = new System.Drawing.Size(858, 25);
            this.bdNgMain.TabIndex = 8;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // addNew
            // 
            this.addNew.Image = global::LSShipMis_Land.Properties.Resources._new;
            this.addNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(68, 22);
            this.addNew.Text = "新添(&A)";
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // bdNgDeleteItem
            // 
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(69, 22);
            this.bdNgDeleteItem.Text = "删除(&D)";
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::LSShipMis_Land.Properties.Resources.retrieve;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "还原初始密码";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // bdNgNewItem
            // 
            this.bdNgNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgNewItem.Image")));
            this.bdNgNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgNewItem.Name = "bdNgNewItem";
            this.bdNgNewItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgNewItem.Text = "新建(&N)";
            this.bdNgNewItem.Visible = false;
            // 
            // bdNgCancelItem
            // 
            this.bdNgCancelItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgCancelItem.Image")));
            this.bdNgCancelItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgCancelItem.Name = "bdNgCancelItem";
            this.bdNgCancelItem.Size = new System.Drawing.Size(68, 22);
            this.bdNgCancelItem.Text = "取消(&R)";
            this.bdNgCancelItem.Click += new System.EventHandler(this.bdNgCancelItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::LSShipMis_Land.Properties.Resources.right;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton3.Text = "设置职务";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // bdNgClose
            // 
            this.bdNgClose.Image = global::LSShipMis_Land.Properties.Resources.close;
            this.bdNgClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgClose.Name = "bdNgClose";
            this.bdNgClose.Size = new System.Drawing.Size(68, 22);
            this.bdNgClose.Text = "关闭(&C)";
            this.bdNgClose.ToolTipText = "关闭";
            this.bdNgClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // bdNgSeparator3
            // 
            this.bdNgSeparator3.Name = "bdNgSeparator3";
            this.bdNgSeparator3.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(852, 435);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员和登录用户信息列表";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AutoFit = true;
            this.dgvUser.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvUser.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.Footer")));
            this.dgvUser.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvUser.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.Header")));
            this.dgvUser.LoadedFinish = false;
            this.dgvUser.Location = new System.Drawing.Point(8, 17);
            this.dgvUser.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.MergeColumnNames")));
            this.dgvUser.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.MergeRowColumn")));
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.RowHeadersWidth = 25;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.ShowRowNumber = false;
            this.dgvUser.Size = new System.Drawing.Size(836, 410);
            this.dgvUser.TabIndex = 14;
            this.dgvUser.Title = null;
            // 
            // FrmSysUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSysUser";
            this.Text = "登录用户信息";
            this.Load += new System.EventHandler(this.FrmSysUser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSysUser_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingNavigator bdNgMain;
        private System.Windows.Forms.ToolStripButton bdNgDeleteItem;
        private System.Windows.Forms.ToolStripButton bdNgNewItem;
        private System.Windows.Forms.ToolStripButton bdNgCancelItem;
        private System.Windows.Forms.ToolStripButton bdNgClose;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator3;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvUser;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1; 
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton addNew;
    }
}