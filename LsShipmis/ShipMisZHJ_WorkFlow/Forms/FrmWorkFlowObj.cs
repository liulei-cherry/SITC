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
    public partial class FrmWorkFlowObj : CommonViewer.BaseForm.FormBase
    {
        public FrmWorkFlowObj()
        {
            InitializeComponent();
        }

        private static FrmWorkFlowObj instance;

        public static FrmWorkFlowObj Instance
        {
            get 
            {
                if (instance == null) instance = new FrmWorkFlowObj();
                return FrmWorkFlowObj.instance; 
            }       
        }       

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        private void FrmWorkFlowObj_Load(object sender, EventArgs e)
        {
            setGridShortCutBtn();
            LoadData();
            loadWorkDataCol();
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理，.
        /// </summary>
        private void setGridShortCutBtn()
        { 
            ucDataGridView.adding = adding;
            ucDataGridView.editing = editing;
            ucDataGridView.deleting = deleting;
        }
        private void adding()
        {
            btnAdd_Click(null,null);
        }
        private void editing()
        {
            btnEdit_Click(null, null);
        }
        private void deleting()
        {
            btnDelete_Click(null, null);
        }
        /// <summary>
        /// 信息列项.
        /// </summary>
        private void loadWorkDataCol()
        {
            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("WorkFlow_Object_Name", "需要控制的流程对象名");
            ucDataGridView.SetDgvGridColumns(dictColumns);
            ucDataGridView.Columns["WorkFlow_Object_Id"].Tag = 0;//设为标签使动态按钮列能正常显示.
            ucDataGridView.Columns["WorkFlow_Object_Name"].Width = 300;
        }

        private void LoadData()
        {
            string err = "";
            DataTable dt = T_WorkFlow_ObjectService.Instance.getInfoOrder(out err);
            if (err.Equals(""))
            {
                ucDataGridView.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmWorkFlowAddEdit frm = new FrmWorkFlowAddEdit();
            frm.Saved += new EventHandler(frm_Saved);
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ucDataGridView.CurrentRow != null)
            {
                T_WorkFlow_Object wo = T_WorkFlow_ObjectService.Instance.getObject(ucDataGridView.CurrentRow);
                FrmWorkFlowAddEdit frm = new FrmWorkFlowAddEdit(wo);
                frm.Saved += new EventHandler(frm_Saved);
                frm.ShowDialog();
            }
        }

        void frm_Saved(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err = "";
            if (ucDataGridView.CurrentRow != null)
            {
                if (MessageBox.Show("确实要删除选定的流程定义类型吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                T_WorkFlow_Object wo = T_WorkFlow_ObjectService.Instance.getObject(ucDataGridView.CurrentRow);
                T_WorkFlow_ObjectService.Instance.deleteUnit(wo, out err);
                if (err.Equals(""))
                {
                    DataTable dt = ((DataTable)ucDataGridView.DataSource);
                    DataRow dr = dt.Select("WorkFlow_Object_Id='" + wo.WorkFlow_Object_Id + "'")[0];
                    if (dr != null)
                    {
                        dt.Rows.Remove(dr);
                    }
                }
                else
                {
                    MessageBox.Show(err);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmWorkFlowObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}