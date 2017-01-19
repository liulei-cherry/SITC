using System;
using System.Collections.Generic;
using System.Text;
using OfficeOperation;
using System.Windows.Forms;

namespace CommonViewer.MultiLanguage
{
    /// <summary>
    /// 实现遍历所有组件,将其可视文本部分的内容全部替换成中文.
    /// </summary>
    public class MultiLanguageTranslate
    {
        /// 记录各种控件的层次结构,什么类型可以有什么样的下级内容.
        /// 下面是有下级元素的控件.
        /// System.Windows.Forms.BindingNavigator.Items -> 
        /// 1,System.Windows.Forms.ToolStripButton (Text)
        /// 2,System.Windows.Forms.ToolStripLabel (Text)
        /// 3,System.Windows.Forms.ToolStripSplitButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
        /// 4,System.Windows.Forms.ToolStripDropDownButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
        /// 
        /// System.Windows.Forms.ContextMenuStrip.Items -> System.Windows.Forms.ToolStripMenuItem
        /// System.Windows.Forms.ToolStripMenuItem.DropDownItems -> System.Windows.Forms.ToolStripMenuItem  
        ///  
        /// System.Windows.Forms.MenuStrip (Text) -> System.Windows.Forms.ToolStripMenuItem   
        #region 单实例

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MultiLanguageTranslate instance;
        public static MultiLanguageTranslate Instance
        {
            get
            {
                if (null == instance)
                {
                    MultiLanguageTranslate.instance = new MultiLanguageTranslate();
                }
                return MultiLanguageTranslate.instance;
            }
        }

        private static ToolTip toolTip = new ToolTip();
        private MultiLanguageTranslate()
        {
            //仅提供private构造.

        }
        #endregion
        #region 系统自带的控件部分

        public void Translate(System.Windows.Forms.Form form)
        {
            form.Text = MultiLanguageDictionary.Instance.Translate(form.Text);
            for (int i = 0; i < form.Controls.Count; i++)
            {
                switchObject(form.Controls[i]);
            }
        }
        public void Translate(System.Windows.Forms.Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                switchObject(panel.Controls[i]);
            }
        }
        public void Translate(System.Windows.Forms.MenuStrip menuStrip)
        {
            menuStrip.Text = MultiLanguageDictionary.Instance.Translate(menuStrip.Text);
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                switchObject(menuStrip.Items[i]);
            }
        }
        public void Translate(System.Windows.Forms.ContextMenuStrip contextMenuStrip)
        {
            contextMenuStrip.Text = MultiLanguageDictionary.Instance.Translate(contextMenuStrip.Text);
            for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            {
                //System.Windows.Forms.ContextMenuStrip.Items -> System.Windows.Forms.ToolStripMenuItem 
                switchObject(contextMenuStrip.Items[i]);
            }
        }
        public void Translate(System.Windows.Forms.ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.Text = MultiLanguageDictionary.Instance.Translate(toolStripMenuItem.Text);
            for (int i = 0; i < toolStripMenuItem.DropDownItems.Count; i++)
            {
                //System.Windows.Forms.ToolStripMenuItem.DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                switchObject(toolStripMenuItem.DropDownItems[i]);
            }
        }
        public void Translate(System.Windows.Forms.BindingNavigator bindingNavigator)
        {
            bindingNavigator.Text = MultiLanguageDictionary.Instance.Translate(bindingNavigator.Text);
            for (int i = 0; i < bindingNavigator.Items.Count; i++)
            {
                /// System.Windows.Forms.BindingNavigator.Items -> 
                /// 1,System.Windows.Forms.ToolStripButton (Text)
                /// 2,System.Windows.Forms.ToolStripLabel (Text)
                /// 3,System.Windows.Forms.ToolStripSplitButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                /// 4,System.Windows.Forms.ToolStripDropDownButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                switchObject(bindingNavigator.Items[i]);
            }
        }
        public void Translate(System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton)
        {
            toolStripDropDownButton.Text = MultiLanguageDictionary.Instance.Translate(toolStripDropDownButton.Text);

            for (int i = 0; i < toolStripDropDownButton.DropDownItems.Count; i++)
            {
                /// 4,System.Windows.Forms.ToolStripDropDownButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                switchObject(toolStripDropDownButton.DropDownItems[i]);
            }
        }
        public void Translate(System.Windows.Forms.ToolStripSplitButton toolStripSplitButton)
        {
            toolStripSplitButton.Text = MultiLanguageDictionary.Instance.Translate(toolStripSplitButton.Text);
            for (int i = 0; i < toolStripSplitButton.DropDownItems.Count; i++)
            {
                /// 3,System.Windows.Forms.ToolStripSplitButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                switchObject(toolStripSplitButton.DropDownItems[i]);
            }
        }
        public void Translate(System.Windows.Forms.TabControl tabControl)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                /// 3,System.Windows.Forms.ToolStripSplitButton (Text) DropDownItems -> System.Windows.Forms.ToolStripMenuItem
                switchObject(tabControl.TabPages[i]);
            }
        }
        public void Translate(System.Windows.Forms.DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = MultiLanguageDictionary.Instance.Translate(dataGridView.Columns[i].HeaderText);
            }
        }

        public void Translate(System.Windows.Forms.GroupBox groupBox)
        {
            groupBox.Text = MultiLanguageDictionary.Instance.Translate(groupBox.Text);
            for (int i = 0; i < groupBox.Controls.Count; i++)
            {
                switchObject(groupBox.Controls[i]);
            }
        }
        public void Translate(System.Windows.Forms.TabPage tabPage)
        {
            tabPage.Text = MultiLanguageDictionary.Instance.Translate(tabPage.Text);
            for (int i = 0; i < tabPage.Controls.Count; i++)
            {
                switchObject(tabPage.Controls[i]);
            }
        }

        public void Translate(System.Windows.Forms.SplitContainer splitContainer)
        {
            for (int i = 0; i < splitContainer.Controls.Count; i++)
            {
                switchObject(splitContainer.Controls[i]);
            }
        }

        public void Translate(System.Windows.Forms.SplitterPanel splitterPanel)
        {
            for (int i = 0; i < splitterPanel.Controls.Count; i++)
            {
                switchObject(splitterPanel.Controls[i]);

            }
        }

        public void Translate(System.Windows.Forms.TableLayoutPanel tableLayoutPanel)
        {
            for (int i = 0; i < tableLayoutPanel.Controls.Count; i++)
            {
                switchObject(tableLayoutPanel.Controls[i]);

            }
        }

        public void Translate(System.Windows.Forms.ListView listView)
        {
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].Text = MultiLanguageDictionary.Instance.Translate(listView.Columns[i].Text);
            }
            if (listView.ContextMenuStrip != null)
            {
                for (int i = 0; i < listView.ContextMenuStrip.Items.Count; i++)
                {
                    listView.ContextMenuStrip.Items[i].Text = MultiLanguageDictionary.Instance.Translate(listView.ContextMenuStrip.Items[i].Text);
                }
            }
        }

        public void Translate(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.ContextMenuStrip != null)
            {
                for (int i = 0; i < treeView.ContextMenuStrip.Items.Count; i++)
                {
                    treeView.ContextMenuStrip.Items[i].Text = MultiLanguageDictionary.Instance.Translate(treeView.ContextMenuStrip.Items[i].Text);
                }
            }
        }

        public void Translate(System.Windows.Forms.StatusStrip statusStrip)
        {
            if (statusStrip != null)
            {
                for (int i = 0; i < statusStrip.Items.Count; i++)
                {
                    switchObject(statusStrip.Items[i]);
                }
            }
        }
        public void Translate(System.Windows.Forms.FlowLayoutPanel flowLayoutPanel)
        {
            if (flowLayoutPanel != null)
            {
                for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
                {
                    switchObject(flowLayoutPanel.Controls[i]);
                }
            }
        }

        //-------------------下面是独立控件,没有下级控件的可视控件---------------------------------------//

        public void Translate(System.Windows.Forms.ToolStripButton toolStripButton)
        {
            toolStripButton.Text = MultiLanguageDictionary.Instance.Translate(toolStripButton.Text);
        }
        public void Translate(System.Windows.Forms.LinkLabel linkLabel)
        {
            linkLabel.Text = MultiLanguageDictionary.Instance.Translate(linkLabel.Text);
        }
        public void Translate(System.Windows.Forms.ToolStripLabel toolStripLabel)
        {
            toolStripLabel.Text = MultiLanguageDictionary.Instance.Translate(toolStripLabel.Text);
        }
        //public void Translate(System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel)
        //{
        //    toolStripStatusLabel.Text = MultiLanguageDictionary.Instance.Translate(toolStripStatusLabel.Text);
        //}
        public void Translate(System.Windows.Forms.SaveFileDialog saveFileDialog)
        {
            saveFileDialog.Filter = MultiLanguageDictionary.Instance.Translate(saveFileDialog.Filter);
            saveFileDialog.Title = MultiLanguageDictionary.Instance.Translate(saveFileDialog.Title);
        }
        public void Translate(System.Windows.Forms.FolderBrowserDialog folderBrowserDialog)
        {
            folderBrowserDialog.Description = MultiLanguageDictionary.Instance.Translate(folderBrowserDialog.Description);
        }
        public void Translate(System.Windows.Forms.Button button)
        {
            button.Text = MultiLanguageDictionary.Instance.Translate(button.Text);
        }
        public void Translate(System.Windows.Forms.CheckBox checkBox)
        {
            checkBox.Text = MultiLanguageDictionary.Instance.Translate(checkBox.Text);
        }
        public void Translate(System.Windows.Forms.RadioButton radioButton)
        {
            radioButton.Text = MultiLanguageDictionary.Instance.Translate(radioButton.Text);
        }
        public void Translate(System.Windows.Forms.Label label)
        {
            label.Text = MultiLanguageDictionary.Instance.Translate(label.Text);

        }
        #endregion

        #region 陆海研发的控件部分

        public void Translate(CommonViewer.ButtonEx buttonEx)
        {
            buttonEx.Text = MultiLanguageDictionary.Instance.Translate(buttonEx.Text);
            buttonEx.Title = MultiLanguageDictionary.Instance.Translate(buttonEx.Title);
        }

        public void Translate(CommonViewer.BaseControl.UCObjectsGridView ucObjectsGridView)
        {
            ucObjectsGridView.ShowText = MultiLanguageDictionary.Instance.Translate(ucObjectsGridView.ShowText);
            for (int i = 0; i < ucObjectsGridView.Controls.Count; i++)
            {
                switchObject(ucObjectsGridView.Controls[i]);
            }

        }

        public void Translate(CommonViewer.UcDataGridView ucDataGridView)
        {
            ucDataGridView.Title = MultiLanguageDictionary.Instance.Translate(ucDataGridView.Title);

            for (int i = 0; i < ucDataGridView.Columns.Count; i++)
            {
                if (ucDataGridView.Columns[i].Visible)
                {
                    ucDataGridView.Columns[i].HeaderText = MultiLanguageDictionary.Instance.Translate(ucDataGridView.Columns[i].HeaderText);
                }
            }
            for (int i = 0; i < ucDataGridView.ContextMenuStrip.Items.Count; i++)
            {
                ucDataGridView.ContextMenuStrip.Items[i].Text = MultiLanguageDictionary.Instance.Translate(ucDataGridView.ContextMenuStrip.Items[i].Text);
            }
            if (ucDataGridView.Header != null)
                for (int i = 0; i < ucDataGridView.Header.Count; i++)
                {
                    if (ucDataGridView.Visible)
                        ucDataGridView.Header[i] = MultiLanguageDictionary.Instance.Translate(ucDataGridView.Header[i]);
                }
            if (ucDataGridView.Footer != null)
                for (int i = 0; i < ucDataGridView.Footer.Count; i++)
                {
                    if (ucDataGridView.Visible)
                        ucDataGridView.Footer[i] = MultiLanguageDictionary.Instance.Translate(ucDataGridView.Footer[i]);
                }
        }

        public void Translate(CommonViewer.BaseControl.ComboxEx comboxEx)
        {
            comboxEx.NullValueShow = MultiLanguageDictionary.Instance.Translate(comboxEx.NullValueShow);
        }

        public void Translate(System.Windows.Forms.UserControl userControl)
        {
            for (int i = 0; i < userControl.Controls.Count; i++)
            {
                switchObject(userControl.Controls[i]);
            }
        }

        #endregion
        private void switchObject(Object theViewObject)
        {
            #region 陆海研发的控件部分

            if (theViewObject.GetType() == typeof(CommonViewer.ButtonEx))
            {
                Translate((CommonViewer.ButtonEx)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(CommonViewer.BaseControl.UCObjectsGridView))
            {
                Translate((CommonViewer.BaseControl.UCObjectsGridView)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(CommonViewer.UcDataGridView))
            {
                Translate((CommonViewer.UcDataGridView)theViewObject);
            }
            #endregion
            #region 系统自带的控件部分

            else if (theViewObject.GetType() == typeof(System.Windows.Forms.BindingNavigator))
            {
                Translate((System.Windows.Forms.BindingNavigator)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ContextMenuStrip))
            {
                Translate((System.Windows.Forms.ContextMenuStrip)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.TabControl))
            {
                Translate((System.Windows.Forms.TabControl)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.TabPage))
            {
                Translate((System.Windows.Forms.TabPage)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripMenuItem))
            {
                Translate((System.Windows.Forms.ToolStripMenuItem)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripSplitButton))
            {
                Translate((System.Windows.Forms.ToolStripSplitButton)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripDropDownButton))
            {
                Translate((System.Windows.Forms.ToolStripDropDownButton)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.MenuStrip))
            {
                Translate((System.Windows.Forms.MenuStrip)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.Form))
            {
                Translate((System.Windows.Forms.Form)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.Panel))
            {
                Translate((System.Windows.Forms.Panel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.BindingNavigator))
            {
                Translate((System.Windows.Forms.BindingNavigator)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripButton))
            {
                Translate((System.Windows.Forms.ToolStripButton)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripLabel))
            {
                Translate((System.Windows.Forms.ToolStripLabel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.SaveFileDialog))
            {
                Translate((System.Windows.Forms.SaveFileDialog)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.FolderBrowserDialog))
            {
                Translate((System.Windows.Forms.FolderBrowserDialog)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.Button))
            {
                Translate((System.Windows.Forms.Button)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.GroupBox))
            {
                Translate((System.Windows.Forms.GroupBox)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.Label))
            {
                Translate((System.Windows.Forms.Label)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.SplitContainer))
            {
                Translate((System.Windows.Forms.SplitContainer)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.SplitterPanel))
            {
                Translate((System.Windows.Forms.SplitterPanel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.TableLayoutPanel))
            {
                Translate((System.Windows.Forms.TableLayoutPanel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ListView))
            {
                Translate((System.Windows.Forms.ListView)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.TreeView))
            {
                Translate((System.Windows.Forms.TreeView)theViewObject);
            }
            else if (theViewObject.GetType().BaseType == typeof(System.Windows.Forms.UserControl))
            {
                Translate((System.Windows.Forms.UserControl)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.CheckBox))
            {
                Translate((System.Windows.Forms.CheckBox)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.RadioButton))
            {
                Translate((System.Windows.Forms.RadioButton)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.StatusStrip))
            {
                Translate((System.Windows.Forms.StatusStrip)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.ToolStripStatusLabel))
            {
                Translate((System.Windows.Forms.ToolStripStatusLabel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
            {
                Translate((System.Windows.Forms.FlowLayoutPanel)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.DataGridView))
            {
                Translate((System.Windows.Forms.DataGridView)theViewObject);
            }
            else if (theViewObject.GetType() == typeof(System.Windows.Forms.LinkLabel))
            {
                Translate((System.Windows.Forms.LinkLabel)theViewObject);
            }
            else
            {
                /// <summary>
                /// 临时,发布时删除,打出不存在控件的类型.
                /// </summary>
                /// <param name="typeName"></param>
                //MultiLanguageDictionary.Instance.ControlTypeWriteToExcel(theViewObject.GetType().ToString());
            }
            #endregion

        }
        public void ShowToolTip(Control c)
        {
            if (toolTip == null) return;
            if (string.IsNullOrEmpty(c.Text)) return;
            c.AutoSize = false;
            string temp = c.Text.Trim();
            double dublong = c.CreateGraphics().MeasureString(temp, c.Font).Width;
            if (dublong < temp.Length)
            {
                c.Text = temp.Substring(0, Convert.ToInt32(dublong - 3)) + "...";
                toolTip.SetToolTip(c, temp);
            }
        }
    }
}
