/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CTB_XFJSTJB.cs
 * 创 建 人：徐正本
 * 创建时间：2012-4-6
 * 标    题：实体类
 * 功能描述：T_CTB_XFJSTJB数据实体类
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
    ///T_CTB_XFJSTJB数据实体
    /// </summary>
    ///[Serializable]
    public partial class CTB_XFJSTJB : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public CTB_XFJSTJB()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public CTB_XFJSTJB
        (
            string iD,
            string sortNo,
            string equipmentName,
            string equipmentCOUNT,
            string equipmentSPEC,
            DateTime warningDate,
            string lastCHECKEDDateDetail,
            string validDateDetail,
            string sHIP_ID
        )
        {
            this.ID = iD;
            this.SortNo = sortNo;
            this.EquipmentName = equipmentName;
            this.EquipmentCOUNT = equipmentCOUNT;
            this.EquipmentSPEC = equipmentSPEC;
            this.WarningDate = warningDate;
            this.LastCHECKEDDateDetail = lastCHECKEDDateDetail;
            this.ValidDateDetail = validDateDetail;
            this.SHIP_ID = sHIP_ID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///排序号
        ///</summary>
        public string SortNo { get; set; }

        ///<summary>
        ///项目
        ///</summary>
        public string EquipmentName { get; set; }

        ///<summary>
        ///数量
        ///</summary>
        public string EquipmentCOUNT { get; set; }

        ///<summary>
        ///规格
        ///</summary>
        public string EquipmentSPEC { get; set; }

        ///<summary>
        ///报警日期
        ///</summary>
        public DateTime WarningDate { get; set; }

        ///<summary>
        ///上次检验日期
        ///</summary>
        public string LastCHECKEDDateDetail { get; set; }

        ///<summary>
        ///有效期描述
        ///</summary>
        public string ValidDateDetail { get; set; }

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
            CTB_XFJSTJB Unit = new CTB_XFJSTJB();
            Unit.ID = this.ID;
            Unit.SortNo = this.SortNo;
            Unit.EquipmentName = this.EquipmentName;
            Unit.EquipmentCOUNT = this.EquipmentCOUNT;
            Unit.EquipmentSPEC = this.EquipmentSPEC;
            Unit.WarningDate = this.WarningDate;
            Unit.LastCHECKEDDateDetail = this.LastCHECKEDDateDetail;
            Unit.ValidDateDetail = this.ValidDateDetail;
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
            return "CTB_XFJSTJB";
        }

        public override bool Update(out string err)
        {
            return CTB_XFJSTJBService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CTB_XFJSTJBService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
