using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using CommonViewer.BaseForm;
using ItemsManage.DataObject;
using ItemsManage.Viewer;
using Maintenance.Services;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace Maintenance.Viewer
{
    public partial class FrmWorkInfoSpare : CommonViewer.BaseForm.FormBase
    {
        public FrmWorkInfoSpare(Maintenance.DataObject.WorkInfo workInfoIn)
        {
            InitializeComponent();
            workInfo = workInfoIn;
        }
        private Maintenance.DataObject.WorkInfo workInfo;
        private ComponentType ComponentType;
        private void FrmWorkInfoSpare_Load(object sender, EventArgs e)
        {
            string err;
            if (workInfo == null || workInfo.IsWrong) throw new Exception("");

            ShipInfo shipInfo = ShipInfoService.Instance.getObject(workInfo.SHIP_ID,out err);
            ucEquipmentClassTreeWithEquipment1.ReloadingShipData(shipInfo);
         
            this.setDgvCheckBox();
            this.setBindingSourceAdded();
            if (bindingSourceAdded.DataSource != null)
            {
                this.setDgvAdded();
            }         
        }

        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            if (objectType == 2)
            {
                ComponentUnit equipment = (ComponentUnit)theObject;
                equipment.FillThisObject();
                if (equipment.TheComponentType != null && !equipment.TheComponentType.IsWrong)
                {
                    ucEquipmentTypeTree1_NodeClick(equipment.TheComponentType);
                }
            }
        }

        void ucEquipmentTypeTree1_NodeClick(ComponentType equipType)
        {
            ComponentType = equipType;
            bool ifHaveSet = true;
            if (dgvUnAdd.Columns.Count <= 1)
            {
                ifHaveSet = false;
            }
            this.setBindingSourceUnAdd();
            if (ifHaveSet == false && bindingSourceUnAdd.DataSource != null)
            {
                this.setDgvUnAdd();              
            }
            
        }

        private void setDgvCheckBox()
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = "check";
            col.TrueValue = 1;
            col.FalseValue = 0;
            col.Width = 30;
            col.HeaderText = "";
            dgvAdded.Columns.Add(col);

            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            col1.Name = "check";
            col1.TrueValue = 1;
            col1.FalseValue = 0;
            col1.Width = 30;
            col1.HeaderText = "";
            dgvUnAdd.Columns.Add(col1);
        }

        private void setBindingSourceUnAdd()
        {
            if (string.IsNullOrEmpty(ComponentType.COMPONENT_TYPE_ID)) return;
            DataTable dtb = WorkInfoService.Instance.GetSpareInfoByCompTypeId(ComponentType.COMPONENT_TYPE_ID);
            bindingSourceUnAdd.DataSource = dtb;
            dgvUnAdd.DataSource = bindingSourceUnAdd;

            string filter = this.formFilterStr();
            bindingSourceUnAdd.Filter = filter;

        }

        private string formFilterStr()
        {
            string returnSql = "";
            if (bindingSourceAdded.DataSource == null || dgvAdded.Rows.Count == 0)
            {
                return returnSql;
            }

            returnSql = "SPARE_ID not in(";
            foreach (DataGridViewRow row in dgvAdded.Rows)
            {
                returnSql += "'";
                returnSql += row.Cells["SPARE_ID"].Value.ToString();
                returnSql += "',";
            }
            returnSql = returnSql.Substring(0, returnSql.Length - 1);
            returnSql += ")";

            return returnSql;
        }

        private void setDgvUnAdd()
        {

            for (int i = 1; i < dgvUnAdd.Columns.Count; i++)
            {
                dgvUnAdd.Columns[i].ReadOnly = true;
                dgvUnAdd.Columns[i].Visible = false;
            }
            dgvUnAdd.Columns["SPARE_NAME"].Visible = true;
            dgvUnAdd.Columns["SPARE_ENAME"].Visible = true;
            dgvUnAdd.Columns["PARTNUMBER"].Visible = true;
            dgvUnAdd.Columns["UNIT_NAME"].Visible = true;
            dgvUnAdd.Columns["REMARK"].Visible = true;
            dgvUnAdd.Columns["UNIT_NAME"].HeaderText = "计量单位";
            dgvUnAdd.Columns["SPARE_NAME"].HeaderText = "备件中文名";
            dgvUnAdd.Columns["SPARE_ENAME"].HeaderText = "备件英文名";
            dgvUnAdd.Columns["PARTNUMBER"].HeaderText = "备件配件号";
            dgvUnAdd.Columns["REMARK"].HeaderText = "备注";
        }

        private void setBindingSourceAdded()
        {
            DataTable dtb = WorkInfoService.Instance.GetWorkInfoSpareByWkId(workInfo);
            bindingSourceAdded.DataSource = dtb;
            dgvAdded.DataSource = bindingSourceAdded;
            
        }

        private void setDgvAdded()
        {
            for (int i = 1; i < dgvAdded.Columns.Count; i++)
            {
                if (!dgvAdded.Columns[i].Name.Equals("UNIT_NAME") && !dgvAdded.Columns[i].Name.Equals("DefaultUseCount"))
                {
                    dgvAdded.Columns[i].ReadOnly = true;
                    dgvAdded.Columns[i].Visible = false;
                }
            }

            dgvAdded.Columns["UNIT_NAME"].Visible = true;
            dgvAdded.Columns["DefaultUseCount"].Visible = true;
            dgvAdded.Columns["SPARE_NAME"].Visible = true;
            dgvAdded.Columns["SPARE_ENAME"].Visible = true;
            dgvAdded.Columns["PARTNUMBER"].Visible = true;
            dgvAdded.Columns["REMARK"].Visible = true;
            dgvAdded.Columns["UNIT_NAME"].HeaderText = "计量单位";
            dgvAdded.Columns["DefaultUseCount"].HeaderText = "默认数量";
            dgvAdded.Columns["SPARE_NAME"].HeaderText = "备件中文名";
            dgvAdded.Columns["SPARE_ENAME"].HeaderText = "备件英文名";
            dgvAdded.Columns["PARTNUMBER"].HeaderText = "备件配件号";
            dgvAdded.Columns["REMARK"].HeaderText = "备注"; 

        }

        private void dgvAdded_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvAdded.Columns[e.ColumnIndex].Name.Equals("DefaultUseCount"))
            {
                int n = 0;
                if (int.TryParse(e.FormattedValue.ToString(),out n) == false)
                {
                    MessageBoxEx.Show("默认数量输入格式不正确！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (bindingSourceAdded.DataSource == null || bindingSourceUnAdd.DataSource == null)
            {
                return;
            }
            foreach (DataGridViewRow row in dgvUnAdd.Rows)
            {
                if (row.Cells["check"].Value != null && row.Cells["check"].Value.ToString().Equals("1"))
                {
                    bindingSourceAdded.AddNew();
                    DataGridViewRow row1 = dgvAdded.CurrentRow;
                    row1.Cells["SPARE_ID"].Value = row.Cells["SPARE_ID"].Value.ToString();
                    row1.Cells["SPARE_NAME"].Value = row.Cells["SPARE_NAME"].Value.ToString();
                    row1.Cells["SPARE_ENAME"].Value = row.Cells["SPARE_ENAME"].Value.ToString();
                    row1.Cells["PARTNUMBER"].Value = row.Cells["PARTNUMBER"].Value.ToString();
                    row1.Cells["UNIT_NAME"].Value = row.Cells["UNIT_NAME"].Value.ToString();
                    row1.Cells["REMARK"].Value = row.Cells["REMARK"].Value.ToString();
                    row1.Cells["ship_id"].Value = workInfo.SHIP_ID; 
                    row1.Cells[0].Value = 0;
                    row1.Cells["DefaultUseCount"].Value = 0;
                }
            }
            this.setBindingSourceUnAdd();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int cout = dgvAdded.Rows.Count;
            for(int i = cout -1 ;i >= 0 ;i--){
                DataGridViewRow row = dgvAdded.Rows[i];
                if (row.Cells["check"].Value != null && row.Cells["check"].Value.ToString().Equals("1"))
                {
                    dgvAdded.Rows.Remove(row);
                }
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bindingSourceAdded.EndEdit();
           
            //保存.
            DataTable dtb = new DataTable();
            dtb.Columns.Add("SPARE_ID", typeof(string));
            dtb.Columns.Add("DefaultUnitName", typeof(string));
            dtb.Columns.Add("DefaultUseCount", typeof(string));
            dtb.Columns.Add("ship_id", typeof(string));
            foreach (DataGridViewRow row in dgvAdded.Rows)
            {
                DataRow row1 = dtb.NewRow();
                row1["SPARE_ID"] = row.Cells["SPARE_ID"].Value.ToString();
                row1["DefaultUnitName"] = row.Cells["UNIT_NAME"].Value.ToString();
                row1["DefaultUseCount"] = row.Cells["DefaultUseCount"].Value.ToString();
                row1["ship_id"] = workInfo.SHIP_ID;
                dtb.Rows.Add(row1);
            }
            string err;
            if (WorkInfoService.Instance.SaveWorkInfoSpareByWorkInfoId(workInfo, dtb, out err))
            {
                MessageBoxEx.Show("修改成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

    }
}