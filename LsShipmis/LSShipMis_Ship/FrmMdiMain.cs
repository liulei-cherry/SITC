/**********************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMdiMain.cs
 * 创 建 人：李景育
 * 创建时间：2007-04-17
 * 标    题：MDI主窗体操作部分
 * 功能描述：用于在菜单项中打开各个功能界面。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 *********************************************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using LSShipMis_Ship.SysLs.Services;
using FileOperationBase.Services;
using LSShipMis_Ship.Common.Remind;
using FileOperation.Forms;
using FileOperation.ISM;
using System.Diagnostics;
using System.Xml;
using FileOperation;
using CustomerTable.Forms;
using ShipCertification;
using ShipCertification.Report;
using CommonViewer;
using Maintenance.Report;
using CommonOperation.BaseClass;
using Maintenance.Viewer;
using BaseInfo.DataAccess;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Threading;
using CommonOperation.Functions;
using LSShipMis_Ship.Properties;
using ItemsManage.Viewer.Forms;
using ItemsManage.Viewer;
using StorageManage.Viewer;
using SeaChartManage.Forms;
using BaseInfo.Viewer;
using CommonOperation;
using CommonViewer.MultiLanguage;
using CommonViewer.BaseControl;
using ItemsManage.Report;
using CommonViewer.BaseForm;
using CMSManage.Viewer;
using FileOperationBase.FileServices;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using SynchDll;

namespace LSShipMis_Ship
{
    /// <summary>
    /// 系统总体MDI主窗体.
    /// </summary> 
    public partial class FrmMdiMain : CommonViewer.BaseForm.FormBase, IFileBoundShow
    {
        private string sChkMessage = "";    //权限检查提示信息（没有配置或者没有权限的提示）.

        bool closeWithoutAsk = false;
        RemindManager manager;
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.

        #region IFileBoundShow 接口实现

        public void ChangeToEmpty()
        {
            this.fileBoundOperation.Image = Properties.Resources.fileunbound;
        }

        public void ChangeToFull()
        {
            this.fileBoundOperation.Image = Properties.Resources.filebound;
        }

        public void fileBoundOperation_Click(object sender, EventArgs e)
        {
            ItemFileBoundingClick();
        }
        public void ItemFileBoundingClick()
        {
            FileBoundingOperation.Instance.FileBoundOperation();
        }

        #endregion

        /// <summary>
        /// 初始化函数.
        /// </summary>
        public FrmMdiMain()
        {
            InitializeComponent();

            FileBoundingOperation.Instance.FileBoundShow = this;
            CommonViewConfig.MainForm = this;
            showImage();
        }

        private void FrmMdiMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            toolStripMenuItem16.Visible = true;
#endif
            GetCustomerTables();

            this.Text = "海丰船舶管理系统(船舶版)——" + CommonOperation.ConstParameter.MAINVERSION;

            if (!CommonOperation.ConstParameter.SupperUser) RemindRegister();
            //清除临时打开的文件目录.

            string path = (@"d:\ShipMisFiles\FileOperation");
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                { }
            }

            //设置菜单权限.
            checkRight();
            resetUserAndPost();
        }

        private void GetCustomerTables()
        {
            try
            {
                for (int i = mnuIsm.DropDownItems.Count - 1; i >= 3; i--)
                {
                    mnuIsm.DropDownItems.RemoveAt(i);
                }
                List<string> allCanShown = CustomerTable.CustomerTableConfig.GetAllCustomerTables();
                List<string> customerTables = WorkModelTypeService.Instance.GetHeadShipRight(CommonOperation.ConstParameter.LoginUserInfo.PostId);

                if (customerTables.Count > 0)
                {
                    toolStripMenuItem3.Visible = true;

                    foreach (string tableName in customerTables)
                    {
                        //判断当前用户是否有这个菜单的权限。.

                        if (allCanShown.Contains(tableName))
                        {
                            ToolStripMenuItem tsiTemp = new ToolStripMenuItem(tableName);
                            tsiTemp.Click += new EventHandler(tsiTemp_Click);
                            mnuIsm.DropDownItems.Add(tsiTemp);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void resetUserAndPost()
        {
            toolStripStatusLabel3.Text = "登录者：" + CommonOperation.ConstParameter.UserName;

            if (!CommonOperation.ConstParameter.SupperUser)
            {
                string err;
                BaseInfo.Objects.Post gw = BaseInfo.DataAccess.PostService.Instance.getObject(CommonOperation.ConstParameter.LoginUserInfo.PostId, out err);
                if (gw != null && gw.POSTNAME != null)
                    toolStripStatusLabel3.Text += "  岗位：" + gw.POSTNAME;
            }

        }

        void tsiTemp_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = CustomerTable.CustomerTableConfig.OpenForm(((ToolStripMenuItem)sender).Text, this);
                frm.Text = ((ToolStripMenuItem)sender).Text;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            { }
        }

        /// <summary>
        /// 退出系统.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPms_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeWithoutAsk)
            {
                if (MessageBoxEx.Show("是否要退出该程序？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void FrmMdiMain_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void FrmMdiMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            FolderDbService.Instance.ClearAllEmptyFolderOfWhichType(CommonOperation.Enum.FileBoundingTypes.COMPONENTFILES);
        }

        #region 船舶参数部分

        private void 船舶基本参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShipCert.Forms.FrmShipInfo frm = ShipCert.Forms.FrmShipInfo.Instance;
            BaseInfo.Viewer.FrmShipInfo frm = BaseInfo.Viewer.FrmShipInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 船舶设备参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsManage.Viewer.FrmComponentManage frm = ItemsManage.Viewer.FrmComponentManage.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 设备分类管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemsManage.Viewer.FrmEquipmentClass frm = ItemsManage.Viewer.FrmEquipmentClass.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }

        private void 设备归类管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemsManage.Viewer.FrmEquipmentSortTree frm = ItemsManage.Viewer.FrmEquipmentSortTree.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }

        private void 设备打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipmentPrint frm = FrmEquipmentPrint.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }
        #endregion

        #region 维护保养部分

        private void mnuPms2_WorkInfo_Click(object sender, EventArgs e)
        {
            FrmWorkInfo frm = FrmWorkInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms2_TimerComp_Click(object sender, EventArgs e)
        {
            FrmTimingCompInit frm = FrmTimingCompInit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms2_Watch_Click(object sender, EventArgs e)
        {
            FrmGauge frm = FrmGauge.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms2_WorkBillTrace_Click(object sender, EventArgs e)
        {
            FrmWorkOrderTrace frm = FrmWorkOrderTrace.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms2_WorkOrderHis_View_Click(object sender, EventArgs e)
        {
            FrmWorkOrderHistory frm = FrmWorkOrderHistory.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 甲板部月度计划形成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanMonthFinish frm = FrmPlanMonthFinish.GetInstance(CommonPrintTableName.CTNOfMonthlyCompleteReport, "甲板部");
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 轮机部月度计划形成与跟踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanMonthFinish frm = FrmPlanMonthFinish.GetInstance(CommonPrintTableName.CTNOfMonthlyCompleteReport, "轮机部");
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 工作信息选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWorkTemplet frm = FrmWorkTemplet.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        private void 工作信息模板分类管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWorkinfoTempletClass frm = FrmWorkinfoTempletClass.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion

        #region CMS部分
        private void Menu_CMSDefine_Click(object sender, EventArgs e)
        {
            FrmCMSConfig frm = FrmCMSConfig.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void Menu_CMSArrange_Click(object sender, EventArgs e)
        {
            FrmCMSDateSetting frm = FrmCMSDateSetting.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void Menu_CMSSelfCheckingItem_Click(object sender, EventArgs e)
        {
            FrmCMSSelfChecking frm = FrmCMSSelfChecking.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void Menu_CMSCCSChecking_Click(object sender, EventArgs e)
        {
            FrmSocietyChecking frm = FrmSocietyChecking.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void Menu_CMSRectify_Click(object sender, EventArgs e)
        {
            FrmCMSRectify frm = FrmCMSRectify.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void Menu_CMSHistory_Click(object sender, EventArgs e)
        {
            FrmCMSHistory frm = FrmCMSHistory.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        #endregion

        # region ISM体系文件

        private void mnuIsm_Ism_Click(object sender, EventArgs e)
        {
            FileOperation.ISM.Forms.frmISMManageMent frm = FileOperation.ISM.Forms.frmISMManageMent.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 普通文件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperation.Forms.FrmDocManagement frm = FileOperation.Forms.FrmDocManagement.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        # endregion

        # region 备件管理

        private void mnuSparePurchaseApply_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmSparePurchaseApply frm = StorageManage.Viewer.FrmSparePurchaseApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        //private void mnuSpare_Apply_Click(object sender, EventArgs e)
        //{

        //    FrmSpareApply frm = FrmSpareApply.Instance;
        //    frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
        //    frm.MdiParent = this;
        //    frm.WindowState = FormWindowState.Maximized;
        //    frm.Show();

        //}
        private void mnuSpare_In_Click(object sender, EventArgs e)
        {
            FrmSpareIn frm = FrmSpareIn.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSpare_Out_Click(object sender, EventArgs e)
        {
            FrmSpareOut frm = FrmSpareOut.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSpare_Check_Click(object sender, EventArgs e)
        {
            FrmSpareStockCheck frm = FrmSpareStockCheck.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSpare_Stock_Click(object sender, EventArgs e)
        {
            FrmSpareStockInit frm = FrmSpareStockInit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSpare_StockQry_Click(object sender, EventArgs e)
        {
            FrmSpareOperation frm = FrmSpareOperation.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSpare_SpBasic_Click(object sender, EventArgs e)
        {
            FrmSpareBasic frm = FrmSpareBasic.Instance;
            frm.WindowState = FormWindowState.Maximized;//窗体最大化.
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        # region 物资管理

        private void mnuMaterial_Purchase_Apply_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmMaterialPurchaseApply frm = StorageManage.Viewer.FrmMaterialPurchaseApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void mnuMaterial_Apply_Click(object sender, EventArgs e)
        {
            //FrmMaterialApply frm = FrmMaterialApply.Instance;
            //frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void mnuMaterial_In_Click(object sender, EventArgs e)
        {
            FrmMaterialIn frm = FrmMaterialIn.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuMaterial_Out_Click(object sender, EventArgs e)
        {
            FrmMaterialOut frm = FrmMaterialOut.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuMaterial_Check_Click(object sender, EventArgs e)
        {
            FrmMaterialStockCheck frm = FrmMaterialStockCheck.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuMaterial_Stock_Click(object sender, EventArgs e)
        {
            FrmMaterialStockInit frm = FrmMaterialStockInit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuMaterial_StockQry_Click(object sender, EventArgs e)
        {
            FrmMaterialOperation frm = FrmMaterialOperation.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuMaterial_Info_Click(object sender, EventArgs e)
        {
            FrmMaterialBaseEdit frm = FrmMaterialBaseEdit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 物资分类维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialTypeEdit frm = FrmMaterialTypeEdit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region 证书部分

        private void mnuShipCert_Register_Click(object sender, EventArgs e)
        {
            FrmCertificationReportOfOneShip frm = ShipCertification.Report.FrmCertificationReportOfOneShip.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 船舶证书信息查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipCertification.Viewer.FrmShipCertificationManage frm = ShipCertification.Viewer.FrmShipCertificationManage.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 船舶证书检验历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipCertification.Viewer.FrmShipCertHis frm = ShipCertification.Viewer.FrmShipCertHis.Instance;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuShipCert_Cert_Click(object sender, EventArgs e)
        {
            ShipCertification.Viewer.FrmShipCertification frm = ShipCertification.Viewer.FrmShipCertification.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }

        private void mnuShipCert_Depart_Click(object sender, EventArgs e)
        {
            ShipCertification.Viewer.FrmShipCertDepart frm = ShipCertification.Viewer.FrmShipCertDepart.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }

        #endregion

        # region 船员管理部分

        private void mnuSeaman_Info_Click(object sender, EventArgs e)
        {
            Seaman.Forms.FrmSeamanInfo frm = Seaman.Forms.FrmSeamanInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        #endregion

        #region 海图信息部分

        private void 海图信息toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            FrmChartBaseInfoManage frm = FrmChartBaseInfoManage.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 船配海图目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmSeaChartCategoryManage frm = FrmSeaChartCategoryManage.Instance;
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            FrmChartShipManage frm = FrmChartShipManage.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 航海通告管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeaChartInfoManage frm = FrmSeaChartInfoManage.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 资料海图库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDataStockManage frm = FrmDataStockManage.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 资料海图领取登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmData frm = FrmData.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        #endregion

        #region 费用管理部分

        //船舶内部费用管理.
        private void 费用简单分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmSimpleclass frm = Cost.Viewer.FrmSimpleclass.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 废旧物资管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmWaste frm = Cost.Viewer.FrmWaste.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        #endregion

        #region 修理管理部分
        private void 修理申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repair.Viewer.FrmRepairApply frm = Repair.Viewer.FrmRepairApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 完工单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repair.Viewer.FrmComplete frm = Repair.Viewer.FrmComplete.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        #endregion

        #region 海丰油水部分

        private void 油品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOil frm = Oil.Viewer.FrmOil.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();

        }

        private void 油品船舶分配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilOfShip frm = Oil.Viewer.FrmOilOfShip.Instance;
            frm.MdiParent = this;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 淡水管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmWater frm = Oil.Viewer.FrmWater.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃油加油管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilAdd frm = Oil.Viewer.FrmOilAdd.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃油消耗管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilConsume frm = Oil.Viewer.FrmOilConsume.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油申请管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilApply frm = Oil.Viewer.FrmOilApply.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油订购管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilOrder frm = Oil.Viewer.FrmOilOrder.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        private void 润滑油消耗管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilLuboilConsume frm = Oil.Viewer.FrmOilLuboilConsume.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 月度润滑油报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilLuboilReport frm = Oil.Viewer.FrmOilLuboilReport.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃润油月度消耗报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilReport frm = Oil.Viewer.FrmOilReport.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        #endregion

        #region 基础信息部分

        private void mnuCustomer_Info_Click(object sender, EventArgs e)
        {
            FrmManufacturer frm = FrmManufacturer.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSys_Basic_Port_Click(object sender, EventArgs e)
        {
            FrmPortInfo frm = FrmPortInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSys_Basic_Warehouse_Click(object sender, EventArgs e)
        {
            FrmShipWareHouse frm = FrmShipWareHouse.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSys_Basic_HeadShip_Click(object sender, EventArgs e)
        {
            FrmPostInfo frm = FrmPostInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSys_Basic_Deport_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = FrmDepartment.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuOil_VoyTimes1_Click(object sender, EventArgs e)
        {
            FrmVoyage frm = FrmVoyage.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 模板管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModelUpdate frm = FrmModelUpdate.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        //pms的基础信息.
        private void mnuSys_Basic_Pms_MeaRepType_Click(object sender, EventArgs e)
        {
            FrmMeaReportType frm = new FrmMeaReportType();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }




        #endregion

        #region 窗口部分

        private void 关闭所有窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form _form in this.MdiChildren)
            {
                _form.Close();
            }
        }
        private void 层叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 横向平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 排列图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        #endregion

        #region 系统部分

        private static ILoginUser GetLoginUserInfo(string userId)
        {
            return (Post)PostService.Instance.GetOneObjectById(userId);
        }
        //切换用户(方便调试,发布时不可以有)
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin("ShipMis0", "LSShipMis_Land.Properties.Settings.ShipMisSqlConnt",
                    "LSShipMis_Land.Properties.Settings.ShipMisSqlLobConnt");
            frmLogin.GetLoginUserInfo += new FrmLogin.getLoginUserInfo(GetLoginUserInfo);
            DialogResult dialogResult = frmLogin.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                foreach (Form _form in this.MdiChildren)
                {
                    _form.Close();
                }
                //报警注册部分.
                RemindRegister();
                //清除临时打开的文件目录.

                string path = (@"d:\ShipMisFiles\FileOperation");
                if (Directory.Exists(path))
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch
                    { }
                }
                checkRight();
                resetUserAndPost();
                GetCustomerTables();
            }

        }

        private void 同步日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SynchDll.FrmSynchLog frm = new SynchDll.FrmSynchLog(true);
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }
        private void mnuSys_Help_Click(object sender, EventArgs e)
        {

            CommonOpt commonOpt = new CommonOpt();

            string helpPath = commonOpt.GetCurrentPath("\\help.chm");
            System.Diagnostics.Process.Start("hh", helpPath);
        }

        private void mnuSys_About_Click(object sender, EventArgs e)
        {
            LSShipMis_Ship.Common.AboutBox about = new LSShipMis_Ship.Common.AboutBox();
            //about.MdiParent = this;
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("hh", Application.StartupPath.ToString() + @"\help.chm");
        }

        //管理员特权.

        private void 用户添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmSysUser frm = SysLs.Forms.FrmSysUser.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmRightSet frm = SysLs.Forms.FrmRightSet.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 船员职务设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmShipUserHead frm = SysLs.Forms.FrmShipUserHead.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 显示设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditTableInfo frm = new FrmEditTableInfo();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void menuArgumentSet_Click(object sender, EventArgs e)
        {
            FrmArgumentSet frm = FrmArgumentSet.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        //管理员特权  结束.

        private void mnuSys_User_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmEditPwd frm = new SysLs.Forms.FrmEditPwd();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.ShowDialog();
        }

        private void 数据处理接口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatabase frm = new FrmDatabase();
            frm.ShowDialog();
        }

        private void whatsNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", Application.StartupPath + @"\\what'snew.txt");
            }
            catch (Exception ee)
            {
                MessageBoxEx.Show("当前操作用户无notepad或notepad的默认路径被篡改,无法打开what's new文件!更多消息见:" + ee.Message);
            }
        }
        private void 还原背景图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOldImage();
        }
        private void 更换背景图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogEx.ShowDialog(dlgBackImage) == DialogResult.OK)
            {
                string file = dlgBackImage.FileName;
                FileInfo fileInfo = new FileInfo(file);
                string copyto = Application.StartupPath + "\\" + fileInfo.Name;
                try
                {
                    fileInfo.CopyTo(copyto, true);
                }
                catch { }
                ConstParameter.SetRegedit("backImage", copyto);
                showImage();
            }

        }
        private void showImage(string filesName, bool isTheOld)
        {
            if (!string.IsNullOrEmpty(filesName) && File.Exists(filesName))
            {
                try
                {
                    Image image = new Bitmap(filesName, true);
                    this.BackgroundImage = image;
                }
                catch
                { }
            }
            else
            {
                if (!isTheOld) showOldImage();
            }
        }
        private void showOldImage()
        {
            string copyto = Application.StartupPath + "\\" + "back.jpg";
            ConstParameter.SetRegedit("backImage", copyto);
            showImage(copyto, true);
        }
        private void showImage()
        {
            string file = ConstParameter.GetRegedit("backImage");
            showImage(file, false);
        }

        #endregion

        #region 报警部分

        private void fRemindTextShow(string x)
        {
            toolStripStatusLabel4.Text = x;
        }
        /// <summary>
        /// 报警注册部分.
        /// </summary>
        private void RemindRegister()
        {

            if (manager != null)
                foreach (ToolStripItem item in manager.statusLabel)
                    statusStrip.Items.Remove(item);
            //报警管理对象.
            manager = new RemindManager(statusStrip, fRemindTextShow);

            #region 工作部分
            manager.register(Common.PeriodValidity.ValidTimeType.WorkOrder, CommonOperation.ConstParameter.ShipUserId);
            manager.register(Common.PeriodValidity.ValidTimeType.WorkOrderConfirm, CommonOperation.ConstParameter.ShipUserId);
            manager.register(Common.PeriodValidity.ValidTimeType.WorkOrderSpareNotEnough, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region 备件物资部分
            if (CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out sChkMessage))
            {

                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SpareStockLower, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SpareIn, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SpareOut, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SpareStockck, CommonOperation.ConstParameter.ShipUserId);

                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialIn, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialOut, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialStockck, CommonOperation.ConstParameter.ShipUserId);

            }
            #endregion

            #region 证书部分
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.SHIPCERTIFICATION_EDIT, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.ShipCert, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region 修理报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.REPAIR_OPERATION, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.RepairApplyAlertNotComplete, CommonOperation.ConstParameter.ShipUserId);
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.REPAIR_OPERATION, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.RepairApplyAlertCheck, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region 油料报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_OPERATION, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.HOilApplyAlertCheck, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            manager.register(Common.PeriodValidity.ValidTimeType.XFJSAlertCheck, CommonOperation.ConstParameter.ShipUserId);
            manager.register(Common.PeriodValidity.ValidTimeType.TDSBAlertCheck, CommonOperation.ConstParameter.ShipUserId);
            manager.checkedStatus();
        }
        /// <summary>
        /// timer事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerRemind_Tick(object sender, EventArgs e)
        {
            timerRemind.Stop();
            if (manager != null && !CommonOperation.ConstParameter.SupperUser)
                manager.checkedStatus();
            timerRemind.Start();
        }
        #endregion

        /// <summary>
        /// 检查用户的操作权限，设置无权限的菜单为不可见.
        /// </summary>
        private void checkRight()
        {
            //管理员设置功能在测试版不具备.
            管理员特权功能ToolStripMenuItem.Visible = CommonOperation.ConstParameter.SupperUser;

            #region 设备保养
            bool pmsManager = proxyRight.CheckRight(CommonOperation.ConstParameter.OPERATION_PMS, out sChkMessage);
            bool PMSInit = proxyRight.CheckRight(CommonOperation.ConstParameter.BASE_WORKINFO_EDIT, out sChkMessage);

            mnuPms2.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN || pmsManager || PMSInit;
            mnuPms2_WorkInfo.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || PMSInit;
            mnuPms2_TimerComp.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || pmsManager;
            mnuPms_floorMonth.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISDECKMAN || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
            mnuPms_machineMonth.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;

            工作信息模板分类管理ToolStripMenuItem.Visible = PMSInit;
            工作信息选择ToolStripMenuItem.Visible = PMSInit;
            #endregion

            #region CMS部分 轮机长本身就具备维护权限,轮机人员都具备查看权限

            //bool CMSManage = proxyRight.CheckRight(CommonOperation.ConstParameter.CMS_MANAGE, out sChkMessage)
            //    || (CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN && CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER);
            //bool CMSView = proxyRight.CheckRight(CommonOperation.ConstParameter.CMS_VIEW, out sChkMessage)
            //    || CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;

            bool CMSManage = false;
            bool CMSView = false;
            Menu_CMSArrange.Visible = CMSManage;
            Menu_CMSCCSChecking.Visible = CMSManage;
            Menu_CMSDefine.Visible = CMSManage;
            Menu_CMSRectify.Visible = CMSManage;
            Menu_CMSSelfCheckingItem.Visible = CMSManage;
            Menu_CMSHistory.Visible = CMSManage || CMSView;
            #endregion

            #region 船舶参数
            bool equipmentManage = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENT_EDIT, out sChkMessage) ||
                proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out sChkMessage);
            设备分类管理ToolStripMenuItem1.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out sChkMessage);
            设备归类管理ToolStripMenuItem1.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out sChkMessage);
            #endregion

            //ism部分.
            mnuIsm_Ism.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;

            #region 证书部分
            mnuShipCert.Visible = true;
            bool certBassV = proxyRight.CheckRight(CommonOperation.ConstParameter.SHIPCERTIFICATION_EDIT, out sChkMessage)
                || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
            船舶证书信息查看ToolStripMenuItem.Visible = certBassV;
            toolStripSeparator6.Visible = certBassV;
            toolStripMenuItem13.Visible = certBassV;
            mnuShipCert_Cert.Visible = certBassV;
            mnuShipCert_Depart.Visible = certBassV;
            船舶证书检验历史ToolStripMenuItem.Visible = certBassV;
            #endregion

            #region 备件菜单
            //备件初始化的权限给部门长.
            bool itemEdit = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEMS_EDIT, out sChkMessage);
            bool itemView = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out sChkMessage);
            bool itemInit = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_INIT, out sChkMessage);
            //其他只要是高级船员就可以.
            mnuSpare.Visible = itemView || itemEdit || CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            mnuSpare_Stock.Visible = itemInit;
            toolStripMenuItem10.Visible = itemEdit;
            mnuSpare_SpareInfo.Visible = itemEdit;
            mnuSparePurchaseApply.Visible = itemView;
            #endregion

            #region 物资部分
            //物资基本信息编辑.
            mnuMaterial.Visible = itemView || itemEdit || CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            mnuMaterial_Stock.Visible = itemInit;
            toolStripMenuItem20.Visible = itemEdit;
            mnuMaterial_BaseInfo.Visible = itemEdit;
            物资分类维护ToolStripMenuItem.Visible = itemEdit;
            mnuMaterial_Purchase_Apply.Visible = itemView;
            #endregion

            //#region 船员部分.
            //mnuSeaman.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage)
            //    || CommonOperation.ConstParameter.SupperUser;
            //#endregion

            #region 海丰油水部分

            bool HOIL_INIT = proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_INIT, out sChkMessage);
            bool HOIL_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_OPERATION, out sChkMessage)
                || (CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN && CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN)
                || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;

            menuOil.Visible = HOIL_INIT || HOIL_OPERATION;//主菜单是否显示.

            toolStripMenuItem7.Visible = HOIL_INIT;
            油品管理ToolStripMenuItem.Visible = HOIL_INIT;
            油品船舶分配ToolStripMenuItem.Visible = HOIL_INIT;
            淡水管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            燃油加油管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            燃油消耗管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            润滑油申请管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            润滑油订购管理toolStripMenuItem.Visible = HOIL_OPERATION;
            润滑油消耗管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            //只有船长或者高级船员才能看到,要么就得是岸端.

            月度润滑油报告ToolStripMenuItem.Visible = (CommonOperation.ConstParameter.IsLandVersion && HOIL_OPERATION)
                || (CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN && CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN)
                || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
            燃润油月度消耗报表ToolStripMenuItem.Visible = HOIL_OPERATION;
            #endregion

            #region 费用管理部分

            bool COST_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage);

            menuCost.Visible = COST_OPERATION;//主菜单是否显示.
            费用简单分类ToolStripMenuItem.Visible = COST_OPERATION;
            废旧物资管理ToolStripMenuItem.Visible = COST_OPERATION;
            #endregion

            #region 修理管理部分
            bool REPAIR_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.REPAIR_OPERATION, out sChkMessage);
            menuRepair.Visible = REPAIR_OPERATION || CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            修理申请ToolStripMenuItem.Visible = REPAIR_OPERATION || CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            完工单管理ToolStripMenuItem.Visible = REPAIR_OPERATION || CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            #endregion

            #region 基础信息部分

            bool baseEdit = proxyRight.CheckRight(CommonOperation.ConstParameter.BASIC_EDIT, out sChkMessage) || CommonOperation.ConstParameter.SupperUser;
            mnuSys_Basic.Visible = baseEdit;

            #endregion
        }

        #region 定时检测最新版本
        /// <summary>
        /// 检测最新版本.
        /// </summary>       
        private void tCheckVersion_Tick(object sender, EventArgs e)
        {
            tCheckVersion.Stop();

            string strExePath = Application.StartupPath;
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(strExePath + "\\LSShipMis_Ship.exe");
            String strFileVersion = string.Format("{0}.{1}.{2}.{3}", myFileVersion.FileMajorPart, myFileVersion.FileMinorPart, myFileVersion.FileBuildPart, myFileVersion.FilePrivatePart);
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            string strObjectID = string.Format(@"SELECT TOP 1 VersionNo
                                            FROM dbo.T_AutoUpdateVersion
                                            WHERE IsValid=1
                                            ORDER BY CreateDate DESC");
            DataTable dtVersion = null;
            string errMessage = "";
            if (dbAccess.GetDataTable(strObjectID, out dtVersion, out errMessage))
            {
                if (dtVersion != null && dtVersion.Rows.Count > 0)
                {
                    if (dtVersion.Rows[0][0].ToString() != strFileVersion)
                    {
                        DialogResult result = MessageBox.Show("存在新版本软件,是否下载?", "请注意", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            tCheckVersion.Start();
                        }
                        else
                        {
                            Process.Start(Application.StartupPath + "\\ShipLogin.exe");
                            this.Close();
                        }
                    }
                }
            }
        }
        #endregion

        private void FrmMdiMain_MdiChildActivate(object sender, EventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);

        }

        private void FrmMdiMain_Activated(object sender, EventArgs e)
        {
            //注册个热键Alt+C为显示数据库连接信息
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.Z);
        }

        private void FrmMdiMain_Deactivate(object sender, EventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
        }

        #region 注册系统热键
        /// <summary>
        /// 100 显示数据库连接信息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键.
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);
                    break;
            }
            base.WndProc(ref m);
        }
        private void ProcessHotkey(Message m)
        {
            IntPtr id = m.WParam;
            int sid = (int)id;
            switch (sid)
            {
                case 100:
                    FrmOptConfig optConfig = new FrmOptConfig(true);
                    optConfig.IsShow = true;
                    optConfig.ShowDialog();
                    break;
            }
        }
        #endregion

        private void PmsAnnualPlan_Click(object sender, EventArgs e)
        {
            FrmPmsAnnualPlan frm = FrmPmsAnnualPlan.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

    }
}