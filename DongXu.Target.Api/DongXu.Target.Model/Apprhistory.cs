using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 审批历史表
    /// </summary>
    public partial class Apprhistory
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ApprHistoryId { get; set; }

        /// <summary>
        /// 活动表id
        /// </summary>
        public int? ApprActivityId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ApprHistoryCreateTime { get; set; }
    }
}
