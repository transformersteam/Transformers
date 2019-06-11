using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 关注表
    /// </summary>
    public partial class Attention
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int AttentionId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int? GoalId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? AttentionIsUse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? AttentionCreateTime { get; set; }
    }
}
