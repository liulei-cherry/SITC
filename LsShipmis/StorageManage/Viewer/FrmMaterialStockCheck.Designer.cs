namespace StorageManage.Viewer
{
    partial class FrmMaterialStockCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialStockCheck));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSpStockckDetail = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.cbOthersData = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboChkState = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSpStockck = new CommonViewer.UcDataGridView(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtState = new CommonViewer.TextBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtShipChecker = new CommonViewer.TextBoxEx();
            this.txtStockChecker = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSpckDate = new CommonViewer.TextBoxEx();
            this.txtLandChecker = new CommonViewer.TextBoxEx();
            this.txtCheckDate = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.txtWareHouse = new CommonViewer.TextBoxEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdNgPrintItem = new CommonViewer.ButtonEx();
            this.btnBanlance = new CommonViewer.ButtonEx();
            this.btnCheck = new CommonViewer.ButtonEx();
            this.btnView = new CommonViewer.ButtonEx();
            this.btnClone = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockckDetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockck)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSpStockckDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 249);
            this.panel1.TabIndex = 1;
            // 
            // dgvSpStockckDetail
            // 
            this.dgvSpStockckDetail.AllowUserToAddRows = false;
            this.dgvSpStockckDetail.AllowUserToDeleteRows = false;
            this.dgvSpStockckDetail.AllowUserToOrderColumns = true;
            this.dgvSpStockckDetail.AutoFit = true;
            this.dgvSpStockckDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSpStockckDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSpStockckDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpStockckDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpStockckDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpStockckDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpStockckDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpStockckDetail.EnableHeadersVisualStyles = false;
            this.dgvSpStockckDetail.ExportColorToExcel = false;
            this.dgvSpStockckDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockckDetail.Footer")));
            this.dgvSpStockckDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSpStockckDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockckDetail.Header")));
            this.dgvSpStockckDetail.LoadedFinish = false;
            this.dgvSpStockckDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvSpStockckDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockckDetail.MergeColumnNames")));
            this.dgvSpStockckDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockckDetail.MergeRowColumn")));
            this.dgvSpStockckDetail.Name = "dgvSpStockckDetail";
            this.dgvSpStockckDetail.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpStockckDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSpStockckDetail.RowHeadersWidth = 25;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen;
            this.dgvSpStockckDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSpStockckDetail.RowTemplate.Height = 23;
            this.dgvSpStockckDetail.ShowRowNumber = true;
            this.dgvSpStockckDetail.Size = new System.Drawing.Size(726, 249);
            this.dgvSpStockckDetail.TabIndex = 41;
            this.dgvSpStockckDetail.Title = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(732, 269);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "盘存单明细信息";
            // 
            // cbOthersData
            // 
            this.cbOthersData.AutoSize = true;
            this.cbOthersData.Checked = true;
            this.cbOthersData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOthersData.Enabled = false;
            this.cbOthersData.Location = new System.Drawing.Point(626, 13);
            this.cbOthersData.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.cbOthersData.Name = "cbOthersData";
            this.cbOthersData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbOthersData.Size = new System.Drawing.Size(120, 16);
            this.cbOthersData.TabIndex = 15;
            this.cbOthersData.Text = "仅看本岗位盘存单";
            this.cbOthersData.UseVisualStyleBackColor = true;
            this.cbOthersData.CheckedChanged += new System.EventHandler(this.cbOthersData_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(257, 10);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(79, 21);
            this.dtpStartDate.TabIndex = 21;
            this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
            // 
            // cboChkState
            // 
            this.cboChkState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChkState.FormattingEnabled = true;
            this.cboChkState.Location = new System.Drawing.Point(504, 10);
            this.cboChkState.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cboChkState.Name = "cboChkState";
            this.cboChkState.Size = new System.Drawing.Size(116, 20);
            this.cboChkState.TabIndex = 4;
            this.cboChkState.SelectedValueChanged += new System.EventHandler(this.cboChkState_SelectedValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(353, 10);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(79, 21);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.CloseUp += new System.EventHandler(this.dtpEndDate_CloseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 135);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1097, 487);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSpStockck);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(361, 487);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘存单信息列表";
            // 
            // dgvSpStockck
            // 
            this.dgvSpStockck.AllowUserToAddRows = false;
            this.dgvSpStockck.AllowUserToDeleteRows = false;
            this.dgvSpStockck.AllowUserToOrderColumns = true;
            this.dgvSpStockck.AutoFit = true;
            this.dgvSpStockck.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSpStockck.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSpStockck.ColumnDeep = 1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpStockck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSpStockck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpStockck.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSpStockck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpStockck.EnableHeadersVisualStyles = false;
            this.dgvSpStockck.ExportColorToExcel = false;
            this.dgvSpStockck.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockck.Footer")));
            this.dgvSpStockck.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSpStockck.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockck.Header")));
            this.dgvSpStockck.LoadedFinish = false;
            this.dgvSpStockck.Location = new System.Drawing.Point(8, 17);
            this.dgvSpStockck.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockck.MergeColumnNames")));
            this.dgvSpStockck.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpStockck.MergeRowColumn")));
            this.dgvSpStockck.Name = "dgvSpStockck";
            this.dgvSpStockck.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpStockck.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSpStockck.RowHeadersWidth = 25;
            this.dgvSpStockck.RowTemplate.Height = 23;
            this.dgvSpStockck.ShowRowNumber = true;
            this.dgvSpStockck.Size = new System.Drawing.Size(345, 462);
            this.dgvSpStockck.TabIndex = 11;
            this.dgvSpStockck.Title = "";
            this.dgvSpStockck.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpStockck_CellDoubleClick);
            this.dgvSpStockck.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpStockck_RowEnter);
            this.dgvSpStockck.Sorted += new System.EventHandler(this.dgvSpStockck_Sorted);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1MinSize = 170;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(732, 487);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(732, 214);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘存单信息添加";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 180);
            this.panel2.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtState, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtShipChecker, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtStockChecker, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpSpckDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLandChecker, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCheckDate, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtWareHouse, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(712, 180);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // txtState
            // 
            this.txtState.CausesValidation = false;
            this.txtState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtState.Location = new System.Drawing.Point(103, 93);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(250, 21);
            this.txtState.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 50);
            this.label9.TabIndex = 1;
            this.label9.Text = "备    注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(103, 123);
            this.txtRemark.MaxLength = 2000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(606, 44);
            this.txtRemark.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 30);
            this.label16.TabIndex = 1;
            this.label16.Text = "船上确认人";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipChecker
            // 
            this.txtShipChecker.CausesValidation = false;
            this.txtShipChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShipChecker.Location = new System.Drawing.Point(103, 63);
            this.txtShipChecker.MaxLength = 50;
            this.txtShipChecker.Name = "txtShipChecker";
            this.txtShipChecker.ReadOnly = true;
            this.txtShipChecker.Size = new System.Drawing.Size(250, 21);
            this.txtShipChecker.TabIndex = 33;
            // 
            // txtStockChecker
            // 
            this.txtStockChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockChecker.Location = new System.Drawing.Point(459, 33);
            this.txtStockChecker.MaxLength = 50;
            this.txtStockChecker.Name = "txtStockChecker";
            this.txtStockChecker.ReadOnly = true;
            this.txtStockChecker.Size = new System.Drawing.Size(250, 21);
            this.txtStockChecker.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(359, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "盘点人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "盘点日期";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(359, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 42;
            this.label1.Text = "岸端确认人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpSpckDate
            // 
            this.dtpSpckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpSpckDate.Location = new System.Drawing.Point(103, 33);
            this.dtpSpckDate.MaxLength = 50;
            this.dtpSpckDate.Name = "dtpSpckDate";
            this.dtpSpckDate.ReadOnly = true;
            this.dtpSpckDate.Size = new System.Drawing.Size(250, 21);
            this.dtpSpckDate.TabIndex = 46;
            // 
            // txtLandChecker
            // 
            this.txtLandChecker.CausesValidation = false;
            this.txtLandChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLandChecker.Location = new System.Drawing.Point(459, 63);
            this.txtLandChecker.MaxLength = 50;
            this.txtLandChecker.Name = "txtLandChecker";
            this.txtLandChecker.ReadOnly = true;
            this.txtLandChecker.Size = new System.Drawing.Size(250, 21);
            this.txtLandChecker.TabIndex = 55;
            // 
            // txtCheckDate
            // 
            this.txtCheckDate.CausesValidation = false;
            this.txtCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckDate.Location = new System.Drawing.Point(459, 93);
            this.txtCheckDate.MaxLength = 50;
            this.txtCheckDate.Name = "txtCheckDate";
            this.txtCheckDate.ReadOnly = true;
            this.txtCheckDate.Size = new System.Drawing.Size(250, 21);
            this.txtCheckDate.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(359, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "审核日期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "盘存单号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(359, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "盘点仓库";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(103, 3);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(250, 21);
            this.txtCode.TabIndex = 46;
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWareHouse.Location = new System.Drawing.Point(459, 3);
            this.txtWareHouse.MaxLength = 50;
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(250, 21);
            this.txtWareHouse.TabIndex = 46;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(1097, 55);
            this.panel4.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.bdNgPrintItem);
            this.flowLayoutPanel1.Controls.Add(this.btnBanlance);
            this.flowLayoutPanel1.Controls.Add(this.btnCheck);
            this.flowLayoutPanel1.Controls.Add(this.btnView);
            this.flowLayoutPanel1.Controls.Add(this.btnClone);
            this.flowLayoutPanel1.Controls.Add(this.bdNgEditItem);
            this.flowLayoutPanel1.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel1.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(525, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(567, 45);
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
            this.btnClose.Location = new System.Drawing.Point(525, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 22;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // bdNgPrintItem
            // 
            this.bdNgPrintItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgPrintItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgPrintItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgPrintItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgPrintItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgPrintItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgPrintItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgPrintItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgPrintItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgPrintItem.FadingSpeed = 20;
            this.bdNgPrintItem.FlatAppearance.BorderSize = 0;
            this.bdNgPrintItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgPrintItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgPrintItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgPrintItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgPrintItem.Image")));
            this.bdNgPrintItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgPrintItem.ImageOffset = 3;
            this.bdNgPrintItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgPrintItem.IsPressed = false;
            this.bdNgPrintItem.KeepPress = false;
            this.bdNgPrintItem.Location = new System.Drawing.Point(481, 3);
            this.bdNgPrintItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.bdNgPrintItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgPrintItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgPrintItem.Name = "bdNgPrintItem";
            this.bdNgPrintItem.Radius = 6;
            this.bdNgPrintItem.ShowBase = true;
            this.bdNgPrintItem.Size = new System.Drawing.Size(44, 42);
            this.bdNgPrintItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgPrintItem.SplitDistance = 0;
            this.bdNgPrintItem.TabIndex = 21;
            this.bdNgPrintItem.Title = "";
            this.bdNgPrintItem.UseVisualStyleBackColor = true;
            this.bdNgPrintItem.Click += new System.EventHandler(this.bdNgPrintItem_Click);
            // 
            // btnBanlance
            // 
            this.btnBanlance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBanlance.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnBanlance.BackColor = System.Drawing.Color.Transparent;
            this.btnBanlance.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnBanlance.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnBanlance.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBanlance.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBanlance.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBanlance.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBanlance.FadingSpeed = 20;
            this.btnBanlance.FlatAppearance.BorderSize = 0;
            this.btnBanlance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanlance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBanlance.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBanlance.Image = ((System.Drawing.Image)(resources.GetObject("btnBanlance.Image")));
            this.btnBanlance.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBanlance.ImageOffset = 7;
            this.btnBanlance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBanlance.IsPressed = false;
            this.btnBanlance.KeepPress = false;
            this.btnBanlance.Location = new System.Drawing.Point(378, 3);
            this.btnBanlance.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnBanlance.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBanlance.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBanlance.Name = "btnBanlance";
            this.btnBanlance.Radius = 6;
            this.btnBanlance.ShowBase = true;
            this.btnBanlance.Size = new System.Drawing.Size(103, 42);
            this.btnBanlance.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBanlance.SplitDistance = 0;
            this.btnBanlance.TabIndex = 21;
            this.btnBanlance.Text = "冲账";
            this.btnBanlance.Title = "";
            this.btnBanlance.UseVisualStyleBackColor = true;
            this.btnBanlance.Click += new System.EventHandler(this.btnBanlance_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCheck.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCheck.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCheck.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCheck.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCheck.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCheck.FadingSpeed = 20;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheck.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCheck.ImageOffset = 3;
            this.btnCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheck.IsPressed = false;
            this.btnCheck.KeepPress = false;
            this.btnCheck.Location = new System.Drawing.Point(283, 3);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Radius = 6;
            this.btnCheck.ShowBase = true;
            this.btnCheck.Size = new System.Drawing.Size(95, 42);
            this.btnCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheck.SplitDistance = 0;
            this.btnCheck.TabIndex = 25;
            this.btnCheck.Text = "审核";
            this.btnCheck.Title = "";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnView.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnView.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnView.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnView.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnView.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnView.FadingSpeed = 20;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnView.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnView.ImageOffset = 3;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.IsPressed = false;
            this.btnView.KeepPress = false;
            this.btnView.Location = new System.Drawing.Point(188, 3);
            this.btnView.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnView.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnView.MenuPos = new System.Drawing.Point(0, 0);
            this.btnView.Name = "btnView";
            this.btnView.Radius = 6;
            this.btnView.ShowBase = true;
            this.btnView.Size = new System.Drawing.Size(95, 42);
            this.btnView.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnView.SplitDistance = 0;
            this.btnView.TabIndex = 24;
            this.btnView.Text = "审阅";
            this.btnView.Title = "";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnClone
            // 
            this.btnClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClone.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClone.BackColor = System.Drawing.Color.Transparent;
            this.btnClone.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClone.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnClone.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClone.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClone.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClone.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClone.FadingSpeed = 20;
            this.btnClone.FlatAppearance.BorderSize = 0;
            this.btnClone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClone.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClone.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClone.ImageOffset = 2;
            this.btnClone.IsPressed = false;
            this.btnClone.KeepPress = false;
            this.btnClone.Location = new System.Drawing.Point(144, 3);
            this.btnClone.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClone.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClone.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClone.Name = "btnClone";
            this.btnClone.Radius = 6;
            this.btnClone.ShowBase = true;
            this.btnClone.Size = new System.Drawing.Size(44, 42);
            this.btnClone.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClone.SplitDistance = 0;
            this.btnClone.TabIndex = 52;
            this.btnClone.Title = "";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // bdNgEditItem
            // 
            this.bdNgEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgEditItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgEditItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgEditItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgEditItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgEditItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgEditItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgEditItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.FadingSpeed = 20;
            this.bdNgEditItem.FlatAppearance.BorderSize = 0;
            this.bdNgEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgEditItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 2;
            this.bdNgEditItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(100, 3);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(44, 42);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 24;
            this.bdNgEditItem.Title = "";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.bdNgEditItem_Click);
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
            this.bdNgDeleteItem.Location = new System.Drawing.Point(56, 3);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(44, 42);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 24;
            this.bdNgDeleteItem.Title = "";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
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
            this.bdNgAddNewItem.Location = new System.Drawing.Point(12, 3);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(44, 42);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 24;
            this.bdNgAddNewItem.Title = "";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
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
            this.buttonEx6.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.buttonEx6.Location = new System.Drawing.Point(5, 5);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(169, 45);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "物资盘存单";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel2.Controls.Add(this.label13);
            this.flowLayoutPanel2.Controls.Add(this.dtpStartDate);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.dtpEndDate);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.cboChkState);
            this.flowLayoutPanel2.Controls.Add(this.cbOthersData);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1091, 45);
            this.flowLayoutPanel2.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(33, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(31, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "船舶";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 104;
            this.ucShipSelect1.Location = new System.Drawing.Point(70, 10);
            this.ucShipSelect1.Margin = new System.Windows.Forms.Padding(3, 10, 0, 0);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(93, 20);
            this.ucShipSelect1.TabIndex = 28;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(33, 15, 3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "盘点日期";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(339, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(13, 15, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "审核状态";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1103, 625);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1097, 65);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查询条件";
            // 
            // FrmMaterialStockCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaterialStockCheck";
            this.Text = "物资盘存单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialStockck_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialStockck_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockckDetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockck)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.UcDataGridView dgvSpStockckDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.CheckBox cbOthersData;
        private System.Windows.Forms.ComboBox cboChkState;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvSpStockck;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtShipChecker;
        private CommonViewer.TextBoxEx txtStockChecker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx dtpSpckDate;
        private CommonViewer.TextBoxEx txtLandChecker;
        private CommonViewer.TextBoxEx txtCheckDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        public CommonViewer.ButtonEx bdNgEditItem;
        private System.Windows.Forms.Label label8;
        public CommonViewer.ButtonEx btnView;
        public CommonViewer.ButtonEx buttonEx6;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx bdNgPrintItem;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public CommonViewer.ButtonEx btnBanlance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.TextBoxEx txtState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtCode;
        private CommonViewer.TextBoxEx txtWareHouse;
        private System.Windows.Forms.Label label13;
        public CommonViewer.ButtonEx btnCheck;
        private CommonViewer.ButtonEx btnClone;

    }
}