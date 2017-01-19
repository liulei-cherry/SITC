using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
namespace BaseInfo.Viewer
{
    public partial class FrmPortInfoSelect : CommonViewer.FrmBaseSelectValue
    {
        public FrmPortInfoSelect()
        {
            #region 基类委托部分
            Init = new DgInit(init);
            GetNewDataTable = new DgGetNewDataTable(getNewDataTable);
            GetSelectedValue = new DgGetSelectedValue(getSelectedValue);
            loaded = true;
            #endregion 委托结束

            InitializeComponent();

            #region gridview委托部分
            ucObjectsGridView1.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(ucObjectsGridView1_TheObjectChanged);
            ucObjectsGridView1.UserDoubleClick += new CommonViewer.BaseControl.UCObjectsGridView.deleDoubleClick(ucObjectsGridView1_UserDoubleClick);
            #endregion

        }

        void ucObjectsGridView1_UserDoubleClick(int rowIndex)
        {
            ValueUseful = true;
            this.Close();
        }

        void ucObjectsGridView1_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (!theNewObject.IsWrong)
            {
                selectedValue = theNewObject.GetId(); 
                ucPort1 .ChangeData(theNewObject);
            }
            else
            {
                ucPort1.ClearData();
                selectedValue = "";
            }
        }

        /// <summary>
        /// 得到新的数据表,如果结构不一致,将会出问题,
        /// 所以datatable必须是这边加载的时候必须使用同一个datatable
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            return ucObjectsGridView1.GetDataTable();
        }
        private string getSelectedValue()
        {
            return selectedValue;
        }

        /// <summary>
        /// 初始化窗体的借口,必须使用指定的Datatable
        /// </summary>
        /// <param name="dt"></param>
        private void init(DataTable dt, string valueColumnIn, string valueSelectIn)
        {
            ucObjectsGridView1.Init(dt, DataAccess.PortInfoService.Instance, valueColumnIn, valueSelectIn,"ShipPort");
        }

        private void buttonEx2_Click_1(object sender, EventArgs e)
        {
            ValueUseful = true;
            this.Close();
        }

        private void buttonEx3_Click_1(object sender, EventArgs e)
        {
            //
            FrmEditOnePort frm = new FrmEditOnePort();
            frm.ShowDialog();
            if (frm.NeedRetrieve)
            {
                reloadData();//重载数据.
            }
        }

        private void buttonEx5_Click_1(object sender, EventArgs e)
        {
            ucPort1.DeleteObject();
            if (ucPort1.needRetrieve == true)
            {
                reloadData();//重载数据.
            }
        }

        private void buttonEx6_Click_1(object sender, EventArgs e)
        {
            ucPort1.UpdateObject();
            
        }

        private void buttonEx7_Click_1(object sender, EventArgs e)
        {
            ValueUseful = false;
            this.Close();
        }
        public void reloadData()
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.PortInfoService.Instance.getInfo(out err);
            ucObjectsGridView1.Init(dt, BaseInfo.DataAccess.PortInfoService.Instance, "ShipPort");
        }

        private void FrmPortInfoSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucObjectsGridView1.SaveDataGridView();
        }
    }
}
