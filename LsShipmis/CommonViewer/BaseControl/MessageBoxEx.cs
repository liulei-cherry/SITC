using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CommonViewer.MultiLanguage;

namespace CommonViewer.BaseControl
{
    public class MessageBoxEx
    {

        private MessageBoxEx()
        {
            //仅提供private构造.
        }

        public static DialogResult Show(string text)
        {
            string showText = text;
            if (CommonOperation.ConstParameter.MultilanguageVersion)
            {
                showText = MultiLanguageDictionary.Instance.Translate(text);
            }
            DialogResult theResult = MessageBox.Show(showText);
            return theResult;
        }
        public static DialogResult Show(string text, string caption)
        {
            string showText = text;
            string showCaption = caption;
            if (CommonOperation.ConstParameter.MultilanguageVersion)
            {
                showText = MultiLanguageDictionary.Instance.Translate(text);
                showCaption = MultiLanguageDictionary.Instance.Translate(caption);
            }
            DialogResult theResult = MessageBox.Show(showText, showCaption);
            return theResult;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            string showText = text;
            string showCaption = caption;
            if (CommonOperation.ConstParameter.MultilanguageVersion)
            {
                showText = MultiLanguageDictionary.Instance.Translate(text);
                showCaption = MultiLanguageDictionary.Instance.Translate(caption);
            }
            DialogResult theResult = MessageBox.Show(showText, showCaption, buttons);
            return theResult;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            string showText = MultiLanguageDictionary.Instance.Translate(text);
            string showCaption = MultiLanguageDictionary.Instance.Translate(caption);
            DialogResult theResult = MessageBox.Show(showText, showCaption, buttons, icon, defaultButton);
            return theResult;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            string showText = text;
            string showCaption = caption;
            if (CommonOperation.ConstParameter.MultilanguageVersion)
            {
                showText = MultiLanguageDictionary.Instance.Translate(text);
                showCaption = MultiLanguageDictionary.Instance.Translate(caption);
            }
            DialogResult theResult = MessageBox.Show(showText, showCaption, buttons, icon);
            return theResult;
        }
    }
}
