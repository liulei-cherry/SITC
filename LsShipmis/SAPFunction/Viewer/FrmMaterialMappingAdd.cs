using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using SAPFunction.DataObject;
using SAPFunction.Services;
using ItemsManage.Services;
using Oil.Services;
using ItemsManage.DataObject;

namespace SAPFunction.Viewer
{
    public partial class FrmMaterialMappingAdd : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialMappingAdd instance = new FrmMaterialMappingAdd();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialMappingAdd Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialMappingAdd.instance = new FrmMaterialMappingAdd();
                }
                return FrmMaterialMappingAdd.instance;
            }
        }
        #endregion
        public FrmMaterialMappingAdd()
        {
            InitializeComponent();
        }
        private void btnSave_Enter(object sender, EventArgs e)
        {
            string err = "";
            string management = textBox8.Text.Trim();
            string material_finance = textBox9.Text.Trim();
            //string storageQuantity = textBox9.Text.Trim();
            string cost_finance = string.IsNullOrEmpty(ucCostSelect1.GetId()) ? ucCostSelect1.GetText() : ucCostSelect1.GetId();
            if (string.IsNullOrEmpty(management))
            {
                MessageBoxEx.Show("管理系统代码不能为空");
                textBox8.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(material_finance) && !string.IsNullOrEmpty(cost_finance))
            {
                MessageBoxEx.Show("财务系统代码与财务系统费用科目只能填写一个");
                textBox9.Focus();
                return;
            }
            if (string.IsNullOrEmpty(material_finance) && string.IsNullOrEmpty(cost_finance))
            {
                MessageBoxEx.Show("财务系统代码与财务系统费用科目必须填写一个");
                textBox9.Focus();
                return;
            }
            if (string.IsNullOrEmpty(material_finance) && string.IsNullOrEmpty(cost_finance))
            {
                MessageBoxEx.Show("财务系统代码与财务系统费用科目必须填写一个");
                textBox9.Focus();
                return;
            }
            MaterialMapping mapping = new MaterialMapping();
            mapping.MANAGEMENT = management;
            mapping.MATERIAL_FINANCE = material_finance;
            mapping.COST_FINANCE = cost_finance;
            mapping.STATUS = "3";

            DataTable dt;
            if (!MaterialMappingService.Instance.GetMapping(management, null, null, out dt, out err))
                return;
            if (dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("管理系统代码已存在其他映射");
                textBox8.Focus();
                return;
            }
            DataTable dtMaterialName;
            MaterialMappingService.Instance.GetMaterialName(management, out dtMaterialName, out err);
            if (dtMaterialName.Rows.Count == 0)
            {
                MessageBoxEx.Show("管理系统物资不属于管理系统");
                textBox8.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(material_finance))
            {
                DataTable dtMaterialFinance;
                if (!MaterialMappingService.Instance.GetMapping(null, material_finance, null, out dtMaterialFinance, out err))
                    return;
                if (dtMaterialFinance.Rows.Count > 0)
                {
                    MessageBoxEx.Show("财务系统物资代码映射已存在其他映射");
                    textBox9.Focus();
                    return;
                }
            }

            if (!MaterialMappingService.Instance.saveUnit(mapping, out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox8.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(mapping.MATERIAL_FINANCE))
            {
                if (dtMaterialName.Rows[0]["MATERIAL_TYPE"].ToString() == "1")
                {
                    MaterialInfo mi = MaterialInfoService.Instance.getObject(mapping.MANAGEMENT, out err);
                    if (mi != null && mi.MATERIAL_CODE != mapping.MATERIAL_FINANCE)
                    {
                        mi.MATERIAL_CODE = mapping.MATERIAL_FINANCE;
                        if (!mi.Update(out err))
                            MessageBoxEx.Show(err);
                    }
                }
                else if (dtMaterialName.Rows[0]["MATERIAL_TYPE"].ToString() == "2")
                {
                    SpareInfo si = SpareInfoService.Instance.getObject(mapping.MANAGEMENT, out err);
                    if (si != null && si.ISSPECIALSP != 1)
                    {
                        si.ISSPECIALSP = 1;
                        if (!si.Update(out err))
                            MessageBoxEx.Show(err);
                    }
                }
            }
            if (DialogResult.Yes == MessageBoxEx.Show("保存成功,是否继续添加?", "系统信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                textBox8.Text = "";
                textBox8.Focus();
                textBox9.Text = "";
                //ucCostSelect1.SelectedId("");
            }
            else
            {
                this.Close();
            }
        }
        private void FrmMaterialMappingAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMaterialMappingAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
