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
using CMSManage.Services;
using CMSManage.DataObject;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;
using CommonOperation.BaseClass;
using OfficeOperation;

namespace CMSManage.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmCMSConfig : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCMSConfig instance = new FrmCMSConfig();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCMSConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCMSConfig.instance = new FrmCMSConfig();
                }
                return FrmCMSConfig.instance;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCMSConfig()
        {

            InitializeComponent();

            #region gridview委托部分
            ucObjectsGridView1.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView1_TheObjectChanged);
            ucObjectsGridView1.UserDoubleClick += new UCObjectsGridView.deleDoubleClick(ucObjectsGridView1_UserDoubleClick);
            #endregion

        }

        private void ucObjectsGridView1_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                ucCMSConfig1.ChangeData(theNewObject);
            }
            else
            {
                ucCMSConfig1.ClearData();
            }
        }

        private void ucObjectsGridView1_UserDoubleClick(int rowIndex)
        {
            CMSConfig cmsConfig = (CMSConfig)ucObjectsGridView1.GetObject(rowIndex);
            FrmEditOneCMSConfig frm = new FrmEditOneCMSConfig(cmsConfig);
            frm.ShowDialog();
            if (frm.NeedRetrieve) reloadDataAndScrollToRow(cmsConfig.GetId());
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmEditOneCMSConfig formNew = new FrmEditOneCMSConfig(ucShipSelect1.GetId());
            formNew.ShowDialog();
            //当新添加数据时，刷新ucObjectsGridView1的值.
            if (formNew.NeedRetrieve)
            {
                reloadData();//重载数据.
            }
        }
        private void reloadDataAndScrollToRow(string id)
        {
            reloadData();
            if (!string.IsNullOrEmpty(id))
            {
                ucObjectsGridView1.ScrollToColumnWithValue("CMS_CONFIG_ID", id);
            }
        }
        public void reloadData()
        {
            ucCMSConfig1.ClearData();
            DataTable dt;
            string err;
            dt = CMSConfigService.Instance.getInfoOfShip(ucShipSelect1.GetId(), out err);

            ucObjectsGridView1.Init(dt, CMSConfigService.Instance, "FrmCMSConfig");
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucCMSConfig1.DeleteObject();
            if (ucCMSConfig1.needRetrieve == true)
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
            ucCMSConfig1.UpdateObject();
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

        private void FrmCMSConfig_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            ucCMSConfig1.ItemChanged = new CommonOperation.BaseClass.CommonClass.deleItemChanged(workInfoChanged);
            reloadData();
        }

        private void FrmCMSConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucObjectsGridView1.SaveDataGridView();
            instance = null;
        }

        private void workInfoChanged(CommonClass whichChanged)
        {
            reloadDataAndScrollToRow(whichChanged.GetId());
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            FrmCMSWorkInfoSelect frm = new FrmCMSWorkInfoSelect(ucShipSelect1.GetId(), true);
            frm.ShowDialog();
            bool haveErrCode = false;
            if (frm.WorkInfoIds != null && frm.WorkInfoIds.Count > 0)
            {
                string err;
                foreach (string workInfoId in frm.WorkInfoIds)
                {
                    WorkInfo workInfo = WorkInfoService.Instance.getObject(workInfoId, out err);
                    if (workInfo != null && !workInfo.IsWrong)
                    {
                        CMSConfig oneCMSConfig = new CMSConfig("", workInfo.WORKINFONAME, workInfo.WORKINFOCODE, workInfoId,
                            workInfo.WORKINFODETAIL, ucShipSelect1.GetId(), workInfo.WORKINFONAME, 0);
                        if (!oneCMSConfig.Update(out err))
                        {
                            MessageBoxEx.Show("关联工作信息出错,错误信息为:" + err);
                            break;
                        }
                        if (string.IsNullOrEmpty(workInfo.WORKINFOCODE)) haveErrCode = true;
                    }
                }
                if (haveErrCode) MessageBoxEx.Show("存在没有填写检验编码的项目,请为其填写检验编码,否则在自动产生检验条目时将出错!");
                reloadData();
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            reloadData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("请先选择有效船舶,再进行导入");
                return;
            }
            //当前船舶有内容,则询问是否全部清空.
            if (ucObjectsGridView1.DataGridView.Rows.Count > 0)
            {
                DialogResult dr = MessageBoxEx.Show("当前船舶已经配置了CMS项目,是否清空后再导入", "提示", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    //delete
                    string err;
                    if (!CMSConfigService.Instance.DeleteAllConfigOfOneShip(ucShipSelect1.GetId(), out err))
                    {
                        MessageBoxEx.Show("删除失败," + err);
                        return;
                    }
                    reloadData();
                }
                else if (dr == DialogResult.No)
                {
                    //not delete 
                }
                else
                {
                    return;
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //判断当前文档是否是Excel文件,
                //从B3开始是否是一下内容:'编号':'检 验 项 目 （中 文）':CODE:'检 验 项 目 （英 文）':到期日期（DUE DATE):Credit Date
                //CODE和英文任何一列有空值,或者包含 * 则不导入.
                if (File.Exists(openFileDialog1.FileName))
                {
                    Excel excel = new Excel();
                    try
                    {
                        excel.OpenDocument(openFileDialog1.FileName);
                        if (excel.GetValue("B3") == "编号" && excel.GetValue("D3") == "CODE")
                        {
                            int maxRow = excel.GetMaxRowNumber(5);
                            for (int i = 4; i <= maxRow; i++)
                            {
                                string sb, sc, sd, se;
                                sb = excel.GetValue("B" + i.ToString());
                                sc = excel.GetValue("C" + i.ToString());
                                sd = excel.GetValue("D" + i.ToString());
                                se = excel.GetValue("E" + i.ToString());
                                if (string.IsNullOrEmpty(sd) || string.IsNullOrEmpty(se) || se.Contains("*")) continue;
                                int ib;
                                if (!int.TryParse(sb, out ib))
                                {
                                    continue;
                                }
                                CMSConfig cmsConfigTemp = new CMSConfig("", sc, sd, null, null, ucShipSelect1.GetId(), se, (int)ib);
                                string err;
                                if (!cmsConfigTemp.Update(out err))
                                {
                                    MessageBoxEx.Show("无法完成导入,错误信息为:" + err);
                                    return;
                                }
                            }
                        }
                    }
                    catch(Exception ex) 
                    {
                        MessageBoxEx.Show(ex.Message);
                    }
                    finally
                    {
                        excel.CloseDocument();
                        excel.Dispose();
                        reloadData();
                    }
                }
            }
        }
    }
}