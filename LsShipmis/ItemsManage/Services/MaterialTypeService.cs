/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialTypeService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/18
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_TYPE数据操作类
 * Codesmith DataAccessLayer.cst 1.01版本生成
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
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MATERIAL_TYPEService.cs
    /// </summary>
    public partial class MaterialTypeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MaterialTypeService instance = new MaterialTypeService();
        public static MaterialTypeService Instance
        {
            get
            {
                if (null == instance)
                {
                    MaterialTypeService.instance = new MaterialTypeService();
                }
                return MaterialTypeService.instance;
            }
        }
        private MaterialTypeService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialType对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MaterialType unit, out string err)
        {
            if (unit.MATERIAL_TYPE_ID != null && unit.MATERIAL_TYPE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL_TYPE] SET "
                    + " [MATERIAL_TYPE_ID] = " + (string.IsNullOrEmpty(unit.MATERIAL_TYPE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_ID) + "'")
                    + " , [SUPERIOR_ID] = " + (string.IsNullOrEmpty(unit.SUPERIOR_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SUPERIOR_ID) + "'")
                    + " , [MATERIAL_TYPE_NAME] = " + (unit.MATERIAL_TYPE_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_NAME) + "'")
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + "\rwhere MATERIAL_TYPE_ID = '" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_ID) + "'";
            }
            else
            {
                unit.MATERIAL_TYPE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_TYPE] ("
                    + "[MATERIAL_TYPE_ID],"
                    + "[SUPERIOR_ID],"
                    + "[MATERIAL_TYPE_NAME],"
                    + "[REMARK]"
                    + "[ISVALID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.MATERIAL_TYPE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SUPERIOR_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SUPERIOR_ID) + "'")
                    + " , " + (unit.MATERIAL_TYPE_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_NAME) + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'"+"1")
                    
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_MATERIAL_TYPE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_TYPE对象</param>
        internal bool deleteUnit(MaterialType unit, out string err)
        {
            return deleteUnit(unit.MATERIAL_TYPE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_MATERIAL_TYPE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_TYPE.mATERIAL_TYPE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MATERIAL_TYPE where MATERIAL_TYPE_ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MATERIAL_TYPE 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_TYPE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "MATERIAL_TYPE_ID"
                + ",SUPERIOR_ID"
                + ",MATERIAL_TYPE_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL_TYPE and ISVALID=1 ";
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
        /// 根据一个主键ID,得到 T_MATERIAL_TYPE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialType DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "MATERIAL_TYPE_ID"
                + ",SUPERIOR_ID"
                + ",MATERIAL_TYPE_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL_TYPE "
                + "\rwhere MATERIAL_TYPE_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据materialtype 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>materialtype 数据实体</returns>
        public MaterialType getObject(DataRow dr)
        {
            MaterialType unit = new MaterialType();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialType类对象!";
                return unit;
            }
            if (DBNull.Value != dr["MATERIAL_TYPE_ID"])
                unit.MATERIAL_TYPE_ID = dr["MATERIAL_TYPE_ID"].ToString();
            if (DBNull.Value != dr["SUPERIOR_ID"])
                unit.SUPERIOR_ID = dr["SUPERIOR_ID"].ToString();
            if (DBNull.Value != dr["MATERIAL_TYPE_NAME"])
                unit.MATERIAL_TYPE_NAME = dr["MATERIAL_TYPE_NAME"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个MaterialType对象.
        /// </summary>
        /// <param name="mATERIAL_TYPE_ID">mATERIAL_TYPE_ID</param>
        /// <returns>MaterialType对象</returns>
        public MaterialType getObject(string Id, out string err)
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

        internal bool MaterialTypeCanBeOthersSubClassification(MaterialType toJudgeOne, MaterialType theParentOne, out string err)
        {
            if (theParentOne != null)
            {
                MaterialType temp = theParentOne;
                while (temp != null && !temp.IsWrong)
                {
                    if (temp.GetId() != toJudgeOne.GetId())
                        temp = MaterialTypeService.Instance.getObject(temp.SUPERIOR_ID, out err);
                    else
                    {
                        err = "出现循环设定,不能将物资分类的上级设置为自己或自己的下级";
                        return false;
                    }
                }
                err = "";
                return true;
            }
            err = "没有拖到有效节点";
            return false;
        }

        internal bool InsertRoot(out string err)
        {
            sql = "select count(1) from dbo.T_MATERIAL_TYPE where SUPERIOR_ID is null";
            if (dbAccess.GetString(sql) == "0")
            {
                sql = "insert into dbo.T_MATERIAL_TYPE ( ([MATERIAL_TYPE_ID],[SUPERIOR_ID],[MATERIAL_TYPE_NAME],[ISVALID]))"
                      + "\rVALUES(newid(),null,'物资根结点',1)";
                return dbAccess.ExecSql(sql, out err);
            }
            err = "";
            return true;
        }

        internal List<MaterialType> getRootItems()
        {
            List<MaterialType> reItems = new List<MaterialType>();
            string err;
            sql = "select "
                + "MATERIAL_TYPE_ID"
                + ",SUPERIOR_ID"
                + ",MATERIAL_TYPE_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL_TYPE "
                + "\rwhere SUPERIOR_ID is null and ISVALID=1" 
                + "\rorder by MATERIAL_TYPE_NAME";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MaterialType materialType = getObject(dt.Rows[i]);
                    reItems.Add(materialType);
                }
                return reItems;
            }
            else
            {
                throw new Exception(err);
            }
        }

        internal List<MaterialType> GetObjectsByParentId(string classId)
        {
            if (string.IsNullOrEmpty(classId)) return getRootItems();
            List<MaterialType> reItems = new List<MaterialType>();
            string err;
            sql = "select "
                + "MATERIAL_TYPE_ID"
                + ",SUPERIOR_ID"
                + ",MATERIAL_TYPE_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL_TYPE "
                + "\rwhere SUPERIOR_ID ='" + dbOperation.ReplaceSqlKeyStr(classId) + "' and ISVALID=1"
                + "\rorder by MATERIAL_TYPE_NAME";

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MaterialType materialType = getObject(dt.Rows[i]);
                    reItems.Add(materialType);
                }
                return reItems;
            }
            else
            {
                throw new Exception(err);
            }
        }
        
        internal bool GetEquipmentRoute(MaterialType materialType, out List<string> LstParentIds,out string err)
        {           
            err = ""; 
            //当结点是根结点时直接返回.
            LstParentIds = new List<string>();
            if (string.IsNullOrEmpty(materialType.GetId()))
            {
                err = "输入结点无效";
                return false;
            }
            string tempId = materialType.GetId();
            LstParentIds.Add(tempId);
            MaterialType theObject= materialType;
            string parentId = theObject.SUPERIOR_ID;
            if (string.IsNullOrEmpty(parentId))
            {
                return true;
            }

            while (!string.IsNullOrEmpty(parentId))
            {
                LstParentIds.Insert(0, parentId);
                theObject = getObject(parentId, out err);
                if (theObject == null || theObject.IsWrong  )
                {
                    err = "某个上级结点不存在！";
                    return false;
                }
                parentId = theObject.SUPERIOR_ID;
            }
            return true;   
        }
    }
}
