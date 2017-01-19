namespace Cost.Viewer
{
    partial class FrmEditOneVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditOneVoucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucManufacturerSelect1 = new BaseInfo.Viewer.UcManufacturerSelect();
            this.txtCommiter = new CommonViewer.TextBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.cob1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cob2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVNum = new CommonViewer.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApplyCompany = new CommonViewer.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCost = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numInvoiceNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShipOwner = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new CommonViewer.TextBoxEx();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lbShip = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.SaveButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInvoiceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 616);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 560);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "凭证信息和明细信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 540);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ucManufacturerSelect1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtCommiter, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.cob1, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.cob2, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.date1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtVNum, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtApplyCompany, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboCost, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.numInvoiceNum, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtShipOwner, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.nudAmount, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.lbShip, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ucShipSelect1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(904, 540);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ucManufacturerSelect1
            // 
            this.ucManufacturerSelect1.CanEdit = false;
            this.ucManufacturerSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManufacturerSelect1.DropDownWidth = 141;
            this.ucManufacturerSelect1.Location = new System.Drawing.Point(123, 107);
            this.ucManufacturerSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucManufacturerSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucManufacturerSelect1.Name = "ucManufacturerSelect1";
            this.ucManufacturerSelect1.NullValueShow = "供应商";
            this.ucManufacturerSelect1.ShowButton = false;
            this.ucManufacturerSelect1.Size = new System.Drawing.Size(336, 20);
            this.ucManufacturerSelect1.TabIndex = 100;
            // 
            // txtCommiter
            // 
            this.txtCommiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommiter.Location = new System.Drawing.Point(123, 211);
            this.txtCommiter.MaxLength = 100;
            this.txtCommiter.Name = "txtCommiter";
            this.txtCommiter.ReadOnly = true;
            this.txtCommiter.Size = new System.Drawing.Size(336, 21);
            this.txtCommiter.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 26);
            this.label14.TabIndex = 98;
            this.label14.Text = "提交人";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cob1
            // 
            this.cob1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cob1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob1.FormattingEnabled = true;
            this.cob1.Location = new System.Drawing.Point(123, 159);
            this.cob1.Name = "cob1";
            this.cob1.Size = new System.Drawing.Size(336, 20);
            this.cob1.TabIndex = 97;
            this.cob1.SelectedValueChanged += new System.EventHandler(this.cob1_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 26);
            this.label12.TabIndex = 96;
            this.label12.Text = "科目";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cob2
            // 
            this.cob2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cob2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob2.FormattingEnabled = true;
            this.cob2.Location = new System.Drawing.Point(123, 185);
            this.cob2.Name = "cob2";
            this.cob2.Size = new System.Drawing.Size(336, 20);
            this.cob2.TabIndex = 95;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 206);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "对应业务数据列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(892, 186);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 94);
            this.label10.TabIndex = 88;
            this.label10.Text = "备注";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // date1
            // 
            this.date1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date1.Location = new System.Drawing.Point(123, 81);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(336, 21);
            this.date1.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(3, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 26);
            this.label8.TabIndex = 76;
            this.label8.Text = "收款人*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 72;
            this.label2.Text = "凭证号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVNum
            // 
            this.txtVNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVNum.Location = new System.Drawing.Point(123, 55);
            this.txtVNum.MaxLength = 50;
            this.txtVNum.Name = "txtVNum";
            this.txtVNum.Size = new System.Drawing.Size(336, 21);
            this.txtVNum.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(465, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 26);
            this.label7.TabIndex = 74;
            this.label7.Text = "申请单位";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApplyCompany
            // 
            this.txtApplyCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApplyCompany.Location = new System.Drawing.Point(565, 55);
            this.txtApplyCompany.MaxLength = 100;
            this.txtApplyCompany.Name = "txtApplyCompany";
            this.txtApplyCompany.Size = new System.Drawing.Size(336, 21);
            this.txtApplyCompany.TabIndex = 75;
            this.txtApplyCompany.Text = "海丰发展";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 85;
            this.label4.Text = "未做凭证费用项目";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCost
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cboCost, 3);
            this.cboCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCost.FormattingEnabled = true;
            this.cboCost.Location = new System.Drawing.Point(123, 29);
            this.cboCost.Name = "cboCost";
            this.cboCost.Size = new System.Drawing.Size(778, 20);
            this.cboCost.TabIndex = 0;
            this.cboCost.SelectedValueChanged += new System.EventHandler(this.cboCost_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(465, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 26);
            this.label11.TabIndex = 50;
            this.label11.Text = "附发票份数";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numInvoiceNum
            // 
            this.numInvoiceNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numInvoiceNum.Location = new System.Drawing.Point(565, 107);
            this.numInvoiceNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numInvoiceNum.Name = "numInvoiceNum";
            this.numInvoiceNum.Size = new System.Drawing.Size(336, 21);
            this.numInvoiceNum.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(465, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 26);
            this.label5.TabIndex = 84;
            this.label5.Text = "应收船东";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipOwner
            // 
            this.txtShipOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShipOwner.Location = new System.Drawing.Point(565, 81);
            this.txtShipOwner.MaxLength = 100;
            this.txtShipOwner.Name = "txtShipOwner";
            this.txtShipOwner.ReadOnly = true;
            this.txtShipOwner.Size = new System.Drawing.Size(336, 21);
            this.txtShipOwner.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "币种";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(465, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 26);
            this.label6.TabIndex = 45;
            this.label6.Text = "金额";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(465, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 26);
            this.label9.TabIndex = 86;
            this.label9.Text = "项目说明";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(565, 159);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(336, 21);
            this.txtDescription.TabIndex = 87;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(123, 237);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(778, 88);
            this.txtRemark.TabIndex = 90;
            this.txtRemark.Text = "";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 6;
            this.nudAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAmount.Location = new System.Drawing.Point(565, 185);
            this.nudAmount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudAmount.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(336, 21);
            this.nudAmount.TabIndex = 94;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbShip
            // 
            this.lbShip.AutoSize = true;
            this.lbShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShip.ForeColor = System.Drawing.Color.Black;
            this.lbShip.Location = new System.Drawing.Point(3, 0);
            this.lbShip.Name = "lbShip";
            this.lbShip.Size = new System.Drawing.Size(114, 26);
            this.lbShip.TabIndex = 85;
            this.lbShip.Text = "按船舶过滤";
            this.lbShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 336;
            this.ucShipSelect1.Location = new System.Drawing.Point(123, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = true;
            this.ucShipSelect1.Size = new System.Drawing.Size(336, 20);
            this.ucShipSelect1.TabIndex = 101;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnBdFiles);
            this.panel3.Controls.Add(this.SaveButton);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(916, 50);
            this.panel3.TabIndex = 50;
            // 
            // btnBdFiles
            // 
            this.btnBdFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBdFiles.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnBdFiles.BackColor = System.Drawing.Color.Transparent;
            this.btnBdFiles.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnBdFiles.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnBdFiles.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBdFiles.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBdFiles.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBdFiles.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBdFiles.FadingSpeed = 20;
            this.btnBdFiles.FlatAppearance.BorderSize = 0;
            this.btnBdFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBdFiles.Font = new System.Drawing.Font("宋体", 9F);
            this.btnBdFiles.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBdFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnBdFiles.Image")));
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBdFiles.ImageOffset = 7;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(731, 5);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(102, 41);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 45;
            this.btnBdFiles.Text = "  附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.SaveButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.SaveButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.SaveButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.SaveButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SaveButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveButton.FadingSpeed = 20;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("宋体", 9F);
            this.SaveButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.SaveButton.ImageOffset = 8;
            this.SaveButton.IsPressed = false;
            this.SaveButton.KeepPress = false;
            this.SaveButton.Location = new System.Drawing.Point(651, 5);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.SaveButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.SaveButton.MenuPos = new System.Drawing.Point(0, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Radius = 6;
            this.SaveButton.ShowBase = true;
            this.SaveButton.Size = new System.Drawing.Size(80, 41);
            this.SaveButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.SaveButton.SplitDistance = 0;
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "保存";
            this.SaveButton.Title = "";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // buttonEx5
            // 
            this.buttonEx5.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx5.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx5.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx5.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx5.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx5.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx5.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx5.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx5.Enabled = false;
            this.buttonEx5.FadingSpeed = 20;
            this.buttonEx5.FlatAppearance.BorderSize = 0;
            this.buttonEx5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(3, 5);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(258, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "凭证信息维护";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.CloseButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.CloseButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.CloseButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.CloseButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CloseButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.CloseButton.FadingSpeed = 20;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("宋体", 9F);
            this.CloseButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.CloseButton.ImageOffset = 5;
            this.CloseButton.IsPressed = false;
            this.CloseButton.KeepPress = false;
            this.CloseButton.Location = new System.Drawing.Point(833, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(78, 41);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // FrmEditOneVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 616);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmEditOneVoucher";
            this.Text = "凭证信息维护";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditOneVoucher_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditOneVoucher_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInvoiceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx SaveButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtVNum;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtApplyCompany;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numInvoiceNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtShipOwner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvDetail;
        private CommonViewer.ButtonEx btnBdFiles;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.ComboBox cob2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cob1;
        private CommonViewer.TextBoxEx txtCommiter;
        private System.Windows.Forms.Label label14;
        private BaseInfo.Viewer.UcManufacturerSelect ucManufacturerSelect1;
        private System.Windows.Forms.Label lbShip;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
    }
}