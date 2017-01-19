/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmToolWorkInfo.cs
 * 创 建 人：黄家龙
 * 创建时间：2011-10-18
 * 标    题：PMS初始化打印工具
 * 功能描述：
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using Maintenance.Services;
using Maintenance.DataObject;
using OfficeOperation;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using System.Text.RegularExpressions;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmToolWorkInfo : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmToolWorkInfo instance = new FrmToolWorkInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        /// 
        public static FrmToolWorkInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmToolWorkInfo.instance = new FrmToolWorkInfo();
                }
                return FrmToolWorkInfo.instance;
            }
        }
        #endregion

        #region 窗体引用对象
        private Excel toOperExcel;
        private string shipid = "";

        private FormControlOption other = FormControlOption.Instance;
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmToolWorkInfo()
        {
            InitializeComponent();
        }

        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            reloadData();
            setComboBox();
            string[] sCols = new string[] { "字段名", "字段说明" };
            dgvOne.setDgvColumnsReadOnly(sCols);
        }

        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        #region IFunctionChildWindow 成员

        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.
            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        #region 控件事件区
        /// 导入临时表按钮点击.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImpTempButton_Click(object sender, EventArgs e)
        {
            string filePath;
            string err = "";

            //打开对话框选择excel文件.
            DialogResult theResult = OpenFileDialogEx.ShowDialog(openFileDialog1);

            string fileName = openFileDialog1.FileName;
            //传递给importExcel(Excel toOperExcel)
            if (File.Exists(fileName))
            {
                FileInfo f = new FileInfo(fileName);
                filePath = f.DirectoryName;
                if (toOperExcel != null)
                {
                    toOperExcel.Dispose();
                    Excel.release(toOperExcel.pt);                    
                } 
                    toOperExcel = new Excel();
                try
                {
                    toOperExcel.OpenDocument(fileName);
                    Dictionary<string, string> dic = getMappings();
                    DataTable dt = import(dic, toOperExcel, 1);

                    if (dt.Rows.Count > 0)
                    {
                        T_TOOL_WORKINFOService.Instance.batchInsert(dt, "T_TOOL_WORKINFO", 1, out err);
                    }

                    //FrmBusy frmBusy = new FrmBusy("正在导入所选择的文件内容\r\nNow is loading the file......", new FrmBusy.FinishedOpeartion(importExcel));
                    //frmBusy.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("文件无法打开,可能是用户没有安装Excel,或者没有权限操作选定的文件\n" + ex.Message);
                }

                toOperExcel.CloseDocument();
                Excel.release(toOperExcel.pt);
            }

            if (err.Length > 0)
            {
                MessageBoxEx.Show("导入失败：" + err);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cobShip_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cobShip.SelectedValue != null)
            {
                shipid = cobShip.SelectedValue.ToString();
            }
        }

        #endregion

        #region 私有方法

        private DataTable import(Dictionary<string, string> excelMAPTable, Excel excel, int sheet)
        {
            string err = "";
            DataTable dt = T_TOOL_WORKINFOService.Instance.getInfo(out err).Clone();
            int indexCopy = 1;
            string valueCopy = "";

            while (indexCopy <= Convert.ToInt32(numericUpDown2.Value)) //导入到Excel结束行当前行.
            {
                DataRow row = dt.NewRow();

                if (excelMAPTable.TryGetValue("ORDERNUM_SHOW", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["ORDERNUM_SHOW"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("CLASS1", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["CLASS1"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("CLASS2", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    string tempValue = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                    row["CLASS2"] = string.IsNullOrEmpty(tempValue) ? row["CLASS1"].ToString() : tempValue;
                }

                if (excelMAPTable.TryGetValue("WORKINFONAME", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["WORKINFONAME"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("WORKINFODETAIL", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["WORKINFODETAIL"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("CIRCLEORTIMING_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["CIRCLEORTIMING_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("CIRCLEPERIOD", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    string temp = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                    row["CIRCLEPERIOD"] = string.IsNullOrEmpty(temp) ? 0 : isnum(temp) ? Int32.Parse(temp) : 0;
                }

                if (excelMAPTable.TryGetValue("CIRCLEPERIOD_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["CIRCLEPERIOD_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("TIMINGPERIOD", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    string temp = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                    row["TIMINGPERIOD"] = string.IsNullOrEmpty(temp) ? 0 : isnum(temp) ? Int32.Parse(temp) : 0;
                }

                if (excelMAPTable.TryGetValue("PRINCIPALPOST_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["PRINCIPALPOST_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("CONFIRMPOST_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["CONFIRMPOST_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }
                else
                {
                    row["CONFIRMPOST_INI"] = cobReportType.Text.Equals("甲板部") ? "大副" : "轮机长";
                }

                if (excelMAPTable.TryGetValue("ISCHECKPROJECT_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["ISCHECKPROJECT_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("ISREPAIRPROJECT_INI", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["ISREPAIRPROJECT_INI"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("MONTHS_CHECK", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    string checkChar = checkString();
                    string month_check = "";

                    for (int i = 1; i <= 12; i++)
                    {
                        if (excel.GetRangeValue(1, valueCopy + indexCopy.ToString()).Equals(checkChar)) month_check = month_check + "{" + i + "},";
                        valueCopy = IntToMoreChar(MoreCharToInt(valueCopy) + Convert.ToInt32(numericUpDown1.Value));
                    }
                    if (month_check.Length > 0)
                    {
                        row["MONTHS_CHECK"] = month_check.Substring(0, month_check.Length - 1);
                    }
                    else
                    {
                        row["MONTHS_CHECK"] = month_check;
                    }
                }

                if (excelMAPTable.TryGetValue("ISBAK", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["ISBAK"] = 0;
                }

                if (excelMAPTable.TryGetValue("EX1", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["EX1"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("EX2", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["EX2"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("EX3", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["EX3"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("EX4", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["EX4"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                if (excelMAPTable.TryGetValue("EX5", out valueCopy) && !string.IsNullOrEmpty(valueCopy))
                {
                    row["EX5"] = excel.GetRangeValue(1, valueCopy + indexCopy.ToString());
                }

                //处理船舶id
                if (!string.IsNullOrEmpty(shipid))
                {
                    row["SHIP_ID"] = shipid;
                }

                row["WORKINFOID"] = Guid.NewGuid().ToString();
                row["EXCEL_ORDERNUM"] = indexCopy;
                row["CIRCLEORTIMING"] = 1; //默认定期.
                row["ITEMTYPE"] = "1";
                row["DEPARTMENT_TYPE"] = cobReportType.Text.Equals("甲板部") ? 1 : 2; 
                dt.Rows.Add(row);
                indexCopy++;
                valueCopy = "";
            }
            return dt;
        }

        /// <summary>
        /// 获取映射key-value值.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> getMappings()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            for (int i = 1; i < dgvOne.RowCount; i++)
            {
                dic.Add(dgvOne.Rows[i].Cells[0].Value.ToString(), dgvOne.Rows[i].Cells[2].Value.ToString().ToUpper());
            }
            return dic;
        }

        /// <summary>
        /// 导入整个excel
        /// </summary>
        /// <param name="toOperExcel"></param>
        private void importExcel()
        {
            //得到有多少页,按照页面去分别处理.
            int sheetCount = toOperExcel.GetSheetsCount();
            for (int i = 1; i <= sheetCount; i++)
            {
                //if (!ImportExcelOneSheetToObject(toOperExcel, i)) break;
            }
        }

        /// <summary>
        /// EXCEL列字母转数字.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int MoreCharToInt(string value)
        {
            int rtn = 0;
            int powIndex = 0;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                int tmpInt = value[i];
                tmpInt -= 64;

                rtn += (int)Math.Pow(26, powIndex) * tmpInt;
                powIndex++;
            }

            return rtn;
        }

        /// <summary>
        /// EXCEL列数字转为字母.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string IntToMoreChar(int value)
        {
            string rtn = string.Empty;
            List<int> iList = new List<int>();
            //To single Int             
            while (value / 26 != 0 || value % 26 != 0)
            {
                iList.Add(value % 26);
                value /= 26;
            }
            //Change 0 To 2614           
            for (int j = 0; j < iList.Count - 1; j++)
            {
                if (iList[j] == 0)
                {
                    iList[j + 1] -= 1;
                    iList[j] = 26;
                }
            }
            //Remove 0 at last24            
            if (iList[iList.Count - 1] == 0)
            {
                iList.Remove(iList[iList.Count - 1]);
            }
            //To String30            
            for (int j = iList.Count - 1; j >= 0; j--)
            {
                char c = (char)(iList[j] + 64);
                rtn += c.ToString();
            }
            return rtn;
        }

        private string checkString()
        {
            string temp = "";
            //if(radioButton1.Checked)
            //{
            //    temp = "☻";
            //}
            //else if(radioButton2.Checked)
            //{
            //    temp = "√";
            //}
            //else
            //{
            //    temp = "◎";
            //}
            temp = txtrRemark.Text;
            return temp;
        }

        /// <summary>
        /// 判断一个字符串是否为合法整数(不限制长度)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool isnum(string str)
        {
            string pattern = @"^\d*$";
            return Regex.IsMatch(str, pattern);
        }
        #endregion

        #region 数据初始化区
        private void reloadData()
        {
            DataTable dt;
            string err;
            dt = T_TOOL_WORKINFOService.Instance.getLittleColumnsInfo(out err);
            dgvOne.DataSource = dt;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err;
            DataTable dtbShip = T_TOOL_WORKINFOService.Instance.GetOwnerShip(out err);
            other.SetComboBoxValue(cobShip, dtbShip);
            cobShip.SelectedValueChanged += new EventHandler(cobShip_SelectedValueChanged);
            cobReportType.SelectedIndex = 0;
        }
        #endregion
    }
}