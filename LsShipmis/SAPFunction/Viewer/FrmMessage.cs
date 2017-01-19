/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMessage.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/16
 * 标    题：FrmMessage窗体
 * 功能描述：sap报文信息
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Data;
using CommonViewer;
using SAPFunction.Services;
using SAPFunction.DataObject;
using CommonViewer.BaseControl;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using CommonOperation;

namespace SAPFunction.Viewer
{
    public partial class FrmMessage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMessage instance = new FrmMessage();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMessage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMessage.instance = new FrmMessage();
                }
                return FrmMessage.instance;
            }
        }
        #endregion
        public FrmMessage()
        {
            InitializeComponent();
        }
        string selection;
        private void FrmMessage_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);//船舶
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            ucDataGridView1.DataSource = bdsMain;

            ReloadData();
            UcDataGridView uc = ucDataGridView1;
            if (uc.DataSource != null)
            {
                Dictionary<string, string> ucDataGridView1ColumnsSetting = new Dictionary<string, string>();
                ucDataGridView1ColumnsSetting.Add("SY_SOURCE", "来源系统编码");
                ucDataGridView1ColumnsSetting.Add("SY_SOURCE_NAME", "来源系统");
                ucDataGridView1ColumnsSetting.Add("INT_ID", "接口名称");
                ucDataGridView1ColumnsSetting.Add("INT_ID_NAME", "来源系统编码");
                ucDataGridView1ColumnsSetting.Add("SHIP_NAME", "船舶");
                ucDataGridView1ColumnsSetting.Add("COMPANY_CODE", "公司代码");
                ucDataGridView1ColumnsSetting.Add("PRODUCE", "接口数据生成时间");
                ucDataGridView1ColumnsSetting.Add("QUANTITY", "行项目记录条数");
                ucDataGridView1ColumnsSetting.Add("OCCUR", "业务发生日期");
                ucDataGridView1ColumnsSetting.Add("ACCOUNT", "实际记账日期");
                ucDataGridView1ColumnsSetting.Add("PACKET_ID", "数据包唯一标识号");
                ucDataGridView1ColumnsSetting.Add("BUSINESS_CODE", "业务代码");
                ucDataGridView1ColumnsSetting.Add("MESSAGE_TYPE_NAME", "报文类型");
                ucDataGridView1ColumnsSetting.Add("BUSINESS_TYPE_NAME", "业务类型");
                ucDataGridView1ColumnsSetting.Add("MESSAGE_ERROR", "错误信息");
                ucDataGridView1ColumnsSetting.Add("STATUS_NAME", "状态");

                uc.LoadGridView("FrmMessage.ucDataGridView1", ucDataGridView1ColumnsSetting);
            }
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {

            //状态
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID", typeof(string));
            dtb.Columns.Add("NAME", typeof(string));
            dtb.Rows.Add("", "全部");
            dtb.Rows.Add("2", "未通过映射");
            dtb.Rows.Add("3", "待发送");
            dtb.Rows.Add("4", "报文错误");
            dtb.Rows.Add("5", "发送成功");
            dtb.Rows.Add("6", "作废");
            dtb.Rows.Add("7", "SAP方法调用失败");
            cbxState.DisplayMember = "NAME";
            cbxState.ValueMember = "ID";
            cbxState.DataSource = dtb;
            cbxState.SelectedValue = "2";


            //业务类型
            DataTable dtb2 = new DataTable();
            dtb2.Columns.Add("ID", typeof(string));
            dtb2.Columns.Add("NAME", typeof(string));
            dtb2.Rows.Add("", "全部");
            dtb2.Rows.Add("1", "物料业务");
            dtb2.Rows.Add("2", "备件业务");
            dtb2.Rows.Add("3", "油料业务");
            dtb2.Rows.Add("4", "其他业务");
            cbxType.DisplayMember = "NAME";
            cbxType.ValueMember = "ID";
            cbxType.DataSource = dtb2;
            cbxType.SelectedValue = "";

        }

        /// <summary>
        /// 绑定数据.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public void ReloadData()
        {
            string err;
            ucDataGridView2.DataSource = null;

            string state = cbxState.SelectedValue == null ? null : cbxState.SelectedValue.ToString();
            string type = cbxType.SelectedValue == null ? null : cbxType.SelectedValue.ToString();

            bdsMain.DataSource = MessageHeaderService.Instance.GetInfo(ucShipSelect1.GetId(), dateYear.Value.ToString("yyyy") + dateMonth.Value.ToString("MM"), null, state, type, out err);
        }

        /// <summary>
        /// 报文头gridview活动行事件,选择哪个类型 显示哪个详细.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void bdsMain_CurrentChanged(object sender, EventArgs e)
        {
            string err;
            txtMessageError.Text = "";
            if (bdsMain.Current == null) return;

            MessageHeader mh = MessageHeaderService.Instance.getObject(((DataRowView)bdsMain.Current)["MESSAGE_HEADER_ID"].ToString(), out err);
            if (!string.IsNullOrEmpty(mh.MESSAGE_HEADER_ID))
            {
                selection = mh.MESSAGE_HEADER_ID;
                //if (mh.STATUS == "5")
                //{
                //    btnRepeat.Enabled = false;
                //}
                //else if (mh.STATUS == "6")
                //{
                //    btnRepeat.Enabled = true;
                //}
                //else
                //{
                //    btnRepeat.Enabled = true;
                //}

                txtMessageError.Text = mh.MESSAGE_ERROR;
                if (mh.MESSAGE_TYPE == "1")
                {
                    PurchaseDataBind(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "2")
                {
                    CostDataBind(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "3")
                {
                    OutboundDataBind(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "4")
                {
                    InvenDataBind(mh.MESSAGE_HEADER_ID, out err);
                }
            }
        }

        #region 设置gridview列样式

        private void PurchaseDataBind(string headerID, out string err)
        {
            UcDataGridView uc = ucDataGridView2;
            uc.DataSource = PurchaseMessageService.Instance.GetInfoByHeaderID(headerID, out err);
            if (((DataTable)uc.DataSource) != null)
            {
                uc.Columns["PURCHASE_MESSAGE_ID"].Visible = false;
                uc.Columns["MESSAGE_HEADER_ID"].Visible = false;
                uc.Columns["LINENUM"].HeaderText = "数据包行号";
                uc.Columns["LINENUM"].ReadOnly = true;
                uc.Columns["MATERIAL"].Visible = false;
                uc.Columns["MATERIAL_NAME"].HeaderText = "物资名称";
                uc.Columns["MATERIAL_MAPPING"].HeaderText = "物资编号映射";
                uc.Columns["QUANTITY"].HeaderText = "数量";
                uc.Columns["CURRENCY"].HeaderText = "币种";
                uc.Columns["AMOUNT"].HeaderText = "金额";
                uc.Columns["SUBJECT_MAPPING"].HeaderText = "科目映射";
                uc.Columns["SHIP_ID"].Visible = false;
                uc.Columns["SHIP_NAME"].HeaderText = "船舶";
                uc.Columns["SHIP_MAPPING"].HeaderText = "船舶映射";
                uc.Columns["INPUT_OUTPUT"].Visible = false;
                uc.Columns["INPUT_OUTPUT_NAME"].HeaderText = "出入库标识";
                uc.Columns["SUPPLIER"].Visible = false;
                uc.Columns["MANUFACTURER_NAME"].HeaderText = "供应商名称";
                uc.Columns["SUPPLIER_MAPPING"].HeaderText = "供应商映射";
                uc.Columns["INPUT_ORDER"].HeaderText = "入库单号";
                uc.Columns["INPUT_OREER_ITEM"].HeaderText = "入库单行项目号";
                uc.Columns["NODE_NAME"].HeaderText = "科目名称";
                uc.Columns["UUID"].HeaderText = "UUID";
                uc.LoadGridView("FrmMessage.ucDataGridViewPurchase");
            }
        }

        private void CostDataBind(string headerID, out string err)
        {
            UcDataGridView uc = ucDataGridView2;
            uc.DataSource = CostMessageService.Instance.GetInfoByHeaderID(headerID, out err);
            if (((DataTable)uc.DataSource) != null)
            {
                uc.Columns["COST_MESSAGE_ID"].Visible = false;
                uc.Columns["MESSAGE_HEADER_ID"].Visible = false;
                uc.Columns["LINENUM"].HeaderText = "数据包行号";
                uc.Columns["LINENUM"].ReadOnly = true;
                uc.Columns["SUPPLIER"].Visible = false;
                uc.Columns["MANUFACTURER_NAME"].HeaderText = "供应商名称";
                uc.Columns["SUPPLIER_MAPPING"].HeaderText = "供应商映射";
                uc.Columns["CURRENCY"].HeaderText = "币种";
                uc.Columns["AMOUNT"].HeaderText = "金额";
                uc.Columns["SUBJECT"].Visible = false;
                uc.Columns["node_name"].HeaderText = "成本类科目";
                uc.Columns["SUBJECT_MAPPING"].HeaderText = "成本类科目映射";
                uc.Columns["COST_TYPE"].HeaderText = "费用类型";
                uc.Columns["Cost_type_NAME"].HeaderText = "费用类型名称";
                uc.Columns["INNER_ORDER"].HeaderText = "内部订单";
                uc.Columns["SHIP_ID"].Visible = false;
                uc.Columns["SHIP_NAME"].HeaderText = "船舶名称";
                uc.Columns["SHIP_MAPPING"].HeaderText = "船舶映射";
                uc.Columns["UUID"].HeaderText = "UUID";
                uc.LoadGridView("FrmMessage.ucDataGridViewCost");
            }
        }

        private void OutboundDataBind(string headerID, out string err)
        {
            UcDataGridView uc = ucDataGridView2;
            uc.DataSource = OutboundMessageService.Instance.GetInfoByHeaderID(headerID, out err);
            if (((DataTable)uc.DataSource) != null)
            {
                uc.Columns["Outbound_MESSAGE_ID"].Visible = false;
                uc.Columns["MESSAGE_HEADER_ID"].Visible = false;
                uc.Columns["LINENUM"].HeaderText = "数据包行号";
                uc.Columns["LINENUM"].ReadOnly = true;
                uc.Columns["MATERIAL"].Visible = false;
                uc.Columns["MATERIAL_NAME"].HeaderText = "物资名称";
                uc.Columns["MATERIAL_MAPPING"].HeaderText = "物资编号映射";
                uc.Columns["QUANTITY"].HeaderText = "数量";
                uc.Columns["SHIP_ID"].Visible = false;
                uc.Columns["SHIP_NAME"].HeaderText = "船舶";
                uc.Columns["SHIP_MAPPING"].HeaderText = "船舶映射";
                uc.Columns["INPUT_OUTPUT"].Visible = false;
                uc.Columns["INPUT_OUTPUT_NAME"].HeaderText = "出入库标识";
                uc.Columns["UUID"].HeaderText = "UUID";
                uc.LoadGridView("FrmMessage.ucDataGridViewInven");
            }
        }

        private void InvenDataBind(string headerID, out string err)
        {
            UcDataGridView uc = ucDataGridView2;
            uc.DataSource = InvenMessageService.Instance.GetInfoByHeaderID(headerID, out err);
            if (((DataTable)uc.DataSource) != null)
            {
                uc.Columns["INVEN_MESSAGE_ID"].Visible = false;
                uc.Columns["MESSAGE_HEADER_ID"].Visible = false;
                uc.Columns["LINENUM"].HeaderText = "数据包行号";
                uc.Columns["LINENUM"].ReadOnly = true;
                uc.Columns["MATERIAL"].Visible = false;
                uc.Columns["MATERIAL_NAME"].HeaderText = "物资名称";
                uc.Columns["MATERIAL_MAPPING"].HeaderText = "物资编号映射";
                uc.Columns["QUANTITY"].HeaderText = "数量";
                uc.Columns["SHIP_ID"].Visible = false;
                uc.Columns["SHIP_NAME"].HeaderText = "船舶";
                uc.Columns["SHIP_MAPPING"].HeaderText = "船舶映射";
                uc.Columns["INPUT_OUTPUT"].Visible = false;
                uc.Columns["INPUT_OUTPUT_NAME"].HeaderText = "出入库标识";
                uc.Columns["UUID"].HeaderText = "UUID";
                uc.LoadGridView("FrmMessage.ucDataGridViewInven");
            }
        }

        #endregion
        /// <summary>
        /// 释放窗体事件,保存列样式.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMessage_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmMessage.ucDataGridView1");
            if (ucDataGridView1.CurrentRow != null)
                switch (Convert.ToInt32(ucDataGridView1.CurrentRow.Cells["MESSAGE_TYPE"].Value))
                {
                    case 1:
                        ucDataGridView2.SaveGridView("FrmMessage.ucDataGridViewPurchase");
                        break;
                    case 2:
                        ucDataGridView2.SaveGridView("FrmMessage.ucDataGridViewCost");
                        break;
                    case 3:
                        ucDataGridView2.SaveGridView("FrmMessage.ucDataGridViewOutbound");
                        break;
                    case 4:
                        ucDataGridView2.SaveGridView("FrmMessage.ucDataGridViewInven");
                        break;
                }
            instance = null;
        }
        /// <summary>
        /// 关闭窗体事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///// <summary>
        ///// 重发按钮时间.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnRepeat_Click(object sender, EventArgs e)
        //{
        //    string err;
        //    if (string.IsNullOrEmpty(selection))
        //        return;
        //    DataTable dt = MessageHeaderService.Instance.getInfo(selection, out err);
        //    if (dt.Rows.Count > 0)
        //    {
        //        MessageHeader mh = MessageHeaderService.Instance.getObject(dt.Rows[0]);
        //        if (mh.STATUS == "5")
        //        {
        //            MessageBoxEx.Show("该报文已发送成功,不能重发");
        //            return;
        //        }
        //        mh.STATUS = "2";
        //        if (!MessageHeaderService.Instance.saveUnit(mh, out err))
        //        {
        //            MessageBoxEx.Show(err, "重发失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //    }
        //    MessageBoxEx.Show("重发成功");
        //    if (!ReloadData(out err))
        //        return;
        //}
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            string err;
            if (!MessageOperation.Instance.SendMessage(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            ReloadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            string err;
            MessageOperation.Instance.MappingMessage(out err);
            if (!string.IsNullOrEmpty(err))
                MessageBoxEx.Show(err);
            ReloadData();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            ReloadData();
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dateMonth_ValueChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void cbxState_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (ucDataGridView1.CurrentRow.Index >= 0)
            {
                if (ucDataGridView1.CurrentRow.Cells["INT_ID"].Value.ToString() == "JMM002")
                {
                    if (SaveFileDialogEx.ShowDialog(saveFileDialog1) == DialogResult.OK)
                    {
                        byte[] fileBytes = (byte[])SAPFunction.Properties.Resources.ResourceManager.GetObject("ZJMM002_TEMPLATE");
                        string sTempName = Guid.NewGuid().ToString();
                        FileStream fs = File.Create(saveFileDialog1.FileName + sTempName, fileBytes.Length, FileOptions.SequentialScan);
                        fs.Write(fileBytes, 0, fileBytes.Length);
                        fs.Flush();
                        fs.Close();
                        FileInfo fi = new FileInfo(saveFileDialog1.FileName + sTempName);
                        CreateJMM002Files(ucDataGridView1.CurrentRow.Index, fi.FullName);
                        fi.CopyTo(saveFileDialog1.FileName, true);
                        fi.Delete();
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            if (MessageBoxEx.Show("写入成功,是否打开文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                Tools.FileOpen(saveFileDialog1.FileName);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("写入失败,可能当前使用者没有本机相应目录的操作权限来完成文件的创建!");
                        }
                    }
                }
            }
        }

        private void CreateJMM002Files(int rowIndex, string fileFullName)
        {
            using (OfficeOperation.Excel oper = new OfficeOperation.Excel())
            {
                oper.OpenDocument(fileFullName);
                oper.SetValue("A5", ucDataGridView1.Rows[rowIndex].Cells["SY_SOURCE"].Value.ToString());
                oper.SetValue("B5", ucDataGridView1.Rows[rowIndex].Cells["INT_ID"].Value.ToString());
                oper.SetValue("C5", ucDataGridView1.Rows[rowIndex].Cells["PACKET_ID"].Value.ToString());
                oper.SetValue("D5", ucDataGridView1.Rows[rowIndex].Cells["COMPANY_CODE"].Value.ToString());
                oper.SetValue("E5", ucDataGridView1.Rows[rowIndex].Cells["PRODUCE"].Value.ToString());
                oper.SetValue("F5", ucDataGridView1.Rows[rowIndex].Cells["QUANTITY"].Value.ToString());
                oper.SetValue("G5", ucDataGridView1.Rows[rowIndex].Cells["OCCUR"].Value.ToString());
                oper.SetValue("H5", ucDataGridView1.Rows[rowIndex].Cells["ACCOUNT"].Value.ToString());
                //
                int i = 8;
                foreach (DataGridViewRow dgvr in ucDataGridView2.Rows)
                {
                    oper.SetValue("A" + i.ToString(), dgvr.Cells["LINENUM"].Value.ToString());
                    oper.SetValue("B" + i.ToString(), dgvr.Cells["SUPPLIER_MAPPING"].Value.ToString());
                    oper.SetValue("C" + i.ToString(), dgvr.Cells["CURRENCY"].Value.ToString());
                    oper.SetValue("D" + i.ToString(), dgvr.Cells["AMOUNT"].Value.ToString());
                    oper.SetValue("E" + i.ToString(), dgvr.Cells["SUBJECT_MAPPING"].Value.ToString());
                    oper.SetValue("F" + i.ToString(), dgvr.Cells["COST_TYPE"].Value.ToString());
                    oper.SetValue("G" + i.ToString(), dgvr.Cells["INNER_ORDER"].Value.ToString());
                    oper.SetValue("H" + i.ToString(), dgvr.Cells["SHIP_MAPPING"].Value.ToString());
                    oper.SetValue("I" + i.ToString(), dgvr.Index.ToString());
                    oper.SetValue("J" + i.ToString(), dgvr.Cells["UUID"].Value.ToString());
                    i++;
                }
                oper.SaveDocument(fileFullName);
                oper.CloseDocument();
            }
        }

      

        private List<string> GetAllSelectValues()
        {
            List<string> lstSelectedRowBasCode = new List<string>();
            foreach (DataGridViewRow dgvr in ucDataGridView1.Rows)
            {
                if (dgvr.Selected)
                {
                    lstSelectedRowBasCode.Add(dgvr.Cells["BUSINESS_CODE"].Value.ToString());
                }
            }
            if (lstSelectedRowBasCode.Count == 0)
            {
                ShowHowToSelectValues();
            }
            return lstSelectedRowBasCode;
        }

        private void ShowHowToSelectValues()
        {
            MessageBoxEx.Show("要选择数据需要用鼠标点击行首的灰色小框，如果希望选择多条，可以按住ctrl选择或直接按住右键拖选！", "提示--如何选中数据");
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("冲账业务影响重大请确认是否操作", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            //将选择的数据，其中状态是已经发送成功的，进行冲账，并发送冲账记录
            //找到所有选择的记录
            List<string> lstSelectedRowBasCode = GetAllSelectValues();
            int stateCode;
            string err;
            List<string> sqls = new List<string>();
            foreach (string busCode in lstSelectedRowBasCode)
            {
                if (!SAPFunction.Services.SAPFunctionOperation.Instance.ReverseAccount(busCode, out stateCode, out  err))
                {
                    return;
                }
            }
            ReloadData();
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("修改当前选中数据的发生时间和实际入账时间，调整为上月最后一天，是否确认", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            //找到所有选择的记录
            List<string> lstSelectedRowBasCode = GetAllSelectValues();
            string err;
            List<string> sqls = new List<string>();
            foreach (string busCode in lstSelectedRowBasCode)
            {
                if (!SAPFunction.Services.SAPFunctionOperation.Instance.ResetDateToLastMonth(busCode, out  err))
                {
                    return;
                }
            }
            ReloadData();
        }

        ///// <summary>
        ///// 作废.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnLeft_Click(object sender, EventArgs e)
        //{
        //    string err;
        //    if (string.IsNullOrEmpty(selection))
        //        return;
        //    DataTable dt = MessageHeaderService.Instance.getInfo(selection, out err);
        //    if (dt.Rows.Count > 0)
        //    {
        //        MessageHeader mh = MessageHeaderService.Instance.getObject(dt.Rows[0]);
        //        if (mh.STATUS == "6")
        //        {
        //            return;
        //        }
        //        mh.STATUS = "6";
        //        if (!MessageHeaderService.Instance.saveUnit(mh, out err))
        //        {
        //            MessageBoxEx.Show(err, "作废失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //    }
        //    MessageBoxEx.Show("作废成功");
        //    if (!ReloadData(out err))
        //        return;
        //}
    }
}
