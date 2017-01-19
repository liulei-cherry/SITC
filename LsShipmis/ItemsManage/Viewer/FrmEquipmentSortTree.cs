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

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    public partial class FrmEquipmentSortTree : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmEquipmentSortTree instance = new FrmEquipmentSortTree();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmEquipmentSortTree Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmEquipmentSortTree.instance = new FrmEquipmentSortTree();
                }
                return FrmEquipmentSortTree.instance;
            }
        }
        #endregion
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEquipmentSortTree()
        {
            InitializeComponent();
            ucEquipmentClassTreeWithEquipment1.draggingFinish += new CommonViewer.DragTreeViewEx.DraggingFinish(draggingFinish);
        }

        #region 公共变量和对象

        List<ComponentUnit> subComponentList = new List<ComponentUnit>();
        //为右边预留所有未选择过分类节点的操作部分,其实不预留也一样可以完成功能.

        #endregion

        /// <summary>
        /// 船舶选择事件功能.
        /// </summary>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            string err;
            ShipInfo theShip = ShipInfoService.Instance.getObject(theSelectedObject, out err);
            ucEquipmentClassTreeWithEquipment1.ReloadingShipData(theShip);
            ucEquipmentClassTreeWithEquipment2.ReloadingShipData(theShip);

        }

        private void draggingFinish(bool ifSuccess)
        {
            if (ucEquipmentClassTreeWithEquipment2.SelectedNode.Parent != null)
                ucEquipmentClassTreeWithEquipment2.RefreshOneNode(ucEquipmentClassTreeWithEquipment2.SelectedNode.Parent);
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEquipmentSortTree_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            ucShipSelect1_TheSelectedChanged(ucShipSelect1.GetId());
        }
    }
}