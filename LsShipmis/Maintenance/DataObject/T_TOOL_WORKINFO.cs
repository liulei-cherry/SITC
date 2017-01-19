/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_TOOL_WORKINFO.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/11/23
 * 标    题：实体类
 * 功能描述：T_TOOL_WORKINFO数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Maintenance.Services;

namespace Maintenance.DataObject
{
	/// <summary>
	///T_TOOL_WORKINFO数据实体.
	/// </summary>
	///[Serializable]
	public partial class T_TOOL_WORKINFO : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///工作信息暂存表.
		///</summary>
		public T_TOOL_WORKINFO()
		{
		}
		///<summary>
		///工作信息暂存表.
		///</summary>
		public T_TOOL_WORKINFO
		(
			string wORKINFOID,
			string rEFOBJID,
			decimal wORKINFOTYPE,
			string oRDERNUM_SHOW,
			string cLASS1,
			string cLASS2,
			string wORKINFONAME,
			string wORKINFODETAIL,
			decimal cIRCLEORTIMING,
			string cIRCLEORTIMING_INI,
			decimal cIRCLEPERIOD,
			string cIRCLEPERIOD_INI,
			string cIRCLEUNIT,
			decimal cIRCLEFRONTLIMIT,
			decimal cIRCLEBACKLIMIT,
			string cIRCLELIMITUNIT,
			decimal tIMINGPERIOD,
			decimal tIMINGFRONTLIMIT,
			decimal tIMINGBACKLIMIT,
			string pRINCIPALPOST,
			string pRINCIPALPOST_INI,
			string cONFIRMPOST,
			string cONFIRMPOST_INI,
			decimal iSCHECKPROJECT,
			string iSCHECKPROJECT_INI,
			decimal iSREPAIRPROJECT,
			string iSREPAIRPROJECT_INI,
			string sHIP_ID,
			string mONTHS_CHECK,
			decimal iSBAK,
			string eX1,
			string eX2,
			string eX3,
			string eX4,
			string eX5,
			int eXCEL_ORDERNUM,
			string iTEMTYPE,
			int dEPARTMENT_TYPE
		)
		{
			this.WORKINFOID          = wORKINFOID;
			this.REFOBJID            = rEFOBJID;
			this.WORKINFOTYPE        = wORKINFOTYPE;
			this.ORDERNUM_SHOW       = oRDERNUM_SHOW;
			this.CLASS1              = cLASS1;
			this.CLASS2              = cLASS2;
			this.WORKINFONAME        = wORKINFONAME;
			this.WORKINFODETAIL      = wORKINFODETAIL;
			this.CIRCLEORTIMING      = cIRCLEORTIMING;
			this.CIRCLEORTIMING_INI  = cIRCLEORTIMING_INI;
			this.CIRCLEPERIOD        = cIRCLEPERIOD;
			this.CIRCLEPERIOD_INI    = cIRCLEPERIOD_INI;
			this.CIRCLEUNIT          = cIRCLEUNIT;
			this.CIRCLEFRONTLIMIT    = cIRCLEFRONTLIMIT;
			this.CIRCLEBACKLIMIT     = cIRCLEBACKLIMIT;
			this.CIRCLELIMITUNIT     = cIRCLELIMITUNIT;
			this.TIMINGPERIOD        = tIMINGPERIOD;
			this.TIMINGFRONTLIMIT    = tIMINGFRONTLIMIT;
			this.TIMINGBACKLIMIT     = tIMINGBACKLIMIT;
			this.PRINCIPALPOST       = pRINCIPALPOST;
			this.PRINCIPALPOST_INI   = pRINCIPALPOST_INI;
			this.CONFIRMPOST         = cONFIRMPOST;
			this.CONFIRMPOST_INI     = cONFIRMPOST_INI;
			this.ISCHECKPROJECT      = iSCHECKPROJECT;
			this.ISCHECKPROJECT_INI  = iSCHECKPROJECT_INI;
			this.ISREPAIRPROJECT     = iSREPAIRPROJECT;
			this.ISREPAIRPROJECT_INI = iSREPAIRPROJECT_INI;
			this.SHIP_ID             = sHIP_ID;
			this.MONTHS_CHECK        = mONTHS_CHECK;
			this.ISBAK               = iSBAK;
			this.EX1                 = eX1;
			this.EX2                 = eX2;
			this.EX3                 = eX3;
			this.EX4                 = eX4;
			this.EX5                 = eX5;
			this.EXCEL_ORDERNUM      = eXCEL_ORDERNUM;
			this.ITEMTYPE            = iTEMTYPE;
			this.DEPARTMENT_TYPE     = dEPARTMENT_TYPE;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///工作信息id
		///</summary>
		public string WORKINFOID{get ;set;}

		///<summary>
		///关联对象Id
		///</summary>
		public string REFOBJID{get ;set;}

		///<summary>
		///信息类别（0无关联；1关联设备）.
		///</summary>
		public decimal WORKINFOTYPE{get ;set;}

		///<summary>
		///显示排序号.
		///</summary>
		public string ORDERNUM_SHOW{get ;set;}

		///<summary>
		///一级分类.
		///</summary>
		public string CLASS1{get ;set;}

		///<summary>
		///二级分类.
		///</summary>
		public string CLASS2{get ;set;}

		///<summary>
		///工作信息名称.
		///</summary>
		public string WORKINFONAME{get ;set;}

		///<summary>
		///工作信息内容.
		///</summary>
		public string WORKINFODETAIL{get ;set;}

		///<summary>
		///定期定时（1定期，2定时，3定期+定时,4,非周期）.
		///</summary>
		public decimal CIRCLEORTIMING{get ;set;}

		///<summary>
		///定期定时初始化项（1定期，2定时，3定期+定时,4,非周期）.
		///</summary>
		public string CIRCLEORTIMING_INI{get ;set;}

		///<summary>
		///定期周期.
		///</summary>
		public decimal CIRCLEPERIOD{get ;set;}

		///<summary>
		///定期周期初始化项.
		///</summary>
		public string CIRCLEPERIOD_INI{get ;set;}

		///<summary>
		///定期单位.
		///</summary>
		public string CIRCLEUNIT{get ;set;}

		///<summary>
		///定期前允差.
		///</summary>
		public decimal CIRCLEFRONTLIMIT{get ;set;}

		///<summary>
		///定期后允差.
		///</summary>
		public decimal CIRCLEBACKLIMIT{get ;set;}

		///<summary>
		///定期允差单位.
		///</summary>
		public string CIRCLELIMITUNIT{get ;set;}

		///<summary>
		///定时周期.
		///</summary>
		public decimal TIMINGPERIOD{get ;set;}

		///<summary>
		///定时前允差.
		///</summary>
		public decimal TIMINGFRONTLIMIT{get ;set;}

		///<summary>
		///定时后允差.
		///</summary>
		public decimal TIMINGBACKLIMIT{get ;set;}

		///<summary>
		///负责人岗位ID
		///</summary>
		public string PRINCIPALPOST{get ;set;}

		///<summary>
		///负责人岗位初始化项.
		///</summary>
		public string PRINCIPALPOST_INI{get ;set;}

		///<summary>
		///确认人岗位ID
		///</summary>
		public string CONFIRMPOST{get ;set;}

		///<summary>
		///确认人岗位初始化项.
		///</summary>
		public string CONFIRMPOST_INI{get ;set;}

		///<summary>
		///检验项目值（0表示否，1表示是）.
		///</summary>
		public decimal ISCHECKPROJECT{get ;set;}

		///<summary>
		///检验项目初始化项（0表示否，1表示是）.
		///</summary>
		public string ISCHECKPROJECT_INI{get ;set;}

		///<summary>
		///修理项目值（0表示否，1表示是）.
		///</summary>
		public decimal ISREPAIRPROJECT{get ;set;}

		///<summary>
		///修理项目初始化项（0表示否，1表示是）.
		///</summary>
		public string ISREPAIRPROJECT_INI{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///月保养勾选.
		///</summary>
		public string MONTHS_CHECK{get ;set;}

		///<summary>
		///是否是备份(0：不是;1：是)
		///</summary>
		public decimal ISBAK{get ;set;}

		///<summary>
		///扩展项1
		///</summary>
		public string EX1{get ;set;}

		///<summary>
		///扩展项2
		///</summary>
		public string EX2{get ;set;}

		///<summary>
		///扩展项3
		///</summary>
		public string EX3{get ;set;}

		///<summary>
		///扩展项4
		///</summary>
		public string EX4{get ;set;}

		///<summary>
		///扩展项5
		///</summary>
		public string EX5{get ;set;}

		///<summary>
		///在EXCEL中的排序号.
		///</summary>
		public int EXCEL_ORDERNUM{get ;set;}

		///<summary>
		///0:表格类型 1：工作信息类型.
		///</summary>
		public string ITEMTYPE{get ;set;}

		///<summary>
		///部门类型（1：甲板类型；2：轮机类型）.
		///</summary>
		public int DEPARTMENT_TYPE{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			T_TOOL_WORKINFO Unit = new T_TOOL_WORKINFO();
			Unit.WORKINFOID=this.WORKINFOID;
			Unit.REFOBJID=this.REFOBJID;
			Unit.WORKINFOTYPE=this.WORKINFOTYPE;
			Unit.ORDERNUM_SHOW=this.ORDERNUM_SHOW;
			Unit.CLASS1=this.CLASS1;
			Unit.CLASS2=this.CLASS2;
			Unit.WORKINFONAME=this.WORKINFONAME;
			Unit.WORKINFODETAIL=this.WORKINFODETAIL;
			Unit.CIRCLEORTIMING=this.CIRCLEORTIMING;
			Unit.CIRCLEORTIMING_INI=this.CIRCLEORTIMING_INI;
			Unit.CIRCLEPERIOD=this.CIRCLEPERIOD;
			Unit.CIRCLEPERIOD_INI=this.CIRCLEPERIOD_INI;
			Unit.CIRCLEUNIT=this.CIRCLEUNIT;
			Unit.CIRCLEFRONTLIMIT=this.CIRCLEFRONTLIMIT;
			Unit.CIRCLEBACKLIMIT=this.CIRCLEBACKLIMIT;
			Unit.CIRCLELIMITUNIT=this.CIRCLELIMITUNIT;
			Unit.TIMINGPERIOD=this.TIMINGPERIOD;
			Unit.TIMINGFRONTLIMIT=this.TIMINGFRONTLIMIT;
			Unit.TIMINGBACKLIMIT=this.TIMINGBACKLIMIT;
			Unit.PRINCIPALPOST=this.PRINCIPALPOST;
			Unit.PRINCIPALPOST_INI=this.PRINCIPALPOST_INI;
			Unit.CONFIRMPOST=this.CONFIRMPOST;
			Unit.CONFIRMPOST_INI=this.CONFIRMPOST_INI;
			Unit.ISCHECKPROJECT=this.ISCHECKPROJECT;
			Unit.ISCHECKPROJECT_INI=this.ISCHECKPROJECT_INI;
			Unit.ISREPAIRPROJECT=this.ISREPAIRPROJECT;
			Unit.ISREPAIRPROJECT_INI=this.ISREPAIRPROJECT_INI;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.MONTHS_CHECK=this.MONTHS_CHECK;
			Unit.ISBAK=this.ISBAK;
			Unit.EX1=this.EX1;
			Unit.EX2=this.EX2;
			Unit.EX3=this.EX3;
			Unit.EX4=this.EX4;
			Unit.EX5=this.EX5;
			Unit.EXCEL_ORDERNUM=this.EXCEL_ORDERNUM;
			Unit.ITEMTYPE=this.ITEMTYPE;
			Unit.DEPARTMENT_TYPE=this.DEPARTMENT_TYPE;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.WORKINFOID;
        }

        public override string GetTypeName()
        {
            return "T_TOOL_WORKINFO";
        }

        public override bool Update(out string err)
        {
            return T_TOOL_WORKINFOService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return T_TOOL_WORKINFOService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
