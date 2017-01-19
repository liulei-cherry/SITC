using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using ShipCertification.DataObject;
using ShipCertification.Services;
using ShipCertification.Viewer;

namespace ShipCertification.PlugIn
{
    public partial class FrmShipCertDepartSelect : CommonViewer.FrmBaseSelectValue
    {
        public FrmShipCertDepartSelect()
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
                ucShipCertDepart1.ChangeData(theNewObject);
            }
            else
            {

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
        private void init(DataTable dt,string valueColumn,string valueSelect)
        {
            ucObjectsGridView1.Init(dt, ShipCertDepartService.Instance, valueColumn, valueSelect,"FrmShipCertDepart");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ValueUseful = true;
            this.Close();   
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ValueUseful = false;
            this.Close ();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ucShipCertDepart1.UpdateObject();
        }
        /// <summary>
        /// add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx3_Click(object sender, EventArgs e)
        {
            FrmEditOneShipCertDepart formNew = new FrmEditOneShipCertDepart();
            formNew.ShowDialog();
            //当新添加数据时，刷新ucObjectsGridView1的值.
            if (formNew.NeedRetrieve)
            {
                reloadData();//重载数据.
            }
           
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            ucShipCertDepart1.DeleteObject();
            if (ucShipCertDepart1.needRetrieve == true)
            {
                reloadData();//重载数据.
            }

        }
        public void reloadData()
        {
            DataTable dt; 
            string err;
            dt = ShipCertDepartService.Instance.getInfo(out err);

            ucObjectsGridView1.Init(dt, ShipCertDepartService.Instance, "FrmShipCertDepart");
        }

        private void FrmShipCertDepartSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucObjectsGridView1.SaveDataGridView();
        }
    }
}
