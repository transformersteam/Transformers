using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    /// <summary>
    /// 周报查询
    /// </summary>
    public class WeekData
    {
        /// <summary>
        /// 目标id
        /// </summary>
        public int Goal_Id { get; set; }

        /// <summary>
        /// 目标名称
        /// </summary>
        public string Goal_Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string IndexLevel_Grade { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string GoalType_Name { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string User_Name { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int GoalYear { get; set; }

        /// <summary>
        /// 目标开始时间
        /// </summary>
        public DateTime Goal_StartTime { get; set; }

        /// <summary>
        /// 反馈进度
        /// </summary>
        public string Feedback_DayEvolve { get; set; }

        /// <summary>
        /// 目标结束时间
        /// </summary>
        public DateTime Goal_EndTime { get; set; }

        /// <summary>
        /// 周报id
        /// </summary>
        public int Frequency_Id { get; set; }

        /// <summary>
        /// 目标状态id
        /// </summary>
        public int GoalState_Id { get; set; }
    }
}
