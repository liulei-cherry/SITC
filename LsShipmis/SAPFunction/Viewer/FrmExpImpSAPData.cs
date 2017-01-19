using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.Viewer;
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage;
using System.IO;
using CommonViewer.BaseControl;
using OfficeOperation;
using CommonViewer.BaseForm;
using SAPFunction.Services;
using SAPFunction.DataObject;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace SAPFunction.Viewer
{
    public partial class FrmExpImpSAPData : CommonViewer.BaseForm.FormBase
    {
        public FrmExpImpSAPData()
        {
            InitializeComponent();
        }
        IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        List<string> wzIds = new List<string>();
        List<string> gysIds = new List<string>();
        Excel toOperExcel;
        /// <summary>
        /// 窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmExpImpSAPData_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// 导出.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //导出.
            if (tabControl1.SelectedTab == tabPage1)
                ucDataGridView1.OutPutExcel();
            else if (tabControl1.SelectedTab == tabPage3)
                ucDataGridView3.OutPutExcel();
        }
        /// <summary>
        /// 导入.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            //打开对话框选择excel文件.
            DialogResult theResult = OpenFileDialogEx.ShowDialog(openFileDialog1);
            if (theResult != DialogResult.OK)
            {
                MessageBoxEx.Show("用户取消了选择");
                return;
            }
            string fileName = openFileDialog1.FileName;

            //传递给importExcel(Excel toOperExcel)
            if (File.Exists(fileName))
            {
                FileInfo f = new FileInfo(fileName);
                if (toOperExcel != null) Excel.release(toOperExcel.pt);
                toOperExcel = new Excel();
                try
                {
                    toOperExcel.OpenDocument(fileName);
                    FrmBusy frmBusy = new FrmBusy("正在导入所选择的文件内容\r\nNow is loading the file......", new FrmBusy.FinishedOpeartion(importExcel));
                    frmBusy.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("文件无法打开,可能是用户没有安装Excel,或者没有权限操作选定的文件,(" + ex.Message + ")");
                }
                finally
                {
                    toOperExcel.CloseDocument();
                    toOperExcel.Dispose();
                }
            }
        }
        /// <summary>
        /// 校验并导入Excel数据.
        /// </summary>
        private void importExcel()
        {
            string err = "";
            int maxRow = toOperExcel.GetMaxRowNumber(1);
            for (int nowRow = 2; nowRow <= maxRow; nowRow++)
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    string sItemId = toOperExcel.GetValue("A" + nowRow.ToString());
                    string sItemType = toOperExcel.GetValue("D" + nowRow.ToString());
                    string sItemSapId = toOperExcel.GetValue("F" + nowRow.ToString());
                    if (string.IsNullOrEmpty(sItemId) || string.IsNullOrEmpty(sItemType) || string.IsNullOrEmpty(sItemSapId))
                    {
                        err += "第" + nowRow.ToString() + "行记录无效,存在必填字段为空的情况:(A,D,F)三列均不允许为空\r\n";
                        continue;
                    }
                    //判断sItemType是否有效(只能是 绑扎件,化学品,缆绳,物料,油漆费,备件,滑油类的某一种.

                    if (!"绑扎件,化学品,缆绳,滑油类,物料,油漆,备件".Contains(sItemType.Trim()))
                    {
                        err += nowRow.ToString() + "行数据种类不符,无法进行导入\r\n";
                        continue;
                    }
                    //查找sItemId是否有效(从备件和物资表联合查询)
                    if (sItemType.Trim().Equals("备件"))
                    {
                        if (!dbOperation.DbHaveThisData(sItemId, "T_SPARE", "SPARE_ID", "SPARE_ID", ""))
                            err += nowRow.ToString() + "行船舶管理系统的备件ID无效,无法继续导入\r\n";
                        continue;
                    }
                    else if (sItemType.Trim().Equals("滑油类"))
                    {
                        if (!dbOperation.DbHaveThisData(sItemId, "T_HOIL", "OIL_ID", "OIL_ID", ""))
                            err += nowRow.ToString() + "行船舶管理系统的滑油类ID无效,无法继续导入\r\n";
                        continue;
                    }
                    else
                    {
                        if (!dbOperation.DbHaveThisData(sItemId, "T_MATERIAL", "MATERIAL_ID", "MATERIAL_ID", ""))
                            err += nowRow.ToString() + "行船舶管理系统的物资ID无效,无法继续导入\r\n";
                        continue;
                    }
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    string sItemId = toOperExcel.GetValue("A" + nowRow.ToString());
                    string sItemSapId = toOperExcel.GetValue("C" + nowRow.ToString());
                    if (string.IsNullOrEmpty(sItemId) || string.IsNullOrEmpty(sItemSapId))
                    {
                        err += "第" + nowRow.ToString() + "行记录无效,存在必填字段为空的情况:(A,D)两列均不允许为空\r\n";
                        continue;
                    }
                    //查找sItemId是否有效.
                    if (!dbOperation.DbHaveThisData(sItemId, "T_MANUFACTURER", "MANUFACTURER_ID", "MANUFACTURER_ID", ""))
                    {
                        err += nowRow.ToString() + "行船舶管理系统的供应商ID无效,无法继续导入\r\n";
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(err))
            {
                for (int nowRow = 2; nowRow <= maxRow; nowRow++)
                {
                    if (tabControl1.SelectedTab == tabPage1)
                    {
                        string sItemId = toOperExcel.GetValue("A" + nowRow.ToString());
                        string sItemType = toOperExcel.GetValue("D" + nowRow.ToString());
                        string sItemSapId = toOperExcel.GetValue("F" + nowRow.ToString());
                        //查找sItemSapId是否已经导入过,而且跟之前不一样,如果不一样,要删除原来的关联,然后再换成当前的对应.
                        if (!MaterialMappingService.Instance.ResetTheMaterialMapping(sItemId, sItemSapId, out err))
                        {
                            MessageBoxEx.Show(nowRow.ToString() + "行设置映射时出错,无法继续导入");
                            return;
                        }
                    }
                    else if (tabControl1.SelectedTab == tabPage3)
                    {
                        string sItemId = toOperExcel.GetValue("A" + nowRow.ToString());
                        string sItemSapId = toOperExcel.GetValue("C" + nowRow.ToString());
                        //删除原来的关联,然后添加当前的对应.

                        if (!SupplierMappingService.Instance.ResetTheSupplierMapping(sItemId, sItemSapId, out err))
                        {
                            MessageBoxEx.Show(nowRow.ToString() + "行设置映射时出错,无法继续导入");
                            return;
                        }
                    }
                }
                MessageBoxEx.Show("操作成功");
            }
            else
            {
                MessageBoxEx.Show(err);
            }
        }
        /// <summary>
        /// 导入备件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx1_Click(object sender, EventArgs e)
        {
            string err;
            //物资.
            FrmSelectSpare frm = new FrmSelectSpare();
            frm.ShowDialog();
            if (frm.Selected)
            {
                DataTable dtbMaterial = MaterialMappingService.Instance.GetAllInfo(out err);

                //MaterialIds
                foreach (StorageParameter spare in frm.Spares)
                {
                    string spareId = spare.ItemId;
                    if (gysIds.Contains(spareId.ToUpper()))
                        continue;
                    if (dtbMaterial.Select("MANAGEMENT='" + spareId + "'").Length > 0)
                        continue;

                    SpareInfo spareInfo = SpareInfoService.Instance.getObject(spareId, out err);
                    if (spareInfo != null && !spareInfo.IsWrong)
                    {
                        gysIds.Add(spareId.ToUpper());
                        int rowNo = ucDataGridView1.Rows.Add();
                        ucDataGridView1.Rows[rowNo].Cells[0].Value = spareId;
                        ucDataGridView1.Rows[rowNo].Cells[1].Value = spareInfo.ToString();
                        ucDataGridView1.Rows[rowNo].Cells[2].Value = spareInfo.UNIT_NAME;
                        ucDataGridView1.Rows[rowNo].Cells[3].Value = "备件";
                        ComponentUnit equipment = SpareInfoService.Instance.SpareOfEquipment(spareId);
                        ucDataGridView1.Rows[rowNo].Cells[4].Value = "辅助备件";//主机备件,副机备件,辅助备件.
                        while (equipment != null && !equipment.IsWrong)
                        {
                            if (equipment.COMP_CHINESE_NAME.Contains("主机"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "主机备件";//主机备件,副机备件,辅助备件.
                            }
                            else if (equipment.COMP_CHINESE_NAME.Contains("柴油发电机") || equipment.COMP_CHINESE_NAME.Contains("发电柴油机"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "副机备件";//主机备件,副机备件,辅助备件.
                            }
                            else
                            {
                                equipment = ComponentUnitService.Instance.getObject(equipment.PARENT_UNIT_ID, out err);
                                continue;
                            }
                            break;
                        }
                        ucDataGridView1.Rows[rowNo].Cells[5].Value = "";//映射的sap代码,不需要设置值.

                    }
                }
            }
        }
        /// <summary>
        /// 导入物资.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            string err;
            //物资.
            FrmSelectMaterial frm = new FrmSelectMaterial();
            frm.ShowDialog();
            if (frm.Selected)
            {
                DataTable dtbMaterial = MaterialMappingService.Instance.GetAllInfo(out err);

                //MaterialIds
                foreach (string materialId in frm.MaterialIds)
                {
                    if (gysIds.Contains(materialId.ToUpper()))
                        continue;

                    if (dtbMaterial.Select("MANAGEMENT='" + materialId + "'").Length > 0)
                        continue;

                    MaterialInfo materialInfo = MaterialInfoService.Instance.getObject(materialId, out err);
                    if (materialInfo != null && !materialInfo.IsWrong)
                    {
                        gysIds.Add(materialId.ToUpper());
                        int rowNo = ucDataGridView1.Rows.Add();
                        ucDataGridView1.Rows[rowNo].Cells[0].Value = materialId;
                        ucDataGridView1.Rows[rowNo].Cells[1].Value = materialInfo.ToString();
                        ucDataGridView1.Rows[rowNo].Cells[2].Value = materialInfo.UNIT_NAME;
                        materialInfo.FillThisObject();
                        MaterialType theTempType = materialInfo.TheType;
                        ucDataGridView1.Rows[rowNo].Cells[3].Value = "物料";
                        ucDataGridView1.Rows[rowNo].Cells[4].Value = "";
                        while (theTempType != null)
                        {
                            if (theTempType.MATERIAL_TYPE_NAME.Contains("绑扎件"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "绑扎件";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "绑扎件";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.

                            }
                            else if (theTempType.MATERIAL_TYPE_NAME.Contains("化学品"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "化学品";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "化学品";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.
                            }
                            else if (theTempType.MATERIAL_TYPE_NAME.Contains("缆绳"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "缆绳";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "缆绳";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.
                            }
                            else if (theTempType.MATERIAL_TYPE_NAME.Contains("油漆"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "油漆";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "油漆";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.
                            }
                            else if (theTempType.MATERIAL_TYPE_NAME.Contains("生产物料"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "物料";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "生产物料";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.
                            }
                            else if (theTempType.MATERIAL_TYPE_NAME.Contains("生活物料"))
                            {
                                ucDataGridView1.Rows[rowNo].Cells[3].Value = "物料";//得到大类代码 绑扎件,化学品,缆绳,物料,油漆费.

                                ucDataGridView1.Rows[rowNo].Cells[4].Value = "生活物料";//得到小类代码 绑扎件,化学品,缆绳,生产物料,生活物料,油漆费.
                            }
                            else
                            {
                                theTempType.FillThisObject();
                                theTempType = theTempType.TheParentType;
                                continue;
                            }
                            break;
                        }
                        ucDataGridView1.Rows[rowNo].Cells[5].Value = "";//映射的sap代码,不需要设置值.

                    }
                }
            }
        }
        /// <summary>
        ///一下子列出所有没有对应过的供应商,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx3_Click(object sender, EventArgs e)
        {
            string err;
            DataTable dt;
            if (!SupplierMappingService.Instance.GetSupplierSelect(out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBoxEx.Show("目前没有未映射的供应商");
                return;
            }
            ucDataGridView3.DataSource = dt;
        }
        /// <summary>
        /// 关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
