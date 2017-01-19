/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmMaterialType.cs
 * 创 建 人：李景育 * 创建时间：2008-03-10
 * 标    题：物资信息维护窗体（包括物资类别和物资基础信息）
 * 功能描述：实现物资类别和物资基础信息业务窗体上的相关功能
 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonViewer;
using ItemsManage.Services;
using CommonViewer.BaseControl;
using ItemsManage.DataObject;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 物资信息维护窗体（包括物资类别和物资基础信息）.
    /// </summary>
    public partial class FrmMaterialBaseEdit : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 权限代理业务类.
        /// </summary>
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialBaseEdit instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialBaseEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialBaseEdit.instance = new FrmMaterialBaseEdit();
                }
                return FrmMaterialBaseEdit.instance;
            }
        }
        #endregion
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmMaterialBaseEdit()
        {
            InitializeComponent();
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                AddButton.Visible = false; deleteButton.Visible = false; btnMaterialTypeEdit.Visible = false;
                btnEdit.Visible = false;

                btnSetType.Visible = false;
            }
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialType_Load(object sender, EventArgs e)
        {
            string err;
            if (!MaterialTypeService.Instance.InsertRoot(out err))
            {
                MessageBoxEx.Show("未找到并无法为物资分类添加根结点,错误原因为:\r" + err);
            }
            ucMaterialTypeTree1.ReloadingAllData();
            btnMaterialTypeEdit.Enabled = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEMS_EDIT, out err);
            ucMaterialInfo1.SetCanEdit(false);
            InitializePermission();
        }
        #region  wanhw-2014-09-26-按钮权限控制
        /// <summary>
        /// 按钮权限控制.
        /// </summary>
        private void InitializePermission()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                deleteButton.Visible = true;
            }
            else
            {
                deleteButton.Visible = false;
            }
        }
        #endregion
        private void setBindingSource()
        {
            if (ucMaterialTypeTree1.SelectedNode != null && ucMaterialTypeTree1.SelectedNode.Tag != null
                && ucMaterialTypeTree1.SelectedNode.Tag.GetType() == typeof(MaterialType))
            {
                string typeId = ((MaterialType)ucMaterialTypeTree1.SelectedNode.Tag).GetId();
                setBindingSource(typeId);
            }
            else
                setBindingSource("");
        }
        /// <summary>
        /// 设置物资基础信息的bindingSource数据源，每次查询的都是指定类别的物资信息。.
        /// </summary>
        private void setBindingSource(string theTypeId)
        {
            ucMaterialInfo1.ClearData();
            DataTable dtbMaterial = MaterialInfoService.Instance.GetMaterialInfoByTypeId(theTypeId);//取得物资基础信息的DataTable对象.
            bindingSourceMain.DataSource = dtbMaterial;//物资基础信息的数据源设置.
            dgvMain.DataSource = bindingSourceMain;

            //设置DataGridView网格标题的名称.
            this.setDataGridView();
        }

        /// <summary>
        /// 设置物资基础信息网格控件dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMain.LoadGridView("FrmMaterialBaseEdit.dgvMain");
            dgvMain.Columns["material_id"].Visible = false;
            dgvMain.Columns["material_type_id"].Visible = false;
            dgvMain.Columns["material_code"].HeaderText = "物资编码";
            dgvMain.Columns["material_name"].HeaderText = "物资名称";
            dgvMain.Columns["material_spec"].HeaderText = "规格型号";
            dgvMain.Columns["unit_name"].HeaderText = "计量单位";
            dgvMain.Columns["material_type_name"].HeaderText = "所属类别";
            dgvMain.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.Columns["remark"].HeaderText = "备注";
            dgvMain.SetDataGridViewNoSort();
            if (dgvMain.Columns["sel"] == null)//如果列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvCheckBoxCol = new DataGridViewCheckBoxColumn();
                dgvCheckBoxCol.Name = "sel";
                dgvCheckBoxCol.HeaderText = "";
                dgvCheckBoxCol.Width = 25;
                dgvMain.Columns.Insert(0, dgvCheckBoxCol);                
            }
            else dgvMain.Columns["sel"].DisplayIndex = 0;
        }

        /// <summary>
        /// 物资基础信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string typeId = "";
            if (ucMaterialTypeTree1.SelectedNode == null)
            {
                MessageBoxEx.Show("请选择要添加物资的所属分类!");
                return;
            }
            if (ucMaterialTypeTree1.SelectedNode.Tag != null)
            {
                if (ucMaterialTypeTree1.SelectedNode.Tag.GetType() == typeof(MaterialType))
                {
                    MaterialType MaterialType = (MaterialType)(ucMaterialTypeTree1.SelectedNode.Tag);
                    typeId = MaterialType.GetId();
                }
                else
                {
                    throw new Exception("FrmMaterialTypeEdit控件配置错误,请联系开发商!");
                }
            }

            MaterialInfo newMaterialInfo = new MaterialInfo("", typeId, "", "", "", "EA", "");
            FrmEditOneMaterialInfo formNew = new FrmEditOneMaterialInfo(newMaterialInfo);

            formNew.ShowDialog();
            if (formNew.NeedRetrieve)
            {
                setBindingSource(formNew.MaterialInfoEdited.MATERIAL_TYPE_ID);
                dgvMain.ScrollToDefinedRow("MATERIAL_ID", formNew.MaterialInfoEdited.GetId());
            }
        }

        /// <summary>
        /// 删除操作物资基础信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (ucMaterialInfo1.TheObject != null && !ucMaterialInfo1.TheObject.IsWrong)
            {
                if (DialogResult.No == MessageBoxEx.Show("确认删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                string err;
                if (ucMaterialInfo1.TheObject.Delete(out err))
                {
                    setBindingSource();
                }
            }
            else
            {
                MessageBoxEx.Show("无信息可以删除!");
            }
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

        private void ucMaterialTypeTree1_ItemChanged(MaterialType materialType)
        {
            if (materialType != null && !materialType.IsWrong)
            {
                ucMaterialInfo1.ClearData();
            }
            setBindingSource(materialType.GetId());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ucMaterialInfo1.TheObject != null && !ucMaterialInfo1.TheObject.IsWrong)
            {
                FrmEditOneMaterialInfo frm = new FrmEditOneMaterialInfo(ucMaterialInfo1.TheObject);
                frm.ShowDialog();
                if (frm.NeedRetrieve)
                {
                    setBindingSource(frm.MaterialInfoEdited.MATERIAL_TYPE_ID);
                    dgvMain.ScrollToDefinedRow("MATERIAL_ID", frm.MaterialInfoEdited.GetId());
                }
            }
            else
            {
                MessageBoxEx.Show("无信息可以编辑!");
            }
        }

        private void btnMaterialTypeEdit_Click(object sender, EventArgs e)
        {
            FrmMaterialTypeEdit frm = new FrmMaterialTypeEdit();
            frm.ShowDialog();
            ucMaterialTypeTree1.ReloadingAllData();
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int nowRow = e.RowIndex;
                if (nowRow >= dgvMain.Rows.Count) nowRow = 0;

                if (dgvMain.Rows.Count > 0 && dgvMain.Rows[nowRow].Cells["MATERIAL_ID"].Value != null)
                {
                    //得到对象,更新到上面.
                    string err;
                    MaterialInfo materialInfo = MaterialInfoService.Instance.getObject(dgvMain.Rows[nowRow].Cells["MATERIAL_ID"].Value.ToString(), out err);
                    ucMaterialInfo1.ChangeData(materialInfo);
                }
                else
                {
                    ucMaterialInfo1.ClearData();
                    return;
                }
            }
        }

        private void FrmMaterialBaseEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
            dgvMain.SaveGridView("FrmMaterialBaseEdit.dgvMain");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvMain.Columns.Contains("sel"))
            {
                foreach (DataGridViewRow dgvr in dgvMain.Rows)
                {
                    dgvr.Cells["sel"].Value = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvMain.Columns.Contains("sel"))
            {
                foreach (DataGridViewRow dgvr in dgvMain.Rows)
                {
                    dgvr.Cells["sel"].Value = false;
                }
            }
        }

        private void btnSetType_Click(object sender, EventArgs e)
        {
            //得到所有选择了true的内容,多于一个 可以调整.
            List<string> ids = new List<string>();
            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells["sel"].Value != null && (bool)dgvr.Cells["sel"].Value)
                {
                    ids.Add(dgvr.Cells["MATERIAL_ID"].Value.ToString());
                }
            }
            if (ids.Count > 0)
            {
                FrmSelectMaterialType frm = new FrmSelectMaterialType();
                frm.ShowDialog();
                if (frm.SelectediMaterialType != null)
                {
                    string err;
                    if (MaterialInfoService.Instance.ResetMaterialInfoType(frm.SelectediMaterialType.GetId(), ids, out err))
                    {
                        MessageBoxEx.Show("设置成功!");
                        if(ucMaterialTypeTree1.SelectedNode!= null && ucMaterialTypeTree1.SelectedNode.Tag!=null
                            && ucMaterialTypeTree1.SelectedNode.Tag.GetType() == typeof(MaterialType))
                            setBindingSource(((MaterialType)ucMaterialTypeTree1.SelectedNode.Tag).GetId());
                    }
                    else
                    {
                        MessageBoxEx.Show("设置失败,错误原因为:\r"+ err);
                    }
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //获取原选择过的id,当重新过滤后,选择的内容将丢失.
            if (txtFilter.Text.Trim().Length > 0)
            {
                string theFilterString = txtFilter.Text.Trim().Replace("'", "''");
                bindingSourceMain.Filter = "material_name like '%" + theFilterString
                    + "%' or material_code like '%" + theFilterString
                    + "%' or material_spec like '%" + theFilterString
                    + "%' or material_type_name like '%" + theFilterString + "%'";
            }
            else bindingSourceMain.Filter = null;
        }

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMain.Columns[e.ColumnIndex].Name == "sel" && e.RowIndex >= 0)
            {
                bool ifselected;
                if (dgvMain.Rows[e.RowIndex].Cells["sel"].Value == null) ifselected = false;
                else ifselected = (bool)dgvMain.Rows[e.RowIndex].Cells["sel"].Value;
                dgvMain.Rows[e.RowIndex].Cells["sel"].Value = !ifselected;
            }
        }
    }
}