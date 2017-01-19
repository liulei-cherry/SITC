/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-4-18
 * 功能描述：船舶设备归类到设备分类中的管理
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
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    public partial class FrmEquipmentSortOut : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmEquipmentSortOut instance = new FrmEquipmentSortOut();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmEquipmentSortOut Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmEquipmentSortOut.instance = new FrmEquipmentSortOut();
                }
                return FrmEquipmentSortOut.instance;
            }
        }
        #endregion

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 网格第一次加载列信息的变量，第一次加载完毕后，以后刷新数据时网格列信息不再加载（配件主机滑油化验信息）.
        /// </summary>
        private bool IsFirstLoad = true;
        private bool IsFirstLoad2 = true;

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEquipmentSortOut()
        {            
            InitializeComponent(); 

        }

        string supClassID;
        EquipmentClass equipClass;
        TreeNode nowNode;

        /// <summary>
        /// 加载tree初始数据.
        /// </summary>
        public void reloadData()
        {

            //加载根节点.
            treeView1.Nodes[0].Text = "中海油服";
            treeView1.Nodes[0].Tag = "root";

            //界面刚打开时把根节点变为当前节点.
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.ExpandAll();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        { 
            reloadData();

        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        /// <summary>
        /// 点击tree节点实现相关功能.
        /// </summary>
        private void treenodeClick(TreeNode tn)
        {
            //判断当前是否需要展开下一级.
            List<string> cwbt = new List<string>();
            string equipClassID = "root".Equals(tn.Tag) ? "" : ((EquipmentClass)tn.Tag).CLASSID;

            List<EquipmentClass> lists = EquipmentClassService.Instance.GetObjectsByParentId(equipClassID);
            tn.Nodes.Clear();
            int i = 0;
            foreach (EquipmentClass equipmentClass in lists)
            {
                tn.Nodes.Add(formATreeNode(equipmentClass, false));
                i++;
            }

            //根据当前节点的信息更新右边列表.
            nowNode = tn;               //更新当前节点信息.
            equipClass = "root".Equals(tn.Tag) ? null : (EquipmentClass)nowNode.Tag;

            string currentID = "root";
            if (equipClass != null) currentID = equipClass.CLASSID;

            //显示当前分类设备列表.
            this.currentClassLoadData(currentID);

            //显示上级分类设备列表.
            txtSearch.Text = "";    //清空搜索内容.
            if (nowNode.Parent == null)
            {
                supClassID = "";
            }
            else if (!"root".Equals(nowNode.Parent.Tag))
            {
                supClassID = ((EquipmentClass)nowNode.Parent.Tag).CLASSID;
            }
            else
            {
                supClassID = "root";
            }
            this.supClassLoadData(supClassID,txtSearch.Text);

        }

        /// <summary>
        ///  在dataGridView上增加复选框.
        /// </summary>
        private void addMulSelect(DataGridView aimDGV)
        {
            aimDGV.Columns["check"].DisplayIndex = 0;
            aimDGV.Columns["check"].HeaderText = "";
            aimDGV.Columns["check"].Width = 30;
        }

        /// <summary>
        ///  加载当前分类条件下设备列表信息.
        /// </summary>
        private void currentClassLoadData(string equipClassID)
        {

            //取得设备列表信息的DataTable对象.
            DataTable dtbCurrentClassEquip;
            if ("root".Equals(equipClassID))
            {
                dtbCurrentClassEquip = ComponentUnitService.Instance.GetComponentsByNot("");
            }
            else
            {
                dtbCurrentClassEquip =  ComponentUnitService.Instance.GetComponentsByClassID(equipClassID,"");
            }
            //datatable 增加复选列.
            dtbCurrentClassEquip.Columns.Add("check", typeof(bool));
            dgvCurrentClass.DataSource = dtbCurrentClassEquip;
            
            //设置列标题.
            if (IsFirstLoad == true)
            {

                addMulSelect(dgvCurrentClass);  //datagridview 增加复选列.
                dgvCurrentClass.Columns["COMPONENT_UNIT_ID"].Visible = false;
                dgvCurrentClass.Columns["COMP_CHINESE_NAME"].HeaderText = "设备名称";
                dgvCurrentClass.Columns["COMP_CHINESE_NAME"].Width = 300;
                dgvCurrentClass.Columns["COMP_ENGLISH_NAME"].HeaderText = "第二语言名称";
                dgvCurrentClass.Columns["COMP_ENGLISH_NAME"].Width = 200;
                dgvCurrentClass.Columns["DETAIL"].HeaderText = "设备参数";
                dgvCurrentClass.Columns["DETAIL"].Width = 200;
                IsFirstLoad = false; //以后刷新数据时网格列信息不再加载.
            }
       
        }

        /// <summary>
        ///  加载上级分类条件下设备列表信息.
        /// </summary>
        private void supClassLoadData(string equipClassID,string componentName)
        {

            //取得设备列表信息的DataTable对象.
            DataTable dtbSubClassEquip = null;
            if ("root".Equals(equipClassID))
            {
                dtbSubClassEquip = ComponentUnitService.Instance.GetComponentsByNot(componentName);
            }
            else
            {
                dtbSubClassEquip = ComponentUnitService.Instance.GetComponentsByClassID(equipClassID,componentName);
            }
            //datatable 增加复选列.
            dtbSubClassEquip.Columns.Add("check", typeof(bool));
            dgvSupClass.DataSource = dtbSubClassEquip;
            
            //设置列标题.
            if (IsFirstLoad2 == true)
            {
                addMulSelect(dgvSupClass);  //datagridview 增加复选列.
                dgvSupClass.Columns["COMPONENT_UNIT_ID"].Visible = false;
                dgvSupClass.Columns["COMP_CHINESE_NAME"].HeaderText = "设备名称";
                dgvSupClass.Columns["COMP_CHINESE_NAME"].Width = 300;
                dgvSupClass.Columns["COMP_ENGLISH_NAME"].HeaderText = "第二语言名称";
                dgvSupClass.Columns["COMP_ENGLISH_NAME"].Width = 200;
                dgvSupClass.Columns["DETAIL"].HeaderText = "设备参数";
                dgvSupClass.Columns["DETAIL"].Width = 200;

                IsFirstLoad2 = false; //以后刷新数据时网格列信息不再加载.
            }
            
        }

        /// <summary>
        ///  当前分类设备列表（全选）.
        /// </summary>
        private void btnAll2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCurrentClass.Rows)
            {
                row.Cells["check"].Value = true;
            }
        }

        /// <summary>
        ///  当前分类设备列表（全清）.
        /// </summary>
        private void btnBlank2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCurrentClass.Rows)
            {
                row.Cells["check"].Value = false;
            }
        }

        /// <summary>
        ///  上级分类设备列表（全选）.
        /// </summary>
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSupClass.Rows)
            {
                row.Cells["check"].Value = true;
            }
        }

        /// <summary>
        ///  上级分类设备列表（全清）.
        /// </summary>
        private void btnBlank_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvSupClass.Rows)
            {
                row.Cells["check"].Value = false;
            }
        }

        /// <summary>
        /// 分配设备到当前分类.
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {

            string err="";
            DataTable dt = (DataTable)dgvSupClass.DataSource;
            List<string> lstEquipmentID = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["check"].ToString() == "True")
                {
                    lstEquipmentID.Add(row["COMPONENT_UNIT_ID"].ToString());
                }
            }

            if (lstEquipmentID.Count == 0)
            {
                MessageBoxEx.Show("请先选中设备!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ComponentUnitService.Instance.componentsToClass(supClassID,equipClass.CLASSID, lstEquipmentID, out err))
            {
                MessageBoxEx.Show(err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                treenodeClick(nowNode); //刷新上级分类列表和当前分类列表.
            }

        }

        /// <summary>
        /// 把当前分类上的设备设为上级分类上.
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            string err = "";
            DataTable dt = (DataTable)dgvCurrentClass.DataSource;
            List<string> lstEquipmentID = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["check"].ToString() == "True")
                {
                    lstEquipmentID.Add(row["COMPONENT_UNIT_ID"].ToString());
                }
            }

            if (lstEquipmentID.Count == 0)
            {
                MessageBoxEx.Show("请先选中设备!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (equipClass != null && !ComponentUnitService.Instance.componentsToSup(supClassID,equipClass.CLASSID, lstEquipmentID, out err))
            {
                MessageBoxEx.Show(err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                treenodeClick(nowNode); //刷新上级分类列表和当前分类列表.
            }
        }

        /// <summary>
        /// 把当前分类上的设备设为根上.
        /// </summary>
        private void btnDownToRoot_Click(object sender, EventArgs e)
        {
            string err = "";
            DataTable dt = (DataTable)dgvCurrentClass.DataSource;
            List<string> lstEquipmentID = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["check"].ToString() == "True")
                {
                    lstEquipmentID.Add(row["COMPONENT_UNIT_ID"].ToString());
                }
            }

            if (lstEquipmentID.Count == 0)
            {
                MessageBoxEx.Show("请先选中设备!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (equipClass != null && !ComponentUnitService.Instance.componentsToRoot(equipClass.CLASSID, lstEquipmentID, out err))
            {
                MessageBoxEx.Show(err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                treenodeClick(nowNode); //刷新上级分类列表和当前分类列表.
            }
        }

        /// <summary>
        /// 搜索上级分类的设备.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.supClassLoadData(supClassID, txtSearch.Text);
        }

        /// <summary>
        /// tree节点选取事件.
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treenodeClick(e.Node);
        }

        /// <summary>
        /// 生成一个新的树结点.
        /// </summary>
        private TreeNode formATreeNode(EquipmentClass equipmentClass, bool ifRoot)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = equipmentClass.CLASSID;
            newNode.Text = equipmentClass.CLASSNAME;

           int caseSwitch = int.Parse(equipmentClass.CLASSTYPE.ToString());
            switch (caseSwitch)
            {
                case 1:
                    newNode.ImageKey = "depart";
                    break;
                case 2:
                    newNode.ImageKey = "system";
                    break;
                case 3:
                    newNode.ImageKey = "equip";
                    break;
            }

            newNode.SelectedImageKey = "open";
            newNode.Tag = equipmentClass;
            return newNode;

        }

        /// <summary>
        /// 树节点点击事件（展开收缩功能）.
        /// </summary>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);           
            treeView1_AfterSelect(sender, new TreeViewEventArgs(e.Node));
            if (info.Location != TreeViewHitTestLocations.PlusMinus)
            {
                if (!e.Node.IsExpanded) e.Node.Expand(); 
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

    }
}