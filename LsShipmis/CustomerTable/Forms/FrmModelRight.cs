using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
namespace CustomerTable.Forms
{
    public partial class FrmModelRight : CommonViewer.BaseForm.FormBase
    {
        private List<string> lstCheckedIds = new List<string>();
        private static FrmModelRight instance = new FrmModelRight();
        public static FrmModelRight Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FrmModelRight();
                }
                return instance;
            }
        }
        private bool loaded = false;

        private FrmModelRight()
        {
            InitializeComponent();
        }

        private void FrmModelRight_Load(object sender, EventArgs e)
        {
            string err;
            DataTable dt = PostService.Instance.getInfo(out err);
            if (dt != null)
            {
                ucDataGridView1.DataSource = dt;
                ucDataGridView1.SetDgvGridColumns(PostService.Instance.GetObjectDisplaySetting());
            }
            List<string> allModelName = CustomerTableConfig.GetAllCustomerTables();
              
            ucDataGridView2.Columns[0].Name = "modelName";
            for  (int i = 0;i<allModelName.Count ;i++)
            {
                ucDataGridView2.Rows.Add();
                ucDataGridView2.Rows[i].Cells[0].Value  = allModelName[i];
            }
            loaded = true;
            DataGridViewCheckBoxColumn dgvCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dgvCheckBoxColumn.HeaderText = "选择";
            dgvCheckBoxColumn.Name = "checked";
            dgvCheckBoxColumn.Width = 50;
            ucDataGridView1.Columns.Add(dgvCheckBoxColumn);
            dgvCheckBoxColumn.DisplayIndex = 0;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucDataGridView2.CurrentRow != null)
            {
                string err;
                if (WorkModelTypeService.Instance.SetModelRight(ucDataGridView2.CurrentRow.Cells[0].Value.ToString(), lstCheckedIds, out err))
                {
                    MessageBoxEx.Show("更新成功！","系统提示");
                }
                else
                {
                    MessageBoxEx.Show("更新权限失败！错误信息为：\r" + err, "错误提示");
                }
            }
        }

        private void ucDataGridView1_Sorted(object sender, EventArgs e)
        {
            resetToHeaderSelect();           
        }

        private void ucDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ucDataGridView1.Columns[e.ColumnIndex].Name == "checked")
                {
                    string theClickedId = ucDataGridView1.Rows[e.RowIndex].Cells["SHIP_HEADSHIP_ID"].Value.ToString();
                    if (ucDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || (bool)(ucDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == false)
                    {
                        if (!lstCheckedIds.Contains(theClickedId))
                        {
                            lstCheckedIds.Add(theClickedId);
                        }
                        ucDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    else
                    {
                        if (lstCheckedIds.Contains(theClickedId))
                        {
                            lstCheckedIds.Remove(theClickedId);
                        }
                        ucDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
            catch { }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {            
            this.Close();
            instance = null;
        }

        private void ucDataGridView2_SelectedChanged(int rowNumber)
        {
            lstCheckedIds.Clear();
            if (loaded &&  rowNumber >= 0)
            {
                lstCheckedIds = WorkModelTypeService.Instance.GetModelRight(ucDataGridView2.Rows[rowNumber].Cells["modelName"].Value.ToString());
            }
            resetToHeaderSelect();
        }

        private void resetToHeaderSelect()
        {
            try
            {
                //排序后，把原来标志过的重新标上选择。.
                foreach (DataGridViewRow dr in ucDataGridView1.Rows)
                {
                    if (lstCheckedIds.Contains(dr.Cells["SHIP_HEADSHIP_ID"].Value.ToString()))
                    {
                        dr.Cells["checked"].Value = true;
                    }
                    else
                    {
                        dr.Cells["checked"].Value = false;
                    }
                }
            }
            catch { }
        }

        //getInfo
    }
}