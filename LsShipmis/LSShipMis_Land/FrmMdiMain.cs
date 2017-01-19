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
using LSShipMis_Land.Common;
using LSShipMis_Land.Common.Classes;
using LSShipMis_Land.SysLs.Services;
using LSShipMis_Land.Common.Remind;
using System.Diagnostics;
using System.Xml;
using FileOperation;
using LSShipMis_Land.Properties;
using CustomerTable.Forms;
using StorageManage.Viewer;
using CommonOperation;
using CommonOperation.BaseClass;
using CommonOperation.Functions;
using CommonViewer;
using CommonViewer.MultiLanguage;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using FileOperationBase.Services;
using FileOperation.Forms;
using ItemsManage.Viewer;
using ItemsManage.Services;
using ItemsManage.Report;
using ItemsManage.Viewer.Forms;
using Maintenance.Report;
using Maintenance.Viewer;
using SeaChartManage.Forms;
using BaseInfo.DataAccess;
using BaseInfo.Viewer;
using Cost.Viewer;
using SAPFunction.Viewer;
using FileOperationBase.FileServices;
using CMSManage.Viewer;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using System.Threading;
using SAPFunction.Services;
using SynchDll;

namespace LSShipMis_Land
{
    /// <summary>
    /// 系统总体MDI主窗体.
    /// </summary>
    public partial class FrmMdiMain : CommonViewer.BaseForm.FormBase, IFileBoundShow
    {

        private string sChkMessage = "";    //权限检查提示信息（没有配置或者没有权限的提示）.
        RemindManager manager;
        Bitmap backImage;
        Bitmap tmpImage;
        static float widthHeightRate = -1;
        private SysUserService sysUserService = new SysUserService();

        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.

        bool closeWithoutAsk = false;

        #region IFileBoundShow 成员

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

        #region 菜单通用功能

        /// <summary>
        ///  初始化函数.
        /// </summary>
        public FrmMdiMain()
        {
            InitializeComponent();
            if (ConstParameter.GetRegedit("IsService") == "1")
            {
                timerAutoSendMessage.Enabled = true;
                string SendMessageSpace = CommonOperation.ConstParameter.ArgumentSetCollection["SendMessageSpace"];
                timerAutoSendMessage.Interval = Convert.ToInt32(1000 * 60 * Convert.ToDecimal(SendMessageSpace));
                timerAutoSendMessage.Start();
            }
            LSShipMis_Land.Common.EnvironmentParm.TempFileSavePath = Path.GetTempPath() + "ShipmanageTempFile\\";
            FileBoundingOperation.Instance.FileBoundShow = this;
            CommonViewConfig.MainForm = this;
            showImage();

        }
        private void FrmMdiMain_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();


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

        private void showImage(string filesName, bool isTheOld)
        {
            if (!string.IsNullOrEmpty(filesName) && File.Exists(filesName))
            {
                try
                {
                    backImage = new Bitmap(filesName, true);
                    if (backImage.Height == 0)
                    {
                        throw new Exception("无法找到背景图片.");
                    }
                    widthHeightRate = (float)backImage.Width / backImage.Height;
                    tmpImage = (Bitmap)backImage.Clone();
                    this.BackgroundImage = new Bitmap(backImage, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    DrawBackGroundImage();
                }
                catch { }
            }
            else
            {
                if (!isTheOld) showOldImage();
            }
        }
        private void DrawBackGroundImage()
        {
            Graphics g = Graphics.FromImage(this.BackgroundImage);
            //当新的宽/高> 原比例

            float x = 0;
            float y = 0;
            float newWidth = statusStrip.Width;
            float newHeight = statusStrip.Location.Y - (menuStripMain.Location.Y + menuStripMain.Height);
            float newRate = (float)newWidth / newHeight;
            if (newRate > widthHeightRate)
            {
                y = (newHeight - newWidth / widthHeightRate) / 2;
                newHeight -= 2 * y;
            }
            else if (newRate < widthHeightRate)
            {
                x = (newWidth - widthHeightRate * newHeight) / 2;
                newWidth -= 2 * x;
            }
            g.DrawImage(tmpImage, new RectangleF(x, y, newWidth, newHeight));
        }

        private delegate void DelegateGetTable();

        private void ResetHeader()
        {
            string whichUser;
            try
            {
                whichUser = sysUserService.GetPersonBelong(CommonOperation.ConstParameter.UserId);
            }
            catch
            { whichUser = ""; }
            this.Text = whichUser + "海丰船舶管理系统(陆地版)——" + CommonOperation.ConstParameter.MAINVERSION;

        }
        private void FrmMdiMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            toolStripMenuItem15.Visible = true;
#endif
            ResetHeader();
            //Console.WriteLine(DateTime.Now.ToString("mm:ss:fff"));

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
            //Console.WriteLine(DateTime.Now.ToString("mm:ss:fff"));
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

        #region 获取体系文件-定制报表
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
        #endregion

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

        private void FrmMdiMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            FolderDbService.Instance.ClearAllEmptyFolderOfWhichType(CommonOperation.Enum.FileBoundingTypes.COMPONENTFILES);
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

        private void Menu_CMSCCSChecking_Click(object sender, EventArgs e)
        {
            FrmSocietyChecking frm = FrmSocietyChecking.Instance;
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

        #region 船舶参数

        private void 船舶信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseInfo.Viewer.FrmShipInfo frm = BaseInfo.Viewer.FrmShipInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 船舶设备参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComponentManage frm = FrmComponentManage.Instance;
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

        //===================已停用.

        private void 设备归类管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsManage.Viewer.FrmEquipmentSortOut frm = ItemsManage.Viewer.FrmEquipmentSortOut.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.Show();
        }
        //===================

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

        #region PMS管理菜单部分

        private void mnuPms_WorkInfo_Click(object sender, EventArgs e)
        {
            FrmWorkInfo frm = FrmWorkInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms_WorkBillTrace_Click(object sender, EventArgs e)
        {
            FrmWorkOrderTrace frm = FrmWorkOrderTrace.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPms_WorkOrderHis_View_Click(object sender, EventArgs e)
        {
            FrmWorkOrderHistory frm = FrmWorkOrderHistory.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 甲板部月度计划形成与跟踪ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 工作信息模板分类管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWorkinfoTempletClass frm = FrmWorkinfoTempletClass.Instance;
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

        private void pMS初始化打印工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmToolWorkInfoMain frm = FrmToolWorkInfoMain.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuPmsAnnualPlanAdjustment_Click(object sender, EventArgs e)
        {
            FrmPmsAnnualPlanAdjustment frm = FrmPmsAnnualPlanAdjustment.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion

        #region ISM体系文件部分

        private void iSM管理ToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void 机务经理常用表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperation.Forms.FrmFrequentlyFormEdit frm = FileOperation.Forms.FrmFrequentlyFormEdit.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        #endregion

        #region 备件管理菜单部分

        private void mnuSparePurchaseApply_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmSparePurchaseApply frm = StorageManage.Viewer.FrmSparePurchaseApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        private void mnuSparePurchaseOrder_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmSparePurchaseOrder frm = StorageManage.Viewer.FrmSparePurchaseOrder.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void mnuSpareCertificate_Click(object sender, EventArgs e)
        {
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("VoucherApplyCompany"))
            {
                MessageBoxEx.Show("请先配置系统参数:VoucherApplyCompany(生成凭证时的申请公司)");
                return;
            }
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherSpareCost"))
            {
                MessageBoxEx.Show("请先配置系统参数:OtherSpareCost(sap映射时,当备件没有所属设备找不到设备分类对应的科目是,就强制指定为它)");
                return;
            }
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherSpareCostName"))
            {
                MessageBoxEx.Show("请先配置系统参数:OtherSpareCostName(sap映射时,当备件没有所属设备找不到设备分类对应的科目是,就强制指定为它)");
                return;
            }
            StorageManage.Viewer.FrmSpareVoucher frm = StorageManage.Viewer.FrmSpareVoucher.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        //private void mnuSpare_Apply_Click(object sender, EventArgs e)
        //{
        //    //备件申请有两种模式：一种是一个申请单只能针对一个设备（标记为1），另一个是一个申请单可以对多个设备的备件进行申请（标记为2）.

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

        private void mnuSpare_Stock_Click(object sender, EventArgs e)
        {
            FrmSpareOperation frm = FrmSpareOperation.Instance;
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

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            FrmSpareStockInit frm = FrmSpareStockInit.Instance;
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

        #region 物资管理菜单部分

        private void mnuMaterial_Purchase_Apply_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmMaterialPurchaseApply frm = StorageManage.Viewer.FrmMaterialPurchaseApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void mnuMaterial_Purchase_Order_Click(object sender, EventArgs e)
        {
            StorageManage.Viewer.FrmMaterialPurchaseOrder frm = StorageManage.Viewer.FrmMaterialPurchaseOrder.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }

        private void mnuMaterialVoucher_Click(object sender, EventArgs e)
        {
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("VoucherApplyCompany"))
            {
                MessageBoxEx.Show("请先配置系统参数:VoucherApplyCompany(生成凭证时的申请公司)");
                return;
            }
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherMaterialCost"))
            {
                MessageBoxEx.Show("请先配置系统参数:OtherMaterialCost(sap映射时,当物资没有所属设备找不到设备分类对应的科目是,就强制指定为它)");
                return;
            }
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherMaterialCostName"))
            {
                MessageBoxEx.Show("请先配置系统参数:OtherMaterialCostName(sap映射时,当物资没有所属设备找不到设备分类对应的科目是,就强制指定为它)");
                return;
            }
            StorageManage.Viewer.FrmMaterialVoucher frm = StorageManage.Viewer.FrmMaterialVoucher.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
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

        private void mnuMaterial_Stock_Click(object sender, EventArgs e)
        {
            FrmMaterialOperation frm = FrmMaterialOperation.Instance;
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

        private void mnuMaterial_Info_Click(object sender, EventArgs e)
        {
            FrmMaterialBaseEdit frm = FrmMaterialBaseEdit.Instance;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 物资分类信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialTypeEdit frm = FrmMaterialTypeEdit.Instance;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion

        #region 海丰油料部分

        private void 油品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Oil.Viewer.FrmOil frm = Oil.Viewer.FrmOil.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 油品船舶分配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilOfShip frm = Oil.Viewer.FrmOilOfShip.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 淡水管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmWater frm = Oil.Viewer.FrmWater.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃油加油管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilAdd frm = Oil.Viewer.FrmOilAdd.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃油消耗管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilConsume frm = Oil.Viewer.FrmOilConsume.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油申请管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilApply frm = Oil.Viewer.FrmOilApply.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilOrder frm = Oil.Viewer.FrmOilOrder.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油凭证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilVoucher frm = Oil.Viewer.FrmOilVoucher.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 润滑油月消耗管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilLuboilConsume frm = Oil.Viewer.FrmOilLuboilConsume.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 月度润滑油报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilLuboilReport frm = Oil.Viewer.FrmOilLuboilReport.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 燃润油月度消耗报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilReport frm = Oil.Viewer.FrmOilReport.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        #endregion

        #region 证书部分

        private void mnuShipCert_Register_Click(object sender, EventArgs e)
        {
            ShipCertification.Report.FrmCertificationReportOfOneShip frm = ShipCertification.Report.FrmCertificationReportOfOneShip.Instance;
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

        #region 船员管理菜单部分

        private void mnuSeaman_Info_Click(object sender, EventArgs e)
        {
            Seaman.Forms.FrmSeamanInfo frm = Seaman.Forms.FrmSeamanInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region 航海资料管理

        private void 海图信息管理toolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChartBaseInfoManage frm = FrmChartBaseInfoManage.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 海图目录管理ToolStripMenuItem_Click(object sender, EventArgs e)
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

        #region 费用管理

        //费用基础信息部分.
        private void 费用科目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCostSubjects frm = FrmCostSubjects.Instance;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        private void mnuAccountPosition_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmCostAccountPosition frm = Cost.Viewer.FrmCostAccountPosition.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        //机务费用.
        private void 船舶年度预算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmAnnualBudget frm = Cost.Viewer.FrmAnnualBudget.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 其它费用管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmShipOwnerCost frm = Cost.Viewer.FrmShipOwnerCost.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmOuterSAPCost frm = Cost.Viewer.FrmOuterSAPCost.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 预算管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmBudget frm = Cost.Viewer.FrmBudget.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 单日凭证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmVoucher frm = Cost.Viewer.FrmVoucher.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 凭证审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmVoucherApproval frm = Cost.Viewer.FrmVoucherApproval.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 单船费用核算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmShipCaculate frm = Cost.Viewer.FrmShipCaculate.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 费用统计清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmShipBill frm = Cost.Viewer.FrmShipBill.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 费用汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmSum frm = Cost.Viewer.FrmSum.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmCostBill frm = Cost.Viewer.FrmCostBill.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        //船舶费用简单管理.

        private void 费用简单分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmSimpleclass frm = Cost.Viewer.FrmSimpleclass.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.BringToFront();
            frm.Show();
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

        private void 保险费用管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cost.Viewer.FrmInsurance frm = Cost.Viewer.FrmInsurance.Instance;
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
        private void 生成修理凭证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("VoucherApplyCompany"))
            {
                MessageBoxEx.Show("请先配置系统参数:VoucherApplyCompany(生成凭证时的申请公司)");
                return;
            }
            Repair.Viewer.FrmCreateCertification frm = Repair.Viewer.FrmCreateCertification.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        private void 坞修总结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repair.Viewer.FrmDockRepairSummarize frm = Repair.Viewer.FrmDockRepairSummarize.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        private void 厂修记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repair.Viewer.FrmDockRepairRecord frm = Repair.Viewer.FrmDockRepairRecord.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        #endregion

        #region 基础信息部分

        private void mnuSys_Basic_Warehouse_Click(object sender, EventArgs e)
        {
            //bsnTableName = "T_Som_WareHouse";
            //sWinText = "仓库信息";

            //BasicData.BasicDtService frmStyle = new LSShipMis_Land.BasicData.BasicDtService(bsnTableName, sWinText);
            //frmStyle.openForm(this);
            FrmShipWareHouse frm = FrmShipWareHouse.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuSys_Basic_Port_Click(object sender, EventArgs e)
        {
            FrmPortInfo frm = FrmPortInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSys_Basic_HeadShip_Click(object sender, EventArgs e)
        {
            FrmPostInfo frm = FrmPostInfo.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
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

        private void 客户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManufacturer frm = FrmManufacturer.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuOil_VoyTimes_Click(object sender, EventArgs e)
        {
            FrmVoyage frm = FrmVoyage.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuCurrency_Click(object sender, EventArgs e)
        {
            FrmCurrency frm = FrmCurrency.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuCurrencyRate_Click(object sender, EventArgs e)
        {
            FrmCurrencyRate frm = FrmCurrencyRate.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 模板文件管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmModelUpdate frm = FrmModelUpdate.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        //pms专用.
        private void mnuPms_BasicDt_MeaRepType_Click(object sender, EventArgs e)
        {
            FrmMeaReportType frm = new FrmMeaReportType();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        //船舶分配.
        private void 船舶分配toolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseInfo.Viewer.FrmUserShip2 frm = BaseInfo.Viewer.FrmUserShip2.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.ShowDialog();
        }

        //审批流程定义部分.
        private void 流程对象定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipMisZHJ_WorkFlow.Forms.FrmWorkFlowObj frm = ShipMisZHJ_WorkFlow.Forms.FrmWorkFlowObj.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 流程定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipMisZHJ_WorkFlow.Forms.FrmWorkFlowDefine frm = ShipMisZHJ_WorkFlow.Forms.FrmWorkFlowDefine.Instance;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        #endregion

        #region 窗口部分

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

        private void 关闭所有窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form _form in this.MdiChildren)
            {
                _form.Close();
            }
        }

        #endregion

        #region 系统部分

        private static ILoginUser GetLoginUserInfo(string userId)
        {
            return (Post)PostService.Instance.GetOneObjectById(userId);
        }
        //切换用户(方便调试,发布时不可以有)
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin("ShipMis1", "LSShipMis_Land.Properties.Settings.ShipMisSqlConnt",
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
                ResetHeader();
            }
        }
        //帮助部分.
        private void mnuSys_Help_Click(object sender, EventArgs e)
        {
            CommonOpt commonOpt = new CommonOpt();
            string helpPath = commonOpt.GetCurrentPath("\\help.chm");
            System.Diagnostics.Process.Start("hh", helpPath);
        }

        private void mnuSys_About_Click(object sender, EventArgs e)
        {
            LSShipMis_Land.Common.AboutBox about = new LSShipMis_Land.Common.AboutBox();
            //about.MdiParent = this;
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }

        private void whatsNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", Application.StartupPath + "\\what'snew.txt");
            }
            catch (Exception ee)
            {
                MessageBoxEx.Show("当前操作用户无notepad或notepad的默认路径被篡改,无法打开what's new文件!更多消息见:" + ee.Message, "系统提示");
            }
        }

        //管理员特权部分.

        private void 系统用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmSysUser frm = new SysLs.Forms.FrmSysUser();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
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

        private void 数据处理接口ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDatabase frm = new FrmDatabase();
            frm.ShowDialog();
        }

        private void menuSysArgumentSet_Click(object sender, EventArgs e)
        {
            BaseInfo.Viewer.FrmArgumentSet frm = BaseInfo.Viewer.FrmArgumentSet.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.BringToFront();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        //口令部分.
        private void mnuSys_User_Pwd_Click(object sender, EventArgs e)
        {
            SysLs.Forms.FrmEditPwd frm = new SysLs.Forms.FrmEditPwd();
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.ShowDialog();
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

        private void 数据复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LSShipMis_Land.SysLs.Forms.FrmComponentCopy frm = LSShipMis_Land.SysLs.Forms.FrmComponentCopy.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion

        #region SAP部分
        private void 映射管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAPFunction.Viewer.FrmMapping frm = SAPFunction.Viewer.FrmMapping.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 报文管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAPFunction.Viewer.FrmMessage frm = SAPFunction.Viewer.FrmMessage.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }

        private void 库存对比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAPFunction.Viewer.FrmStorageContrast frm = SAPFunction.Viewer.FrmStorageContrast.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront(); frm.Show();
        }
        #endregion

        #region 报警部分
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

            #region 备件申请船队审核报警
            bool ItemManage = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out sChkMessage)
              || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
              || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
              || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage);
            if (ItemManage)
            {
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseApplyCheckOnce, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseOrderCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseOrderNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseOrderReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.SparePurchaseOrderCheckOnce, CommonOperation.ConstParameter.ShipUserId);


                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                {
                    manager.register(Common.PeriodValidity.ValidTimeType.SpareInBySpareApply, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.MaterialInByMaterialApply, CommonOperation.ConstParameter.ShipUserId);

                    manager.register(Common.PeriodValidity.ValidTimeType.SpareIn, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.SpareOut, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.SpareStockck, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.SpareNotVoucher, CommonOperation.ConstParameter.ShipUserId);
                }

            }
            #endregion

            #region 物资申请船队审核报警
            if (ItemManage)
            {
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseApplyCheckOnce, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseOrderCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseOrderNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseOrderReject, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.MaterialPurchaseOrderCheckOnce, CommonOperation.ConstParameter.ShipUserId);

                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                {
                    manager.register(Common.PeriodValidity.ValidTimeType.MaterialIn, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.MaterialOut, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.MaterialStockck, CommonOperation.ConstParameter.ShipUserId);
                    manager.register(Common.PeriodValidity.ValidTimeType.MaterialNotVoucher, CommonOperation.ConstParameter.ShipUserId);
                }

            }
            #endregion

            #region 工单报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.OPERATION_PMS, out sChkMessage))
                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.WorkOrder, CommonOperation.ConstParameter.ShipUserId);
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.OPERATION_PMS, out sChkMessage))
                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.WorkOrderConfirm, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region 证书部分
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.SHIPCERTIFICATION_EDIT, out sChkMessage))
                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.ShipCert, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region SAP报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.SAP_OPERATION, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.SAPMapping, CommonOperation.ConstParameter.ShipUserId);
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.SAP_OPERATION, out sChkMessage))
                manager.register(Common.PeriodValidity.ValidTimeType.SAPMessage, CommonOperation.ConstParameter.ShipUserId);
            #endregion

            #region 修理报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.REPAIR_OPERATION, out sChkMessage))
            {
                manager.register(Common.PeriodValidity.ValidTimeType.RepairApplyAlertNotComplete, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.RepairApplyAlertCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.RepairApplyAlertCheckOnce, CommonOperation.ConstParameter.ShipUserId);
                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.RepairNotVoucher, CommonOperation.ConstParameter.ShipUserId);
            }
            #endregion

            #region 油料报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_OPERATION, out sChkMessage))
            {
                manager.register(Common.PeriodValidity.ValidTimeType.HOilApplyAlertCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.HOilApplyAlertCheckOnce, CommonOperation.ConstParameter.ShipUserId);
                if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.OilNotVoucher, CommonOperation.ConstParameter.ShipUserId);

            }
            #endregion

            #region 费用报警
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage))
            {
                manager.register(Common.PeriodValidity.ValidTimeType.VoucherAlertCheck, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.VoucherAlertCheckReject, CommonOperation.ConstParameter.ShipUserId);
                if ("机务财务岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    manager.register(Common.PeriodValidity.ValidTimeType.CostNotVoucher, CommonOperation.ConstParameter.ShipUserId);
            }
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.COST_VIEW, out sChkMessage))
            {
                manager.register(Common.PeriodValidity.ValidTimeType.VoucherAlertPassCheckOnce, CommonOperation.ConstParameter.ShipUserId);
                manager.register(Common.PeriodValidity.ValidTimeType.VoucherAlertNotPassCheckOnce, CommonOperation.ConstParameter.ShipUserId);
            }
            #endregion

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
        private void fRemindTextShow(string x)
        {
            toolStripStatusLabel4.Text = x;
        }

        #endregion

        /// <summary>
        /// 检查用户的操作权限，设置无权限的菜单为不可见.
        /// </summary>
        private void checkRight()
        {
            //管理员设置功能在测试版不具备.
            管理员特权功能ToolStripMenuItem.Visible = CommonOperation.ConstParameter.SupperUser;
            // if (CommonOperation.ConstParameter.SupperUser) return;
            #region 基础数据部分
            bool BasicV = proxyRight.CheckRight(CommonOperation.ConstParameter.BASIC_EDIT, out sChkMessage) || CommonOperation.ConstParameter.SupperUser;
            mnuSys_Basic.Visible = BasicV;

            #endregion

            #region 设备保养
            bool pmsViewer = proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_PMS, out sChkMessage);
            bool pmsManager = proxyRight.CheckRight(CommonOperation.ConstParameter.OPERATION_PMS, out sChkMessage);

            mnuPms.Visible = pmsViewer || pmsManager;
            mnuPms_WorkInfo.Visible = pmsViewer || pmsManager;
            mnuPms_WorkBillTrace.Visible = pmsViewer || pmsManager;
            mnuPms_WorkOrderHis_View.Visible = pmsViewer || pmsManager;
            工作信息模板分类管理ToolStripMenuItem.Visible = pmsManager;
            工作信息选择ToolStripMenuItem.Visible = pmsManager;
            mnuPmsAnnualPlanAdjustment.Visible = false;//pmsManager;
            #region 报表部分

            //轮机部年度计划原始表格维护ToolStripMenuItem.Visible = pmsViewer || pmsManager;
            轮机部月度计划形成与跟踪ToolStripMenuItem.Visible = pmsViewer || pmsManager;
            //甲板部年度计划原始表格维护ToolStripMenuItem.Visible = pmsViewer || pmsManager;
            甲板部月度计划形成与跟踪ToolStripMenuItem.Visible = pmsViewer || pmsManager;
            #endregion

            #endregion

            #region CMS部分
            //bool CMSManage = proxyRight.CheckRight(CommonOperation.ConstParameter.CMS_MANAGE, out sChkMessage);
            //bool CMSView = proxyRight.CheckRight(CommonOperation.ConstParameter.CMS_VIEW, out sChkMessage);
            bool CMSManage = false;
            bool CMSView = false;

            Menu_CMSArrange.Visible = CMSManage;
            Menu_CMSCCSChecking.Visible = CMSManage;
            Menu_CMSDefine.Visible = CMSManage;
            Menu_CMSHistory.Visible = CMSManage || CMSView;
            #endregion

            #region 船舶参数
            设备分类管理ToolStripMenuItem1.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out sChkMessage);
            设备归类管理ToolStripMenuItem1.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out sChkMessage);
            #endregion

            #region 物资部分
            bool ItemManage = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage);
            bool itemEdit = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEMS_EDIT, out sChkMessage);
            bool itemInit = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_INIT, out sChkMessage);
            mnuMaterial_Check.Visible = ItemManage;
            mnuMaterial_Out.Visible = ItemManage;
            mnuMaterial_Stock.Visible = ItemManage;
            mnuMaterial_In.Visible = ItemManage;
            mnuMaterial.Visible = ItemManage;
            mnuMaterialVoucher.Visible = ItemManage;
            mnuSparePurchaseApply.Visible = ItemManage;
            mnuSparePurchaseOrder.Visible = ItemManage;
            mnuSpareVoucher.Visible = ItemManage;
            mnuMaterial_Purchase_Apply.Visible = ItemManage;
            mnuMaterial_Purchase_Order.Visible = ItemManage;
            mnuSpare_Stock_Init.Visible = itemInit;
            mnuSpare_Check.Visible = ItemManage;
            mnuSpare_Stock.Visible = ItemManage;
            mnuSpare_Out.Visible = ItemManage;
            mnuSpare_In.Visible = ItemManage;
            mnuSpare.Visible = ItemManage;
            toolStripMenuItem2.Visible = itemEdit;
            mnuSpare_SpBasic.Visible = itemEdit;
            toolStripMenuItem26.Visible = itemEdit;
            mnuMaterial_Info.Visible = itemEdit;
            物资分类信息ToolStripMenuItem.Visible = itemEdit;
            #endregion

            #region 证书部分
            bool SHIPCERT_EDIT = proxyRight.CheckRight(CommonOperation.ConstParameter.SHIPCERTIFICATION_EDIT, out sChkMessage);
            mnuShipCert_Register.Visible = SHIPCERT_EDIT;

            toolStripSeparator5.Visible = SHIPCERT_EDIT;
            toolStripMenuItem7.Visible = SHIPCERT_EDIT;
            mnuShipCert_Cert.Visible = SHIPCERT_EDIT;
            mnuShipCert_Depart.Visible = SHIPCERT_EDIT;
            #endregion

            //#region 船员部分.

            //mnuSeaman.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage) || CommonOperation.ConstParameter.SupperUser;

            //#endregion

            #region 修理管理部分
            bool REPAIR_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.REPAIR_OPERATION, out sChkMessage);
            RepairMenuItem.Visible = REPAIR_OPERATION;//主菜单是否显示.

            修理申请ToolStripMenuItem.Visible = REPAIR_OPERATION;
            完工单管理ToolStripMenuItem.Visible = REPAIR_OPERATION;
            生成修理凭证ToolStripMenuItem.Visible = REPAIR_OPERATION;
            坞修总结ToolStripMenuItem.Visible = REPAIR_OPERATION;
            厂修记录ToolStripMenuItem.Visible = REPAIR_OPERATION;
            #endregion

            #region 海丰油水管理

            bool HOIL_INIT = proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_INIT, out sChkMessage);
            bool HOIL_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_OPERATION, out sChkMessage);
            bool HOIL_VIEW = proxyRight.CheckRight(CommonOperation.ConstParameter.HOIL_VIEW, out sChkMessage);

            menuHOil.Visible = HOIL_INIT || HOIL_OPERATION || HOIL_VIEW;//主菜单是否显示.

            toolStripMenuItem14.Visible = HOIL_INIT;
            油品管理ToolStripMenuItem.Visible = HOIL_INIT;
            油品船舶分配ToolStripMenuItem.Visible = HOIL_INIT;
            淡水管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            燃油加油管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            燃油消耗管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            润滑油申请管理ToolStripMenuItem.Visible = HOIL_OPERATION;
            润滑油ToolStripMenuItem.Visible = HOIL_OPERATION;
            月度润滑油报告ToolStripMenuItem.Visible = HOIL_OPERATION;
            燃润油月度消耗报表ToolStripMenuItem.Visible = HOIL_OPERATION;
            #endregion

            #region 费用管理

            bool COST_INIT = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_INIT, out sChkMessage);
            bool COST_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.COST_VIEW, out sChkMessage);
            bool COST_BILL = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_BILL, out sChkMessage);

            费用管理ToolStripMenuItem.Visible = COST_INIT || COST_OPERATION;//主菜单是否显示.

            mnuAccountPosition.Visible = COST_INIT;
            费用科目ToolStripMenuItem.Visible = COST_INIT;
            船舶年度预算ToolStripMenuItem.Visible = COST_INIT;

            其它费用管理ToolStripMenuItem.Visible = COST_OPERATION;
            周预算管理ToolStripMenuItem.Visible = COST_OPERATION;
            单日凭证ToolStripMenuItem.Visible = COST_OPERATION;
            凭证审批ToolStripMenuItem.Visible = COST_OPERATION;
            单船费用核算ToolStripMenuItem.Visible = COST_OPERATION;
            费用统计清单ToolStripMenuItem.Visible = COST_OPERATION;
            费用汇总ToolStripMenuItem.Visible = COST_OPERATION;
            toolStripMenuItem9.Visible = COST_BILL;

            费用简单分类ToolStripMenuItem.Visible = COST_OPERATION;
            废旧物资管理ToolStripMenuItem.Visible = COST_OPERATION;
            保险费用管理ToolStripMenuItem.Visible = COST_OPERATION;

            #endregion

            #region SAP
            bool SAP_OPERATION = proxyRight.CheckRight(CommonOperation.ConstParameter.SAP_OPERATION, out sChkMessage);
            sAPToolStripMenuItem.Visible = SAP_OPERATION;//主菜单是否显示.

            映射管理ToolStripMenuItem.Visible = SAP_OPERATION;
            报文管理ToolStripMenuItem.Visible = SAP_OPERATION;
            库存对比ToolStripMenuItem.Visible = SAP_OPERATION;
            #endregion

        }

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
                            this.Close();
                        }
                    }
                }
            }
        }

        private void synchLog_Click(object sender, EventArgs e)
        {
            SynchDll.FrmSynchLog frm = new SynchDll.FrmSynchLog(true);
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void timerAutoSendMessage_Tick(object sender, EventArgs e)
        {
            string err;
            CommonOperation.ConstParameter.ArgumentSetCollectionInit();
            try { MessageOperation.Instance.MappingMessage(out err); }
            catch { }
            try { MessageOperation.Instance.SendMessage(out err); }
            catch { }

        }


        private void FrmMdiMain_MdiChildActivate(object sender, EventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
        }

        private void 最小化到任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Visible = false;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;

            if (this.TopMost != true)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMdiMain_Resize(object sender, EventArgs e)
        {
            DrawBackGroundImage();
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

        private void aaaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSAPWarnSendMail frm = new FrmSAPWarnSendMail();
            frm.ShowDialog();
        }

        private void BtnPmsAnnualPlan_Click(object sender, EventArgs e)
        {
            FrmPmsAnnualPlan frm = FrmPmsAnnualPlan.Instance;
            frm.Text = ((System.Windows.Forms.ToolStripMenuItem)sender).Text;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


    }
}