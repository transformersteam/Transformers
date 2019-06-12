using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 审批配置表
    /// </summary>
    public partial class Apprconfiguration
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ApprConfigurationId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int? GoalId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? ApprConfigurationIsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ApprConfigurationCreateTime { get; set; }

        /// <summary>
        /// 下一步节点id
        /// </summary>
        public int? ApprConfigurationNextid { get; set; }

        /// <summary>
        /// 状态id
        /// </summary>
        public int? ApprConfigurationStateid { get; set; }

        /// <summary>
        /// 公司部门角色id
        /// </summary>
        public int? RoleId { get; set; }
    }
}
