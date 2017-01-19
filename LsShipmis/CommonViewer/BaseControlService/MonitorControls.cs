/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MonitorControls.cs
 * 创 建 人：牛振军
 * 创建时间：2008-7-19
 * 标    题：监控当前用户是否变更数据，用来提醒用户数据是否有变化的接口
 * 功能描述：
 * 修 改 人：牛振军
 * 修改时间：2009-11-11
 * 修改内容：重新构造
 * 使用方法
 * 1、在需要监控的对象内部生成一个MonitorControls monitor=new MonitorControls()类型的对象
 * 2、设置需要监控的属性monitor.BeginMonitor＝true；
 * 3、将需要监控的几个传过来monitor.Colls=this.Controls; monitor.startMonitor();
 *                       或 monitor.Monitor(this.Controls) 自动进行监控启动动作
 *                       此方法的调用必须在界面上所有的数据加载完毕之后调用
 * 4、获取监控结果 bool result=monitor.getResult();
 * 注意：自己保存数据后，要调用一次restartMonitor()方法或.BeginMonitor＝false;
 * 高级应用
 * 1、可以自己增加需要监控的控件类型 AddMonitorType方法。
 * 2、停止监控 stopMonitor
 * 3、重启监控 restartMonitor
 * 4、自动触发监控改变的事件 monitor.dataChanged();
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CommonViewer.BaseControlService
{
    public class MonitorControls 
    {

        #region 私有变量

        /// <summary>
        /// 需要监控变化的控件集合.
        /// </summary>
        private Control.ControlCollection colls;
        private Dictionary<Type, monitoriType> monitorType = new Dictionary<Type, monitoriType>();
        private Dictionary<object, string> objValue = new Dictionary<object, string>();
        private Dictionary<object, monitoriType> monitorObj = new Dictionary<object, monitoriType>();
        private Form ContainerForm;
        private string message="数据发生变化，是否保存";

        #endregion

        #region 公有属性

        /// <summary>
        /// 监视对象的值类型.
        /// </summary>
        public enum monitoriType { Text, Value, Checked };

        /// <summary>
        /// 哪些集合需要进行监控.
        /// </summary>
        public Control.ControlCollection Colls
        {
            get { return colls; }
            set 
            { 
                colls = value;
            }
        }

        /// <summary>
        /// 是否进行监控.
        /// </summary>
        public bool BeginMonitor;

        private bool close=true;

        /// <summary>
        /// 触发保存时间后是否继续关闭窗体.
        /// </summary>
        public bool Close
        {
            get { return close; }
            set { close = value; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数，默认可以监控支持 TextBox,ComboBox,DateTimePicker,CheckBox,RadioButton
        /// </summary>
        public MonitorControls()
        {
            monitorType.Add(typeof(TextBox), monitoriType.Text);
            monitorType.Add(typeof(ComboBox), monitoriType.Text);
            monitorType.Add(typeof(DateTimePicker), monitoriType.Value);
            monitorType.Add(typeof(CheckBox), monitoriType.Checked);
            monitorType.Add(typeof(RadioButton), monitoriType.Checked);
            monitorType.Add(typeof(TextBoxEx), monitoriType.Text);
            monitorType.Add(typeof(NumericUpDown), monitoriType.Value);
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="msg">退出时有变化的提示信息</param>
        public MonitorControls(string msg):this()
        {
            message = msg;
        }

        void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BeginMonitor && getResult())
            {
                 DialogResult res= MessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(res==DialogResult.Yes)
                {
                    if (dataChanged != null)
                        dataChanged();
                    if (!close)
                    {
                        e.Cancel = true;
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
        
        #region 公有方法

        /// <summary>
        /// 增加一个新的监控对象类型.
        /// </summary>
        /// <param name="objType">对象的类型，Ex:typeof(TextBox)</param>
        /// <param name="valueType">监控对象的值类型</param>
        public void AddMonitorType(Type objType,monitoriType valueType)
        {
            monitoriType val;
            if (!monitorType.TryGetValue(objType, out val)) //没有注册过.
            {
                monitorType.Add(objType, valueType);
            }
        }

        /// <summary>
        /// 获取监控的结果，不清除结果.
        /// </summary>
        /// <returns></returns>
        public bool getResult()
        {
            foreach (object obj in objValue.Keys)
            {
                string value;
                if (objValue.TryGetValue(obj, out value))
                {
                    monitoriType montype;
                    monitorObj.TryGetValue(obj, out montype);
                    if (ReflectObjValue(obj, montype) != value)
                    {
                        return true && BeginMonitor;
                    }
                }
            }
            return false && BeginMonitor;
        }

        /// <summary>
        /// 设定重新监控，清除上次的监控结果.
        /// </summary>
        public void restartMonitor()
        {
            stopMonitor();
            startMonitor();
        }

        /// <summary>
        /// 停止监控.
        /// </summary>
        public void stopMonitor()
        {
            BeginMonitor = false;
        }

        /// <summary>
        /// 开始监控.
        /// </summary>
        public void startMonitor()
        {
            BeginMonitor = true;
            objValue.Clear();
            monitorObj.Clear();
            lMonitor(colls);
            GetContainerForm();
        }

        /// <summary>
        /// 开始监控.
        /// </summary>
        /// <param name="cols">需要监控的集合</param>
        public void Monitor(Control.ControlCollection cols)
        {
            colls = cols;
            startMonitor();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设定被监控的控件，支持 Dictionary<Type, monitoriType> monitorObj包含的类型.
        /// </summary>
        /// <param name="controls">被监控的控件集合，比如this.Controls</param>
        private void lMonitor(Control.ControlCollection controls)
        {
            if (colls == null) return;

            foreach (Control col in controls)
            {
                monitoriType type;
                if (!monitorType.TryGetValue(col.GetType(), out type) && col.HasChildren) //如果当前对象在需要监视的类型里面则监视.
                {
                    lMonitor(col.Controls);
                }
                else
                {
                    monitorObj.Add(col, type);
                    switch (type)
                    {
                        case monitoriType.Text:
                            objValue.Add(col, col.Text);
                            break;
                        case monitoriType.Value:
                            objValue.Add(col, ReflectObjValue(col, monitoriType.Value));
                            break;
                        case monitoriType.Checked:
                            objValue.Add(col, ReflectObjValue(col, monitoriType.Checked));
                            break;
                    }
                }
            }
        }

        //反射获取值.
        private string ReflectObjValue(object obj, monitoriType type)
        {
            string val = "";
            PropertyInfo[] pis = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);//获得对象的所有public属性.
            if (pis != null)//如果获得了属性.
            {
                foreach (PropertyInfo pi in pis)//针对每一个属性进行循环.
                {
                    if (type.ToString() == pi.Name)//如果对象的属性名称恰好和字符串中的属性名相同.
                    {
                        val = pi.GetValue(obj, null).ToString();
                        break;
                    }
                }
            }
            return val;
        }

        //获取控件所在的父窗体.
        private void GetContainerForm()
        {
            if (colls == null)
            {
                ContainerForm = null;
            }
            else
            {
                ContainerForm = (System.Windows.Forms.Form)gteParentForm(colls[0]);
                if (ContainerForm != null)
                {
                    ContainerForm.FormClosing += new FormClosingEventHandler(ContainerForm_FormClosing);
                }
            }
        }

        private Control gteParentForm(Control col)
        {
            while (col != null && col.GetType().BaseType.FullName != "System.Windows.Forms.Form")
            {
                col = col.Parent;
            }
            return col;
        }

        #endregion

        #region 有变化的事件
        public delegate void DataChanged();
        public event DataChanged dataChanged;
        #endregion

    }
}
