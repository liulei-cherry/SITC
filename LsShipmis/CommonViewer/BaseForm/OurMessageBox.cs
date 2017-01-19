using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonViewer.BaseForm
{
    public partial class OurMessageBox : FormBase
    {
        private bool answer = false;
        private string answerTxt = "";

        public OurMessageBox()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        public OurMessageBox(string sMessage)
        {
            InitializeComponent();
            textBox2.Text = sMessage;
            textBox1.Focus();
        }
        public OurMessageBox(string sMessage, string sTitle)
        {
            InitializeComponent();
            this.Text = sTitle;
            textBox2.Text = sMessage;
            textBox1.Focus();
        }

        public OurMessageBox(string sMessage, string sTitle, string beforeText)
        {
            InitializeComponent();
            if (beforeText.Length > 0)
            {
                textBox1.Text = beforeText;
            }
            Text = sTitle;
            textBox2.Text = sMessage;
            textBox1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            answer = true;
            answerTxt = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }
        public string AnswerTxt
        {
            get
            {
                return answerTxt;
            }
            set
            {
                answerTxt = value;
            }
        }
    }
}