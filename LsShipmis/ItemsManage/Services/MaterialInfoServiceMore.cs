using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ItemsManage.Services
{
    public partial class MaterialInfoService
    {
        /// <summary>
        /// 找出指定备件所有的库存数量.
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public string GetOneMaterialAmountOfAShip(string materialId, string shipId)
        {
            sql = "SELECT isnull(sum(stocks),0) amount FROM T_MATERIAL_STOCKS " +
                 "where MATERIAL_ID='" + materialId + "' and ship_id = '" + shipId + "'";
            return dbAccess.GetString(sql);
        }

        //得到所有某个id的下级所有物资类型的语法.
        public string GetMaterialType(string materialTypeId)
        {
            if (string.IsNullOrEmpty(materialTypeId)) return "";
            sql = " with tb as(select MATERIAL_TYPE_ID, SUPERIOR_ID,MATERIAL_TYPE_ID ID,MATERIAL_TYPE_NAME typename from  T_MATERIAL_TYPE where SUPERIOR_ID in (select MATERIAL_TYPE_ID from T_MATERIAL_TYPE where SUPERIOR_ID is null)"
            + "\runion all select a.MATERIAL_TYPE_ID, a.SUPERIOR_ID,b.id,b.typename from  T_MATERIAL_TYPE a,tb b where a.SUPERIOR_ID=b.MATERIAL_TYPE_ID)"
            + "\rselect typename from tb where MATERIAL_TYPE_ID = '" + materialTypeId + "'";
            return dbAccess.GetString(sql);
        }

        /// <summary>
        /// 得到某个类型id的所有上级类型的语法.
        /// </summary>
        /// <param name="materialTypeId"></param>
        /// <returns></returns>
        public bool GetMaterialSuperiorType(string materialTypeId, out DataTable dt, out string err)
        {
            sql = " WITH CTE (MATERIAL_TYPE_ID,SUPERIOR_ID, MATERIAL_TYPE_NAME)"
                + " AS"
                + " ("
                + " SELECT MATERIAL_TYPE_ID,SUPERIOR_ID, MATERIAL_TYPE_NAME"
                + " FROM T_MATERIAL_TYPE"
                + " WHERE MATERIAL_TYPE_ID='" + materialTypeId + "'"
                + " UNION ALL"
                + " SELECT  E.MATERIAL_TYPE_ID,E.SUPERIOR_ID, E.MATERIAL_TYPE_NAME"
                + " FROM T_MATERIAL_TYPE E"
                + " JOIN CTE ON E.MATERIAL_TYPE_ID = CTE.SUPERIOR_ID "
                + " )"
                + " SELECT MATERIAL_TYPE_ID,SUPERIOR_ID, MATERIAL_TYPE_NAME"
                + " FROM CTE";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 取得指定树节点下的物资类型信息.
        /// </summary>
        /// <param name="superiorId">上级类型Id</param>
        /// <returns>返回指定树节点下的物资类型信息</returns>
        public DataTable GetMaterialTypeByParentId(string superiorId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.


            //Select语句加工部分.
            sSql += "select ";
            sSql += "material_type_id,";
            sSql += "material_type_name ";
            sSql += "from t_material_type ";
            if (string.IsNullOrEmpty(superiorId))
            {
                sSql += "where superior_id is null and ISVALID=1";
            }
            else
            {
                sSql += "where superior_id = '" + superiorId + "' ";
            }
            sSql += "order by material_type_name";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 取得指定大类的物资信息.
        /// </summary>
        /// <param name="materialTypeId">物资大类Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetMaterialInfoByTypeId(string materialTypeId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.material_id,";
            sSql += "a.material_type_id,";
            sSql += "a.material_name,";
            sSql += "a.material_code,";
            sSql += "a.material_spec,";
            sSql += "a.unit_name,";
            sSql += "a.remark,";
            sSql += "c.material_type_name ";
            sSql += "from t_material a ";
            sSql += "inner join t_material_type c on a.material_type_id=c.material_type_id  and a.ISVALID=1";
            if (materialTypeId.Length > 0) sSql += "where a.material_type_id = '" + materialTypeId + "' ";
            sSql += "order by a.material_code,material_name";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_MATERIAL 的DataTable
        /// </summary>
        public DataTable GetMaterialInfoAndStock(string Id, string SHIP_ID)
        {
            string err;
            sql = "select "
                + "a.MATERIAL_ID"
                + ",a.MATERIAL_TYPE_ID"
                + ",a.MATERIAL_CODE"
                + ",a.MATERIAL_NAME"
                + ",a.MATERIAL_SPEC"
                + ",a.UNIT_NAME"
                + ",a.REMARK"
                + ",isnull(c.STOCKSAll,0) as STOCKSAll"
                + "\rfrom T_MATERIAL a"
                + " left join (select SHIP_ID , MATERIAL_ID ,sum(STOCKSAll) STOCKSAll from V_MATERIAL_STOCKS where ship_id = '"
                + SHIP_ID + "' group by MATERIAL_ID,SHIP_ID) c on a.MATERIAL_ID = c.MATERIAL_ID "
                + "\rwhere a.MATERIAL_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 取得指定树节点下的物资类型信息.
        /// </summary>
        /// <param name="materialTypeId">当前类别Id</param>
        /// <returns>返回指定树节点下的物资类型信息</returns>
        public DataTable GetMaterialTypeById(string materialTypeId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "material_type_id,";
            sSql += "superior_id,";
            sSql += "material_type_name,";
            sSql += "remark";
            sSql += "\rfrom t_material_type ";
            sSql += "\rwhere material_type_id = '" + materialTypeId + "'";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 删除数据表T_MATERIAL中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL.MATERIAL_ID主键</param>
        public bool deleteType(string typeId, out string err)
        {
            sql = "delete from T_MATERIAL_TYPE where T_MATERIAL_TYPE.MATERIAL_TYPE_ID='" + typeId.Replace("'", "''") + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 物资类别信息保存.
        /// </summary>
        /// <param name="materialTypeId">类别Id</param>
        /// <param name="subMaterialTypeId">上级类别Id</param>
        /// <param name="materialTypeName">类别名称</param>
        /// <param name="typeRemark">类别备注</param>        
        /// <param name="optMark">操作标记（0为添加，1为修改）</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveMaterialType(string materialTypeId, string subMaterialTypeId,
                                    string materialTypeName, string typeRemark,
                                    int optMark, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";                           //操作的SQL语句.

            //添加操作.
            if (optMark == 0)
            {
                //添加Udcs信息的SQL语句.
                sSql += "insert into t_material_type(material_type_id,superior_id,";
                sSql += "material_type_name,remark) ";
                sSql += "values('" + materialTypeId + "','" + subMaterialTypeId + "',";
                sSql += "'" + materialTypeName + "','" + typeRemark + "')";
                lstSqlOpt.Add(sSql);
            }
            //修改操作.
            else if (optMark == 1)
            {
                //修改Udcs信息的SQL语句.
                sSql += "update t_material_type set material_type_name = '" + materialTypeName + "',";
                sSql += "remark = '" + typeRemark + "'";
                sSql += " where material_type_id = '" + materialTypeId + "'";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        internal bool ResetMaterialInfoType(string newTypeId, List<string> materialIds, out string err)
        {
            List<string> sqls = new List<string>();
            foreach (string materialId in materialIds)
            {
                if (string.IsNullOrEmpty(materialId)) continue;
                sqls.Add("update t_material set material_type_id ='" + dbOperation.ReplaceSqlKeyStr(newTypeId) +"' " 
                    +"\rwhere material_id= '" + dbOperation.ReplaceSqlKeyStr(materialId) + "'");
            }
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
