namespace StorageManage.Viewer
{
    partial class FrmSpareOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpareOut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSpOut = new CommonViewer.UcDataGridView(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtStateName = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSpOutDetail = new CommonViewer.UcDataGridView(this.components);
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInMan = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpInDate = new CommonViewer.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.ucDepartmentSelect1 = new CommonViewer.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShipCheck = new CommonViewer.TextBoxEx();
            this.txtLandCheck = new CommonViewer.TextBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCheckDate = new CommonViewer.TextBoxEx();
            this.cbxIsComplete = new System.Windows.Forms.CheckBox();
            this.cbOnlyUnfinished = new System.Windows.Forms.CheckBox();
            this.cbOthersData = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.toolStripButton2 = new CommonViewer.ButtonEx();
            this.btnBalance = new CommonViewer.ButtonEx();
            this.btnCheck = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.btnClone = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.label1 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpOut)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpOutDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 125);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1002, 438);
            this.splitContainer2.SplitterDistance = 339;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSpOut);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(339, 438);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出库单信息列表";
            // 
            // dgvSpOut
            // 
            this.dgvSpOut.AllowUserToAddRows = false;
            this.dgvSpOut.AllowUserToDeleteRows = false;
            this.dgvSpOut.AllowUserToOrderColumns = true;
            this.dgvSpOut.AutoFit = true;
            this.dgvSpOut.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSpOut.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpOut.EnableHeadersVisualStyles = false;
            this.dgvSpOut.ExportColorToExcel = false;
            this.dgvSpOut.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOut.Footer")));
            this.dgvSpOut.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSpOut.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOut.Header")));
            this.dgvSpOut.LoadedFinish = false;
            this.dgvSpOut.Location = new System.Drawing.Point(8, 17);
            this.dgvSpOut.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOut.MergeColumnNames")));
            this.dgvSpOut.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOut.MergeRowColumn")));
            this.dgvSpOut.Name = "dgvSpOut";
            this.dgvSpOut.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpOut.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSpOut.RowHeadersWidth = 25;
            this.dgvSpOut.RowTemplate.Height = 23;
            this.dgvSpOut.ShowRowNumber = true;
            this.dgvSpOut.Size = new System.Drawing.Size(323, 413);
            this.dgvSpOut.TabIndex = 11;
            this.dgvSpOut.Title = "";
            this.dgvSpOut.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpOut_CellDoubleClick);
            this.dgvSpOut.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpOut_RowEnter);
            this.dgvSpOut.Sorted += new System.EventHandler(this.dgvSpOut_Sorted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(659, 438);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出库单信息添加";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtStateName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtInMan, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.dtpInDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ucDepartmentSelect1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtShipCheck, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtLandCheck, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpCheckDate, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbxIsComplete, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(639, 404);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // txtStateName
            // 
            this.txtStateName.Location = new System.Drawing.Point(432, 3);
            this.txtStateName.MaxLength = 20;
            this.txtStateName.Name = "txtStateName";
            this.txtStateName.ReadOnly = true;
            this.txtStateName.Size = new System.Drawing.Size(204, 21);
            this.txtStateName.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 30);
            this.label11.TabIndex = 45;
            this.label11.Text = "审核日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox3, 4);
            this.groupBox3.Controls.Add(this.dgvSpOutDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(633, 198);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出库单明细信息";
            // 
            // dgvSpOutDetail
            // 
            this.dgvSpOutDetail.AllowUserToAddRows = false;
            this.dgvSpOutDetail.AllowUserToDeleteRows = false;
            this.dgvSpOutDetail.AllowUserToOrderColumns = true;
            this.dgvSpOutDetail.AutoFit = true;
            this.dgvSpOutDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSpOutDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSpOutDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpOutDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSpOutDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpOutDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSpOutDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpOutDetail.EnableHeadersVisualStyles = false;
            this.dgvSpOutDetail.ExportColorToExcel = false;
            this.dgvSpOutDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOutDetail.Footer")));
            this.dgvSpOutDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSpOutDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOutDetail.Header")));
            this.dgvSpOutDetail.LoadedFinish = false;
            this.dgvSpOutDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvSpOutDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOutDetail.MergeColumnNames")));
            this.dgvSpOutDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSpOutDetail.MergeRowColumn")));
            this.dgvSpOutDetail.Name = "dgvSpOutDetail";
            this.dgvSpOutDetail.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpOutDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSpOutDetail.RowHeadersWidth = 25;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen;
            this.dgvSpOutDetail.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSpOutDetail.RowTemplate.Height = 23;
            this.dgvSpOutDetail.ShowRowNumber = true;
            this.dgvSpOutDetail.Size = new System.Drawing.Size(627, 178);
            this.dgvSpOutDetail.TabIndex = 41;
            this.dgvSpOutDetail.Title = "";
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(103, 123);
            this.txtRemark.MaxLength = 1500;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(533, 74);
            this.txtRemark.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(312, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "出库人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInMan
            // 
            this.txtInMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInMan.Location = new System.Drawing.Point(432, 33);
            this.txtInMan.MaxLength = 20;
            this.txtInMan.Name = "txtInMan";
            this.txtInMan.ReadOnly = true;
            this.txtInMan.Size = new System.Drawing.Size(204, 21);
            this.txtInMan.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "出库日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label9.Size = new System.Drawing.Size(94, 80);
            this.label9.TabIndex = 1;
            this.label9.Text = "备注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpInDate
            // 
            this.dtpInDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpInDate.Location = new System.Drawing.Point(103, 33);
            this.dtpInDate.MaxLength = 20;
            this.dtpInDate.Name = "dtpInDate";
            this.dtpInDate.ReadOnly = true;
            this.dtpInDate.Size = new System.Drawing.Size(203, 21);
            this.dtpInDate.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "出库部门*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucDepartmentSelect1
            // 
            this.ucDepartmentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartmentSelect1.Location = new System.Drawing.Point(103, 3);
            this.ucDepartmentSelect1.MaxLength = 20;
            this.ucDepartmentSelect1.Name = "ucDepartmentSelect1";
            this.ucDepartmentSelect1.ReadOnly = true;
            this.ucDepartmentSelect1.Size = new System.Drawing.Size(203, 21);
            this.ucDepartmentSelect1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "船端确认人";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(312, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "岸端确认人";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipCheck
            // 
            this.txtShipCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShipCheck.Location = new System.Drawing.Point(103, 63);
            this.txtShipCheck.MaxLength = 20;
            this.txtShipCheck.Name = "txtShipCheck";
            this.txtShipCheck.ReadOnly = true;
            this.txtShipCheck.Size = new System.Drawing.Size(203, 21);
            this.txtShipCheck.TabIndex = 24;
            // 
            // txtLandCheck
            // 
            this.txtLandCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLandCheck.Location = new System.Drawing.Point(432, 63);
            this.txtLandCheck.MaxLength = 20;
            this.txtLandCheck.Name = "txtLandCheck";
            this.txtLandCheck.ReadOnly = true;
            this.txtLandCheck.Size = new System.Drawing.Size(204, 21);
            this.txtLandCheck.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(312, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 30);
            this.label10.TabIndex = 44;
            this.label10.Text = "当前状态*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCheckDate.Location = new System.Drawing.Point(103, 93);
            this.dtpCheckDate.MaxLength = 20;
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.ReadOnly = true;
            this.dtpCheckDate.Size = new System.Drawing.Size(203, 21);
            this.dtpCheckDate.TabIndex = 46;
            // 
            // cbxIsComplete
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbxIsComplete, 2);
            this.cbxIsComplete.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxIsComplete.Enabled = false;
            this.cbxIsComplete.Location = new System.Drawing.Point(312, 93);
            this.cbxIsComplete.Name = "cbxIsComplete";
            this.cbxIsComplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxIsComplete.Size = new System.Drawing.Size(133, 24);
            this.cbxIsComplete.TabIndex = 47;
            this.cbxIsComplete.Text = "已提交";
            this.cbxIsComplete.UseVisualStyleBackColor = true;
            // 
            // cbOnlyUnfinished
            // 
            this.cbOnlyUnfinished.AutoSize = true;
            this.cbOnlyUnfinished.Checked = true;
            this.cbOnlyUnfinished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnlyUnfinished.Location = new System.Drawing.Point(555, 3);
            this.cbOnlyUnfinished.Name = "cbOnlyUnfinished";
            this.cbOnlyUnfinished.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.cbOnlyUnfinished.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbOnlyUnfinished.Size = new System.Drawing.Size(104, 26);
            this.cbOnlyUnfinished.TabIndex = 16;
            this.cbOnlyUnfinished.Text = "未审核单据";
            this.cbOnlyUnfinished.UseVisualStyleBackColor = true;
            this.cbOnlyUnfinished.CheckedChanged += new System.EventHandler(this.cbOnlyUnfinished_CheckedChanged);
            // 
            // cbOthersData
            // 
            this.cbOthersData.AutoSize = true;
            this.cbOthersData.Checked = true;
            this.cbOthersData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOthersData.Enabled = false;
            this.cbOthersData.Location = new System.Drawing.Point(421, 3);
            this.cbOthersData.Name = "cbOthersData";
            this.cbOthersData.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.cbOthersData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbOthersData.Size = new System.Drawing.Size(128, 26);
            this.cbOthersData.TabIndex = 15;
            this.cbOthersData.Text = "仅本岗位出库单";
            this.cbOthersData.UseVisualStyleBackColor = true;
            this.cbOthersData.CheckedChanged += new System.EventHandler(this.cbOthersData_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(328, 10);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(87, 21);
            this.dtpEndDate.TabIndex = 11;
            this.dtpEndDate.CloseUp += new System.EventHandler(this.dtpEndDate_CloseUp);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(226, 10);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(86, 21);
            this.dtpStartDate.TabIndex = 10;
            this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(1008, 56);
            this.panel4.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.toolStripButton2);
            this.flowLayoutPanel1.Controls.Add(this.btnBalance);
            this.flowLayoutPanel1.Controls.Add(this.btnCheck);
            this.flowLayoutPanel1.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel1.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel1.Controls.Add(this.btnClone);
            this.flowLayoutPanel1.Controls.Add(this.bdNgEditItem);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(258, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(748, 46);
            this.flowLayoutPanel1.TabIndex = 26;
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
            this.btnClose.Location = new System.Drawing.Point(706, 0);
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
            // toolStripButton2
            // 
            this.toolStripButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripButton2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.toolStripButton2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.toolStripButton2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.toolStripButton2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.toolStripButton2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripButton2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButton2.FadingSpeed = 20;
            this.toolStripButton2.FlatAppearance.BorderSize = 0;
            this.toolStripButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripButton2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.toolStripButton2.ImageOffset = 4;
            this.toolStripButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStripButton2.IsPressed = false;
            this.toolStripButton2.KeepPress = false;
            this.toolStripButton2.Location = new System.Drawing.Point(566, 0);
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.toolStripButton2.MenuPos = new System.Drawing.Point(0, 0);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Radius = 6;
            this.toolStripButton2.ShowBase = true;
            this.toolStripButton2.Size = new System.Drawing.Size(140, 42);
            this.toolStripButton2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.toolStripButton2.SplitDistance = 0;
            this.toolStripButton2.TabIndex = 21;
            this.toolStripButton2.Text = "备件月出库报表";
            this.toolStripButton2.Title = "";
            this.toolStripButton2.UseVisualStyleBackColor = true;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnBalance.BackColor = System.Drawing.Color.Transparent;
            this.btnBalance.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnBalance.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnBalance.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBalance.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBalance.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBalance.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBalance.FadingSpeed = 20;
            this.btnBalance.FlatAppearance.BorderSize = 0;
            this.btnBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBalance.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBalance.Image = ((System.Drawing.Image)(resources.GetObject("btnBalance.Image")));
            this.btnBalance.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBalance.ImageOffset = 5;
            this.btnBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBalance.IsPressed = false;
            this.btnBalance.KeepPress = false;
            this.btnBalance.Location = new System.Drawing.Point(442, 0);
            this.btnBalance.Margin = new System.Windows.Forms.Padding(0);
            this.btnBalance.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBalance.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Radius = 6;
            this.btnBalance.ShowBase = true;
            this.btnBalance.Size = new System.Drawing.Size(124, 42);
            this.btnBalance.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBalance.SplitDistance = 0;
            this.btnBalance.TabIndex = 33;
            this.btnBalance.Text = "冲账";
            this.btnBalance.Title = "";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Visible = false;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // btnCheck
            // 
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
            this.btnCheck.Location = new System.Drawing.Point(327, 0);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Radius = 6;
            this.btnCheck.ShowBase = true;
            this.btnCheck.Size = new System.Drawing.Size(115, 42);
            this.btnCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheck.SplitDistance = 0;
            this.btnCheck.TabIndex = 32;
            this.btnCheck.Text = "审核";
            this.btnCheck.Title = "";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
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
            this.bdNgDeleteItem.Location = new System.Drawing.Point(283, 0);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
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
            this.bdNgAddNewItem.Location = new System.Drawing.Point(239, 0);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
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
            // btnClone
            // 
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
            this.btnClone.ImageOffset = 3;
            this.btnClone.IsPressed = false;
            this.btnClone.KeepPress = false;
            this.btnClone.Location = new System.Drawing.Point(195, 0);
            this.btnClone.Margin = new System.Windows.Forms.Padding(0);
            this.btnClone.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnClone.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClone.Name = "btnClone";
            this.btnClone.Radius = 6;
            this.btnClone.ShowBase = true;
            this.btnClone.Size = new System.Drawing.Size(44, 42);
            this.btnClone.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClone.SplitDistance = 0;
            this.btnClone.TabIndex = 50;
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
            this.bdNgEditItem.Location = new System.Drawing.Point(151, 0);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
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
            this.buttonEx6.Location = new System.Drawing.Point(5, 3);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(236, 51);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "备件出库单";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(315, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 102;
            this.ucShipSelect1.Location = new System.Drawing.Point(49, 10);
            this.ucShipSelect1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(125, 20);
            this.ucShipSelect1.TabIndex = 25;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 566);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1002, 60);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查询过滤";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.dtpStartDate);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.dtpEndDate);
            this.flowLayoutPanel2.Controls.Add(this.cbOthersData);
            this.flowLayoutPanel2.Controls.Add(this.cbOnlyUnfinished);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(996, 40);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "船舶";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSpareOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSpareOut";
            this.Text = "备件出库单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSpareOut_FormClosing);
            this.Load += new System.EventHandler(this.FrmSpareOut_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpOut)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpOutDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvSpOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private CommonViewer.TextBoxEx txtRemark;
        private CommonViewer.TextBoxEx txtInMan;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox cbOnlyUnfinished;
        private System.Windows.Forms.CheckBox cbOthersData;
        private CommonViewer.TextBoxEx ucDepartmentSelect1;
        private CommonViewer.TextBoxEx dtpInDate;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        public CommonViewer.ButtonEx bdNgEditItem;
        public CommonViewer.ButtonEx buttonEx6;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx toolStripButton2;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvSpOutDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtShipCheck;
        private CommonViewer.TextBoxEx txtLandCheck;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx dtpCheckDate;
        private System.Windows.Forms.CheckBox cbxIsComplete;
        public CommonViewer.ButtonEx btnCheck;
        private CommonViewer.TextBoxEx txtStateName;
        public CommonViewer.ButtonEx btnBalance;
        private CommonViewer.ButtonEx btnClone;
    }
}