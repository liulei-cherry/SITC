using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Interfaces
{
    public interface IRemindViewState
    {
        /// <summary>
        /// 设置窗体审批处理类型报警显示状态
        /// </summary>
        void SetRemindViewApprovalState();
        /// <summary>
        /// 设置窗体通知类型报警显示状态
        /// </summary>
        void SetRemindViewInformState();
    }
}
