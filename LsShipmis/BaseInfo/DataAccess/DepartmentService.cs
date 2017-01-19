/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：DepartmentService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010-12-30
 * 标    题：数据操作类
 * 功能描述：
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using System.Windows.Forms;

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_UNITService.cs
    /// </summary>
    public partial class DepartmentService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static DepartmentService instance = new DepartmentService();
        public static DepartmentService Instance
        {
            get
            {
                if (null == instance)
                {
                    DepartmentService.instance = new DepartmentService();
                }
                return DepartmentService.instance;
            }
        }
        private DepartmentService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Department对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Department unit, out string err)
        {
            if (unit.DEPARTMENTID != null && unit.DEPARTMENTID.Length > 0) //edit
            {
                sql = "UPDATE [T_DEPARTMENT] SET "
                    + " [DEPARTMENTID] = " + (string.IsNullOrEmpty(unit.DEPARTMENTID) ? "null" : "'" + unit.DEPARTMENTID.Replace("'", "''") + "'")
                    + " , [DEPARTNAME] = " + (unit.DEPARTNAME == null ? "''" : "'" + unit.DEPARTNAME.Replace("'", "''") + "'")
                    + " , [DEPARTCODE] = " + (unit.DEPARTCODE == null ? "''" : "'" + unit.DEPARTCODE.Replace("'", "''") + "'")
                    + " , [DEPARTMENTTYPE] = " + (unit.DEPARTMENTTYPE == null ? "''" : "'" + unit.DEPARTMENTTYPE.Replace("'", "''") + "'")
                    + " , [UPDEPARTID] = " + (string.IsNullOrEmpty(unit.UPDEPARTID) ? "null" : "'" + unit.UPDEPARTID.Replace("'", "''") + "'")
                    + " , [ISLANDDEPART] = " + unit.ISLANDDEPART.ToString()
                    + " , [SORTNO] = " + unit.SORTNO.ToString()
                    + " , [UNMODIFY] = " + unit.UNMODIFY.ToString()
                    + " , [DETAIL] = " + (unit.DETAIL == null ? "''" : "'" + unit.DETAIL.Replace("'", "''") + "'")
                    + " where upper(DEPARTMENTID) = '" + unit.DEPARTMENTID.ToUpper() + "'";
            }
            else
            {
                unit.DEPARTMENTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_DEPARTMENT] ("
                    + "[DEPARTMENTID],"
                    + "[DEPARTNAME],"
                    + "[DEPARTCODE],"
                    + "[DEPARTMENTTYPE],"
                    + "[UPDEPARTID],"
                    + "[ISLANDDEPART],"
                    + "[SORTNO],"
                    + "[UNMODIFY],"
                    + "[DETAIL]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.DEPARTMENTID) ? "null" : "'" + unit.DEPARTMENTID.Replace("'", "''") + "'")
                    + " , " + (unit.DEPARTNAME == null ? "''" : "'" + unit.DEPARTNAME.Replace("'", "''") + "'")
                    + " , " + (unit.DEPARTCODE == null ? "''" : "'" + unit.DEPARTCODE.Replace("'", "''") + "'")
                    + " , " + (unit.DEPARTMENTTYPE == null ? "''" : "'" + unit.DEPARTMENTTYPE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.UPDEPARTID) ? "null" : "'" + unit.UPDEPARTID.Replace("'", "''") + "'")
                    + " ," + unit.ISLANDDEPART.ToString()
                    + " ," + unit.SORTNO.ToString()
                    + " ," + unit.UNMODIFY.ToString()
                    + " , " + (unit.DETAIL == null ? "''" : "'" + unit.DETAIL.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_DEPARTMENT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_DEPARTMENT对象</param>
        internal bool deleteUnit(Department unit, out string err)
        {
            return deleteUnit(unit.DEPARTMENTID, out err);
        }

        /// <summary>
        /// 删除数据表T_DEPARTMENT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_DEPARTMENT.dEPARTMENTID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_DEPARTMENT where "
                + " upper(T_DEPARTMENT.DEPARTMENTID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_DEPARTMENT 所有数据信息.
        /// </summary>
        /// <returns>T_DEPARTMENT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "DEPARTMENTID"
                + ",DEPARTNAME"
                + ",DEPARTCODE"
                + ",UPDEPARTID"
                + ",ISLANDDEPART"
                + ",SORTNO"
                + ",UNMODIFY"
                + ",DETAIL"
                + "\rfrom T_DEPARTMENT  order by SORTNO";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_DEPARTMENT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Department DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "DEPARTMENTID"
                + ",DEPARTNAME"
                + ",DEPARTCODE"
                + ",DEPARTMENTTYPE"
                + ",UPDEPARTID"
                + ",ISLANDDEPART"
                + ",SORTNO"
                + ",UNMODIFY"
                + ",DETAIL"
                + "\rfrom T_DEPARTMENT "
                + "\rwhere upper(DEPARTMENTID)='" + Id.ToUpper() + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据department 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>department 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public Department getObject(DataRow dr)
        {
            Department unit = new Department();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Department类对象!";
                return unit;
            }
            if (DBNull.Value != dr["DEPARTMENTID"])
                unit.DEPARTMENTID = dr["DEPARTMENTID"].ToString();
            if (DBNull.Value != dr["DEPARTNAME"])
                unit.DEPARTNAME = dr["DEPARTNAME"].ToString();
            if (DBNull.Value != dr["DEPARTCODE"])
                unit.DEPARTCODE = dr["DEPARTCODE"].ToString();
            if (DBNull.Value != dr["DEPARTMENTTYPE"])
                unit.DEPARTMENTTYPE = dr["DEPARTMENTTYPE"].ToString();
            if (DBNull.Value != dr["UPDEPARTID"])
                unit.UPDEPARTID = dr["UPDEPARTID"].ToString();
            if (DBNull.Value != dr["ISLANDDEPART"])
                unit.ISLANDDEPART = Convert.ToDecimal(dr["ISLANDDEPART"]);
            if (DBNull.Value != dr["SORTNO"])
                unit.SORTNO = Convert.ToDecimal(dr["SORTNO"]);
            if (DBNull.Value != dr["UNMODIFY"])
                unit.UNMODIFY = Convert.ToDecimal(dr["UNMODIFY"]);
            if (DBNull.Value != dr["DETAIL"])
                unit.DETAIL = dr["DETAIL"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Department对象.
        /// </summary>
        /// <param name="dEPARTMENTID">dEPARTMENTID</param>
        /// <returns>Department对象</returns>
        public Department getObject(string Id, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfo(Id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {
                return getObject(null);
            }
        }
        #endregion

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("DEPARTCODE", "部门编码");
            reValue.Add("DEPARTNAME", "部门名称");
            reValue.Add("UPDEPARTID", "上级部门");
            reValue.Add("ISLANDDEPART", "岸端部门");
            reValue.Add("DETAIL", "部门描述");
            return reValue;
        }

        #endregion

        public CommonOperation.BaseClass.CommonClass GetOneObjectByName(string postName)
        {
            string err;
            DataTable dt = getInfoByName(postName, out err);
            if (dt.Rows.Count >= 0) return getObject(dt.Rows[0]);
            else throw new Exception("没有定义" + postName + "名称的职务");
        }
        /// <summary>
        /// 得到  T_DEPARTMENT 所有数据信息.
        /// </summary>
        /// <returns>T_DEPARTMENT DataTable</returns>
        public DataTable GetInfo(bool landDepart, out string err)
        {
            sql = "select	"
                + "DEPARTMENTID"
                + ",DEPARTNAME"
                + ",DEPARTCODE"
                + ",UPDEPARTID"
                + ",ISLANDDEPART"
                + ",SORTNO"
                + ",UNMODIFY"
                + ",DETAIL"
                + "\rfrom T_DEPARTMENT"
                + "\rwhere ISLANDDEPART " + (landDepart ? " = 1" : " <> 1") + " and isnull(UPDEPARTID,'') <>''"
                + "\rand DEPARTNAME not in ('岸上部门','船上部门') order by SORTNO";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_BASE_HEADSHIP 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>PostInfo DataTable</returns>
        private DataTable getInfoByName(string name, out string err)
        {
            sql = "select	"
                + "DEPARTMENTID"
                + ",DEPARTNAME"
                + ",DEPARTCODE"
                + ",DEPARTMENTTYPE"
                + ",UPDEPARTID"
                + ",ISLANDDEPART"
                + ",SORTNO"
                + ",UNMODIFY"
                + ",DETAIL"
                + "\rfrom T_DEPARTMENT "
                + "\rwhere DEPARTNAME = '" + name + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据"轮机长岗位"或"大副岗位",得到部门长名称.
        /// </summary>
        public bool GetDepartmentHeaderByPostType(string postType, out string username, out string err)
        {
            err = "";
            username = "";
            sql = @"select username from t_ship_user su
left join t_ship_user_head suh on suh.shipuserid=su.shipuserid
left join t_base_headship bh on suh.ship_headship_id= bh.ship_headship_id
where posttype='" + postType + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count > 0)
                    username = dt.Rows[0]["username"].ToString();
                return true;
            }
            else
            {
                return false;
            }

        }
        internal List<Department> GetDepartmentByParentId(string parentId)
        {
            List<Department> lstDepartment = new List<Department>();
            sql = "select	"
              + "DEPARTMENTID"
              + ",DEPARTNAME"
              + ",DEPARTCODE"
              + ",DEPARTMENTTYPE"
              + ",UPDEPARTID"
              + ",ISLANDDEPART"
              + ",SORTNO"
              + ",UNMODIFY"
              + ",DETAIL"
              + "\rfrom T_DEPARTMENT "
              + "\rwhere UPDEPARTID = '" + parentId.Replace("'", "''") + "' order by SORTNO";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstDepartment.Add(getObject(dr));
                }
                return lstDepartment;
            }

            throw new Exception(err);

        }

        /// <summary>
        /// 判断一个部门是否是另一个部门的子部门.
        /// 用于部门上下级设置时使用,避免一个高级部门选择上级为自己的下级部门造成闭环.
        /// </summary>
        /// <param name="departmentId">要判断的部门</param>
        /// <param name="departmentId2">目标部门</param>
        /// <returns></returns>
        public bool ADepartmentIsChildOfAnotherOne(string departmentId, string aimDepartmentId, out bool isChild)
        {
            isChild = true;
            if (string.IsNullOrEmpty(departmentId) || string.IsNullOrEmpty(aimDepartmentId) ||
                departmentId.Length != 36 || aimDepartmentId.Length != 36) return false;
            sql = "WITH  aimTable(departmentid,upids)AS(" +
                   "\rselect departmentid,updepartid" +
                   "\rfrom t_department " +
                   "\rwhere departmentid = '" + aimDepartmentId.Replace("'", "''") + "'" +
                   "\runion all" +
                   "\rselect t_department.departmentid,t_department.updepartid" +
                   "\rfrom aimTable inner join t_department on t_department.departmentid = aimTable.upids)" +
                   "\rselect count(1) from aimTable" +
                   "\rwhere upids = '" + departmentId.Replace("'", "''") + "'";
            isChild = dbAccess.GetString(sql) == "1";
            return true;
        }

        /// <summary>
        /// 根据部门类型得到部门信息.
        /// </summary>
        /// <returns>T_DEPARTMENT DataTable</returns>
        public Department GetInfoByDepartmentType(string DEPARTMENTTYPE, out string err)
        {
            sql = "select	"
                + "DEPARTMENTID"
                + ",DEPARTNAME"
                + ",DEPARTCODE"
                + ",UPDEPARTID"
                + ",ISLANDDEPART"
                + ",SORTNO"
                + ",UNMODIFY"
                + ",DETAIL"
                + ",DEPARTMENTTYPE"
                + "\rfrom T_DEPARTMENT"
                + "\rwhere DEPARTMENTTYPE ='" + DEPARTMENTTYPE + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count == 0)
                {
                    err = "部门信息不完整!";
                    return new Department();
                }
                else
                {
                    return this.getObject(dt.Rows[0]);
                }
            }
            else
            {
                throw new Exception(err);
            }
        }

        public void reloadTree(TreeView departTree,out Department topDepartment)
        {
            string err;
            // 把默认的几个节点加载上,如果数据库中没有,则自动生成.

            try
            {
                topDepartment = (Department)DepartmentService.Instance.GetOneObjectByName("部门信息");
            }
            catch
            {
                topDepartment = new Department("", "部门信息", "", "其它部门", "", 1, 1, 1, "");
                topDepartment.Update(out err);
            }
            Department top21;//岸上部门.
            try
            {
                top21 = (Department)DepartmentService.Instance.GetOneObjectByName("岸上部门");
                if (top21.UPDEPARTID != topDepartment.GetId())
                {
                    top21.UPDEPARTID = topDepartment.GetId();
                    top21.Update(out err);
                }
            }
            catch
            {
                top21 = new Department("", "岸上部门", "", "其它部门", topDepartment.GetId(), 1, 10, 1, "");
                top21.Update(out err);
            }
            Department top22;//船上部门.
            try
            {
                top22 = (Department)DepartmentService.Instance.GetOneObjectByName("船上部门");
                if (top22.UPDEPARTID != topDepartment.GetId())
                {
                    top22.UPDEPARTID = topDepartment.GetId();
                    top22.Update(out err);
                }
            }
            catch
            {
                top22 = new Department("", "船上部门", "", "其它部门", topDepartment.GetId(), 2, 20, 1, "");
                top22.Update(out err);
            }

            departTree.Nodes[0].Tag = topDepartment;
            departTree.Nodes[0].Nodes[0].Tag = top21;
            departTree.Nodes[0].Nodes[1].Tag = top22;
        }

    }
}
