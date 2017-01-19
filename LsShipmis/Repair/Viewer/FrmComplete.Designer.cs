namespace Repair.Viewer
{
    partial class FrmComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComplete));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckbOnlySelf = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.btnCompleteAll = new CommonViewer.ButtonEx();
            this.btnComplete = new CommonViewer.ButtonEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDelegate = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddProject = new CommonViewer.ButtonEx();
            this.btnDisannul = new CommonViewer.ButtonEx();
            this.btnProjectOff = new CommonViewer.ButtonEx();
            this.btnEditRemark = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtREPAIRCODE = new CommonViewer.TextBoxEx();
            this.txtMANUFACTURER_NAME = new CommonViewer.TextBoxEx();
            this.txtSHIPAFFIRMANT = new CommonViewer.TextBoxEx();
            this.txtARRANGEDPERSON = new CommonViewer.TextBoxEx();
            this.txtSHIP_NAME = new CommonViewer.TextBoxEx();
            this.txtREPAIRPORT = new CommonViewer.TextBoxEx();
            this.txtREPAIRDATE = new CommonViewer.TextBoxEx();
            this.txtCOMPLETEDATE = new CommonViewer.TextBoxEx();
            this.txtCOMPAFFIRMANT = new CommonViewer.TextBoxEx();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelegate)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 110;
            this.ucShipSelect1.Location = new System.Drawing.Point(189, 22);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(165, 20);
            this.ucShipSelect1.TabIndex = 27;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.ckbOnlySelf);
            this.panel4.Controls.Add(this.flowLayoutPanel3);
            this.panel4.Controls.Add(this.ucShipSelect1);
            this.panel4.Controls.Add(this.buttonEx2);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(991, 55);
            this.panel4.TabIndex = 11;
            // 
            // ckbOnlySelf
            // 
            this.ckbOnlySelf.AutoSize = true;
            this.ckbOnlySelf.Location = new System.Drawing.Point(376, 24);
            this.ckbOnlySelf.Name = "ckbOnlySelf";
            this.ckbOnlySelf.Size = new System.Drawing.Size(72, 16);
            this.ckbOnlySelf.TabIndex = 28;
            this.ckbOnlySelf.Text = "仅我安排";
            this.ckbOnlySelf.UseVisualStyleBackColor = true;
            this.ckbOnlySelf.CheckedChanged += new System.EventHandler(this.ckbOnlySelf_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.btnClose);
            this.flowLayoutPanel3.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel3.Controls.Add(this.bdNgEditItem);
            this.flowLayoutPanel3.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(483, 6);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(502, 43);
            this.flowLayoutPanel3.TabIndex = 42;
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
            this.btnClose.ImageOffset = 5;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(424, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 5;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(78, 43);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
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
            this.bdNgDeleteItem.Location = new System.Drawing.Point(380, 0);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(44, 43);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 40;
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
            this.bdNgEditItem.Location = new System.Drawing.Point(336, 0);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(44, 43);
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
            this.bdNgAddNewItem.Location = new System.Drawing.Point(214, 0);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(122, 43);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 41;
            this.bdNgAddNewItem.Text = "添加完工单";
            this.bdNgAddNewItem.Title = "";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
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
            this.buttonEx2.Size = new System.Drawing.Size(477, 43);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "完工单管理";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // btnCompleteAll
            // 
            this.btnCompleteAll.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCompleteAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCompleteAll.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCompleteAll.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCompleteAll.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCompleteAll.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCompleteAll.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCompleteAll.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCompleteAll.FadingSpeed = 20;
            this.btnCompleteAll.FlatAppearance.BorderSize = 0;
            this.btnCompleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCompleteAll.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCompleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteAll.Image")));
            this.btnCompleteAll.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCompleteAll.ImageOffset = 3;
            this.btnCompleteAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCompleteAll.IsPressed = false;
            this.btnCompleteAll.KeepPress = false;
            this.btnCompleteAll.Location = new System.Drawing.Point(102, 0);
            this.btnCompleteAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnCompleteAll.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCompleteAll.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCompleteAll.Name = "btnCompleteAll";
            this.btnCompleteAll.Radius = 6;
            this.btnCompleteAll.ShowBase = true;
            this.btnCompleteAll.Size = new System.Drawing.Size(112, 23);
            this.btnCompleteAll.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCompleteAll.SplitDistance = 0;
            this.btnCompleteAll.TabIndex = 29;
            this.btnCompleteAll.Text = "全部完工";
            this.btnCompleteAll.Title = "";
            this.btnCompleteAll.UseVisualStyleBackColor = true;
            this.btnCompleteAll.Click += new System.EventHandler(this.btnCompleteAll_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnComplete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnComplete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnComplete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnComplete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnComplete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnComplete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnComplete.FadingSpeed = 20;
            this.btnComplete.FlatAppearance.BorderSize = 0;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComplete.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnComplete.Image = ((System.Drawing.Image)(resources.GetObject("btnComplete.Image")));
            this.btnComplete.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnComplete.ImageOffset = 3;
            this.btnComplete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnComplete.IsPressed = false;
            this.btnComplete.KeepPress = false;
            this.btnComplete.Location = new System.Drawing.Point(0, 0);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(0);
            this.btnComplete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnComplete.MenuPos = new System.Drawing.Point(0, 0);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Radius = 6;
            this.btnComplete.ShowBase = true;
            this.btnComplete.Size = new System.Drawing.Size(102, 24);
            this.btnComplete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnComplete.SplitDistance = 0;
            this.btnComplete.TabIndex = 29;
            this.btnComplete.Text = "单项完工";
            this.btnComplete.Title = "";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "修理编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(419, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "修理港口";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(211, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "船舶名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 34);
            this.label4.TabIndex = 0;
            this.label4.Text = "服务商";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 35);
            this.label8.TabIndex = 0;
            this.label8.Text = "船端确认人";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 573);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(985, 512);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDelegate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(341, 512);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "委托单列表";
            // 
            // dgvDelegate
            // 
            this.dgvDelegate.AllowUserToAddRows = false;
            this.dgvDelegate.AllowUserToDeleteRows = false;
            this.dgvDelegate.AllowUserToOrderColumns = true;
            this.dgvDelegate.AutoFit = true;
            this.dgvDelegate.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDelegate.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelegate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDelegate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDelegate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDelegate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDelegate.EnableHeadersVisualStyles = false;
            this.dgvDelegate.ExportColorToExcel = false;
            this.dgvDelegate.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDelegate.Footer")));
            this.dgvDelegate.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvDelegate.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDelegate.Header")));
            this.dgvDelegate.LoadedFinish = false;
            this.dgvDelegate.Location = new System.Drawing.Point(8, 17);
            this.dgvDelegate.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDelegate.MergeColumnNames")));
            this.dgvDelegate.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDelegate.MergeRowColumn")));
            this.dgvDelegate.Name = "dgvDelegate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelegate.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDelegate.RowHeadersWidth = 25;
            this.dgvDelegate.RowTemplate.Height = 23;
            this.dgvDelegate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelegate.ShowRowNumber = false;
            this.dgvDelegate.Size = new System.Drawing.Size(325, 487);
            this.dgvDelegate.TabIndex = 11;
            this.dgvDelegate.Title = "";
            this.dgvDelegate.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dtbDelegate_SelectedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 325);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "委托单详细";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvDetail, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(634, 305);
            this.tableLayoutPanel3.TabIndex = 12;
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
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.ExportColorToExcel = false;
            this.dgvDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Footer")));
            this.dgvDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Header")));
            this.dgvDetail.LoadedFinish = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 33);
            this.dgvDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeColumnNames")));
            this.dgvDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeRowColumn")));
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.RowHeadersWidth = 25;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.ShowRowNumber = false;
            this.dgvDetail.Size = new System.Drawing.Size(628, 269);
            this.dgvDetail.TabIndex = 11;
            this.dgvDetail.Title = "";
            this.dgvDetail.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dgvDetail_SelectedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnComplete);
            this.flowLayoutPanel2.Controls.Add(this.btnCompleteAll);
            this.flowLayoutPanel2.Controls.Add(this.btnAddProject);
            this.flowLayoutPanel2.Controls.Add(this.btnDisannul);
            this.flowLayoutPanel2.Controls.Add(this.btnProjectOff);
            this.flowLayoutPanel2.Controls.Add(this.btnEditRemark);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(628, 24);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAddProject.BackColor = System.Drawing.Color.Transparent;
            this.btnAddProject.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAddProject.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAddProject.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddProject.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddProject.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddProject.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddProject.FadingSpeed = 20;
            this.btnAddProject.FlatAppearance.BorderSize = 0;
            this.btnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddProject.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAddProject.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProject.Image")));
            this.btnAddProject.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAddProject.ImageOffset = 3;
            this.btnAddProject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddProject.IsPressed = false;
            this.btnAddProject.KeepPress = false;
            this.btnAddProject.Location = new System.Drawing.Point(214, 0);
            this.btnAddProject.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddProject.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddProject.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Radius = 6;
            this.btnAddProject.ShowBase = true;
            this.btnAddProject.Size = new System.Drawing.Size(102, 24);
            this.btnAddProject.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAddProject.SplitDistance = 0;
            this.btnAddProject.TabIndex = 29;
            this.btnAddProject.Text = "添加新项";
            this.btnAddProject.Title = "";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnDisannul
            // 
            this.btnDisannul.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDisannul.BackColor = System.Drawing.Color.Transparent;
            this.btnDisannul.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDisannul.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDisannul.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDisannul.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDisannul.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDisannul.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDisannul.FadingSpeed = 20;
            this.btnDisannul.FlatAppearance.BorderSize = 0;
            this.btnDisannul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisannul.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisannul.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDisannul.Image = ((System.Drawing.Image)(resources.GetObject("btnDisannul.Image")));
            this.btnDisannul.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDisannul.ImageOffset = 3;
            this.btnDisannul.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDisannul.IsPressed = false;
            this.btnDisannul.KeepPress = false;
            this.btnDisannul.Location = new System.Drawing.Point(316, 0);
            this.btnDisannul.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisannul.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDisannul.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDisannul.Name = "btnDisannul";
            this.btnDisannul.Radius = 6;
            this.btnDisannul.ShowBase = true;
            this.btnDisannul.Size = new System.Drawing.Size(102, 24);
            this.btnDisannul.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDisannul.SplitDistance = 0;
            this.btnDisannul.TabIndex = 29;
            this.btnDisannul.Text = "以后完成";
            this.btnDisannul.Title = "";
            this.btnDisannul.UseVisualStyleBackColor = true;
            this.btnDisannul.Click += new System.EventHandler(this.btnDisannul_Click);
            // 
            // btnProjectOff
            // 
            this.btnProjectOff.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnProjectOff.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectOff.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnProjectOff.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnProjectOff.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnProjectOff.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnProjectOff.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnProjectOff.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnProjectOff.FadingSpeed = 20;
            this.btnProjectOff.FlatAppearance.BorderSize = 0;
            this.btnProjectOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectOff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProjectOff.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnProjectOff.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectOff.Image")));
            this.btnProjectOff.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnProjectOff.ImageOffset = 5;
            this.btnProjectOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProjectOff.IsPressed = false;
            this.btnProjectOff.KeepPress = false;
            this.btnProjectOff.Location = new System.Drawing.Point(418, 0);
            this.btnProjectOff.Margin = new System.Windows.Forms.Padding(0);
            this.btnProjectOff.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnProjectOff.MenuPos = new System.Drawing.Point(0, 0);
            this.btnProjectOff.Name = "btnProjectOff";
            this.btnProjectOff.Radius = 6;
            this.btnProjectOff.ShowBase = true;
            this.btnProjectOff.Size = new System.Drawing.Size(102, 24);
            this.btnProjectOff.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnProjectOff.SplitDistance = 0;
            this.btnProjectOff.TabIndex = 29;
            this.btnProjectOff.Text = "移除项目";
            this.btnProjectOff.Title = "";
            this.btnProjectOff.UseVisualStyleBackColor = true;
            this.btnProjectOff.Click += new System.EventHandler(this.btnProjectOff_Click);
            // 
            // btnEditRemark
            // 
            this.btnEditRemark.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnEditRemark.BackColor = System.Drawing.Color.Transparent;
            this.btnEditRemark.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnEditRemark.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnEditRemark.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnEditRemark.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnEditRemark.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditRemark.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEditRemark.FadingSpeed = 20;
            this.btnEditRemark.FlatAppearance.BorderSize = 0;
            this.btnEditRemark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRemark.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditRemark.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnEditRemark.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRemark.Image")));
            this.btnEditRemark.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnEditRemark.ImageOffset = 3;
            this.btnEditRemark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditRemark.IsPressed = false;
            this.btnEditRemark.KeepPress = false;
            this.btnEditRemark.Location = new System.Drawing.Point(520, 0);
            this.btnEditRemark.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditRemark.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnEditRemark.MenuPos = new System.Drawing.Point(0, 0);
            this.btnEditRemark.Name = "btnEditRemark";
            this.btnEditRemark.Radius = 6;
            this.btnEditRemark.ShowBase = true;
            this.btnEditRemark.Size = new System.Drawing.Size(102, 24);
            this.btnEditRemark.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnEditRemark.SplitDistance = 0;
            this.btnEditRemark.TabIndex = 30;
            this.btnEditRemark.Text = "修改备注";
            this.btnEditRemark.Title = "";
            this.btnEditRemark.UseVisualStyleBackColor = true;
            this.btnEditRemark.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 187);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "委托信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtREPAIRCODE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtMANUFACTURER_NAME, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIPAFFIRMANT, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtARRANGEDPERSON, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_NAME, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtREPAIRPORT, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtREPAIRDATE, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCOMPLETEDATE, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCOMPAFFIRMANT, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtREMARK, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 167);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(211, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 35);
            this.label9.TabIndex = 0;
            this.label9.Text = "岸端确认人";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(419, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 35);
            this.label10.TabIndex = 0;
            this.label10.Text = "修理完成日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(419, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "修理开始日期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(211, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 34);
            this.label7.TabIndex = 0;
            this.label7.Text = "安排人";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREPAIRCODE
            // 
            this.txtREPAIRCODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREPAIRCODE.Location = new System.Drawing.Point(103, 3);
            this.txtREPAIRCODE.Name = "txtREPAIRCODE";
            this.txtREPAIRCODE.ReadOnly = true;
            this.txtREPAIRCODE.Size = new System.Drawing.Size(102, 21);
            this.txtREPAIRCODE.TabIndex = 1;
            // 
            // txtMANUFACTURER_NAME
            // 
            this.txtMANUFACTURER_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMANUFACTURER_NAME.Location = new System.Drawing.Point(103, 34);
            this.txtMANUFACTURER_NAME.Name = "txtMANUFACTURER_NAME";
            this.txtMANUFACTURER_NAME.ReadOnly = true;
            this.txtMANUFACTURER_NAME.Size = new System.Drawing.Size(102, 21);
            this.txtMANUFACTURER_NAME.TabIndex = 1;
            // 
            // txtSHIPAFFIRMANT
            // 
            this.txtSHIPAFFIRMANT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIPAFFIRMANT.Location = new System.Drawing.Point(103, 68);
            this.txtSHIPAFFIRMANT.Name = "txtSHIPAFFIRMANT";
            this.txtSHIPAFFIRMANT.ReadOnly = true;
            this.txtSHIPAFFIRMANT.Size = new System.Drawing.Size(102, 21);
            this.txtSHIPAFFIRMANT.TabIndex = 1;
            // 
            // txtARRANGEDPERSON
            // 
            this.txtARRANGEDPERSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtARRANGEDPERSON.Location = new System.Drawing.Point(311, 34);
            this.txtARRANGEDPERSON.Name = "txtARRANGEDPERSON";
            this.txtARRANGEDPERSON.ReadOnly = true;
            this.txtARRANGEDPERSON.Size = new System.Drawing.Size(102, 21);
            this.txtARRANGEDPERSON.TabIndex = 1;
            // 
            // txtSHIP_NAME
            // 
            this.txtSHIP_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_NAME.Location = new System.Drawing.Point(311, 3);
            this.txtSHIP_NAME.Name = "txtSHIP_NAME";
            this.txtSHIP_NAME.ReadOnly = true;
            this.txtSHIP_NAME.Size = new System.Drawing.Size(102, 21);
            this.txtSHIP_NAME.TabIndex = 1;
            // 
            // txtREPAIRPORT
            // 
            this.txtREPAIRPORT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREPAIRPORT.Location = new System.Drawing.Point(529, 3);
            this.txtREPAIRPORT.Name = "txtREPAIRPORT";
            this.txtREPAIRPORT.ReadOnly = true;
            this.txtREPAIRPORT.Size = new System.Drawing.Size(102, 21);
            this.txtREPAIRPORT.TabIndex = 1;
            // 
            // txtREPAIRDATE
            // 
            this.txtREPAIRDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREPAIRDATE.Location = new System.Drawing.Point(529, 34);
            this.txtREPAIRDATE.Name = "txtREPAIRDATE";
            this.txtREPAIRDATE.ReadOnly = true;
            this.txtREPAIRDATE.Size = new System.Drawing.Size(102, 21);
            this.txtREPAIRDATE.TabIndex = 1;
            // 
            // txtCOMPLETEDATE
            // 
            this.txtCOMPLETEDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCOMPLETEDATE.Location = new System.Drawing.Point(529, 68);
            this.txtCOMPLETEDATE.Name = "txtCOMPLETEDATE";
            this.txtCOMPLETEDATE.ReadOnly = true;
            this.txtCOMPLETEDATE.Size = new System.Drawing.Size(102, 21);
            this.txtCOMPLETEDATE.TabIndex = 1;
            // 
            // txtCOMPAFFIRMANT
            // 
            this.txtCOMPAFFIRMANT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCOMPAFFIRMANT.Location = new System.Drawing.Point(311, 68);
            this.txtCOMPAFFIRMANT.Name = "txtCOMPAFFIRMANT";
            this.txtCOMPAFFIRMANT.ReadOnly = true;
            this.txtCOMPAFFIRMANT.Size = new System.Drawing.Size(102, 21);
            this.txtCOMPAFFIRMANT.TabIndex = 1;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtREMARK, 5);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Location = new System.Drawing.Point(103, 103);
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtREMARK, 2);
            this.txtREMARK.Size = new System.Drawing.Size(528, 61);
            this.txtREMARK.TabIndex = 1;
            // 
            // FrmComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(991, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmComplete";
            this.Text = "完工单管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmComplete_FormClosing);
            this.Load += new System.EventHandler(this.FrmComplete_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelegate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx bdNgEditItem;
        public CommonViewer.ButtonEx btnComplete;
        public CommonViewer.ButtonEx buttonEx2;
        protected CommonViewer.ButtonEx btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvDelegate;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtREPAIRCODE;
        private CommonViewer.TextBoxEx txtMANUFACTURER_NAME;
        private CommonViewer.TextBoxEx txtSHIPAFFIRMANT;
        private CommonViewer.TextBoxEx txtARRANGEDPERSON;
        private CommonViewer.TextBoxEx txtSHIP_NAME;
        private CommonViewer.TextBoxEx txtREPAIRPORT;
        private CommonViewer.TextBoxEx txtREPAIRDATE;
        private CommonViewer.TextBoxEx txtCOMPLETEDATE;
        private CommonViewer.TextBoxEx txtCOMPAFFIRMANT;
        private CommonViewer.TextBoxEx txtREMARK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public CommonViewer.ButtonEx btnDisannul;
        public CommonViewer.ButtonEx btnCompleteAll;
        public CommonViewer.ButtonEx btnProjectOff;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        public CommonViewer.ButtonEx btnAddProject;
        public CommonViewer.ButtonEx btnEditRemark;
        private System.Windows.Forms.CheckBox ckbOnlySelf;
    }
}