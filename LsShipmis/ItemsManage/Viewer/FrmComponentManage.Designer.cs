namespace ItemsManage.Viewer
 {
    partial class FrmComponentManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComponentManage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucEquipmentClassTreeWithEquipment1 = new ItemsManage.Viewer.UcEquipmentClassTreeWithEquipment();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucShipInfo1 = new BaseInfo.Viewer.UcShipInfo();
            this.gbEquipmentClass = new System.Windows.Forms.GroupBox();
            this.ucEquipmentClass1 = new ItemsManage.Viewer.UcEquipmentClass();
            this.ucEquipment1 = new ItemsManage.Viewer.UcEquipment();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWorkInfoEdit = new CommonViewer.ButtonEx();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.btnCompHistory = new CommonViewer.ButtonEx();
            this.buttonEx3 = new CommonViewer.ButtonEx();
            this.btnSpareInfo = new CommonViewer.ButtonEx();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.SaveButton = new CommonViewer.ButtonEx();
            this.deleteButton = new CommonViewer.ButtonEx();
            this.AddButton = new CommonViewer.ButtonEx();
            this.btnClone = new CommonViewer.ButtonEx();
            this.buttonSearch = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbEquipmentClass.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1246, 530);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucEquipmentClassTreeWithEquipment1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 530);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备信息树";
            // 
            // ucEquipmentClassTreeWithEquipment1
            // 
            this.ucEquipmentClassTreeWithEquipment1.AllowDrop = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowEquipmentClassDragToOtherClass = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserDrag = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserEdit = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserMultiSelect = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserSort = true;
            this.ucEquipmentClassTreeWithEquipment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEquipmentClassTreeWithEquipment1.Font = new System.Drawing.Font("宋体", 12F);
            this.ucEquipmentClassTreeWithEquipment1.ImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ItemHeight = 22;
            this.ucEquipmentClassTreeWithEquipment1.Location = new System.Drawing.Point(3, 17);
            this.ucEquipmentClassTreeWithEquipment1.Name = "ucEquipmentClassTreeWithEquipment1";
            this.ucEquipmentClassTreeWithEquipment1.OneShipMode = false;
            this.ucEquipmentClassTreeWithEquipment1.OnlyShowNotClassifedEquipment = false;
            this.ucEquipmentClassTreeWithEquipment1.SelectedImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ShowAllClass = false;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipmentHaveSpare = true;
            this.ucEquipmentClassTreeWithEquipment1.ShowNotClassifedEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.Size = new System.Drawing.Size(526, 510);
            this.ucEquipmentClassTreeWithEquipment1.TabIndex = 1;
            this.ucEquipmentClassTreeWithEquipment1.ItemChanged += new ItemsManage.Viewer.UcEquipmentClassTreeWithEquipment.itemChanged(this.ucEquipmentClassTreeWithEquipment1_ItemChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 530);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucShipInfo1);
            this.panel4.Controls.Add(this.gbEquipmentClass);
            this.panel4.Controls.Add(this.ucEquipment1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(704, 474);
            this.panel4.TabIndex = 7;
            // 
            // ucShipInfo1
            // 
            this.ucShipInfo1.AutoScroll = true;
            this.ucShipInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucShipInfo1.Name = "ucShipInfo1";
            this.ucShipInfo1.Size = new System.Drawing.Size(704, 474);
            this.ucShipInfo1.TabIndex = 7;
            // 
            // gbEquipmentClass
            // 
            this.gbEquipmentClass.Controls.Add(this.ucEquipmentClass1);
            this.gbEquipmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEquipmentClass.Location = new System.Drawing.Point(0, 0);
            this.gbEquipmentClass.Name = "gbEquipmentClass";
            this.gbEquipmentClass.Size = new System.Drawing.Size(704, 474);
            this.gbEquipmentClass.TabIndex = 6;
            this.gbEquipmentClass.TabStop = false;
            this.gbEquipmentClass.Text = "设备分类编码";
            // 
            // ucEquipmentClass1
            // 
            this.ucEquipmentClass1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEquipmentClass1.Location = new System.Drawing.Point(3, 17);
            this.ucEquipmentClass1.Name = "ucEquipmentClass1";
            this.ucEquipmentClass1.Size = new System.Drawing.Size(698, 454);
            this.ucEquipmentClass1.TabIndex = 5;
            // 
            // ucEquipment1
            // 
            this.ucEquipment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEquipment1.Location = new System.Drawing.Point(0, 0);
            this.ucEquipment1.Name = "ucEquipment1";
            this.ucEquipment1.Size = new System.Drawing.Size(704, 474);
            this.ucEquipment1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWorkInfoEdit);
            this.groupBox1.Controls.Add(this.btnBdFiles);
            this.groupBox1.Controls.Add(this.btnCompHistory);
            this.groupBox1.Controls.Add(this.buttonEx3);
            this.groupBox1.Controls.Add(this.btnSpareInfo);
            this.groupBox1.Controls.Add(this.buttonEx1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 44);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备相关信息组";
            // 
            // btnWorkInfoEdit
            // 
            this.btnWorkInfoEdit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnWorkInfoEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkInfoEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnWorkInfoEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnWorkInfoEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnWorkInfoEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnWorkInfoEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWorkInfoEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnWorkInfoEdit.FadingSpeed = 100;
            this.btnWorkInfoEdit.FlatAppearance.BorderSize = 0;
            this.btnWorkInfoEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkInfoEdit.Font = new System.Drawing.Font("宋体", 9F);
            this.btnWorkInfoEdit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnWorkInfoEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWorkInfoEdit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.btnWorkInfoEdit.ImageOffset = 0;
            this.btnWorkInfoEdit.IsPressed = false;
            this.btnWorkInfoEdit.KeepPress = false;
            this.btnWorkInfoEdit.Location = new System.Drawing.Point(3, 14);
            this.btnWorkInfoEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorkInfoEdit.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnWorkInfoEdit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWorkInfoEdit.Name = "btnWorkInfoEdit";
            this.btnWorkInfoEdit.Radius = 6;
            this.btnWorkInfoEdit.ShowBase = true;
            this.btnWorkInfoEdit.Size = new System.Drawing.Size(65, 25);
            this.btnWorkInfoEdit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnWorkInfoEdit.SplitDistance = 2;
            this.btnWorkInfoEdit.TabIndex = 42;
            this.btnWorkInfoEdit.Text = " 保养内容";
            this.btnWorkInfoEdit.Title = "";
            this.btnWorkInfoEdit.UseVisualStyleBackColor = true;
            this.btnWorkInfoEdit.Click += new System.EventHandler(this.btnWorkInfoEdit_Click);
            // 
            // btnBdFiles
            // 
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
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.btnBdFiles.ImageOffset = 0;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(360, 14);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(65, 25);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 43;
            this.btnBdFiles.Text = "   附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // btnCompHistory
            // 
            this.btnCompHistory.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCompHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnCompHistory.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCompHistory.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCompHistory.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCompHistory.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCompHistory.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCompHistory.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCompHistory.FadingSpeed = 20;
            this.btnCompHistory.FlatAppearance.BorderSize = 0;
            this.btnCompHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompHistory.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCompHistory.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCompHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompHistory.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.btnCompHistory.ImageOffset = 0;
            this.btnCompHistory.IsPressed = false;
            this.btnCompHistory.KeepPress = false;
            this.btnCompHistory.Location = new System.Drawing.Point(69, 14);
            this.btnCompHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnCompHistory.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnCompHistory.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCompHistory.Name = "btnCompHistory";
            this.btnCompHistory.Radius = 6;
            this.btnCompHistory.ShowBase = true;
            this.btnCompHistory.Size = new System.Drawing.Size(65, 25);
            this.btnCompHistory.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCompHistory.SplitDistance = 2;
            this.btnCompHistory.TabIndex = 44;
            this.btnCompHistory.Text = " 保养历史";
            this.btnCompHistory.Title = "";
            this.btnCompHistory.UseVisualStyleBackColor = true;
            this.btnCompHistory.Click += new System.EventHandler(this.btnCompHistory_Click);
            // 
            // buttonEx3
            // 
            this.buttonEx3.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx3.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx3.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx3.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx3.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx3.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx3.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx3.FadingSpeed = 20;
            this.buttonEx3.FlatAppearance.BorderSize = 0;
            this.buttonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx3.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx3.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx3.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.buttonEx3.ImageOffset = 0;
            this.buttonEx3.IsPressed = false;
            this.buttonEx3.KeepPress = false;
            this.buttonEx3.Location = new System.Drawing.Point(294, 14);
            this.buttonEx3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx3.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonEx3.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Radius = 6;
            this.buttonEx3.ShowBase = true;
            this.buttonEx3.Size = new System.Drawing.Size(65, 25);
            this.buttonEx3.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx3.SplitDistance = 0;
            this.buttonEx3.TabIndex = 47;
            this.buttonEx3.Text = " 操作说明";
            this.buttonEx3.Title = "";
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Click += new System.EventHandler(this.buttonEx3_Click);
            // 
            // btnSpareInfo
            // 
            this.btnSpareInfo.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSpareInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnSpareInfo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSpareInfo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSpareInfo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSpareInfo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSpareInfo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSpareInfo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSpareInfo.FadingSpeed = 20;
            this.btnSpareInfo.FlatAppearance.BorderSize = 0;
            this.btnSpareInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpareInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSpareInfo.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSpareInfo.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.btnSpareInfo.ImageOffset = 0;
            this.btnSpareInfo.IsPressed = false;
            this.btnSpareInfo.KeepPress = false;
            this.btnSpareInfo.Location = new System.Drawing.Point(215, 14);
            this.btnSpareInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnSpareInfo.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnSpareInfo.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSpareInfo.Name = "btnSpareInfo";
            this.btnSpareInfo.Radius = 6;
            this.btnSpareInfo.ShowBase = true;
            this.btnSpareInfo.Size = new System.Drawing.Size(65, 25);
            this.btnSpareInfo.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSpareInfo.SplitDistance = 0;
            this.btnSpareInfo.TabIndex = 40;
            this.btnSpareInfo.Text = " 备件图纸";
            this.btnSpareInfo.Title = "";
            this.btnSpareInfo.UseVisualStyleBackColor = true;
            this.btnSpareInfo.Click += new System.EventHandler(this.btnSpareInfo_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.buttonEx1.ImageOffset = 0;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(149, 14);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = true;
            this.buttonEx1.Size = new System.Drawing.Size(65, 25);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 41;
            this.buttonEx1.Text = " 备件维护";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1256, 53);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1256, 53);
            this.panel3.TabIndex = 51;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CloseButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteButton);
            this.flowLayoutPanel1.Controls.Add(this.AddButton);
            this.flowLayoutPanel1.Controls.Add(this.btnClone);
            this.flowLayoutPanel1.Controls.Add(this.buttonSearch);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(262, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(994, 53);
            this.flowLayoutPanel1.TabIndex = 45;
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
            this.CloseButton.Location = new System.Drawing.Point(949, 2);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(40, 40);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(43, 46);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.SaveButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
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
            this.SaveButton.Location = new System.Drawing.Point(906, 2);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.SaveButton.MaxImageSize = new System.Drawing.Point(40, 40);
            this.SaveButton.MenuPos = new System.Drawing.Point(0, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Radius = 6;
            this.SaveButton.ShowBase = true;
            this.SaveButton.Size = new System.Drawing.Size(43, 46);
            this.SaveButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.SaveButton.SplitDistance = 0;
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Title = "";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.deleteButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.deleteButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.deleteButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.deleteButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deleteButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.deleteButton.FadingSpeed = 20;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("宋体", 9F);
            this.deleteButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.deleteButton.ImageOffset = 3;
            this.deleteButton.IsPressed = false;
            this.deleteButton.KeepPress = false;
            this.deleteButton.Location = new System.Drawing.Point(863, 2);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaxImageSize = new System.Drawing.Point(40, 40);
            this.deleteButton.MenuPos = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Radius = 6;
            this.deleteButton.ShowBase = true;
            this.deleteButton.Size = new System.Drawing.Size(43, 46);
            this.deleteButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.deleteButton.SplitDistance = 0;
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Title = "";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.AddButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.AddButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.AddButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.AddButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AddButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.AddButton.FadingSpeed = 20;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("宋体", 9F);
            this.AddButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.AddButton.ImageOffset = 3;
            this.AddButton.IsPressed = false;
            this.AddButton.KeepPress = false;
            this.AddButton.Location = new System.Drawing.Point(820, 2);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.MaxImageSize = new System.Drawing.Point(40, 40);
            this.AddButton.MenuPos = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Radius = 6;
            this.AddButton.ShowBase = true;
            this.AddButton.Size = new System.Drawing.Size(43, 46);
            this.AddButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.AddButton.SplitDistance = 0;
            this.AddButton.TabIndex = 22;
            this.AddButton.Title = "";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.新建NToolStripButton_Click);
            // 
            // btnClone
            // 
            this.btnClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnClone.Location = new System.Drawing.Point(777, 2);
            this.btnClone.Margin = new System.Windows.Forms.Padding(0);
            this.btnClone.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnClone.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClone.Name = "btnClone";
            this.btnClone.Radius = 6;
            this.btnClone.ShowBase = true;
            this.btnClone.Size = new System.Drawing.Size(43, 46);
            this.btnClone.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClone.SplitDistance = 0;
            this.btnClone.TabIndex = 48;
            this.btnClone.Title = "";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.buttonEx4_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonSearch.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonSearch.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonSearch.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonSearch.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonSearch.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonSearch.FadingSpeed = 20;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonSearch.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonSearch.ImageOffset = 2;
            this.buttonSearch.IsPressed = false;
            this.buttonSearch.KeepPress = false;
            this.buttonSearch.Location = new System.Drawing.Point(730, 2);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSearch.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonSearch.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Radius = 6;
            this.buttonSearch.ShowBase = true;
            this.buttonSearch.Size = new System.Drawing.Size(47, 46);
            this.buttonSearch.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonSearch.SplitDistance = 0;
            this.buttonSearch.TabIndex = 28;
            this.buttonSearch.Title = "";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(642, 2);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = true;
            this.buttonEx2.Size = new System.Drawing.Size(88, 46);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 46;
            this.buttonEx2.Text = "导入";
            this.buttonEx2.Title = "快速";
            this.buttonEx2.UseVisualStyleBackColor = true;
            this.buttonEx2.Click += new System.EventHandler(this.buttonEx2_Click);
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
            this.buttonEx5.ImageOffset = 0;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(3, 0);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(248, 53);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "设备基本信息维护";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1256, 540);
            this.panel2.TabIndex = 2;
            // 
            // FrmComponentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1256, 593);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmComponentManage";
            this.Text = "设备维护";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmComponentManage_FormClosed);
            this.Load += new System.EventHandler(this.FrmComponentManage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gbEquipmentClass.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonSearch;
        private CommonViewer.ButtonEx SaveButton;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx AddButton;
        private CommonViewer.ButtonEx deleteButton;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx btnSpareInfo;
        private CommonViewer.ButtonEx btnWorkInfoEdit;
        private CommonViewer.ButtonEx buttonEx1;
        private CommonViewer.ButtonEx btnCompHistory;
        private CommonViewer.ButtonEx btnBdFiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CommonViewer.ButtonEx buttonEx2;
        private System.Windows.Forms.GroupBox groupBox2;
        private UcEquipmentClassTreeWithEquipment ucEquipmentClassTreeWithEquipment1;
        private System.Windows.Forms.GroupBox gbEquipmentClass;
        private UcEquipmentClass ucEquipmentClass1;
        private BaseInfo.Viewer.UcShipInfo ucShipInfo1;
        private CommonViewer.ButtonEx buttonEx3;
        private UcEquipment ucEquipment1;
        private CommonViewer.ButtonEx btnClone;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}