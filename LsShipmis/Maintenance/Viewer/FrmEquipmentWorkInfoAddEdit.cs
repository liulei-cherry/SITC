using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using Maintenance.DataObject;

namespace Maintenance.Viewer
{
    public partial class FrmEquipmentWorkInfoAddEdit : CommonViewer.BaseForm.FormBase
    {
        private ComponentUnit componentUnit = null;
        public ComponentUnit ComponentUnit
        {
            get { return componentUnit; }
            set { componentUnit = value;
            ucWorkInfo.Component_unit = componentUnit;
            }
        }

        private Maintenance.DataObject.WorkInfo workInfo;
        /// <summary>
        /// 属性赋值.
        /// </summary>
        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get { return workInfo; }
            set
            {
                if (null == value)
                {
                    workInfo = null;

                    ucWorkInfo.WorkInfo = value;
                    return;
                }

                workInfo = value;
                ucWorkInfo.WorkInfo = workInfo;
                ucWorkInfo.Component_unit = componentUnit;
            }
        }

        public FrmEquipmentWorkInfoAddEdit()
        {
            InitializeComponent();

            this.CancelButton = btnClose;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err;

            if (ucWorkInfo.saveWk(out err))
            {
                this.Close();
            }

        }

        private void FrmEquipmentWorkInfoAddEdit_Load(object sender, EventArgs e)
        {
            ucWorkInfo.setControlsDisable(false);
            ucWorkInfo.WorkInfo = workInfo;
            this.Text = "";
        }
    }
}