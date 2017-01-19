using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Enum
{
    public enum Operation { Add, Edit, View }

    /// <summary>
    /// 编号是6000以上的是体系文件类型，6000以下是业务文件类型。.
    /// 步骤1：增加类型；.
    /// 步骤2：在EnumConfig()中初始化；.
    /// 步骤3：在FolderDbService.InitFolders() 中sql语句初始化；.
    /// 步骤4：在船舶管理中点击【船舶重新初始化】，实现真正设置。.
    /// </summary>
    public enum FileBoundingTypes
    {
        NULL = -1,
        COMMONFILESROOT = 0,//文档库根结点.
        SHIPINFO = 1,//船舶.
        SHIPCERTIFILES = 2,//证书资料.
        SPEARINFO = 3,//备件管理.
        WORKINFOFILES = 4,//工单管理.
        PROJECTMANAGE = 5,//修船管理.
        PROJECTORIGINAL = 6,//工程原始文档.
        PROJECTCONTRACT = 7,//合同相关文档.
        PROJECTFINISH = 8,//完工相关文档.
        ITEMSMANAGE = 9,//物资管理.
        BASESHIPCERT = 11,//标准船舶证书.
        SHIPCERTREGISTER = 12,//船舶证书登记.
        SHIPCERTCHECK = 13,//船舶证书检验.
        SHIPMAN = 14,//	船员管理.

        SPEARORDER = 31,//备件订单
        SPEARAPPLY = 36,//备件申请.
        SPEARIN = 32,//备件入库.
        SPEAROUT = 33,//备件出库.
        SPEARCOUNT = 34,//备件盘点.
        SPEARSTOCK = 35,//备件库存.

        MAINTENANCE = 40,
        DECKWORKMONTHPLAN = 41,
        MACHINEWORKMONTHPLAN = 42,
        DECKWORKMONTHFINISH = 43,
        MACHINEWORKMONTHFINISH = 44,
        DECKWORKYEARPLAN = 45,
        MACHINEWORKYEARPLAN = 46,

        ITEMSAPPLY = 96,//	物资申请.
        ITEMSORDER = 91,//	物资订单.
        ITEMSIN = 92,//	物资入库.
        ITEMSOUT = 93,//物资出库.
        ITEMSCOUNT = 94,//物资盘点.
        ITEMSSTOCK = 95,//物资库存.

        OILMANAGE = 100,//油料管理.
        OILAPPLY = 101,//油料申请.
        OILSTOCK = 102,//油料库存.

        COSTMANAGE = 200,        // 费用管理.
        VOUCHERFILES = 201,        // 单日凭证文件.

        DESIGNCOMPLATE = 1001,//完工图.
        DESIGNOPINION = 1002,//退审图及意见.
        CERTIFICATESCAN = 1003,//证书扫描件.

        COMPONYFILES = 4000,//	公司文件.
        COMPONENTFILES = 4001,//设备类别资料.
        COMPONENTOPERATION = 4002,//设备操作说明文件.
        COMPONENTSYSTEMFILES = 4003,//设备系统资料文件.
        COMMONDIR = 4101,//一般文件夹.
        MEASUREREPORT = 4102,//工作报告.

        ISMFILESROOT = 5000,//ISM文档管理.
        COMPONYISMFILESROOT = 5001,//公司ISM文档.
        ISMMODELS = 5002,//ISM报告模板.
        MEASUREREPORTMODEL = 5003,//工作报告模板.
        OTHERREPORTMODEL = 5005,//其它体系文件.

        SHIPISMFILES = 6001,//船舶体系文档.

    }

    public class EnumConfig
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static EnumConfig instance = new EnumConfig();
        public static EnumConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    EnumConfig.instance = new EnumConfig();
                }
                return EnumConfig.instance;
            }
        }
        #endregion

        private Dictionary<FileBoundingTypes, string> fileBoundingTypesDetail = new Dictionary<FileBoundingTypes, string>();

        public Dictionary<FileBoundingTypes, string> FileBoundingTypesDetail
        {
            get { return fileBoundingTypesDetail; }
            set { fileBoundingTypesDetail = value; }
        }
        public EnumConfig()
        {
            #region FileBoundingTypes初始化展示描述

            if (fileBoundingTypesDetail.Count == 0)
            {
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMMONFILESROOT, "文档库根结点File Base Root");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPINFO, "船舶资料Ship Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPCERTIFILES, "证书资料Ship Certificate Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARINFO, "备件管理Spare Management Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.WORKINFOFILES, "工单管理Work Info Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.PROJECTMANAGE, "修理工程管理Ship Repair Management Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.PROJECTORIGINAL, "工程原始文档Ship Project Apply Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.PROJECTCONTRACT, "合同相关文档Ship Project Contract");
                fileBoundingTypesDetail.Add(FileBoundingTypes.PROJECTFINISH, "完工相关文档Ship Project Complete Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSMANAGE, "物资管理Material Management Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.BASESHIPCERT, "标准船舶证书Ship Certificate Basic Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPCERTREGISTER, "船舶证书登记Ship Certificate Register");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPCERTCHECK, "船舶证书检验Ship Certificate Check");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPMAN, "船员管理Shipman Management Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARAPPLY, "备件申请Spare Apply");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARORDER, "备件订单Spare Order");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARIN, "备件入库Spare Inbound");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEAROUT, "备件出库Spare Outbound");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARCOUNT, "备件盘点Spare Stock-taking");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SPEARSTOCK, "备件库存Spare Stock");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MAINTENANCE, "维护保养Maintenance");
                fileBoundingTypesDetail.Add(FileBoundingTypes.DECKWORKMONTHPLAN, "甲板月度计划Deck Monthly Plan");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MACHINEWORKMONTHPLAN, "轮机月度计划Machine Monthly Plan");
                fileBoundingTypesDetail.Add(FileBoundingTypes.DECKWORKMONTHFINISH, "甲板月度完成Deck Monthly Report");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MACHINEWORKMONTHFINISH, "轮机月度完成Machine Monthly Report");
                fileBoundingTypesDetail.Add(FileBoundingTypes.DECKWORKYEARPLAN, "甲板年度计划Deck Yearly Plan");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MACHINEWORKYEARPLAN, "轮机年度计划Machine Yearly Plan");
                fileBoundingTypesDetail.Add(FileBoundingTypes.OILMANAGE, "油料管理Oil Management");
                fileBoundingTypesDetail.Add(FileBoundingTypes.OILAPPLY, "油料申请Oil Apply");
                fileBoundingTypesDetail.Add(FileBoundingTypes.OILSTOCK, "油料库存Oil Stock");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSAPPLY, "物资申请Material Apply");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSORDER, "物资订单Material Order");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSIN, "物资入库Material Inbound");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSOUT, "物资出库Material Outbound");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSCOUNT, "物资盘点Material Stock-taking");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ITEMSSTOCK, "物资库存Material Stock");
                fileBoundingTypesDetail.Add(FileBoundingTypes.DESIGNCOMPLATE, "完工图Design Complate");
                fileBoundingTypesDetail.Add(FileBoundingTypes.DESIGNOPINION, "退审图及意见Design Opinion");
                fileBoundingTypesDetail.Add(FileBoundingTypes.CERTIFICATESCAN, "证书扫描件Certificate Scanning");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMPONYFILES, "公司文件Company Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMPONENTFILES, "设备资料Equipment Electronic Data");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMPONENTOPERATION, "设备操作说明文件Equipment Operation Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMPONENTSYSTEMFILES, "设备系统资料Equipment System Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MEASUREREPORTMODEL, "工作报告模板Work Report Table");
                fileBoundingTypesDetail.Add(FileBoundingTypes.MEASUREREPORT, "工作报告Work Report");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ISMFILESROOT, "ISM文档管理ISM Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMPONYISMFILESROOT, "ISM公司文档Company ISM Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.OTHERREPORTMODEL, "其它体系文件Other Model Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.ISMMODELS, "ISM报告模板ISM Report Table");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COMMONDIR, "一般文件夹Common Directory");
                fileBoundingTypesDetail.Add(FileBoundingTypes.SHIPISMFILES, "船舶体系文档Ship Standard Files");
                fileBoundingTypesDetail.Add(FileBoundingTypes.COSTMANAGE, "费用管理Cost Management");
                fileBoundingTypesDetail.Add(FileBoundingTypes.VOUCHERFILES, "单日凭证Voucher Files");
            }
            #endregion
        }
        public string GetFolderDetail(int foldertype)
        {
            string re;
            try
            {
                re = FileBoundingTypesDetail[(FileBoundingTypes)(foldertype)];
            }
            catch
            {
                re = "无效值";
            }
            return re;
        }
        public string GetFolderDetail(FileBoundingTypes foldertype)
        {
            return FileBoundingTypesDetail[foldertype];
        }

        public string GetFileTypeLinkedString()
        {
            StringBuilder re = new StringBuilder();
            foreach (FileBoundingTypes fileBoundingType in fileBoundingTypesDetail.Keys)
                re.Append((int)fileBoundingType).Append(",");
            if (re.Length == 0) return "";
            return re.ToString(0, re.Length - 1);
        }
    }

    public enum ActionEnum
    {
        Add,
        Edit,
        View,
        Check,
        Join
    }   
}
