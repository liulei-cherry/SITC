namespace ShipCertification.Viewer
{
    partial class UcShipCertRegister
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要.
        /// 使用代码编辑器修改此方法的内容。.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSortNo = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbShip = new System.Windows.Forms.Label();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.dtBegin = new CommonViewer.DateTimePickerEx();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboShipCertType = new System.Windows.Forms.ComboBox();
            this.ucShipCertDepartSelect1 = new ShipCertification.PlugIn.UcShipCertDepartSelect();
            this.ucShipCertSelect1 = new ShipCertification.PlugIn.UcShipCertSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlertDays = new CommonViewer.TextBoxEx();
            this.txtEffectDate = new CommonViewer.TextBoxEx();
            this.labelAlterDays = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dtEnd = new CommonViewer.DateTimePickerEx();
            this.label6 = new System.Windows.Forms.Label();
            this.dtOverDue = new CommonViewer.DateTimePickerEx();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCertCode = new CommonViewer.TextBoxEx();
            this.txtCertName = new CommonViewer.TextBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbChange = new System.Windows.Forms.RadioButton();
            this.rbStamp = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPlace = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtSortNo, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbShip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDetail, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.dtBegin, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ucShipSelect1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboShipCertType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ucShipCertDepartSelect1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ucShipCertSelect1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAlertDays, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtEffectDate, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelAlterDays, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelEnd, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtEnd, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtOverDue, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCertCode, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCertName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPlace, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(527, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtSortNo
            // 
            this.txtSortNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSortNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSortNo.Font = new System.Drawing.Font("宋体", 9F);
            this.txtSortNo.Location = new System.Drawing.Point(359, 205);
            this.txtSortNo.Multiline = true;
            this.txtSortNo.Name = "txtSortNo";
            this.txtSortNo.Size = new System.Drawing.Size(165, 20);
            this.txtSortNo.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(275, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 26);
            this.label11.TabIndex = 48;
            this.label11.Text = "打印排序";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(3, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "待检|检验状态";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.Location = new System.Drawing.Point(3, 231);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label12.Size = new System.Drawing.Size(96, 81);
            this.label12.TabIndex = 24;
            this.label12.Text = "备注";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(3, 153);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "签发日期*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbShip
            // 
            this.lbShip.BackColor = System.Drawing.Color.Transparent;
            this.lbShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShip.Font = new System.Drawing.Font("宋体", 9F);
            this.lbShip.Location = new System.Drawing.Point(3, 3);
            this.lbShip.Margin = new System.Windows.Forms.Padding(3);
            this.lbShip.Name = "lbShip";
            this.lbShip.Size = new System.Drawing.Size(96, 20);
            this.lbShip.TabIndex = 0;
            this.lbShip.Text = "船舶*";
            this.lbShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDetail
            // 
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDetail, 3);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Font = new System.Drawing.Font("宋体", 9F);
            this.txtDetail.Location = new System.Drawing.Point(105, 231);
            this.txtDetail.MaxLength = 100;
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(419, 81);
            this.txtDetail.TabIndex = 13;
            // 
            // dtBegin
            // 
            this.dtBegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtBegin.Font = new System.Drawing.Font("宋体", 9F);
            this.dtBegin.Location = new System.Drawing.Point(105, 153);
            this.dtBegin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtBegin.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtBegin.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.ReadOnly = false;
            this.dtBegin.Size = new System.Drawing.Size(164, 23);
            this.dtBegin.TabIndex = 27;
            this.dtBegin.Value = new System.DateTime(((long)(0)));
            this.dtBegin._ValueChanged += new CommonViewer.DateTimePickerEx.ValueChanged(this.txtEffectDate_TextChanged);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.BackColor = System.Drawing.Color.Transparent;
            this.ucShipSelect1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 107;
            this.ucShipSelect1.Location = new System.Drawing.Point(105, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(164, 20);
            this.ucShipSelect1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 26);
            this.label4.TabIndex = 36;
            this.label4.Text = "有效期种类*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 26);
            this.label5.TabIndex = 40;
            this.label5.Text = "证书类型";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 40;
            this.label3.Text = "主管机关";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(275, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "证书号码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboShipCertType
            // 
            this.cboShipCertType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShipCertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipCertType.FormattingEnabled = true;
            this.cboShipCertType.Location = new System.Drawing.Point(105, 101);
            this.cboShipCertType.Name = "cboShipCertType";
            this.cboShipCertType.Size = new System.Drawing.Size(164, 20);
            this.cboShipCertType.TabIndex = 41;
            this.cboShipCertType.SelectedIndexChanged += new System.EventHandler(this.cboShipCertType_SelectedIndexChanged);
            // 
            // ucShipCertDepartSelect1
            // 
            this.ucShipCertDepartSelect1.CanEdit = true;
            this.ucShipCertDepartSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipCertDepartSelect1.DropDownWidth = 110;
            this.ucShipCertDepartSelect1.Location = new System.Drawing.Point(105, 127);
            this.ucShipCertDepartSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipCertDepartSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipCertDepartSelect1.Name = "ucShipCertDepartSelect1";
            this.ucShipCertDepartSelect1.NullValueShow = "未知";
            this.ucShipCertDepartSelect1.ShowButton = true;
            this.ucShipCertDepartSelect1.Size = new System.Drawing.Size(164, 20);
            this.ucShipCertDepartSelect1.TabIndex = 42;
            // 
            // ucShipCertSelect1
            // 
            this.ucShipCertSelect1.CanEdit = true;
            this.ucShipCertSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipCertSelect1.DropDownWidth = 158;
            this.ucShipCertSelect1.Location = new System.Drawing.Point(105, 29);
            this.ucShipCertSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipCertSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipCertSelect1.Name = "ucShipCertSelect1";
            this.ucShipCertSelect1.NullValueShow = "其他证书";
            this.ucShipCertSelect1.ShowButton = false;
            this.ucShipCertSelect1.Size = new System.Drawing.Size(164, 20);
            this.ucShipCertSelect1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(275, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 37;
            this.label1.Text = " 报警天数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertDays
            // 
            this.txtAlertDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAlertDays.Font = new System.Drawing.Font("宋体", 9F);
            this.txtAlertDays.Location = new System.Drawing.Point(359, 179);
            this.txtAlertDays.Multiline = true;
            this.txtAlertDays.Name = "txtAlertDays";
            this.txtAlertDays.Size = new System.Drawing.Size(165, 20);
            this.txtAlertDays.TabIndex = 39;
            // 
            // txtEffectDate
            // 
            this.txtEffectDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEffectDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEffectDate.Font = new System.Drawing.Font("宋体", 9F);
            this.txtEffectDate.Location = new System.Drawing.Point(359, 101);
            this.txtEffectDate.Multiline = true;
            this.txtEffectDate.Name = "txtEffectDate";
            this.txtEffectDate.Size = new System.Drawing.Size(165, 20);
            this.txtEffectDate.TabIndex = 39;
            this.txtEffectDate.TextChanged += new System.EventHandler(this.txtEffectDate_TextChanged);
            // 
            // labelAlterDays
            // 
            this.labelAlterDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlterDays.Location = new System.Drawing.Point(275, 98);
            this.labelAlterDays.Name = "labelAlterDays";
            this.labelAlterDays.Size = new System.Drawing.Size(78, 26);
            this.labelAlterDays.TabIndex = 37;
            this.labelAlterDays.Text = "有效期(年)";
            this.labelAlterDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEnd
            // 
            this.labelEnd.BackColor = System.Drawing.Color.Transparent;
            this.labelEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEnd.Font = new System.Drawing.Font("宋体", 9F);
            this.labelEnd.Location = new System.Drawing.Point(3, 179);
            this.labelEnd.Margin = new System.Windows.Forms.Padding(3);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(96, 20);
            this.labelEnd.TabIndex = 26;
            this.labelEnd.Text = "待检|检验日期";
            this.labelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtEnd
            // 
            this.dtEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtEnd.Font = new System.Drawing.Font("宋体", 9F);
            this.dtEnd.Location = new System.Drawing.Point(105, 179);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtEnd.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtEnd.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ReadOnly = false;
            this.dtEnd.Size = new System.Drawing.Size(164, 23);
            this.dtEnd.TabIndex = 28;
            this.dtEnd.Value = new System.DateTime(((long)(0)));
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(275, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "到期日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtOverDue
            // 
            this.dtOverDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtOverDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOverDue.Font = new System.Drawing.Font("宋体", 9F);
            this.dtOverDue.Location = new System.Drawing.Point(359, 153);
            this.dtOverDue.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtOverDue.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtOverDue.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtOverDue.Name = "dtOverDue";
            this.dtOverDue.ReadOnly = false;
            this.dtOverDue.Size = new System.Drawing.Size(165, 23);
            this.dtOverDue.TabIndex = 28;
            this.dtOverDue.Value = new System.DateTime(((long)(0)));
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 46);
            this.label8.TabIndex = 40;
            this.label8.Text = "证书名称*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCertCode
            // 
            this.txtCertCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCertCode.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCertCode.Location = new System.Drawing.Point(359, 29);
            this.txtCertCode.Multiline = true;
            this.txtCertCode.Name = "txtCertCode";
            this.txtCertCode.Size = new System.Drawing.Size(165, 20);
            this.txtCertCode.TabIndex = 2;
            // 
            // txtCertName
            // 
            this.txtCertName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCertName, 2);
            this.txtCertName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCertName.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCertName.Location = new System.Drawing.Point(105, 55);
            this.txtCertName.Multiline = true;
            this.txtCertName.Name = "txtCertName";
            this.txtCertName.Size = new System.Drawing.Size(248, 40);
            this.txtCertName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(359, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 46);
            this.label10.TabIndex = 40;
            this.label10.Text = "证书打印时使用此名称";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbChange);
            this.panel1.Controls.Add(this.rbStamp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(102, 202);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 26);
            this.panel1.TabIndex = 47;
            // 
            // rbChange
            // 
            this.rbChange.AutoSize = true;
            this.rbChange.Location = new System.Drawing.Point(3, 5);
            this.rbChange.Name = "rbChange";
            this.rbChange.Size = new System.Drawing.Size(47, 16);
            this.rbChange.TabIndex = 46;
            this.rbChange.TabStop = true;
            this.rbChange.Text = "换发";
            this.rbChange.UseVisualStyleBackColor = true;
            // 
            // rbStamp
            // 
            this.rbStamp.AutoSize = true;
            this.rbStamp.Location = new System.Drawing.Point(91, 5);
            this.rbStamp.Name = "rbStamp";
            this.rbStamp.Size = new System.Drawing.Size(59, 16);
            this.rbStamp.TabIndex = 45;
            this.rbStamp.TabStop = true;
            this.rbStamp.Text = "仅签章";
            this.rbStamp.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.Location = new System.Drawing.Point(275, 127);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "发证地点";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlace
            // 
            this.txtPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlace.Font = new System.Drawing.Font("宋体", 9F);
            this.txtPlace.Location = new System.Drawing.Point(359, 127);
            this.txtPlace.Multiline = true;
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(165, 20);
            this.txtPlace.TabIndex = 2;
            // 
            // UcShipCertRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcShipCertRegister";
            this.Size = new System.Drawing.Size(527, 315);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbShip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private CommonViewer.TextBoxEx txtCertCode;
        private CommonViewer.TextBoxEx txtDetail;
        private System.Windows.Forms.Label labelEnd;
        private CommonViewer.DateTimePickerEx dtBegin;
        private CommonViewer.DateTimePickerEx dtEnd;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAlterDays;
        private CommonViewer.TextBoxEx txtAlertDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private ShipCertification.PlugIn.UcShipCertDepartSelect ucShipCertDepartSelect1;
        private ShipCertification.PlugIn.UcShipCertSelect ucShipCertSelect1;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtEffectDate;
        private System.Windows.Forms.Label label6;
        private CommonViewer.DateTimePickerEx dtOverDue;
        private System.Windows.Forms.RadioButton rbChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbStamp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboShipCertType;
        private CommonViewer.TextBoxEx txtCertName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.TextBoxEx txtSortNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private CommonViewer.TextBoxEx txtPlace;
    }
}
