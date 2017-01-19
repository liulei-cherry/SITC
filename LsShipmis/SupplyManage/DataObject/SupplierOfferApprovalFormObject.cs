﻿using System;using System.Collections.Generic;using System.Text;using BLToolkit.Mapping;using BLToolkit.DataAccess;using BLToolkit.Validation;namespace SupplyManage.DataObject{	[TableName(Name = "T_SUPPLIER_OFFER_APPROVAL_FORM")]	public class SupplierOfferApprovalFormObject	{		#region POCO		///<summary>		///主键.		///</summary>		[PrimaryKey]		[Required]		public String ID{get;set;}		///<summary>		///船舶ID.		///</summary>		[Required]		public String SHIP_ID{get;set;}		///<summary>		///供货项目.		///</summary>		[Nullable(true)]		public String SUPPLY_ITEM{get;set;}		///<summary>		///港口基础表中的ID.		///</summary>		[Nullable(true)]		public String PORT_ID{get;set;}		///<summary>		///申请日期.		///</summary>		[Nullable(true)]		public DateTime APPLY_DATE{get;set;}		///<summary>		///供应日期.		///</summary>		[Nullable(true)]		public DateTime SUPPLY_DATE{get;set;}		///<summary>		///最终确定供应商ID.		///</summary>		[Nullable(true)]		public String SUPPLIER_ID{get;set;}		///<summary>		///最终确定供应商名称.		///</summary>		[Nullable(true)]		public String SUPPLIER_NAME{get;set;}		///<summary>		///申请主管.		///</summary>		[Nullable(true)]		public String SUPERVISOR{get;set;}		///<summary>		///供应理由.		///</summary>		[Nullable(true)]		public String SUPPLY_REASON{get;set;}		///<summary>		///机务经理.		///</summary>		[Nullable(true)]		public String MANAGER{get;set;}		///<summary>		///机务经理审核意见.		///</summary>		[Nullable(true)]		public String MANAGER_OPINION{get;set;}		///<summary>		///机务经理审核时间.		///</summary>		[Nullable(true)]		public DateTime MANAGER_DATE{get;set;}		///<summary>		///总经理.		///</summary>		[Nullable(true)]		public String GM{get;set;}		///<summary>		///总经理审核意见.		///</summary>		[Nullable(true)]		public String GM_OPINION{get;set;}		///<summary>		///总经理审核时间.		///</summary>		[Nullable(true)]		public DateTime GM_DATE{get;set;}		///<summary>		///备注.		///</summary>		[Nullable(true)]		public String REMARK{get;set;}		///<summary>		///0未提交 1待机务经理审批 2待总经理审批 3审批通过 4打回.		///</summary>		[Nullable(true)]		public String CHCKSTATUS{get;set;}		///<summary>		///审批单号S+SHIP_CODE+2位年份+2位月份+3位年度流水号.		///</summary>		[Nullable(true)]		public String FORM_CODE{get;set;}		#endregion	}}
