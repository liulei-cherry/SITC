namespace ShipMisZHJ_WorkFlow.UserControls
{
    partial class UCNode
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
            this.labPost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labPost
            // 
            this.labPost.AutoSize = true;
            this.labPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPost.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPost.Location = new System.Drawing.Point(0, 0);
            this.labPost.Name = "labPost";
            this.labPost.Size = new System.Drawing.Size(53, 12);
            this.labPost.TabIndex = 2;
            this.labPost.Text = "审核岗位";
            this.labPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labPost.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labObject_MouseDown);
            this.labPost.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labObject_MouseMove);
            this.labPost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labPost_MouseClick);
            this.labPost.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labPost_MouseUp);
            // 
            // UCNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labPost);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCNode";
            this.Size = new System.Drawing.Size(53, 12);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPost;
    }
}
