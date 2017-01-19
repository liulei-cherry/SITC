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
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmCostSubjects : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCostSubjects instance = new FrmCostSubjects();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCostSubjects Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCostSubjects.instance = new FrmCostSubjects();
                }
                return FrmCostSubjects.instance;
            }
        }
        #endregion

        #region 窗体对象

        Account nowItem = null;

        #endregion

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {          
            ucCostSubjectsTree1.ReloadingAllData();
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCostSubjects()
        {
            InitializeComponent();
        }     

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {          

            Account tempObject ;
            
            if(nowItem==null)
            {
                tempObject = new Account(null, "", "", "", "", 99);
            }
            else
            {
                tempObject = new Account(null, "", nowItem.NODE_ID, nowItem.TOP_NODE_ID, "", 99);
            }
            FrmEditOneCostSubjects formNew = new FrmEditOneCostSubjects(tempObject,nowItem==null?"费用科目根结点": nowItem.NODE_NAME);            
            formNew.ShowDialog();
            ucCostSubjectsTree1.SelectOneAccount(tempObject);
            ucCostSubjectsTree1.reloading(ucCostSubjectsTree1.SelectedNode);
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (nowItem != null )
            {                
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (nowItem.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    ucCostSubjectsTree1.SelectedNode.Remove();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("当前节点不能删除!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
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
            if (nowItem != null)
            {
                //对象赋值.
                nowItem.CODE = txtCode.Text;
                nowItem.NODE_NAME = txtName.Text;
                nowItem.ORDER_NUM = int.Parse(Decimal.Round(numOrder.Value,0).ToString());
                
                //对象校验.
                if (string.IsNullOrEmpty(nowItem.NODE_NAME))
                {
                    MessageBoxEx.Show("科目名称不允许为空!","",new MessageBoxButtons(),MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                //保存对象.
                if (!AccountService.Instance.saveUnit(nowItem, out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    if (nowItem.NODE_NAME != ucCostSubjectsTree1.SelectedNode.Text)
                    {
                        ucCostSubjectsTree1.SelectedNode.Text = nowItem.NODE_NAME;
                    }
                }
            }
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

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string tempCode = listBox1.Items[listBox1.SelectedIndex].ToString();
                 
                txtCode.Text = tempCode.Split ('\t')[0];
            }
        }

        private void ucCostSubjectsTree1_ItemChanged(Account account)
        {
            nowItem = account;
            if (account != null)
            {
                txtCode.Enabled = true;
                txtName.Enabled = true;
                numOrder.Enabled = true;
                txtCode.Text = account.CODE;
                txtName.Text = account.NODE_NAME;
                numOrder.Value = account.ORDER_NUM;
                if (!string.IsNullOrEmpty(txtCode.Text))
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.Items[i].ToString().StartsWith(txtCode.Text))
                        {
                            listBox1.SelectedIndex = i;
                            return;
                        }
                    }
                }
                listBox1.SelectedIndex = -1;
            }
            else
            {
                txtCode.Enabled = false;
                txtName.Enabled = false;
                numOrder.Enabled = false;
                txtCode.Text = "";
                txtName.Text = "费用科目根结点";
                numOrder.Value = 0;
            }
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            ucCostSubjectsTree1.ReloadingAllData();
        }
    }
}