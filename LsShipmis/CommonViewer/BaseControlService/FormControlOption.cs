using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using CommonViewer.BaseControl;

namespace CommonViewer.BaseControlService
{
    public class FormControlOption
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FormControlOption instance = new FormControlOption();
        public static FormControlOption Instance
        {
            get
            {
                if (null == instance)
                {
                    FormControlOption.instance = new FormControlOption();
                }
                return FormControlOption.instance;
            }
        }
        private FormControlOption() { }
        #endregion

        public void EnableOrDisableCtrls(TableLayoutPanel tbLayPanel, bool blEnable)
        {
            foreach (Control control in tbLayPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox curTxt = (TextBox)control;
                    if (curTxt.ReadOnly == false)
                    {
                        curTxt.Enabled = blEnable;
                    }
                }
                else
                {
                    control.Enabled = blEnable;
                }
            }
        }

        /// <summary>
        /// 给指定的下拉列表框cbo设置下拉列表值.
        /// </summary>
        /// <param name="cbo">ComboBox控件</param>
        /// <param name="dictValue">包含值与名称的Dictionary集合</param>
        public void SetComboBoxValue(ComboBox cbo, Dictionary<string, string> dictValue)
        {
            DataTable dtbForCbo = new DataTable();
            dtbForCbo.Columns.Add("Value", typeof(string));
            dtbForCbo.Columns.Add("Name", typeof(string));

            if (dictValue.Count >= 0)
            {
                foreach (string curKey in dictValue.Keys)
                {
                    DataRow theRow = dtbForCbo.NewRow();
                    theRow["Value"] = curKey;
                    theRow["Name"] = dictValue[curKey];
                    dtbForCbo.Rows.Add(theRow);
                }

                cbo.DataSource = dtbForCbo;
                cbo.DisplayMember = "Name";
                cbo.ValueMember = "Value";
            }
        }

        /// <summary>
        /// 给指定的下拉列表框cbo设置下拉列表值.
        /// </summary>
        /// <param name="cbo">ComboBox控件</param>
        /// <param name="dtb">要绑定的包含数据的DataTable对象</param>
        public void SetComboBoxValue(ComboBox cbo, DataTable dtb)
        {
            SetComboBoxValue(cbo, dtb, 0, 1);
        }

        public void SetComboBoxValue(ComboBox cbo, DataTable dtb, int valueRow, int showRow)
        {
            string valueFld = "";
            string nameFld = "";

            if (dtb.Columns.Count < 2)
            {
                MessageBoxEx.Show("给定的DataTable对象的列数必须至少有两列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dtb.Columns.Count <= valueRow || dtb.Columns.Count <= showRow || valueRow < 0 || showRow < 0)
            {
                MessageBoxEx.Show("给定的DataTable对象的列数与参数不匹配", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                valueFld = dtb.Columns[valueRow].ColumnName;
                nameFld = dtb.Columns[showRow].ColumnName;
            }

            if (dtb.Rows.Count >= 0)
            { 
                cbo.DisplayMember = nameFld;
                cbo.ValueMember = valueFld;
                cbo.DataSource = dtb;
               
            }
        }
        public void SetComboBoxValue(ComboBox cbo, DataTable dtb, string valueColumn, string showColumn)
        {  
            if (!dtb.Columns.Contains(valueColumn) || !dtb.Columns.Contains(showColumn) )
            {
                MessageBoxEx.Show("给定的DataTable对象的列数与参数不匹配", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 

            if (dtb.Rows.Count >= 0)
            {
                cbo.DataSource = dtb;
                cbo.DisplayMember = showColumn;
                cbo.ValueMember = valueColumn;
            }
        }
    }
}
