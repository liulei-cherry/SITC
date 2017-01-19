using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace ShipMisZHJ_WorkFlow.Forms
{
    public partial class FrmWorkFlowAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmWorkFlowAddEdit()
        {
            InitializeComponent();
            this.Text = "增加流程对象";
        }

        private T_WorkFlow_Object oWo;

        public FrmWorkFlowAddEdit(T_WorkFlow_Object wo) : this()
        {
            this.Text = "修改流程对象";
            oWo = wo;
        }

        private void FrmWorkFlowAddEdit_Load(object sender, EventArgs e)
        {
            if (oWo != null)
            {
                txtObj.Text = oWo.WorkFlow_Object_Name;
            }
        }

        public event EventHandler Saved;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtObj.Text = txtObj.Text.Trim();
            string err = "";
            if (txtObj.Text.Length == 0)
            {
                MessageBox.Show("必须输入要进行流程控制的业务名", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (oWo == null) oWo = new T_WorkFlow_Object();
            oWo.WorkFlow_Object_Name = txtObj.Text;

            int rows = T_WorkFlow_ObjectService.Instance.findObj(txtObj.Text);
            if (err.Equals(""))
            {
                if (rows >= 1) //duplicate
                {
                    MessageBox.Show("重复的流程对象名称", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    T_WorkFlow_ObjectService.Instance.saveUnit(oWo, out err);
                    if (err.Equals(""))
                    {
                        if (Saved!= null)
                        {
                            Saved(sender, e);
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(err);
                    }
                }
    
            }
            else
            {
                MessageBox.Show(err);
            }
        }

    }
}