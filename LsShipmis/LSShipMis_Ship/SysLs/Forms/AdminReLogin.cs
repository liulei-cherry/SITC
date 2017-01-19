using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LSShipMis_Ship.SysLs.Forms
{
    public partial class AdminReLogin : CommonViewer.BaseForm.FormBase
    {
        public string Password="";
        public AdminReLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Password = this.textBox1.Text;
            this.Close();
        }
    }
}