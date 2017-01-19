/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SysUserService.cs
 * 创 建 人：李景育
 * 创建时间：2009-08-24
 * 标    题：系统用户管理业务类
 * 功能描述：实现系统用户管理业务数据的增删改查等业务操作
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 系统用户管理业务类.
    /// </summary>
    public class SysUserService
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        ///  取得系统用户信息数据.
        /// </summary>
        /// <param name="allUser">是否加载所有用户，0表示否（只加载陆地端用户），1表示是</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSysUser(int allUser)
        {
            //变量定义部分.
            DataTable dtb = null;    //定义一个DataTable对象.
            string sMidErrMessage = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.userid,";
            sSql += "a.shipuserid,";
            sSql += "b.username,";
            sSql += "a.userloginname,";
            sSql += "a.creator ";
            sSql += "from t_sys_user a ";
            sSql += "inner join t_ship_user b on a.shipuserid=b.shipuserid ";
            sSql += "where b.username <> '超级用户' ";
            sSql += "order by b.username";

            if (dbAccess.GetDataTable(sSql, out dtb, out sMidErrMessage))
                return dtb;
            else return null;
        }
 
        /// <summary>
        /// 取得为指定人员可分配的船舶信息（注意，这个信息包括已经分配给该用户的船舶及从未分配给任何人的船舶）.
        /// </summary>
        /// <param name="userId">人员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetUserShip(string userId)
        { 
            DataTable dtb = null;    //定义一个DataTable对象.
            string sMidErrMessage = "";         //错误信息返回参数.
            string sSql = string.Format(@" select  
tt1.ship_name , tt1.Ship_Id ,case when t5.User_Ship_Id is null then 0 else 1 end  sel 
from
(select SHIP_NAME,SHIP_ID ,case when charindex([SHIP_CODE],(select top 1 isnull([CODE_VALUE],'')
from [T_ARGUMENT_SET] where [CODE] = 'shandongship') )>0 then 1 else 0 end isShandong 
from T_SHIP) tt1 inner join 
(select top 1 t3.USERID ,case when substring(t2.HEADSHIP_NAME,1,2)= '山东' then 1 else 0 end ISShandong,t3.[USERLOGINNAME]
from T_SHIP_USER_HEAD t1
inner join T_BASE_HEADSHIP t2 on t1.SHIP_HEADSHIP_ID = t2.SHIP_HEADSHIP_ID
inner join T_SYS_USER t3 on t1.SHIPUSERID = t3.SHIPUSERID  and t3.USERID = '{0}'
) tt2 on (case when charindex(tt2.USERLOGINNAME,(select top 1 isnull([CODE_VALUE],'')
from [T_ARGUMENT_SET] where [CODE] = 'allshipperson') )>0 then 1 else 0 end ) =1 or tt1.isshandong = tt2.isshandong  
left join t_user_ship  t5 on  t5.Ship_Id = tt1.SHIP_ID and t5.UserId = tt2.USERID
order by tt1.SHIP_NAME", userId);

            Console.WriteLine(sSql);
            if (dbAccess.GetDataTable(sSql, out dtb, out sMidErrMessage))
                return dtb;
            else return null;
        }
        /// <summary>
        /// 保存为指定用户选择的船舶        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="lstShipIds">包含选择的船舶Id的List泛型集合</param>
        /// <param name="sMidErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveUserShip(string userId, List<string> lstShipIds, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSqlDel = "";    //删除的SQL语句.
            string sSqlInt = "";    //添加的SQL语句.

            //在添加前先删除指定用户userId的所有船舶Id信息.
            sSqlDel = "delete from T_User_Ship where userId = '" + userId + "'";
            lstSqlOpt.Add(sSqlDel);

            //循环泛型集合lstSubjectIds中的每个选择的船舶Id，然后组成一个Insert语句.
            //放到操作集合中去。.
            foreach (string shipId in lstShipIds)
            {
                sSqlInt = "insert into T_User_Ship(User_Ship_Id,UserId,Ship_Id) ";
                sSqlInt += "values('" + Guid.NewGuid().ToString() + "','" + userId + "',";
                sSqlInt += "'" + shipId + "')";
                lstSqlOpt.Add(sSqlInt);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
           return dbAccess.ExecSql(lstSqlOpt, out err);
        }
        /// <summary>
        /// 得到一个用户的所属
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>"上海","山东",""(未来可以扩展)</returns>
        public string GetPersonBelong(string userid)
        { 
            string sSql  = "";    //添加的SQL语句.

            //在添加前先删除指定用户userId的所有船舶Id信息.
            sSql = string.Format(@"select top 1 case when charindex(USERLOGINNAME,(select top 1 isnull([CODE_VALUE],'')
from [T_ARGUMENT_SET] where [CODE] = 'allshipperson') )>0 then '' else
(case when substring(t2.HEADSHIP_NAME,1,2)= '山东' then '山东' else '上海' end) end 
from T_SHIP_USER_HEAD t1
inner join T_BASE_HEADSHIP t2 on t1.SHIP_HEADSHIP_ID = t2.SHIP_HEADSHIP_ID
inner join T_SYS_USER t3 on t1.SHIPUSERID = t3.SHIPUSERID  and t3.USERID = '{0}'", userid);
              
            return dbAccess.GetString(sSql);
        }
    }
}