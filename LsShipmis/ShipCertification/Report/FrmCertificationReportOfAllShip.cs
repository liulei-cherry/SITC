using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using ShipCertification.Services;
using FileOperationBase.FileServices;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using FileOperationBase.Services;
using CommonOperation.Enum;
using System.IO;
using ShipCertification.DataObject;
using ShipCertification.Viewer;

namespace ShipCertification.Report
{
    public partial class FrmCertificationReportOfAllShip : FormBase
    {

        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmCertificationReportOfAllShip instance;
        public static FrmCertificationReportOfAllShip Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCertificationReportOfAllShip.instance = new FrmCertificationReportOfAllShip();
                }
                return FrmCertificationReportOfAllShip.instance;
            }
        }
        #endregion

        public FrmCertificationReportOfAllShip()
        {
            InitializeComponent();

        }

        private void FrmCertificationReportOfAllShip_Load(object sender, EventArgs e)
        {
            //初始化数据.
            retrieveData();
            dataGridView.ExportColorToExcel = true;
        }

        private void retrieveData()
        {
            DataTable dtbInfo = ShipCertRegisterService.Instance.GetAllShipCertRegisterCrossTableInfo();
            dataGridView.DataSource = dtbInfo;
            dataGridView.Columns["Ship_Name"].HeaderText = "船舶名称";
            setAlertState();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAllShip_Click(object sender, EventArgs e)
        {
            if (ShipCertificationConfig.customExportAllShipCertificationReportInfo != null)
            {
                ShipCertificationConfig.customExportAllShipCertificationReportInfo();
            }
            else
            {
                dataGridView.OutPutExcel();
            }
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            FrmShipCertPrintConfig frmConfig = new FrmShipCertPrintConfig();
            frmConfig.ShowDialog();
            if (frmConfig.NeedRetrieve)
            {
                retrieveData();
            }
        }

        private void FrmCertificationReportOfAllShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
        private void setAlertState()
        {
            //确定多少列.
            //从第一行找到最后一行.
            //从第一个数据列开始找到最后.
            //如果超期红色,如果报警橙色.
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                for (int i = 1; i < dataGridView.Columns.Count; i++)
                {
                    DateTime alertDate;
                    if (dr.Cells[i].Value != null && DateTime.TryParse(dr.Cells[i].Value.ToString(), out alertDate))
                    {
                        if (alertDate < DateTime.Today)
                        {
                            //红色.
                            dr.Cells[i].Style.ForeColor = Color.Red;
                            //红色.
                            dr.Cells[i].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            int alertDays = 90;
                            if (alertDate.AddDays(-1 * alertDays) < DateTime.Today)
                            {
                                //橙色.
                                dr.Cells[i].Style.ForeColor = Color.Orange;
                            }
                        }
                    }
                }
            }
        }
        private void FrmCertificationReportOfAllShip_Shown(object sender, EventArgs e)
        {
            setAlertState();
        }
    }
}