using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web
{
    public class GoalStateGoal
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string GoalState_Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string GoalState_Explain { get; set; }

        public decimal percent { get; set; }

        public int count { get; set; }
    }
}
