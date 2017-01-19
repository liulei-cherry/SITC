/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 功能描述：油品信息的管理
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
    /// 油品信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOil : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOil instance = new FrmOil();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOil Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOil.instance = new FrmOil();
                }
                return FrmOil.instance;
            }
        }
        #endregion

        #region 窗体对象

        private HOil currentObject;
        public HOil CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject(currentObject);
            }
        }

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOil_Load(object sender, EventArgs e)
        {
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.
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
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";
            //油品类型.
            DataTable dtb1 = HOilService.Instance.getOilType(out err);
            other.SetComboBoxValue(cboType, dtb1);

            //润油类型.
            DataTable dtb2 = HOilService.Instance.getLOilType(out err);
            other.SetComboBoxValue(cboLType, dtb2);
        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";

            DataTable dtb = HOilService.Instance.getInfoEx(out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0) CurrentObject = null;// 没有对象则显示置空.
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            dgvMain.LoadGridView("FrmOil.dgvMain");
            //设置列标题.
            dictColumns.Add("OIL_NAME", "厂家");
            dictColumns.Add("TRADEMARK", "牌号");
            dictColumns.Add("OIL_CODE", "编码");
            dictColumns.Add("OIL_TYPE_NAME", "油品种类");
            dictColumns.Add("LOIL_TYPE_NAME", "润滑油种类");
            dictColumns.Add("ORDERNUM", "排序");

            dgvMain.SetDgvGridColumns(dictColumns);

            isFirstLoadMain = false;
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["OIL_ID"].Value && null != dr.Cells["OIL_ID"].Value)
                    objectID = dr.Cells["OIL_ID"].Value.ToString();

                CurrentObject = HOilService.Instance.getObject(objectID, out err);
            }

        }

        private void showObject(HOil nowObject)
        {
            if (nowObject != null && !nowObject.IsWrong )
            {
                txtMark.Text = nowObject.TRADEMARK;
                txtName.Text = nowObject.OIL_NAME;
                txtCode.Text = nowObject.OIL_CODE;
                cboType.SelectedValue = nowObject.OIL_TYPE;
                cboLType.SelectedValue = nowObject.LOIL_TYPE;
                numOrder.Value = nowObject.ORDERNUM;
            }
            else
            {
                txtMark.Text = "";
                txtName.Text = "";
                txtCode.Text = "";
                numOrder.Value = 0;
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {

            HOil tempObject = new HOil(null, "", "", "", "0", "0", 0);

            FrmOilEdit formNew = new FrmOilEdit(tempObject);
            formNew.ShowDialog();

            //刷新列表.
            loadMainData();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                string err;
                if (HOilService.Instance.GetOilBelongShip(currentObject.OIL_ID).Rows.Count > 0)
                {
                    MessageBoxEx.Show("该油品已绑定船舶,不能删除!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                    return;
                }

                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (currentObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private bool check(out string err)
        {
            err = "";

            if ("".Equals(txtMark.Text))
            {
                MessageBoxEx.Show("牌号不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return false;
            }
            if ("".Equals(txtName.Text))
            {
                MessageBoxEx.Show("名称不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.TRADEMARK = txtMark.Text;
                currentObject.OIL_NAME = txtName.Text;
                currentObject.OIL_CODE = txtCode.Text;
                currentObject.OIL_TYPE = cboType.SelectedValue.ToString();
                if (cboLType.Visible)
                {
                    currentObject.LOIL_TYPE = cboLType.SelectedValue.ToString();
                }
                else
                {
                    currentObject.LOIL_TYPE = "3";
                }
                currentObject.ORDERNUM = int.Parse(numOrder.Value.ToString());
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            string err;
            if (currentObject != null)
            {
                if (!check(out err))
                {
                    return;
                }

                this.FormToObject(out err);      //从界面获取数据到对象中.

                //保存对象.
                if (!HOilService.Instance.saveUnit(currentObject, out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
            }

        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLType.SelectedValue != null)
            {
                bool rValue = "2".Equals(cboType.SelectedValue.ToString());

                label2.Visible = rValue;
                cboLType.Visible = rValue;
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

        private void FrmOil_FormClosing(object sender, FormClosingEventArgs e)
        {

            dgvMain.SaveGridView("FrmOil.dgvMain");
            instance = null;
        }

    }
}