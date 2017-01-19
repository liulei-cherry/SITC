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
    public partial class FrmBusyWithStep : Form
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmBusyWithStep instance;
        public static FrmBusyWithStep Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new FrmBusyWithStep();
                }
                return FrmBusyWithStep.instance;
            }
        }
        #endregion

        public delegate void FinishedOpeartion();
        FinishedOpeartion finishOperation;
        private FrmBusyWithStep()
        {
            InitializeComponent();
        }

        public FrmBusyWithStep(FinishedOpeartion f)
        {
            InitializeComponent();
            finishOperation = f;
        }

        public FrmBusyWithStep(string whyBusy, FinishedOpeartion f)
        {
            InitializeComponent();
            textBox1.Text = whyBusy;
            finishOperation = f;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        public void ChangeStep(string step, double percent)
        {            
            textBox2.Text = step;
            int iPercent = (percent<0?0:(percent>100?100:(int)percent));
            progressBar1.Value = iPercent;
            Application.DoEvents();
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
