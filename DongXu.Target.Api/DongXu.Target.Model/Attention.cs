using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 关注表
    /// </summary>
    public partial class Attention
    {
        public int AttentionId { get; set; }
        public int? GoalId { get; set; }
        public int? UserId { get; set; }
        public sbyte? AttentionIsUse { get; set; }
        public DateTime? AttentionCreateTime { get; set; }
    }
}
