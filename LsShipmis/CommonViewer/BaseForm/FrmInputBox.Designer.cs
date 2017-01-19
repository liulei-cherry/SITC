namespace CommonViewer
{
    partial class FrmInputBox
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtInputBox = new CommonViewer.TextBoxEx();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSearchFld = new System.Windows.Forms.Label();
            this.cboSearchFld = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 29);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "搜索内容：";
            // 
            // txtInputBox
            // 
            this.txtInputBox.Location = new System.Drawing.Point(14, 44);
            this.txtInputBox.Name = "txtInputBox";
            this.txtInputBox.Size = new System.Drawing.Size(366, 21);
            this.txtInputBox.TabIndex = 1;
            this.txtInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputBox_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(224, 71);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "搜索(&S)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSearchFld
            // 
            this.lblSearchFld.AutoSize = true;
            this.lblSearchFld.Location = new System.Drawing.Point(12, 12);
            this.lblSearchFld.Name = "lblSearchFld";
            this.lblSearchFld.Size = new System.Drawing.Size(65, 12);
            this.lblSearchFld.TabIndex = 0;
            this.lblSearchFld.Text = "搜索字段：";
            this.lblSearchFld.Visible = false;
            // 
            // cboSearchFld
            // 
            this.cboSearchFld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchFld.FormattingEnabled = true;
            this.cboSearchFld.Location = new System.Drawing.Point(83, 8);
            this.cboSearchFld.Name = "cboSearchFld";
            this.cboSearchFld.Size = new System.Drawing.Size(121, 20);
            this.cboSearchFld.TabIndex = 4;
            this.cboSearchFld.Visible = false;
            // 
            // FrmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 108);
            this.Controls.Add(this.cboSearchFld);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtInputBox);
            this.Controls.Add(this.lblSearchFld);
            this.Controls.Add(this.lblSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "快速搜索";
            this.Load += new System.EventHandler(this.FrmInputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private CommonViewer.TextBoxEx txtInputBox;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSearchFld;
        private System.Windows.Forms.ComboBox cboSearchFld;
    }
}