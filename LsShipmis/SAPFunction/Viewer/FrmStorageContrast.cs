using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using SAPFunction.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace SAPFunction.Viewer
{
    public partial class FrmStorageContrast : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmStorageContrast instance = new FrmStorageContrast();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmStorageContrast Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmStorageContrast.instance = new FrmStorageContrast();
                }
                return FrmStorageContrast.instance;
            }
        }
        private FrmStorageContrast()
        {
            InitializeComponent();
        }

        #endregion
        bool isLoadedView = false;
        private void FrmStorageContrast_Load(object sender, EventArgs e)
        {
            dgvContrast.DataSource = bdsContrast;
            ucShipSelect1.ChangeSelectedState(false, false);
        }
        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            if (isLoadedView) return;
            isLoadedView = true;
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("MATERIAL_NAME", "物资");
            dgvColumnStyle.Add("MATERIAL_SPEC", "物资型号");
            dgvColumnStyle.Add("UNIT_NAME", "物资单位");
            dgvColumnStyle.Add("MATERIAL_FINANCE", "物资SAP编号");
            dgvColumnStyle.Add("MATERIAL_TYPE_NAME", "物资类型");
            dgvColumnStyle.Add("MEINS", "SAP单位");
            dgvColumnStyle.Add("STOCKSAll", "机务库存");
            dgvColumnStyle.Add("INITIAL_STORAGE", "初始库存");
            dgvColumnStyle.Add("LABST", "SAP库存");
            dgvColumnStyle.Add("DIFF_QUANTITY", "相差库存(机务库存-初始库存-SAP库存)");
            dgvContrast.SetDgvGridColumns(dgvColumnStyle);
            int i = 0;
            foreach (string key in dgvColumnStyle.Keys)
            {
                dgvContrast.Columns[key].DisplayIndex = i;
                i++;
            }
            dgvContrast.LoadGridView("FrmStorageContrast.dgvContrast");
        }
        /// <summary>
        /// 对比操作.
        /// </summary>
        private void Contrast()
        {
            string err;
            DataTable dtSap;

#if DEBUG
            #region 这里是测试代码,因为没有SAP服务器

            if (!StorageContrastService.Instance.GetTestSapStockInfo(out dtSap, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            #endregion
#else

            #region 这里是真正的访问SAP库存量的代码
            ShipInfo shipinfo = ShipInfoService.Instance.getObject(ucShipSelect1.GetId(), out err);
            if (!string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bool isValid;
            if (!RFCOperation.Instance.GetInventoryVB(shipinfo.SHIP_CODE, out dtSap, out isValid, out err))
            {
                MessageBoxEx.Show("SAP库存清单方法调用失败,错误原因:" + err);
                return;
            }
            if (!isValid)
            {
                MessageBoxEx.Show("SAP库存清单方法调用成功,但SAP端返回无效.");
                return;
            }
            #endregion
#endif
            DataTable dtStock;
            if (!StorageContrastService.Instance.GetStockInfo(ucShipSelect1.GetId(), out dtStock, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dtStock.Columns.Add("LABST", typeof(decimal));
            dtStock.Columns.Add("MEINS", typeof(string));
            dtStock.Columns.Add("DIFF_QUANTITY", typeof(decimal));
            DataTable localAbsence = dtSap.Clone();
            DataTable sapAbsence = dtSap.Clone();

            foreach (DataRow item in dtSap.Rows)
            {
                DataRow[] drs = dtStock.Select("MATERIAL_FINANCE='" + item["MATNR"].ToString() + "'");
                if (drs.Length == 0)
                {
                    DataRow dr = dtStock.NewRow();
                    dr["LABST"] = item["LABST"].ToString();
                    dr["MEINS"] = item["MEINS"].ToString();
                    dr["DIFF_QUANTITY"] = Convert.ToDecimal(item["LABST"]);
                    dtStock.Rows.Add(dr);
                    localAbsence.Rows.Add(item.ItemArray);
                }
                else
                {
                    drs[0]["LABST"] = item["LABST"].ToString();
                    drs[0]["MEINS"] = item["MEINS"].ToString();
                    drs[0]["DIFF_QUANTITY"] = Convert.ToDecimal(drs[0]["STOCKSAll"])
                        - Convert.ToDecimal(drs[0]["INITIAL_STORAGE"])
                        - Convert.ToDecimal(item["LABST"]);
                }
            }
            bdsContrast.DataSource = dtStock;
            setDataGridView();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            Contrast();
            SetFilter();
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void ckbViewDiff_CheckedChanged(object sender, EventArgs e)
        {
            SetFilter();
        }
        private void SetFilter()
        {
            StringBuilder temp = new StringBuilder();
            temp.AppendLine("1=1 ");
            if (!string.IsNullOrEmpty(txtPosition.Text.Trim()))
            {
                temp.AppendLine(" and (MATERIAL_NAME like '%" + txtPosition.Text.Trim() + "%'");
                temp.AppendLine(" or MATERIAL_FINANCE like '%" + txtPosition.Text.Trim() + "%')");
            }
            if (ckbViewDiff.Checked)
                temp.AppendLine(" and (MATERIAL_NAME is null or DIFF_QUANTITY is null or DIFF_QUANTITY<>0)");

            //dgvColumnStyle.Add("STOCKSAll", "机务库存");
            //dgvColumnStyle.Add("LABST", "SAP库存");
            //dgvColumnStyle.Add("DIFF_QUANTITY", "相差库存(机务库存-SAP库存)");

            bdsContrast.Filter = temp.ToString();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Contrast();
            SetFilter();
        }

        /// <summary>
        /// 释放窗体事件,保存列样式.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStorageContrast_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            dgvContrast.SaveGridView("FrmStorageContrast.dgvContrast");
            instance = null;
        }
        /// <summary>
        /// 关闭窗体事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
