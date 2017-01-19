using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.MultiLanguage;
namespace CommonViewer.BaseForm
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_Shown(object sender, EventArgs e)
        {
            if(CommonOperation.ConstParameter.MultilanguageVersion)translate();
        }
        public void translate()
        {
            MultiLanguageTranslate multiLanguageTranslate = MultiLanguageTranslate.Instance;
            multiLanguageTranslate.Translate(this);
        }
    }
}