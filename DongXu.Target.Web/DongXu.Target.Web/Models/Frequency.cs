using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 反馈频次表
    /// </summary>
    public partial class Frequency
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int FrequencyId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FrequencyName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FrequencyCreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? FrequencyIsUse { get; set; }
    }
}
