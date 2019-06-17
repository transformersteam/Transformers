using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class GoalQuery
    {
        /// <summary>
        /// 目标名称
        /// </summary>
        public string Goal_Name { get; set; }

        /// <summary>
        /// 目标级别
        /// </summary>
        public string IndexLevel_Grade { get; set; }

        /// <summary>
        /// 目标类别
        /// </summary>
        public string GoalType_Name { get; set; }

        /// <summary>
        /// 责任单位
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string User_Name { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime Goal_EndTime { get; set; }

        /// <summary>
        /// 当前进度
        /// </summary>
        public int Feedback_NowEvolve { get; set; } 
    }
}
