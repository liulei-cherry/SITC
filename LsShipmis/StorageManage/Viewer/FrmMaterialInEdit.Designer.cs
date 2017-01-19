namespace StorageManage.Viewer
{
    partial class FrmMaterialInEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialInEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpInDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.ucDepartmentSelect1 = new BaseInfo.Viewer.UcDepartmentSelect();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInMan = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShipChecker = new CommonViewer.TextBoxEx();
            this.txtLandChecker = new CommonViewer.TextBoxEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboManufactory = new System.Windows.Forms.ComboBox();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.cboInTypeCode = new System.Windows.Forms.ComboBox();
            this.cboWareHouse = new System.Windows.Forms.ComboBox();
            this.dgvSpInDetail = new CommonViewer.UcDataGridView(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOrderDetail = new CommonViewer.UcDataGridView(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdNgComplete = new CommonViewer.ButtonEx();
            this.btnReject = new CommonViewer.ButtonEx();
            this.bdCommit = new CommonViewer.ButtonEx();
            this.bdNgSaveItem = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.btnFromOrder = new CommonViewer.ButtonEx();
            this.btnFromApply = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpInDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1072, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1066, 114);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入库单信息添加";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel2.Controls.Add(this.dtpInDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.ucDepartmentSelect1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtInMan, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtShipChecker, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLandChecker, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1046, 80);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // dtpInDate
            // 
            this.dtpInDate.CustomFormat = "yyyy-MM-dd";
            this.dtpInDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInDate.Location = new System.Drawing.Point(103, 3);
            this.dtpInDate.Name = "dtpInDate";
            this.dtpInDate.Size = new System.Drawing.Size(190, 21);
            this.dtpInDate.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "入库日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(595, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "备注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(695, 3);
            this.txtRemark.MaxLength = 1500;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.tableLayoutPanel2.SetRowSpan(this.txtRemark, 3);
            this.txtRemark.Size = new System.Drawing.Size(348, 84);
            this.txtRemark.TabIndex = 25;
            // 
            // ucDepartmentSelect1
            // 
            this.ucDepartmentSelect1.CanEdit = false;
            this.ucDepartmentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartmentSelect1.DropDownWidth = 151;
            this.ucDepartmentSelect1.Location = new System.Drawing.Point(399, 3);
            this.ucDepartmentSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucDepartmentSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucDepartmentSelect1.Name = "ucDepartmentSelect1";
            this.ucDepartmentSelect1.NullValueShow = "";
            this.ucDepartmentSelect1.ShowButton = true;
            this.ucDepartmentSelect1.Size = new System.Drawing.Size(190, 20);
            this.ucDepartmentSelect1.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(299, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "入库部门*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "入库人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInMan
            // 
            this.txtInMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInMan.Location = new System.Drawing.Point(103, 33);
            this.txtInMan.MaxLength = 20;
            this.txtInMan.Name = "txtInMan";
            this.txtInMan.ReadOnly = true;
            this.txtInMan.Size = new System.Drawing.Size(190, 21);
            this.txtInMan.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(299, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "船上确认者";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "岸端确认者";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipChecker
            // 
            this.txtShipChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShipChecker.Location = new System.Drawing.Point(399, 33);
            this.txtShipChecker.MaxLength = 20;
            this.txtShipChecker.Name = "txtShipChecker";
            this.txtShipChecker.ReadOnly = true;
            this.txtShipChecker.Size = new System.Drawing.Size(190, 21);
            this.txtShipChecker.TabIndex = 24;
            // 
            // txtLandChecker
            // 
            this.txtLandChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLandChecker.Location = new System.Drawing.Point(103, 63);
            this.txtLandChecker.MaxLength = 20;
            this.txtLandChecker.Name = "txtLandChecker";
            this.txtLandChecker.ReadOnly = true;
            this.txtLandChecker.Size = new System.Drawing.Size(190, 21);
            this.txtLandChecker.TabIndex = 24;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 123);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1066, 405);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 42;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboManufactory);
            this.groupBox3.Controls.Add(this.cboCurrency);
            this.groupBox3.Controls.Add(this.cboInTypeCode);
            this.groupBox3.Controls.Add(this.cboWareHouse);
            this.groupBox3.Controls.Add(this.dgvSpInDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1066, 200);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入库单明细信息";
            // 
            // cboManufactory
            // 
            this.cboManufactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManufactory.FormattingEnabled = true;
            this.cboManufactory.Items.AddRange(new object[] {
            "到货",
            "翻新",
            "调配",
            "盘点"});
            this.cboManufactory.Location = new System.Drawing.Point(15, 113);
            this.cboManufactory.Name = "cboManufactory";
            this.cboManufactory.Size = new System.Drawing.Size(121, 20);
            this.cboManufactory.TabIndex = 46;
            this.cboManufactory.Visible = false;
            this.cboManufactory.SelectedValueChanged += new System.EventHandler(this.cboManufactory_SelectedValueChanged);
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Items.AddRange(new object[] {
            "到货",
            "翻新",
            "调配",
            "盘点"});
            this.cboCurrency.Location = new System.Drawing.Point(15, 61);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 20);
            this.cboCurrency.TabIndex = 45;
            this.cboCurrency.Visible = false;
            this.cboCurrency.SelectedValueChanged += new System.EventHandler(this.cboCurrency_SelectedValueChanged);
            // 
            // cboInTypeCode
            // 
            this.cboInTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInTypeCode.FormattingEnabled = true;
            this.cboInTypeCode.Items.AddRange(new object[] {
            "到货",
            "翻新",
            "调配",
            "盘点"});
            this.cboInTypeCode.Location = new System.Drawing.Point(15, 87);
            this.cboInTypeCode.Name = "cboInTypeCode";
            this.cboInTypeCode.Size = new System.Drawing.Size(121, 20);
            this.cboInTypeCode.TabIndex = 44;
            this.cboInTypeCode.Visible = false;
            this.cboInTypeCode.SelectedValueChanged += new System.EventHandler(this.cboInTypeCode_SelectedValueChanged);
            // 
            // cboWareHouse
            // 
            this.cboWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWareHouse.FormattingEnabled = true;
            this.cboWareHouse.Location = new System.Drawing.Point(15, 35);
            this.cboWareHouse.Name = "cboWareHouse";
            this.cboWareHouse.Size = new System.Drawing.Size(121, 20);
            this.cboWareHouse.TabIndex = 42;
            this.cboWareHouse.Visible = false;
            this.cboWareHouse.SelectedValueChanged += new System.EventHandler(this.cboWareHouse_SelectedValueChanged);
            // 
            // dgvSpInDetail
            // 
            this.dgvSpInDetail.AllowUserToAddRows = false;
            this.dgvSpInDetail.AllowUserToDeleteRows = false;
            this.dgvSpInDetail.AllowUserToOrderColumns = true;
            this.dgvSpInDetail.AutoFit = true;
            this.dgvSpInDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSpInDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpInDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpInDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpInDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpInDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpInDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSpInDetail.EnableHeadersVisualStyles = false;
            this.dgvSpInDetail.ExportColorToExcel = false;
            this.dgvSpInDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpInDetail.Footer")));
            this.dgvSpInDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSpInDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpInDetail.Header")));
            this.dgvSpInDetail.LoadedFinish = false;
            this.dgvSpInDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvSpInDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpInDetail.MergeColumnNames")));
            this.dgvSpInDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpInDetail.MergeRowColumn")));
            this.dgvSpInDetail.Name = "dgvSpInDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpInDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSpInDetail.RowHeadersWidth = 25;
            this.dgvSpInDetail.RowTemplate.Height = 23;
            this.dgvSpInDetail.ShowRowNumber = true;
            this.dgvSpInDetail.Size = new System.Drawing.Size(1060, 180);
            this.dgvSpInDetail.TabIndex = 41;
            this.dgvSpInDetail.Title = "";
            this.dgvSpInDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpInDetail_CellContentClick);
            this.dgvSpInDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSpInDetail_CellValidating);
            this.dgvSpInDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpInDetail_CellValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOrderDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1066, 201);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购单明细信息";
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AllowUserToAddRows = false;
            this.dgvOrderDetail.AllowUserToDeleteRows = false;
            this.dgvOrderDetail.AllowUserToOrderColumns = true;
            this.dgvOrderDetail.AutoFit = true;
            this.dgvOrderDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOrderDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOrderDetail.EnableHeadersVisualStyles = false;
            this.dgvOrderDetail.ExportColorToExcel = false;
            this.dgvOrderDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrderDetail.Footer")));
            this.dgvOrderDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvOrderDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrderDetail.Header")));
            this.dgvOrderDetail.LoadedFinish = false;
            this.dgvOrderDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvOrderDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrderDetail.MergeColumnNames")));
            this.dgvOrderDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrderDetail.MergeRowColumn")));
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrderDetail.RowHeadersWidth = 30;
            this.dgvOrderDetail.RowTemplate.Height = 23;
            this.dgvOrderDetail.ShowRowNumber = true;
            this.dgvOrderDetail.Size = new System.Drawing.Size(1060, 181);
            this.dgvOrderDetail.TabIndex = 0;
            this.dgvOrderDetail.Title = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1074, 56);
            this.panel4.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.bdNgComplete);
            this.flowLayoutPanel1.Controls.Add(this.btnReject);
            this.flowLayoutPanel1.Controls.Add(this.bdCommit);
            this.flowLayoutPanel1.Controls.Add(this.bdNgSaveItem);
            this.flowLayoutPanel1.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel1.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel1.Controls.Add(this.btnFromOrder);
            this.flowLayoutPanel1.Controls.Add(this.btnFromApply);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(217, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(854, 51);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 6;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(808, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(46, 45);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 22;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // bdNgComplete
            // 
            this.bdNgComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgComplete.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgComplete.BackColor = System.Drawing.Color.Transparent;
            this.bdNgComplete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgComplete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgComplete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgComplete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgComplete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgComplete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgComplete.FadingSpeed = 20;
            this.bdNgComplete.FlatAppearance.BorderSize = 0;
            this.bdNgComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgComplete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgComplete.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgComplete.Image = ((System.Drawing.Image)(resources.GetObject("bdNgComplete.Image")));
            this.bdNgComplete.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgComplete.ImageOffset = 5;
            this.bdNgComplete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgComplete.IsPressed = false;
            this.bdNgComplete.KeepPress = false;
            this.bdNgComplete.Location = new System.Drawing.Point(708, 0);
            this.bdNgComplete.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgComplete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgComplete.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgComplete.Name = "bdNgComplete";
            this.bdNgComplete.Radius = 6;
            this.bdNgComplete.ShowBase = true;
            this.bdNgComplete.Size = new System.Drawing.Size(100, 45);
            this.bdNgComplete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgComplete.SplitDistance = 0;
            this.bdNgComplete.TabIndex = 24;
            this.bdNgComplete.Text = "审核";
            this.bdNgComplete.Title = "";
            this.bdNgComplete.UseVisualStyleBackColor = true;
            this.bdNgComplete.Click += new System.EventHandler(this.bdNgComplete_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnReject.BackColor = System.Drawing.Color.Transparent;
            this.btnReject.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnReject.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnReject.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnReject.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnReject.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReject.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReject.FadingSpeed = 20;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReject.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnReject.Image = ((System.Drawing.Image)(resources.GetObject("btnReject.Image")));
            this.btnReject.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnReject.ImageOffset = 8;
            this.btnReject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReject.IsPressed = false;
            this.btnReject.KeepPress = false;
            this.btnReject.Location = new System.Drawing.Point(607, 0);
            this.btnReject.Margin = new System.Windows.Forms.Padding(0);
            this.btnReject.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnReject.MenuPos = new System.Drawing.Point(0, 0);
            this.btnReject.Name = "btnReject";
            this.btnReject.Radius = 6;
            this.btnReject.ShowBase = true;
            this.btnReject.Size = new System.Drawing.Size(101, 45);
            this.btnReject.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnReject.SplitDistance = 0;
            this.btnReject.TabIndex = 27;
            this.btnReject.Text = "打回";
            this.btnReject.Title = "";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // bdCommit
            // 
            this.bdCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdCommit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdCommit.BackColor = System.Drawing.Color.Transparent;
            this.bdCommit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdCommit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdCommit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdCommit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdCommit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdCommit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdCommit.FadingSpeed = 20;
            this.bdCommit.FlatAppearance.BorderSize = 0;
            this.bdCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdCommit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdCommit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdCommit.Image = ((System.Drawing.Image)(resources.GetObject("bdCommit.Image")));
            this.bdCommit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdCommit.ImageOffset = 5;
            this.bdCommit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdCommit.IsPressed = false;
            this.bdCommit.KeepPress = false;
            this.bdCommit.Location = new System.Drawing.Point(519, 0);
            this.bdCommit.Margin = new System.Windows.Forms.Padding(0);
            this.bdCommit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdCommit.MenuPos = new System.Drawing.Point(0, 0);
            this.bdCommit.Name = "bdCommit";
            this.bdCommit.Radius = 6;
            this.bdCommit.ShowBase = true;
            this.bdCommit.Size = new System.Drawing.Size(88, 45);
            this.bdCommit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdCommit.SplitDistance = 0;
            this.bdCommit.TabIndex = 25;
            this.bdCommit.Text = "提交";
            this.bdCommit.Title = "";
            this.bdCommit.UseVisualStyleBackColor = true;
            this.bdCommit.Click += new System.EventHandler(this.bdCommit_Click);
            // 
            // bdNgSaveItem
            // 
            this.bdNgSaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgSaveItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgSaveItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgSaveItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgSaveItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgSaveItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgSaveItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgSaveItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgSaveItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgSaveItem.FadingSpeed = 20;
            this.bdNgSaveItem.FlatAppearance.BorderSize = 0;
            this.bdNgSaveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgSaveItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgSaveItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgSaveItem.Image")));
            this.bdNgSaveItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgSaveItem.ImageOffset = 5;
            this.bdNgSaveItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgSaveItem.IsPressed = false;
            this.bdNgSaveItem.KeepPress = false;
            this.bdNgSaveItem.Location = new System.Drawing.Point(409, 0);
            this.bdNgSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgSaveItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.Name = "bdNgSaveItem";
            this.bdNgSaveItem.Radius = 6;
            this.bdNgSaveItem.ShowBase = true;
            this.bdNgSaveItem.Size = new System.Drawing.Size(110, 45);
            this.bdNgSaveItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgSaveItem.SplitDistance = 0;
            this.bdNgSaveItem.TabIndex = 24;
            this.bdNgSaveItem.Text = "保存草稿";
            this.bdNgSaveItem.Title = "";
            this.bdNgSaveItem.UseVisualStyleBackColor = true;
            this.bdNgSaveItem.Click += new System.EventHandler(this.bdNgSaveItem_Click);
            // 
            // bdNgDeleteItem
            // 
            this.bdNgDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgDeleteItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgDeleteItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgDeleteItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgDeleteItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgDeleteItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgDeleteItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgDeleteItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.FadingSpeed = 20;
            this.bdNgDeleteItem.FlatAppearance.BorderSize = 0;
            this.bdNgDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgDeleteItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgDeleteItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgDeleteItem.ImageOffset = 2;
            this.bdNgDeleteItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgDeleteItem.IsPressed = false;
            this.bdNgDeleteItem.KeepPress = false;
            this.bdNgDeleteItem.Location = new System.Drawing.Point(361, 0);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(48, 45);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 24;
            this.bdNgDeleteItem.Title = "";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // bdNgAddNewItem
            // 
            this.bdNgAddNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgAddNewItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgAddNewItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgAddNewItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgAddNewItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgAddNewItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgAddNewItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgAddNewItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgAddNewItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgAddNewItem.FadingSpeed = 20;
            this.bdNgAddNewItem.FlatAppearance.BorderSize = 0;
            this.bdNgAddNewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgAddNewItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgAddNewItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgAddNewItem.ImageOffset = 2;
            this.bdNgAddNewItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgAddNewItem.IsPressed = false;
            this.bdNgAddNewItem.KeepPress = false;
            this.bdNgAddNewItem.Location = new System.Drawing.Point(313, 0);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(48, 45);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 24;
            this.bdNgAddNewItem.Title = "";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFromOrder
            // 
            this.btnFromOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromOrder.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnFromOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnFromOrder.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnFromOrder.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnFromOrder.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFromOrder.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFromOrder.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFromOrder.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFromOrder.FadingSpeed = 20;
            this.btnFromOrder.FlatAppearance.BorderSize = 0;
            this.btnFromOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFromOrder.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnFromOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnFromOrder.Image")));
            this.btnFromOrder.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnFromOrder.ImageOffset = 3;
            this.btnFromOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFromOrder.IsPressed = false;
            this.btnFromOrder.KeepPress = false;
            this.btnFromOrder.Location = new System.Drawing.Point(164, 0);
            this.btnFromOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnFromOrder.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnFromOrder.MenuPos = new System.Drawing.Point(0, 0);
            this.btnFromOrder.Name = "btnFromOrder";
            this.btnFromOrder.Radius = 6;
            this.btnFromOrder.ShowBase = true;
            this.btnFromOrder.Size = new System.Drawing.Size(149, 45);
            this.btnFromOrder.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnFromOrder.SplitDistance = 0;
            this.btnFromOrder.TabIndex = 26;
            this.btnFromOrder.Text = "导入订单明细";
            this.btnFromOrder.Title = "";
            this.btnFromOrder.UseVisualStyleBackColor = true;
            this.btnFromOrder.Click += new System.EventHandler(this.btnFromOrder_Click);
            // 
            // btnFromApply
            // 
            this.btnFromApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromApply.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnFromApply.BackColor = System.Drawing.Color.Transparent;
            this.btnFromApply.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnFromApply.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnFromApply.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFromApply.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFromApply.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFromApply.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFromApply.FadingSpeed = 20;
            this.btnFromApply.FlatAppearance.BorderSize = 0;
            this.btnFromApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromApply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFromApply.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnFromApply.Image = ((System.Drawing.Image)(resources.GetObject("btnFromApply.Image")));
            this.btnFromApply.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnFromApply.ImageOffset = 3;
            this.btnFromApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFromApply.IsPressed = false;
            this.btnFromApply.KeepPress = false;
            this.btnFromApply.Location = new System.Drawing.Point(15, 0);
            this.btnFromApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnFromApply.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnFromApply.MenuPos = new System.Drawing.Point(0, 0);
            this.btnFromApply.Name = "btnFromApply";
            this.btnFromApply.Radius = 6;
            this.btnFromApply.ShowBase = true;
            this.btnFromApply.Size = new System.Drawing.Size(149, 45);
            this.btnFromApply.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnFromApply.SplitDistance = 0;
            this.btnFromApply.TabIndex = 28;
            this.btnFromApply.Text = "导入申请单明细";
            this.btnFromApply.Title = "";
            this.btnFromApply.UseVisualStyleBackColor = true;
            this.btnFromApply.Click += new System.EventHandler(this.btnFromApply_Click);
            // 
            // buttonEx6
            // 
            this.buttonEx6.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx6.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx6.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx6.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx6.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx6.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx6.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx6.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx6.Enabled = false;
            this.buttonEx6.FadingSpeed = 20;
            this.buttonEx6.FlatAppearance.BorderSize = 0;
            this.buttonEx6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx6.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx6.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx6.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx6.Image")));
            this.buttonEx6.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx6.ImageOffset = 3;
            this.buttonEx6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx6.IsPressed = false;
            this.buttonEx6.KeepPress = false;
            this.buttonEx6.Location = new System.Drawing.Point(2, 4);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(186, 48);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "物资入库单";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // FrmMaterialInEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 591);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaterialInEdit";
            this.Text = "物资入库单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialInEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialInEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpInDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvSpInDetail;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.ComboBox cboWareHouse;
        private System.Windows.Forms.ComboBox cboInTypeCode;
        private System.Windows.Forms.DateTimePicker dtpInDate;
        private CommonViewer.TextBoxEx txtInMan;
        private CommonViewer.TextBoxEx txtRemark;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        public CommonViewer.ButtonEx bdNgComplete;
        public CommonViewer.ButtonEx bdNgSaveItem;
        public CommonViewer.ButtonEx buttonEx6;
        protected CommonViewer.ButtonEx btnClose;
        private BaseInfo.Viewer.UcDepartmentSelect ucDepartmentSelect1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public CommonViewer.ButtonEx bdCommit;
        public CommonViewer.ButtonEx btnFromOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtShipChecker;
        private CommonViewer.TextBoxEx txtLandChecker;
        public CommonViewer.ButtonEx btnReject;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.ComboBox cboManufactory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvOrderDetail;
        public CommonViewer.ButtonEx btnFromApply;
    }
}