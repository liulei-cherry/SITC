/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UcDataGridView.cs
 * 创 建 人：牛振军
 * 创建时间：2009-05-12
 * 标    题：用户自定义的DataGridView控件
 * 功能描述：用户自定义的DataGridView控件
 * 修 改 人：徐正本
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Design;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;
namespace CommonViewer
{
    /// <summary>
    /// 用户自定义的DataGridView控件.
    /// </summary>
    public partial class UcDataGridView : DataGridView
    {
        private string selectRowName = "altoAddedSelectColumn";

        private bool loadedFinish = false;

        //记录所有的横向合并的情况;
        private Dictionary<int, Dictionary<string, List<string>>> stockOfAllRows = new Dictionary<int, Dictionary<string, List<string>>>();

        private List<string> displayedColumns = new List<string>();
        /// <summary>
        /// 当使用merge的时候，如果用户修改数据，应该重新刷对象，让此刷新显示效果。.
        /// 为了减少刷新次数，加载了此属性.
        /// </summary>
        public bool LoadedFinish
        {
            get { return loadedFinish; }
            set
            {
                loadedFinish = value;
                if (loadedFinish)
                {
                    stockOfAllRows.Clear();
                    resetColumnDisplayArray();
                }
            }
        }
        public delegate void DeleSelectedChanged(int rowNumber);
        public event DeleSelectedChanged SelectedChanged;
        private bool autoFit = true;
        /// <summary>
        /// 当前搜索的值（用于连续搜索时）.
        /// </summary>
        private string searchValue = "";
        private bool showRowNumber = true;   //是否显示行号.
        /// <summary>
        /// 是否显示行号.
        /// </summary>
        [Description("设定是否显示行号"), Category("自定义属性")]
        public bool ShowRowNumber
        {
            get { return showRowNumber; }
            set { showRowNumber = value; }
        }
        private bool exportColorToExcel = false;
        /// <summary>
        /// 是否显示行号.
        /// </summary>
        [Description("导出到Excel时,是否导出颜色"), Category("自定义属性")]
        public bool ExportColorToExcel
        {
            get { return exportColorToExcel; }
            set { exportColorToExcel = value; }
        }
        /// <summary>
        /// 从持久化加载列宽.
        /// </summary>
        private bool loadColWidthFromDb = false;

        /// <summary>
        /// 当前搜索的行号（用于连续搜索时）.
        /// </summary>
        private int currentRow = 0;
        private int treeDepth;
        private TreeView _ColHeaderTreeView = new TreeView();
        public void LoadGridView(string posionId)
        {
            DataGridViewExt.loadGridView(this, CommonOperation.ConstParameter.UserId, posionId);
        }
        /// <summary>
        /// 加载列样式
        /// </summary>
        /// <param name="posionId">要加载的列样式名称</param>
        /// <param name="dic">窗体定义的列样式</param>
        /// <param name="mulSelectName">要创建的复选框名称</param>
        public void LoadGridView(string posionId, Dictionary<string, string> dic, string mulSelectName)
        {
            int index = 0;
            if (string.IsNullOrEmpty(mulSelectName))
            {
                this.SetDgvGridColumns(dic);
            }

            else
            {
                this.SetDgvGridColumns(dic, mulSelectName);
                index = 1;
            }

            foreach (string item in dic.Keys)//按照dic的项顺序设置列顺序
            {
                this.Columns[item].DisplayIndex = index++;
            }
            DataGridViewExt.loadGridView(this, CommonOperation.ConstParameter.UserId, posionId);

            if (dic != null && dic.Count > 0)//不在dic里面的列就不显示,解决因旧的列样式储存数据,现在旧列
            {

                foreach (DataGridViewColumn item in this.Columns)
                {
                    if (!dic.ContainsKey(item.Name))
                    {
                        item.Visible = false;
                        if (item.Name == mulSelectName)
                        {
                            item.Visible = true;
                            item.DisplayIndex = 0;
                        }

                    }
                    else
                    {

                    }
                }
            }
        }
        public void LoadGridView(string posionId, Dictionary<string, string> dic)
        {
            LoadGridView(posionId, dic, null);
        }
        public void SaveGridView(string posionId)
        {
            DataGridViewExt.saveGridView(this, CommonOperation.ConstParameter.UserId, posionId);
        }
        /// <summary>
        /// 多维列标题的树结构.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("多维列表标题树结构,使用本属性时,必须要求显示列与树形控件叶节点数量一致,否则显示将异常,如果某个节点不显示,将其Tag置为hide"), Category("自定义属性")]
        public TreeNodeCollection HeadSource
        {
            get
            {
                //if (this._ColHeaderTreeView!=null && this._ColHeaderTreeView.Nodes.Count == 0) return null;
                iNodeLevels = 0;
                ColLists.Clear();
                this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                myNodeLevels();
                setColumns();
                return this._ColHeaderTreeView.Nodes;
            }
        }

        private void setColumns()
        {
            if (DesignMode && this._ColHeaderTreeView.Nodes.Count != 0)
            {
                this.Columns.Clear();
                foreach (TreeNode tn in ColLists)
                {
                    this.Columns.Add(tn.Name, tn.Text);
                }
            }
        }
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if (!loadColWidthFromDb && this._ColHeaderTreeView != null) refreshHeader();
        }

        private void refreshHeader()
        {
            this.Invalidate(new Rectangle(this.Location, new Size(this.Width, this.ColumnHeadersHeight)));
        }
        //使用水平滚动条时刷新控件.
        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll) Refresh();
        }
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if (showRowNumber)
            {
                int rownum = (e.RowIndex + 1);
                Rectangle rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, this.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, rownum.ToString(), this.RowHeadersDefaultCellStyle.Font, rct, this.RowHeadersDefaultCellStyle.ForeColor,
                    this.RowHeadersDefaultCellStyle.BackColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
        /// <summary>
        /// 释放资源.
        /// </summary>
        /// <param name="o"></param>
        private void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally
            {
                o = null;
            }
        }

        private int _cellHeight = 23;
        private int _columnDeep = 1;
        [Description("设置或获得合并表头树的深度")]
        public int ColumnDeep
        {
            get
            {
                if (this.Columns.Count == 0)
                    _columnDeep = 1;
                this.ColumnHeadersHeight = _cellHeight * _columnDeep;
                return _columnDeep;
            }

            set
            {
                if (value < 1)
                    _columnDeep = 1;
                else
                    _columnDeep = value;
                this.ColumnHeadersHeight = _cellHeight * _columnDeep;
            }
        }

        #region 添加删除修改部分的委托


        public delegate void Adding();
        public delegate void Editing();
        public delegate void Deleting();
        public Adding adding;
        public Editing editing;
        public Deleting deleting;
        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            this.tspSeparator.Visible = (adding != null) || (deleting != null) || (editing != null);
            this.tspMnuDel.Visible = (deleting != null);
            this.tspMnuEdit.Visible = (editing != null);
            this.tspMnuAdd.Visible = (adding != null);
        }
        /// <summary>
        /// 上下文菜单中的添加数据的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuAdd_Click(object sender, EventArgs e)
        {
            if (adding != null) adding();
        }

        /// <summary>
        /// 上下文菜单中的修改数据的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuEdit_Click(object sender, EventArgs e)
        {
            if (editing != null) editing();
        }

        /// <summary>
        /// 上下文菜单中的删除数据的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuDel_Click(object sender, EventArgs e)
        {
            if (deleting != null) deleting();

        }

        /// <summary>
        /// 上下文菜单中的搜索信息的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuSearch_Click(object sender, EventArgs e)
        {
            this.SearchInfo();
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public UcDataGridView()
        {
            InitializeComponent();
            footer = new List<string>();
            header = new List<string>();
            ctxMenu.ImageList = imgLstMain;
            tspMnuAdd.ImageIndex = 0;
            tspMnuEdit.ImageIndex = 1;
            tspMnuDel.ImageIndex = 2;
            tspMnuSearch.ImageIndex = 3;
            tspMnuOutput.ImageIndex = 4;
            selectedRowclicked = new DataGridViewCellEventHandler(UcDataGridView_CellClick);
            tspMnuAdd.Click += new EventHandler(tspMnuAdd_Click);
            tspMnuEdit.Click += new EventHandler(tspMnuEdit_Click);
            tspMnuDel.Click += new EventHandler(tspMnuDel_Click);
            tspMnuSearch.Click += new EventHandler(tspMnuSearch_Click);
            tspMnuOutput.Click += new EventHandler(tspMnuOutput_Click);
            tspMnuSetColumn.Click += new EventHandler(tspMnuSetColumn_Click);
        }
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if (loadedFinish && _mergeRowColumn.Count > 0) this.Refresh();
        }
        public UcDataGridView(IContainer container)
            : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// 上下文菜单中的导出为Excel的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuOutput_Click(object sender, EventArgs e)
        {
            this.OutPutExcel();
        }
        private void tspMnuSetColumn_Click(object sender, EventArgs e)
        {
            frmColumnSet frm = new frmColumnSet();
            frm.dgv = this;
            frm.ShowDialog();
            frm.StartPosition = FormStartPosition.CenterParent;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta));
            }
        }

        public ContextMenuStrip CtxMenu
        {
            get { return ctxMenu; }
            set { ctxMenu = value; }
        }

        private string _checkColName = "";

        /// <summary>
        /// 设置指定网格所有要显示的列的列标题.
        /// </summary>
        /// <param name="dictColumns">包含要设置的列的列名称与列标题（未包含的列全部隐藏）</param>
        public void SetDgvGridColumns(Dictionary<string, string> dictColumns)
        {
            _checkColName = "";
            //选隐藏所有列.
            foreach (DataGridViewColumn curColumn in this.Columns)
            {
                curColumn.Tag = 0;
                curColumn.Visible = false;
            }

            //设置集合dictColumns中的所有列的列标题.
            foreach (string columnName in dictColumns.Keys)
            {
                try
                {
                    this.Columns[columnName].Tag = 1;
                    this.Columns[columnName].HeaderText = dictColumns[columnName];
                    this.Columns[columnName].Visible = true;

                    //2011-10-26 数字型的自动过滤小数点后的内容,并靠右排.
                    if (this.Columns[columnName].ValueType == typeof(float) || this.Columns[columnName].ValueType == typeof(decimal)
                        || this.Columns[columnName].ValueType == typeof(double))
                    {
                        this.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.Columns[columnName].DefaultCellStyle.Format = "0.######";
                    }
                }
                catch { }
            }
            this.Refresh();
        }

        private DataGridViewCellEventHandler selectedRowclicked;
        /// <summary>
        /// 设置指定网格所有要显示的列的列标题(重载)。增加复选列,并使用复选列.
        /// </summary>
        /// <param name="dictColumns">包含要设置的列的列名称与列标题（未包含的列全部隐藏）</param>
        public void SetDgvGridColumns(Dictionary<string, string> dictColumns, string mulSelectedName)
        {
            _checkColName = "";
            //选隐藏所有列.
            foreach (DataGridViewColumn curColumn in this.Columns)
            {
                curColumn.Tag = 0;
                curColumn.Visible = false;
            }

            //设置集合dictColumns中的所有列的列标题.
            foreach (string columnName in dictColumns.Keys)
            {
                try
                {
                    this.Columns[columnName].Tag = 1;
                    this.Columns[columnName].HeaderText = dictColumns[columnName];
                    this.Columns[columnName].Visible = true;

                    //2011-10-26 数字型的自动过滤小数点后的内容,并靠右排.
                    if (this.Columns[columnName].ValueType == typeof(float) || this.Columns[columnName].ValueType == typeof(decimal)
                        || this.Columns[columnName].ValueType == typeof(double))
                    {
                        this.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.Columns[columnName].DefaultCellStyle.Format = "0.######";
                    }
                }
                catch { }
            }
            if (!this.Columns.Contains(selectRowName))
            {
                //增加复选列.
                DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                check.Name = mulSelectedName;
                check.HeaderText = "";
                selectRowName = mulSelectedName;
                check.Width = 25;
                check.Visible = true;
                check.DisplayIndex = 0;
                check.ReadOnly = true;
                check.DefaultCellStyle.BackColor = Color.Linen;
                check.TrueValue = 1;
                check.FalseValue = 0;
                this.Columns.Add(check);

                _checkColName = mulSelectedName;
                DatagridViewCheckBoxHeaderCell ch = new DatagridViewCheckBoxHeaderCell();
                ch.OnCheckBoxClicked += ch_OnChangeCheckBoxStatusHandler;

                check.HeaderCell = ch;
                check.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字


                this.Refresh();
                this.CellClick -= selectedRowclicked;
                this.CellClick += selectedRowclicked;
            }
            else
            {
                this.Columns[selectRowName].Visible = true;
                this.Columns[selectRowName].DisplayIndex = 0;
            }
        }

        void ch_OnChangeCheckBoxStatusHandler(bool state)
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                this.Rows[i].Cells[_checkColName].Value = state;
            }
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            try
            {
                DatagridViewCheckBoxHeaderCell ch = (DatagridViewCheckBoxHeaderCell)this.Columns[_checkColName].HeaderCell; 
                if (this.Columns[e.ColumnIndex].Name == _checkColName)
                {
                    if (!Convert.ToBoolean(this.Rows[e.RowIndex].Cells[_checkColName].Value))
                    {
                        ch.OnChangeCheckBoxStatus(false);
                    }
                    else
                    {
                        int flag = 0;
                        foreach (DataGridViewRow dr in this.Rows)
                        {
                            //校验是否选中.
                            if (!Convert.ToBoolean(dr.Cells[_checkColName].Value))
                            {
                                ch.OnChangeCheckBoxStatus(false);
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            ch.OnChangeCheckBoxStatus(true);
                        }
                    }

                }
            }
            catch
            {
            }

            base.OnCellContentClick(e);
        }

        private void UcDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && this.Columns[e.ColumnIndex].Name == selectRowName)
            {
                bool select = false;
                if (this.Rows[e.RowIndex].Cells[selectRowName].FormattedValue == null)
                    select = false;
                else select = (bool)this.Rows[e.RowIndex].Cells[selectRowName].FormattedValue;
                this.Rows[e.RowIndex].Cells[selectRowName].Value = !select;
            }
        }

        /// <summary>
        /// 当前网格的信息搜索.
        /// </summary>
        public void SearchInfo()
        {
            string searchCol = "";  //要搜索的字段名（用逗号连接的字符串）.

            //把所有显示的列名用逗号分隔成字符串.
            foreach (DataGridViewColumn dgvColumn in this.Columns)
            {
                if (dgvColumn.Visible == true)
                {
                    searchCol += dgvColumn.Name + ",";
                }
            }

            if (searchCol == "")
            {
                MessageBoxEx.Show("当前网格没有可见的列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmInputBoxGrid frm = new FrmInputBoxGrid();
                DialogResult dlrResult = frm.ShowDialog();
                this.searchValue = frm.SearchValue;

                if (dlrResult == DialogResult.OK)
                {
                    //去掉最后一个逗号.
                    searchCol = searchCol.Substring(0, searchCol.Length - 1);
                    this.dgvSearch(searchCol, searchValue, ref currentRow);
                }
            }
        }

        public void ContinueSearch()
        {
            string searchCol = "";  //要搜索的字段名（用逗号连接的字符串）.
            //把所有显示的列名用逗号分隔成字符串.
            foreach (DataGridViewColumn dgvColumn in this.Columns)
            {
                if (dgvColumn.Visible == true)
                {
                    searchCol += dgvColumn.Name + ",";
                }
            }

            //去掉最后一个逗号.
            searchCol = searchCol.Substring(0, searchCol.Length - 1);

            if (searchCol == "")
            {
                MessageBoxEx.Show("当前网格没有可见的列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvSearch(searchCol, searchValue, ref currentRow);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyData == Keys.F3)
            {
                ContinueSearch();
            }
        }

        private void dgvSearch(string searchCol, string searchValue, ref int currentRow)
        {
            dgvSearch(searchCol, searchValue, ref currentRow, false);
        }

        /// <summary>
        /// 网格的快速搜索.
        /// </summary>
        /// <param name="searchCol">要搜索的列（用逗号分隔的字符串）</param>
        /// <param name="searchValue">当前搜索的值</param>
        /// <param name="currentRow">当前搜索的行</param>
        private void dgvSearch(string searchCol, string searchValue, ref int currentRow, bool needMessageBox)
        {
            int find = 0;
            if (this.Rows.Count < currentRow) return;

            string[] searchCols = searchCol.Split(',');
            int foundCol = 0;
            try
            {
                for (int i = currentRow; i < this.Rows.Count; i++)
                {

                    string str = "";
                    foreach (string curSearchName in searchCols)
                    {
                        if (this[curSearchName.Trim(), i].Value != null)
                        {
                            str += this[curSearchName.Trim(), i].Value.ToString() + ";";
                        }
                    }

                    currentRow = i;

                    if (str.IndexOf(searchValue, 0, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        find = 1;
                        int fountPos = str.IndexOf(searchValue, 0, StringComparison.OrdinalIgnoreCase);
                        string subStr = str.Substring(0, fountPos + searchValue.Length);
                        string[] weidu = subStr.Split(';');
                        foundCol = weidu.Length - 1;
                        currentRow++;
                        break;
                    }
                    else
                        find = 0;

                }

                if (find == 0)
                {
                    currentRow = 0;
                    if (needMessageBox)
                        MessageBoxEx.Show("没有查找的项了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int c = Columns[searchCols[foundCol]].Index;
                    if (!Columns[searchCols[foundCol]].Visible) c = this.FirstDisplayedCell.ColumnIndex;

                    this.CurrentCell = this[c, currentRow - 1];
                }

                this.Focus();
            }
            catch (Exception e)
            {
                MessageBoxEx.Show(e.Message, "搜索出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 将当前网格的数据源导出到Excel中.
        /// </summary>
        public void OutPutExcel()
        {
            Cursor.Current = Cursors.WaitCursor;
            Export2Excel(this, true);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 把一个DataTable中包含的数据转存成一个二维数组.
        /// </summary>
        /// <param name="dtb">要转换的DataTable对象</param>
        /// <returns>返回一个二维数组</returns>
        private Object[,] getObjArray(System.Data.DataTable dtb)
        {
            int rowCount = dtb.Rows.Count;      //dtb中的行数.
            int columnCount = dtb.Columns.Count;//dtb中的列数.

            //根据dtb的大小声明一个与之相同大小的二维数组.
            Object[,] objData = new Object[rowCount, columnCount];

            //循环把dtb中包含的数据转存成一个二维数组.
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    string curValue = dtb.Rows[i][j].ToString();
                    objData[i, j] = curValue;
                }
            }

            return objData;
        }

        #region Export to Excel

        object objApp_Late;
        object objBook_Late;
        object objBooks_Late;
        object objSheets_Late;
        object objSheet_Late;
        object objRange_Late;
        object[] Parameters;
        int visibleCols;

        /// <summary>
        /// Exports a passed datagridview to an Excel worksheet.
        /// If captions is true, grid headers will appear in row 1.
        /// Data will start in row 2.
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="captions"></param>
        private void Export2Excel(DataGridView datagridview, bool captions)
        {
            int kk = 0;
            foreach (DataGridViewColumn col in datagridview.Columns)
            {
                if (col.GetType().Name == "DataGridViewTextBoxColumn" && col.Visible == true)// 
                {
                    kk++;
                }
            }
            visibleCols = kk;
            string[] headers = new string[kk];
            string[] columns = new string[kk];
            string[] colName = new string[kk];
            int i = 0;
            int c = 0;
            int m = 0;
            for (c = 0; c < datagridview.Columns.Count; c++)
            {
                for (int j = 0; j < datagridview.Columns.Count; j++)
                {
                    DataGridViewColumn tmpcol = datagridview.Columns[j];
                    if (tmpcol.DisplayIndex == c)
                    {
                        if (tmpcol.GetType().Name == "DataGridViewTextBoxColumn" && tmpcol.Visible) //不显示的隐藏列初始化为tag＝0 
                        {
                            headers[c - m] = tmpcol.HeaderText;
                            i = c - m + 1;
                            columns[c - m] = ConvertColumnNum2String(i);
                            colName[c - m] = tmpcol.Name;
                        }
                        else
                        {
                            m++;
                        }
                        break;
                    }
                }
            }
            try
            {
                // Get the class type and instantiate Excel.
                Type objClassType;
                objClassType = Type.GetTypeFromProgID("Excel.Application");
                objApp_Late = Activator.CreateInstance(objClassType);
                //Get the workbooks collection.
                objBooks_Late = objApp_Late.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, objApp_Late, null);
                //Add a new workbook.
                objBook_Late = objBooks_Late.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, objBooks_Late, null);
                //Get the worksheets collection.
                objSheets_Late = objBook_Late.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, objBook_Late, null);
                //Get the first worksheet.
                Parameters = new Object[1];
                Parameters[0] = 1;
                objSheet_Late = objSheets_Late.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, objSheets_Late, Parameters);
                if (captions)
                {
                    //这里重新写入excel的头.
                    //多维表头.
                    //_ColHeaderTreeView  表头TreeView
                    //iNodeLevels 表头的层数.
                    //_ColHeaderTreeView.Nodes.a
                    if (this._ColHeaderTreeView.Nodes.Count > 0)
                    {
                        TreeView tr = new TreeView();
                        CopyTree(_ColHeaderTreeView.Nodes, tr.Nodes);
                        WriteCell(tr.Nodes, 1, 1);
                    }
                    else
                    {
                        // Create the headers in the first row of the sheet
                        for (c = 0; c < kk; c++)
                        {
                            //Get a range object that contains cell.
                            Parameters = new Object[2];
                            Parameters[0] = columns[c] + "1";
                            Parameters[1] = Missing.Value;
                            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                            //Write Headers in cell.
                            Parameters = new Object[1];
                            Parameters[0] = headers[c];
                            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                        }
                    }
                }
                // Now add the data from the grid to the sheet starting in row 2
                int startRow = 2;
                if (iNodeLevels != 0)
                {
                    startRow = iNodeLevels + 1;
                }
                if (exportColorToExcel)
                {
                    object objFont;
                    for (i = 0; i < datagridview.RowCount; i++)
                    {
                        c = 0;
                        foreach (string txtCol in colName)
                        {
                            DataGridViewColumn col = datagridview.Columns[txtCol];
                            if (col.Visible)
                            {
                                //Get a range object that contains cell.
                                Parameters = new Object[2];

                                Parameters[0] = columns[c] + Convert.ToString(i + startRow);
                                Parameters[1] = Missing.Value;
                                objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                                //Write Headers in cell.
                                Parameters = new Object[1];
                                if (datagridview.Rows[i].Cells[col.Name].Value != null)
                                {
                                    Parameters[0] = datagridview.Rows[i].Cells[col.Name].Value.ToString().Replace(" 0:00:00", ""); //string.Format("{0:d}",dt);//2005-11-5
                                }
                                else
                                {
                                    Parameters[0] = "";
                                }
                                objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                                if (datagridview.Rows[i].Cells[col.Name].Style != null)
                                {
                                    //这里仅支持字体颜色 背景色不知道如何获取 datagridview.Rows[i].Cells[col.Name].Style.BackColor获取不到.
                                    objFont = objRange_Late.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, objRange_Late, null);
                                    Color colorFont = datagridview.Rows[i].Cells[col.Name].Style.ForeColor;
                                    int colorValue = colorFont.R + 255 * colorFont.G + 255 * 255 * colorFont.B;
                                    objFont.GetType().InvokeMember("Color", BindingFlags.SetProperty, null, objFont, new object[] { colorValue });
                                }
                                c++;
                            }

                        }
                    }
                }
                else
                {
                    //使用2维数组进行粘贴，速度可能更快.
                    string[,] vals = new string[this.Rows.Count, headers.Length];
                    string startCell = columns[0] + Convert.ToString(startRow);
                    string endCell = columns[columns.Length - 1] + Convert.ToString(startRow + this.Rows.Count - 1);
                    for (i = 0; i < datagridview.RowCount; i++)
                    {
                        int j = 0;
                        foreach (string txtCol in colName)
                        {
                            DataGridViewColumn col = datagridview.Columns[txtCol];
                            if (col.Visible)
                            {
                                if (datagridview.Rows[i].Cells[col.Name].Value != null)
                                {
                                    vals[i, j] = datagridview.Rows[i].Cells[col.Name].Value.ToString().Replace(" 0:00:00", ""); //string.Format("{0:d}",dt);//2005-11-5
                                }
                                else
                                {
                                    vals[i, j] = "";
                                }
                                j++;
                            }
                        }
                    }
                    //块写入.
                    Parameters = new Object[2];
                    Parameters[0] = startCell;
                    Parameters[1] = endCell;
                    objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);

                    //写入值.
                    Parameters = new Object[1];
                    Parameters[0] = vals;
                    objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                    //设为文本格式.
                    //object[] o = new object[1];
                    //o[0] = "#,##0.00 ";
                    Parameters = new Object[1];
                    Parameters[0] = "@";
                    objRange_Late.GetType().InvokeMember("NumberFormatLocal", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                }
                //左右合并单元格.
                mergeRowsCell(startRow);
                //上下合并单元格.
                //start row = startRow, end row= startRow+ startRow+datagridview.RowCount
                //calculate column index tobe bombined
                int endRow = startRow + datagridview.RowCount - 1;
                if (_mergecolumnname != null && _mergecolumnname.Count > 0)
                {
                    foreach (string cn in _mergecolumnname)
                    {
                        int col = Array.IndexOf<string>(colName, cn) + 1;
                        if (col > 0) mergeColumnsCell(startRow, endRow, col);//设置的合并列没有显示的不进行合并操作.
                    }
                }
                drawLine();
                // 写入footer
                int maxRows = iNodeLevels + 1 + datagridview.RowCount;
                if (iNodeLevels == 0) maxRows++;
                if (footer != null) writeFooter(maxRows);
                //写入header
                if (header != null) writeHeader();
                if (title != null) writeTitle();
                //Return control of Excel to the user.
                Parameters = new Object[1];
                Parameters[0] = true;
                objApp_Late.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, objApp_Late, Parameters);
                objApp_Late.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, objApp_Late, Parameters);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }

        //复制tree，将隐藏的节点去除.
        private void CopyTree(TreeNodeCollection nodes, TreeNodeCollection tgNodes)
        {
            foreach (TreeNode nd in nodes)
            {
                if (nd.Tag == null || nd.Tag.ToString() != "hide")
                {
                    TreeNode newNode = new TreeNode(nd.Text);
                    tgNodes.Add(newNode);
                    if (nd.Nodes.Count > 0) CopyTree(nd.Nodes, newNode.Nodes);
                }
            }
        }

        private void mergeRowsCell(int startRow)
        {
            reCalculateAllStock();
            objApp_Late.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, objApp_Late, new object[] { false });
            foreach (int i in stockOfAllRows.Keys)
            {
                foreach (string tempKeys in stockOfAllRows[i].Keys)
                {
                    {
                        string theValue = getValue(startRow + i, displayedColumns.IndexOf(tempKeys) + 1);
                        string[] points = new string[2];

                        int smallvalue = 10000, bigvalue = 0;
                        if (stockOfAllRows[i][tempKeys].Count < 2) continue;
                        for (int r = 0; r < stockOfAllRows[i][tempKeys].Count; r++)
                        {
                            int tempvalue = displayedColumns.IndexOf(stockOfAllRows[i][tempKeys][r]) + 1;
                            if (smallvalue > tempvalue)
                                smallvalue = displayedColumns.IndexOf(stockOfAllRows[i][tempKeys][r]) + 1;
                            if (bigvalue < tempvalue)
                                bigvalue = tempvalue;
                        }
                        points[0] = ConvertColumnNum2String(smallvalue) + (startRow + i).ToString();
                        points[1] = ConvertColumnNum2String(bigvalue) + (startRow + i).ToString();
                        objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, points);
                        objRange_Late.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod, null, objRange_Late, null);

                    }

                }
            }
        }

        /// <summary>
        /// 上下合并单元格.
        /// </summary>
        /// <param name="startRow">起始行</param>
        /// <param name="endRow">终止行</param>
        /// <param name="col">第几列</param>
        private void mergeColumnsCell(int startRow, int endRow, int excelColumn)
        {
            objApp_Late.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, objApp_Late, new object[] { false });
            for (int i = endRow; i > startRow; i--)
            {
                if (displayedColumns.Count <= excelColumn || excelColumn < 1 ||
                    (checkHasTheColumn(displayedColumns[excelColumn - 1], i - startRow).Length > 0
                    || checkHasTheColumn(displayedColumns[excelColumn - 1], i - 1 - startRow).Length > 0))
                    continue;

                string s = getValue(i, excelColumn);

                if (!string.IsNullOrEmpty(s) && s == getValue(i - 1, excelColumn))
                {
                    string point1 = ConvertColumnNum2String(excelColumn) + i.ToString();
                    string point2 = ConvertColumnNum2String(excelColumn) + (i - 1).ToString();
                    objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
                    objRange_Late.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod, null, objRange_Late, null);
                }
            }
        }

        /// <summary>
        /// 数字转换为Excel字母数字的列.
        /// </summary>
        /// <param name="columnNum">数字</param>
        /// <returns>返回字符串</returns>
        private string ConvertColumnNum2String(int columnNum)
        {
            if (columnNum > 26)
            {
                return string.Format("{0}{1}", (char)(((columnNum - 1) / 26) + 64), (char)(((columnNum - 1) % 26) + 65));
            }
            else
            {
                return ((char)(columnNum + 64)).ToString();
            }
        }

        private string getValue(int row, int col)
        {
            string point1 = ConvertColumnNum2String(col) + row.ToString();
            string point2 = ConvertColumnNum2String(col) + row.ToString();
            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
            Parameters = new Object[1];
            Parameters[0] = Missing.Value;
            object rt = objRange_Late.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, objRange_Late, Parameters);
            if (rt == null)
            {
                return "";
            }
            return rt.ToString();
        }

        private void removeHideNode(TreeNode node)
        {
            if (node.Tag != null && node.Tag.ToString() == "hide")
            {
                node.Remove();
            }
            else
            {
                for (int i = node.Nodes.Count - 1; i >= 0; i--)
                {
                    TreeNode nd = node.Nodes[i];
                    removeHideNode(nd);
                }
            }
        }

        /// <summary>
        /// 遍历treeview并写入.
        /// </summary>
        /// <param name="rootNodes">treeview 节点集合</param>
        /// <param name="excelRow">写入的行:从1开始</param>
        /// <param name="excelColumn">写入的列:从1开始</param>
        /// <returns>占用的列数</returns>
        private int WriteCell(TreeNodeCollection rootNodes, int excelRow, int excelColumn)
        {
            int cellCount = 1;
            if (rootNodes.Count < 1)
            {
                WriteExcelROW(excelRow - 1, excelColumn, cellCount, treeDepth);//sd为treeview的深度.
                return cellCount;
            }
            int cellCountSum = 0;
            foreach (TreeNode TNode in rootNodes)
            {
                cellCount = WriteCell(TNode.Nodes, excelRow + 1, excelColumn);
                WriteExcel(excelRow, excelColumn, cellCount, TNode.Text);
                cellCountSum += cellCount;
                excelColumn += cellCount;
            }
            return cellCountSum;
        }

        private void WriteExcelROW(int excelRow, int excelColumn, int cellCountSum, int sd)
        {
            //列数没有限制.
            string point1 = ConvertColumnNum2String(excelColumn) + excelRow.ToString();//单元格起始点 如:A1 
            string point2 = ConvertColumnNum2String(excelColumn) + (sd + 1).ToString();//单元格起始点 如:A1 
            if (point1 != point2)
            {
                objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
                objRange_Late.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, objRange_Late, new object[] { true });
            }

        }

        /// <summary>
        /// 报表header的输出.
        /// </summary>
        /// <param name="excelRow"></param>
        /// <param name="excelColumn"></param>
        /// <param name="cellCountSum"></param>
        /// <param name="excelValue"></param>
        private void WriteExcel(int excelRow, int excelColumn, int cellCountSum, string excelValue)
        {
            //列数没有限制.
            string point1 = ConvertColumnNum2String(excelColumn) + excelRow.ToString();//单元格起始点 如:A1
            string point2 = ConvertColumnNum2String(excelColumn + cellCountSum - 1) + excelRow.ToString();//单元格结束点 如:B4

            //_Range = _Worksheet.get_Range(point1, point2);//获取单元格.
            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
            if (cellCountSum > 0)
            {
                //_Range.MergeCells = true; //合并单元格.
                objRange_Late.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, objRange_Late, new object[] { true });
            }

            objRange_Late.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, objRange_Late, new object[] { -4108 });//内容水平居中 Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter 
            objRange_Late.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, objRange_Late, new object[] { -4108 });  //内容垂直居中Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter 

            //_Worksheet.Cells[_Range.Row, _Range.Column] = excelValue;//把内容写入单元格.
            Parameters = new Object[1];
            Parameters[0] = excelValue;
            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
        }
        /// <summary>
        /// 报表footer的输出.
        /// </summary>
        /// <param name="excelRow"></param>
        /// <param name="excelColumn"></param>
        /// <param name="cellCountSum"></param>
        /// <param name="excelValue"></param>
        private void WriteExcels(int excelRow, int excelColumn, int cellCountSum, string excelValue)
        {
            //列数没有限制..
            string point1 = ConvertColumnNum2String(excelColumn) + excelRow.ToString();//单元格起始点 如:A1
            string point2 = ConvertColumnNum2String(excelColumn + cellCountSum - 1).ToString() + excelRow.ToString();//单元格结束点 如:B4

            //_Range = _Worksheet.get_Range(point1, point2);//获取单元格.
            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
            if (cellCountSum > 0)
            {
                //_Range.MergeCells = true; //合并单元格.
                objRange_Late.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, objRange_Late, new object[] { true });
            }
            //_Worksheet.Cells[_Range.Row, _Range.Column] = excelValue;//把内容写入单元格.
            Parameters = new Object[1];
            Parameters[0] = excelValue;
            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
        }

        /// <summary>
        /// 报表title的输出.
        /// </summary>
        /// <param name="excelRow"></param>
        /// <param name="excelColumn"></param>
        /// <param name="cellCountSum"></param>
        /// <param name="excelValue"></param>
        private void WriteExcelTitle(int excelRow, int excelColumn, int cellCountSum, string excelValue)
        {
            string point1 = ConvertColumnNum2String(excelColumn) + excelRow.ToString();//单元格起始点 如:A1
            string point2 = ConvertColumnNum2String(excelColumn + cellCountSum - 1).ToString() + excelRow.ToString();//单元格结束点 如:B4

            //_Range = _Worksheet.get_Range(point1, point2);//获取单元格.
            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, new object[] { point1, point2 });
            if (cellCountSum > 0)
            {
                //_Range.MergeCells = true; //合并单元格.
                objRange_Late.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, objRange_Late, new object[] { true });
            }

            objRange_Late.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, objRange_Late, new object[] { -4108 });//内容水平居中 Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter 
            objRange_Late.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, objRange_Late, new object[] { -4108 });  //内容垂直居中Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter 

            object Font = objRange_Late.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, objRange_Late, null);
            objRange_Late.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Font, new object[] { 20 });

            //_Worksheet.Cells[_Range.Row, _Range.Column] = excelValue;//把内容写入单元格.
            Parameters = new Object[1];
            Parameters[0] = excelValue;
            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
        }

        /// <summary>
        /// 插入行.
        /// </summary>
        /// <param name="Index">插入的行</param>
        /// <param name="value">插入的值</param>
        /// <param name="isTitle">是否为title</param>
        private void Insert(int Index, string value, bool isTitle)
        {
            object EntireRow_Late;

            Parameters = new Object[2];
            Parameters[0] = "A1";
            Parameters[1] = Missing.Value;

            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);
            EntireRow_Late = objRange_Late.GetType().InvokeMember("EntireRow", BindingFlags.GetProperty, null, objRange_Late, null);
            EntireRow_Late.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, EntireRow_Late, null);
            if (!isTitle)
            {
                WriteExcels(Index, 1, visibleCols, value);
            }
            else
            {
                WriteExcelTitle(Index, 1, visibleCols, value);
            }

        }

        /// <summary>
        /// 导出数据是否自动设置行列的宽度.
        /// </summary>
        [Description("导出数据是否自动设置行列的宽度"), Category("自定义属性")]
        public bool AutoFit
        {
            get { return autoFit; }
            set { autoFit = value; }
        }

        /// <summary>
        /// 写数据的内容画实线.
        /// </summary>
        private void drawLine()
        {
            object Range = objSheet_Late.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, objSheet_Late, null);
            object[] args = new object[] { 1 };
            object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
            Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
            //自动适应行列的宽高.
            if (autoFit)
            {
                Object dataColumns = Range.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, Range, null);
                dataColumns.GetType().InvokeMember("AutoFit", BindingFlags.InvokeMethod, null, dataColumns, null);
            }
        }

        #endregion

        //数据个的合并,同一列的合并 dgvMyTask._mergeColumnNames.Add("Work_Detail");
        //自定义表头, ColHeaderTreeView=TreeView

        #region 增加多表头及合并的问题

        #region 字段定义

        /// <summary>
        /// 树的最大层数.
        /// </summary>
        private int iNodeLevels;

        /// <summary>
        /// 一维列表标题的高度.
        /// </summary>
        private int iCellHeight = 22;

        /// <summary>
        /// 所有页节点.
        /// </summary>
        private IList<TreeNode> ColLists = new List<TreeNode>();

        #endregion

        #region 方法函数

        /// <summary>
        /// 递归计算树的最大层数,保存所有的叶节点.
        /// </summary>
        /// <param name="tnc"></param>
        /// <returns></returns>
        private int myGetNodeLevels(TreeNodeCollection tnc)
        {
            if (tnc == null) return 0;

            foreach (TreeNode tn in tnc)
            {
                if ((tn.Level + 1) > iNodeLevels)//tn.Level是从0开始的.
                {
                    iNodeLevels = tn.Level + 1;
                }

                if (tn.Nodes.Count > 0)
                {
                    myGetNodeLevels(tn.Nodes);
                }
                else if (tn.Tag == null || tn.Tag.ToString() != "hide")
                {
                    ColLists.Add(tn);//页节点.
                }
            }

            return iNodeLevels;
        }
        /// <summary>
        /// 调用递归求最大层数,列头总高.
        /// </summary>
        private void myNodeLevels()
        {

            iNodeLevels = 1;//初始值为1

            ColLists.Clear();

            int iNodeDeep = myGetNodeLevels(_ColHeaderTreeView.Nodes);
            treeDepth = iNodeDeep - 1;

            this.ColumnHeadersHeight = iCellHeight * iNodeDeep;//列头总高=一维列高*层数.
            this.ColumnDeep = iNodeDeep;

        }

        private List<TreeNode> _columnList = new List<TreeNode>();
        [Description("最底层节点集合")]
        public List<TreeNode> NadirColumnList
        {
            get
            {
                if (this._ColHeaderTreeView == null)
                    return null;

                if (this._ColHeaderTreeView.Nodes == null)
                    return null;

                if (this._ColHeaderTreeView.Nodes.Count == 0)
                    return null;

                _columnList.Clear();
                foreach (TreeNode node in this._ColHeaderTreeView.Nodes)
                {
                    //GetNadirColumnNodes(_columnList, node, false);
                    GetNadirColumnNodes(_columnList, node);
                }
                return _columnList;
            }
        }
        private void GetNadirColumnNodes(List<TreeNode> alList, TreeNode node)
        {
            if (node.FirstNode == null)//( && (node.Tag == null || node.Tag.ToString() != "hide"))
            {
                alList.Add(node);
            }
            foreach (TreeNode n in node.Nodes)
            {
                GetNadirColumnNodes(alList, n);
            }
        }

        /// <summary>
        /// 获得合并标题字段的宽度.
        /// </summary>
        /// <param name="node">字段节点</param>
        /// <returns>字段宽度</returns>
        private int GetUnitHeaderWidth(TreeNode node)
        {
            int uhWidth = 0;
            //获得最底层字段的宽度.
            if (node.Nodes == null)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            if (node.Nodes.Count == 0)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            //获得非最底层字段的宽度.
            for (int i = 0; i <= node.Nodes.Count - 1; i++)
            {
                uhWidth = uhWidth + GetUnitHeaderWidth(node.Nodes[i]);
            }
            return uhWidth;
        }

        /// <summary>获得底层字段索引.
        /// 
        /// </summary>
        ///' <param name="node">底层字段节点</param>
        /// <returns>索引</returns>
        /// <remarks></remarks>
        private int GetColumnListNodeIndex(TreeNode node)
        {
            for (int i = 0; i <= ColLists.Count - 1; i++)
            {
                if (ColLists[i].Equals(node))
                    return i;
            }
            return -1;
        }
        ///<summary>
        ///绘制合并表头.
        ///</summary>
        ///<param name="node">合并表头节点</param>
        ///<param name="e">绘图参数集</param>
        ///<param name="level">结点深度</param>
        ///<remarks></remarks>
        public void PaintUnitHeader(TreeNode node, DataGridViewCellPaintingEventArgs e, int level)
        {
            //根节点时退出递归调用.
            if (level == 0)
                return;

            RectangleF uhRectangle;
            int uhWidth;
            SolidBrush gridBrush = new SolidBrush(this.GridColor);

            Pen gridLinePen = new Pen(gridBrush);
            StringFormat textFormat = new StringFormat();

            textFormat.Alignment = StringAlignment.Center;

            uhWidth = GetUnitHeaderWidth(node);

            //与原贴算法有所区别在这。.
            if (node.Nodes.Count == 0)
            {
                uhRectangle = new Rectangle(e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * _cellHeight,
                            uhWidth - 1,
                            _cellHeight * (_columnDeep - node.Level) - 1);
            }
            else
            {
                uhRectangle = new Rectangle(
                            e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * _cellHeight,
                            uhWidth - 1,
                            _cellHeight - 1);
            }

            Color backColor = e.CellStyle.BackColor;
            if (node.BackColor != Color.Empty)
            {
                backColor = node.BackColor;
            }
            SolidBrush backColorBrush = new SolidBrush(backColor);
            //画矩形.
            e.Graphics.FillRectangle(backColorBrush, uhRectangle);

            //划底线.
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Left
                                , uhRectangle.Bottom
                                , uhRectangle.Right
                                , uhRectangle.Bottom);
            //划右端线.
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Right
                                , uhRectangle.Top
                                , uhRectangle.Right
                                , uhRectangle.Bottom);

            ////写字段文本.
            Color foreColor = Color.Black;
            if (node.ForeColor != Color.Empty)
            {
                foreColor = node.ForeColor;
            }
            float x = uhRectangle.Left + uhRectangle.Width / 2 - e.Graphics.MeasureString(node.Text, this.Font).Width / 2 - 1;
            x = x > uhRectangle.Left ? x : uhRectangle.Left;
            e.Graphics.DrawString(node.Text, this.Font
                                    , new SolidBrush(foreColor)
                                    , x
                                    , uhRectangle.Top + uhRectangle.Height / 2 - e.Graphics.MeasureString(node.Text, this.Font).Height / 2);

            ////递归调用()
            if (node.PrevNode == null)
                if (node.Parent != null)
                    PaintUnitHeader(node.Parent, e, level - 1);
        }

        #endregion
        /// <summary>
        /// 单元格绘制(重写)
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DrawCell(e);
            }
            //行标题不重写.
            if (e.ColumnIndex < 0)
            {
                base.OnCellPainting(e);
                return;
            }

            if (_columnDeep == 1)
            {
                base.OnCellPainting(e);
                return;
            }

            //绘制表头.
            if (e.RowIndex == -1)
            {
                PaintUnitHeader((TreeNode)NadirColumnList[e.ColumnIndex], e, _columnDeep);
                e.Handled = true;
            }
        }

        #region 属性


        /// <summary>
        /// 设置或获取合并列的集合.
        /// </summary>
        [MergableProperty(false)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Description("设置或获取合并列的集合"), Browsable(true), Category("单元格合并")]
        public List<string> MergeColumnNames
        {
            get
            {
                return _mergecolumnname;
            }
            set
            {
                if (value != null) _mergecolumnname = value;
            }
        }
        private List<string> _mergecolumnname = new List<string>();

        /// <summary>
        /// 设置或获取合并列的集合.
        /// </summary>
        [MergableProperty(false)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Description("设置或获取同行并列的列集合，每一行录入格式=列1,列2[,列n]\r当'列1'的内容不为空,且随后的列均为空时,单元格合并"), Browsable(true), Category("单元格合并")]
        public List<string> MergeRowColumn
        {
            get
            {
                return _mergeRowColumn;
            }
            set
            {
                _mergeRowColumn = value;
                resetMergeRowColumns();
            }
        }
        private List<string> _mergeRowColumn = new List<string>();
        private List<List<string>> _lstMergeRowColumn = new List<List<string>>();

        private void resetMergeRowColumns()
        {
            _lstMergeRowColumn.Clear();
            if (null != _mergeRowColumn)
            {
                foreach (string mergeRowTemp in _mergeRowColumn)
                {
                    char[] cs = { ',' };
                    string[] rowColumns = mergeRowTemp.Split(cs, StringSplitOptions.RemoveEmptyEntries);
                    if (rowColumns.Length >= 2)
                    {
                        List<string> tempStringLst = new List<string>();

                        for (int r = 0; r < rowColumns.Length; r++)
                        {
                            if (rowColumns[r].Trim().Length > 0)
                            {
                                if (!Columns.Contains(rowColumns[r]) || Columns[rowColumns[r]].Displayed)
                                    tempStringLst.Add(rowColumns[r].Trim());
                            }
                        }
                        if (tempStringLst.Count < 2) continue;

                        bool added = false;
                        for (int r = 0; r < _lstMergeRowColumn.Count; r++)
                        {
                            if (_lstMergeRowColumn[r][0] == tempStringLst[0] && _lstMergeRowColumn[r].Count < tempStringLst.Count)
                            {
                                _lstMergeRowColumn.Insert(r, tempStringLst);
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            _lstMergeRowColumn.Add(tempStringLst);
                        }
                    }
                }
            }
            else _mergeRowColumn = new List<string>();
        }
        #endregion

        private void reCalculateAllStock()
        {
            stockOfAllRows.Clear();
            foreach (List<string> lstRowColumn in _lstMergeRowColumn)
            {
                for (int rowNo = 0; rowNo < Rows.Count; rowNo++)
                {
                    if (null != this.Rows[rowNo].Cells[lstRowColumn[0]])
                    {
                        string mainValue = this.Rows[rowNo].Cells[lstRowColumn[0]].Value.ToString().Trim();
                        if (mainValue.Length == 0) continue;

                        //可以合并.
                        bool canMergeRow = true;
                        //本行不用检查了,因为这个组合的某个列已经跟别的合并了.
                        bool nowNeedToCheckThisGroup = false;

                        for (int i = 1; i < lstRowColumn.Count; i++)
                        {
                            //在合并集合中找到了当前行和列.
                            if (checkHasTheColumn(lstRowColumn[0], rowNo).Length > 0)
                            {
                                nowNeedToCheckThisGroup = true;
                                break;
                            }
                            //为空,或者不可见,或者为空字符串.
                            if (this.Rows[rowNo].Cells[lstRowColumn[i]].Value == null ||
                                !this.Columns[lstRowColumn[i]].Visible ||
                                string.IsNullOrEmpty(this.Rows[rowNo].Cells[lstRowColumn[i]].Value.ToString()) ||
                                this.Rows[rowNo].Cells[lstRowColumn[i]].Value.ToString() == mainValue)
                            {
                                continue;
                            }
                            canMergeRow = false;
                            break;
                        }
                        if (nowNeedToCheckThisGroup) continue;
                        if (canMergeRow)
                        {
                            if (!stockOfAllRows.ContainsKey(rowNo))
                            {
                                stockOfAllRows.Add(rowNo, new Dictionary<string, List<string>>());
                            }
                            if (stockOfAllRows[rowNo].ContainsKey(lstRowColumn[0]))
                            {
                                stockOfAllRows[rowNo].Remove(lstRowColumn[0]);
                            }
                            stockOfAllRows[rowNo].Add(lstRowColumn[0], lstRowColumn);
                        }
                    }
                }
            }
        }

        #region DataGridView行合并.请对属性MergeColumnNames 赋值既可


        /// <summary>
        /// 画单元格.
        /// </summary>
        /// <param name="e"></param>
        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Brush gridBrush = new SolidBrush(this.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);

            //上面相同的行数.
            int upRows = 0;
            //下面相同的行数.
            int downRows = 0;
            //左边要合并的列.
            int leftColumns = 0;
            //右边要合并的列.
            int rightColumns = 0;

            Pen gridLinePen = new Pen(gridBrush);
            bool mergeRow = false;
            resetMergeRowColumns();
            #region 横向合并,必须加载完毕才能操作
            if (e.RowIndex != -1 && this._lstMergeRowColumn.Count > 0 && loadedFinish && displayedColumns.Count > 0)
            {
                foreach (List<string> lstRowColumn in _lstMergeRowColumn)
                {
                    //如果合并了,或者如果关键列不显示,就不再找了;
                    if (mergeRow || !Columns[lstRowColumn[0]].Visible) break;

                    if (!lstRowColumn.Contains(this.Columns[e.ColumnIndex].Name)) continue;
                    #region 保证都连在一起


                    leftColumns = 0;
                    rightColumns = 0;
                    for (int i = displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) - 1; i >= 0; i--)
                    {
                        if (lstRowColumn.Contains(displayedColumns[i]))
                        {
                            leftColumns++;
                            continue;
                        }
                        break;
                    }
                    for (int i = displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) + 1; i < displayedColumns.Count; i++)
                    {
                        if (lstRowColumn.Contains(displayedColumns[i]))
                        {
                            rightColumns++;
                            continue;
                        }
                        break;
                    }
                    if (leftColumns + rightColumns + 1 != lstRowColumn.Count) continue;
                    #endregion

                    string haveTheItem = checkHasTheColumn(Columns[e.ColumnIndex].Name, e.RowIndex);

                    if (haveTheItem.Length > 0)
                    {
                        stockOfAllRows[e.RowIndex].Remove(haveTheItem);
                    }

                    #region 保证头为非空,其他为空

                    if (null != this.Rows[e.RowIndex].Cells[lstRowColumn[0]])
                    {
                        string mainValue = this.Rows[e.RowIndex].Cells[lstRowColumn[0]].Value.ToString().Trim();
                        if (mainValue.Length == 0) continue;

                        bool canMergeRow = true;

                        for (int i = 1; i < lstRowColumn.Count; i++)
                        {
                            //为空,或者不可见,或者为空字符串.
                            if (this.Rows[e.RowIndex].Cells[lstRowColumn[i]].Value == null ||
                                !this.Columns[lstRowColumn[i]].Visible ||
                                string.IsNullOrEmpty(this.Rows[e.RowIndex].Cells[lstRowColumn[i]].Value.ToString()) ||
                                this.Rows[e.RowIndex].Cells[lstRowColumn[i]].Value.ToString() == mainValue)
                            {
                                continue;
                            }
                            canMergeRow = false;
                            break;
                        }
                        if (canMergeRow)
                        {
                            //以背景色填充.
                            e.Graphics.FillRectangle(backBrush, e.CellBounds);
                            PaintingFont(e, this.Rows[e.RowIndex].Cells[lstRowColumn[0]].Value.ToString().Trim(), 0, 0, leftColumns, rightColumns);
                            if (!stockOfAllRows.ContainsKey(e.RowIndex))
                            {
                                stockOfAllRows.Add(e.RowIndex, new Dictionary<string, List<string>>());
                            }
                            if (stockOfAllRows[e.RowIndex].ContainsKey(lstRowColumn[0]))
                            {
                                stockOfAllRows[e.RowIndex].Remove(lstRowColumn[0]);
                            }
                            stockOfAllRows[e.RowIndex].Add(lstRowColumn[0], lstRowColumn);
                            // 画右边线.
                            if (rightColumns == 0)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                            }

                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                            e.Handled = true;
                            mergeRow = true;
                        }

                    }
                    #endregion
                }
            }
            #endregion

            #region 竖向合并
            if (!mergeRow && _mergecolumnname != null && this._mergecolumnname.Contains(this.Columns[e.ColumnIndex].Name)
                && e.RowIndex != -1 && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                string curValue = e.Value.ToString();

                if (!string.IsNullOrEmpty(curValue))
                {
                    #region 获取下面的行数

                    for (int i = e.RowIndex + 1; i < this.Rows.Count; i++)
                    {
                        if (checkHasTheColumn(Columns[e.ColumnIndex].Name, i).Length > 0) break;
                        if (this.Rows[i].Cells[e.ColumnIndex].Value != null && this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                        {
                            downRows++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region 获取上面的行数

                    for (int i = e.RowIndex - 1; i >= 0; i--)
                    {
                        if (checkHasTheColumn(Columns[e.ColumnIndex].Name, i).Length > 0) break;
                        if (this.Rows[i].Cells[e.ColumnIndex].Value != null && this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                        {
                            upRows++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    if (downRows == 0 && upRows == 0) return;

                }
                if (this.Rows[e.RowIndex].Selected)
                {
                    backBrush.Color = e.CellStyle.SelectionBackColor;
                    fontBrush.Color = e.CellStyle.SelectionForeColor;
                }
                //以背景色填充.
                e.Graphics.FillRectangle(backBrush, e.CellBounds);
                //画字符串.
                PaintingFont(e, curValue, upRows, downRows, 0, 0);
                if (downRows == 0)
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }
                // 画右边线.
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                e.Handled = true;
            }
            #endregion
        }

        private string checkHasTheColumn(string columnName, int rowIndex)
        {
            if (stockOfAllRows.ContainsKey(rowIndex))
            {
                foreach (string sTemp in stockOfAllRows[rowIndex].Keys)
                {
                    if (stockOfAllRows[rowIndex][sTemp].Contains(columnName))
                    {
                        return sTemp;
                    }
                }
            }
            return "";
        }
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, string showValue, int UpRowsIn, int DownRowsIn, int leftColumnsIn, int rightColumnsIn)
        {
            int UpRows = UpRowsIn;
            int DownRows = DownRowsIn;
            int leftColumns = leftColumnsIn;
            int rightColumns = rightColumnsIn;
            int cellwidth = e.CellBounds.Width;
            int cellheight = e.CellBounds.Height;
            int fondHalf = (int)(e.CellStyle.Font.Size);
            int sumHeight = 0;
            for (int i = e.RowIndex - UpRows; i <= e.RowIndex + DownRows; i++)
            {
                //sumHeight += this.Rows[i].Displayed ? this.Rows[i].Height : 0;
                sumHeight += this.Rows[i].Height;
            }
            int sumWidth = 0;
            if (leftColumns > 0 || rightColumns > 0)
            {
                for (int i = displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) - leftColumns;
                    i <= displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) + rightColumns; i++)
                {
                    sumWidth += this.Columns[displayedColumns[i]].Visible ? this.Columns[displayedColumns[i]].Width : 0;
                }
            }
            else sumWidth = Columns[e.ColumnIndex].Width;

            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int fontheight = (int)e.Graphics.MeasureString(showValue, e.CellStyle.Font).Height + 1;
            int fontwidth = (int)e.Graphics.MeasureString(showValue, e.CellStyle.Font).Width + 1;

            int wordWidth = fontwidth > (sumWidth) ? (sumWidth) : fontwidth;

            int wordHeight = ((fontwidth - 1) / (sumWidth - fondHalf) + 1) * fontheight;
            //如果不到一行的情况下,字的高度设置为字体的高度.
            if (fontwidth <= sumWidth) wordHeight = fontheight;
            //如果字的高度大于总高度,只好把总高度赋值给字的高度.
            else if (wordHeight > sumHeight) wordHeight = sumHeight;

            int x0 = e.CellBounds.X;
            for (int i = displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) - 1;
                i >= displayedColumns.IndexOf(Columns[e.ColumnIndex].Name) - leftColumns; i--)
            {
                if (this.Columns[displayedColumns[i]].Visible)
                    x0 -= this.Columns[displayedColumns[i]].Width;
            }
            int y0 = e.CellBounds.Y;
            for (int i = e.RowIndex - 1; i >= e.RowIndex - UpRows; i--)
            {
                // if (this.Rows[i].Displayed)
                y0 -= this.Rows[i].Height;
            }
            Rectangle drawRec;
            int recX, recY;

            StringFormat theStringFormat = StringFormat.GenericTypographic;

            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter ||
                e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft ||
                e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                recY = y0 + sumHeight - wordHeight;
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter ||
            e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft ||
            e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                recY = y0;
            }
            else
            {
                recY = y0 + (sumHeight - wordHeight) / 2;
            }
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft ||
              e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft ||
              e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                recX = x0;
                theStringFormat.Alignment = StringAlignment.Near;
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight ||
              e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight ||
              e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                recX = x0 + sumWidth - wordWidth;
                theStringFormat.Alignment = StringAlignment.Far;
            }
            else
            {
                recX = x0 + (sumWidth - wordWidth) / 2;
                theStringFormat.Alignment = StringAlignment.Center;
            }
            Rectangle r = this.GetCellDisplayRectangle(FirstDisplayedCell.ColumnIndex, FirstDisplayedCell.RowIndex, true);
            if (recY >= r.Y)
            {
                drawRec = new Rectangle(recX, recY, wordWidth, wordHeight);
                e.Graphics.DrawString(showValue, e.CellStyle.Font, fontBrush, drawRec, theStringFormat);
            }
            //if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * UpRows + (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X, e.CellBounds.Y - cellheight * UpRows + (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * UpRows + (sumHeight - wordHeight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec, new StringFormat(StringFormatFlags.LineLimit));
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1), cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1), cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1), cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
            //else
            //{
            //    drawRec = new Rectangle(e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (sumHeight - fontheight) / 2, cellwidth, wordHeight);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, drawRec);
            //}
        }

        #endregion

        #endregion

        #region 增加报表的头和尾的定制

        private string title;

        /// <summary>
        /// 表头需要写入的内容.
        /// </summary>
        [Bindable(true), Category("自定义属性"), Description("报表的header需要写入的内容")]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public List<string> Header
        {
            get { return header; }
            set { header = value; }
        }

        private List<string> header;

        private List<string> footer;

        /// <summary>
        /// 页脚内容.
        /// </summary>
        [Bindable(true), Category("自定义属性"), Description("报表的footer需要写入的内容")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]  只有去除这句话才可以在设计时对其赋值.
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public List<string> Footer
        {
            get { return footer; }
            set { footer = value; }
        }
        /// <summary>
        /// 报表头.
        /// </summary>
        [Bindable(true), Category("自定义属性"), Description("报表的title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 写入title
        /// </summary>
        private void writeTitle()
        {
            if (!string.IsNullOrEmpty(title))
            {
                Insert(1, title, true);
            }
        }

        /// <summary>
        /// 写入header
        /// </summary>
        private void writeHeader()
        {
            for (int i = header.Count - 1; i >= 0; i--)
            {
                Insert(1, header[i], false);
            }
        }

        /// <summary>
        /// 写入footer
        /// </summary>
        /// <param name="maxRows">开始写入的行</param>
        private void writeFooter(int maxRows)
        {
            for (int i = 0; i < footer.Count; i++)
            {
                WriteExcels(maxRows + i, 1, visibleCols, footer[i]);
            }
        }

        #endregion

        string lastOjbect = "";
        bool sysControl;
        public void BandingDatasourceEx(DataTable dt)
        {
            sysControl = true;
            this.DataSource = dt;
            string newOjbect;
            int rowNumber;
            rowNumber = this.currentRow;
            if (rowNumber < 0 || RowCount == 0)
            {
                selectionChanged(-1);
            }
            else if (lastOjbect.Length == 0)
            {
                selectionChanged(currentRow);
            }
            else if (Columns.Count > 0)
            {
                for (int i = 0; i < Rows.Count; i++)
                {
                    if (this.Rows[i].Cells[0].Value != null)
                    {
                        newOjbect = this.Rows[i].Cells[0].Value.ToString();
                        if (newOjbect == lastOjbect)
                        {
                            if (this.Columns.Count > 0)
                            {
                                CurrentCell = this.Rows[i].Cells[1];
                                selectionChanged(i);
                                sysControl = false;
                                return;
                            }
                            break;
                        }
                    }

                }
                selectionChanged(currentRow);
                if (this.Rows[currentRow].Cells[0].Value != null)
                {
                    lastOjbect = this.Rows[currentRow].Cells[0].Value.ToString();
                }
            }
            //重新加载数据时,自己找到原数据,滚动到指定位置.
            sysControl = false;
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            base.OnRowEnter(e);
            if (sysControl)
            {
                return;
            }
            selectionChanged(e.RowIndex);
        }

        private void selectionChanged(int row)
        {
            if (row >= 0 && this.Rows[row].Cells[0].Value != null)
            {
                lastOjbect = this.Rows[row].Cells[0].Value.ToString();
            }
            else
            {
                lastOjbect = "";
            }
            if (SelectedChanged != null)
            {
                SelectedChanged(row);
            }
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// 设置指定列为只读.
        /// </summary>
        public void setDgvColumnsReadOnly(string[] sCol)
        {
            foreach (string curCol in sCol)
            {
                if (this.Columns.Contains(curCol))
                {
                    this.Columns[curCol].ReadOnly = true;
                    Color GridReadOnlyColor = Color.Linen;
                    this.Columns[curCol].DefaultCellStyle.BackColor = GridReadOnlyColor;
                }
            }
        }

        /// <summary>
        /// 设置所有为DateTime类型的列的Format显示格式为短格式"yyyy/MM/dd"
        /// </summary>
        public void SetDgvGridDateColumnsFormatShort()
        {
            foreach (DataGridViewColumn item in this.Columns)
            {
                if (item.ValueType == typeof(DateTime))
                    item.DefaultCellStyle.Format = "yyyy/MM/dd";
            }
        }
        /// <summary>
        /// 设置指定网格中的指定列为只读.
        /// </summary>
        /// <param name="sColumns">字段,只变此值有内容的列</param>
        /// <param name="sCol">包含要设置只读属性的列名称的数组</param>
        public void setDgvCellReadOnly(string sColumns, string[] sCol)
        {
            if (!this.Columns.Contains(sColumns)) return;
            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string curId = dgvRow.Cells[sColumns].Value.ToString();
                if (curId.Trim().Length > 0)
                {
                    foreach (string curCol in sCol)
                    {
                        dgvRow.Cells[curCol].ReadOnly = true;
                        dgvRow.Cells[curCol].Style.BackColor = Color.Linen;
                    }
                }
            }
        }
        public void ScrollToDefinedRow(string columnsName, string value)
        {
            currentRow = 0;
            dgvSearch(columnsName, value, ref currentRow);
        }

        public void SetDataGridViewNoSort()
        {
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            loadedFinish = false;
        }
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            myNodeLevels();
            loadedFinish = true;
        }
        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    this.Refresh();
        //}
        protected override void OnSorted(EventArgs e)
        {
            base.OnSorted(e);
            this.Refresh();
        }
        protected override void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnDisplayIndexChanged(e);
            resetColumnDisplayArray();
        }

        private void resetColumnDisplayArray()
        {
            displayedColumns.Clear();
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Visible)
                {
                    bool find = false;
                    for (int r = displayedColumns.Count - 1; r >= 0; r--)
                    {
                        if (Columns[displayedColumns[r]].DisplayIndex < Columns[i].DisplayIndex)
                        {
                            find = true;
                            displayedColumns.Insert(r + 1, Columns[i].Name);
                            break;
                        }
                    }
                    if (!find)
                    {
                        displayedColumns.Insert(0, Columns[i].Name);
                    }
                }
            }
        }

        /// <summary>
        /// 判断当前值在网格dgv的colname列中是否存在重复值，如果存在则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <param name="curVal">当前要判断的值</param>
        /// <returns>返回bool值</returns>
        public bool HasRepliVal(string colname, string curVal)
        {
            int replicount = 0;     //值curVal在列colname中重复的次数.
            bool blnResult = false;

            //值curVal为空时不进行判断.
            if (curVal.Trim().Equals(""))
            {
                return false;
            }

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString().ToUpper();
                if (sCurCell.Trim().Equals(curVal.ToUpper()))
                {
                    replicount += 1;
                }
            }

            if (replicount >= 2)
            {
                blnResult = true;
            }
            return blnResult;
        }
        /// <summary>
        /// 判断当前值在网格dgv的colname1列和colname2列的组合值中是否存在重复值，如果存在则返回true
        /// </summary>
        /// <param name="colname1">要校验的列名称1</param>
        /// <param name="colname1">要校验的列名称2</param>
        /// <param name="curVal">当前要判断的值（它是两个列的组合值）</param>
        /// <returns>返回bool值</returns>
        public bool HasRepliVal(string colname1, string colname2, string curVal)
        {
            int replicount = 0;     //值curVal在列colname中重复的次数.
            bool blnResult = false;

            //值curVal为空时不进行判断.
            if (curVal.Trim().Equals(""))
            {
                return false;
            }

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell1 = dgvRow.Cells[colname1].Value.ToString();
                string sCurCell2 = dgvRow.Cells[colname2].Value.ToString();
                string sCurCell = sCurCell1 + sCurCell2;

                if (sCurCell.Trim().Equals(curVal))
                {
                    replicount += 1;
                }
            }

            if (replicount >= 2)
            {
                blnResult = true;
            }
            return blnResult;
        }

        public bool HasValue(string colname, string curVal)
        {
            //值curVal为空时不进行判断.
            if (curVal.Trim().Equals(""))
            {
                return false;
            }

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString().ToUpper();
                if (sCurCell.Trim().Equals(curVal.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断网格dgv的列colname中是否存在不为空的单元格，如果有则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值，如果存在一个不为空的单元格，则返回true，全空返回false</returns>
        public bool HasEmptyVal(string colname)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString();
                if (sCurCell.Trim().Length == 0)
                {
                    blnResult = true;
                    break;
                }
            }

            return blnResult;
        }

        /// <summary>
        /// 判断网格dgv的colname列中是否存在重复值，如果存在则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值</returns>
        public bool HasRepliVal(string colname)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString();
                if (this.HasRepliVal(colname, sCurCell))
                {
                    return true;
                }
            }
            return blnResult;
        }
        /// <summary>
        /// 判断网格dgv的colname1和colname2两个列是存在相等值，如果存在则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <param name="diff">此参数没有实际意义，仅仅是不致使重载函数重复</param>
        /// <returns>返回bool值</returns>
        public bool HasRepliColumn(string colname1, string colname2)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell1 = dgvRow.Cells[colname1].Value.ToString();
                string sCurCell2 = dgvRow.Cells[colname2].Value.ToString();
                if (sCurCell1.Equals(sCurCell2))
                {
                    return true;
                }
            }
            return blnResult;
        }

        /// <summary>
        /// 判断网格dgv的列colname中的所有值是否都是数值型的，如果不是则返回false
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值</returns>
        public bool IsNumeric(string colname)
        {
            bool blnResult = true;
            float fltValidate = 0.0f;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString();

                //如果为空，则变为0
                if (sCurCell.Length == 0)
                {
                    sCurCell = "0";
                }
                if (float.TryParse(sCurCell, out fltValidate) == false)
                {
                    blnResult = false;
                    break;
                }
            }

            return blnResult;
        }

        /// <summary>
        /// 判断某列是否为0或负数.
        /// </summary>
        /// <param name="colname"></param>
        /// <returns></returns>
        public bool IsNagativeOrZeroNumeric(string colname)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                if (Math.Sign(double.Parse(dgvRow.Cells[colname].Value.ToString())) == 0 || Math.Sign(double.Parse(dgvRow.Cells[colname].Value.ToString())) == -1)
                {
                    blnResult = true;
                }
            }
            return blnResult;
        }
        private void UcDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            //设置集合dictColumns中的所有列的列标题.
            foreach (DataGridViewColumn column in Columns)
            {
                //2011-10-26 数字型的自动过滤小数点后的内容,并靠右排.
                if (column.Visible && (column.ValueType == typeof(float) || column.ValueType == typeof(decimal)
                    || column.ValueType == typeof(double)))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //   column.DefaultCellStyle.Format = "0.######";
                }
            }
        }
    }

    public delegate void CheckBoxClickedHandler(bool state);

    /// <summary>
    /// 改变列头的CheckBox的状态
    /// </summary>
    /// <param name="state"></param>
    public delegate void ChangeCheckBoxStatusHandler(bool state);

    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }

        public bool Checked
        {
            get { return _bChecked; }
        }
    }


    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;
        public event ChangeCheckBoxStatusHandler OnChangeCheckBoxStatusHandler;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }


            }
            this.DataGridView.Refresh();
            base.OnMouseClick(e);
        }

        /// <summary>
        /// 改变列头CheckBox的状态的事件
        /// </summary>
        /// <param name="NewStatus"></param>
        public void OnChangeCheckBoxStatus(bool NewStatus)
        {
            if (OnCheckBoxClicked != null)
            {
                _checked = NewStatus;
                if (OnChangeCheckBoxStatusHandler != null)
                {
                    OnChangeCheckBoxStatusHandler(NewStatus);
                }
                if (this.DataGridView != null)
                {
                    this.DataGridView.InvalidateCell(this);
                }
                this.DataGridView.Refresh();
            }
        }

    }
}