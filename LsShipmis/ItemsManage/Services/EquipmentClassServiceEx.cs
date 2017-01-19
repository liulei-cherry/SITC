/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentClassService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-4-12
 * 标    题：数据操作类
 * 功能描述：EquipmentClass数据操作类
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
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_EQUIPMENT_CLASSService.cs
    /// </summary>
    public partial class EquipmentClassService
    {
        /// <summary>
        /// 判断一个分类是否可以作为另一个分类的子分类
        /// 注意,由于界面层已经做了上下级的判断,这里暂时不做同为3级分类是,
        /// 上下级异常的处理,如果需要,则在此统一加入
        /// </summary>
        /// <param name="toJudgeOne">要判断的分类</param>
        /// <param name="theParentOne">父分类</param>
        /// <param name="err">错误提示</param>
        /// <returns>是否可以</returns>
        public bool EquipmentClassCanBeOthersSubClassification(EquipmentClass toJudgeOne, EquipmentClass theParentOne, out string err)
        {
            if (theParentOne != null)
            {
                EquipmentClass temp = theParentOne;
                while (temp != null && !temp.IsWrong)
                {
                    if (temp.GetId() != toJudgeOne.GetId())
                        temp = EquipmentClassService.Instance.getObject(temp.PARENTCLASSID, out err);
                    else
                    {
                        err = "出现循环设定,不能将分类的上级设置为自己或自己的下级";
                        return false;
                    }
                }
                err = "";
                return true;
            }
            else
            {
                err = "";
                return true;
            }

        }

        /// <summary>
        ///  将一个分类拖到另一个分类下
        /// </summary>
        /// <param name="needChecking">是否需要检验有效性</param>
        /// <param name="toDrop">要释放的节点</param>
        /// <param name="aimClass">目标节点</param>
        /// <param name="position">放到位置</param>
        /// <param name="err">错误提示</param>
        /// <returns>是否成功</returns>
        public bool DropClassToOtherClass(bool needChecking, EquipmentClass toDrop, EquipmentClass aimClass, int sortno, out string err)
        {
            if (needChecking && !EquipmentClassCanBeOthersSubClassification(toDrop, aimClass, out err)) return false;
            err = "传入的参数无效";
            if (toDrop == null || toDrop.IsWrong) return false;
            toDrop.PARENTCLASSID = (aimClass == null ? "" : aimClass.CLASSID);
            toDrop.SORTNO = sortno;

            if (!toDrop.Update(out err)) return false;
            return resortClass(toDrop.PARENTCLASSID, out err);
        }

        /// <summary>
        /// 通过父节点ID获取tree的子节点集合
        /// </summary>
        internal List<EquipmentClass> GetObjectsByParentId(string parentId)
        {
            return GetObjectsByParentId(parentId, true, "");
        }

        /// <summary>
        /// 得到某个分类下的所有下级分类,
        /// 注意第二和第三个参数
        /// </summary>
        /// <param name="parentId">上级id</param>
        /// <param name="showAll">是否显示所有节点,当为false时第三个参数有效</param>
        /// <param name="shipid">当前船舶关联过设备的分类才会显示,注意,下级关联过当前没有关联的也显示</param>
        /// <returns></returns>
        internal List<EquipmentClass> GetObjectsByParentId(string parentId, bool showAll, string shipid)
        {
            List<EquipmentClass> lists = new List<EquipmentClass>();
            DataTable dt;
            string err = "";
            if (parentId == null) parentId = "";
            if (showAll)
            {
                sql = "select * from T_EQUIPMENT_CLASS where PARENTCLASSID ='" + parentId.Replace("'", "''") + "' order by SORTNO";
            }
            else
            {
                sql = "with class(baseId,classid)  as("
                    + "\rselect classid,classid from T_EQUIPMENT_CLASS where PARENTCLASSID ='" + parentId.Replace("'", "''") + "'"
                    + "\runion all"
                    + "\rselect class.baseId, T_EQUIPMENT_CLASS.classid from class inner join  T_EQUIPMENT_CLASS on class.classid = T_EQUIPMENT_CLASS.PARENTCLASSID)"
                    + "\rselect t.CLASSID,t.CLASSCODE,t.CLASSNAME,t.CLASSTYPE,t.CLASSDETAIL,t.SORTNO,t.PARENTCLASSID "
                    + "\rfrom class t1 inner join T_EQUIPMENT_CLASS t on t1.baseId = t.classid"
                    + "\rleft join (T_EQUIPMENT_CLASS_REF t2 inner join dbo.T_COMPONENT_UNIT t3"
                    + "\ron t2.COMPONENT_UNIT_ID = t3.COMPONENT_UNIT_ID and t3.ship_id = '" + shipid + "') on t1.classid = t2.CLASSID"
                    + "\rwhere t2.CLASSID is not null"
                    + "\rgroup by t.CLASSID,t.CLASSCODE,t.CLASSNAME,t.CLASSTYPE,t.CLASSDETAIL,t.SORTNO,t.PARENTCLASSID order by t.SORTNO";
            }
            sql = sql.Replace("=''", " is null");
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
        /// 通过设备下级查找没有关联过任何设备分类的设备集合.
        /// </summary>
        internal List<ComponentUnit> GetNotClassifiedEquipments(string parentID)
        {
            List<ComponentUnit> lists = new List<ComponentUnit>();

            sql = "SELECT t1.COMPONENT_UNIT_ID, t1.COMPONENT_TYPE_ID, t1.PARENT_UNIT_ID,t1.COMP_NUMBER, "
                + "t1.PRODUCE_TIME,t1.USE_TIME,t1.USE_RATE,t1.COMP_CHINESE_NAME,t1.COMP_ENGLISH_NAME, "
                + " t1.COMP_STATUS, t1.EXAMINATION_CODE,  t1.CREATOR, t1.CREATETIME,  t1.UPDATETIME, "
                + "t1.SHIP_ID,   t1.CWBT_CODE,  t1.wareHouse, t1.total_workhours,   t1.last_couter_time, "
                + "t1.after_repair_hours, t1.repair_date, t1.comp_serial_no, t1.certification,t1.detail,t1.sortno"
                + "\rFROM T_Component_Unit t1 left join T_EQUIPMENT_CLASS_REF t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID"
                + "\rleft join T_COMPONENT_TYPE t3 on t1.COMPONENT_TYPE_ID = t3.COMPONENT_TYPE_ID"
                + "\rwhere  t1.PARENT_UNIT_ID = '" + parentID + "' and t2.COMPONENT_UNIT_ID is null"
                + "\rorder by isnull(t1.sortno,0),t1.CREATETIME";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lists.Add(ComponentUnitService.Instance.getObject(dr));
                }
                return lists;
            }
            throw new Exception(err);
        }

        /// <summary>
        /// 返回设备分类下的所有设备集合.
        /// </summary>
        internal List<ComponentUnit> GetClassifiedEquipmentByClassId(string classId, string shipid)
        {
            List<ComponentUnit> lists = new List<ComponentUnit>();

            sql = "SELECT t1.COMPONENT_UNIT_ID, t1.COMPONENT_TYPE_ID, t1.PARENT_UNIT_ID,t1.COMP_NUMBER, "
                + "t1.PRODUCE_TIME,t1.USE_TIME,t1.USE_RATE,t1.COMP_CHINESE_NAME,t1.COMP_ENGLISH_NAME, "
                + " t1.COMP_STATUS, t1.EXAMINATION_CODE,  t1.CREATOR, t1.CREATETIME,  t1.UPDATETIME, "
                + "t1.SHIP_ID,   t1.CWBT_CODE,  t1.wareHouse, t1.total_workhours,   t1.last_couter_time, "
                + "t1.after_repair_hours, t1.repair_date, t1.comp_serial_no, t1.certification,t1.detail,t1.sortno"
                + "\rFROM T_Component_Unit t1 inner join T_EQUIPMENT_CLASS_REF t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID"
                + "\rleft join T_COMPONENT_TYPE t3 on t1.COMPONENT_TYPE_ID = t3.COMPONENT_TYPE_ID"
                + "\rwhere  t2.CLASSID = '" + classId + "' and t1.ship_id = '" + shipid + "'"
                + "\rorder by isnull(t2.sortno,0), isnull(t1.sortno,0),t1.createtime ";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lists.Add(ComponentUnitService.Instance.getObject(dr));
                }
                return lists;
            }
            throw new Exception(err);
        }

        /// <summary>
        /// 删除某个设备与某个分类的绑定关系.
        /// </summary>
        /// <param name="classId">分类id,如果为空则是全部的关系都删掉</param>
        /// <param name="equipmentId">设备id</param>
        /// <param name="err">错误信息</param>
        /// <returns>是否成功</returns>
        public bool DeleteClassifiedEquipmentRelation(string classId, string equipmentId, out string err)
        {
            List<string> sqls = new List<string>();

            sql = "delete T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID ='" + equipmentId + "'"
                + (string.IsNullOrEmpty(classId) ? "" : " and CLASSID = '" + classId + "'");
            sqls.Add(sql);
            sql = "exec dbo.P_Resort_Class_ref '" + classId + "'";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 把设备和分类建立关联关系（树形方式进行设备归类）.

        /// </summary>
        public bool ClassifyEquipmentToClass(string classID, string equipmentId, int sort, out string err)
        {
            List<string> lstSql = new List<string>();
            sql = "select classid from T_EQUIPMENT_CLASS_REF where COMPONENT_UNIT_ID ='" + equipmentId + "'";
            string lastId = dbAccess.GetString(sql);
            sql = "select top 1 t2.COMPONENT_UNIT_ID from t_component_unit t1 inner join t_component_unit t2 on t1.ship_id = t2.ship_id and t2.parent_unit_id is null"
                + "\rwhere t1.COMPONENT_UNIT_ID = '" + equipmentId + "'";
            string shipRootId = dbAccess.GetString(sql);
            sql = "update t_component_unit set parent_unit_id = '" + shipRootId + "' where COMPONENT_UNIT_ID = '" + equipmentId + "'";
            dbAccess.ExecSql(sql, out err);

            sql = "delete T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID ='" + equipmentId + "'";
            lstSql.Add(sql);

            if (!string.IsNullOrEmpty(lastId) && lastId != classID)
            {
                sql = "exec dbo.P_Resort_Class_ref '" + lastId + "'";
                lstSql.Add(sql);
            }
            sql = "INSERT INTO [T_EQUIPMENT_CLASS_REF] ( [REFID], [CLASSID], [COMPONENT_UNIT_ID],[SORTNO]) "
                + "\rVALUES( '" + Guid.NewGuid().ToString() + "' ,  '" + classID + "' , '" + equipmentId + "'," + sort.ToString() + " )";
            lstSql.Add(sql);
            sql = "exec dbo.P_Resort_Class_ref '" + classID + "'";
            lstSql.Add(sql);
            return dbAccess.ExecSql(lstSql, out err);
        }
        /// <summary>
        /// 把设备和分类建立关联关系（树形方式进行设备归类）,放到最后.
        /// </summary>
        public bool ClassifyEquipmentToClass(string classID, string equipmentId, string shipid, out string err)
        {
            //如果已经排序了 这里不需要进行重新排序.
            sql = "select count(1) from T_EQUIPMENT_CLASS_REF where component_unit_id = '" + equipmentId + "' and classId = '" + classID + "'";
            if (dbAccess.GetString(sql) == "1")
            {
                sql = "exec dbo.P_Resort_Class_ref '" + classID + "'";
                return dbAccess.ExecSql(sql, out err);
            }
            sql = "select max(t1.SORTNO) + 10 from [T_EQUIPMENT_CLASS_REF] t1 inner join T_COMPONENT_UNIT t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID where [CLASSID] = '"
                + classID + "' and t2.ship_id = '" + shipid + "' ";
            int sort;
            if (int.TryParse(dbAccess.GetString(sql), out sort))
            {
                return ClassifyEquipmentToClass(classID, equipmentId, sort, out err);
            }
            else
                return ClassifyEquipmentToClass(classID, equipmentId, 5, out err);
        }
        /// <summary>
        /// 把设备（集合）和分类建立关联关系（树形方式进行设备归类）.
        /// </summary>
        public bool ClassifyEquipmentsToClass(string classID, List<ComponentUnit> lists, out string err)
        {
            List<string> lstSql = new List<string>();
            string componentIDs = "";
            foreach (ComponentUnit unit in lists)
            {
                componentIDs += "'" + unit.COMPONENT_UNIT_ID + "',";
            }
            componentIDs = componentIDs.Length > 0 ? componentIDs.Substring(0, componentIDs.Length - 1) : "";
            sql = "select distinct classId from T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID in (" + componentIDs + ")";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err)) return false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0] != null)
                {
                    sql = "exec dbo.P_Resort_Class_ref '" + dr[0].ToString() + "'";
                    lstSql.Add(sql);
                }
            }
            sql = "delete T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID in (" + componentIDs + ")";
            lstSql.Add(sql);

            for (int i = 0; i < lists.Count; i++)
            {
                sql = "INSERT INTO [T_EQUIPMENT_CLASS_REF] ("
                    + "[REFID],"
                    + "[CLASSID],"
                    + "[COMPONENT_UNIT_ID],[SORTNO]"
                    + ") select  "
                    + " " + ("'" + Guid.NewGuid().ToString() + "'")
                    + " , " + ("'" + classID + "'")
                    + " , " + ("'" + lists[i].COMPONENT_UNIT_ID + "'")
                    + ",(select count(1)*10 + 5 from T_EQUIPMENT_CLASS_REF t1 "
                    + "\rinner join t_component_unit t2 on t1.COMPONENT_UNIT_ID= t2.COMPONENT_UNIT_ID "
                    + "\r where t2.ship_id = '" + lists[i].SHIP_ID + "')";

                lstSql.Add(sql);
            }
            sql = "exec dbo.P_Resort_Class_ref '" + classID + "'";
            lstSql.Add(sql);

            return dbAccess.ExecSql(lstSql, out err);
        }

        /// <summary>
        /// 如果当前节点并非关系信息的设备信息,则删除时自动把其下级调整为其上级的下级,
        /// 只有满足包含下级,且下级已经被其它分类引用的设备才可以进行此操作,操作前需要提示用户.
        /// </summary>
        /// <param name="equipmentId">要检查的id</param>
        /// <returns></returns>
        public bool CanBeDeletedVirtualEquipment(string equipmentId)
        {
            sql = "select count(1) from T_Component_unit t1 left join  T_EQUIPMENT_CLASS_REF t2"
                + "\r on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID"
                + "\r where t1.PARENT_UNIT_ID = '" + equipmentId + "' and t2.COMPONENT_UNIT_ID is null";
            return (dbAccess.GetString(sql) == "0");
        }
        /// <summary>
        /// 取得设备属于的分类ID
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        public string GetEquipmentBelongClass(string equipmentId)
        {
            sql = "select CLASSID from T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID ='" + equipmentId + "'";
            return dbAccess.GetString(sql);
        }
        /// <summary>
        /// 取得上级分类ID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public bool GetSuperClass(string classID, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" with cl(classid)  as(");
            sb.Append(" select e1.classid from T_EQUIPMENT_CLASS e1 where e1.classid ='" + classID + "'");
            sb.Append(" union all");
            sb.Append(" select e2.PARENTCLASSID from T_EQUIPMENT_CLASS e2  ");
            sb.Append(" JOIN cl ON e2.classid =cl.classid where e2.PARENTCLASSID is not null )");
            sb.Append(" SELECT classid FROM cl");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        public bool GetEquipmentRoute(ComponentUnit equipment, out List<string> lstEquipmentRouts)
        {
            lstEquipmentRouts = new List<string>();
            string err;
            if (equipment == null || string.IsNullOrEmpty(equipment.SHIP_ID)) return false;

            if (!ComponentUnitService.Instance.GetListParentIds(equipment.GetId(), out lstEquipmentRouts, out err)) return false;
            if (lstEquipmentRouts.Count == 0) return false;
            if (lstEquipmentRouts.Count == 1) return true;

            string equipmentClassTempId = null;
            int i = 0;
            for (; i < lstEquipmentRouts.Count; i++)
            {
                equipmentClassTempId = GetEquipmentBelongClass(lstEquipmentRouts[i]);
                if (!string.IsNullOrEmpty(equipmentClassTempId))
                {
                    break;
                }
            }
            if (string.IsNullOrEmpty(equipmentClassTempId))
            {
                //相当于直接从船舶id出发找到对象.
                return true;
            }
            else
            {
                for (int r = i - 1; r > 0; r--)
                {
                    lstEquipmentRouts.RemoveAt(r);
                }
            }
            lstEquipmentRouts.Insert(1, equipmentClassTempId);
            EquipmentClass equipmentClass = getObject(equipmentClassTempId, out err);
            if (string.IsNullOrEmpty(equipmentClass.PARENTCLASSID)) return true;
            while (true)
            {
                equipmentClass = getObject(equipmentClass.PARENTCLASSID, out err);
                if (equipmentClass == null || string.IsNullOrEmpty(equipmentClass.GetId()))
                {
                    return true;
                }
                lstEquipmentRouts.Insert(1, equipmentClass.GetId());
            }
        }

        public bool GetEquipmentClassByNameAndParentId(string className, string parentId, out EquipmentClass theEquipmentClass)
        {
            sql = "select	"
             + "CLASSID"
             + ",CLASSCODE"
             + ",CLASSNAME"
             + ",CLASSTYPE"
             + ",CLASSDETAIL"
             + ",SORTNO"
             + ",PARENTCLASSID"
             + "  from T_EQUIPMENT_CLASS where CLASSNAME = '" + dbOperation.ReplaceSqlKeyStr(className) + "' "
             + (string.IsNullOrEmpty(parentId) ? "" : " and PARENTCLASSID = '" + dbOperation.ReplaceSqlKeyStr(parentId) + "'");
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count > 0)
            {
                theEquipmentClass = getObject(dt.Rows[0]);
                if (theEquipmentClass != null) return true;
            }
            theEquipmentClass = null;
            return false;
        }
    }
}