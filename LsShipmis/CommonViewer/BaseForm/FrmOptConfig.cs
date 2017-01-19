using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using CommonViewer.BaseControl;

namespace CommonViewer.BaseForm
{
    public partial class FrmOptConfig : Form
    {
        public string errMessage;
        public bool NeedReloading = false;
        string path = Application.ExecutablePath + ".config";
        string oldDBConStr = "";
        string oldLobConStr = "";
        string newDBConStr = "";
        string newLobConStr = "";
        public bool IsShow = false;
        public FrmOptConfig()
        {
            InitializeComponent();
        }
        public FrmOptConfig(bool IsShow)
        {
            this.IsShow = IsShow;
            InitializeComponent();
        }

        public delegate void GetDbConnectionString(out string DB, out string LobDB);
        public GetDbConnectionString getDbConnectionString;
        private bool manual = true;
        private void FrmOptConfig_Load(object sender, EventArgs e)
        {
            //if (getDbConnectionString != null) getDbConnectionString(out DB, out LobDB);
            //else throw new Exception("数据连接串无法获取");
            if (TestCon(CommonOperation.ConstParameter.DBConnectString, DataBaseType.DataBase, out errMessage) && TestCon(CommonOperation.ConstParameter.LobDBConnectString, DataBaseType.FileBase, out errMessage))
            {
                oldDBConStr = CommonOperation.ConstParameter.DBConnectString;
                oldLobConStr = CommonOperation.ConstParameter.LobDBConnectString;
            }
            else
            {
                //ReadConfig(); //不再从配置文件中读缺省数据库连接字符串了 - 夏喜龙 2012.2.13修改.
                oldDBConStr = CommonOperation.ConstParameter.ShipMisSqlConnt;
                oldLobConStr = CommonOperation.ConstParameter.ShipMisSqlLobConnt;

            }
            if (oldDBConStr != "")
            {
                DBConStr DBCon = SplitConStr(oldDBConStr);
                this.tbxuser.Text = DBCon.UserID;
                this.tbxpwd.Text = DBCon.Pwd;
                cboServer.Text = DBCon.DataSource;
                cboServer_SelectedIndexChanged(sender, null);
                cboDataBase.Text = DBCon.DataBase;

            }
            if (oldLobConStr != "")
            {
                DBConStr LobCon = SplitConStr(oldLobConStr);
                cboDataBase2.Text = LobCon.DataBase;
            }
            if (this.IsShow)
            {
                this.cboServer.Enabled = false;
                this.tbxuser.Enabled = false;
                this.tbxpwd.Enabled = false;
                this.cboDataBase.Enabled = false;
                this.cboDataBase2.Enabled = false;

                this.checkBox1.Enabled = false;
                this.btnTest.Enabled = false;
                this.btnOK.Enabled = false;
            }
        }

        //private void ReadConfig()
        //{
        //    System.Xml.XmlDocument doc = new XmlDocument();
        //    doc.Load(path);

        //    // 解析完成后,整个 Xml 的内容都在内存中的 DOM 中.
        //    System.Xml.XmlNodeList list = doc.GetElementsByTagName("connectionStrings");
        //    if (list.Count > 0)
        //    {
        //        System.Xml.XmlElement element = list[0] as XmlElement;
        //        // 取得元素的属性.
        //        System.Xml.XmlNodeList lists = element.ChildNodes;
        //        for (int i = 0; i < lists.Count; i++)
        //        {
        //            System.Xml.XmlElement e = lists[i] as XmlElement;
        //            string name = e.GetAttribute("name");
        //            if (name == DB)
        //            {
        //                oldDBConStr = e.GetAttribute("connectionString");
        //            }
        //            else if (name == LobDB)
        //            {
        //                oldLobConStr = e.GetAttribute("connectionString");
        //            }
        //        }
        //    }
        //}

        private DBConStr SplitConStr(string str)
        {
            DBConStr dbConStr = new DBConStr();
            string[] strs = str.Split(';');
            foreach (string s in strs)
            {
                string[] obj = s.Split('=');
                if (obj[0] == "Data Source")
                {
                    dbConStr.DataSource = obj[1];
                }
                if (obj[0] == "Initial Catalog")
                {
                    dbConStr.DataBase = obj[1];
                }
                if (obj[0] == "User ID")
                {
                    dbConStr.UserID = obj[1];
                }
                if (obj[0] == "Password")
                {
                    dbConStr.Pwd = obj[1];
                }
            }
            return dbConStr;
        }

        //得到新的连接字符串.
        private string GetConStr(string tSer, string tDB, TextBox tUser, TextBox tPwd)
        {
            return GetConStr(tSer, tDB, tUser, tPwd, 15);
        }
        private string GetConStr(string tSer, string tDB, TextBox tUser, TextBox tPwd, int timeout)
        {
            StringBuilder conStr = new StringBuilder();
            conStr.Append("Data Source=").Append(tSer);
            conStr.Append(";Initial Catalog=").Append(tDB);
            conStr.Append(";Persist Security Info=True");
            conStr.Append(";User ID=").Append(tUser.Text);
            conStr.Append(";Password=").Append(tPwd.Text);
            conStr.Append(";Connect Timeout=").Append(timeout.ToString());
            return conStr.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            newDBConStr = GetConStr(cboServer.Text, cboDataBase.Text, this.tbxuser, this.tbxpwd);
            newLobConStr = GetConStr(cboServer.Text, cboDataBase2.Text, this.tbxuser, this.tbxpwd);
            bool isSuc = TestCon(newDBConStr, DataBaseType.DataBase, out errMessage) && TestCon(newLobConStr, DataBaseType.FileBase, out errMessage);
            if (isSuc)
                MessageBoxEx.Show("连接成功");
            else
            {
                newDBConStr = "";
                MessageBoxEx.Show(errMessage);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newDBConStr = GetConStr(cboServer.Text, cboDataBase.Text, this.tbxuser, this.tbxpwd);
            newLobConStr = GetConStr(cboServer.Text, cboDataBase2.Text, this.tbxuser, this.tbxpwd);
            if (!TestCon(newDBConStr, DataBaseType.DataBase, out errMessage))
            {
                MessageBoxEx.Show(errMessage);
                return;
            }
            if (!TestCon(newLobConStr, DataBaseType.FileBase, out errMessage))
            {
                MessageBoxEx.Show(errMessage);
                return;
            }
            if (!CommonOperation.ConstParameter.ShipMisSqlConnt.Equals(newDBConStr)
                || !CommonOperation.ConstParameter.ShipMisSqlLobConnt.Equals(newLobConStr))
            {
                CommonOperation.ConstParameter.ShipMisSqlConnt = newDBConStr;
                CommonOperation.ConstParameter.ShipMisSqlLobConnt = newLobConStr;
                NeedReloading = true;
            }
            Close();
        }
        //测试连接.
        private bool TestCon(string conStr, DataBaseType dbType, out string errMessage)
        {
            errMessage = "";
            bool isOK = false;
            SqlConnection connection = new SqlConnection(conStr);

            try
            {
                connection.Open();
                string strSql = string.Empty;
                //检查大文件库.
                if (dbType == DataBaseType.FileBase)
                {
                    strSql = string.Format(@"SELECT COUNT(1) FROM T_FILEINFO");
                    SqlCommand command = new SqlCommand(strSql, connection);
                    command.CommandTimeout = 10;
                    try
                    {
                        int rowCount = int.Parse(command.ExecuteScalar().ToString());
                        if (rowCount <= 0)
                            errMessage = "文件库连接成功，但没有任何记录，可能存在问题，请检查！";
                        isOK = true;
                    }
                    catch
                    {
                        errMessage = "文件库连接失败，请重试！";
                        isOK = false;
                    }
                }
                else
                {
                    //检查信息库.
                    strSql = string.Format(@"SELECT COUNT(1) FROM T_SYS_USER");
                    SqlCommand command = new SqlCommand(strSql, connection);
                    command.CommandTimeout = 10;
                    try
                    {
                        int rowCount = int.Parse(command.ExecuteScalar().ToString());
                        if (rowCount <= 0)
                            errMessage = "信息库连接成功，但表用户表没有任何记录，可能存在问题，请检查！";
                        isOK = true;
                    }
                    catch
                    {
                        errMessage = "信息库连接失败，请重试！";
                        isOK = false;
                    }
                }
            }
            catch
            {
                if (dbType == DataBaseType.FileBase)
                    errMessage = "文件库连接失败，请重试！";
                else
                    errMessage = "信息库连接失败，请重试！";
                isOK = false;
            }
            return isOK;
        }
        //测试连接.
        private bool TestCon1(string conStr, int type)
        {
            if (type == 1)
            {
                if (string.IsNullOrEmpty(cboDataBase.Text) || cboDataBase.Text.Contains("lob"))
                {
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cboDataBase2.Text) || !cboDataBase2.Text.Contains("lob"))
                {
                    return false;
                }
            }
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

        private void tbxpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnTest_Click(sender, null);
            }
        }

        private string[] getDbName(string server, string user, string password)
        {
            string[] arry = null;
            string list = string.Empty;
            string sql = "select name from master.dbo.sysdatabases where name not in ('master','model','msdb','tempdb') order by name";
            SqlConnection oSQLConn = new SqlConnection();
            oSQLConn.ConnectionString = "Data Source=" + server + ";Initial Catalog=master;Persist Security Info=True;User ID=" + user + ";Password=" + password + ";Connect Timeout=5";

            DataTable dat = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sql, oSQLConn);
            try
            {
                adp.Fill(dat);
                if (dat != null && dat.Rows.Count > 0)
                {
                    for (int i = 0; i < dat.Rows.Count; i++)
                    {
                        list += dat.Rows[i][0].ToString();
                        if (i < dat.Rows.Count - 1) list += ",";
                    }
                }
            }
            catch
            { //do nothing
            }

            if (list.Length > 0)
            {
                arry = list.Split(',');
            }

            return arry;
        }

        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!manual)
            {
                string[] database = getDbName(cboServer.Text, tbxuser.Text, tbxpwd.Text);
                string[] database2;
                if (database != null)
                {
                    database2 = (string[])database.Clone();
                    cboDataBase.DataSource = database;
                    cboDataBase2.DataSource = database2;
                }
                else
                {
                    cboDataBase.DataSource = null;
                    cboDataBase2.DataSource = null;
                }
            }
        }

        private void cboDataBase_TextChanged(object sender, EventArgs e)
        {
            string newtestConStr = GetConStr(cboServer.Text, cboDataBase.Text, this.tbxuser, this.tbxpwd);
            if (!manual && TestCon(newtestConStr, DataBaseType.DataBase, out errMessage))
            {
                string newtestLobConStr = GetConStr(cboServer.Text, cboDataBase.Text + "_Lob", this.tbxuser, this.tbxpwd, 1000);
                if (TestCon(newtestLobConStr, DataBaseType.FileBase, out errMessage))
                {
                    cboDataBase2.Text = cboDataBase.Text + "_Lob";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                manual = false;
                if (cboServer.DataSource == null)
                {
                    string[] server = SqlLocator.GetServers();
                    cboServer.DataSource = server;
                }
            }
            else
            {
                manual = true;
            }
        }

    }

    public class DBConStr
    {
        public DBConStr()
        { }
        private string dataSource;
        private string database;
        private string userid;
        private string pwd;

        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public string DataBase
        {
            get { return database; }
            set { database = value; }
        }

        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
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

            short inStringLength, System.Text.StringBuilder outString, short outStringLength,

            out short outLengthNeeded);

        private const short SQL_HANDLE_ENV = 1;

        private const short SQL_HANDLE_DBC = 2;

        private const int SQL_ATTR_ODBC_VERSION = 200;

        private const int SQL_OV_ODBC3 = 3;

        private const short SQL_SUCCESS = 0;

        private const short SQL_NEED_DATA = 99;

        private const short DEFAULT_RESULT_SIZE = 1024;

        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

        private SqlLocator() { }

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
                {

                    SQLFreeHandle(SQL_HANDLE_DBC, hconn);

                }

                if (henv != IntPtr.Zero)
                {

                    SQLFreeHandle(SQL_HANDLE_ENV, hconn);

                }

            }

            string[] array = null;

            if (list.Length > 0)
            {

                array = list.Split(',');

            }

            return array;

        }

        public enum DataBaseType
        {
            FileBase = 2, DataBase = 1
        }
    }

    public enum DataBaseType
    {
        FileBase = 2, DataBase = 1
    }
}