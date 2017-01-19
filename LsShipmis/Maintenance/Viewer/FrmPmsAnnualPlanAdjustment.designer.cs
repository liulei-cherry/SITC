namespace Maintenance.Viewer
{
    partial class FrmPmsAnnualPlanAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPmsAnnualPlanAdjustment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.btnTableEdit = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpQueryYear = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxREPROT_TYPE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOrigin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTarget = new System.Windows.Forms.DateTimePicker();
            this.btnAnnualCopy = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvWork = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucWorkInfo = new Maintenance.Viewer.UcWorkInfoNotEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtEx1 = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtORDERNUM_SHOW = new CommonViewer.TextBoxEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEXCEL_ORDERNUM = new CommonViewer.TextBoxEx();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bdsWorkOrder = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 592);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.bdNgDeleteItem);
            this.panel2.Controls.Add(this.btnTableEdit);
            this.panel2.Controls.Add(this.bdNgAddNewItem);
            this.panel2.Controls.Add(this.bdNgEditItem);
            this.panel2.Controls.Add(this.CloseButton);
            this.panel2.Controls.Add(this.buttonEx5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 54);
            this.panel2.TabIndex = 54;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnPrint.Location = new System.Drawing.Point(885, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 6;
            this.btnPrint.ShowBase = true;
            this.btnPrint.Size = new System.Drawing.Size(45, 44);
            this.btnPrint.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.bdNgDeleteItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgDeleteItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgDeleteItem.ImageOffset = 7;
            this.bdNgDeleteItem.IsPressed = false;
            this.bdNgDeleteItem.KeepPress = false;
            this.bdNgDeleteItem.Location = new System.Drawing.Point(768, 5);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(117, 44);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 37;
            this.bdNgDeleteItem.Text = "   停止";
            this.bdNgDeleteItem.Title = "工作信息";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
            // 
            // btnTableEdit
            // 
            this.btnTableEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTableEdit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnTableEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnTableEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnTableEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnTableEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnTableEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnTableEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTableEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTableEdit.FadingSpeed = 20;
            this.btnTableEdit.FlatAppearance.BorderSize = 0;
            this.btnTableEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableEdit.Font = new System.Drawing.Font("宋体", 9F);
            this.btnTableEdit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnTableEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnTableEdit.Image")));
            this.btnTableEdit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnTableEdit.ImageOffset = 7;
            this.btnTableEdit.IsPressed = false;
            this.btnTableEdit.KeepPress = false;
            this.btnTableEdit.Location = new System.Drawing.Point(417, 5);
            this.btnTableEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnTableEdit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnTableEdit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnTableEdit.Name = "btnTableEdit";
            this.btnTableEdit.Radius = 6;
            this.btnTableEdit.ShowBase = true;
            this.btnTableEdit.Size = new System.Drawing.Size(117, 44);
            this.btnTableEdit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnTableEdit.SplitDistance = 0;
            this.btnTableEdit.TabIndex = 36;
            this.btnTableEdit.Text = "  调整";
            this.btnTableEdit.Title = "工作信息";
            this.btnTableEdit.UseVisualStyleBackColor = true;
            this.btnTableEdit.Click += new System.EventHandler(this.btnTableEdit_Click);
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
            this.bdNgAddNewItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgAddNewItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgAddNewItem.ImageOffset = 5;
            this.bdNgAddNewItem.IsPressed = false;
            this.bdNgAddNewItem.KeepPress = false;
            this.bdNgAddNewItem.Location = new System.Drawing.Point(534, 5);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(117, 44);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 36;
            this.bdNgAddNewItem.Text = "  增加";
            this.bdNgAddNewItem.Title = "工作信息";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
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
            this.bdNgEditItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 7;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(651, 5);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(117, 44);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 30;
            this.bdNgEditItem.Text = "  编辑";
            this.bdNgEditItem.Title = "工作信息";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.bdNgEditItem_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(930, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(45, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
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
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx5.ForeColor = System.Drawing.Color.Black;
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 0;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(4, 4);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(301, 48);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 27;
            this.buttonEx5.Text = "维护保养年度计划调整";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 55);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询和操作";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.dtpQueryYear);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.cbxREPROT_TYPE);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpOrigin);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.dtpTarget);
            this.flowLayoutPanel1.Controls.Add(this.btnAnnualCopy);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(972, 35);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "船舶";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 189;
            this.ucShipSelect1.Location = new System.Drawing.Point(55, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(126, 20);
            this.ucShipSelect1.TabIndex = 20;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(199, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(15, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "查询年度";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpQueryYear
            // 
            this.dtpQueryYear.CustomFormat = "yyyy";
            this.dtpQueryYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpQueryYear.Location = new System.Drawing.Point(258, 3);
            this.dtpQueryYear.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpQueryYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpQueryYear.Name = "dtpQueryYear";
            this.dtpQueryYear.ShowUpDown = true;
            this.dtpQueryYear.Size = new System.Drawing.Size(60, 21);
            this.dtpQueryYear.TabIndex = 36;
            this.dtpQueryYear.ValueChanged += new System.EventHandler(this.dtpQueryYear_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(15, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "类型";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxREPROT_TYPE
            // 
            this.cbxREPROT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxREPROT_TYPE.FormattingEnabled = true;
            this.cbxREPROT_TYPE.Items.AddRange(new object[] {
            "甲板类型",
            "轮机类型"});
            this.cbxREPROT_TYPE.Location = new System.Drawing.Point(371, 3);
            this.cbxREPROT_TYPE.Name = "cbxREPROT_TYPE";
            this.cbxREPROT_TYPE.Size = new System.Drawing.Size(121, 20);
            this.cbxREPROT_TYPE.TabIndex = 41;
            this.cbxREPROT_TYPE.SelectionChangeCommitted += new System.EventHandler(this.cbxITEMTYPE_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "源年度";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpOrigin
            // 
            this.dtpOrigin.CustomFormat = "yyyy";
            this.dtpOrigin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrigin.Location = new System.Drawing.Point(592, 3);
            this.dtpOrigin.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpOrigin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpOrigin.Name = "dtpOrigin";
            this.dtpOrigin.ShowUpDown = true;
            this.dtpOrigin.Size = new System.Drawing.Size(60, 21);
            this.dtpOrigin.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "目标年度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTarget
            // 
            this.dtpTarget.CustomFormat = "yyyy";
            this.dtpTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarget.Location = new System.Drawing.Point(734, 3);
            this.dtpTarget.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpTarget.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpTarget.Name = "dtpTarget";
            this.dtpTarget.ShowUpDown = true;
            this.dtpTarget.Size = new System.Drawing.Size(60, 21);
            this.dtpTarget.TabIndex = 40;
            // 
            // btnAnnualCopy
            // 
            this.btnAnnualCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnualCopy.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAnnualCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnualCopy.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAnnualCopy.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAnnualCopy.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAnnualCopy.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAnnualCopy.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAnnualCopy.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAnnualCopy.FadingSpeed = 20;
            this.btnAnnualCopy.FlatAppearance.BorderSize = 0;
            this.btnAnnualCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnualCopy.Font = new System.Drawing.Font("宋体", 9F);
            this.btnAnnualCopy.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAnnualCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnualCopy.Image")));
            this.btnAnnualCopy.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAnnualCopy.ImageOffset = 5;
            this.btnAnnualCopy.IsPressed = false;
            this.btnAnnualCopy.KeepPress = false;
            this.btnAnnualCopy.Location = new System.Drawing.Point(807, 2);
            this.btnAnnualCopy.Margin = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.btnAnnualCopy.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAnnualCopy.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAnnualCopy.Name = "btnAnnualCopy";
            this.btnAnnualCopy.Radius = 6;
            this.btnAnnualCopy.ShowBase = true;
            this.btnAnnualCopy.Size = new System.Drawing.Size(99, 24);
            this.btnAnnualCopy.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAnnualCopy.SplitDistance = 0;
            this.btnAnnualCopy.TabIndex = 36;
            this.btnAnnualCopy.Text = "年度复制";
            this.btnAnnualCopy.Title = "";
            this.btnAnnualCopy.UseVisualStyleBackColor = true;
            this.btnAnnualCopy.Click += new System.EventHandler(this.btnAnnualCopy_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 124);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(978, 465);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvWork);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(390, 465);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工作信息列表";
            // 
            // dgvWork
            // 
            this.dgvWork.AllowUserToAddRows = false;
            this.dgvWork.AllowUserToDeleteRows = false;
            this.dgvWork.AllowUserToOrderColumns = true;
            this.dgvWork.AutoFit = true;
            this.dgvWork.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWork.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWork.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWork.EnableHeadersVisualStyles = false;
            this.dgvWork.ExportColorToExcel = false;
            this.dgvWork.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.Footer")));
            this.dgvWork.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWork.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.Header")));
            this.dgvWork.LoadedFinish = false;
            this.dgvWork.Location = new System.Drawing.Point(8, 17);
            this.dgvWork.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.MergeColumnNames")));
            this.dgvWork.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.MergeRowColumn")));
            this.dgvWork.Name = "dgvWork";
            this.dgvWork.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWork.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWork.RowHeadersWidth = 25;
            this.dgvWork.RowTemplate.Height = 23;
            this.dgvWork.ShowRowNumber = true;
            this.dgvWork.Size = new System.Drawing.Size(374, 440);
            this.dgvWork.TabIndex = 2;
            this.dgvWork.Title = "";
            this.dgvWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWork_CellDoubleClick);
            this.dgvWork.CurrentCellChanged += new System.EventHandler(this.dgvWork_CurrentCellChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ucWorkInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.45161F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.54839F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 465);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ucWorkInfo
            // 
            this.ucWorkInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.ucWorkInfo.Component_unit = null;
            this.ucWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkInfo.Location = new System.Drawing.Point(3, 3);
            this.ucWorkInfo.Name = "ucWorkInfo";
            this.ucWorkInfo.Size = new System.Drawing.Size(578, 302);
            this.ucWorkInfo.TabIndex = 0;
            this.ucWorkInfo.WorkInfo = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 151);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印输出表格样式";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtEx1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtORDERNUM_SHOW, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtEXCEL_ORDERNUM, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(572, 131);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtEx1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtEx1, 3);
            this.txtEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEx1.Location = new System.Drawing.Point(96, 78);
            this.txtEx1.Multiline = true;
            this.txtEx1.Name = "txtEx1";
            this.txtEx1.ReadOnly = true;
            this.txtEx1.Size = new System.Drawing.Size(473, 50);
            this.txtEx1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 56);
            this.label6.TabIndex = 4;
            this.label6.Text = "备注";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 46);
            this.label5.TabIndex = 1;
            this.label5.Text = "月保养勾选";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "序号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtORDERNUM_SHOW
            // 
            this.txtORDERNUM_SHOW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtORDERNUM_SHOW.Location = new System.Drawing.Point(96, 3);
            this.txtORDERNUM_SHOW.Name = "txtORDERNUM_SHOW";
            this.txtORDERNUM_SHOW.ReadOnly = true;
            this.txtORDERNUM_SHOW.Size = new System.Drawing.Size(193, 21);
            this.txtORDERNUM_SHOW.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Controls.Add(this.checkBox1);
            this.flowLayoutPanel2.Controls.Add(this.checkBox2);
            this.flowLayoutPanel2.Controls.Add(this.checkBox3);
            this.flowLayoutPanel2.Controls.Add(this.checkBox4);
            this.flowLayoutPanel2.Controls.Add(this.checkBox5);
            this.flowLayoutPanel2.Controls.Add(this.checkBox6);
            this.flowLayoutPanel2.Controls.Add(this.checkBox7);
            this.flowLayoutPanel2.Controls.Add(this.checkBox8);
            this.flowLayoutPanel2.Controls.Add(this.checkBox9);
            this.flowLayoutPanel2.Controls.Add(this.checkBox10);
            this.flowLayoutPanel2.Controls.Add(this.checkBox11);
            this.flowLayoutPanel2.Controls.Add(this.checkBox12);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(96, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(473, 40);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 30);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "{1}";
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(24, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 30);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Tag = "{2}";
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(45, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 30);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Tag = "{3}";
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(66, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 30);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Tag = "{4}";
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(87, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 30);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Tag = "{5}";
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(108, 3);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 30);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Tag = "{6}";
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(129, 3);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 30);
            this.checkBox7.TabIndex = 0;
            this.checkBox7.Tag = "{7}";
            this.checkBox7.Text = "7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(150, 3);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 30);
            this.checkBox8.TabIndex = 0;
            this.checkBox8.Tag = "{8}";
            this.checkBox8.Text = "8";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox9.Enabled = false;
            this.checkBox9.Location = new System.Drawing.Point(171, 3);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(15, 30);
            this.checkBox9.TabIndex = 0;
            this.checkBox9.Tag = "{9}";
            this.checkBox9.Text = "9";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox10.Enabled = false;
            this.checkBox10.Location = new System.Drawing.Point(192, 3);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(21, 30);
            this.checkBox10.TabIndex = 0;
            this.checkBox10.Tag = "{10}";
            this.checkBox10.Text = "10";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox11.Enabled = false;
            this.checkBox11.Location = new System.Drawing.Point(219, 3);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(21, 30);
            this.checkBox11.TabIndex = 0;
            this.checkBox11.Tag = "{11}";
            this.checkBox11.Text = "11";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox12.Enabled = false;
            this.checkBox12.Location = new System.Drawing.Point(246, 3);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(21, 30);
            this.checkBox12.TabIndex = 0;
            this.checkBox12.Tag = "{12}";
            this.checkBox12.Text = "12";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(295, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "排序号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEXCEL_ORDERNUM
            // 
            this.txtEXCEL_ORDERNUM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEXCEL_ORDERNUM.Location = new System.Drawing.Point(375, 3);
            this.txtEXCEL_ORDERNUM.Name = "txtEXCEL_ORDERNUM";
            this.txtEXCEL_ORDERNUM.ReadOnly = true;
            this.txtEXCEL_ORDERNUM.Size = new System.Drawing.Size(194, 21);
            this.txtEXCEL_ORDERNUM.TabIndex = 2;
            // 
            // FrmPmsAnnualPlanAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(984, 592);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPmsAnnualPlanAdjustment";
            this.Text = "维护保养年度计划调整";
            this.Load += new System.EventHandler(this.FrmPmsAnnualPlanAdjustment_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPmsAnnualPlanAdjustment_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CommonViewer.UcDataGridView dgvWork;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource bdsWorkOrder;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.ButtonEx bdNgEditItem;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx bdNgDeleteItem;
        private CommonViewer.ButtonEx bdNgAddNewItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UcWorkInfoNotEdit ucWorkInfo;
        private CommonViewer.ButtonEx btnAnnualCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpQueryYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOrigin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTarget;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtORDERNUM_SHOW;
        private CommonViewer.TextBoxEx txtEx1;
        private System.Windows.Forms.Label label6;
        private CommonViewer.ButtonEx btnTableEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtEXCEL_ORDERNUM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxREPROT_TYPE;
        public CommonViewer.ButtonEx btnPrint;

    }
}