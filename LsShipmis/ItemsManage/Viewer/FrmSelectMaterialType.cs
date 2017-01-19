using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    public partial class FrmSelectMaterialType : FormBase
    {
        public MaterialType SelectediMaterialType { get; set; }
        public FrmSelectMaterialType()
        {
            InitializeComponent();
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            if (ucMaterialTypeTree1.SelectedNode != null && ucMaterialTypeTree1.SelectedNode.Tag != null
                && ucMaterialTypeTree1.SelectedNode.Tag.GetType() == typeof(MaterialType))
            {
                SelectediMaterialType = (MaterialType)ucMaterialTypeTree1.SelectedNode.Tag;
                this.Close();
                return;
            }
            SelectediMaterialType = null;
            MessageBoxEx.Show("未选择有效备件分类,请重新进行操作,或关闭窗体!");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSelectMaterialType_Load(object sender, EventArgs e)
        {
            ucMaterialTypeTree1.ReloadingAllData();
        }
    }
}
