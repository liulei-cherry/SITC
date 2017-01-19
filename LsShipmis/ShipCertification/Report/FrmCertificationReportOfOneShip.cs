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
using CommonViewer.MultiLanguage;
using CommonViewer.BaseControl;
namespace ShipCertification.Report
{
    public partial class FrmCertificationReportOfOneShip : FormBase
    {

        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmCertificationReportOfOneShip instance = new FrmCertificationReportOfOneShip();
        public static FrmCertificationReportOfOneShip Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCertificationReportOfOneShip.instance = new FrmCertificationReportOfOneShip();
                }
                return FrmCertificationReportOfOneShip.instance;
            }
        }
        #endregion
        private string shipid; 
        private FrmCertificationReportOfOneShip()
        {
            InitializeComponent();
            //初始化数据.
            ucShipSelect1.ChangeSelectedState(false, true);
        }

        private void intData()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                ucShipSelect1.Enabled = true;
                ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
                shipid = ucShipSelect1.GetId();
            }
            else
            {
                ucShipSelect1.Enabled = false;
                ucShipSelect1.Visible = false;
                label3.Visible = false;
                shipid = CommonOperation.ConstParameter.ShipId;

            }
            retrieveData();
        }

        private void FrmCertificationReportOfOneShip_Load(object sender, EventArgs e)
        {
            intData();
        }

        #region 刷新数据部分

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (ucShipSelect1.GetId() != shipid)
            {
                shipid = ucShipSelect1.GetId();
                retrieveData();
            }
        }
        private void retrieveData()
        { 
            DataTable dtbInfo = ShipCertRegisterService.Instance.GetAllShipCertificationOfShip(shipid);
            bindingSource1.DataSource = dtbInfo;
            dataGridView.DataSource = bindingSource1;
            dataGridView.LoadGridView("FrmCertificationReportOfOneShip.dataGridView");            
            dataGridView.Columns["SHIP_CERT_REGISTERID"].Visible = false;
            dataGridView.Columns["SHIP_NAME"].HeaderText = "船名";
            dataGridView.Columns["SHIP_NAME"].Visible = true;
            dataGridView.Columns["alertdate"].Visible = false;
            dataGridView.Columns["MATUREDATE"].HeaderText = "下次检查日期";
            dataGridView.Columns["MATUREDATE"].Visible = true;
            dataGridView.Columns["SHIPCERTNUMB"].HeaderText = "证书编号";
            dataGridView.Columns["SHIPCERTNUMB"].Visible = true; 
            dataGridView.Columns["SHIP_CERT_NAME"].HeaderText = "证书名称";
            dataGridView.Columns["SHIP_CERT_NAME"].Visible = true;
            dataGridView.Columns["PLACE"].HeaderText = "发证地点";
            dataGridView.Columns["PLACE"].Visible = true;
            dataGridView.Columns["SIGNEDDATE"].HeaderText = "签发日期";
            dataGridView.Columns["SIGNEDDATE"].Visible = true;
            dataGridView.Columns["ENDDATE"].HeaderText = "证书有效日期";
            dataGridView.Columns["ENDDATE"].Visible = true;
            dataGridView.Columns["EFFECTDATE"].HeaderText = "有效期限(年)";
            dataGridView.Columns["EFFECTDATE"].Visible = true;
            dataGridView.Columns["SHIPCERTDEPARTNAME"].HeaderText = "主管机关";
            dataGridView.Columns["SHIPCERTDEPARTNAME"].Visible = true;
            dataGridView.Columns["SHIP_NAME"].DisplayIndex = 0;
            dataGridView.Columns["SHIP_CERT_NAME"].DisplayIndex = 1;
            dataGridView.Columns["SHIPCERTNUMB"].DisplayIndex = 2;
            dataGridView.Columns["SIGNEDDATE"].DisplayIndex = 3;
            dataGridView.Columns["PLACE"].DisplayIndex = 4;
            dataGridView.Columns["ENDDATE"].DisplayIndex = 5;            
            dataGridView.Columns["MATUREDATE"].DisplayIndex = 6;
            dataGridView.Columns["EFFECTDATE"].DisplayIndex = 7;
            dataGridView.Columns["SHIPCERTDEPARTNAME"].DisplayIndex = 8;
            dataGridView.SetDataGridViewNoSort();
            setAlertState();
        }

        private void setAlertState()
        {            
            //如果超期红色,如果报警橙色.
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                DateTime alertDate;
                if (dr.Cells["MATUREDATE"].Value != null && DateTime.TryParse(dr.Cells["MATUREDATE"].Value.ToString(), out alertDate))
                {
                    if (alertDate < DateTime.Today)
                    {
                        //红色.
                        dr.Cells["MATUREDATE"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        if (dr.Cells["alertdate"].Value != null && DateTime.TryParse(dr.Cells["alertdate"].Value.ToString(), out alertDate))
                        {
                            if (alertDate < DateTime.Today)
                            {
                                //橙色.
                                dr.Cells["MATUREDATE"].Style.BackColor = Color.Orange;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOneShip_Click(object sender, EventArgs e)
        {
            shipid = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipid)) return;

            string fileid, err;

            WorkModelType workModelType = WorkModelTypeService.Instance.getModelObject(shipid, CommonPrintTableName.CTNOfShipCertification, out err);
            string fileName = workModelType.ModelName + "_" + ucShipSelect1.GetText() + "_" + DateTime.Today.ToLongDateString() + ".xls";

            ourFolder rootFolder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.SHIPCERTIFILES, shipid);

            if (rootFolder != null && FolderFileDbService.Instance.IfFolderHasTheFile(rootFolder.NodeId, fileName, out fileid))
            { 
                if ( MessageBoxEx.Show("找到了之前形成的船舶证书一览表[" + fileName + "],是否要直接打开此文件?" +
                   "选择否,系统将删除旧的同名文件,以免形成多个单据给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
               // if (MessageBoxEx1.Instance.Show("找到了之前形成的船舶证书一览表[" + fileName + "]", "系统提示", MessageBoxButtons.YesNo,
               //    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)

                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "系统提示");
                    }
                    else
                    {
                        openFile opf = new openFile();
                        opf.FileOpen(ofile, right.U);
                        return;
                    }
                }
                else
                {
                    if (!FolderFileDbService.Instance.DeleteAFile(rootFolder.NodeId, fileid, out err))
                    {
                        MessageBoxEx.Show("非常抱歉,系统帮您删除旧文件时出错,错误信息为:" + err
                            + "\r这不会影响您的主要业务,但有时间希望您可以到文件管理目录中删除相应文件!", "错误提示!");
                    }
                }
            }

            DataTable dt = bindingSource1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                string dPath;
                if (FolderBrowserDialogEx.ShowDialog(folderBD) == DialogResult.OK)
               // if (folderBD.ShowDialog() == DialogResult.OK)
                    dPath = folderBD.SelectedPath.ToString();
                else
                    return;

                string filePath;

                if (FileDbService.Instance.GetABolbByFileId(workModelType.ModelFile, out filePath) && File.Exists(filePath))
                {
                    FileInfo fileinfo = new FileInfo(filePath);

                    string path = System.IO.Path.Combine(dPath, fileName);
                    if (System.IO.File.Exists(path))
                    {
                        if (MessageBoxEx.Show("是否覆盖原文件?", "请注意", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            fileName = fileName.Remove(fileName.Length - 4) + DateTime.Now.Millisecond.ToString().Trim() + ".xls";
                            path = System.IO.Path.Combine(dPath, fileName);
                        }
                        else
                        {
                            try
                            {
                                (new FileInfo(path)).Delete();
                            }
                            catch
                            {
                                path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path),
                                        DateTime.Now.Millisecond.ToString().Trim() + "_" + fileName);
                                MessageBoxEx.Show("无法覆盖原文件,可能是文件正在使用或者无权限删除!我们文件保存成:\r" + path);
                            }
                        }
                    }

                    if (path == "") return;

                    fileinfo.CopyTo(path, true);

                    ShipInfo shipInfo = (ShipInfo)ShipInfoService.Instance.GetOneObjectById(shipid);
                    if (shipInfo == null || shipInfo.IsWrong)
                    {
                        MessageBoxEx.Show("打印" + CommonPrintTableName.CTNOfShipCertification +
                            "时传入的船舶主键无效", "错误提示");
                        return;
                    } 

                    WorkModelType model = WorkModelTypeService.Instance.getModelObject(shipid,
                                   CommonPrintTableName.CTNOfShipCertification, out err);
                    if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
                    {
                        MessageBoxEx.Show("获取客户定制的" + CommonPrintTableName.CTNOfShipCertification +
                            "时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err, "错误提示");
                        return;
                    }
                    //得到所有的基本证书.
                    List<ShipCert> allReportCert;
                    try
                    {
                        allReportCert = ShipCertService.Instance.GetAllReportCert();
                    }
                    catch (Exception ee)
                    {
                        MessageBoxEx.Show("打印" + CommonPrintTableName.CTNOfShipCertification +
                            ",在获取所有船舶基本证书时发送错误,\r错误信息为: " + ee.Message, "错误提示");
                        return;
                    }
                    //进行证书匹配,打印所有的匹配过的证书的最新信息. 
                    List<ShipCertRegister> lstCertsOfOneShip = ShipCertRegisterService.Instance.GetAllShipCertificationListOfShip(shipid);

                    if (ShipCertificationConfig.customShipCertificationReport != null)
                    {
                        if (!ShipCertificationConfig.customShipCertificationReport(shipInfo, allReportCert, lstCertsOfOneShip, model, path, out err))
                        {
                            MessageBoxEx.Show(err, "错误提示");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    ourFile ofile;

                    if (!WorkModelTypeService.Instance.SetReport(FileBoundingTypes.SHIPCERTIFILES, false, rootFolder.NodeName, rootFolder.NodeId, DateTime.Today, CommonOperation.ConstParameter.UserName,
                        shipid, model.ModelFile, path, out ofile, out err))
                    {
                        MessageBoxEx.Show(err, "错误提示");
                        return;
                    }
                    else
                    {
                        openFile opf = new openFile();
                        opf.FileOpen(ofile, right.U);
                    }
                }
                else
                {
                    MessageBoxEx.Show("不存在模板文件");
                    return;
                }
            }
            else
            {
                MessageBoxEx.Show("没有数据");
            }
        }

        private void btnAllShip_Click(object sender, EventArgs e)
        {
            FrmCertificationReportOfAllShip frm = FrmCertificationReportOfAllShip.Instance;
            if (this.MdiParent != null) frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void FrmCertificationReportOfOneShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView.SaveGridView("FrmCertificationReportOfOneShip.dataGridView");
            instance = null;
        }

        private void FrmCertificationReportOfOneShip_Shown(object sender, EventArgs e)
        {
            this.setAlertState();
        }

    }
}