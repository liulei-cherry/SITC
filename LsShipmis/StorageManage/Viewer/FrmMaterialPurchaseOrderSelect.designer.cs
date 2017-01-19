namespace StorageManage.Viewer
{
    partial class FrmMaterialPurchaseOrderSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialPurchaseOrderSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOrder = new CommonViewer.UcDataGridView(this.components);
            this.btnClose = new CommonViewer.ButtonEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelect = new CommonViewer.ButtonEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_CODE = new CommonViewer.TextBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_PERSON = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMANUFACTURER_NAME = new CommonViewer.TextBoxEx();
            this.txtSENDDATE = new CommonViewer.TextBoxEx();
            this.txtLANDCHECKER = new CommonViewer.TextBoxEx();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.txtSHIP_NAME = new CommonViewer.TextBoxEx();
            this.txtPURCHASE_ORDER_DATE = new CommonViewer.TextBoxEx();
            this.txtCHECKDATE = new CommonViewer.TextBoxEx();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSENDPORT = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labShip = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.labState = new System.Windows.Forms.Label();
            this.cboChkState = new System.Windows.Forms.ComboBox();
            this.labMANUFACTURER = new System.Windows.Forms.Label();
            this.ckbMANUFACTURER = new System.Windows.Forms.ComboBox();
            this.ckbShowReference = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToOrderColumns = true;
            this.dgvOrder.AutoFit = true;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOrder.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.EnableHeadersVisualStyles = false;
            this.dgvOrder.ExportColorToExcel = false;
            this.dgvOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.Footer")));
            this.dgvOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.Header")));
            this.dgvOrder.LoadedFinish = false;
            this.dgvOrder.Location = new System.Drawing.Point(8, 17);
            this.dgvOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.MergeColumnNames")));
            this.dgvOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.MergeRowColumn")));
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrder.RowHeadersWidth = 25;
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.ShowRowNumber = true;
            this.dgvOrder.Size = new System.Drawing.Size(359, 422);
            this.dgvOrder.TabIndex = 11;
            this.dgvOrder.Title = "";
            this.dgvOrder.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dgvOrder_SelectedChanged);
            this.dgvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            // 
            // btnClose
            // 
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
            this.btnClose.Location = new System.Drawing.Point(534, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 39);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 1;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSelect);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(302, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(576, 39);
            this.flowLayoutPanel2.TabIndex = 42;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSelect.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSelect.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSelect.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSelect.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelect.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSelect.FadingSpeed = 20;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelect.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSelect.ImageOffset = 1;
            this.btnSelect.IsPressed = false;
            this.btnSelect.KeepPress = false;
            this.btnSelect.Location = new System.Drawing.Point(413, 0);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSelect.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Radius = 6;
            this.btnSelect.ShowBase = true;
            this.btnSelect.Size = new System.Drawing.Size(121, 39);
            this.btnSelect.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSelect.SplitDistance = 0;
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "选择并关闭";
            this.btnSelect.Title = "";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(499, 447);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "订单信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_CODE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_PERSON, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtREMARK, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label14, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtMANUFACTURER_NAME, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSENDDATE, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLANDCHECKER, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_NAME, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_DATE, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCHECKDATE, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSENDPORT, 3, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(479, 413);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(316, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 30);
            this.label7.TabIndex = 56;
            this.label7.Text = "船舶";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(316, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "岸端确认日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "处理单号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_CODE
            // 
            this.txtPURCHASE_ORDER_CODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_CODE.Enabled = false;
            this.txtPURCHASE_ORDER_CODE.Location = new System.Drawing.Point(78, 3);
            this.txtPURCHASE_ORDER_CODE.MaxLength = 50;
            this.txtPURCHASE_ORDER_CODE.Name = "txtPURCHASE_ORDER_CODE";
            this.txtPURCHASE_ORDER_CODE.Size = new System.Drawing.Size(73, 21);
            this.txtPURCHASE_ORDER_CODE.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "供应商";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "发起日期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_PERSON
            // 
            this.txtPURCHASE_ORDER_PERSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_PERSON.Enabled = false;
            this.txtPURCHASE_ORDER_PERSON.Location = new System.Drawing.Point(237, 3);
            this.txtPURCHASE_ORDER_PERSON.MaxLength = 20;
            this.txtPURCHASE_ORDER_PERSON.Name = "txtPURCHASE_ORDER_PERSON";
            this.txtPURCHASE_ORDER_PERSON.Size = new System.Drawing.Size(73, 21);
            this.txtPURCHASE_ORDER_PERSON.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(157, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "申请人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 63);
            this.label10.TabIndex = 1;
            this.label10.Text = "备注";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtREMARK, 5);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Enabled = false;
            this.txtREMARK.Location = new System.Drawing.Point(78, 93);
            this.txtREMARK.MaxLength = 1500;
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.Size = new System.Drawing.Size(398, 57);
            this.txtREMARK.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(157, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "到货日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(316, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 30);
            this.label14.TabIndex = 49;
            this.label14.Text = "岸端审核人";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMANUFACTURER_NAME
            // 
            this.txtMANUFACTURER_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMANUFACTURER_NAME.Enabled = false;
            this.txtMANUFACTURER_NAME.Location = new System.Drawing.Point(78, 63);
            this.txtMANUFACTURER_NAME.MaxLength = 20;
            this.txtMANUFACTURER_NAME.Name = "txtMANUFACTURER_NAME";
            this.txtMANUFACTURER_NAME.Size = new System.Drawing.Size(73, 21);
            this.txtMANUFACTURER_NAME.TabIndex = 28;
            // 
            // txtSENDDATE
            // 
            this.txtSENDDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSENDDATE.Enabled = false;
            this.txtSENDDATE.Location = new System.Drawing.Point(237, 33);
            this.txtSENDDATE.MaxLength = 20;
            this.txtSENDDATE.Name = "txtSENDDATE";
            this.txtSENDDATE.Size = new System.Drawing.Size(73, 21);
            this.txtSENDDATE.TabIndex = 28;
            // 
            // txtLANDCHECKER
            // 
            this.txtLANDCHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLANDCHECKER.Enabled = false;
            this.txtLANDCHECKER.Location = new System.Drawing.Point(401, 63);
            this.txtLANDCHECKER.MaxLength = 20;
            this.txtLANDCHECKER.Name = "txtLANDCHECKER";
            this.txtLANDCHECKER.Size = new System.Drawing.Size(75, 21);
            this.txtLANDCHECKER.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox4, 6);
            this.groupBox4.Controls.Add(this.dgvDetail);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(473, 254);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "订单详细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.ExportColorToExcel = false;
            this.dgvDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Footer")));
            this.dgvDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Header")));
            this.dgvDetail.LoadedFinish = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeColumnNames")));
            this.dgvDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeRowColumn")));
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(467, 234);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            // 
            // txtSHIP_NAME
            // 
            this.txtSHIP_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_NAME.Enabled = false;
            this.txtSHIP_NAME.Location = new System.Drawing.Point(401, 3);
            this.txtSHIP_NAME.MaxLength = 20;
            this.txtSHIP_NAME.Name = "txtSHIP_NAME";
            this.txtSHIP_NAME.Size = new System.Drawing.Size(75, 21);
            this.txtSHIP_NAME.TabIndex = 28;
            // 
            // txtPURCHASE_ORDER_DATE
            // 
            this.txtPURCHASE_ORDER_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_DATE.Enabled = false;
            this.txtPURCHASE_ORDER_DATE.Location = new System.Drawing.Point(78, 33);
            this.txtPURCHASE_ORDER_DATE.MaxLength = 50;
            this.txtPURCHASE_ORDER_DATE.Name = "txtPURCHASE_ORDER_DATE";
            this.txtPURCHASE_ORDER_DATE.Size = new System.Drawing.Size(73, 21);
            this.txtPURCHASE_ORDER_DATE.TabIndex = 21;
            // 
            // txtCHECKDATE
            // 
            this.txtCHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCHECKDATE.Enabled = false;
            this.txtCHECKDATE.Location = new System.Drawing.Point(401, 33);
            this.txtCHECKDATE.MaxLength = 50;
            this.txtCHECKDATE.Name = "txtCHECKDATE";
            this.txtCHECKDATE.Size = new System.Drawing.Size(75, 21);
            this.txtCHECKDATE.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(157, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 30);
            this.label15.TabIndex = 49;
            this.label15.Text = "送货港口";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSENDPORT
            // 
            this.txtSENDPORT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSENDPORT.Enabled = false;
            this.txtSENDPORT.Location = new System.Drawing.Point(237, 63);
            this.txtSENDPORT.MaxLength = 20;
            this.txtSENDPORT.Name = "txtSENDPORT";
            this.txtSENDPORT.Size = new System.Drawing.Size(73, 21);
            this.txtSENDPORT.TabIndex = 28;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 562);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Controls.Add(this.buttonEx2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(884, 51);
            this.panel4.TabIndex = 11;
            // 
            // buttonEx2
            // 
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx2.AutoSize = true;
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx2.Enabled = false;
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(6, 6);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = false;
            this.buttonEx2.Size = new System.Drawing.Size(296, 39);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "物资采购订单选择";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labShip);
            this.flowLayoutPanel1.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel1.Controls.Add(this.labState);
            this.flowLayoutPanel1.Controls.Add(this.cboChkState);
            this.flowLayoutPanel1.Controls.Add(this.labMANUFACTURER);
            this.flowLayoutPanel1.Controls.Add(this.ckbMANUFACTURER);
            this.flowLayoutPanel1.Controls.Add(this.ckbShowReference);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(872, 32);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // labShip
            // 
            this.labShip.AutoSize = true;
            this.labShip.Location = new System.Drawing.Point(3, 0);
            this.labShip.Name = "labShip";
            this.labShip.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.labShip.Size = new System.Drawing.Size(44, 19);
            this.labShip.TabIndex = 26;
            this.labShip.Text = "船舶";
            this.labShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 110;
            this.ucShipSelect1.Location = new System.Drawing.Point(53, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(141, 20);
            this.ucShipSelect1.TabIndex = 27;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(200, 0);
            this.labState.Name = "labState";
            this.labState.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.labState.Size = new System.Drawing.Size(44, 19);
            this.labState.TabIndex = 26;
            this.labState.Text = "状态";
            this.labState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboChkState
            // 
            this.cboChkState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChkState.FormattingEnabled = true;
            this.cboChkState.Location = new System.Drawing.Point(250, 3);
            this.cboChkState.Name = "cboChkState";
            this.cboChkState.Size = new System.Drawing.Size(182, 20);
            this.cboChkState.TabIndex = 4;
            this.cboChkState.SelectedIndexChanged += new System.EventHandler(this.cboChkState_SelectedIndexChanged);
            // 
            // labMANUFACTURER
            // 
            this.labMANUFACTURER.AutoSize = true;
            this.labMANUFACTURER.Location = new System.Drawing.Point(438, 0);
            this.labMANUFACTURER.Name = "labMANUFACTURER";
            this.labMANUFACTURER.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.labMANUFACTURER.Size = new System.Drawing.Size(56, 19);
            this.labMANUFACTURER.TabIndex = 29;
            this.labMANUFACTURER.Text = "供应商";
            this.labMANUFACTURER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labMANUFACTURER.Visible = false;
            // 
            // ckbMANUFACTURER
            // 
            this.ckbMANUFACTURER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ckbMANUFACTURER.DropDownWidth = 350;
            this.ckbMANUFACTURER.FormattingEnabled = true;
            this.ckbMANUFACTURER.Location = new System.Drawing.Point(500, 3);
            this.ckbMANUFACTURER.Name = "ckbMANUFACTURER";
            this.ckbMANUFACTURER.Size = new System.Drawing.Size(182, 20);
            this.ckbMANUFACTURER.TabIndex = 28;
            this.ckbMANUFACTURER.Visible = false;
            this.ckbMANUFACTURER.SelectedIndexChanged += new System.EventHandler(this.ckbMANUFACTURER_SelectedIndexChanged);
            // 
            // ckbShowReference
            // 
            this.ckbShowReference.AutoSize = true;
            this.ckbShowReference.Location = new System.Drawing.Point(695, 7);
            this.ckbShowReference.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.ckbShowReference.Name = "ckbShowReference";
            this.ckbShowReference.Size = new System.Drawing.Size(120, 16);
            this.ckbShowReference.TabIndex = 30;
            this.ckbShowReference.Text = "显示被入库单引用";
            this.ckbShowReference.UseVisualStyleBackColor = true;
            this.ckbShowReference.CheckedChanged += new System.EventHandler(this.ckbShowReference_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 112);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(878, 447);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOrder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(375, 447);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单列表";
            // 
            // FrmMaterialPurchaseOrderSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaterialPurchaseOrderSelect";
            this.Text = "物资采购订单选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialPurchaseOrderSelect_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialPurchaseOrderSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonViewer.UcDataGridView dgvOrder;
        protected CommonViewer.ButtonEx btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_CODE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_PERSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtREMARK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private CommonViewer.TextBoxEx txtMANUFACTURER_NAME;
        private CommonViewer.TextBoxEx txtSENDDATE;
        private CommonViewer.TextBoxEx txtLANDCHECKER;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.UcDataGridView dgvDetail;
        private CommonViewer.TextBoxEx txtSHIP_NAME;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_DATE;
        private CommonViewer.TextBoxEx txtCHECKDATE;
        private System.Windows.Forms.Label label15;
        private CommonViewer.TextBoxEx txtSENDPORT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx buttonEx2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labShip;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.ComboBox cboChkState;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.ButtonEx btnSelect;
        private System.Windows.Forms.Label labMANUFACTURER;
        private System.Windows.Forms.ComboBox ckbMANUFACTURER;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox ckbShowReference;

    }
}