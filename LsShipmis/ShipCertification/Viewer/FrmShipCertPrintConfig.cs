using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using ShipCertification.DataObject;
using ShipCertification.Services;
using CommonViewer.BaseControl;

namespace ShipCertification.Viewer
{
    public partial class FrmShipCertPrintConfig : FormBase
    { 
        public bool NeedRetrieve = false;
        List<ShipCert> lstAllBaseCert = new List<ShipCert>();
        Dictionary<string, ShipCert> dicAllBaseCert = new Dictionary<string, ShipCert>();
        public FrmShipCertPrintConfig()
        {
            InitializeComponent();
        }

        private void btnAllShip_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = !richTextBox1.Visible;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            string err;
            //把界面上的内容全部获取到对象列表中.
            for (int i=0;i< dataGridView.Rows.Count ;i++)
            {
                string tempid = dataGridView.Rows[i].Cells["cShipCertId"].Value.ToString ();
                if (dicAllBaseCert.ContainsKey(tempid))
                {
                    if(dicAllBaseCert[tempid].NEEDOUTPUTSHOW.Equals((bool)dataGridView.Rows[i].Cells["cIfShow"].Value)
                       &&  dicAllBaseCert[tempid].AIMTOCONFIG.Equals(dataGridView.Rows[i].Cells["cRelationName"].Value.ToString ())
                       &&  dicAllBaseCert[tempid].AIMTOCONFIGSHORT.Equals(dataGridView.Rows[i].Cells["cRelationShortName"].Value.ToString ()))
                    {
                        continue ;
                    }

                    dicAllBaseCert[tempid].NEEDOUTPUTSHOW = (bool)dataGridView.Rows[i].Cells["cIfShow"].Value;
                    dicAllBaseCert[tempid].AIMTOCONFIG = dataGridView.Rows[i].Cells["cRelationName"].Value.ToString ();
                    dicAllBaseCert[tempid].AIMTOCONFIGSHORT = dataGridView.Rows[i].Cells["cRelationShortName"].Value.ToString ();
                    if (!dicAllBaseCert[tempid].Update(out err))
                    {
                        MessageBoxEx.Show("发生异常，获取了修改的内容，但保存失败！更多描述为：" + err);                        
                        return;
                    }
                    NeedRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("发生异常，修改的结果无法保存！");
                    return;
                }
            }
            MessageBoxEx.Show("修改成功！");
        }

        private void FrmShipCertPrintConfig_Load(object sender, EventArgs e)
        {
            try
            {
                //获取所有的证书基本信息对象.
                lstAllBaseCert = ShipCertService.Instance.GetAllReportCert();
            }
            catch (Exception ee)
            {
                MessageBoxEx.Show(ee.Message);
            }
            //按照排序一个个输出到界面上.
            for (int i = 0; i < lstAllBaseCert.Count; i++)
            {
                if (lstAllBaseCert[i] == null || lstAllBaseCert[i].IsWrong) continue;
                
                int r = dataGridView.Rows.Add();
                dicAllBaseCert.Add(lstAllBaseCert[i].GetId(), lstAllBaseCert[i]);
                dataGridView.Rows[r].Cells["cShipCertId"].Value = lstAllBaseCert[i].GetId();
                dataGridView.Rows[r].Cells["cCertName"].Value = lstAllBaseCert[i].SHIPCERTCHNAME;
                dataGridView.Rows[r].Cells["cIfShow"].Value = lstAllBaseCert[i].NEEDOUTPUTSHOW;
                dataGridView.Rows[r].Cells["cRelationName"].Value = lstAllBaseCert[i].AIMTOCONFIG;
                dataGridView.Rows[r].Cells["cRelationShortName"].Value = lstAllBaseCert[i].AIMTOCONFIGSHORT;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}