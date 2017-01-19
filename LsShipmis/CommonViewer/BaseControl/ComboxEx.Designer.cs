namespace CommonViewer.BaseControl
{
    partial class ComboxEx
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
            this.btnExtForm = new System.Windows.Forms.Button();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExtForm
            // 
            this.btnExtForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExtForm.Font = new System.Drawing.Font("宋体", 6F);
            this.btnExtForm.Location = new System.Drawing.Point(78, 0);
            this.btnExtForm.Margin = new System.Windows.Forms.Padding(0);
            this.btnExtForm.Name = "btnExtForm";
            this.btnExtForm.Size = new System.Drawing.Size(24, 20);
            this.btnExtForm.TabIndex = 5;
            this.btnExtForm.Text = "...";
            this.btnExtForm.UseVisualStyleBackColor = true;
            this.btnExtForm.Click += new System.EventHandler(this.btnExtForm_Click);
            // 
            // cbList
            // 
            this.cbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbList.DropDownHeight = 500;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(0, 0);
            this.cbList.Margin = new System.Windows.Forms.Padding(0);
            this.cbList.MaxDropDownItems = 100;
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(79, 20);
            this.cbList.TabIndex = 6;
            this.cbList.TextChanged += new System.EventHandler(this.cbList_TextChanged);
            this.cbList.Leave += new System.EventHandler(this.cbList_Leave);
            // 
            // ComboxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExtForm);
            this.Controls.Add(this.cbList);
            this.MaximumSize = new System.Drawing.Size(2000, 20);
            this.MinimumSize = new System.Drawing.Size(60, 20);
            this.Name = "ComboxEx";
            this.Size = new System.Drawing.Size(102, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExtForm;
        private System.Windows.Forms.ComboBox cbList;
    }
}
