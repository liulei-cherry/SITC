using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControlService;
namespace Maintenance.Viewer
{
    public partial class FrmEquipmentHistory : CommonViewer.BaseForm.FormBase
    {
        public FrmEquipmentHistory(ComponentUnit componentUnit)
        {
            InitializeComponent();
            equipment = componentUnit;
        }
        private ComponentUnit equipment;
        private void FrmEquipmentHistory_Load(object sender, EventArgs e)
        {
            this.setBindingSource();
            if (bindingSourceMain.DataSource != null)
            {
                this.setDataGridView();
            }
        }

        private void setDataGridView()
        {
            DataGridViewExt.loadGridView(dgvMain, CommonOperation.ConstParameter.UserId, "FrmEquipmentHistory.dgvMain");
            foreach (DataGridViewColumn col in dgvMain.Columns)
            {
                col.Visible = false;
            }
            dgvMain.Columns["ship_id"].Visible = false;
            dgvMain.Columns["COMP_CHINESE_NAME"].Visible = true;
            dgvMain.Columns["COMP_CHINESE_NAME"].HeaderText = "设备中文名";
            dgvMain.Columns["COMP_ENGLISH_NAME"].Visible = true;
            dgvMain.Columns["COMP_ENGLISH_NAME"].HeaderText = "设备英文名";
            dgvMain.Columns["HIS_BEGINTIME"].Visible = true;
            dgvMain.Columns["HIS_BEGINTIME"].HeaderText = "开始时间";
            dgvMain.Columns["HIS_STATEName"].Visible = true;
            dgvMain.Columns["HIS_STATEName"].HeaderText = "设备历史状态";
            dgvMain.Columns["HIS_ENDTIME"].Visible = true;
            dgvMain.Columns["HIS_ENDTIME"].HeaderText = "结束时间";
            dgvMain.Columns["COMPONENT_NAME"].Visible = true;
            dgvMain.Columns["COMPONENT_NAME"].HeaderText = "设备历史名";
            dgvMain.Columns["TIMING_COUNTER_VALUE"].Visible = true;
            dgvMain.Columns["TIMING_COUNTER_VALUE"].HeaderText = "定时设备抄表值";
            dgvMain.Columns["DETAIL"].Visible = true;
            dgvMain.Columns["DETAIL"].HeaderText = "备注";
            dgvMain.Columns["total_workhours"].Visible = true;
            dgvMain.Columns["total_workhours"].HeaderText = "设备累计运转值";
           
        }

        private void setBindingSource()
        {

            DataTable dtb = ComponentUnitService.Instance.GetEquipmentHistoryByUnitId(equipment.COMPONENT_UNIT_ID);
            bindingSourceMain.DataSource = dtb;
            dgvMain.DataSource = dtb;
        }

        private void FrmEquipmentHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bindingSourceMain.DataSource != null)
            {
                DataGridViewExt.saveGridView(dgvMain, CommonOperation.ConstParameter.UserId, "FrmEquipmentHistory.dgvMain");
            }
        }
    }
}