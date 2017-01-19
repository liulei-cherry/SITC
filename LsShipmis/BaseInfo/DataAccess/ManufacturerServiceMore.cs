using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using BaseInfo.Objects;

namespace BaseInfo.DataAccess
{
    partial class ManufacturerService : IObjectsService
    {
        #region IObjectsService 成员

       public  CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("MANUFACTURER_NoUse", "是否作废");
            reValue.Add("MANUFACTURER_NAME", "厂家名称");
            reValue.Add("MANUFACTURER_CODE", "SAP代码");
            reValue.Add("MANUFACTURER_TYPE", "厂家类型");
            reValue.Add("MOBILPHONE", "移动电话");
            reValue.Add("TELEPHONE", "固定电话"); 
            reValue.Add("LINKER", "联系人"); 
            return reValue;
        }

        #endregion

        /// <summary>
        /// 根据.
        /// </summary>
        /// <param name="manufacturerName"></param>        
        /// <returns></returns>
        public Manufacturer getObjectByName(string name)
        {
            string err ;
            string manufacturer_id;
            sql = "Select   MANUFACTURER_ID from T_MANUFACTURER where   MANUFACTURER_NAME = '" + name + "'";
            manufacturer_id = dbAccess.GetString(sql);
            try
            {
                DataTable dt = getInfo(manufacturer_id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {

                return getObject(null);
            }
        }

        public bool UpdateAManufacturerObject(string name, string contact, out string err)
        {
            err = "";
            if (string.IsNullOrEmpty(name))
            {
                err = "供应商名称不可为空!";
                return false;
            }
            Manufacturer toUpdateObject = getObjectByName(name);
            if (toUpdateObject == null || toUpdateObject.IsWrong )
            {
                toUpdateObject = new Manufacturer();                
            }
            else if (toUpdateObject.TELEPHONE == contact)
            {
                return true;
            }
            toUpdateObject.TELEPHONE = contact;
            toUpdateObject.MANUFACTURER_NAME=name;
            //toUpdateObject.MANUFACTURER_CODE = "默认添加";
            return toUpdateObject.Update (out err);
        }

        /// <summary>
        /// 得到T_MANUFACTURER 所有数据信息，用于下拉框.
        /// </summary>
        /// <returns>T_MANUFACTURER DataTable</returns>
        public DataTable getInfoList(out string err)
        {
            sql = "select	"
                + "MANUFACTURER_ID, "
                + "MANUFACTURER_NAME "
                + "  from T_MANUFACTURER order by MANUFACTURER_NAME";
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
        /// 获取某类型厂家的中英文名.
        /// </summary>
        /// <param name="code">厂商某类型代号 A:修船 B:油 C:备件 D:物资 E:其他</param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getInfoListByType(string code,out string err)
        {
            err = "";
            sql = "select "
                + "MANUFACTURER_ID,"
                + "MANUFACTURER_NAME,"
                + "[MANUFACTURER_ENAME]"
                + " from T_MANUFACTURER"
                + " WHERE MANUFACTURER_TYPE = '" + code.ToUpper() + "'"
                + " order by MANUFACTURER_NAME";

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


        public bool ErrManufacturerChecking(out DataTable errDatas)
        {
            string err = ""; 
            errDatas = null;
            sql = @"select MANUFACTURER_NAME  
from T_MANUFACTURER
group by MANUFACTURER_NAME
having count(1)>1";
            if (dbAccess.GetDataTable(sql, out errDatas, out err))
            {
                if (errDatas != null && errDatas.Rows.Count > 0)
                {
                    //合并重复的供应商
                }
            }
            return true;

        }

        public bool CombineSameManufacturer(DataTable dt, out string err)
        {
            err = "";
            return true;
        }
    }
}
