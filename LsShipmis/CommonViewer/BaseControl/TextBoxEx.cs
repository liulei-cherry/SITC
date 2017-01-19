using System;
using System.Collections.Generic;
using System.Text;

namespace CommonViewer
{
    public class TextBoxEx : System.Windows.Forms.TextBox
    {
        protected override void  OnTextChanged(EventArgs e)
        {
            string str = this.Text;
            int lent = System.Text.ASCIIEncoding.Default.GetByteCount(str);
            int max = this.MaxLength;
            byte[] bb = System.Text.ASCIIEncoding.Default.GetBytes(str);//得到输入的字符串的数组.
            if (lent > max)
            {
                this.Text = System.Text.ASCIIEncoding.Default.GetString(bb, 0, max);//将截断后的字节数组转换成字符串.
                this.SelectionStart = max;//将光标放置在输入文字的最后.
            } 
            base.OnTextChanged(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            this.Text = this.Text.Trim();
            base.OnLostFocus(e);
        }
    }
}
