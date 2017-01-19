namespace StorageManage.Viewer
{
    partial class FrmMaterialPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialPurchaseOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_CODE = new CommonViewer.TextBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_PERSON = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCURRENCYNAME = new CommonViewer.TextBoxEx();
            this.txtSENDDATE = new CommonViewer.TextBoxEx();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.txtMANUFACTURER_NAME = new CommonViewer.TextBoxEx();
            this.txtLANDCHECKER = new CommonViewer.TextBoxEx();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSHIP_NAME = new CommonViewer.TextBoxEx();
            this.txtTOTALPRICE = new CommonViewer.TextBoxEx();
            this.txtPURCHASE_ORDER_DATE = new CommonViewer.TextBoxEx();
            this.txtCHECKDATE = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSENDPORT = new CommonViewer.TextBoxEx();
            this.btnClose = new CommonViewer.ButtonEx();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLandCheck = new CommonViewer.ButtonEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.btn_CheckView = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.btnContinueOrder = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labShip = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChkState = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOrder = new CommonViewer.UcDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(442, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 30);
            this.label9.TabIndex = 58;
            this.label9.Text = "总价";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(442, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 30);
            this.label7.TabIndex = 56;
            this.label7.Text = "船舶";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(216, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "岸端确认日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "处理单号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_CODE
            // 
            this.txtPURCHASE_ORDER_CODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_CODE.Location = new System.Drawing.Point(80, 3);
            this.txtPURCHASE_ORDER_CODE.MaxLength = 3000;
            this.txtPURCHASE_ORDER_CODE.Name = "txtPURCHASE_ORDER_CODE";
            this.txtPURCHASE_ORDER_CODE.ReadOnly = true;
            this.txtPURCHASE_ORDER_CODE.Size = new System.Drawing.Size(130, 21);
            this.txtPURCHASE_ORDER_CODE.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "供应商";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "发起日期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(216, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "货币";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_PERSON
            // 
            this.txtPURCHASE_ORDER_PERSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_PERSON.Location = new System.Drawing.Point(306, 3);
            this.txtPURCHASE_ORDER_PERSON.MaxLength = 3000;
            this.txtPURCHASE_ORDER_PERSON.Name = "txtPURCHASE_ORDER_PERSON";
            this.txtPURCHASE_ORDER_PERSON.ReadOnly = true;
            this.txtPURCHASE_ORDER_PERSON.Size = new System.Drawing.Size(130, 21);
            this.txtPURCHASE_ORDER_PERSON.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(216, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "申请人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 63);
            this.label10.TabIndex = 1;
            this.label10.Text = "备注";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtREMARK, 5);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Location = new System.Drawing.Point(80, 123);
            this.txtREMARK.MaxLength = 1500;
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.ReadOnly = true;
            this.txtREMARK.Size = new System.Drawing.Size(558, 57);
            this.txtREMARK.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(216, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "到货日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCURRENCYNAME
            // 
            this.txtCURRENCYNAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCURRENCYNAME.Location = new System.Drawing.Point(306, 33);
            this.txtCURRENCYNAME.MaxLength = 3000;
            this.txtCURRENCYNAME.Name = "txtCURRENCYNAME";
            this.txtCURRENCYNAME.ReadOnly = true;
            this.txtCURRENCYNAME.Size = new System.Drawing.Size(130, 21);
            this.txtCURRENCYNAME.TabIndex = 28;
            // 
            // txtSENDDATE
            // 
            this.txtSENDDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSENDDATE.Location = new System.Drawing.Point(306, 63);
            this.txtSENDDATE.MaxLength = 3000;
            this.txtSENDDATE.Name = "txtSENDDATE";
            this.txtSENDDATE.ReadOnly = true;
            this.txtSENDDATE.Size = new System.Drawing.Size(130, 21);
            this.txtSENDDATE.TabIndex = 28;
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
            this.dgvDetail.Size = new System.Drawing.Size(629, 204);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 30);
            this.label14.TabIndex = 49;
            this.label14.Text = "岸端审核人";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMANUFACTURER_NAME
            // 
            this.txtMANUFACTURER_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMANUFACTURER_NAME.Location = new System.Drawing.Point(80, 63);
            this.txtMANUFACTURER_NAME.MaxLength = 3000;
            this.txtMANUFACTURER_NAME.Name = "txtMANUFACTURER_NAME";
            this.txtMANUFACTURER_NAME.ReadOnly = true;
            this.txtMANUFACTURER_NAME.Size = new System.Drawing.Size(130, 21);
            this.txtMANUFACTURER_NAME.TabIndex = 28;
            // 
            // txtLANDCHECKER
            // 
            this.txtLANDCHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLANDCHECKER.Location = new System.Drawing.Point(80, 93);
            this.txtLANDCHECKER.MaxLength = 3000;
            this.txtLANDCHECKER.Name = "txtLANDCHECKER";
            this.txtLANDCHECKER.ReadOnly = true;
            this.txtLANDCHECKER.Size = new System.Drawing.Size(130, 21);
            this.txtLANDCHECKER.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox4, 6);
            this.groupBox4.Controls.Add(this.dgvDetail);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 186);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 224);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "订单详细";
            // 
            // txtSHIP_NAME
            // 
            this.txtSHIP_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHIP_NAME.Location = new System.Drawing.Point(507, 3);
            this.txtSHIP_NAME.MaxLength = 3000;
            this.txtSHIP_NAME.Name = "txtSHIP_NAME";
            this.txtSHIP_NAME.ReadOnly = true;
            this.txtSHIP_NAME.Size = new System.Drawing.Size(131, 21);
            this.txtSHIP_NAME.TabIndex = 28;
            // 
            // txtTOTALPRICE
            // 
            this.txtTOTALPRICE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTOTALPRICE.Location = new System.Drawing.Point(507, 33);
            this.txtTOTALPRICE.MaxLength = 3000;
            this.txtTOTALPRICE.Name = "txtTOTALPRICE";
            this.txtTOTALPRICE.ReadOnly = true;
            this.txtTOTALPRICE.Size = new System.Drawing.Size(131, 21);
            this.txtTOTALPRICE.TabIndex = 28;
            // 
            // txtPURCHASE_ORDER_DATE
            // 
            this.txtPURCHASE_ORDER_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_DATE.Location = new System.Drawing.Point(80, 33);
            this.txtPURCHASE_ORDER_DATE.MaxLength = 3000;
            this.txtPURCHASE_ORDER_DATE.Name = "txtPURCHASE_ORDER_DATE";
            this.txtPURCHASE_ORDER_DATE.ReadOnly = true;
            this.txtPURCHASE_ORDER_DATE.Size = new System.Drawing.Size(130, 21);
            this.txtPURCHASE_ORDER_DATE.TabIndex = 21;
            // 
            // txtCHECKDATE
            // 
            this.txtCHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCHECKDATE.Location = new System.Drawing.Point(306, 93);
            this.txtCHECKDATE.MaxLength = 3000;
            this.txtCHECKDATE.Name = "txtCHECKDATE";
            this.txtCHECKDATE.ReadOnly = true;
            this.txtCHECKDATE.Size = new System.Drawing.Size(130, 21);
            this.txtCHECKDATE.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_CODE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_PERSON, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtREMARK, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCURRENCYNAME, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtMANUFACTURER_NAME, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSENDDATE, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtLANDCHECKER, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtSHIP_NAME, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTOTALPRICE, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_DATE, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCHECKDATE, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label15, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSENDPORT, 5, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(641, 413);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(442, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 30);
            this.label15.TabIndex = 49;
            this.label15.Text = "送货港口";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSENDPORT
            // 
            this.txtSENDPORT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSENDPORT.Location = new System.Drawing.Point(507, 63);
            this.txtSENDPORT.MaxLength = 3000;
            this.txtSENDPORT.Name = "txtSENDPORT";
            this.txtSENDPORT.ReadOnly = true;
            this.txtSENDPORT.Size = new System.Drawing.Size(131, 21);
            this.txtSENDPORT.TabIndex = 28;
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
            this.btnClose.Location = new System.Drawing.Point(941, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 1;
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
            this.bdNgDeleteItem.Enabled = false;
            this.bdNgDeleteItem.FadingSpeed = 20;
            this.bdNgDeleteItem.FlatAppearance.BorderSize = 0;
            this.bdNgDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgDeleteItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgDeleteItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.Center;
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgDeleteItem.ImageOffset = 2;
            this.bdNgDeleteItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgDeleteItem.IsPressed = false;
            this.bdNgDeleteItem.KeepPress = false;
            this.bdNgDeleteItem.Location = new System.Drawing.Point(493, 0);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(36, 36);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 36;
            this.bdNgDeleteItem.Title = "";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(661, 447);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "订单信息";
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
            this.btnLandCheck.Location = new System.Drawing.Point(624, 0);
            this.btnLandCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnLandCheck.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnLandCheck.MenuPos = new System.Drawing.Point(0, 0);
            this.btnLandCheck.Name = "btnLandCheck";
            this.btnLandCheck.Radius = 10;
            this.btnLandCheck.ShowBase = true;
            this.btnLandCheck.Size = new System.Drawing.Size(95, 36);
            this.btnLandCheck.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnLandCheck.SplitDistance = 0;
            this.btnLandCheck.TabIndex = 29;
            this.btnLandCheck.Text = "多项审批";
            this.btnLandCheck.Title = "";
            this.btnLandCheck.UseVisualStyleBackColor = true;
            this.btnLandCheck.Click += new System.EventHandler(this.btnLandCheck_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnBdFiles);
            this.flowLayoutPanel2.Controls.Add(this.btn_CheckView);
            this.flowLayoutPanel2.Controls.Add(this.btnLandCheck);
            this.flowLayoutPanel2.Controls.Add(this.bdNgEditItem);
            this.flowLayoutPanel2.Controls.Add(this.bdNgDeleteItem);
            this.flowLayoutPanel2.Controls.Add(this.bdNgAddNewItem);
            this.flowLayoutPanel2.Controls.Add(this.btnContinueOrder);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(183, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(977, 39);
            this.flowLayoutPanel2.TabIndex = 42;
            // 
            // btnBdFiles
            // 
            this.btnBdFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnBdFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBdFiles.GroupPos = CommonViewer.ButtonEx.e_groupPos.Right;
            this.btnBdFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnBdFiles.Image")));
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBdFiles.ImageOffset = 4;
            this.btnBdFiles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(846, 0);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 10;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(95, 36);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 40;
            this.btnBdFiles.Text = "关联附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // btn_CheckView
            // 
            this.btn_CheckView.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_CheckView.BackColor = System.Drawing.Color.Transparent;
            this.btn_CheckView.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_CheckView.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btn_CheckView.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_CheckView.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_CheckView.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_CheckView.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_CheckView.Enabled = false;
            this.btn_CheckView.FadingSpeed = 20;
            this.btn_CheckView.FlatAppearance.BorderSize = 0;
            this.btn_CheckView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_CheckView.GroupPos = CommonViewer.ButtonEx.e_groupPos.Right;
            this.btn_CheckView.Image = ((System.Drawing.Image)(resources.GetObject("btn_CheckView.Image")));
            this.btn_CheckView.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_CheckView.ImageOffset = 3;
            this.btn_CheckView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_CheckView.IsPressed = false;
            this.btn_CheckView.KeepPress = false;
            this.btn_CheckView.Location = new System.Drawing.Point(719, 0);
            this.btn_CheckView.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CheckView.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_CheckView.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_CheckView.Name = "btn_CheckView";
            this.btn_CheckView.Radius = 6;
            this.btn_CheckView.ShowBase = true;
            this.btn_CheckView.Size = new System.Drawing.Size(127, 36);
            this.btn_CheckView.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_CheckView.SplitDistance = 0;
            this.btn_CheckView.TabIndex = 41;
            this.btn_CheckView.Text = "审批记录查看";
            this.btn_CheckView.Title = "";
            this.btn_CheckView.UseVisualStyleBackColor = true;
            this.btn_CheckView.Click += new System.EventHandler(this.btn_CheckView_Click);
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
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.Center;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 5;
            this.bdNgEditItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(529, 0);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(95, 36);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 38;
            this.bdNgEditItem.Text = "单项审批";
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
            this.bdNgAddNewItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.Left;
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgAddNewItem.ImageOffset = 2;
            this.bdNgAddNewItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgAddNewItem.IsPressed = false;
            this.bdNgAddNewItem.KeepPress = false;
            this.bdNgAddNewItem.Location = new System.Drawing.Point(457, 0);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 10;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(36, 36);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 37;
            this.bdNgAddNewItem.Title = "";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // btnContinueOrder
            // 
            this.btnContinueOrder.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnContinueOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnContinueOrder.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnContinueOrder.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnContinueOrder.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnContinueOrder.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnContinueOrder.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnContinueOrder.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContinueOrder.Enabled = false;
            this.btnContinueOrder.FadingSpeed = 20;
            this.btnContinueOrder.FlatAppearance.BorderSize = 0;
            this.btnContinueOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinueOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnContinueOrder.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnContinueOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnContinueOrder.Image")));
            this.btnContinueOrder.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnContinueOrder.ImageOffset = 3;
            this.btnContinueOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContinueOrder.IsPressed = false;
            this.btnContinueOrder.KeepPress = false;
            this.btnContinueOrder.Location = new System.Drawing.Point(322, 0);
            this.btnContinueOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnContinueOrder.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnContinueOrder.MenuPos = new System.Drawing.Point(0, 0);
            this.btnContinueOrder.Name = "btnContinueOrder";
            this.btnContinueOrder.Radius = 10;
            this.btnContinueOrder.ShowBase = true;
            this.btnContinueOrder.Size = new System.Drawing.Size(135, 36);
            this.btnContinueOrder.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnContinueOrder.SplitDistance = 0;
            this.btnContinueOrder.TabIndex = 39;
            this.btnContinueOrder.Text = "继续未完成订购";
            this.btnContinueOrder.Title = "";
            this.btnContinueOrder.UseVisualStyleBackColor = true;
            this.btnContinueOrder.Click += new System.EventHandler(this.btnContinueOrder_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1166, 562);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.panel4.Size = new System.Drawing.Size(1166, 51);
            this.panel4.TabIndex = 11;
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
            this.buttonEx2.Size = new System.Drawing.Size(177, 39);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "物资采购订单";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1160, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labShip);
            this.flowLayoutPanel1.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cboChkState);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1154, 32);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 0);
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
            this.cboChkState.Location = new System.Drawing.Point(250, 3);
            this.cboChkState.Name = "cboChkState";
            this.cboChkState.Size = new System.Drawing.Size(182, 20);
            this.cboChkState.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 112);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 447);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOrder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(495, 447);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单列表";
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToOrderColumns = true;
            this.dgvOrder.AutoFit = true;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOrder.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.EnableHeadersVisualStyles = false;
            this.dgvOrder.ExportColorToExcel = false;
            this.dgvOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.Footer")));
            this.dgvOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.Header")));
            this.dgvOrder.LoadedFinish = false;
            this.dgvOrder.Location = new System.Drawing.Point(8, 17);
            this.dgvOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.MergeColumnNames")));
            this.dgvOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOrder.MergeRowColumn")));
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrder.RowHeadersWidth = 25;
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.ShowRowNumber = true;
            this.dgvOrder.Size = new System.Drawing.Size(479, 422);
            this.dgvOrder.TabIndex = 11;
            this.dgvOrder.Title = "";
            this.dgvOrder.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dgvOrder_SelectedChanged);
            this.dgvOrder.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrder_CellMouseDoubleClick);
            // 
            // FrmMaterialPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaterialPurchaseOrder";
            this.Text = "物资采购订单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialPurchaseOrder_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_CODE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_PERSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtREMARK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label11;
        private CommonViewer.TextBoxEx txtCURRENCYNAME;
        private System.Windows.Forms.Label label14;
        private CommonViewer.TextBoxEx txtMANUFACTURER_NAME;
        private CommonViewer.TextBoxEx txtSENDDATE;
        private CommonViewer.TextBoxEx txtLANDCHECKER;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.UcDataGridView dgvDetail;
        private CommonViewer.TextBoxEx txtSHIP_NAME;
        private CommonViewer.TextBoxEx txtTOTALPRICE;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_DATE;
        private CommonViewer.TextBoxEx txtCHECKDATE;
        protected CommonViewer.ButtonEx btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        public CommonViewer.ButtonEx btnLandCheck;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public CommonViewer.ButtonEx bdNgDeleteItem;
        public CommonViewer.ButtonEx bdNgEditItem;
        public CommonViewer.ButtonEx bdNgAddNewItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx buttonEx2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labShip;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChkState;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvOrder;
        private System.Windows.Forms.Label label15;
        private CommonViewer.TextBoxEx txtSENDPORT;
        public CommonViewer.ButtonEx btnContinueOrder;
        public CommonViewer.ButtonEx btnBdFiles;
        public CommonViewer.ButtonEx btn_CheckView;
    }
}