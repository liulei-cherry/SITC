using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CommonViewer.BaseForm
{
    public partial class FrmBusy : Form
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmBusy instance;
        public static FrmBusy Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new FrmBusy();
                }
                return FrmBusy.instance;
            }
        }
        #endregion

        public delegate void FinishedOpeartion();
        FinishedOpeartion finishOperation;
        private FrmBusy()
        {
            InitializeComponent();
        }

        public FrmBusy(FinishedOpeartion f)
        {
            InitializeComponent();
            pictureBox1.Location = new Point(12, 50);
            finishOperation = f;
        }

        public FrmBusy(string whyBusy, FinishedOpeartion f)
        {
            InitializeComponent();
            textBox1.Text = whyBusy;
            finishOperation = f;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ChangeString(string toChange)
        {
            textBox1.Text = toChange;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (finishOperation != null)
            {
                try
                {
                    finishOperation();
                }
                catch
                {
                    this.Close();
                }
            }
            this.Close();           
        }
       
        private void FrmBusy_Load(object sender, EventArgs e)
        {
            timer1.Start();
        } 
    }
}
