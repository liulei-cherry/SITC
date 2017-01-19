using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CommonViewer.MultiLanguage;

namespace CommonViewer.BaseControl
{
    public class OpenFileDialogEx
    {
        private OpenFileDialogEx()
        {
            //仅提供private构造.
        }

        public static DialogResult ShowDialog(OpenFileDialog theOpenFileDialog)
        {
            theOpenFileDialog.FileName = MultiLanguageDictionary.Instance.Translate(theOpenFileDialog.FileName);
            theOpenFileDialog.Filter = MultiLanguageDictionary.Instance.Translate(theOpenFileDialog.Filter);
            theOpenFileDialog.Title = MultiLanguageDictionary.Instance.Translate(theOpenFileDialog.Title);
            return theOpenFileDialog.ShowDialog();
        }
    }
}
