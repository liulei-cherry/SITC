/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2012-12-12
 * 功能描述：滑油消耗汇总的功能管理
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
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Oil.DataObject;
using Oil.Services;
using Oil.Viewer;
using CommonViewer.BaseControl;

namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilLuboilConsumeSum : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilLuboilConsumeSum instance = new FrmOilLuboilConsumeSum();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilLuboilConsumeSum Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilLuboilConsumeSum.instance = new FrmOilLuboilConsumeSum();
                }
                return FrmOilLuboilConsumeSum.instance;
            }
        }
        #endregion

        #region 窗体对象

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();
        #endregion

        #region 其它公共业务类
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilLuboilConsumeSum()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilLuboilConsume_Load(object sender, EventArgs e)
        {
            dateStart.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dateEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            loadMainData();
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
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getYearSum(sDate, eDate, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dgvMain.Rows.Count == 0)
            {
                dgvSub.DataSource = null;
            }
        }

        /// <summary>
        /// 加载子数据.
        /// </summary>
        public void loadSubData(string ship_id)
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getMonthSum(ship_id,sDate, eDate, out err);
            dgvSub.DataSource = dtb;

            //加载列项.
            loadDataColSub();

        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.Rows[e.RowIndex].Cells["ship_id"].Value != null)
            {
                string ShipId = dgvMain.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                loadSubData(ShipId);
            }


        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("SHIP_NAME", "船舶");
            dictColumns.Add("TYPE1SUME", "主机气缸油消耗");
            dictColumns.Add("TYPE2SUME", "主机系统油消耗");
            dictColumns.Add("TYPE3SUME", "副机系统油消耗");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        /// <summary>
        /// 设置子列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();

            //设置列标题.
            dictColumnsSub.Add("SHIP_NAME", "船舶");
            dictColumnsSub.Add("RECORD_DATE", "月份");
            dictColumnsSub.Add("TYPE1SUME", "主机气缸油消耗");
            dictColumnsSub.Add("TYPE2SUME", "主机系统油消耗");
            dictColumnsSub.Add("TYPE3SUME", "副机系统油消耗");

            dgvSub.SetDgvGridColumns(dictColumnsSub);
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
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

        private void FrmOilLuboilConsume_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

    }
}