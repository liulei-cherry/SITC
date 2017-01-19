/****************************************************************************************************
 * Copyright (C) 2007 ����½���Ƽ����޹�˾ ��Ȩ����
 * �� �� ����FrmMaterialStockck.cs
 * �� �� �ˣ�������
 * ����ʱ�䣺2010-5-5
 * ��    �⣺�����̵�ҵ����
 * ����������ʵ�������̵�ҵ�����ϵ���ع���
 * �� �� �ˣ�
 * �޸�ʱ�䣺
 * �޸����ݣ�
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManage.Services;
using CommonViewer.BaseForm;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using StorageManage.DataObject;
namespace StorageManage.Viewer
{
    public partial class FrmMaterialStockCheck : CommonViewer.BaseForm.FormBase,IRemindViewState
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//����һ��������CommonOpt����.
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//Ȩ�޴���ҵ����.
        private bool loaded = false;
        #region ���嵥ʵ��ģ��

        /// <summary>
        /// ��ǰ����ľ�̬ʵ������.
        /// </summary>
        private static FrmMaterialStockCheck instance = new FrmMaterialStockCheck();

        /// <summary>
        /// ��ǰ����ľ�̬ʵ������.
        /// </summary>
        public static FrmMaterialStockCheck Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialStockCheck.instance = new FrmMaterialStockCheck();
                }

                return FrmMaterialStockCheck.instance;
            }
        }

        #endregion

        private FrmMaterialStockCheck()
        {
            InitializeComponent();
        }
        private void FrmMaterialStockck_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            //��ѯ����Ĭ��Ϊ�����µ�����.
            dtpStartDate.Value = DateTime.Now.AddMonths(-12);
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            this.setComboBox();     //���ô�������������б�������Դ.
            if (!this.checkRight()) return;      //����Ȩ��У��.
            loaded = true;
            this.setBindingSource();//��������Դ.
            this.setDataGridView(); //��������ؼ�dgvSpApply�����������ͷ������.
            this.bindingCtrols();   //�󶨴���ؼ�.
            this.WindowState = FormWindowState.Maximized;//�������.

            Search();
        }

        /// <summary>
        ///���ô����ϵ���Ҫ��ҵ�����ݵ������б�ؼ�.
        /// </summary>
        private void setComboBox()
        {
            //���״̬ѡ���DataTable����.
            DataTable dtbChkState = new DataTable();

            //״̬(1.�ȴ���������,2.�ȴ����˵���,3.�ȴ�����ȷ��,4�ȴ�����ȷ��,5��˱����,6����ȷ��)
            //��صĵ��ݼ�����.
            dtbChkState.Columns.Add("Id", typeof(string));
            dtbChkState.Columns.Add("State", typeof(string));
            DataRow row0 = dtbChkState.NewRow();
            row0["Id"] = "0";
            row0["State"] = "ȫ��";
            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "1";
            row1["State"] = "�ȴ���������";
            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "2";
            row2["State"] = "�ȴ����˵���";
            DataRow row3 = dtbChkState.NewRow();
            row3["Id"] = "3";
            row3["State"] = "�ȴ�����ȷ��";
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "4";
            row4["State"] = "�ȴ�����ȷ��";
            DataRow row5 = dtbChkState.NewRow();
            row5["Id"] = "5";
            row5["State"] = "��˱����";
            DataRow row6 = dtbChkState.NewRow();
            row6["Id"] = "6";
            row6["State"] = "����ȷ��";

            dtbChkState.Rows.Add(row0);
            if (StorageConfig.StorageStorageCheckNeedLandView) dtbChkState.Rows.Add(row1);
            dtbChkState.Rows.Add(row2);
            dtbChkState.Rows.Add(row3);
            dtbChkState.Rows.Add(row4);
            dtbChkState.Rows.Add(row5);
            dtbChkState.Rows.Add(row6);

            cboChkState.DataSource = dtbChkState;
            cboChkState.DisplayMember = "State";
            cboChkState.ValueMember = "Id";
        }
        /// <summary>
        /// ����������Ϣ��bindingSource����Դ��ÿ�β�ѯ�Ķ���ָ��������������Ϣ��.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;
            string shipId = ucShipSelect1.GetId();
            string sckState = "";
            if (cboChkState.SelectedValue != null)
            {
                sckState = cboChkState.SelectedValue.ToString();        //���״̬.
            }

            //ȡ�������̴浥��Ϣ��DataTable����.
            DataTable dtbMaterialStockck = MaterialDepotCheckService.Instance.GetMaterialStockCheck(shipId, dtpStartDate.Value, dtpEndDate.Value, sckState, !cbOthersData.Checked);
            bindingSourceMain.DataSource = dtbMaterialStockck;//�����̵���Ϣ������Դ����.
            dgvSpStockck.DataSource = bindingSourceMain;
            resetStrikeBalanceColor();
        }

        /// <summary>
        /// ���������̵���Ϣ����ؼ�dgvSpIn������������ʾ����.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpStockck.LoadGridView("FrmMaterialDepotCheck.dgvSpStockck");
            dgvSpStockck.Columns["DEPOTCHECKID"].Visible = false;
            dgvSpStockck.Columns["SHIP_ID"].Visible = false;
            dgvSpStockck.Columns["ship_name"].Visible = true;
            dgvSpStockck.Columns["WAREHOUSE_ID"].Visible = false;
            dgvSpStockck.Columns["CHECKDATE"].Visible = false;
            dgvSpStockck.Columns["CHECK_PERSON_POSTID"].Visible = false;
            dgvSpStockck.Columns["STATE"].Visible = false;
            dgvSpStockck.Columns["ISCOMPLETE"].Visible = false;
            dgvSpStockck.Columns["CHECK_CODE"].Visible = false;
            dgvSpStockck.Columns["remark"].Visible = false;
            dgvSpStockck.Columns["ship_name"].HeaderText = "����";
            dgvSpStockck.Columns["WAREHOUSE_NAME"].HeaderText = "�̵�ֿ�";
            dgvSpStockck.Columns["CHECK_DATE"].HeaderText = "�̵�����";
            dgvSpStockck.Columns["CHECK_PERSON"].HeaderText = "�̵���";
            dgvSpStockck.Columns["stateName"].HeaderText = "�̵�״̬";
            dgvSpStockck.Columns["DEPART_ID"].Visible = false;
            dgvSpStockck.Columns["SHIPCHECKER"].Visible = false;
            dgvSpStockck.Columns["LANDCHECKER"].Visible = false;
            dgvSpStockck.Columns["BALANCEDEPOTCHECKID"].Visible = false;
            dgvSpStockck.Columns["StrikeToBalance"].Visible = false;
            dgvSpStockck.Columns["hasBeenBalanced"].Visible = false;
        }
        private void resetStrikeBalanceColor()
        {
            //ˢ�³��˼�¼.
            for (int i = 0; i < dgvSpStockck.Rows.Count; i++)
            {
                if (dgvSpStockck.Rows[i].Cells["StrikeToBalance"].Value.ToString() == "1")
                {
                    dgvSpStockck.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        /// <summary>
        /// �󶨴���ؼ����̴浥��Ϣ�ؼ��İ󶨣�.
        /// </summary>
        private void bindingCtrols()
        {
            //����ֵDEPOTCHECKID�İ�ʹ����dtpSpckDate��Tag���Խ�����޷�ʹ�����صĿؼ���.
            txtCode.DataBindings.Add("Text", bindingSourceMain, "CHECK_CODE", true);
            txtWareHouse.DataBindings.Add("Text", bindingSourceMain, "WAREHOUSE_NAME", true);
            dtpSpckDate.DataBindings.Add("Tag", bindingSourceMain, "DEPOTCHECKID", true);
            dtpSpckDate.DataBindings.Add("Text", bindingSourceMain, "CHECK_DATE", true);
            txtStockChecker.DataBindings.Add("Text", bindingSourceMain, "CHECK_PERSON", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            txtShipChecker.DataBindings.Add("Text", bindingSourceMain, "SHIPCHECKER", true);
            txtCheckDate.DataBindings.Add("Text", bindingSourceMain, "CHECKDATE", true);
            txtLandChecker.DataBindings.Add("Text", bindingSourceMain, "LANDCHECKER", true);
            txtState.DataBindings.Add("Text", bindingSourceMain, "stateName", true);
        }

        /// <summary>
        /// ���湦��Ȩ�޵�У��.
        /// </summary>
        private bool checkRight()
        {
            btnView.Enabled = false;
            btnBanlance.Enabled = false;
            btnCheck.Enabled = false;
            string err;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                bdNgAddNewItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                bdNgEditItem.Visible = false;
                if (StorageConfig.StorageStorageCheckNeedLandView) btnView.Visible = true;
                cbOthersData.Checked = false;
                cbOthersData.Visible = false;

                if (!proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err))
                {
                    MessageBoxEx.Show("����߱����������ʹ���Ȩ�ޡ������ʰ�����ˡ�Ȩ�޲��ܿ������ݣ�");
                    return false;
                }
                else if (proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                   || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                   || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err))
                {
                    btnCheck.Visible = true;
                }
                btnBanlance.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.STRIKE_A_BALANCE, out err);
            }
            else
            {
                btnView.Visible = false;
                btnBanlance.Visible = false;
                //Ȩ���жϲ���,����п�������Ϣ��Ȩ��ʱ��checkbox���óɿɲ��������򲻿ɲ���.
                if (proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, out err)
                    || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    cbOthersData.Checked = false;
                    cbOthersData.Enabled = true;
                }
                else
                {
                    cbOthersData.Checked = true;
                    cbOthersData.Enabled = false;//���ܿ����˵�.
                }
                //�߼���Ա�����쵼��λ.
                if (CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    //������ҪȨ�޿��ƵĿؼ��Ŀɼ���.
                    bdNgAddNewItem.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    bdNgEditItem.Visible = true;
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    //������ҪȨ�޿��ƵĿؼ��Ŀɼ���.
                    bdNgAddNewItem.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    bdNgEditItem.Visible = true;
                    btnCheck.Visible = true;
                }
                else
                {
                    MessageBoxEx.Show("���˴����ĸ߼���Ա�⣬�����˵�¼�˽���Ҳ���ܲ����������κ����ݣ�");
                    return false;
                }
            }
            return true;
            // 
        }

        /// <summary>
        /// ���̴浥��Ϣ�����иı�ʱ����ʾ��ǰ�е��̴浥��ϸ��Ϣ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpStockck_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string stockckId = "";                  //��ǰ����dgvSpStockck�е��̴浥��Ϣ����.
            string stockCkCode = "";                //�����̴浥���.
            string shipId;
            string state;
            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //״̬(1.�ȴ���������,2.�ȴ����˵���,3.�ȴ�����ȷ��,4�ȴ�����ȷ��,5��˱����,6����ȷ��)
                //�����ǰ�������ǿ���ɾ���ģ�״̬�����˿���ɾ�����쵼����ɾ����.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" &&
                    (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5"))
                {
                    bdNgEditItem.Enabled = true;
                }
                else if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "0"
                    && dgvSpStockck.CurrentRow.Cells["DEPART_ID"].Value.ToString().Equals(CommonOperation.ConstParameter.LoginUserInfo.DepartmentId))
                {
                    if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "1")
                        bdNgEditItem.Enabled = true;
                    else if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                        || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5")
                        bdNgEditItem.Enabled = true;
                    else
                        bdNgEditItem.Enabled = false;
                }
                else
                {
                    bdNgEditItem.Enabled = false;
                }
            }
            else
            {
                bdNgEditItem.Enabled = false;
            }
            if (dgvSpStockck.Rows[e.RowIndex].Cells["DEPOTCHECKID"].Value != null)
            {
                stockckId = dgvSpStockck.Rows[e.RowIndex].Cells["DEPOTCHECKID"].Value.ToString();
                stockCkCode = dgvSpStockck.Rows[e.RowIndex].Cells["CHECK_CODE"].Value.ToString();
                shipId = dgvSpStockck.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                state = dgvSpStockck.Rows[e.RowIndex].Cells["state"].Value.ToString();
                this.setBindingSourceDetail(stockckId, state);
                //�󶨴��ĵ�.
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(stockckId, stockCkCode, CommonOperation.Enum.FileBoundingTypes.SPEARCOUNT, shipId);

                btnView.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "1" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1");
                btnCheck.Enabled = (((dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "3" && !CommonOperation.ConstParameter.IsLandVersion)
                    || (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "4" && CommonOperation.ConstParameter.IsLandVersion))
                    && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1");
                btnBanlance.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "6" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1"
                    && dgvSpStockck.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0" && dgvSpStockck.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "1");
                btnClone.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "6" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1"
                    && dgvSpStockck.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0");

            }
            else
            {
                this.setBindingSourceDetail("", "");
            }
        }

        /// <summary>
        /// ���������̴浥��ϸ��Ϣ��bindingSource����Դ��ÿ�β�ѯ�Ķ���ָ���̴浥����ϸ��Ϣ����.
        /// </summary>
        /// <param name="stockckId">�̴浥��ϢId</param>
        /// <param name="stockckId">�̴浥��ϢId</param>
        private void setBindingSourceDetail(string stockckId, string state)
        {
            DataTable dtbMaterialStockckDetail = MaterialDepotCheckService.Instance.GetMaterialStockckDetail(stockckId);//ȡ�������̴浥��ϸ��Ϣ��DataTable����.
            bindingSourceDetail.DataSource = dtbMaterialStockckDetail;//�����̵���ϸ��Ϣ������Դ����.
            dgvSpStockckDetail.DataSource = bindingSourceDetail;
            this.setDataGridViewDetail(state);
        }

        /// <summary>
        /// �������̵���ϸ��Ϣ����ؼ�dgvSpStockckDetail������������ʾ����.
        /// </summary>
        private void setDataGridViewDetail(string state)
        {
            dgvSpStockckDetail.LoadGridView("FrmMaterialStockCheck.dgvSpStockckDetail");
            dgvSpStockckDetail.Columns["MaterialCHECKDETAIL_ID"].Visible = false;
            dgvSpStockckDetail.Columns["DEPOTCHECKID"].Visible = false;
            dgvSpStockckDetail.Columns["WAREHOUSE_ID"].Visible = false;
            dgvSpStockckDetail.Columns["material_Id"].Visible = false;
            dgvSpStockckDetail.Columns["ship_id"].Visible = false;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].Visible = false;
            dgvSpStockckDetail.Columns["COUNT"].Visible = false;
            dgvSpStockckDetail.Columns["ISSAP"].HeaderText = "��������";
            dgvSpStockckDetail.Columns["material_code"].HeaderText = "���ʱ���";
            dgvSpStockckDetail.Columns["material_name"].HeaderText = "��������";
            dgvSpStockckDetail.Columns["material_spec"].HeaderText = "����ͺ�";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].HeaderText = "��������";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].HeaderText = "ʵ������";
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["COUNT"].HeaderText = "ӯ������";
            dgvSpStockckDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["unit_name"].HeaderText = "��λ";
            dgvSpStockckDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpStockckDetail.Columns["remark"].HeaderText = "ӯ��ԭ��";
            dgvSpStockckDetail.Columns["material_code"].ReadOnly = true;
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
            //1.�ȴ���������,2.�ȴ����˵���,3.�ȴ�����ȷ��,4�ȴ�����ȷ��,5��˱����,6����ȷ��.
            int iState;
            if (int.TryParse(state, out iState))
            {
                if (iState > 1)
                {
                    dgvSpStockckDetail.Columns["THEORETICALCOUNT"].Visible = true;
                    dgvSpStockckDetail.Columns["COUNT"].Visible = true;
                }
            }
        }

        #region ��ѯ
        /// <summary>
        /// ���뵥��¼ɸѡ.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //����̵㵥û�м�¼�����̵㵥��ϸҲ��Ӧ��������.
            if (loaded && dgvSpStockck.Rows.Count == 0)
            {
                this.setBindingSourceDetail("", "");
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.Search();
        }

        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void cboChkState_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Search();
        }
        private void cbOthersData_CheckedChanged(object sender, EventArgs e)
        {
            this.Search();
        }
        #endregion

        #region ��ť����
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            FrmMaterialStockCheckEdit frmMaterialStockckEdit = new FrmMaterialStockCheckEdit();
            frmMaterialStockckEdit.ShowDialog();
            this.Search();
        }

        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //״̬(1.�ȴ���������,2.�ȴ����˵���,3.�ȴ�����ȷ��,4�ȴ�����ȷ��,5��˱����,6����ȷ��)
                //�����ǰ�������ǿ���ɾ���ģ�״̬�����˿���ɾ�����쵼����ɾ����.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" &&
                    (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5"))
                {
                    openform(3);
                }
                else if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "0"
                    && dgvSpStockck.CurrentRow.Cells["DEPART_ID"].Value.ToString().Equals(CommonOperation.ConstParameter.LoginUserInfo.DepartmentId))
                {
                    if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "1")
                        openform(2);
                    else if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                        || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5")
                        openform(3);
                }
            }
        }

        /// <summary>
        /// ɾ������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //������Ϣ����.

            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //�����ǰ�������ǿ���ɾ���ģ�״̬�����˿���ɾ�����쵼����ɾ����.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" 
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() != (StorageConfig.StorageStorageCheckNeedLandView ? "1" : "3"))
                {
                    MessageBoxEx.Show("������ɾ��δ��ɲ�����û���ύ�κ�����˵ĵ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                //����Ȩ�ޣ�ֻҪ�ܿ����������ݵģ��Ϳ��Զ�����в�������Ҫ�ٴν����ж�.
                if (MessageBoxEx.Show("ȷ��ɾ�����̵㵥��Ϣ��",
                   "����", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MaterialDepotCheckService.Instance.deleteUnit(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out err))
                {
                    MessageBoxEx.Show("ɾ���ɹ���", "ɾ���ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "ɾ��ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //�����ǰû�����ݣ������������Ŀؼ�Ϊ������״̬������Ϊ����״̬��.
                Search();
            }
        }

        /// <summary>
        /// �����̵�ͳ����Ϣ��ӡ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("�޿ɴ�ӡ����Ϣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dgvSpStockckDetail.Title = dgvSpStockck.CurrentRow.Cells["ship_name"].Value.ToString() + dtpSpckDate.Text + "�����̴浥";
            dgvSpStockckDetail.Header.Clear();
            dgvSpStockckDetail.Header.Add("�̴浥���:" + dgvSpStockck.CurrentRow.Cells["CHECK_CODE"].Value.ToString() +
                "      �̵���:" + txtStockChecker.Text + "     �̵�ֿ�:" + dgvSpStockck.CurrentRow.Cells["warehouse_name"].Value.ToString());
            dgvSpStockckDetail.Footer.Clear();
            if (txtRemark.Text.Length > 0)
                dgvSpStockckDetail.Footer.Add("��ע:" + txtRemark.Text);

            dgvSpStockckDetail.OutPutExcel();
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("δѡ���κ���Ϣ,�޷�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() != "1" || dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() != "1")
            {
                MessageBoxEx.Show("��ǰ����״̬����ȷ,�޷��������ģ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //����ʱ,�����޸�����,ֻ������������,���Դ�ӡ�����������,����������ʱ,Ӧ�ÿ��Կ������е�����.
            string sChkMessage;
            //ֻ���Ǿ߱�������˹��ܵĲ��ܲ���.
            if (!proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
                && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
                && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage))
            {
                MessageBoxEx.Show("ֻ���ǰ��˻������Ȩ�޵��쵼���ܲ����˹���", "�����������");
                return;
            }
            openform(4);

        }

        /// <summary>
        /// ��һ��ά������.
        /// </summary>
        /// <param name="function">  1 ���̵㵥,ע��ͬһ���ֿ���һ���̵�δ��ɲ��ܽ����̵�,���ڳ�����¼δ���Ҳ���ܽ����̵�.
        ///    2 �޸�δ�ύ���̵㵥 ����Ҫ����Ĭ�϶���,������1һ��.
        ///    3 ����ص��̵㵥,�򰶶�������ɵ��̵㵥,�ȴ��޸� ���Կ������ۿ��ֵ.
        ///    4 �������� //ֻ����д��ע,Ҳ������д��ϸ��ע.
        ///    5 ������� //�����޸�����,�ı�ע.
        ///    6 ������� //�����޸�����,�ı�ע,����б�Ҫ,�����͸�SAP</param>
        private void openform(int function)
        {
            if (dgvSpStockck.CurrentRow != null)
            {
                FrmMaterialStockCheckEdit frmMaterialStockckEdit = new FrmMaterialStockCheckEdit(dtpSpckDate.Tag.ToString(), function);
                frmMaterialStockckEdit.ShowDialog();
                this.Search();
            }
        }

        private void FrmMaterialStockck_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;    //�ͷŴ���ʵ������.
            dgvSpStockck.SaveGridView("FrmMaterialDepotCheck.dgvSpStockck");
            dgvSpStockckDetail.SaveGridView("FrmMaterialStockCheck.dgvSpStockckDetail");
        }

        private void dgvSpStockck_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bdNgEditItem_Click(null, null);
        }

        /// <summary>
        /// ���˺󣬿�¡�̵�����(��������ͬ����SAP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("δѡ���κ���Ϣ,�޷�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //��ʾ,��д����ԭ��;
            OurMessageBox messagebox = new OurMessageBox("ȷ��Ҫ���̵���Ϣ���п�¡���˲�����\r���ȷ��,��������¡ԭ�򲢵��[ȷ��]��ť,������[ȡ��]��ť.",
                  "ȷ�Ͽ�", DateTime.Now.ToShortDateString() + "�� " + CommonOperation.ConstParameter.UserName + "��¡");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;

            string err;
            //��ԭ������ȫ��������,�����ӱ�,�����״̬��Ϊ���ȴ�����ȷ�ϣ�.
            if (MaterialDepotCheckService.Instance.CloneStockTake(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), messagebox.AnswerTxt, out err))
            {
                MessageBoxEx.Show("��¡���", "��ʾ");
                this.Search();
            }
            else
            {
                MessageBoxEx.Show("��¡ʧ��,����ԭ��Ϊ" + err, "����");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("δѡ���κ���Ϣ,�޷�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //���Ӧ���ڰ��˴��˷ֱ���Ե��,Ч����ͬ,�����ǲ��ų���˻򴬳����,��������д���������,��״̬,
            //��������Ӧ���Ȩ�޵���Ա���,��˺�Ҳ��״̬.
            //����ʱ,�����޸�����,ֻ������������,���Դ�ӡ�����������,����������ʱ,Ӧ�ÿ��Կ������е�����.
            string sChkMessage;
            //ֻ���Ǿ߱�������˹��ܵĲ��ܲ���.
            if (CommonOperation.ConstParameter.IsLandVersion && (proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage)))
            {
                openform(6);
            }
            else if (!CommonOperation.ConstParameter.IsLandVersion &&
                (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER))
            {
                openform(5);
            }
            else
            {
                MessageBoxEx.Show("��ǰ�����߲��߱����Ȩ��,�޷������˲���", "������ʾ");
            }
        }

        private void btnBanlance_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("δѡ���κ���Ϣ,�޷�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //��ʾ,��д����ԭ��;
            OurMessageBox messagebox = new OurMessageBox("ȷ��Ҫ���Ѿ����ĵ��ݽ��г��˲�����\r���ȷ��,����������ԭ�򲢵��[ȷ��]��ť,������[ȡ��]��ť.",
                  "ȷ�Ͽ�", DateTime.Now.ToShortDateString() + "�� " + CommonOperation.ConstParameter.UserName + "����");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;

            string err;
            int stateCode = 0;

            //��ԭ������ȫ��������,�����ӱ�,ͬʱ�Ѱ���ȷ���˺�ʱ���޸ĳɵ�ǰ��Ա.
            if (MaterialDepotCheckService.Instance.StrikeABalance(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), messagebox.AnswerTxt, out err))
            {
                if (StorageConfig.reverseAccount != null)
                {
                    if (!StorageConfig.reverseAccount(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out stateCode, out err))
                    {
                        MessageBoxEx.Show("���������ݴ��ݸ�SAPʱ���ִ���,������ʾ�ο�:\r" + err);
                        MaterialDepotCheckService.Instance.RemoveABalance(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out err);
                        return;
                    }
                }
                if (stateCode == 0)
                    MessageBoxEx.Show("�ɹ������ϱ�SAP����.");
                else
                    MessageBoxEx.Show("��Ԥ���Ѿ����뵽SAP��,�޷�����,�Ѿ���SAP���˴���.");
                this.Search();
            }
            else
            {
                MessageBoxEx.Show("����ʧ��,����ԭ��Ϊ" + err);
            }

        }

        private void dgvSpStockck_Sorted(object sender, EventArgs e)
        {
            resetStrikeBalanceColor();
        }
        #endregion


        #region IRemindViewState ��Ա

        public void SetRemindViewApprovalState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("���д�");
            cboChkState.Text = "ȫ��";
            Search();
        }

        public void SetRemindViewInformState()
        {
        }

        #endregion
    }
}