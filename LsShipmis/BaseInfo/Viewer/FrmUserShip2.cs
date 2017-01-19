/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmUserShip2.cs
 * 创 建 人：李景育 * 创建时间：2008-03-10
 * 标    题：人员对船舶管理职责划分业务窗体 * 功能描述：实现人员对船舶管理职责划分业务窗体上的相关功能
 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControlService;

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 人员对船舶管理职责划分业务窗体.
    /// </summary>
    public partial class FrmUserShip2 : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 系统用户业务类.
        /// </summary>
        private SysUserService sysUserService = new SysUserService();


        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmUserShip2 instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmUserShip2 Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmUserShip2.instance = new FrmUserShip2();
                }

                return FrmUserShip2.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmUserShip2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserShip2_Load(object sender, EventArgs e)
        {
            this.setCmbUser();  //设置用户列表框数据源.
            this.lstUser_SelectedValueChanged(sender, e);
        }

        /// <summary>
        /// 设置用户列表框数据源.
        /// </summary>
        private void setCmbUser()
        {
            //1.用户选择的DataTable对象.
            DataTable dtbSysUser = sysUserService.GetSysUser(0);
            lstUser.DataSource = dtbSysUser;
            lstUser.DisplayMember = "username";
            lstUser.ValueMember = "userid";
        }

        private void ResetList(DataTable dtbUserShip)
        {
            if (dtbUserShip == null) return;
            chkLstShip.DataSource = dtbUserShip;
            chkLstShip.DisplayMember = "SHIP_NAME";
            chkLstShip.ValueMember = "SHIP_ID";

            for (int i = 0; i < dtbUserShip.Rows.Count; i++)
            {
                chkLstShip.SetItemChecked(i, (dtbUserShip.Rows[i]["sel"].ToString() == "1"));
            }
        }
        /// <summary>
        /// 当用户列表数据发生变化时，显示其管辖的船舶列表（打勾的项）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUser_SelectedValueChanged(object sender, EventArgs e)
        {
            //20150914重新获取船舶列表及其状态。
            if (lstUser.SelectedValue != null)
            {
                string userId = lstUser.SelectedValue.ToString();
                
                ResetList(sysUserService.GetUserShip(userId));
            }
        }

        /// <summary>
        /// 保存选择好的数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sFrmErrMessage = "";                     //错误信息参数.
            List<string> lstShipIds = new List<string>();   //包含船舶Id的List泛型集合.
            string userId = "";                             //用户Id

            //校验部分.
            if (lstUser.SelectedValue == null)
            {
                MessageBox.Show("当前用户列表没有值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkLstShip.SelectedValue == null)
            {
                MessageBox.Show("当前船舶列表没有值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //取当前用户Id
            userId = lstUser.SelectedValue.ToString();

            //把为当前用户所选择的每一艘船舶的Id值添加到List集合lstShipIds中去.
            for (int i = 0; i < this.chkLstShip.CheckedItems.Count; i++)
            {
                DataRowView dataRowView = (DataRowView)this.chkLstShip.CheckedItems[i];
                lstShipIds.Add(dataRowView["SHIP_ID"].ToString());
            }

            //更新结果报告.
            if (sysUserService.SaveUserShip(userId, lstShipIds, out sFrmErrMessage))
            {
                MessageBox.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sFrmErrMessage, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserShip2_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstShip.Items.Count; i++)
            {
                chkLstShip.SetItemChecked(i, true);
            }
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstShip.Items.Count; i++)
            {
                chkLstShip.SetItemChecked(i, false);
            }
        }

    }
}