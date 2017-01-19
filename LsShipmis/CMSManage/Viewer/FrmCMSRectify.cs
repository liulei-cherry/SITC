using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using CommonOperation.Functions;
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;
using CMSManage.Services;
using CMSManage.DataObject;
using CommonOperation.Interfaces;
using Maintenance.DataObject;
using CommonViewer;
using OfficeOperation;

namespace CMSManage.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmCMSRectify : CommonViewer.BaseForm.FormBase
    {
        private CMSCheckLog nowLog;
        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCMSRectify instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCMSRectify Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCMSRectify.instance = new FrmCMSRectify();
                }

                return FrmCMSRectify.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmCMSRectify()
        {
            InitializeComponent();
            ucShipSelect1.ChangeSelectedState(false,true);
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSocietyChecking_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
        }  
        private void setDataGridView()
        {
            dgvCMSWorkOrder.LoadGridView("FrmCMSRectify.dgvCMSWorkOrder"); 
            Dictionary<string, string> disp = new Dictionary<string, string>();
            disp.Add("CHECK_PERSON", "检验人");
            disp.Add("CHECK_DATE", "检验时间");
            disp.Add("CHECK_TITLE", "检验项目(中文)");
            disp.Add("CHECKENGLISHNAME", "检验项目(英文)");          
            disp.Add("CMS_CODE", "检验项目代码");
            disp.Add("CHECK_DETAIL", "备注");
            disp.Add("PLAN_DATE", "预计检验日期");
            disp.Add("CHECK_DEPART_NAME", "检验方");
            disp.Add("RECTIFY_STATE", "整改状态");
            disp.Add("CHECK_STATE_VIEW", "检验状态");

            dgvCMSWorkOrder.SetDgvGridColumns(disp);
            dgvCMSWorkOrder.setDgvColumnsReadOnly(new string[] { "CHECK_PERSON", "CHECK_DATE", "CHECK_TITLE", "CHECKENGLISHNAME", 
                "CMS_CODE", "CHECK_DETAIL", "PLAN_DATE", "CHECK_DEPART_NAME", "RECTIFY_STATE", "CHECK_STATE_VIEW" });
        }

        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSocietyChecking_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvCMSWorkOrder.SaveGridView("FrmCMSRectify.dgvCMSWorkOrder");
            instance = null;//释放窗体实例变量.
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            operation();
        }
        private void operation()
        {
            //只允许一次整改一条,弹出整改界面,进行维护,完毕后退出 如果已经整改完成的,同样可以打开编辑,不做强制限制.
            if (dgvCMSWorkOrder.CurrentRow != null)
            {
                CMSRectify cmsRectify;
                CMSCheck cmsCheck;
                string checkId = dgvCMSWorkOrder.CurrentRow.Cells["CMS_CHECK_ID"].Value.ToString();
                string err;
                cmsCheck = CMSCheckService.Instance.getObject(checkId, out err);
                if (cmsCheck != null && !cmsCheck.IsWrong)
                {
                    cmsCheck.FillThisObject();
                    cmsRectify = cmsCheck.CmsRectify;
                    if (cmsRectify != null && !cmsRectify.IsWrong)
                    {
                        FrmEditOneCMSRectify frm = new FrmEditOneCMSRectify(cmsRectify, true);
                        frm.ShowDialog();
                        reloadingDetail();
                        if (dgvCMSWorkOrder.Rows.Count == 0)
                        {
                            nowLog.CHECK_STATE = 2;
                            nowLog.Update(out err);
                            MessageBoxEx.Show("已经完成了所有整改,此界面将关闭");
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBoxEx.Show("未获取当前检验项目的整改信息,无法进行整改处理!");
                }
            }
            else
            {
                MessageBoxEx.Show("未选择任何数据,无法进行整改处理!");
            }
        }
   
        private void dgvCMSWorkOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            operation();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            //先给bd清空.
            bdsCMSCheck.DataSource = null;
            //获取最后的一次状态为3(存在缺陷)的CMS检验.
            CMSCheckLog cmsCheckLog = CMSCheckLogService.Instance.GetLastCheckLog(theSelectedObject, 3);
            if (cmsCheckLog == null || cmsCheckLog.IsWrong)
            {
                MessageBoxEx.Show("当前船舶不存在任何CMS检验缺陷项目,不需要进行整改!");
                return;
            }
            else
            {
                nowLog = cmsCheckLog;
                txtCheckName.Text = nowLog.CHECK_NAME;
                txtChecker.Text = nowLog.CHECK_PERSON;
                txtCheckPlace.Text = nowLog.CHECK_PLACE;
                txtDetail.Text = nowLog.CHECK_DETAIL;
                dtCheckDate.Value = nowLog.CHECK_DATE;
                reloadingDetail();     
            }
        }
        private void reloadingDetail()
        {
            DataTable dt = CMSCheckService.Instance.GetAllItemOfOneLog(nowLog.GetId(), true, 3);
            bdsCMSCheck.DataSource = dt;
            dgvCMSWorkOrder.DataSource = bdsCMSCheck;
            setDataGridView();    
        }
    }
}