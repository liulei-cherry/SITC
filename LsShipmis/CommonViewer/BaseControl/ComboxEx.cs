using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommonViewer.BaseControl
{
    public partial class ComboxEx : UserControl
    {
        #region userdefine
        [Browsable(true), Category("用户自定义区域"), Description("下拉宽度.")]
        public int DropDownWidth
        {
            get
            {
                return cbList.DropDownWidth;
            }
            set
            {
                cbList.DropDownWidth = value;
            }
        }

        private bool showButton = true;
        [Browsable(true), Category("用户自定义区域"), Description("不让显示按钮.")]
        public bool ShowButton
        {
            get
            {
                return showButton;
            }
            set
            {
                showButton = value;
                resetTheControl();
            }
        }

        private string nullValueShow = "";
        [Browsable(true), Category("用户自定义区域"), Description("当下拉列表未选择任何值时的默认的显示提示.如‘请选择岗位’，‘您未选择任何内容’，‘所有信息’等")]
        public string NullValueShow
        {
            get { return nullValueShow; }
            set
            {
                nullValueShow = value;
                resetTheControl();
            }
        }

        private bool canEdit = true;
        [Browsable(true), Category("用户自定义区域"), Description("是否可以编辑,如果选择了不可以编辑,则只能通过下拉进行选择.")]
        public bool CanEdit
        {
            get { return canEdit; }
            set
            {
                canEdit = value;
                resetTheControl();
            }
        }

        public override string Text
        {
            get { return this.GetText(); }
            set { this.SelectedText(value); }
        }
        public string Value
        {
            get { return this.GetId(); }
        }
        #endregion
        private bool dataloaded = false;        //数据被加载了,如果没有加载数据的时候,即当前没有被初始化,很多功能不允许使用.

        private string lastValue = "";          //上一个值,仅用于可以编辑的情况下,记录不是下拉中存在的值时,用户输入的内容.
        private string valueColumn = "";        //在数据源中作为最终值的列名(通常为id列名)
        private string displayColumn = "";      //在数据源中作为显示值的列名(通常为name相关的列名)
        private string valueSelect;             //当前选中的数据,仅在valueUseful==true时有意义.
        private int displayColumnIndex = -1;
        private bool valueUseful = false;       //当前是否正常选中了某列,如果用户直接选择,或输入的值与某显示值相同均当作正常选中,
        //仅在输入模式下未完成输入的过程中为非有效值.
        private bool userChange = true;         //是否是用户引发的行变(由于windows原combox控件会因为切换数据源等情况下主动触发textchanged消息,
        //这个时候不应该触发相应的消息响应方法,所以引入了这个标志变量(这是权宜之计)
        DataTable showDateTable;                //当前下拉中绑定的数据源.
        FrmBaseSelectValue theSelectValueForm;  //当前对象维护和选择的界面(使用的是基类),当设置了本实例时,可以通过点击后面的按钮打开界面.
        private bool isLoading;                 //一样是权益之计,这个变量是true时,表达当控件是初始化状态下,不触发textchanged事件,初始化完毕则为false
        private bool canNull = false;           //当前是否可以选择空值,如果可以选择空值,则在数据源的第一行前加入一行空值.注意,init中的nullValueIn属性,
        //当canNull==ture的时候,null值显示成什么字,默认为空.如一条船不选的时候显示所有船,则这个nullValueIn传入"所有船"即可.
        private bool errValueCanleave = false;  //输入错误的(或者说列表中不存在的值)后,是否可以离开当前控件.
        public ComboxEx()
        {
            InitializeComponent();
        }
        private void resetTheControl()
        {
            if ((!haveTheForm() && clickedTheButton == null) || !showButton)
            {
                btnExtForm.Enabled = false;
                btnExtForm.Visible = false;
                cbList.Width = this.Width;

            }
            else
            {
                btnExtForm.Visible = true;
                btnExtForm.Width = 25;
                btnExtForm.Location = new Point(this.Width - 25, 0);
                cbList.Width = this.Width - btnExtForm.Width;
            }
            if (canEdit)
            {
                cbList.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cbList.DropDownStyle = ComboBoxStyle.DropDownList;
                valueUseful = true;//如果是限制编辑的状态,所有值均为有效!
            }
            if (string.IsNullOrEmpty(nullValueShow) && showDateTable.Rows.Count > 1 && canNull)
            {
                showDateTable.Rows[0][displayColumn] = nullValueShow;
            }

        }
        /// <summary>
        /// 初始化当前控件,所有继承此基类的具体控件必须调用这个方法.
        /// </summary>
        /// <param name="dtToDrop">数据源</param>
        /// <param name="valueColumnIn">值列名</param>
        /// <param name="displayColumnIn">显示列名</param>
        /// <param name="canEditIn">canEdit</param>
        /// <param name="canNullIn">canNull</param>
        /// <param name="nullValueIn">当canNull==ture的时候,null值显示成什么字,默认为空.如一条船不选的时候显示所有船,则这个nullValueIn传入"所有船"即可</param>
        /// <param name="theForm">theSelectValueForm</param>
        /// <param name="errValueCanleaveIn">errValueCanleave</param>
        public void Init(DataTable dtToDrop, string valueColumnIn, string displayColumnIn, bool canEditIn,
            bool canNullIn, string nullValueIn, FrmBaseSelectValue theForm, bool errValueCanleaveIn)
        {
            //表明正在加载.
            isLoading = true;
            userChange = false;
            //检验数据源是否有效.
            if (dtToDrop == null)
            {
                throw new Exception("下拉控件不应该可以传入空数据集合,否则无法进行下拉操作");
            }
            //进行了校验则肯定表明数据有效,但这里进行赋值是避免用户没有调用init,跳过了上面的校验过程.
            dataloaded = true;
            theSelectValueForm = theForm;
            showDateTable = dtToDrop;
            valueColumn = valueColumnIn;
            displayColumn = displayColumnIn;
            canEdit = canEditIn;

            //判断当前数据源是否有指定两列,如果没有,会造成显示异常,所以直接抛出异常.
            if (!showDateTable.Columns.Contains(displayColumn))
            {
                throw new Exception("不存在所传入的列" + displayColumn);
            }
            if (!showDateTable.Columns.Contains(valueColumn))
            {
                throw new Exception("不存在所传入的列" + valueColumn);
            }

            //判断是否需要插入空值行,需要则添加到第一行.
            if (dtToDrop.Rows.Count == 0 || canNullIn)
            {
                DataRow dr = showDateTable.NewRow();
                canNull = true;
                nullValueShow = nullValueIn;
                dr[displayColumn] = nullValueIn;//显示值使用传入参数.
                dr[valueColumn] = "";//实际值使用"" 0长字符串,不使用null,为了以后操作方便.
                showDateTable.Rows.InsertAt(dr, 0);
                valueUseful = true;
            }
            else
            {
                canNull = false;
                valueUseful = true;
                cbList.Text = showDateTable.Rows[0][displayColumn].ToString();
                valueSelect = showDateTable.Rows[0][valueColumnIn].ToString();
            }
            cbList.DataSource = showDateTable;
            cbList.DisplayMember = displayColumn;
            cbList.ValueMember = valueColumn;
            for (int i = 0; i < showDateTable.Columns.Count; i++)
            {
                if (showDateTable.Columns[i].ColumnName.Equals(displayColumn))
                {
                    displayColumnIndex = i;
                    break;
                }
            }
            errValueCanleave = errValueCanleaveIn;
            userChange = true;
            isLoading = false;//关闭初始化状态. 注意使用这样的状态值时,不允许有提前return的代码,否则可能出乱.            

            if (!string.IsNullOrEmpty(valueSelect))
            {
                if (TheSelectedChanged != null)
                {
                    TheSelectedChanged(valueSelect);
                }
            }
            resetTheControl();
        }

        /// <summary>
        /// 所选的内容变化后调用的委托,传出的值是当前选择的id
        /// </summary>
        /// <param name="theSelectedObject"></param>
        public delegate void ObjectChanged(string theSelectedObject);

        public event ObjectChanged TheSelectedChanged;

        public new delegate void TextChanged(string theSelectedText);

        public event TextChanged theTextChanged;

        public void SelectedId(string value, bool triggerEvent)
        {
            if (userChange)
            {
                filterValue("");
                cbList.DroppedDown = false;
            }
            if (value == null)
            {
                value = "";
            }
            userChange = false;
            //当显示列和值列一致,且可以录入错误离开焦点的情况下,直接把值设置成传入值即可.
            valueUseful = true;
            valueSelect = value;
            lastValue = cbList.SelectedText;

            if (displayColumn == valueColumn && errValueCanleave)
            {
                cbList.Text = value;
            }
            else
            {
                cbList.SelectedValue = value;
                if (string.IsNullOrEmpty(value))
                    cbList.Text = nullValueShow;
                else
                {
                    if (cbList.SelectedIndex >= 0)
                        cbList.Text = showDateTable.Rows[cbList.SelectedIndex][displayColumn].ToString();
                }
            }
            if (!isLoading && triggerEvent && TheSelectedChanged != null)
            {
                TheSelectedChanged(value);
            }
            userChange = true;
        }
        public void SelectedId(string value)
        {
            SelectedId(value, true);
        }

        public void SelectedText(string text, bool triggerEvent)
        {
            if (userChange)
            {
                filterValue("");
                cbList.DroppedDown = false;
            }
            if (text == null) text = "";
            //先定位完全一样的.
            DataRow[] dr = showDateTable.Select(displayColumn + "='" + text.Replace("'", "''") + "'");
            if (dr.Length >= 1)
            {
                userChange = false;
                SelectedId(dr[0][valueColumn].ToString());
                userChange = true;
                return;
            }
            else if (displayColumn == valueColumn && errValueCanleave)
            {
                valueUseful = true;
                cbList.Text = text;
            }
        }
        public void SelectedText(string text)
        {
            SelectedText(text, true);
        }

        /// <summary>
        /// 获取当前id值.
        /// </summary>
        /// <returns></returns>
        public string GetId()
        {

            if (!dataloaded)
            {
                throw new Exception("不能使用还未初始化的comboxEx控件");
            }
            if (valueUseful && cbList.SelectedIndex >= 0)
            {
                return cbList.SelectedValue.ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取当前文本值.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            if (!dataloaded)
            {
                throw new Exception("不能使用还未初始化的comboxEx控件");
            }
            if (valueUseful || errValueCanleave)
            {
                return cbList.Text;
            }
            else
            {
                return "";
            }
        }

        private bool haveTheForm()
        {
            return (theSelectValueForm != null);
        }
        private FrmBaseSelectValue getTheFrm()
        {
            return theSelectValueForm;
        }

        private void btnExtForm_Click(object sender, EventArgs e)
        {
            if (clickedTheButton != null)
            {
                string selectedId;
                if (clickedTheButton(out selectedId))
                {
                    SelectedId(selectedId);
                }
            }
            else if (getTheFrm() != null)
            {
                theSelectValueForm.Init(showDateTable, valueColumn, valueSelect);
                theSelectValueForm.ShowDialog();
                //关闭打开的窗体后会进入到这里,如果用户是正常关闭的,则进行值的判断,否则不做操作.
                if (theSelectValueForm.ValueUseful)
                {
                    showDateTable = theSelectValueForm.GetNewDataTable();
                    cbList.DisplayMember = displayColumn;
                    cbList.ValueMember = valueColumn;
                    cbList.DataSource = showDateTable;
                    SelectedId(theSelectValueForm.GetSelectedValue());
                }
            }
        }

        private void cbList_Leave(object sender, EventArgs e)
        {
            if (!errValueCanleave && canEdit)
            {
                if (!valueUseful && canNull && (cbList.SelectedValue == null || cbList.SelectedValue.ToString() == ""))
                {
                    switch (MessageBoxEx.Show("此处值无效,如要继续编辑,请选择[yes],如希望离开焦点并清除已维护内容请选择[no]", "错误提示",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        case DialogResult.Yes:
                            cbList.Focus();
                            cbList.Select(cbList.Text.Length, 0);
                            return;
                        default:
                            cbList.Text = "";
                            return;
                    }
                }
                else
                {
                    if (cbList.SelectedValue != null && cbList.SelectedValue.ToString() != "")
                    {
                        if (displayColumnIndex != -1)
                            cbList.Text = ((DataRowView)cbList.SelectedItem).Row.ItemArray[displayColumnIndex].ToString();
                        valueUseful = true;
                    }
                    if (!valueUseful)
                    {
                        MessageBoxEx.Show("此处值无效,请选择有效值");
                        cbList.Focus();
                    }
                    else if (!canNull && valueSelect.Length == 0)
                    {
                        MessageBoxEx.Show("此处值不允许为空,请录入或选择有效值!");
                        cbList.Focus();
                    }

                }
            }
            else
            {
                valueUseful = true;
                valueSelect = cbList.Text;
                /////////如果有实现这个委托的则调用,只有 valueUseful为fasle，即下拉表中不存在这个值时调用/////////////
                if (theTextChanged != null)
                {
                    valueSelect = cbList.Text;
                    theTextChanged(valueSelect);
                }

            }
        }

        private void cbList_TextChanged(object sender, EventArgs e)
        {
            if (!dataloaded)
            {
                throw new Exception("不能使用还未初始化的comboxEx控件");
            }
            if (!isLoading)
            {
                if (userChange)
                {
                    if (canEdit)
                    {
                        if (lastValue != cbList.Text)
                        {
                            valueUseful = false;
                            if (cbList.Text.Length > 0)
                            {
                                lastValue = cbList.Text;
                                filterValue(lastValue);
                            }
                            else
                            {
                                userChange = false;
                                cbList.DisplayMember = displayColumn;
                                cbList.ValueMember = valueColumn;
                                cbList.DataSource = showDateTable;
                                cbList.Text = "";
                                //ValueSelected("",false);                                
                                userChange = true;
                            }
                        }
                    }
                    else
                    {
                        if (cbList.SelectedValue == null)
                            SelectedId(null);
                        else
                            SelectedId(cbList.SelectedValue.ToString());
                    }
                }
            }
        }

        private void filterValue(string value)
        {
            if (!isLoading && userChange && !string.IsNullOrEmpty(value) && canEdit)
            {
                //先定位完全一样的.
                DataRow[] dr = showDateTable.Select(displayColumn + "='" + lastValue.Replace("'", "''") + "'");
                if (dr.Length >= 1)
                {
                    userChange = false;
                    SelectedId(dr[0][valueColumn].ToString());
                    userChange = true;
                    return;
                }
                valueUseful = false;//默认值都算无效,如果有效,则.

                DataTable newShow = showDateTable.Clone();
                string filterStr = "";
                if (lastValue.Contains(" "))
                {
                    string[] arrayStr = lastValue.Split(' ');
                    foreach (string s in arrayStr)
                    {
                        if (s.Trim().Length > 0)
                        {
                            filterStr += displayColumn + " like '%" + s.Trim().Replace("'", "''") + "%' and ";
                        }
                    }
                    if (filterStr.Length > 0)
                    {
                        filterStr = filterStr.Substring(0, filterStr.Length - 4);
                    }
                }
                else
                {
                    filterStr = displayColumn + " like '%" + lastValue.Replace("'", "''") + "%'";
                }
                if (filterStr.Trim() != "")
                {
                    DataRow[] newdrs = showDateTable.Select(filterStr);

                    foreach (DataRow newdr in newdrs)
                    {
                        newShow.ImportRow(newdr);
                    }
                }
                userChange = false;
                cbList.ValueMember = valueColumn;
                cbList.DisplayMember = displayColumn;

                //当一行没有,重新给完整数据源,但不显示.
                if (newShow.Rows.Count != 0)
                {
                    cbList.DataSource = newShow;
                    cbList.DroppedDown = true;
                }
                else
                {
                    cbList.DataSource = showDateTable;
                    cbList.DroppedDown = false;
                }
                cbList.Text = lastValue;
                cbList.Select(lastValue.Length, 0);
                userChange = true;

            }
            else if (!isLoading && userChange && canEdit)
            {
                userChange = false;
                cbList.DataSource = showDateTable;
                cbList.Text = lastValue;
                cbList.Select(lastValue.Length, 0);
                userChange = true;
            }
        }

        public delegate bool DeleClick(out string selectedId);
        public DeleClick clickedTheButton;
        public int NewDropDownWidth
        {
            set { cbList.DropDownWidth = value; }
        }
    }
}
