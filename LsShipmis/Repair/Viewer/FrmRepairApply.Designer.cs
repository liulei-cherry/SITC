namespace Repair.Viewer
{
    partial class FrmRepairApply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepairApply));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApply = new CommonViewer.UcDataGridView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnPrint = new CommonViewer.ButtonEx();
            this.btnDelegate = new CommonViewer.ButtonEx();
            this.btnLandCheck = new CommonViewer.ButtonEx();
            this.btnShipCheck = new CommonViewer.ButtonEx();
            this.btndepartmentCheck = new CommonViewer.ButtonEx();
            this.btnAllSelect = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.btnFromMaintain = new CommonViewer.ButtonEx();
            this.btnFromHistory = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labShip = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChkState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbType = new System.Windows.Forms.ComboBox();
            this.cbPost = new System.Windows.Forms.CheckBox();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 625);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApply);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(1108, 510);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请信息列表";
            // 
            // dgvApply
            // 
            this.dgvApply.AllowUserToAddRows = false;
            this.dgvApply.AllowUserToDeleteRows = false;
            this.dgvApply.AllowUserToOrderColumns = true;
            this.dgvApply.AutoFit = true;
            this.dgvApply.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvApply.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApply.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApply.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApply.EnableHeadersVisualStyles = false;
            this.dgvApply.ExportColorToExcel = false;
            this.dgvApply.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.Footer")));
            this.dgvApply.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvApply.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.Header")));
            this.dgvApply.LoadedFinish = false;
            this.dgvApply.Location = new System.Drawing.Point(8, 17);
            this.dgvApply.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.MergeColumnNames")));
            this.dgvApply.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.MergeRowColumn")));
            this.dgvApply.Name = "dgvApply";
            this.dgvApply.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApply.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApply.RowHeadersWidth = 25;
            this.dgvApply.RowTemplate.Height = 23;
            this.dgvApply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApply.ShowRowNumber = true;
            this.dgvApply.Size = new System.Drawing.Size(1092, 485);
            this.dgvApply.TabIndex = 11;
            this.dgvApply.Title = "";
            this.dgvApply.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApply_CellMouseDoubleClick);
            this.dgvApply.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApply_RowEnter);
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
            this.panel4.Size = new System.Drawing.Size(1114, 51);
            this.panel4.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnPrint);
            this.flowLayoutPanel2.Controls.Add(this.btnDelegate);
            this.flowLayoutPanel2.Controls.Add(this.btnLandCheck);
            this.flowLayoutPanel2.Controls.Add(this.btnShipCheck);
            this.flowLayoutPanel2.Controls.Add(this.btndepartmentCheck);
            this.flowLayoutPanel2.Controls.Add(this.btnAllSelect);
            this.flowLayoutPanel2.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel2.Controls.Add(this.bdNgEditItem);
            this.flowLayoutPanel2.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel2.Controls.Add(this.btnFromMaintain);
            this.flowLayoutPanel2.Controls.Add(this.btnFromHistory);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(140, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(968, 39);
            this.flowLayoutPanel2.TabIndex = 42;
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
            this.btnClose.Location = new System.Drawing.Point(926, 0);
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
            // btnPrint
            // 
            this.btnPrint.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPrint.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnPrint.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPrint.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPrint.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrint.FadingSpeed = 20;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPrint.ImageOffset = 3;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.IsPressed = false;
            this.btnPrint.KeepPress = false;
            this.btnPrint.Location = new System.Drawing.Point(882, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 6;
            this.btnPrint.ShowBase = true;
            this.btnPrint.Size = new System.Drawing.Size(44, 39);
            this.btnPrint.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.bdNgPrintItem_Click);
            // 
            // btnDelegate
            // 
            this.btnDelegate.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDelegate.BackColor = System.Drawing.Color.Transparent;
            this.btnDelegate.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDelegate.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDelegate.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDelegate.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDelegate.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelegate.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelegate.Enabled = false;
            this.btnDelegate.FadingSpeed = 20;
            this.btnDelegate.FlatAppearance.BorderSize = 0;
            this.btnDelegate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelegate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelegate.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDelegate.Image = ((System.Drawing.Image)(resources.GetObject("btnDelegate.Image")));
            this.btnDelegate.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDelegate.ImageOffset = 3;
            this.btnDelegate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelegate.IsPressed = false;
            this.btnDelegate.KeepPress = false;
            this.btnDelegate.Location = new System.Drawing.Point(787, 0);
            this.btnDelegate.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelegate.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDelegate.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDelegate.Name = "btnDelegate";
            this.btnDelegate.Radius = 6;
            this.btnDelegate.ShowBase = true;
            this.btnDelegate.Size = new System.Drawing.Size(95, 39);
            this.btnDelegate.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDelegate.SplitDistance = 0;
            this.btnDelegate.TabIndex = 28;
            this.btnDelegate.Text = "委托";
            this.btnDelegate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelegate.Title = "";
            this.btnDelegate.UseVisualStyleBackColor = true;
            this.btnDelegate.Visible = false;
            this.btnDelegate.Click += new System.EventHandler(this.btnDelegate_Click);
            // 
            // btnLandCheck
            // 
            this.btnLandCheck.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnLandCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnLandCheck.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnLandCheck.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnLandCheck.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnLandCheck.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnLandCheck.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLandCheck.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLandCheck.Enabled = false;
            this.btnLandCheck.FadingSpeed = 20;
            this.btnLandCheck.FlatAppearance.BorderSize = 0;
            this.btnLandCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLandCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLandCheck.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnLandCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnLandCheck.Image")));
            this.btnLandCheck.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnLandCheck.ImageOffset = 3;
            this.btnLandCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLandCheck.IsPressed = false;
            this.btnLandCheck.KeepPress = false;
            this.btnLandCheck.Location = new System.Drawing.Point(692, 0);
            this.btnLandCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnLandCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnLandCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnLandCheck.Name = "btnLandCheck";
            this.btnLandCheck.Radius = 6;
            this.btnLandCheck.ShowBase = true;
            this.btnLandCheck.Size = new System.Drawing.Size(95, 39);
            this.btnLandCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnLandCheck.SplitDistance = 0;
            this.btnLandCheck.TabIndex = 29;
            this.btnLandCheck.Text = "审核";
            this.btnLandCheck.Title = "";
            this.btnLandCheck.UseVisualStyleBackColor = true;
            this.btnLandCheck.Visible = false;
            this.btnLandCheck.Click += new System.EventHandler(this.btnLandCheck_Click);
            // 
            // btnShipCheck
            // 
            this.btnShipCheck.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnShipCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnShipCheck.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnShipCheck.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnShipCheck.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnShipCheck.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnShipCheck.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnShipCheck.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnShipCheck.Enabled = false;
            this.btnShipCheck.FadingSpeed = 20;
            this.btnShipCheck.FlatAppearance.BorderSize = 0;
            this.btnShipCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShipCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShipCheck.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnShipCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnShipCheck.Image")));
            this.btnShipCheck.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnShipCheck.ImageOffset = 3;
            this.btnShipCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShipCheck.IsPressed = false;
            this.btnShipCheck.KeepPress = false;
            this.btnShipCheck.Location = new System.Drawing.Point(606, 0);
            this.btnShipCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnShipCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnShipCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnShipCheck.Name = "btnShipCheck";
            this.btnShipCheck.Radius = 6;
            this.btnShipCheck.ShowBase = true;
            this.btnShipCheck.Size = new System.Drawing.Size(86, 39);
            this.btnShipCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnShipCheck.SplitDistance = 0;
            this.btnShipCheck.TabIndex = 31;
            this.btnShipCheck.Text = "审核";
            this.btnShipCheck.Title = "船长";
            this.btnShipCheck.UseVisualStyleBackColor = true;
            this.btnShipCheck.Visible = false;
            this.btnShipCheck.Click += new System.EventHandler(this.btnShipCheck_Click);
            // 
            // btndepartmentCheck
            // 
            this.btndepartmentCheck.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btndepartmentCheck.BackColor = System.Drawing.Color.Transparent;
            this.btndepartmentCheck.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btndepartmentCheck.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btndepartmentCheck.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btndepartmentCheck.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btndepartmentCheck.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btndepartmentCheck.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btndepartmentCheck.Enabled = false;
            this.btndepartmentCheck.FadingSpeed = 20;
            this.btndepartmentCheck.FlatAppearance.BorderSize = 0;
            this.btndepartmentCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndepartmentCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btndepartmentCheck.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btndepartmentCheck.Image = ((System.Drawing.Image)(resources.GetObject("btndepartmentCheck.Image")));
            this.btndepartmentCheck.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btndepartmentCheck.ImageOffset = 3;
            this.btndepartmentCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btndepartmentCheck.IsPressed = false;
            this.btndepartmentCheck.KeepPress = false;
            this.btndepartmentCheck.Location = new System.Drawing.Point(511, 0);
            this.btndepartmentCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btndepartmentCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btndepartmentCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btndepartmentCheck.Name = "btndepartmentCheck";
            this.btndepartmentCheck.Radius = 6;
            this.btndepartmentCheck.ShowBase = true;
            this.btndepartmentCheck.Size = new System.Drawing.Size(95, 39);
            this.btndepartmentCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btndepartmentCheck.SplitDistance = 0;
            this.btndepartmentCheck.TabIndex = 30;
            this.btndepartmentCheck.Text = "审核";
            this.btndepartmentCheck.Title = "部门长";
            this.btndepartmentCheck.UseVisualStyleBackColor = true;
            this.btndepartmentCheck.Visible = false;
            this.btndepartmentCheck.Click += new System.EventHandler(this.btndepartmentCheck_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAllSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnAllSelect.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAllSelect.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAllSelect.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAllSelect.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAllSelect.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAllSelect.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAllSelect.FadingSpeed = 35;
            this.btnAllSelect.FlatAppearance.BorderSize = 0;
            this.btnAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAllSelect.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.Image")));
            this.btnAllSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllSelect.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAllSelect.ImageOffset = 7;
            this.btnAllSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAllSelect.IsPressed = false;
            this.btnAllSelect.KeepPress = false;
            this.btnAllSelect.Location = new System.Drawing.Point(390, 0);
            this.btnAllSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnAllSelect.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAllSelect.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Radius = 6;
            this.btnAllSelect.ShowBase = true;
            this.btnAllSelect.Size = new System.Drawing.Size(121, 39);
            this.btnAllSelect.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAllSelect.SplitDistance = 0;
            this.btnAllSelect.TabIndex = 39;
            this.btnAllSelect.Text = "(仅审核范围)";
            this.btnAllSelect.Title = "全部审核";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Visible = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // bdNgDeleteItem
            // 
            this.bdNgDeleteItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgDeleteItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgDeleteItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgDeleteItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgDeleteItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgDeleteItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgDeleteItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.Enabled = false;
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
            this.bdNgDeleteItem.Location = new System.Drawing.Point(346, 0);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(44, 39);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 36;
            this.bdNgDeleteItem.Title = "";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
            // 
            // bdNgEditItem
            // 
            this.bdNgEditItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgEditItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgEditItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgEditItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgEditItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgEditItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgEditItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.Enabled = false;
            this.bdNgEditItem.FadingSpeed = 20;
            this.bdNgEditItem.FlatAppearance.BorderSize = 0;
            this.bdNgEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgEditItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 5;
            this.bdNgEditItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(302, 0);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(44, 39);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 38;
            this.bdNgEditItem.Title = "";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.bdNgEditItem_Click);
            // 
            // bdNgAddNewItem
            // 
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
            this.bdNgAddNewItem.Location = new System.Drawing.Point(258, 0);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(44, 39);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 37;
            this.bdNgAddNewItem.Title = "";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // btnFromMaintain
            // 
            this.btnFromMaintain.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnFromMaintain.BackColor = System.Drawing.Color.Transparent;
            this.btnFromMaintain.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnFromMaintain.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnFromMaintain.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFromMaintain.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFromMaintain.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFromMaintain.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFromMaintain.FadingSpeed = 20;
            this.btnFromMaintain.FlatAppearance.BorderSize = 0;
            this.btnFromMaintain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromMaintain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFromMaintain.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnFromMaintain.Image = ((System.Drawing.Image)(resources.GetObject("btnFromMaintain.Image")));
            this.btnFromMaintain.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnFromMaintain.ImageOffset = 3;
            this.btnFromMaintain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFromMaintain.IsPressed = false;
            this.btnFromMaintain.KeepPress = false;
            this.btnFromMaintain.Location = new System.Drawing.Point(138, 0);
            this.btnFromMaintain.Margin = new System.Windows.Forms.Padding(0);
            this.btnFromMaintain.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnFromMaintain.MenuPos = new System.Drawing.Point(0, 0);
            this.btnFromMaintain.Name = "btnFromMaintain";
            this.btnFromMaintain.Radius = 6;
            this.btnFromMaintain.ShowBase = true;
            this.btnFromMaintain.Size = new System.Drawing.Size(120, 39);
            this.btnFromMaintain.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnFromMaintain.SplitDistance = 0;
            this.btnFromMaintain.TabIndex = 41;
            this.btnFromMaintain.Text = "从维护保养";
            this.btnFromMaintain.Title = "快速导入";
            this.btnFromMaintain.UseVisualStyleBackColor = true;
            this.btnFromMaintain.Click += new System.EventHandler(this.btnFromMaintain_Click);
            // 
            // btnFromHistory
            // 
            this.btnFromHistory.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnFromHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnFromHistory.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnFromHistory.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnFromHistory.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFromHistory.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFromHistory.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFromHistory.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFromHistory.FadingSpeed = 20;
            this.btnFromHistory.FlatAppearance.BorderSize = 0;
            this.btnFromHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFromHistory.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnFromHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnFromHistory.Image")));
            this.btnFromHistory.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnFromHistory.ImageOffset = 3;
            this.btnFromHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFromHistory.IsPressed = false;
            this.btnFromHistory.KeepPress = false;
            this.btnFromHistory.Location = new System.Drawing.Point(12, 0);
            this.btnFromHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnFromHistory.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnFromHistory.MenuPos = new System.Drawing.Point(0, 0);
            this.btnFromHistory.Name = "btnFromHistory";
            this.btnFromHistory.Radius = 6;
            this.btnFromHistory.ShowBase = true;
            this.btnFromHistory.Size = new System.Drawing.Size(126, 39);
            this.btnFromHistory.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnFromHistory.SplitDistance = 0;
            this.btnFromHistory.TabIndex = 40;
            this.btnFromHistory.Text = "从已有修理";
            this.btnFromHistory.Title = "快速导入";
            this.btnFromHistory.UseVisualStyleBackColor = true;
            this.btnFromHistory.Click += new System.EventHandler(this.btnFromHistory_Click);
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
            this.buttonEx2.Size = new System.Drawing.Size(134, 39);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "修理申请";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1108, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labShip);
            this.flowLayoutPanel1.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.ckbDepartment);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cboChkState);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.ckbType);
            this.flowLayoutPanel1.Controls.Add(this.cbPost);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1102, 32);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "部门";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbDepartment
            // 
            this.ckbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ckbDepartment.FormattingEnabled = true;
            this.ckbDepartment.Location = new System.Drawing.Point(250, 3);
            this.ckbDepartment.Name = "ckbDepartment";
            this.ckbDepartment.Size = new System.Drawing.Size(112, 20);
            this.ckbDepartment.TabIndex = 4;
            this.ckbDepartment.SelectedIndexChanged += new System.EventHandler(this.ckbDepartment_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboChkState
            // 
            this.cboChkState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChkState.FormattingEnabled = true;
            this.cboChkState.Location = new System.Drawing.Point(418, 3);
            this.cboChkState.Name = "cboChkState";
            this.cboChkState.Size = new System.Drawing.Size(119, 20);
            this.cboChkState.TabIndex = 4;
            this.cboChkState.SelectedIndexChanged += new System.EventHandler(this.cboChkState_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "项目类型";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbType
            // 
            this.ckbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ckbType.FormattingEnabled = true;
            this.ckbType.Location = new System.Drawing.Point(617, 3);
            this.ckbType.Name = "ckbType";
            this.ckbType.Size = new System.Drawing.Size(104, 20);
            this.ckbType.TabIndex = 4;
            this.ckbType.SelectedIndexChanged += new System.EventHandler(this.ckbType_SelectedIndexChanged);
            // 
            // cbPost
            // 
            this.cbPost.AutoSize = true;
            this.cbPost.Location = new System.Drawing.Point(747, 3);
            this.cbPost.Margin = new System.Windows.Forms.Padding(23, 3, 3, 3);
            this.cbPost.Name = "cbPost";
            this.cbPost.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.cbPost.Size = new System.Drawing.Size(120, 19);
            this.cbPost.TabIndex = 15;
            this.cbPost.Text = "仅看本岗位申请单";
            this.cbPost.UseVisualStyleBackColor = true;
            this.cbPost.CheckedChanged += new System.EventHandler(this.cbPost_CheckedChanged);
            // 
            // FrmRepairApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1114, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmRepairApply";
            this.Text = "修理申请";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRepairApply_FormClosing);
            this.Load += new System.EventHandler(this.FrmRepairApply_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx bdNgEditItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx btnShipCheck;
        public CommonViewer.ButtonEx btndepartmentCheck;
        public CommonViewer.ButtonEx btnLandCheck;
        public CommonViewer.ButtonEx btnPrint;
        public CommonViewer.ButtonEx buttonEx2;
        protected CommonViewer.ButtonEx btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvApply;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.Windows.Forms.Label labShip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public CommonViewer.ButtonEx btnAllSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public CommonViewer.ButtonEx btnFromHistory;
        public CommonViewer.ButtonEx btnFromMaintain;
        public CommonViewer.ButtonEx btnDelegate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.ComboBox cboChkState;
        public System.Windows.Forms.CheckBox cbPost;
        public System.Windows.Forms.ComboBox ckbDepartment;
        public System.Windows.Forms.ComboBox ckbType;
        public BaseInfo.Viewer.UcShipSelect ucShipSelect1;

    }
}