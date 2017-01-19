/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportDeckMaintain.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/6
 * 标    题：实体类
 * 功能描述：T_REPORT_DECK_MAINTAIN数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CustomerTable.Haifeng.Services;

namespace CustomerTable.Haifeng.DataObject
{
	/// <summary>
	///T_REPORT_DECK_MAINTAIN数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportDeckMaintain : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public ReportDeckMaintain()
		{
		}
		///<summary>
		///
		///</summary>
		public ReportDeckMaintain
		(
			string rEPORT_ID,
			string fILE_ID,
			DateTime fILE_DATE,
			string sHIP_ID,
			string vOYAGE,
			DateTime rEPORT_DATE,
			DateTime bEGIN_DATE,
			DateTime eND_DATE,
			string aIR_LINE,
			string cHUAN_ZHANG,
			string dA_FU,
			string eR_FU,
			string sAN_FU,
			string sHUI_SHOU,
			string mU_JIANG,
			string cTJG,
			string cKB,
			string xZ_SHQ,
			string jB,
			string jBSB,
			string cG,
			string yST,
			string dBSC,
			string yZSC,
			string jBGX,
			string xF,
			string jS,
			string sMM_C,
			string tQG,
			string tFSB,
			string qT,
			string uNDONE_PROJECT,
			string pROBLEM,
			string tEMPORARY_PROJECT,
			string vERIFY_SUGGESTION
		)
		{
			this.REPORT_ID         = rEPORT_ID;
			this.FILE_ID           = fILE_ID;
			this.FILE_DATE         = fILE_DATE;
			this.SHIP_ID           = sHIP_ID;
			this.VOYAGE            = vOYAGE;
			this.REPORT_DATE       = rEPORT_DATE;
			this.BEGIN_DATE        = bEGIN_DATE;
			this.END_DATE          = eND_DATE;
			this.AIR_LINE          = aIR_LINE;
			this.CHUAN_ZHANG       = cHUAN_ZHANG;
			this.DA_FU             = dA_FU;
			this.ER_FU             = eR_FU;
			this.SAN_FU            = sAN_FU;
			this.SHUI_SHOU         = sHUI_SHOU;
			this.MU_JIANG          = mU_JIANG;
			this.CTJG              = cTJG;
			this.CKB               = cKB;
			this.XZ_SHQ            = xZ_SHQ;
			this.JB                = jB;
			this.JBSB              = jBSB;
			this.CG                = cG;
			this.YST               = yST;
			this.DBSC              = dBSC;
			this.YZSC              = yZSC;
			this.JBGX              = jBGX;
			this.XF                = xF;
			this.JS                = jS;
			this.SMM_C             = sMM_C;
			this.TQG               = tQG;
			this.TFSB              = tFSB;
			this.QT                = qT;
			this.UNDONE_PROJECT    = uNDONE_PROJECT;
			this.PROBLEM           = pROBLEM;
			this.TEMPORARY_PROJECT = tEMPORARY_PROJECT;
			this.VERIFY_SUGGESTION = vERIFY_SUGGESTION;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string REPORT_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public string FILE_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public DateTime FILE_DATE{get ;set;}

		///<summary>
		///船舶.
		///
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///航次.
		///
		///</summary>
		public string VOYAGE{get ;set;}

		///<summary>
		///日期.
		///
		///</summary>
		public DateTime REPORT_DATE{get ;set;}

		///<summary>
		///开始时间.
		///</summary>
		public DateTime BEGIN_DATE{get ;set;}

		///<summary>
		///结束时间.
		///</summary>
		public DateTime END_DATE{get ;set;}

		///<summary>
		///
		///</summary>
		public string AIR_LINE{get ;set;}

		///<summary>
		///船长.
		///</summary>
		public string CHUAN_ZHANG{get ;set;}

		///<summary>
		///大幅.
		///</summary>
		public string DA_FU{get ;set;}

		///<summary>
		///二副.
		///</summary>
		public string ER_FU{get ;set;}

		///<summary>
		///三幅.
		///</summary>
		public string SAN_FU{get ;set;}

		///<summary>
		///水手.
		///</summary>
		public string SHUI_SHOU{get ;set;}

		///<summary>
		///木匠.
		///</summary>
		public string MU_JIANG{get ;set;}

		///<summary>
		///船体结构（舱壁、底版等）.
		///
		///</summary>
		public string CTJG{get ;set;}

		///<summary>
		///船壳板.
		///</summary>
		public string CKB{get ;set;}

		///<summary>
		///舾装、生活区.
		///</summary>
		public string XZ_SHQ{get ;set;}

		///<summary>
		///甲板.
		///</summary>
		public string JB{get ;set;}

		///<summary>
		///甲板设施.
		///</summary>
		public string JBSB{get ;set;}

		///<summary>
		///舱盖.
		///
		///</summary>
		public string CG{get ;set;}

		///<summary>
		///引水梯.
		///
		///</summary>
		public string YST{get ;set;}

		///<summary>
		///顶边水舱.
		///
		///</summary>
		public string DBSC{get ;set;}

		///<summary>
		///压载水舱.
		///
		///</summary>
		public string YZSC{get ;set;}

		///<summary>
		///甲板管系.
		///
		///</summary>
		public string JBGX{get ;set;}

		///<summary>
		///消防.
		///
		///</summary>
		public string XF{get ;set;}

		///<summary>
		///救生.
		///
		///</summary>
		public string JS{get ;set;}

		///<summary>
		///水密门、窗.
		///
		///</summary>
		public string SMM_C{get ;set;}

		///<summary>
		///透气管.
		///</summary>
		public string TQG{get ;set;}

		///<summary>
		///通风设备.
		///
		///</summary>
		public string TFSB{get ;set;}

		///<summary>
		///其他.
		///
		///</summary>
		public string QT{get ;set;}

		///<summary>
		///维修保养工程，哪些未完成，何原因，预计何时完成？.
		///</summary>
		public string UNDONE_PROJECT{get ;set;}

		///<summary>
		///存在哪些问题需解决？有什么合理化建议及要求？.
		///
		///</summary>
		public string PROBLEM{get ;set;}

		///<summary>
		///临修的工程及原因，修理费及影响营运的时间多少？.
		///
		///</summary>
		public string TEMPORARY_PROJECT{get ;set;}

		///<summary>
		///机务主管审核意见：.
		///</summary>
		public string VERIFY_SUGGESTION{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportDeckMaintain Unit = new ReportDeckMaintain();
			Unit.REPORT_ID=this.REPORT_ID;
			Unit.FILE_ID=this.FILE_ID;
			Unit.FILE_DATE=this.FILE_DATE;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.VOYAGE=this.VOYAGE;
			Unit.REPORT_DATE=this.REPORT_DATE;
			Unit.BEGIN_DATE=this.BEGIN_DATE;
			Unit.END_DATE=this.END_DATE;
			Unit.AIR_LINE=this.AIR_LINE;
			Unit.CHUAN_ZHANG=this.CHUAN_ZHANG;
			Unit.DA_FU=this.DA_FU;
			Unit.ER_FU=this.ER_FU;
			Unit.SAN_FU=this.SAN_FU;
			Unit.SHUI_SHOU=this.SHUI_SHOU;
			Unit.MU_JIANG=this.MU_JIANG;
			Unit.CTJG=this.CTJG;
			Unit.CKB=this.CKB;
			Unit.XZ_SHQ=this.XZ_SHQ;
			Unit.JB=this.JB;
			Unit.JBSB=this.JBSB;
			Unit.CG=this.CG;
			Unit.YST=this.YST;
			Unit.DBSC=this.DBSC;
			Unit.YZSC=this.YZSC;
			Unit.JBGX=this.JBGX;
			Unit.XF=this.XF;
			Unit.JS=this.JS;
			Unit.SMM_C=this.SMM_C;
			Unit.TQG=this.TQG;
			Unit.TFSB=this.TFSB;
			Unit.QT=this.QT;
			Unit.UNDONE_PROJECT=this.UNDONE_PROJECT;
			Unit.PROBLEM=this.PROBLEM;
			Unit.TEMPORARY_PROJECT=this.TEMPORARY_PROJECT;
			Unit.VERIFY_SUGGESTION=this.VERIFY_SUGGESTION;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.REPORT_ID;
        }

        public override string GetTypeName()
        {
            return "ReportDeckMaintain";
        }

        public override bool Update(out string err)
        {
            return ReportDeckMaintainService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportDeckMaintainService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
