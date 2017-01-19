using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;  

namespace Maintenance.Viewer
{
    public partial class FrmSetGaugeType : CommonViewer.BaseForm.FormBase
    {

        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSetGaugeType instance = new FrmSetGaugeType();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSetGaugeType Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSetGaugeType.instance = new FrmSetGaugeType();
                }

                return FrmSetGaugeType.instance;
            }
        }
        #endregion

        private Gauge gauge;
        public Gauge TheGauge
        {
            get { return gauge; }
            set
            {
                if (null == value)
                {
                    gauge = null;
                    return;
                }
                gauge = value;
            }
        }

        public FrmSetGaugeType()
        {
            InitializeComponent();

            this.AcceptButton = btnSet;
        }

        private void FrmSetGaugeType_Load(object sender, EventArgs e)
        {
            ObjectToForm(gauge);
        }

        private void ObjectToForm(Gauge gaugeIn)
        {
            if (gaugeIn!=null)
            {
                if (gaugeIn.RECORD_TYPE == 1)
                {
                    rbTotalValue.Checked = true;
                }
                else {
                    rbIncreaseValue.Checked = true;
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string err;

            if (rbTotalValue.Checked)
            {
                gauge.RECORD_TYPE = 1;
            }
            else {
                gauge.RECORD_TYPE = 2;
            } 
            if (gauge.Update (out err))
            {
                MessageBoxEx.Show("保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void FormToObject(Gauge gaugeIn)
        {
            if (gaugeIn != null)
            {
                if (gaugeIn.RECORD_TYPE == 1)
                {
                    rbTotalValue.Checked = true;
                }
                else
                {
                    rbIncreaseValue.Checked = true;
                }
            }

        }

        private void FrmSetGaugeType_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

    }
}