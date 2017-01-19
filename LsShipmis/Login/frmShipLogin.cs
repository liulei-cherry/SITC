using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Login.Services;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Data.SqlClient;

namespace Login
{
    public partial class frmShipLogin : Form
    {
        #region 窗体变量
        FrmOptConfig frm = null;
        /// <summary>
        /// 数据库访问类.
        /// </summary>
        SqlServerAccess dbAccess = null;
        /// <summary>
        /// 服务器上XML文件集合.
        /// </summary>
        DataSet dsServer = null;
        /// <summary>
        /// 客户端上的XML文集集合.
        /// </summary>
        DataSet dsClient = null;

        FileOperation fileOperation = null;
        /// <summary>
        /// 主程序名称.
        /// </summary>
        protected string MainProgramName
        {
            get { return "LSShipMis_" + ConstParameter.ShipOfLand + ".exe"; }
        }
        #endregion

        #region 构造函数

        public frmShipLogin()
        {
            InitializeComponent();
            string errMessage = string.Empty;
            fileOperation = new FileOperation();
            if (fileOperation.CheckVersionTableExits(out errMessage))
            {
                if (fileOperation.CheckFileTableExits(out errMessage))
                {
                    if (!fileOperation.CheckRelationTableExits(out errMessage))
                    {
                        MessageBox.Show(errMessage);
                    }
                }
                else
                    MessageBox.Show(errMessage);
            }
            else
                MessageBox.Show(errMessage);

        }
        #endregion

        #region 窗体载入

        private void frmShipLogin_Shown(object sender, EventArgs e)
        {
            this.Text = ConstParameter.Detail + "（自动升级程序）";
            dbAccess = new SqlServerAccess(Login.ConstParameter.DBConnectString);
            this.Refresh();
            if (!CheckConnIsValid(Login.ConstParameter.DBConnectString))
            {
                lbMessage.Text = "信息库连接不成功，请按F10重新配置";
            }
            else
            {
                if (!CheckConnIsValid(Login.ConstParameter.LobDBConnectString))
                {
                    lbMessage.Text = "文件库连接不成功，请按F10重新配置";
                }
                else
                {
                    //1.下载XML或上传文件.
                    if (DownLoadXmlFile())
                    {
                        //3.比较版本.
                        CompareEditions();
                    }
                }
            }
            this.ControlBox = true;
        }
        #endregion

        #region 窗体方法
        /// <summary>
        /// 检查数据库连接.
        /// </summary>
        /// <param name="conStr">连接字符串</param>
        /// <returns></returns>
        private bool CheckConnIsValid(string conStr)
        {
            bool isOK = false;
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                isOK = true;
            }
            catch
            {
                isOK = false;
            }
            return isOK;
        }
        /// <summary>
        /// 获取取XML文件.
        /// 存储在根目录下的Update
        /// </summary>
        private bool DownLoadXmlFile()
        {

            lbMessage.Text = "程序启动中...";
            progressBar1.Visible = false;
            string returnValue;
            string filePath = Application.StartupPath + "\\Update";
            DirectoryInfo dir = new DirectoryInfo(filePath);
            if (!dir.Exists) dir.Create();

            DeleteTempFile();
            DataTable dtVersion = null;
            string strObjectID = string.Format(@"SELECT TOP 1 OBJECT_ID
                                            FROM dbo.T_AutoUpdateVersion
                                            WHERE IsValid=1
                                            ORDER BY CreateDate DESC");
            if (dbAccess.GetDataTable(strObjectID, out dtVersion, out returnValue))
            {
                if (dtVersion != null && dtVersion.Rows.Count > 0)
                {
                    //XML文件存储ID                   
                    string newVersion_ObjectID = dtVersion.Rows[0][0].ToString();
                    //船端更新XML文件名称.
                    string newVersion_FileName = filePath + "\\AutoUpdateShip.xml";
                    if (!String.IsNullOrEmpty(newVersion_ObjectID))
                    {
                        if (FileDbService.Instance.GetABlobByBlodId(newVersion_ObjectID, newVersion_FileName))
                        {
                            if (File.Exists(newVersion_FileName))
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    //数据库中没有版本文件.
                    //第一次使用，上传逻辑.
                    lbMessage.Text = "上传最新版本中...";
                    progressBar1.Visible = true;
                    string errMessage;
                    fileOperation = new FileOperation();
                    fileOperation.UpdateFilesPercent = new FileOperation.OperationPercent(operationPercent);
                    bool isLast = fileOperation.UpLoadLastVersion(true, out errMessage);
                    if (isLast)
                    {
                        DoSomeThing();
                        return false;
                    }
                    else
                    {
                        this.ControlBox = true;
                        lbMessage.Text = errMessage;
                        return false;
                    }

                }
            }
            else
            {
                //记录日志吧.
                this.ControlBox = true;
                lbMessage.Text = returnValue;
                return false;
            }

            return true;
        }
        /// <summary>
        /// 比较版本差异.
        /// </summary>
        private void CompareEditions()
        {
            //本地文件版本号.
            String strFileVersion = string.Empty;
            try
            {
                FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MainProgramName);
                strFileVersion = string.Format("{0}.{1}.{2}.{3}", myFileVersion.FileMajorPart, myFileVersion.FileMinorPart, myFileVersion.FileBuildPart, myFileVersion.FilePrivatePart);
            }
            catch
            {
                //记录日志吧.
                this.ControlBox = true;
                lbMessage.Text = "船舶管理主程序文件不存在，请检查！";
                return;
            }

            #region 检测XML文件
            string serverFileName = Application.StartupPath + "\\Update\\AutoUpdateShip.xml";
            string clientsFileName = Application.StartupPath + "\\AutoUpdateShip.xml";
            if (File.Exists(serverFileName))
            {
                dsServer = new DataSet();
                dsServer.ReadXml(serverFileName);
            }
            else
            {
                //记录日志吧.

                lbMessage.Text = serverFileName + "文件不存在，请重新启动程序！";
                return;
            }
            if (File.Exists(clientsFileName))
            {
                dsClient = new DataSet();
                dsClient.ReadXml(clientsFileName);
            }
            else
            {
                fileOperation = new FileOperation();
                fileOperation.CreateXmlFile(clientsFileName, strFileVersion);
                dsClient = new DataSet();
                dsClient.ReadXml(clientsFileName);
            }
            #endregion

            //服务端主表信息.

            DataTable dtServerVersion = dsServer.Tables[0];
            //服务器最新程序版本号.
            string serverVersion = dtServerVersion.Rows[0]["Version"].ToString();
            //客户端主表信息.

            DataTable dtClientVersion = dsClient.Tables[0];
            //本地主程序版本号.
            //XML版本号不起到任何效果.
            string clientVersion = strFileVersion;

            if (serverVersion != clientVersion)
            {
                fileOperation = new FileOperation();
                DataTable dtServerFile = dsServer.Tables[1];
                DataTable dtClientFile = dsClient.Tables[1];
                if (CompareVersion(serverVersion, clientVersion))
                {
                    //服务端较高提示用户下载最新版本.

                    DialogResult result = MessageBox.Show("存在新版本软件,是否下载?\r\n是：下载最新程序.\r\n否：重新配置程序数据库连接.\r\n取消：不升级程序直接关闭.", "请注意", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.No)
                    {
                        FrmOptConfig optConfig = new FrmOptConfig();
                        optConfig.ShowDialog();

                        //Application.Restart();
                        DoSomeThing();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        DeleteTempFile();
                        this.Close();
                    }
                    else
                    {
                        //下载新版本.

                        progressBar1.Visible = true;
                        lbMessage.Text = "下传最新版本...";
                        string errMessage;
                        fileOperation.DownLoadFilesPercent = new FileOperation.OperationPercent(operationPercent);
                        if (fileOperation.DownLoadLastVersion(dtServerFile, dtClientFile, out errMessage))
                            DoSomeThing();
                        else
                        {
                            this.ControlBox = true;
                            lbMessage.Text = errMessage;
                        }
                    }
                }
                else
                {
                    //上传最新版.
                    progressBar1.Visible = true;
                    lbMessage.Text = "上传最新版本...";
                    string errMessage;
                    fileOperation.UpdateFilesPercent = new FileOperation.OperationPercent(operationPercent);
                    if (fileOperation.UpLoadLastVersion(false, out errMessage))
                        DoSomeThing();
                    else
                    {
                        this.ControlBox = true;
                        lbMessage.Text = errMessage;
                    }
                }

            }
            else
            {
                DeleteTempFile();
                //版本一致.

                DoSomeThing();
            }
        }

        public void DeleteTempFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + "\\Update");
            FileInfo[] fileInfos = dirInfo.GetFiles();
            foreach (FileInfo fileModel in fileInfos)
            {
                fileModel.Delete();
            }
        }

        private void DoSomeThing()
        {
            this.Hide();
            try
            {
                Process.Start(Application.StartupPath + "\\" + MainProgramName, ConstParameter.BackCallArg);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// 比较版本大小.
        /// </summary>
        /// <param name="serverVersion">服务端版本</param>
        /// <param name="clientVersion">客户端版本</param>
        /// <returns>true服务端版本高</returns>
        private bool CompareVersion(string serverVersion, string clientVersion)
        {
            //默认是服务端版本高.

            bool returnValue = true;

            #region 比较版本高低
            int splitServerCount = serverVersion.Split('.').Length;
            int splitClientCount = clientVersion.Split('.').Length;

            for (int i = 0; i < splitClientCount; i++)
            {
                for (int j = 0; j < splitClientCount; j++)
                {
                    if (i == j)
                    {
                        if (serverVersion.Split('.')[i] != clientVersion.Split('.')[j])
                        {
                            if (int.Parse(serverVersion.Split('.')[i]) > int.Parse(clientVersion.Split('.')[j]))
                            {
                                //服务端版本大于客户端版本.
                                return true;
                            }
                            else
                            {
                                //客户端版本大于服务端版本.
                                return false;
                            }
                        }
                    }

                }

            }
            #endregion

            return returnValue;
        }
        /// <summary>
        /// 打开数据库配置连接界面.
        /// </summary>
        private void openConfigFrm()
        {
            if (frm == null) frm = new FrmOptConfig();
            frm.ShowDialog();
            if (frm.NeedReloading)
            {
                DoSomeThing();
                //frmShipLogin_Shown(null, null);
            }
        }
        /// <summary>
        /// 进度显示.
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="whichStep"></param>
        private void operationPercent(int percent, string whichStep)
        {
            lbMessage.Text = whichStep;
            if (percent > progressBar1.Maximum) percent = progressBar1.Maximum;
            else if (percent < progressBar1.Minimum) percent = progressBar1.Minimum;
            progressBar1.Value = percent;
            this.Refresh();
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 键盘按下事件.
        /// </summary>       
        private void frmShipLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                openConfigFrm();
            }
        }
        private void lbMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                openConfigFrm();
            }
        }
        #endregion

    }
}
