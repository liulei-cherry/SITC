/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmLogin.cs
 * 创 建 人：李景育
 * 创建时间：2007-08-22
 * 标    题：用户登录界面
 * 功能描述：验证用户登录同时赋初值
 * 修 改 人：王鹏程加入中英文登录 徐正本更换到CommonViewer中
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

using System.Diagnostics;
using System.IO;
using CommonOperation.Interfaces;
using CommonOperation;
using CommonOperation.Functions;
using CommonViewer.MultiLanguage;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;


namespace CommonViewer.BaseForm
{
    /// <summary>
    /// 用户登录界面.
    /// </summary>
    public partial class FrmLogin : Form
    {
        #region 窗体变量
        FrmOptConfig frm = new FrmOptConfig();
        private Object thisLock = new Object();

        public delegate ILoginUser getLoginUserInfo(string userId);
        public getLoginUserInfo GetLoginUserInfo;
        string regString = "ShipMis";
        string db, lobDb;
        public string strBaseExeVersion = string.Empty;
        public string strUpdateExeVersion = string.Empty;

        Thread thread = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmLogin()
        {
            InitializeComponent();
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                strBaseExeVersion = "LSShipMis_Land.exe";
                strUpdateExeVersion = "LandLogin.exe";
            }
            else
            {
                strBaseExeVersion = "LSShipMis_Ship.exe";
                strUpdateExeVersion = "ShipLogin.exe";
            }
            this.lbl_User.Text = CommonOperation.ConstParameter.MAINUSER;
            this.lbl_Version.Text = CommonOperation.ConstParameter.MAINVERSION;


            //Thread t = new Thread(new ThreadStart(ExcuteSql));
            //t.Start();
        }
        #endregion

        #region 窗体载入
        public FrmLogin(string regString, string db, string lobdb)
            : this()
        {
            this.regString = regString;
            this.db = db;
            this.lobDb = lobdb;

#if !DEBUG
            //1.检测升级程序最新版
            CheckAutoUpdateAppVersion();
            //2.检测主程序最新版本
            /*张Yu注释2014-12-29*/
            //CheckLatestVersion();
#endif

        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

            frm.getDbConnectionString += new FrmOptConfig.GetDbConnectionString(GetDbConnectionString);
            //创建一个线程,用来加载中英文Excel文件.
            if (CommonOperation.ConstParameter.MultilanguageVersion)
            {
                Thread t = new Thread(new ThreadStart(MultiLanguageInit));
                t.Start();
            }
            else
            {
                rdoCH.Visible = false;
                rdoEN.Visible = false;
                checkBox1.Location = new Point(this.Width / 2 - checkBox1.Width / 2, checkBox1.Location.Y);
            }
            try
            {
                txtLogIn.Text = ConstParameter.GetRegedit("LastUser");//开发版数据库连接信息.

                checkBox1.Checked = (ConstParameter.GetRegedit("SavePass") == "1" ? true : false);
                txtPwd.Text = ConstParameter.GetRegedit("LastPassword");
                bool defaultLanguage = (ConstParameter.GetRegedit("DefaultLanguage") == "1" ? true : false);
                if (defaultLanguage) rdoEN.Checked = true;
                else rdoCH.Checked = true;

            }
            catch { }
        }

        /// <summary>
        /// 多语言初始化,读取Excel
        /// </summary>
        private void MultiLanguageInit()
        {
            lock (thisLock)
            {
                MultiLanguageDictionary.Instance.CustomLanguage = customLanguage.CHINESE;
                string err = "";
                string path = Environment.CurrentDirectory;//获得应用程序的当前路径.

                //bool status = MultiLanguageDictionary.Instance.InitCustomDictionary(path + "\\translate.xls", out err);
                bool status = MultiLanguageDictionary.Instance.InitCustomDictionary(path + "\\Translate.xml", out err);
            }
        }
        /// <summary>
        /// 弹出登录等待panel,禁用login页上控件.
        /// </summary>
        private void ShowLoginWait()
        {
            btnLogin.Enabled = false;
            btnClose.Enabled = false;
            rdoCH.Enabled = false;
            rdoEN.Enabled = false;
            checkBox1.Enabled = false;
            txtLogIn.Enabled = false;
            txtPwd.Enabled = false;
            pnlLoginWait.Show();
        }
        /// <summary>
        /// 取消登录等待.
        /// </summary>
        private void CancelLoginWait()
        {
            btnLogin.Enabled = true;
            btnClose.Enabled = true;
            rdoCH.Enabled = true;
            rdoEN.Enabled = true;
            checkBox1.Enabled = true;
            txtLogIn.Enabled = true;
            txtPwd.Enabled = true;
            pnlLoginWait.Hide();
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 用户登录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login(true);
        }

        public void GetDbConnectionString(out string DB, out string LobDB)
        {
            DB = db;
            LobDB = lobDb;
        }
        /// <summary>
        /// 取消登录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            MultiLanguageDictionary.Instance.closeExcel();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtLogIn.Focus();

        }

        private void FrmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                timer1.Stop();
                if (frm == null) frm = new FrmOptConfig();
                frm.ShowDialog();
                if (frm.NeedReloading)
                    Application.Restart();
            }
        }

        private void rdoEN_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "UserName";
            label2.Text = "Password";
            label3.Text = "Landsea ShipMIS Login";
            checkBox1.Text = "SavePassword";
            btnLogin.Text = "Login";
            btnClose.Text = "Close";
        }

        private void rdoCH_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "用户";
            label2.Text = "口令";
            label3.Text = "陆海船舶管理系统登录";
            checkBox1.Text = "保存密码";
            btnLogin.Text = "登录";
            btnClose.Text = "关闭";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            login(false);
        }

        private void login(bool withMessage)
        {
            try
            {
                if (CommonOperation.ConstParameter.MultilanguageVersion)
                {
                    ShowLoginWait();
                    if (this.rdoEN.Checked)
                    {
                        MultiLanguageDictionary.Instance.CustomLanguage = customLanguage.ENGLISH;
                    }
                    else
                    {
                        MultiLanguageDictionary.Instance.CustomLanguage = customLanguage.CHINESE;
                        CommonOperation.ConstParameter.MultilanguageVersion = false;
                    }
                }
                //登录校验部分.
                Cursor.Current = Cursors.WaitCursor;
                if (txtLogIn.Text.Trim().Length == 0)
                {
                    if (!withMessage)
                    {
                        timer1.Stop();
                        return;
                    }
                    MessageBox.Show("请填写用户名！\rUser name cannot be empty!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLogIn.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (txtPwd.Text.Trim().Length == 0)
                {
                    if (!withMessage)
                    {
                        timer1.Stop();
                        return;
                    }
                    MessageBox.Show("请填写登录口令！\rPassword cannot be empty!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPwd.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                UserLogin userLogin = new UserLogin(txtLogIn.Text, txtPwd.Text);//取得当前用户登录对象.

                //如果数据库连接出错则直接弹出数据库配置对话框进行连接配置.
                if (userLogin.IsConnected() == false)
                {
                    if (!withMessage)
                    {
                        timer1.Stop();
                        return;
                    }
                    if (frm == null) frm = new FrmOptConfig();
                    frm.ShowDialog();
                    Application.Restart();
                    return;
                }
                ConstParameter.ShipId = Parameter.GetShipId();
                if (userLogin.CheckUser() == false)
                {
                    if (!withMessage)
                    {
                        timer1.Stop();
                        return;
                    }
                    MessageBox.Show("当前登录名称不正确！\rUser name is invalid!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLogIn.Clear();
                    txtPwd.Clear();
                    txtLogIn.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (userLogin.CheckPwd() == false)
                {
                    if (!withMessage)
                    {
                        timer1.Stop();
                        return;
                    }
                    MessageBox.Show("当前登录口令不正确！\rPassword is invalid!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPwd.Clear();
                    txtPwd.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                //设置环境变量.
                ConstParameter.SetRegedit("LastUser", txtLogIn.Text);

                //英文为1,中文为0
                if (rdoEN.Checked)
                {
                    ConstParameter.SetRegedit("DefaultLanguage", "1");
                }
                else
                {
                    ConstParameter.SetRegedit("DefaultLanguage", "0");
                }

                if (checkBox1.Checked)
                {
                    ConstParameter.SetRegedit("SavePass", "1");
                    ConstParameter.SetRegedit("LastPassword", txtPwd.Text);
                }
                else
                {
                    ConstParameter.SetRegedit("SavePass", "0");
                    ConstParameter.SetRegedit("LastPassword", "");
                }

                userLogin.SettingUserInfo();
                if (GetLoginUserInfo != null)
                    CommonOperation.ConstParameter.LoginUserInfo = GetLoginUserInfo(userLogin.UserHeadId);
                else
                    throw new Exception("无法获取用户信息!");
                //如果dictAllRights返回null则直接弹出数据库配置对话框进行连接配置.
                if (CommonOperation.ConstParameter.dictAllRights == null)
                {
                    if (frm == null) frm = new FrmOptConfig();
                    frm.ShowDialog();
                    Cursor.Current = Cursors.Default;
                    Application.Restart();
                    return;
                }
                if (CommonOperation.ConstParameter.MultilanguageVersion)
                {
                    lock (thisLock)
                    {
                        this.DialogResult = DialogResult.OK;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CancelLoginWait();
            }
        }

        private void txtLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Stop();
        }
        #endregion

        #region 检测主程序版本

        public bool IsChangeVersion
        {
            get;
            private set;
        }
        protected void CheckLatestVersion()
        {
            String errMessage = string.Empty;
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            string strExePath = Application.StartupPath;
            //数据库版本.
            string dataFileVersion = string.Empty;
            if (!GetDataVersion(out dataFileVersion))
            {
                return;
            }
            //当前软件版本.
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(strExePath + "\\" + strBaseExeVersion);
            string exeFileVersion = string.Format("{0}.{1}.{2}.{3}", myFileVersion.FileMajorPart, myFileVersion.FileMinorPart, myFileVersion.FileBuildPart, myFileVersion.FilePrivatePart);
            if (dataFileVersion != exeFileVersion)
            {
                IsChangeVersion = true;
            }
            else { IsChangeVersion = false; }
        }

        private bool GetDataVersion(out string dataVersion)
        {
            string errMessage;
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            string strObjectID = string.Format(@"SELECT TOP 1 VersionNo FROM dbo.T_AutoUpdateVersion
                                                 WHERE IsValid=1 ORDER BY CreateDate DESC");
            //数据库中软件版本.
            DataTable dtVersion = null;
            if (dbAccess.GetDataTable(strObjectID, out dtVersion, out errMessage))
            {
                if (dtVersion != null && dtVersion.Rows.Count > 0)
                {
                    dataVersion = dtVersion.Rows[0][0].ToString();
                    return true;
                }
                else
                {
                    dataVersion = null;
                    return true;
                }
            }
            else
            {
                dataVersion = null;
                MessageBox.Show(errMessage);
                return false;
            }
        }

        #endregion

        #region 检测升级程序版本

        /// <summary>
        /// 检测升级程序版本
        /// </summary>
        protected void CheckAutoUpdateAppVersion()
        {

            String errMessage, sContent = string.Empty;

            if (!CheckTableColumnsAndAddCoumns(out errMessage))
            {
                MessageBox.Show(errMessage);
                return;
            }

            String strExePath = Application.StartupPath;
            //当升级前软件版本.
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(strExePath + "\\" + strUpdateExeVersion);
            String exeFileVersion = string.Format("{0}.{1}.{2}.{3}", myFileVersion.FileMajorPart, myFileVersion.FileMinorPart, myFileVersion.FileBuildPart, myFileVersion.FilePrivatePart);
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            String strSql = string.Format(@"SELECT TOP 1 FileVsersionNo FROM dbo.T_AutoUpdateFile
                                            WHERE FileName='{0}' ORDER BY CreateDate DESC", strUpdateExeVersion);
            if (dbAccess.GetString(strSql, out sContent, out errMessage))
            {
                if (exeFileVersion != sContent)
                {
                    if (CompareVersion(sContent, exeFileVersion))//版本比较
                    {
                        //需要下载升级程序最新版
                        #region 下载文件

                        string objectIdSql = string.Format(@"SELECT TOP 1 OBJECT_ID,FileMD5 FROM dbo.T_AutoUpdateFile
                                            WHERE FileName='{0}'
                                            ORDER BY CreateDate DESC", strUpdateExeVersion);

                        DataTable dt = new DataTable();
                        if (dbAccess.GetDataTable(objectIdSql, out dt, out errMessage))
                        {
                            string objectId = dt.Rows[0][0].ToString();//最新版升级程序大文件ID
                            string fileMd5 = dt.Rows[0][1].ToString();
                            //文件存放的位置和名称
                            DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + "\\Update\\");
                            if (!dirInfo.Exists) dirInfo.Create();
                            string strPathAndName = Application.StartupPath + "\\Update\\" + strUpdateExeVersion;
                            if (!File.Exists(strPathAndName))
                            {
                                if (!FileDbServiceNew.Instance.GetABlobByBlodId(objectId, strPathAndName))
                                {
                                    MessageBox.Show(strUpdateExeVersion + "文件下载失败，请重试！");
                                }
                            }
                            else
                            {
                                //文件存在可能是个下载一半的坏文件.
                                //检查MD5是否正确.
                                string strMD5 = MD5Stream(strPathAndName);
                                if (strMD5 != fileMd5)
                                {
                                    //文件MD5不一致还得下载.
                                    if (!FileDbServiceNew.Instance.GetABlobByBlodId(objectId, strPathAndName))
                                    {
                                        MessageBox.Show(strUpdateExeVersion + "文件下载失败，请重试！");
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show(errMessage);
                        #endregion

                        #region 移动文件
                        FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\Update\\" + strUpdateExeVersion);
                        string filePathAndName = Application.StartupPath + "\\" + fileInfo.Name;
                        FileInfo fileD = new FileInfo(filePathAndName);
                        fileD.Delete();
                        fileInfo.CopyTo(filePathAndName, true);
                        #endregion
                    }
                    else
                    {
                        //需要上传升级程序最新版
                        string fileNameAndPath = strExePath + "\\" + strUpdateExeVersion;//升级程序所在目录和文件名
                        string sTempBlobId;
                        if (FileDbServiceNew.Instance.InsertABlob(fileNameAndPath, out sTempBlobId))
                        {
                            string strFile = string.Format(@"INSERT INTO  dbo.T_AutoUpdateFile (AutoUpdateFileID, OBJECT_ID, FileVsersionNo, FileName, FileMD5, FilePath)
                                                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                            Guid.NewGuid().ToString(), sTempBlobId, exeFileVersion, strUpdateExeVersion,
                                            MD5Stream(fileNameAndPath), "\\");
                            if (!dbAccess.ExecSql(strFile, out errMessage))
                            {
                                //TODO删除大文件
                                MessageBox.Show("升级程序文件写入数据库失败！");
                            }

                        }
                        else
                        {
                            MessageBox.Show("上传文件失败，请重试！");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(errMessage);
            }
        }
        /// <summary>
        /// 比较版本大小.
        /// </summary>
        /// <param name="serverVersion">服务端版本</param>
        /// <param name="clientVersion">客户端版本</param>
        /// <returns>true服务端版本高false客户端版本高</returns>
        private bool CompareVersion(string serverVersion, string clientVersion)
        {
            //默认是服务端版本高.

            bool returnValue = true;

            if (string.IsNullOrEmpty(serverVersion))
                return false;

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
        /// 对文件流进行MD5加密.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <example></example>
        private static string MD5Stream(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(fs);
            fs.Close();

            byte[] b = md5.Hash;
            md5.Clear();

            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i].ToString("X2"));
            }

            return sb.ToString();
        }
        /// <summary>
        /// 检测某表某字段是否存在,若不存在则直接创建.
        /// </summary>
        /// <param name="errMessage">错误消息</param>
        /// <returns></returns>
        public static bool CheckTableColumnsAndAddCoumns(out string errMessage)
        {
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            errMessage = "";
            bool returnValue = false;
            string strSql = string.Format(@"IF NOT EXISTS (SELECT * FROM syscolumns
                                            WHERE id=(SELECT ID FROM SYSOBJECTS WHERE NAME='T_AutoUpdateFile')
                                            AND name='CreateDate')
                                            ALTER TABLE T_AutoUpdateFile
                                            ADD CreateDate Datetime default getdate()");
            if (dbAccess.ExecSql(strSql, out errMessage)) { returnValue = true; } else { returnValue = false; }

            return returnValue;
        }
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        private void ExcuteSql()
        {
            string errMessage;
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            
            List<String> lstSql = new List<string>();
            lstSql = GetListSql48484(lstSql);//2016-01-08-liulei-4.8.4.84时修改的版本
            if (!dbAccess.ExecSql(lstSql, out errMessage))
            {
                MessageBox.Show(errMessage);
            }
        }
        #endregion

        #region 此方法是2016年1月08号（4.8.4.84）版本，需保留延续两个版本可能被删除，若需补充，请额外构建新的方法
        /// <summary>
        /// 此方法是2016年1月08号（4.8.4.84）版本，需保留延续两个版本可能被删除，若需补充，请额外构建新的方法.
        /// </summary>
        /// <param name="lstSql">需要执行的语句.</param>
        /// <returns>需要执行的语句.</returns>
        private List<String> GetListSql48484(List<String> lstSql)
        {        
           
            //添加是否启用字段.
            lstSql.Add(String.Format(@"if exists (select 1
            from  syscolumns
            WHERE name='MANUFACTURER_NAME'
            AND  id = object_id('T_MANUFACTURER')
)
 ALTER Table T_MANUFACTURER ALTER COLUMN MANUFACTURER_NAME VARCHAR(500)
 
 if exists (select 1
            from  syscolumns
            WHERE name='MANUFACTURER_ENAME'
            AND  id = object_id('T_MANUFACTURER')
)
 ALTER Table T_MANUFACTURER ALTER COLUMN MANUFACTURER_ENAME VARCHAR(500)

if exists (select 1
            from  syscolumns
            WHERE name='MANUFACTURER_NAME'
            AND  id = object_id('B_MANUFACTURER')
)
 ALTER Table B_MANUFACTURER ALTER COLUMN MANUFACTURER_NAME VARCHAR(500)
 
 if exists (select 1
            from  syscolumns
            WHERE name='MANUFACTURER_ENAME'
            AND  id = object_id('B_MANUFACTURER')
)
 ALTER Table B_MANUFACTURER ALTER COLUMN MANUFACTURER_ENAME VARCHAR(500)
 
 
"));



            return lstSql;
        }

        #endregion
    }
}