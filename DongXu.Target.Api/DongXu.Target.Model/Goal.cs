﻿using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 目标表
    /// </summary>
    public partial class Goal
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int GoalId { get; set; }

        /// <summary>
        /// 目标名称
        /// </summary>
        public string GoalName { get; set; }

        /// <summary>
        /// 目标状态id
        /// </summary>
        public int GoalStateId { get; set; }

        /// <summary>
        /// 指标单位id
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 指标类型id
        /// </summary>
        public int? GoalTypeId { get; set; }

        /// <summary>
        /// 指标等级id
        /// </summary>
        public int? IndexLevelId { get; set; }

        /// <summary>
        /// 反馈频次id
        /// </summary>
        public int? FrequencyId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? GoalStartTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? GoalEndTime { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        public DateTime? GoalPeriod { get; set; }

        /// <summary>
        /// 责任单位（只是部门）
        /// </summary>
        public string GoalUnit { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string GoalChargePeople { get; set; }

        /// <summary>
        /// 考核权重
        /// </summary>
        public int? GoalWeight { get; set; }

        /// <summary>
        /// 填报人
        /// </summary>
        public string GoalInformant { get; set; }

        /// <summary>
        /// 协办人名称
        /// </summary>
        public string GoalOrganiser { get; set; }

        /// <summary>
        /// 计算公式
        /// </summary>
        public string GoalFormula { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string GoalSources { get; set; }

        /// <summary>
        /// 文件id
        /// </summary>
        public int? FileId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GoalCreateTime { get; set; }

        /// <summary>
        /// 待办状态 待办已办
        /// </summary>
        public int Business_State { get; set; }

        /// <summary>
        /// 进度百分比
        /// </summary>
        public int FeedbackId { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public int Goal_DutyUserId { get; set; }

        /// <summary>
        /// 责任单位
        /// </summary>
        public int Goal_DutyCommanyId { get; set; }

        /// <summary>
        /// 父级节点
        /// </summary>
        public int Goal_ParentId { get; set; }
    }
}
