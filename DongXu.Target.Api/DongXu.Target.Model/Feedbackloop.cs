using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 反馈周期表
    /// </summary>
    public partial class Feedbackloop
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int FeedbackLoopId { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? FeedbackLoopTimes { get; set; }

        /// <summary>
        /// 提醒内容
        /// </summary>
        public string FeedbackLoopContent { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? FeedbackLoopUpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FeedbackLoopCreateTime { get; set; }
    }
}
