using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 红绿灯状态表格显示
    /// </summary>
    public class BusinessStateTable
    {
        /// <summary>
        /// 目标id
        /// </summary>
        public int Goal_Id { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int GoalState_Id { get; set; } 

        /// <summary>
        /// 状态总数
        /// </summary>
        public int statecount { get; set; }
    }
}
