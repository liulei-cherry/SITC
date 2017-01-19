using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ShipMisZHJ_WorkFlow.Services
{
    public partial class T_DepartmentService
    {
        /// <summary>
        /// 取得指定树节点下的部门信息.
        /// </summary>
        /// <param name="parentId">上级Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetDepartment(string parentId)
        {
            //变量定义部分.
            DataTable dtb = new DataTable();//定义一个DataTable对象.
            string sMidErrMessage = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string sWhere = "";             //查询条件.

            if (parentId == "root")
            {
                sWhere += " and UPDEPARTID is null ";
            }
            else
            {
                sWhere += " and UPDEPARTID = '" + parentId + "' ";
            }

            //Select语句加工部分.
            sSql += "select ";
            sSql += "DepartmentId,";
            sSql += "DEPARTNAME,";
            sSql += "ISLANDDEPART ";
            sSql += "from T_Department ";
            sSql += "where 1 = 1 ";

            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by DEPARTNAME";

            dbAccess.GetDataTable(sSql, out dtb, out sMidErrMessage);
            return dtb;
        }

        /// <summary>
        /// 保存新添加的部门信息.
        /// </summary>
        /// <param name="departId">部门Id</param>
        /// <param name="parentId">上级部门Id</param>
        /// <param name="departName">部门名称</param>
        /// <param name="departType">类型（0表示船舶端部门，1表示陆地端部门）</param>
        /// <param name="sMidErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public void SaveDepartment(string departId, string parentId, string departName,
                                     int departType, out string sMidErrMessage)
        {
            string theParentId = "null";//加工后的上级部门Id（为null值表示当前节点的父节点是根节点）.
            string sSql = "";           //SQL操作语句.

            //如果当前节点的父节点不是根节点.
            if (parentId != "root")
            {
                theParentId = "'" + parentId + "'";
            }

            sSql = "insert into T_Department(DepartmentId, UPDEPARTID, DEPARTNAME, ISLANDDEPART,UNMODIFY) values(";
            sSql += "'" + departId + "'," + theParentId + ",'" + departName + "'," + departType + ",1)";

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(sSql, out sMidErrMessage);
        }

        /// <summary>
        /// 更新部门名称信息.
        /// </summary>
        /// <param name="departId">部门Id</param>
        /// <param name="departName">部门名称</param>
        /// <param name="sMidErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public void UpdateDepartment(string departId, string departName, out string sMidErrMessage)
        {
            string sSql = "";   //SQL操作语句.

            sSql = "update T_Department set DEPARTNAME = '" + departName + "' where DepartmentId = '" + departId + "'";

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(sSql, out sMidErrMessage);
        }

        /// <summary>
        /// 删除部门信息.
        /// </summary>
        /// <param name="unitId">部门Id</param>
        /// <param name="sMidErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public void DelDepartment(string departId, out string sMidErrMessage)
        {
            string sSql = "";   //SQL操作语句.

            sSql = "delete from T_Department where DepartmentId = '" + departId + "'";

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(sSql, out sMidErrMessage);
        }
    }
}
