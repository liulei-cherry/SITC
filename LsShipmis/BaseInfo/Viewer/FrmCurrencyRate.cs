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
using BaseInfo.Objects;
using CommonViewer.BaseControl;

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmCurrencyRate : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCurrencyRate instance = new FrmCurrencyRate();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCurrencyRate Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCurrencyRate.instance = new FrmCurrencyRate();
                }
                return FrmCurrencyRate.instance;
            }
        }
        #endregion
        bool isFirstSetColumn = true;
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCurrencyRate()
        {

            InitializeComponent();

            #region gridview委托部分

            #endregion

        }
        private void ucDataGridView1_SelectedChanged(int rowNumber)
        {
            if (rowNumber >= 0)
            {
                string id = ucDataGridView1.Rows[rowNumber].Cells["RATEID"].Value.ToString();
                string err;
                ucCurrencyRate1.ChangeData(CurrencyRateService.Instance.getObject(id, out err));
            }
            else
            {
                ucCurrencyRate1.ClearData();
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmEditOneCurrencyRate formNew = new FrmEditOneCurrencyRate();
            formNew.ShowDialog();
            //当新添加数据时，刷新ucDataGridView1的值.
            if (formNew.NeedRetrieve)
            {
                reloadData();//重载数据.
            }
        }
        public void reloadData()
        {
            DataTable dt;
            string err;
            dt = CurrencyRateService.Instance.getInfoEx(out err);
            ucCurrencyRate1.ClearData();
            ucCurrencyRate1.SetCanEdit(false);
            ucDataGridView1.DataSource = dt;
            SetDisplayColumn();
        }
        public void SetDisplayColumn()
        {
            if (isFirstSetColumn)
            {
                isFirstSetColumn = false;
                Dictionary<string, string> reValue = new Dictionary<string, string>();
                reValue.Add("B_CURRENCY", "基准货币");
                reValue.Add("E_CURRENCY", "兑换货币");
                reValue.Add("EXCHANGERATE", "汇率");
                reValue.Add("USEFULDATEFROM", "有效起始日期");
                reValue.Add("USEFULDATEEND", "有效结束日期");
                reValue.Add("ISUSE", "是否有效");
                reValue.Add("REMARK", "备注");
                ucDataGridView1.LoadGridView("FrmCurrencyRate.ucDataGridView1", reValue);
            }
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucCurrencyRate1.DeleteObject();
            if (ucCurrencyRate1.needRetrieve == true)
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
            ucCurrencyRate1.UpdateObject();
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

        private void FrmCurrency_Load(object sender, EventArgs e)
        {
            string benweibi = ArgumentSetService.Instance.chk_GetDefaultCurrency("SetDefaultCurrency");
            if (string.IsNullOrEmpty(benweibi))
            {
                MessageBoxEx.Show("当前系统没有本位币,系统将默认设置人民币为本位币");
                string err;
                if (!ArgumentSetService.Instance.chk_InsertDefaultCurrency("人民币", out err))
                {
                    MessageBoxEx.Show("默认本位币修改或设置失败,错误原因:" + err);
                    this.Close();
                }
            }

            if (CurrencyService.Instance.GetByName(benweibi).Rows.Count == 0)
            {
                MessageBoxEx.Show("获取本位币ID失败,请重新设置本位币");
                this.Close();
            }
            BindingStandardMoney();
            reloadData();
        }
        private void BindingStandardMoney()
        {
            string benweibi = ArgumentSetService.Instance.chk_GetDefaultCurrency("SetDefaultCurrency");
            if (string.IsNullOrEmpty(benweibi))
                groupBox2.Text = "货币基本信息   当前没有设置本位币";
            else
                groupBox2.Text = "货币基本信息   当前本位币是:" + benweibi;
        }
        private void FrmCurrency_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmCurrencyRate.ucDataGridView1");
            instance = null;
        }


    }
}