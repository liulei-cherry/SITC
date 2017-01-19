namespace Maintenance.Viewer
{
    partial class FrmComponentWorkList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComponentWorkList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datHistory = new CommonViewer.UcDataGridView(this.components);
            this.ucWorkInfoHistoryView = new Maintenance.Viewer.UcWorkOrder();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.datHistory)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datHistory
            // 
            this.datHistory.AllowUserToAddRows = false;
            this.datHistory.AllowUserToDeleteRows = false;
            this.datHistory.AllowUserToOrderColumns = true;
            this.datHistory.AutoFit = true;
            this.datHistory.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.datHistory.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.datHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datHistory.EnableHeadersVisualStyles = false;
            this.datHistory.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("datHistory.Footer")));
            this.datHistory.GridColor = System.Drawing.Color.SteelBlue;
            this.datHistory.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("datHistory.Header")));
            this.datHistory.LoadedFinish = false;
            this.datHistory.Location = new System.Drawing.Point(0, 0);
            this.datHistory.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("datHistory.MergeColumnNames")));
            this.datHistory.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("datHistory.MergeRowColumn")));
            this.datHistory.Name = "datHistory";
            this.datHistory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datHistory.RowHeadersWidth = 30;
            this.datHistory.RowTemplate.Height = 23;
            this.datHistory.ShowRowNumber = true;
            this.datHistory.Size = new System.Drawing.Size(319, 498);
            this.datHistory.TabIndex = 1;
            this.datHistory.Title = "";
            this.datHistory.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datHistory_RowEnter);
            // 
            // ucWorkInfoHistoryView
            // 
            this.ucWorkInfoHistoryView.BackColor = System.Drawing.Color.AliceBlue;
            this.ucWorkInfoHistoryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkInfoHistoryView.Location = new System.Drawing.Point(0, 0);
            this.ucWorkInfoHistoryView.Name = "ucWorkInfoHistoryView";
            this.ucWorkInfoHistoryView.Size = new System.Drawing.Size(635, 498);
            this.ucWorkInfoHistoryView.TabIndex = 2;
            this.ucWorkInfoHistoryView.TaskId = null;
            this.ucWorkInfoHistoryView.ThisWorkOrder = null;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.datHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucWorkInfoHistoryView);
            this.splitContainer1.Size = new System.Drawing.Size(958, 498);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 1;
            // 
            // FrmComponentWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(958, 498);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmComponentWorkList";
            this.Text = "设备工作历史";
            this.Load += new System.EventHandler(this.FrmComponentWorkList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmComponentWorkList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.datHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonViewer.UcDataGridView datHistory;
        private UcWorkOrder ucWorkInfoHistoryView;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}