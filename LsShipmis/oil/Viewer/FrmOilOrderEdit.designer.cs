namespace Oil.Viewer
{
    partial class FrmOilOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOilOrderEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboCURRENCY = new System.Windows.Forms.ComboBox();
            this.dgvMatApplyDetail = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvApplyDetail = new CommonViewer.UcDataGridView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnPass = new CommonViewer.ButtonEx();
            this.bdNgComplete = new CommonViewer.ButtonEx();
            this.bdNgSaveItem = new CommonViewer.ButtonEx();
            this.btnDelete = new CommonViewer.ButtonEx();
            this.btnAdd = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cobPort = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpArriveDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLandChecker = new CommonViewer.TextBoxEx();
            this.ucManufacturerSelect1 = new BaseInfo.Viewer.UcManufacturerSelect();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDown = new CommonViewer.ButtonEx();
            this.cboApply = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatApplyDetail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(860, 159);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "订购单明细信息(单位:升)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboCURRENCY);
            this.panel1.Controls.Add(this.dgvMatApplyDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 139);
            this.panel1.TabIndex = 1;
            // 
            // cboCURRENCY
            // 
            this.cboCURRENCY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCURRENCY.FormattingEnabled = true;
            this.cboCURRENCY.Location = new System.Drawing.Point(25, 22);
            this.cboCURRENCY.Name = "cboCURRENCY";
            this.cboCURRENCY.Size = new System.Drawing.Size(121, 20);
            this.cboCURRENCY.TabIndex = 43;
            this.cboCURRENCY.Visible = false;
            this.cboCURRENCY.SelectedIndexChanged += new System.EventHandler(this.cboCURRENCY_SelectedIndexChanged);
            // 
            // dgvMatApplyDetail
            // 
            this.dgvMatApplyDetail.AllowUserToAddRows = false;
            this.dgvMatApplyDetail.AllowUserToDeleteRows = false;
            this.dgvMatApplyDetail.AllowUserToOrderColumns = true;
            this.dgvMatApplyDetail.AutoFit = true;
            this.dgvMatApplyDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvMatApplyDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatApplyDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatApplyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatApplyDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatApplyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatApplyDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMatApplyDetail.EnableHeadersVisualStyles = false;
            this.dgvMatApplyDetail.ExportColorToExcel = false;
            this.dgvMatApplyDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMatApplyDetail.Footer")));
            this.dgvMatApplyDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMatApplyDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMatApplyDetail.Header")));
            this.dgvMatApplyDetail.LoadedFinish = false;
            this.dgvMatApplyDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvMatApplyDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMatApplyDetail.MergeColumnNames")));
            this.dgvMatApplyDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMatApplyDetail.MergeRowColumn")));
            this.dgvMatApplyDetail.Name = "dgvMatApplyDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatApplyDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMatApplyDetail.RowHeadersWidth = 25;
            this.dgvMatApplyDetail.RowTemplate.Height = 23;
            this.dgvMatApplyDetail.ShowRowNumber = false;
            this.dgvMatApplyDetail.Size = new System.Drawing.Size(854, 139);
            this.dgvMatApplyDetail.TabIndex = 41;
            this.dgvMatApplyDetail.Title = "";
            this.dgvMatApplyDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMatApplyDetail_CellValidating);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 574);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvApplyDetail);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(860, 114);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "待选申请单明细";
            // 
            // dgvApplyDetail
            // 
            this.dgvApplyDetail.AllowUserToAddRows = false;
            this.dgvApplyDetail.AllowUserToDeleteRows = false;
            this.dgvApplyDetail.AllowUserToOrderColumns = true;
            this.dgvApplyDetail.AutoFit = true;
            this.dgvApplyDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvApplyDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplyDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApplyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplyDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvApplyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApplyDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvApplyDetail.EnableHeadersVisualStyles = false;
            this.dgvApplyDetail.ExportColorToExcel = false;
            this.dgvApplyDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApplyDetail.Footer")));
            this.dgvApplyDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvApplyDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApplyDetail.Header")));
            this.dgvApplyDetail.LoadedFinish = false;
            this.dgvApplyDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvApplyDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApplyDetail.MergeColumnNames")));
            this.dgvApplyDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApplyDetail.MergeRowColumn")));
            this.dgvApplyDetail.Name = "dgvApplyDetail";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplyDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApplyDetail.RowHeadersWidth = 25;
            this.dgvApplyDetail.RowTemplate.Height = 23;
            this.dgvApplyDetail.ShowRowNumber = false;
            this.dgvApplyDetail.Size = new System.Drawing.Size(854, 94);
            this.dgvApplyDetail.TabIndex = 42;
            this.dgvApplyDetail.Title = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(860, 49);
            this.panel4.TabIndex = 43;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnPass);
            this.flowLayoutPanel1.Controls.Add(this.bdNgComplete);
            this.flowLayoutPanel1.Controls.Add(this.bdNgSaveItem);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(301, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(554, 39);
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
            this.btnClose.Location = new System.Drawing.Point(512, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 22;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPass.BackColor = System.Drawing.Color.Transparent;
            this.btnPass.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPass.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnPass.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPass.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPass.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPass.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPass.FadingSpeed = 20;
            this.btnPass.FlatAppearance.BorderSize = 0;
            this.btnPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPass.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPass.ImageOffset = 3;
            this.btnPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPass.IsPressed = false;
            this.btnPass.KeepPress = false;
            this.btnPass.Location = new System.Drawing.Point(401, 0);
            this.btnPass.Margin = new System.Windows.Forms.Padding(0);
            this.btnPass.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPass.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPass.Name = "btnPass";
            this.btnPass.Radius = 6;
            this.btnPass.ShowBase = true;
            this.btnPass.Size = new System.Drawing.Size(111, 40);
            this.btnPass.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPass.SplitDistance = 0;
            this.btnPass.TabIndex = 25;
            this.btnPass.Text = "审核并完结";
            this.btnPass.Title = "";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
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
            this.bdNgComplete.Location = new System.Drawing.Point(318, 0);
            this.bdNgComplete.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgComplete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgComplete.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgComplete.Name = "bdNgComplete";
            this.bdNgComplete.Radius = 6;
            this.bdNgComplete.ShowBase = true;
            this.bdNgComplete.Size = new System.Drawing.Size(83, 40);
            this.bdNgComplete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgComplete.SplitDistance = 0;
            this.bdNgComplete.TabIndex = 24;
            this.bdNgComplete.Text = "审核";
            this.bdNgComplete.Title = "";
            this.bdNgComplete.UseVisualStyleBackColor = true;
            this.bdNgComplete.Click += new System.EventHandler(this.bdNgComplete_Click);
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
            this.bdNgSaveItem.Location = new System.Drawing.Point(195, 0);
            this.bdNgSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgSaveItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.Name = "bdNgSaveItem";
            this.bdNgSaveItem.Radius = 6;
            this.bdNgSaveItem.ShowBase = true;
            this.bdNgSaveItem.Size = new System.Drawing.Size(123, 40);
            this.bdNgSaveItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgSaveItem.SplitDistance = 0;
            this.bdNgSaveItem.TabIndex = 24;
            this.bdNgSaveItem.Text = "仅保存单据";
            this.bdNgSaveItem.Title = "";
            this.bdNgSaveItem.UseVisualStyleBackColor = true;
            this.bdNgSaveItem.Click += new System.EventHandler(this.bdNgSaveItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDelete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDelete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDelete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDelete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.FadingSpeed = 20;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDelete.ImageOffset = 2;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.IsPressed = false;
            this.btnDelete.KeepPress = false;
            this.btnDelete.Location = new System.Drawing.Point(151, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDelete.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Radius = 6;
            this.btnDelete.ShowBase = true;
            this.btnDelete.Size = new System.Drawing.Size(44, 40);
            this.btnDelete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDelete.SplitDistance = 0;
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Title = "";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAdd.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAdd.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAdd.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAdd.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAdd.FadingSpeed = 20;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAdd.ImageOffset = 2;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.IsPressed = false;
            this.btnAdd.KeepPress = false;
            this.btnAdd.Location = new System.Drawing.Point(107, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAdd.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 6;
            this.btnAdd.ShowBase = true;
            this.btnAdd.Size = new System.Drawing.Size(44, 40);
            this.btnAdd.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAdd.SplitDistance = 0;
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Title = "";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.buttonEx6.Location = new System.Drawing.Point(0, 0);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(207, 48);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "润滑油订购单编辑";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 228);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(860, 343);
            this.panel3.TabIndex = 42;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(860, 343);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(860, 180);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订购单信息";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(10, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 146);
            this.panel2.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.cobPort, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpApplyDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpArriveDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLandChecker, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucManufacturerSelect1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 146);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // cobPort
            // 
            this.cobPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPort.FormattingEnabled = true;
            this.cobPort.Location = new System.Drawing.Point(655, 3);
            this.cobPort.Name = "cobPort";
            this.cobPort.Size = new System.Drawing.Size(182, 20);
            this.cobPort.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 86);
            this.label9.TabIndex = 1;
            this.label9.Text = "备    注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 5);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(103, 63);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(734, 80);
            this.txtRemark.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 38);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 22);
            this.label16.TabIndex = 1;
            this.label16.Text = "供货商";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(289, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "岸端审核人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "订购日期*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.CustomFormat = "yyyy-MM-dd";
            this.dtpApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyDate.Location = new System.Drawing.Point(103, 3);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(94, 21);
            this.dtpApplyDate.TabIndex = 27;
            this.dtpApplyDate.Value = new System.DateTime(2007, 9, 13, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(289, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "送船日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpArriveDate
            // 
            this.dtpArriveDate.CustomFormat = "yyyy-MM-dd";
            this.dtpArriveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArriveDate.Location = new System.Drawing.Point(379, 3);
            this.dtpArriveDate.Name = "dtpArriveDate";
            this.dtpArriveDate.Size = new System.Drawing.Size(95, 21);
            this.dtpArriveDate.TabIndex = 29;
            this.dtpArriveDate.Value = new System.DateTime(2007, 9, 13, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(565, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "送船港";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLandChecker
            // 
            this.txtLandChecker.CausesValidation = false;
            this.txtLandChecker.Location = new System.Drawing.Point(379, 33);
            this.txtLandChecker.MaxLength = 15;
            this.txtLandChecker.Name = "txtLandChecker";
            this.txtLandChecker.ReadOnly = true;
            this.txtLandChecker.Size = new System.Drawing.Size(180, 21);
            this.txtLandChecker.TabIndex = 44;
            // 
            // ucManufacturerSelect1
            // 
            this.ucManufacturerSelect1.CanEdit = true;
            this.ucManufacturerSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManufacturerSelect1.DropDownWidth = 180;
            this.ucManufacturerSelect1.Location = new System.Drawing.Point(103, 33);
            this.ucManufacturerSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucManufacturerSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucManufacturerSelect1.Name = "ucManufacturerSelect1";
            this.ucManufacturerSelect1.NullValueShow = "服务商";
            this.ucManufacturerSelect1.ShowButton = false;
            this.ucManufacturerSelect1.Size = new System.Drawing.Size(180, 20);
            this.ucManufacturerSelect1.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.cboApply);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 44);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已批准申请单";
            // 
            // btnDown
            // 
            this.btnDown.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDown.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDown.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDown.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDown.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDown.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDown.FadingSpeed = 20;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDown.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDown.ImageOffset = 5;
            this.btnDown.IsPressed = false;
            this.btnDown.KeepPress = false;
            this.btnDown.Location = new System.Drawing.Point(245, 13);
            this.btnDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDown.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDown.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Radius = 6;
            this.btnDown.ShowBase = true;
            this.btnDown.Size = new System.Drawing.Size(121, 25);
            this.btnDown.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDown.SplitDistance = 0;
            this.btnDown.TabIndex = 50;
            this.btnDown.Text = "申请明细到订购";
            this.btnDown.Title = "";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cboApply
            // 
            this.cboApply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApply.FormattingEnabled = true;
            this.cboApply.Location = new System.Drawing.Point(6, 18);
            this.cboApply.Name = "cboApply";
            this.cboApply.Size = new System.Drawing.Size(226, 20);
            this.cboApply.TabIndex = 49;
            this.cboApply.SelectedValueChanged += new System.EventHandler(this.cboApply_SelectedValueChanged);
            // 
            // FrmOilOrderEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(866, 574);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmOilOrderEdit";
            this.Text = "润滑油订购单编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOilOrderEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterielApplyEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatApplyDetail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.UcDataGridView dgvMatApplyDetail;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx bdNgComplete;
        public CommonViewer.ButtonEx bdNgSaveItem;
        public CommonViewer.ButtonEx btnDelete;
        public CommonViewer.ButtonEx btnAdd;
        public CommonViewer.ButtonEx buttonEx6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpApplyDate;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpArriveDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtLandChecker;
        private System.Windows.Forms.ComboBox cobPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboApply;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.UcDataGridView dgvApplyDetail;
        private CommonViewer.ButtonEx btnDown;
        private BaseInfo.Viewer.UcManufacturerSelect ucManufacturerSelect1;
        private System.Windows.Forms.ComboBox cboCURRENCY;
        public CommonViewer.ButtonEx btnPass;
    }
}