using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 审核活动表
    /// </summary>
    public partial class Appractivity
    {
        public int ApprActivityId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int? GoalId { get; set; }

        /// <summary>
        /// 下一个节点id
        /// </summary>
        public int? NextId { get; set; }

        /// <summary>
        /// 状态id
        /// </summary>
        public int? StateId { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 配置表id
        /// </summary>
        public int? ApprConfigurationId { get; set; }

        /// <summary>
        /// 审批详情
        /// </summary>
        public string ApprActivityOpinion { get; set; }

        /// <summary>
        /// 执行操作
        /// </summary>
        public sbyte? ApprActivityIsExecute { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? ApprActivityIsUse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ApprActivityCreateTime { get; set; }
    }
}
