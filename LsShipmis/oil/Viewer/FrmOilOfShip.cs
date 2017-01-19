using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using Oil.Services;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonViewer.BaseControl;
using Oil.DataObject;

namespace Oil.Viewer
{
    public partial class FrmOilOfShip : CommonViewer.BaseForm.FormBase
    {
        private string lastShipID = "1";

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilOfShip instance = new FrmOilOfShip();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilOfShip Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilOfShip.instance = new FrmOilOfShip();
                }
                return FrmOilOfShip.instance;
            }
        }
        #endregion
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        public FrmOilOfShip()
        {
            InitializeComponent();
        }

        private void FrmOilOfShip_Load(object sender, EventArgs e)
        {
            bdNgAddNewItem.Visible = true;
            bdNgDeleteItem.Visible = true;
            btnSave.Visible = true;
            string err;
            //加载船舶列表.
            DataTable dtShip = ShipInfoService.Instance.GetOwnerShip(out err);
            bindingSourceMain.DataSource = dtShip;
            if (dtShip != null)
            {
                ucDataGridView1.DataSource = bindingSourceMain;
                setDataGridView();
                ucDataGridView2.DataSource = bindingSourceDetail;
                setDataGridViewDetail();
            }
            else
            {
                bindingSourceDetail.DataSource = null;
            }

        }
        private bool IsLeaveCheckDataTableState(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return true;
            DataView dv = new DataView(dt);
            dv.RowStateFilter = DataViewRowState.Added;
            if (dv.ToTable().Rows.Count > 0)
            {
                if (DialogResult.No == MessageBoxEx.Show("该关联信息存在被新添加但未保存的数据,是否离开?", "提示", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    return false;
                }
                return true;
            }
            dv.RowStateFilter = DataViewRowState.Deleted;
            if (dv.ToTable().Rows.Count > 0)
            {
                if (DialogResult.No == MessageBoxEx.Show("该关联信息存在被删除但未保存的数据,是否离开?", "提示", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    return false;
                }
                return true;
            }
            dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
            if (dv.ToTable().Rows.Count > 0)
            {
                if (DialogResult.No == MessageBoxEx.Show("该关联信息存在被修改但未保存的数据,是否离开?", "提示", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        private void ucDataGridView1_SelectedChanged(int rowNumber)
        {
            string shipId = ucDataGridView1.Rows[rowNumber].Cells["ship_Id"].Value.ToString();
            if (lastShipID == shipId) return;
            //刷新所有当前船舶绑定的数据.
            DataTable dtbShipOil = HOilService.Instance.GetShipOil(shipId);
            bindingSourceDetail.DataSource = dtbShipOil;
        }

        private void setDataGridView()
        {
            ucDataGridView1.LoadGridView("FrmOilOfShip.ucDataGridView1");
            ucDataGridView1.SetDgvGridColumns(ShipInfoService.Instance.GetObjectDisplaySetting());
        }
        private void setDataGridViewDetail()
        {
            ucDataGridView2.LoadGridView("FrmOilOfShip.ucDataGridView2");
            Dictionary<string, string> dicDetail = new Dictionary<string, string>();
            dicDetail.Add("OIL_TYPE_NAME", "油品种类");
            dicDetail.Add("OIL_FULL_NAME", "油品全称");
            dicDetail.Add("ForWhichType", "本船用油名称");
            dicDetail.Add("ORDERNUM", "排序号");
            ucDataGridView2.SetDgvGridColumns(dicDetail);
            string[] readOnlyC = new string[2];
            readOnlyC[0] = "OIL_TYPE_NAME";
            readOnlyC[1] = "OIL_FULL_NAME";
            ucDataGridView2.setDgvColumnsReadOnly(readOnlyC);
        }
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (bindingSourceMain.Current == null) return;
            string shipId = ((DataRowView)bindingSourceMain.Current).Row["ship_Id"].ToString();
            if (string.IsNullOrEmpty(shipId)) return;
            //弹出 所有滑油选择的界面.
            FrmMultiSelectOilType frm = new FrmMultiSelectOilType(shipId);
            frm.ShowDialog();
            string err;
            if (frm.Selected)
            {
                foreach (string oneId in frm.OilTypes)
                {
                    DataTable dtb = (DataTable)(bindingSourceDetail.DataSource);
                    if (dtb.Select("Oil_Id='" + oneId + "'").Length > 0)
                        continue;

                    HOil oneOil = HOilService.Instance.getObject(oneId, out err);
                    if (oneOil == null || oneOil.IsWrong) continue;

                    int nowRow = dtb.Rows.Count - 1;
                    DataRow dr = dtb.NewRow();
                    dr["Oil_SHIP_Id"] = Guid.NewGuid().ToString();
                    dr["Oil_Id"] = oneId;
                    dr["OIL_NAME"] = oneOil.OIL_NAME;
                    dr["OIL_FULL_NAME"] = oneOil.OIL_NAME + " " + oneOil.TRADEMARK;
                    dr["OIL_TYPE"] = oneOil.OIL_TYPE;
                    dr["OIL_TYPE_NAME"] = (oneOil.OIL_TYPE == "0" ? "重油" : (oneOil.OIL_TYPE == "1" ? "轻油" : (oneOil.OIL_TYPE == "2" ? "润滑油" : "")));
                    dr["SHIP_ID"] = shipId;
                    dr["ORDERNUM"] = nowRow + 1;
                    dtb.Rows.Add(dr);
                }
            }
        }

        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            //删除当前选择的行.
            if (bindingSourceDetail.Current != null)
            {
                string err;
                DataTable dtb = HOilLuboilConsumeService.Instance.GetInfoByMonthOil(lastShipID, null, ((DataRowView)bindingSourceDetail.Current).Row["Oil_Id"].ToString(), out err);
                if (dtb.Rows.Count > 0)
                {
                    MessageBoxEx.Show("该润滑油已存在月消耗存量信息,不能删除!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                //DataTable dt = (DataTable)bindingSourceDetail.DataSource;
                ////删除当前记录.
                //if (dt.Rows.Count > 0)
                //{
                //    string err = "";
                //    string detailID = ((DataRowView)bindingSourceDetail.Current).Row["OIL_SHIP_ID"].ToString();
                //    HOilShipService.Instance.deleteUnit(detailID, out err);
                //}

                bindingSourceDetail.RemoveCurrent();
                btnSave_Click(sender, e);
            }
            else
            {
                MessageBoxEx.Show("未选择任何行,无法删除", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bindingSourceMain.Current == null) return;
            foreach (DataGridViewRow dr in ucDataGridView2.Rows)
            {
                dr.Cells["ORDERNUM"].Value = dr.Index + 1;
            }
            //保存当前所有的设定值,如果没有设置,报警.
            //所有的排序必须是数字,本船用途必填.
            if (ucDataGridView2.HasEmptyVal("ForWhichType"))
            {
                MessageBoxEx.Show("本船用途自动必须填写,否则影响以后报表的输出", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            if (!ucDataGridView2.IsNumeric("ORDERNUM"))
            {
                MessageBoxEx.Show("排序号必须为数值型", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            string err;
            if (dbOperation.SaveFormData((DataTable)bindingSourceDetail.DataSource, "T_HOil_Ship", 0, out err))
            {
                MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            if (!IsLeaveCheckDataTableState(dt))
            {
                return;
            }
            this.Close();
        }

        private void FrmOilOfShip_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmOilOfShip.ucDataGridView1");
            ucDataGridView2.SaveGridView("FrmOilOfShip.ucDataGridView2");
            instance = null;
        }

    }
}
