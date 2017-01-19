namespace ShipMisZHJ_WorkFlow.Forms
{
    partial class FrmFlowAddEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboFlowObj = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labDetp = new System.Windows.Forms.Label();
            this.btnDeptSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFlowName = new CommonViewer.TextBoxEx();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "流程对象";
            // 
            // cboFlowObj
            // 
            this.cboFlowObj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFlowObj.FormattingEnabled = true;
            this.cboFlowObj.Location = new System.Drawing.Point(104, 22);
            this.cboFlowObj.Name = "cboFlowObj";
            this.cboFlowObj.Size = new System.Drawing.Size(322, 20);
            this.cboFlowObj.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "提交部门";
            // 
            // labDetp
            // 
            this.labDetp.AutoSize = true;
            this.labDetp.Location = new System.Drawing.Point(142, 53);
            this.labDetp.Name = "labDetp";
            this.labDetp.Size = new System.Drawing.Size(0, 12);
            this.labDetp.TabIndex = 3;
            // 
            // btnDeptSelect
            // 
            this.btnDeptSelect.Location = new System.Drawing.Point(104, 48);
            this.btnDeptSelect.Name = "btnDeptSelect";
            this.btnDeptSelect.Size = new System.Drawing.Size(32, 23);
            this.btnDeptSelect.TabIndex = 4;
            this.btnDeptSelect.Text = "…";
            this.btnDeptSelect.UseVisualStyleBackColor = true;
            this.btnDeptSelect.Click += new System.EventHandler(this.btnDeptSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "流程名";
            // 
            // txtFlowName
            // 
            this.txtFlowName.Location = new System.Drawing.Point(104, 80);
            this.txtFlowName.Name = "txtFlowName";
            this.txtFlowName.Size = new System.Drawing.Size(322, 21);
            this.txtFlowName.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(185, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(317, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmFlowAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 174);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtFlowName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeptSelect);
            this.Controls.Add(this.labDetp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFlowObj);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFlowAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "流程定义";
            this.Load += new System.EventHandler(this.FrmFlowAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFlowObj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labDetp;
        private System.Windows.Forms.Button btnDeptSelect;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtFlowName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}