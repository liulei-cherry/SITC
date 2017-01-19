/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmShipInfo.cs
 * 创 建 人：李景育
 * 创建时间：2008-08-31
 * 标    题：船舶信息管理业务窗体
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
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using CommonViewer.MultiLanguage;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmShipInfo : CommonViewer.BaseForm.BaseMdiChildForm
    {
        ///// <summary>
        ///// 定义一个公共类CommonOpt对象.
        ///// </summary>        
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private string selectedValue1;
        private string selectedValue2;
        private string selectedValue3;
        private ShipInfo thisShip;
        private ShipHold thisShipHold;
        private ShipOilWareHouse thisShipOilWareHouse;

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipInfo instance = new FrmShipInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipInfo.instance = new FrmShipInfo();
                }
                return FrmShipInfo.instance;
            }
        }
        #endregion
              
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmShipInfo()
        {
            
            InitializeComponent();

            #region gridview委托部分            
            ucObjectsGridView1.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView1_TheObjectChanged);
            ucObjectsGridView2.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView2_TheObjectChanged);
            ucObjectsGridView3.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView3_TheObjectChanged);
            #endregion
            retreive();
           
        }

        public void retreive()
        {
            string err;
            // liulei-2016/01/29-修改数据源 admin 加载所有数据,其他人加载所分配的船
            //DataTable dt = BaseInfo.DataAccess.ShipInfoService.Instance.getInfo(out err);
            DataTable dt = new DataTable();
            if (CommonOperation.ConstParameter.SupperUser)
            {
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.getAllShipInfo(out err);
            }
            else
            {
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.GetOwnerShip(CommonOperation.ConstParameter.UserId, out err);
            }
            ucObjectsGridView1.Init(dt, DataAccess.ShipInfoService.Instance,"shipinfo.Main");
        }

        public void retreive2(string shipid)
        {
            if (shipid == null) shipid = "";
            DataTable dt2 = BaseInfo.DataAccess.ShipHoldService.Instance.GetShipHold(shipid);
            DataTable dt3 = BaseInfo.DataAccess.ShipOilWareHouseService.Instance.GetShipWare(shipid);
            ucObjectsGridView2.Init(dt2, DataAccess.ShipHoldService.Instance, "shipinfo.dt2");
            ucObjectsGridView3.Init( dt3, DataAccess.ShipOilWareHouseService.Instance, "shipinfo.dt3");

        }

        void ucObjectsGridView1_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                selectedValue1 = theNewObject.GetId(); 
                ucShipHold1.ClearData();
                ucOilWareHouse1.ClearData();
                thisShip = (ShipInfo)DataAccess.ShipInfoService.Instance.GetOneObjectById(selectedValue1);
                ucShipInfo1.ChangeData(thisShip);
                if (thisShip != null && !thisShip.IsWrong)
                { ucShipInfo1.SetCanEdit(true); }
                retreive2(selectedValue1);
            }
            else
            {
                ucShipInfo1.ClearData();
                selectedValue1 = "";
                thisShip = null;
            }
        }

        void ucObjectsGridView2_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                selectedValue2 = theNewObject.GetId();
                thisShipHold = (ShipHold)DataAccess.ShipHoldService.Instance.GetOneObjectById(selectedValue2);                
                ucShipHold1.ChangeData(thisShipHold);
                if (thisShipHold != null && !thisShipHold.IsWrong)
                { ucShipHold1.SetCanEdit(true); }
            }
            else
            {
                ucShipHold1.ClearData();
                selectedValue2 = "";
                thisShipHold = null;
            }
        }

        void ucObjectsGridView3_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                selectedValue3 = theNewObject.GetId();
                thisShipOilWareHouse = (ShipOilWareHouse)DataAccess.ShipOilWareHouseService.Instance.GetOneObjectById(selectedValue3);
                ucOilWareHouse1.ChangeData(thisShipOilWareHouse);
                if (thisShipOilWareHouse != null && !thisShipOilWareHouse.IsWrong)
                { ucOilWareHouse1.SetCanEdit(true); }
            }
            else
            {
                ucOilWareHouse1.ClearData ();
                selectedValue3 = "";
                thisShipOilWareHouse = null;
            }
        }

        #region FormLoad事件
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        private void FrmShipInfo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            string sChkMessage;
            bool equipmentManage = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENT_EDIT, out sChkMessage);
            bool InitManage = proxyRight.CheckRight(CommonOperation.ConstParameter.BASIC_EDIT, out sChkMessage);
            btnInit.Visible = CommonOperation.ConstParameter.SupperUser || (equipmentManage && InitManage);//必须设备也可以维护，而且还可以初始化的人才可以执行。.
            
            //liulei-2016/01/28-编辑操作只留给管理员
            bool isAdmin = CommonOperation.ConstParameter.SupperUser;
            //AddButton.Visible = equipmentManage || isAdmin;
            //deleteButton.Visible = equipmentManage || isAdmin;
            //SaveButton.Visible = equipmentManage || isAdmin;

            AddButton.Visible = isAdmin;
            deleteButton.Visible = isAdmin;
            SaveButton.Visible = isAdmin;
        }
        #endregion

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
           {
               if (!CommonOperation.ConstParameter.IsLandVersion)
               {
                   MessageBoxEx.Show("船舶端版本不允许添加和删除船舶！");
                   return;
               }
               FrmEditOneShip frmEditOneShip = new FrmEditOneShip();
               frmEditOneShip.ShowDialog();
               if (frmEditOneShip.NeedRetrieve) retreive();
           }
           else if (tabMain.SelectedIndex == 1)
           {
               FrmEditShipHold FrmEditShipHold = new FrmEditShipHold(thisShip);
               FrmEditShipHold.ShowDialog();

               if (FrmEditShipHold.NeedRetrieve)
               {
                   if (thisShip != null && !thisShip.IsWrong)
                   {
                       retreive2(thisShip.GetId());
                   }
                   else
                   {
                       retreive2("");
                   }
               }
           }
           else if (tabMain.SelectedIndex == 2)
           {
               FrmEditShipOilWareHouse FrmEditShipWareHouse = new FrmEditShipOilWareHouse(thisShip);
               FrmEditShipWareHouse.ShowDialog();

               if (FrmEditShipWareHouse.NeedRetrieve)
               {
                   if (thisShip != null && !thisShip.IsWrong)
                   {
                       retreive2(thisShip.GetId());
                   }
                   else
                   {
                       retreive2("");
                   }
               }
           }
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                if (!CommonOperation.ConstParameter.IsLandVersion)
                {
                    MessageBoxEx.Show("船舶端版本不允许添加和删除船舶！");
                    return;
                }
                if (!string.IsNullOrEmpty(selectedValue1))
                {
                    if (MessageBoxEx.Show("删除船舶是存在很严重影响的操作,请确认一定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    string err;
                    if (!ShipInfoService.Instance.DeleteShipRelationTableData(selectedValue1, out err))
                    {
                        MessageBoxEx.Show("删除船舶相关信息时出错，错误信息为：" + err);
                        return;
                    }
                    if (!ShipInfoService.Instance.deleteUnit(selectedValue1,out err))
                    {
                        MessageBoxEx.Show("删除船舶相关信息时出错，错误信息为：" + err);
                        return;
                    }
                    else
                    {
                        MessageBoxEx.Show("删除成功");
                        retreive();
                        return;
                    }                   
                }                
                //bdNgAddNewItem.Enabled = true;
            }
            else if (tabMain.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(selectedValue2))
                {
                    string err;
                    if (!ShipHoldService.Instance.deleteUnit(selectedValue2, out err))
                    {
                        MessageBoxEx.Show("删除船舶货舱信息时出错，错误信息为：" + err);
                        return;
                    }
                    else
                    {
                        MessageBoxEx.Show("删除成功");
                        if (thisShip != null && !thisShip.IsWrong)
                        {
                            retreive2(thisShip.GetId());
                        }
                        else
                        {
                            retreive2("");
                        }
                        return;
                    }
                }                
            }
            else if (tabMain.SelectedIndex == 2)
            {
                if (!string.IsNullOrEmpty(selectedValue3))
                {
                    string err;
                    if (!ShipOilWareHouseService.Instance.deleteUnit(selectedValue3, out err))
                    {
                        MessageBoxEx.Show("删除船舶油水舱柜信息时出错，错误信息为：" + err);
                        return;
                    }
                    else
                    {
                        MessageBoxEx.Show("删除成功");
                        if (thisShip != null && !thisShip.IsWrong)
                        {
                            retreive2(thisShip.GetId());
                        }
                        else
                        {
                            retreive2("");
                        }
                        return;
                    }
                }
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

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmShipInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucObjectsGridView1.SaveDataGridView();
            instance = null;
        }

        #region 初始化一条新的船舶

        /// <summary>
        /// 初始化一条新船的数据库.
        /// </summary>
        /// <param name="p">船舶的id</param>
        private void InitializeDataBase(string shipID)
        {
            string err;
            if (!ShipInfoService.Instance.InitAShipWithAllRelationInfo(shipID, out err))
            {
                MessageBoxEx.Show("初始化一条船舶的相关信息时出错，错误信息为："+err);
            }
        }             
        #endregion

        string fileName;

        /// <summary>
        /// 打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (thisShip == null || thisShip.IsWrong)
            {
                return;
            }
            if (SaveFileDialogEx.ShowDialog(saveFileDialog1) == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                FrmBusy frm = new FrmBusy("正在导出船舶基本信息文件,请稍好\r此过程中请不要打开未完成导出的Excel文件", new FrmBusy.FinishedOpeartion(exporting));
                try
                {
                    frm.ShowDialog();                    
                }
                catch(Exception err)
                {
                    MessageBoxEx.Show("导出失败!错误原因请参考:\r" + err.Message);
                    return;
                }
                MessageBoxEx.Show("导出完成!");
            }
        }

        private void exporting()
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            byte[] fileBytes = global::BaseInfo.Properties.Resources.船舶基本信息;
            fs.Write(fileBytes, 0, fileBytes.Length);
            fs.Close();
            ShipInfoService.Instance.ExportItemToExcel(fileName, thisShip);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {

                ucShipInfo1.UpdateObject();
            }
            else if (tabMain.SelectedIndex == 1)
            {
                ucShipHold1.ShipID = thisShip.SHIP_ID;
                ucShipHold1.UpdateObject();
            }
            else if (tabMain.SelectedIndex == 2)
            {
                ucOilWareHouse1.ShipID = thisShip.SHIP_ID;
                ucOilWareHouse1.UpdateObject();
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
        public bool JudgeTheAuthorityCanOpenTHisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        #endregion

        #region IFunctionChildWindow 成员

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (thisShip == null || thisShip.IsWrong)
            {
                return;
            }
            if (MessageBoxEx.Show("重新初始化将调整当前船舶的存储文件结构,但不会对当前数据造成任何影响,\r请确认是否进行船舶重新初始化", 
                "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            string err;
            if (ShipInfoService.Instance.InitAShipWithAllRelationInfo(thisShip.GetId(), out err))
            {
                MessageBoxEx.Show("重新初始化成功", "系统提示");
            }
            else
            {
                MessageBoxEx.Show("重新初始化失败,错误提示为:"+err, "系统提示");
            }
        }

    }
}