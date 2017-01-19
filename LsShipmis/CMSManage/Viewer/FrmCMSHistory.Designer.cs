namespace CMSManage.Viewer
{
    partial class FrmCMSHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCMSHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEndFinDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartFinDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.cbx_CheckState = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCMSCheckList = new CommonViewer.UcDataGridView(this.components);
            this.grpWorkOrderList = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckName = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckPlace = new CommonViewer.TextBoxEx();
            this.dtCheckDate = new CommonViewer.DateTimePickerEx();
            this.dtBegin = new CommonViewer.DateTimePickerEx();
            this.dtEnd = new CommonViewer.DateTimePickerEx();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCheckerName = new CommonViewer.TextBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtShip = new CommonViewer.TextBoxEx();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rb_plan = new System.Windows.Forms.RadioButton();
            this.rb_Complete = new System.Windows.Forms.RadioButton();
            this.rb_flaw = new System.Windows.Forms.RadioButton();
            this.dgvCMSCheckLogDetailList = new CommonViewer.UcDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Print = new CommonViewer.ButtonEx();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdsCMSCheck = new System.Windows.Forms.BindingSource(this.components);
            this.bdsCmsCheckLog = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSCheckList)).BeginInit();
            this.grpWorkOrderList.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSCheckLogDetailList)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCmsCheckLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 571);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dtpEndFinDate);
            this.groupBox2.Controls.Add(this.dtpStartFinDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ucShipSelect1);
            this.groupBox2.Controls.Add(this.cbx_CheckState);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1098, 56);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检索条件";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(867, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 62;
            this.checkBox1.Text = "只看问题项";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(544, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 23);
            this.label13.TabIndex = 61;
            this.label13.Text = "检验时间";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndFinDate
            // 
            this.dtpEndFinDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndFinDate.Location = new System.Drawing.Point(758, 21);
            this.dtpEndFinDate.Name = "dtpEndFinDate";
            this.dtpEndFinDate.Size = new System.Drawing.Size(82, 21);
            this.dtpEndFinDate.TabIndex = 59;
            // 
            // dtpStartFinDate
            // 
            this.dtpStartFinDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartFinDate.Location = new System.Drawing.Point(645, 21);
            this.dtpStartFinDate.Name = "dtpStartFinDate";
            this.dtpStartFinDate.Size = new System.Drawing.Size(92, 21);
            this.dtpStartFinDate.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(743, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(9, 7);
            this.label8.TabIndex = 60;
            this.label8.Text = "~";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "检验船舶";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(290, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "检验状态";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 159;
            this.ucShipSelect1.Location = new System.Drawing.Point(130, 23);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(127, 20);
            this.ucShipSelect1.TabIndex = 54;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // cbx_CheckState
            // 
            this.cbx_CheckState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_CheckState.FormattingEnabled = true;
            this.cbx_CheckState.Items.AddRange(new object[] {
            "全部",
            "未检验",
            "检验通过",
            "存在缺陷"});
            this.cbx_CheckState.Location = new System.Drawing.Point(381, 23);
            this.cbx_CheckState.Name = "cbx_CheckState";
            this.cbx_CheckState.Size = new System.Drawing.Size(121, 20);
            this.cbx_CheckState.TabIndex = 55;
            this.cbx_CheckState.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 125);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpWorkOrderList);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 443);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCMSCheckList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CMS检验清单";
            // 
            // dgvCMSCheckList
            // 
            this.dgvCMSCheckList.AllowUserToAddRows = false;
            this.dgvCMSCheckList.AllowUserToDeleteRows = false;
            this.dgvCMSCheckList.AllowUserToOrderColumns = true;
            this.dgvCMSCheckList.AutoFit = true;
            this.dgvCMSCheckList.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCMSCheckList.ColumnDeep = 1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSCheckList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCMSCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCMSCheckList.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCMSCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCMSCheckList.EnableHeadersVisualStyles = false;
            this.dgvCMSCheckList.ExportColorToExcel = false;
            this.dgvCMSCheckList.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckList.Footer")));
            this.dgvCMSCheckList.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvCMSCheckList.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckList.Header")));
            this.dgvCMSCheckList.LoadedFinish = false;
            this.dgvCMSCheckList.Location = new System.Drawing.Point(3, 17);
            this.dgvCMSCheckList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckList.MergeColumnNames")));
            this.dgvCMSCheckList.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckList.MergeRowColumn")));
            this.dgvCMSCheckList.Name = "dgvCMSCheckList";
            this.dgvCMSCheckList.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSCheckList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCMSCheckList.RowHeadersWidth = 30;
            this.dgvCMSCheckList.RowTemplate.Height = 23;
            this.dgvCMSCheckList.ShowRowNumber = false;
            this.dgvCMSCheckList.Size = new System.Drawing.Size(360, 423);
            this.dgvCMSCheckList.TabIndex = 0;
            this.dgvCMSCheckList.Title = "";
            this.dgvCMSCheckList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucDataGridView1_RowEnter);
            // 
            // grpWorkOrderList
            // 
            this.grpWorkOrderList.Controls.Add(this.splitContainer2);
            this.grpWorkOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkOrderList.Location = new System.Drawing.Point(0, 0);
            this.grpWorkOrderList.Name = "grpWorkOrderList";
            this.grpWorkOrderList.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.grpWorkOrderList.Size = new System.Drawing.Size(728, 443);
            this.grpWorkOrderList.TabIndex = 13;
            this.grpWorkOrderList.TabStop = false;
            this.grpWorkOrderList.Text = "检验项目内容";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(8, 17);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvCMSCheckLogDetailList);
            this.splitContainer2.Size = new System.Drawing.Size(712, 418);
            this.splitContainer2.SplitterDistance = 189;
            this.splitContainer2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.txtDetail, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckPlace, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtCheckDate, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtBegin, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtEnd, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckerName, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtShip, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 3, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(712, 189);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // txtDetail
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtDetail, 5);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(123, 81);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.tableLayoutPanel3.SetRowSpan(this.txtDetail, 2);
            this.txtDetail.Size = new System.Drawing.Size(586, 105);
            this.txtDetail.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "检验编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckName
            // 
            this.txtCheckName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckName.Location = new System.Drawing.Point(123, 3);
            this.txtCheckName.Name = "txtCheckName";
            this.txtCheckName.ReadOnly = true;
            this.txtCheckName.Size = new System.Drawing.Size(111, 21);
            this.txtCheckName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(240, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "检验日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(240, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "自检跨度开始";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(477, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "检验地点";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(477, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "自检跨度结束";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckPlace
            // 
            this.txtCheckPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckPlace.Location = new System.Drawing.Point(597, 3);
            this.txtCheckPlace.Name = "txtCheckPlace";
            this.txtCheckPlace.ReadOnly = true;
            this.txtCheckPlace.Size = new System.Drawing.Size(112, 21);
            this.txtCheckPlace.TabIndex = 8;
            // 
            // dtCheckDate
            // 
            this.dtCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCheckDate.Location = new System.Drawing.Point(360, 3);
            this.dtCheckDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtCheckDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtCheckDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtCheckDate.Name = "dtCheckDate";
            this.dtCheckDate.ReadOnly = true;
            this.dtCheckDate.Size = new System.Drawing.Size(111, 23);
            this.dtCheckDate.TabIndex = 10;
            this.dtCheckDate.Value = new System.DateTime(((long)(0)));
            // 
            // dtBegin
            // 
            this.dtBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtBegin.Location = new System.Drawing.Point(360, 29);
            this.dtBegin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtBegin.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtBegin.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.ReadOnly = true;
            this.dtBegin.Size = new System.Drawing.Size(111, 23);
            this.dtBegin.TabIndex = 11;
            this.dtBegin.Value = new System.DateTime(((long)(0)));
            // 
            // dtEnd
            // 
            this.dtEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtEnd.Location = new System.Drawing.Point(597, 29);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtEnd.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtEnd.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ReadOnly = true;
            this.dtEnd.Size = new System.Drawing.Size(112, 23);
            this.dtEnd.TabIndex = 12;
            this.dtEnd.Value = new System.DateTime(((long)(0)));
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 23);
            this.label9.TabIndex = 13;
            this.label9.Text = "验船师";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 44);
            this.label7.TabIndex = 9;
            this.label7.Text = "检验说明";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckerName
            // 
            this.txtCheckerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckerName.Location = new System.Drawing.Point(123, 29);
            this.txtCheckerName.Name = "txtCheckerName";
            this.txtCheckerName.ReadOnly = true;
            this.txtCheckerName.Size = new System.Drawing.Size(111, 21);
            this.txtCheckerName.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "被检船舶";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(240, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 23);
            this.label11.TabIndex = 13;
            this.label11.Text = "检验状态";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShip
            // 
            this.txtShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShip.Location = new System.Drawing.Point(123, 55);
            this.txtShip.Name = "txtShip";
            this.txtShip.ReadOnly = true;
            this.txtShip.Size = new System.Drawing.Size(111, 21);
            this.txtShip.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.rb_plan);
            this.flowLayoutPanel1.Controls.Add(this.rb_Complete);
            this.flowLayoutPanel1.Controls.Add(this.rb_flaw);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(357, 52);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(355, 26);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // rb_plan
            // 
            this.rb_plan.AutoSize = true;
            this.rb_plan.Enabled = false;
            this.rb_plan.Location = new System.Drawing.Point(3, 3);
            this.rb_plan.Name = "rb_plan";
            this.rb_plan.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.rb_plan.Size = new System.Drawing.Size(59, 18);
            this.rb_plan.TabIndex = 0;
            this.rb_plan.TabStop = true;
            this.rb_plan.Text = "未检验";
            this.rb_plan.UseVisualStyleBackColor = true;
            // 
            // rb_Complete
            // 
            this.rb_Complete.AutoSize = true;
            this.rb_Complete.Enabled = false;
            this.rb_Complete.Location = new System.Drawing.Point(68, 3);
            this.rb_Complete.Name = "rb_Complete";
            this.rb_Complete.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.rb_Complete.Size = new System.Drawing.Size(71, 18);
            this.rb_Complete.TabIndex = 1;
            this.rb_Complete.TabStop = true;
            this.rb_Complete.Text = "检验完成";
            this.rb_Complete.UseVisualStyleBackColor = true;
            // 
            // rb_flaw
            // 
            this.rb_flaw.AutoSize = true;
            this.rb_flaw.Enabled = false;
            this.rb_flaw.Location = new System.Drawing.Point(145, 3);
            this.rb_flaw.Name = "rb_flaw";
            this.rb_flaw.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.rb_flaw.Size = new System.Drawing.Size(71, 18);
            this.rb_flaw.TabIndex = 2;
            this.rb_flaw.TabStop = true;
            this.rb_flaw.Text = "存在缺陷";
            this.rb_flaw.UseVisualStyleBackColor = true;
            // 
            // dgvCMSCheckLogDetailList
            // 
            this.dgvCMSCheckLogDetailList.AllowUserToAddRows = false;
            this.dgvCMSCheckLogDetailList.AllowUserToDeleteRows = false;
            this.dgvCMSCheckLogDetailList.AllowUserToOrderColumns = true;
            this.dgvCMSCheckLogDetailList.AutoFit = true;
            this.dgvCMSCheckLogDetailList.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCMSCheckLogDetailList.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSCheckLogDetailList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCMSCheckLogDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCMSCheckLogDetailList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCMSCheckLogDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCMSCheckLogDetailList.EnableHeadersVisualStyles = false;
            this.dgvCMSCheckLogDetailList.ExportColorToExcel = false;
            this.dgvCMSCheckLogDetailList.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckLogDetailList.Footer")));
            this.dgvCMSCheckLogDetailList.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvCMSCheckLogDetailList.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckLogDetailList.Header")));
            this.dgvCMSCheckLogDetailList.LoadedFinish = false;
            this.dgvCMSCheckLogDetailList.Location = new System.Drawing.Point(0, 0);
            this.dgvCMSCheckLogDetailList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckLogDetailList.MergeColumnNames")));
            this.dgvCMSCheckLogDetailList.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSCheckLogDetailList.MergeRowColumn")));
            this.dgvCMSCheckLogDetailList.Name = "dgvCMSCheckLogDetailList";
            this.dgvCMSCheckLogDetailList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSCheckLogDetailList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCMSCheckLogDetailList.RowHeadersWidth = 25;
            this.dgvCMSCheckLogDetailList.RowTemplate.Height = 23;
            this.dgvCMSCheckLogDetailList.ShowRowNumber = false;
            this.dgvCMSCheckLogDetailList.Size = new System.Drawing.Size(712, 225);
            this.dgvCMSCheckLogDetailList.TabIndex = 7;
            this.dgvCMSCheckLogDetailList.Title = "";
            this.dgvCMSCheckLogDetailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCMSCheckLogDetailList_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btn_Print);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1098, 54);
            this.panel3.TabIndex = 53;
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_Print.BackColor = System.Drawing.Color.Transparent;
            this.btn_Print.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_Print.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Print.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_Print.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_Print.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Print.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Print.FadingSpeed = 20;
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_Print.ImageOffset = 0;
            this.btn_Print.IsPressed = false;
            this.btn_Print.KeepPress = false;
            this.btn_Print.Location = new System.Drawing.Point(873, 6);
            this.btn_Print.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Print.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_Print.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Radius = 6;
            this.btn_Print.ShowBase = true;
            this.btn_Print.Size = new System.Drawing.Size(133, 43);
            this.btn_Print.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_Print.SplitDistance = 0;
            this.btn_Print.TabIndex = 53;
            this.btn_Print.Text = "CMS检验打印";
            this.btn_Print.Title = "";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.Enabled = false;
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 0;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(6, 6);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = false;
            this.buttonEx1.Size = new System.Drawing.Size(220, 44);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 47;
            this.buttonEx1.Text = "CMS检验历史查询";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 2;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(1006, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(87, 43);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "关闭";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // FrmCMSHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCMSHistory";
            this.Text = "CMS检验历史查询";
            this.Load += new System.EventHandler(this.FrmWorkOrderHistory_Load);
            this.Shown += new System.EventHandler(this.FrmCMSHistory_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkOrderHistory_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSCheckList)).EndInit();
            this.grpWorkOrderList.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSCheckLogDetailList)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCmsCheckLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource bdsCMSCheck;
        private CommonViewer.ButtonEx btnClose;
        private CommonViewer.ButtonEx buttonEx1;
        private CommonViewer.ButtonEx btn_Print;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.ComboBox cbx_CheckState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpWorkOrderList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CommonViewer.TextBoxEx txtDetail;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtCheckName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CommonViewer.TextBoxEx txtCheckPlace;
        private CommonViewer.DateTimePickerEx dtCheckDate;
        private CommonViewer.DateTimePickerEx dtBegin;
        private CommonViewer.DateTimePickerEx dtEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtCheckerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private CommonViewer.TextBoxEx txtShip;
        private CommonViewer.UcDataGridView dgvCMSCheckLogDetailList;
        private CommonViewer.UcDataGridView dgvCMSCheckList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEndFinDate;
        private System.Windows.Forms.DateTimePicker dtpStartFinDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bdsCmsCheckLog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rb_plan;
        private System.Windows.Forms.RadioButton rb_Complete;
        private System.Windows.Forms.RadioButton rb_flaw;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}