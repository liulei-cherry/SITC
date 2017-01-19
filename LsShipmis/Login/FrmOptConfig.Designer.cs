using System.Windows.Forms;
namespace Login
{
    partial class FrmOptConfig
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbxuser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxpwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDataBase2 = new System.Windows.Forms.ComboBox();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "服务器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "信息库：";
            // 
            // tbxuser
            // 
            this.tbxuser.Location = new System.Drawing.Point(76, 49);
            this.tbxuser.Name = "tbxuser";
            this.tbxuser.Size = new System.Drawing.Size(275, 21);
            this.tbxuser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "用户名：";
            // 
            // tbxpwd
            // 
            this.tbxpwd.Location = new System.Drawing.Point(76, 84);
            this.tbxpwd.Name = "tbxpwd";
            this.tbxpwd.PasswordChar = '*';
            this.tbxpwd.Size = new System.Drawing.Size(275, 21);
            this.tbxpwd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "密 码：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "文件库：";
            // 
            // cboDataBase2
            // 
            this.cboDataBase2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDataBase2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDataBase2.DisplayMember = "name";
            this.cboDataBase2.FormattingEnabled = true;
            this.cboDataBase2.Location = new System.Drawing.Point(76, 153);
            this.cboDataBase2.Name = "cboDataBase2";
            this.cboDataBase2.Size = new System.Drawing.Size(275, 20);
            this.cboDataBase2.TabIndex = 5;
            // 
            // cboDataBase
            // 
            this.cboDataBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDataBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDataBase.DisplayMember = "name";
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Location = new System.Drawing.Point(76, 119);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(275, 20);
            this.cboDataBase.TabIndex = 4;
            this.cboDataBase.DropDown += new System.EventHandler(this.cboDataBase_DropDown);
            // 
            // cboServer
            // 
            this.cboServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(76, 15);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(275, 20);
            this.cboServer.TabIndex = 1;
            this.cboServer.DropDown += new System.EventHandler(this.cboServer_DropDown);
            // 
            // FrmOptConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 220);
            this.Controls.Add(this.cboDataBase2);
            this.Controls.Add(this.cboDataBase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxpwd);
            this.Controls.Add(this.tbxuser);
            this.Controls.Add(this.label4);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(386, 258);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(386, 258);
            this.Name = "FrmOptConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置数据库";
            this.Load += new System.EventHandler(this.FrmOptConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.ComboBox cboDataBase2;
        private System.Windows.Forms.TextBox tbxuser;
        private System.Windows.Forms.TextBox tbxpwd;
    }
}