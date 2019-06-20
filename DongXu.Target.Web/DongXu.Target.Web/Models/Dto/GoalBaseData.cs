using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web.Models
{
    public class GoalBaseData
    {
        /// <summary>
        /// 目标名称
        /// </summary>
        public string GoalName { get; set; }

        /// <summary>
        /// 指标单位id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 父级节点
        /// </summary>
        public int Goal_ParentId { get; set; }

        /// <summary>
        /// 指标类型id
        /// </summary>
        public int GoalTypeId { get; set; }

        /// <summary>
        /// 指标等级id
        /// </summary>
        public int IndexLevelId { get; set; }

        /// <summary>
        /// 反馈频次id
        /// </summary>
        public int FrequencyId { get; set; }

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
        /// 责任人
        /// </summary>
        public int Goal_DutyUserId { get; set; }

        /// <summary>
        /// 责任单位
        /// </summary>
        public int Goal_DutyCommanyId { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int? GoalId { get; set; }

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

        public string AuditValue { get; set; }
    }
}
