using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;

namespace BaseInfo.Viewer
{
    public partial class UcPostSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcPostSelect()
        {
            DataTable dt;
            string err;
            InitializeComponent();
            dt = BaseInfo.DataAccess.PostService.Instance.getInfo(out err);
            FrmPostInfoSelect frm = new FrmPostInfoSelect();
            Init(dt, "SHIP_HEADSHIP_ID", "HEADSHIP_NAME", false, true, "所有岗位", frm, false);            
        }
        /// <summary>
        /// 切换选择模式这种情况不需要维护基本信息.
        /// </summary>
        /// <param name="whichToSelect"></param>
        public void ChangeSelectedState(string whichToSelect,bool canAll)
        {
            DataTable dt;
            string err;
            Department depart = (Department)BaseInfo.DataAccess.DepartmentService.Instance.GetOneObjectByName(whichToSelect);
            if (depart.IsWrong) throw new Exception(depart.WhyWrong);
            dt = BaseInfo.DataAccess.PostService.Instance.getDepartPosts(depart.GetId(), out err);
            Init(dt, "SHIP_HEADSHIP_ID", "HEADSHIP_NAME", false, canAll, "所有" + whichToSelect + "岗位", null, false);            
        }
        /// <summary>
        /// 切换选择模式这种情况不需要维护基本信息.
        /// </summary>
        /// <param name="whichToSelect"></param>
        public void ChangeSelectedState(bool landPostList, bool onlyLeader)
        {
            ChangeSelectedState(landPostList, onlyLeader, false);
        }
        /// <summary>
        /// 切换选择模式这种情况不需要维护基本信息.
        /// </summary>
        /// <param name="whichToSelect"></param>
        public void ChangeSelectedState(bool landPostList, bool onlyLeader, bool canNullIn)
        {
            ChangeSelectedState(landPostList, onlyLeader, canNullIn, "未选择任何岗位");
        }
        /// <summary>
        /// 切换选择模式这种情况不需要维护基本信息.
        /// </summary>
        /// <param name="whichToSelect"></param>
        public void ChangeSelectedState(bool landPostList, bool onlyLeader, bool canNullIn, string nullString)
        {
            DataTable dt;
            dt = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(landPostList, onlyLeader);
            Init(dt, "SHIP_HEADSHIP_ID", "HEADSHIP_NAME", false, canNullIn, nullString, null, false);
        }
    }
}
