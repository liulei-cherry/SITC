namespace ItemsManage.Viewer
{
    partial class FrmMaterialBaseEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialBaseEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.deleteButton = new CommonViewer.ButtonEx();
            this.AddButton = new CommonViewer.ButtonEx();
            this.btnEdit = new CommonViewer.ButtonEx();
            this.btnMaterialTypeEdit = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucMaterialTypeTree1 = new ItemsManage.Viewer.UcMaterialTypeTree();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ucMaterialInfo1 = new ItemsManage.Viewer.UcMaterialInfo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new CommonViewer.TextBoxEx();
            this.btnClear = new CommonViewer.ButtonEx();
            this.btnSelectAll = new CommonViewer.ButtonEx();
            this.btnSetType = new CommonViewer.ButtonEx();
            this.imgLstMain = new System.Windows.Forms.ImageList(this.components);
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 667);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.panel3.Size = new System.Drawing.Size(962, 54);
            this.panel3.TabIndex = 51;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CloseButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteButton);
            this.flowLayoutPanel1.Controls.Add(this.AddButton);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnMaterialTypeEdit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(410, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(552, 54);
            this.flowLayoutPanel1.TabIndex = 47;
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
            this.CloseButton.Location = new System.Drawing.Point(499, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(43, 43);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
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
            this.deleteButton.Location = new System.Drawing.Point(456, 5);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.deleteButton.MenuPos = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Radius = 6;
            this.deleteButton.ShowBase = true;
            this.deleteButton.Size = new System.Drawing.Size(43, 43);
            this.deleteButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.deleteButton.SplitDistance = 0;
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Title = "";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
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
            this.AddButton.Location = new System.Drawing.Point(413, 5);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.AddButton.MenuPos = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Radius = 6;
            this.AddButton.ShowBase = true;
            this.AddButton.Size = new System.Drawing.Size(43, 43);
            this.AddButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.AddButton.SplitDistance = 0;
            this.AddButton.TabIndex = 22;
            this.AddButton.Title = "";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEdit.FadingSpeed = 20;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("宋体", 9F);
            this.btnEdit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnEdit.ImageOffset = 8;
            this.btnEdit.IsPressed = false;
            this.btnEdit.KeepPress = false;
            this.btnEdit.Location = new System.Drawing.Point(310, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnEdit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Radius = 6;
            this.btnEdit.ShowBase = true;
            this.btnEdit.Size = new System.Drawing.Size(103, 43);
            this.btnEdit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnEdit.SplitDistance = 0;
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "编辑";
            this.btnEdit.Title = "";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnMaterialTypeEdit
            // 
            this.btnMaterialTypeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaterialTypeEdit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnMaterialTypeEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnMaterialTypeEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnMaterialTypeEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnMaterialTypeEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnMaterialTypeEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnMaterialTypeEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMaterialTypeEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnMaterialTypeEdit.FadingSpeed = 20;
            this.btnMaterialTypeEdit.FlatAppearance.BorderSize = 0;
            this.btnMaterialTypeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterialTypeEdit.Font = new System.Drawing.Font("宋体", 9F);
            this.btnMaterialTypeEdit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnMaterialTypeEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterialTypeEdit.Image")));
            this.btnMaterialTypeEdit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnMaterialTypeEdit.ImageOffset = 3;
            this.btnMaterialTypeEdit.IsPressed = false;
            this.btnMaterialTypeEdit.KeepPress = false;
            this.btnMaterialTypeEdit.Location = new System.Drawing.Point(154, 5);
            this.btnMaterialTypeEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaterialTypeEdit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnMaterialTypeEdit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnMaterialTypeEdit.Name = "btnMaterialTypeEdit";
            this.btnMaterialTypeEdit.Radius = 6;
            this.btnMaterialTypeEdit.ShowBase = true;
            this.btnMaterialTypeEdit.Size = new System.Drawing.Size(156, 43);
            this.btnMaterialTypeEdit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnMaterialTypeEdit.SplitDistance = 0;
            this.btnMaterialTypeEdit.TabIndex = 27;
            this.btnMaterialTypeEdit.Text = "物资分类维护";
            this.btnMaterialTypeEdit.Title = "";
            this.btnMaterialTypeEdit.UseVisualStyleBackColor = true;
            this.btnMaterialTypeEdit.Click += new System.EventHandler(this.btnMaterialTypeEdit_Click);
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
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.buttonEx5.Size = new System.Drawing.Size(222, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "物资信息维护";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(956, 607);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucMaterialTypeTree1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(392, 607);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物资分类树";
            // 
            // ucMaterialTypeTree1
            // 
            this.ucMaterialTypeTree1.AllowDrop = true;
            this.ucMaterialTypeTree1.AllowUserDrag = false;
            this.ucMaterialTypeTree1.AllowUserSort = false;
            this.ucMaterialTypeTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaterialTypeTree1.Font = new System.Drawing.Font("宋体", 12F);
            this.ucMaterialTypeTree1.ImageIndex = 0;
            this.ucMaterialTypeTree1.ItemHeight = 22;
            this.ucMaterialTypeTree1.Location = new System.Drawing.Point(8, 17);
            this.ucMaterialTypeTree1.Name = "ucMaterialTypeTree1";
            this.ucMaterialTypeTree1.SelectedImageIndex = 0;
            this.ucMaterialTypeTree1.Size = new System.Drawing.Size(376, 582);
            this.ucMaterialTypeTree1.TabIndex = 0;
            this.ucMaterialTypeTree1.ItemChanged += new ItemsManage.Viewer.UcMaterialTypeTree.itemChanged(this.ucMaterialTypeTree1_ItemChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(560, 607);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvMain);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox4.Size = new System.Drawing.Size(554, 371);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "物资基础信息列表";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.AutoFit = true;
            this.dgvMain.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvMain.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ExportColorToExcel = false;
            this.dgvMain.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Footer")));
            this.dgvMain.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMain.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Header")));
            this.dgvMain.LoadedFinish = false;
            this.dgvMain.Location = new System.Drawing.Point(8, 17);
            this.dgvMain.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeColumnNames")));
            this.dgvMain.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeRowColumn")));
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersWidth = 25;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.ShowRowNumber = false;
            this.dgvMain.Size = new System.Drawing.Size(538, 346);
            this.dgvMain.TabIndex = 12;
            this.dgvMain.Title = "";
            this.dgvMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseClick);
            this.dgvMain.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_RowEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucMaterialInfo1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(554, 194);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "物资基础信息";
            // 
            // ucMaterialInfo1
            // 
            this.ucMaterialInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaterialInfo1.Location = new System.Drawing.Point(10, 24);
            this.ucMaterialInfo1.Name = "ucMaterialInfo1";
            this.ucMaterialInfo1.Size = new System.Drawing.Size(534, 160);
            this.ucMaterialInfo1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSelectAll);
            this.panel1.Controls.Add(this.btnSetType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 30);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "过滤";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(221, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(169, 21);
            this.txtFilter.TabIndex = 31;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClear.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnClear.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClear.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClear.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClear.FadingSpeed = 20;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClear.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClear.ImageOffset = 3;
            this.btnClear.IsPressed = false;
            this.btnClear.KeepPress = false;
            this.btnClear.Location = new System.Drawing.Point(67, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClear.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 6;
            this.btnClear.ShowBase = true;
            this.btnClear.Size = new System.Drawing.Size(64, 26);
            this.btnClear.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClear.SplitDistance = 0;
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "清空";
            this.btnClear.Title = "";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSelectAll.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSelectAll.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSelectAll.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSelectAll.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelectAll.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSelectAll.FadingSpeed = 20;
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSelectAll.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSelectAll.ImageOffset = 3;
            this.btnSelectAll.IsPressed = false;
            this.btnSelectAll.KeepPress = false;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 2);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectAll.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSelectAll.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Radius = 6;
            this.btnSelectAll.ShowBase = true;
            this.btnSelectAll.Size = new System.Drawing.Size(64, 26);
            this.btnSelectAll.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSelectAll.SplitDistance = 0;
            this.btnSelectAll.TabIndex = 29;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Title = "";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSetType
            // 
            this.btnSetType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetType.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSetType.BackColor = System.Drawing.Color.Transparent;
            this.btnSetType.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSetType.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSetType.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSetType.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSetType.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSetType.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSetType.FadingSpeed = 20;
            this.btnSetType.FlatAppearance.BorderSize = 0;
            this.btnSetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetType.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSetType.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSetType.Image = ((System.Drawing.Image)(resources.GetObject("btnSetType.Image")));
            this.btnSetType.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSetType.ImageOffset = 3;
            this.btnSetType.IsPressed = false;
            this.btnSetType.KeepPress = false;
            this.btnSetType.Location = new System.Drawing.Point(420, 2);
            this.btnSetType.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetType.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSetType.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSetType.Name = "btnSetType";
            this.btnSetType.Radius = 6;
            this.btnSetType.ShowBase = true;
            this.btnSetType.Size = new System.Drawing.Size(129, 26);
            this.btnSetType.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSetType.SplitDistance = 0;
            this.btnSetType.TabIndex = 28;
            this.btnSetType.Text = "调整分类";
            this.btnSetType.Title = "";
            this.btnSetType.UseVisualStyleBackColor = true;
            this.btnSetType.Click += new System.EventHandler(this.btnSetType_Click);
            // 
            // imgLstMain
            // 
            this.imgLstMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMain.ImageStream")));
            this.imgLstMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMain.Images.SetKeyName(0, "");
            this.imgLstMain.Images.SetKeyName(1, "folder.gif");
            this.imgLstMain.Images.SetKeyName(2, "openfolder.gif");
            // 
            // FrmMaterialBaseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(962, 667);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaterialBaseEdit";
            this.Text = "物资信息维护";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMaterialBaseEdit_FormClosed);
            this.Load += new System.EventHandler(this.FrmMaterialType_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imgLstMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.UcDataGridView dgvMain;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx btnEdit;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx AddButton;
        private CommonViewer.ButtonEx deleteButton;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CommonViewer.ButtonEx btnMaterialTypeEdit;
        private UcMaterialTypeTree ucMaterialTypeTree1;
        private UcMaterialInfo ucMaterialInfo1;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.ButtonEx btnClear;
        private CommonViewer.ButtonEx btnSelectAll;
        private CommonViewer.ButtonEx btnSetType;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtFilter;
    }
}