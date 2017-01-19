/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipInfo.cs
 * 创 建 人：xuzb
 * 创建时间：2009-10-22
 * 标    题：实体类
 * 功能描述：T_SHIP数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace BaseInfo.Objects
{
    /// <summary>
    ///T_SHIP数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipInfo : CommonClass
    {

        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public ShipInfo()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipInfo
        (
            string sHIP_ID,
            string sHIP_NAME,
            string sHIP_EN_NAME,
            string sHIP_CODE,
            string sHIP_HH,
            string iMO,
            string mMSI,
            string cBDJH,
            string cQG,
            string cJG,
            string hQ,
            string cBSYR,
            string sHIP_TYPE,
            decimal xK,
            decimal xS,
            decimal zC,
            decimal lZJC,
            decimal qZCS,
            decimal sJCS,
            decimal qZPSL,
            decimal mZPSL,
            decimal zD,
            decimal jD,
            decimal zZD,
            decimal sYSZD,
            decimal bNMZD,
            decimal hS,
            decimal zDPY,
            string zJXH,
            decimal zJTS,
            decimal zJGL,
            decimal zJZS,
            string zJJZC,
            DateTime zJCZRQ,
            string fDJYDJXH,
            decimal fDJYDJTS,
            decimal fDJYDJGL,
            decimal fDJYDJZS,
            string fDJXH,
            decimal fDJTS,
            decimal zYCL,
            decimal qYCL,
            decimal dSCL,
            DateTime yYKSRQ,
            DateTime yYJSRQ,
            string cBZZC,
            DateTime zZRQ,
            decimal zDHS,
            string cD,
            decimal cW,
            decimal zJGJ,
            decimal zJXC,
            decimal zJYH,
            string zJSBZK,
            decimal fJKYSL,
            string rYXH1,
            string rYXH2,
            string hYXH,
            decimal hYCR,
            string pICTURE,
            decimal xHHL,
            decimal xHTS,
            decimal xZTL,
            decimal tLZJ,
            decimal tLJTS,
            decimal zDJ,
            decimal jSTSL,
            decimal jZTSL,
            decimal fDJGL,
            decimal mAINENGINE_EXAUST_M,
            decimal aUXILIARY_EXAUST_M,
            decimal aUXILIARY_EXAUST_G,
            int mainEngine_TowNum,
            int mainEngine_MaxSpeedNum,
            int mainEngine_EcoSpeedNum,
            int mainEngine_CruiseNum,
            string cjfh,
            string remark,
            string sSFGS
        )
        {
            this.SHIP_ID = sHIP_ID;
            this.SHIP_NAME = sHIP_NAME;
            this.SHIP_EN_NAME = sHIP_EN_NAME;
            this.SHIP_CODE = sHIP_CODE;
            this.SHIP_HH = sHIP_HH;
            this.IMO = iMO;
            this.MMSI = mMSI;
            this.CBDJH = cBDJH;
            this.CQG = cQG;
            this.CJG = cJG;
            this.HQ = hQ;
            this.CBSYR = cBSYR;
            this.SHIP_TYPE = sHIP_TYPE;
            this.XK = xK;
            this.XS = xS;
            this.ZC = zC;
            this.LZJC = lZJC;
            this.QZCS = qZCS;
            this.SJCS = sJCS;
            this.QZPSL = qZPSL;
            this.MZPSL = mZPSL;
            this.ZD = zD;
            this.JD = jD;
            this.ZZD = zZD;
            this.SYSZD = sYSZD;
            this.BNMZD = bNMZD;
            this.HS = hS;
            this.ZDPY = zDPY;
            this.ZJXH = zJXH;
            this.ZJTS = zJTS;
            this.ZJGL = zJGL;
            this.ZJZS = zJZS;
            this.ZJJZC = zJJZC;
            this.ZJCZRQ = zJCZRQ;
            this.FDJYDJXH = fDJYDJXH;
            this.FDJYDJTS = fDJYDJTS;
            this.FDJYDJGL = fDJYDJGL;
            this.FDJYDJZS = fDJYDJZS;
            this.FDJXH = fDJXH;
            this.FDJTS = fDJTS;
            this.ZYCL = zYCL;
            this.QYCL = qYCL;
            this.DSCL = dSCL;
            this.YYKSRQ = yYKSRQ;
            this.YYJSRQ = yYJSRQ;
            this.CBZZC = cBZZC;
            this.ZZRQ = zZRQ;
            this.ZDHS = zDHS;
            this.CD = cD;
            this.CW = cW;
            this.ZJGJ = zJGJ;
            this.ZJXC = zJXC;
            this.ZJYH = zJYH;
            this.ZJSBZK = zJSBZK;
            this.FJKYSL = fJKYSL;
            this.RYXH1 = rYXH1;
            this.RYXH2 = rYXH2;
            this.HYXH = hYXH;
            this.HYCR = hYCR;
            this.PICTURE = pICTURE;
            this.XHHL = xHHL;
            this.XHTS = xHTS;
            this.XZTL = xZTL;
            this.TLZJ = tLZJ;
            this.TLJTS = tLJTS;
            this.ZDJ = zDJ;
            this.JSTSL = jSTSL;
            this.JZTSL = jZTSL;
            this.FDJGL = fDJGL;
            this.MAINENGINE_EXAUST_M = mAINENGINE_EXAUST_M;
            this.AUXILIARY_EXAUST_M = aUXILIARY_EXAUST_M;
            this.AUXILIARY_EXAUST_G = aUXILIARY_EXAUST_G;
            this.mainEngine_TowNum = mainEngine_TowNum;
            this.mainEngine_MaxSpeedNum = mainEngine_MaxSpeedNum;
            this.mainEngine_EcoSpeedNum = mainEngine_EcoSpeedNum;
            this.mainEngine_CruiseNum = mainEngine_CruiseNum;
            this.CJFH = cjfh;
            this.REMARK = remark;
            this.SSFGS = sSFGS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键.
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///船舶中文名称.
        ///</summary>
        public string SHIP_NAME { get; set; }

        ///<summary>
        ///船舶英文名称.
        ///</summary>
        public string SHIP_EN_NAME { get; set; }

        ///<summary>
        ///船舶编号.
        ///</summary>
        public string SHIP_CODE { get; set; }

        ///<summary>
        ///船舶呼号.
        ///</summary>
        public string SHIP_HH { get; set; }

        ///<summary>
        ///IMO
        ///</summary>
        public string IMO { get; set; }

        ///<summary>
        ///MMSI
        ///</summary>
        public string MMSI { get; set; }

        ///<summary>
        ///船舶登记号.
        ///</summary>
        public string CBDJH { get; set; }

        ///<summary>
        ///船旗国.
        ///</summary>
        public string CQG { get; set; }

        ///<summary>
        ///船籍港.
        ///</summary>
        public string CJG { get; set; }

        ///<summary>
        ///航区.
        ///</summary>
        public string HQ { get; set; }

        ///<summary>
        ///船舶所有人.
        ///</summary>
        public string CBSYR { get; set; }

        ///<summary>
        ///船舶类型.
        ///</summary>
        public string SHIP_TYPE { get; set; }

        ///<summary>
        ///型宽(m)
        ///</summary>
        public decimal XK { get; set; }

        ///<summary>
        ///型深(m)
        ///</summary>
        public decimal XS { get; set; }

        ///<summary>
        ///总长(m)
        ///</summary>
        public decimal ZC { get; set; }

        ///<summary>
        ///垂线间长.
        ///</summary>
        public decimal LZJC { get; set; }

        ///<summary>
        ///轻载吃水.
        ///</summary>
        public decimal QZCS { get; set; }

        ///<summary>
        ///设计吃水.
        ///</summary>
        public decimal SJCS { get; set; }

        ///<summary>
        ///轻载排水量(t)
        ///</summary>
        public decimal QZPSL { get; set; }

        ///<summary>
        ///满载排水量(t)
        ///</summary>
        public decimal MZPSL { get; set; }

        ///<summary>
        ///总吨(Gt)
        ///</summary>
        public decimal ZD { get; set; }

        ///<summary>
        ///净吨(Nt)
        ///</summary>
        public decimal JD { get; set; }

        ///<summary>
        ///载重吨.
        ///</summary>
        public decimal ZZD { get; set; }

        ///<summary>
        ///苏伊士运河吨.
        ///</summary>
        public decimal SYSZD { get; set; }

        ///<summary>
        ///巴拿马运河吨.
        ///</summary>
        public decimal BNMZD { get; set; }

        ///<summary>
        ///航速(Kn)
        ///</summary>
        public decimal HS { get; set; }

        ///<summary>
        ///最低配员.
        ///</summary>
        public decimal ZDPY { get; set; }

        ///<summary>
        ///主机型号.
        ///</summary>
        public string ZJXH { get; set; }

        ///<summary>
        ///主机台数.
        ///</summary>
        public decimal ZJTS { get; set; }

        ///<summary>
        ///主机功率.
        ///</summary>
        public decimal ZJGL { get; set; }

        ///<summary>
        ///主机转速.
        ///</summary>
        public decimal ZJZS { get; set; }

        ///<summary>
        ///主机建造厂商.
        ///</summary>
        public string ZJJZC { get; set; }

        ///<summary>
        ///主机出厂日期.
        ///</summary>
        public DateTime ZJCZRQ { get; set; }

        ///<summary>
        ///发电机原动机型号.
        ///</summary>
        public string FDJYDJXH { get; set; }

        ///<summary>
        ///发电机原动机台数.
        ///</summary>
        public decimal FDJYDJTS { get; set; }

        ///<summary>
        ///发电机原动机功率(Kw)
        ///</summary>
        public decimal FDJYDJGL { get; set; }

        ///<summary>
        ///发动机原动机转速(rpm)
        ///</summary>
        public decimal FDJYDJZS { get; set; }

        ///<summary>
        ///发电机型号.
        ///</summary>
        public string FDJXH { get; set; }

        ///<summary>
        ///发电机台数.
        ///</summary>
        public decimal FDJTS { get; set; }

        ///<summary>
        ///重油储量(m3)
        ///</summary>
        public decimal ZYCL { get; set; }

        ///<summary>
        ///轻油储量(m3)
        ///</summary>
        public decimal QYCL { get; set; }

        ///<summary>
        ///淡水储量(m3)
        ///</summary>
        public decimal DSCL { get; set; }

        ///<summary>
        ///运营开始日期.
        ///</summary>
        public DateTime YYKSRQ { get; set; }

        ///<summary>
        ///运营结束日期.
        ///</summary>
        public DateTime YYJSRQ { get; set; }

        ///<summary>
        ///船舶制造厂.
        ///</summary>
        public string CBZZC { get; set; }

        ///<summary>
        ///制造日期.
        ///</summary>
        public DateTime ZZRQ { get; set; }

        ///<summary>
        ///最大航速.
        ///</summary>
        public decimal ZDHS { get; set; }

        ///<summary>
        ///船队.
        ///</summary>
        public string CD { get; set; }

        ///<summary>
        ///床位.
        ///</summary>
        public decimal CW { get; set; }

        ///<summary>
        ///主机缸径.
        ///</summary>
        public decimal ZJGJ { get; set; }

        ///<summary>
        ///主机行程.
        ///</summary>
        public decimal ZJXC { get; set; }

        ///<summary>
        ///主机油耗.
        ///</summary>
        public decimal ZJYH { get; set; }

        ///<summary>
        ///主机设备状况.
        ///</summary>
        public string ZJSBZK { get; set; }

        ///<summary>
        ///副机可用数量.
        ///</summary>
        public decimal FJKYSL { get; set; }

        ///<summary>
        ///燃油型号1
        ///</summary>
        public string RYXH1 { get; set; }

        ///<summary>
        ///燃油型号2
        ///</summary>
        public string RYXH2 { get; set; }

        ///<summary>
        ///滑油型号.
        ///</summary>
        public string HYXH { get; set; }

        ///<summary>
        ///滑油仓容.
        ///</summary>
        public decimal HYCR { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PICTURE { get; set; }

        ///<summary>
        ///续航海里.
        ///</summary>
        public decimal XHHL { get; set; }

        ///<summary>
        ///续航天数.
        ///</summary>
        public decimal XHTS { get; set; }

        ///<summary>
        ///系柱拖力.
        ///</summary>
        public decimal XZTL { get; set; }

        ///<summary>
        ///拖缆直径.
        ///</summary>
        public decimal TLZJ { get; set; }

        ///<summary>
        ///拖缆机台数.
        ///</summary>
        public decimal TLJTS { get; set; }

        ///<summary>
        ///制淡机.
        ///</summary>
        public decimal ZDJ { get; set; }

        ///<summary>
        ///救生艇数量.
        ///</summary>
        public decimal JSTSL { get; set; }

        ///<summary>
        ///救助艇数量.
        ///</summary>
        public decimal JZTSL { get; set; }

        ///<summary>
        ///发电机功率.
        ///</summary>
        public decimal FDJGL { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal MAINENGINE_EXAUST_M { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal AUXILIARY_EXAUST_M { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal AUXILIARY_EXAUST_G { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int mainEngine_TowNum { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int mainEngine_MaxSpeedNum { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int mainEngine_EcoSpeedNum { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int mainEngine_CruiseNum { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CJFH { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SSFGS { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ShipInfo Unit = new ShipInfo();
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.SHIP_NAME = this.SHIP_NAME;
            Unit.SHIP_EN_NAME = this.SHIP_EN_NAME;
            Unit.SHIP_CODE = this.SHIP_CODE;
            Unit.SHIP_HH = this.SHIP_HH;
            Unit.IMO = this.IMO;
            Unit.MMSI = this.MMSI;
            Unit.CBDJH = this.CBDJH;
            Unit.CQG = this.CQG;
            Unit.CJG = this.CJG;
            Unit.HQ = this.HQ;
            Unit.CBSYR = this.CBSYR;
            Unit.SHIP_TYPE = this.SHIP_TYPE;
            Unit.XK = this.XK;
            Unit.XS = this.XS;
            Unit.ZC = this.ZC;
            Unit.LZJC = this.LZJC;
            Unit.QZCS = this.QZCS;
            Unit.SJCS = this.SJCS;
            Unit.QZPSL = this.QZPSL;
            Unit.MZPSL = this.MZPSL;
            Unit.ZD = this.ZD;
            Unit.JD = this.JD;
            Unit.ZZD = this.ZZD;
            Unit.SYSZD = this.SYSZD;
            Unit.BNMZD = this.BNMZD;
            Unit.HS = this.HS;
            Unit.ZDPY = this.ZDPY;
            Unit.ZJXH = this.ZJXH;
            Unit.ZJTS = this.ZJTS;
            Unit.ZJGL = this.ZJGL;
            Unit.ZJZS = this.ZJZS;
            Unit.ZJJZC = this.ZJJZC;
            Unit.ZJCZRQ = this.ZJCZRQ;
            Unit.FDJYDJXH = this.FDJYDJXH;
            Unit.FDJYDJTS = this.FDJYDJTS;
            Unit.FDJYDJGL = this.FDJYDJGL;
            Unit.FDJYDJZS = this.FDJYDJZS;
            Unit.FDJXH = this.FDJXH;
            Unit.FDJTS = this.FDJTS;
            Unit.ZYCL = this.ZYCL;
            Unit.QYCL = this.QYCL;
            Unit.DSCL = this.DSCL;
            Unit.YYKSRQ = this.YYKSRQ;
            Unit.YYJSRQ = this.YYJSRQ;
            Unit.CBZZC = this.CBZZC;
            Unit.ZZRQ = this.ZZRQ;
            Unit.ZDHS = this.ZDHS;
            Unit.CD = this.CD;
            Unit.CW = this.CW;
            Unit.ZJGJ = this.ZJGJ;
            Unit.ZJXC = this.ZJXC;
            Unit.ZJYH = this.ZJYH;
            Unit.ZJSBZK = this.ZJSBZK;
            Unit.FJKYSL = this.FJKYSL;
            Unit.RYXH1 = this.RYXH1;
            Unit.RYXH2 = this.RYXH2;
            Unit.HYXH = this.HYXH;
            Unit.HYCR = this.HYCR;
            Unit.PICTURE = this.PICTURE;
            Unit.XHHL = this.XHHL;
            Unit.XHTS = this.XHTS;
            Unit.XZTL = this.XZTL;
            Unit.TLZJ = this.TLZJ;
            Unit.TLJTS = this.TLJTS;
            Unit.ZDJ = this.ZDJ;
            Unit.JSTSL = this.JSTSL;
            Unit.JZTSL = this.JZTSL;
            Unit.FDJGL = this.FDJGL;
            Unit.MAINENGINE_EXAUST_M = this.MAINENGINE_EXAUST_M;
            Unit.AUXILIARY_EXAUST_M = this.AUXILIARY_EXAUST_M;
            Unit.AUXILIARY_EXAUST_G = this.AUXILIARY_EXAUST_G;
            Unit.mainEngine_TowNum = this.mainEngine_TowNum;
            Unit.mainEngine_MaxSpeedNum = this.mainEngine_MaxSpeedNum;
            Unit.mainEngine_EcoSpeedNum = this.mainEngine_EcoSpeedNum;
            Unit.mainEngine_CruiseNum = this.mainEngine_CruiseNum;
            Unit.CJFH = this.CJFH;
            Unit.REMARK = this.REMARK;
            Unit.SSFGS = this.SSFGS;
            return Unit;
        }
        #endregion
		
    }
}
