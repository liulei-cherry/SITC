/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSRectify.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/20
 * 标    题：实体类
 * 功能描述：T_CMS_RECTIFY数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CMSManage.Services;

namespace CMSManage.DataObject
{
    /// <summary>
    ///T_CMS_RECTIFY数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CMSRectify : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///缺陷整改记录,记录哪次检验,整改的内容.
        ///整改状态,整改时间,船级社意见等.
        ///</summary>
        public CMSRectify()
        {
        }
        ///<summary>
        ///缺陷整改记录,记录哪次检验,整改的内容.
        ///整改状态,整改时间,船级社意见等.
        ///</summary>
        public CMSRectify
        (
            string cMS_RECTIFY_ID,
            string cMS_CHECK_ID,
            string rECTIFY_OPINION,
            decimal rECTIFY_STATE,
            DateTime rECTIFY_PLAN_DATE,
            DateTime rECTIFY_DATE,
            string rECTIFY_DETAIL,
            string rECTIFY_APPROVE,
            string sHIP_ID
        )
        {
            this.CMS_RECTIFY_ID = cMS_RECTIFY_ID;
            this.CMS_CHECK_ID = cMS_CHECK_ID;
            this.RECTIFY_OPINION = rECTIFY_OPINION;
            this.RECTIFY_STATE = rECTIFY_STATE;
            this.RECTIFY_PLAN_DATE = rECTIFY_PLAN_DATE;
            this.RECTIFY_DATE = rECTIFY_DATE;
            this.RECTIFY_DETAIL = rECTIFY_DETAIL;
            this.RECTIFY_APPROVE = rECTIFY_APPROVE;
            this.SHIP_ID = sHIP_ID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string CMS_RECTIFY_ID { get; set; }

        ///<summary>
        ///检查id
        ///</summary>
        public string CMS_CHECK_ID { get; set; }

        ///<summary>
        ///整改观点.
        ///</summary>
        public string RECTIFY_OPINION { get; set; }

        ///<summary>
        ///整个状态，1等待整改，2整改完成.
        ///</summary>
        public decimal RECTIFY_STATE { get; set; }

        ///<summary>
        ///预计整改日期.
        ///</summary>
        public DateTime RECTIFY_PLAN_DATE { get; set; }

        ///<summary>
        ///实际整改日期.
        ///</summary>
        public DateTime RECTIFY_DATE { get; set; }

        ///<summary>
        ///整改情况.
        ///</summary>
        public string RECTIFY_DETAIL { get; set; }

        ///<summary>
        ///整改批准人.
        ///</summary>
        public string RECTIFY_APPROVE { get; set; }

        ///<summary>
        ///船舶id
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CMSRectify Unit = new CMSRectify();
            Unit.CMS_RECTIFY_ID = this.CMS_RECTIFY_ID;
            Unit.CMS_CHECK_ID = this.CMS_CHECK_ID;
            Unit.RECTIFY_OPINION = this.RECTIFY_OPINION;
            Unit.RECTIFY_STATE = this.RECTIFY_STATE;
            Unit.RECTIFY_PLAN_DATE = this.RECTIFY_PLAN_DATE;
            Unit.RECTIFY_DATE = this.RECTIFY_DATE;
            Unit.RECTIFY_DETAIL = this.RECTIFY_DETAIL;
            Unit.RECTIFY_APPROVE = this.RECTIFY_APPROVE;
            Unit.SHIP_ID = this.SHIP_ID;
            return Unit;
        }
        #endregion

        public CMSCheck ThisCheck;
        public override string GetId()
        {
            return this.CMS_RECTIFY_ID;
        }

        public override string GetTypeName()
        {
            return "CMSRectify";
        }

        public override bool Update(out string err)
        {
            if (CMSRectifyService.Instance.saveUnit(this, out err))
            {
                this.FillThisObject();
                if (ThisCheck != null && !ThisCheck.IsWrong)
                {
                    ThisCheck.CHECK_STATE = 4 - this.RECTIFY_STATE;
                    return ThisCheck.Update(out err);
                }                
                return true;
            }
            else
                return false;
        }

        public override bool Delete(out string err)
        {
            return CMSRectifyService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if (ThisCheck == null || ThisCheck.IsWrong)
            {
                string err;
                ThisCheck = CMSCheckService.Instance.getObject(CMS_CHECK_ID, out err);
            }
        }
    }
}
