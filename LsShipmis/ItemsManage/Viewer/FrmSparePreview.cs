using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.Services;
using System.Drawing.Drawing2D;
using ItemsManage.DataObject;
using CommonViewer.BaseControlService;
using ItemsManage.Services;
using ItemsManage.Viewer.Forms;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using System.IO;

namespace ItemsManage.Viewer
{
    public partial class FrmSparePreview : CommonViewer.BaseForm.FormBase
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmSparePreview instance = new FrmSparePreview();
        public static FrmSparePreview Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSparePreview.instance = new FrmSparePreview();
                }
                return FrmSparePreview.instance;
            }
        }
        #endregion
        /// <summary>
        /// 权限代理业务类.
        /// </summary>
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;
        private FrmSparePreview()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            panel3.MouseWheel += new MouseEventHandler(panel3_MouseWheel);
            string err;
            buttonEx3.Enabled = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEMS_EDIT, out err);
        }
        public FrmSparePreview(string componentTypeIdIn)
            : this()
        {
            component_type = componentTypeIdIn;
        }
        public FrmSparePreview(ComponentUnit componentUnitIn)
            : this(componentUnitIn.COMPONENT_TYPE_ID)
        {
            component_unit = componentUnitIn;
        }
        private Point m_ptStart = new Point(0, 0);
        public delegate void NeedSpare(List<StorageParameter> needSpares);
        public NeedSpare needSpare;
        #region 新增多图片浏览功能
        void panel3_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                //autoLoadNextPic(Forword.DOWN);
                //缩小.
                resetPictrue(false);
            }
            else
            {
                //autoLoadNextPic(Forword.UP);
                //放大.
                resetPictrue(true);
            }
        }

        /// <summary>
        /// 设置图片只能水平显示.
        /// </summary>
        private void setPictureScale(bool changeImg)
        {
            if (img == null)
            {
                if (pictureBox.Image != null) pictureBox.Image.Dispose();
                return;
            }
            int panelHer = panel3.Width;
            if (changeImg)
            {
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName)) return;
                pictureBox.Width = panelHer;
                pictureBox.Image = img;
            }
            int imgHer = img.Width;

            if (imgHer > panelHer)
            {
                float scale = (float)panelHer / (float)imgHer;
                int newHei = Convert.ToInt16(img.Height * scale);
                pictureBox.Size = new Size(panel3.Width, newHei);
            }
            else
            {
                pictureBox.Size = img.Size;
            }
            if (pictureBox.Width < panelHer) pictureBox.Location = new Point((panelHer - pictureBox.Width) / 2, 0);
            else pictureBox.Location = new Point(0, 0);
            pictureBox.Refresh();
        }

        Image img = null;
        private void resetPictrue(bool bigger)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName)) return;
                int panelHer = panel3.Width; //panel宽度 - 给滚动条预留的宽度 - 23
                int pictureNowWidth = pictureBox.Width; //图片当前宽度.

                int imgHer = img.Width; //图片原始宽度.
                int nextWidth; //下次宽度.
                if (bigger)
                {
                    int maxSize = panelHer;
                    if (imgHer * 3 > maxSize) maxSize = imgHer * 3;
                    if (pictureNowWidth >= maxSize || pictureNowWidth >= 6000 || (pictureNowWidth * img.Height / img.Width) >= 6000) return;
                    nextWidth = (int)(pictureNowWidth * 1.25);
                    if (nextWidth == pictureNowWidth) nextWidth++;
                    if (pictureNowWidth < img.Width && nextWidth > img.Width) nextWidth = img.Width;
                    else if (nextWidth > maxSize) nextWidth = maxSize;
                }
                ////增大逻辑处理部分:最大大小是300% 及 控件大小的较大者  && 当滚动放大时,越过100%大小时先选择100%再继续.
                //if (bigger)
                //{
                //    int maxSize = 6000 < panelHer ? 6000 : panelHer;
                //    if (imgHer * 3 > maxSize) maxSize = imgHer * 3;
                //    if (pictureNowWidth >= maxSize) return;

                //    nextWidth = (int)(pictureNowWidth * 1.25);
                //    if (nextWidth == pictureNowWidth) nextWidth++;
                //    if (pictureNowWidth < img.Width && nextWidth > img.Width) nextWidth = img.Width;
                //    else if (nextWidth > maxSize) nextWidth = maxSize;
                //}

                //缩小逻辑处理部分:最小大小是屏幕控件大小及100%的最小者 && 当滚动缩小时,越过100%大小时,同样选择100%再继续.
                else
                {
                    int minSize = panelHer;
                    if (imgHer < minSize) minSize = imgHer;
                    if (pictureNowWidth <= minSize) return;
                    nextWidth = (int)(pictureNowWidth * 0.90);
                    if (nextWidth == pictureNowWidth) nextWidth--;
                    if (pictureNowWidth > img.Width && nextWidth < img.Width) nextWidth = img.Width;
                    else if (nextWidth < minSize) nextWidth = minSize;
                }
                int lastX = pictureBox.Width;
                int lastY = pictureBox.Height;

                Point p = Cursor.Position;
                Point pOfPanel = LocationOnClient(panel3);
                //Cursor.Size
                //当前鼠标X轴位置.
                int pointX = p.X - pOfPanel.X;
                //当前鼠标Y轴位置.
                int pointY = p.Y - pOfPanel.Y - Cursor.Size.Height;
                //当前宽度.
                int viewX = nextWidth;
                //当前高度.
                int viewY = (int)(img.Height * nextWidth / img.Width);
                //原始高度.
                int originalX = img.Width;
                //原始宽度.
                int originalY = img.Height;
                //当前放大率.
                decimal currentMagniFication = (decimal)viewX / originalX;
                //上一次放大率.
                decimal lastMagniFication = (decimal)lastX / originalX;
                //上一次图片X轴的位置.
                int lastPicX = pictureBox.Location.X;
                //上一次图片Y轴的位置.
                int lastPicY = pictureBox.Location.Y;

                int realX = pointX - lastPicX;
                int realY = pointY - lastPicY;

                int picX = pointX - (int)(currentMagniFication * realX / lastMagniFication);
                int picY = pointY - (int)(currentMagniFication * realY / lastMagniFication);
                pictureBox.Size = new Size(viewX, viewY);
                pictureBox.Location = new Point(picX, picY);

                pictureBox.Refresh();
            }
            catch
            {
                MessageBox.Show("已经最大无法继续放大");
            }
        }

        private Point LocationOnClient(Control c)
        {
            Point retval = new Point(0, 0);
            for (; c.Parent != null; c = c.Parent)
            {
                retval.Offset(c.Location);
            }
            return retval;
        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            panel3.Focus();
        }

        //获取当前行便宜量为p行的文件名.
        private string getCurrentFileName(int p)
        {
            if (filesView.Rows.Count <= 0 || filesView.CurrentCell == null) return null;
            int currentRow = filesView.CurrentCell.RowIndex;
            return filesView.Rows[currentRow + p].Cells["FILE_NAME"].Value.ToString();
        }

        #endregion

        //当前的设备.
        private ComponentUnit component_unit;
        //设备类别.
        private string component_type;
        private string fileName;

        /// <summary>
        /// 加载数据.
        /// </summary>
        private void loadData()
        {
            if (component_type == null) return;
            loadSpares(component_type);
            //加载图纸信息.
            loadPicture(component_type);
        }

        /// <summary>
        /// 加载备件信息.
        /// </summary>
        /// <param name="component_type"></param>
        private void loadSpares(string component_type)
        {
            if (component_type == null) return;
            DataTable dt = SpareInfoService.Instance.GetSpareByComponentType(component_type);
            bindingSource1.DataSource = dt;
            dgvSpare.DataSource = bindingSource1;
            dgvSpare.LoadGridView("FrmSparePreview.dgvSpare");

            Dictionary<string, string> allColumnsName = new Dictionary<string, string>();
            allColumnsName.Add("spare_name", "备件名称");
            allColumnsName.Add("spare_ename", "第二语言名称");
            allColumnsName.Add("partnumber", "配件号|规格");
            allColumnsName.Add("partnumber_his1", "历史备件号1");
            allColumnsName.Add("partnumber_his2", "历史备件号2");
            allColumnsName.Add("picnumber", "备件图号");
            allColumnsName.Add("piccode", "在图编号");
            allColumnsName.Add("unit_name", "计量单位");
            allColumnsName.Add("alertstock", "警戒库存");
            allColumnsName.Add("makeupNumber", "构成数量");
            allColumnsName.Add("remark", "备注");

            dgvSpare.SetDgvGridColumns(allColumnsName);

            //为dgv添加一个多选列，可以一下选择一堆.
            DataGridViewColumn toSelect = new DataGridViewColumn(new DataGridViewCheckBoxCell());
            toSelect.Name = "selected";
            toSelect.HeaderText = "";
            toSelect.DisplayIndex = 0;
            toSelect.ReadOnly = false;
            toSelect.Width = 30;
            dgvSpare.Columns.Add(toSelect);
        }

        /// <summary>
        /// 加载设备图纸,这里的类别id相当于文件夹id
        /// </summary>
        /// <param name="p">传入设备的类别id</param>
        private void loadPicture(string p)
        {
            DataTable dt = FolderFileDbService.Instance.GetFileByFolder(p);

            DataColumn colext = new DataColumn("ext");
            dt.Columns.Add(colext);

            //将扩展名增加入列.
            foreach (DataRow dr in dt.Rows)
            {
                if (DBNull.Value != dr["FILE_NAME"] && dr["FILE_NAME"].ToString() != "")
                {
                    string fileName = dr["FILE_NAME"].ToString().Trim();
                    System.IO.FileInfo fio = new System.IO.FileInfo(fileName);
                    String ext = fio.Extension.ToLower();
                    dr["ext"] = ext;
                }
            }

            //绑定.
            DataView dv = dt.DefaultView;
            dv.RowFilter = "ext in ('.gif','.jpg','.jpeg','.bmp','.wmf','.png')";
            filesView.DataSource = dv;
            filesView.LoadGridView("FrmSparePreview.filesView");
            //设定隐藏列.
            foreach (DataGridViewColumn col in filesView.Columns)
            {
                col.Visible = false;
            }
            filesView.Columns["FILE_NAME"].HeaderText = "图纸名";
            filesView.Columns["FILE_NAME"].Visible = true;
        }

        int lastRowIndex = -1;

        //点击显示文件.
        private void filesView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == lastRowIndex) return;
            lastRowIndex = e.RowIndex;
            FrmBusy frm = new FrmBusy("正在读取数据库中的备件图片文件\r\nloading spare picture...", new FrmBusy.FinishedOpeartion(loadingPic));
            frm.ShowDialog();
        }
        private void loadingPic()
        {
            if (FileDbService.Instance.GetABolbByFileId(filesView.Rows[lastRowIndex].Cells["file_id"].Value.ToString(), out fileName))
            {
                if (string.Empty.Equals(fileName)) return;//没有文件则返回.

                if (img != null) img.Dispose();
                GC.Collect();

                img = Image.FromFile(fileName);
                setPictureScale(true);

                ////过滤信息.
                System.IO.FileInfo fl = new System.IO.FileInfo(fileName);

                DataView dv = (DataView)dgvSpare.DataSource;
                string condition = "'" + fl.Name.Replace("'", "''") + "' like  '%'+ " + CommonOperation.Functions.InterfaceInstantiation.NewADBOperation().DbIsNull + "(picnumber,'')+ '%'";

                dv.RowFilter = condition;
                if (dgvSpare.Rows.Count == 0)
                {

                    dv.RowFilter = "";
                }
            }
        }

        private void FrmSpareOutStore_Resize(object sender, EventArgs e)
        {
            setPictureScale(false);
        }

        private void FrmSpareOutStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvSpare.SaveGridView("FrmSparePreview.dgvSpare");
            filesView.SaveGridView("FrmSparePreview.filesView");
            instance = null;    //释放窗体实例变量.
        }

        //设定复选框的选定状态.
        private void dgvSpare_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvSpare.Columns[e.ColumnIndex].Name == "selected" && e.RowIndex >= 0)
            {
                if (null == dgvSpare.Rows[e.RowIndex].Cells["selected"].Value) dgvSpare.Rows[e.RowIndex].Cells["selected"].Value = true;
                else
                    dgvSpare.Rows[e.RowIndex].Cells["selected"].Value = !(bool)(dgvSpare.Rows[e.RowIndex].Cells["selected"].Value);

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            if (txtSearch.Text.Trim().Length > 0)
            {
                string condition = "spare_name like '%" + txtSearch.Text.Trim() + "%' or spare_ename like '%" + txtSearch.Text.Trim()
                    + "%' or picnumber like '%" + txtSearch.Text.Trim() + "%'  or partnumber like '%" + txtSearch.Text.Trim() + "%'";
                bindingSource1.Filter = condition;
            }
        }
        //显示全部.
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = "";
        }

        /// <summary>
        /// 备件申请（调用备件申请界面申请选择的备件信息）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequire_Click(object sender, EventArgs e)
        {

            List<StorageParameter> lstSpareIds = this.getLstSpares();   //取网格dgvSpare中选择的备件Id组成的List集合.
            string remark = "";

            if (lstSpareIds.Count > 0)
            {
                //打开备件申请界面.
                if (ItemsManageConfig.openSpareApplyForm != null)
                    ItemsManageConfig.openSpareApplyForm(component_unit, lstSpareIds, remark);
                else
                {
                    MessageBoxEx.Show("系统没有把备件申请界面注册到此处！");
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要申请的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// 备件入库（调用备件入库界面申请选择的备件信息）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIn_Click(object sender, EventArgs e)
        {
            List<StorageParameter> lstSpareIds = this.getLstSpares();   //取网格dgvSpare中选择的备件Id组成的List集合.
            string remark = "设备维护保养过程中的备件入库";

            if (lstSpareIds.Count > 0)
            {
                //打开备件申请界面.
                if (ItemsManageConfig.openSpareInForm != null)
                    ItemsManageConfig.openSpareInForm(lstSpareIds, remark);
                else
                {
                    MessageBoxEx.Show("系统没有把备件出库界面注册到此处！");
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要入库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 备件出库（调用备件出库界面申请选择的备件信息）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            List<StorageParameter> lstSpares = this.getLstSpares();   //取网格dgvSpare中选择的备件Id组成的List集合.
            string remark = "设备维护保养过程中的备件出库";

            if (lstSpares.Count > 0)
            {
                //打开备件申请界面.
                if (ItemsManageConfig.openSpareOutForm != null)
                    ItemsManageConfig.openSpareOutForm(lstSpares, remark);
                else
                {
                    MessageBoxEx.Show("系统没有把备件出库界面注册到此处！");
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要出库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 取网格dgvSpare中选择的备件Id组成的List集合.
        /// </summary>
        /// <returns></returns>
        private List<StorageParameter> getLstSpares()
        {
            List<StorageParameter> lstSpares = new List<StorageParameter>();
            foreach (DataGridViewRow dgvRow in dgvSpare.Rows)
            {
                if (dgvRow.Cells["selected"].Value != null && (bool)(dgvRow.Cells["selected"].Value) == true)
                {
                    StorageParameter sp = new StorageParameter();
                    sp.ItemId = dgvRow.Cells["spare_id"].Value.ToString();
                    lstSpares.Add(sp);
                }
            }
            return lstSpares;
        }

        private void FrmSpareOutStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (img != null)
            {
                img.Dispose();
            }
            if (pictureBox.Image != null) pictureBox.Image.Dispose();
            GC.Collect();

            instance = null;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            m_ptStart = new Point(e.X, e.Y);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureBox.Width > panel3.Width || pictureBox.Height > panel3.Height)
            {
                Point nowPoint = new Point(e.X, e.Y);
                pictureBox.Location = new Point(pictureBox.Location.X + nowPoint.X - m_ptStart.X, pictureBox.Location.Y + nowPoint.Y - m_ptStart.Y);
                try
                {
                    pictureBox.Refresh();
                }
                catch { }//此处不捕获错误.
            }
        }

        private int topHeight = 0;
        private int leftWidth = 0;

        private void FrmSpareOutStore_Load(object sender, EventArgs e)
        {
            topHeight = splitContainer1.Panel1.Height;
            leftWidth = splitContainer2.Panel1.Width;
            if (needSpare != null)
            {
                button2.Visible = true;
                //btnIn.Visible = false;
                btnOut.Visible = false;
                btnRequire.Visible = false;
            }
            else
            {
                button2.Visible = false;
                if (!CommonOperation.ConstParameter.IsLandVersion)
                {
                    if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN)
                    {
                        //        btnIn.Visible = true;
                        btnOut.Visible = true;
                        btnRequire.Visible = true;
                    }
                }
            }
            loadData();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Panel1.Height == topHeight ? this.Height - 10 : topHeight;
            splitContainer2.SplitterDistance = splitContainer2.Panel1.Width == 0 ? leftWidth : 0;
            setPictureScale(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<StorageParameter> lstSpares = this.getLstSpares();   //取网格dgvSpare中选择的备件Id组成的List集合.

            if (lstSpares.Count > 0)
            {
                if (needSpare != null)
                {
                    needSpare(lstSpares);
                    this.Close();
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            FrmSparePreview.instance = null;
            this.Close();
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            if (dgvSpare.CurrentRow != null && dgvSpare.CurrentRow.Cells["spare_id"].Value != null)
            {
                FrmSpareBasic frm = new FrmSpareBasic(dgvSpare.CurrentRow.Cells["spare_id"].Value.ToString());
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                button1_Click(sender, e);
            }
            else
            {
                MessageBoxEx.Show("请先选择到下方备件列表的某行，才能进行所选备件维护！");
            }
        }
        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            if (pictureBox.Width > panel3.Width || pictureBox.Height > panel3.Height)
                pictureBox.Cursor = Cursors.SizeAll;
            else
                pictureBox.Cursor = Cursors.Default;
        }
    }
}