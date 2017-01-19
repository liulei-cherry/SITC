namespace StorageManage.Viewer
{
    partial class FrmMaterialStockCheckEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialStockCheckEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.buttonEx8 = new CommonViewer.ButtonEx();
            this.btn_NotOk = new CommonViewer.ButtonEx();
            this.btn_Ok = new CommonViewer.ButtonEx();
            this.bdNgComplete = new CommonViewer.ButtonEx();
            this.bdNgSaveItem = new CommonViewer.ButtonEx();
            this.buttonEx4 = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.btnQuestion = new CommonViewer.ButtonEx();
            this.Btn_Produce = new CommonViewer.ButtonEx();
            this.buttonEx7 = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.txtLandChecker = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.ucShipWareHouseSelect1 = new BaseInfo.Viewer.UcShipWareHouseSelect();
            this.txtCheckDate = new CommonViewer.DateTimePickerEx();
            this.dtpSpckDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSpStockckDetail = new CommonViewer.UcDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockckDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1149, 53);
            this.panel4.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx8);
            this.flowLayoutPanel1.Controls.Add(this.btn_NotOk);
            this.flowLayoutPanel1.Controls.Add(this.btn_Ok);
            this.flowLayoutPanel1.Controls.Add(this.bdNgComplete);
            this.flowLayoutPanel1.Controls.Add(this.bdNgSaveItem);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx4);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx5);
            this.flowLayoutPanel1.Controls.Add(this.btnQuestion);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Produce);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(247, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(902, 53);
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
            this.btnClose.Location = new System.Drawing.Point(850, 5);
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
            // buttonEx8
            // 
            this.buttonEx8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx8.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx8.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx8.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx8.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx8.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx8.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx8.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx8.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx8.FadingSpeed = 20;
            this.buttonEx8.FlatAppearance.BorderSize = 0;
            this.buttonEx8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx8.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx8.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx8.Image")));
            this.buttonEx8.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx8.ImageOffset = 3;
            this.buttonEx8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx8.IsPressed = false;
            this.buttonEx8.KeepPress = false;
            this.buttonEx8.Location = new System.Drawing.Point(806, 5);
            this.buttonEx8.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx8.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx8.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx8.Name = "buttonEx8";
            this.buttonEx8.Radius = 6;
            this.buttonEx8.ShowBase = true;
            this.buttonEx8.Size = new System.Drawing.Size(44, 42);
            this.buttonEx8.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx8.SplitDistance = 0;
            this.buttonEx8.TabIndex = 21;
            this.buttonEx8.Title = "";
            this.buttonEx8.UseVisualStyleBackColor = true;
            this.buttonEx8.Click += new System.EventHandler(this.bdNgPrintItem_Click);
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
            this.btn_NotOk.Location = new System.Drawing.Point(712, 5);
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
            this.btn_Ok.Location = new System.Drawing.Point(630, 5);
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
            this.bdNgComplete.Location = new System.Drawing.Point(529, 5);
            this.bdNgComplete.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgComplete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgComplete.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgComplete.Name = "bdNgComplete";
            this.bdNgComplete.Radius = 6;
            this.bdNgComplete.ShowBase = true;
            this.bdNgComplete.Size = new System.Drawing.Size(101, 42);
            this.bdNgComplete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgComplete.SplitDistance = 0;
            this.bdNgComplete.TabIndex = 24;
            this.bdNgComplete.Text = "提交审核";
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
            this.bdNgSaveItem.Location = new System.Drawing.Point(430, 5);
            this.bdNgSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgSaveItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgSaveItem.Name = "bdNgSaveItem";
            this.bdNgSaveItem.Radius = 6;
            this.bdNgSaveItem.ShowBase = true;
            this.bdNgSaveItem.Size = new System.Drawing.Size(99, 42);
            this.bdNgSaveItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgSaveItem.SplitDistance = 0;
            this.bdNgSaveItem.TabIndex = 24;
            this.bdNgSaveItem.Text = "保存草稿";
            this.bdNgSaveItem.Title = "";
            this.bdNgSaveItem.UseVisualStyleBackColor = true;
            this.bdNgSaveItem.Click += new System.EventHandler(this.bdNgSaveItem_Click);
            // 
            // buttonEx4
            // 
            this.buttonEx4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx4.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx4.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx4.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx4.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx4.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx4.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx4.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx4.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx4.FadingSpeed = 20;
            this.buttonEx4.FlatAppearance.BorderSize = 0;
            this.buttonEx4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx4.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx4.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx4.Image")));
            this.buttonEx4.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx4.ImageOffset = 2;
            this.buttonEx4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx4.IsPressed = false;
            this.buttonEx4.KeepPress = false;
            this.buttonEx4.Location = new System.Drawing.Point(386, 5);
            this.buttonEx4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx4.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx4.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx4.Name = "buttonEx4";
            this.buttonEx4.Radius = 6;
            this.buttonEx4.ShowBase = true;
            this.buttonEx4.Size = new System.Drawing.Size(44, 42);
            this.buttonEx4.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx4.SplitDistance = 0;
            this.buttonEx4.TabIndex = 24;
            this.buttonEx4.Title = "";
            this.buttonEx4.UseVisualStyleBackColor = true;
            this.buttonEx4.Click += new System.EventHandler(this.打开OToolStripButton_Click);
            // 
            // buttonEx5
            // 
            this.buttonEx5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx5.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx5.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx5.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx5.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx5.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx5.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx5.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx5.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx5.FadingSpeed = 20;
            this.buttonEx5.FlatAppearance.BorderSize = 0;
            this.buttonEx5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 2;
            this.buttonEx5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(342, 5);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = true;
            this.buttonEx5.Size = new System.Drawing.Size(44, 42);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 24;
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            this.buttonEx5.Click += new System.EventHandler(this.新建NToolStripButton_Click);
            // 
            // btnQuestion
            // 
            this.btnQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestion.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnQuestion.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestion.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnQuestion.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnQuestion.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnQuestion.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnQuestion.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuestion.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnQuestion.FadingSpeed = 20;
            this.btnQuestion.FlatAppearance.BorderSize = 0;
            this.btnQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuestion.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnQuestion.Image = ((System.Drawing.Image)(resources.GetObject("btnQuestion.Image")));
            this.btnQuestion.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnQuestion.ImageOffset = 6;
            this.btnQuestion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuestion.IsPressed = false;
            this.btnQuestion.KeepPress = false;
            this.btnQuestion.Location = new System.Drawing.Point(229, 5);
            this.btnQuestion.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuestion.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnQuestion.MenuPos = new System.Drawing.Point(0, 0);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Radius = 6;
            this.btnQuestion.ShowBase = true;
            this.btnQuestion.Size = new System.Drawing.Size(113, 42);
            this.btnQuestion.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnQuestion.SplitDistance = 0;
            this.btnQuestion.TabIndex = 25;
            this.btnQuestion.Text = "只看不同项";
            this.btnQuestion.Title = "";
            this.btnQuestion.UseVisualStyleBackColor = true;
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // Btn_Produce
            // 
            this.Btn_Produce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Produce.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.Btn_Produce.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Produce.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.Btn_Produce.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.Btn_Produce.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.Btn_Produce.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.Btn_Produce.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Produce.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Btn_Produce.FadingSpeed = 20;
            this.Btn_Produce.FlatAppearance.BorderSize = 0;
            this.Btn_Produce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Produce.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Btn_Produce.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.Btn_Produce.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Produce.Image")));
            this.Btn_Produce.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.Btn_Produce.ImageOffset = 3;
            this.Btn_Produce.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_Produce.IsPressed = false;
            this.Btn_Produce.KeepPress = false;
            this.Btn_Produce.Location = new System.Drawing.Point(99, 5);
            this.Btn_Produce.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Produce.MaxImageSize = new System.Drawing.Point(0, 0);
            this.Btn_Produce.MenuPos = new System.Drawing.Point(0, 0);
            this.Btn_Produce.Name = "Btn_Produce";
            this.Btn_Produce.Radius = 6;
            this.Btn_Produce.ShowBase = true;
            this.Btn_Produce.Size = new System.Drawing.Size(130, 42);
            this.Btn_Produce.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.Btn_Produce.SplitDistance = 0;
            this.Btn_Produce.TabIndex = 24;
            this.Btn_Produce.Text = "生成盘存明细";
            this.Btn_Produce.Title = "";
            this.Btn_Produce.UseVisualStyleBackColor = true;
            this.Btn_Produce.Click += new System.EventHandler(this.produceButton_Click);
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
            this.buttonEx7.Location = new System.Drawing.Point(2, 6);
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
            this.buttonEx7.Text = "库存盘点编辑";
            this.buttonEx7.Title = "";
            this.buttonEx7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1149, 521);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1143, 515);
            this.panel3.TabIndex = 42;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1MinSize = 154;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1143, 515);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1143, 232);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘点单信息";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1123, 198);
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
            this.tableLayoutPanel2.Controls.Add(this.txtLandChecker, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ucShipWareHouseSelect1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCheckDate, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtpSpckDate, 1, 1);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1123, 198);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // txtState
            // 
            this.txtState.CausesValidation = false;
            this.txtState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtState.Location = new System.Drawing.Point(103, 93);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(455, 21);
            this.txtState.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 68);
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
            this.txtRemark.Size = new System.Drawing.Size(1017, 62);
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
            this.txtShipChecker.Size = new System.Drawing.Size(455, 21);
            this.txtShipChecker.TabIndex = 33;
            // 
            // txtStockChecker
            // 
            this.txtStockChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockChecker.Location = new System.Drawing.Point(664, 33);
            this.txtStockChecker.MaxLength = 50;
            this.txtStockChecker.Name = "txtStockChecker";
            this.txtStockChecker.ReadOnly = true;
            this.txtStockChecker.Size = new System.Drawing.Size(456, 21);
            this.txtStockChecker.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(564, 30);
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
            this.label1.Location = new System.Drawing.Point(564, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 42;
            this.label1.Text = "岸端确认人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLandChecker
            // 
            this.txtLandChecker.CausesValidation = false;
            this.txtLandChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLandChecker.Location = new System.Drawing.Point(664, 63);
            this.txtLandChecker.MaxLength = 50;
            this.txtLandChecker.Name = "txtLandChecker";
            this.txtLandChecker.ReadOnly = true;
            this.txtLandChecker.Size = new System.Drawing.Size(456, 21);
            this.txtLandChecker.TabIndex = 55;
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
            this.label5.Location = new System.Drawing.Point(564, 90);
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
            this.label10.Location = new System.Drawing.Point(564, 0);
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
            this.txtCode.Size = new System.Drawing.Size(455, 21);
            this.txtCode.TabIndex = 46;
            // 
            // ucShipWareHouseSelect1
            // 
            this.ucShipWareHouseSelect1.CanEdit = false;
            this.ucShipWareHouseSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipWareHouseSelect1.DropDownWidth = 456;
            this.ucShipWareHouseSelect1.Location = new System.Drawing.Point(664, 3);
            this.ucShipWareHouseSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipWareHouseSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipWareHouseSelect1.Name = "ucShipWareHouseSelect1";
            this.ucShipWareHouseSelect1.NullValueShow = "未选择";
            this.ucShipWareHouseSelect1.ShowButton = false;
            this.ucShipWareHouseSelect1.Size = new System.Drawing.Size(456, 20);
            this.ucShipWareHouseSelect1.TabIndex = 57;
            this.ucShipWareHouseSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipWareHouseSelect1_TheSelectedChanged);
            // 
            // txtCheckDate
            // 
            this.txtCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckDate.Location = new System.Drawing.Point(664, 93);
            this.txtCheckDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.txtCheckDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtCheckDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtCheckDate.Name = "txtCheckDate";
            this.txtCheckDate.ReadOnly = true;
            this.txtCheckDate.Size = new System.Drawing.Size(456, 27);
            this.txtCheckDate.TabIndex = 59;
            this.txtCheckDate.Value = new System.DateTime(((long)(0)));
            // 
            // dtpSpckDate
            // 
            this.dtpSpckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpSpckDate.Location = new System.Drawing.Point(103, 33);
            this.dtpSpckDate.Name = "dtpSpckDate";
            this.dtpSpckDate.Size = new System.Drawing.Size(455, 21);
            this.dtpSpckDate.TabIndex = 60;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1143, 279);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "盘点明细信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSpStockckDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 259);
            this.panel1.TabIndex = 1;
            // 
            // dgvSpStockckDetail
            // 
            this.dgvSpStockckDetail.AllowUserToAddRows = false;
            this.dgvSpStockckDetail.AllowUserToDeleteRows = false;
            this.dgvSpStockckDetail.AllowUserToOrderColumns = true;
            this.dgvSpStockckDetail.AutoFit = true;
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
            this.dgvSpStockckDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpStockckDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSpStockckDetail.RowHeadersWidth = 25;
            this.dgvSpStockckDetail.RowTemplate.Height = 23;
            this.dgvSpStockckDetail.ShowRowNumber = true;
            this.dgvSpStockckDetail.Size = new System.Drawing.Size(1137, 259);
            this.dgvSpStockckDetail.TabIndex = 41;
            this.dgvSpStockckDetail.Title = "";
            this.dgvSpStockckDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSpStockckDetail_CellValidating);
            // 
            // FrmMaterialStockCheckEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 574);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Name = "FrmMaterialStockCheckEdit";
            this.Text = "库存盘点编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialStockCheckEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialStockckEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpStockckDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx buttonEx4;
        public CommonViewer.ButtonEx buttonEx5;
        public CommonViewer.ButtonEx bdNgComplete;
        public CommonViewer.ButtonEx bdNgSaveItem;
        public CommonViewer.ButtonEx Btn_Produce;
        public CommonViewer.ButtonEx btn_Ok;
        public CommonViewer.ButtonEx btn_NotOk;
        public CommonViewer.ButtonEx buttonEx7;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx buttonEx8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.UcDataGridView dgvSpStockckDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CommonViewer.TextBoxEx txtState;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtShipChecker;
        private CommonViewer.TextBoxEx txtStockChecker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtLandChecker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtCode;
        private BaseInfo.Viewer.UcShipWareHouseSelect ucShipWareHouseSelect1;
        private CommonViewer.DateTimePickerEx txtCheckDate;
        public CommonViewer.ButtonEx btnQuestion;
        private System.Windows.Forms.DateTimePicker dtpSpckDate;
    }
}