using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CommonViewer.MultiLanguage;

namespace CommonViewer.BaseControl
{
    public class FolderBrowserDialogEx
    {

        private FolderBrowserDialogEx()
        {
            //仅提供private构造.
        }

        public static DialogResult ShowDialog(FolderBrowserDialog thefoleBD)
        {
            thefoleBD.Description = MultiLanguageDictionary.Instance.Translate(thefoleBD.Description);
            return thefoleBD.ShowDialog();
        }
    }
}
