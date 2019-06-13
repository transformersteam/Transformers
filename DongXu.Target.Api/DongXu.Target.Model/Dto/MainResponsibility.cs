using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    /// <summary>
    /// 主责
    /// </summary>
    public class MainResponsibility
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Key]
        public int GoalId { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        public string GoalName { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        public string GoalStateName { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public string IndexLevelGrade { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string GoalChargePeople { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? GoalEndTime { get; set; }

        /// <summary>
        /// 当前进度
        /// </summary>
        public int? FeedbackNowEvolve { get; set; }
    }
}
