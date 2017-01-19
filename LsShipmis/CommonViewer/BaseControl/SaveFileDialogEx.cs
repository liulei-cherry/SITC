using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CommonViewer.MultiLanguage;

namespace CommonViewer.BaseControl
{
    public class SaveFileDialogEx
    {
        private SaveFileDialogEx()
        {
            //仅提供private构造.
        }
        public static DialogResult ShowDialog(SaveFileDialog theSaveFileDialog)
        {
            theSaveFileDialog.FileName = MultiLanguageDictionary.Instance.Translate(theSaveFileDialog.FileName);
            theSaveFileDialog.Filter = MultiLanguageDictionary.Instance.Translate(theSaveFileDialog.Filter);
            theSaveFileDialog.Title = MultiLanguageDictionary.Instance.Translate(theSaveFileDialog.Title);
            return theSaveFileDialog.ShowDialog();
        }
    }
}
