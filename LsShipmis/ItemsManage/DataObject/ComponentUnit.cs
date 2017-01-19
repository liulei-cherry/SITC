/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ComponentUnit.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/28
 * 标    题：实体类
 * 功能描述：T_COMPONENT_UNIT数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using ItemsManage.Services;

namespace ItemsManage.DataObject
{
    /// <summary>
    ///T_COMPONENT_UNIT数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ComponentUnit : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public ComponentUnit()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ComponentUnit
        (
            string cOMPONENT_UNIT_ID,
            string cOMPONENT_TYPE_ID,
            string pARENT_UNIT_ID,
            string cOMP_NUMBER,
            DateTime pRODUCE_TIME,
            DateTime uSE_TIME,
            decimal uSE_RATE,
            string cOMP_CHINESE_NAME,
            string cOMP_ENGLISH_NAME,
            decimal cOMP_STATUS,
            string eXAMINATION_CODE,
            string sHIP_ID,
            string cWBT_CODE,
            string wareHouse,
            decimal total_workhours,
            DateTime last_couter_time,
            decimal after_repair_hours,
            DateTime repair_date,
            string comp_serial_no,
            string certification,
            string detail,
            decimal sortNo
        )
        {
            this.COMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            this.COMPONENT_TYPE_ID = cOMPONENT_TYPE_ID;
            this.PARENT_UNIT_ID = pARENT_UNIT_ID;
            this.COMP_NUMBER = cOMP_NUMBER;
            this.PRODUCE_TIME = pRODUCE_TIME;
            this.USE_TIME = uSE_TIME;
            this.USE_RATE = uSE_RATE;
            this.COMP_CHINESE_NAME = cOMP_CHINESE_NAME;
            this.COMP_ENGLISH_NAME = cOMP_ENGLISH_NAME;
            this.COMP_STATUS = cOMP_STATUS;
            this.EXAMINATION_CODE = eXAMINATION_CODE;
            this.SHIP_ID = sHIP_ID;
            this.CWBT_CODE = cWBT_CODE;
            this.wareHouse = wareHouse;
            this.total_workhours = total_workhours;
            this.last_couter_time = last_couter_time;
            this.after_repair_hours = after_repair_hours;
            this.repair_date = repair_date;
            this.comp_serial_no = comp_serial_no;
            this.certification = certification;
            this.Detail = detail;
            this.SortNo = sortNo;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string COMPONENT_UNIT_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COMPONENT_TYPE_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PARENT_UNIT_ID { get; set; }

        ///<summary>
        ///新的作用,当无内容或者内容为"SB",表达是'设备',"BJ"表达是'部件'
        ///</summary>
        public string COMP_NUMBER { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime PRODUCE_TIME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime USE_TIME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal USE_RATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COMP_CHINESE_NAME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COMP_ENGLISH_NAME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal COMP_STATUS { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string EXAMINATION_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CWBT_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string wareHouse { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal total_workhours { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime last_couter_time { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal after_repair_hours { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime repair_date { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string comp_serial_no { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string certification { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Detail { get; set; }

        ///<summary>
        ///排序编号.
        ///</summary>
        public decimal SortNo { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ComponentUnit Unit = new ComponentUnit();
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.COMPONENT_TYPE_ID = this.COMPONENT_TYPE_ID;
            Unit.PARENT_UNIT_ID = this.PARENT_UNIT_ID;
            Unit.COMP_NUMBER = this.COMP_NUMBER;
            Unit.PRODUCE_TIME = this.PRODUCE_TIME;
            Unit.USE_TIME = this.USE_TIME;
            Unit.USE_RATE = this.USE_RATE;
            Unit.COMP_CHINESE_NAME = this.COMP_CHINESE_NAME;
            Unit.COMP_ENGLISH_NAME = this.COMP_ENGLISH_NAME;
            Unit.COMP_STATUS = this.COMP_STATUS;
            Unit.EXAMINATION_CODE = this.EXAMINATION_CODE;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CWBT_CODE = this.CWBT_CODE;
            Unit.wareHouse = this.wareHouse;
            Unit.total_workhours = this.total_workhours;
            Unit.last_couter_time = this.last_couter_time;
            Unit.after_repair_hours = this.after_repair_hours;
            Unit.repair_date = this.repair_date;
            Unit.comp_serial_no = this.comp_serial_no;
            Unit.certification = this.certification;
            Unit.Detail = this.Detail;
            Unit.SortNo = this.SortNo;
            return Unit;
        }
        #endregion
        public override string ToString()
        {
            string re = COMP_CHINESE_NAME;
            if (!string.IsNullOrEmpty(COMP_ENGLISH_NAME) && !COMP_CHINESE_NAME.Contains(COMP_ENGLISH_NAME))
            {
                re += "(" + COMP_ENGLISH_NAME + ")";
            }
            //以后有了设备型号 应该主动把设备型号名也加进来!
            return re;
        }
        public override string GetId()
        {
            return this.COMPONENT_UNIT_ID;
        }

        public override string GetTypeName()
        {
            return "ComponentUnit";
        }
          
        public override bool Update(out string err)
        {
            if (!canUpdate(out err)) return false;
            if (!ComponentUnitService.Instance.saveUnit(this, out err)) return false;
            return ComponentUnitService.Instance.resortUnit(this, out err);
        }
        public override bool Delete(out string err)
        {
            if (!canDelete(out err)) return false;
            return ComponentUnitService.Instance.deleteUnit(this, out err);
        }
        public override void FillThisObject()
        {
            //很多都没有写.
            string err;
            if (TheComponentType == null )
            {
                if (COMPONENT_TYPE_ID != null && COMPONENT_TYPE_ID.Length == 36)
                {
                    TheComponentType = ComponentTypeService.Instance.getObject(COMPONENT_TYPE_ID, out err);

                }
                else
                {
                    TheComponentType = new ComponentType();
                    TheComponentType.IsWrong = true;
                    TheComponentType.WhyWrong = "";
                }
            }
            if (TheParentComponentUnit == null)
            {
                if (String.IsNullOrEmpty(PARENT_UNIT_ID))
                {
                    TheParentComponentUnit = new ComponentUnit();
                    TheParentComponentUnit.IsWrong = false;
                }
                else if (PARENT_UNIT_ID.Length == 36)
                {
                    TheParentComponentUnit = ComponentUnitService.Instance.getObject(PARENT_UNIT_ID, out err);

                }
                else
                {
                    TheParentComponentUnit = new ComponentUnit();
                    TheParentComponentUnit.IsWrong = true;
                    TheParentComponentUnit.WhyWrong = "";
                }
            }
        }

        /// <summary>
        /// 提交前的判断.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool canUpdate(out string err)
        {
            err = "";
            if (string.IsNullOrEmpty(COMPONENT_TYPE_ID))
            {
                err = "设备型号必须填写";
                return false;
            }
            if (string.IsNullOrEmpty(COMP_CHINESE_NAME))
            {
                err = "设备名称必须填写";
                return false;
            }
            return true;
        }

        private bool canDelete(out string err)
        {
            return ComponentUnitService.Instance.oneEquipmentCanBeDeleted(this, out err);
        }

        public bool CompletelyDelete(out string err)
        {
            return ComponentUnitService.Instance.CompletelyDeleteOneEquipment(this, out err);
        }
        public ComponentType TheComponentType { get; set; }

        public ComponentUnit TheParentComponentUnit { get; set; }

    }
}
