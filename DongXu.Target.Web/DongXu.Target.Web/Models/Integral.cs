using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 积分表
    /// </summary>
    public partial class Integral
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int IntegralId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 积分总数
        /// </summary>
        public int? IntegralNum { get; set; }
    }
}
