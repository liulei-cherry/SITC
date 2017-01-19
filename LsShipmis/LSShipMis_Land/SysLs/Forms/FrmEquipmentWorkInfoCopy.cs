/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：夏喜龙
 * 创建时间：2009-05-25
 * 标    题：
 * 功能描述：设备工作信息管理
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
using System.Windows.Forms;
using ItemsManage.Services;
using Maintenance.Viewer;
using ItemsManage.DataObject;
using CommonOperation.Enum;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;
using LSShipMis_Land.SysLs.Services;

namespace LSShipMis_Land.SysLs.Forms
{
    public partial class FrmEquipmentWorkInfoCopy : CommonViewer.BaseForm.FormBase
    {
        bool flag = false;
        public FrmEquipmentWorkInfoCopy(string ship_id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            ucShipSource.ChangeSelectedState(false, false);
            ucShipSource.SelectedId(ship_id);
        }

        private void FrmEquipmentWorkInfo_Load(object sender, EventArgs e)
        {
            this.LoadGridViewData();    //加载单个设备的工作列表信息.
            //加载网格控件默认的列宽信息.
            dgvWorkState.LoadGridView("FrmEquipmentWorkInfoCopy.dgvEquipWork");
        }

        private void LoadGridViewData()
        {
            string err;
            //加载列表数据.
            DataTable dtbWorkState;
            if (!CopyDataService.Instance.GetShipWorkInfoStateByYear(dtpAnnual.Value, out dtbWorkState, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvWorkState.DataSource = dtbWorkState;

            SetGridViewStyle();
        }

        private void SetGridViewStyle()
        {
            //设置列标题.
            if (flag) return;
            flag = true;
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Add("SHIP_NAME", "船舶");
            dictColumns.Add("ishasworkinfo", "原始工作信息");
            dictColumns.Add("ishasyearworkinfo", "年度工作信息");
            dictColumns.Add("ishasyearworkorder", "生成工单");
            dgvWorkState.SetDgvGridColumns(dictColumns);
        }
        private void dtpAnnual_ValueChanged(object sender, EventArgs e)
        {
            LoadGridViewData();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string err;
            if (string.IsNullOrEmpty(ucShipSource.GetId()))
            {
                MessageBoxEx.Show("请先选择源船舶");
                return;
            }

            string ship_id = dgvWorkState.CurrentRow.Cells["ship_id"].Value.ToString();
            if (ship_id == ucShipSource.GetId())
            {
                MessageBoxEx.Show("源和目标不能选择相同船舶");
                return;
            }
            if (!CopyDataService.Instance.CopyEquipment(ucShipSource.GetId(), dtpAnnual.Value, ship_id,cbkIsCopyWorkInfo.Checked, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            MessageBoxEx.Show("操作成功");
            LoadGridViewData();
        }
        /// <summary>
        /// 生成工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateWorkOrder_Click(object sender, EventArgs e)
        {
            if (dgvWorkState.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择目标船舶");
                return;
            }
            if (dgvWorkState.CurrentRow.Cells["ishasyearworkinfo"].Value.ToString() == "无")
            {
                MessageBoxEx.Show("请先确认该船舶已有年度工作信息");
                return;
            }
            string err = "";     //错误信息参数.
            string ship_id = dgvWorkState.CurrentRow.Cells["ship_id"].Value.ToString();
            DataTable dtWorkinfo;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.GetNeedCreateWorkorder(ship_id, dtpAnnual.Value, out dtWorkinfo, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            List<string> workids = new List<string>();
            foreach (DataRow item in dtWorkinfo.Rows)
                workids.Add(item["WorkInfoID"].ToString());
            DataTable dtbFirstArrangeWorkInfo = WorkInfoService.Instance.GetFirstArrangeWorkInfo(workids);

            //取所有要首排的行信息.
            if (dtbFirstArrangeWorkInfo.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有任何要首排的工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataRow item in dtWorkinfo.Rows) //工单首排：月周期数计算
            {
                //string tempstr = item["MONTHS_CHECK"].ToString();
                //tempstr = tempstr.Replace("{", "");
                //tempstr = tempstr.Replace("}", "");
                //string[] mc = tempstr.Split(',');
                //DataRow[] drs = dtbFirstArrangeWorkInfo.Select("WORKINFOID='" + item["WorkInfoID"].ToString() + "'");
                //DateTime pd = new DateTime(Convert.ToDateTime(item["ANNUAL"]).Year, Convert.ToInt32(mc[0]), 20);
                //drs[0]["planexedate"] = pd;
                //drs[0]["arrangetimes"] = 1;

                string tempstr = item["MONTHS_CHECK"].ToString();
                tempstr = tempstr.Replace("{", "");
                tempstr = tempstr.Replace("}", "");
                string[] mc = tempstr.Split(',');
                int[] mcInt = new int[mc.Length];
                for (int i = 0; i < mcInt.Length; i++)
                {
                    mcInt[i] = Convert.ToInt32(mc[i]);
                }
                int year = Convert.ToDateTime(item["ANNUAL"]).Year;
                int month = Convert.ToInt32(mc[0]);

                int currentMonth = DateTime.Now.Month; //当前月
                if (mc.Length == 0) //没有有年度勾选
                {
                    continue;
                }
                else if (mc.Length == 1)//一年一次
                {
                    if (mcInt[0] < currentMonth)//小于当前月
                    {
                        year = year + 1;
                        month = mcInt[0];
                    }
                    else//大于等于当前月
                    {
                        month = mcInt[0];
                    }
                }
                else //一年多次
                {
                    for (int i = 0; i < mcInt.Length; i++)
                    {
                        if (mcInt[i] >= currentMonth)
                        {
                            month = mcInt[i];
                            break;
                        }
                    }
                }

                DataRow[] drs = dtbFirstArrangeWorkInfo.Select("WORKINFOID='" + item["WorkInfoID"].ToString() + "'");
                DateTime pd = new DateTime(year, month, 15);
                drs[0]["planexedate"] = pd;
                drs[0]["arrangetimes"] = 1;
            }
            //更新结果报告.
            if (WorkInfoService.Instance.WorkInfoArrange(dtbFirstArrangeWorkInfo, out err))
            {
                MessageBoxEx.Show("工作信息首排成功！", "首排成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "首排失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmEquipmentWorkInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格控件各列的列宽信息.
            dgvWorkState.SaveGridView("FrmEquipmentWorkInfoCopy.dgvEquipWork");
        }
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}