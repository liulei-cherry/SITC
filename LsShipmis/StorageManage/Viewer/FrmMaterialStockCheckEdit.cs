using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManage.DataObject;
using StorageManage.Services;
using CommonViewer.BaseForm;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.Interfaces;
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using CommonViewer.BaseControl;
using ItemsManage;
namespace StorageManage.Viewer
{
    public partial class FrmMaterialStockCheckEdit : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private MaterialDepotCheck theMaterialDepotCheck;
        /// <summary>
        /// 1 新盘点单,注意同一个仓库上一次盘点未完成不能进行盘点,存在出入库记录未审核也不能进行盘点.
        /// 2 修改未提交的盘点单 或 打回的工单由船上修改 不需要建立默认对象,其他与1一致.
        /// 3 被打回的盘点单,或岸端审阅完成的盘点单,等待修改 可以看到理论库存值.
        /// 4 岸端审阅 //只能填写备注,也可以填写明细备注.
        /// 5 船上审核 //可以修改数量,改备注.
        /// 6 岸上审核 //可以修改数量,改备注,如果有必要,将传送给SAP
        /// </summary>
        private int mainFunction = 1;
        string shipId = CommonOperation.ConstParameter.ShipId;//取当前船舶Id

        public FrmMaterialStockCheckEdit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// 传入id的方式调用,只能是2以上的情况.
        /// </summary>
        /// <param name="stockckId"></param>
        /// <param name="functionIn"></param>
        public FrmMaterialStockCheckEdit(string stockckId, int functionIn)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            string sChkMessage = "传入的id无效，无法展示数据";
            if (stockckId.Length == 36)
            {
                theMaterialDepotCheck = MaterialDepotCheckService.Instance.getObject(stockckId, out sChkMessage);
            }
            if (theMaterialDepotCheck == null)
            {
                throw new Exception(sChkMessage);
            }
            shipId = theMaterialDepotCheck.SHIP_ID;
            if (functionIn <= 2) mainFunction = 2;
            else if (functionIn >= 6) mainFunction = 6;
            else mainFunction = functionIn;
        }

        private void FrmMaterialStockckEdit_Load(object sender, EventArgs e)
        {
            this.bindingData();

            if (mainFunction != 1)
            {
                this.setBindingSourceDetail(theMaterialDepotCheck.GetId());
            }
            else
            {
                ucShipWareHouseSelect1.ChangeMode(shipId, false);
                this.setBindingSourceDetail("");

            }
            this.WindowState = FormWindowState.Normal;
            setButtonsAndControls();
        }

        private void setButtonsAndControls()
        {
            Btn_Produce.Visible = (mainFunction == 1);
            //修改的按钮谁都可以看，但审核的时候不能用仅保存，只能一次完成.
            bdNgSaveItem.Visible = (mainFunction <= 3);
            bdNgComplete.Visible = (mainFunction <= 3);
            btnQuestion.Visible = (mainFunction > 2);
            //应该正确显示审核按钮，用下面3句控制.
            btn_Ok.Visible = (mainFunction > 3);
            //审阅时只需要看到同意.
            btn_NotOk.Visible = (mainFunction > 4);
        }

        /// <summary>
        /// 绑定窗体控件（申请单信息控件的绑定）.
        /// </summary>
        private void bindingData()
        {
            //如果是包含子记录的，要把主记录和子记录都加上，否则只需要主记录.
            if (mainFunction == 1)
            {
                string wareHouseId = ucShipWareHouseSelect1.GetId();
                theMaterialDepotCheck = new MaterialDepotCheck();
                theMaterialDepotCheck.CHECK_DATE = DateTime.Today;
                theMaterialDepotCheck.CHECK_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;//这里用登录者的岗位，必须使用它，在过滤的时候用到了！.
                theMaterialDepotCheck.SHIP_ID = shipId;
                theMaterialDepotCheck.DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
                theMaterialDepotCheck.CHECK_PERSON = CommonOperation.ConstParameter.UserName;
                theMaterialDepotCheck.ISCOMPLETE = 0;

                //徐正本 2013-8-23 根据配置项调节默认状态
                theMaterialDepotCheck.STATE = (StorageConfig.StorageStorageCheckNeedLandView?1:3);
            }
            showDataToForm();
        }

        private void showDataToForm()
        {
            if (theMaterialDepotCheck == null)
            {
                throw new Exception("错误，不应该出现无法识别盘点单信息的情况!");
            }
            txtStockChecker.Text = theMaterialDepotCheck.CHECK_PERSON;
            if (theMaterialDepotCheck.CHECK_DATE != DateTime.MinValue)
                dtpSpckDate.Value = theMaterialDepotCheck.CHECK_DATE;
            txtCode.Text = theMaterialDepotCheck.CHECK_CODE;
            txtRemark.Text = theMaterialDepotCheck.REMARK;
            ucShipWareHouseSelect1.SelectedId(theMaterialDepotCheck.WAREHOUSE_ID);
            txtShipChecker.Text = theMaterialDepotCheck.SHIPCHECKER;
            txtLandChecker.Text = theMaterialDepotCheck.LANDCHECKER;
            if (theMaterialDepotCheck.CHECKDATE <= DateTime.MinValue || theMaterialDepotCheck.CHECKDATE >= DateTime.MinValue)
                txtCheckDate.Text = "";
            else
                txtCheckDate.Value = theMaterialDepotCheck.CHECKDATE;
            //根据不同状态控制单元格的可编辑情况.
            ucShipWareHouseSelect1.Enabled = (mainFunction == 1);

        }

        /// <summary>
        /// 设置物资盘存单明细信息的bindingSource数据源，每次查询的都是指定盘存单的明细信息数据.
        /// </summary>
        /// <param name="stockckId">盘存单信息Id</param>
        private void setBindingSourceDetail(string stockckId)
        {
            DataTable dtbMaterialStockckDetail = MaterialDepotCheckService.Instance.GetMaterialStockckDetail(stockckId);//取得物资盘存单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbMaterialStockckDetail;//物资盘点明细信息的数据源设置.
            dgvSpStockckDetail.DataSource = bindingSourceDetail;
            this.setDataGridViewDetail();
        }

        /// <summary>
        /// 设物资盘点明细信息网格控件dgvSpStockckDetail的隐藏列与显示标题.
        /// </summary>
        private void setDataGridViewDetail()
        {
            dgvSpStockckDetail.LoadGridView("FrmMaterialStockCheckEdit.dgvSpStockckDetail");
            dgvSpStockckDetail.Columns["MaterialCHECKDETAIL_ID"].Visible = false;
            dgvSpStockckDetail.Columns["DEPOTCHECKID"].Visible = false;
            dgvSpStockckDetail.Columns["material_Id"].Visible = false;
            dgvSpStockckDetail.Columns["ship_id"].Visible = false;
            dgvSpStockckDetail.Columns["WAREHOUSE_ID"].Visible = false;
            dgvSpStockckDetail.Columns["ISSAP"].HeaderText = "物料类型";
            dgvSpStockckDetail.Columns["material_code"].HeaderText = "物资编码";
            dgvSpStockckDetail.Columns["material_name"].HeaderText = "物资名称";
            dgvSpStockckDetail.Columns["material_spec"].HeaderText = "规格型号";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].HeaderText = "帐面数量";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].HeaderText = "实存数量";
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["COUNT"].HeaderText = "盈亏数量";
            dgvSpStockckDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpStockckDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpStockckDetail.Columns["remark"].HeaderText = "盈亏原因";
            dgvSpStockckDetail.Columns["material_code"].ReadOnly = true;
            dgvSpStockckDetail.Columns["ISSAP"].ReadOnly = true;
            dgvSpStockckDetail.Columns["ISSAP"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["material_code"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["material_name"].ReadOnly = true;
            dgvSpStockckDetail.Columns["material_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["material_spec"].ReadOnly = true;
            dgvSpStockckDetail.Columns["material_spec"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].ReadOnly = true;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["unit_name"].ReadOnly = true;
            dgvSpStockckDetail.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["COUNT"].ReadOnly = true;
            dgvSpStockckDetail.Columns["COUNT"].DefaultCellStyle.BackColor = Color.Linen;

            //    1 新盘点单,注意同一个仓库上一次盘点未完成不能进行盘点,存在出入库记录未审核也不能进行盘点.
            //    2 修改未提交的盘点单 或 打回的工单由船上修改 不需要建立默认对象,其他与1一致.
            //    3 被打回的盘点单,或岸端审阅完成的盘点单,等待修改 可以看到理论库存值.
            //    4 岸端审阅 //只能填写备注,也可以填写明细备注.
            //    5 船上审核 //可以修改数量,改备注.
            //    6 岸上审核 //可以修改数量,改备注,如果有必要,将传送给SAP  
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].Visible = (mainFunction > 2 || !StorageConfig.StorageStorageCheckNeedLandView);
            dgvSpStockckDetail.Columns["COUNT"].Visible = (mainFunction > 2 || !StorageConfig.StorageStorageCheckNeedLandView);

        }

        private bool checkingBeforeSave()
        {
            txtCheckDate.Focus();//切一下焦点,好获取变化.
            if (string.IsNullOrEmpty(ucShipWareHouseSelect1.GetId()))
            {
                MessageBoxEx.Show("盘点仓库是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ucShipWareHouseSelect1.Enabled)
            {
                if (MessageBoxEx.Show("盘点仓库保存后将不允许修改！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return false;
                }
                ucShipWareHouseSelect1.Enabled = false;
            }
            updateObjectFromForm();
            return true;
        }

        private void updateObjectFromForm()
        {
            if (theMaterialDepotCheck == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }

            theMaterialDepotCheck.CHECK_DATE = dtpSpckDate.Value;
            theMaterialDepotCheck.REMARK = txtRemark.Text;
            theMaterialDepotCheck.WAREHOUSE_ID = ucShipWareHouseSelect1.GetId();
            theMaterialDepotCheck.LANDCHECKER = txtLandChecker.Text;
            theMaterialDepotCheck.SHIPCHECKER = txtShipChecker.Text;
        }

        private bool saveInfor()
        {
            string err;
            updateObjectFromForm();
            if (theMaterialDepotCheck.Update(out err))
            {
                if (!saveDetails(out err))
                {
                    MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool saveDetails(out string err)
        {
            err = "";
            if (dgvSpStockckDetail.Rows.Count == 0) return true;
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return false;
            }

            //***************数据保存*****************************************************************************
            bindingSourceDetail.EndEdit();
            dgvSpStockckDetail.EndEdit();
            DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            return commonOpt.SaveFormData(dtb, "T_Material_DEPOT_CHECK_DETAIL", 0, out err);//保存数据.
            //更新结果报告.
        }

        #region 按钮区

        private void produceButton_Click(object sender, EventArgs e)
        {
            if (mainFunction != 1 && dgvSpStockckDetail.Rows.Count > 0)
            {
                MessageBoxEx.Show("仅新生成的盘点单可以进行此操作!");
                return;
            }
            string err; //错误信息参数.
            string shipId = theMaterialDepotCheck.SHIP_ID;
            string wareHouseId = ucShipWareHouseSelect1.GetId();//仓库Id  
            if (string.IsNullOrEmpty(wareHouseId))
            {
                MessageBoxEx.Show("请先选择盘点仓库!");
                ucShipWareHouseSelect1.Focus();
                return;
            }

            if (!MaterialStockService.Instance.MaterialCanReinitOrCheck(shipId, wareHouseId, theMaterialDepotCheck.GetId(), out err))
            {
                MessageBoxEx.Show(err + "\r必须先处理完毕，才能进行盘点操作");
                return;
            }
            if (dgvSpStockckDetail.Rows.Count > 0 && MessageBoxEx.Show("生成盘存明细将删除所有已有数据,确认要生成盘存单明细信息吗？", "确认框", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            if (string.IsNullOrEmpty(theMaterialDepotCheck.CHECK_CODE))
                theMaterialDepotCheck.CHECK_CODE = StorageCommonService.Instance.GetSpareAndMaterialCheckCode(shipId);
            theMaterialDepotCheck.WAREHOUSE_ID = wareHouseId;
            if (!theMaterialDepotCheck.Update(out err))
            {
                MessageBoxEx.Show("无法保存当前盘点单,不能为其形成盘存明细记录,更多描述请参考:\r" + err);
                return;
            }

            //调用函数ProduceStockNewLst生成指定仓库的盘存单.
            if (MaterialDepotCheckService.Instance.ProduceStockNewLst(shipId, wareHouseId, theMaterialDepotCheck.GetId(), out err))
            {
                this.setBindingSourceDetail(theMaterialDepotCheck.GetId());//刷新网格.
                txtCode.Text = theMaterialDepotCheck.CHECK_CODE;
                MessageBoxEx.Show("盘存单明细内容生成成功！", "生成成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucShipWareHouseSelect1.Enabled = false;
            }
            else
            {
                MessageBoxEx.Show(err, "生成失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 物资盘点明细信息添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(theMaterialDepotCheck.WAREHOUSE_ID))
            {
                MessageBoxEx.Show("请先保存当前盘点单,或直接生成盘点明细!");
                return;
            }
            //新添加一条记录后把物资名称列变为当前单元格（注意：这正是设置当前活动单元格的方式）.
            if (dgvSpStockckDetail.CurrentCell != null)
            {
                dgvSpStockckDetail.CurrentCell = dgvSpStockckDetail.CurrentRow.Cells["material_name"];
            }
            FrmSelectMaterial frm = new FrmSelectMaterial();
            frm.ShowDialog();

            if (frm.Selected && frm.Materials.Count > 0)
            {
                InsertMaterialsToGridView(frm.Materials, dgvSpStockckDetail.Rows.Count, false);
            }
        }

        /// <summary>
        /// 物资盘点明细信息消耗信息删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开OToolStripButton_Click(object sender, EventArgs e)
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
                dgvSpStockckDetail.EndEdit();
                DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

                //更新结果报告.
                if (commonOpt.SaveFormData(dtb, "T_Material_DEPOT_CHECK_DETAIL", 0, out err))
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
        /// 盘点信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            if (!checkingBeforeSave()) return;

            ////把仅保存的状态打上.
            theMaterialDepotCheck.ISCOMPLETE = 0;
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                setBindingSourceDetail(theMaterialDepotCheck.GetId());
            }
        }
        /// <summary>
        /// 盘存单完成操作（只有完成的盘存单才允许审核）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgComplete_Click(object sender, EventArgs e)
        {
            if (dgvSpStockckDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("盘存没有任何明细，不允许提交审核！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            if (MessageBoxEx.Show("本次盘点是否提交审核？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;

            theMaterialDepotCheck.ISCOMPLETE = 1;
            //如果当前用户正好是部门长，可以直接把部门长的信息维护上，直接等待船长审核.
            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
            {
                if (theMaterialDepotCheck.STATE == 2 || theMaterialDepotCheck.STATE == 3 || theMaterialDepotCheck.STATE == 5)
                {
                    txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                    theMaterialDepotCheck.STATE = 4;
                }
                else if (StorageConfig.StorageStorageCheckNeedLandView)
                    theMaterialDepotCheck.STATE = 1;
                else
                    theMaterialDepotCheck.STATE = 4;
            }
            else
            {
                if (theMaterialDepotCheck.STATE == 2 || theMaterialDepotCheck.STATE == 3 || theMaterialDepotCheck.STATE == 5)
                    theMaterialDepotCheck.STATE = 3;
                else if (StorageConfig.StorageStorageCheckNeedLandView)
                    theMaterialDepotCheck.STATE = 1;
                else
                    theMaterialDepotCheck.STATE = 3;
            }
            if (!checkingBeforeSave()) return;
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
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
                MessageBoxEx.Show("添加物资入库条目信息时，传入的物资条目为0！", "错误提示");
                return;
            }
            if (index < 0) index = 0;
            if (index > dgvSpStockckDetail.Rows.Count) index = dgvSpStockckDetail.Rows.Count;
            if (replaceRow && dgvSpStockckDetail.Rows.Count - 1 < index)
            {
                throw new Exception("添加物资入库条目信息时，替代已有行时,index参数并不实际存在！");
            }
            #endregion

            //从指定行开始加.
            bool theFirstRow = replaceRow;
            bool hasReplitRow = false;
            string err;
            foreach (StorageParameter materialTemp in materialids)
            {
                string materialId = materialTemp.ItemId;

                //这里缺少判断相同录入的内容。.
                if (dgvSpStockckDetail.HasValue("material_Id", materialId))
                {
                    hasReplitRow = true;
                    continue;
                }
                MaterialInfo material = MaterialInfoService.Instance.getObject(materialId, out err);
                material.FillThisObject();
                if (theFirstRow)
                {
                    theFirstRow = false;
                }
                else
                {
                    bindingSourceDetail.AddNew();//执行添加记录功能.
                    dgvSpStockckDetail.CurrentRow.Cells["MaterialCHECKDETAIL_ID"].Value = Guid.NewGuid().ToString();
                    dgvSpStockckDetail.CurrentRow.Cells["DEPOTCHECKID"].Value = theMaterialDepotCheck.GetId();
                    dgvSpStockckDetail.CurrentRow.Cells["ship_id"].Value = theMaterialDepotCheck.SHIP_ID;//当前船舶Id
                    dgvSpStockckDetail.CurrentRow.Cells["WAREHOUSE_ID"].Value = theMaterialDepotCheck.WAREHOUSE_ID;
                }
                //如果当前物资有指定库存，则用指定库，如果没有则拷贝上一行的.
                dgvSpStockckDetail.CurrentRow.Cells["material_id"].Value = materialId;//物资Id
                dgvSpStockckDetail.CurrentRow.Cells["MATERIAL_CODE"].Value = material.MATERIAL_CODE;//规格型号.
                dgvSpStockckDetail.CurrentRow.Cells["material_name"].Value = material.MATERIAL_NAME;//物资名称.
                dgvSpStockckDetail.CurrentRow.Cells["material_spec"].Value = material.MATERIAL_SPEC;//规格型号.
                dgvSpStockckDetail.CurrentRow.Cells["unit_name"].Value = material.UNIT_NAME;//计量单位名称.
                dgvSpStockckDetail.CurrentRow.Cells["THEORETICALCOUNT"].Value = MaterialStockService.Instance.GetMaterialStockOfWarehouse(shipId, materialId, theMaterialDepotCheck.WAREHOUSE_ID);
                dgvSpStockckDetail.CurrentRow.Cells["ACTUALCOUNT"].Value = 0;
                dgvSpStockckDetail.CurrentRow.Cells["COUNT"].Value = 0;
            }

            if (hasReplitRow)
            {
                MessageBoxEx.Show("同一物资入库记录不能重复，只能填一条数据,刚刚选择了已经存在的记录，被自动过滤！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            saveDetails(out err);
        }

        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {
            ShipInfo theShip = (ShipInfo)ShipInfoService.Instance.GetOneObjectById(theMaterialDepotCheck.SHIP_ID);
            dgvSpStockckDetail.Title = theShip.SHIP_NAME + dtpSpckDate.Text + "物资盘存单";
            dgvSpStockckDetail.Header.Clear();
            dgvSpStockckDetail.Header.Add("盘存单编号:" + theMaterialDepotCheck.CHECK_CODE +
                "      盘点人:" + txtStockChecker.Text + "     盘点仓库:" + ucShipWareHouseSelect1.GetText());
            dgvSpStockckDetail.Footer.Clear();
            if (txtRemark.Text.Length > 0)
                dgvSpStockckDetail.Footer.Add("备注:" + txtRemark.Text);

            dgvSpStockckDetail.OutPutExcel();
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //同时表达审阅的意思.
            //这里不做权限判断，前面做过了.
            if (txtRemark.Text.IndexOf("不同意") >= 0)
            {
                MessageBoxEx.Show("备注中含有【不同意】的内容，请先处理备注内容，再进行同意操作", "提示");
                return;
            }

            if (dgvSpStockckDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有任何明细数据，不能进行同意操作", "提示");
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            
            if (!checkingBeforeSave()) return;

            if (MessageBoxEx.Show("本次同意本次盘点？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;

            //岸端审阅.
            if (mainFunction == 4)
            {
                theMaterialDepotCheck.STATE = 2;
            }
            //船端审核.
            else if (mainFunction == 5)
            {
                txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                theMaterialDepotCheck.STATE = 4;
            }
            //岸端审核.
            else if (mainFunction == 6)
            {
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
                theMaterialDepotCheck.CHECKDATE = DateTime.Today;
                theMaterialDepotCheck.STATE = 6;
            }
            else return;

            if (saveInfor())
            {
                string err;
                if (theMaterialDepotCheck.STATE == 6 && StorageConfig.createMessage != null)
                {
                    DataTable dtb;
                    if (!SAPServiceOfSpareAndMaterial.Instance.GetMaterialDepotCheckOperationToSAP(theMaterialDepotCheck.GetId(), out dtb, out err))
                    {
                        MessageBoxEx.Show("将变化数据发送给SAP时发生错误,需要重新审核,错误信息请参考:\r" + err);
                        theMaterialDepotCheck.STATE = 4;
                        if (!theMaterialDepotCheck.Update(out err))
                            MessageBoxEx.Show("将变化数据发送给SAP时发生错误回滚数据时出现错误,错误信息请参考:\r" + err);
                        return;
                    }

                    if (dtb.Rows.Count > 0)
                    {
                        if (!StorageConfig.createMessage(theMaterialDepotCheck.SHIP_ID, theMaterialDepotCheck.CHECK_DATE, theMaterialDepotCheck.CHECKDATE, theMaterialDepotCheck.GetId(), dtb, "4", "1", out err))
                        {
                            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,需要重新审核,错误信息请参考:\r" + err);
                            theMaterialDepotCheck.STATE = 4;
                            if (!theMaterialDepotCheck.Update(out err))
                                MessageBoxEx.Show("将变化数据发送给SAP时发生错误回滚数据时出现错误,错误信息请参考:\r" + err);
                            return;
                        }
                    }
                    //将当前数据的内容全部刷新成历史版本.
                    if (!MaterialDepotCheckService.Instance.MaterialStockCheckFinish(theMaterialDepotCheck.GetId(), out err))
                    {
                        MessageBoxEx.Show("将历史库存变化锁定时发生错误,错误信息为:\r" + err);
                        return;
                    }
                }

                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
        }

        private void FrmMaterialStockCheckEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvSpStockckDetail.SaveGridView("FrmMaterialStockCheckEdit.dgvSpStockckDetail");
        }

        private void ucShipWareHouseSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (theSelectedObject.Equals(theMaterialDepotCheck.WAREHOUSE_ID)) return;
            if (mainFunction > 1)
            {
                MessageBoxEx.Show("仅新建盘存单可以选择仓库!");
                return;
            }
            //有任何记录都不能切换仓库.
            if (dgvSpStockckDetail.Rows.Count > 0)
            {
                if (MessageBoxEx.Show("当前单据包含明细项,只有先删除明细项才能切换其它仓库,是否继续操作?\r'继续操作'请点击[是],否则点击[否]",
                    "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    theMaterialDepotCheck.WAREHOUSE_ID = theSelectedObject;
                    produceButton_Click(null, null);
                }
                else
                {
                    ucShipWareHouseSelect1.SelectedId(theMaterialDepotCheck.WAREHOUSE_ID, false);
                    return;
                }
            }
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            btnQuestion.IsPressed = !btnQuestion.IsPressed;

            if (btnQuestion.IsPressed)
            {
                bindingSourceDetail.Filter = "count <> 0";
            }
            else
            {
                bindingSourceDetail.Filter = "";
            }

        }
        private void btn_NotOk_Click(object sender, EventArgs e)
        {
            string frmName = "盘点单不同原因录入窗口";
            string frmDefaultValue = CommonOperation.ConstParameter.UserName + "不同意此盘点单\r";

            CommonViewer.BaseForm.FrmDisagree frm = new CommonViewer.BaseForm.FrmDisagree(frmName, frmDefaultValue, "");
            frm.ShowDialog();
            if (!frm.Accept)
            {
                MessageBoxEx.Show("您取消了操作！", "提示");
                return;
            }
            //不同意的话，岸端打回到发起者,船端也一样.
            theMaterialDepotCheck.STATE = 3;
            txtRemark.Text += "\r" + frm.Reason;

            if (!checkingBeforeSave()) return;

            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
        }

        #endregion

        #region 物资盘存单明细网格校验部分


        /// <summary>
        /// 明细数据保存时的校验函数.
        /// </summary>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool validateDet()
        {
            if (dgvSpStockckDetail.HasEmptyVal("ACTUALCOUNT") == true)
            {
                if (MessageBoxEx.Show("实际数量为必填内容！未填写的行的实际数量是否自动填0?", "警告", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvSpStockckDetail.Rows.Count; i++)
                    {
                        if (dgvSpStockckDetail.Rows[i].Cells["ACTUALCOUNT"].Value == null || dgvSpStockckDetail.Rows[i].Cells["ACTUALCOUNT"].Value.ToString() == "")
                        {
                            dgvSpStockckDetail.Rows[i].Cells["ACTUALCOUNT"].Value = 0;
                            float fltCount = 0;
                            if (float.TryParse(dgvSpStockckDetail.Rows[i].Cells["THEORETICALCOUNT"].Value.ToString(), out fltCount))
                            {
                                dgvSpStockckDetail.Rows[i].Cells["COUNT"].Value = -1 * fltCount;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            if (dgvSpStockckDetail.HasEmptyVal("material_id") == true)
            {
                MessageBoxEx.Show("物资名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpStockckDetail.HasEmptyVal("WAREHOUSE_ID") == true)
            {
                for (int i = 0; i < dgvSpStockckDetail.Rows.Count; i++)
                {
                    dgvSpStockckDetail.Rows[i].Cells["WAREHOUSE_ID"].Value = theMaterialDepotCheck.WAREHOUSE_ID;
                }
                return false;
            }

            return true;
        }
        private void dgvSpStockckDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            float flt = 0.0f;
            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgvSpStockckDetail.Columns[e.ColumnIndex].Name.ToLower();
            //取当前值赋给变量scurValue
            string sCurValue = e.FormattedValue.ToString().Trim();

            if (sColName.Equals("actualcount"))
            {
                if (sCurValue.Trim().Length > 0 && float.TryParse(sCurValue, out flt) == false)
                {
                    MessageBoxEx.Show("实存数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSpStockckDetail.CurrentRow.Cells[sColName].Value = 0;
                    e.Cancel = true;
                    return;
                }
                if (flt < 0)
                {
                    MessageBoxEx.Show("实存数量不能为负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSpStockckDetail.CurrentRow.Cells[sColName].Value = 0;
                    e.Cancel = true;
                    return;
                }

                float fltCount = 0;
                if (float.TryParse(dgvSpStockckDetail.Rows[e.RowIndex].Cells["THEORETICALCOUNT"].Value.ToString(), out fltCount))
                {
                    //add by lip 20140114 start
                    //如果不加这句话，当修改完【实存数量】后，光标直接离开datagrid控件，【实存数量】的值会回复到原来的值
                    dgvSpStockckDetail.EndEdit();
                    //add by lip 20140114 end
                    dgvSpStockckDetail.Rows[e.RowIndex].Cells["COUNT"].Value = flt - fltCount;
                }

            }
        }
        #endregion

    }
}