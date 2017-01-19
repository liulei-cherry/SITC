using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance.Services;
using Maintenance.DataObject;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmWorkTemplet : CommonViewer.BaseForm.FormBase
    {
        #region
        private static FrmWorkTemplet instance;
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWorkTemplet Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWorkTemplet.instance = new FrmWorkTemplet();
                }
                return FrmWorkTemplet.instance;
            }
        }
        #endregion

        #region 窗体对象

        T_WORKINFO_TEMPLATE_CLASS templateClass;
        TreeNode nowNode;

        #endregion

        private FrmWorkTemplet()
        {
            InitializeComponent();
        }

        private void FrmSelectWorkTemplate_Load(object sender, EventArgs e)
        {
            reloadData();//加载分类树.
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

        private void setDataGridView()
        {
            dgvMain.LoadGridView("FrmWorkTemplet.dgvMain");
            dgvMain.Columns["WORKINFO_TEMPLET_ID"].Visible = false;
            dgvMain.Columns["PERIODICAL"].Visible = false;
            dgvMain.Columns["CLASS_ID"].Visible = false;
            dgvMain.Columns["COMPONENTREFERENCE"].Visible = false;
            dgvMain.Columns["ITEMNAME"].HeaderText = "保养项目";
            dgvMain.Columns["ITEMCONTENT"].HeaderText = "保养内容";
            dgvMain.Columns["PERIOD"].HeaderText = "预检周期";
            dgvMain.Columns["PERIODICAL"].HeaderText = "单位";
            dgvMain.Columns["PERIODICALDIsplay"].HeaderText = "单位";
            dgvMain.Columns["TIMINGPERIOD"].HeaderText = "预检周期（定时）";
            dgvMain.Columns["REMARK"].HeaderText = "备注";

            DataTable dt = new DataTable();
            dt.Columns.Add("PERIODICAL_NAME");
            dt.Rows.Add("年");
            dt.Rows.Add("月");
            dt.Rows.Add("日");

            ComboBox cmbox = new ComboBox();
            cmbox.DataSource = dt;
            cmbox.DisplayMember = "PERIODICAL_NAME";
            cmbox.ValueMember = "PERIODICAL_NAME";
            cmbox.Visible = false;
            DgvBindDrop dgvBindDrop = new DgvBindDrop();
            dgvBindDrop.bindDropToDgv(dgvMain, cmbox, 6, false, 1);

            dgvMain.Columns["PERIODICALDIsplay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";
            IDBOperation dbo = InterfaceInstantiation.NewADBOperation();
            if (dgvMain.HasEmptyVal("ITEMNAME") || dgvMain.HasEmptyVal("ITEMCONTENT"))
            {
                MessageBoxEx.Show("保养项目和保养内容列不允许为空!");
                return;
            }
            DataTable dtb = (DataTable)dgvMain.DataSource;
            if (dbo.SaveFormData(dtb, "T_WORKINFO_TEMPLET", 0, out err))
            {
                MessageBoxEx.Show("保存成功!");
            }
            else
            {
                MessageBoxEx.Show("保存失败,错误原因请参考:\r" + err);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (templateClass != null)
            {
                DataTable dt = (DataTable)dgvMain.DataSource;
                dt.Rows.InsertAt(dt.NewRow(), 0);
                dt.Rows[0]["WORKINFO_TEMPLET_ID"] = Guid.NewGuid().ToString();
                dt.Rows[0]["CLASS_ID"] = templateClass.GetId();
            }
            else
            {
                MessageBoxEx.Show("请先选择一个模板分类!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Cells["WORKINFO_TEMPLET_ID"].Value != null)
            {
                if (MessageBoxEx.Show("请确认您要删除此信息？！", "警告", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                if (T_WORKINFO_TEMPLETService.Instance.deleteUnit(dgvMain.CurrentRow.Cells["WORKINFO_TEMPLET_ID"].Value.ToString(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //删除后刷新列表.
                treenodeClick(nowNode);

            }
        }

        private void FrmWorkTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvMain.SaveGridView("FrmWorkTemplet.dgvMain");
        }

        /// <summary>
        /// tree节点选取事件.
        /// </summary>
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
                string classID = "";
                if (!"root".Equals(tn.Tag))
                {
                    templateClass = (T_WORKINFO_TEMPLATE_CLASS)nowNode.Tag;
                    classID = templateClass.GetId();
                }
                else
                {
                    templateClass = null;
                }

                //加载模板列表.
                string err;
                DataTable dt = T_WORKINFO_TEMPLETService.Instance.getInfoByClass(classID, out err);
                dgvMain.DataSource = dt;
                setDataGridView();

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

    }
}