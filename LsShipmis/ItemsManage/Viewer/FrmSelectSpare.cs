/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSelectSpare.cs
 * 创 建 人：徐正本
 * 创建时间：2007-12-07
 * 标    题：备件信息选择业务窗体
 * 功能描述：实现备件信息选择业务窗体上的相关功能
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.Services;
using CommonViewer;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace ItemsManage.Viewer
{
    public partial class FrmSelectSpare : CommonViewer.BaseForm.FormBase
    {
        private ComponentUnit equipment;
        public bool Selected = false;
        private List<string> spareIds = new List<string>();
        public List<StorageParameter> Spares = new List<StorageParameter>();

        /// <summary>
        /// 备件信息选择业务窗体.
        /// </summary>
        public FrmSelectSpare()
        {
            InitializeComponent();
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                string err;
                equipment = ComponentUnitService.Instance.GetObjectByRootAndShipId(CommonOperation.ConstParameter.ShipId, out err);
            }
            else
            {
                ucEquipmentClassTreeWithEquipment1.OneShipMode = false;
            }
        }
        /// <summary>
        /// 备件信息选择业务窗体.
        /// </summary>
        public FrmSelectSpare(string shipId)
        {
            InitializeComponent();
            string err;
            equipment = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipId, out err);

        }
        public FrmSelectSpare(ComponentUnit equipment)
        {
            InitializeComponent();
            this.equipment = equipment;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectSpare_Load(object sender, EventArgs e)
        {
            if (equipment != null && !equipment.IsWrong)
            {
                string err;
                ShipInfo shipInfo = ShipInfoService.Instance.getObject(equipment.SHIP_ID, out err);
                ucEquipmentClassTreeWithEquipment1.ReloadingShipData(shipInfo);
            }
            else
            {
                ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
            }
            ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(equipment);
        }

        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            if (objectType == 2)
            {
                equipment = (ComponentUnit)theObject;
                loadSpares();
            }
        }

        private void ucEquipmentClassTreeWithEquipment1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageKey == "equipwithpic") openSelectSpareFrm();
        }

        private void loadSpares()
        {
            if (equipment == null || equipment.IsWrong) return;

            //取当前设备型号下的备件信息（这个信息用叶子节点表示）.
            DataTable dtbTreeDataSpCompTypeBd = SpareInfoService.Instance.GetSpareByComponentType(equipment.COMPONENT_TYPE_ID, equipment.SHIP_ID);

            if (dtbTreeDataSpCompTypeBd.Rows.Count > 0)
            {
                //调用commonOpt类的FillTreeNode方法加载当前设备型号下的备件信息.
                for (int i = 0; i < dtbTreeDataSpCompTypeBd.Rows.Count; )
                {
                    if (spareIds.Contains(dtbTreeDataSpCompTypeBd.Rows[i]["spare_id"].ToString()))
                    {
                        dtbTreeDataSpCompTypeBd.Rows.Remove(dtbTreeDataSpCompTypeBd.Rows[i]);
                    }
                    else i++;
                }
            }
            bindingSource1.DataSource = dtbTreeDataSpCompTypeBd;
            ucDataGridView1.DataSource = bindingSource1;
            this.setDataGridViewDetail();
        }

        private void setDataGridViewDetail()
        {
            //给ucDataGridView1加一个选择列.

            if (ucDataGridView1.Columns["sel"] == null)//如果列已经存在，则不能重复添加.
            {
                ucDataGridView1.LoadGridView("FrmSelectSpare.ucDataGridView1");
                ucDataGridView1.Columns["spare_id"].Visible = false;
                ucDataGridView1.Columns["spare_ename"].Visible = false;
                ucDataGridView1.Columns["ATTACHTYPE"].Visible = false;
                ucDataGridView1.Columns["ATTACHCOMP"].Visible = false;
                ucDataGridView1.Columns["ISSPECIALSP"].Visible = false;
                ucDataGridView1.Columns["sparestuff"].Visible = false;
                ucDataGridView1.Columns["alertstock"].Visible = false;
                ucDataGridView1.Columns["creator"].Visible = false;
                ucDataGridView1.Columns["comptypespareid"].Visible = false;
                ucDataGridView1.Columns["makeupNumber"].Visible = false;
                ucDataGridView1.Columns["ISSPECIALSP"].Visible = false;
                ucDataGridView1.Columns["creator"].Visible = false;
                //ucDataGridView1.Columns["isspecialsp1"].Visible = false;

                ucDataGridView1.Columns["isspecialsp_name"].HeaderText = "特殊备件";
                ucDataGridView1.Columns["spare_name"].HeaderText = "备件名称";
                ucDataGridView1.Columns["unit_name"].HeaderText = "单位";
                ucDataGridView1.Columns["partnumber"].HeaderText = "配件号|规格";
                ucDataGridView1.Columns["stocksall"].HeaderText = "库存数量";
                ucDataGridView1.Columns["partnumber_his1"].HeaderText = "历史备件号1";
                ucDataGridView1.Columns["partnumber_his2"].HeaderText = "历史备件号2";
                ucDataGridView1.Columns["picnumber"].HeaderText = "图号";
                ucDataGridView1.Columns["piccode"].HeaderText = "在图编号";
                ucDataGridView1.Columns["remark"].HeaderText = "备注";
                ucDataGridView1.Columns["spare_name"].Width = 150;
                ucDataGridView1.Columns["partnumber"].Width = 120;
                ucDataGridView1.Columns["stocksall"].Width = 70;
                ucDataGridView1.Columns["partnumber_his1"].Width = 120;
                ucDataGridView1.Columns["partnumber_his2"].Width = 120;
                ucDataGridView1.Columns["remark"].Width = 200;
                DataGridViewCheckBoxColumn dgvCheckBoxCol = new DataGridViewCheckBoxColumn();
                dgvCheckBoxCol.Name = "sel";
                dgvCheckBoxCol.HeaderText = "";
                dgvCheckBoxCol.Width = 25;
                ucDataGridView1.Columns.Insert(0, dgvCheckBoxCol);

            }
            string[] sCols = new string[] { "spare_name", "partnumber", "stocksall", "partnumber_his1", "partnumber_his2", "picnumber", "piccode", "remark", "isspecialsp", "isspecialsp_name" };
            ucDataGridView1.setDgvCellReadOnly("spare_id", sCols);

        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Selected = false;
            this.Close();
        }

        private void openSelectSpareFrm()
        {
            if (equipment == null || equipment.IsWrong)
            {
                MessageBoxEx.Show("未选择任何设备，不能进行备件的选择！", "警告提示");
                return;
            }
            FrmSparePreview frm = new FrmSparePreview(equipment.COMPONENT_TYPE_ID);
            frm.needSpare = GetSomeSpares;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openSelectSpareFrm();
        }

        public void GetSomeSpares(List<StorageParameter> newSpares)
        {
            //调用commonOpt类的FillTreeNode方法加载当前设备型号下的备件信息.
            foreach (StorageParameter tempSpare in newSpares)
            {
                if (!spareIds.Contains(tempSpare.ItemId))
                {
                    spareIds.Add(tempSpare.ItemId);
                    StorageParameter oneSpare = new StorageParameter();
                    oneSpare.ItemId = tempSpare.ItemId;
                    Spares.Add(oneSpare); 
                    DataTable dt = SpareInfoService.Instance.GetSpareInfoAndStock(tempSpare.ItemId, equipment.SHIP_ID);
                    int newRowCount = dataGridView1.Rows.Add();
                    dataGridView1.Rows[newRowCount].Cells[0].Value = true;
                    dataGridView1.Rows[newRowCount].Cells[1].Value = tempSpare.ItemId;
                    dataGridView1.Rows[newRowCount].Cells[2].Value = dt.Rows[0]["SPARE_NAME"].ToString();
                    dataGridView1.Rows[newRowCount].Cells[3].Value = dt.Rows[0]["PARTNUMBER"].ToString();
                    dataGridView1.Rows[newRowCount].Cells[4].Value = dt.Rows[0]["UNIT_NAME"].ToString();
                    dataGridView1.Rows[newRowCount].Cells[5].Value = dt.Rows[0]["STOCKSAll"];
                    dataGridView1.Rows[newRowCount].Cells[6].Value = dt.Rows[0]["PARTNUMBER_HIS1"].ToString();
                    dataGridView1.Rows[newRowCount].Cells[7].Value = dt.Rows[0]["PARTNUMBER_HIS2"].ToString();
                    dataGridView1.Rows[newRowCount].Cells[8].Value = dt.Rows[0]["REMARK"].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selected = true;
            Spares.Clear();
            spareIds.Clear();
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells[0].Value.ToString().ToLower() == "true")
                {
                    string tempId = dgvr.Cells[1].Value.ToString();
                    spareIds.Add(tempId);
                    StorageParameter oneSpare = new StorageParameter();
                    oneSpare.ItemId = tempId;
                    oneSpare.unit_name = dgvr.Cells["unit_name"].Value.ToString();
                    if (dgvr.Cells["stocksall"].Value != DBNull.Value)
                        oneSpare.stocksall = Convert.ToDecimal(dgvr.Cells["stocksall"].Value);
                    else
                        oneSpare.stocksall = 0;
                    Spares.Add(oneSpare);
                }
            }
            this.Close();
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in ucDataGridView1.Rows)
            {
                dgvr.Cells[0].Value = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in ucDataGridView1.Rows)
            {
                dgvr.Cells[0].Value = false;
            }
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in ucDataGridView1.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.ToString().ToLower() == "true")
                {
                    //如果spareid已经存在，则不添加.

                    string newSpareId = dgvr.Cells["spare_id"].Value.ToString();
                    if (spareIds.Contains(newSpareId)) continue;
                    int newRowCount = dataGridView1.Rows.Add();
                    spareIds.Add(newSpareId);
                    StorageParameter oneSpare = new StorageParameter();
                    oneSpare.ItemId = newSpareId;
                    Spares.Add(oneSpare);
                    dataGridView1.Rows[newRowCount].Cells[0].Value = true;
                    dataGridView1.Rows[newRowCount].Cells[1].Value = newSpareId;
                    dataGridView1.Rows[newRowCount].Cells[2].Value = dgvr.Cells["spare_name"].Value;
                    dataGridView1.Rows[newRowCount].Cells[3].Value = dgvr.Cells["PARTNUMBER"].Value;
                    dataGridView1.Rows[newRowCount].Cells[4].Value = dgvr.Cells["unit_name"].Value;
                    dataGridView1.Rows[newRowCount].Cells[5].Value = dgvr.Cells["STOCKSAll"].Value;
                    dataGridView1.Rows[newRowCount].Cells[6].Value = dgvr.Cells["PARTNUMBER_HIS1"].Value;
                    dataGridView1.Rows[newRowCount].Cells[7].Value = dgvr.Cells["PARTNUMBER_HIS2"].Value;
                    dataGridView1.Rows[newRowCount].Cells[8].Value = dgvr.Cells["REMARK"].Value;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                string theFilterString = textBox1.Text.Trim().Replace("'", "''");
                bindingSource1.Filter = "SPARE_NAME like '%" + theFilterString + "%' or SPARE_ENAME like '%" + theFilterString
                    + "%' or PARTNUMBER like '%" + theFilterString + "%' or PARTNUMBER_HIS1 like '%"
                    + theFilterString + "%'" + " or PARTNUMBER_HIS2 like '%" + theFilterString
                    + "%'or piccode like '%" + theFilterString + "%' or picnumber like '%" + theFilterString + "%'";
            }
            else bindingSource1.Filter = null;
            //调用函数设置物料名称与配件号是否可编辑，引用的物料不可编辑，手工添加的物料可编辑。.

            string[] sCols = new string[] { "spare_name", "partnumber", "stocksall", "partnumber_his1", "partnumber_his2", "picnumber", "piccode", "remark" };
            ucDataGridView1.setDgvCellReadOnly("spare_id", sCols);
        }

        private void btnClearall_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            spareIds.Clear();
            Spares.Clear();
        }

        private void buttonEx7_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm;
            if (equipment != null && string.IsNullOrEmpty(equipment.SHIP_ID))
                frm = new FrmSelectComponent(equipment.SHIP_ID);
            else
                frm = new FrmSelectComponent();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(frm.Equipment);
            }
        }

        private void FrmSelectSpare_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmSelectSpare.ucDataGridView1");
        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;

            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower() == "true")
                {
                    string tempid = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (spareIds.Contains(tempid))
                    {
                        spareIds.Remove(tempid);
                        foreach (StorageParameter sp in Spares)
                        {
                            if (sp.ItemId.Equals(tempid))
                            {
                                Spares.Remove(sp);
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }

    }
}