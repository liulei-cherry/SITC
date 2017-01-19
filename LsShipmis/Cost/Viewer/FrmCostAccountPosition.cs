/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：王鹏程
 * 创建时间：2011-10-10
 * 功能描述：为业务定位科目
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
using System.IO;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmCostAccountPosition : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCostAccountPosition instance = new FrmCostAccountPosition();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCostAccountPosition Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCostAccountPosition.instance = new FrmCostAccountPosition();
                }
                return FrmCostAccountPosition.instance;
            }
        }
        #endregion
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCostAccountPosition()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            SetComboBoxSource();
            SetPositionBindingSource();
            SetAccountBindingSource();
            setDataGridView();
        }
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvAccount.SaveGridView("FrmCostAccountPosition.dgvAccount");
            dgvPosition.SaveGridView("FrmCostAccountPosition.dgvPosition");
            instance = null;
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 设置下拉列表数据.
        /// </summary>
        private void SetComboBoxSource()
        {
            //类别（1：备件；2：物料；3：航修；4：坞修；5：捆扎件；6：缆绳；7：油漆;8:化学品）.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
            DataRow dr = dt.NewRow();
            dr["ID"] = "1";
            dr["NAME"] = "备件";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["ID"] = "2";
            dr1["NAME"] = "物料";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["ID"] = "3";
            dr2["NAME"] = "航修";
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["ID"] = "4";
            dr3["NAME"] = "坞修";
            dt.Rows.Add(dr3);
            DataRow dr4 = dt.NewRow();
            dr4["ID"] = "5";
            dr4["NAME"] = "捆扎件";
            dt.Rows.Add(dr4);
            DataRow dr5 = dt.NewRow();
            dr5["ID"] = "6";
            dr5["NAME"] = "缆绳";
            dt.Rows.Add(dr5);
            DataRow dr7 = dt.NewRow();
            dr7["ID"] = "7";
            dr7["NAME"] = "油漆";
            dt.Rows.Add(dr7);
            DataRow dr8 = dt.NewRow();
            dr8["ID"] = "8";
            dr8["NAME"] = "化学品";
            dt.Rows.Add(dr8);
            DataRow dr9 = dt.NewRow();
            dr9["ID"] = "9";
            dr9["NAME"] = "滑油";
            dt.Rows.Add(dr9);
            cmbClass.ValueMember = "ID";
            cmbClass.DisplayMember = "NAME";
            cmbClass.DataSource = dt;
        }
        /// <summary>
        /// 绑定定位数据.
        /// </summary>
        private void SetPositionBindingSource()
        {
            string err;
            DataTable dt;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(
                new CostAccountPositionCondition(null, null, cmbClass.SelectedValue.ToString()), out dt, out err))
            {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            bdsPosition.DataSource = dt;
            dgvPosition.DataSource = bdsPosition;
        }
        /// <summary>
        /// 绑定定位数据.
        /// </summary>
        private void SetAccountBindingSource()
        {
            bdsAccount.DataSource = AccountService.Instance.GetTreeSubjectsByPosition("");
            dgvAccount.DataSource = bdsAccount;
        }
        /// <summary>
        ///  设置列样式.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("path", "名称");
            dic.Add("CODE", "编号");
            dgvPosition.SetDgvGridColumns(dic);
            dgvPosition.LoadGridView("FrmCostAccountPosition.dgvPosition");

            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("path", "名称");
            dic2.Add("CODE", "编号");
            dgvAccount.SetDgvGridColumns(dic2);
            dgvAccount.LoadGridView("FrmCostAccountPosition.dgvAccount");
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (bdsAccount.Current != null)
            {
                DataTable dt = (DataTable)bdsPosition.DataSource;
                DataRow[] drs = dt.Select("NODE_ID='" + ((DataRowView)bdsAccount.Current)["NODE_ID"].ToString() + "'");
                if (drs.Length == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["NODE_NAME"] = ((DataRowView)bdsAccount.Current)["path"].ToString();
                    dr["NODE_ID"] = ((DataRowView)bdsAccount.Current)["NODE_ID"].ToString();
                    dr["CODE"] = ((DataRowView)bdsAccount.Current)["CODE"].ToString();
                    dt.Rows.Add(dr);
                }
            }
            string err;
            if (!SaveOperation(out err))
            {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (bdsPosition.Current != null)
            {
                DataTable dt = (DataTable)bdsPosition.DataSource;
                DataRow[] drs = dt.Select("NODE_ID='" + ((DataRowView)bdsPosition.Current)["NODE_ID"].ToString() + "'");
                if (drs.Length > 0)
                {
                    dt.Rows.Remove(drs[0]);
                }
            }
            string err;
            if (!SaveOperation(out err))
            {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 保存按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err;
            if (!SaveOperation(out err))
            {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
        }
        /// <summary>
        /// 保存操作.
        /// </summary>
        private bool SaveOperation(out string err)
        {
            if (!CostAccountPositionService.Instance.DeleteUnitCondition(
                new CostAccountPositionCondition(null, null, cmbClass.SelectedValue.ToString()), out err))
            {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return false;
            }
            DataTable dt = (DataTable)bdsPosition.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CostAccountPosition cap = new CostAccountPosition(null, dt.Rows[i]["NODE_ID"].ToString(), cmbClass.SelectedValue.ToString(), i + 1);
                if (!cap.Update(out err))
                {
                    MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return false;
                }
            }
            SetPositionBindingSource();
            SetAccountBindingSource();
            return true;
        }

        /// <summary>
        /// 上移功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bdsPosition.DataSource;
            int position = bdsPosition.Position;
            if (position != 0)
            {
                DataRow[] drs = dt.Select("NODE_ID='" + ((DataRowView)bdsPosition.Current)["NODE_ID"].ToString() + "'");
                if (drs.Length > 0)
                {
                    object[] _rowData = dt.Rows[position - 1].ItemArray;
                    dt.Rows[position - 1].ItemArray = dt.Rows[position].ItemArray;
                    dt.Rows[position].ItemArray = _rowData;
                    bdsPosition.Position = position - 1;
                }
            }
        }
        /// <summary>
        /// 下移功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bdsPosition.DataSource;
            int position = bdsPosition.Position;
            if (position != bdsPosition.Count - 1)
            {
                DataRow[] drs = dt.Select("NODE_ID='" + ((DataRowView)bdsPosition.Current)["NODE_ID"].ToString() + "'");
                if (drs.Length > 0)
                {
                    object[] _rowData = dt.Rows[position + 1].ItemArray;
                    dt.Rows[position + 1].ItemArray = dt.Rows[position].ItemArray;
                    dt.Rows[position].ItemArray = _rowData;
                    bdsPosition.Position = position + 1;
                }
            }
        }
        /// <summary>
        /// 定位类型改变时,刷新数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetPositionBindingSource();
        }

    }
}