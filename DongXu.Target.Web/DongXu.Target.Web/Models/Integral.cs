using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
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

        /// <summary>
        /// 目标id
        /// </summary>
        public int Goal_Id { get; set; }
    }
}
