/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：夏喜龙
 * 创建时间：2009-05-25
 * 标    题：
 * 功能描述：设备工作信息管理
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.Services;
using Maintenance.Viewer;
using ItemsManage.DataObject;
using CommonOperation.Enum;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmEquipmentWorkInfo : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        private ComponentUnit componentUnit = null;
        private Maintenance.DataObject.WorkInfo workInfo;
        private int currentRow = 0;

        /// <summary>
        /// 属性赋值.
        /// </summary>
        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get { return workInfo; }
            set
            {
                if (null == value)
                {
                    workInfo = null;
                    ucWorkInfo.WorkInfo = value;
                    return;
                }
                workInfo = value;
                ucWorkInfo.WorkInfo = workInfo;
            }
        }

        public FrmEquipmentWorkInfo(ComponentUnit component)
        {
            InitializeComponent();
            this.componentUnit = component;
            dgvEquipWork.adding = new CommonViewer.UcDataGridView.Adding(delegateAdding);
            dgvEquipWork.editing = new CommonViewer.UcDataGridView.Editing(delegateEditing);
            dgvEquipWork.deleting = new CommonViewer.UcDataGridView.Deleting(delegateDeleting);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmEquipmentWorkInfo_Load(object sender, EventArgs e)
        {
            this.loadEquipWorkData();    //加载单个设备的工作列表信息.
            //加载网格控件默认的列宽信息.
            dgvEquipWork.LoadGridView("FrmEquipmentWorkInfo.dgvEquipWork");
        }

        /// <summary>
        /// 加载单个设备的工作信息列表.
        /// </summary>
        private void loadEquipWorkData()
        {
            //加groupbox标题.
            groupBox1.Text = componentUnit.COMP_CHINESE_NAME + " 工作信息列表";

            //防止rowEnter报错.
            dgvEquipWork.RowEnter -= new DataGridViewCellEventHandler(dgvEquipWork_RowEnter);

            //加载列表数据.
            DataTable dtbEquipWork = WorkInfoService.Instance.GetEquipWork(componentUnit);
            dgvEquipWork.DataSource = dtbEquipWork;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("WorkInfoName", "工作名称");
            dictColumns.Add("worker", "责任人");
            dictColumns.Add("CircleOrTiming", "定期/定时");
            dgvEquipWork.SetDgvGridColumns(dictColumns);
            dgvEquipWork.Columns["WorkInfoName"].Tag = 0;
            //工作信息的初始化设置。.
            if (dtbEquipWork.Rows.Count == 0)
            {
                workInfo = null;
                ucWorkInfo.WorkInfo = workInfo;
                ucWorkInfo.addRefrshControls();
            }
            ucWorkInfo.Component_unit = componentUnit;
            ucWorkInfo.stopComponentBtn();
            ucWorkInfo.setControlsDisable(true);

            //防止rowEnter报错.
            dgvEquipWork.RowEnter += new DataGridViewCellEventHandler(dgvEquipWork_RowEnter);
        }

        private void delegateAdding()
        {
            //保存当前行.
            if (dgvEquipWork.Rows.Count > 0 && this.dgvEquipWork.CurrentCell != null)
            {
                currentRow = this.dgvEquipWork.CurrentCell.RowIndex;
            }
            else
            {
                currentRow = 0;
            }

            Maintenance.DataObject.WorkInfo work = new Maintenance.DataObject.WorkInfo();
            work.SHIP_ID = componentUnit.SHIP_ID;
            work.WORKINFOID = null;
            work.WORKINFOSTATE = 1;
            work.WORKINFOTYPE = 1;
            work.REFOBJID = componentUnit.COMPONENT_UNIT_ID;
            componentUnit.FillThisObject();
            work.PRINCIPALPOST = componentUnit.TheComponentType.HEADSHIP;
            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.WorkInfo = work;
            frm.ComponentUnit = componentUnit;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            this.loadEquipWorkData();
            if (dgvEquipWork.Rows.Count > 0)
            {
                dgvEquipWork.CurrentCell = dgvEquipWork["WorkInfoName", currentRow];//显示当前行.
            }

        }
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            delegateAdding();
        }
        private void delegateEditing()
        {
            if (dgvEquipWork.Rows.Count == 0)
            {
                MessageBoxEx.Show("无记录可修改！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.dgvEquipWork.CurrentRow == null)
            {
                dgvEquipWork.CurrentCell = dgvEquipWork.FirstDisplayedCell;
            }
            currentRow = this.dgvEquipWork.CurrentRow.Index;
            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.WorkInfo = workInfo;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            this.loadEquipWorkData();
            dgvEquipWork.CurrentCell = dgvEquipWork["WorkInfoName", currentRow];
        }

        private void delegateDeleting()
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择要删除的工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBoxEx.Show("您确认删除选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            string err = "";
            if (workInfo.Delete(out err))
            {
                MessageBoxEx.Show("工作信息删除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentRow = 0;

                this.loadEquipWorkData();    //加载单个设备的工作列表信息.
            }
            else
            {
                MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvEquipWork.Rows.Count <= 0)
            {
                workInfo = null;
                ucWorkInfo.addRefrshControls();
                dgvEquipWork.CurrentCell = null;
            }
            else
            {
                dgvEquipWork.CurrentCell = dgvEquipWork["WorkInfoName", 0];
            }
        }

        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            delegateEditing();
        }

        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            delegateDeleting();
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEquipmentWorkInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格控件各列的列宽信息.
            dgvEquipWork.SaveGridView("FrmEquipmentWorkInfo.dgvEquipWork");
        }

        /// <summary>
        /// 加载工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEquipWork_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err;

            if (e.RowIndex < 0 || this.dgvEquipWork.Rows.Count == 0)
            {
                ucWorkInfo.addRefrshControls();
                return;
            }
            else
            {
                DataGridViewRow dr = dgvEquipWork.Rows[e.RowIndex];
                string workInfoID = "";
                if (DBNull.Value != dr.Cells["WorkInfoID"].Value)
                    workInfoID = dr.Cells["WorkInfoID"].Value.ToString();

                workInfo = WorkInfoService.Instance.getObject(workInfoID, out err);
            }
            ucWorkInfo.WorkInfo = workInfo;

        }

        private void dgvEquipWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bdNgEditItem_Click(sender, null);
        }

        private void FrmEquipmentWorkInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (componentUnit != null)
            {
                //  FrmSelectWorkTemplate frm = new FrmSelectWorkTemplate((ComponentUnit)ComponentUnitService.Instance.GetOneObjectById(componentUnit.COMPONENT_UNIT_ID));
                FrmSelectWorkTemplet frm = new FrmSelectWorkTemplet((ComponentUnit)ComponentUnitService.Instance.GetOneObjectById(componentUnit.COMPONENT_UNIT_ID));

                frm.ShowDialog();
                if (frm.NeedRetrieve)
                {
                    loadEquipWorkData();
                }
            }
        }
    }
}