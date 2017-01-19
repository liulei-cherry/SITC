using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;

namespace ItemsManage.Viewer
{
    public partial class UcSpareInWhich : UserControl
    {
        bool isWrong = false;
        private SpareInfo theSpareInfo;
        public UcSpareInWhich()
        {
            InitializeComponent();
        }
        public delegate string setSpareId();
        string spareId;
        public setSpareId SetSpareId;
        /// <summary>
        /// 添加根结点.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void addRootNode(string id)
        {
            treeView1.Nodes.Clear();
            string err;
            DataTable dt;
            if (!SpareInfoService.Instance.GetSpareBandingComponentType(id, out dt, out err))
            {
                isWrong = false;
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode nodeType = new TreeNode();
                nodeType.Text = dr["COMPTYPE_CHINESE_NAME"].ToString() +
                    (dr["COMPONENT_STYLE"] != null ? "(" + dr["COMPONENT_STYLE"].ToString() + ")" : "") +
                    (dr["MANUFACTURER"] != null ? "(" + dr["MANUFACTURER"].ToString() + ")" : "");
                nodeType.Tag = 2;
                nodeType.ImageKey = "设备型号";
                nodeType.SelectedImageKey = "selected";
                string typeId = dr["COMPONENT_TYPE_ID"].ToString();
                nodeType.Name = typeId;
                insertAllUnit(nodeType, typeId);
                if (nodeType.Nodes.Count > 0)
                    treeView1.Nodes.Add(nodeType);
            }
            treeView1.ExpandAll();
        }

        private void insertAllUnit(TreeNode nodeType, string typeId)
        {
            if (isWrong) return;

            Dictionary<string, string> dicAllUnit = ComponentTypeService.Instance.GetOneCompTypeAllComponent(typeId);
            if (dicAllUnit == null || dicAllUnit.Count == 0) return;

            foreach (string unitId in dicAllUnit.Keys)
            {
                TreeNode nodeUnit = new TreeNode();
                nodeUnit.Text = dicAllUnit[unitId];
                nodeUnit.Tag = 3;
                nodeUnit.ImageKey = "设备";
                nodeUnit.SelectedImageKey = "selected";
                nodeUnit.Name = unitId;
                nodeType.Nodes.Add(nodeUnit);
            }
        }

        public void ClearView()
        {
            treeView1.Nodes.Clear();
            spareId = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SetSpareId == null) return;
            spareId = SetSpareId();
            if (theSpareInfo == null || theSpareInfo.IsWrong || !theSpareInfo.GetId().Equals(spareId))
            {
                treeView1.Nodes.Clear();
                theSpareInfo = (SpareInfo)SpareInfoService.Instance.GetOneObjectById(spareId);
                if (theSpareInfo == null || theSpareInfo.IsWrong) isWrong = true;
                addRootNode(theSpareInfo.GetId());
            }
            else if (treeView1.Nodes.Count == 0 && theSpareInfo != null)
            {
                addRootNode(theSpareInfo.GetId());
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.ToString() == "3")
            {
                FrmComponentManage.Instance.Show();
                FrmComponentManage.Instance.WindowState = FormWindowState.Maximized;
                FrmComponentManage.Instance.SwitchToEquipment(e.Node.Name);
            }
        }
    }
}
