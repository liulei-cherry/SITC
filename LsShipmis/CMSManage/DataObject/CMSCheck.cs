/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSCheck.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/20
 * 标    题：实体类
 * 功能描述：T_CMS_CHECK数据实体类
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
    ///T_CMS_CHECK数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CMSCheck : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///CMS 检验表 对所有CMS检验项目进行管理和历史记录的表.
        ///包含主要信息有,预计检验时间,实际检验时间,检验人,检验状态,意见,检验项目相关信息等.
        ///检验信息不要强制关联T_CMS_CONFIG,避免历史信息与T_CMS_CONFIG处理时发生异常.
        ///仅在形成时使用T_CMS_CONFIG的相关信息。.
        ///</summary>
        public CMSCheck()
        {
        }
        ///<summary>
        ///CMS 检验表 对所有CMS检验项目进行管理和历史记录的表.
        ///包含主要信息有,预计检验时间,实际检验时间,检验人,检验状态,意见,检验项目相关信息等.
        ///检验信息不要强制关联T_CMS_CONFIG,避免历史信息与T_CMS_CONFIG处理时发生异常.
        ///仅在形成时使用T_CMS_CONFIG的相关信息。.
        ///</summary>
        public CMSCheck
        (
            string cMS_CHECK_ID,
            string cHECK_TITLE,
            string cMS_CODE,
            string wORKORDER_ID,
            string cHECK_DETAIL,
            DateTime pLAN_DATE,
            decimal cHECK_STATE,
            decimal cHECK_DEPART,
            string cHECK_PERSON,
            DateTime cHECK_DATE,
            string cHECK_LOG_ID,
            string sHIP_ID,
            string cHECKENGLISHNAME,
            decimal sortNo
        )
        {
            this.CMS_CHECK_ID = cMS_CHECK_ID;
            this.CHECK_TITLE = cHECK_TITLE;
            this.CMS_CODE = cMS_CODE;
            this.WORKORDER_ID = wORKORDER_ID;
            this.CHECK_DETAIL = cHECK_DETAIL;
            this.PLAN_DATE = pLAN_DATE;
            this.CHECK_STATE = cHECK_STATE;
            this.CHECK_DEPART = cHECK_DEPART;
            this.CHECK_PERSON = cHECK_PERSON;
            this.CHECK_DATE = cHECK_DATE;
            this.CHECK_LOG_ID = cHECK_LOG_ID;
            this.SHIP_ID = sHIP_ID;
            this.CHECKENGLISHNAME = cHECKENGLISHNAME;
            this.SortNo = sortNo;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string CMS_CHECK_ID { get; set; }

        ///<summary>
        ///检验项目.
        ///</summary>
        public string CHECK_TITLE { get; set; }

        ///<summary>
        ///检验代码.
        ///</summary>
        public string CMS_CODE { get; set; }

        ///<summary>
        ///工单id，根据工作信息产生或引用一个工单的id
        ///</summary>
        public string WORKORDER_ID { get; set; }

        ///<summary>
        ///检验内容.
        ///</summary>
        public string CHECK_DETAIL { get; set; }

        ///<summary>
        ///具体安排日期.
        ///</summary>
        public DateTime PLAN_DATE { get; set; }

        ///<summary>
        ///1.计划，2检验通过，3存在缺陷.
        ///</summary>
        public decimal CHECK_STATE { get; set; }

        ///<summary>
        ///1.自行检查，2.船级社检查.
        ///</summary>
        public decimal CHECK_DEPART { get; set; }

        ///<summary>
        ///检查人姓名.
        ///</summary>
        public string CHECK_PERSON { get; set; }

        ///<summary>
        ///实际检查日期.
        ///</summary>
        public DateTime CHECK_DATE { get; set; }

        ///<summary>
        ///检验日志id
        ///</summary>
        public string CHECK_LOG_ID { get; set; }

        ///<summary>
        ///船舶id
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CHECKENGLISHNAME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal SortNo { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CMSCheck Unit = new CMSCheck();
            Unit.CMS_CHECK_ID = this.CMS_CHECK_ID;
            Unit.CHECK_TITLE = this.CHECK_TITLE;
            Unit.CMS_CODE = this.CMS_CODE;
            Unit.WORKORDER_ID = this.WORKORDER_ID;
            Unit.CHECK_DETAIL = this.CHECK_DETAIL;
            Unit.PLAN_DATE = this.PLAN_DATE;
            Unit.CHECK_STATE = this.CHECK_STATE;
            Unit.CHECK_DEPART = this.CHECK_DEPART;
            Unit.CHECK_PERSON = this.CHECK_PERSON;
            Unit.CHECK_DATE = this.CHECK_DATE;
            Unit.CHECK_LOG_ID = this.CHECK_LOG_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CHECKENGLISHNAME = this.CHECKENGLISHNAME;
            Unit.SortNo = this.SortNo;
            return Unit;
        }
        #endregion
 
        public CMSRectify CmsRectify { get; set; }
        public override string GetId()
        {
            return this.CMS_CHECK_ID;
        }

        public override string GetTypeName()
        {
            return "CMSCheck";
        }

        public override bool Update(out string err)
        {
            if (canUpdate(out err))
                return CMSCheckService.Instance.saveUnit(this, out err);
            else
            {
                return false;
            } 
        }

        public override bool Delete(out string err)
        {
            return CMSCheckService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if (CmsRectify == null || CmsRectify.IsWrong)
            {
                CmsRectify = CMSRectifyService.Instance.getObjectByCMSCheckId(CMS_CHECK_ID);
            }
        }
        public bool CanBandWorkInfo
        {
            get
            {
                CMSConfig oneConfig = CMSConfigService.Instance.GetConfigByShipAndCMSCode(SHIP_ID, CMS_CODE);
                return (oneConfig != null && !string.IsNullOrEmpty(oneConfig.WORKINFOID));
            }
        }
        /// <summary>
        /// 检验名称(中文)和code两个加起来必须唯一.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool canUpdate(out string err)
        {
            err = "当前检验名称及检验编号已经存在,不允许保存当前数据,请更改重复记录后再尝试保存";
            //当前表的检验编号不允许重复;
            return !CMSCheckService.Instance.CMSCheckTitleIsDuplicated(CHECK_TITLE, CHECK_LOG_ID, GetId())
                || !CMSCheckService.Instance.CMSCheckCodeIsDuplicated(CMS_CODE,CHECK_LOG_ID, GetId());
        }
    }
}
