/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有

 * 文 件 名：PostInfoService.cs
 * 创 建 人：徐正本

 * 创建时间：2010-6-25
 * 标    题：数据操作类

 * 功能描述：T_BASE_HEADSHIP数据操作类

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
    /// 数据层实例化接口类 dbo.T_BASE_HEADSHIPService.cs
    /// </summary>
    public partial class PostService : IObjectsService
    {

        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static PostService instance = new PostService();
        public static PostService Instance
        {
            get
            {
                if (null == instance)
                {
                    PostService.instance = new PostService();
                }
                return PostService.instance;
            }
        }
        private PostService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Post对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Post unit, out string err)
        {
            if (unit.POSTID != null && unit.POSTID.Length > 0) //edit
            {
                sql = "UPDATE [T_BASE_HEADSHIP] SET "
                    + " [SHIP_HEADSHIP_ID] = " + (string.IsNullOrEmpty(unit.POSTID) ? "null" : "'" + unit.POSTID.Replace("'", "''") + "'")
                    + " , [DEPARTMENTID] = " + (string.IsNullOrEmpty(unit.DEPARTMENTID) ? "null" : "'" + unit.DEPARTMENTID.Replace("'", "''") + "'")
                    + " , [ISHEADER] = " + unit.ISHEADER.ToString()
                    + " , [HEADSHIP_NAME] = " + (unit.POSTNAME == null ? "" : "'" + unit.POSTNAME.Replace("'", "''")) + "'"
                    + " , [POSTCODE] = " + (unit.POSTCODE == null ? "" : "'" + unit.POSTCODE.Replace("'", "''")) + "'"
                    + " , [POSTLEVEL] = " + unit.POSTLEVEL.ToString()
                    + " , [ISLANDPOST] = " + unit.ISLANDPOST.ToString()
                    + ",  [ISHIGHLEVELSHIPMAN] = " + unit.IsHighLevelShipMan.ToString()
                    + " , [DETAIL] = " + (unit.DETAIL == null ? "" : "'" + unit.DETAIL.Replace("'", "''")) + "'"
                    + " , [POSTTYPE] = " + (unit.POSTTYPE == null ? "" : "'" + unit.POSTTYPE.Replace("'", "''")) + "'"
                    + " where upper(SHIP_HEADSHIP_ID) = '" + unit.POSTID.ToUpper() + "'";
            }
            else
            {
                unit.POSTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_BASE_HEADSHIP] ("
                    + "[SHIP_HEADSHIP_ID],"
                    + "[DEPARTMENTID],"
                    + "[ISHEADER],"
                    + "[HEADSHIP_NAME],"
                    + "[POSTCODE],"
                    + "[POSTLEVEL],"
                    + "[ISLANDPOST],"
                    + "[ISHIGHLEVELSHIPMAN],"
                    + "[DETAIL],"
                    + "[POSTTYPE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.POSTID) ? "null" : "'" + unit.POSTID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.DEPARTMENTID) ? "null" : "'" + unit.DEPARTMENTID.Replace("'", "''") + "'")
                    + " ," + unit.ISHEADER.ToString()
                    + " , " + (unit.POSTNAME == null ? "''" : "'" + unit.POSTNAME.Replace("'", "''")) + "'"
                    + " , " + (unit.POSTCODE == null ? "''" : "'" + unit.POSTCODE.Replace("'", "''")) + "'"
                    + " ," + unit.POSTLEVEL.ToString()
                    + " ," + unit.ISLANDPOST.ToString()
                    + "," + unit.IsHighLevelShipMan.ToString()
                    + " , " + (unit.DETAIL == null ? "''" : "'" + unit.DETAIL.Replace("'", "''")) + "'"
                    + " , " + (unit.POSTTYPE == null ? "''" : "'" + unit.POSTTYPE.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_BASE_HEADSHIP中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_BASE_HEADSHIP对象</param>
        internal bool deleteUnit(Post unit, out string err)
        {
            return deleteUnit(unit.POSTID, out err);
        }

        /// <summary>
        /// 删除数据表T_BASE_HEADSHIP中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_BASE_HEADSHIP.SHIP_HEADSHIP_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_BASE_HEADSHIP where "
                + " upper(T_BASE_HEADSHIP.SHIP_HEADSHIP_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_BASE_HEADSHIP 所有数据信息.
        /// </summary>
        /// <returns>T_BASE_HEADSHIP DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + "  from T_BASE_HEADSHIP order by ISLANDPOST desc,POSTLEVEL,HEADSHIP_NAME";
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
        /// <returns>Post DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + " from T_BASE_HEADSHIP "
                + " where upper(SHIP_HEADSHIP_ID)='" + Id.ToUpper() + "'";
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
        /// 根据post 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>post 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public Post getObject(DataRow dr)
        {
            Post unit = new Post();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Post类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SHIP_HEADSHIP_ID"])
                unit.POSTID = dr["SHIP_HEADSHIP_ID"].ToString();
            if (DBNull.Value != dr["DEPARTMENTID"])
                unit.DEPARTMENTID = dr["DEPARTMENTID"].ToString();
            if (DBNull.Value != dr["ISHEADER"])
                unit.ISHEADER = Convert.ToDecimal(dr["ISHEADER"]);
            if (DBNull.Value != dr["HEADSHIP_NAME"])
                unit.POSTNAME = dr["HEADSHIP_NAME"].ToString();
            if (DBNull.Value != dr["POSTCODE"])
                unit.POSTCODE = dr["POSTCODE"].ToString();
            if (DBNull.Value != dr["POSTLEVEL"])
                unit.POSTLEVEL = Convert.ToDecimal(dr["POSTLEVEL"]);
            if (DBNull.Value != dr["ISLANDPOST"])
                unit.ISLANDPOST = Convert.ToDecimal(dr["ISLANDPOST"]);
            if (DBNull.Value != dr["ISHIGHLEVELSHIPMAN"])
                unit.IsHighLevelShipMan = Convert.ToDecimal(dr["ISHIGHLEVELSHIPMAN"]);
            if (DBNull.Value != dr["DETAIL"])
                unit.DETAIL = dr["DETAIL"].ToString();
            if (DBNull.Value != dr["POSTTYPE"])
                unit.POSTTYPE = dr["POSTTYPE"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Post对象.
        /// </summary>
        /// <param name="SHIP_HEADSHIP_ID">SHIP_HEADSHIP_ID</param>
        /// <returns>Post对象</returns>
        public Post getObject(string Id, out string err)
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
            reValue.Add("HEADSHIP_NAME", "岗位名称");
            reValue.Add("POSTCODE", "岗位编码");
            reValue.Add("DETAIL", "岗位描述");
            return reValue;
        }

        #endregion

        /// <summary>
        /// 得到  T_BASE_HEADSHIP 所有数据信息.
        /// </summary>
        /// <returns>T_BASE_HEADSHIP DataTable</returns>
        public DataTable getDepartPosts(string departmentid, out string err)
        {
            sql = "update T_BASE_HEADSHIP set DEPARTMENTID = null where departmentid not in (select departmentid from T_DEPARTMENT)";
            dbAccess.ExecSql(sql, out err);
            sql = "select	"
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + "\rfrom T_BASE_HEADSHIP";
            if (!string.IsNullOrEmpty(departmentid))
                sql += "\rwhere departmentId = '" + departmentid + "'  order by ISLANDPOST desc,POSTLEVEL,HEADSHIP_NAME";
            else
                sql += "\rwhere isnull(departmentId,'') = '' order by ISLANDPOST desc,POSTLEVEL,HEADSHIP_NAME";
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
        /// 得到部门的部门长;
        /// 不涉及递归问题,就是当前部门的部门长.
        /// </summary>
        /// <param name="departmentid"></param>
        /// <param name="leaderPost"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetDepartLeaderPost(string departmentid, out Post leaderPost, out string err)
        {
            leaderPost = null;
            sql = "select	"
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + "\rfrom T_BASE_HEADSHIP";
            if (!string.IsNullOrEmpty(departmentid))
                sql += "\rwhere departmentId = '" + departmentid + "' and ISHEADER = 1 order by ISLANDPOST,POSTLEVEL";
            string postId;
            if (!dbAccess.GetString(sql, out postId, out err)) return false;
            leaderPost = (Post)GetOneObjectById(postId);
            return true;
        }

        public CommonOperation.BaseClass.CommonClass GetOneObjectByName(string HEADSHIP_NAME)
        {
            string err;
            DataTable dt = getInfoByName(HEADSHIP_NAME, out err);
            if (dt.Rows.Count > 0) return getObject(dt.Rows[0]);
            else return null;
        }

        /// <summary>
        /// 根据一个主键ID,得到 T_BASE_HEADSHIP 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>PostInfo DataTable</returns>
        private DataTable getInfoByName(string name, out string err)
        {
            sql = "select	"
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + "  from T_BASE_HEADSHIP"
                + "\rwhere HEADSHIP_NAME = '" + name + "'";
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

        public bool GetPostHeader(Post post, out Post rePost, out string err)
        {
            rePost = null;
            err = "传入的岗位无效或为岸端岗位,当前只支持获取船端岗位的部门长!";
            if (post != null && post.ISLANDPOST != 1)
            {
                //找到岗位所在部门,必须是船上部门.
                Department tempDept;
                post.FillThisObject();
                tempDept = post.Belonging;
                if (tempDept == null) return false;
                while (tempDept != null)
                {
                    tempDept.FillThisObject();
                    if (tempDept.Belonging != null)
                    {
                        if (tempDept.Belonging.DEPARTNAME == "船上部门")
                            break;
                        tempDept = tempDept.Belonging;
                    }
                    else return false;
                }
                //把其id取出,获取其责任人, 
                return GetDepartLeaderPost(tempDept.GetId(), out rePost, out err);
            }
            return false;
        }

        public DataTable GetLandOrShipPostList(bool landPostList, bool onlyLeader)
        {
            sql = "select	"
              + "SHIP_HEADSHIP_ID"
              + ",DEPARTMENTID"
              + ",ISHEADER"
              + ",HEADSHIP_NAME"
              + ",POSTCODE"
              + ",POSTLEVEL"
              + ",ISLANDPOST"
              + ",ISHIGHLEVELSHIPMAN"
              + ",DETAIL"
              + ",POSTTYPE"
              + "\rfrom T_BASE_HEADSHIP"
              + "\rwhere ( ISLANDPOST " + (landPostList ? "=1)" : "<>1 and ISHIGHLEVELSHIPMAN =1) ") + (onlyLeader ? " and ISLANDPOST <> 1 and ISHEADER=1" : "")
              + "\rorder by ISLANDPOST desc,POSTLEVEL,HEADSHIP_NAME";
            string err;
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

        public string GetShipCaptainName()
        {
            sql = "select top 1username from T_SHIP_USER t1"
                + "\rinner join T_SHIP_USER_HEAD t2 on t1.SHIPUSERID = t2.SHIPUSERID"
                + "\rinner join T_BASE_HEADSHIP t3 on t2.SHIP_HEADSHIP_ID = t3.SHIP_HEADSHIP_ID"
                + "\rwhere t3.HEADSHIP_NAME = '船长' order by t3.postlevel";
            return dbAccess.GetString(sql);
        }

        public string GetShipChiefEngineer()
        {
            sql = "select top 1username from T_SHIP_USER t1"
              + "\rinner join T_SHIP_USER_HEAD t2 on t1.SHIPUSERID = t2.SHIPUSERID"
              + "\rinner join T_BASE_HEADSHIP t3 on t2.SHIP_HEADSHIP_ID = t3.SHIP_HEADSHIP_ID"
              + "\rwhere t3.HEADSHIP_NAME = '轮机长' order by t3.postlevel";
            return dbAccess.GetString(sql);
        }

        /// <summary>
        /// 通过岗位类型获取数据.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getInfoByType(string type, out string err)
        {
            sql = "select "
                + "SHIP_HEADSHIP_ID"
                + ",DEPARTMENTID"
                + ",ISHEADER"
                + ",HEADSHIP_NAME"
                + ",POSTCODE"
                + ",POSTLEVEL"
                + ",ISLANDPOST"
                + ",ISHIGHLEVELSHIPMAN"
                + ",DETAIL"
                + ",POSTTYPE"
                + " from T_BASE_HEADSHIP "
                + " where upper(POSTTYPE)='" + type.ToUpper() + "'";
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
        /// 通过岗位类型获得岗位.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public Post getObjectByType(string type, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfoByType(type, out err);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("岗位信息不完整");
                    return new Post();
                }
                else
                {
                    return getObject(dt.Rows[0]);
                }
            }
            catch
            {
                return getObject(null);
            }
        }

        /// <summary>
        /// 获取岗位类型.
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getPostTypes(string departmentID, out string err)
        {
            sql = "select PostType as POSTTYPE,HEADSHIP_NAME as  PostName, case when ISHEADER <> 0  then '是' end  as  PostHeader from T_BASE_HEADSHIP where upper(DepartmentId)='" + departmentID.ToUpper() + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 获取部门ID
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string getDept(string postType)
        {
            sql = "select DepartmentId from T_BASE_HEADSHIP where upper(PostType)='" + postType.ToUpper() + "'";
            return dbAccess.GetString(sql);
        }

        /// <summary>
        /// 获取某人的岗位类型
        /// </summary>
        public string GetUserPostType(string username)
        {
            sql = @"select posttype from T_SHIP_USER su
inner join T_SHIP_USER_HEAD suh on su.SHIPUSERID=suh.SHIPUSERID
inner join T_BASE_HEADSHIP bh on suh.SHIP_HEADSHIP_ID=bh.SHIP_HEADSHIP_ID
where su.USERNAME='" + username + "'";
            return dbAccess.GetString(sql);
        }
    }
}
