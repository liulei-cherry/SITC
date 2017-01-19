using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using ItemsManage.DataObject;
namespace ItemsManage.Services
{
    partial class SpareInfoService : IObjectsService
    {
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            //throw new Exception("The method or operation is not implemented.");
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("SPARE_ID", "备件id");
            reValue.Add("SPARE_NAME", "备件名称");
            reValue.Add("SPARE_ENAME", "备件英文名");
            reValue.Add("PARTNUMBER", "配件号|规格");
            reValue.Add("REMARK", "备注");
            return reValue;
            // throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        /// <summary>
        /// 找出指定备件历史的最大出库数量.
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public string GetOneSpareMaxOutNum(string spareId)
        {
            string err;
            DataTable dt;
            string returnAmount = "1.00";
            sql = "SELECT max(OUT_NUM) FROM T_SOM_OUT_DETAIL GROUP BY SPARE_ID having SPARE_ID='" + spareId + "'";
            dbAccess.GetDataTable(sql, out dt, out err);
            if (dt.Rows.Count != 0)
            {
                returnAmount = dt.Rows[0][0].ToString();
            }
            return returnAmount;
        }
        /// <summary>
        /// 找出备件所属的设备:先根据备件找出设备型号，然后根据设备型号找出属于这些设备型号所有的设备.
        /// 设备与设备型号是n：1的关系，即某设备只能属于一种设备型号，一种设备型号可以有多种设备.
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public DataTable GetOneSpareComponentUnit(string spareId)
        {
            DataTable dtRe;
            string err;
            sql = "SELECT t1.COMPONENT_UNIT_ID,t1.COMP_CHINESE_NAME FROM";
            sql += " T_COMPONENTTYPE_SPARE AS t2  LEFT OUTER JOIN  T_COMPONENT_TYPE AS t3";
            sql += " ON t2.COMPONENT_TYPE_ID= t3.COMPONENT_TYPE_ID ";
            sql += " left join T_Component_Unit  AS t1 on t1.COMPONENT_TYPE_ID= t3.COMPONENT_TYPE_ID ";
            sql += " WHERE t2.SPARE_ID='" + spareId + "'";
            dbAccess.GetDataTable(sql, out dtRe, out err);
            return dtRe;
        }

        /// <summary>
        /// 找出备件所属的设备:先根据备件找出设备型号，然后根据设备型号找出属于这些设备型号所有的设备.
        /// 设备与设备型号是n：1的关系，即某设备只能属于一种设备型号，一种设备型号可以有多种设备.
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public DataTable GetOneSpareComponentUnit(string shipID, string spareId)
        {
            DataTable dtRe;
            string err;
            sql = "SELECT t1.COMPONENT_UNIT_ID,t1.COMP_CHINESE_NAME FROM";
            sql += " T_COMPONENTTYPE_SPARE AS t2  LEFT OUTER JOIN  T_COMPONENT_TYPE AS t3";
            sql += " ON t2.COMPONENT_TYPE_ID= t3.COMPONENT_TYPE_ID ";
            sql += " left join T_Component_Unit  AS t1 on t1.COMPONENT_TYPE_ID= t3.COMPONENT_TYPE_ID ";
            sql += " WHERE t1.ship_id='" + shipID + "' and t2.SPARE_ID='" + spareId + "'";
            dbAccess.GetDataTable(sql, out dtRe, out err);
            return dtRe;
        }

        /// <summary>
        /// 备件基础信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public bool GetSpareBasic(out DataTable dtb, out string err)
        {
            //变量定义部分.
            dtb = new DataTable();    //定义一个DataTable对象.
            err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            ////Where条件加工部分<param name="bindmark">备件查询标记，1表示已被设备型号绑定的备件，0表示未被设备型号绑定的备件</param>
            //if (bindmark == 1)
            //{
            // 
            //    sWhere += " and a.spare_id in (select c.spare_id from t_componenttype_spare c) ";
            //}
            //else if (bindmark == 0)
            //{
            //    sWhere += " and a.spare_id not in (select c.spare_id from t_componenttype_spare c) ";
            //}

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.spare_id,";
            sSql += "a.spare_name,";
            sSql += "a.spare_ename,";
            sSql += "a.partnumber,";
            sSql += "a.partnumber_his1,";
            sSql += "a.partnumber_his2,";
            sSql += "a.picnumber,";
            sSql += "a.piccode,";
            sSql += "a.sparestuff,";
            sSql += "a.unit_name,";
            sSql += "a.alertstock,";
            sSql += "a.remark,";
            sSql += "a.ISSPECIALSP,case a.ISSPECIALSP when 1 then '是' else '否' end isspecialsp_name ,";
            sSql += "a.creator, case when a.spare_id in (select c.spare_id from t_componenttype_spare c) then 1 else 0 end bindmark ";
            sSql += "\rfrom t_spare a ";

            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "\rorder by a.picnumber, case when dbo.isreallyNumeric(a.PICCODE) = 1 then cast(a.piccode as numeric) else 999999 end, a.PICCODE,a.spare_name";//按创建时间排序.

            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        public bool GetSpareStockUnderAlert(string shipid, out DataTable dtb)
        {
            //变量定义部分.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            if (!string.IsNullOrEmpty(shipid)) sWhere += " and a.ship_Id='" + shipid + "' ";

            //Select语句加工部分.
            sSql += "select distinct a.ship_id,a.spare_id,(b.ALERTSTOCK - a.stocks) underStockCount "
                + "\rfrom (select spare_id,ship_id, sum(STOCKSAll) stocks from V_SPARE_STOCKS group by spare_id,ship_id) a"
                + "\rinner join t_spare b on a.spare_id = b.spare_id"
                + "\rwhere b.ALERTSTOCK >  a.stocks ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        /// <summary>
        /// 得到一个备件所绑定的设备型号.
        /// </summary>
        /// <param name="spare_id">备件id</param>
        /// <param name="dt">返回datatable</param>
        /// <param name="err">错误信息</param>
        /// <returns></returns>
        public bool GetSpareBandingComponentType(string spare_id, out DataTable dt, out string err)
        {
            if (string.IsNullOrEmpty(spare_id))
            {
                dt = null;
                err = "调用函数GetSpareBandingComponentType得到一个备件所绑定的设备型号时，传入参数无效";
                return false;
            }
            sql = "select t2.COMPONENT_TYPE_ID, t2.COMPTYPE_CHINESE_NAME,t2.COMPONENT_STYLE,t2.MANUFACTURER"
                 + "\rfrom  dbo.T_COMPONENTTYPE_SPARE t1 inner join dbo.T_COMPONENT_TYPE t2 on t1.COMPONENT_TYPE_ID = t2.COMPONENT_TYPE_ID"
                 + "\rwhere t1.SPARE_ID ='" + spare_id.Replace("'", "''") + "'";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }

        /// <summary>
        /// 取设备型号对应的备件信息.
        /// </summary>
        /// <param name="componentTypeId">设备型号Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareByComponentType(string componentTypeId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";        //错误信息返回参数.
            string sSql = "select "
                + "a.spare_id,"
                + "a.spare_name,"
                + "a.spare_ename,"
                + "a.partnumber,"
                + "a.partnumber_his1,"
                + "a.partnumber_his2,"
                + "a.picnumber,"
                + "a.piccode,"
                + "a.sparestuff,"
                + "a.unit_name,"
                + "a.alertstock,"
                + "a.ISSPECIALSP,case a.ISSPECIALSP when 1 then '是' else '否' end isspecialsp_name ,"
                + "a.creator ,b.comptypespareid ,b.makeupNumber,a.ATTACHCOMP,a.ATTACHTYPE,ISSPECIALSP,a.remark"
                + " from t_spare a "
                + " left join t_componenttype_spare b on a.spare_Id = b.spare_Id "
                + " where b.component_type_id = '" + componentTypeId + "' "
                + " order by a.picnumber,case when dbo.isreallyNumeric(a.PICCODE) = 1 then cast(a.piccode as numeric) else 999999 end, a.PICCODE,spare_name,spare_ename";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///得到备件信息和库存信息
        /// </summary>
        public DataTable GetSpareInfoAndStock(string Id, string SHIP_ID)
        {
            string err;
            sql = "select "
                + "a.SPARE_ID"
                + ",a.SPARE_NAME"
                + ",a.SPARE_ENAME"
                + ",a.PARTNUMBER"
                + ",a.PICNUMBER"
                + ",a.PICCODE"
                + ",a.SPARESTUFF"
                + ",a.ATTACHCOMP"
                + ",a.ATTACHTYPE"
                + ",a.REMARK"
                + ",a.ISSPECIALSP"
                + ",a.ALERTSTOCK"
                + ",a.PARTNUMBER_HIS1"
                + ",a.PARTNUMBER_HIS2"
                + ",a.UNIT_NAME"
                + ",isnull(c.STOCKSAll,0) as STOCKSAll"
                + " from T_SPARE a "
                + " left join (select SHIP_ID , SPARE_ID ,sum(STOCKSAll) STOCKSAll from V_SPARE_STOCKS where ship_id = '"
                + SHIP_ID + "' group by spare_id,SHIP_ID) c on a.spare_Id = c.spare_Id "
                + " where upper(a.SPARE_ID)='" + Id.ToUpper() + "'";
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
        /// 取设备型号对应的备件信息.
        /// </summary>
        /// <param name="componentTypeId">设备型号Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareByComponentType(string componentTypeId, string shipId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";        //错误信息返回参数.
            string sSql = "select "
                + "a.spare_id,"
                + "a.spare_name,"
                + "a.spare_ename,"
                + "isnull(c.STOCKSAll,0) STOCKSAll,"
                + "a.partnumber,"
                + "a.partnumber_his1,"
                + "a.partnumber_his2,"
                + "a.picnumber,"
                + "a.piccode,"
                + "a.sparestuff,"
                + "a.unit_name,"
                + "a.alertstock,"
                + "a.ISSPECIALSP,case a.ISSPECIALSP when 1 then '是' else '否' end isspecialsp_name ,"
                + "a.creator ,b.comptypespareid ,b.makeupNumber,a.ATTACHCOMP,a.ATTACHTYPE,ISSPECIALSP,a.remark"
                + " from t_spare a "
                + " left join t_componenttype_spare b on a.spare_Id = b.spare_Id "
                + " left join (select SHIP_ID , SPARE_ID ,sum(STOCKSAll) STOCKSAll from V_SPARE_STOCKS where ship_id = '"
                + shipId + "' group by spare_id,SHIP_ID) c on a.spare_Id = c.spare_Id "
                + " where b.component_type_id = '" + componentTypeId + "'  "
                + " order by a.picnumber,case when dbo.isreallyNumeric(a.PICCODE) = 1 then cast(a.piccode as numeric) else 999999 end, a.PICCODE,spare_name,spare_ename";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 取设备型号对应的备件信息.
        /// </summary>
        /// <param name="componentTypeId">设备型号Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSparesByComponentTypeAndTypeChild(string componentTypeId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            List<ComponentType> eqtypes = ComponentTypeService.Instance.GetSonEquipmentTypes(componentTypeId, out err);
            string typeIds = "";
            foreach (ComponentType ty in eqtypes)
            {
                typeIds += "'" + ty.COMPONENT_TYPE_ID.ToUpper() + "',";
            }
            typeIds += "'" + componentTypeId.ToUpper() + "'";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.spare_id,";
            sSql += "a.spare_name,";
            sSql += "a.spare_ename,";
            sSql += "a.partnumber,";
            sSql += "a.partnumber_his1,";
            sSql += "a.partnumber_his2,";
            sSql += "a.picnumber,";
            sSql += "a.piccode,";
            sSql += "a.sparestuff,";
            sSql += "a.unit_name,";
            sSql += "a.alertstock,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_spare a ";
            sSql += "left join t_componenttype_spare b on a.spare_Id = b.spare_Id ";
            sSql += "where upper(b.component_type_id) in(" + typeIds + ")";
            sSql += "order by a.picnumber,case when dbo.isreallyNumeric(a.PICCODE) = 1 then cast(a.piccode as numeric) else 999999 end, a.PICCODE,spare_name,spare_ename";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public SpareInfo GetOneObjectByNameAndPartno(string name, string partno, out string err)
        {
            sql = "select "
              + "SPARE_ID"
              + ",SPARE_NAME"
              + ",SPARE_ENAME"
              + ",PARTNUMBER"
              + ",PICNUMBER"
              + ",PICCODE"
              + ",SPARESTUFF"
              + ",ATTACHCOMP"
              + ",ATTACHTYPE"
              + ",REMARK"
              + ",UNIT_NAME"
              + ",ISSPECIALSP"
              + ",ALERTSTOCK"
              + ",PARTNUMBER_HIS1"
              + ",PARTNUMBER_HIS2"
              + "\rfrom T_SPARE "
              + "\rwhere SPARE_NAME=N'" + name.Replace("'", "''") + "' and PARTNUMBER = N'" + partno.Replace("'", "''") + "'";
            DataTable dtb;
            if (!dbAccess.GetDataTable(sql, out dtb, out err) || dtb.Rows.Count == 0)
            {
                return null;
            }
            return getObject(dtb.Rows[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public ComponentUnit SpareOfEquipment(string spareId)
        {
            ComponentUnit theUnit = null;
            string sql = "select top 1 COMPONENT_UNIT_ID"
              + "\rfrom dbo.T_COMPONENTTYPE_SPARE t1 inner join dbo.T_COMPONENT_UNIT t2 on "
              + "\rt2.COMPONENT_TYPE_ID = t1.COMPONENT_TYPE_ID "
              + "\rwhere t1.SPARE_ID = '" + spareId + "'";
            string unitId = dbAccess.GetString(sql);
            if (string.IsNullOrEmpty(unitId)) return null;
            string err;
            theUnit = ComponentUnitService.Instance.getObject(unitId, out err);
            if (theUnit == null || theUnit.IsWrong) return null;
            return theUnit;
        }
        /// <summary>
        /// 更新备件的相关设备和分类信息
        /// </summary>
        /// <param name="shipId"></param>
        public bool UpdateSpareComponentInfo(out string err)
        {
            //1.判断是否有存储过程,没有的话,进行创建.
            //2.屏蔽备件的触发器
            //3.执行存储过程
            //4.打开备件触发器
            #region 存储过程代码
            string procedureCode = @"create procedure [dbo].[P_Reset_Spare_CompInfo] 
as
begin 
   declare @haveTable int;
	select @haveTable = COUNT(1) from sysobjects where name = 'T_temp_classsort';
	if @haveTable = 1 begin
	drop table T_temp_classsort;
	end ;
	with ClassToSort(classId,ParentClassId,classFullName,sortNo,deep)As
	(
		select CLASSID,ParentClassId,cast(CLASSNAME as varchar(300)), cast((case when sortNo >990 then 99 else sortno / 10 end) as numeric(38,0)),1 from dbo.T_EQUIPMENT_CLASS 
		union all
		select t2.CLASSID,t1.ParentClassId,cast(t1.CLASSNAME + '--' + t2.classFullName as varchar(300)), 
		cast( t1.sortno * ( case deep when 3 then 1000000 when 2 then 10000 when 1 then 100 else 1 end) / 10  +  t2.sortNo as numeric(38,0) ),deep + 1
		from dbo.T_EQUIPMENT_CLASS t1 inner join ClassToSort t2 on t2.ParentClassId = t1.CLASSID
	)
	select sortNo * case deep when 1 then 1000000 when 2 then 10000 when 3 then 100 else 1 end Classsort,* 
	into T_temp_classsort
	from ClassToSort where ParentClassId  is null
	order by Classsort
	
	select @haveTable = COUNT(1) from sysobjects where name = 't_temp_compsort';
	if @haveTable = 1 begin
	drop table t_temp_compsort;
	end ;
	with  compnent_unit_Temp(compid ,topid,compfullname,oldsort,sortno,times) as
	(
		select COMPONENT_UNIT_ID, COMPONENT_UNIT_ID ,
		cast(COMP_CHINESE_NAME as varchar(300)),cast(sortno /10 as numeric(38,0) ),cast(sortno /10 as numeric(38,0) ), 1
		from t_component_unit 
		where isnull(PARENT_UNIT_ID,'') <> ''
		union all
		select t1.compid,t2.parent_unit_id,cast( t3.COMP_CHINESE_NAME + '--' + compfullname  as varchar(300)),t1.sortno
		 ,cast( t2.sortno * ( case times when 3 then 1000000 when 2 then 10000 when 1 then 100 else 1 end) / 10  +  case when times = 1 then 0 else t1.sortNo end  as numeric(38,0) ), times+1
		from compnent_unit_Temp t1 inner join t_component_unit t2 on t2.COMPONENT_UNIT_ID = t1.topid
		inner join t_component_unit t3 on t2.PARENT_UNIT_ID = t3.COMPONENT_UNIT_ID
		where isnull(t3.PARENT_UNIT_ID,'') <> ''
	) 
	select t2.*,t3.COMP_CHINESE_NAME,t4.COMP_CHINESE_NAME topname,
	case when t1.times = 1 then t6.classsort * 1000000000 + t5.SORTNO * 10000000
			 else (t8.classsort * 1000000000 + t7.SORTNO * 10000000 + 
			 t2.sortno * case t2.times when 2 then 10000
			 when 3 then 100 else 1 end) end compsort 
	into t_temp_compsort
	from 
	(select compid , max(times) times from compnent_unit_Temp group by compid) t1 
	inner join compnent_unit_Temp t2 on t1.compid = t2.compid and t1.times = t2.times 
	inner join t_component_unit t3 on t2.compid = t3.COMPONENT_UNIT_ID 
	inner join t_component_unit t4 on t2.topid = t4.COMPONENT_UNIT_ID 
	left join T_EQUIPMENT_CLASS_REF t5 on t1.compid = t5.COMPONENT_UNIT_ID
	left join T_temp_classsort t6 on t5.CLASSID = t6.classId
	left join T_EQUIPMENT_CLASS_REF t7 on t2.topid = t7.COMPONENT_UNIT_ID
	left join T_temp_classsort t8 on t8.CLASSID = t7.classId
    
	update t_spare
	set [ATTACHTYPE] = isnull(t7.classFullName ,''),
		ATTACHCOMP = case when t3.COMPTYPE_CHINESE_NAME IS null then '' else t3.COMPTYPE_CHINESE_NAME end 
	  + case when COMPONENT_STYLE is not null and isnull(t3.COMPTYPE_CHINESE_NAME,'') <> t3.COMPONENT_STYLE then ' ( '+t3.COMPONENT_STYLE + ' )' else '' end
	from
	t_spare t1 left join (select max(COMPONENT_TYPE_ID) COMPONENT_TYPE_ID,SPARE_ID from T_COMPONENTTYPE_SPARE group by SPARE_ID) t2 on t1.SPARE_ID = t2.SPARE_ID 
	left join T_COMPONENT_TYPE t3 on t2.COMPONENT_TYPE_ID= t3.COMPONENT_TYPE_ID
	left join (select max(COMPONENT_UNIT_ID) COMPONENT_UNIT_ID,COMPONENT_TYPE_ID from T_COMPONENT_UNIT group by COMPONENT_TYPE_ID) t4 on t3.COMPONENT_TYPE_ID = t4.COMPONENT_TYPE_ID
	left join (select compid,max(topid) topid from t_temp_compsort group by compid) t5 on t4.COMPONENT_UNIT_ID = t5.compid
	left join T_COMPONENT_UNIT t6 on t5.topid = t6.COMPONENT_UNIT_ID
	left join 
	(select Classsort ,t3.*,t4.SORTNO refSortno ,t4.COMPONENT_UNIT_ID,t1.classFullName
	 from T_temp_classsort t1  
	inner join T_EQUIPMENT_CLASS t3 on t1.classId = t3.CLASSID
	inner join T_EQUIPMENT_CLASS_REF t4 on t3.CLASSID = t4.CLASSID) t7 on t6.COMPONENT_UNIT_ID = t7.COMPONENT_UNIT_ID

end";
            #endregion 
            string sql = "select COUNT(1) from sysobjects where name = 'P_Reset_Spare_CompInfo' and xtype = 'P'";
            List<string> sqls = new List<string>();

            if (dbAccess.GetString(sql) == "0")
            {
                sqls.Add(procedureCode);
                sqls.Add("alter table t_spare alter column ATTACHCOMP varchar(500)");
                sqls.Add("alter table t_spare alter column ATTACHTYPE varchar(500)");
            }
            dbAccess.ExecSql(sqls, out err);
            sqls.Clear();
            sqls.Add("exec StartOrStopATableSynchTrigger 't_spare',0");
            sqls.Add("exec dbo.P_Reset_Spare_CompInfo ");
            sqls.Add("exec StartOrStopATableSynchTrigger 't_spare',1");
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
