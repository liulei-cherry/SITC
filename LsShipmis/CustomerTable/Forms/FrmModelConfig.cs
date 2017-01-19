using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonViewer.BaseControl;
namespace CustomerTable.Forms
{
    public partial class FrmModelConfig : CommonViewer.BaseForm.FormBase
    {
        private bool modelChanged = false;

        public bool ModelChanged
        {
            get { return modelChanged; } 
        }
        StringOperation theObject = new StringOperation();

        public FrmModelConfig()
        {
            InitializeComponent();
        }
        public FrmModelConfig(string name)
        {
            InitializeComponent();
            txtTableName.Text = name;
               
        }

        /// <summary>
        /// 设置dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgv.Columns["Column0"].ReadOnly = true;
            dgv.Columns["Column0"].DefaultCellStyle.BackColor = Color.Linen;
            dgv.Columns["Column0"].Width = 70;
            dgv.Columns["Column1"].Width = 170;
            dgv.Columns["Column2"].Width = 170;
            dgv.Columns["Column3"].Width = 270; 
        }

        private void FrmModelConfig_Load(object sender, EventArgs e)
        {
            dgv.LoadedFinish = false;
            setDataGridView();
            List <CustomerTableClass> lstToShow;
            int useCount;
            string err;
            if (!CustomerTableClassService.Instance.GetACustomerTableConfigerGroup(txtTableName.Text, out lstToShow, out useCount, out err))
            {
                MessageBoxEx.Show("获取过当前表格的配置项时出错，错误信息为：" + err, "错误提示");

            }
            else
            {
                for (int i = 0; i < lstToShow.Count; i++)
                {
                    insertARow(lstToShow[i].CATEGERY01, lstToShow[i].CATEGERY02, lstToShow[i].CATEGERY03);
                }
                if (dgv.Rows.Count ==0)
                {
                    MessageBoxEx.Show("未配置过当前表格的配置项", "提示信息");
                }
                resetSornNo();
            }           
            dgv.adding += new CommonViewer.UcDataGridView.Adding(adding);             
            dgv.deleting += new CommonViewer.UcDataGridView.Deleting(deleting);
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.LoadedFinish = true;
        }
        string lastInfo = "";
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            dgv.LoadedFinish = false;

            string toFind = richTextBox1.Rtf;
            if (toFind == lastInfo) return;
            lastInfo = toFind;
            string[] lines = toFind.Split('\r');

            string temp1;
            string temp2;
            string temp3;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].EndsWith("\\row"))
                {
                    lines[i] = lines[i].Substring(lines[i].IndexOf("\\intbl"), lines[i].IndexOf("\\row") - lines[i].IndexOf("\\intbl"));

                    temp1 = lines[i].Substring(lines[i].IndexOf("\\intbl") + 6, lines[i].IndexOf("\\cell") - lines[i].IndexOf("\\intbl") - 6);
                    lines[i] = lines[i].Substring(lines[i].IndexOf("\\cell") + 5, lines[i].Length - lines[i].IndexOf("\\cell") - 5);
                    if (lines[i].IndexOf("\\cell") < 0)
                    {
                        insertARow(theObject.ChangeRichBoxTextToCommonText(temp1), "", "");
                        continue;
                    }
                    temp2 = lines[i].Substring(0, lines[i].IndexOf("\\cell"));

                    lines[i] = lines[i].Substring(lines[i].IndexOf("\\cell") + 5, lines[i].Length - lines[i].IndexOf("\\cell") - 5);
                    if (lines[i].IndexOf("\\cell") < 0)
                    {
                        insertARow(theObject.ChangeRichBoxTextToCommonText(temp1), theObject.ChangeRichBoxTextToCommonText(temp2), "");
                        continue;
                    }
                    temp3 = lines[i].Substring(0, lines[i].IndexOf("\\cell"));

                    insertARow(theObject.ChangeRichBoxTextToCommonText(temp1), theObject.ChangeRichBoxTextToCommonText(temp2), theObject.ChangeRichBoxTextToCommonText(temp3));
                }
            }

            resetSornNo();
            dgv.LoadedFinish = true;
        }

        private void resetSornNo()
        {
            if(dgv.Rows.Count >0 )
            {
                for (int i = 0;i< dgv.Rows.Count ;i++)
                {
                    dgv.Rows[i].Cells["Column0"].Value = i + 1;
                }
            }
        }
      
        private void insertARow(string c1, string c2, string c3)
        {

            //得到当前最高行.
            
            int insertRowNo;
            if (dgv.CurrentRow != null)
            {
                insertRowNo = dgv.CurrentRow.Index + 1;
                dgv.Rows.Insert(insertRowNo, 1);
            }
            else
            {
                insertRowNo = dgv.Rows.Add();
            }
            
            dgv.Rows[insertRowNo].Cells["Column1"].Value = c1;
            dgv.Rows[insertRowNo].Cells["Column2"].Value = c2;
            dgv.Rows[insertRowNo].Cells["Column3"].Value = c3;
            dgv.CurrentCell = dgv.Rows[insertRowNo].Cells["Column1"];
        }
       
        private void adding()
        {
            insertARow("", "", "");
            resetSornNo();
        }
       
        private void deleting()
        {
            if (dgv.CurrentRow != null)
            {
                int crtrow = dgv.CurrentRow.Index;
                dgv.Rows.RemoveAt(crtrow);
            }
            resetSornNo();
        } 

        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSave_Click(object sender, EventArgs e)
        {
            List<CustomerTableClass> lstToSave = new List<CustomerTableClass> ();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                CustomerTableClass ctcTemp = new CustomerTableClass();
                ctcTemp.CT_CLASS = txtTableName.Text;
                ctcTemp.SEQUNCE = int.Parse(dr.Cells["Column0"].Value.ToString());
                ctcTemp.CATEGERY01 = (dr.Cells["Column1"].Value == null ? "" : dr.Cells["Column1"].Value.ToString());
                ctcTemp.CATEGERY02 = (dr.Cells["Column2"].Value == null ? "" : dr.Cells["Column2"].Value.ToString());
                ctcTemp.CATEGERY03 = (dr.Cells["Column3"].Value == null ? "" : dr.Cells["Column3"].Value.ToString());
                lstToSave.Add(ctcTemp);
            }
            string err;
            try
            {
                if (CustomerTableClassService.Instance.SaveACustomerTableConfigerGroup(txtTableName.Text, lstToSave, out err))
                {
                    MessageBoxEx.Show("保存成功", "提示信息");
                }
                else
                {
                    MessageBoxEx.Show("更新失败，失败提示信息请参考："+err, "提示信息");
                }
            }
            catch (Exception ee)
            {
                MessageBoxEx.Show(ee.Message, "提示信息");
            }
            modelChanged = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRapid_Click(object sender, EventArgs e)
        {            
            if (Clipboard.GetDataObject() != null)//判断剪贴板上面有没有东西，有则继续下面的语句.
            {
                IDataObject obj = Clipboard.GetDataObject();//获取剪贴板上的信息.
                if (obj.GetDataPresent(DataFormats.Rtf)) //判断剪贴板上面是不是text文本，即字符.
                {
                    richTextBox1.Rtf = (obj.GetData(DataFormats.Rtf)).ToString();//因为GetDataPresent这方法取出来的是一个object类型，因此要转换.
                }
            }            
        }
       
        private void dgv1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                btnRapid_Click(sender, e);
            }
        }
       
        private void AddButton_Click(object sender, EventArgs e)
        {
            adding();
        }
        
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleting();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

    }
}
