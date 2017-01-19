/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSCheckLog.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/26
 * 标    题：实体类
 * 功能描述：T_CMS_CHECKING_LOG数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CMSManage.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace CMSManage.DataObject
{
    /// <summary>
    ///T_CMS_CHECKING_LOG数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CMSCheckLog : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///表达一次CMS检验的相关信息,
        ///此信息作为CMS检验表的一种管理维度,
        ///同时记录船级社CMS的检验意见等信息.
        ///
        ///一次检验日志中可以既包含船级社检验的内容又包含船舶自查的内容。.
        ///
        ///一次检验中关联过的数据项将不再出现在其他检验日志中.
        ///</summary>
        public CMSCheckLog()
        {
        }
        ///<summary>
        ///表达一次CMS检验的相关信息,
        ///此信息作为CMS检验表的一种管理维度,
        ///同时记录船级社CMS的检验意见等信息.
        ///
        ///一次检验日志中可以既包含船级社检验的内容又包含船舶自查的内容。.
        ///
        ///一次检验中关联过的数据项将不再出现在其他检验日志中.
        ///</summary>
        public CMSCheckLog
        (
            string cHECK_LOG_ID,
            string cHECK_NAME,
            DateTime cHECK_DATE,
            string cHECK_PERSON,
            string cHECK_PLACE,
            string cHECK_DETAIL,
            DateTime cHECK_SPAN_BEGIN,
            DateTime cHECK_SPAN_END,
            string sHIP_ID,
            decimal cHECK_STATE
        )
        {
            this.CHECK_LOG_ID = cHECK_LOG_ID;
            this.CHECK_NAME = cHECK_NAME;
            this.CHECK_DATE = cHECK_DATE;
            this.CHECK_PERSON = cHECK_PERSON;
            this.CHECK_PLACE = cHECK_PLACE;
            this.CHECK_DETAIL = cHECK_DETAIL;
            this.CHECK_SPAN_BEGIN = cHECK_SPAN_BEGIN;
            this.CHECK_SPAN_END = cHECK_SPAN_END;
            this.SHIP_ID = sHIP_ID;
            this.CHECK_STATE = cHECK_STATE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string CHECK_LOG_ID { get; set; }

        ///<summary>
        ///检验代码.
        ///</summary>
        public string CHECK_NAME { get; set; }

        ///<summary>
        ///检验日期.
        ///</summary>
        public DateTime CHECK_DATE { get; set; }

        ///<summary>
        ///船级社人员姓名.
        ///</summary>
        public string CHECK_PERSON { get; set; }

        ///<summary>
        ///检查地点.
        ///</summary>
        public string CHECK_PLACE { get; set; }

        ///<summary>
        ///检验总体描述.
        ///</summary>
        public string CHECK_DETAIL { get; set; }

        ///<summary>
        ///跨度开始.
        ///</summary>
        public DateTime CHECK_SPAN_BEGIN { get; set; }

        ///<summary>
        ///跨度结束.
        ///</summary>
        public DateTime CHECK_SPAN_END { get; set; }

        ///<summary>
        ///船舶id
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///检查状态1.计划，2检验通过，3存在缺陷,4缺陷整改完成.
        ///</summary>
        public decimal CHECK_STATE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CMSCheckLog Unit = new CMSCheckLog();
            Unit.CHECK_LOG_ID = this.CHECK_LOG_ID;
            Unit.CHECK_NAME = this.CHECK_NAME;
            Unit.CHECK_DATE = this.CHECK_DATE;
            Unit.CHECK_PERSON = this.CHECK_PERSON;
            Unit.CHECK_PLACE = this.CHECK_PLACE;
            Unit.CHECK_DETAIL = this.CHECK_DETAIL;
            Unit.CHECK_SPAN_BEGIN = this.CHECK_SPAN_BEGIN;
            Unit.CHECK_SPAN_END = this.CHECK_SPAN_END;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CHECK_STATE = this.CHECK_STATE;
            return Unit;
        }
        #endregion

        public ShipInfo TheShip { get; set; }

        public override string GetId()
        {
            return this.CHECK_LOG_ID;
        }

        public override string GetTypeName()
        {
            return "CMSCheckLog";
        }

        public override bool Update(out string err)
        {
            if (canUpdate(out err))
                return CMSCheckLogService.Instance.saveUnit(this, out err);
            else
            {
                return false;
            }
        }

        public override bool Delete(out string err)
        {
            return CMSCheckLogService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if ((TheShip == null || TheShip.IsWrong) && !string.IsNullOrEmpty(SHIP_ID) && SHIP_ID.Trim().Length == 36)
            {
                string err;
                TheShip = ShipInfoService.Instance.getObject(SHIP_ID, out err);
            }
        }

        public override string ToString()
        {
            FillThisObject();
            if (TheShip != null && !TheShip.IsWrong)
                return TheShip.SHIP_NAME + "(" + this.CHECK_NAME + ")";
            else
                return this.CHECK_NAME;
        }
        public bool canUpdate(out string err)
        {
            err = "当前检验编号已经存在,不允许保存当前数据,请更新检验编号后再尝试保存";
            //当前表的检验编号不允许重复;
            return !CMSCheckLogService.Instance.CMSCodeIsDuplicated(CHECK_NAME, SHIP_ID, GetId());
        }
    }
}
