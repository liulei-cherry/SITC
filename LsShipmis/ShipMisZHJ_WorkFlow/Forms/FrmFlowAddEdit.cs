using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace ShipMisZHJ_WorkFlow.Forms
{
    public partial class FrmFlowAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmFlowAddEdit()
        {
            InitializeComponent();
        }

        public FrmFlowAddEdit(T_WorkFlow_Entrance we):this()
        {
            entrance = we;
            showData(entrance);
        }

        T_WorkFlow_Entrance entrance;

        public T_WorkFlow_Entrance Entrance
        {
            get { return entrance; }
            set { entrance = value;}
        }

        private void showData(T_WorkFlow_Entrance entrance)
        {
            string err = "";
            if (entrance != null && entrance.WorkFlow_Entrance_Id.Length==36)
            {
                cboFlowObj.Text = T_WorkFlow_ObjectService.Instance.getObject(entrance.WorkFlow_Object_Id, out err).WorkFlow_Object_Name;
                labDetp.Text =   DepartmentService.Instance.getObject(entrance.DepartmentId, out err).DEPARTNAME;
                labDetp.Tag = entrance.DepartmentId;
                txtFlowName.Text = entrance.WorkFlow_Name;
            }
        }

        private void FrmFlowAddEdit_Load(object sender, EventArgs e)
        {
            string err = "";
            cboFlowObj.DisplayMember = "WorkFlow_Object_Name";
            cboFlowObj.ValueMember = "WorkFlow_Object_Id";
            cboFlowObj.DataSource = T_WorkFlow_ObjectService.Instance.getInfoOrder(out err);

            showData(entrance);

        }

        private void btnDeptSelect_Click(object sender, EventArgs e)
        {
            FrmDeptSelect frm = new FrmDeptSelect();
            frm.ShowDialog();
            Department dept = frm.Dept;
            if (dept != null)
            {
                labDetp.Text = dept.DEPARTNAME;
                labDetp.Tag = dept.DEPARTMENTID;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!makeObj()) return;
            string err = "";
            if (string.IsNullOrEmpty(entrance.WorkFlow_Entrance_Id)) //New add
            {
                if (T_WorkFlow_EntranceService.Instance.getDuplicate(entrance.WorkFlow_Object_Id, entrance.DepartmentId) > 0) //已经定义过这个流程.
                {
                    MessageBox.Show("已经定义过这个流程");
                    return; 
                }
            }
            else //edit
            {
                string editTo = T_WorkFlow_EntranceService.Instance.getGuid(entrance.WorkFlow_Object_Id, entrance.DepartmentId);
                if (editTo.Length == 36 && !editTo.Equals(entrance.WorkFlow_Entrance_Id))
                {
                    MessageBox.Show("已经定义过这个流程");
                    return; 
                }
            }

            if (entrance.WorkFlow_Id.Length != 36)
            {
                T_WorkFlow workflow = new T_WorkFlow();
                T_WorkFlowService.Instance.saveUnit(workflow, out err);
                if (err.Equals(""))
                {
                    entrance.WorkFlow_Id = workflow.WorkFlow_Id;
                }
                else
                {
                    MessageBox.Show(err);
                    return;
                }
            }
            
            T_WorkFlow_EntranceService.Instance.saveUnit(entrance, out err);
            if (err.Equals(""))
            {
                Close();
            }
            else
            {
                MessageBox.Show(err);
            }

        }

        private bool makeObj()
        {
            if (entrance == null) entrance = new T_WorkFlow_Entrance();
            entrance.WorkFlow_Object_Id = this.cboFlowObj.SelectedValue.ToString();
            if( labDetp.Tag==null || labDetp.Tag.ToString().Length!=36)
            {
                MessageBox.Show("请选择提交部门");
                return false;
            }
            entrance.DepartmentId = this.labDetp.Tag.ToString();
            entrance.WorkFlow_Name = this.txtFlowName.Text.Trim();
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}