using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControlService;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmReplaceWork : CommonViewer.BaseForm.FormBase
    {
        public FrmReplaceWork()
        {
            InitializeComponent();
            instance = this;
        }
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmReplaceWork instance = new FrmReplaceWork();
        public static FrmReplaceWork Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmReplaceWork.instance = new FrmReplaceWork();
                }
                return FrmReplaceWork.instance;
            }
        }
        #endregion
        private Maintenance.DataObject.WorkInfo workInfo;

        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get { return workInfo; }
            set 
            {
                if (null == value) return;
                workInfo = value;
                getLeftWork();
                getBindWork();
                ucWorkInfoBriefDescription.WorkInfo = value;

            }
        }

        /// <summary>
        /// 获取已经绑定的工作.
        /// </summary>
        private void getBindWork()
        {
            DataTable dt = WorkInfoService.Instance.getBindWork(workInfo);
            this.dgvBindWork.DataSource = dt;
            setBindWorkColumns();
            dgvBindWork.LoadGridView("FrmReplaceWork.dgvBindWork");
            foreach(DataGridViewColumn col in dgvBindWork.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 获取可以绑定的工作列表.
        /// </summary>
        private void getLeftWork()
        {
            DataTable dt = WorkInfoService.Instance.getLeftWork(workInfo);
            this.dgvLeftWork.DataSource = dt;
            setLeftWorkColumns();
            dgvLeftWork.LoadGridView("FrmReplaceWork.dgvLeftWork");
            foreach (DataGridViewColumn col in dgvLeftWork.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void setLeftWorkColumns()
        {
            disableAllColumns(this.dgvLeftWork);
        }

        private void setBindWorkColumns()
        {
            disableAllColumns(this.dgvBindWork);
        }

        /// <summary>
        /// 设定datagridvidw的所有列为不可见.
        /// </summary>
        /// <param name="dgv"></param>
        private void disableAllColumns(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Tag = 0;
                col.Visible = false;
            } 

            setVisible(dgv, "WorkInfoName", "工作名称");
            setVisible(dgv, "Worker", "负责岗位");
            setVisible(dgv, "manager", "确认岗位"); 
        }
        private void setVisible(DataGridView dgv, string columnName, string displayHeader)
        {
            dgv.Columns[columnName].HeaderText = displayHeader;
            dgv.Columns[columnName].Visible = true;
            dgv.Columns[columnName].Tag = null;
        }

        //保存grid的列宽和顺序.
        private void FrmReplaceWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvBindWork.SaveGridView("FrmReplaceWork.dgvBindWork");
            dgvLeftWork.SaveGridView( "FrmReplaceWork.dgvLeftWork");
        }

        //增加选择.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            moveRow(this.dgvLeftWork,this.dgvBindWork);
        }

        //移除选择.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            moveRow(this.dgvBindWork, this.dgvLeftWork);
        }

        //行移动.
        private void moveRow(DataGridView source, DataGridView target)
        {
            DataTable sourceTable = (DataTable)source.DataSource;
            DataTable targetTable = (DataTable)target.DataSource;

            if (source.CurrentCell == null) return;
            int j = source.CurrentCell.RowIndex;
            targetTable.ImportRow(sourceTable.Rows[j]);
            sourceTable.Rows.Remove(sourceTable.Rows[j]);  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";

            //先删除再插入.
            if (!WorkInfoService.Instance.deleteWorkInfoInsteadRelationByMainWorkInfoID(workInfo.WORKINFOID, out err))
            {
                MessageBoxEx.Show("删除原绑定工作信息时出错，出错信息为：\r"+ err);
                return;
            }

            DataTable saveTable=(DataTable)this.dgvBindWork.DataSource;

            foreach (DataRow dr in saveTable.Rows)
            {
                if (!WorkInfoService.Instance.insertWorkInfoInsteadRelation(workInfo.WORKINFOID, dr["WorkInfoId"].ToString(),
                true, workInfo.SHIP_ID, out err))
                {
                    MessageBoxEx.Show("添加绑定工作信息时出错，出错信息为：\r" + err);
                    return;
                }                
            }
            MessageBoxEx.Show("工作信息关联设置成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void dgvLeftWork_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtLeft.Text = this.dgvLeftWork.Rows[e.RowIndex].Cells["WorkInfoDetail"].Value.ToString();
        }

        private void dgvBindWork_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtBind.Text = this.dgvBindWork.Rows[e.RowIndex].Cells["WorkInfoDetail"].Value.ToString();
        }  
        private void FrmReplaceWork_Load(object sender, EventArgs e)
        { 
        }

        private void FrmReplaceWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

    }
}