using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 指标等级表
    /// </summary>
    public partial class Indexlevel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int IndexLevelId { get; set; }

        /// <summary>
        /// 指标等级
        /// </summary>
        public string IndexLevelGrade { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? IndexLevelCreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? IndexLevelIsUse { get; set; }
    }
}
