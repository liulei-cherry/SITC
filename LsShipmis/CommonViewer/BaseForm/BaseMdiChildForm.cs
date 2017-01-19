using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;

namespace CommonViewer.BaseForm
{
    public partial class BaseMdiChildForm : CommonViewer.BaseForm.FormBase, IFunctionChildWindow 
    {
        private IFunctionMainWindow theMainForm;

        public IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        //string WindowsName { get;set;}
        //获取所有可以打开本窗体的权限.
        public List<Authority> GetAllAuthorityCanOpenThisWindow()
        {
            return new List<Authority>();
        }

        public bool JudgeTheAuthorityCanOpenThisWindow(Authority theAuthority)
        {
            return false;
        }
        //打开本窗体.
        //void OpenCommonWindow();

        public BaseMdiChildForm()
        {
            InitializeComponent();
        }

        private void BaseMdiChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (TheMainForm != null)
            {
                TheMainForm.ChildClosed(this);
            }
        }

        public void FormShow(IFunctionMainWindow mdiMainForm,Point location,int width,int height)
        {
            TheMainForm = mdiMainForm;
            this.MdiParent = (Form)mdiMainForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;           
            this.Visible = true;
            this.Location = location;
            this.Width = width;
            this.Height = height;
            //frm.Visible = true;
            //frm.Show();
        }
        
        private string functionName;
        public string FunctionName
        {
            get
            {
                return functionName;
            }
            set
            {
                functionName = value;
            }
        } 
    }
}