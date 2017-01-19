using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance.Services;
using Maintenance.DataObject;
using CommonViewer.BaseForm;
using CommonOperation.BaseClass;
using ItemsManage.DataObject;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmSelectWorkTemplet : FormBase
    {

        #region 窗体对象

        T_WORKINFO_TEMPLATE_CLASS templateClass;
        TreeNode nowNode;

        #endregion

        public bool NeedRetrieve = false;
        int typeOfRefObject = 0;
        string confirmpostid = "";
        string postid;
        string shipid;
        CommonClass refObject;
        List<string> lstExistWorkInfo = new List<string>();

        public FrmSelectWorkTemplet(CommonClass refObject)
        {
            InitializeComponent();
            this.refObject = refObject;
            if (refObject == null || refObject.IsWrong)
            {
                buttonEx5.Text = "要初始化工作信息的对象无效";
            }
            else
            {
                if (refObject.GetTypeName() == "ComponentUnit")
                {
                    typeOfRefObject = 1;
                    refObject.FillThisObject();
                    ((ComponentUnit)refObject).TheComponentType.FillThisObject();
                    shipid = ((ComponentUnit)refObject).SHIP_ID;
                    Post post = ((ComponentUnit)refObject).TheComponentType.ThePrincipalPost;
                    Post leaderPost;
                    if (post != null && !post.IsWrong)
                    {                     
                        string err;
                        PostService.Instance.GetDepartLeaderPost(post.DEPARTMENTID, out leaderPost, out err);
                        postid = post.GetId();
                        if (leaderPost != null) confirmpostid = leaderPost.GetId();
                    }               
               
                    List<WorkInfo> lstWorkInfo = WorkInfoService.Instance.GetAllWorkInfoOfAObject(refObject.GetId());
                    foreach (WorkInfo wi in lstWorkInfo)
                    {
                        if (!lstExistWorkInfo.Contains(wi.WORKINFONAME)) lstExistWorkInfo.Add(wi.WORKINFONAME);
                    }
                }
                else if (refObject.GetTypeName() == "SpareInfo")
                {
                    typeOfRefObject = 2;
                }
                buttonEx5.Text = "为" + refObject.ToString() + "快速初始化工作信息";
            }
        }

        private void FrmSelectWorkTemplate_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        /// <summary>
        /// 加载tree初始数据.
        /// </summary>
        public void reloadData()
        {
            //加载根节点.
            TreeNode rootNode = new TreeNode("工作模板分类");
            rootNode.Tag = "root";
            rootNode.ImageKey = "root";
            treeView1.Nodes.Add(rootNode);

            //界面刚打开时把根节点变为当前节点.
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treenodeClick(e.Node);
        }

        /// <summary>
        /// 点击tree节点实现相关功能.
        /// </summary>
        private void treenodeClick(TreeNode tn)
        {
            //判断当前是否需要展开下一级.
            string objectID = "root".Equals(tn.Tag) ? "" : ((CommonClass)tn.Tag).GetId();

            List<T_WORKINFO_TEMPLATE_CLASS> lists = T_WORKINFO_TEMPLATE_CLASSService.Instance.GetObjectsByParentId(objectID);
            tn.Nodes.Clear();
            int i = 0;
            foreach (T_WORKINFO_TEMPLATE_CLASS node in lists)
            {
                tn.Nodes.Add(formATreeNode(node, false));
                i++;
            }
            //展开当前节点.
            tn.Expand();

            //把当前节点的信息传给右边.
            try
            {
                nowNode = tn;               //更新当前节点信息.
                string classID ="";
                if (!"root".Equals(tn.Tag))
                {
                    templateClass = (T_WORKINFO_TEMPLATE_CLASS)nowNode.Tag;
                    classID = templateClass.GetId();
                }
                else
                {
                    templateClass = null;
                }

                //加载工作信息列表.
                workinfoByObject(classID);
            }
            catch { }
        }

        /// <summary>
        /// 生成一个新的树结点.
        /// </summary>
        private TreeNode formATreeNode(T_WORKINFO_TEMPLATE_CLASS node, bool ifRoot)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = node.GetId();
            newNode.Text = node.NODE_NAME;
            newNode.Tag = node;

            newNode.ImageKey = "base";
            newNode.SelectedImageKey = "open";
            return newNode;

        }

        /// <summary>
        /// 显示工作信息列表.
        /// </summary>
        private void workinfoByObject(string classID)
        {
            string err = "";
            DataTable dt = T_WORKINFO_TEMPLETService.Instance.getDetail(classID, lstExistWorkInfo, out err);
            dgvMain.DataSource = dt;
            dgvMain.SetDataGridViewNoSort();
            dgvMain.Columns["WORKINFO_TEMPLET_ID"].Visible = false;
            dgvMain.Columns["COMPONENTREFERENCE"].Visible = false;
            dgvMain.Columns["CLASS_ID"].Visible = false;

            dgvMain.Columns["ITEMNAME"].HeaderText = "保养项目";
            dgvMain.Columns["ITEMNAME"].ReadOnly = true;
            dgvMain.Columns["ITEMCONTENT"].HeaderText = "保养内容";
            dgvMain.Columns["ITEMCONTENT"].ReadOnly = true;
            dgvMain.Columns["PERIOD"].HeaderText = "预检周期";
            dgvMain.Columns["PERIOD"].ReadOnly = true;
            dgvMain.Columns["PERIODICAL"].HeaderText = "单位";
            dgvMain.Columns["PERIODICAL"].ReadOnly = true;
            dgvMain.Columns["TIMINGPERIOD"].HeaderText = "预检周期(定时)";
            dgvMain.Columns["TIMINGPERIOD"].ReadOnly = true;
            dgvMain.Columns["REMARK"].HeaderText = "备注";
            dgvMain.Columns["REMARK"].ReadOnly = true;

            dgvMain.Columns["COMPONENTREFERENCE"].Width = 160;
            dgvMain.Columns["ITEMNAME"].Width = 100;
            dgvMain.Columns["ITEMCONTENT"].Width = 400;
            dgvMain.Columns["PERIOD"].Width = 40;
            dgvMain.Columns["PERIODICAL"].Width = 40;
            dgvMain.Columns["REMARK"].Width = 400;

            foreach (DataGridViewRow dr in dgvMain.Rows)
            {
                dr.Cells["selected"].Value = cbSelectAll.Checked;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";
            foreach (DataGridViewRow dr in dgvMain.Rows)
            {
                if ((bool)dr.Cells["selected"].Value)
                {
                    WorkInfo wi = new WorkInfo();
                    wi.SHIP_ID = ((ComponentUnit)refObject).SHIP_ID;
                    wi.REFOBJID = refObject.GetId();
                    wi.WORKINFONAME = dr.Cells["ITEMNAME"].Value.ToString();
                    wi.WORKINFOTYPE = typeOfRefObject;
                    wi.CIRCLEPERIOD = 0;
                    wi.TIMINGPERIOD = 0;
                    if (dr.Cells["PERIODICAL"].Value.ToString().Trim() == "年" || dr.Cells["PERIODICAL"].Value.ToString().Trim() == "月" || dr.Cells["PERIODICAL"].Value.ToString().Trim() == "日")
                    {
                        try
                        {
                            wi.CIRCLEPERIOD = (int)(double.Parse(dr.Cells["PERIOD"].Value.ToString()));
                        }
                        catch
                        {
                            wi.CIRCLEPERIOD = 0;
                        }
                        wi.CIRCLEUNIT = dr.Cells["PERIODICAL"].Value.ToString();
                    }

                    try
                    {
                        wi.TIMINGPERIOD = (int)(double.Parse(dr.Cells["TIMINGPERIOD"].Value.ToString()));
                    }
                    catch
                    {
                        wi.TIMINGPERIOD = 0;
                    }

                    wi.WORKINFODETAIL = dr.Cells["ITEMCONTENT"].Value.ToString();
                    wi.PRINCIPALPOST = postid;

                    if (wi.CIRCLEPERIOD == 0 && wi.TIMINGPERIOD == 0) wi.CIRCLEORTIMING = 4;
                    else if (wi.CIRCLEPERIOD != 0 && wi.TIMINGPERIOD != 0) wi.CIRCLEORTIMING = 3;
                    else if (wi.CIRCLEPERIOD == 0) wi.CIRCLEORTIMING = 2;
                    else if (wi.TIMINGPERIOD == 0) wi.CIRCLEORTIMING = 1;
                    wi.CONFIRMPOST = confirmpostid;
                    wi.SHIP_ID = shipid;
                    if (!wi.Update(out err))
                    {
                        MessageBoxEx.Show("保存工作信息时发生错误，错误信息为：\r" + err);
                        return;
                    }
                }
            }

            MessageBoxEx.Show("添加成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
            NeedRetrieve = true;
            Close();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            FrmWorkTemplet frm = FrmWorkTemplet.Instance;
            frm.Show();
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvMain.Rows)
            {
                dr.Cells["selected"].Value = cbSelectAll.Checked;
            }
        }

    }
}