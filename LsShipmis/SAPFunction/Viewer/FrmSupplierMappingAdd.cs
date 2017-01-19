using System;
using System.Data;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using SAPFunction.DataObject;
using SAPFunction.Services;
using BaseInfo.DataAccess;

namespace SAPFunction.Viewer
{
    public partial class FrmSupplierMappingAdd : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSupplierMappingAdd instance = new FrmSupplierMappingAdd();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSupplierMappingAdd Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSupplierMappingAdd.instance = new FrmSupplierMappingAdd();
                }
                return FrmSupplierMappingAdd.instance;
            }
        }
        #endregion
        public FrmSupplierMappingAdd()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            string err = "";
            string management = string.IsNullOrEmpty(ucSupplierSelect1.GetId()) ? ucSupplierSelect1.GetText() : ucSupplierSelect1.GetId();
            string finance = textBox4.Text.Trim();
            if (string.IsNullOrEmpty(management))
            {
                MessageBoxEx.Show("管理系统代码不能为空");
                ucSupplierSelect1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(finance))
            {
                MessageBoxEx.Show("财务系统代码不能为空");
                textBox4.Focus();
                return;
            }
            SupplierMapping mapping = new SupplierMapping();
            mapping.MANAGEMENT = management;
            mapping.FINANCE = finance;
            mapping.STATUS = "3";

            DataTable dt;
            if (!SupplierMappingService.Instance.GetMapping(management, null, null, out dt, out err))
                return;
            if (dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("管理系统代码已存在其他映射");
                ucSupplierSelect1.Focus();
                return;
            }
            DataTable dtSupplier = ManufacturerService.Instance.getInfo(management, out err);
            if (dtSupplier.Rows.Count == 0)
            {
                MessageBoxEx.Show("供应商不属于管理系统");
                ucSupplierSelect1.Focus();
                return;
            }
            DataTable dtfinance;
            if (!SupplierMappingService.Instance.GetMapping(null, finance, null, out dtfinance, out err))
                return;
            if (dtfinance.Rows.Count > 0)
            {
                MessageBoxEx.Show("财务系统船舶代码已存在其他映射");
                textBox4.Focus();
                return;
            }
            if (!SupplierMappingService.Instance.saveUnit(mapping, out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ucSupplierSelect1.Focus();
                return;
            }
            if (DialogResult.Yes == MessageBoxEx.Show("保存成功,是否继续添加?", "系统信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                textBox4.Text = "";
                ucSupplierSelect1.Focus();
                //ucSupplierSelect1.SelectedId("");
            }
            else
            {
                this.Close();
            }
        }

        private void FrmSupplierMappingAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void FrmSupplierMappingAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

    }
}
