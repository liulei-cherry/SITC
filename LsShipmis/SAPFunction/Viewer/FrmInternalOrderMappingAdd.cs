using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SAPFunction.DataObject;
using CommonViewer.BaseControl;
using SAPFunction.Services;
using Cost.Services;
using BaseInfo.DataAccess;

namespace SAPFunction.Viewer
{
    public partial class FrmInternalOrderMappingAdd : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmInternalOrderMappingAdd instance = new FrmInternalOrderMappingAdd();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmInternalOrderMappingAdd Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmInternalOrderMappingAdd.instance = new FrmInternalOrderMappingAdd();
                }
                return FrmInternalOrderMappingAdd.instance;
            }
        }
        #endregion
        public FrmInternalOrderMappingAdd()
        {
            InitializeComponent();
            ucShipSelect1.ChangeSelectedState(false,false);
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx1_Enter(object sender, EventArgs e)
        {
            string err = "";
            string ship_code = string.IsNullOrEmpty(ucShipSelect1.GetId()) ? ucShipSelect1.GetText() : ucShipSelect1.GetId();
            string item_code = string.IsNullOrEmpty(ucCostSubjectSelect2.GetId()) ? ucCostSubjectSelect2.GetText() : ucCostSubjectSelect2.GetId();
            string internal_order_finance = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(ship_code))
            {
                MessageBoxEx.Show("船舶代号不能为空");
                ucShipSelect1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(item_code))
            {
                MessageBoxEx.Show("项目类别代号不能为空");
                ucCostSubjectSelect2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(internal_order_finance))
            {
                MessageBoxEx.Show("财务系统的内部订单号不能为空");
                textBox7.Focus();
                return;
            }
            InternalOrderMapping mapping = new InternalOrderMapping();
            mapping.SHIP_CODE = ship_code;
            mapping.ITEM_CODE = item_code;
            mapping.INTERNAL_ORDER_FINANCE = internal_order_finance;
            mapping.STATUS = "3";

            DataTable dt;
            if (!InternalOrderMappingService.Instance.GetMapping(ship_code, item_code, null, null, out dt, out err))
                return;
            if (dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("内部订单已存在");
                ucShipSelect1.Focus();
                return;
            }
            DataTable dtShip = ShipInfoService.Instance.getInfo(ship_code, out err);
            if (dtShip.Rows.Count == 0)
            {
                MessageBoxEx.Show("船舶代码不属于管理系统");
                ucShipSelect1.Focus();
                return;
            }
            DataTable dtCost = AccountService.Instance.getInfo(item_code, out err);
            if (dtCost.Rows.Count == 0)
            {
                MessageBoxEx.Show("项目类别代码不属于管理系统");
                ucCostSubjectSelect2.Focus();
                return;
            }
            DataTable dtinternal_order_finances;
            if (!InternalOrderMappingService.Instance.GetMapping(ship_code, item_code, null, null, out dtinternal_order_finances, out err))
                return;
            if (dtinternal_order_finances.Rows.Count > 0)
            {
                MessageBoxEx.Show("财务系统船舶代码与项目类别代码已存在其他映射");
                ucShipSelect1.Focus();
                return;
            }
            if (!InternalOrderMappingService.Instance.saveUnit(mapping, out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ucShipSelect1.Focus();
                return;
            }
            if (DialogResult.Yes == MessageBoxEx.Show("保存成功,是否继续添加?", "系统信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                //ucShipSelect1.SelectedId("");
                ucShipSelect1.Focus();
                textBox7.Text = "";
                //ucCostSubjectSelect2.SelectedId("");
            }
            else
            {
                this.Close();
            }
        }

        private void FrmInternalOrderMappingAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void FrmInternalOrderMappingAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
