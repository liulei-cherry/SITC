/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CTB_TDSBTJB.cs
 * 创 建 人：徐正本
 * 创建时间：2012-4-6
 * 标    题：实体类
 * 功能描述：T_CTB_TDSBTJB数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CustomTable.Haifeng.Services;

namespace CustomTable.Haifeng.DataObject
{
    /// <summary>
    ///T_CTB_TDSBTJB数据实体
    /// </summary>
    ///[Serializable]
    public partial class CTB_TDSBTJB : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public CTB_TDSBTJB()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public CTB_TDSBTJB
        (
            string iD,
            string equipmentName,
            string sortNo,
            string sEQUNCE,
            DateTime dueDate,
            string equipmentFactory,
            string equipmentType,
            string equipSerialNo,
            string detail,
            string sHIP_ID
        )
        {
            this.ID = iD;
            this.EquipmentName = equipmentName;
            this.SortNo = sortNo;
            this.SEQUNCE = sEQUNCE;
            this.DueDate = dueDate;
            this.EquipmentFactory = equipmentFactory;
            this.EquipmentType = equipmentType;
            this.EquipSerialNo = equipSerialNo;
            this.Detail = detail;
            this.SHIP_ID = sHIP_ID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///设备明细
        ///</summary>
        public string EquipmentName { get; set; }

        ///<summary>
        ///排序号
        ///</summary>
        public string SortNo { get; set; }

        ///<summary>
        ///表格显示序号
        ///</summary>
        public string SEQUNCE { get; set; }

        ///<summary>
        ///报警日期
        ///</summary>
        public DateTime DueDate { get; set; }

        ///<summary>
        ///设备厂家
        ///</summary>
        public string EquipmentFactory { get; set; }

        ///<summary>
        ///设备型号
        ///</summary>
        public string EquipmentType { get; set; }

        ///<summary>
        ///设备系列号
        ///</summary>
        public string EquipSerialNo { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Detail { get; set; }

        ///<summary>
        ///所属船舶
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CTB_TDSBTJB Unit = new CTB_TDSBTJB();
            Unit.ID = this.ID;
            Unit.EquipmentName = this.EquipmentName;
            Unit.SortNo = this.SortNo;
            Unit.SEQUNCE = this.SEQUNCE;
            Unit.DueDate = this.DueDate;
            Unit.EquipmentFactory = this.EquipmentFactory;
            Unit.EquipmentType = this.EquipmentType;
            Unit.EquipSerialNo = this.EquipSerialNo;
            Unit.Detail = this.Detail;
            Unit.SHIP_ID = this.SHIP_ID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.ID;
        }

        public override string GetTypeName()
        {
            return "CTB_TDSBTJB";
        }

        public override bool Update(out string err)
        {
            return CTB_TDSBTJBService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CTB_TDSBTJBService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
