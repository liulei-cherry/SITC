using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;

namespace CommonViewer.BaseControl
{
    public partial class UCObjectsGridView : UserControl
    {
        private CommonClass theSelectedValue;
        private DataTable dtToShow;
        private IObjectsService theService; 
        private string text="";
        private string datagridInfo;
        #region 委托

        public delegate void ObjectChanged(CommonClass theNewObject);
        public event ObjectChanged TheObjectChanged;

        public delegate void deleDoubleClick(int rowIndex);
        public event deleDoubleClick UserDoubleClick;

        #endregion

        [Browsable(true), Category("用户自定义区域"), Description("DataGridView的ReadOnly属性")]
        public bool ReadOnly
        {
            set 
            {
                ucObjectsView.ReadOnly = value;
            }
            get
            {
                return ucObjectsView.ReadOnly;
            }
        }
        [Browsable(true), Category("用户自定义区域"), Description("DataGridView的Column是否Fill属性")]
        public bool AutoColumnsFill
        {
            set
            {
                if (value)
                { 
                    ucObjectsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
                }
                else
                {
                    ucObjectsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }
            }
            get
            {
                return (ucObjectsView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill);
            }
        }
        public UCObjectsGridView()
        {
            InitializeComponent();
          
            ucObjectsView.SelectedChanged += new UcDataGridView.DeleSelectedChanged(ucObjectsView_SelectedChanged);            
        }

        void ucObjectsView_SelectedChanged(int rowNumber)
        {
            if (TheObjectChanged != null)
            {
                //判断上一个对象与当前对象是否相同,如果不相同,则调用对象变化.
                CommonClass theNewObject = GetObject(rowNumber);
                if (theNewObject!=null && !theNewObject.EqualTo(theSelectedValue))
                {
                    theSelectedValue = theNewObject;
                    TheObjectChanged(theSelectedValue);
                }
            }
        }
        /// <summary>
        /// 初始化控件方法.
        /// </summary>
        /// <param name="showName">groupbox的名</param>
        /// <param name="dtToShowIn">数据</param>
        /// <param name="theServiceIn">实现接口</param>
        /// <param name="datagridInfo">给这个datagrid起个名,方便以后保存其大小</param>
        public void Init( DataTable dtToShowIn, IObjectsService theServiceIn,string datagridInfo)
        {
            theSelectedValue = null;
            this.datagridInfo = datagridInfo;
            if (dtToShowIn != null )
            {
                dtToShow = dtToShowIn;
                theService = theServiceIn;
                ucObjectsView.DataSource = dtToShow;
                ucObjectsView.LoadGridView(this.datagridInfo);
                ucObjectsView.SetDgvGridColumns(theServiceIn.GetObjectDisplaySetting());
            }
            else
            {
                ucObjectsView.DataSource = 0;//当传入空的数据集合时，直接清空该控件的数据.
                //throw new Exception("调用UCObjectsGridView的Init时,使用了空的数据集合,造成控件无法使用!");
            }
        }
        public void ScrollToColumnWithValue(string valueColumn, string valueSelect)
        {
            int firstDisplayedColumnIndex = -1;
            //默认显示valueselect的值.
            try
            {

                firstDisplayedColumnIndex = ucObjectsView.FirstDisplayedCell.ColumnIndex;
            }
            catch { }
            if (firstDisplayedColumnIndex == -1) firstDisplayedColumnIndex = 1;

            string value = "";
            for (int i = 0; i <= ucObjectsView.RowCount - 1; i++)
            {
                if (ucObjectsView.Rows[i].Cells[valueColumn].Value != null)
                {
                    value = ucObjectsView.Rows[i].Cells[valueColumn].Value.ToString();
                }
                if (value == valueSelect)
                {
                    ucObjectsView.CurrentCell = ucObjectsView[firstDisplayedColumnIndex, i];//显示当前行.
                    ucObjectsView_SelectedChanged(i);
                    break;
                }

            }
        }
        public void Init(DataTable dtToShowIn, IObjectsService theServiceIn, string valueColumn, string valueSelect, string datagridInfo)
        {
            try
            {
                Init(dtToShowIn, theServiceIn, datagridInfo);
                ScrollToColumnWithValue(valueColumn, valueSelect);
            }
            catch(Exception e)
            {
                MessageBoxEx.Show(e.Message);
            }
           
        }

        [Browsable(true), Category("用户自定义区域"), Description("DataGridView的显示名称")]
        public string ShowText
        {
            set
            {
                text = value;
                if (!string.IsNullOrEmpty(text)) groupBox1.Text = text;
            }
            get 
            {
                return text;
            }
        }

        public DataGridView DataGridView
        {
            get
            {
                return ucObjectsView;
            }
        }
        public CommonClass GetObject(int rowNumber)
        {
            string itemId;
            if (rowNumber >= 0 && ucObjectsView.Rows.Count > rowNumber)
            {
                itemId = ucObjectsView.Rows[rowNumber].Cells[0].Value.ToString();
            }
            else
            {
                itemId = "";
            }
            return theService.GetOneObjectById(itemId);
        }

        private void ucObjectsView_DoubleClick(object sender, EventArgs e)
        {
            if (ucObjectsView.CurrentRow == null) return;
            ucObjectsView_SelectedChanged(ucObjectsView.CurrentRow.Index );
            if (UserDoubleClick != null)
            {
                UserDoubleClick(ucObjectsView.CurrentRow.Index);
            }
        }
        public DataTable GetDataTable()
        {
            return (DataTable)ucObjectsView.DataSource;
        }

        public void SaveDataGridView()
        {
            ucObjectsView.SaveGridView(datagridInfo);
        }

        private void UCObjectsGridView_Load(object sender, EventArgs e)
        { 
            if (!string.IsNullOrEmpty(text)) groupBox1.Text = text;
        }
    }
}
