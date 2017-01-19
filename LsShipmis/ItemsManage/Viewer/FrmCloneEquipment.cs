using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using ItemsManage.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using CommonViewer.BaseControl;
using ItemsManage.Services;

namespace ItemsManage.Viewer
{
    public partial class FrmCloneEquipment : FormBase
    {
        private FrmCloneEquipment()
        {
            InitializeComponent();
            arrayTextBox.Add(textBox1);
            arrayTextBox.Add(textBox2);
            arrayTextBox.Add(textBox3);
            arrayTextBox.Add(textBox4);
            arrayTextBox.Add(textBox5);
            arrayTextBox.Add(textBox6);
            arrayTextBox.Add(textBox7);
            arrayTextBox.Add(textBox8);
            arrayTextBox.Add(textBox9);
            arrayTextBox.Add(textBox10);
            arrayTextBox.Add(textBox11);
            arrayTextBox.Add(textBox12);
        }
        ComponentUnit toCloneItem;
        ComponentUnit theAimComponent;
        EquipmentClass theAimClass;
        public EquipmentClass TheAimClass
        {
            get { return theAimClass; }
        }
        public ComponentUnit TheAimComponent
        {
            get { return theAimComponent; } 
        }
        public FrmCloneEquipment(ComponentUnit toCloneItem)
            : this()
        {
            this.toCloneItem = toCloneItem; 
            if (toCloneItem == null || toCloneItem.IsWrong) return;
            ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
            ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(toCloneItem);
            TreeNode nowNode = ucEquipmentClassTreeWithEquipment1.SelectedNode;
            if(nowNode.Parent!=null)
            {
                nowNode = nowNode.Parent;
                ucEquipmentClassTreeWithEquipment1.SelectedNode = nowNode;
            }
            textBoxEx1.Text = toCloneItem.COMP_CHINESE_NAME;
            comboBox1.Text = "1";
            comboBox2.Text = "2";
        }
        List<TextBox> arrayTextBox = new List<TextBox>();
        private void setCanEdit(int copyCount)
        {
            int i = 0;
            for (; i < copyCount; i++)
            {
                arrayTextBox[i].ReadOnly = false;
                arrayTextBox[i].Text = "";
            }
            for (; i < 12; i++)
            {
                arrayTextBox[i].ReadOnly = true;
                arrayTextBox[i].Text = "";
            }
        }

        private void setTextBoxValue()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                return;
            }
            int copyCount = int.Parse(comboBox1.Text);
            int startNo = int.Parse(comboBox2.Text);
            bool nameStyle = radioButton2.Checked;
            setCanEdit(copyCount);
            for (int i = 0; i < copyCount; i++,startNo++)
            {
                arrayTextBox[i].Text = nameStyle ? (startNo + "# " + textBoxEx1.Text) : ("No." + startNo + " " + textBoxEx1.Text);
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTextBoxValue();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int copyCount = int.Parse(comboBox1.Text);

            bool toEquipmentClass;
            string err; 
            string shipId;
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag!=null)
            {
                toEquipmentClass = (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(EquipmentClass));
                if (toEquipmentClass)
                {
                    theAimClass = (EquipmentClass)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag;
                    TreeNode temp = ucEquipmentClassTreeWithEquipment1.SelectedNode;
                    while (temp.Parent != null)
                    {
                        temp = temp.Parent;
                    }
                    if (temp != null && temp.Tag.GetType() == typeof(ShipInfo))
                        shipId = ((ShipInfo)temp.Tag).GetId();
                    else
                        shipId = theAimComponent.SHIP_ID;
                }
                else
                {
                    if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(ShipInfo))
                    {
                        shipId = ((ShipInfo)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag).GetId();
                        theAimComponent = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipId, out err);
                    }
                    else if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(ComponentUnit))
                    {
                        theAimComponent = (ComponentUnit)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag;
                        shipId = theAimComponent.SHIP_ID;
                    }
                    else
                    {//shipId = theAimComponent.SHIP_ID;
                        throw new Exception("错误的节点类型,无法进行后续操作");
                    }
                } 
            }
            else 
            {
                MessageBoxEx.Show("未正确选择要拷贝到的位置，无法完成克隆");
                ucEquipmentClassTreeWithEquipment1.Focus();
                return ;
            }
            bool saveEngname = cbSaveEngname.Checked;
            bool saveExamCode = cbSaveExamCode.Checked;
            //克隆一个完整的备件.
            for (int i = 0; i < copyCount; i++)
            {
                if (toEquipmentClass)
                {
                    if (!ComponentUnitService.Instance.CloneEquipmentAndSubToAClass(toCloneItem,theAimClass.GetId(),shipId,arrayTextBox[i].Text,saveEngname,saveExamCode ,out err))
                    {
                        MessageBoxEx.Show("克隆未成功完成，错误原因是："+err);
                        return;
                    }
                }
                else
                {
                    if (!ComponentUnitService.Instance.CloneEquipmentAndSubToAnotherEquipment(toCloneItem, theAimComponent.GetId(), shipId, arrayTextBox[i].Text, saveEngname, saveExamCode, out err))
                    {
                        MessageBoxEx.Show("克隆未成功完成，错误原因是：" + err);
                        return;
                    }
                }
            }
            MessageBoxEx.Show("克隆完成");            
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            setTextBoxValue();
        }

        private void textBoxEx1_TextChanged(object sender, EventArgs e)
        {
            setTextBoxValue();
        }

    }
}
