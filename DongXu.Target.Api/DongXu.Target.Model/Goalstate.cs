using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 目标状态表
    /// </summary>
    public partial class Goalstate
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int GoalStateId { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string GoalStateName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string GoalStateExplain { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool GoalStateIsUse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GoalStateCreateTime { get; set; }
    }
}
