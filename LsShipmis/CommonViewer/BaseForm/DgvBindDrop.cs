/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：DgvBindDrop.cs
 * 创 建 人：李景育 * 创建时间：2007-05-27
 * 标    题：给指定的DataGridView控件的指定列绑定下拉列表框 * 功能描述：给指定的DataGridView控件的指定列绑定下拉列表框 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using CommonViewer.BaseControl;

namespace CommonViewer.BaseForm
{
    /// <summary>
    /// 给指定的DataGridView控件的指定列绑定下拉列表框.
    /// </summary>
    public class DgvBindDrop
    {
        /// <summary>
        /// 是否使用列的index,作为确定列的依据,默认是true,
        /// 其实用列index是不好的方法,经常因为sql语句变化,导致查找失败,但是之前同事是这么写的,很多地方已经这么用了,只好保留.
        /// 推荐使用列名作为索引项.
        /// </summary>
        private bool useColumnsIndex = true;
        private string columnNameForView;
        private string columnNameForUpdate;
        /// <summary>
        /// cmb为定义的Combobox控件，它将代替用户传过来的Combobox控件.
        /// </summary>    
        private ComboBox cmb = new ComboBox();

        /// <summary>
        /// dtpPicker为定义的DateTimePicker控件，它将代替用户传过来的DateTimePicker控件.
        /// </summary>
        private DateTimePicker dtpPicker = new DateTimePicker();

        /// <summary>
        /// dgv为定义的DataGridView控件，它将代替用户传过来的DataGridView控件.
        /// </summary>
        private DataGridView dgv = new DataGridView();

        /// <summary>
        /// 为定义的DataGridView控件的列索引，它将代替用户传过来的columnb变量.
        /// </summary>
        private int columnb = 0;

        /// <summary>
        /// bdType为绑定下拉列表的方式，它将代替用户传过来的bdType变量.
        /// </summary>
        private int bdType = 1;

        /// <summary>
        /// 当前传入的控件类型是否是DateTimePicker
        /// </summary>
        private bool IsDateTimePicker = false;

        /// <summary>
        /// 构造函数,用于初始化时设置下拉列表框不可见.
        /// </summary>
        public DgvBindDrop()
        {
            this.cmb.Visible = false;
            this.dtpPicker.Visible = false;
        }
        /// <summary>
        /// 给指定的DataGridView控件的指定列columnb绑定下拉列表框,下拉列表框的值来自dtb
        /// </summary>
        /// <param name="dgv">用于绑定下拉列表框的DataGridView控件</param>
        /// <param name="dtb">用于为下拉列表框填充值的DataTable对象，需要定义保存值和显示值</param>
        /// <param name="columnb">用于绑定到DataGridView控件的列的索引</param>
        /// <param name="allowEdit">true表示当cmb可手工编辑，false为不可手工编辑</param>
        /// <param name="bdType">1表示绑定Id和名称，2表示仅绑定名称</param>
        public void bindDropToDgv(DataGridView dgv, DataTable dtb, string columnName, string columnNameForUpdate, bool allowEdit, int bdType)
        {
            //设置实例变量DataGridView控件等于用户传过来的变量DataGridView控件,实例变量columnb等于用户传过来的变量columnb
            this.dgv = dgv;
            this.columnNameForView = columnName;
            this.columnNameForUpdate = columnNameForUpdate;
            useColumnsIndex = false;
            this.bdType = bdType;
            bindDropToDgv(dtb, allowEdit);
        }
        /// <summary>
        /// 给指定的DataGridView控件的指定列columnb绑定下拉列表框,下拉列表框的值来自dtb
        /// </summary>
        /// <param name="dgv">用于绑定下拉列表框的DataGridView控件</param>
        /// <param name="dtb">用于为下拉列表框填充值的DataTable对象，需要定义保存值和显示值</param>
        /// <param name="columnb">用于绑定到DataGridView控件的列的索引</param>
        /// <param name="allowEdit">true表示当cmb可手工编辑，false为不可手工编辑</param>
        /// <param name="bdType">1表示绑定Id和名称，2表示仅绑定名称</param>
        public void bindDropToDgv(DataGridView dgv, DataTable dtb, int columnb, bool allowEdit, int bdType)
        {
            //设置实例变量DataGridView控件等于用户传过来的变量DataGridView控件,实例变量columnb等于用户传过来的变量columnb
            this.dgv = dgv;
            this.columnb = columnb;
            this.bdType = bdType;
            bindDropToDgv(dtb, allowEdit);
        }
        private void bindDropToDgv(DataTable dtb, bool allowEdit)
        {
            //定义dgv控件的CurrentCellChanged事件、Scroll事件和ColumnWidthChanged事件.
            dgv.CurrentCellChanged += new System.EventHandler(dgv_CurrentCellChanged);
            dgv.Scroll += new System.Windows.Forms.ScrollEventHandler(dgv_Scroll);
            dgv.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(dgv_ColumnWidthChanged);

            //添加下拉列表框事件.
            //cmb.TextChanged += new System.EventHandler(cmb_TextChanged);
            cmb.TextUpdate += new System.EventHandler(cmb_TextUpdate);
            cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);

            //设置下拉列表框cmb要绑定的数据源dtb
            cmb.ValueMember = dtb.Columns[0].Caption;       //下拉列表框的保存值.
            cmb.DisplayMember = dtb.Columns[1].Caption;     //下拉列表框的显示值.
            cmb.DataSource = dtb;                           //下拉列表框的数据源.

            if (allowEdit)
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDownList; //下拉列表框的下拉样式.
            }

            dgv.Controls.Add(cmb);//把下拉列表框添加到dgv容器中去.
        }

        public void bindDropToDgv(DataGridView dgv, ComboBox cmb, string columnName, string columnNameForUpdate, bool allowEdit, int bdType)
        {
            //设置实例变量DataGridView控件等于用户传过来的变量DataGridView控件,实例变量columnb等于用户传过来的变量columnb
            this.dgv = dgv;
            this.columnNameForView = columnName;
            this.columnNameForUpdate = columnNameForUpdate;
            useColumnsIndex = false;
            this.bdType = bdType;
            this.cmb = cmb;
            bindDropToDgv(cmb, allowEdit);
        }

        /// <summary>
        /// 给指定的DataGridView控件的指定列columnb绑定现成的下拉列表框.
        /// </summary>
        /// <param name="dgv">用于绑定下拉列表框的DataGridView控件</param>
        /// <param name="cmb">用于绑定的现成的ComboBox控件</param>
        /// <param name="columnb">用于绑定到DataGridView控件的列的索引</param>
        /// <param name="allowEdit">true表示当cmb可手工编辑，false为不可手工编辑</param>
        /// <param name="bdType">1表示用Id填充单元格，2表示用名称填充单元格</param>
        public void bindDropToDgv(DataGridView dgv, ComboBox cmb, int columnb, bool allowEdit, int bdType)
        {
            //设置实例变量DataGridView控件等于用户传过来的变量DataGridView控件,实例变量columnb等于用户传过来的变量columnb
            this.dgv = dgv;
            this.columnb = columnb;
            this.bdType = bdType;
            this.cmb = cmb;
            bindDropToDgv(cmb, allowEdit);
        }
        private void bindDropToDgv(ComboBox cmb, bool allowEdit)
        {
            //定义dgv控件的CurrentCellChanged事件、Scroll事件和ColumnWidthChanged事件.
            dgv.CurrentCellChanged += new System.EventHandler(dgv_CurrentCellChanged);
            dgv.Scroll += new System.Windows.Forms.ScrollEventHandler(dgv_Scroll);
            dgv.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(dgv_ColumnWidthChanged);

            //添加下拉列表框事件.
            //cmb.TextChanged += new System.EventHandler(cmb_TextChanged);
            cmb.TextUpdate += new System.EventHandler(cmb_TextUpdate);
            cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);

            if (allowEdit)
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDownList; //下拉列表框的下拉样式.
            }

            dgv.Controls.Add(cmb);//把下拉列表框添加到dgv容器中去.
        }

        public void bindDropToDgv(DataGridView dgv, DateTimePicker dtpPicker, string columnName)
        {
            //设置实例变量columnb等于用户传过来的变量columnb，实例变量DataGridView控件等于用户传过来的变量DataGridView控件.
            this.columnNameForView = columnName;
            this.columnNameForUpdate = columnName;
            useColumnsIndex = false;
            this.dgv = dgv;
            this.dtpPicker = dtpPicker;
            this.IsDateTimePicker = true;
            bindDropToDgv();
        }
        /// <summary>
        /// 给指定的DataGridView控件的指定列columnb绑定现成的下拉列表框.
        /// </summary>
        /// <param name="dgv">用于绑定下拉列表框的DataGridView控件</param>
        /// <param name="dtpPicker">用于绑定的现成的DateTimePicker控件</param>
        /// <param name="columnb">用于绑定到DataGridView控件的列的索引</param>
        /// <param name="IsDateTimePicker">表示当前传入的控件类型是DateTimePicker</param>
        public void bindDropToDgv(DataGridView dgv, DateTimePicker dtpPicker, int columnb)
        {
            //设置实例变量columnb等于用户传过来的变量columnb，实例变量DataGridView控件等于用户传过来的变量DataGridView控件.
            this.columnb = columnb;
            this.dgv = dgv;
            this.dtpPicker = dtpPicker;
            this.IsDateTimePicker = true;
            bindDropToDgv();
        }
        private void bindDropToDgv()
        {
            this.dtpPicker.Value = DateTime.Now;
            //定义dgv控件的CurrentCellChanged事件、Scroll事件和ColumnWidthChanged事件.
            dgv.CurrentCellChanged += new System.EventHandler(dgv_CurrentCellChanged);
            dgv.Scroll += new System.Windows.Forms.ScrollEventHandler(dgv_Scroll);
            dgv.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(dgv_ColumnWidthChanged);

            //添加下日期选择框事件.
            dtpPicker.CloseUp += new EventHandler(dtpPicker_CloseUp);

            //把日期选择框添加到dgv容器中去.
            dgv.Controls.Add(dtpPicker);
        }

        /// <summary>
        /// 当用户选择dgv的列为columnb这一列时单元格显示下拉列表框，.
        /// 因为要在这一列绑定下拉列表框.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.CurrentCell != null && ((useColumnsIndex && dgv.CurrentCell.ColumnIndex == columnb)
                    || (!useColumnsIndex && dgv.Columns[dgv.CurrentCell.ColumnIndex].Name == columnNameForView)))
                {
                    //取得dgv当前单元格的矩形区域大小.
                    Rectangle rect = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false);

                    if (dgv.CurrentCell.Value == null) return;
                    //设置下拉列表框中的显示值为dgv当前单元格的值.
                    string sexValue = dgv.CurrentCell.Value.ToString();

                    if (this.IsDateTimePicker == false)
                    {
                        //设置下拉列表框的矩形区域大小等于dgv当前单元格的矩形区域大小.
                        cmb.Text = sexValue;
                        cmb.Left = rect.Left;
                        cmb.Top = rect.Top;
                        cmb.Width = rect.Width;
                        cmb.Height = rect.Height;
                        cmb.Visible = true;//设置下拉列表框可见.
                    }
                    else if (this.IsDateTimePicker == true)
                    {
                        //如果当前单元格只读，表示当前单元格不需要绑定日期下拉列表框.
                        if (dgv.CurrentCell.ReadOnly == true)
                        {
                            return;
                        }

                        //设置下拉列表框的矩形区域大小等于dgv当前单元格的矩形区域大小.
                        if (sexValue != "")
                        {
                            dtpPicker.Value = DateTime.Parse(sexValue);
                        }

                        dtpPicker.Left = rect.Left;
                        dtpPicker.Top = rect.Top;
                        dtpPicker.Width = rect.Width;
                        dtpPicker.Height = rect.Height;
                        dtpPicker.Visible = true;//设置下拉列表框可见.
                    }

                }
                else
                {
                    cmb.Visible = false;//如果当前单元格所在的列不是要绑定的列，则隐藏下拉列表框控件cmb
                    dtpPicker.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }

        /// <summary>
        /// 滚动DataGridView时将下拉列表框设为不可见.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            cmb.Visible = false;
            dtpPicker.Visible = false;
        }

        /// <summary>
        /// 当用户改变下拉列表框的值时（包括手工编辑），将同时改变DataGridView单元格的内容.
        /// 这个事件比SelectedIndexChanged连动性更强，效果更好.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_TextUpdate(object sender, EventArgs e)
        {
            if (dgv.CurrentCell != null)
            {
                if (bdType == 1)
                {
                    //设置当前单元格的值为cmb的选择文本值.
                    dgv.CurrentCell.Value = cmb.Text;
                    if (useColumnsIndex)
                    {
                        //设置当前单元格的前一个单元格的值为cmb的SelectedValue值.
                        int sideCellIndex = dgv.CurrentCell.ColumnIndex - 1;//取当前单元格的前一个单元格的列索引.
                        if (sideCellIndex > 0)
                        {
                            DataGridViewCell cell = dgv.CurrentRow.Cells[sideCellIndex];//取前一个单元格.
                            cell.Value = cmb.SelectedValue;
                        }
                    }
                    else
                    {
                        dgv.CurrentRow.Cells[columnNameForUpdate].Value = cmb.SelectedValue;
                    }
                }
                else if (bdType == 2)
                {
                    //设置当前单元格的值为cmb的选择文本值.
                    dgv.CurrentCell.Value = cmb.Text;
                }
            }
        }

        /// <summary>
        /// 当用户改变下拉列表框的值时，将同时改变DataGridView单元格的内容.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentCell != null)
            {
                if (bdType == 1 && dgv.Rows.Count > 0)
                {
                    //设置当前单元格的值为cmb的选择文本值.
                    dgv.CurrentCell.Value = cmb.Text;
                    if (useColumnsIndex)
                    {
                        //设置当前单元格的前一个单元格的值为cmb的SelectedValue值.
                        int sideCellIndex = dgv.CurrentCell.ColumnIndex - 1;//取当前单元格的前一个单元格的列索引.
                        if (sideCellIndex > 0)
                        {
                            DataGridViewCell cell = dgv.CurrentRow.Cells[sideCellIndex];//取前一个单元格.
                            cell.Value = cmb.SelectedValue;
                        }
                    }
                    else
                    {
                        dgv.CurrentRow.Cells[columnNameForUpdate].Value = cmb.SelectedValue;
                    }
                }
                else if (bdType == 2 && dgv.Rows.Count > 0)
                {
                    //设置当前单元格的值为cmb的选择文本值.
                    dgv.CurrentCell.Value = cmb.Text;
                }
            }
        }

        /// <summary>
        /// 当用户选择日期框的值后，将同时改变DataGridView单元格的内容.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpPicker_CloseUp(object sender, EventArgs e)
        {
            //设置当前单元格的值为dtpPicker的选择文本值.
            if (dgv.CurrentCell != null)
                dgv.CurrentCell.Value = dtpPicker.Value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 调dgv的列宽时将下拉列表框设为不可见.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            cmb.Visible = false;
            dtpPicker.Visible = false;
        }
    }
}