using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonViewer.BaseForm
{
    public partial class FrmDisagree : CommonViewer.BaseForm.FormBase
    {
        private bool accept = false;
        public bool Accept
        {
            get
            {
                return accept;
            }
        }
        public string Reason
        {
            get
            {
                return textBox1.Text;
            }
        }
        public FrmDisagree()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 意见录入统一窗体.
        /// </summary>
        /// <param name="frmName">窗体名称,可空</param>
        /// <param name="defaultvalue">默认字符，可空</param>
        /// <param name="detailMessage">描述性文字，可空</param>
        public FrmDisagree(string frmName,string defaultvalue,string detailMessage)
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(frmName)) this.Text = frmName;
            if (!string.IsNullOrEmpty(defaultvalue)) textBox1.Text = defaultvalue;
            if (!string.IsNullOrEmpty(detailMessage)) textBox2.Text = detailMessage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            accept = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accept = false;
            this.Close();
        }
    }
}