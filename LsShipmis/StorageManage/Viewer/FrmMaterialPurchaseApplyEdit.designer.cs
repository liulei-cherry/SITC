namespace StorageManage.Viewer
{
    partial class FrmMaterialPurchaseApplyEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialPurchaseApplyEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPURCHASE_APPLY_CODE = new CommonViewer.TextBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPURCHASE_APPLY_PERSON = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHEADSHIP_NAME = new CommonViewer.TextBoxEx();
            this.dtpPURCHASE_APPLY_DATE = new CommonViewer.DateTimePickerEx();
            this.txtDEPARTNAME = new CommonViewer.TextBoxEx();
            this.txtSHIP_LEADER_CHECKER = new CommonViewer.TextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSHIP_LEADER_CHECKDATE = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSHIP_BOSS_CHECKER = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSHIP_BOSS_CHECKDATE = new CommonViewer.TextBoxEx();
            this.labShip = new System.Windows.Forms.Label();
            this.txtLANDCHECKER = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCHECKDATE = new CommonViewer.DateTimePickerEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.btnSave = new CommonViewer.ButtonEx();
            this.btnPass = new CommonViewer.ButtonEx();
            this.btnSubmit = new CommonViewer.ButtonEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnDisagree = new CommonViewer.ButtonEx();
            this.btnAgree = new CommonViewer.ButtonEx();
            this.btnDeleteDetail = new CommonViewer.ButtonEx();
            this.btnAddDetail = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvApply = new CommonViewer.UcDataGridView(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "处理单号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(862, 482);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "申请单信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_APPLY_CODE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_APPLY_PERSON, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtREMARK, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtHEADSHIP_NAME, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpPURCHASE_APPLY_DATE, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDEPARTNAME, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_LEADER_CHECKER, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.ucShipSelect1, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_LEADER_CHECKDATE, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_BOSS_CHECKER, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_BOSS_CHECKDATE, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.labShip, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtLANDCHECKER, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpCHECKDATE, 7, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(842, 448);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(199, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 30);
            this.label7.TabIndex = 56;
            this.label7.Text = "船舶*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_APPLY_CODE
            // 
            this.txtPURCHASE_APPLY_CODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_APPLY_CODE.Enabled = false;
            this.txtPURCHASE_APPLY_CODE.Location = new System.Drawing.Point(89, 3);
            this.txtPURCHASE_APPLY_CODE.MaxLength = 50;
            this.txtPURCHASE_APPLY_CODE.Name = "txtPURCHASE_APPLY_CODE";
            this.txtPURCHASE_APPLY_CODE.Size = new System.Drawing.Size(104, 21);
            this.txtPURCHASE_APPLY_CODE.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(611, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "申请人部门";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "申请日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(409, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "申请人岗位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_APPLY_PERSON
            // 
            this.txtPURCHASE_APPLY_PERSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_APPLY_PERSON.Enabled = false;
            this.txtPURCHASE_APPLY_PERSON.Location = new System.Drawing.Point(299, 3);
            this.txtPURCHASE_APPLY_PERSON.MaxLength = 20;
            this.txtPURCHASE_APPLY_PERSON.Name = "txtPURCHASE_APPLY_PERSON";
            this.txtPURCHASE_APPLY_PERSON.Size = new System.Drawing.Size(104, 21);
            this.txtPURCHASE_APPLY_PERSON.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(199, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "申请人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 85);
            this.label4.TabIndex = 1;
            this.label4.Text = "备注";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtREMARK, 7);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Enabled = false;
            this.txtREMARK.Location = new System.Drawing.Point(89, 93);
            this.txtREMARK.MaxLength = 1500;
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.Size = new System.Drawing.Size(750, 79);
            this.txtREMARK.TabIndex = 31;
            this.txtREMARK.TextChanged += new System.EventHandler(this.txtREMARK_TextChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(409, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "部门长确认";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHEADSHIP_NAME
            // 
            this.txtHEADSHIP_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHEADSHIP_NAME.Enabled = false;
            this.txtHEADSHIP_NAME.Location = new System.Drawing.Point(501, 3);
            this.txtHEADSHIP_NAME.MaxLength = 20;
            this.txtHEADSHIP_NAME.Name = "txtHEADSHIP_NAME";
            this.txtHEADSHIP_NAME.Size = new System.Drawing.Size(104, 21);
            this.txtHEADSHIP_NAME.TabIndex = 28;
            // 
            // dtpPURCHASE_APPLY_DATE
            // 
            this.dtpPURCHASE_APPLY_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPURCHASE_APPLY_DATE.Enabled = false;
            this.dtpPURCHASE_APPLY_DATE.Location = new System.Drawing.Point(89, 33);
            this.dtpPURCHASE_APPLY_DATE.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtpPURCHASE_APPLY_DATE.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPURCHASE_APPLY_DATE.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPURCHASE_APPLY_DATE.Name = "dtpPURCHASE_APPLY_DATE";
            this.dtpPURCHASE_APPLY_DATE.ReadOnly = false;
            this.dtpPURCHASE_APPLY_DATE.Size = new System.Drawing.Size(104, 27);
            this.dtpPURCHASE_APPLY_DATE.TabIndex = 53;
            this.dtpPURCHASE_APPLY_DATE.Value = new System.DateTime(((long)(0)));
            this.dtpPURCHASE_APPLY_DATE._ValueChanged += new CommonViewer.DateTimePickerEx.ValueChanged(this.dtpPURCHASE_APPLY_DATE__ValueChanged);
            // 
            // txtDEPARTNAME
            // 
            this.txtDEPARTNAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDEPARTNAME.Enabled = false;
            this.txtDEPARTNAME.Location = new System.Drawing.Point(733, 3);
            this.txtDEPARTNAME.MaxLength = 20;
            this.txtDEPARTNAME.Name = "txtDEPARTNAME";
            this.txtDEPARTNAME.Size = new System.Drawing.Size(106, 21);
            this.txtDEPARTNAME.TabIndex = 28;
            // 
            // txtSHIP_LEADER_CHECKER
            // 
            this.txtSHIP_LEADER_CHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_LEADER_CHECKER.Enabled = false;
            this.txtSHIP_LEADER_CHECKER.Location = new System.Drawing.Point(501, 33);
            this.txtSHIP_LEADER_CHECKER.MaxLength = 20;
            this.txtSHIP_LEADER_CHECKER.Name = "txtSHIP_LEADER_CHECKER";
            this.txtSHIP_LEADER_CHECKER.Size = new System.Drawing.Size(104, 21);
            this.txtSHIP_LEADER_CHECKER.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 8);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 267);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购详细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetail.Enabled = false;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.ExportColorToExcel = false;
            this.dgvDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Footer")));
            this.dgvDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Header")));
            this.dgvDetail.LoadedFinish = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeColumnNames")));
            this.dgvDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeRowColumn")));
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(830, 247);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 102;
            this.ucShipSelect1.Enabled = false;
            this.ucShipSelect1.Location = new System.Drawing.Point(299, 33);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = true;
            this.ucShipSelect1.Size = new System.Drawing.Size(104, 20);
            this.ucShipSelect1.TabIndex = 60;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(611, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 30);
            this.label15.TabIndex = 61;
            this.label15.Text = "部门长确认日期";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSHIP_LEADER_CHECKDATE
            // 
            this.txtSHIP_LEADER_CHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_LEADER_CHECKDATE.Enabled = false;
            this.txtSHIP_LEADER_CHECKDATE.Location = new System.Drawing.Point(733, 33);
            this.txtSHIP_LEADER_CHECKDATE.MaxLength = 20;
            this.txtSHIP_LEADER_CHECKDATE.Name = "txtSHIP_LEADER_CHECKDATE";
            this.txtSHIP_LEADER_CHECKDATE.Size = new System.Drawing.Size(106, 21);
            this.txtSHIP_LEADER_CHECKDATE.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "船长确认";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSHIP_BOSS_CHECKER
            // 
            this.txtSHIP_BOSS_CHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_BOSS_CHECKER.Enabled = false;
            this.txtSHIP_BOSS_CHECKER.Location = new System.Drawing.Point(89, 63);
            this.txtSHIP_BOSS_CHECKER.MaxLength = 20;
            this.txtSHIP_BOSS_CHECKER.Name = "txtSHIP_BOSS_CHECKER";
            this.txtSHIP_BOSS_CHECKER.Size = new System.Drawing.Size(104, 21);
            this.txtSHIP_BOSS_CHECKER.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(199, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 30);
            this.label16.TabIndex = 63;
            this.label16.Text = "船长确认日期";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSHIP_BOSS_CHECKDATE
            // 
            this.txtSHIP_BOSS_CHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_BOSS_CHECKDATE.Enabled = false;
            this.txtSHIP_BOSS_CHECKDATE.Location = new System.Drawing.Point(299, 63);
            this.txtSHIP_BOSS_CHECKDATE.MaxLength = 20;
            this.txtSHIP_BOSS_CHECKDATE.Name = "txtSHIP_BOSS_CHECKDATE";
            this.txtSHIP_BOSS_CHECKDATE.Size = new System.Drawing.Size(104, 21);
            this.txtSHIP_BOSS_CHECKDATE.TabIndex = 64;
            // 
            // labShip
            // 
            this.labShip.AutoSize = true;
            this.labShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labShip.Location = new System.Drawing.Point(409, 60);
            this.labShip.Name = "labShip";
            this.labShip.Size = new System.Drawing.Size(86, 30);
            this.labShip.TabIndex = 49;
            this.labShip.Text = "岸端审核人";
            this.labShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLANDCHECKER
            // 
            this.txtLANDCHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLANDCHECKER.Enabled = false;
            this.txtLANDCHECKER.Location = new System.Drawing.Point(501, 63);
            this.txtLANDCHECKER.MaxLength = 20;
            this.txtLANDCHECKER.Name = "txtLANDCHECKER";
            this.txtLANDCHECKER.Size = new System.Drawing.Size(104, 21);
            this.txtLANDCHECKER.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(611, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 30);
            this.label2.TabIndex = 51;
            this.label2.Text = "岸端确认日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpCHECKDATE
            // 
            this.dtpCHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCHECKDATE.Enabled = false;
            this.dtpCHECKDATE.Location = new System.Drawing.Point(733, 63);
            this.dtpCHECKDATE.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtpCHECKDATE.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCHECKDATE.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCHECKDATE.Name = "dtpCHECKDATE";
            this.dtpCHECKDATE.ReadOnly = false;
            this.dtpCHECKDATE.Size = new System.Drawing.Size(106, 27);
            this.dtpCHECKDATE.TabIndex = 53;
            this.dtpCHECKDATE.Value = new System.DateTime(((long)(0)));
            // 
            // buttonEx6
            // 
            this.buttonEx6.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx6.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx6.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx6.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx6.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx6.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx6.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx6.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx6.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx6.Enabled = false;
            this.buttonEx6.FadingSpeed = 20;
            this.buttonEx6.FlatAppearance.BorderSize = 0;
            this.buttonEx6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx6.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx6.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx6.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx6.Image")));
            this.buttonEx6.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx6.ImageOffset = 3;
            this.buttonEx6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx6.IsPressed = false;
            this.buttonEx6.KeepPress = false;
            this.buttonEx6.Location = new System.Drawing.Point(5, 5);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(207, 46);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "物资采购明细";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FadingSpeed = 20;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSave.ImageOffset = 5;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(294, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(103, 42);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存草稿";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPass.BackColor = System.Drawing.Color.Transparent;
            this.btnPass.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPass.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnPass.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPass.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPass.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPass.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPass.FadingSpeed = 20;
            this.btnPass.FlatAppearance.BorderSize = 0;
            this.btnPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPass.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPass.ImageOffset = 3;
            this.btnPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPass.IsPressed = false;
            this.btnPass.KeepPress = false;
            this.btnPass.Location = new System.Drawing.Point(509, 0);
            this.btnPass.Margin = new System.Windows.Forms.Padding(0);
            this.btnPass.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPass.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPass.Name = "btnPass";
            this.btnPass.Radius = 6;
            this.btnPass.ShowBase = true;
            this.btnPass.Size = new System.Drawing.Size(146, 42);
            this.btnPass.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPass.SplitDistance = 0;
            this.btnPass.TabIndex = 24;
            this.btnPass.Text = "等待订购";
            this.btnPass.Title = "审批完成";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSubmit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSubmit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSubmit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSubmit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSubmit.FadingSpeed = 20;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSubmit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSubmit.ImageOffset = 3;
            this.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSubmit.IsPressed = false;
            this.btnSubmit.KeepPress = false;
            this.btnSubmit.Location = new System.Drawing.Point(397, 0);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubmit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSubmit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 6;
            this.btnSubmit.ShowBase = true;
            this.btnSubmit.Size = new System.Drawing.Size(112, 42);
            this.btnSubmit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSubmit.SplitDistance = 0;
            this.btnSubmit.TabIndex = 24;
            this.btnSubmit.Text = "提交审批";
            this.btnSubmit.Title = "";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(1106, 56);
            this.panel4.TabIndex = 42;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnDisagree);
            this.flowLayoutPanel1.Controls.Add(this.btnAgree);
            this.flowLayoutPanel1.Controls.Add(this.btnPass);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteDetail);
            this.flowLayoutPanel1.Controls.Add(this.btnAddDetail);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(212, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(889, 46);
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
            this.btnClose.Location = new System.Drawing.Point(847, 0);
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
            // btnDisagree
            // 
            this.btnDisagree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisagree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDisagree.BackColor = System.Drawing.Color.Transparent;
            this.btnDisagree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDisagree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDisagree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDisagree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDisagree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDisagree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDisagree.FadingSpeed = 20;
            this.btnDisagree.FlatAppearance.BorderSize = 0;
            this.btnDisagree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisagree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisagree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDisagree.Image = ((System.Drawing.Image)(resources.GetObject("btnDisagree.Image")));
            this.btnDisagree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDisagree.ImageOffset = 3;
            this.btnDisagree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDisagree.IsPressed = false;
            this.btnDisagree.KeepPress = false;
            this.btnDisagree.Location = new System.Drawing.Point(745, 0);
            this.btnDisagree.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisagree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDisagree.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDisagree.Name = "btnDisagree";
            this.btnDisagree.Radius = 6;
            this.btnDisagree.ShowBase = true;
            this.btnDisagree.Size = new System.Drawing.Size(102, 42);
            this.btnDisagree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDisagree.SplitDistance = 0;
            this.btnDisagree.TabIndex = 24;
            this.btnDisagree.Text = "不同意";
            this.btnDisagree.Title = "";
            this.btnDisagree.UseVisualStyleBackColor = true;
            this.btnDisagree.Visible = false;
            this.btnDisagree.Click += new System.EventHandler(this.btnDisagree_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAgree.BackColor = System.Drawing.Color.Transparent;
            this.btnAgree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAgree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAgree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAgree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAgree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAgree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAgree.FadingSpeed = 20;
            this.btnAgree.FlatAppearance.BorderSize = 0;
            this.btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAgree.Image = ((System.Drawing.Image)(resources.GetObject("btnAgree.Image")));
            this.btnAgree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAgree.ImageOffset = 3;
            this.btnAgree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAgree.IsPressed = false;
            this.btnAgree.KeepPress = false;
            this.btnAgree.Location = new System.Drawing.Point(655, 0);
            this.btnAgree.Margin = new System.Windows.Forms.Padding(0);
            this.btnAgree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAgree.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Radius = 6;
            this.btnAgree.ShowBase = true;
            this.btnAgree.Size = new System.Drawing.Size(90, 42);
            this.btnAgree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAgree.SplitDistance = 0;
            this.btnAgree.TabIndex = 24;
            this.btnAgree.Text = "同意";
            this.btnAgree.Title = "";
            this.btnAgree.UseVisualStyleBackColor = true;
            this.btnAgree.Visible = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDeleteDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteDetail.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDeleteDetail.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDeleteDetail.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDeleteDetail.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDeleteDetail.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteDetail.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeleteDetail.FadingSpeed = 20;
            this.btnDeleteDetail.FlatAppearance.BorderSize = 0;
            this.btnDeleteDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteDetail.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDeleteDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDetail.Image")));
            this.btnDeleteDetail.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDeleteDetail.ImageOffset = 2;
            this.btnDeleteDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteDetail.IsPressed = false;
            this.btnDeleteDetail.KeepPress = false;
            this.btnDeleteDetail.Location = new System.Drawing.Point(190, 0);
            this.btnDeleteDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Radius = 6;
            this.btnDeleteDetail.ShowBase = true;
            this.btnDeleteDetail.Size = new System.Drawing.Size(104, 42);
            this.btnDeleteDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDeleteDetail.SplitDistance = 0;
            this.btnDeleteDetail.TabIndex = 38;
            this.btnDeleteDetail.Text = "删除明细";
            this.btnDeleteDetail.Title = "";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Visible = false;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAddDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDetail.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAddDetail.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAddDetail.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddDetail.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddDetail.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddDetail.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddDetail.FadingSpeed = 20;
            this.btnAddDetail.FlatAppearance.BorderSize = 0;
            this.btnAddDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddDetail.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAddDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDetail.Image")));
            this.btnAddDetail.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAddDetail.ImageOffset = 2;
            this.btnAddDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddDetail.IsPressed = false;
            this.btnAddDetail.KeepPress = false;
            this.btnAddDetail.Location = new System.Drawing.Point(86, 0);
            this.btnAddDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Radius = 6;
            this.btnAddDetail.ShowBase = true;
            this.btnAddDetail.Size = new System.Drawing.Size(104, 42);
            this.btnAddDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAddDetail.SplitDistance = 0;
            this.btnAddDetail.TabIndex = 38;
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.Title = "";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Visible = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1106, 482);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 44;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvApply);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 482);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "审核信息列表";
            // 
            // dgvApply
            // 
            this.dgvApply.AllowUserToAddRows = false;
            this.dgvApply.AllowUserToDeleteRows = false;
            this.dgvApply.AllowUserToOrderColumns = true;
            this.dgvApply.AutoFit = true;
            this.dgvApply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApply.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvApply.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApply.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApply.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApply.EnableHeadersVisualStyles = false;
            this.dgvApply.ExportColorToExcel = false;
            this.dgvApply.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.Footer")));
            this.dgvApply.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvApply.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.Header")));
            this.dgvApply.LoadedFinish = false;
            this.dgvApply.Location = new System.Drawing.Point(3, 17);
            this.dgvApply.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.MergeColumnNames")));
            this.dgvApply.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvApply.MergeRowColumn")));
            this.dgvApply.Name = "dgvApply";
            this.dgvApply.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApply.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApply.RowHeadersWidth = 25;
            this.dgvApply.RowTemplate.Height = 23;
            this.dgvApply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApply.ShowRowNumber = true;
            this.dgvApply.Size = new System.Drawing.Size(234, 462);
            this.dgvApply.TabIndex = 12;
            this.dgvApply.Title = "";
            this.dgvApply.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dgvApply_SelectedChanged);
            // 
            // FrmMaterialPurchaseApplyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Name = "FrmMaterialPurchaseApplyEdit";
            this.Text = "物资采购明细";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialPurchaseApplyEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialPurchaseApplyEdit_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtPURCHASE_APPLY_CODE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtPURCHASE_APPLY_PERSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtREMARK;
        private System.Windows.Forms.Label label11;
        private CommonViewer.TextBoxEx txtHEADSHIP_NAME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labShip;
        private CommonViewer.DateTimePickerEx dtpPURCHASE_APPLY_DATE;
        public CommonViewer.ButtonEx buttonEx6;
        public CommonViewer.ButtonEx btnSave;
        public CommonViewer.ButtonEx btnPass;
        public CommonViewer.ButtonEx btnSubmit;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx btnDisagree;
        public CommonViewer.ButtonEx btnAgree;
        private CommonViewer.TextBoxEx txtDEPARTNAME;
        private CommonViewer.TextBoxEx txtSHIP_LEADER_CHECKER;
        private CommonViewer.TextBoxEx txtSHIP_BOSS_CHECKER;
        private CommonViewer.TextBoxEx txtLANDCHECKER;
        private CommonViewer.DateTimePickerEx dtpCHECKDATE;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvDetail;
        private System.Windows.Forms.Label label7;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        public CommonViewer.ButtonEx btnAddDetail;
        public CommonViewer.ButtonEx btnDeleteDetail;
        private System.Windows.Forms.Label label15;
        private CommonViewer.TextBoxEx txtSHIP_LEADER_CHECKDATE;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtSHIP_BOSS_CHECKDATE;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvApply;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
    }
}