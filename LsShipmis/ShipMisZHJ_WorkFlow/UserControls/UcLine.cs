using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ShipMisZHJ_WorkFlow.UserControls
{
    public partial class UcLine : UserControl
    {
        public UcLine(Control parent,Color ocolor)
        {
            InitializeComponent();
            this.Parent = parent;
            color = ocolor;
        }

        private Point x;
        private Point y;
        private Color color;
        private new Control Parent;
        public Point X
        {
            get { return x; }
            set 
            {
                x = value;
            }
        }
        
        public Point Y
        {
            get { return y; }
            set { y = value;}
        }

        internal void draw()
        {
            Graphics g = Parent.CreateGraphics();
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen p = new Pen(color, 1);
            p.CustomEndCap = lineCap;//定义线尾的样式为箭头.
            g.DrawLine(p, x, y);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            draw();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Graphics g = Parent.CreateGraphics();
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen p = new Pen(color, 1);
            p.CustomEndCap = lineCap;//定义线尾的样式为箭头.
            g.DrawLine(p, x, y);
        }

        public void SetFocus()
        {
            OnGotFocus(new EventArgs());
        }

        public void releaseFocus()
        {
            OnLostFocus(new EventArgs());
        }
    }
}
