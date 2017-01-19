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
using CustomerTable;
using System.Runtime.InteropServices;
using FileOperationBase.FileServices;
using CommonOperation.BaseClass;
using CommonViewer.BaseControl;

namespace CustomerTable.Forms
{
    public partial class FrmModelUpdate : CommonViewer.BaseForm.FormBase
    {   
        private static FrmModelUpdate instance = new FrmModelUpdate();
        public static FrmModelUpdate Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FrmModelUpdate();
                }
                return instance;
            }
        }

        private WorkModelType workModelType;
        public WorkModelType WorkModelType
        {
            get
            {
                return workModelType;
            }
            set
            {
                if (value == null)
                {
                    workModelType = null;
                }
                else
                {
                    workModelType = value;
                }
            }
        }
        string shipid = "";
        string shipName = "";
        string err = "";

        List<string> modelName = CustomerTableConfig.GetAllCustomerTables();
        public FrmModelUpdate()
        {
            InitializeComponent();
            ucShipSelect1.ChangeSelectedState(false);
        }

        private void FrmModelUpdate_Load(object sender, EventArgs e)
        {
            ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
            
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfMonthlyCompleteReport) && !modelName.Contains(CommonPrintTableName.CTNOfMonthlyCompleteReport))
            {
                modelName.Add(CommonPrintTableName.CTNOfMonthlyCompleteReport);
            }
            //证书部分.
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfShipCertification) && !modelName.Contains(CommonPrintTableName.CTNOfShipCertification))
            {
                modelName.Add(CommonPrintTableName.CTNOfShipCertification);
            }
            //油料部分.
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfOilApply) && !modelName.Contains(CommonPrintTableName.CTNOfOilApply))
            {
                modelName.Add(CommonPrintTableName.CTNOfOilApply);
            }
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfOilOrder) && !modelName.Contains(CommonPrintTableName.CTNOfOilOrder))
            {
                modelName.Add(CommonPrintTableName.CTNOfOilOrder);
            }
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfHLuboilOilReport) && !modelName.Contains(CommonPrintTableName.CTNOfHLuboilOilReport))
            {
                modelName.Add(CommonPrintTableName.CTNOfHLuboilOilReport);
            }
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfHOilReport) && !modelName.Contains(CommonPrintTableName.CTNOfHOilReport))
            {
                modelName.Add(CommonPrintTableName.CTNOfHOilReport);
            }
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfEquipmentMaintenance) && !modelName.Contains(CommonPrintTableName.CTNOfEquipmentMaintenance))
            {
                modelName.Add(CommonPrintTableName.CTNOfEquipmentMaintenance);
            }
            if (!string.IsNullOrEmpty(CommonPrintTableName.CTNOfDeckMaintenance) && !modelName.Contains(CommonPrintTableName.CTNOfDeckMaintenance))
            {
                modelName.Add(CommonPrintTableName.CTNOfDeckMaintenance);
            }
            BindData();
        }

        private WorkModelType InitModel(string modelname, int type)
        {
            Guid guid = Guid.NewGuid();
            WorkModelType unit = new WorkModelType();
            unit.ModelID = guid.ToString();
            unit.type = type;
            unit.ModelName = modelname;
            unit.ContentExp = modelname;
            unit.ModelFile = "";
            unit.SHIP_ID = shipid;
            return unit;
        }

        private void BindData()
        {
            shipid = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipid) || shipid.Trim().Length != 36)
            { 
                shipName = "";
            }
            else
            {                
                shipName = ucShipSelect1.GetText();
            }
            if (shipid != "")
            {
                CheckModelFileInfo();

                DataTable tableWMT = WorkModelTypeService.Instance.getModelInfo(shipid, "", out err);
                if (tableWMT.Rows.Count > 0)
                { 
                    this.dgv.DataSource = tableWMT;
                    ShowColT();
                }
                else
                {
                    this.dgv.DataSource = null;
                }
            }
        }

        void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {          
            BindData();
        }

        private void ShowColT()
        {
            dgv.Columns["ModelID"].Visible = false;
            dgv.Columns["ModelName"].Visible = true;
            dgv.Columns["ModelName"].HeaderText = "模板名称";
            dgv.Columns["ModelName"].ReadOnly = true;
            dgv.Columns["ModelName"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["ContentExp"].Visible = true;
            dgv.Columns["ContentExp"].HeaderText = "模板描述";
            dgv.Columns["ModelFile"].Visible = true;
            dgv.Columns["ModelFile"].HeaderText = "模板文件";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(this.dgv["ModelFile", i].Value.ToString().Trim()) || this.dgv["ModelFile", i].Value.ToString() == "ffffffff-ffff-ffff-ffff-ffffffffffff")
                {
                    dgv["ModelFile", i].Value = "不存在";
                }
                else
                {
                    dgv["ModelFile", i].Tag = dgv["ModelFile", i].Value;
                    dgv["ModelFile", i].Value = "存在";
                }
            }
            dgv.Columns["ModelFile"].ReadOnly = true;
            dgv.Columns["ModelFile"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["DateCol"].Visible = true;
            dgv.Columns["DateCol"].HeaderText = "报表值起始列";
            dgv.Columns["DateCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["DateRow"].Visible = true;
            dgv.Columns["DateRow"].HeaderText = "报表值起始行";
            dgv.Columns["DateRow"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["SHIP_ID"].Visible = false;
            dgv.Columns["type"].Visible = false;
        }

        //检查模板是否存在.
        private void CheckModelFileInfo()
        {
            for (int i = 0; i < modelName.Count; i++)
            {
                WorkModelType workModelType = new WorkModelType();

                workModelType = WorkModelTypeService.Instance.getModelObject(shipid, modelName[i], out err);
                if (workModelType != null)
                {
                    string fileid = workModelType.ModelFile; 
                    ourFile of;
                    if (!FileDbService.Instance.GetAFileById(fileid, out of))
                    {
                        workModelType.ModelFile = "";
                        WorkModelTypeService.Instance.saveUnit(workModelType, out err);
                    }
                }
                else
                {
                    WorkModelTypeService.Instance.InsertModel(InitModel(modelName[i], i), out err);
                }
            }
        }

        private void FrmModelUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err;
            WorkModelType modelType;
            if (e.RowIndex < 0)
            {
                modelType = null;
                return;
            }
            else
            {
                DataGridViewRow dr = dgv.Rows[e.RowIndex];
                string modelID = "";
                if (DBNull.Value != dr.Cells["ModelID"].Value)
                    modelID = dr.Cells["ModelID"].Value.ToString();

                modelType = WorkModelTypeService.Instance.getObject(modelID, out err);
            }
            workModelType = modelType;          

        }

        private void tsbModelIn_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogEx.ShowDialog(ofd) == DialogResult.Cancel) return;
          
            ofd.AddExtension = false;

            string path = ofd.FileName;
            if (path == null || path.Trim() == "")
            {
                return;
            }

            FileInfo finfo = new FileInfo(path);
            ourFolder folderISM = FolderDbService.Instance.getFolderByFolderType(CommonOperation.Enum.FileBoundingTypes.SHIPISMFILES, shipid);
            ourFolder folder = FolderDbService.Instance.getOrCreateSubFolderByName(folderISM, "体系文件模板", CommonOperation.Enum.FileBoundingTypes.ISMMODELS);
            if (folder == null)
            {
                MessageBoxEx.Show("请初始化文档模板类型的文件夹节点,到船舶基本信息管理页面点击初始化即可!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
           
            DialogResult result = MessageBoxEx.Show("是否导入新的模板文件以更新所选中的模板?", "导入更新模板", MessageBoxButtons.YesNo);
           
            if (result == DialogResult.Yes)
            {
                string sfileid = "";
                sfileid = workModelType.ModelFile;
                ourFile thefile;
                bool success;

                if (FileDbService.Instance.GetAFileById(sfileid, out thefile))
                {
                    thefile.FileName = finfo.Name;
                    thefile.ShipId = shipid;
                    thefile.Size = finfo.Length;
                    thefile.File_Type = "DOT";
                    thefile.CreateDate = DateTime.Today;
                    thefile.Creator = CommonOperation.ConstParameter.UserName;     
                    
                    string tempFileId;
                    if (!FolderFileDbService.Instance.IfFolderHasTheFile(folder.NodeId, thefile.FileName, out tempFileId) || tempFileId != sfileid)
                    {
                        string sourcefolder = FolderFileDbService.Instance.GetFolderIdByFileId(sfileid);
                        if (sourcefolder.Length > 0)
                        {
                            FolderFileDbService.Instance.MoveFile(sourcefolder, folder.NodeId, sfileid, out err);
                            success = FileDbService.Instance.UpdateAFile(thefile, path, out err);
                        }
                        else
                            success = FolderFileDbService.Instance.InsertAFile(folder.NodeId, thefile, path, out err);
                    }
                    else
                    {
                        success = FileDbService.Instance.UpdateAFile(thefile, path, out err);
                    }
                }
                else
                {
                    thefile = new ourFile();
                    thefile.FileName = finfo.Name;
                    thefile.ShipId = shipid;
                    thefile.Size = finfo.Length;
                    thefile.File_Type = "DOT";
                    thefile.CreateDate = DateTime.Today;
                    thefile.Creator = CommonOperation.ConstParameter.UserName;
                    success = FolderFileDbService.Instance.InsertAFile(folder.NodeId, thefile, path, out err);
                }
                if (success)
                {
                    DataTable dt = dgv.DataSource as DataTable; 
                    WorkModelType objwmt = WorkModelTypeService.Instance.getModelObject(shipid, workModelType.ModelName, out err);
                    objwmt.ModelFile = thefile.FileId;
                    WorkModelTypeService.Instance.saveUnit(objwmt, out err);
                    MessageBoxEx.Show("成功生成模板文件");
                }
                else
                {
                    MessageBoxEx.Show("模板文件生成失败");
                    return;
                }
            }
            BindData();           
        }

        private void tsbModelUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxEx.Show("是否更新模板信息?", "更新模板文件", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dgv.EndEdit();
                DataTable dt = (DataTable)(dgv.DataSource);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["ModelID"].ToString();
                    WorkModelType objwmt = WorkModelTypeService.Instance.getObject(id, out err);
                    if (dt.Rows[i]["ModelName"] == null || dt.Rows[i]["ModelName"].ToString().Trim() == "")
                    {
                        MessageBoxEx.Show("模板名称不能为空");
                        return;
                    }
                    else
                    {
                        objwmt.ModelName = dt.Rows[i]["ModelName"].ToString();
                    }

                    if (workModelType.ContentExp != null)
                    {
                        objwmt.ContentExp = dt.Rows[i]["ContentExp"].ToString();
                    }

                    if (workModelType.DateCol.ToString() != null && dt.Rows[i]["DateCol"].ToString().Trim() != "")
                    {
                        try
                        {
                            objwmt.DateCol = (decimal)dt.Rows[i]["DateCol"];
                            objwmt.DateRow = (decimal)dt.Rows[i]["DateRow"];
                        }
                        catch
                        {
                            MessageBoxEx.Show("请输入>0的整数");
                            return;
                        }
                    }
                    WorkModelTypeService.Instance.saveUnit(objwmt, out err);
                }
                BindData();
            }
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckModel_Click(object sender, EventArgs e)
        {
            if (workModelType != null)
            {   
                ourFile ofile = new ourFile();
                FileDbService.Instance.GetAFileById(workModelType.ModelFile, out ofile);
                openFile opf = new openFile();
                opf.FileOpen(ofile, right.U);
            }
            else
            {
                MessageBoxEx.Show("没有模板");
            }
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            //设置模板权限；.
            FrmModelRight frm = FrmModelRight.Instance;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = !richTextBox1.Visible;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

            if (dgv.CurrentRow != null)
            {
                if (dgv.Columns["ModelName"] != null)
                {
                    FrmModelConfig frm = new FrmModelConfig(dgv.CurrentRow.Cells["ModelName"].Value.ToString());

                    frm.ShowDialog();
                }
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        { 
            if (workModelType == null || workModelType.IsWrong) return;
            ourFile file;
            
            //当前有模板,
            if (string.IsNullOrEmpty(workModelType.ModelFile)
            || !FileDbService.Instance.GetAFileById(workModelType.ModelFile, out file))
            {
                MessageBoxEx.Show("当前模板没有导入有效的模板文件,不能克隆给其它船舶");
                return;
            }
            //询问用户是否替换所有的船,已经有了模板的也要替换.
            if (MessageBoxEx.Show("是否替换所有其他船舶的[" + workModelType.ModelName + "]模板?这将覆盖已有的模板文件", "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //处理.
            if (WorkModelTypeService.Instance.CopyConfigToAllShip(workModelType, out err))
            {
                MessageBoxEx.Show("操作成功");
            }
            else
            {
                MessageBoxEx.Show("操作失败,错误原因请参考:\r" + err);
            }
        }
    }
}