using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using System.IO;
using System.Runtime.InteropServices;
using CommonOperation.Functions;
using ItemsManage.Services;
using OfficeOperation;
using CommonViewer.BaseControl;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseForm;
using CommonOperation.Enum;
using BaseInfo.DataObject;
using FileOperationBase.Services;
using FileOperationBase.FileServices;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonOperation;

namespace Maintenance.Viewer
{
    public partial class FrmQuicklyInsertEquipmentNew : CommonViewer.BaseForm.FormBase
    {
        #region 内部变量
        private ComponentUnit shipUnit = null;
        private ComponentUnit parentComponentUnit = null;//所有导入的根，原则上初始构造了就不能再维护
        private ComponentType thisComponentType = null;
        private EquipmentClass thisEquipmentClass = null;
        private bool onlySpare = false;
        private bool hasErr = false;
        private string filePath;
        private ModelHelper modelHelper = new ModelHelper();
        #endregion

        #region 窗体功能

        #region 构造

        /// <summary>
        /// 构造函数1,传入上级id,完全初始化时调用的构造.
        /// </summary>
        /// <param name="parentId">上级设备id</param>
        public FrmQuicklyInsertEquipmentNew(string parentId)
        {
            InitializeComponent();
            string err;
            parentComponentUnit = ComponentUnitService.Instance.getObject(parentId, out err);
        }

        /// <summary>
        /// 构造函数2,传入设备型号对象,为其添加备件,属于仅初始化备件的构造函数.
        /// </summary>
        /// <param name="theComponentType"></param>
        public FrmQuicklyInsertEquipmentNew(ComponentType theComponentType)
        {
            InitializeComponent();
            if (theComponentType != null && !theComponentType.IsWrong)
            {
                thisComponentType = theComponentType;
                onlySpare = true;
            }
            else
            {
                this.Text += ":注意,所选设备有误,请关闭此界面,从新操作!";
                hasErr = true;
            }
        }

        /// <summary>
        /// 构造函数3,传入设备所在的分类对象,和船舶id,在船舶id下添加设备,同时绑定到指定分类上去.
        /// </summary>
        /// <param name="belongEquipment"></param>
        /// <param name="shipId"></param>
        public FrmQuicklyInsertEquipmentNew(EquipmentClass belongEquipment, string shipId)
        {
            InitializeComponent();
            //由于shipid未必是ship这条船的设备的id,必须先获取到.
            string err;
            parentComponentUnit = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipId, out err);
            //要有个克隆对象
            shipUnit = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipId, out err);
            if (parentComponentUnit == null || parentComponentUnit.IsWrong)
            {
                this.Text += ":注意,所选设备有误,请关闭此界面,从新操作!";
                hasErr = true;
            }
            thisEquipmentClass = belongEquipment;
        }
        #endregion

        private void FrmQuicklyInsertComp_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            if (onlySpare) this.Text += "为 [ " + thisComponentType.COMPTYPE_CHINESE_NAME + " ] 快速添加备件";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region  模板下载代码 2013-4-11 徐正本

        enum FileType
        {
            OneEquipModel = 1,
            AllFleetEquipmentsModel = 2,
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            DownLoadFiles(FileType.OneEquipModel);
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            DownLoadFiles(FileType.AllFleetEquipmentsModel);
        }
        private void DownLoadFiles(FileType fielType)
        {
            string fileName = (fielType == FileType.OneEquipModel ? "设备备件快速初始化模板" : "船舶设备列表模板");
            if (SaveFileDialogEx.ShowDialog(saveFileDialog1) == DialogResult.OK)
            {
                byte[] fileBytes = (byte[])Maintenance.Properties.Resources.ResourceManager.GetObject(fileName);
                string sTempName = Guid.NewGuid().ToString();
                FileStream fs = File.Create(saveFileDialog1.FileName + sTempName, fileBytes.Length, FileOptions.SequentialScan);
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Flush();
                fs.Close();
                FileInfo fi = new FileInfo(saveFileDialog1.FileName + sTempName);
                fi.CopyTo(saveFileDialog1.FileName, true);
                fi.Delete();
                if (File.Exists(saveFileDialog1.FileName))
                {
                    if (MessageBoxEx.Show("写入成功,是否打开文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        Tools.FileOpen(saveFileDialog1.FileName);
                    }
                }
                else
                {
                    MessageBoxEx.Show("写入失败,可能当前使用者没有本机相应目录的操作权限来完成文件的创建!");
                }
            }
        }

        #endregion

        #region 单设备导入
        /// <summary>
        /// 单个设备导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (hasErr)
            {
                MessageBoxEx.Show("所选的设备型号有误,无法继续完成操作");
                return;
            }
            PrepareToImportSingleComponent();
        }

        private void PrepareToImportSingleComponent()
        {
            openFileDialog1.Multiselect = true;
            //打开对话框选择excel文件.
            DialogResult theResult = OpenFileDialogEx.ShowDialog(openFileDialog1);
            if (theResult != DialogResult.OK)
            {
                MessageBoxEx.Show("用户取消了选择");
                return;
            }
            string[] fileNames = openFileDialog1.FileNames;
            int allCount = fileNames.Length;
            for (int i = 0; i < allCount; i++)
            {
                string fileName = fileNames[i];
                if (File.Exists(fileName))
                {
                    reallyImportOneFile(new FileInfo(fileName), false);
                }
            }
        }

        #endregion

        #region 导入单个设备对应Excel时的部分，此部分会被所有三个按钮调用
        /// <summary>
        /// filename,fileid
        /// </summary>
        Dictionary<string, string> allFiles = new Dictionary<string, string>();

        /// <summary>
        /// 导入excel单个标签页.
        /// </summary>
        /// <param name="toOperExcel">要打开的excel对象</param>
        /// <param name="sheet">页码,从1开始</param>
        /// <returns></returns>
        private void ImportExcelOneSheet()
        {
            if (currentModelType == ModelType.Err) returnErr = true;
            returnErr = !ImportExcelOneSheet(filePath, importAllfiles);
        }

        /// <summary>
        /// 根据一个位置坐标得到一个信息
        /// </summary>
        /// <param name="position">（如：Cell（A2)则传入“A2”）</param>
        /// <returns>传入位置的信息值</returns>
        private string GetAValueFromPosition(string position)
        {
            return toOperExcel.GetRangeValue(nowImportSheet, position).Replace("\n", "\r\n").Trim();
        }

        /// <summary>
        /// 直接得到某配置项的信息
        /// </summary>
        /// <param name="parameterType">配置信息项</param>
        private string GetAValueFromModel(ParameterType parameterType)
        {
            return GetAValueFromPosition(modelHelper.GetAPosition(currentModelType, parameterType));
        }

        /// <summary>
        /// 根据配置项的列和当前行得到信息
        /// </summary>
        /// <param name="parameterType">配置信息项</param>
        /// <param name="row">所在行</param>
        private string GetAValueFromParameterTypeAndRow(ParameterType parameterType, int row)
        {
            int iColumn = modelHelper.GetAColumnPostion(currentModelType, parameterType);
            if (iColumn <= 0) return "";
            return GetAValueFromPositionColumnAndRow(iColumn, row);
        }

        /// <summary>
        /// 根据具体的行列得到信息，与配置项无关
        /// </summary>
        /// <param name="column">信息所在列</param>
        /// <param name="row">信息所在行</param>
        private string GetAValueFromPositionColumnAndRow(int column, int row)
        {
            return GetAValueFromPosition(toOperExcel.GetSingleCellRange(column, row));
        }

        private bool ImportExcelOneSheet(string filePath, bool importAllfiles)
        {
            string type = GetAValueFromModel(ParameterType.分类);
            string sysCode = GetAValueFromModel(ParameterType.设备编号);
            string Name = GetAValueFromModel(ParameterType.设备or系统名称);
            #region 导入系统
            if (type == "系统")
            {
                return ImportASystem(sysCode, Name);
            }
            else if (type != "设备" && type != "部件")
            {
                return false;
            }
            #endregion
            #region 导入设备

            return ImportAEquipmentOrAssemblyUnit(type, sysCode, Name);
            #endregion
        }

        private bool ImportASystem(string sysCode, string sysName)
        {
            string err;
            //是系统,导入是上级必须是系统
            if (thisEquipmentClass == null)
            {
                MessageBoxEx.Show("系统分类必须导入到其他分类下,不能导入设备下!");
                return false;
            }
            if (string.IsNullOrEmpty(sysName))
            {
                MessageBoxEx.Show("作为设备分类系统,模板中的C4列为必填字段!");
                return false;
            }
            //查看系统中是否存在上级为thisEquipmentClass,名称为sysName的设备分类 
            if (EquipmentClassService.Instance.GetEquipmentClassByNameAndParentId(sysName, thisEquipmentClass.GetId(), out  nowImportingClass) && nowImportingClass != null)
            {
                if (string.IsNullOrEmpty(sysCode)) nowImportingClass.CLASSCODE = sysCode;
            }
            else
            {
                nowImportingClass = new EquipmentClass("", sysCode, sysName, 1, sysName, thisEquipmentClass.GetId());
            }

            return nowImportingClass.Update(out err);
        }

        private bool ImportAEquipmentOrAssemblyUnit(string type, string sysCode, string name)
        {
            string err;
            int nowRow = 20;
            nowImportingEquipt = new ComponentUnit();
            ComponentType tempType = new ComponentType();
            //不是仅导入备件时,需要对设备表进行处理.
            List<int> workinfoRowNumber = new List<int>();
            List<WorkInfo> lstTempWorkInfo = new List<WorkInfo>();
            if (!onlySpare)
            {
                nowImportingEquipt.SHIP_ID = parentComponentUnit.SHIP_ID;

                #region 设备头必填字段没有填写的情况
                if (string.IsNullOrEmpty(GetAValueFromModel(ParameterType.设备or系统名称)) || string.IsNullOrEmpty(GetAValueFromModel(ParameterType.产品名称))
                    || (type == "设备" && (string.IsNullOrEmpty(GetAValueFromModel(ParameterType.型号)) || string.IsNullOrEmpty(GetAValueFromModel(ParameterType.生产厂家)))))
                {
                    MessageBoxEx.Show("第" + nowImportSheet.ToString() + "页,设备基本信息位置存在必填字段没有填写的情况,请填写后再进行导入!");
                    return false;
                }
                #endregion


                parentComponentUnit.FillThisObject();
                parentComponentUnit.TheComponentType.FillThisObject();

                #region 设备和设备型号的导入
                nowImportingEquipt.COMP_NUMBER = sysCode;
                //设备名称*
                nowImportingEquipt.COMP_CHINESE_NAME = GetAValueFromModel(ParameterType.设备or系统名称);
                //英文名称.
                nowImportingEquipt.COMP_ENGLISH_NAME = GetAValueFromModel(ParameterType.英文名称);
                //产品名称* 
                tempType.COMPTYPE_CHINESE_NAME = GetAValueFromModel(ParameterType.产品名称);
                //型号*
                tempType.COMPONENT_STYLE = GetAValueFromModel(ParameterType.型号);
                if (string.IsNullOrEmpty(tempType.COMPONENT_STYLE))
                    tempType.COMPONENT_STYLE = parentComponentUnit.TheComponentType.COMPONENT_STYLE;

                //生产厂家*
                tempType.MANUFACTURER = GetAValueFromModel(ParameterType.生产厂家);
                if (string.IsNullOrEmpty(tempType.MANUFACTURER))
                    tempType.MANUFACTURER = parentComponentUnit.TheComponentType.MANUFACTURER;
                //修理厂家.
                tempType.SERVICE_PROVIDER = GetAValueFromModel(ParameterType.修理厂家);
                //主要参数.
                tempType.DETAIL = GetAValueFromModel(ParameterType.主要参数);
                //负责人岗位* //如果为空,从parentComponentUnit中获取负责人岗位,如果依然不能获取则报错.
                string gw = GetAValueFromModel(ParameterType.设备负责人岗位);
                try
                {
                    if (string.IsNullOrEmpty(gw))
                    {
                        tempType.ThePrincipalPost = parentComponentUnit.TheComponentType.ThePrincipalPost;
                    }
                    else tempType.ThePrincipalPost = (Post)PostService.Instance.GetOneObjectByName(gw);
                    tempType.HEADSHIP = tempType.ThePrincipalPost.GetId();
                }
                catch
                {
                    MessageBoxEx.Show("无法进行导入,导入的负责人岗位为空,也可能存在无效的Excel导入页");
                    return false;
                }
                //序列号.

                nowImportingEquipt.comp_serial_no = GetAValueFromModel(ParameterType.序列号);
                //设备证书号码.
                nowImportingEquipt.certification = GetAValueFromModel(ParameterType.设备证书号码);
                //生产日期,填写了就赋值,否则不赋值.

                DateTime dt;
                if (DateTime.TryParse(GetAValueFromModel(ParameterType.生产日期), out dt))
                    nowImportingEquipt.PRODUCE_TIME = dt;
                //安装日期,填写了就赋值,否则不赋值.

                if (DateTime.TryParse(GetAValueFromModel(ParameterType.安装日期), out dt))
                    nowImportingEquipt.USE_TIME = dt;
                //大修时间.
                if (DateTime.TryParse(GetAValueFromModel(ParameterType.大修时间), out dt))
                    nowImportingEquipt.repair_date = dt;
                //船检编码.
                nowImportingEquipt.EXAMINATION_CODE = GetAValueFromModel(ParameterType.船检编码);
                //运转率.

                decimal dTemp;
                string sTemp = GetAValueFromModel(ParameterType.运转率);
                if (!string.IsNullOrEmpty(sTemp) && decimal.TryParse(sTemp, out dTemp))
                    nowImportingEquipt.USE_RATE = dTemp / 100;
                //本设备特殊说明.

                nowImportingEquipt.Detail = GetAValueFromModel(ParameterType.本设备特殊说明).Replace("\n", "\r\n");
                if (string.IsNullOrEmpty(tempType.MANUFACTURER))
                {
                    thisComponentType = ComponentTypeService.Instance.GetComponentTypeByNameAndStyleNumber
                        (tempType.COMPTYPE_CHINESE_NAME, tempType.COMPONENT_STYLE);
                }
                else
                {
                    thisComponentType = ComponentTypeService.Instance.GetComponentTypeByNameAndStyleNumber
                        (tempType.COMPTYPE_CHINESE_NAME, tempType.COMPONENT_STYLE, tempType.MANUFACTURER);
                }
                if (thisComponentType == null || thisComponentType.IsWrong)
                {
                    thisComponentType = tempType;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tempType.MANUFACTURER)) thisComponentType.MANUFACTURER = tempType.MANUFACTURER;
                    if (!string.IsNullOrEmpty(tempType.SERVICE_PROVIDER)) thisComponentType.SERVICE_PROVIDER = tempType.SERVICE_PROVIDER;
                    if (!string.IsNullOrEmpty(tempType.DETAIL)) thisComponentType.DETAIL = tempType.DETAIL;
                }
                if (!thisComponentType.Update(out err))
                {
                    MessageBoxEx.Show("添加新的设备型号时出错,错误信息为:" + err);
                    return false;
                }
                nowImportingEquipt.TheComponentType = thisComponentType;
                nowImportingEquipt.COMPONENT_TYPE_ID = thisComponentType.GetId();
                nowImportingEquipt.PARENT_UNIT_ID = parentComponentUnit.GetId();
                //最新代码把导入重复设备的条件放大,认为,同一个型号,同一个上级同一个分类且同名的才是一个设备,否则均不是一个设备.
                //ComponentUnit tempUnitFind = ComponentUnitService.Instance.getObjectByNameAndParentId
                //    (tempUnit.PARENT_UNIT_ID, tempUnit.COMP_CHINESE_NAME, out err);

                ComponentUnit tempUnitFind = ComponentUnitService.Instance.GetObjectByNameAndParentIdAndTypeAndClass
                    (nowImportingEquipt.PARENT_UNIT_ID, nowImportingEquipt.COMP_CHINESE_NAME, thisComponentType.GetId(), thisEquipmentClass == null ? "" : thisEquipmentClass.GetId(), out err);
                bool useLast = false;
                if (tempUnitFind != null && !tempUnitFind.IsWrong)
                {
                    if (tempUnitFind.COMPONENT_TYPE_ID != nowImportingEquipt.COMPONENT_TYPE_ID)
                    {
                        DialogResult ds = MessageBoxEx.Show("是否替换同层次下的同名设备." +
                            "\r[是],设备的保养内容以及修理历史等均不受影响," +
                            "\r[否]建立一个新的同名设备,不利于以后区分" +
                            "\r[取消]退出,可重新改名再重新导入!", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (ds == DialogResult.Yes)
                        {
                            useLast = true;
                        }
                        else if (ds == DialogResult.Cancel)
                        {
                            return false;
                        }
                        else
                        {
                            //不做任何处理,实际就是继续按照新设备继续导入.
                        }
                    }
                    else
                    {
                        useLast = true;
                    }
                }
                if (useLast)
                {
                    tempUnitFind.COMPONENT_TYPE_ID = nowImportingEquipt.COMPONENT_TYPE_ID;
                    if (!string.IsNullOrEmpty(nowImportingEquipt.COMP_ENGLISH_NAME)) tempUnitFind.COMP_ENGLISH_NAME = nowImportingEquipt.COMP_ENGLISH_NAME;
                    if (!string.IsNullOrEmpty(nowImportingEquipt.comp_serial_no)) tempUnitFind.comp_serial_no = nowImportingEquipt.comp_serial_no;
                    if (!string.IsNullOrEmpty(nowImportingEquipt.certification)) tempUnitFind.certification = nowImportingEquipt.certification;
                    if (!string.IsNullOrEmpty(nowImportingEquipt.EXAMINATION_CODE)) tempUnitFind.EXAMINATION_CODE = nowImportingEquipt.EXAMINATION_CODE;
                    nowImportingEquipt = tempUnitFind;
                }
                if (!nowImportingEquipt.Update(out err))
                {
                    MessageBoxEx.Show("添加新的设备时出错,错误信息为:" + err);
                    return false;
                }
                #endregion

                #region 设备的操作说明部分 注意包含文件和filePath目录下查找到的文件,如果文件没有查找到,同样不能进行操作

                while (!GetAValueFromParameterTypeAndRow(ParameterType.判断分割标志所在列, nowRow).Equals(ModelHelper.CutOffLineString))
                {
                    Application.DoEvents();
                    if (nowRow > 100)
                    {
                        MessageBoxEx.Show("模板格式有问题,无法完成导入!");
                        return false;
                    }
                    nowRow++;
                    //当不为空行时操作,操作说明部分即时有空行也可以继续操作.
                    sTemp = GetAValueFromParameterTypeAndRow(ParameterType.序号列, nowRow);
                    if (!string.IsNullOrEmpty(sTemp))
                    {
                        #region 导入单行操作说明及其相关文件部分
                        //先识别操作对象.

                        EquipmentOperation tempEquipOper = new EquipmentOperation();
                        if (!string.IsNullOrEmpty(sTemp) && decimal.TryParse(sTemp, out dTemp))
                            tempEquipOper.SORTNO = (int)dTemp;
                        else
                            tempEquipOper.SORTNO = nowRow - 20;
                        tempEquipOper.OPERATIONNAME = GetAValueFromParameterTypeAndRow(ParameterType.序号列, nowRow);
                        tempEquipOper.OPERATIONDETAIL = GetAValueFromParameterTypeAndRow(ParameterType.序号列, nowRow);
                        tempEquipOper.EQUIPMENTID = thisComponentType.GetId();
                        if (!string.IsNullOrEmpty(tempEquipOper.OPERATIONNAME) && !string.IsNullOrEmpty(tempEquipOper.OPERATIONDETAIL))
                        {
                            EquipmentOperation tempEquipOperToFind = EquipmentOperationService.Instance.GetObjectByEquipmentIdAndName(tempEquipOper.EQUIPMENTID, tempEquipOper.OPERATIONNAME);
                            if (tempEquipOperToFind != null && !tempEquipOperToFind.IsWrong) tempEquipOper.EQUOPERATIONID = tempEquipOperToFind.GetId();
                            tempEquipOper.Update(out err);
                        }
                        int ckwjColumn = modelHelper.GetAColumnPostion(currentModelType, ParameterType.参考文件开始列);
                        ourFolder tempFolder = FolderDbService.Instance.getFolderByFolderID(tempEquipOper.GetId());
                        #region 循环文件处理，可以提炼
                        while (!string.IsNullOrEmpty(GetAValueFromPositionColumnAndRow(ckwjColumn, nowRow)))
                        {
                            if (tempFolder == null)
                            {
                                ourFolder companyFolder = FolderDbService.Instance.getFolderByFolderType(CommonOperation.Enum.FileBoundingTypes.COMPONYFILES);
                                // ourFolder companyFolder
                                ourFolder operationFolder = FolderDbService.Instance.getOrCreateSubFolderByName(companyFolder, "操作说明(Operation)", FileBoundingTypes.COMPONENTOPERATION);
                                operationFolder.Node_Type = (int)CommonOperation.Enum.FileBoundingTypes.COMPONENTOPERATION;
                                tempFolder = FolderDbService.Instance.getOrCreateSubFolderByNameAndId(operationFolder, thisComponentType.ToString(), tempEquipOper.GetId());
                            }
                            FileInfo tempFile = new FileInfo(filePath + "\\" + GetAValueFromPositionColumnAndRow(ckwjColumn, nowRow));
                            ckwjColumn++;//必须有这句,让列后移一位.

                            if (!tempFile.Exists) continue;
                            ourFile theFile = new ourFile();
                            theFile.CreateDate = tempFile.CreationTime;
                            theFile.Creator = CommonOperation.ConstParameter.UserName;
                            theFile.File_Type = "DOC";
                            theFile.FileName = tempFile.Name;
                            theFile.Size = tempFile.Length;
                            string tempFileId;
                            if (!FolderFileDbService.Instance.IfFolderHasTheFile(tempEquipOper.GetId(), theFile.FileName, out tempFileId))
                            {
                                FolderFileDbService.Instance.InsertAFile(tempEquipOper.GetId(), theFile, tempFile.FullName, out err);
                            }
                            else
                            {
                                theFile.FileId = tempFileId;
                                if (!allFiles.ContainsKey(tempFile.FullName.ToLower()))
                                {
                                    FileDbService.Instance.UpdateAFile(theFile, tempFile.FullName, out err);
                                }
                            }
                            allFiles.Add(tempFile.FullName.ToLower(), theFile.FileId);

                            if (string.IsNullOrEmpty(theFile.FileId))
                                throw new Exception("");
                        }
                        #endregion
                        #endregion
                    }
                }

                #endregion

                #region 设备的维护保养内容部分

                //先找到开始第一行.

                //当前的nowRow应该恰好是标题前一行,而标题头加说明共两行,先判断一下标题头是否有问题.
                nowRow += 2;
                if (!GetAValueFromPositionColumnAndRow(1, nowRow).Equals(GetAValueFromModel(ParameterType.PMS项目开始行首列列名)))
                {
                    MessageBoxEx.Show("模板格式有问题,无法完成导入!");
                    return false;
                }
                nowRow++;

                while (!GetAValueFromParameterTypeAndRow(ParameterType.判断分割标志所在列, nowRow).Equals(ModelHelper.CutOffLineString))
                {
                    Application.DoEvents();
                    if (nowRow > 200)
                    {
                        MessageBoxEx.Show("模板格式有问题,无法完成导入!");
                        return false;
                    }
                    //当不为空行时操作,操作说明部分即时有空行也可以继续操作.
                    sTemp = GetAValueFromParameterTypeAndRow(ParameterType.序号列, nowRow);
                    if (!string.IsNullOrEmpty(sTemp))
                    {
                        #region 导入单行操作说明及其相关文件部分
                        WorkInfo tempWorkInfo = new WorkInfo();
                        tempWorkInfo.WORKINFOSTATE = 0;
                        tempWorkInfo.WORKINFOTYPE = 1;
                        tempWorkInfo.REFOBJID = nowImportingEquipt.GetId();
                        tempWorkInfo.SHIP_ID = nowImportingEquipt.SHIP_ID;
                        //A 项目代码或序号.
                        tempWorkInfo.WORKINFOCODE = sTemp;
                        //B 项目名称*
                        tempWorkInfo.WORKINFONAME = GetAValueFromParameterTypeAndRow(ParameterType.PMS项目名称, nowRow);
                        //C "负责人岗位不填按设备的算"

                        Post tempPost = (Post)PostService.Instance.GetOneObjectByName(GetAValueFromParameterTypeAndRow(ParameterType.PMS负责人岗位, nowRow));
                        if (tempPost == null || tempPost.IsWrong)
                        {
                            tempWorkInfo.PRINCIPALPOST = thisComponentType.HEADSHIP;
                        }
                        else
                        {
                            tempWorkInfo.PRINCIPALPOST = tempPost.GetId();
                        }
                        Post tempHeaderPost;
                        if (tempPost != null && PostService.Instance.GetDepartLeaderPost(tempPost.DEPARTMENTID, out tempHeaderPost, out err))
                            tempWorkInfo.CONFIRMPOST = tempHeaderPost.GetId();
                        else
                            tempWorkInfo.CONFIRMPOST = tempWorkInfo.PRINCIPALPOST;
                        bool isTiming = false;
                        #region 定时周期(hour)
                        if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定时周期, nowRow), out dTemp))
                        {
                            isTiming = true;
                            tempWorkInfo.TIMINGPERIOD = (int)dTemp;
                            //E 定期前允差.
                            if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定时前允差, nowRow), out dTemp))
                            {
                                tempWorkInfo.TIMINGFRONTLIMIT = (int)dTemp;

                            }
                            if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定时后允差, nowRow), out dTemp))
                            {
                                tempWorkInfo.TIMINGBACKLIMIT = (int)dTemp;
                            }
                        }
                        #endregion
                        bool isCircle = false;
                        #region F 定期周期
                        if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定期周期, nowRow), out dTemp))
                        {
                            isCircle = true;
                            tempWorkInfo.CIRCLEPERIOD = (int)dTemp;
                            //G 周期单位(年月日)
                            tempWorkInfo.CIRCLEUNIT = GetAValueFromParameterTypeAndRow(ParameterType.周期单位, nowRow);
                            tempWorkInfo.CIRCLELIMITUNIT = tempWorkInfo.CIRCLEUNIT;
                            //H 定期前允差.
                            if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定期前允差, nowRow), out dTemp))
                            {
                                tempWorkInfo.CIRCLEFRONTLIMIT = (int)dTemp;
                            }
                            else
                            {
                                tempWorkInfo.CIRCLEFRONTLIMIT = 0;
                            }
                            //I 定期后允差.
                            if (decimal.TryParse(GetAValueFromParameterTypeAndRow(ParameterType.定期后允差, nowRow), out dTemp))
                            {
                                tempWorkInfo.CIRCLEBACKLIMIT = (int)dTemp;
                            }
                            else
                            {
                                tempWorkInfo.CIRCLEBACKLIMIT = 0;
                            }
                        }
                        #endregion

                        if (isTiming && isCircle)
                        {
                            tempWorkInfo.CIRCLEORTIMING = 3;
                        }
                        else if (isTiming)
                        {
                            tempWorkInfo.CIRCLEORTIMING = 2;
                        }
                        else if (isCircle)
                        {
                            tempWorkInfo.CIRCLEORTIMING = 1;
                        }
                        else
                        {
                            tempWorkInfo.CIRCLEORTIMING = 4;
                        }
                        //J 项目内容*
                        tempWorkInfo.WORKINFODETAIL = GetAValueFromParameterTypeAndRow(ParameterType.项目内容, nowRow);
                        //K 是否船检项目.
                        tempWorkInfo.ISCHECKPROJECT = (GetAValueFromParameterTypeAndRow(ParameterType.是否船检项目, nowRow) == "是" ? 1 : 0);
                        //L 是否修理项目.
                        tempWorkInfo.ISREPAIRPROJECT = (GetAValueFromParameterTypeAndRow(ParameterType.是否修理项目, nowRow) == "是" ? 1 : 0);
                        //M CMS编号.                       
                        tempWorkInfo.WORKINFOID = WorkInfoService.Instance.GetWorkinfoByEquipmentIdAndWorkinfoName(tempWorkInfo.REFOBJID, tempWorkInfo.WORKINFONAME);
                        if (!tempWorkInfo.Update(out err))
                        {
                            MessageBoxEx.Show("第" + nowImportSheet + "页,第" + nowRow + "行的工作信息导入不成功"
                                + "\r错误信息为" + err);
                            return false;
                        }
                        lstTempWorkInfo.Add(tempWorkInfo);
                        workinfoRowNumber.Add(nowRow);
                        #endregion
                    }
                    nowRow++;
                }

                #endregion

                #region 如果存在分类代码,则把设备安排到分类下
                if (thisEquipmentClass != null)
                    ItemsManage.Services.EquipmentClassService.Instance.ClassifyEquipmentToClass(thisEquipmentClass.GetId(), nowImportingEquipt.GetId(), nowImportingEquipt.SHIP_ID, out err);
                #endregion
            }
            //查找并获取备件的首行.
            while (!GetAValueFromParameterTypeAndRow(ParameterType.备件显示名, nowRow).Equals(GetAValueFromModel(ParameterType.备件开始行首列列名)))
            {
                nowRow++;
            }

            #region 备件插入临时结构 及 备件图信息

            List<string> sparePics = new List<string>();
            Dictionary<string, SpareInfo> dicSpareInfos = new Dictionary<string, SpareInfo>();
            Dictionary<string, int> dicSpareMakeNumber = new Dictionary<string, int>();
            Dictionary<SpareInfo, Dictionary<string, decimal>> dicAllSpareStorageInfo = new Dictionary<SpareInfo, Dictionary<string, decimal>>();
            bool decimalAsZero = false;
            nowRow++;
            while (!string.IsNullOrEmpty(GetAValueFromParameterTypeAndRow(ParameterType.备件显示名, nowRow)))
            {
                Application.DoEvents();
                SpareInfo spareInfoTemp = new SpareInfo();
                int makingNumber = 0;
                spareInfoTemp.SPARE_NAME = GetAValueFromParameterTypeAndRow(ParameterType.备件显示名, nowRow);
                spareInfoTemp.SPARE_ENAME = GetAValueFromParameterTypeAndRow(ParameterType.备件别名, nowRow);
                //
                spareInfoTemp.PARTNUMBER = GetAValueFromParameterTypeAndRow(ParameterType.备件号, nowRow);
                spareInfoTemp.PARTNUMBER_HIS1 = GetAValueFromParameterTypeAndRow(ParameterType.历史备件号1, nowRow);
                spareInfoTemp.PARTNUMBER_HIS2 = GetAValueFromParameterTypeAndRow(ParameterType.历史备件号2, nowRow);
                spareInfoTemp.PICNUMBER = GetAValueFromParameterTypeAndRow(ParameterType.图号, nowRow);
                if (!sparePics.Contains(spareInfoTemp.PICNUMBER.ToLower()) && !string.IsNullOrEmpty(spareInfoTemp.PICNUMBER))
                    sparePics.Add(spareInfoTemp.PICNUMBER.ToLower());
                spareInfoTemp.PICCODE = GetAValueFromParameterTypeAndRow(ParameterType.在图编号, nowRow);

                decimal dTemp = 0;
                string sTemp = GetAValueFromParameterTypeAndRow(ParameterType.警戒库存, nowRow);
                if (string.IsNullOrEmpty(sTemp)) spareInfoTemp.ALERTSTOCK = 0;
                else if (!decimal.TryParse(sTemp, out dTemp))
                {
                    if (!decimalAsZero && MessageBoxEx.Show("存在警戒库存不是数字的项,是否继续导入,继续导入将此类问题自动设置为0!", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return false;
                    }
                    decimalAsZero = true;
                    dTemp = 0;
                }
                spareInfoTemp.ALERTSTOCK = dTemp;

                //构成数量.
                dTemp = 0;
                sTemp = GetAValueFromParameterTypeAndRow(ParameterType.构成数量, nowRow);
                if (!string.IsNullOrEmpty(sTemp))
                {
                    if (!decimal.TryParse(sTemp, out dTemp))
                    {
                        if (!decimalAsZero && MessageBoxEx.Show("存在构成数量不是数字的项,是否继续导入,继续导入将此类问题自动设置为0!", "提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return false;
                        }
                        decimalAsZero = true;
                    }
                    else
                    {
                        makingNumber = (int)dTemp;
                    }
                }
                //计量单位
                sTemp = GetAValueFromParameterTypeAndRow(ParameterType.计量单位, nowRow);
                if (!string.IsNullOrEmpty(sTemp)) spareInfoTemp.UNIT_NAME = sTemp;
                else spareInfoTemp.UNIT_NAME = "EA";

                spareInfoTemp.REMARK = GetAValueFromParameterTypeAndRow(ParameterType.备注, nowRow);
                spareInfoTemp.ISSPECIALSP = 0;
                if (!dicSpareInfos.ContainsKey(spareInfoTemp.PARTNUMBER))
                {
                    dicSpareInfos.Add(spareInfoTemp.PARTNUMBER, spareInfoTemp);
                    dicSpareMakeNumber.Add(spareInfoTemp.PARTNUMBER, makingNumber);
                }
                else
                {
                    dicSpareMakeNumber[spareInfoTemp.PARTNUMBER] += makingNumber;
                }
                #region 增加库存部分
                Dictionary<string, decimal> tempStorage = new Dictionary<string, decimal>();
                int column = modelHelper.GetAColumnPostion(currentModelType, ParameterType.所在仓库起始列); ;
                while (!string.IsNullOrEmpty(GetAValueFromPositionColumnAndRow(column, nowRow)))
                {
                    string s1;
                    decimal d1 = 0;
                    s1 = GetAValueFromPositionColumnAndRow(column, nowRow);

                    if (!decimal.TryParse(GetAValueFromPositionColumnAndRow(column + 1, nowRow), out  d1))
                    {
                        d1 = 0;
                    }

                    if (s1.Length == 0 || d1 == 0) break;
                    if (tempStorage.ContainsKey(s1))
                        tempStorage[s1] += d1;
                    else
                        tempStorage.Add(s1, d1);
                    column += 2;
                }
                if (tempStorage.Count > 0)
                    dicAllSpareStorageInfo.Add(spareInfoTemp, tempStorage);
                #endregion
                nowRow++;
            }
            #endregion

            #region 插入备件 及 备件图

            foreach (string sparePartNumber in dicSpareInfos.Keys)
            {
                Application.DoEvents();
                SpareInfo siTemp = dicSpareInfos[sparePartNumber];
                string sTempId;
                //插入siTemp,判断是更新还是新增.

                SpareInfo spinfo = SpareInfoService.Instance.GetOneObjectByNameAndPartno(siTemp.SPARE_NAME, siTemp.PARTNUMBER, out err);
                //更新其与设备品型的关系.

                if (spinfo == null || spinfo.IsWrong)
                {
                    if (!siTemp.Update(out err))
                    {
                        MessageBoxEx.Show("插入备件时出错,错误信息为 :" + err);
                        return false;
                    }
                    sTempId = siTemp.GetId();
                }
                else
                {
                    sTempId = spinfo.GetId();
                    siTemp.SPARE_ID = sTempId;
                    if (!siTemp.Update(out err))
                    {
                        MessageBoxEx.Show("插入备件时出错,错误信息为 :" + err);
                        return false;
                    }
                }

                if (!ComponentTypeService.Instance.BandingToSpare(thisComponentType.GetId(), sTempId, dicSpareMakeNumber[sparePartNumber], out err))
                {
                    MessageBoxEx.Show("绑定备件到设备品型时出错,错误信息为 :" + err);
                    return false;
                }
                if (dicAllSpareStorageInfo.ContainsKey(siTemp))
                {
                    if (!StorageManage.Services.SpareStockService.Instance.UpdateSpareStorage(sTempId, nowImportingEquipt.SHIP_ID, dicAllSpareStorageInfo[siTemp], out err))
                    {
                        MessageBoxEx.Show("更新备件库存的情况下出错,出错信息为:" + err);
                        return false;
                    }
                }
            }

            Dictionary<string, FileInfo> allPictureFiles = new Dictionary<string, FileInfo>();
            DirectoryInfo d = new DirectoryInfo(filePath);
            if (importAllfiles)
            {
                FileInfo[] files = d.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.FullName.ToLower() != fileFullName.ToLower())
                    {
                        allFiles.Add(file.FullName.ToLower(), "");
                        allPictureFiles.Add(file.FullName.ToLower(), file);
                    }
                }
            }
            else
            {
                //先找到所有文件.
                foreach (string picCode in sparePics)
                {
                    Application.DoEvents();
                    try
                    {
                        FileInfo[] files = d.GetFiles("*" + picCode + "*");
                        foreach (FileInfo file in files)
                        {
                            if (!allPictureFiles.ContainsKey(file.FullName.ToLower()))
                            {
                                if (allFiles.ContainsKey(file.FullName.ToLower())) allPictureFiles.Add(file.FullName.ToLower(), file);
                                else
                                {
                                    allFiles.Add(file.FullName.ToLower(), "");
                                    allPictureFiles.Add(file.FullName.ToLower(), file);
                                }
                            }
                        }
                    }
                    catch { continue; }
                }
            }


            //得到设备类型对应的folder
            ourFolder equipmentTypeFolder;

            if (allPictureFiles.Count > 0)
            {
                equipmentTypeFolder = FolderDbService.Instance.getFolderByFolderID(thisComponentType.GetId());
                if (equipmentTypeFolder == null)
                {
                    ourFolder companyFolder = FolderDbService.Instance.getFolderByFolderType(CommonOperation.Enum.FileBoundingTypes.COMPONYFILES);
                    // ourFolder companyFolder
                    ourFolder operationFolder = FolderDbService.Instance.getOrCreateSubFolderByName(companyFolder, "设备资料");
                    operationFolder.Node_Type = (int)CommonOperation.Enum.FileBoundingTypes.COMPONENTFILES;
                    equipmentTypeFolder = FolderDbService.Instance.getOrCreateSubFolderByNameAndId(operationFolder, thisComponentType.ToString(), thisComponentType.GetId());
                }
                foreach (string fileName in allPictureFiles.Keys)
                {
                    FileInfo file = allPictureFiles[fileName];
                    //如果有id 则直接关联id,如果没有则需要插入文件.

                    if (!file.Exists) continue;
                    ourFile theFile = new ourFile();
                    theFile.CreateDate = file.CreationTime;
                    theFile.Creator = CommonOperation.ConstParameter.UserName;
                    theFile.File_Type = "DOC";
                    theFile.FileName = file.Name;
                    theFile.Size = file.Length;
                    string tempFileId = allFiles[file.FullName.ToLower()];
                    if (!string.IsNullOrEmpty(tempFileId))
                    {
                        if (FolderFileDbService.Instance.refFiles(thisComponentType.GetId(), new List<string> { tempFileId }, out err))
                        {
                            continue;
                        }
                    }

                    if (!FolderFileDbService.Instance.IfFolderHasTheFile(thisComponentType.GetId(), theFile.FileName, out tempFileId))
                    {
                        FolderFileDbService.Instance.InsertAFile(thisComponentType.GetId(), theFile, file.FullName, out err);
                    }
                    else
                    {
                        theFile.FileId = tempFileId;
                    }
                    allFiles[file.FullName.ToLower()] = theFile.FileId;
                }
            }
            #endregion

            #region 插入维护保养默认消耗备件情况

            if (lstTempWorkInfo.Count != workinfoRowNumber.Count)
            {
                return (MessageBoxEx.Show("由于读取错误,造成工作信息默认消耗备件部分无法正常导入,是否继续导入其它信息?\r点击确认将继续,点击取消则退出)",
                    "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK);
            }

            for (int i = 0; i < workinfoRowNumber.Count; i++)
            {
                Application.DoEvents();
                //插入第i行的备件.
                //dicSpareInfos
                int nowColumn = modelHelper.GetAColumnPostion(currentModelType, ParameterType.可能消耗备件开始列);
                //N 可能消耗备件编号1
                string partnumber = GetAValueFromPositionColumnAndRow(nowColumn, workinfoRowNumber[i]);

                while (!string.IsNullOrEmpty(partnumber))
                {
                    if (dicSpareInfos.ContainsKey(partnumber))
                    {
                        //默认消耗数量.
                        decimal usingCount;
                        if (!decimal.TryParse(GetAValueFromPositionColumnAndRow(nowColumn + 1, workinfoRowNumber[i]), out usingCount))
                        {
                            break;
                        }
                        WorkInfoService.Instance.InsertIntoWorkinfoSpares(lstTempWorkInfo[i], dicSpareInfos[partnumber], (int)usingCount, out err);
                    }
                    nowColumn += 2;
                    partnumber = GetAValueFromPositionColumnAndRow(nowColumn, workinfoRowNumber[i]);
                }
            }
            #endregion
            return true;
        }


        #endregion

        #region 导入文件夹
        /// <summary>
        /// 导入文件夹
        /// 文件夹的存放要求(很严格,不符合则会报错)
        ///1) 最高层为系统文件夹,导入的文件夹里有一个什么系统的Excel文件 必须是系统类型
        ///   里面有子设备的文件夹
        ///2) 子设备文件夹 子设备的文件夹分两种,判断是哪种子设备文件夹
        /// 
        ///3)一种是里面只有各种设备的文件夹,
        /// 进入到每一个子设备中,分别处理每一个子设备文件夹
        ///4) 另一种是无下家文件夹有一堆的图片和Excel文件.
        /// 依次倒入所有的设备Excel文件,完成操作
        ///5)具体设备的文件夹
        /// 如果有子设备的文件夹,则里面是单个设备或者同型号的两个或多个设备
        ///     同型的设备用处理完第一个,剩下的 [ 根据某个设备拷贝到另一个设备 ] 的方式完成后续操作.
        /// 此类文件夹下面还可能有子设备文件夹,但不可能有多种设备并列的文件夹.只处理子设备文件夹.(与上面的2相同)
        /// 
        /// 导入时,可以直接选择一个系统文件夹(在系统下),也可以直接选择一个具体设备的文件夹或子设备文件夹(在系统和设备下均可)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (hasErr)
            {
                MessageBoxEx.Show("所选的设备型号有误,无法继续完成操作");
                return;
            }
            PrepareToImportDirectoryAllFiles();
        }
        private void PrepareToImportDirectoryAllFiles()
        {
            //打开对话框选择excel文件.
            DialogResult theResult = FolderBrowserDialogEx.ShowDialog(folderBrowserDialog1);
            if (theResult != DialogResult.OK)
            {
                MessageBoxEx.Show("用户取消了选择");
                return;
            }
            DirectoryInfo thisFolder = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            if (!thisFolder.Exists)
            {
                MessageBoxEx.Show("未选择有效的文件目录");
                return;
            }
            if (thisEquipmentClass == null)
            {
                importIntoOneEquipment(thisFolder, (ComponentUnit)parentComponentUnit.Clone());
            }
            else
            {
                importIntoOneSystem(thisFolder, (EquipmentClass)thisEquipmentClass.Clone());
            }
        }

        #region 目录夹导入时用到的功能
        //注意，这部分变量是为了让导入时有弹出正在导入的提示框。当时处理的不好，必须用无参数的委托函数才能执行。
        int nowImportSheet;
        bool returnErr = false;
        Excel toOperExcel;
        bool importAllfiles = false;
        ModelType currentModelType = ModelType.Err;
        ComponentUnit nowImportingEquipt = null;
        EquipmentClass nowImportingClass = null;
        List<ComponentUnit> nowImportingEquipments = null;
        string fileFullName = "";

        private void reallyImportOneFile(FileInfo f, bool importAllfiles, ComponentUnit parentUnit, EquipmentClass parentClass)
        {
            parentComponentUnit = parentUnit;
            thisEquipmentClass = parentClass;
            reallyImportOneFile(f, importAllfiles);
        }

        private void reallyImportOneFile(FileInfo f, bool importAllfiles)
        {
            fileFullName = f.FullName;
            filePath = f.DirectoryName;
            nowImportingEquipt = null;
            nowImportingClass = null;
            this.importAllfiles = importAllfiles;
            nowImportingEquipments = new List<ComponentUnit>();
            using (toOperExcel = new Excel())
            {
                try
                {
                    toOperExcel.OpenDocument(f.FullName);
                    if (onlySpare)
                    {
                        nowImportSheet = 1;
                        FrmBusy frmBusy = new FrmBusy("正在导入:" + f.Name, new FrmBusy.FinishedOpeartion(ImportExcelOneSheet));
                        frmBusy.ShowDialog();
                    }
                    else
                    {
                        //得到有多少页,按照页面去分别处理.
                        int sheetCount = toOperExcel.GetSheetsCount();
                        for (int i = 1; i <= sheetCount; i++)
                        {
                            returnErr = false;
                            nowImportSheet = i;
                            ModelType modelType;
                            int type;
                            judgeFile(f, i, out modelType, out type);
                            currentModelType = modelType;
                            if (modelType == ModelType.Err)
                            {
                                continue;
                            }
                            nowImportingEquipt = null;
                            FrmBusy frmBusy = new FrmBusy("正在导入:" + f.Name, new FrmBusy.FinishedOpeartion(ImportExcelOneSheet));
                            frmBusy.ShowDialog();
                            if (returnErr)
                                return;
                            if (nowImportingEquipt != null)
                                nowImportingEquipments.Add(nowImportingEquipt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("文件无法打开,可能是用户没有安装Excel,或者没有权限操作选定的文件,更多信息请参考:\r" + ex.Message);
                }
                toOperExcel.CloseDocument();
            }
        }

        /// <summary>
        /// 导入文件夹到系统下, 导入的内容可以是系统,也有可能是设备.得根据excel的内容判断.
        /// </summary>
        /// <param name="theFolder"></param>
        /// <param name="shipId"></param>
        /// <param name="parentSystem"></param>
        /// <returns></returns>
        private bool importIntoOneSystem(DirectoryInfo theFolder, EquipmentClass parentSystem)
        {
            FileInfo[] fileXls = theFolder.GetFiles("*.xls*");
            DirectoryInfo[] folders = theFolder.GetDirectories();
            string err;

            if (fileXls.Length == 1)
            {
                //单个系统或单个设备
                ModelType modelType;
                int type;
                FileInfo f = fileXls[0];

                if (judgeFile(f, out modelType, out type))
                {
                    reallyImportOneFile(f, true, shipUnit, parentSystem);

                    if (type == 1)
                    {
                        //导入当前的系统,且以后的所属系统用这个系统
                        if (nowImportingClass != null)
                        {
                            foreach (DirectoryInfo folder in folders)
                            {
                                if (!importIntoOneSystem(folder, (EquipmentClass)nowImportingClass.Clone()))
                                    return false;
                            }
                        }
                    }
                    else
                    {
                        List<ComponentUnit> tempEquipments = new List<ComponentUnit>();

                        for (int i = 0; i < nowImportingEquipments.Count; i++)
                        {
                            tempEquipments.Add((ComponentUnit)nowImportingEquipments[i].Clone());
                        }
                        for (int i = 0; i < tempEquipments.Count; i++)
                        {
                            ComponentUnit comp = tempEquipments[i];
                            if (i == 0)
                            {
                                foreach (DirectoryInfo folder in folders)
                                {
                                    if (!importIntoOneEquipment(folder, comp))
                                        return false;
                                }
                            }
                            else
                            {
                                if (!ComponentUnitService.Instance.CloneEquipmentSubToAnotherEquipmentSub(tempEquipments[0], comp, shipUnit.SHIP_ID, true, false, out err))
                                    return false;
                            }
                        }
                    }
                }
            }
            else if (fileXls.Length == 0)
            {
                //没有excel,则循环下面目录,再次进入此函数
                foreach (DirectoryInfo tempFolder in folders)
                {
                    if (!importIntoOneSystem(tempFolder, parentSystem))
                        return false;
                }
            }
            else
            {
                //是一堆的文件,则使用importSomeEquipments导入,不再进行下级目录的导入
                if (!importSomeEquipments(theFolder, shipUnit, parentSystem))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 导入文件夹到设备下, 导入的内容只能是设备.
        /// </summary>
        /// <param name="theFolder"></param>
        /// <param name="parentSystem"></param>
        /// <returns></returns>
        private bool importIntoOneEquipment(DirectoryInfo theFolder, ComponentUnit parentEquipment)
        {
            FileInfo[] fileXls = theFolder.GetFiles("*.xls*");
            DirectoryInfo[] folders = theFolder.GetDirectories();
            string err;

            if (fileXls.Length == 1)
            {
                //单个系统或单个设备
                ModelType modelType;
                int type;
                FileInfo f = fileXls[0];

                if (judgeFile(f, out modelType, out type))
                {
                    if (type == 1)
                    {
                        if (MessageBoxEx.Show("设备下不能导入系统,导入中断,中断的文件是" + f.FullName
                            + "\r\n 如果当前属于录入错误,继续当设备(部件)导入,请选择是,否则选择否!", "错误提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                            return false;
                        else
                        {
                            try
                            {
                                using (Excel tempExcel = new Excel())
                                {
                                    tempExcel.OpenDocument(f.FullName);
                                    tempExcel.SetValue("C2", "部件");
                                    tempExcel.SaveDocument(f.FullName);
                                    tempExcel.CloseDocument();
                                    tempExcel.Dispose();
                                }
                            }
                            catch
                            {
                                MessageBoxEx.Show("未修改成功,可能是文件锁定导致的,请退出程序,手动修改并重试!");
                            }
                        }
                    }

                    //导入文件
                    reallyImportOneFile(f, true, parentEquipment, null);

                    //导入当前设备,且以后的所属设备用这个设备.
                    if (nowImportingEquipments != null && nowImportingEquipments.Count > 0)
                    {
                        if (nowImportingEquipments.Count == 1)
                        {
                            ComponentUnit comp = nowImportingEquipments[0];
                            foreach (DirectoryInfo folder in folders)
                            {
                                if (!importIntoOneEquipment(folder, comp))
                                    return false;
                            }
                        }
                        else
                        {
                            List<ComponentUnit> tempEquipments = new List<ComponentUnit>();

                            for (int i = 0; i < nowImportingEquipments.Count; i++)
                            {
                                tempEquipments.Add((ComponentUnit)nowImportingEquipments[i].Clone());
                            }
                            for (int i = 0; i < tempEquipments.Count; i++)
                            {
                                ComponentUnit comp = tempEquipments[i];
                                if (i == 0)
                                {
                                    foreach (DirectoryInfo folder in folders)
                                    {
                                        if (!importIntoOneEquipment(folder, comp))
                                            return false;
                                    }
                                }
                                else
                                {
                                    if (!ComponentUnitService.Instance.CloneEquipmentSubToAnotherEquipmentSub(tempEquipments[0], comp, shipUnit.SHIP_ID, true, false, out err))
                                        return false;
                                }
                            }
                        }
                    }

                }
            }
            else if (fileXls.Length == 0)
            {
                //没有excel,则循环下面目录,再次进入此函数
                foreach (DirectoryInfo tempFolder in folders)
                {
                    if (!importIntoOneEquipment(tempFolder, parentEquipment))
                        return false;
                }
            }
            else
            {
                //是一堆的文件,则使用importSomeEquipments导入,不再进行下级目录的导入
                if (!importSomeEquipments(theFolder, parentEquipment, null))
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 一堆子设备,不可能还有下级了,不需要再递归
        /// </summary>
        /// <param name="theFolder"></param>
        /// <param name="childOfSystem"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private bool importSomeEquipments(DirectoryInfo theFolder, ComponentUnit parentUnit, EquipmentClass parentClass)
        {
            //给分别分配给单个文件的导入....
            FileInfo[] fileXls = theFolder.GetFiles("*.xls*");
            foreach (FileInfo f in fileXls)
            {
                reallyImportOneFile(f, false, parentUnit, parentClass);
                if (nowImportingEquipt == null && nowImportingClass == null)
                    return false;
            }
            return true;
        }

        private bool judgeFile(FileInfo fileinfo, out ModelType modelType, out int type)
        {
            return judgeFile(fileinfo, 1, out modelType, out type);
        }
        private bool judgeFile(FileInfo fileinfo, int pageCount, out ModelType modelType, out int type)
        {
            using (Excel tempExcel = new Excel())
            {
                modelType = ModelType.Err;
                type = 2;
                if (fileinfo.Exists)
                {
                    tempExcel.OpenDocument(fileinfo.FullName);

                    #region 检查模板版 及其有效性
                    if (tempExcel.GetRangeValue(pageCount, "A1").Equals("版本号:1.10"))
                    {
                        if (!tempExcel.GetRangeValue(pageCount, "B2").Equals("设备名称*") || !tempExcel.GetRangeValue(pageCount, "B20").Equals("操作名称*"))
                        {
                            MessageBoxEx.Show("无法进行导入,导入的文件格式有误");
                            return false;
                        }
                        modelType = ModelType.Model110;
                    }
                    else if (tempExcel.GetRangeValue(pageCount, "A1").Equals("版本号:1.20"))
                    {
                        if (!tempExcel.GetRangeValue(pageCount, "B2").Equals("分类") || !tempExcel.GetRangeValue(pageCount, "B22").Equals("操作名称*"))
                        {
                            MessageBoxEx.Show("无法进行导入,导入的文件格式有误");
                            return false;
                        }
                        modelType = ModelType.Model120;
                        string typeName = tempExcel.GetRangeValue(pageCount, "C2");
                        if (typeName == "系统")
                        {
                            type = 1;
                        }
                        else if (typeName == "设备")
                        {
                            type = 2;
                        }
                        else if (typeName == "部件")
                        {
                            type = 3;
                        }
                        else type = 4;
                    }
                    #endregion

                }
                else
                {
                    MessageBoxEx.Show("文件[" + fileinfo + "]不存在");
                    return false;
                }
            }
            return true;
        }

        #endregion

        #endregion

        #region 整船导入

        protected enum EquipmentType
        {
            EQUIPCLASS = 1,
            EQUIPMENT = 2,
            COMPONENT = 3,
            ERROR = 4,
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            PrepareToImportFullFleet();
        }

        private void PrepareToImportFullFleet()
        {
            openFileDialog1.Multiselect = false;
            //打开对话框选择excel文件.
            DialogResult theResult = OpenFileDialogEx.ShowDialog(openFileDialog1);
            if (theResult != DialogResult.OK)
            {
                MessageBoxEx.Show("用户取消了选择");
                return;
            }
            string[] fileNames = openFileDialog1.FileNames;
            StringBuilder errInfo = new StringBuilder();
            if (ImportFullFleetEquipment(new FileInfo(fileNames[0]), ref errInfo))
            {
                MessageBox.Show("未能成功导入,发现错误信息为:\r" + errInfo, "导入失败");
            }
            else if (errInfo.Length > 0)
            {
                MessageBox.Show("成功导入,但发现如下错误信息:\r" + errInfo, "导入成功");
            }
        }

        /// <summary>
        /// 导入全船资料
        /// 导入时，如果导入excel的设备型号名称与外围的设备Excel文件名称不一致，则报一个警，但不终止。
        /// （注意，文件中的设备名称，在这种导入的方式下，不作为参考内容，但不一样也同样报警）
        /// </summary>
        /// <param name="fullFleetEquipment">全船资料</param>
        private bool ImportFullFleetEquipment(FileInfo fullFleetEquipment, ref StringBuilder err)
        {
            err = new StringBuilder();
            //step 1,文件格式校验, 
            //
            Dictionary<string, EquipmentInfoOfFullFleetFile> dicAllInfo = new Dictionary<string, EquipmentInfoOfFullFleetFile>();
            List<EquipmentInfoOfFullFleetFile> listAllInfo = new List<EquipmentInfoOfFullFleetFile>();
            bool deadError = false;
            #region step 2,构成对象,并建立上下级关系,
            using (toOperExcel = new Excel())
            {
                try
                {
                    toOperExcel.OpenDocument(fullFleetEquipment.FullName);
                }
                catch (Exception e)
                {
                    deadError = true;
                    err.AppendLine("不能打开Excel文件" + fullFleetEquipment.FullName + "\r" + e.Message);
                    return false;
                }
                int excelRowCount = toOperExcel.GetMaxRowNumber();
                for (int i = 3; i <= excelRowCount; i++)
                {
                    EquipmentInfoOfFullFleetFile tempOne = GetOneEquipmentInfoByRowNumber(toOperExcel, i);
                    listAllInfo.Add(tempOne);
                    //设备文件不存在,报警
                    //父编号和父名称对不上
                    if (dicAllInfo.ContainsKey(tempOne.EquimentInfoCode))
                    {

                    }
                    else
                    {
                        dicAllInfo.Add(tempOne.EquimentInfoCode, tempOne);
                    }
                }
            }
            #endregion
            if (deadError) return false;

            //step 3,导入到数据库.
            return true;
        }
        /// <summary>
        /// 获取某行的业务对象
        /// </summary>
        /// <param name="excelOperation">Excel文件操作对象</param>
        /// <param name="rowNumber">行数</param>
        /// <returns></returns>
        private EquipmentInfoOfFullFleetFile GetOneEquipmentInfoByRowNumber(Excel excelOperation, int rowNumber)
        {
            EquipmentInfoOfFullFleetFile equipmentInfoOfFullFleetFile = new EquipmentInfoOfFullFleetFile();
            long sortTemp;
            if (long.TryParse(excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(2, rowNumber)), out sortTemp))
            {
                equipmentInfoOfFullFleetFile.Sort = sortTemp;
            }
            string typeString = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(3, rowNumber));
            equipmentInfoOfFullFleetFile.Equipment_Type = (typeString == "系统" ? EquipmentType.EQUIPCLASS :
                (typeString == "设备" ? EquipmentType.EQUIPMENT : (typeString == "部件" ? EquipmentType.COMPONENT : EquipmentType.ERROR)));
            equipmentInfoOfFullFleetFile.EquimentInfoCode = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(4, rowNumber));
            equipmentInfoOfFullFleetFile.EquipmentInfoName = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(5, rowNumber));
            equipmentInfoOfFullFleetFile.EquipmentFileName = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(6, rowNumber));
            equipmentInfoOfFullFleetFile.SystemCode = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(7, rowNumber));
            equipmentInfoOfFullFleetFile.ParentCode = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(8, rowNumber));
            equipmentInfoOfFullFleetFile.ParentName = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(9, rowNumber));
            equipmentInfoOfFullFleetFile.FileLocation = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(10, rowNumber));
            equipmentInfoOfFullFleetFile.SerialNumber = excelOperation.GetRangeValue(1, excelOperation.GetSingleCellRange(11, rowNumber));
            return equipmentInfoOfFullFleetFile;
        }

        protected class EquipmentInfoOfFullFleetFile
        {
            /// <summary>
            /// NO	排序号  将来按照排序号给设备排序
            /// </summary>
            public long Sort;
            /// <summary>
            /// 类型：分类，设备，部件
            /// </summary>
            public EquipmentType Equipment_Type;
            /// <summary>
            /// COMPONENT_CODE	设备编号(CWBT09) CWBT编号，也可能是其他设备编号，有则导入
            /// </summary>
            public string EquimentInfoCode;
            /// <summary>
            /// COMPONENT_NAME	设备名称
            /// </summary>
            public string EquipmentInfoName;
            /// <summary>
            /// COMPONENT_FILE_NAME	设备Excel文件名（如不一样时，需要标明）
            ///      同时作为设备型号名称 ，如果有，则使用其在存放位置处找文件，
            ///      如果没有则使用‘设备名称’配合存放位置找文件，如果找不到，则在存放位置找第一个Excle文件即可。
            /// </summary>
            public string EquipmentFileName;
            /// <summary>
            /// SYSTEM	类别(CWBT09系统)
            /// </summary>
            public string SystemCode;
            /// <summary>
            /// PARENTCOM_CODE	父设备编号（CWBT09）
            /// </summary>
            public string ParentCode;
            /// <summary>
            /// PARENTCOM_NAME	父设备(上级结点名称)     其实有code就行了 这个列无用,可以做一个校验,不一致提示.
            /// </summary>
            public string ParentName;
            /// <summary>
            /// FILELOCATION	资料存放位置
            /// </summary>
            public string FileLocation;
            /// <summary>
            /// SERIAL_NUMBER	设备序列号
            /// </summary>
            public string SerialNumber;

            public string ID;
        }
        #endregion
    }
}
