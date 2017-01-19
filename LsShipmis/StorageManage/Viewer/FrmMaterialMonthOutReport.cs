using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms; 
using FileOperationBase.Services; 
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using StorageManage.Services;
using CommonViewer.BaseControl;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialMonthOutReport : CommonViewer.BaseForm.FormBase
    {          
        int year;
        int month;

        public FrmMaterialMonthOutReport()
        {
            InitializeComponent();
        }

        private void FrmMonthReport_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);    
            for(int i = 0;i<8;i++)
            {
                cbbxyear.Items.Add(DateTime.Today.Year - i);
            }
            cbbxyear.Text = DateTime.Today.Year.ToString();
            cbbmonth.Text = DateTime.Today.Month.ToString();
            cbbxyear.SelectedIndexChanged += new EventHandler(cbbxyear_SelectedIndexChanged);
            cbbmonth.SelectedIndexChanged += new EventHandler(cbbmonth_SelectedIndexChanged);
            BindData();
        }

        private void BindData()
        {
            try
            {
                if (year.ToString() == this.cbbxyear.SelectedItem.ToString() 
                    && month.ToString() == this.cbbmonth.SelectedItem.ToString()) return;
                year = Int32.Parse(this.cbbxyear.SelectedItem.ToString()); 
                month = Int32.Parse(this.cbbmonth.SelectedItem.ToString());
            }
            catch
            {
                return;
            }

            if (!string.IsNullOrEmpty(ucShipSelect1.GetId ()))
            {
                DataTable mTable = MaterialDepotOperationService.Instance.GetMonthMaterialOut(ucShipSelect1.GetId(), year, month);
                dgv.DataSource = mTable;
                Dictionary<string, string> gridColumns = new Dictionary<string, string>();
                gridColumns.Add("MATERIAL_CODE", "物资编码");
                gridColumns.Add("material_name", "物资名称");
                gridColumns.Add("MATERIAL_SPEC", "规格型号");  
                gridColumns.Add("COUNT", "本月消耗量");
                gridColumns.Add("unit_name", "计量单位");
                gridColumns.Add("stocksum", "库存余量");
                dgv.SetDgvGridColumns(gridColumns);
                dgv.LoadGridView("FrmMaterialMonthOutReport");
            }
        }

        private void FrmMonthReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgv.SaveGridView("FrmMaterialMonthOutReport"); 
        }
 
        private void cbbxyear_SelectedIndexChanged(object sender, EventArgs e)
        {           
            BindData();
        }

        private void cbbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsbtnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {               
                dgv.Title = "船舶主要物资" + month.ToString() + "月份消耗报表";
                dgv.Header.Clear();
                dgv.Header.Add("船名：" + ucShipSelect1.GetText() + "                      部门长：");
                dgv.OutPutExcel();               
            }
            else
            {
                MessageBoxEx.Show("没有数据！");
            }
        }

        private void tsbtnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        { 
            BindData();
        }
    }

}