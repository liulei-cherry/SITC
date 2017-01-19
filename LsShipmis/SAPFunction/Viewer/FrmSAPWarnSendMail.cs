using CommonViewer.BaseForm;
using SAPFunction.DataObject;
using SAPFunction.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAPFunction.Viewer
{
    public partial class FrmSAPWarnSendMail : FormBase
    {
        #region 窗体变量
        public String errMessage = String.Empty;
        #endregion

        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSAPWarnSendMail instance = new FrmSAPWarnSendMail();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSAPWarnSendMail Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSAPWarnSendMail.instance = new FrmSAPWarnSendMail();
                }
                return FrmSAPWarnSendMail.instance;
            }
        }
        #endregion

        #region 构造方法
        public FrmSAPWarnSendMail()
        {
            InitializeComponent();
        }
        #endregion

        #region 画面初始化
        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSAPWarnSendMail_Load(object sender, EventArgs e)
        {
            this.InitializeData();
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 添加明细行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                bindingSourceMain.AddNew(); //执行添加记录功能.
                dgvMain.CurrentRow.Cells["IsStart"].Value = true;
            }
            else
            {
                if (!HasEmptyVal("MailAlertSendIndex", dgvMain) && !HasEmptyVal("MailAlertSendTitle", dgvMain) && !HasEmptyVal("MailAlertAddress", dgvMain))
                {
                    if (dgvMain.Rows.Count < 5)
                    {
                        bindingSourceMain.AddNew(); //执行添加记录功能.
                        dgvMain.CurrentRow.Cells["IsStart"].Value = true;
                    }
                    else
                    {
                        MessageBox.Show("SAP报警只能添加5条报警邮件信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 删除明细行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (bindingSourceMain.Current != null)
            {
                if (MessageBox.Show("确定要删除吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }



                String businessId = dgvMain.CurrentRow.Cells["MailAlertDetailId"].Value.ToString();

                SAPWarnSendMailService.Instance.DeleteMailAlertDetail(businessId,out errMessage);

                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();

                //DataSet dstWarnDeatil = new DataSet();
                //dstWarnDeatil.ReadXml(xmlWarnDetailPath);
                ////从BindingSource组件中取得信息集放到DataTable中去.
                //DataTable dtbMailWarn_Detail = (DataTable)bindingSourceMain.DataSource;

                //try
                //{
                //    //保存邮件报警信息还点信息.
                //    dtbMailWarn_Detail.TableName = this.selectShipId;
                //    if (dstWarnDeatil.Tables[this.selectShipId] != null)
                //    {
                //        dstWarnDeatil.Tables[this.selectShipId].Clear();
                //        foreach (DataRow dr in dtbMailWarn_Detail.Rows)
                //        {
                //            DataRow detail = dstWarnDeatil.Tables[this.selectShipId].NewRow();
                //            detail["Start"] = dr["Start"];
                //            detail["ShipNumb"] = dr["ShipNumb"];
                //            detail["ShipName"] = dr["ShipName"];
                //            detail["TransFerMail"] = dr["TransFerMail"];
                //            dstWarnDeatil.Tables[this.selectShipId].Rows.Add(detail);
                //        }
                //    }

                //    dstWarnDeatil.WriteXml(xmlWarnDetailPath);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateMainTableData() == false) { return; }

            if (this.ValidateDetailTableData() == false) { return; }

            MailAlertModel mainModel = new MailAlertModel();

            mainModel.MailAlertId = Guid.NewGuid().ToString().ToUpper();
            mainModel.MailAlertSiteName = txtSpotWarnName.Text;
            mainModel.SSLPort = Int32.Parse(txtSSLWarnPort.Text);
            mainModel.SmtpServer = txtSmtpWarnServer.Text;
            mainModel.SmtpUserName = txtSmtpWarnUserName.Text;
            mainModel.MailPass = txtWarnPassword.Text;

            List<MailAlertDetailModel> MAM = new List<MailAlertDetailModel>();
            for (int i = 0, rowCount = dgvMain.RowCount; i < rowCount; i++)
            {
                MailAlertDetailModel detailModel = new MailAlertDetailModel();
                detailModel.MailAlertDetailId = Guid.NewGuid().ToString();
                detailModel.MailAlertId = mainModel.MailAlertId;
                detailModel.MailAlertSendIndex = dgvMain.Rows[i].Cells["MailAlertSendIndex"].Value.ToString();
                detailModel.MailAlertSendTitle = dgvMain.Rows[i].Cells["MailAlertSendTitle"].Value.ToString();
                detailModel.MailAlertAddress = dgvMain.Rows[i].Cells["MailAlertAddress"].Value.ToString();
                detailModel.IsSend = dgvMain.Rows[i].Cells["Start"].Value.ToString() == "1" ? 1 : 0;
                detailModel.MailAlertType = 1;
                MAM.Add(detailModel);
            }
            if (SAPWarnSendMailService.Instance.SaveMailAlertTable(mainModel, MAM, out errMessage))
            {
                MessageBox.Show("保存成功！");
            }
            else { MessageBox.Show("保存失败，错误原因如下：" +errMessage); }
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 窗体方法

        private Boolean ValidateMainTableData()
        {
            if (txtSpotWarnName.Text.Trim().Length == 0)
            {
                MessageBox.Show("站点名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpotWarnName.Focus();
                return false;
            }
            if (txtSmtpWarnServer.Text.Trim().Length == 0)
            {
                MessageBox.Show("SMTP服务器是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSmtpWarnServer.Focus();
                return false;
            }

            if (txtSmtpWarnUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("SMTP用户名是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSmtpWarnUserName.Focus();
                return false;
            }

            if (txtSSLWarnPort.Text.Trim().Length == 0)
            {
                MessageBox.Show("端口号是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSSLWarnPort.Focus();
                return false;
            }

            if (txtWarnPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("邮件密码是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWarnPassword.Focus();
                return false;
            }

            return true;
        }

        private Boolean ValidateDetailTableData()
        {
            if (dgvMain.Rows.Count == 0)
            {
                MessageBox.Show("邮件发送列表中不存在任何需要保持的数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (IsEmpty(dgvMain, "MailAlertSendIndex") == true)
            {
                MessageBox.Show("序列号是必须填写的内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (IsEmpty(dgvMain, "MailAlertSendTitle") == true)
            {
                MessageBox.Show("用户名是必须填写的内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (IsEmpty(dgvMain, "MailAlertAddress") == true)
            {
                MessageBox.Show("发送邮箱是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 邮件报警设置初始化取值
        /// </summary>
        private void InitializeData()
        {
            #region 读取配置


            String errMessage = String.Empty;

            DataTable dtmailsource = SAPWarnSendMailService.Instance.SelectMailAlertTable(out errMessage);
            if (dtmailsource.Rows.Count > 0)
            {
                txtSpotWarnName.Text = dtmailsource.Rows[0]["MailAlertSiteName"] == null ? "" : dtmailsource.Rows[0]["MailAlertSiteName"].ToString();
                txtSmtpWarnServer.Text = dtmailsource.Rows[0]["SmtpServer"] == null ? "" : dtmailsource.Rows[0]["SmtpServer"].ToString();
                txtSmtpWarnUserName.Text = dtmailsource.Rows[0]["SmtpUserName"] == null ? "" : dtmailsource.Rows[0]["SmtpUserName"].ToString();
                txtWarnPassword.Text = dtmailsource.Rows[0]["MailPass"] == null ? "" : dtmailsource.Rows[0]["MailPass"].ToString();
                txtSSLWarnPort.Text = dtmailsource.Rows[0]["SSLPort"] == null ? "" : dtmailsource.Rows[0]["SSLPort"].ToString();
            }
            DataTable dt = new DataTable();
            dt = SAPWarnSendMailService.Instance.SelectMailAlertDetailTable(1, out errMessage);
            bindingSourceMain.DataSource = dt;
            dgvMain.DataSource = bindingSourceMain;
            this.InitializeStyle();
            #endregion
        }

        /// <summary>
        /// 设置邮件报警信息网格的各个列名
        /// </summary>
        private void InitializeStyle()
        {

            //添加一个CheckBox的启动列.
            if (dgvMain.Columns["IsStart"] == null)
            {
                DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
                chkcol.Width = 40;
                chkcol.Name = "IsStart";
                chkcol.HeaderText = "启动";
                chkcol.DataPropertyName = "Start";
                dgvMain.Columns.Insert(0, chkcol);
            }


            dgvMain.Columns["Start"].Visible = false;
            dgvMain.Columns["MailAlertSendIndex"].HeaderText = "序列号";
            dgvMain.Columns["MailAlertSendTitle"].HeaderText = "用户名";
            dgvMain.Columns["MailAlertAddress"].HeaderText = "发送报警邮箱";
            dgvMain.Columns["MailAlertSendIndex"].Width = 90;
            dgvMain.Columns["MailAlertSendTitle"].Width = 90;
            dgvMain.Columns["MailAlertAddress"].Width = 180;

            dgvMain.Columns["MailAlertDetailId"].Visible = false;
            dgvMain.Columns["MailAlertId"].Visible = false;
            dgvMain.Columns["MailAlertType"].Visible = false;
            this.SetDataGridViewNoSort(dgvMain);

        }

        /// <summary>
        /// 取消指定的DataGridView组件的各个列的排序功能.
        /// </summary>
        /// <param name="dgv">要取消列排序功能的DataGridView组件</param>
        public void SetDataGridViewNoSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        /// <summary>
        /// 判断网格dgv的列colname中是否存在为空的单元格，如果有则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值</returns>
        public bool IsEmpty(DataGridView dgv, string colname)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString();
                if (sCurCell.Trim().Length == 0 || sCurCell == "0")
                {
                    blnResult = true;
                    break;
                }
            }

            return blnResult;
        }

        /// <summary>
        /// 判断网格dgv的列colname中是否存在不为空的单元格，如果有则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值，如果存在一个不为空的单元格，则返回true，全空返回false</returns>
        public bool HasEmptyVal(string ColumnName, DataGridView dgvView)
        {
            bool blnResult = true;
            DataGridViewRow dgvRow = dgvView.Rows[dgvView.Rows.Count - 1];

            string sCurCell = dgvRow.Cells[ColumnName].Value.ToString();
            if (sCurCell.Trim().Length > 0)
            {
                blnResult = false;
            }

            return blnResult;
        }
        #endregion
    }
}
