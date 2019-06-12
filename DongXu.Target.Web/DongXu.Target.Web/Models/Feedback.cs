using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 反馈表
    /// </summary>
    public partial class Feedback
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int FeedbackId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int? GoalId { get; set; }

        /// <summary>
        /// 状态id
        /// </summary>
        public int? StateId { get; set; }

        /// <summary>
        /// 累计工作进展
        /// </summary>
        public string FeedbackWorkEvolve { get; set; }

        /// <summary>
        /// 当日周进展
        /// </summary>
        public string FeedbackDayEvolve { get; set; }

        /// <summary>
        /// 存在问题
        /// </summary>
        public string FeedbackQuestion { get; set; }

        /// <summary>
        /// 解决措施
        /// </summary>
        public string FeedbackMeasure { get; set; }

        /// <summary>
        /// 需集团协调事项
        /// </summary>
        public string FeedbackCoordinateMatters { get; set; }

        /// <summary>
        /// 当前进展
        /// </summary>
        public int? FeedbackNowEvolve { get; set; }
    }
}
