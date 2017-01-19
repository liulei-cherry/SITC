namespace CMSManage.Viewer
{
    partial class UcCMSConfig
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCMSConfigName = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCMSCode = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWorkInfo = new CommonViewer.TextBoxEx();
            this.btn_workInfoSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.txtSortNo = new CommonViewer.TextBoxEx();
            this.txtCHECKENGLISHNAME = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCMSConfigName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCMSCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtRemark, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucShipSelect1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSortNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCHECKENGLISHNAME, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(3, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 30);
            this.label7.TabIndex = 19;
            this.label7.Text = "检验项目(英文)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 30);
            this.label4.TabIndex = 18;
            this.label4.Text = "检验序号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "检验项目(中文)*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCMSConfigName
            // 
            this.txtCMSConfigName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCMSConfigName.Location = new System.Drawing.Point(117, 63);
            this.txtCMSConfigName.Name = "txtCMSConfigName";
            this.txtCMSConfigName.Size = new System.Drawing.Size(317, 21);
            this.txtCMSConfigName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "检验代码*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCMSCode
            // 
            this.txtCMSCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCMSCode.Location = new System.Drawing.Point(117, 123);
            this.txtCMSCode.Name = "txtCMSCode";
            this.txtCMSCode.Size = new System.Drawing.Size(317, 21);
            this.txtCMSCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "关联工作信息";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 53);
            this.label5.TabIndex = 13;
            this.label5.Text = "检验内容";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(117, 183);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.tableLayoutPanel1.SetRowSpan(this.txtRemark, 2);
            this.txtRemark.Size = new System.Drawing.Size(317, 211);
            this.txtRemark.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtWorkInfo);
            this.panel1.Controls.Add(this.btn_workInfoSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(117, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 24);
            this.panel1.TabIndex = 15;
            // 
            // txtWorkInfo
            // 
            this.txtWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkInfo.Location = new System.Drawing.Point(0, 0);
            this.txtWorkInfo.Name = "txtWorkInfo";
            this.txtWorkInfo.ReadOnly = true;
            this.txtWorkInfo.Size = new System.Drawing.Size(281, 21);
            this.txtWorkInfo.TabIndex = 0;
            // 
            // btn_workInfoSelect
            // 
            this.btn_workInfoSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_workInfoSelect.Location = new System.Drawing.Point(281, 0);
            this.btn_workInfoSelect.Name = "btn_workInfoSelect";
            this.btn_workInfoSelect.Size = new System.Drawing.Size(36, 24);
            this.btn_workInfoSelect.TabIndex = 1;
            this.btn_workInfoSelect.Text = "...";
            this.btn_workInfoSelect.UseVisualStyleBackColor = true;
            this.btn_workInfoSelect.Click += new System.EventHandler(this.btn_WorkInfoSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 30);
            this.label6.TabIndex = 16;
            this.label6.Text = "检验船舶*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 317;
            this.ucShipSelect1.Enabled = false;
            this.ucShipSelect1.Location = new System.Drawing.Point(117, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(317, 20);
            this.ucShipSelect1.TabIndex = 0;
            // 
            // txtSortNo
            // 
            this.txtSortNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSortNo.Location = new System.Drawing.Point(117, 33);
            this.txtSortNo.Name = "txtSortNo";
            this.txtSortNo.Size = new System.Drawing.Size(317, 21);
            this.txtSortNo.TabIndex = 1;
            // 
            // txtCHECKENGLISHNAME
            // 
            this.txtCHECKENGLISHNAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCHECKENGLISHNAME.Location = new System.Drawing.Point(117, 93);
            this.txtCHECKENGLISHNAME.Name = "txtCHECKENGLISHNAME";
            this.txtCHECKENGLISHNAME.Size = new System.Drawing.Size(317, 21);
            this.txtCHECKENGLISHNAME.TabIndex = 3;
            // 
            // UcCMSConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcCMSConfig";
            this.Size = new System.Drawing.Size(437, 397);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtCMSCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_workInfoSelect;
        private CommonViewer.TextBoxEx txtWorkInfo;
        private CommonViewer.TextBoxEx txtCMSConfigName;
        private System.Windows.Forms.Label label6;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtSortNo;
        private CommonViewer.TextBoxEx txtCHECKENGLISHNAME;
	}
}
