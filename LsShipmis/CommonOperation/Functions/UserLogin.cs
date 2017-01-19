using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;

namespace CommonOperation.Functions
{
    /// <summary>
    /// 用户登录业务类.
    /// </summary>
    public class UserLogin
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        /// <summary>
        /// 用户登录名称.
        /// </summary>
        private string userLoginName;

        /// <summary>
        /// 用户登录口令.
        /// </summary>
        private string userLoginPass;

        public string UserHeadId;
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="userLoginName">用户登录名称</param>
        /// <param name="userLoginPass">用户登录口令</param>
        public UserLogin(string userLoginName, string userLoginPass)
        {
            this.userLoginName = userLoginName;
            this.userLoginPass = userLoginPass;
        }

        /// <summary>
        /// 检测数据库连接是否正确.
        /// </summary>
        /// <returns>如果连接正确，返回true，否则返回false</returns>
        public bool IsConnected()
        { 
            DataTable dtb;    
            string err = "";  
            string sSql = "select userid from t_sys_user";   

            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        /// <summary>
        /// 检证当前登录用户名称是否合法.
        /// </summary>
        /// <returns>如果正确，返回true，否则返回false</returns>
        public bool CheckUser()
        { 
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "userid ";
            sSql += "from t_sys_user ";
            sSql += "where userloginname = '" + userLoginName + "'";

            if (!dbAccess.GetDataTable(sSql, out dtb, out err) || dtb.Rows.Count == 0) return false;
            return true;
        }

        /// <summary>
        /// 检证当前登录口令是否正确.
        /// </summary>
        /// <returns>如果正确，返回true，否则返回false</returns>
        public bool CheckPwd()
        { 
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "userid,SUPPERUSSER ";
            sSql += "from t_sys_user ";
            sSql += "where userloginname = '" + userLoginName + "' ";
            sSql += "and userloginpass = '" + userLoginPass + "'";

            if (!dbAccess.GetDataTable(sSql, out dtb, out err) || dtb.Rows.Count == 0) return false;

            CommonOperation.ConstParameter.SupperUser = (dtb.Rows[0][1].ToString() == "1");
            CommonOperation.ConstParameter.UserId = dtb.Rows[0][0].ToString();
            return true;
        }
  
        /// <summary>
        /// 取得登录用户的岗位Id
        /// </summary>
        /// <returns>返回岗位Id</returns>
        public void GetShipUserInfo()
        {  
            string sSql = "";           //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "b.shipuserid,b.username,a.SHIP_HEADSHIP_ID ";
            sSql += "\rfrom t_ship_user_head a ";
            sSql += "inner join t_ship_user b on a.shipuserid = b.shipuserid ";
            sSql += "inner join t_sys_user c on b.shipuserid = c.shipuserid ";
            sSql += "\rwhere c.userloginname = '" +  dbOperation.ReplaceSqlKeyStr ( userLoginName) + "' ";
            sSql += "and c.userloginpass = '" + dbOperation.ReplaceSqlKeyStr ( userLoginPass) + "'";
            DataTable dtb;
            string err;
            if(!dbAccess.GetDataTable(sSql,out dtb,out err) || dtb.Rows .Count ==0)return ;
            CommonOperation.ConstParameter.ShipUserId = dtb.Rows[0][0].ToString();
            CommonOperation.ConstParameter.UserName = dtb.Rows[0][1].ToString();
            UserHeadId = dtb.Rows[0][2].ToString();    
        }
        /// <summary>
        /// 取得登录用户的岗位Id,不需要密码.
        /// </summary>
        /// <returns>返回岗位Id</returns>
        public void GetShipUserInfoNotPass()
        {
            string sSql = "";           //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "b.shipuserid,b.username,a.SHIP_HEADSHIP_ID ";
            sSql += "\rfrom t_ship_user_head a ";
            sSql += "inner join t_ship_user b on a.shipuserid = b.shipuserid ";
            sSql += "inner join t_sys_user c on b.shipuserid = c.shipuserid ";
            sSql += "\rwhere c.userloginname = '" + dbOperation.ReplaceSqlKeyStr(userLoginName) + "' ";
            DataTable dtb;
            string err;
            if (!dbAccess.GetDataTable(sSql, out dtb, out err) || dtb.Rows.Count == 0) return;
            CommonOperation.ConstParameter.ShipUserId = dtb.Rows[0][0].ToString();
            CommonOperation.ConstParameter.UserName = dtb.Rows[0][1].ToString();
            UserHeadId = dtb.Rows[0][2].ToString();
        }
 
        /// <summary>
        /// 为环境变量dictAllRights加载所有权限名称.
        /// </summary>
        /// <param name="userId">当前用户Id</param>
        /// <returns>返回包含所有权限名称的字典集合</returns>
        public Dictionary<string, bool> GetAllRights(string userId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            Dictionary<string, bool> dictAllRights = new Dictionary<string,bool>();//包含所有权限名称的字典型集合.

            List<string> lstCurUserRights=null; //包含当前登录用户的权限名称的集合.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "distinct right_name ";
            sSql += "from t_right";

            if(!dbAccess.GetDataTable(sSql,out dtb, out err))          
            {
                return null;//如果数据库连接出错，直接返回null
            }

            foreach (DataRow dataRow in dtb.Rows)
            {
                string rightName = dataRow["right_name"].ToString();
                dictAllRights.Add(rightName, false);
            }

            //取得当前登录用户所拥有的权限名称（包括该用户所拥有的权限.

            //及该用户所属职务所拥有的权限）放到一个集合中。.

            lstCurUserRights = this.GetCurUserRights(userId);

            //根据用户当前所拥有的权限来设置所有权限集合中与之对应的权限的可用属性为true
            this.setAllRights(dictAllRights, lstCurUserRights);
            return dictAllRights;
        }

        /// <summary>
        /// 取得当前登录用户所拥有的权限名称（包括该用户所拥有的权限.
        /// 及该用户所属职务所拥有的权限）放到一个集合中返回。.
        /// </summary>
        /// <param name="userId">当前用户Id</param>
        /// <returns>返回当前登录用户所拥有权限名称的集合</returns>
        private List<string> GetCurUserRights(string userId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            List<string> lstCurUserRights = new List<string>();//包含当前登录用户的权限名称的集合.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //1.先取出当前登录用户所拥有的所有权限名称放到lstCurUserRights集合中去.
            sSql = "select ";
            sSql += "a.right_name ";
            sSql += "from t_right a ";
            sSql += "inner join t_ship_user_right b on a.right_id = b.right_id ";
            sSql += "inner join t_sys_user c on b.shipuserid = c.shipuserid ";
            sSql += "where c.userid  = '" + userId + "' ";
            sSql += "order by a.right_name";

            if (!dbAccess.GetDataTable(sSql, out dtb, out err)) return lstCurUserRights;

            foreach (DataRow dataRow in dtb.Rows)
            {
                string rightName = dataRow["right_name"].ToString();
                lstCurUserRights.Add(rightName);
            }

            //2.再取出当前登录用户所属的所有职务所拥有的权限放到lstCurUserRights集合中去，.

            //对于已经存在于集合中的权限不用再添加。.

            sSql = "select ";
            sSql += "a.ship_headship_id ";
            sSql += "from t_ship_user_head a ";
            sSql += "inner join t_ship_user b on a.shipuserid = b.shipuserid ";
            sSql += "inner join t_sys_user c on b.shipuserid = c.shipuserid ";
            sSql += "where c.userid  = '" + userId + "'";

            //取当前登录用户所有的职务信息.
            if (!dbAccess.GetDataTable(sSql, out dtb, out err)) return lstCurUserRights;

            foreach (DataRow dataRow in dtb.Rows)
            {
                //取出当前职务Id
                string shipHeadshipId = dataRow["ship_headship_id"].ToString();

                //取当前职务所拥有权限的SQL语句.
                string sSqlHeadRight = "select ";
                sSqlHeadRight += "a.right_name ";
                sSqlHeadRight += "from t_right a ";
                sSqlHeadRight += "inner join t_ship_head_right b on a.right_id = b.right_id ";
                sSqlHeadRight += "where b.ship_headship_id = '" + shipHeadshipId + "'";
                sSqlHeadRight += "order by a.right_name";

                DataTable dtbHeadRight;
                if (!dbAccess.GetDataTable(sSqlHeadRight, out dtbHeadRight, out err)) return lstCurUserRights;

                //循环取出当前职务的所有权限名称放到lstCurUserRights集合中去（要判断是否重复）.

                foreach (DataRow dataRowHeadRight in dtbHeadRight.Rows)
                {
                    string rightName = dataRowHeadRight["right_name"].ToString();
                    if (!lstCurUserRights.Contains(rightName))
                    {
                        lstCurUserRights.Add(rightName);
                    }
                }
            }

            return lstCurUserRights;
        }

        /// <summary>
        /// 根据用户当前所拥有的权限来设置所有权限集合中与之对应的权限的可用属性为true。.
        /// </summary>
        /// <param name="dictAllRights">包含所有权限的字典型集合</param>
        /// <param name="lstCurUserRights">包含当前登录用户的权限集合</param>
        private void setAllRights(Dictionary<string, bool> dictAllRights, 
                                            List<string> lstCurUserRights)
        {
            foreach (string curUserRight in lstCurUserRights)
            {
                dictAllRights[curUserRight] = true;
            }
        }
        public void restallAUserPassword(string userid,out string err)
        {
            string sSql = "update  T_SYS_USER set USERLOGINPASS = '123456' where userid = '" + userid + "'";

            dbAccess.ExecSql(sSql, out err);
        }

        public void SettingUserInfo()
        {
            if (CommonOperation.ConstParameter.SupperUser)
            {
                CommonOperation.ConstParameter.ShipUserId = "";
                CommonOperation.ConstParameter.UserName = "admin";
                CommonOperation.ConstParameter.LoginUserInfo = new SuperUser();
            }
            else
            {
                GetShipUserInfo();
            }
            CommonOperation.ConstParameter.dictAllRights = GetAllRights(CommonOperation.ConstParameter.UserId);

        }
        public void SettingUserInfoNotPass()
        {
            if (CommonOperation.ConstParameter.SupperUser)
            {
                CommonOperation.ConstParameter.ShipUserId = "";
                CommonOperation.ConstParameter.UserName = "admin";
                CommonOperation.ConstParameter.LoginUserInfo = new SuperUser();
            }
            else
            {
                GetShipUserInfoNotPass();
            }
            CommonOperation.ConstParameter.dictAllRights = GetAllRights(CommonOperation.ConstParameter.UserId);

        }
        public object GetShipHeadShipId()
        {
            throw new NotImplementedException();
        }
    }
}