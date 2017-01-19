using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace ShipMisZHJ_WorkFlow.UserControls
{
    public partial class UCNode : UserControl
    {
        public UCNode()
        {
            InitializeComponent();
        }

        public UCNode(string postType)
            : this()
        {
            PostType = postType;
        }

        #region private field
 
        string postType;          //岗位类型.
        string cameFrom;
        string passTo;
        string denyTo;

        #endregion

        #region public field
        /// <summary>
        /// 工作流id
        /// </summary>
        /// <summary>
        /// 岗位类型.
        /// </summary>
        public string PostType
        {
            get 
            {
                return postType; 
            }
            set 
            {
                postType = value;
                ShowPost(postType);
            }
        }
        public string CameFrom
        {
            get { return cameFrom; }
            set { cameFrom = value; }
        }

        public string PassTo
        {
            get { return passTo; }
            set { passTo = value; }
        }

        public string DenyTo
        {
            get { return denyTo; }
            set { denyTo = value; }
        } 
      
        #endregion

        #region mouse event
        private void labObject_MouseDown(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labObject.Left + tableLayoutPanel.Left, labObject.Top + tableLayoutPanel.Top);
            this.OnMouseDown(e);
        }

        private void labObject_MouseMove(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labObject.Left + tableLayoutPanel.Left, labObject.Top + tableLayoutPanel.Top);
            this.OnMouseMove(e);
        }

        private void labObject_MouseUp(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labObject.Left + tableLayoutPanel.Left, labObject.Top + tableLayoutPanel.Top);
            this.OnMouseUp(e);
        }

        private void labPost_MouseDown(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labPost.Left + tableLayoutPanel.Left, labPost.Top + tableLayoutPanel.Top);
            this.OnMouseDown(e);
        }

        private void labPost_MouseMove(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labPost.Left + tableLayoutPanel.Left, labPost.Top + tableLayoutPanel.Top);
            this.OnMouseMove(e);
        }

        private void labPost_MouseUp(object sender, MouseEventArgs e)
        {
            //MouseArgus argu = new MouseArgus(e, labPost.Left + tableLayoutPanel.Left, labPost.Top + tableLayoutPanel.Top);
            this.OnMouseUp(e);
        }

        public class MouseArgus : MouseEventArgs
        {
            public MouseArgus(MouseEventArgs argus, int x, int y)
                : base(argus.Button, argus.Clicks, argus.X + x, argus.Y + y, argus.Delta)
            {
            }
        }
        #endregion

        private void ShowPost(string type)
        {
            if (type != null)
            {
                string err = "";
                Post post = PostService.Instance.getObjectByType(type, out err);
                if (!post.IsWrong)
                {
                    labPost.Text = post.POSTNAME;
                }
            }
        }

        private void labObject_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void labPost_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.labPost.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.labPost.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

    }
}
