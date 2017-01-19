using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic; 

namespace Login
{
    public partial class FrmOptConfig : Form
    {
        public bool NeedReloading = false;
        public FrmOptConfig()
        {
            InitializeComponent();
        }

        private void FrmOptConfig_Load(object sender, EventArgs e)
        {
            string oldDBConStr = ConstParameter.DBConnectString;
            string oldLobConStr = ConstParameter.LobDBConnectString;
            string server, user, pwd, db;
            if (!string.IsNullOrEmpty(oldDBConStr))
            {
                SplitConStr(oldDBConStr, out server, out db, out user, out pwd);
                cboServer.Text = server;
                cboDataBase.Text = db;
                this.tbxuser.Text = user;
                this.tbxpwd.Text = pwd;
            }
            if (!string.IsNullOrEmpty(oldLobConStr))
            {
                SplitConStr(oldLobConStr, out server, out db, out user, out pwd);
                cboDataBase2.Text = db;
            }
            this.cboDataBase.TextChanged += new System.EventHandler(this.cboDataBase_TextChanged);
        }

        /// <summary>
        /// 把连接字符串提取成对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private void SplitConStr(string str, out string server, out string db, out string userid, out string pwd)
        {
            server = "";
            db = "";
            userid = "";
            pwd = "";
            string[] strs = str.Split(';');
            foreach (string s in strs)
            {
                string[] obj = s.Split('=');
                if (obj != null && obj.Length > 1)
                {
                    switch (obj[0])
                    {
                        case "Data Source":
                            server = obj[1];
                            break;
                        case "Initial Catalog":
                            db = obj[1];
                            break;
                        case "User ID":
                            userid = obj[1];
                            break;
                        case "Password":
                            pwd = obj[1];
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 得到新的连接字符串.
        /// </summary>
        private string MakeConStr(string tSer, string tDB, string tUser, string tPwd)
        {
            StringBuilder conStr = new StringBuilder();
            conStr.Append("Data Source=").Append(tSer);
            conStr.Append(";Initial Catalog=").Append(tDB);
            conStr.Append(";Persist Security Info=True");
            conStr.Append(";User ID=").Append(tUser);
            conStr.Append(";Password=").Append(tPwd);
            conStr.Append(";Connect Timeout=").Append("10");
            return conStr.ToString();
        }

        /// <summary>
        /// 获取指定服务器上的所有数据库信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private DataTable GetAllDbNameByServer(string server, string user, string password)
        {
            string connStr = "Data Source=" + server + ";Initial Catalog=master;Persist Security Info=True;User ID=" + user + ";Password=" + password + ";Connect Timeout=10";
            string sql = "select name from master.dbo.sysdatabases where name not in ('master','model','msdb','tempdb') order by name";
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 自动获取当前网络服务器功能
        /// </summary>
        private void cboServer_DropDown(object sender, EventArgs e)
        {
            if (cboServer.DataSource == null)
            {
                string[] server = null;
                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    server = SqlLocator.GetServers();
                }
                catch { }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                if (server != null && server.Length > 0)
                    cboServer.DataSource = server;
            }
        }

        /// <summary>
        /// 自动获取当前服务器的全部数据库功能
        /// </summary>
        private void cboDataBase_DropDown(object sender, EventArgs e)
        {
            string server = cboServer.Text.Trim();
            string user = tbxuser.Text.Trim();
            string pwd = tbxpwd.Text.Trim();
            if (!string.IsNullOrEmpty(server) && !string.IsNullOrEmpty(user)
                && !string.IsNullOrEmpty(pwd) && cboDataBase.DataSource == null)
            {
                string errMessage;
                string newServerConStr = "Data Source=" + server + ";Persist Security Info=True;User ID=" + user + ";Password=" + pwd + ";Connect Timeout=10";
                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    if (!TestConByConStr(newServerConStr, out errMessage))
                    {
                        MessageBox.Show("服务器连接失败.失败原因可能为:\r\n" + errMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch { }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                DataTable dt = GetAllDbNameByServer(cboServer.Text, tbxuser.Text, tbxpwd.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cboDataBase.DataSource = dt;
                    cboDataBase2.DataSource = dt.Copy();
                }
                else
                {
                    cboDataBase.DataSource = null;
                    cboDataBase2.DataSource = null;
                }

            }
        }

        /// <summary>
        /// 自动设置文件库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDataBase_TextChanged(object sender, EventArgs e)
        {
            cboDataBase2.Text = cboDataBase.Text + "_Lob";
        }

        /// <summary>
        /// 测试连接.
        /// </summary>
        private bool TestConByConStr(string conStr, out string errMessage)
        {
            errMessage = "";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(conStr);
                connection.Open();
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }

        private bool CheckForm()
        {
            string server = cboServer.Text.Trim();
            string user = tbxuser.Text.Trim();
            string pwd = tbxpwd.Text.Trim();
            string db = cboDataBase.Text.Trim();
            string lob = cboDataBase2.Text.Trim();
            if (string.IsNullOrEmpty(server))
            {
                MessageBox.Show("请填写服务器名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("请填写用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请填写密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(db))
            {
                MessageBox.Show("请填写信息库名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(lob))
            {
                MessageBox.Show("请填写文件库名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.CheckForm())
                return;
            string server = cboServer.Text.Trim();
            string user = tbxuser.Text.Trim();
            string pwd = tbxpwd.Text.Trim();
            string db = cboDataBase.Text.Trim();
            string lob = cboDataBase2.Text.Trim();
            string errMessage;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string newServerConStr = "Data Source=" + server + ";Persist Security Info=True;User ID=" + user + ";Password=" + pwd + ";Connect Timeout=10";
                if (!TestConByConStr(newServerConStr, out errMessage))
                {
                    MessageBox.Show("服务器连接失败.失败原因可能为:\r\n" + errMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dt = null;
                if (cboDataBase.DataSource == null)
                    dt = GetAllDbNameByServer(cboServer.Text, tbxuser.Text, tbxpwd.Text);
                else
                    dt = (DataTable)cboDataBase2.DataSource;

                string newDBConStr = MakeConStr(server, db, user, pwd);
                if (dt.Select("name='" + db + "'").Length == 0 || !TestConByConStr(newDBConStr, out errMessage))
                {
                    MessageBox.Show("信息库不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string newLobConStr = MakeConStr(server, lob, user, pwd);
                if (dt.Select("name='" + lob + "'").Length == 0 || !TestConByConStr(newLobConStr, out errMessage))
                {
                    MessageBox.Show("文件库不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!newDBConStr.Equals(ConstParameter.ShipMisSqlConnt) || !newLobConStr.Equals(ConstParameter.ShipMisSqlLobConnt))
                {
                    ConstParameter.ShipMisSqlConnt = newDBConStr;
                    ConstParameter.ShipMisSqlLobConnt = newLobConStr;
                    this.DialogResult = DialogResult.OK;
                    NeedReloading = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
    }

    /// <summary>
    /// 获取网内的数据库服务器名称.
    /// </summary>
    public class SqlLocator
    {
        [System.Runtime.InteropServices.DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);

        [System.Runtime.InteropServices.DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);

        [System.Runtime.InteropServices.DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle);

        [System.Runtime.InteropServices.DllImport("odbc32.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, System.Text.StringBuilder inString,
            short inStringLength, System.Text.StringBuilder outString, short outStringLength, out short outLengthNeeded);

        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;
        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

        /// <summary>
        /// 获取网内的数据库服务器名称，是一个字符串数组。.
        /// </summary>
        /// <returns></returns>
        public static string[] GetServers()
        {
            string list = string.Empty;
            IntPtr henv = IntPtr.Zero;
            IntPtr hconn = IntPtr.Zero;
            System.Text.StringBuilder inString = new System.Text.StringBuilder(SQL_DRIVER_STR);
            System.Text.StringBuilder outString = new System.Text.StringBuilder(DEFAULT_RESULT_SIZE);
            short inStringLength = (short)inString.Length;
            short lenNeeded = 0;
            try
            {
                if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
                {
                    if (SQL_SUCCESS == SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (IntPtr)SQL_OV_ODBC3, 0))
                    {
                        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
                        {
                            if (SQL_NEED_DATA == SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                 DEFAULT_RESULT_SIZE, out lenNeeded))
                            {
                                if (DEFAULT_RESULT_SIZE < lenNeeded)
                                {
                                    outString.Capacity = lenNeeded;
                                    if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                         lenNeeded, out lenNeeded))
                                    {
                                        throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                                    }
                                }
                                list = outString.ToString();
                                int start = list.IndexOf("{") + 1;
                                int len = list.IndexOf("}") - start;
                                if ((start > 0) && (len > 0))
                                {
                                    list = list.Substring(start, len);
                                }
                                else
                                {
                                    list = string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                list = string.Empty;
            }
            finally
            {
                if (hconn != IntPtr.Zero)
                    SQLFreeHandle(SQL_HANDLE_DBC, hconn);
                if (henv != IntPtr.Zero)
                    SQLFreeHandle(SQL_HANDLE_ENV, hconn);
            }
            string[] array = null;
            if (list.Length > 0)
                array = list.Split(',');
            return array;
        }
    }
}