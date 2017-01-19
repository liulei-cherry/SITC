/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSelectMaterial.cs
 * 创 建 人：李景育
 * 创建时间：2007-12-07
 * 标    题：物资信息选择业务窗体
 * 功能描述：把当前界面上的所有打勾的物资信息添加到目标界面上去，本界面提供了物资的查找与过滤功能。
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
using CommonViewer;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 物资信息选择业务窗体.
    /// </summary>
    public partial class FrmSelectMaterial : CommonViewer.BaseForm.FormBase
    { 
        public bool Selected = false;
        public List<string> MaterialIds = new List<string>();
        public List<StorageParameter> Materials = new List<StorageParameter>();
        private DataTable dtAllMaterial;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSelectMaterial()
        {
            InitializeComponent();
            //获取所有的物资信息，保存到一个datatable中.
            dtAllMaterial = MaterialInfoService.Instance.GetMaterialInfoByTypeId("");
            if (!CommonOperation.ConstParameter.IsLandVersion)
                buttonEx8.Visible = false;
        }
      
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectMaterial_Load(object sender, EventArgs e)
        {
            FillTrViewMaterialType(null);
        }

        /// <summary>
        /// 物资大类选择时显示相关的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trViewMaterialType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                //调用函数FillTrViewMaterialType为树的当前节点加载数据.
                this.FillTrViewMaterialType(e.Node);
            }
            this.setBindingSource();
        }
        /// <summary>
        /// 为物资类别树trMaterial的当前节点加载数据.
        /// </summary>
        /// <param name="curNode">物资类别树trMaterial的当前节点</param>
        private void FillTrViewMaterialType(TreeNode curNode)
        {
            DataTable dtbTreeDataMaterialType = null; //保存物资类别信息的DataTable对象.

            //在物资类别树当前节点加载数据前先删除掉以前存在的所有节点.
            if(curNode != null)curNode.Nodes.Clear();

            //取当前物资类别下的子物资类别.
            dtbTreeDataMaterialType = MaterialInfoService.Instance.GetMaterialTypeByParentId((curNode == null || curNode.Tag == null) ? "" : curNode.Tag.ToString());
            if (dtbTreeDataMaterialType.Rows.Count > 0)
            {
                //调用commonOpt类的FillTreeNode方法加载子物资类别数据.
                FillTreeNode(curNode, dtbTreeDataMaterialType, 1, 2);
            }

            if (curNode != null) curNode.Expand();//展开当前节点.
            else trMaterial.ExpandAll();
        }

        /// <summary>
        /// 十四、填充TreeView中指定节点的子节点.
        /// </summary>
        /// <param name="treeNode">TreeView控件中的当前指定节点</param>
        /// <param name="dtbCurNode">包含TreeNode所需数据的DataTable</param>
        /// <param name="imgIndex">要显示的图标索引</param>
        /// <param name="selImgIndex">选择的图标索引</param>
        public void FillTreeNode(TreeNode treeNode, DataTable dtbCurNode, int imgIndex, int selImgIndex)
        {
            //用dtbCurNode中的值填充当前节点treeNode
            foreach (DataRow dataRow in dtbCurNode.Rows)
            {
                string sId = dataRow[0].ToString();  //取出Id用于设置子节点的Tag属性.
                string sName = dataRow[1].ToString();//取出名称用于设置子节点的Text属性.
                TreeNode newNode = new TreeNode();   //建立一个新的节点对象.
                newNode.Tag = sId;                   //设置子节点的Tag属性；.
                newNode.Name = sId;                  //设置子节点的Name属性；.
                newNode.Text = sName;                //设置子节点的Text属性.
                newNode.ImageIndex = imgIndex;       //设置子节点的图标.
                newNode.SelectedImageIndex = selImgIndex;//设置子节点的打开图标.
                if (treeNode == null)
                {
                    trMaterial.Nodes.Add(newNode);
                }
                else
                {
                    treeNode.Nodes.Add(newNode);         //把newNode节点做为子节点添加到treeNode节点对象中去.
                }
            }
        }

        /// <summary>
        /// 设置物资基础信息的bindingSource数据源，每次查询的都是指定大类的物资信息。.
        /// </summary>
        private void setBindingSource()
        {
            string materialTypeId = "";//物资大类Id

            //如果物资大类树当前节点不为空，则加载当前大类节点的物资信息.
            if (trMaterial.SelectedNode != null)
            {
                dgvMaterial.DataSource = null;
                materialTypeId = trMaterial.SelectedNode.Tag.ToString();
                DataTable dtbMaterial = MaterialInfoService.Instance.GetMaterialInfoByTypeId(materialTypeId);//取得物资基础信息的DataTable对象.
                bindingSourceMain.DataSource = dtbMaterial;//物资基础信息的数据源设置.
                dgvMaterial.DataSource = bindingSourceMain;
                bindingSourceMain.Filter = "";
                this.setDataGridView();
            }
        }

        /// <summary>
        /// 设置物资基础信息网格控件dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMaterial.Columns["material_id"].Visible = false;
            dgvMaterial.Columns["material_type_id"].Visible = false;
            dgvMaterial.Columns["unit_name"].Visible = false; 
            dgvMaterial.Columns["remark"].Visible = false;
            dgvMaterial.Columns["material_code"].HeaderText = "物资编码";
            dgvMaterial.Columns["material_code"].ReadOnly = true;
            dgvMaterial.Columns["material_name"].HeaderText = "物资名称";
            dgvMaterial.Columns["material_name"].ReadOnly = true;
            dgvMaterial.Columns["material_spec"].HeaderText = "规格型号";
            dgvMaterial.Columns["material_type_name"].HeaderText = "所属类别";            
            dgvMaterial.Columns["material_spec"].ReadOnly = true;
            dgvMaterial.Columns["unit_name"].HeaderText = "单位";
            dgvMaterial.Columns["unit_name"].ReadOnly = true;
            dgvMaterial.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMaterial.Columns["material_code"].Width = 80;
            dgvMaterial.Columns["material_name"].Width = 180;
            dgvMaterial.Columns["material_spec"].Width = 100;
            dgvMaterial.Columns["unit_name"].Width = 40;
            dgvMaterial.SetDataGridViewNoSort();
        }

        /// <summary>
        /// 物资搜索.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSearch_Click(object sender, EventArgs e)
        {
            FrmInputBox frm = new FrmInputBox(trMaterial, false);
            frm.ShowDialog();
        }

        /// <summary>
        /// 当选择某个物资时如果不存在，可快速定位到物资基础信息界面上进行维护.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgMatBasic_Click(object sender, EventArgs e)
        {
            //取树控件trViewMaterialType的当前节点的物资大类Id（包含在tag中）.
            string materialTypeId = "";
            if (trMaterial.SelectedNode != null && trMaterial.SelectedNode != trMaterial.TopNode)
            {
                materialTypeId = trMaterial.SelectedNode.Tag.ToString();
            }

            FrmMaterialBaseEdit frm = FrmMaterialBaseEdit.Instance;

            if (frm.Visible)
            {
                frm.Close();
            }
            frm = FrmMaterialBaseEdit.Instance;
            frm.Size = new Size(900, 650);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            //关闭frm弹出窗体后刷新trViewMaterialType的当前节点以便显示新添加的物资.
            this.setBindingSource();
            bindingSourceMain.MoveLast();//移动到最新添加的物资上.
            if (dgvMaterial.CurrentRow != null)
            {
                dgvMaterial.CurrentRow.Cells["select"].Value = true;//新物资自动打勾.
            }
        }
     
        /// <summary>
        /// 为调用界面上的DataGridView组件添加物资相关数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSelect_Click(object sender, EventArgs e)
        {
            if (dgvMaterial.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可选择的物资信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvMaterial.EndEdit();
            //循环物资网格dgvMaterial中的每一行，把所有打勾的项添加到目标界面上去.
            foreach (DataGridViewRow dgvRow in dgvMaterial.Rows)
            {
                //如果选择标记被选中，则将当前项添加到目标界面上去.
                if (dgvRow.Cells["select"].Value != null && dgvRow.Cells["select"].Value.ToString().Equals("True"))
                {
                    string id = dgvRow.Cells["material_id"].Value.ToString();
                    if (MaterialIds.Contains(id)) continue;
                    MaterialIds.Add(id);
                    StorageParameter temp = new StorageParameter();
                    temp.ItemId = id;
                    Materials.Add(temp);
                }
            }
            Selected = true;
            this.Close();            
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

        private void bdNgTxtFilter_TextChanged(object sender, EventArgs e)
        {

            string sFilter = bdNgTxtFilter.Text.Replace ("'","''");
            if (sFilter.Trim().Length < 2)
            {
                this.setBindingSource();
            }
            else
            {
                dgvMaterial.DataSource = null;

                bindingSourceMain.DataSource = dtAllMaterial;                
                bindingSourceMain.Filter = "material_name like '%" + sFilter + "%' or material_code like '%" + sFilter + "%' or material_spec like '%" + sFilter + "%'";
                dgvMaterial.DataSource = bindingSourceMain;

                this.setDataGridView();
            }
        }   
    }
}