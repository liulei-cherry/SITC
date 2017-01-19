namespace Oil.Viewer
{
    partial class FrmOilAudit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOilAudit));
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOilApplyDetail = new CommonViewer.UcDataGridView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btn_NotOk = new CommonViewer.ButtonEx();
            this.btn_Ok = new CommonViewer.ButtonEx();
            this.buttonEx7 = new CommonViewer.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cobPort = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCheckor = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLeader = new CommonViewer.TextBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpArriveDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoyage = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLandChecker = new CommonViewer.TextBoxEx();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOilApplyDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 550);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 278);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(664, 269);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "申请单明细信息(单位:升)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOilApplyDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 249);
            this.panel2.TabIndex = 1;
            // 
            // dgvOilApplyDetail
            // 
            this.dgvOilApplyDetail.AllowUserToAddRows = false;
            this.dgvOilApplyDetail.AllowUserToDeleteRows = false;
            this.dgvOilApplyDetail.AllowUserToOrderColumns = true;
            this.dgvOilApplyDetail.AutoFit = true;
            this.dgvOilApplyDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOilApplyDetail.ColumnDeep = 1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOilApplyDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOilApplyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOilApplyDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOilApplyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOilApplyDetail.EnableHeadersVisualStyles = false;
            this.dgvOilApplyDetail.ExportColorToExcel = false;
            this.dgvOilApplyDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOilApplyDetail.Footer")));
            this.dgvOilApplyDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvOilApplyDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOilApplyDetail.Header")));
            this.dgvOilApplyDetail.LoadedFinish = false;
            this.dgvOilApplyDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvOilApplyDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOilApplyDetail.MergeColumnNames")));
            this.dgvOilApplyDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOilApplyDetail.MergeRowColumn")));
            this.dgvOilApplyDetail.Name = "dgvOilApplyDetail";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOilApplyDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOilApplyDetail.RowHeadersWidth = 25;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen;
            this.dgvOilApplyDetail.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOilApplyDetail.RowTemplate.Height = 23;
            this.dgvOilApplyDetail.ShowRowNumber = false;
            this.dgvOilApplyDetail.Size = new System.Drawing.Size(658, 249);
            this.dgvOilApplyDetail.TabIndex = 51;
            this.dgvOilApplyDetail.Title = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(664, 53);
            this.panel4.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btn_NotOk);
            this.flowLayoutPanel1.Controls.Add(this.btn_Ok);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(436, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(228, 52);
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
            this.btnClose.Location = new System.Drawing.Point(176, 5);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_NotOk
            // 
            this.btn_NotOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NotOk.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_NotOk.BackColor = System.Drawing.Color.Transparent;
            this.btn_NotOk.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_NotOk.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btn_NotOk.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_NotOk.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_NotOk.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_NotOk.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_NotOk.FadingSpeed = 20;
            this.btn_NotOk.FlatAppearance.BorderSize = 0;
            this.btn_NotOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NotOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_NotOk.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_NotOk.Image = ((System.Drawing.Image)(resources.GetObject("btn_NotOk.Image")));
            this.btn_NotOk.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_NotOk.ImageOffset = 3;
            this.btn_NotOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_NotOk.IsPressed = false;
            this.btn_NotOk.KeepPress = false;
            this.btn_NotOk.Location = new System.Drawing.Point(82, 5);
            this.btn_NotOk.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NotOk.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_NotOk.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_NotOk.Name = "btn_NotOk";
            this.btn_NotOk.Radius = 6;
            this.btn_NotOk.ShowBase = true;
            this.btn_NotOk.Size = new System.Drawing.Size(94, 42);
            this.btn_NotOk.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_NotOk.SplitDistance = 0;
            this.btn_NotOk.TabIndex = 24;
            this.btn_NotOk.Text = "不同意";
            this.btn_NotOk.Title = "";
            this.btn_NotOk.UseVisualStyleBackColor = true;
            this.btn_NotOk.Visible = false;
            this.btn_NotOk.Click += new System.EventHandler(this.btn_NotOk_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_Ok.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btn_Ok.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_Ok.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_Ok.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Ok.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Ok.FadingSpeed = 20;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Ok.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_Ok.ImageOffset = 3;
            this.btn_Ok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Ok.IsPressed = false;
            this.btn_Ok.KeepPress = false;
            this.btn_Ok.Location = new System.Drawing.Point(0, 5);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Ok.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_Ok.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Radius = 6;
            this.btn_Ok.ShowBase = true;
            this.btn_Ok.Size = new System.Drawing.Size(82, 42);
            this.btn_Ok.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_Ok.SplitDistance = 0;
            this.btn_Ok.TabIndex = 24;
            this.btn_Ok.Text = "同意";
            this.btn_Ok.Title = "";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // buttonEx7
            // 
            this.buttonEx7.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx7.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx7.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx7.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx7.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx7.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx7.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx7.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx7.Enabled = false;
            this.buttonEx7.FadingSpeed = 20;
            this.buttonEx7.FlatAppearance.BorderSize = 0;
            this.buttonEx7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx7.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx7.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx7.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx7.Image")));
            this.buttonEx7.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx7.ImageOffset = 3;
            this.buttonEx7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx7.IsPressed = false;
            this.buttonEx7.KeepPress = false;
            this.buttonEx7.Location = new System.Drawing.Point(2, 4);
            this.buttonEx7.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx7.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx7.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx7.Name = "buttonEx7";
            this.buttonEx7.Radius = 6;
            this.buttonEx7.ShowBase = false;
            this.buttonEx7.Size = new System.Drawing.Size(231, 42);
            this.buttonEx7.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx7.SplitDistance = 0;
            this.buttonEx7.TabIndex = 23;
            this.buttonEx7.Text = "润滑油申请审核";
            this.buttonEx7.Title = "";
            this.buttonEx7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 210);
            this.panel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cobPort, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCheckor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtLeader, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpApplyDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpArriveDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtVoyage, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtLandChecker, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(664, 210);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // cobPort
            // 
            this.cobPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPort.FormattingEnabled = true;
            this.cobPort.Location = new System.Drawing.Point(103, 33);
            this.cobPort.Name = "cobPort";
            this.cobPort.Size = new System.Drawing.Size(231, 20);
            this.cobPort.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 90);
            this.label9.TabIndex = 1;
            this.label9.Text = "备    注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(103, 123);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(558, 84);
            this.txtRemark.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 68);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 22);
            this.label16.TabIndex = 1;
            this.label16.Text = "部门长签字";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCheckor
            // 
            this.txtCheckor.CausesValidation = false;
            this.txtCheckor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckor.Location = new System.Drawing.Point(103, 63);
            this.txtCheckor.MaxLength = 15;
            this.txtCheckor.Name = "txtCheckor";
            this.txtCheckor.ReadOnly = true;
            this.txtCheckor.Size = new System.Drawing.Size(231, 21);
            this.txtCheckor.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(340, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "船长签字";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLeader
            // 
            this.txtLeader.CausesValidation = false;
            this.txtLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLeader.Location = new System.Drawing.Point(430, 63);
            this.txtLeader.MaxLength = 15;
            this.txtLeader.Name = "txtLeader";
            this.txtLeader.ReadOnly = true;
            this.txtLeader.Size = new System.Drawing.Size(231, 21);
            this.txtLeader.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "申请日期*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.CustomFormat = "yyyy-MM-dd";
            this.dtpApplyDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpApplyDate.Enabled = false;
            this.dtpApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyDate.Location = new System.Drawing.Point(103, 3);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(231, 21);
            this.dtpApplyDate.TabIndex = 27;
            this.dtpApplyDate.Value = new System.DateTime(2007, 9, 13, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(340, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "送船日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpArriveDate
            // 
            this.dtpArriveDate.CustomFormat = "yyyy-MM-dd";
            this.dtpArriveDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpArriveDate.Enabled = false;
            this.dtpArriveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArriveDate.Location = new System.Drawing.Point(430, 3);
            this.dtpArriveDate.Name = "dtpArriveDate";
            this.dtpArriveDate.Size = new System.Drawing.Size(231, 21);
            this.dtpArriveDate.TabIndex = 29;
            this.dtpArriveDate.Value = new System.DateTime(2007, 9, 13, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "申请送船港";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(340, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 30);
            this.label3.TabIndex = 46;
            this.label3.Text = "航次";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVoyage
            // 
            this.txtVoyage.CausesValidation = false;
            this.txtVoyage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVoyage.Location = new System.Drawing.Point(430, 33);
            this.txtVoyage.MaxLength = 15;
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(231, 21);
            this.txtVoyage.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "岸端审核";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLandChecker
            // 
            this.txtLandChecker.CausesValidation = false;
            this.txtLandChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLandChecker.Location = new System.Drawing.Point(103, 93);
            this.txtLandChecker.MaxLength = 15;
            this.txtLandChecker.Name = "txtLandChecker";
            this.txtLandChecker.ReadOnly = true;
            this.txtLandChecker.Size = new System.Drawing.Size(231, 21);
            this.txtLandChecker.TabIndex = 44;
            // 
            // FrmOilAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmOilAudit";
            this.Text = "润滑油申请审核";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOilAudit_FormClosing);
            this.Load += new System.EventHandler(this.FrmOilAudit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOilApplyDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx btn_NotOk;
        public CommonViewer.ButtonEx btn_Ok;
        public CommonViewer.ButtonEx buttonEx7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cobPort;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtCheckor;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtLeader;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpApplyDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpArriveDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtVoyage;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtLandChecker;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.UcDataGridView dgvOilApplyDetail;
    }
}