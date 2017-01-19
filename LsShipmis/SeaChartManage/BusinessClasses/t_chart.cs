/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：t_chart.cs
 * 创 建 人：盛文
 * 创建时间：2009-8-26
 * 标    题：实体类
 * 功能描述：t_chart数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///t_chart数据实体.
	/// </summary>
	///[Serializable]
	public class t_chart
	{
		#region 变量定义
		///<summary>
		///海图信息汇总表.
		///</summary>
		private string _chartid;
		///<summary>
		///海图号.
		///</summary>
		private string _chartnum = String.Empty;
		///<summary>
		///海图名.
		///</summary>
		private string _chartname = String.Empty;
		///<summary>
		///海图英文名.
		///</summary>
		private string _chartenglishname = String.Empty;
		///<summary>
		///比例尺1：.
		///</summary>
		private string _chartrule = String.Empty;
		///<summary>
		///纸质图.
		///</summary>
		private string _paperchart = String.Empty;
		///<summary>
		///改版日期.
		///</summary>
		private string _changedate = String.Empty;
		///<summary>
		///图积.
		///</summary>
		private string _chartformat = String.Empty;
		///<summary>
		///航告期数.
		///</summary>
		private string _sailtellnum = String.Empty;
		///<summary>
		///备注.
		///</summary>
		private string _remark = String.Empty;
        ///<summary>
        ///发布部门.
        ///</summary>
        private string _publishdept = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public t_chart()
		{
		}
		///<summary>
		///
		///</summary>
		public t_chart
		(
			string chartid,
			string chartnum,
			string chartname,
			string chartenglishname,
			string chartrule,
			string paperchart,
			string changedate,
			string chartformat,
			string sailtellnum,
            string remark,
            string publishdept
		)
		{
			_chartid          = chartid;
			_chartnum         = chartnum;
			_chartname        = chartname;
			_chartenglishname = chartenglishname;
			_chartrule        = chartrule;
			_paperchart       = paperchart;
			_changedate       = changedate;
			_chartformat      = chartformat;
			_sailtellnum      = sailtellnum;
            _remark = remark;
            _publishdept = publishdept;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///海图信息汇总表.
		///</summary>
		public string chartid
		{
			get {return _chartid;}
			set {_chartid = value;}
		}

		///<summary>
		///海图号.
		///</summary>
		public string chartnum
		{
			get {return _chartnum;}
			set {_chartnum = value;}
		}

		///<summary>
		///海图名.
		///</summary>
		public string chartname
		{
			get {return _chartname;}
			set {_chartname = value;}
		}

		///<summary>
		///海图英文名.
		///</summary>
		public string chartenglishname
		{
			get {return _chartenglishname;}
			set {_chartenglishname = value;}
		}

		///<summary>
		///比例尺1：.
		///</summary>
		public string chartrule
		{
			get {return _chartrule;}
			set {_chartrule = value;}
		}

		///<summary>
		///纸质图.
		///</summary>
		public string paperchart
		{
			get {return _paperchart;}
			set {_paperchart = value;}
		}

		///<summary>
		///改版日期.
		///</summary>
		public string changedate
		{
			get {return _changedate;}
			set {_changedate = value;}
		}

		///<summary>
		///图积.
		///</summary>
		public string chartformat
		{
			get {return _chartformat;}
			set {_chartformat = value;}
		}

		///<summary>
		///航告期数.
		///</summary>
		public string sailtellnum
		{
			get {return _sailtellnum;}
			set {_sailtellnum = value;}
		}

		///<summary>
		///备注.
		///</summary>
		public string remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
        ///<summary>
        ///发布部门.
        ///</summary>
        public string publishdept
        {
            get { return _publishdept; }
            set { _publishdept = value; }
        }
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public t_chart Clone()
		{
			t_chart Unit = new t_chart();
			Unit.chartid=this.chartid;
			Unit.chartnum=this.chartnum;
			Unit.chartname=this.chartname;
			Unit.chartenglishname=this.chartenglishname;
			Unit.chartrule=this.chartrule;
			Unit.paperchart=this.paperchart;
			Unit.changedate=this.changedate;
			Unit.chartformat=this.chartformat;
			Unit.sailtellnum=this.sailtellnum;
            Unit.remark = this.remark;
            Unit.publishdept = this.publishdept;
          return Unit;
		}
		#endregion
		
	}
}
