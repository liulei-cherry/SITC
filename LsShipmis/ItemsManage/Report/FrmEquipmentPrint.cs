/*
 *徐正本，2011年6月13日 
 * 
 *展示的不同之处
 *1:船舶，
 *  标题显示，某某船的设备明细表（轮机部分）；等轮机结束后，新一页显示 某某船的设备明细表（电气部分）
 *  内容显示，
 *      先显示系统，单独一行，靠左显示，字体用黑体加粗
 *      在显示设备装置，左边列设备是一组的，后面下级具体设备是单条的，再下级设备不显示
 *2：部门，只显示船舶中的一个部分，内容同上
 *3：系统，
 *  标题显示 某某船***系统的设备明细表
 *  内容显示，不总领一行系统内容，因为标题中已经有了，其它同上；
 *4：设备分类
 *  标题显示 某某船***分类的设备明细 
 *  内容同3.
 * 注意，分类这一级不再显示。
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using CommonViewer.BaseControlService;
using ItemsManage.DataObject;
using BaseInfo.Objects;
using CommonViewer.BaseControl;
using OfficeOperation;
using ItemsManage.Services;
using BaseInfo.DataAccess;
using System.Runtime.InteropServices;

namespace ItemsManage.Report
{
    public partial class FrmEquipmentPrint : FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmEquipmentPrint instance = new FrmEquipmentPrint();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmEquipmentPrint Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmEquipmentPrint.instance = new FrmEquipmentPrint();
                }
                return FrmEquipmentPrint.instance;
            }
        }
        #endregion
        bool addHeaderFooter = true;
        Font titleFont = new Font("宋体", 20, FontStyle.Bold);
        Font tableHeadFont = new Font("宋体", 10, FontStyle.Bold);
        Font systemFont = new Font("黑体", 12, FontStyle.Bold);
        Font bodyFont = new Font("宋体", 8);
        List<string> allRowName = new List<string>();
        private FrmEquipmentPrint()
        {
            InitializeComponent();
            allRowName.Add("设备");
            allRowName.Add("中英文名称");
            allRowName.Add("型号");
            allRowName.Add("技术参数");
            allRowName.Add("国家,厂商");
            allRowName.Add("序列号");
            allRowName.Add("出厂日期");
            allRowName.Add("设备证书");
            allRowName.Add("船检编码");
            allRowName.Add("大修时间");
        }

        private void FrmEquipmentPrint_Load(object sender, EventArgs e)
        {
            ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
            //按照默认值显示列,而非默认值中只允许设备证书\船检编码\大修时间三个列显示.
            //设备\中英文名称\型号\技术参数\4个列不允许去除,默认字段还有国家\厂商,编号(实际是设备序列号),出厂日期.
        }

        int nowLine = 0;
        private OperationExcel reloading()
        {
            addHeaderFooter = checkBox10.Checked;
            // if (operationExcel != null) operationExcel.Dispose();
            int showType = -1;//-1:无效，1：船舶，2：部门，3：系统，4：设备分类.

            string shipId;
            string err;
            EquipmentClass theClass;
            #region 获取当前用户选定内容
            TreeNode temp = ucEquipmentClassTreeWithEquipment1.SelectedNode;
            if (temp == null || temp.Tag == null)
            {
                MessageBoxEx.Show("请选择具体打印内容");
                return null;
            }
            if (temp.Tag.GetType() == typeof(ComponentUnit))
            {
                ComponentUnit equipment = (ComponentUnit)temp.Tag;
                shipId = equipment.SHIP_ID;
                while (temp.Parent != null && temp.Parent.Tag != null && temp.Parent.Tag.GetType() != typeof(EquipmentClass))
                {
                    temp = temp.Parent;
                }
                if (temp.Parent.Tag.GetType() != typeof(EquipmentClass))
                {
                    throw new Exception("Ex11061401");
                }
                theClass = (EquipmentClass)temp.Parent.Tag;
                showType = 4;
            }
            else if (temp.Tag.GetType() == typeof(ShipInfo))
            {
                shipId = ((ShipInfo)temp.Tag).GetId();
                showType = 1;
                theClass = null;
            }
            else if (temp.Tag.GetType() == typeof(EquipmentClass))
            {
                theClass = (EquipmentClass)temp.Tag;
                while (temp.Parent != null)
                {
                    temp = temp.Parent;
                }
                if (temp != null && temp.Tag != null && temp.Tag.GetType() == typeof(ShipInfo))
                    shipId = ((ShipInfo)temp.Tag).GetId();
                else
                    throw new Exception("Ex11061402");
                showType = (int)theClass.CLASSTYPE + 1;
            }
            else
            {
                throw new Exception("Ex11061403");
            }
            #endregion
            ShipInfo theShip = ShipInfoService.Instance.getObject(shipId, out err);
            if (theShip == null || theShip.IsWrong)
            {
                MessageBoxEx.Show("无法正确获取船舶信息");
                return null;
            }
            List<OneUnit> allColumn;
            Dictionary<int, int> allColumnSize;

            nowLine = 0;
            OperationExcel operationExcel = new OperationExcel();
            operationExcel.OnceInsertBoder = true;
            operationExcel.ColumnsToReMerge.Add(2);
            values = new List<string[]>();
            getAllColumnsUnitSet(out allColumn, out allColumnSize);
            if (frm != null)
            {
                operationExcel.ChangeStepView = new OperationExcel.changeStepView(frm.ChangeStep);
                frm.ChangeStep("准备导出到Excel", 1);
            }
            operationExcel.SetHorizontal(true);
            foreach (int key in allColumnSize.Keys)
            {
                operationExcel.AddAllColumnSize(key, allColumnSize[key]);
            }

            switch (showType)
            {
                case 1:
                    #region 依次查询所有的部门，是否存在记录。存在则调用 insertOneDepartData
                    List<EquipmentClass> lstAllClass = EquipmentClassService.Instance.GetObjectsByParentId("", false, theShip.GetId());
                    if (lstAllClass.Count == 0)
                    {
                        MessageBoxEx.Show("当前船舶没有进行设备分类,或没有进行设备初始化,无法打印输出!");
                    }
                    else
                    {
                        foreach (EquipmentClass tempClass in lstAllClass)
                        {
                            pushOnce(allColumn, nowLine, 2, ref operationExcel);
                            insertOneDepartData(allColumn, allColumnSize, ref operationExcel, tempClass, theShip);
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region 判断当前部门是否有记录，如果不存在则报警，否则调用insertOneDepartData
                    insertOneDepartData(allColumn, allColumnSize, ref operationExcel, theClass, theShip);
                    #endregion
                    break;
                case 3:
                    #region 先添加表头： 某某船***系统的设备明细表
                    if (addHeaderFooter) addHeader(theShip.ToString() + theClass.CLASSNAME + "系统的设备明细表", allColumn, allColumnSize.Count, 1, operationExcel);
                    else
                    {
                        if (!operationExcel.InsertABodyUnit(new OneUnit(theShip.ToString() + theClass.CLASSNAME + "系统的设备明细表",
                            false, ++nowLine, 2, 1, allColumnSize.Count - 1, false, false, XlHorizontalAlignment.xlCenter, titleFont), out err))
                            return null;
                        addOneLineColumns(allColumn, ++nowLine, ref operationExcel);
                    }
                    #endregion
                    //再添加表体.
                    insertOneSystemData(allColumn, allColumnSize, ref operationExcel, theClass, theShip);
                    break;
                case 4:
                    #region 先添加表头： 某某船***分类的设备明细表
                    //得到所有下级设备，如果什么都没有则报警 存在则调用insertOneSystemData
                    if (addHeaderFooter)
                    {
                        addHeader(theShip.ToString() + theClass.CLASSNAME + "分类的设备明细表", allColumn, allColumnSize.Count, 1, operationExcel);
                    }
                    else
                    {
                        if (!operationExcel.InsertABodyUnit(new OneUnit(theShip.ToString() + theClass.CLASSNAME + "分类的设备明细表",
                            false, ++nowLine, 2, 1, allColumnSize.Count - 1, false, false, XlHorizontalAlignment.xlCenter, titleFont), out err))
                            return null;
                        addOneLineColumns(allColumn, ++nowLine, ref operationExcel);
                    }
                    #endregion
                    //再添加表体.

                    insertOneSystemData(allColumn, allColumnSize, ref operationExcel, theClass, theShip);
                    break;
            }
            pushOnce(allColumn, nowLine, 2, ref operationExcel);
            return operationExcel;
        }

        private void addHeader(string headerMainName, List<OneUnit> allUnit, int columnsCount, int fromLine, OperationExcel operationExcel)
        {
            if (fromLine <= 0) fromLine = 1;
            List<OneUnit> theHeader = new List<OneUnit>();
            theHeader.Add(new OneUnit(headerMainName, false, 1, 1, 1, columnsCount, false, true, XlHorizontalAlignment.xlCenter, titleFont));
            theHeader.Add(new OneUnit("打印日期:" + DateTime.Today.ToShortDateString(), false, 2, 2, 1, columnsCount > 4 ? 2 : 1,
                false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theHeader.Add(new OneUnit("第##Page##页/共##PageCount##页", false, 2, columnsCount > 4 ? columnsCount - 1 : columnsCount, 1,
                columnsCount > 4 ? 2 : 1, false, false, XlHorizontalAlignment.xlRight, bodyFont));
            List<OneUnit> theFooter = new List<OneUnit>();
            theFooter.Add(new OneUnit("编译:" + CommonOperation.ConstParameter.UserName, false, 1, 2, 1, 2, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            List<int> headerHeight = new List<int>();
            headerHeight.Add(40);
            headerHeight.Add(22);
            headerHeight.Add(22);
            theHeader.AddRange(allUnit);
            List<int> footerHeight = new List<int>();
            footerHeight.Add(22);
            footerHeight.Add(2);
            HeaderAndFooter oneHeaderAndFooter = new HeaderAndFooter(theHeader, theFooter, fromLine, headerHeight, footerHeight);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter);
        }

        private void getAllColumnsUnitSet(out List<OneUnit> allUnit, out Dictionary<int, int> allColumnSize)
        {
            allUnit = new List<OneUnit>();
            allColumnSize = new Dictionary<int, int>();
            List<int> listAllColumnSize = new List<int>();
            //必填内容.
            //选填内容.
            //计算单元格大小.
            //最多1设备\2中英文名称\3型号\4技术参数 \5国家,厂商\6序列号\7出厂日期\8设备证书\9船检编码\10大修时间.
            //固定宽度 1(90)2(153)3(98)4(不定长)5(121)6(105)7(90)8(118)9(80)10(90)
            int i = 5;
            allUnit.Add(new OneUnit(allRowName[0], false, 3, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            allUnit.Add(new OneUnit(allRowName[1], false, 3, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            allUnit.Add(new OneUnit(allRowName[2], false, 3, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            //allUnit.Add(new OneUnit(allRowName[3], false, 3, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            listAllColumnSize.Add(20);
            listAllColumnSize.Add(90);
            listAllColumnSize.Add(153);
            listAllColumnSize.Add(98);
            //listAllColumnSize.Add(50);
            if (checkBox9.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[3], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(50);
                i++;
            }
            if (checkBox1.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[4], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(121);
                i++;
            }
            if (checkBox2.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[5], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(105);
                i++;
            }
            if (checkBox3.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[6], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(90);
                i++;
            }
            if (checkBox4.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[7], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(118);
                i++;
            }
            if (checkBox5.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[8], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(80);
                i++;
            }
            if (checkBox6.Checked)
            {
                allUnit.Add(new OneUnit(allRowName[9], false, 3, i, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
                listAllColumnSize.Add(90);
                i++;
            }
            //如果选了所有列,太多,则所有列都稍微压缩一下,给技术参数让位.

            int para = 1130;
            for (int r = 1; r <= listAllColumnSize.Count; r++)
            {
                if (r != 5 || !checkBox9.Checked)
                {
                    allColumnSize.Add(r, listAllColumnSize[r - 1]);
                    para = para - allColumnSize[r];
                }
            }
            if (checkBox9.Checked)
            {
                if (para > 300)
                {
                    if (checkBox3.Checked)
                    {
                        int paraMore = para - 300;
                        allColumnSize[3] = allColumnSize[3] + paraMore / 2;
                        allColumnSize[6] = allColumnSize[6] + paraMore / 2;
                        allColumnSize.Add(5, 300);
                    }
                    else
                    {
                        int paraMore = para - 400;
                        allColumnSize[3] = allColumnSize[3] + paraMore;
                        allColumnSize.Add(5, 400);
                    }
                }
                else
                {
                    allColumnSize.Add(5, para);
                }
            }
            else
            {
                if (checkBox3.Checked && checkBox1.Checked)
                {
                    allColumnSize[3] = allColumnSize[3] + para / 2;
                    allColumnSize[4] = allColumnSize[4] + para / 6;
                    allColumnSize[5] = allColumnSize[5] + para / 3;
                }
                else
                {

                    allColumnSize[3] = allColumnSize[3] + para * 2 / 3;
                    allColumnSize[4] = allColumnSize[4] + para / 3;
                }
            }
        }

        /// <summary>
        /// 往当前位置添加一行标题头.
        /// </summary>
        private void addOneLineColumns(List<OneUnit> allHeader, int line, ref OperationExcel theOperationExcel)
        {
            Application.DoEvents();
            string err;
            string[,] headers = new string[1, allHeader.Count];
            for (int i = 0; i < allHeader.Count; i++)
            {
                headers[0, i] = allHeader[i].ToString();
            }
            if (!theOperationExcel.InsertATable(new OneTable(headers, false, line, 2, 1, allHeader.Count, false, XlHorizontalAlignment.xlCenter), out err)) return;
        }

        private List<string[]> values = new List<string[]>();

        /// <summary>
        /// 将当前的table形成一个版本然后push给excel,构造一个新版本.
        /// </summary>
        /// <param name="theOperationExcel"></param>
        private void pushOnce(List<OneUnit> allColumn, int fromLine, int fromColumn, ref OperationExcel theOperationExcel)
        {
            Application.DoEvents();
            if (values != null && values.Count > 0)
            {
                string[,] valuesNew = new string[values.Count, allColumn.Count];
                for (int i = 0; i < values.Count; i++)
                    for (int r = 0; r < allColumn.Count; r++)
                        valuesNew[i, r] = values[i][r];
                string err;
                if (!theOperationExcel.InsertATable(new OneTable(valuesNew, false, fromLine + 1, fromColumn,
                    values.Count, allColumn.Count, false, XlHorizontalAlignment.xlLeft, bodyFont), out err))
                    return;
            }
            nowLine += values.Count;
            values = new List<string[]>();

        }

        /// <summary>
        /// 插入一个部门的所有内容.
        /// </summary>
        /// <param name="allUnit"></param>
        /// <param name="allColumnSize"></param>
        /// <param name="theOperationExcel"></param>
        /// <param name="theEquipmentClass"></param>
        /// <param name="theShip"></param>
        private void insertOneDepartData(List<OneUnit> allUnit, Dictionary<int, int> allColumnSize, ref OperationExcel theOperationExcel, EquipmentClass theEquipmentClass, ShipInfo theShip)
        {
            string err;
            List<EquipmentClass> lstAllClass = EquipmentClassService.Instance.GetObjectsByParentId(theEquipmentClass.GetId(), false, theShip.GetId());
            pushOnce(allUnit, nowLine, 2, ref theOperationExcel);
            #region 当前位置需要插入标题

            if (addHeaderFooter)
                addHeader(theShip.ToString() + "的设备明细表(" + theEquipmentClass.CLASSNAME + "部分)", allUnit, allColumnSize.Count, nowLine + 1, theOperationExcel);
            else
            {
                if (!theOperationExcel.InsertABodyUnit(new OneUnit(theShip.ToString() + "的设备明细表(" + theEquipmentClass.CLASSNAME + "部分)",
                    false, ++nowLine, 2, 1, allColumnSize.Count - 1, false, false, XlHorizontalAlignment.xlCenter, systemFont), out err))
                    return;
            }
            #endregion
            #region 插入内容 此部分内容插入与直接插入一个系统的顺序相同,因此直接调用插入一个系统内容即可

            foreach (EquipmentClass oneClass in lstAllClass)
            {
                pushOnce(allUnit, nowLine, 2, ref theOperationExcel);
                if (!theOperationExcel.InsertABodyUnit(new OneUnit(oneClass.CLASSNAME, false, ++nowLine,
                    2, 1, allColumnSize.Count - 1, false, false, XlHorizontalAlignment.xlCenter, systemFont), out err))
                    return;
                if (!theOperationExcel.InsertABodyUnit(new OneUnit("", false, ++nowLine,
                   2, 1, allColumnSize.Count - 1, false, false, XlHorizontalAlignment.xlCenter, systemFont), out err))
                    return;
                theOperationExcel.AddAllLineSize(nowLine, 0);
                if (!addHeaderFooter) addOneLineColumns(allUnit, ++nowLine, ref theOperationExcel);
                insertOneSystemData(allUnit, allColumnSize, ref theOperationExcel, oneClass, theShip);
            }
            #endregion
        }

        /// <summary>
        /// 插入一个系统的所有内容.
        /// 先看系统下的直接设备,然后再展示系统下的其他分类下的设备,如果这些位置均不存在数据,则直接退出.
        /// </summary>
        /// <param name="allUnit"></param>
        /// <param name="allColumnSize"></param>
        /// <param name="theOperationExcel"></param>
        /// <param name="theEquipmentClass"></param>
        /// <param name="theShip"></param>
        private void insertOneSystemData(List<OneUnit> allUnit, Dictionary<int, int> allColumnSize, ref OperationExcel theOperationExcel, EquipmentClass theEquipmentClass, ShipInfo theShip)
        {
            List<EquipmentClass> lstAllClass = EquipmentClassService.Instance.GetObjectsByParentId(theEquipmentClass.GetId(), false, theShip.GetId());
            List<ComponentUnit> lstAllUnit = EquipmentClassService.Instance.GetClassifiedEquipmentByClassId(theEquipmentClass.GetId(), theShip.GetId());
            //如果所有下级设备都没有子设备，则将分类名称显示出，其他情况，则分别进入各个设备进行展示。.

            if (lstAllUnit.Count > 0 && !ComponentUnitService.Instance.GetListEquipmentHaveSubEquip(lstAllUnit))
            {
                realInertEquipmentData(allUnit, theEquipmentClass.CLASSNAME, lstAllUnit);
            }
            else
            {
                foreach (ComponentUnit oneEquipment in lstAllUnit)
                {
                    Application.DoEvents();
                    List<ComponentUnit> lstAllSubUnit = ComponentUnitService.Instance.GetListComponentByParentId(oneEquipment.GetId());
                    //如果没有下级,则把自己当自己的下级展示.
                    oneEquipment.FillThisObject();
                    bool find = false;
                    foreach (ComponentUnit oneItem in lstAllSubUnit)
                    {
                        oneItem.FillThisObject();
                        if (oneEquipment.TheComponentType.COMPONENT_STYLE.Equals(oneItem.TheComponentType.COMPONENT_STYLE))
                        {
                            find = true;
                            break;
                        }
                    }
                    if (!find) lstAllSubUnit.Insert(0, oneEquipment);
                    //if (lstAllSubUnit.Count <= 1 && !string.IsNullOrEmpty (oneEquipment.TheComponentType.COMPONENT_STYLE) )
                    //    lstAllSubUnit.Insert(0,oneEquipment);
                    realInertEquipmentData(allUnit, oneEquipment.COMP_CHINESE_NAME, lstAllSubUnit);
                }
            }
            foreach (EquipmentClass oneClass in lstAllClass)
            {
                insertOneSystemData(allUnit, allColumnSize, ref theOperationExcel, oneClass, theShip);
            }
        }
        /// <summary>
        /// 真正往Excel中插入的函数，现在有两种情况.
        /// 1。设备分类下的设备全是一级的，则用设备分类起头，.
        /// 2。设备下级还有子设备的，用父设备起头。.
        /// </summary>
        /// <param name="allUnit"></param>
        /// <param name="allColumnSize"></param>
        /// <param name="isEquipmentClass"></param>
        /// <param name="ParentsName"></param>
        /// <param name="allEquipments"></param>
        /// <param name="theOperationExcel"></param>
        private void realInertEquipmentData(List<OneUnit> allUnit, string ParentsName, List<ComponentUnit> allEquipments)
        {
            #region 插入下级设备内容
            for (int i = 0; i < allEquipments.Count; i++)
            {
                ComponentUnit tempEquip = allEquipments[i];
                int row = values.Count;
                values.Add(new string[allUnit.Count]);
                values[row][0] = ParentsName;
                for (int r = 0; r < allUnit.Count; r++)
                {
                    Application.DoEvents();
                    tempEquip.FillThisObject();
                    ComponentType theTypeOfThisUnit = tempEquip.TheComponentType;
                    if (allUnit[r].ToString() == allRowName[1])//allRowName.Add("中英文名称");
                    {
                        values[row][r] = tempEquip.ToString();
                    }
                    else if (allUnit[r].ToString() == allRowName[2]) //allRowName.Add("型号");
                    {
                        values[row][r] = theTypeOfThisUnit.COMPONENT_STYLE;
                    }
                    if (allUnit[r].ToString() == allRowName[3])//allRowName.Add("技术参数");
                    {
                        values[row][r] = theTypeOfThisUnit.DETAIL;
                    }
                    else if (allUnit[r].ToString() == allRowName[4]) //allRowName.Add("国家,厂商");
                    {
                        values[row][r] = theTypeOfThisUnit.MANUFACTURER;
                    }
                    else if (allUnit[r].ToString() == allRowName[5])//allRowName.Add("序列号");
                    {
                        values[row][r] = tempEquip.comp_serial_no;
                    }
                    else if (allUnit[r].ToString() == allRowName[6]) //allRowName.Add("出厂日期");
                    {
                        values[row][r] = tempEquip.PRODUCE_TIME.Year != 1 ? tempEquip.PRODUCE_TIME.ToString("yyyy年MM月") : "";
                    }
                    else if (allUnit[r].ToString() == allRowName[7]) //allRowName.Add("设备证书");
                    {
                        values[row][r] = tempEquip.certification;
                    }
                    else if (allUnit[r].ToString() == allRowName[8])//allRowName.Add("船检编码");
                    {
                        values[row][r] = tempEquip.EXAMINATION_CODE;
                    }
                    else if (allUnit[r].ToString() == allRowName[9]) //allRowName.Add("大修时间");
                    {
                        values[row][r] = tempEquip.repair_date.Year != 1 ? tempEquip.repair_date.ToString("yyyy年MM月") : "";
                    }
                }
            }
            #endregion
        }

        FrmBusyWithStep frm;

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //首先选择一个文件路径,成功以后再进行导出操作.       
            if (SaveFileDialogEx.ShowDialog(saveFileDialog1) == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                frm = new FrmBusyWithStep("正在导出Excel文件,\r\n如果导出内容过多可能需要几分钟时间!", new FrmBusyWithStep.FinishedOpeartion(export));
                frm.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("用户取消了操作!");
            }
        }
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

        private void export()
        {
            string err;
            OperationExcel operationExcel = reloading();
            if (operationExcel != null)
            {
                if (!operationExcel.ExportToExcel(saveFileDialog1.FileName, true, out err))
                {
                    MessageBoxEx.Show(err);
                }
                else
                {
                    WinExec("rundll32.exe shell32.dll,OpenAs_RunDLL " + saveFileDialog1.FileName, 5);
                }
            }
            operationExcel.Dispose();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEquipmentPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
