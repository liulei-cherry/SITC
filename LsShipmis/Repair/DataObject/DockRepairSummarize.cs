/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：DockRepairSummarize.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/1/16
 * 标    题：实体类
 * 功能描述：T_DOCKREPAIR_SUMMARIZE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Repair.Services;

namespace Repair.DataObject
{
    /// <summary>
    ///T_DOCKREPAIR_SUMMARIZE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class DockRepairSummarize : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public DockRepairSummarize()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public DockRepairSummarize
        (
            string dOCKREPAIR_SUMMARIZE_ID,
            string sHIP_ID,
            DateTime bEGINDATE,
            DateTime eNDDATE,
            string nODE_ID,
            string mANUFACTURER_ID,
            decimal tOTAL_AMOUNT,
            decimal eSTIMATE_AMOUNT,
            string cURRENCY_ID
        )
        {
            this.DOCKREPAIR_SUMMARIZE_ID = dOCKREPAIR_SUMMARIZE_ID;
            this.SHIP_ID = sHIP_ID;
            this.BEGINDATE = bEGINDATE;
            this.ENDDATE = eNDDATE;
            this.NODE_ID = nODE_ID;
            this.MANUFACTURER_ID = mANUFACTURER_ID;
            this.TOTAL_AMOUNT = tOTAL_AMOUNT;
            this.ESTIMATE_AMOUNT = eSTIMATE_AMOUNT;
            this.CURRENCY_ID = cURRENCY_ID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string DOCKREPAIR_SUMMARIZE_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime BEGINDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime ENDDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string NODE_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MANUFACTURER_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal TOTAL_AMOUNT { get; set; }

        ///<summary>
        ///预估金额.
        ///
        ///</summary>
        public decimal ESTIMATE_AMOUNT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CURRENCY_ID { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            DockRepairSummarize Unit = new DockRepairSummarize();
            Unit.DOCKREPAIR_SUMMARIZE_ID = this.DOCKREPAIR_SUMMARIZE_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.BEGINDATE = this.BEGINDATE;
            Unit.ENDDATE = this.ENDDATE;
            Unit.NODE_ID = this.NODE_ID;
            Unit.MANUFACTURER_ID = this.MANUFACTURER_ID;
            Unit.TOTAL_AMOUNT = this.TOTAL_AMOUNT;
            Unit.ESTIMATE_AMOUNT = this.ESTIMATE_AMOUNT;
            Unit.CURRENCY_ID = this.CURRENCY_ID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.DOCKREPAIR_SUMMARIZE_ID;
        }

        public override string GetTypeName()
        {
            return "DockRepairSummarize";
        }

        public override bool Update(out string err)
        {
            return DockRepairSummarizeService.Instance.saveUnit(this, out err);
        }
        public string Update()
        {
            return DockRepairSummarizeService.Instance.saveUnit(this);
        }
        public override bool Delete(out string err)
        {
            return DockRepairSummarizeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
