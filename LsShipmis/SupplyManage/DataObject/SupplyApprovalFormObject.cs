﻿using System;using System.Collections.Generic;using System.Text;using BLToolkit.Mapping;using BLToolkit.DataAccess;using BLToolkit.Validation;namespace SupplyManage.DataObject{	[TableName(Name = "T_SUPPLY_APPROVAL_FORM")]	public class SupplyApprovalFormObject	{		#region POCO		///<summary>		///主键.		///</summary>		[PrimaryKey]		[Required]		public String ID{get;set;}		///<summary>		///船舶ID.		///</summary>		[Required]		public String SHIP_ID{get;set;}		///<summary>		///供货项目.		///</summary>		[Nullable(true)]		public String SUPPLY_ITEM{get;set;}		///<summary>		///1年度；2季度；3临时.		///</summary>		[Nullable(true)]		public String SUPPLY_CYCLE{get;set;}		///<summary>		///申请日期.		///</summary>		[Nullable(true)]		public DateTime APPLY_DATE{get;set;}		///<summary>		///拟供货日期.		///</summary>		[Nullable(true)]		public DateTime PLAN_SUPPLY_DATE{get;set;}		///<summary>		///供应商基本信息表中的供应商ID.		///</summary>		[Nullable(true)]		public String SUPPLIER_ID{get;set;}		///<summary>		///供应商名称.		///</summary>		[Required]		public String SUPPLIER_NAME{get;set;}		///<summary>		///供货地点.		///</summary>		[Nullable(true)]		public String SUPPLY_ADDRESS{get;set;}		///<summary>		///采购金额.		///</summary>		[Nullable(true)]		public String PURCHASE_AMOUNT{get;set;}		///<summary>		///采购币种.		///</summary>		[Nullable(true)]		public String CURRENCY_ID{get;set;}		///<summary>		///上次供应是否是本供应商 0否 1是.		///</summary>		[Nullable(true)]		public String IS_LASTSUPPLY{get;set;}		///<summary>		///供应商更换原因.		///</summary>		[Nullable(true)]		public String CHANGE_REASON{get;set;}		///<summary>		///机务主管审批意见.		///</summary>		[Nullable(true)]		public String SUPERVISOR_OPINION{get;set;}		///<summary>		///机务主管签名.		///</summary>		[Nullable(true)]		public String SUPERVISOR{get;set;}		///<summary>		///机务主管审批时间.		///</summary>		[Nullable(true)]		public DateTime SUPERVISOR_DATE{get;set;}		///<summary>		///机务经理审批意见.		///</summary>		[Nullable(true)]		public String MANAGER_OPINION{get;set;}		///<summary>		///机务经理签名.		///</summary>		[Nullable(true)]		public String MANAGER{get;set;}		///<summary>		///机务经理审批时间.		///</summary>		[Nullable(true)]		public DateTime MANAGER_DATE{get;set;}		///<summary>		///总经理审批意见.		///</summary>		[Nullable(true)]		public String GM_OPINION{get;set;}		///<summary>		///总经理签字.		///</summary>		[Nullable(true)]		public String GM{get;set;}		///<summary>		///总经理审批时间.		///</summary>		[Nullable(true)]		public DateTime GM_DATE{get;set;}		///<summary>		///备注.		///</summary>		[Nullable(true)]		public String REMARK{get;set;}		///<summary>		///0未提交 1待机务经理审批 2待总经理审批 3审批通过 4打回.		///</summary>		[Nullable(true)]		public String CHCKSTATUS{get;set;}		///<summary>		///审批单号S+SHIP_CODE+2位年份+2位月份+3位年度流水号.		///</summary>		[Nullable(true)]		public String FORM_CODE{get;set;}		#endregion	}}
