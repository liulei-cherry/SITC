/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
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
using CommonOperation.BaseClass;
using CommonViewer.BaseForm;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;
using CommonViewer;

using OfficeOperation;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmSum : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSum instance = new FrmSum();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSum Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSum.instance = new FrmSum();
                }
                return FrmSum.instance;
            }
        }
        #endregion

        #region 窗体对象

        private DateTime yearMonth;
        public DateTime YearMonth
        {
            get { return yearMonth; }
            set { yearMonth = value; }
        }

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        DataTable dt;

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSum()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            loadMainData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
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
        /// 加载主列表数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            YearMonth = dateYear.Value;

            dt = ACTUAL_COSTSService.Instance.getSum(yearMonth, out err);//获取年度汇总费用.
            dgvMain.DataSource = dt;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            //每两行更改背景色
            ShownStyle();
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            int columns = dt.Columns.Count;
            for (int i = 0; i < columns / 2; i++)
            {
                if (!"ship_id".Equals(dt.Columns[i].ColumnName) && !"ship_en_name".Equals(dt.Columns[i].ColumnName))
                    dictColumns.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
            }

            dgvMain.SetDgvGridColumns(dictColumns);
            dgvMain.SetDataGridViewNoSort();

            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        /// <summary>
        /// 打开导出报表窗口.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            OperationExcel operationExcel = null;
            try
            {
                string err;
                if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfSum(yearMonth, out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取信息,不能输出,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("费用汇总导出", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex) 
            {
                MessageBoxEx.Show(ex.Message);
            }
            finally
            {
                if (operationExcel != null)
                    operationExcel.Dispose();
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
        /// 样式表显示（每两行更改背景色）
        /// </summary>
        private void ShownStyle()
        {
            int n = 1;
            Color currentFrontColor = Color.White;
            Color currentBackColor = Color.SkyBlue;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                row.DefaultCellStyle.ForeColor = currentFrontColor;
                row.DefaultCellStyle.BackColor = currentBackColor;
                if (n % 2 == 0)
                {
                    currentFrontColor = currentFrontColor.Equals(Color.Black) ? Color.White : Color.Black;
                    currentBackColor = currentBackColor.Equals(Color.SkyBlue) ? Color.White : Color.SkyBlue;
                }
                n++;
            }
        }
        

        private void FrmSum_Shown(object sender, EventArgs e)
        {
            //每两行更改背景色
            ShownStyle();
        }

    }
}