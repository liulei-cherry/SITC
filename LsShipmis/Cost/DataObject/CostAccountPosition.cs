/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostAccountPosition.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/10/10
 * 标    题：实体类
 * 功能描述：T_COST_ACCOUNT_POSITION数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Cost.Services;

namespace Cost.DataObject
{
    /// <summary>
    ///T_COST_ACCOUNT_POSITION数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CostAccountPosition : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///科目分类定位表.
        ///</summary>
        public CostAccountPosition()
        {
        }
        ///<summary>
        ///科目分类定位表.
        ///</summary>
        public CostAccountPosition
        (
            string pOSITION_ID,
            string nODE_ID,
            string cLASS,
            int oRDER_NUM
        )
        {
            this.POSITION_ID = pOSITION_ID;
            this.NODE_ID = nODE_ID;
            this.CLASS = cLASS;
            this.ORDER_NUM = oRDER_NUM;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///ID
        ///</summary>
        public string POSITION_ID { get; set; }

        ///<summary>
        ///科目ID
        ///</summary>
        public string NODE_ID { get; set; }

        ///<summary>
        ///类别（1：备件；2：物料；3：航修；4：坞修；5：捆扎件；6：缆绳；.
        ///7：油漆;8:化学品）.
        ///</summary>
        public string CLASS { get; set; }

        ///<summary>
        ///排序号.
        ///</summary>
        public int ORDER_NUM { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CostAccountPosition Unit = new CostAccountPosition();
            Unit.POSITION_ID = this.POSITION_ID;
            Unit.NODE_ID = this.NODE_ID;
            Unit.CLASS = this.CLASS;
            Unit.ORDER_NUM = this.ORDER_NUM;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.POSITION_ID;
        }

        public override string GetTypeName()
        {
            return "CostAccountPosition";
        }

        public override bool Update(out string err)
        {
            return CostAccountPositionService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CostAccountPositionService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
