using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    partial class ComponentUnitService : IObjectsService
    {

        public DataTable GetComponentByName(string name, bool mayLike, string shipId)
        {
            string err;
            sql = sql = "select COMPONENT_UNIT_ID,"
                + "(select Ship_name from t_ship where t_ship.ship_id = T_Component_Unit.ship_id ) SHIP_Name,"
                + "(select COMPTYPE_CHINESE_NAME from T_COMPONENT_TYPE where T_COMPONENT_TYPE.COMPONENT_TYPE_ID = T_Component_Unit.COMPONENT_TYPE_ID ) COMPONENT_TYPE,"
                + "COMPONENT_TYPE_ID,"
                + "PARENT_UNIT_ID,"
                + "COMP_NUMBER,"
                + "PRODUCE_TIME,"
                + "USE_TIME,"
                + "USE_RATE,"
                + "COMP_CHINESE_NAME,"
                + "COMP_ENGLISH_NAME,"
                + "COMP_STATUS,"
                + "EXAMINATION_CODE,"
                + "CREATOR,"
                + "CREATETIME,"
                + "UPDATETIME,"
                + "SHIP_ID,"
                + "CWBT_CODE,"
                + "wareHouse,"
                + "total_workhours,"
                + "last_couter_time,"
                + "after_repair_hours,"
                + "repair_date,"
                + "comp_serial_no,"
                + "certification,detail "
                + (mayLike ? " FROM  T_Component_Unit where (COMP_CHINESE_NAME like N'%" + dbOperation.ReplaceSqlKeyStr(name) + "%' or COMP_ENGLISH_NAME like N'%" + dbOperation.ReplaceSqlKeyStr(name) + "%')" :
                " FROM  T_Component_Unit where (COMP_CHINESE_NAME = N'" + dbOperation.ReplaceSqlKeyStr(name) + "' or COMP_ENGLISH_NAME = N'" + dbOperation.ReplaceSqlKeyStr(name) + "')");

            if (shipId.Length != 0)
            {
                sql += "and ship_id = '" + shipId + "'";
            }
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据设备的上级结点得到所有的下1级结点.
        /// </summary>
        /// <param name="superCompId"></param>
        /// <returns></returns>
        public DataTable GetComponentByParentId(string superCompId)
        {
            sql = "select COMPONENT_UNIT_ID,"
                + "(select Ship_name from t_ship where t_ship.ship_id = t1.ship_id ) SHIP_Name,"
                + "t2.COMPTYPE_CHINESE_NAME  COMPONENT_TYPE,"
                + "t1.COMPONENT_TYPE_ID,"
                + "t1.PARENT_UNIT_ID,"
                + "t1.COMP_NUMBER,"
                + "t1.PRODUCE_TIME,"
                + "t1.USE_TIME,"
                + "t1.USE_RATE,"
                + "t1.COMP_CHINESE_NAME,"
                + "t1.COMP_ENGLISH_NAME,"
                + "t1.COMP_STATUS,"
                + "t1.EXAMINATION_CODE,"
                + "t1.CREATOR,"
                + "t1.CREATETIME,"
                + "t1.UPDATETIME,"
                + "t1.SHIP_ID,"
                + "t1.CWBT_CODE,"
                + "t1.wareHouse,"
                + "t1.total_workhours,"
                + "t1.last_couter_time,"
                + "t1.after_repair_hours,"
                + "t1.repair_date,"
                + "t1.comp_serial_no,"
                + "t1.certification,t1.detail,t1.sortno "
                + "\rFROM  T_Component_Unit t1 inner join T_COMPONENT_TYPE t2 on t2.COMPONENT_TYPE_ID = t1.COMPONENT_TYPE_ID "
                + "\rwhere upper(PARENT_UNIT_ID)='" + superCompId.ToUpper() + "' "
                + "\rorder by  isnull(t1.sortno,0),t1.CREATETIME";
            string err;
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据设备的上级结点得到所有的下1级结点.
        /// </summary>
        /// <param name="superCompId"></param>
        /// <returns></returns>
        public List<ComponentUnit> GetListComponentByParentId(string superCompId)
        {
            DataTable dt = GetComponentByParentId(superCompId);
            return makeComponentUnits(dt);
        }

        /// <summary>
        /// 构造对象集合并返回.
        /// </summary>
        /// <param name="dt">对象的datatable</param>
        /// <returns>对象list</returns>
        private List<ComponentUnit> makeComponentUnits(DataTable dt)
        {
            if (null == dt)
                return null;
            List<ComponentUnit> components = new List<ComponentUnit>();
            foreach (DataRow dr in dt.Rows)
            {
                components.Add(getObject(dr));
            }
            return components;
        }

        public bool GetListParentIds(string componentId, out List<string> LstParentIds, out string err)
        {
            err = "";
            bool isTrue = false;
            //当结点是根结点时直接返回.
            LstParentIds = new List<string>();
            if (string.IsNullOrEmpty(componentId))
            {
                err = "输入结点无效";
                return false;
            }
            LstParentIds.Add(componentId);
            string parentId = GetParentId(componentId, out isTrue);
            if (parentId.Equals("") && isTrue)
            {
                return true;
            }
            if (parentId.Equals("") && !isTrue)
            {
                err = "输入结点的上级结点不存在！";
                return false;
            }

            while (!parentId.Equals(""))
            {
                LstParentIds.Insert(0, parentId);
                parentId = GetParentId(parentId, out isTrue);
                if (parentId.Equals("") && !isTrue)
                {
                    err = "某个上级结点不存在！";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 根据设备.
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        private string GetParentId(string componentId, out bool isTrue)
        {
            isTrue = false;
            string parentId = "";
            sql = "select t1.PARENT_UNIT_ID,t2.COMPONENT_UNIT_ID from T_Component_Unit t1 left join T_Component_Unit t2 on"
                + "\rt2.COMPONENT_UNIT_ID = t1.PARENT_UNIT_ID"
                + "\rwhere t1.COMPONENT_UNIT_ID='" + componentId + "' ";
            DataTable dtb;
            string err;

            if (!dbAccess.GetDataTable(sql, out dtb, out err) || dtb.Rows.Count != 1)
            {
                isTrue = false;
                return parentId;
            }
            if (dtb.Rows[0][0] != null && dtb.Rows[0][0].ToString().Length > 0 &&
                (dtb.Rows[0][1] == null || string.IsNullOrEmpty(dtb.Rows[0][1].ToString())))
            {
                sql = "select t1.COMPONENT_UNIT_ID from T_Component_Unit t1 inner join  T_Component_Unit t2 "
                + "\ron t1.ship_id = t2.ship_id where t1.PARENT_UNIT_ID is null and t2.COMPONENT_UNIT_ID='" + componentId + "' ";
                string topUnitId = dbAccess.GetString(sql);
                if (string.IsNullOrEmpty(topUnitId))
                {
                    isTrue = false;
                    return "";
                }
                sql = "update COMPONENT_UNIT_ID set PARENT_UNIT_ID = '" + topUnitId + "' where COMPONENT_UNIT_ID='" + componentId + "' ";
                isTrue = dbAccess.ExecSql(sql, out err);
                return topUnitId;
            }
            isTrue = true;
            return dtb.Rows[0][0].ToString();
        }

        /// <summary>
        /// 删除虚拟设备,删除前需要再次确认是否是虚拟设备,
        /// 是否可以删除.
        /// </summary>
        /// <param name="equipmentId">要删除的设备id</param>
        /// <param name="err">错误提示</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteVirtualEquipment(string equipmentId, out string err)
        {
            err = "";
            if (EquipmentClassService.Instance.CanBeDeletedVirtualEquipment(equipmentId))
            {
                List<string> sqls = new List<string>();
                sql = "update T_COMPONENT_UNIT set PARENT_UNIT_ID = "
                    + "\r(select PARENT_UNIT_ID from T_COMPONENT_UNIT where COMPONENT_UNIT_ID = '" + equipmentId + "')"
                    + "\rfrom T_COMPONENT_UNIT where PARENT_UNIT_ID = '" + equipmentId + "'";
                sqls.Add(sql);
                sql = "delete T_COMPONENT_UNIT where COMPONENT_UNIT_ID = '" + equipmentId + "'";
                sqls.Add(sql);
                return dbAccess.ExecSql(sqls, out err);
            }
            else
            {
                err = "当前设备存在下级未分配给其它分类的情况,不允许将其作为虚拟设备删除";
                return false;
            }
        }

        public bool GetOneComponentHasSparePic(ComponentUnit equipment)
        {
            if (equipment == null || equipment.IsWrong) return false;

            sql = "select case when (select count(1) from T_FILE_MANAGE a inner join T_FILE_REF c on c.FILE_ID=a.FILE_ID "
                + "\rwhere upper(c.NODE_ID) =  upper(component_type_id) "
                + "\rand (upper(right(a.file_name,4)) in ('.gif', '.jpg', 'jpeg','.bmp', '.wmf', '.png'  ))) > 0 then 1 else 0 end c"
                + "\r from T_Component_Unit where COMPONENT_UNIT_ID = '" + equipment.GetId() + "'";
            return dbAccess.GetString(sql) == "1";
        }

        public DataTable GetEquipmentHistoryByUnitId(string componentId)
        {
            string sSql = "";
            string err;
            DataTable dtb;

            sSql += "select a.COMPONENT_HIS_ID,a.COMPONENT_UNIT_ID,a.ship_id,b.COMP_CHINESE_NAME,b.COMP_ENGLISH_NAME,a.HIS_BEGINTIME,a.HIS_STATE,";
            sSql += "case when a.HIS_STATE=1 then '运行' when a.HIS_STATE=2 then '正常' when a.HIS_STATE=3 then '修理' when a.HIS_STATE=4 then '报废' end as HIS_STATEName,";
            sSql += "a.total_workhours,";
            sSql += "a.HIS_ENDTIME,a.COMPONENT_NAME,a.TIMING_COUNTER_VALUE,a.DETAIL from T_COMPONENT_HISTORY a ";
            sSql += "inner join T_COMPONENT_UNIT b on b.COMPONENT_UNIT_ID=a.COMPONENT_UNIT_ID ";
            sSql += "where upper(a.COMPONENT_UNIT_ID)='";
            sSql += componentId.ToUpper();
            sSql += "' ";
            sSql += "order by a.HIS_BEGINTIME desc ";

            dbAccess.GetDataTable(sSql, out dtb, out err);

            return dtb;

        }
        
        public DataTable getComponentWorkHistory(ComponentUnit component)
        {
            sql = "select * from V_WorkOrder ";
            sql += " where upper(component_unit_id)='" + component.COMPONENT_UNIT_ID.ToUpper() + "'";
            sql += " order by completeddate desc,planexedate desc";
            DataTable dt;
            string err;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        
        /// <summary>
        /// 根据设备分类ID获得相关设备的DataTable
        /// </summary>
        public DataTable GetComponentsByClassID(string componentClassID, string componentName)
        {

            string err;
            DataTable dt;

            sql = "SELECT t1.COMPONENT_UNIT_ID,t1.COMP_CHINESE_NAME,t1.COMP_ENGLISH_NAME,t1.DETAIL FROM T_Component_Unit t1";
            sql += " inner join T_EQUIPMENT_CLASS_REF t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID";
            sql += " where t1.COMP_CHINESE_NAME like N'%" + dbOperation.ReplaceSqlKeyStr( componentName) + "%'and t2.CLASSID='" + componentClassID + "'";

            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }

        /// <summary>
        /// 获取所有未归类的设备，并以DataTable形式返回.
        /// </summary>
        public DataTable GetComponentsByNot(string componentName)
        {

            string err;
            DataTable dt;

            sql = "SELECT t1.COMPONENT_UNIT_ID,t1.COMP_CHINESE_NAME,t1.COMP_ENGLISH_NAME,t1.DETAIL FROM T_Component_Unit t1";
            sql += " where t1.COMP_CHINESE_NAME like N'%" + dbOperation.ReplaceSqlKeyStr(componentName) + "%'and t1.COMPONENT_UNIT_ID not in (select COMPONENT_UNIT_ID from T_EQUIPMENT_CLASS_REF)";

            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }

        /// <summary>
        /// 把设备和分类建立关联关系.
        /// </summary>
        public bool componentsToClass(string supClassID, string classID, List<string> lstComponentids, out string err)
        {
            List<string> lstSql = new List<string>();
            string delsql = "";
            foreach (string componentID in lstComponentids)
            {
                sql = "INSERT INTO [T_EQUIPMENT_CLASS_REF] ("
                    + "[REFID],"
                    + "[CLASSID],"
                    + "[COMPONENT_UNIT_ID]"
                    + ") VALUES( "
                    + " " + ("'" + Guid.NewGuid().ToString() + "'")
                    + " , " + ("'" + classID + "'")
                    + " , " + ("'" + componentID + "'")
                    + ")";
                if (!"root".Equals(supClassID))
                {
                    delsql = "delete from T_EQUIPMENT_CLASS_REF where CLASSID ='"
                        + supClassID + "' and COMPONENT_UNIT_ID ='" + componentID + "'";
                    lstSql.Add(delsql);
                }

                lstSql.Add(sql);
            }

            return dbAccess.ExecSql(lstSql, out err);
        }

        /// <summary>
        /// 把设备设置到上级分类上.
        /// </summary>
        public bool componentsToSup(string supClassID, string classID, List<string> lstComponentids, out string err)
        {
            List<string> lstSql = new List<string>();
            string delsql = "";
            if ("root".Equals(supClassID))
            {
                foreach (string componentID in lstComponentids)
                {
                    delsql = "delete from T_EQUIPMENT_CLASS_REF where CLASSID ='"
                        + classID + "' and COMPONENT_UNIT_ID ='" + componentID + "'";
                    lstSql.Add(delsql);
                }
            }
            else
            {
                string[] aCompIDs = lstComponentids.ToArray();
                string componentIDs = String.Join("\',\'", aCompIDs);
                sql = "update T_EQUIPMENT_CLASS_REF set CLASSID ='" + supClassID +
                    "'  where CLASSID ='" + classID + "' and COMPONENT_UNIT_ID in ('" + componentIDs + "')";
                lstSql.Add(sql);
            }

            return dbAccess.ExecSql(lstSql, out err);
        }

        /// <summary>
        /// 把设备设置到根目录.
        /// </summary>
        public bool componentsToRoot(string classID, List<string> lstComponentids, out string err)
        {
            List<string> lstSql = new List<string>();
            string delsql = "";
            foreach (string componentID in lstComponentids)
            {
                if (!"root".Equals(classID))
                {
                    delsql = "delete from T_EQUIPMENT_CLASS_REF where CLASSID ='"
                        + classID + "' and COMPONENT_UNIT_ID ='" + componentID + "'";
                    lstSql.Add(delsql);
                }
            }

            return dbAccess.ExecSql(lstSql, out err);
        }
 
        /// <summary>
        /// 通过设备ID获取tree的子节点集合.
        /// </summary>
        internal List<ComponentUnit> GetObjectsByCompenentID(string CompenentID)
        {
            List<ComponentUnit> lists = new List<ComponentUnit>();

            sql = "SELECT t1.*  FROM T_Component_Unit t1";
            sql += " where  t1.PARENT_UNIT_ID = '" + CompenentID + "'";

            DataTable dt;
            string err = "";
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lists.Add(getObject(dr));
                }
                return lists;
            }

            throw new Exception(err);

        }

        /// <summary>
        /// 在这里插入。。。。。判断一组设备是否有子设备.
        /// </summary>
        /// <param name="equipments"></param>
        /// <returns></returns>
        internal bool GetListEquipmentHaveSubEquip(List<ComponentUnit> equipments)
        {
            //得到一个字符串.
            if (equipments == null || equipments.Count == 0) return false;
            string ids = "";
            foreach (ComponentUnit tempUnit in equipments)
            {
                ids += "'" + tempUnit.GetId() + "',";
            }
            ids = ids.Substring(0, ids.Length - 1);
            sql = "select count(1) from t_component_unit where PARENT_UNIT_ID in (" + ids + ")";
            return dbAccess.GetString(sql) != "0";
        }

        /// <summary>
        /// 把一个设备包含其子设备一起拷贝生成另一个设备，.
        /// 拷贝时需要将其工作信息一起拷贝过去.
        /// 拷贝生成的设备所属于某个设备分类下。.
        /// </summary>
        /// <param name="toCloneOne">要复制的原设备</param>
        /// <param name="toWhichClassId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal bool CloneEquipmentAndSubToAClass(ComponentUnit toCloneOne, string toWhichClassId, string shipid, string newName, bool saveEngname, bool saveExamCode, out string err)
        {

            //先把第一级设备的拷贝形成.
            ComponentUnit theClonedEquipment = (ComponentUnit)toCloneOne.Clone();
            theClonedEquipment.PARENT_UNIT_ID = shipid;
            theClonedEquipment.COMPONENT_UNIT_ID = null;
            theClonedEquipment.COMP_CHINESE_NAME = newName;
            if (!saveEngname) theClonedEquipment.COMP_ENGLISH_NAME = "";
            theClonedEquipment.comp_serial_no = "";
            if (!saveExamCode) theClonedEquipment.EXAMINATION_CODE = "";
            theClonedEquipment.certification = "";
            theClonedEquipment.SHIP_ID = shipid;
            if (!theClonedEquipment.Update(out err)) return false;
            if (!EquipmentClassService.Instance.ClassifyEquipmentToClass(toWhichClassId, theClonedEquipment.GetId(), shipid, out err)) return false;

            return CloneEquipmentSubToAnotherEquipmentSub(toCloneOne, theClonedEquipment, shipid, saveEngname, saveExamCode, out err);
        }
        /// <summary>
        /// 把一个设备包含其子设备一起拷贝生成另一个设备，.
        /// 拷贝时需要将其工作信息一起拷贝过去.
        /// 拷贝生成的设备所属于某个其它设备.
        /// </summary>
        /// <param name="toCloneOne"></param>
        /// <param name="toWhichEquipmentId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal bool CloneEquipmentAndSubToAnotherEquipment(ComponentUnit toCloneOne, string toWhichEquipmentId, string shipid, string newName, bool saveEngname, bool saveExamCode, out string err)
        {
            //不允许把一个设备拷贝到自己本身的下级.
            sql = "select dbo.F_Comp_AIsBChild('" + toWhichEquipmentId + "','" + toCloneOne.GetId() + "')";
            if (toCloneOne.GetId() == toWhichEquipmentId || dbAccess.GetString(sql) == "1")
            {
                err = "不允许把一个设备拷贝到自己本身的下级!";
                return false;
            }
            //先把第一级设备的拷贝形成.
            ComponentUnit theClonedEquipment = (ComponentUnit)toCloneOne.Clone();
            theClonedEquipment.PARENT_UNIT_ID = toWhichEquipmentId;
            theClonedEquipment.COMPONENT_UNIT_ID = null;
            theClonedEquipment.COMP_CHINESE_NAME = newName;
            if (!saveEngname) theClonedEquipment.COMP_ENGLISH_NAME = "";
            theClonedEquipment.comp_serial_no = "";
            theClonedEquipment.SHIP_ID = shipid;
            theClonedEquipment.certification = "";
            if (!saveExamCode) theClonedEquipment.EXAMINATION_CODE = "";
            if (!theClonedEquipment.Update(out err)) return false;

            return CloneEquipmentSubToAnotherEquipmentSub(toCloneOne, theClonedEquipment, shipid, saveEngname, saveExamCode, out err);
        }

        /// <summary>
        /// 把一个设备的下级以及操作和保养内容，均拷贝到另一个已经存在的设备上去。.
        /// </summary>
        /// <param name="toCloneOne"></param>
        /// <param name="toWhichEquipment"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CloneEquipmentSubToAnotherEquipmentSub(ComponentUnit toCloneOne, ComponentUnit toWhichEquipment, string shipid, bool saveEngname, bool saveExamCode, out string err)
        {
            if (toCloneOne == null || toWhichEquipment == null || toCloneOne.IsWrong || toWhichEquipment.IsWrong)
            {
                err = "传入的设备无效，不能进行复制";
                return false;
            }
            //拷贝当前级别的维护保养内容.
            if (ItemsManageConfig.copyWorkInfosFromOneEquipmentToOther != null)
            {
                if (!ItemsManageConfig.copyWorkInfosFromOneEquipmentToOther(toCloneOne, toWhichEquipment, out err)) return false;
            }
            else
            {
                throw new Exception("没有实现委托ItemsManageConfig.copyWorkInfosFromOneEquipmentToOther");
            }
            //获取toCloneOne的所有下级设备，然后clone形成新的设备，递归调用本方法.
            List<ComponentUnit> allSubs = GetObjectsByCompenentID(toCloneOne.GetId());
            for (int i = 0; i < allSubs.Count; i++)
            {
                ComponentUnit tempOne = (ComponentUnit)allSubs[i].Clone();
                tempOne.COMPONENT_UNIT_ID = null;
                tempOne.PARENT_UNIT_ID = toWhichEquipment.GetId();
                tempOne.SHIP_ID = shipid;
                if (!saveEngname) tempOne.COMP_ENGLISH_NAME = "";
                tempOne.comp_serial_no = "";
                tempOne.certification = "";
                if (!saveExamCode) tempOne.EXAMINATION_CODE = "";
                if (!tempOne.Update(out err))
                {
                    return false;
                }
                if (!CloneEquipmentSubToAnotherEquipmentSub(allSubs[i], tempOne, shipid, saveEngname, saveExamCode, out err)) return false;
            }
            return true;
        }
        /// <summary>
        /// 取得上级设备ID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public bool GetSuperEquipment(string equipmentID, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" with cl(COMPONENT_UNIT_ID)  as(");
            sb.Append(" select e1.COMPONENT_UNIT_ID from T_COMPONENT_UNIT e1 where e1.COMPONENT_UNIT_ID ='" + equipmentID + "'");
            sb.Append(" union all");
            sb.Append(" select e2.PARENT_UNIT_ID from T_COMPONENT_UNIT e2  ");
            sb.Append(" JOIN cl ON e2.COMPONENT_UNIT_ID =cl.COMPONENT_UNIT_ID where e2.PARENT_UNIT_ID is not null )");
            sb.Append(" SELECT COMPONENT_UNIT_ID FROM cl");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("SHIP_Name", "船舶名称");
            // reValue.Add("COMPONENT_TYPE", "设备型号");
            reValue.Add("COMP_CHINESE_NAME", "设备名称");
            // reValue.Add("COMP_ENGLISH_NAME", "设备英文名");
            reValue.Add("comp_serial_no", "设备序列号");

            //reValue.Add("COMPONENT_UNIT_ID", "id");
            // reValue.Add("COMPTYPE_CHINESE_NAME", "设备型号");
            return reValue;
        }

        #endregion
    }
}
