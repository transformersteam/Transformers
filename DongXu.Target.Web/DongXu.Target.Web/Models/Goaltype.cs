using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 目标类型表
    /// </summary>
    public partial class Goaltype
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int GoalTypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string GoalTypeName { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public int? GoalTypePid { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? GoalTypeIsUse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GoalTypeCreateTime { get; set; }
    }
}
