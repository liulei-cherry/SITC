/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-4-12
 * 功能描述：船舶设备分类信息管理的相关功能
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
    public partial class FrmEquipmentClass : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmEquipmentClass instance = new FrmEquipmentClass();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmEquipmentClass Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmEquipmentClass.instance = new FrmEquipmentClass();
                }
                return FrmEquipmentClass.instance;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEquipmentClass()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            int level = 0;          //level 是父节点等级。0代表是根节点.
            string subID = "";
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode == null)
            {
                MessageBoxEx.Show("请选择要添加分类的上级节点!\rSelect the parent node of which you want to add.");
                return;
            }
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag != null)
            {
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(EquipmentClass))
                {
                    EquipmentClass equipmentClass = (EquipmentClass)(ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag);
                    level = int.Parse(equipmentClass.CLASSTYPE.ToString());
                    subID = equipmentClass.CLASSID;
                }
                else
                {
                    throw new Exception("UcEquipmentClassTreeWithEquipment控件配置错误,请联系开发商!");
                }
            }

            EquipmentClass newEquipmentClass = new EquipmentClass(null, "", "", level < 3 ? level + 1 : level, "", subID);
            FrmEditOneEquipmentClass formNew = new FrmEditOneEquipmentClass(newEquipmentClass);

            formNew.ShowDialog();
            //当新添加数据时，刷新tree
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null)
            {
                ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode);
            }
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucEquipmentClass1.DeleteObject();
            if (ucEquipmentClass1.needRetrieve == true)
            {
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent != null)
                {
                    ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent);
                }
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            ucEquipmentClass1.UpdateObject();
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent != null)
            {
                ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent);
            }
        }

        #region IFunctionChildWindow 成员

        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.
            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
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
        /// 截获树控件的切换焦点事件.
        /// </summary>
        /// <param name="theObject"></param>
        /// <param name="objectType"></param>
        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            //仅当正常事件是才处理.
            if (objectType == 3)
            {
                ucEquipmentClass1.ChangeData((EquipmentClass)theObject);
            }
        }
    }
}