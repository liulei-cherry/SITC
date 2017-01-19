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
using BaseInfo.DataObject;
using BaseInfo.Viewer;
using CommonViewer.BaseControl;

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 油品信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmArgumentSet : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmArgumentSet instance = new FrmArgumentSet();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmArgumentSet Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmArgumentSet.instance = new FrmArgumentSet();
                }
                return FrmArgumentSet.instance;
            }
        }
        #endregion

        #region 窗体对象

        private ArgumentSet  currentObject;
        public ArgumentSet CurrentObject
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
        private FrmArgumentSet()
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
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            loadMainData();

        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvMain.SaveGridView("FrmArgumentSet.dgvMain");
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
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";

            DataTable dtb = ArgumentSetService.Instance.getInfo(out err);
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

            //设置列标题.
            dictColumns.Add("code", "编码");
            dictColumns.Add("code_value", "编码值");
            dictColumns.Add("intro", "介绍");
            dgvMain.SetDgvGridColumns(dictColumns);
            dgvMain.LoadGridView("FrmArgumentSet.dgvMain");
            isFirstLoadMain = false;
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["SYS_ID"].Value && null != dr.Cells["SYS_ID"].Value)
                    objectID = dr.Cells["SYS_ID"].Value.ToString();

                CurrentObject = ArgumentSetService.Instance.getObject(objectID, out err);
            }

        }

        private void showObject(ArgumentSet nowObject)
        {
            if (nowObject != null)
            {
                txtCode.Text = nowObject.CODE;
                txtCodeValue.Text = nowObject.CODE_VALUE;
                txtIntro.Text =nowObject.INTRO;
            }
            else {
                txtCode.Text = "";
                txtCodeValue.Text = "";
                txtIntro.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {

            ArgumentSet tempObject = new ArgumentSet(null, "", "", "");

            FrmArgumentSetEdit formNew = new FrmArgumentSetEdit(tempObject);
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
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (currentObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private bool check(out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBoxEx.Show("编码不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            } 
            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.CODE = txtCode.Text;
                currentObject.CODE_VALUE = txtCodeValue.Text;
                currentObject.INTRO = txtIntro.Text;
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
                if (!ArgumentSetService.Instance.saveUnit(currentObject, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
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

    }
}