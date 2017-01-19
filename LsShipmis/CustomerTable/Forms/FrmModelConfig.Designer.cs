namespace CustomerTable.Forms
{
    partial class FrmModelConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModelConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.btnRapid = new CommonViewer.ButtonEx();
            this.AddButton = new CommonViewer.ButtonEx();
            this.deleteButton = new CommonViewer.ButtonEx();
            this.btnConfig = new CommonViewer.ButtonEx();
            this.bdNgSave = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonEx7 = new CommonViewer.ButtonEx();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv = new CommonViewer.UcDataGridView(this.components);
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.btnRapid);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.deleteButton);
            this.panel3.Controls.Add(this.btnConfig);
            this.panel3.Controls.Add(this.bdNgSave);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 56);
            this.panel3.TabIndex = 54;
            // 
            // buttonEx1
            // 
            this.buttonEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 6;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(369, 4);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = true;
            this.buttonEx1.Size = new System.Drawing.Size(82, 42);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 33;
            this.buttonEx1.Text = "清空";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // btnRapid
            // 
            this.btnRapid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRapid.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnRapid.BackColor = System.Drawing.Color.Transparent;
            this.btnRapid.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnRapid.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnRapid.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRapid.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRapid.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRapid.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRapid.FadingSpeed = 20;
            this.btnRapid.FlatAppearance.BorderSize = 0;
            this.btnRapid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapid.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRapid.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnRapid.Image = ((System.Drawing.Image)(resources.GetObject("btnRapid.Image")));
            this.btnRapid.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnRapid.ImageOffset = 3;
            this.btnRapid.IsPressed = false;
            this.btnRapid.KeepPress = false;
            this.btnRapid.Location = new System.Drawing.Point(451, 5);
            this.btnRapid.Margin = new System.Windows.Forms.Padding(0);
            this.btnRapid.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnRapid.MenuPos = new System.Drawing.Point(0, 0);
            this.btnRapid.Name = "btnRapid";
            this.btnRapid.Radius = 6;
            this.btnRapid.ShowBase = true;
            this.btnRapid.Size = new System.Drawing.Size(98, 41);
            this.btnRapid.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnRapid.SplitDistance = 0;
            this.btnRapid.TabIndex = 32;
            this.btnRapid.Text = "快速导入";
            this.btnRapid.Title = "";
            this.btnRapid.UseVisualStyleBackColor = true;
            this.btnRapid.Click += new System.EventHandler(this.btnRapid_Click);
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
            this.AddButton.Location = new System.Drawing.Point(549, 5);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.AddButton.MenuPos = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Radius = 6;
            this.AddButton.ShowBase = true;
            this.AddButton.Size = new System.Drawing.Size(43, 41);
            this.AddButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.AddButton.SplitDistance = 0;
            this.AddButton.TabIndex = 30;
            this.AddButton.Title = "";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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
            this.deleteButton.Location = new System.Drawing.Point(592, 5);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.deleteButton.MenuPos = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Radius = 6;
            this.deleteButton.ShowBase = true;
            this.deleteButton.Size = new System.Drawing.Size(39, 41);
            this.deleteButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.deleteButton.SplitDistance = 0;
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Title = "";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnConfig.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfig.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnConfig.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnConfig.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnConfig.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnConfig.Enabled = false;
            this.btnConfig.FadingSpeed = 20;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnConfig.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnConfig.ImageOffset = 3;
            this.btnConfig.IsPressed = false;
            this.btnConfig.KeepPress = false;
            this.btnConfig.Location = new System.Drawing.Point(7, 5);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfig.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnConfig.MenuPos = new System.Drawing.Point(0, 0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Radius = 6;
            this.btnConfig.ShowBase = false;
            this.btnConfig.Size = new System.Drawing.Size(287, 45);
            this.btnConfig.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnConfig.SplitDistance = 0;
            this.btnConfig.TabIndex = 29;
            this.btnConfig.Text = "客户化表格固定项配置";
            this.btnConfig.Title = "";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // bdNgSave
            // 
            this.bdNgSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgSave.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgSave.BackColor = System.Drawing.Color.Transparent;
            this.bdNgSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgSave.FadingSpeed = 20;
            this.bdNgSave.FlatAppearance.BorderSize = 0;
            this.bdNgSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgSave.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgSave.Image = ((System.Drawing.Image)(resources.GetObject("bdNgSave.Image")));
            this.bdNgSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgSave.ImageOffset = 8;
            this.bdNgSave.IsPressed = false;
            this.bdNgSave.KeepPress = false;
            this.bdNgSave.Location = new System.Drawing.Point(631, 5);
            this.bdNgSave.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgSave.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgSave.Name = "bdNgSave";
            this.bdNgSave.Radius = 6;
            this.bdNgSave.ShowBase = true;
            this.bdNgSave.Size = new System.Drawing.Size(99, 41);
            this.bdNgSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgSave.SplitDistance = 0;
            this.bdNgSave.TabIndex = 23;
            this.bdNgSave.Text = "保存修改";
            this.bdNgSave.Title = "";
            this.bdNgSave.UseVisualStyleBackColor = true;
            this.bdNgSave.Click += new System.EventHandler(this.bdNgSave_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(730, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(75, 41);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 56;
            this.label1.Text = "配置表名称";
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableName.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTableName.Location = new System.Drawing.Point(159, 144);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(609, 23);
            this.txtTableName.TabIndex = 56;
            this.txtTableName.Text = "name";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.richTextBox1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.richTextBox1.Location = new System.Drawing.Point(167, 83);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(16, 13);
            this.richTextBox1.TabIndex = 58;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // buttonEx7
            // 
            this.buttonEx7.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx7.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx7.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx7.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx7.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx7.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx7.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx7.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx7.Enabled = false;
            this.buttonEx7.FadingSpeed = 20;
            this.buttonEx7.FlatAppearance.BorderSize = 0;
            this.buttonEx7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx7.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx7.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx7.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx7.Image")));
            this.buttonEx7.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx7.ImageOffset = 2;
            this.buttonEx7.IsPressed = false;
            this.buttonEx7.KeepPress = false;
            this.buttonEx7.Location = new System.Drawing.Point(142, 68);
            this.buttonEx7.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx7.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx7.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx7.Name = "buttonEx7";
            this.buttonEx7.Radius = 6;
            this.buttonEx7.ShowBase = true;
            this.buttonEx7.Size = new System.Drawing.Size(53, 49);
            this.buttonEx7.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx7.SplitDistance = 0;
            this.buttonEx7.TabIndex = 59;
            this.buttonEx7.Title = "";
            this.buttonEx7.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)), true);
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(209, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(596, 59);
            this.label2.TabIndex = 60;
            this.label2.Text = "【快速导入】按钮说明：将word或Excel文档中的相应列鼠标全选后，\r\n点击【快速导入按钮】，系统将自动识别其内容，注意最多识别三列。\r\n[注意]导入内容中存在" +
                "合并单元格时，将丢失部分信息。";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoFit = true;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.ExportColorToExcel = false;
            this.dgv.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.Footer")));
            this.dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.dgv.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.Header")));
            this.dgv.LoadedFinish = false;
            this.dgv.Location = new System.Drawing.Point(9, 179);
            this.dgv.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeColumnNames")));
            this.dgv.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeRowColumn")));
            this.dgv.Name = "dgv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.RowHeadersWidth = 30;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ShowRowNumber = false;
            this.dgv.Size = new System.Drawing.Size(796, 446);
            this.dgv.TabIndex = 61;
            this.dgv.Title = null;
            this.dgv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv1_KeyUp);
            // 
            // Column0
            // 
            this.Column0.HeaderText = "序号";
            this.Column0.Name = "Column0";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "用户表格配置列1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "用户表格配置列2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "用户表格配置列3";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // FrmModelConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEx7);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FrmModelConfig";
            this.Text = "客户化表格固定项配置";
            this.Load += new System.EventHandler(this.FrmModelConfig_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx btnConfig;
        private CommonViewer.ButtonEx bdNgSave;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtTableName;
        private CommonViewer.ButtonEx btnRapid;
        private CommonViewer.ButtonEx AddButton;
        private CommonViewer.ButtonEx deleteButton;
        private CommonViewer.ButtonEx buttonEx1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private CommonViewer.ButtonEx buttonEx7;
        private System.Windows.Forms.Label label2;
        private CommonViewer.UcDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
