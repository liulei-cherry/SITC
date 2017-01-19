namespace Maintenance.Viewer
{
    partial class FrmWorkOrderTempAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkOrderTempAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboConfirmPost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPlanExeDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsCheckProject = new System.Windows.Forms.CheckBox();
            this.chkIsRepairProject = new System.Windows.Forms.CheckBox();
            this.txtWorkDescription = new CommonViewer.TextBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWorkOrderName = new CommonViewer.TextBoxEx();
            this.cboPrincipalPost = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtWorkCompletedInfo = new CommonViewer.TextBoxEx();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工单名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(42, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "责任人岗位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboConfirmPost
            // 
            this.cboConfirmPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConfirmPost.FormattingEnabled = true;
            this.cboConfirmPost.Location = new System.Drawing.Point(374, 168);
            this.cboConfirmPost.Name = "cboConfirmPost";
            this.cboConfirmPost.Size = new System.Drawing.Size(130, 20);
            this.cboConfirmPost.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(286, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "确认人岗位";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpPlanExeDate
            // 
            this.dtpPlanExeDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPlanExeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanExeDate.Location = new System.Drawing.Point(130, 204);
            this.dtpPlanExeDate.Name = "dtpPlanExeDate";
            this.dtpPlanExeDate.Size = new System.Drawing.Size(130, 21);
            this.dtpPlanExeDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "预计执行日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsCheckProject
            // 
            this.chkIsCheckProject.Location = new System.Drawing.Point(300, 205);
            this.chkIsCheckProject.Name = "chkIsCheckProject";
            this.chkIsCheckProject.Size = new System.Drawing.Size(87, 23);
            this.chkIsCheckProject.TabIndex = 5;
            this.chkIsCheckProject.Text = "检验项目";
            this.chkIsCheckProject.UseVisualStyleBackColor = true;
            // 
            // chkIsRepairProject
            // 
            this.chkIsRepairProject.Location = new System.Drawing.Point(393, 206);
            this.chkIsRepairProject.Name = "chkIsRepairProject";
            this.chkIsRepairProject.Size = new System.Drawing.Size(85, 23);
            this.chkIsRepairProject.TabIndex = 6;
            this.chkIsRepairProject.Text = "修理项目";
            this.chkIsRepairProject.UseVisualStyleBackColor = true;
            // 
            // txtWorkDescription
            // 
            this.txtWorkDescription.Location = new System.Drawing.Point(130, 235);
            this.txtWorkDescription.MaxLength = 1000;
            this.txtWorkDescription.Multiline = true;
            this.txtWorkDescription.Name = "txtWorkDescription";
            this.txtWorkDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkDescription.Size = new System.Drawing.Size(374, 148);
            this.txtWorkDescription.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(44, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "工单内容";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkOrderName
            // 
            this.txtWorkOrderName.Location = new System.Drawing.Point(130, 133);
            this.txtWorkOrderName.MaxLength = 400;
            this.txtWorkOrderName.Name = "txtWorkOrderName";
            this.txtWorkOrderName.Size = new System.Drawing.Size(374, 21);
            this.txtWorkOrderName.TabIndex = 0;
            // 
            // cboPrincipalPost
            // 
            this.cboPrincipalPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrincipalPost.Enabled = false;
            this.cboPrincipalPost.FormattingEnabled = true;
            this.cboPrincipalPost.Location = new System.Drawing.Point(130, 170);
            this.cboPrincipalPost.Name = "cboPrincipalPost";
            this.cboPrincipalPost.Size = new System.Drawing.Size(130, 20);
            this.cboPrincipalPost.TabIndex = 2;
            this.cboPrincipalPost.SelectedIndexChanged += new System.EventHandler(this.cboPrincipalPost_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.buttonEx5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 106);
            this.panel1.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(109, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 40);
            this.label4.TabIndex = 32;
            this.label4.Text = "选择\'直接完工\'相当于事后为自己填写工单,请填写\'工单完成情况说明\'.\r\n不选择\'直接完工\'则属于工单安排,需要指定责任人岗位和预计完工日期.\r\n\r\n";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(166, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "直接完工";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSave.ImageOffset = 2;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(333, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(111, 44);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "确认操作";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(444, 12);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(100, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Text = "取消操作";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.btnClose_Click);
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
            this.buttonEx5.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(9, 8);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(144, 53);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 27;
            this.buttonEx5.Text = "添加临时工单";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(18, 389);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 69);
            this.label16.TabIndex = 54;
            this.label16.Text = "工单完成情况说明";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkCompletedInfo
            // 
            this.txtWorkCompletedInfo.Location = new System.Drawing.Point(130, 389);
            this.txtWorkCompletedInfo.MaxLength = 1000;
            this.txtWorkCompletedInfo.Multiline = true;
            this.txtWorkCompletedInfo.Name = "txtWorkCompletedInfo";
            this.txtWorkCompletedInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkCompletedInfo.Size = new System.Drawing.Size(374, 143);
            this.txtWorkCompletedInfo.TabIndex = 55;
            // 
            // FrmWorkOrderTempAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(547, 544);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtWorkCompletedInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtWorkDescription);
            this.Controls.Add(this.chkIsRepairProject);
            this.Controls.Add(this.chkIsCheckProject);
            this.Controls.Add(this.dtpPlanExeDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPrincipalPost);
            this.Controls.Add(this.cboConfirmPost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtWorkOrderName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkOrderTempAdd";
            this.Text = "增加临时工单";
            this.Load += new System.EventHandler(this.FrmWorkOrderTempAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonViewer.TextBoxEx txtWorkOrderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboConfirmPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPlanExeDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsCheckProject;
        private System.Windows.Forms.CheckBox chkIsRepairProject;
        private CommonViewer.TextBoxEx txtWorkDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPrincipalPost;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.ButtonEx btnSave;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtWorkCompletedInfo;
    }
}