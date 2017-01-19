/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：t_chart_ship.cs
 * 创 建 人：盛文
 * 创建时间：2009-8-27
 * 标    题：实体类
 * 功能描述：t_chart_ship数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///t_chart_ship数据实体.
	/// </summary>
	///[Serializable]
	public class t_chart_ship
	{
		#region 变量定义
		///<summary>
		///海图信息与船舶对应表.
		///</summary>
		private string _chart_shipid;
		///<summary>
		///海图信息id
		///</summary>
		private string _chartid = String.Empty;
		///<summary>
		///对应船舶id
		///</summary>
		private string _ship_id = String.Empty;
		///<summary>
		///
		///</summary>
		private string _portid = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public t_chart_ship()
		{
		}
		///<summary>
		///
		///</summary>
		public t_chart_ship
		(
			string chart_shipid,
			string chartid,
			string ship_id,
			string portid
		)
		{
			_chart_shipid = chart_shipid;
			_chartid      = chartid;
			_ship_id      = ship_id;
			_portid       = portid;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///海图信息与船舶对应表.
		///</summary>
		public string chart_shipid
		{
			get {return _chart_shipid;}
			set {_chart_shipid = value;}
		}

		///<summary>
		///海图信息id
		///</summary>
		public string chartid
		{
			get {return _chartid;}
			set {_chartid = value;}
		}

		///<summary>
		///对应船舶id
		///</summary>
		public string ship_id
		{
			get {return _ship_id;}
			set {_ship_id = value;}
		}

		///<summary>
		///
		///</summary>
		public string portid
		{
			get {return _portid;}
			set {_portid = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public t_chart_ship Clone()
		{
			t_chart_ship Unit = new t_chart_ship();
			Unit.chart_shipid=this.chart_shipid;
			Unit.chartid=this.chartid;
			Unit.ship_id=this.ship_id;
			Unit.portid=this.portid;
          return Unit;
		}
		#endregion
		
	}
}
