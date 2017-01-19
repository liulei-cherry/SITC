using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FileOperationBase.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using StorageManage.Services;
using ItemsManage.Services;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;

namespace StorageManage.Viewer
{
    public partial class FrmSpareInShipInfo : CommonViewer.BaseForm.FormBase
    {
        string spareid = "";
        string shipid = "";
        public FrmSpareInShipInfo(string shipid,string spareid)
        {
            InitializeComponent();
            this.shipid = shipid;
            this.spareid = spareid;
        }

        private void FrmSpareInShipInfo_Load(object sender, EventArgs e)
        {
            setBdsStocks();
            SpareInfo spinfo = (SpareInfo)SpareInfoService.Instance.GetOneObjectById(spareid);
         
            txtSpareName.Text = spinfo.SPARE_NAME;
            txtSpareEName.Text = spinfo.SPARE_ENAME;
            txtPartNumber.Text = spinfo.PARTNUMBER;
            txtPartNumberHis1.Text = spinfo.PARTNUMBER_HIS1;
            txtPartNumberHis2.Text = spinfo.PARTNUMBER_HIS2;
            txtPicNumber.Text = spinfo.PICNUMBER;
            txtUnit.Text = spinfo.UNIT_NAME;
            txtPicCode.Text = spinfo.PICCODE;
            txtSpareStuff.Text = spinfo.SPARESTUFF;
            txtAlertStock.Text = spinfo.ALERTSTOCK.ToString ();
            txtRemark.Text = spinfo.REMARK;        
        }
        /// <summary>
        /// 设置库存信息的bindingSource数据源.
        /// </summary>
        private void setBdsStocks()
        {
            DataTable dtbSpareStock = SpareStockService.Instance.GetSpareStockOfShip(shipid, spareid);         
            bdsStock.DataSource = dtbSpareStock;
            dgv.DataSource = bdsStock; 
            dgv.Columns["ship_id"].Visible = false;
            dgv.Columns["ship_name"].Visible = false;
            dgv.Columns["warehouse_id"].Visible = false;
            dgv.Columns["spare_id"].Visible = false; 
            dgv.Columns["isoutstock"].Visible = false;
            dgv.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgv.Columns["spare_name"].Visible = false;
            dgv.Columns["partnumber"].Visible = false;
            dgv.Columns["ALERTSTOCK"].Visible = false;
            dgv.Columns["stocks"].HeaderText = "本库数量";
            dgv.Columns["unit_name"].HeaderText = "计量单位";
            dgv.Columns["outnumb"].HeaderText = "操作数量";
            dgv.Columns["shipallstock"].HeaderText = "全船数量";
            dgv.Columns["warehouse_name"].ReadOnly = true;
            dgv.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["spare_name"].ReadOnly = true;
            dgv.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["partnumber"].ReadOnly = true;
            dgv.Columns["partnumber"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["partnumber"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["ALERTSTOCK"].ReadOnly = true;
            dgv.Columns["ALERTSTOCK"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["ALERTSTOCK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["shipallstock"].ReadOnly = true;
            dgv.Columns["shipallstock"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["shipallstock"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["stocks"].ReadOnly = true;
            dgv.Columns["stocks"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["stocks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["stocks"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["unit_name"].ReadOnly = true;
            dgv.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["unit_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["outnumb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["outnumb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["warehouse_name"].Width = 100;
            dgv.Columns["spare_name"].Width = 200;
            dgv.Columns["partnumber"].Width = 100;
            dgv.Columns["stocks"].Width = 80;
            dgv.Columns["unit_name"].Width = 60;
            dgv.Columns["outnumb"].Width = 80;

            if (dgv.Columns["chkoutstock"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "chkoutstock";
                dgvChkCol.HeaderText = "操作";
                dgvChkCol.ReadOnly = true;
                dgvChkCol.DefaultCellStyle.BackColor = Color.Linen;
                dgvChkCol.DataPropertyName = "isoutstock";
                dgvChkCol.Width = 40;
                dgv.Columns.Insert(dgv.Columns.Count - 1, dgvChkCol);
            }
            dgv.LoadGridView("FrmSpareInShipInfo.dgvSpareStock");
        }

        private void FrmSpareInShipInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgv.SaveGridView("FrmSpareInShipInfo.dgvSpareStock");
        }

        private void tsbtnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            setBdsStocks();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            dgv.EndEdit();
 
            if (this.IsChkNoStockNumb())
            {
                MessageBoxEx.Show("对于要入库的备件必须填写正确的入库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.IsEmpty())
            {
                MessageBoxEx.Show("请选择要入库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgv.IsNumeric("outnumb") == false)
            {
                MessageBoxEx.Show("入库数量必须是数值型数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBoxEx.Show("确认要入库吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            //***************数据保存*****************************************************************************
            bdsStock.EndEdit();
            DataTable dtb = (DataTable)bdsStock.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            DataRow[] outRows = dtb.Select("isoutstock = 1");
            if (SpareDepotOperationService.Instance.SpareIn(outRows, out err))
            {
                this.setBdsStocks();
                MessageBoxEx.Show("成功生成一条入库单，库存已被更新！", "入库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "入库失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            dgv.EndEdit();

            if (this.IsChkNoStockNumb())
            {
                MessageBoxEx.Show("对于要出库的备件必须填写正确的出库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.IsEmpty())
            {
                MessageBoxEx.Show("请选择要出库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgv.IsNumeric("outnumb") == false)
            {
                MessageBoxEx.Show("出库数量必须是数值型数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dgvCellValidating(out err) == false)
            {
                MessageBoxEx.Show(err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBoxEx.Show("确认要出库吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            //***************数据保存*****************************************************************************
            bdsStock.EndEdit();
            DataTable dtb = (DataTable)bdsStock.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            DataRow[] outRows = dtb.Select("isoutstock = 1");
            if (SpareDepotOperationService.Instance.SpareOut(outRows, out err))
            {
                this.setBdsStocks();
                MessageBoxEx.Show("成功生成一条出库单，库存已被更新！", "出库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "出库失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 在保存出库信息时，如果有选择出库标记但未填写出库数量时，则提示。.
        /// </summary>
        /// <returns>如果存在未填写出库数量的现象，返回true，否则返回false</returns>        
        private bool IsChkNoStockNumb()
        {
            bool blResult = false;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    string sOutNumb = dgvRow.Cells["outnumb"].Value.ToString();
                    if (sOutNumb.Equals(""))
                    {
                        blResult = true;
                        break;
                    }
                    float outNumb = float.Parse(sOutNumb);
                    if (outNumb <= 0)
                    {
                        blResult = true;
                        break;
                    }
                }
            }

            return blResult;
        }

        /// <summary>
        /// 检测网格控件中指定的列是否全部是空值。.
        /// </summary>
        /// <returns>如果全部是空值，返回true，否则返回false</returns>        
        private bool IsEmpty()
        {
            bool blResult = true;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    blResult = false;
                    break;
                }
            }

            return blResult;
        }

        /// <summary>
        /// 当备件出库时进行网格校验.
        /// </summary>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool dgvCellValidating(out string err)
        {
            bool blResult = true;
            err = "";

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    float stocks = float.Parse(dgvRow.Cells["stocks"].Value.ToString());    //库存数量.
                    float outnumb = float.Parse(dgvRow.Cells["outnumb"].Value.ToString());  //出库数量.

                    if (stocks == 0)
                    {
                        blResult = false;
                        err = "当前库存数量为0！";
                        break;
                    }

                    if (outnumb < 0)
                    {
                        blResult = false;
                        err = "出库数量不能为负！";
                        break;
                    }

                    if (outnumb > stocks)
                    {
                        blResult = false;
                        err = "出库数量不能大于库存数量！";
                        break;
                    }
                }
            }

            return blResult;
        }
      
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            float flt = 0.0f;
            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgv.Columns[e.ColumnIndex].Name.ToLower();
            //取当前值赋给变量scurValue
            string sCurValue = e.FormattedValue.ToString().Trim();
            //取当前库存数.
            float fltStocks = float.Parse(dgv.CurrentRow.Cells["stocks"].Value.ToString());

            if (sColName.IndexOf("outnumb") >= 0 && sCurValue.Length > 0 && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("出入库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (sColName.IndexOf("outnumb") >= 0 && sCurValue.Length > 0 && float.Parse(sCurValue) < 0)
            {
                MessageBoxEx.Show("出入库数量不能为负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (flt != 0)
            {
                dgv.CurrentRow.Cells["isoutstock"].Value = 1;
            }
            else
            {
                dgv.CurrentRow.Cells["isoutstock"].Value = 0;
            }
        }
    }

}