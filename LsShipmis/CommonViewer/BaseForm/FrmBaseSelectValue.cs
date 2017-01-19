using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonViewer
{
    public partial class FrmBaseSelectValue : CommonViewer.BaseForm.FormBase
    {
        private string formType;
        private bool valueUseful = true;
        public bool ValueUseful
        {
            get { return valueUseful; }
            set { valueUseful = value; }
        }
        protected string selectedValue;
        protected bool loaded = false;

        public delegate void CloseForm();
        public delegate DataTable DgGetNewDataTable();
        public delegate void DgInit(DataTable dt,string valueColumn,string valueSelect);
        public delegate string DgGetSelectedValue();

        public CloseForm closeForm;
        public DgInit Init;
        public DgGetNewDataTable GetNewDataTable;
        public DgGetSelectedValue GetSelectedValue;

        public FrmBaseSelectValue()
        {
            InitializeComponent();
        }
        public FrmBaseSelectValue(string InstanceName)
        {
            formType = InstanceName;
            InitializeComponent();
        }

        private void FrmBaseSelectValue_Load(object sender, EventArgs e)
        {
            if (loaded && (Init == null || GetNewDataTable == null))
            {
                throw new Exception("设计态问题,存在继承于FrmBaseSelectValue,却不实现其委托的窗体!");
            }
        }
        private void FrmBaseSelectValue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeForm != null)
            {
                closeForm();
            }
            //这个地方不允许被重载,如果要在close里写代码,必须在上面的委托closeForm中进行操作!
            if (instance.ContainsValue(this))
            {
                try
                {
                    instance.Remove(formType);
                }
                catch
                { 
                }
            }
        }
        private static Dictionary<string, FrmBaseSelectValue> instance = new Dictionary<string, FrmBaseSelectValue>();
        public static FrmBaseSelectValue GetInstance(string InstanceName)
        {
            if (!instance.ContainsKey(InstanceName))
            {
                instance.Add(InstanceName, new FrmBaseSelectValue(InstanceName));
            }            
            return instance[InstanceName];
        }

    }
}