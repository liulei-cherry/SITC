/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_Checked.cs
 * 创 建 人：夏喜龙
 * 创建时间：2009-11-3
 * 标    题：实体类
 * 功能描述：T_Checked数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
    /// <summary>
    ///T_Checked数据实体.
    /// </summary>
    ///[Serializable]
    public class T_Checked
    {
        #region 变量定义
        ///<summary>
        ///审核Id
        ///</summary>
        private string _checked_Id;
        ///<summary>
        ///流程Id
        ///</summary>
        private string _workFlow_Id = String.Empty;
        ///<summary>
        ///当前流程Id
        ///</summary>
        private string _current_WorkFlow_Id = String.Empty;
        ///<summary>
        ///当前审批岗位Id
        ///</summary>
        private string _current_PostId = String.Empty;
        ///<summary>
        ///申请单状态（0表示申请，1表示审核中，2表示驳回，3表示结束）.
        ///</summary>
        private decimal _current_State;
        ///<summary>
        ///业务对象Id
        ///</summary>
        private string _business_Object_Id = String.Empty;
        ///<summary>
        ///船舶Id
        ///</summary>
        private string _ship_Id = String.Empty;
        #endregion

        #region 中间变量 业务名和业务主信息

        public string BusinessMainInfo
        {
            get;
            private set;
        }
        public string BusinessDetailInfo
        {
            get;
            private set;
        }

        #endregion

        #region 构造函数

        ///<summary>
        ///
        ///</summary>
        public T_Checked()
        {
            BusinessMainInfo = "未知业务对象";
            BusinessDetailInfo = "未知业务信息";
        }

        #endregion

        #region 公共属性
        ///<summary>
        ///审核Id
        ///</summary>
        public string Checked_Id
        {
            get { return _checked_Id; }
            set { _checked_Id = value; }
        }

        ///<summary>
        ///流程Id
        ///</summary>
        public string WorkFlow_Id
        {
            get { return _workFlow_Id; }
            set { _workFlow_Id = value; }
        }

        ///<summary>
        ///当前流程Id
        ///</summary>
        public string Current_WorkFlow_Id
        {
            get { return _current_WorkFlow_Id; }
            set { _current_WorkFlow_Id = value; }
        }

        ///<summary>
        ///当前审批岗位类型（不是岗位ID）.
        ///</summary>
        public string CurrentPostName
        {
            get { return _current_PostId; }
            set { _current_PostId = value; }
        }

        ///<summary>
        ///申请单状态（0表示申请，1表示审核中，2表示驳回(打回上一级），3表示结束, 4提交被打回（打回到头））
        ///</summary>
        public decimal Current_State
        {
            get { return _current_State; }
            set { _current_State = value; }
        }

        ///<summary>
        ///业务对象Id
        ///</summary>
        public string Business_Object_Id
        {
            get { return _business_Object_Id; }
            set { _business_Object_Id = value; }
        }

        ///<summary>
        ///船舶Id
        ///</summary>
        public string Ship_Id
        {
            get { return _ship_Id; }
            set { _ship_Id = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public T_Checked Clone()
        {
            T_Checked Unit = new T_Checked();
            Unit.Checked_Id = this.Checked_Id;
            Unit.WorkFlow_Id = this.WorkFlow_Id;
            Unit.Current_WorkFlow_Id = this.Current_WorkFlow_Id;
            Unit.CurrentPostName = this.CurrentPostName;
            Unit.Current_State = this.Current_State;
            Unit.Business_Object_Id = this.Business_Object_Id;
            Unit.Ship_Id = this.Ship_Id;
            return Unit;
        }
        #endregion

        internal void FillBusinessInfo(string businessMainInfo, string businessDetailInfo)
        {
            BusinessMainInfo = businessMainInfo;
            BusinessDetailInfo = businessDetailInfo;
        }
    }
}
