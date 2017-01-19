namespace Cost.Viewer
{
    partial class FrmVoucherApproval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoucherApproval));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new CommonViewer.UcDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReverse = new CommonViewer.ButtonEx();
            this.btnSame = new CommonViewer.ButtonEx();
            this.btnCheck = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateYear = new System.Windows.Forms.DateTimePicker();
            this.labyear = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnByFeeSort = new CommonViewer.ButtonEx();
            this.txtContent = new CommonViewer.TextBoxEx();
            this.lnkReverse = new System.Windows.Forms.LinkLabel();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.btnCheckRecode = new CommonViewer.ButtonEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.NullValue = null;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoFit = true;
            this.dgvMain.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvMain.ColumnDeep = 1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ExportColorToExcel = false;
            this.dgvMain.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Footer")));
            this.dgvMain.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMain.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Header")));
            this.dgvMain.LoadedFinish = false;
            this.dgvMain.Location = new System.Drawing.Point(3, 96);
            this.dgvMain.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeColumnNames")));
            this.dgvMain.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeRowColumn")));
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowHeadersWidth = 30;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowRowNumber = true;
            this.dgvMain.Size = new System.Drawing.Size(872, 457);
            this.dgvMain.TabIndex = 53;
            this.dgvMain.Title = "";
            this.dgvMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseClick);
            this.dgvMain.CurrentCellChanged += new System.EventHandler(this.dgvMain_CurrentCellChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnReverse);
            this.panel3.Controls.Add(this.btnSame);
            this.panel3.Controls.Add(this.btnCheck);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 50);
            this.panel3.TabIndex = 50;
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReverse.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnReverse.BackColor = System.Drawing.Color.Transparent;
            this.btnReverse.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnReverse.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnReverse.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnReverse.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnReverse.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReverse.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReverse.FadingSpeed = 20;
            this.btnReverse.FlatAppearance.BorderSize = 0;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.Font = new System.Drawing.Font("宋体", 9F);
            this.btnReverse.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnReverse.ImageOffset = 7;
            this.btnReverse.IsPressed = false;
            this.btnReverse.KeepPress = false;
            this.btnReverse.Location = new System.Drawing.Point(687, 7);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(0);
            this.btnReverse.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnReverse.MenuPos = new System.Drawing.Point(0, 0);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Radius = 6;
            this.btnReverse.ShowBase = true;
            this.btnReverse.Size = new System.Drawing.Size(119, 41);
            this.btnReverse.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnReverse.SplitDistance = 0;
            this.btnReverse.TabIndex = 48;
            this.btnReverse.Text = "上报及审核";
            this.btnReverse.Title = "撤销";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnSame
            // 
            this.btnSame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSame.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSame.BackColor = System.Drawing.Color.Transparent;
            this.btnSame.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSame.FadingSpeed = 20;
            this.btnSame.FlatAppearance.BorderSize = 0;
            this.btnSame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSame.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSame.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSame.Image = ((System.Drawing.Image)(resources.GetObject("btnSame.Image")));
            this.btnSame.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSame.ImageOffset = 7;
            this.btnSame.IsPressed = false;
            this.btnSame.KeepPress = false;
            this.btnSame.Location = new System.Drawing.Point(588, 7);
            this.btnSame.Margin = new System.Windows.Forms.Padding(0);
            this.btnSame.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSame.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSame.Name = "btnSame";
            this.btnSame.Radius = 6;
            this.btnSame.ShowBase = true;
            this.btnSame.Size = new System.Drawing.Size(99, 41);
            this.btnSame.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSame.SplitDistance = 0;
            this.btnSame.TabIndex = 47;
            this.btnSame.Text = "上报SAP";
            this.btnSame.Title = "审核";
            this.btnSame.UseVisualStyleBackColor = true;
            this.btnSame.Click += new System.EventHandler(this.btnSame_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnCheck.ImageOffset = 5;
            this.btnCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheck.IsPressed = false;
            this.btnCheck.KeepPress = false;
            this.btnCheck.Location = new System.Drawing.Point(506, 7);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Radius = 6;
            this.btnCheck.ShowBase = true;
            this.btnCheck.Size = new System.Drawing.Size(82, 41);
            this.btnCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheck.SplitDistance = 0;
            this.btnCheck.TabIndex = 45;
            this.btnCheck.Text = "审批";
            this.btnCheck.Title = "";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
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
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(7, 5);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(203, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "凭证审批";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
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
            this.CloseButton.Location = new System.Drawing.Point(806, 7);
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
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
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
            this.btnBdFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnBdFiles.Image")));
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBdFiles.ImageOffset = 7;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(146, 10);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(85, 26);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 44;
            this.btnBdFiles.Text = "  附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucShipSelect1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbxState);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateYear);
            this.groupBox3.Controls.Add(this.labyear);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(878, 44);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询";
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 102;
            this.ucShipSelect1.Location = new System.Drawing.Point(37, 16);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(130, 20);
            this.ucShipSelect1.TabIndex = 43;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "船舶:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(330, 16);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(100, 20);
            this.cbxState.TabIndex = 41;
            this.cbxState.SelectedIndexChanged += new System.EventHandler(this.dateYear_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(295, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateYear
            // 
            this.dateYear.CustomFormat = "yyyy";
            this.dateYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateYear.Location = new System.Drawing.Point(214, 16);
            this.dateYear.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateYear.Name = "dateYear";
            this.dateYear.ShowUpDown = true;
            this.dateYear.Size = new System.Drawing.Size(60, 21);
            this.dateYear.TabIndex = 35;
            this.dateYear.ValueChanged += new System.EventHandler(this.dateYear_ValueChanged);
            // 
            // labyear
            // 
            this.labyear.AutoSize = true;
            this.labyear.Location = new System.Drawing.Point(192, 20);
            this.labyear.Name = "labyear";
            this.labyear.Size = new System.Drawing.Size(17, 12);
            this.labyear.TabIndex = 34;
            this.labyear.Text = "年";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(884, 662);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnByFeeSort);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.lnkReverse);
            this.groupBox1.Controls.Add(this.lnkClear);
            this.groupBox1.Controls.Add(this.ckbSelectAll);
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Controls.Add(this.btnCheckRecode);
            this.groupBox1.Controls.Add(this.btnBdFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 556);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "凭证列表";
            // 
            // btnByFeeSort
            // 
            this.btnByFeeSort.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnByFeeSort.BackColor = System.Drawing.Color.Transparent;
            this.btnByFeeSort.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnByFeeSort.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnByFeeSort.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnByFeeSort.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnByFeeSort.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnByFeeSort.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnByFeeSort.FadingSpeed = 20;
            this.btnByFeeSort.FlatAppearance.BorderSize = 0;
            this.btnByFeeSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnByFeeSort.Font = new System.Drawing.Font("宋体", 9F);
            this.btnByFeeSort.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnByFeeSort.Image = ((System.Drawing.Image)(resources.GetObject("btnByFeeSort.Image")));
            this.btnByFeeSort.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnByFeeSort.ImageOffset = 5;
            this.btnByFeeSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnByFeeSort.IsPressed = false;
            this.btnByFeeSort.KeepPress = false;
            this.btnByFeeSort.Location = new System.Drawing.Point(320, 10);
            this.btnByFeeSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnByFeeSort.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnByFeeSort.MenuPos = new System.Drawing.Point(0, 0);
            this.btnByFeeSort.Name = "btnByFeeSort";
            this.btnByFeeSort.Radius = 6;
            this.btnByFeeSort.ShowBase = true;
            this.btnByFeeSort.Size = new System.Drawing.Size(85, 26);
            this.btnByFeeSort.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnByFeeSort.SplitDistance = 0;
            this.btnByFeeSort.TabIndex = 57;
            this.btnByFeeSort.Text = "费用排序";
            this.btnByFeeSort.Title = "";
            this.btnByFeeSort.UseVisualStyleBackColor = true;
            this.btnByFeeSort.Click += new System.EventHandler(this.btnByFeeSort_Click);
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(3, 39);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(872, 50);
            this.txtContent.TabIndex = 56;
            // 
            // lnkReverse
            // 
            this.lnkReverse.AutoSize = true;
            this.lnkReverse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkReverse.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkReverse.Location = new System.Drawing.Point(104, 18);
            this.lnkReverse.Name = "lnkReverse";
            this.lnkReverse.Size = new System.Drawing.Size(29, 12);
            this.lnkReverse.TabIndex = 55;
            this.lnkReverse.TabStop = true;
            this.lnkReverse.Text = "反选";
            this.lnkReverse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReverse_LinkClicked);
            // 
            // lnkClear
            // 
            this.lnkClear.AutoSize = true;
            this.lnkClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkClear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkClear.Location = new System.Drawing.Point(63, 18);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(29, 12);
            this.lnkClear.TabIndex = 55;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "全清";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.ForeColor = System.Drawing.Color.Blue;
            this.ckbSelectAll.Location = new System.Drawing.Point(10, 17);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(48, 16);
            this.ckbSelectAll.TabIndex = 54;
            this.ckbSelectAll.Text = "全选";
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // btnCheckRecode
            // 
            this.btnCheckRecode.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCheckRecode.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckRecode.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCheckRecode.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCheckRecode.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCheckRecode.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCheckRecode.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCheckRecode.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCheckRecode.FadingSpeed = 20;
            this.btnCheckRecode.FlatAppearance.BorderSize = 0;
            this.btnCheckRecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckRecode.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCheckRecode.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCheckRecode.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckRecode.Image")));
            this.btnCheckRecode.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCheckRecode.ImageOffset = 5;
            this.btnCheckRecode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheckRecode.IsPressed = false;
            this.btnCheckRecode.KeepPress = false;
            this.btnCheckRecode.Location = new System.Drawing.Point(233, 10);
            this.btnCheckRecode.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheckRecode.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheckRecode.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheckRecode.Name = "btnCheckRecode";
            this.btnCheckRecode.Radius = 6;
            this.btnCheckRecode.ShowBase = true;
            this.btnCheckRecode.Size = new System.Drawing.Size(85, 26);
            this.btnCheckRecode.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheckRecode.SplitDistance = 0;
            this.btnCheckRecode.TabIndex = 45;
            this.btnCheckRecode.Text = "审批记录";
            this.btnCheckRecode.Title = "";
            this.btnCheckRecode.UseVisualStyleBackColor = true;
            this.btnCheckRecode.Click += new System.EventHandler(this.btnCheckRecode_Click);
            // 
            // FrmVoucherApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 662);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FrmVoucherApproval";
            this.Text = "凭证审批";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVoucherApproval_FormClosed);
            this.Load += new System.EventHandler(this.FrmVoucherApproval_Load);
            this.Shown += new System.EventHandler(this.FrmVoucherApproval_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateYear;
        private System.Windows.Forms.Label labyear;
        private CommonViewer.UcDataGridView dgvMain;
        private CommonViewer.ButtonEx btnBdFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label1;
        private CommonViewer.ButtonEx btnReverse;
        private CommonViewer.ButtonEx btnSame;
        public CommonViewer.ButtonEx btnCheck;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private CommonViewer.ButtonEx btnCheckRecode;
        private System.Windows.Forms.LinkLabel lnkReverse;
        private System.Windows.Forms.LinkLabel lnkClear;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtContent;
        private CommonViewer.ButtonEx btnByFeeSort;
    }
}