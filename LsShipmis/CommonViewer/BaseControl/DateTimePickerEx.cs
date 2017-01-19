using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CommonViewer.BaseControl;

namespace CommonViewer
{
    public partial class DateTimePickerEx : UserControl
    {
        public DateTimePickerEx()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设定或返回的日期值.
        /// </summary>
        private DateTime value;
        /// <summary>
        /// 设定或返回的日期字符串.
        /// </summary>
        private string text;

        /// <summary>
        /// 系统可以接受的最小日期.
        /// </summary>
        private DateTime mimValue = DateTimePicker.MinimumDateTime;

        public bool ReadOnly
        {
            get
            {
                return textBox.ReadOnly;
            }
            set
            {
                textBox.ReadOnly = value;
            }
        }

        public DateTime MimValue
        {
            get { return mimValue; }
            set { mimValue = value; }
        }
        /// <summary>
        /// 系统可以接受的最大日期.
        /// </summary>
        private DateTime maxValue = DateTimePicker.MaximumDateTime;

        public DateTime MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        /// <summary>
        /// 用于界面绑定文本框使用，李景育添加.
        /// </summary>
        public TextBoxEx TextBox
        {
            get { return textBox; }
            set { textBox = value; }
        }

        /// <summary>
        /// 返回的日期字符串.
        /// </summary>
        public override string Text
        {
            get { return value.ToString(); }
            set
            {
                if (IsDate(value))
                {
                    this.value = Convert.ToDateTime(value);
                    text = value;
                    textBox.Text = value;
                }
                else
                {
                    this.value = Convert.ToDateTime(null);
                    textBox.Text = null;
                }
            }
        }

        /// <summary>
        /// 返回的日期型值.
        /// </summary>
        public DateTime Value
        {
            get 
            {
                if (!IsDate(textBox.Text))
                {
                    return Convert.ToDateTime(null);
                }
                return this.value;
            }
            set
            {
                if (IsDate(value.ToString()))
                {
                    this.value = value;
                    textBox.Text = value.ToString(dateTimePicker.CustomFormat);
                }
                else
                {
                    this.value = Convert.ToDateTime(null);
                    textBox.Text = null;
                }
            }
        }

        [DllImport("user32.dll")]
        static extern long SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        const int WM_SYSKEYDOWN = 0x0104, VK_DOWN = 0x28;

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Enabled && !this.ReadOnly)
                clickPicker();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (this.Enabled && !this.ReadOnly)
                clickPicker();
            textBox.Focus();
            textBox.SelectAll();
        }

        private void clickPicker()
        {
            if (value != null && IsDate(value.ToString()))
            {
                try
                {
                    dateTimePicker.Value = Convert.ToDateTime(value.ToLongDateString());
                    Text = value.ToString(dateTimePicker.CustomFormat);
                }
                catch
                { }
            }
            SendMessage(dateTimePicker.Handle, WM_SYSKEYDOWN, VK_DOWN, 0);
        }

        /// <summary>
        /// 校验是否为日期.
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        private bool IsDate(string strDate)
        {
            DateTime dtDate;
            bool bValid = true;
            if (strDate == null) return false;
            try
            {
                dtDate = DateTime.Parse(strDate);
                if (dtDate <= mimValue || dtDate >= maxValue) bValid = false;
            }
            catch (FormatException)
            {
                // 如果解析方法失败则表示不是日期性数据.
                bValid = false;
            }
            return bValid;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text != null && textBox.Text.Length > 0)
            {
                if (!IsDate(textBox.Text))
                {
                    MessageBoxEx.Show("输入必须为正确的年月日，格式为YYYY-MM-DD！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Focus();
                }
                else
                {
                    text = textBox.Text;
                    value = Convert.ToDateTime(text);
                }
            }

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            textBox.Text = dateTimePicker.Text;
            text = textBox.Text;
            value = Convert.ToDateTime(text);
            if (_ValueChanged != null)
                _ValueChanged(sender, e);
        }

        public delegate void ValueChanged(object sender, EventArgs e);
        public event ValueChanged _ValueChanged;

        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            textBox.Focus();
            textBox.SelectAll();

        }
        private bool isBackKey = false;
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (isBackKey)
            {
                if (textBox.Text.Length == 4 || textBox.Text.Length == 7)
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Trim().Length;
                this.Text = textBox.Text.Trim();
                return;
            }
            //if (textBox.Text.Length == 7 && Convert.ToInt32(textBox.Text.Substring(5, 2)) > 12)
            //{
            //    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            //    textBox.SelectionStart = textBox.Text.Trim().Length;
            //    return;
            //}
            //if (textBox.Text.Length == 10)
            //{
            //    DateTime dt = new DateTime(Convert.ToInt32(textBox.Text.Substring(0, 4))
            //    , (Convert.ToInt32(textBox.Text.Substring(5, 2))), 1);
            //    if (dt.AddMonths(1).AddDays(-1).Day < Convert.ToInt32(textBox.Text.Substring(8, 2)))
            //    {
            //        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            //        textBox.SelectionStart = textBox.Text.Trim().Length;
            //        return;
            //    }
            //}
            if (textBox.Text.Trim().Length == 4)
            {
                textBox.Text += "-";
            }
            if (textBox.Text.Trim().Length == 7)
            {
                textBox.Text += "-";
            }
            textBox.SelectionStart = textBox.Text.Trim().Length;
            this.Text = textBox.Text.Trim();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            isBackKey = false;
            e.Handled = true;
            if (e.KeyChar == (char)0x08)
            {
                e.Handled = false;
                isBackKey = true;
                return;
            }
            if (textBox.Text.Trim().Length >= 10 && textBox.SelectionLength != 10)
            {
                return;
            }
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
                //if (textBox.Text.Trim().Length == 5 && e.KeyChar > '1')//月份第一位不能大于1
                //{
                //    e.Handled = true;
                //}
                //if (textBox.Text.Trim().Length == 8 && e.KeyChar > '3')//日第一位不能大于3
                //{
                //    e.Handled = true;
                //}
            }

        }
    }
}
