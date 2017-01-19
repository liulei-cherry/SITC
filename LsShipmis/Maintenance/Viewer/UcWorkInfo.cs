using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Functions;
using ItemsManage.Viewer;
using CommonOperation.Enum;
using ItemsManage.DataObject;
using ItemsManage.Services;
using Maintenance.DataObject;
using Maintenance.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class UcWorkInfo : UserControl
    {
        public UcWorkInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用户控件显示的工作信息对象.
        /// </summary>
        private ComponentUnit component_unit; //2009.5.20 夏喜龙 添加.

        public ComponentUnit Component_unit
        {
            get { return component_unit; }
            set
            {
                component_unit = value;
                if (component_unit != null && !component_unit.IsWrong)
                {
                    txtReferEquip.Text = component_unit.ToString();
                }
            }
        }

        private WorkInfo workInfo;

        /// <summary>
        /// 工作信息对象.
        /// </summary>
        public WorkInfo WorkInfo
        {
            get { return workInfo; }
            set
            {
                workInfo = value;
                if (null == value)
                {
                    this.setControlsDisable(true);
                    return;
                }
                showWorkInfo();
            }
        }

        /// <summary>
        /// 将私有对象component(设备)信息显示到窗体上.
        /// </summary>
        private void showComponent()
        {
            string err;

            if (workInfo != null && workInfo.WORKINFOID != null && workInfo.REFOBJID != null)
            {
                component_unit = ComponentUnitService.Instance.getObject(workInfo.REFOBJID, out err);
            }
            if (component_unit != null && component_unit.COMP_CHINESE_NAME != "")
            {
                txtReferEquip.Text = component_unit.COMP_CHINESE_NAME;
            }
            else
            {
                txtReferEquip.Text = "";
            }

        }

        /// <summary>
        /// 禁止工作挂接设备按钮.
        /// </summary>
        public void stopComponentBtn()
        {
            btnReferEquip.Visible = false;
            btnClear.Visible = false;
        }

        /// <summary>
        /// 将私有对象workInfo信息显示到窗体上.
        /// </summary>
        private void showWorkInfo()
        {

            //设置设备的中文名称.
            showComponent();        //显示设备信息.

            txtWkName.Text = workInfo.WORKINFONAME;
            int workInfoState = (int)workInfo.WORKINFOSTATE;
            txtWorkInfoNo.Text = workInfo.WORKINFOCODE;
            if (workInfo.PRINCIPALPOST != "")
            {
                cboResponerHeadship.SelectedId(workInfo.PRINCIPALPOST);//责任人岗位.
            }
            if (workInfo.CONFIRMPOST != "")
            {
                cboConfirmHeadship.SelectedId(workInfo.CONFIRMPOST);//确认岗位.
            }

            if (workInfoState == 1) //运行或停止.
            {
                btnStopStartWork.Text = "已启动";
            }
            else
            {
                btnStopStartWork.Text = "已停止";
            }

            int check = (int)workInfo.ISCHECKPROJECT;
            if (check == 1)                 //是否是检验.
            {
                cbCheck.Checked = true;
            }
            else
            {
                cbCheck.Checked = false;
            }

            int repair = (int)workInfo.ISREPAIRPROJECT;
            if (repair == 1)                //是否是维修.
            {
                cbRepair.Checked = true;
            }
            else
            {
                cbRepair.Checked = false;
            }

            int timing = (int)workInfo.CIRCLEORTIMING; //计时类型：定期 1;定时 2；定期并且定时 3;非周期 4；.
            if (timing == 1)
            {
                cbNoCycle.Checked = false;
                cbTime.Checked = false;
                cbCycle.Checked = true;
            }
            else if (timing == 2)
            {
                cbNoCycle.Checked = false;
                cbTime.Checked = true;
                cbCycle.Checked = false;
            }
            else if (timing == 3)
            {
                cbNoCycle.Checked = false;
                cbTime.Checked = true;
                cbCycle.Checked = true;
            }
            else if (timing == 4)
            {
                cbNoCycle.Checked = true;
                cbTime.Checked = false;
                cbCycle.Checked = false;
            }

            //定期数据.
            txtCCycle.Text = workInfo.CIRCLEPERIOD.ToString();

            if (workInfo.CIRCLEUNIT.Trim() != "")
            {
                cboxCycle.Text = workInfo.CIRCLEUNIT.Trim();    //定期单位.
            }

            txtCToleranceBefore.Text = workInfo.CIRCLEFRONTLIMIT.ToString();
            txtCToleranceAfter.Text = workInfo.CIRCLEBACKLIMIT.ToString();

            if (workInfo.CIRCLELIMITUNIT.Trim() != "")
            {
                cboxBefore.Text = workInfo.CIRCLELIMITUNIT.Trim();
            }

            //定时数据.
            txtTCycle.Text = workInfo.TIMINGPERIOD.ToString();
            txtTToleranceBefore.Text = workInfo.TIMINGFRONTLIMIT.ToString();
            txtTToleranceAfter.Text = workInfo.TIMINGBACKLIMIT.ToString();

            // 工作详细描述.
            if (workInfo.WORKINFODETAIL == null)
            {
                txtWkDescription.Text = "";
            }
            else
            {
                txtWkDescription.Text = workInfo.WORKINFODETAIL.ToString();
            }

        }

        /// <summary>
        /// 设置控件是否可编辑.
        /// </summary>
        /// <param name="isTrue">true不可编辑false可编辑</param>
        public void setControlsDisable(bool isTrue)
        {
            if (isTrue)
            {
                txtReferEquip.ReadOnly = true;
                btnReferEquip.Enabled = false;
                btnClear.Enabled = false;
                txtWkName.ReadOnly = true;
                txtWorkInfoNo.ReadOnly = true;
                cboResponerHeadship.Enabled = false;
                cboConfirmHeadship.Enabled = false;
                cbNoCycle.Enabled = false;
                cbCheck.Enabled = false;
                cbRepair.Enabled = false;
                cbTime.Enabled = false;
                cbCycle.Enabled = false;

                //定时周期.
                txtTCycle.ReadOnly = true;
                txtTToleranceBefore.ReadOnly = true;
                txtTToleranceAfter.ReadOnly = true;

                //定期周期.
                txtCCycle.ReadOnly = true;
                txtCToleranceBefore.ReadOnly = true;
                txtCToleranceAfter.ReadOnly = true;
                cboxCycle.Enabled = false;
                cboxBefore.Enabled = false;

                txtWkDescription.ReadOnly = true;
            }
            else
            {
                txtReferEquip.ReadOnly = true;
                btnReferEquip.Enabled = true;
                btnClear.Enabled = true;
                txtWkName.ReadOnly = false;
                txtWorkInfoNo.ReadOnly = false;
                cboResponerHeadship.Enabled = true;
                cboConfirmHeadship.Enabled = true;
                cbCheck.Enabled = true;
                cbRepair.Enabled = true;
                cbNoCycle.Enabled = true;
                cbTime.Enabled = true;
                cbCycle.Enabled = true;

                //非周期.
                if (cbNoCycle.Checked)
                {
                    cbTime.Checked = false;
                    cbTime.Enabled = false;
                    cbCycle.Checked = false;
                    cbCycle.Enabled = false;
                }

                //定时周期.
                if (cbTime.Checked)
                {
                    txtTCycle.ReadOnly = false;
                    txtTToleranceBefore.ReadOnly = false;
                    txtTToleranceAfter.ReadOnly = false;
                }

                //定期周期.
                if (cbCycle.Checked)
                {
                    txtCCycle.ReadOnly = false;
                    txtCToleranceBefore.ReadOnly = false;
                    txtCToleranceAfter.ReadOnly = false;
                    cboxCycle.Enabled = true;
                    cboxBefore.Enabled = true;
                }

                txtWkDescription.ReadOnly = false;
            }

            //btnMeasureReportTemplate.Visible = true;
            //btnRefSpare.Visible = true;
            //btnReplaceWork.Visible = true;
            //btnStopStartWork.Visible = true;
        }

        /// <summary>
        /// 添加时对控件初始化.
        /// </summary>
        public void addRefrshControls()
        {
            txtReferEquip.Text = "";
            txtWkName.Text = "";
            txtWorkInfoNo.Text = "";
            cboResponerHeadship.Text = "";
            cboConfirmHeadship.Text = "";

            cbCheck.Checked = false;
            cbRepair.Checked = false;
            cbTime.Checked = false;
            cbCycle.Checked = false;

            //定时周期.
            txtTCycle.Text = "0";
            txtTToleranceBefore.Text = "0";
            txtTToleranceAfter.Text = "0";

            //定期周期.
            txtCCycle.Text = "0";
            txtCToleranceBefore.Text = "0";
            txtCToleranceAfter.Text = "0";

            txtWkDescription.Text = "";

        }

        /// <summary>
        /// 添加默认参数.
        /// </summary>
        private void AddWkInfo()
        {
            workInfo = (WorkInfo)workInfo.Clone();
            workInfo.WORKINFOID = null;
            addRefrshControls();

        }

        /// <summary>
        /// 从界面获取数据保存到对象T_WORKINFO 中.
        /// </summary>
        private void FormToObject()
        {
            if (workInfo == null)
            {
                return;
            }

            if (btnStopStartWork.Text == "已启动")
            {
                workInfo.WORKINFOSTATE = 1;
            }
            else
            {
                workInfo.WORKINFOSTATE = 0;
            }

            if (component_unit != null && component_unit.COMPONENT_UNIT_ID != null)
            {
                workInfo.WORKINFOTYPE = 1;
                workInfo.REFOBJID = component_unit.COMPONENT_UNIT_ID;
            }
            workInfo.WORKINFONAME = txtWkName.Text;
            workInfo.PRINCIPALPOST = cboResponerHeadship.GetId();
            workInfo.CONFIRMPOST = cboConfirmHeadship.GetId();
            workInfo.WORKINFOCODE = txtWorkInfoNo.Text;

            //检验和维修.
            if (cbCheck.Checked)
            {
                workInfo.ISCHECKPROJECT = 1;
            }
            else
            {
                workInfo.ISCHECKPROJECT = 0;
            }

            if (cbRepair.Checked)
            {
                workInfo.ISREPAIRPROJECT = 1;
            }
            else
            {
                workInfo.ISREPAIRPROJECT = 0;
            }

            //非周期.
            if (cbNoCycle.Checked)
            {
                workInfo.CIRCLEORTIMING = 4;

                workInfo.CIRCLEPERIOD = 0;
                workInfo.CIRCLEFRONTLIMIT = 0;
                workInfo.CIRCLEBACKLIMIT = 0;

                workInfo.TIMINGPERIOD = 0;
                workInfo.TIMINGFRONTLIMIT = 0;
                workInfo.TIMINGBACKLIMIT = 0;
            }

            //定时和定期.
            if (cbCycle.Checked && !cbTime.Checked)     //定期.
            {
                workInfo.CIRCLEORTIMING = 1;
                workInfo.CIRCLEPERIOD = decimal.Parse(txtCCycle.Text);
                workInfo.CIRCLEUNIT = cboxCycle.Text;
                workInfo.CIRCLEFRONTLIMIT = decimal.Parse(txtCToleranceBefore.Text);
                workInfo.CIRCLEBACKLIMIT = decimal.Parse(txtCToleranceAfter.Text);
                workInfo.CIRCLELIMITUNIT = cboxBefore.Text;
                decimal zq;
                if (decimal.TryParse(txtTCycle.Text, out zq))
                    workInfo.TIMINGPERIOD = zq;
                else
                    workInfo.TIMINGPERIOD = 0;
                workInfo.TIMINGFRONTLIMIT = 0;
                workInfo.TIMINGBACKLIMIT = 0;
            }
            else if (!cbCycle.Checked && cbTime.Checked)    //定时.
            {
                workInfo.CIRCLEORTIMING = 2;
                workInfo.TIMINGPERIOD = decimal.Parse(txtTCycle.Text);
                workInfo.TIMINGFRONTLIMIT = decimal.Parse(txtTToleranceBefore.Text);
                workInfo.TIMINGBACKLIMIT = decimal.Parse(txtTToleranceAfter.Text);

                workInfo.CIRCLEPERIOD = 0;
                workInfo.CIRCLEFRONTLIMIT = 0;
                workInfo.CIRCLEBACKLIMIT = 0;

            }
            else if (cbCycle.Checked && cbTime.Checked)
            {
                workInfo.CIRCLEORTIMING = 3;
                workInfo.CIRCLEPERIOD = decimal.Parse(txtCCycle.Text);
                workInfo.CIRCLEUNIT = cboxCycle.Text;
                workInfo.CIRCLEFRONTLIMIT = decimal.Parse(txtCToleranceBefore.Text);
                workInfo.CIRCLEBACKLIMIT = decimal.Parse(txtCToleranceAfter.Text);
                workInfo.CIRCLELIMITUNIT = cboxBefore.Text;
                workInfo.TIMINGPERIOD = decimal.Parse(txtTCycle.Text);
                workInfo.TIMINGFRONTLIMIT = decimal.Parse(txtTToleranceBefore.Text);
                workInfo.TIMINGBACKLIMIT = decimal.Parse(txtTToleranceAfter.Text);
            }

            workInfo.WORKINFODETAIL = txtWkDescription.Text;
        }

        /// <summary>
        /// 新增或修改对象的保存方法.
        /// 如果主键id＝null or ＝"" 则为新增.
        /// </summary>
        /// <returns></returns>
        public bool saveWk(out string err)
        {
            if (!WkCheck())
            {
                err = "";
                return false;
            }
            this.FormToObject();      //从界面获取数据到对象中.

            if (!ifEquipOfTimingInit()) //是否已定时初始化.
            {
                err = "";
                return false;
            }

            if (workInfo.Update(out err))
            {
                MessageBoxEx.Show("保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBoxEx.Show("保存失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 定时设备是否正确初始化.
        /// </summary>
        public bool ifEquipOfTimingInit()
        {
            String err;
            if (workInfo.CIRCLEORTIMING == 2 || workInfo.CIRCLEORTIMING == 3)
            {
                //定时设备是否已经初始化.
                if (!WorkInfoService.Instance.IfHaveGauge(component_unit, out err))
                {
                    MessageBoxEx.Show("设备没有定时初始化,请对此设备进行定时初始化!\r" + (err.Length > 0 ? err : ""),
                        "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return true;
        }

        private bool WkCheck()
        {
            string err;
            List<TextBox> lstTextBox = new List<TextBox>();
            lstTextBox.Add(txtWkName);

            if (cbCycle.Checked == true)
            {
                lstTextBox.Add(txtCCycle);
                lstTextBox.Add(txtCToleranceBefore);
                lstTextBox.Add(txtCToleranceAfter);
            }

            if (cbTime.Checked == true)
            {
                lstTextBox.Add(txtTCycle);
                lstTextBox.Add(txtTToleranceBefore);
                lstTextBox.Add(txtTToleranceAfter);
            }

            lstTextBox.Add(txtWkDescription);

            foreach (TextBox tempBox in lstTextBox)
            {

                if (IfEmpty(tempBox, out err))
                {
                    MessageBoxEx.Show(err, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempBox.Focus();
                    return false;
                }
            }

            List<TextBox> lstTextInt = new List<TextBox>();
            List<TextBox> lstTextIntB = new List<TextBox>();//数字要求大于0

            if (cbCycle.Checked == true)
            {
                lstTextIntB.Add(txtCCycle);
                lstTextInt.Add(txtCToleranceBefore);
                lstTextInt.Add(txtCToleranceAfter);
            }

            if (cbTime.Checked == true)
            {
                lstTextIntB.Add(txtTCycle);
                lstTextInt.Add(txtTToleranceBefore);
                lstTextInt.Add(txtTToleranceAfter);
            }

            foreach (TextBox tempBox in lstTextIntB)
            {
                if (IfHaveNotNumB(tempBox, typeof(int), out err))
                {
                    MessageBoxEx.Show(err, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempBox.Focus();
                    return false;
                }
            }

            foreach (TextBox tempBox in lstTextInt)
            {
                if (IfHaveNotNum(tempBox, typeof(int), out err))
                {
                    MessageBoxEx.Show(err, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempBox.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(cboResponerHeadship.GetId()))
            {
                MessageBoxEx.Show("责任人岗位不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboResponerHeadship.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboConfirmHeadship.GetId()))
            {
                MessageBoxEx.Show("确认者岗位不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboConfirmHeadship.Focus();
                return false;
            }

            if (!cbTime.Checked && !cbCycle.Checked && !cbNoCycle.Checked)
            {
                MessageBoxEx.Show("请选择非周期、定期和定时至少其中一种!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (cbTime.Checked && txtReferEquip.Text.Length == 0)
            {
                MessageBoxEx.Show("定时工作必须关联设备!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnReferEquip.Focus();
                return false;
            }

            return true;
        }

        private bool IfEmpty(TextBox textBox, out string err)
        {
            err = "";
            if (textBox.Text.Trim().Equals("") && textBox.Visible == true)
            {
                err = "该信息不能为空！";

                return true;
            }
            return false;
        }
        public bool IfHaveNotNum(TextBox textBox, Type type, out string err)
        {
            err = "输入数值数据类型不正确！";

            if (type.Equals(typeof(int)))
            {
                int temp;
                if (int.TryParse(textBox.Text, out temp))
                {

                    return false;
                }

            }
            else if (type.Equals(typeof(long)))
            {
                long temp;
                if (long.TryParse(textBox.Text, out temp))
                {
                    return false;
                }
            }
            else if (type.Equals(typeof(double)))
            {
                double temp;
                if (double.TryParse(textBox.Text, out temp))
                {
                    return false;
                }
            }
            else if (type.Equals(typeof(decimal)))
            {
                decimal temp;
                if (decimal.TryParse(textBox.Text, out temp))
                {
                    return false;
                }
            }
            else if (type.Equals(typeof(ulong)))
            {
                ulong temp;
                if (ulong.TryParse(textBox.Text, out temp))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IfHaveNotNumB(TextBox textBox, Type type, out string err)
        {
            err = "输入数值数据类型不正确！";
            string errMess = "输入数值要大于零！";

            if (type.Equals(typeof(int)))
            {
                int temp;
                if (int.TryParse(textBox.Text, out temp))
                {
                    if (temp < 1)
                    {
                        err = errMess;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else if (type.Equals(typeof(long)))
            {
                long temp;
                if (long.TryParse(textBox.Text, out temp))
                {
                    if (temp < 1)
                    {
                        err = errMess;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (type.Equals(typeof(double)))
            {
                double temp;
                if (double.TryParse(textBox.Text, out temp))
                {
                    if (temp < 1)
                    {
                        err = errMess;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (type.Equals(typeof(decimal)))
            {
                decimal temp;
                if (decimal.TryParse(textBox.Text, out temp))
                {
                    if (temp < 1)
                    {
                        err = errMess;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (type.Equals(typeof(ulong)))
            {
                ulong temp;
                if (ulong.TryParse(textBox.Text, out temp))
                {
                    if (temp < 1)
                    {
                        err = errMess;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public delegate void CancelWork();
        public event CancelWork cancelWork;

        private void UcWorkInfoII_Load(object sender, EventArgs e)
        {
            checkRight();
            cboConfirmHeadship.ChangeSelectedState(false, true, true);
            cboResponerHeadship.ChangeSelectedState(false, false, true);
            cboxCycle.Text = "月";
            cboxBefore.Text = "月";
        }

        private void checkRight()
        {
            ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
            string sChkMessage = "";
            bool canEdit = proxyRight.CheckRight(CommonOperation.ConstParameter.OPERATION_PMS, out sChkMessage);

            btnStopStartWork.Enabled = canEdit;
            btnReplaceWork.Enabled = canEdit;
            btnRefSpare.Enabled = canEdit;
            btnMeasureReportTemplate.Enabled = canEdit;
            btnReferEquip.Enabled = canEdit;
        }

        /// <summary>
        /// 启动或停止工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopStartWork_Click(object sender, EventArgs e)
        {
            if (!CheckAndSaveItem()) return;

            DialogResult result;
            string err = "";
            if (WorkInfo.WORKINFOSTATE == 1)
            {
                int deleteType = 0;
                #region 停止工作
                if (WorkInfoService.Instance.getLeftValidWork(workInfo.WORKINFOID) > 0)
                {
                    result = MessageBoxEx.Show("该工作信息有未完成的工单，删除已经列入计划的工单信息吗?", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        deleteType = 1;
                        btnStopStartWork.Text = "已停止";
                    }
                }
                else
                {
                    result = MessageBoxEx.Show("确定停止选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        btnStopStartWork.Text = "已停止";
                    }

                }

                //是否删除已经该工作信息已列入计划的工作，1删除，0不删除.
                if (WorkInfoService.Instance.cancelWorkInfo(workInfo, deleteType, out err))
                {
                    MessageBoxEx.Show("工作定义停止成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (cancelWork != null)
                        cancelWork();
                }
                else
                {
                    MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
            else
            {
                #region 启动工作
                result = MessageBoxEx.Show("确定启动选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    workInfo.WORKINFOSTATE = 1;
                    if (workInfo.Update(out err))
                    {
                        MessageBoxEx.Show("工作定义启动成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnStopStartWork.Text = "已启动";

                        if (cancelWork != null)
                            cancelWork();
                    }
                    else
                    {
                        MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// 替代工作维护.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplaceWork_Click(object sender, EventArgs e)
        {
            if (!CheckAndSaveItem()) return;
            FrmReplaceWork frm = new FrmReplaceWork();
            frm.WorkInfo = null;
            frm.WorkInfo = workInfo;
            frm.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("工作信息是日常工作的模板,并非具体任务,通常我们根据设备的说明书初始化工作信息!\n安排某工作信息,可以形成这条工作信息的执行任务!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 工作报告工作模板.
        /// </summary>
        private void btnMeasureReportTemplate_Click(object sender, EventArgs e)
        {
            if (!CheckAndSaveItem()) return;
            FrmMeasureReportTemplate frm = new FrmMeasureReportTemplate(workInfo);
            frm.ShowDialog();
        }

        /// <summary>
        /// 备件信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefSpare_Click(object sender, EventArgs e)
        {
            if (!CheckAndSaveItem()) return;
            FrmWorkInfoSpare frm = new FrmWorkInfoSpare(workInfo);
            frm.ShowDialog();
        }

        /// <summary>
        /// 关联工作信息到设备.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferEquip_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm = new FrmSelectComponent(workInfo.SHIP_ID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm_nodeSelect(frm.Equipment);
            }
        }

        void frm_nodeSelect(ComponentUnit component)
        {
            if (component == null) return;
            component_unit = component;
            txtReferEquip.Text = component_unit.COMP_CHINESE_NAME;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string err;
            if (component_unit == null)
            {
                MessageBoxEx.Show("无设备挂接!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                component_unit = null;
                if (workInfo != null)
                {
                    workInfo.WORKINFOTYPE = 1;
                    workInfo.REFOBJID = "";
                    if (workInfo.Update(out err))
                    {
                        txtReferEquip.Text = "";
                        MessageBoxEx.Show("设备与工作已取消挂接!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void cbNoCycle_Click(object sender, EventArgs e)
        {
            if (cbNoCycle.Checked)
            {
                cbCycle.Checked = false;
                cbCycle.Enabled = false;
                cbTime.Checked = false;
                cbTime.Enabled = false;

                //定期周期.
                txtCCycle.Text = "";
                txtCToleranceBefore.Text = "";
                txtCToleranceAfter.Text = "";

                txtCCycle.ReadOnly = true;
                txtCToleranceBefore.ReadOnly = true;
                txtCToleranceAfter.ReadOnly = true;

                cboxCycle.Enabled = false;
                cboxBefore.Enabled = false;

                //定时周期.
                txtTCycle.Text = "";
                txtTToleranceBefore.Text = "";
                txtTToleranceAfter.Text = "";

                setTimeEnable(false);
            }
            else if (!cbNoCycle.Checked)
            {
                cbCycle.Enabled = true;
                cbTime.Enabled = true;
            }
        }

        private void cbCycle_Click(object sender, EventArgs e)
        {
            if (cbCycle.Checked)
            {
                //定期周期.
                txtCCycle.ReadOnly = false;
                txtCToleranceBefore.ReadOnly = false;
                txtCToleranceAfter.ReadOnly = false;

                cboxCycle.Enabled = true;
                cboxBefore.Enabled = true;
            }
            else if (!cbCycle.Checked)
            {
                //定期周期.
                txtCCycle.Text = "";
                txtCToleranceBefore.Text = "";
                txtCToleranceAfter.Text = "";

                txtCCycle.ReadOnly = true;
                txtCToleranceBefore.ReadOnly = true;
                txtCToleranceAfter.ReadOnly = true;

                cboxCycle.Enabled = false;
                cboxBefore.Enabled = false;
            }
        }

        private void cbTime_Click(object sender, EventArgs e)
        {
            if (cbTime.Checked)
            {
                setTimeEnable(true);
            }
            else if (!cbTime.Checked)
            {
                txtTCycle.Text = "";
                txtTToleranceBefore.Text = "";
                txtTToleranceAfter.Text = "";

                setTimeEnable(false);
            }
        }

        private void setTimeEnable(bool flag)
        {
            if (flag == true)
            {
                txtTCycle.ReadOnly = false;
                txtTToleranceBefore.ReadOnly = false;
                txtTToleranceAfter.ReadOnly = false;
            }
            else
            {
                txtTCycle.ReadOnly = true;
                txtTToleranceBefore.ReadOnly = true;
                txtTToleranceAfter.ReadOnly = true;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (!CheckAndSaveItem()) return;
            FrmFinishedWorkOrderView frm = new FrmFinishedWorkOrderView(workInfo);
            frm.ShowDialog();

        }

        private bool CheckAndSaveItem()
        {
            if (workInfo == null) return false;
            if (string.IsNullOrEmpty(workInfo.GetId()))
            {
                if (MessageBoxEx.Show("当前工作信息没有保存,无法执行进一步操作,\r请点击下面按钮完成进一步操作,\r是:保存,并执行下一步操作;\r否:不做任何处理",
                    "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string err;
                    if (!this.saveWk(out  err))
                        return false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return true;
        }
        private void cboResponerHeadship_TheSelectedChanged(string theSelectedObject)
        {
            string err;
            Post thePost;
            if (string.IsNullOrEmpty(theSelectedObject))
            {
                string sPrincipalPostName = cboResponerHeadship.GetText();
                thePost = (Post)PostService.Instance.GetOneObjectByName(sPrincipalPostName);
            }
            else
            {
                thePost = PostService.Instance.getObject(theSelectedObject, out err);
            }
            Post theLeaderPost;
            if (thePost != null && PostService.Instance.GetDepartLeaderPost(thePost.DEPARTMENTID, out theLeaderPost, out err) && theLeaderPost != null)
            {
                cboConfirmHeadship.Text = theLeaderPost.POSTNAME;
            }
            else
            {
                cboConfirmHeadship.Text = "";
            }
        }
    }

}
