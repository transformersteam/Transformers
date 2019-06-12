using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 权限表
    /// </summary>
    public partial class Power
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int PowerId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string PowerUrl { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public int? PowerPid { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        public int? PowerSortId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? PowerIsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? PowerCreateTime { get; set; }
    }
}
