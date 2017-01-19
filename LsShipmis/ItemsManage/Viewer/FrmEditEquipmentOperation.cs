using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    public partial class FrmEditEquipmentOperation : CommonViewer.BaseForm.FormBase
    {

        public EquipmentOperation equipmentOperation;
        public FrmEditEquipmentOperation()
        {
            InitializeComponent();
        }
        
        public FrmEditEquipmentOperation(EquipmentOperation operation)
        {           
            InitializeComponent();

            equipmentOperation = operation;
            this.ChangeData(equipmentOperation);
        }

        public void ChangeData(EquipmentOperation operation)
        {

            txtName.Text = operation.OPERATIONNAME;
            numOrderNum.Value = operation.SORTNO;
            txtDetail.Text = operation.OPERATIONDETAIL;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        /// <summary>
        /// 保存对象功能.
        /// </summary>
        public void UpdateObject()
        {
            string err;
            if (!SetObject(out err))
            {
                return;
            }
            if (beforSaveCheck())
            {
                MessageBoxEx.Show("保存成功!");
                this.Close();
            }
        }

        private bool beforSaveCheck()
        {
            if (string.IsNullOrEmpty(equipmentOperation.OPERATIONNAME))
            {
                MessageBoxEx.Show("名称不允许为空!");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(equipmentOperation.OPERATIONDETAIL))
            {
                MessageBoxEx.Show("操作步骤不允许为空!");
                txtDetail.Focus();
                return false;
            }

            string err;
            if (!EquipmentOperationService.Instance.saveUnit(equipmentOperation, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 把显示值设置到对象上.
        /// </summary>
        public bool SetObject(out string err)
        {
            err = "";
            if (equipmentOperation != null)
            {
                equipmentOperation.OPERATIONNAME = txtName.Text;
                equipmentOperation.SORTNO = int.Parse(numOrderNum.Value.ToString());
                equipmentOperation.OPERATIONDETAIL = txtDetail.Text;
                return true;
            }
            else
            {
                err = "当前对象无效!";
                MessageBoxEx.Show(err);

            }
            return false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}