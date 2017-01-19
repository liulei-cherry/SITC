/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmInputBox.cs
 * 创 建 人：李景育 * 创建时间：2007-12-20
 * 标    题：快速搜索对话框窗体
 * 功能描述：实现快速搜索对话框窗体上的相关功能
 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl; 

namespace CommonViewer
{
    /// <summary>
    /// 快速搜索对话框窗体.
    /// </summary>
    public partial class FrmInputBox : CommonViewer.BaseForm.FormBase
    {
        private TreeView treeView = null;           //接收传过来的树控件.
        private ListBox listBox = null;             //接收传过来的特殊备件列表控件.
        private BindingSource bindingSource = null; //接收传过来的BindingSource组件.
        private DataGridView dgv = null;            //接收传过来的DataGridView控件.
        private string colName = "";                //接收传过来的要搜索的字段名.
        Dictionary<string, string> dictCol = null;  //接收传过来的要搜索的字段名集合.
        private bool isCloseFrm = false;            //搜索完毕后，是否关闭搜索对话框.
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 接收树控件的构造函数.
        /// </summary>
        /// <param name="treeView">TreeView树控件，要在树控件上搜索</param>
        /// <param name="isCloseFrm">搜索完毕后是否关闭搜索对话框</param>
        public FrmInputBox(TreeView treeView, bool isCloseFrm)
        {
            InitializeComponent();
            this.treeView = treeView;
            this.isCloseFrm = isCloseFrm;
        }

        /// <summary>
        /// 接收列表控件的构造函数.
        /// </summary>
        /// <param name="listBox">ListBox列表控件，要在控件上搜索</param>
        /// <param name="isCloseFrm">搜索完毕后是否关闭搜索对话框</param>
        public FrmInputBox(ListBox listBox, bool isCloseFrm)
        {
            InitializeComponent();
            this.listBox = listBox;
            this.isCloseFrm = isCloseFrm;
        }

        /// <summary>
        /// 接BindingSource组件、DataGridView控件和要搜索的DataGridView的列名的构造函数.
        /// </summary>
        /// <param name="bindingSource">bindingSource组件</param>
        /// <param name="dgv">DataGridView组件，要在它上搜索</param>
        /// <param name="colName">要搜索的DataGridView的列名</param>
        /// <param name="isCloseFrm">搜索完毕后是否关闭搜索对话框</param>
        public FrmInputBox(BindingSource bindingSource, 
                            DataGridView dgv, string colName, bool isCloseFrm)
        {
            InitializeComponent();
            this.bindingSource = bindingSource;
            this.dgv = dgv;
            this.colName = colName;
            this.isCloseFrm = isCloseFrm;
        }

        /// <summary>
        /// 接BindingSource组件、DataGridView控件和要搜索的DataGridView的列名的构造函数.
        /// </summary>
        /// <param name="bindingSource">bindingSource组件</param>
        /// <param name="dgv">DataGridView组件，要在它上搜索</param>
        /// <param name="dictCol">要搜索的DataGridView的列名的集合</param>
        /// <param name="isCloseFrm">搜索完毕后是否关闭搜索对话框</param>
        public FrmInputBox(BindingSource bindingSource, DataGridView dgv, 
                            Dictionary<string,string> dictCol, bool isCloseFrm)
        {
            InitializeComponent();
            this.bindingSource = bindingSource;
            this.dgv = dgv;
            this.dictCol = dictCol;
            this.isCloseFrm = isCloseFrm;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInputBox_Load(object sender, EventArgs e)
        {
            //如果列表集合dictCol不为空，则给检索字段下拉列表框.
            //cboSearchFld赋数据源。.
            if (dictCol != null && dictCol.Count > 0)
            {
                DataTable dtb = new DataTable();
                dtb.Columns.Add("value", typeof(string));
                dtb.Columns.Add("disname", typeof(string));
                foreach (string key in dictCol.Keys)
                {
                    DataRow dataRow = dtb.NewRow();
                    dataRow["value"] = key;
                    dataRow["disname"] = dictCol[key];
                    dtb.Rows.Add(dataRow);
                }

                cboSearchFld.DisplayMember = "disname";
                cboSearchFld.ValueMember = "value";
                cboSearchFld.DataSource = dtb;

                lblSearchFld.Visible = true;
                cboSearchFld.Visible = true;
            }
        }
        /// <summary>
        /// 在指定的树控件（treeView）上，从当前节点（curNode）出发，逐级搜索要搜索的内容（sContent）.
        /// </summary>
        /// <param name="treeView">树控件</param>
        /// <param name="curNode">树控件上的当前节点</param>
        /// <param name="sContent">要搜索的内容</param>
        /// <param name="bln">
        /// 如果开始搜索时curNode的内容就已经等于sContent，这时无法前进，.
        /// 所以在调用时要传一个false值.
        /// </param>
        /// <param name="mark">0表示按节点的文本搜索，1表示按节点的tag值搜索</param>
        public void TreeSearch(TreeView treeView, TreeNode curNode, string sContent, bool bln, int mark)
        {
          
            if (curNode == null) return;
            treeView.SelectedNode = curNode;//把焦点移到当前节点上.

            if (mark == 0) //按节点的文本搜索.
            {
                if (bln == true && curNode.Text.IndexOf(sContent) != -1)
                {
                    //如果找到了则退出.
                    return;
                }
            }
            //按节点的tag值搜索.
            else
            {
                if (bln == true && curNode.Tag.ToString().Equals(sContent))
                {
                    //如果找到了则退出.
                    return;
                }
            }
            //下级节点搜索.
            if (curNode.Nodes.Count > 0)
            {
                TreeSearch(treeView, curNode.Nodes[0], sContent, true, mark);
            }
            //同级节点搜索.
            else if (curNode.NextNode != null)
            {
                TreeSearch(treeView, curNode.NextNode, sContent, true, mark);
            }
            //上级节点搜索.
            else
            {
                TreeNode thisnode = curNode;
                while (thisnode.Parent != null)
                {
                    thisnode = thisnode.Parent;
                    if (thisnode.NextNode != null)
                    {
                        TreeSearch(treeView, thisnode.NextNode, sContent, true, mark);
                        return;
                    }
                }
                if (mark == 0) //按节点的文本搜索.
                {
                    if (thisnode.Parent == null && thisnode.Text.IndexOf(sContent) == -1)
                    {
                        MessageBoxEx.Show("已搜索到结尾，未找到符合条件的内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //按节点的tag值搜索.
                else
                {
                    if (thisnode.Parent == null && thisnode.Tag.ToString().Equals(sContent))
                    {
                        MessageBoxEx.Show("已搜索到结尾，未找到符合条件的内容");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 设置搜索内容.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtInputBox.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入要搜索的内容！", "提示");
            }
            else
            {
                btnCancel.Enabled = false;//搜索前关闭按钮不可用.

                //如果是在TreeView树控件上搜索.
                if (treeView != null)
                {
                    TreeNode curNode = treeView.SelectedNode;
                    TreeSearch(treeView, curNode, txtInputBox.Text, false, 0);
                }
                //如果是在ListBox上搜索.
                else if (listBox != null)
                {
                    listBox.Text = txtInputBox.Text;
                }
                //如果是在DataGridView网格中搜索.
                else if (dgv != null)
                {
                    this.searchInDgv();
                }

                btnCancel.Enabled = true;//搜索后恢复关闭按钮的可用状态.
                //根据会传过来的isCloseFrm变量来确定是否关闭搜索对话框.
                if (isCloseFrm)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 在DataGridView网格中搜索.
        /// </summary>
        private void searchInDgv()
        {
            string searchName = ""; //要查询的字段名.

            int iRowCout = 0;
            string searchContent = txtInputBox.Text.Trim();//要搜索的内容.
            dgv.Select();
            if (dgv.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可搜索的内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //如果当前是由用户选择字段进行查询（dictCol != null && dictCol.Count > 0的情况下），.
            //那么检查dictCol中包含的字段在dgv中是否存在。.
            if (dictCol != null && dictCol.Count > 0)
            {
                foreach (string key in dictCol.Keys)
                {
                    if (dgv.Columns.Contains(key.ToLower()) == false)
                    {
                        MessageBoxEx.Show("字段名“" + key + "”在网格中不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                searchName = cboSearchFld.SelectedValue.ToString();
            }
            else
            {
                searchName = colName;
            }

            iRowCout = dgv.CurrentRow.Index;    //DataGridView当前行数.
            while (iRowCout <= dgv.Rows.Count)  //循环每一行，判断每一行是否存在符合条件的值.
            {
                bindingSource.Position = iRowCout + 1;//定位到当前行的下一行.
                string curContent = dgv.CurrentRow.Cells[searchName].Value.ToString();//取当前行的要查询的列的内容.
                if (curContent.IndexOf(searchContent) != -1)//如果找到则退出循环.
                {
                    break;
                }
                //如果搜索到结尾并且结尾也不是符合条件的内容，则提示未找到.
                else if (iRowCout == dgv.Rows.Count && curContent.IndexOf(searchContent) == -1)
                {
                    MessageBoxEx.Show("已搜索到结尾，未找到符合条件的内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                iRowCout++;//增加当前行变量.
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 当在快速搜索文本框中按回车时执行btnOk功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk_Click(sender, e);
            }
        }

        /// <summary>
        /// 搜索标签文本设置（允许调用者修改搜索标签文本）.
        /// </summary>
        public Label LblSearch
        {
            get
            {
                return lblSearch;
            }
            set
            {
                lblSearch = value;
            }
        }
    }
}