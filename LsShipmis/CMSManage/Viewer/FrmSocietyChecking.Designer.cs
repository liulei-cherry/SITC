namespace CMSManage.Viewer
{
    partial class FrmSocietyChecking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSocietyChecking));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpWorkOrderList = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckPlace = new CommonViewer.TextBoxEx();
            this.dtCheckDate = new CommonViewer.DateTimePickerEx();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChecker = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.txtCheckName = new CommonViewer.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCMSWorkOrder = new CommonViewer.UcDataGridView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbx_OnlyNotFinished = new System.Windows.Forms.CheckBox();
            this.btn_NotOk = new System.Windows.Forms.Button();
            this.cbx_AllSociety = new System.Windows.Forms.CheckBox();
            this.btn_sel_null = new System.Windows.Forms.Button();
            this.btn_selAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_save = new CommonViewer.ButtonEx();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.btn_OK = new CommonViewer.ButtonEx();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdsCMSCheck = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.grpWorkOrderList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSWorkOrder)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpWorkOrderList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 571);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // grpWorkOrderList
            // 
            this.grpWorkOrderList.Controls.Add(this.tableLayoutPanel2);
            this.grpWorkOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkOrderList.Location = new System.Drawing.Point(3, 62);
            this.grpWorkOrderList.Name = "grpWorkOrderList";
            this.grpWorkOrderList.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.grpWorkOrderList.Size = new System.Drawing.Size(1112, 506);
            this.grpWorkOrderList.TabIndex = 12;
            this.grpWorkOrderList.TabStop = false;
            this.grpWorkOrderList.Text = "检验项目内容";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.42553F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.57447F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1096, 481);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 176);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.txtDetail, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckPlace, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtCheckDate, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtChecker, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucShipSelect1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckName, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1090, 176);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // txtDetail
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtDetail, 5);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(123, 55);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.tableLayoutPanel3.SetRowSpan(this.txtDetail, 2);
            this.txtDetail.Size = new System.Drawing.Size(964, 118);
            this.txtDetail.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(366, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "检验日期*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(729, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "检验地点";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckPlace
            // 
            this.txtCheckPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckPlace.Location = new System.Drawing.Point(849, 29);
            this.txtCheckPlace.Name = "txtCheckPlace";
            this.txtCheckPlace.Size = new System.Drawing.Size(238, 21);
            this.txtCheckPlace.TabIndex = 8;
            // 
            // dtCheckDate
            // 
            this.dtCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCheckDate.Location = new System.Drawing.Point(486, 29);
            this.dtCheckDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtCheckDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtCheckDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtCheckDate.Name = "dtCheckDate";
            this.dtCheckDate.ReadOnly = false;
            this.dtCheckDate.Size = new System.Drawing.Size(237, 23);
            this.dtCheckDate.TabIndex = 10;
            this.dtCheckDate.Value = new System.DateTime(((long)(0)));
            this.dtCheckDate._ValueChanged += new CommonViewer.DateTimePickerEx.ValueChanged(this.dateTimerPickerEx1__ValueChanged);
            this.dtCheckDate.Enter += new System.EventHandler(this.dtCheckDate_Enter);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "验船师*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChecker
            // 
            this.txtChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChecker.Location = new System.Drawing.Point(123, 29);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.Size = new System.Drawing.Size(237, 21);
            this.txtChecker.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "检验船舶*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(366, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "检验编码*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 192;
            this.ucShipSelect1.Location = new System.Drawing.Point(123, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(237, 20);
            this.ucShipSelect1.TabIndex = 13;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // txtCheckName
            // 
            this.txtCheckName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckName.Location = new System.Drawing.Point(486, 3);
            this.txtCheckName.Name = "txtCheckName";
            this.txtCheckName.ReadOnly = true;
            this.txtCheckName.Size = new System.Drawing.Size(237, 21);
            this.txtCheckName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "检验情况";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCMSWorkOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 263);
            this.panel2.TabIndex = 8;
            // 
            // dgvCMSWorkOrder
            // 
            this.dgvCMSWorkOrder.AllowUserToAddRows = false;
            this.dgvCMSWorkOrder.AllowUserToDeleteRows = false;
            this.dgvCMSWorkOrder.AllowUserToOrderColumns = true;
            this.dgvCMSWorkOrder.AutoFit = true;
            this.dgvCMSWorkOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCMSWorkOrder.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCMSWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCMSWorkOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCMSWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCMSWorkOrder.EnableHeadersVisualStyles = false;
            this.dgvCMSWorkOrder.ExportColorToExcel = false;
            this.dgvCMSWorkOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.Footer")));
            this.dgvCMSWorkOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvCMSWorkOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.Header")));
            this.dgvCMSWorkOrder.LoadedFinish = false;
            this.dgvCMSWorkOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvCMSWorkOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.MergeColumnNames")));
            this.dgvCMSWorkOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.MergeRowColumn")));
            this.dgvCMSWorkOrder.Name = "dgvCMSWorkOrder";
            this.dgvCMSWorkOrder.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSWorkOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCMSWorkOrder.RowHeadersWidth = 25;
            this.dgvCMSWorkOrder.RowTemplate.Height = 23;
            this.dgvCMSWorkOrder.ShowRowNumber = false;
            this.dgvCMSWorkOrder.Size = new System.Drawing.Size(1090, 263);
            this.dgvCMSWorkOrder.TabIndex = 7;
            this.dgvCMSWorkOrder.Title = "";
            this.dgvCMSWorkOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCMSWorkOrder_CellDoubleClick);
            this.dgvCMSWorkOrder.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCMSWorkOrder_CellMouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbx_OnlyNotFinished);
            this.panel4.Controls.Add(this.btn_NotOk);
            this.panel4.Controls.Add(this.cbx_AllSociety);
            this.panel4.Controls.Add(this.btn_sel_null);
            this.panel4.Controls.Add(this.btn_selAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 182);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1096, 30);
            this.panel4.TabIndex = 9;
            // 
            // cbx_OnlyNotFinished
            // 
            this.cbx_OnlyNotFinished.AutoSize = true;
            this.cbx_OnlyNotFinished.Location = new System.Drawing.Point(286, 7);
            this.cbx_OnlyNotFinished.Name = "cbx_OnlyNotFinished";
            this.cbx_OnlyNotFinished.Size = new System.Drawing.Size(84, 16);
            this.cbx_OnlyNotFinished.TabIndex = 55;
            this.cbx_OnlyNotFinished.Text = "屏蔽已完成";
            this.cbx_OnlyNotFinished.UseVisualStyleBackColor = true;
            this.cbx_OnlyNotFinished.CheckedChanged += new System.EventHandler(this.cbx_OnlyNotFinished_CheckedChanged);
            // 
            // btn_NotOk
            // 
            this.btn_NotOk.Location = new System.Drawing.Point(404, 3);
            this.btn_NotOk.Name = "btn_NotOk";
            this.btn_NotOk.Size = new System.Drawing.Size(124, 23);
            this.btn_NotOk.TabIndex = 8;
            this.btn_NotOk.Text = "统一设置缺陷";
            this.btn_NotOk.UseVisualStyleBackColor = true;
            this.btn_NotOk.Click += new System.EventHandler(this.btnNotOk_Click);
            // 
            // cbx_AllSociety
            // 
            this.cbx_AllSociety.AutoSize = true;
            this.cbx_AllSociety.Location = new System.Drawing.Point(136, 8);
            this.cbx_AllSociety.Name = "cbx_AllSociety";
            this.cbx_AllSociety.Size = new System.Drawing.Size(144, 16);
            this.cbx_AllSociety.TabIndex = 52;
            this.cbx_AllSociety.Text = "仅显示船级社检验项目";
            this.cbx_AllSociety.UseVisualStyleBackColor = true;
            this.cbx_AllSociety.CheckedChanged += new System.EventHandler(this.cbx_AllSociety_CheckedChanged);
            // 
            // btn_sel_null
            // 
            this.btn_sel_null.Location = new System.Drawing.Point(65, 4);
            this.btn_sel_null.Name = "btn_sel_null";
            this.btn_sel_null.Size = new System.Drawing.Size(55, 23);
            this.btn_sel_null.TabIndex = 7;
            this.btn_sel_null.Text = "全清";
            this.btn_sel_null.UseVisualStyleBackColor = true;
            this.btn_sel_null.Click += new System.EventHandler(this.btn_sel_null_Click);
            // 
            // btn_selAll
            // 
            this.btn_selAll.Location = new System.Drawing.Point(11, 4);
            this.btn_selAll.Name = "btn_selAll";
            this.btn_selAll.Size = new System.Drawing.Size(55, 23);
            this.btn_selAll.TabIndex = 6;
            this.btn_selAll.Text = "全选";
            this.btn_selAll.UseVisualStyleBackColor = true;
            this.btn_selAll.Click += new System.EventHandler(this.btn_selAll_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.buttonEx2);
            this.panel3.Controls.Add(this.btn_OK);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 53);
            this.panel3.TabIndex = 45;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_save.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_save.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_save.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_save.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_save.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_save.FadingSpeed = 20;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_save.ImageOffset = 5;
            this.btn_save.IsPressed = false;
            this.btn_save.KeepPress = false;
            this.btn_save.Location = new System.Drawing.Point(665, 6);
            this.btn_save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_save.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_save.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Radius = 6;
            this.btn_save.ShowBase = true;
            this.btn_save.Size = new System.Drawing.Size(106, 43);
            this.btn_save.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_save.SplitDistance = 0;
            this.btn_save.TabIndex = 57;
            this.btn_save.Text = "保存草稿";
            this.btn_save.Title = "";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.Enabled = false;
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 2;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(4, 4);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = false;
            this.buttonEx1.Size = new System.Drawing.Size(313, 44);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 47;
            this.buttonEx1.Text = "CMS船级社检验";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // buttonEx2
            // 
            this.buttonEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 5;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(900, 6);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = true;
            this.buttonEx2.Size = new System.Drawing.Size(124, 43);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 56;
            this.buttonEx2.Text = "导出Excel";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            this.buttonEx2.Click += new System.EventHandler(this.buttonEx2_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_OK.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_OK.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_OK.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_OK.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_OK.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_OK.FadingSpeed = 20;
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_OK.Image = ((System.Drawing.Image)(resources.GetObject("btn_OK.Image")));
            this.btn_OK.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_OK.ImageOffset = 1;
            this.btn_OK.IsPressed = false;
            this.btn_OK.KeepPress = false;
            this.btn_OK.Location = new System.Drawing.Point(771, 6);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(0);
            this.btn_OK.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_OK.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Radius = 6;
            this.btn_OK.ShowBase = true;
            this.btn_OK.Size = new System.Drawing.Size(128, 43);
            this.btn_OK.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_OK.SplitDistance = 0;
            this.btn_OK.TabIndex = 53;
            this.btn_OK.Text = "检验完成";
            this.btn_OK.Title = "";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 2;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(1025, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(80, 43);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "关闭";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // FrmSocietyChecking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSocietyChecking";
            this.Text = "CMS船级社检验";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSocietyChecking_FormClosing);
            this.Load += new System.EventHandler(this.FrmSocietyChecking_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpWorkOrderList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSWorkOrder)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpWorkOrderList;
        private System.Windows.Forms.BindingSource bdsCMSCheck;
        private CommonViewer.ButtonEx btnClose;
        private CommonViewer.ButtonEx buttonEx1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtCheckName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtCheckPlace;
        private CommonViewer.DateTimePickerEx dtCheckDate;
        private CommonViewer.TextBoxEx txtDetail;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.UcDataGridView dgvCMSWorkOrder;
        private System.Windows.Forms.CheckBox cbx_AllSociety;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtChecker;
        private CommonViewer.ButtonEx btn_OK;
        private System.Windows.Forms.CheckBox cbx_OnlyNotFinished;
        private CommonViewer.ButtonEx buttonEx2;
        private CommonViewer.ButtonEx btn_save;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_NotOk;
        private System.Windows.Forms.Button btn_sel_null;
        private System.Windows.Forms.Button btn_selAll;
    }
}