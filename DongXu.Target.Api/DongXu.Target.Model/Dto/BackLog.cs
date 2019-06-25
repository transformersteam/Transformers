using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DongXu.Target.Model.Dto
{

    /// <summary>
    /// 待办
    /// </summary>
    public class BackLog
    {

        /// <summary>
        /// 业务名称
        /// </summary>
        public string Goal_Name { get; set; }

        /// <summary>
        /// 频次
        /// </summary>
        public string Frequency_Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string GoalType_Name { get; set; } 

        /// <summary>
        /// 级别
        /// </summary>
        public string IndexLevel_Grade { get; set; } 

        /// <summary>
        /// 责任人
        /// </summary>
        public string Goal_ChargePeople { get; set; } 

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? Goal_EndTime { get; set; } 

        /// <summary>
        /// 当前进度
        /// </summary>
        public int? Feedback_NowEvolve { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string GoalState_Name { get; set; } 
    }
}
