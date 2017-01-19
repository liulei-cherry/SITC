namespace LSShipMis_Ship.Seaman.Forms
{
    partial class FrmSeamanInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeamanInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSeaman = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bdNgMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdNgAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.bdNgCancelItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtChName = new CommonViewer.TextBoxEx();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtBirthday = new CommonViewer.TextBoxEx();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAddress = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConnection = new CommonViewer.TextBoxEx();
            this.txtNation = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMarriage = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSchage = new CommonViewer.TextBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdent = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSeaNumb = new CommonViewer.TextBoxEx();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSsnumb = new CommonViewer.TextBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSerNumb = new CommonViewer.TextBoxEx();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.搜索F3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaman)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSeaman);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(430, 499);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "船员基本信息列表";
            // 
            // dgvSeaman
            // 
            this.dgvSeaman.AllowUserToAddRows = false;
            this.dgvSeaman.AllowUserToDeleteRows = false;
            this.dgvSeaman.AllowUserToOrderColumns = true;
            this.dgvSeaman.AutoFit = true;
            this.dgvSeaman.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSeaman.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeaman.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeaman.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeaman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeaman.EnableHeadersVisualStyles = false;
            this.dgvSeaman.ExportColorToExcel = false;
            this.dgvSeaman.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSeaman.Footer")));
            this.dgvSeaman.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSeaman.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSeaman.Header")));
            this.dgvSeaman.LoadedFinish = false;
            this.dgvSeaman.Location = new System.Drawing.Point(8, 17);
            this.dgvSeaman.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSeaman.MergeColumnNames")));
            this.dgvSeaman.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSeaman.MergeRowColumn")));
            this.dgvSeaman.Name = "dgvSeaman";
            this.dgvSeaman.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeaman.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSeaman.RowHeadersWidth = 25;
            this.dgvSeaman.RowTemplate.Height = 23;
            this.dgvSeaman.ShowRowNumber = false;
            this.dgvSeaman.Size = new System.Drawing.Size(414, 474);
            this.dgvSeaman.TabIndex = 11;
            this.dgvSeaman.Title = ""; 
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.01027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.98973F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 530);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
            this.tableLayoutPanel1.SetColumnSpan(this.bdNgMain, 2);
            this.bdNgMain.CountItem = null;
            this.bdNgMain.DeleteItem = null;
            this.bdNgMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bdNgAddNewItem,
            this.bdNgDeleteItem,
            this.bdNgSaveItem,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.bdNgCancelItem,
            this.bdNgClose});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = null;
            this.bdNgMain.MoveLastItem = null;
            this.bdNgMain.MoveNextItem = null;
            this.bdNgMain.MovePreviousItem = null;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = null;
            this.bdNgMain.Size = new System.Drawing.Size(909, 25);
            this.bdNgMain.TabIndex = 42;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // bdNgAddNewItem
            // 
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(68, 22);
            this.bdNgAddNewItem.Text = "新添(&A)";
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
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
            // bdNgSaveItem
            // 
            this.bdNgSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgSaveItem.Image")));
            this.bdNgSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgSaveItem.Name = "bdNgSaveItem";
            this.bdNgSaveItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgSaveItem.Text = "保存(&S)";
            this.bdNgSaveItem.Click += new System.EventHandler(this.bdNgSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::LSShipMis_Ship.Properties.Resources.right;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton3.Text = "注册登录用户";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            // bdNgClose
            // 
            this.bdNgClose.Image = global::LSShipMis_Ship.Properties.Resources.close;
            this.bdNgClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgClose.Name = "bdNgClose";
            this.bdNgClose.Size = new System.Drawing.Size(68, 22);
            this.bdNgClose.Text = "关闭(&C)";
            this.bdNgClose.ToolTipText = "关闭";
            this.bdNgClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(439, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.groupBox2.Size = new System.Drawing.Size(467, 499);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "船员基本信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtChName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboSex, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBirthday, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtAddress, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtConnection, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtNation, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboMarriage, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboCountry, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSchage, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtIdent, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtSeaNumb, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtSsnumb, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label14, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtSerNumb, 3, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(447, 470);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(226, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "出生年月";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "性别";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChName
            // 
            this.txtChName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChName.Location = new System.Drawing.Point(83, 4);
            this.txtChName.Name = "txtChName";
            this.txtChName.Size = new System.Drawing.Size(137, 21);
            this.txtChName.TabIndex = 21;
            // 
            // cboSex
            // 
            this.cboSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(83, 35);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(137, 20);
            this.cboSex.TabIndex = 23;
            // 
            // txtBirthday
            // 
            this.txtBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBirthday.CausesValidation = false;
            this.txtBirthday.Location = new System.Drawing.Point(306, 34);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(138, 21);
            this.txtBirthday.TabIndex = 24;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 240);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 230);
            this.label18.TabIndex = 1;
            this.label18.Text = "备注";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(83, 243);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(361, 224);
            this.txtRemark.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 30);
            this.label17.TabIndex = 1;
            this.label17.Text = "家庭住址";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Location = new System.Drawing.Point(83, 214);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(361, 21);
            this.txtAddress.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 30);
            this.label16.TabIndex = 1;
            this.label16.Text = "联系方式";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConnection
            // 
            this.txtConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtConnection, 3);
            this.txtConnection.Location = new System.Drawing.Point(83, 184);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(361, 21);
            this.txtConnection.TabIndex = 37;
            // 
            // txtNation
            // 
            this.txtNation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNation.Location = new System.Drawing.Point(306, 94);
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(138, 21);
            this.txtNation.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(226, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "民族";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "婚否";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMarriage
            // 
            this.cboMarriage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMarriage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarriage.FormattingEnabled = true;
            this.cboMarriage.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cboMarriage.Location = new System.Drawing.Point(83, 65);
            this.cboMarriage.Name = "cboMarriage";
            this.cboMarriage.Size = new System.Drawing.Size(137, 20);
            this.cboMarriage.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(226, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "国籍";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(306, 65);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(138, 20);
            this.cboCountry.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "学历";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSchage
            // 
            this.txtSchage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchage.Location = new System.Drawing.Point(83, 94);
            this.txtSchage.Name = "txtSchage";
            this.txtSchage.Size = new System.Drawing.Size(137, 21);
            this.txtSchage.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "身份证号";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdent
            // 
            this.txtIdent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdent.Location = new System.Drawing.Point(83, 124);
            this.txtIdent.Name = "txtIdent";
            this.txtIdent.Size = new System.Drawing.Size(137, 21);
            this.txtIdent.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(226, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "海员证号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeaNumb
            // 
            this.txtSeaNumb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeaNumb.Location = new System.Drawing.Point(306, 124);
            this.txtSeaNumb.Name = "txtSeaNumb";
            this.txtSeaNumb.Size = new System.Drawing.Size(138, 21);
            this.txtSeaNumb.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 30);
            this.label13.TabIndex = 1;
            this.label13.Text = "适任证号";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSsnumb
            // 
            this.txtSsnumb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSsnumb.Location = new System.Drawing.Point(83, 154);
            this.txtSsnumb.Name = "txtSsnumb";
            this.txtSsnumb.Size = new System.Drawing.Size(137, 21);
            this.txtSsnumb.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(226, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 30);
            this.label14.TabIndex = 1;
            this.label14.Text = "服务簿号";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerNumb
            // 
            this.txtSerNumb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerNumb.Location = new System.Drawing.Point(306, 154);
            this.txtSerNumb.Name = "txtSerNumb";
            this.txtSerNumb.Size = new System.Drawing.Size(138, 21);
            this.txtSerNumb.TabIndex = 34;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Gif文件|*.gif|Jpg文件|*.jpg|Bmp文件|*.bmp";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.搜索F3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
            // 
            // 搜索F3ToolStripMenuItem
            // 
            this.搜索F3ToolStripMenuItem.Name = "搜索F3ToolStripMenuItem";
            this.搜索F3ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.搜索F3ToolStripMenuItem.Text = "搜索(F3...)";
            // 
            // FrmSeamanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSeamanInfo";
            this.Text = "船员基本信息";
            this.Load += new System.EventHandler(this.FrmSeamanInfo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSeamanInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaman)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvSeaman;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.BindingNavigator bdNgMain;
        private System.Windows.Forms.ToolStripButton bdNgAddNewItem;
        private System.Windows.Forms.ToolStripButton bdNgDeleteItem;
        private System.Windows.Forms.ToolStripButton bdNgCancelItem;
        private System.Windows.Forms.ToolStripButton bdNgSaveItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.ComboBox cboMarriage;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton bdNgClose;
        private CommonViewer.TextBoxEx txtChName;
        private CommonViewer.TextBoxEx txtBirthday;
        private CommonViewer.TextBoxEx txtNation;
        private CommonViewer.TextBoxEx txtSchage;
        private CommonViewer.TextBoxEx txtIdent;
        private CommonViewer.TextBoxEx txtSsnumb;
        private CommonViewer.TextBoxEx txtSeaNumb;
        private CommonViewer.TextBoxEx txtSerNumb;
        private CommonViewer.TextBoxEx txtConnection;
        private CommonViewer.TextBoxEx txtAddress;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 搜索F3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}