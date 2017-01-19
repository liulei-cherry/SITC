/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportBoilerwaterService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/9/12
 * 标    题：数据操作类
 * 功能描述：T_REPORT_BOILERWATER数据操作类
 * Codesmith DataAccessLayer.cst 1.01版本生成
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using BaseInfo.Objects;
using StorageManage.Services;
using StorageManage.DataObject;
using BaseInfo.DataAccess;
using System.IO;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using System.Data;
using Maintenance.Services;
using Maintenance.DataObject;
using CommonOperation.BaseClass;
using OfficeOperation;
using ShipCertification.DataObject;
using System.Drawing;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;
using CommonViewer;
using System.Windows.Forms;
using Repair.DataObject;
using Repair.Services;

namespace CustomerTable.Haifeng.Services
{
    public class AllCustomerReport
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static AllCustomerReport instance;
        public static AllCustomerReport Instance
        {
            get
            {
                if (null == instance)
                {
                    AllCustomerReport.instance = new AllCustomerReport();
                }
                return AllCustomerReport.instance;
            }
        }
        private AllCustomerReport()
        {
        }
        #endregion
        Font titleFont = new Font("宋体", 20, FontStyle.Bold);
        Font tableHeadFont = new Font("宋体", 10, FontStyle.Bold);
        Font systemFont = new Font("黑体", 12, FontStyle.Bold);
        Font bodyFont = new Font("宋体", 10);
        Font pageHeaderFont = new Font("宋体", 7);
        Font pageFooterFont = new Font("宋体", 8, FontStyle.Italic);

        static FileDbService filo = FileDbService.Instance;

        #region 备件申请部分
        /// <summary>
        /// path包含名称.
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="path"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool customSpareApplyPrint(string applyId, out string err)
        {
            SparePurchaseApply spareApply = SparePurchaseApplyService.Instance.getObject(applyId, out err);
            if (spareApply == null || spareApply.IsWrong || string.IsNullOrEmpty(spareApply.SHIP_ID) || string.IsNullOrEmpty(spareApply.COMPONENT_UNIT_ID))
            {
                err = "无法获取备件申请表的详细内容,或者申请表的信息不完整(船舶或设备为空)";
                return false;
            }
            DataTable dt;
            if (!SparePurchaseApplyDetailService.Instance.GetInfo(applyId, out dt, out err))
            {
                return false;
            }
            string[,] tableData = new string[dt.Rows.Count, 9];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                tableData[i, 0] = (i + 1).ToString();
                tableData[i, 1] = dr["SPARE_NAME"].ToString();
                tableData[i, 2] = dr["PICNUMBER"].ToString();
                tableData[i, 3] = dr["PARTNUMBER"].ToString();
                tableData[i, 4] = dr["UNIT_NAME"].ToString();
                tableData[i, 5] = dr["APPLYCOUNT"].ToString();
                tableData[i, 6] = dr["COUNTINSHIP"].ToString();
                tableData[i, 7] = dr["REMARK"].ToString();
                tableData[i, 8] = dr["CONFIRMEDCOUNT"].ToString();
            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 60);
                operExcel.AddAllColumnSize(3, 40);
                operExcel.AddAllColumnSize(4, 140);
                operExcel.AddAllColumnSize(5, 120);
                operExcel.AddAllColumnSize(6, 140);
                operExcel.AddAllColumnSize(7, 40);
                operExcel.AddAllColumnSize(8, 40);
                operExcel.AddAllColumnSize(9, 40);
                operExcel.AddAllColumnSize(10, 75);
                operExcel.AddAllColumnSize(11, 70);
                operExcel.AddAllColumnSize(12, 55);
                operExcel.AddAllColumnSize(13, 15);

                //if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, dt.Rows.Count, 9, true, XlHorizontalAlignment.xlLeft), out err))
                //{
                //    return false;
                //}
                for (int i = 1; i <= tableData.GetLength(0); i++)
                {
                    if (!operExcel.InsertABodyUnit(new OneUnit(tableData[i-1, 0],false,i,2,1,1,true,false,XlHorizontalAlignment.xlCenter), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 1], false, i, 3, 1, 2, true, true, XlHorizontalAlignment.xlLeft), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 2], false, i, 5, 1, 1, true, true, XlHorizontalAlignment.xlLeft), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 3], false, i, 6, 1, 1, true, true, XlHorizontalAlignment.xlLeft), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 4], false, i, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 5], false, i, 8, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 6], false, i, 9, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 7], false, i, 10, 1, 2, true, true, XlHorizontalAlignment.xlLeft), out err)
                        || !operExcel.InsertABodyUnit(new OneUnit(tableData[i - 1, 8], false, i, 12, 1, 1, true, true, XlHorizontalAlignment.xlRight), out err)
                        )
                    {

                    }
                }


                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    operExcel.AddAllLineSize(i, 30);
                }

                addHeaderSpare(operExcel, spareApply);

                FrmOurReport frm = new FrmOurReport("备件申请单打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        /// <summary>
        /// path包含名称.
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="path"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool customAskPricePrint(string applyId, out string err)
        {
            SparePurchaseApply spareApply = SparePurchaseApplyService.Instance.getObject(applyId, out err);
            if (spareApply == null || spareApply.IsWrong || string.IsNullOrEmpty(spareApply.SHIP_ID) || string.IsNullOrEmpty(spareApply.COMPONENT_UNIT_ID))
            {
                err = "无法获取备件申请表的详细内容,或者申请表的信息不完整(船舶或设备为空)";
                return false;
            }
            DataTable dt;
            if (!SparePurchaseApplyDetailService.Instance.GetInfo(applyId, out dt, out err))
            {
                return false;
            }
            string[,] tableData = new string[dt.Rows.Count, 10];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                tableData[i, 0] = (i + 1).ToString();
                tableData[i, 1] = dr["SPARE_NAME"].ToString();
                tableData[i, 2] = dr["PICNUMBER"].ToString();
                tableData[i, 3] = dr["PARTNUMBER"].ToString();
                tableData[i, 4] = dr["APPLYCOUNT"].ToString();
                tableData[i, 5] = dr["CONFIRMEDCOUNT"].ToString();
                tableData[i, 6] = dr["UNIT_NAME"].ToString();
                tableData[i, 7] = "";//单价
                tableData[i, 8] = "";//总价
                tableData[i, 9] = "";
            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 50);
                operExcel.AddAllColumnSize(3, 190);
                operExcel.AddAllColumnSize(4, 120);
                operExcel.AddAllColumnSize(5, 120);
                operExcel.AddAllColumnSize(6, 60);
                operExcel.AddAllColumnSize(7, 60);
                operExcel.AddAllColumnSize(8, 40);
                operExcel.AddAllColumnSize(9, 60);
                operExcel.AddAllColumnSize(10, 60);
                operExcel.AddAllColumnSize(11, 120);
                operExcel.AddAllColumnSize(12, 15);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, dt.Rows.Count, 10, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }
                addHeaderAskPriceSpare(operExcel, spareApply);

                FrmOurReport frm = new FrmOurReport("备件询价单打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        private void addHeaderAskPriceSpare(OperationExcel operationExcel, SparePurchaseApply theApply)
        {
            theApply.FillThisObject();
            string shipName = theApply.TheShipInfo.SHIP_NAME;
            ComponentUnit theEquipment = theApply.TheApplyEquipment;
            List<OneUnit> theHeader = new List<OneUnit>();
            theEquipment.FillThisObject();
            theHeader.Add(new OneUnit(shipName + "轮备件询价单", false, 1, 2, 1, 10, false, false, XlHorizontalAlignment.xlCenter, titleFont));
            theHeader.Add(new OneUnit("EQUIPMENT:" + theEquipment.COMP_CHINESE_NAME, false, 2, 2, 1, 2, false, false, XlHorizontalAlignment.xlLeft, systemFont));
            theHeader.Add(new OneUnit("SERIAL No.:" + (string.IsNullOrEmpty(theEquipment.comp_serial_no) ? "" : theEquipment.comp_serial_no), false, 2, 8, 1, 3, false, false, XlHorizontalAlignment.xlRight, systemFont));
            if (theEquipment.TheComponentType != null && !theEquipment.TheComponentType.IsWrong)
            {
                theHeader.Add(new OneUnit("TYPE:" + theEquipment.TheComponentType.COMPONENT_STYLE, false, 2, 4, 1, 3, false, false, XlHorizontalAlignment.xlCenter, systemFont));
                theHeader.Add(new OneUnit("MAKER:" + theEquipment.TheComponentType.MANUFACTURER, false, 3, 2, 1, 4, false, false, XlHorizontalAlignment.xlLeft, systemFont));
            }
            theHeader.Add(new OneUnit("编号:" + theApply.PURCHASE_APPLY_CODE, false, 3, 7, 1, 4, false, false, XlHorizontalAlignment.xlRight, systemFont));
            theHeader.Add(new OneUnit("序号", false, 4, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备件名称", false, 4, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("图纸号", false, 4, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备件号", false, 4, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("申请数量", false, 4, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("订购数量", false, 4, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("单位", false, 4, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("单价", false, 4, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("总价", false, 4, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备注", false, 4, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));

            List<OneUnit> theFooter = new List<OneUnit>();

            List<int> headerHeight = new List<int>();
            headerHeight.Add(33);
            headerHeight.Add(20);
            headerHeight.Add(40);
            headerHeight.Add(33);
            List<int> footerHeight = new List<int>();
            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
            operationExcel.SetPageFillGrid(true, 2, 11, 20);
        }
        private void addHeaderSpare(OperationExcel operationExcel, SparePurchaseApply theApply)
        {

            theApply.FillThisObject();
            string shipName = theApply.TheShipInfo.SHIP_NAME;
            ComponentUnit theEquipment = theApply.TheApplyEquipment;


            List<OneUnit> theHeader = new List<OneUnit>();
            theEquipment.FillThisObject();
            theHeader.Add(new OneUnit("SITC04综合操作须知                                                                                             第45页",
                false, 1, 2, 1, 10, false, true, false, XlHorizontalAlignment.xlCenter, pageHeaderFont, XLPattern.xlPatternNone, Color.Gray));

            theHeader.Add(new OneUnit(shipName, false, 2, 4, 1, 2, false, true, false, XlHorizontalAlignment.xlCenter, titleFont, XLPattern.xlPatternNone));
            theHeader.Add(new OneUnit("轮备件申请单", false, 2, 6, 1, 7, false, false, XlHorizontalAlignment.xlLeft, titleFont));
            //theHeader.Add(new OneUnit(shipName + "轮备件申请单", false, 1, 2, 1, 9, false, false, XlHorizontalAlignment.xlCenter, titleFont));

            theHeader.Add(new OneUnit("编号：100105－2", false, 3, 2, 1, 11, false, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("SPARE PARTS APPLICATION LIST", false, 4, 2, 1, 11, false, false, XlHorizontalAlignment.xlCenter, systemFont));
            theHeader.Add(new OneUnit("EQUIPMENT:", false, 5, 2, 1, 2, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit(theEquipment.COMP_CHINESE_NAME, false, 5, 4, 1, 1, false, true, false, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit("SERIAL No.:", false, 5, 9, 1, 2, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit((string.IsNullOrEmpty(theEquipment.comp_serial_no) ? "" : theEquipment.comp_serial_no), false, 5, 11, 1, 2, false, true, false, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
            if (theEquipment.TheComponentType != null && !theEquipment.TheComponentType.IsWrong)
            {
                theHeader.Add(new OneUnit("TYPE:", false, 5, 5, 1, 1, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
                theHeader.Add(new OneUnit(theEquipment.TheComponentType.COMPONENT_STYLE, false, 5, 6, 1, 1, false, true, false, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
                theHeader.Add(new OneUnit("MAKER:" , false, 6, 2, 1, 1, false,false, false, XlHorizontalAlignment.xlLeft,XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone,Color.Black));
                theHeader.Add(new OneUnit(theEquipment.TheComponentType.MANUFACTURER, false, 6, 3, 1, 2, false, true, false, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlBottom, systemFont, XLPattern.xlPatternNone, Color.Black));
            }
            theHeader.Add(new OneUnit("编号:" + theApply.PURCHASE_APPLY_CODE, false, 7, 10, 1, 3, false, false, XlHorizontalAlignment.xlLeft, bodyFont));

            theHeader.Add(new OneUnit("序          号", false, 8, 2, 1, 1, true, false, true, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlCenter, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit("备件名称", false, 8, 3, 1, 2, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("图纸号", false, 8, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备件号", false, 8, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("单          位", false, 8, 7, 1, 1, true, false, true, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlCenter, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit("申  订  数  量", false, 8, 8, 1, 1, true, false, true, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlCenter, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit("船  存  数  量", false, 8, 9, 1, 1, true, false, true, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlCenter, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theHeader.Add(new OneUnit("申请理由", false, 8, 10, 1, 2, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("公司实                订数量", false, 8, 12, 1, 1, true, false, true, XlHorizontalAlignment.xlCenter, XlVerticalAlignment.xlCenter, bodyFont, XLPattern.xlPatternNone, Color.Black));

            List<OneUnit> theFooter = new List<OneUnit>();
            theFooter.Add(new OneUnit("轮机长/大副签名:" + (theApply.SHIP_LEADER_CHECKER == null ? "" : theApply.SHIP_LEADER_CHECKER),
                false, 1, 2, 1, 4, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit((theApply.SHIP_LEADER_CHECKDATE == null || theApply.SHIP_LEADER_CHECKDATE == DateTime.MinValue ? "" : theApply.SHIP_LEADER_CHECKDATE.ToString("yyyy年MM月dd日")),
                false, 1, 6, 1, 1, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit("船长签名:" + (theApply.SHIP_BOSS_CHECKER == null ? "" : theApply.SHIP_BOSS_CHECKER),
                 false, 1, 7, 1, 3, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit((theApply.SHIP_BOSS_CHECKDATE == null || theApply.SHIP_BOSS_CHECKDATE == DateTime.MinValue ? "" : theApply.SHIP_BOSS_CHECKDATE.ToString("yyyy年MM月dd日")),
                 false, 1, 10, 1, 3, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit("审核", false,
                3, 2, 1, 2, false, false, XlHorizontalAlignment.xlCenter, bodyFont));


            theFooter.Add(new OneUnit(theApply.REMARK+"",
               false, 2, 4, 2, 9, false, false, true, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlTop, bodyFont, XLPattern.xlPatternNone, Color.Black));
            
            
            theFooter.Add(new OneUnit("机务主管签名:" + (theApply.LANDCHECKER == null ? "" : theApply.LANDCHECKER),
               false, 4, 4, 1, 3, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit((theApply.CHECKDATE == null || theApply.CHECKDATE == DateTime.MinValue ? "" : theApply.CHECKDATE.ToString("yyyy年MM月dd日")),
               false, 4, 7, 1, 6, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("备注： 1、年底由轮机长和大副分别申报本部门下年度所需备件，经船长批准后，报机务部，",
                false, 5, 2, 1, 11, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("            机务主管审核并批准。船舶和机务主管各存一份。",
                false, 6, 2, 1, 11, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("       2、未经公司同意不得外购。",
                false, 7, 2, 1, 11, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("       3、对于计划外必需备件，也要填写此申请单。",
                false, 8, 2, 1, 11, false, false, XlHorizontalAlignment.xlLeft, bodyFont));

            theFooter.Add(new OneUnit("  Controlled Copy                                                 Rev.1.0                                                 Do Not Duplicate",
                false, 9, 2, 1, 11, false, false, false, XlHorizontalAlignment.xlCenter, pageFooterFont, XLPattern.xlPatternGray16, Color.Gray));
            List<OneGrid> allHeaderGrid = new List<OneGrid>();
            List<OneGrid> allFooterGrid = new List<OneGrid>();
            OneGrid oneGrid = new OneGrid(1, 2, 1, 11, new int[] { 2, 7, 13 }, new int[] { 1, 2 });
            OneGrid oneGridTwo = new OneGrid(2, 2, 3, 11, new int[] {4,13 }, new int[] { 2, 5 });
            allFooterGrid.Add(oneGrid);
            allFooterGrid.Add(oneGridTwo);
            List<int> headerHeight = new List<int>();
            headerHeight.Add(20);
            headerHeight.Add(33);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(48);
            List<int> footerHeight = new List<int>();
            footerHeight.Add(30);
            footerHeight.Add(23);
            footerHeight.Add(30);
            footerHeight.Add(23);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(2);
            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight, allHeaderGrid,allFooterGrid);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
            operationExcel.SetPageFillGrid(true, 2, 12, 30);
        }

        #endregion

        #region 修理申请部分
        /// <summary>
        /// path包含名称.
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="path"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool customRepairApplyPrint(List<string> applyList, out string err)
        {
            DataTable dt = new DataTable();
            string[,] tableData = new string[applyList.Count, 3];
            for (int i = 0; i < applyList.Count; i++)
            {
                DataTable apply = ShipRepairProjectService.Instance.GetInfo(applyList[i], null, null, null, null, null);
                if (i == 0) dt = apply;
                DataRow dr = apply.Rows[0];
                tableData[i, 0] = (i + 1).ToString();
                tableData[i, 1] = dr["PROJECTNAME"].ToString() + "\r\n" + dr["PROJECTDETAIL"].ToString();
                tableData[i, 2] = dr["REMARK"].ToString();
            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 100);
                operExcel.AddAllColumnSize(3, 350);
                operExcel.AddAllColumnSize(4, 330);
                operExcel.AddAllColumnSize(5, 15);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, applyList.Count, 3, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }
                SetHeaderFooter(operExcel, dt.Rows[0]);

                FrmOurReport frm = new FrmOurReport("申请单打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        private void SetHeaderFooter(OperationExcel operationExcel, DataRow theApply)
        {
            string err;
            List<OneUnit> theHeader = new List<OneUnit>();

            theHeader.Add(new OneUnit("修理单", false, 2, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, titleFont));
            theHeader.Add(new OneUnit("编号：100103－1", false, 3, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("船名: " + theApply["SHIP_NAME"].ToString(), false, 4, 2, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theHeader.Add(new OneUnit("日期: " + Convert.ToDateTime(theApply["APPLYDATE"]).ToString("yyyy年MM月dd日"), false, 4, 4, 1, 1, false, false, XlHorizontalAlignment.xlRight, bodyFont));
            if (theApply["DEPARTMENTID"].ToString() != DepartmentService.Instance.GetInfoByDepartmentType("甲板部门", out err).DEPARTMENTID)
                theHeader.Add(new OneUnit("轮机部 [√]", false, 5, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            else
                theHeader.Add(new OneUnit("甲板部 [ ]", false, 5, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            if (theApply["DEPARTMENTID"].ToString() != DepartmentService.Instance.GetInfoByDepartmentType("轮机部门", out err).DEPARTMENTID)
                theHeader.Add(new OneUnit("甲板部 [√]", false, 5, 3, 1, 1, false, false, XlHorizontalAlignment.xlCenter, bodyFont));
            else
                theHeader.Add(new OneUnit("甲板部 [ ]", false, 5, 3, 1, 1, false, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("港口: " + theApply["REPAIRPORT"].ToString(), false, 5, 4, 1, 1, false, false, XlHorizontalAlignment.xlRight, bodyFont));
            theHeader.Add(new OneUnit("序号", false, 6, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("项               目", false, 6, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备注", false, 6, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));

            List<OneUnit> theFooter = new List<OneUnit>();
            theFooter.Add(new OneUnit("备注:", false, 2, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("1.修理项目要注明位置，制造者/型式號材料，存在缺陷和修理要求，必要时附上草图说明。", false, 2, 3, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("2.说明修理需要的备件、材料和是否高空作业或清洗油舱明火作业等。", false, 3, 3, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("部门长：" + theApply["SHIPAFFIRMANT"].ToString(), false, 4, 2, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("机务主管：" + theApply["COMPAFFIRMANT"].ToString(), false, 4, 4, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));

            List<int> headerHeight = new List<int>();
            headerHeight.Add(5);
            headerHeight.Add(30);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(20);
            headerHeight.Add(30);
            List<int> footerHeight = new List<int>();
            footerHeight.Add(0);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(30);

            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
            operationExcel.SetPageFillGrid(true, 2, 4, 20);
        }

        #endregion
        #region 坞修总结部分
        /// <summary>
        /// 坞修总结报表.
        /// </summary>
        public bool customDockRepairSummarizePrint(DataTable dt, out string err)
        {
            string[,] tableData = new string[dt.Rows.Count, 7];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tableData[i, 0] = (i + 1).ToString();
                tableData[i, 1] = dt.Rows[i]["SHIP_NAME"].ToString();
                tableData[i, 2] = dt.Rows[i]["NODE_NAME"].ToString();
                tableData[i, 3] = dt.Rows[i]["MANUFACTURER_NAME"].ToString();
                tableData[i, 4] = dt.Rows[i]["CURRENCYNAME"].ToString();
                tableData[i, 5] = dt.Rows[i]["ESTIMATE_AMOUNT"].ToString();
                tableData[i, 6] = dt.Rows[i]["TOTAL_AMOUNT"].ToString();
            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 50);
                operExcel.AddAllColumnSize(3, 100);
                operExcel.AddAllColumnSize(4, 100);
                operExcel.AddAllColumnSize(5, 200);
                operExcel.AddAllColumnSize(6, 100);
                operExcel.AddAllColumnSize(7, 100);
                operExcel.AddAllColumnSize(8, 150);
                operExcel.AddAllColumnSize(9, 15);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, dt.Rows.Count, 7, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }

                #region SetHeaderFooter
                List<OneUnit> theHeader = new List<OneUnit>();
                theHeader.Add(new OneUnit("坞修总结", false, 1, 1, 1, 8, false, false, XlHorizontalAlignment.xlCenter, titleFont));
                theHeader.Add(new OneUnit("序号", false, 2, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("船舶", false, 2, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("科目", false, 2, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("供应商", false, 2, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("币种", false, 2, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("预估金额", false, 2, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("汇总金额(美元)", false, 2, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));

                //dic.Add("SHIP_NAME", "船舶");
                //dic.Add("NODE_NAME", "科目");
                //dic.Add("MANUFACTURER_NAME", "供应商");
                //dic.Add("ESTIMATE_AMOUNT", "预估金额");
                //dic.Add("TOTAL_AMOUNT", "汇总金额");

                List<int> headerHeight = new List<int>();
                headerHeight.Add(30);
                headerHeight.Add(30);

                List<OneUnit> theFooter = new List<OneUnit>();
                List<int> footerHeight = new List<int>();

                HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight);
                operExcel.AddHeaderAndFooter(oneHeaderAndFooter);
                operExcel.SetPageFillGrid(true, 2, 8, 20);
                #endregion
                FrmOurReport frm = new FrmOurReport("坞修总结打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        #endregion
        public bool customMaterialApplyPrint(string applyId, out string err)
        {
            MaterialPurchaseApply apply = MaterialPurchaseApplyService.Instance.getObject(applyId, out err);
            if (apply == null || apply.IsWrong || string.IsNullOrEmpty(apply.SHIP_ID))
            {
                err = "无法获取申请表的详细内容,或者申请表的信息不完整";
                return false;
            }
            DataTable dt;
            if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(applyId, out dt, out err))
            {
                return false;
            }
            string[,] tableData = new string[dt.Rows.Count, 8];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                tableData[i, 0] = dr["MATERIAL_NAME"].ToString();
                tableData[i, 1] = dr["MATERIAL_CODE"].ToString();
                tableData[i, 2] = dr["MATERIAL_SPEC"].ToString();
                tableData[i, 3] = dr["UNIT_NAME"].ToString();
                tableData[i, 4] = dr["COUNTINSHIP"].ToString();
                tableData[i, 5] = dr["APPLYCOUNT"].ToString();
                tableData[i, 6] = dr["CONFIRMEDCOUNT"].ToString();
                tableData[i, 7] = dr["REMARK"].ToString();

            }
            using (OperationExcel operExcel = new OperationExcel())
            {

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, dt.Rows.Count, 8, true, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    operExcel.AddAllLineSize(i, 30);
                }

                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 145);
                operExcel.AddAllColumnSize(3, 130);
                operExcel.AddAllColumnSize(4, 121);
                operExcel.AddAllColumnSize(5, 110);
                operExcel.AddAllColumnSize(6, 48);
                operExcel.AddAllColumnSize(7, 48);
                operExcel.AddAllColumnSize(8, 48);
                operExcel.AddAllColumnSize(9, 150);
                operExcel.AddAllColumnSize(10, 15);

                addHeaderMaterial(operExcel, apply);
                FrmOurReport frm = new FrmOurReport("物料申请单打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        public bool customMaterialAskPricePrint(string applyId, out string err)
        {
            MaterialPurchaseApply apply = MaterialPurchaseApplyService.Instance.getObject(applyId, out err);
            if (apply == null || apply.IsWrong || string.IsNullOrEmpty(apply.SHIP_ID))
            {
                err = "无法获取申请表的详细内容,或者申请表的信息不完整";
                return false;
            }
            DataTable dt;
            if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(applyId, out dt, out err))
            {
                return false;
            }
            string[,] tableData = new string[dt.Rows.Count, 9];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                tableData[i, 0] = dr["MATERIAL_NAME"].ToString();
                tableData[i, 1] = dr["MATERIAL_CODE"].ToString();
                tableData[i, 2] = dr["MATERIAL_SPEC"].ToString();
                tableData[i, 3] = dr["APPLYCOUNT"].ToString();
                tableData[i, 4] = dr["CONFIRMEDCOUNT"].ToString();
                tableData[i, 5] = dr["UNIT_NAME"].ToString();
                tableData[i, 6] = "";//单价
                tableData[i, 7] = "";//总价
                tableData[i, 8] = "";

            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(false);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 170);
                operExcel.AddAllColumnSize(3, 140);
                operExcel.AddAllColumnSize(4, 120);
                operExcel.AddAllColumnSize(5, 60);
                operExcel.AddAllColumnSize(6, 60);
                operExcel.AddAllColumnSize(7, 60);
                operExcel.AddAllColumnSize(8, 60);
                operExcel.AddAllColumnSize(9, 60);
                operExcel.AddAllColumnSize(10, 150);
                operExcel.AddAllColumnSize(11, 15);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, dt.Rows.Count, 9, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }
                addHeaderMaterialAskPrice(operExcel, apply);

                FrmOurReport frm = new FrmOurReport("物料询价单打印预览", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        private void addHeaderMaterialAskPrice(OperationExcel operationExcel, MaterialPurchaseApply theApply)
        {
            theApply.FillThisObject();
            string shipName = theApply.TheShipInfo.SHIP_NAME;
            string err = "";
            string departName = "";
            Department department = DepartmentService.Instance.getObject(theApply.DEPART_ID, out err);
            if (department != null || !department.IsWrong)
            {
                departName = department.DEPARTNAME;
            }

            List<OneUnit> theHeader = new List<OneUnit>();
            theHeader.Add(new OneUnit(shipName + "轮物资询价单(" + departName + ")", false, 1, 2, 1, 9, false, false, XlHorizontalAlignment.xlCenter, titleFont));

            theHeader.Add(new OneUnit("物资名称", false, 3, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("物资编码", false, 3, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("型号规格", false, 3, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("申请数量", false, 3, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("订购数量", false, 3, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("单位", false, 3, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("单价", false, 3, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("总价", false, 3, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备 注", false, 3, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));

            List<OneUnit> theFooter = new List<OneUnit>();
            List<int> headerHeight = new List<int>();
            headerHeight.Add(33);
            headerHeight.Add(20);
            headerHeight.Add(33);
            List<int> footerHeight = new List<int>();
            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
            operationExcel.SetPageFillGrid(true, 2, 10, 20);
        }
        private void addHeaderMaterial(OperationExcel operationExcel, MaterialPurchaseApply theApply)
        {
            theApply.FillThisObject();
            string shipName = theApply.TheShipInfo.SHIP_NAME;
            string err = "";
            string departName = "";
            Department department = DepartmentService.Instance.getObject(theApply.DEPART_ID, out err);
            if (department != null || !department.IsWrong)
            {
                departName = department.DEPARTNAME;
            }

            List<OneUnit> theHeader = new List<OneUnit>();
            theHeader.Add(new OneUnit("SITC04综合操作须知                                                                                             第44页",
                false, 1, 2, 1, 8, false, true, false, XlHorizontalAlignment.xlCenter, pageHeaderFont, XLPattern.xlPatternNone, Color.Gray));
            //theHeader.Add(new OneUnit(shipName + "轮物资申请单(" + departName + ")", false, 3, 2, 1, 8, false, false, XlHorizontalAlignment.xlCenter, titleFont));
            theHeader.Add(new OneUnit(shipName, false, 2, 3, 1, 2, false, true,false, XlHorizontalAlignment.xlCenter, titleFont, XLPattern.xlPatternNone));
            theHeader.Add(new OneUnit("轮物料申请单", false, 2, 5, 1, 6, false, false, XlHorizontalAlignment.xlLeft, titleFont));
            theHeader.Add(new OneUnit("编号：100105－1 ", false, 3, 2, 1, 8, false, false, XlHorizontalAlignment.xlCenter, bodyFont));

            theHeader.Add(new OneUnit("物料名称", false, 5, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("物料编码", false, 5, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("型号规格                     尺寸等", false, 5, 4, 1, 1, true, true, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("计量                     单位", false, 5, 5, 1, 1, true, true, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("船存数", false, 5, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("申领数", false, 5, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("审核数", false, 5, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));
            theHeader.Add(new OneUnit("备 注", false, 5, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, bodyFont));

            List<OneUnit> theFooter = new List<OneUnit>();
            
            theFooter.Add(new OneUnit("轮机长/大副签名:" + (theApply.SHIP_LEADER_CHECKER == null ? "" : theApply.SHIP_LEADER_CHECKER),
                false, 1, 2, 1, 2, false,false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom,bodyFont, XLPattern.xlPatternNone,Color.Black));

            theFooter.Add(new OneUnit((theApply.SHIP_LEADER_CHECKDATE == null || theApply.SHIP_LEADER_CHECKDATE == DateTime.MinValue ? "" : theApply.SHIP_LEADER_CHECKDATE.ToString("yyyy年MM月dd日")),
                false, 1, 4, 1, 1, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));

            theFooter.Add(new OneUnit("船长签名:" + (theApply.SHIP_BOSS_CHECKER == null ? "" : theApply.SHIP_BOSS_CHECKER),
                 false, 1, 5, 1, 3, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));


            theFooter.Add(new OneUnit((theApply.SHIP_BOSS_CHECKDATE == null || theApply.SHIP_BOSS_CHECKDATE == DateTime.MinValue ? "" : theApply.SHIP_BOSS_CHECKDATE.ToString("yyyy年MM月dd日")),
                 false, 1, 8, 1, 2, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit(theApply.REMARK == null ? "" : theApply.REMARK
               , false, 2, 2, 1, 8, false, false, true, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlTop, bodyFont, XLPattern.xlPatternNone, Color.Black));

            theFooter.Add(new OneUnit("机务主管签名:" + (theApply.LANDCHECKER == null ? "" : theApply.LANDCHECKER)
               , false, 3, 2, 1, 2, false, false, false, XlHorizontalAlignment.xlLeft, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));

            theFooter.Add(new OneUnit((theApply.CHECKDATE == null || theApply.CHECKDATE == DateTime.MinValue ? "" : theApply.CHECKDATE.ToString("yyyy年MM月dd日")),
               false, 3, 8, 1, 2, false, false, false, XlHorizontalAlignment.xlRight, XlVerticalAlignment.xlBottom, bodyFont, XLPattern.xlPatternNone, Color.Black));
            theFooter.Add(new OneUnit("备注：在正常情况下，按3个月消耗量申领。在每季度末由轮机长和大副分别申报本部门的物料，",
                false, 4, 2, 1, 8, false, false, true, XlHorizontalAlignment.xlLeft, bodyFont, XLPattern.xlPatternNone));
            theFooter.Add(new OneUnit("      经船长批准后，报机务部。船舶和机务部各存一份。",
                false, 5, 2, 1, 8, false, false, true, XlHorizontalAlignment.xlLeft, bodyFont, XLPattern.xlPatternNone));

            theFooter.Add(new OneUnit("  Controlled Copy                                                 Rev.1.0                                                 Do Not Duplicate",
                false, 6, 2, 1, 8, false, false, false, XlHorizontalAlignment.xlCenter, pageFooterFont, XLPattern.xlPatternGray16, Color.Gray));
            
            List<OneGrid> allHeaderGrid = new List<OneGrid>();
            List<OneGrid> allFooterGrid= new List<OneGrid>();
            OneGrid oneGrid = new OneGrid(1, 2, 1, 8, new int[] { 1, 5, 10 }, new int[] { 1, 2 });
            OneGrid oneGridTwo = new OneGrid(2, 2, 2, 8, new int[] { 2, 10 }, new int[] { 2, 4 });
            allFooterGrid.Add(oneGrid);
            allFooterGrid.Add(oneGridTwo);
            List<int> headerHeight = new List<int>();
             headerHeight.Add(16);
             headerHeight.Add(33);
             headerHeight.Add(20);
            headerHeight.Add(6);
            headerHeight.Add(32);
            List<int> footerHeight = new List<int>();
            footerHeight.Add(30);
            footerHeight.Add(30);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(2);
            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight, allHeaderGrid, allFooterGrid);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
            operationExcel.SetPageFillGrid(true, 2, 9, 30);
        }

        #region MyRegion
        //public bool customMachineMonthlyCompleteReport(string shipId, int year, int month, List<string> lstPost, string path, out string err)
        //{
        //    #region 传入参数的判断与加工.
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        err = "传入的path参数无效.";
        //        return false;
        //    }
        //    err = "";

        //    DateTime fromDate = new DateTime(year, month, 1);
        //    DateTime endDate = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);

        //    //当postinfo为null或无效时,为所有岗位的表格.
        //    List<WorkOrder> lstWorkOrders;
        //    if (!WorkOrderService.Instance.GetWorkOrderOfDate(fromDate, endDate, lstPost, shipId, true,
        //        out lstWorkOrders, out err))
        //    {
        //        err = "获取具体的工单完成情况时出错,\r错误信息为:" + err;
        //    }
        //    ShipInfo shipinfo = (ShipInfo)(ShipInfoService.Instance.GetOneObjectById(shipId));
        //    #endregion

        //    #region 获取模板相关的内容.
        //    WorkModelType model = WorkModelTypeService.Instance.getModelObject(shipId, CommonPrintTableName.CTNOfMonthlyMachineCompleteReport, out err);
        //    if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
        //    {
        //        err = "获取客户定制的轮机月度完成情况表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
        //        return false;
        //    }

        //    FileInfo f = new FileInfo(path);
        //    if (f.Exists) f.Delete();

        //    string path2;
        //    //获取模板文件,并保存到指定位置;
        //    if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
        //    {
        //        err = "获取客户定制的轮机月度完成情况表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
        //        return false;
        //    }

        //    int rowIndexStart = (int)model.DateRow;
        //    #endregion

        //    OfficeOperation.Excel excel = new OfficeOperation.Excel();
        //    excel.OpenDocument(path2);
        //    excel.SetSingelCellValue(3, 3, shipinfo.SHIP_NAME, XlHorizontalAlignment.xlLeft);
        //    excel.SetSingelCellValue(5, 3, year.ToString() + "年" + month.ToString() + "月", XlHorizontalAlignment.xlLeft);
        //    excel.SetSingelCellValue(10, 3, DateTime.Today.ToLongDateString(), XlHorizontalAlignment.xlLeft);

        //    //由于几行可能并列到一行中去,所以这个代码不能用了.
        //    //for (int i = 22; i <= lstWorkOrders.Count + rowIndexStart; i++)
        //    //{
        //    //    excel.CopyRowToRow(i - 1);
        //    //}

        //    WorkInfo workInfoTemp = null;
        //    string lastWorkOrderName = "";
        //    int sameNo = 0;
        //    int rowNo = -1;
        //    for (int i = 0; i < lstWorkOrders.Count; i++)
        //    {
        //        WorkOrder workOrderTemp = lstWorkOrders[i];

        //        if (workOrderTemp.TheWorkInfo != null && workOrderTemp.TheWorkInfo.EqualTo(workInfoTemp) && workOrderTemp.WORKORDERNAME.Equals(lastWorkOrderName))
        //        {
        //            sameNo++;
        //        }
        //        else
        //        {
        //            workInfoTemp = workOrderTemp.TheWorkInfo;
        //            lastWorkOrderName = workOrderTemp.WORKORDERNAME;
        //            sameNo = 0;
        //            rowNo++;
        //            if (rowNo + rowIndexStart > 20) excel.CopyRowToRow(i + rowIndexStart - 1);

        //            excel.SetSingelCellValue(2, rowNo + rowIndexStart, workOrderTemp.LevelOfTheWork, XlHorizontalAlignment.xlLeft);
        //            excel.SetSingelCellValue(3, rowNo + rowIndexStart, workOrderTemp.WORKORDERNAME + "\r" + workOrderTemp.WORKDESCRIPTION, XlHorizontalAlignment.xlLeft);
        //            excel.SetSingelCellValue(5, rowNo + rowIndexStart, workOrderTemp.CyclePhrase, XlHorizontalAlignment.xlLeft);
        //            excel.SetSingelCellValue(14, rowNo + rowIndexStart, workOrderTemp.WORKEXECUTOR, XlHorizontalAlignment.xlLeft);

        //        }
        //        if (sameNo >= 4) continue;
        //        if (workOrderTemp.PLANEXEDATE.Month == month)
        //            excel.SetSingelCellValue(6 + sameNo, rowNo + rowIndexStart, workOrderTemp.PLANEXEDATE.Day.ToString(), XlHorizontalAlignment.xlLeft);
        //        else
        //            excel.SetSingelCellValue(6 + sameNo, rowNo + rowIndexStart, string.Format("{0:d}.{1:d}", workOrderTemp.PLANEXEDATE.Month.ToString(), workOrderTemp.PLANEXEDATE.Day.ToString()), XlHorizontalAlignment.xlLeft);
        //        if (workOrderTemp.COMPLETEDDATE.Month == month)
        //            excel.SetSingelCellValue(10 + sameNo, rowNo + rowIndexStart, workOrderTemp.COMPLETEDDATE.Day.ToString(), XlHorizontalAlignment.xlLeft);
        //        else
        //            excel.SetSingelCellValue(10 + sameNo, rowNo + rowIndexStart, string.Format("{0:d}.{1:d}", workOrderTemp.COMPLETEDDATE.Month.ToString(), workOrderTemp.COMPLETEDDATE.Day.ToString()), XlHorizontalAlignment.xlLeft);

        //    }
        //    excel.RowAutoFit(rowIndexStart, rowIndexStart + rowNo - 1);
        //    excel.SaveDocument(path2);
        //    excel.CloseDocument();
        //    Excel.release(excel.pt);

        //    File.Copy(path2, path);
        //    ourFile ofile;

        //    //right.C  为创建一个新的体系文件.
        //    if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MACHINEWORKMONTHFINISH,
        //        false, "", "", DateTime.Today, CommonOperation.ConstParameter.UserName, shipId, model.ModelFile, f.FullName, out ofile, out err))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        openFile opf = new openFile();
        //        opf.FileOpen(ofile, right.U);
        //    }
        //    return true;
        //}

        //public bool customDeckMonthlyCompleteReport(string shipId, int year, int month, List<string> lstPost, string path, out string err)
        //{
        //    #region 传入参数的判断与加工.
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        err = "传入的path参数无效.";
        //        return false;
        //    }
        //    err = "";
        //    //string sql = "";

        //    DateTime fromDate = new DateTime(year, month, 1);
        //    DateTime endDate = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);

        //    List<WorkOrder> lstWorkOrders;
        //    if (!WorkOrderService.Instance.GetWorkOrderOfDate(fromDate, endDate, lstPost, shipId, true,
        //        out lstWorkOrders, out err))
        //    {
        //        err = "获取具体的工单完成情况时出错,\r错误信息为:" + err;
        //    }
        //    ShipInfo shipinfo = (ShipInfo)(ShipInfoService.Instance.GetOneObjectById(shipId));
        //    #endregion

        //    #region 获取模板相关的内容.
        //    WorkModelType model = WorkModelTypeService.Instance.getModelObject(shipId, CommonPrintTableName.CTNOfMonthlyDeckCompleteReport, out err);
        //    if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
        //    {
        //        err = "获取客户定制的甲板月度完成情况表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
        //        return false;
        //    }

        //    FileInfo f = new FileInfo(path);
        //    if (f.Exists) f.Delete();

        //    string path2;
        //    //获取模板文件,并保存到指定位置;
        //    if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
        //    {
        //        err = "获取客户定制的甲板月度完成情况表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
        //        return false;
        //    }

        //    int rowIndexStart = (int)model.DateRow;
        //    #endregion

        //    OfficeOperation.Excel excel = new OfficeOperation.Excel();
        //    excel.OpenDocument(path2);
        //    excel.SetSingelCellValue(3, 6, shipinfo.SHIP_NAME, XlHorizontalAlignment.xlLeft);
        //    excel.SetSingelCellValue(5, 6, "甲板部", XlHorizontalAlignment.xlLeft);
        //    excel.SetSingelCellValue(10, 6, year.ToString(), XlHorizontalAlignment.xlLeft);
        //    excel.SetSingelCellValue(12, 6, month.ToString(), XlHorizontalAlignment.xlLeft);

        //    WorkInfo workInfoTemp = null;
        //    string lastWorkOrderName = "";
        //    //int sameNo = 0;
        //    //int rowNo = -1;
        //    int i;
        //    for (i = 0; i < lstWorkOrders.Count; i++)
        //    {
        //        excel.InsertRows("c" + (8 + i));
        //        WorkOrder workOrderTemp = lstWorkOrders[i];
        //        workInfoTemp = workOrderTemp.TheWorkInfo;
        //        lastWorkOrderName = workOrderTemp.WORKORDERNAME;
        //        //if (i + rowIndexStart > 20) excel.CopyRowToRow(i + rowIndexStart - 1);
        //        excel.SetSingelCellValue(2, i + 8, (i + 1).ToString(), XlHorizontalAlignment.xlLeft);
        //        string workinfodetail = "";
        //        if (workOrderTemp.TheWorkInfo == null || workOrderTemp.TheWorkInfo.IsWrong)
        //            workinfodetail = workOrderTemp.WORKORDERNAME + ":" + workOrderTemp.WORKDESCRIPTION;
        //        else
        //            if (workOrderTemp.TheWorkInfo.WORKINFODETAIL.Contains(workOrderTemp.TheWorkInfo.WORKINFONAME))
        //                workinfodetail = workOrderTemp.TheWorkInfo.WORKINFODETAIL;
        //            else
        //                workinfodetail = workOrderTemp.TheWorkInfo.WORKINFONAME + ":" + workOrderTemp.TheWorkInfo.WORKINFODETAIL;
        //        excel.SetSingelCellValue(3, i + 8, workinfodetail + "\r" + workOrderTemp.WORKDESCRIPTION, XlHorizontalAlignment.xlLeft);
        //        excel.SetSingelCellValue(4, i + 8, workOrderTemp.PLANEXEDATE.ToShortDateString(), XlHorizontalAlignment.xlLeft);
        //        excel.SetSingelCellValue(5, i + 8, workOrderTemp.COMPLETEDDATE.ToShortDateString(), XlHorizontalAlignment.xlLeft);
        //        excel.SetSingelCellValue(6, i + 8, workOrderTemp.WORKEXECUTOR, XlHorizontalAlignment.xlLeft);
        //        excel.SetSingelCellValue(7, i + 8, workOrderTemp.WORKCOMPLETEDINFO, XlHorizontalAlignment.xlLeft);
        //    }
        //    excel.RowAutoFit(8, 8 + i);
        //    excel.SaveDocument(path2);
        //    excel.CloseDocument();
        //    Excel.release(excel.pt);

        //    File.Copy(path2, path);
        //    ourFile ofile;
        //    if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.DECKWORKMONTHFINISH,
        //        false, "", "", DateTime.Today, CommonOperation.ConstParameter.UserName, shipId, model.ModelFile, f.FullName, out ofile, out err))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        openFile opf = new openFile();
        //        opf.FileOpen(ofile, right.U);
        //    }
        //    return true;
        //} 
        #endregion
        #region 甲板和轮机部月度保养计划执行表

        /// <summary>
        /// 甲板和轮机部月度保养计划执行表.
        /// </summary>
        public bool customMonthlyCompleteReport(string shipId, int year, int month, List<string> lstPost, int departmentType, out string err)
        {
            err = "";
            //string sql = "";

            DateTime fromDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);

            List<WorkOrder> lstWorkOrders;
            if (!WorkOrderService.Instance.GetWorkOrderOfDate(fromDate, endDate, lstPost, shipId, false,
                out lstWorkOrders, out err))
            {
                err = "获取具体的工单完成情况时出错,\r错误信息为:" + err;
            }
            ShipInfo shipinfo = (ShipInfo)(ShipInfoService.Instance.GetOneObjectById(shipId));
            WorkInfo workInfoTemp = null;
            string lastWorkOrderName = "";

            string[,] tableData = new string[lstWorkOrders.Count, 6];
            for (int i = 0; i < lstWorkOrders.Count; i++)
            {
                WorkOrder workOrderTemp = lstWorkOrders[i];
                if (workOrderTemp.TheWorkInfo != null)
                    workInfoTemp = workOrderTemp.TheWorkInfo;
                lastWorkOrderName = workOrderTemp.WORKORDERNAME;

                string workinfodetail = "";
                if (workOrderTemp.TheWorkInfo == null || workOrderTemp.TheWorkInfo.IsWrong)
                    workinfodetail = workOrderTemp.WORKORDERNAME + ":" + workOrderTemp.WORKDESCRIPTION;
                else
                    if (workOrderTemp.TheWorkInfo.WORKINFODETAIL.Contains(workOrderTemp.TheWorkInfo.WORKINFONAME))
                        workinfodetail = workOrderTemp.TheWorkInfo.WORKINFODETAIL;
                    else
                        workinfodetail = workOrderTemp.TheWorkInfo.WORKINFONAME + ":" + workOrderTemp.TheWorkInfo.WORKINFODETAIL;
                if (workInfoTemp != null && workInfoTemp.WORKINFOCODE != null)
                {
                    //同一个月完成的，不算超期。
                    tableData[i, 0] = (workOrderTemp.PLANEXEDATE < workOrderTemp.COMPLETEDDATE
                        && (workOrderTemp.PLANEXEDATE.Month != workOrderTemp.COMPLETEDDATE.Month
                        || workOrderTemp.PLANEXEDATE.Year != workOrderTemp.COMPLETEDDATE.Year
                        ) ? "Y " : "") + workInfoTemp.WORKINFOCODE;
                }
                tableData[i, 1] = workinfodetail + "\r" + workOrderTemp.WORKDESCRIPTION;
                tableData[i, 2] = workOrderTemp.PLANEXEDATE.ToShortDateString();
                tableData[i, 3] = (workOrderTemp.COMPLETEDDATE.Year == 0 ? "" : workOrderTemp.COMPLETEDDATE.ToShortDateString());
                tableData[i, 4] = workOrderTemp.WORKEXECUTOR;
                tableData[i, 5] = workOrderTemp.WORKCOMPLETEDINFO;
            }
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.OnceInsertBoder = true;
                operExcel.SetHorizontal(true);
                operExcel.AddAllColumnSize(1, 15);
                operExcel.AddAllColumnSize(2, 120);
                operExcel.AddAllColumnSize(3, 330);
                operExcel.AddAllColumnSize(4, 120);
                operExcel.AddAllColumnSize(5, 120);
                operExcel.AddAllColumnSize(6, 120);
                operExcel.AddAllColumnSize(7, 330);
                operExcel.AddAllColumnSize(8, 15);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 1, 2, lstWorkOrders.Count, 6, false, XlHorizontalAlignment.xlLeft, new Font("宋体", 9), true), out err))
                {
                    return false;
                }

                #region SetHeaderFooter
                List<OneUnit> theHeader = new List<OneUnit>();
                theHeader.Add(new OneUnit("SITC04综合操作须知                                                                                             第63页", false, 2, 2, 1, 6, false, true, false, XlHorizontalAlignment.xlCenter, pageHeaderFont, XLPattern.xlPatternNone, Color.Gray));
                theHeader.Add(new OneUnit("月度维修保养计划及完成记录表", false, 3, 2, 1, 6, false, false, XlHorizontalAlignment.xlCenter, titleFont));
                theHeader.Add(new OneUnit("编号：100107-3", false, 4, 2, 1, 6, false, false, XlHorizontalAlignment.xlCenter, bodyFont));
                theHeader.Add(new OneUnit("船名：" + shipinfo.SHIP_NAME + "       部门:" + (departmentType == 1 ? "甲板部" : "轮机部"), false, 5, 2, 1, 3, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theHeader.Add(new OneUnit("年度：" + year.ToString() + "        月份:" + month.ToString(), false, 5, 6, 1, 2, false, false, XlHorizontalAlignment.xlRight, bodyFont));
                theHeader.Add(new OneUnit("项目", false, 6, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                theHeader.Add(new OneUnit("检修内容", false, 6, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                theHeader.Add(new OneUnit("本月计划检修日期", false, 6, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                theHeader.Add(new OneUnit("实际完成时间", false, 6, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                theHeader.Add(new OneUnit("检修负责人", false, 6, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                theHeader.Add(new OneUnit("检修情况及存在问题", false, 6, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                List<int> headerHeight = new List<int>();
                headerHeight.Add(5);
                headerHeight.Add(10);
                headerHeight.Add(30);
                headerHeight.Add(15);
                headerHeight.Add(15);
                headerHeight.Add(30);

                List<OneUnit> theFooter = new List<OneUnit>();
                theFooter.Add(new OneUnit("部门负责人：", false, 1, 4, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("船长：", false, 1, 7, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("注：", false, 2, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("1.项目号按年度计划项目填写。", false, 2, 3, 1, 5, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("2.上月遗留工程列入本月计划,在原项目号前加“Y”。", false, 3, 3, 1, 5, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("3.本表由部门负责人填写，一式二份，报机务主管一份，船舶存一份。", false, 4, 3, 1, 5, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                theFooter.Add(new OneUnit("  Controlled Copy                                                 Rev.1.0                                                 Do Not Duplicate", false, 5, 2, 1, 6, false, false, false, XlHorizontalAlignment.xlCenter, pageFooterFont, XLPattern.xlPatternGray16, Color.Gray));
                theFooter.Add(new OneUnit("", false, 6, 1, 1, 1, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
                List<int> footerHeight = new List<int>();
                footerHeight.Add(15);
                footerHeight.Add(15);
                footerHeight.Add(15);
                footerHeight.Add(15);
                footerHeight.Add(10);
                footerHeight.Add(3);

                HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, 1, headerHeight, footerHeight);
                operExcel.AddHeaderAndFooter(oneHeaderAndFooter);
                operExcel.SetPageFillGrid(true, 2, 7, 20);
                #endregion
                FrmOurReport frm = new FrmOurReport((departmentType == 1 ? "甲板部" : "轮机部") + "月度维修保养计划及完成记录表", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            return true;
        }
        #endregion
        public bool customShipCertificationReport(ShipInfo shipInfo, List<ShipCert> allReportCert,
              List<ShipCertRegister> lstCertsOfOneShip, WorkModelType model, string path, out string err)
        {
            err = "";
            //得到所有需要输出的证书列,
            List<CustomerTableClass> allConfigCertNames;
            int useCount;
            if (!CustomerTableClassService.Instance.GetACustomerTableConfigerGroup(CommonPrintTableName.CTNOfShipCertification,
                out allConfigCertNames, out useCount, out err))
            {
                err = "获取过当前表格的配置项时出错，错误信息为：" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (!f.Exists)
            {
                err = "传入的文件路径下并不存在实际文件,无法继续操作文件,\r路径为" + path;
                return false;
            }
            int rowIndexStart = 7;
            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path);
            //前配置的证书列必须按照要求打印,
            int i = 0;
            foreach (ShipCertRegister scrTemp in lstCertsOfOneShip)
            {
                if (i >= 4)
                {
                    excel.CopyRowToRow(i + rowIndexStart - 3, i + rowIndexStart);
                }
                //当前行赋值粘贴出一行,
                excel.SetSingelCellValue(2, i + rowIndexStart, (i + 1).ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(3, i + rowIndexStart, scrTemp.SHIP_CERT_NAME, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, i + rowIndexStart, (scrTemp.EFFECTDATE > 0 ? (decimal.Ceiling(scrTemp.EFFECTDATE) == scrTemp.EFFECTDATE ?
                    ((int)(scrTemp.EFFECTDATE)).ToString() : scrTemp.EFFECTDATE.ToString()) + "年" : "长期"), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(5, i + rowIndexStart, scrTemp.SHIPCERTNUMB, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, i + rowIndexStart, scrTemp.PLACE, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, i + rowIndexStart, scrTemp.SIGNEDDATE.ToShortDateString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(8, i + rowIndexStart, scrTemp.MATUREDATE.ToShortDateString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(9, i + rowIndexStart, scrTemp.EXPIREDATE.ToShortDateString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(10, i + rowIndexStart, scrTemp.REMARK, XlHorizontalAlignment.xlLeft);
                i++;
            }
            //多余的非定制的证书需要一次按照sortno打印.
            excel.SaveDocument(path);
            excel.CloseDocument();
            Excel.release(excel.pt);
            return true;
        }
    }
}
