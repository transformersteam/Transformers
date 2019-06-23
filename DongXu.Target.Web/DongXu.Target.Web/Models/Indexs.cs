using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 指标分解表
    /// </summary>
    public partial class Indexs
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int IndexsId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int GoalId { get; set; }

        /// <summary>
        /// 一月
        /// </summary>
        public int? IndexsJanuary { get; set; }

        /// <summary>
        /// 二月
        /// </summary>
        public int? IndexsFebruary { get; set; }

        /// <summary>
        /// 三月
        /// </summary>
        public int? IndexsMarch { get; set; }

        /// <summary>
        /// 四月
        /// </summary>
        public int? IndexsApril { get; set; }

        /// <summary>
        /// 五月
        /// </summary>
        public int? IndexsMay { get; set; }

        /// <summary>
        /// 六月
        /// </summary>
        public int? IndexsJune { get; set; }

        /// <summary>
        /// 七月
        /// </summary>
        public int? IndexsJuly { get; set; }

        /// <summary>
        /// 八月
        /// </summary>
        public int? IndexsAugust { get; set; }

        /// <summary>
        /// 九月
        /// </summary>
        public int? IndexsSeptember { get; set; }

        /// <summary>
        /// 十月
        /// </summary>
        public int? IndexsOctober { get; set; }

        /// <summary>
        /// 十一月
        /// </summary>
        public int? IndexsNovember { get; set; }

        /// <summary>
        /// 十二月
        /// </summary>
        public int? IndexsYearTarget { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime IndexsCreateTime { get; set; }
    }
}
