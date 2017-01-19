using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using BaseInfo.Objects;
using Maintenance.Services;
using CommonViewer.BaseControl;

namespace CMSManage.Viewer
{
    public partial class FrmCMSWorkInfoSelect : FormBase
    {
        string shipId;
        bool multiSelect;
        public List<string> WorkInfoIds = new List<string>();
        private FrmCMSWorkInfoSelect()
        {
            InitializeComponent();
        }
        public FrmCMSWorkInfoSelect(string shipId, bool multiSelect)
        {
            if (string.IsNullOrEmpty(shipId))
            {
                throw new Exception("传入的船舶id无效");
            }
            this.shipId = shipId;
            this.multiSelect = multiSelect;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            WorkInfoIds.Clear();
            ucDataGridView1.SaveGridView("FrmCMSWorkInfoSelect");
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!multiSelect)
            {
                //如果是只选一个,则把当前获取到.
                if (ucDataGridView1.CurrentRow != null)
                {
                    WorkInfoIds.Add(ucDataGridView1.CurrentRow.Cells["WORKINFOID"].Value.ToString());
                }
            }
            else
            {
                //从头找到尾,看有多少个checked!
                for (int i = 0; i < ucDataGridView1.Rows.Count; i++)
                {
                    if(ucDataGridView1.Rows[i].Cells["selected"].Value!=null && ucDataGridView1.Rows[i].Cells["selected"].Value.ToString().ToLower() == "true")
                    {
                        WorkInfoIds.Add(ucDataGridView1.Rows[i].Cells["WORKINFOID"].Value.ToString());
                    }
                }
            }
            if (WorkInfoIds.Count == 0)
            {
                MessageBoxEx.Show("未选中任何记录!");
            }
            else
            {
                ucDataGridView1.SaveGridView("FrmCMSWorkInfoSelect");
                this.Close();
            }
        }

        private void FrmCMSWorkInfoSelect_Load(object sender, EventArgs e)
        {
            string err;
            DataTable dtb;
            if (!CMSCheckingService.Instance.GetAllWorkInfoOfChecking(shipId, out dtb, out err))
            {
                MessageBoxEx.Show("未正常获取到可选择的工作信息项,错误信息为:" + err);
            }
            ucDataGridView1.DataSource = dtb;
            setDataGridView();
        }

        private void setDataGridView()
        {
            ucDataGridView1.LoadGridView("FrmCMSWorkInfoSelect");
            ucDataGridView1.Columns["WORKINFOID"].Visible = false; 
            ucDataGridView1.Columns["WORKINFONAME"].HeaderText = "工作信息名称"; 
            ucDataGridView1.Columns["WORKINFODETAIL"].HeaderText = "工作内容";     
            if (multiSelect && ucDataGridView1.Columns["selected"] == null)//如果按钮列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "selected";
                dgvChkCol.HeaderText = "";
                dgvChkCol.Width = 25;
                ucDataGridView1.Columns.Insert(0, dgvChkCol);
            }
            else if (!multiSelect && ucDataGridView1.Columns["selected"] != null)
            {
                ucDataGridView1.Columns.Remove("selected");
            }
        }
    }
}
