/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmShipInfo.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-28
 * 标    题：船舶标准证书信息
 * 功能描述：实现船舶信息管理业务窗体上的相关功能
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

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmPortInfo : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmPortInfo instance = new FrmPortInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmPortInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmPortInfo.instance = new FrmPortInfo();
                }
                return FrmPortInfo.instance;
            }
        }
        #endregion
              
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmPortInfo()
        {
            
            InitializeComponent();

            #region gridview委托部分
            ucObjectsGridView1.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView1_TheObjectChanged);
         
            #endregion 
           
        }

        void ucObjectsGridView1_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                ucPort1.ChangeData(theNewObject);
            }
            else
            {
                ucPort1.ClearData();
            }
        }
       
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmEditOnePort formNew = new FrmEditOnePort();           
            formNew.ShowDialog();
            //当新添加数据时，刷新ucObjectsGridView1的值.
            if (formNew.NeedRetrieve)
            {
                reloadData();//重载数据.
            }           
        }
        public void reloadData()
        {
            DataTable dt;
            string err;
            dt =  PortInfoService.Instance.getInfo(out err);

            ucObjectsGridView1.Init(dt, PortInfoService.Instance, "FrmPortInfo");
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucPort1.DeleteObject();
            if (ucPort1.needRetrieve == true)
            {
                reloadData();//重载数据.
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ucPort1.UpdateObject();
            reloadData();
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

        private void FrmPortInfo_Load(object sender, EventArgs e)
        { 
            reloadData();
        }

        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucObjectsGridView1.SaveDataGridView();
            instance = null;
        } 
    }
}