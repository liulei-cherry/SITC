/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMaterialOutEdit.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-4
 * 标    题：物资出库业务窗体
 * 功能描述：实现物资出库业务窗体上的相关功能
 *          本页面有三个情况下使用，一是直接出库单填写时编辑，二是通过其他界面点击出库，传入出库物资id集合出库，三新增出库单
 * 修 改 人：徐正本
 * 修改时间：2011-8-3
 * 修改内容：将业务增加审核流程,根据配置项
 * StorageConfig.StorageChangeNeedShipCheck 及 StorageChangeNeedLandCheck 是否需要审核,再配合
 * 当前是船端还是岸端,将审核流程实现到具体界面中,同时也修改了后台的存储表,使用最新的出出库用同一套表的方案.
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using StorageManage.DataObject;
using StorageManage.Services;
using CommonOperation.Interfaces;
using ItemsManage.DataObject;
using ItemsManage.Services;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using ItemsManage.Viewer;
using CommonViewer.BaseControl;
using ItemsManage;

namespace StorageManage.Viewer
{
    /// <summary>
    /// 物资出库业务窗体.
    /// </summary>
    public partial class FrmMaterialOutEdit : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private List<StorageParameter> lstMaterials = null;    //接收调用方传过来的要出库的物资的List集合（由设备维护保养系统调用）.
        private string remark = "";                 //接收调用方传过来的要出库的备注信息（由设备维护保养系统调用）.

        private MaterialDepotOperation theMaterialOut = new MaterialDepotOperation();
        private int mainFunction = 1;
        private bool isComplete = false;
        string shipId = "";
        //            1 新出库.
        //*           2 别处选择物资，调用添加申请单、.
        //*           3 修改申请单.
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMaterialOutEdit()
        {
            InitializeComponent();
            shipId = CommonOperation.ConstParameter.ShipId;
        } 

        public FrmMaterialOutEdit(string MaterialOutId)
        {
            mainFunction = 3;
            InitializeComponent();
            string err;
            theMaterialOut = MaterialDepotOperationService.Instance.getObject(MaterialOutId, out err);
            shipId = theMaterialOut.SHIP_ID;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialOutEdit_Load(object sender, EventArgs e)
        {
            ucDepartmentSelect1.ChangeMode(2, true);
            bindingData();
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            if (mainFunction == 2)
            {
                setBindingSourceDetail("");
                InsertMaterialsToGridView(lstMaterials, 0, false);
            }
            else
            {
                //加载子记录.
                setBindingSourceDetail(theMaterialOut.GetId());
            }
            //审核和提交审核的显示状态. 
            //仅需要审核,而且当前内容是未审核状态,而且当前人员不是部门长时,才能看到提交审核按钮.
            if (theMaterialOut != null && (theMaterialOut.STATE == 1 || theMaterialOut.STATE == 3)
                && (StorageConfig.StorageChangeNeedLandCheck || StorageConfig.StorageChangeNeedShipCheck)
                && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.IsLandVersion)
            {
                bdNgComplete.Visible = false;
                bdCommit.Visible = true;
                btnReject.Visible = false;
            }
            else
            {
                bdNgComplete.Visible = true;
                btnReject.Visible = (theMaterialOut != null && theMaterialOut.STATE > 1);
                bdCommit.Visible = false;
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;

        }

        /// <summary>
        /// 从指定的位置往下连续加入几行物资申请信息.
        /// </summary> 
        /// <param name="materialids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertMaterialsToGridView(List<StorageParameter> materialids, int index, bool replaceRow)
        {
            #region 参数判断部分
            if (materialids.Count == 0)
            {
                MessageBoxEx.Show("添加物资出库条目信息时，传入的物资条目为0！", "错误提示");
                return;
            }
            if (index < 0) index = 0;
            if (index > dgvSpOutDetail.Rows.Count) index = dgvSpOutDetail.Rows.Count;
            if (replaceRow && dgvSpOutDetail.Rows.Count - 1 < index)
            {
                throw new Exception("添加物资出库条目信息时，替代已有行时,index参数并不实际存在！");
            }
            #endregion
            string err;
            //从指定行开始加.
            bool theFirstRow = replaceRow;
            bool hasReplitRow = false;
            foreach (StorageParameter materialTemp in materialids)
            {
                decimal dCount = (materialTemp.Count > 0 ? materialTemp.Count : 1);
                string materialId = materialTemp.ItemId;

                if (dgvSpOutDetail.HasValue("material_Id", materialId))
                {
                    hasReplitRow = true;
                    continue;
                }
                MaterialInfo material = MaterialInfoService.Instance.getObject(materialId, out err);
                if (theFirstRow)
                {
                    theFirstRow = false;
                }
                else
                {
                    bindingSourceDetail.AddNew();//执行添加记录功能.
                    //为som_in_detail_id列添加一个新的全球码号.
                    dgvSpOutDetail.CurrentRow.Cells["MaterialOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
                    dgvSpOutDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值出库单信息主键值.
                    dgvSpOutDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
                }
                //如果当前物资有指定库存，则用指定库，如果没有则拷贝上一行的.
                dgvSpOutDetail.CurrentRow.Cells["material_id"].Value = materialId;//物资Id
                dgvSpOutDetail.CurrentRow.Cells["MATERIAL_CODE"].Value = material.MATERIAL_CODE;//物资编码.
                dgvSpOutDetail.CurrentRow.Cells["material_name"].Value = material.MATERIAL_NAME;//物资名称.
                dgvSpOutDetail.CurrentRow.Cells["MATERIAL_SPEC"].Value = material.MATERIAL_SPEC;//规格型号.
                dgvSpOutDetail.CurrentRow.Cells["COUNT"].Value = dCount;
                string warehouseId, wareHouseName;
                dgvSpOutDetail.CurrentRow.Cells["unit_name"].Value = material.UNIT_NAME;//计量单位名称.
                MaterialStockService.Instance.GetMaterialWarehouseInfo(materialId, shipId, out warehouseId, out wareHouseName, out err);

                dgvSpOutDetail.CurrentRow.Cells["warehouse_id"].Value = warehouseId;    //取得当前物资的默认仓库Id（有库存的仓库）.
                dgvSpOutDetail.CurrentRow.Cells["type_code"].Value = "消耗";
                dgvSpOutDetail.CurrentRow.Cells["remark"].Value = material.REMARK;
                if (string.IsNullOrEmpty(dgvSpOutDetail.CurrentRow.Cells["warehouse_id"].Value.ToString()))
                {
                    if (dgvSpOutDetail.CurrentRow.Index > 0)
                    {
                        dgvSpOutDetail.CurrentRow.Cells["warehouse_id"].Value = dgvSpOutDetail.Rows[dgvSpOutDetail.CurrentRow.Index - 1].Cells["warehouse_id"].Value;
                        dgvSpOutDetail.CurrentRow.Cells["warehouse_name"].Value = dgvSpOutDetail.Rows[dgvSpOutDetail.CurrentRow.Index - 1].Cells["warehouse_name"].Value;
                    }
                }
                else
                {
                    dgvSpOutDetail.CurrentRow.Cells["warehouse_name"].Value = wareHouseName;//取得当前物资的默认仓库名称（有库存的仓库）.
                    dgvSpOutDetail.CurrentRow.Cells["stocksum"].Value = MaterialStockService.Instance.GetMaterialStock(shipId, materialId);
                    dgvSpOutDetail.CurrentRow.Cells["remark"].Value = material.REMARK;
                }
            }

            if (hasReplitRow)
            {
                MessageBoxEx.Show("同一物资出库记录不能重复，只能填一条数据,刚刚选择了已经存在的记录，被自动过滤！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            saveDetails(out err);
        }

        private bool updateObjectFromForm()
        {
            if (theMaterialOut == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            theMaterialOut.OPERATION_DATE = dtpInDate.Value;
            theMaterialOut.DEPART_ID = ucDepartmentSelect1.GetId();
            theMaterialOut.ISCOMPLETE = isComplete ? 1 : 0;
            if (theMaterialOut.STATE == 4) theMaterialOut.CHECKDATE = DateTime.Today;
            theMaterialOut.LANDCHECKER = txtLandChecker.Text;
            theMaterialOut.SHIPCHECKER = txtShipChecker.Text;
            theMaterialOut.OPERATION_PERSON = txtInMan.Text;
            theMaterialOut.REMARK = txtRemark.Text;

            if (string.IsNullOrEmpty(theMaterialOut.DEPART_ID))
            {
                MessageBoxEx.Show("部门是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 绑定窗体控件（申请单信息控件的绑定）.
        /// </summary>
        private void bindingData()
        {
            string err;
            //如果是包含子记录的,说明是需要形成记录的，其他都是已经有记录的.
            if (mainFunction != 3)
            {
                theMaterialOut.SHIP_ID = shipId;
                theMaterialOut.OPERATION_DATE = DateTime.Today;
                theMaterialOut.OPERATION_PERSON = CommonOperation.ConstParameter.UserName;
                theMaterialOut.OPERATION_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;//这里用登录者的岗位，必须使用它，在过滤的时候用到了！.
                theMaterialOut.DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
                theMaterialOut.ISCOMPLETE = 0;
                theMaterialOut.STATE = 1;
                theMaterialOut.IN_OR_OUT = 2;
                theMaterialOut.REMARK = remark;
                theMaterialOut.Update(out err);
                txtInMan.Tag = theMaterialOut.GetId();
            }
            showDataToForm();
        }

        private void showDataToForm()
        {
            if (theMaterialOut == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            dtpInDate.Value = theMaterialOut.OPERATION_DATE;
            ucDepartmentSelect1.SelectedId(theMaterialOut.DEPART_ID);
            txtInMan.Text = theMaterialOut.OPERATION_PERSON;
            txtInMan.Tag = theMaterialOut.GetId();
            txtShipChecker.Text = theMaterialOut.SHIPCHECKER;
            txtLandChecker.Text = theMaterialOut.LANDCHECKER;
            txtRemark.Text = theMaterialOut.REMARK;
            isComplete = theMaterialOut.ISCOMPLETE == 1 ? true : false;

        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err;
            //把仓库名称下拉列表绑定到网格控件dgvSpOutDetail上.
            DataTable dtbWareHouse = ShipWareHouseService.Instance.getInfoByShipId(shipId, out err);
            cboWareHouse.DataSource = dtbWareHouse;
            cboWareHouse.DisplayMember = "warehouse_name";
            cboWareHouse.ValueMember = "warehouse_id";

            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
                dgvBindDrop1.bindDropToDgv(dgvSpOutDetail, cboWareHouse, 8, false, 1);
            }
            //把出库方式下拉列表绑定到网格控件dgvSpOutDetail上.
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvSpOutDetail, cboInTypeCode, 13, false, 2);
        }

        /// <summary>
        /// 设置物资出库单明细信息的bindingSource数据源，每次查询的都是指定出库单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="MaterialOutId">出库单信息Id</param>
        private void setBindingSourceDetail(string MaterialOutId)
        {
            DataTable dtbMaterialOutDetail = MaterialDepotOperationService.Instance.GetMaterialOutDetail(MaterialOutId);//取得物资出库单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbMaterialOutDetail;//物资出库明细信息的数据源设置.
            dgvSpOutDetail.DataSource = bindingSourceDetail;
            dgvSpOutDetail.LoadGridView("FrmMaterialOutEdit.dgvSpOutDetail");
            dgvSpOutDetail.Columns["MaterialOPERDETAIL_ID"].Visible = false;
            dgvSpOutDetail.Columns["DEPOTOPERID"].Visible = false;
            dgvSpOutDetail.Columns["material_Id"].Visible = false;
            dgvSpOutDetail.Columns["warehouse_id"].Visible = false;
            dgvSpOutDetail.Columns["ship_id"].Visible = false;
            dgvSpOutDetail.Columns["material_CODE"].HeaderText = "物资编码";
            dgvSpOutDetail.Columns["ISSAP"].HeaderText = "物料类型";
            dgvSpOutDetail.Columns["material_name"].HeaderText = "物资名称";
            dgvSpOutDetail.Columns["material_SPEC"].HeaderText = "规格型号";
            dgvSpOutDetail.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpOutDetail.Columns["stocksum"].HeaderText = "库存数量";
            dgvSpOutDetail.Columns["stocksum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpOutDetail.Columns["COUNT"].HeaderText = "出库数量";
            dgvSpOutDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpOutDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpOutDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpOutDetail.Columns["type_code"].HeaderText = "出库方式";
            dgvSpOutDetail.Columns["remark"].HeaderText = "备注";
            dgvSpOutDetail.Columns["material_CODE"].ReadOnly = true;
            dgvSpOutDetail.Columns["material_CODE"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["material_name"].ReadOnly = true;
            dgvSpOutDetail.Columns["material_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["material_SPEC"].ReadOnly = true;
            dgvSpOutDetail.Columns["material_SPEC"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["warehouse_name"].ReadOnly = true;
            dgvSpOutDetail.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["stocksum"].ReadOnly = true;
            dgvSpOutDetail.Columns["stocksum"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["unit_name"].ReadOnly = true;
            dgvSpOutDetail.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.Columns["type_code"].ReadOnly = true;
            dgvSpOutDetail.Columns["type_code"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpOutDetail.SetDataGridViewNoSort();

            //给dgvSpApplyDetail加一个列按钮列用于打开弹出对话框选择物资信息.
            if (dgvSpOutDetail.Columns["selMaterial"] == null)//如果按钮列已经存在，则不能重复添加.
            {
                DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                dgvBtnCol.Name = "selMaterial";
                dgvBtnCol.HeaderText = "";
                dgvBtnCol.UseColumnTextForButtonValue = true;
                dgvBtnCol.Text = "…";
                dgvBtnCol.Width = 25;
                dgvSpOutDetail.Columns.Insert(4, dgvBtnCol);
            }
            else dgvSpOutDetail.Columns["selMaterial"].DisplayIndex = 4;
            //调用函数设置物资名称与规格型号是否可编辑，引用的物资不可编辑，手工添加的物资可编辑。.
            string[] sCols = new string[] { "material_name", "material_code", "material_spec" };
            dgvSpOutDetail.setDgvCellReadOnly("material_id", sCols);
        }

        #region 明细数据添加维护的操作


        /// <summary>
        /// 单击选择按钮打开物资弹出框窗体选择物资的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpOutDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSpOutDetail.Columns[e.ColumnIndex].Name == "selMaterial")
            {
                FrmSelectMaterial frm = new FrmSelectMaterial();
                frm.ShowDialog();

                if (frm.Selected && frm.Materials.Count > 0)
                {
                    InsertMaterialsToGridView(frm.Materials, e.RowIndex, true);
                }
            }
        }

        /// <summary>
        /// 当仓库变换内容时显示指定仓库的库存数量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            string wareHouseId = "";//当前仓库Id
            string wareHousename = "";//当前仓库Id
            string materialId = "";    //当前物资Id

            if (dgvSpOutDetail.CurrentRow != null)
            {
                wareHouseId = cboWareHouse.SelectedValue.ToString();
                wareHousename = cboWareHouse.Text;
                materialId = dgvSpOutDetail.CurrentRow.Cells["material_id"].Value.ToString();
                dgvSpOutDetail.CurrentRow.Cells["stocksum"].Value = MaterialStockService.Instance.GetMaterialStock(shipId, materialId);

                //如果当前存在未填写的仓库，则输入内容后，其他未填写的均变成此仓库.

                for (int i = 0; i < dgvSpOutDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpOutDetail.Rows[i].Cells["warehouse_id"].Value.ToString()))
                    {
                        dgvSpOutDetail.Rows[i].Cells["warehouse_id"].Value = wareHouseId;
                        dgvSpOutDetail.Rows[i].Cells["warehouse_name"].Value = wareHousename;
                    }
                }
            }
        }

        private void cboCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            string CURRENCYID = "";//当前仓库Id
            string CURRENCYCODE = "";//当前仓库Id 
            if (dgvSpOutDetail.CurrentRow != null)
            {
                CURRENCYID = cboWareHouse.SelectedValue.ToString();
                CURRENCYCODE = cboWareHouse.Text;

                for (int i = 0; i < dgvSpOutDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpOutDetail.Rows[i].Cells["CURRENCYID"].Value.ToString()))
                    {
                        dgvSpOutDetail.Rows[i].Cells["CURRENCYID"].Value = CURRENCYID;
                        dgvSpOutDetail.Rows[i].Cells["CURRENCYCODE"].Value = CURRENCYCODE;
                    }
                }
            }
        }

        private void cboInTypeCode_SelectedValueChanged(object sender, EventArgs e)
        {
            string inTypeCode = cboInTypeCode.Text;
            if (dgvSpOutDetail.CurrentRow != null)
            {
                for (int i = 0; i < dgvSpOutDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpOutDetail.Rows[i].Cells["type_code"].Value.ToString()))
                    {
                        dgvSpOutDetail.Rows[i].Cells["type_code"].Value = inTypeCode;
                    }
                }
            }
        }
        #endregion

        #region 物资出库单明细网格校验部分


        private void dgvSpOutDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            float flt = 0.0f;
            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgvSpOutDetail.Columns[e.ColumnIndex].Name.ToLower();
            //取当前值赋给变量scurValue
            string sCurValue = e.FormattedValue.ToString().Trim();

            if (sColName.Equals("COUNT") && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("出库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("COUNT") && float.Parse(sCurValue) <= 0)
            {
                MessageBoxEx.Show("出库数量不能为0或负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// 明细数据保存时的校验函数.
        /// </summary>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool validateDet()
        {
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("出库部门是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpOutDetail.HasEmptyVal("material_name") == true)
            {
                MessageBoxEx.Show("物资名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpOutDetail.HasEmptyVal("warehouse_id") == true)
            {
                MessageBoxEx.Show("仓库名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpOutDetail.HasEmptyVal("stocksum") == true)
            {
                MessageBoxEx.Show("当前库存量为空时无法出库！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpOutDetail.HasEmptyVal("COUNT") == true)
            {
                MessageBoxEx.Show("出库数量是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpOutDetail.IsNumeric("COUNT") == false)
            {
                MessageBoxEx.Show("出库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dgvSpOutDetail.HasEmptyVal("type_code") == true)
            {
                MessageBoxEx.Show("出库方式是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool ifSTOCKCANBELOWZERO = false;
            if (CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("STOCKCANBELOWZERO"))
            {
                if (CommonOperation.ConstParameter.ArgumentSetCollection["STOCKCANBELOWZERO"] == "1")
                    ifSTOCKCANBELOWZERO = true;
            }
            if (!ifSTOCKCANBELOWZERO)
            {
                foreach (DataGridViewRow dgvr in dgvSpOutDetail.Rows)
                {
                    if (decimal.Parse(dgvr.Cells["stocksum"].Value.ToString()) < decimal.Parse(dgvr.Cells["COUNT"].Value.ToString()))
                    {
                        MessageBoxEx.Show("出库数量不能大于库存数量！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 按钮的操作

        /// <summary>
        /// 物资出库明细信息添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shipId = theMaterialOut.SHIP_ID;

            //新添加一条记录后把物资名称列变为当前单元格（注意：这正是设置当前活动单元格的方式）.
            if (dgvSpOutDetail.CurrentCell != null)
            {
                dgvSpOutDetail.CurrentCell = dgvSpOutDetail.CurrentRow.Cells["material_name"];
            }

            bindingSourceDetail.AddNew();//执行添加记录功能.
            //为som_in_detail_id列添加一个新的全球码号.
            dgvSpOutDetail.CurrentRow.Cells["MaterialOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
            dgvSpOutDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值出库单信息主键值.
            dgvSpOutDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
            dgvSpOutDetail.CurrentRow.Cells["type_code"].Value = "消耗";
        }

        /// <summary>
        /// 物资出库明细信息消耗信息删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (bindingSourceDetail.Current != null)
            {

                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                bindingSourceDetail.RemoveCurrent();
                bindingSourceDetail.EndEdit();
                DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (commonOpt.SaveFormData(dtb, "T_Material_DEPOT_OPERATION_DETAIL", 0, out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 物资出库信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            //isComplete = false;
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return;
            }
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                setBindingSourceDetail(theMaterialOut.GetId());
            }
        }

        /// <summary>
        /// 出库单完成操作（只有完成的出库单才允许审核）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgComplete_Click(object sender, EventArgs e)
        {

            string err = ""; //错误信息参数.
            string somInId = "";        //出库单Id 

            isComplete = true;
            bindingSourceDetail.EndEdit();
            dgvSpOutDetail.EndEdit();
            if (dgvSpOutDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可操作的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            somInId = txtInMan.Tag.ToString(); 
            //岸端,则状态为4,船端则状态为2;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
                theMaterialOut.STATE = 4;
            }
            else
            {
                txtLandChecker.Text = "";
                txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                if (!StorageConfig.StorageChangeNeedLandCheck)
                    theMaterialOut.STATE = 4;
                else
                    theMaterialOut.STATE = 2;
            }
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return;
            }
            if (MessageBoxEx.Show("是否确认当前出库单信息？如果确认请点击【是】否则点击【否】！\r注意，如果确认则不允许再次编辑！", "确认框", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //***************数据操作*****************************************************************************
                //更新结果报告.
                if (saveInfor())
                {
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        //如果需要跟外部接口,则直接调用接口函数处理.
                        if (theMaterialOut.STATE == 4 && StorageConfig.createMessage != null)
                        {
                            DataTable dtb;
                            if (SAPServiceOfSpareAndMaterial.Instance.GetMaterialDepotOutOperationToSAP(theMaterialOut.GetId(), out dtb, out err))
                            {
                                if (dtb.Rows.Count == 0)
                                {
                                    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                    return;
                                }
                                if (StorageConfig.createMessage(theMaterialOut.SHIP_ID, theMaterialOut.OPERATION_DATE, theMaterialOut.CHECKDATE, theMaterialOut.GetId(), dtb, "3", "1", out err))
                                {
                                    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                    return;
                                }
                            }
                            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,需要重新审核,错误信息请参考:\r" + err);
                            theMaterialOut.STATE = 2;
                            if (!theMaterialOut.Update(out err))
                                MessageBoxEx.Show("将变化数据发送给SAP时发生错误回滚数据时出现错误,错误信息请参考:\r" + err);
                            return;
                        }
                    }
                    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        private void bdCommit_Click(object sender, EventArgs e)
        {
            //如果是船端,状态是1的才能进行此按钮的操作,否则,到了部门长或者船长级别,或者岸端审核人员都不应该出现此按钮.
            isComplete = true;
            txtLandChecker.Text = "";
            if (dgvSpOutDetail.Rows.Count > 0)
            {
                if (this.validateDet() == false)
                {
                    return;
                }
                if (saveInfor())
                {
                    if (StorageConfig.StorageChangeNeedShipCheck)
                    {
                        theMaterialOut.STATE = 1;
                    }
                    else
                    {
                        txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                        theMaterialOut.STATE = 2;
                    }
                }
                else return;
            }
            else
            {
                MessageBoxEx.Show("当前出库单不包含任何有效数据,无法提交审核.");
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("操作失败！", "提示");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            //如果是船端,状态是1的才能进行此按钮的操作,否则,到了部门长或者船长级别,或者岸端审核人员都不应该出现此按钮.
            isComplete = true;
            theMaterialOut.STATE = 3;
            if (CommonOperation.ConstParameter.IsLandVersion)
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
            else
                txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
            if (this.validateDet() == false)
            {
                return;
            }
            OurMessageBox messagebox = new OurMessageBox("确定要打回出库操作吗？\r如果确认,请描述打回原因并点击[确定]按钮,否则点击[取消]按钮.",
                  "确认框", theMaterialOut.REMARK + "\r\n" + DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + " 打回");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;
            txtRemark.Text = messagebox.AnswerTxt;
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("操作失败！", "提示");
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool saveInfor()
        {
            string err;
            if (updateObjectFromForm() == false)
            {
                return false;
            }
            if (string.IsNullOrEmpty(theMaterialOut.OPERATION_CODE)) theMaterialOut.OPERATION_CODE = StorageCommonService.Instance.GetSpareAndMaterialInOrOutCode(theMaterialOut.SHIP_ID);
            if (theMaterialOut.Update(out err))
            {
                return saveDetails(out err);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        private bool saveDetails(out string err)
        {
            bindingSourceDetail.EndEdit();
            dgvSpOutDetail.EndEdit();
            err = "";
            if (dgvSpOutDetail.Rows.Count == 0) return true;
            //***************数据保存*****************************************************************************
            DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            return commonOpt.SaveFormData(dtb, "T_Material_DEPOT_OPERATION_DETAIL", 0, out err);//保存数据.
        }

        /// <summary>
        /// 窗体关闭时对网格dgvSpOutDetail的一些必填值进行校验并释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialOutEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string err;
            if (theMaterialOut.ISCOMPLETE == 0 && dgvSpOutDetail.Rows.Count == 0)
            {
                if (MessageBoxEx.Show("没有添加任何出库条目，请确认是否保存当前信息，\r保存请按【是】不保存请按【否】", "提示", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    theMaterialOut.Delete(out err);
                }
            }
            dgvSpOutDetail.SaveGridView("FrmMaterialOutEdit.dgvSpOutDetail");
        }
        #endregion

        private void btnFromStock_Click(object sender, EventArgs e)
        {
            FrmSelectMaterialFromStock frm = FrmSelectMaterialFromStock.Instance;
            frm.ShowDialog();
            if (frm.Selected)
            {
                InsertMaterialsToGridView(frm.Materials, dgvSpOutDetail.Rows.Count, false);
            }
        }

        private void btnFromApply_Click(object sender, EventArgs e)
        {
            //FrmMaterialApplyForSel frm = new FrmMaterialApplyForSel(shipId);
            //frm.ShowDialog();
            //if (frm.Selected)
            //{
            //    InsertMaterialsToGridView(frm.Materials, dgvSpOutDetail.Rows.Count, false);
            //}
        }

    }
}