using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CommonOperation.Functions;

namespace CommonOperation
{
    partial class ConstParameter
    {
        #region 权限名称 注意，所有的这些名称必须在ProxyRight中注册，否则将比较麻烦。

        //----------公共的部分--------------------
        public static string EQUIPMENTCLASS_EDIT = "船舶设备分类维护";
        public static string EQUIPMENT_EDIT = "船舶设备维护";
        public static string OPERATION_PMS = "维护保养维护";//计划形成、工作信息修改等.
        public static string ITEMS_EDIT = "物资基础信息维护";
        public static string BASIC_EDIT = "基础信息维护";
        public static string ITEM_INIT = "物资初始化";
        public static string SHIPCERTIFICATION_EDIT = "船舶证书信息操作";
        public static string ISM_MODEL_EDIT = "体系模板维护";
        public static string SEAMAN_INFO_OPERATION = "船员信息维护";
        public static string ITEM_VIEW = "物资管理";//能在岸端查看备件物料的库存以及申请情况的权限，并不具备基本信息维护权限。.
        //public static string CMS_VIEW = "CMS检查项目查看";

        //----------船上的部分--------------------
        public static string WATCH_OTHERS_INFO_OF_SAME_DEPT = "查看同部门他人信息";
        public static string BASE_WORKINFO_EDIT = "基础工作信息维护";
        //public static string CMS_MANAGE = "CMS检查项目管理";

        //----------岸上部分----------------------
        public static string WATCH_PMS = "维护保养查看";
        public static string SHIPCERTIFICATION_VIWER = "船舶证书查看";//默认先不使用，跟用户协商一下再说。.
        public static string ITEM_LAND_CHECK = "备件物料岸端机务审核";//     
        public static string ITEM_LAND_LEADER_CHECK = "备件物料岸端机务部门长审核";//      
        public static string ITEM_LAND_MANAGER_CHECK = "备件物料岸端船管总经理长审核";//      


        public static string STRIKE_A_BALANCE = "物资冲账功能权限";//      

        //海丰功能权限部分.
        public static string COST_INIT = "费用基础信息维护";    // 
        public static string COST_OPERATION = "费用业务信息操作";//
        public static string COST_VIEW = "费用业务信息查看";//
        public static string COST_BILL = "费用发票实际付款日期管理";//

        public static string SAP_OPERATION = "SAP操作";// 
        public static string REPAIR_OPERATION = "修理操作";//
        public static string HOIL_INIT = "油料基础信息维护";//燃油、滑油基础信息的登记。.
        public static string HOIL_OPERATION = "油料业务信息操作";//燃油、滑油业务信息的添加和维护。.
        public static string HOIL_VIEW = "油料信息的查询统计";//燃油、滑油统计和图表显示。.
        //----------船上的部分--------------------

        //----------岸上部分----------------------

        public static Dictionary<string, bool> dictAllRights = null;//包含所有权限名称的字典型集合.

        public static void AllRightInit()
        {
            //int = 1,岸和船均可 =2 岸端 = 3 船端.
            ProxyRight.AllRight.Clear();
            ProxyRight.AllRight.Add(ConstParameter.EQUIPMENTCLASS_EDIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.EQUIPMENT_EDIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.ITEMS_EDIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.BASIC_EDIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.SHIPCERTIFICATION_EDIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.ISM_MODEL_EDIT, 1);
            // ProxyRight.AllRight.Add(ConstParameter.SEAMAN_INFO_OPERATION, 1);
            ProxyRight.AllRight.Add(ConstParameter.WATCH_PMS, 2);
            ProxyRight.AllRight.Add(ConstParameter.OPERATION_PMS, 1);
            ProxyRight.AllRight.Add(ConstParameter.SHIPCERTIFICATION_VIWER, 2);
            ProxyRight.AllRight.Add(ConstParameter.ITEM_LAND_CHECK, 2);
            ProxyRight.AllRight.Add(ConstParameter.ITEM_LAND_LEADER_CHECK, 2);
            ProxyRight.AllRight.Add(ConstParameter.ITEM_LAND_MANAGER_CHECK, 2);
#warning 海丰不使用物资冲账功能，屏蔽此权限 2015-1-29 徐正本
            //ProxyRight.AllRight.Add(ConstParameter.STRIKE_A_BALANCE, 2);
            
            ProxyRight.AllRight.Add(ConstParameter.ITEM_VIEW, 1);
            ProxyRight.AllRight.Add(ConstParameter.ITEM_INIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, 3);
            ProxyRight.AllRight.Add(ConstParameter.BASE_WORKINFO_EDIT, 1);
            //     ProxyRight.AllRight.Add(ConstParameter.CMS_MANAGE, 3);
            //     ProxyRight.AllRight.Add(ConstParameter.CMS_VIEW, 1);
            ProxyRight.AllRight.Add(ConstParameter.COST_INIT, 2);
            ProxyRight.AllRight.Add(ConstParameter.COST_OPERATION, 1);
            ProxyRight.AllRight.Add(ConstParameter.COST_VIEW, 1);
            ProxyRight.AllRight.Add(ConstParameter.COST_BILL, 2);
            ProxyRight.AllRight.Add(ConstParameter.SAP_OPERATION, 2);
            ProxyRight.AllRight.Add(ConstParameter.REPAIR_OPERATION, 1);
            ProxyRight.AllRight.Add(ConstParameter.HOIL_INIT, 1);
            ProxyRight.AllRight.Add(ConstParameter.HOIL_OPERATION, 1);
            ProxyRight.AllRight.Add(ConstParameter.HOIL_VIEW, 1);
        }
        #endregion

        #region 参数设置集合:用于系统全局性的参数设定。

        public class SystemParameter
        {
            public string this[string k]
            {
                get
                {
                    if (ConstParameter.dicArgumentSetCollection.ContainsKey(k))
                        return ConstParameter.dicArgumentSetCollection[k];
                    else
                    {
                        return "";
                    }
                }
            }
            public bool ContainsKey(string k)
            {
                return ConstParameter.dicArgumentSetCollection.ContainsKey(k);
            }
        }
        //参数设置集合.
        private static Dictionary<string, string> dicArgumentSetCollection = new Dictionary<string, string>();
        private static SystemParameter argumentSet = new SystemParameter();
        public static SystemParameter ArgumentSetCollection
        {
            get { return argumentSet; }
            //set { ConstParameter.ArgumentSetCollection22 = value; }
        }

        public static void ArgumentSetCollectionInit()
        {
            string err = "";
            dicArgumentSetCollection.Clear();
            DataTable dt = Parameter.getInfo(out err);

            foreach (DataRow row in dt.Rows)
            {
                dicArgumentSetCollection.Add(row["CODE"].ToString(), row["CODE_VALUE"].ToString());
            }
        }

        #endregion
    }
}
