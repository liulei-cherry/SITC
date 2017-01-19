using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonViewer.BaseForm; 

namespace SynchDll
{
    public partial class FrmEditTableInfo : Form
    {
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        SynchDllService exImportService = new SynchDllService();
        private string sLastTableId = "";
        private ComboBox comboBox = new ComboBox();
        private ComboBox comboField = new ComboBox();
        public FrmEditTableInfo()
        {
            InitializeComponent();
        }

        private void FrmEditTableInfo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.setCboTable();
            this.setBindingSourceTable();
            this.setDataGridView();
            this.setCboBox();
            this.setBindingControl();
            comboField.Visible = false;
        }
        /// <summary>
        /// 加载第一次加载窗体需要加载下拉列表.
        /// </summary>
        private void setCboBox()
        {
            DataTable dtb = exImportService.GetSynchronousTableIdAndCName();
            comboBox.DataSource = dtb;
            comboBox.DisplayMember = "table_name";
            comboBox.ValueMember = "table_id";
            comboBox.Visible = false;
            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvField, comboBox, 6, false, 1);
            DataTable dtbType = new DataTable();
            DataColumn colId = new DataColumn("Id", typeof(int));
            DataColumn colName = new DataColumn("Name", typeof(string));
            dtbType.Columns.Add(colId);
            dtbType.Columns.Add(colName);
            DataRow row1 = dtbType.NewRow();
            row1["Id"] = 0;
            row1["Name"] = "普通列";
            DataRow row2 = dtbType.NewRow();
            row2["Id"] = 1;
            row2["Name"] = "主键列";
            DataRow row3 = dtbType.NewRow();
            row3["Id"] = 2;
            row3["Name"] = "外键列";
            dtbType.Rows.Add(row1);
            dtbType.Rows.Add(row2);
            dtbType.Rows.Add(row3);

            DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
            dgvBindDrop2.bindDropToDgv(dgvField, dtbType, 4, false, 1);

            DataTable dtbOwner = new DataTable();
            dtbOwner.Columns.Add("Id", typeof(int));
            dtbOwner.Columns.Add("Name", typeof(string));
            row1 = dtbOwner.NewRow();
            row1["Id"] = 0;
            row1["Name"] = "仅船舶端维护";
            row2 = dtbOwner.NewRow();
            row2["Id"] = 1;
            row2["Name"] = "仅公司端维护";
            row3 = dtbOwner.NewRow();
            row3["Id"] = 2;
            row3["Name"] = "双方均可以维护";
            dtbOwner.Rows.Add(row1);
            dtbOwner.Rows.Add(row2);
            dtbOwner.Rows.Add(row3);
            cboOwner.DataSource = dtbOwner;
            cboOwner.DisplayMember = "Name";
            cboOwner.ValueMember = "Id";

            //this.setCboField();
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvField, comboField, 2, false, 2);

            DataTable dtb2 = new DataTable();
            dtb2.Columns.Add("Id", typeof(int));
            dtb2.Columns.Add("Name", typeof(string));
            DataRow row4 = dtb2.NewRow();
            row4[0] = 0;
            row4[1] = "string";
            DataRow row5 = dtb2.NewRow();
            row5[0] = 1;
            row5[1] = "number";
            DataRow row6 = dtb2.NewRow();
            row6[0] = 2;
            row6[1] = "dateTime";
            DataRow row7 = dtb2.NewRow();
            row7[0] = 3;
            row7[1] = "blob";
            dtb2.Rows.Add(row4);
            dtb2.Rows.Add(row5);
            dtb2.Rows.Add(row6);
            dtb2.Rows.Add(row7);
            //需要挂下拉列表.

            DgvBindDrop dgvBindDrop = new DgvBindDrop();
            dgvBindDrop.bindDropToDgv(dgvField, dtb2, 9, false, 1);
        }
        /// <summary>
        /// 设置CboField的数据源.
        /// </summary>
        private void setCboField()
        {
            if (dgvTable.CurrentRow == null) return;
            //string sTableName = dgvTable.CurrentRow.Cells["table_name"].Value.ToString();
            OurTable nowTable = OurTableServices.GetInstance.LoadATableById(sLastTableId);
            DataTable dtbColumns = new DataTable();
            DataColumn col = new DataColumn("name", typeof(string));
            dtbColumns.Columns.Add(col);
            DataTable dtbTemp = new DataTable();
            dtbTemp = exImportService.GetAllFields(nowTable.TableName);
            if (dtbTemp == null)
            {
                return;
            }

            foreach (DataColumn col1 in dtbTemp.Columns)
            {
                DataRow row = dtbColumns.NewRow();
                row["name"] = col1.ColumnName;
                dtbColumns.Rows.Add(row);
            }
            comboField.DataSource = dtbColumns;
            comboField.DisplayMember = "name";
            comboField.ValueMember = "name";
            DataTable dtbShowColumn = dtbColumns.Copy();
            DataRow row1 = dtbShowColumn.NewRow();
            row1["name"] = null;
            dtbShowColumn.Rows.InsertAt(row1, 0);
            cboShowFieldName.DataSource = dtbShowColumn;
            cboShowFieldName.DisplayMember = "name";
            cboShowFieldName.ValueMember = "name";
        }
        /// <summary>
        /// 设置下拉列表CboTable
        /// </summary>
        private void setCboTable()
        {
            DataTable dtb = exImportService.GetAllRealTableName();
            cboTable.DataSource = dtb;
            cboTable.DisplayMember = dtb.Columns[0].ColumnName;
            cboTable.ValueMember = dtb.Columns[0].ColumnName;
        }

        /// <summary>
        /// 设置绑定控件BindingSourceTable的数据源.
        /// </summary>
        private void setBindingSourceTable()
        {
            DataTable dtb = exImportService.GetSynchronousTableIdAndCName();
            bindingSourceTable.DataSource = dtb;
            dgvTable.DataSource = bindingSourceTable;
        }
        /// <summary>
        /// 设置dgvTable的显示列.
        /// </summary>
        private void setDataGridView()
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            dgvTable.Columns.Insert(0, col);
            col.TrueValue = 1;
            col.FalseValue = 0;
            col.HeaderText = "自连表";
            col.DataPropertyName = "link_myself";
            dgvTable.LoadGridView("FrmEditTableInfo.dgvTable");
            dgvTable.Columns["table_id"].Visible = false;
            dgvTable.Columns["table_status"].Visible = false;
            dgvTable.Columns["table_belong"].Visible = false;
            dgvTable.Columns["link_myself"].Visible = false;
            dgvTable.Columns["synchFilterOfLand"].Visible = false;
            dgvTable.Columns["synchFilterOfShip"].Visible = false;
            dgvTable.Columns["table_name"].HeaderText = "表名";
            dgvTable.Columns["table_chinesename"].HeaderText = "表显示名";
            dgvTable.Columns["table_belongName"].HeaderText = "表所有者";
            dgvTable.Columns["show_column_name"].Visible = false;
            dgvTable.Columns["table_status_name"].HeaderText = "表状态";
            dgvTable.Columns["synchShip"].Visible = false;
            if (dgvTable.Rows.Count > 0)
            {
                dgvTable.CurrentCell = dgvTable.Rows[0].Cells["table_name"];
            }
        }
        /// <summary>
        /// 绑定控件.
        /// </summary>
        private void setBindingControl()
        {
            cboTable.DataBindings.Add("SelectedValue", bindingSourceTable, "table_name", true);
            txtTableCName.DataBindings.Add("Text", bindingSourceTable, "table_chinesename", true);
            txtTableCName.DataBindings.Add("Tag", bindingSourceTable, "table_id", true);
            cboOwner.DataBindings.Add("SelectedValue", bindingSourceTable, "table_belong", true);
            cboOwner.DataBindings.Add("Text", bindingSourceTable, "table_belongName", true);
            cboShowFieldName.DataBindings.Add("Text", bindingSourceTable, "show_column_name", true);
            checkBox1.DataBindings.Add("Checked", bindingSourceTable, "link_myself", true);
            checkBox2.DataBindings.Add("Checked", bindingSourceTable, "table_status", true);
            txtFilterLand.DataBindings.Add("Text", bindingSourceTable, "synchFilterOfLand", true);
            txtFilterShip.DataBindings.Add("Text", bindingSourceTable, "synchFilterOfShip", true);
            txtShipSetting.DataBindings.Add("Text", bindingSourceTable, "synchShip", true);
        }
        /// <summary>
        /// 设定绑定控件BindingSourceField的数据源.
        /// </summary>
        private void setBindingSourceField()
        {
            DataTable dtb = exImportService.GetAllFieldByTableId(sLastTableId);
            bindingSourceField.DataSource = dtb;
            dgvField.DataSource = bindingSourceField;
        }
        /// <summary>
        /// 设定dgvField的显示.
        /// </summary>
        private void setDataGridViewField()
        {
            dgvField.LoadGridView("FrmEditTableInfo.dgvField");
            dgvField.Columns["field_id"].Visible = false;
            dgvField.Columns["table_id"].Visible = false;
            dgvField.Columns["fk_table_id"].Visible = false;
            dgvField.Columns["field_type"].Visible = false;
            dgvField.Columns["value_type"].Visible = false;
            dgvField.Columns["field_name"].HeaderText = "列名";
            dgvField.Columns["field_name"].ReadOnly = true;
            dgvField.Columns["field_typeName"].HeaderText = "列类型";
            dgvField.Columns["field_typeName"].ReadOnly = true;
            dgvField.Columns["table_name"].HeaderText = "外键表名";
            dgvField.Columns["table_name"].ReadOnly = true;
            dgvField.Columns["sortNum"].Visible = false;
            dgvField.Columns["value_typeName"].HeaderText = "数据类型";
            dgvField.Columns["value_typeName"].ReadOnly = true;

            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id", typeof(int));
            dtb.Columns.Add("name", typeof(string));
            if (dgvField.Rows.Count > 0)
            {
                dgvField.CurrentCell = dgvField.Rows[0].Cells["table_name"];
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvTable.CurrentCell != null)
            {
                bindingSourceField.AddNew();
                dgvField.CurrentRow.Cells["field_id"].Value = Guid.NewGuid().ToString();
                dgvField.CurrentRow.Cells["table_id"].Value = sLastTableId;
                dgvField.CurrentRow.Cells["field_type"].Value = 0;
                dgvField.CurrentRow.Cells["field_typeName"].Value = "普通列";
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvField.Rows.Count > 0)
            {
                bindingSourceField.RemoveCurrent();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bindingSourceField.EndEdit();

            //数据校验.
            if (dgvField.HasEmptyVal("field_id"))
            {
                MessageBox.Show("列名不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //保存.
            DataTable dtb = (DataTable)bindingSourceField.DataSource;
            string sErrMessage = "";
            if (dbOperation.SaveFormData(dtb, "t_table_field", 0, out sErrMessage))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show(sErrMessage);
            }
        }

        /**********************************************************************************************************************************/
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            if (bindingSourceTable.DataSource != null)
            {
                bindingSourceTable.AddNew();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                txtTableCName.Tag = Guid.NewGuid().ToString();
                checkBox1.Checked = false;
            }

        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {

            if (dgvTable.Rows.Count > 0)
            {
                bindingSourceTable.RemoveCurrent();
            }

        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            DataTable dtb;
            string sErrMessage = "";
            bindingSourceTable.EndEdit();
            string tableId = txtTableCName.Tag.ToString();
            dtb = (DataTable)bindingSourceTable.DataSource;
            if (dbOperation.SaveFormData(dtb, "t_table_name", 0, out sErrMessage))
            {
                MessageBox.Show("保存成功");
                setCboBox();
                setCboTable();
                bindingSourceField.DataSource = null;
            }
            else
            {
                MessageBox.Show(sErrMessage);
            }
            this.setBindingSourceTable();
            if (!string.IsNullOrEmpty(tableId))
            {
                dgvTable.ScrollToDefinedRow("table_id", tableId);
            }
        }

        private void tsBtnUndo_Click(object sender, EventArgs e)
        {
            this.setBindingSourceTable();

        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvField_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvField.CurrentCell != null)
            {
                if (dgvField.Rows[e.RowIndex].Cells["field_type"].Value != null && e.ColumnIndex == dgvField.Columns["table_name"].Index)
                {
                    if (!dgvField.Rows[e.RowIndex].Cells["field_type"].Value.ToString().Equals("2"))
                    {
                        comboBox.Enabled = false;
                        comboBox.Visible = false;
                        dgvField.Rows[e.RowIndex].Cells["table_name"].Value = null;
                        dgvField.Rows[e.RowIndex].Cells["fk_table_id"].Value = null;
                    }
                    else
                    {
                        comboBox.Enabled = true;
                        comboBox.Visible = true;
                    }
                }

            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            string err;
            //当id有意义的时候,重新为当前表进行配置,
            if (txtTableCName.Tag.ToString().Length != 36)
            {
                return;
            }
            if (!SynchDllService.GetInstance.IsAUsefullTableId(txtTableCName.Tag.ToString()))
            {
                MessageBox.Show("当前表无效或未保存,系统无法认知!");
                return;
            }
            //step1,删除所有已经配置的错误项,仅删除名称错误的,排序字段不处理.
            if (!SynchDllService.GetInstance.DeleteAllRegeditWrongColumns(cboTable.Text, out err))
            {
                MessageBox.Show("删除所有已经配置的表错误字段时出错,错误信息为" + err);
                return;
            }
            //step2,添加所有未存在的配置项.
            if (!SynchDllService.GetInstance.InsertNotRegeditColumns(cboTable.Text, out err))
            {
                MessageBox.Show("添加所有未存在的配置项时出错,错误信息为" + err);
                return;
            }
            //由于排序已经不能影响同步了,所以不再作为关键属性进行维护.
            this.setCboField();
            this.setBindingSourceField();
            this.setDataGridViewField();
            cboShowFieldName.Text = dgvTable.CurrentRow.Cells["show_column_name"].Value.ToString().Trim();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string err;
            if (MessageBox.Show("是否要删除所有数据库配置项中错误的内容?", "报警提示",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!SynchDllService.GetInstance.DeleteAllRegeditWrongColumns(out err)
                || !SynchDllService.GetInstance.DeleteAllRegeditWrongTables(out err))
                {
                    MessageBox.Show("删除所有已经配置的表错误字段时出错,错误信息为" + err);
                    return;
                }
                else
                {
                    MessageBox.Show("处理完毕!");
                    bindingSourceField.DataSource = null;
                    this.setBindingSourceTable();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string err;
            if (!SynchDllService.GetInstance.InsertNotRegeditColumns(out err))
            {
                MessageBox.Show("添加所有未存在的配置项时出错,错误信息为" + err);
                return;
            }
            else
            {
                bindingSourceField.DataSource = null;
                MessageBox.Show("处理完毕!");
                this.setBindingSourceTable();
            }

        }

        private void btnRecreateTrigger_Click(object sender, EventArgs e)
        {
            string err;
            if (!SynchDllService.GetInstance.RecreateTableTrigger(cboTable.Text, out err))
            {
                MessageBox.Show(err);
            }
            else
            {
                MessageBox.Show("成功操作!");
            }
        }

        private void FrmEditTableInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("显示列名表达式指在此表的某条数据需要提示时,所配置的表达此条数据信息的列!"
            + "\r如设备表 设置为 [设备名称 + 型号] 设置的时候需要专业人员填写相应的sql语法,不能随意填写!");
        }

        private void dgvTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nIndex = e.RowIndex;
            if (dgvTable.Rows[nIndex].Cells["table_id"].Value == null) return;
            string sSelectTableId = dgvTable.Rows[nIndex].Cells["table_id"].Value.ToString();
            if (sSelectTableId.Equals(sLastTableId))
            {
                return;
            }
            sLastTableId = sSelectTableId;
            this.setCboField();
            this.setBindingSourceField();
            this.setDataGridViewField();
            if (dgvTable.CurrentRow != null)
                cboShowFieldName.Text = dgvTable.CurrentRow.Cells["show_column_name"].Value.ToString().Trim();
        }
    }
}