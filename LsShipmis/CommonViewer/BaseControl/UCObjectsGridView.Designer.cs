namespace CommonViewer.BaseControl
{
    partial class UCObjectsGridView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCObjectsGridView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucObjectsView = new CommonViewer.UcDataGridView(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucObjectsView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucObjectsView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 413);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ucObjectsView
            // 
            this.ucObjectsView.AllowUserToAddRows = false;
            this.ucObjectsView.AllowUserToDeleteRows = false;
            this.ucObjectsView.AllowUserToOrderColumns = true;
            this.ucObjectsView.AutoFit = true;
            this.ucObjectsView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ucObjectsView.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucObjectsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucObjectsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucObjectsView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ucObjectsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucObjectsView.EnableHeadersVisualStyles = false;
            this.ucObjectsView.ExportColorToExcel = false;
            this.ucObjectsView.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("ucObjectsView.Footer")));
            this.ucObjectsView.GridColor = System.Drawing.Color.SteelBlue;
            this.ucObjectsView.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("ucObjectsView.Header")));
            this.ucObjectsView.LoadedFinish = false;
            this.ucObjectsView.Location = new System.Drawing.Point(3, 17);
            this.ucObjectsView.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("ucObjectsView.MergeColumnNames")));
            this.ucObjectsView.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("ucObjectsView.MergeRowColumn")));
            this.ucObjectsView.Name = "ucObjectsView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucObjectsView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ucObjectsView.RowHeadersWidth = 25;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucObjectsView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ucObjectsView.RowTemplate.Height = 23;
            this.ucObjectsView.ShowRowNumber = true;
            this.ucObjectsView.Size = new System.Drawing.Size(407, 393);
            this.ucObjectsView.TabIndex = 0;
            this.ucObjectsView.Title = null;
            this.ucObjectsView.DoubleClick += new System.EventHandler(this.ucObjectsView_DoubleClick);
            // 
            // UCObjectsGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCObjectsGridView";
            this.Size = new System.Drawing.Size(413, 413);
            this.Load += new System.EventHandler(this.UCObjectsGridView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucObjectsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UcDataGridView ucObjectsView;
    }
}
