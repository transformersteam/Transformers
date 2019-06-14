using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    /// <summary>
    /// 目标详情
    /// </summary>
    public class TargetDetails
    {
        public string GoalType_Name { get; set; }

        public int Integral_Num { get; set; }

        /// <summary>
        /// 指标等级
        /// </summary>
        public string IndexLevelGrade { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FrequencyName { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string GoalChargePeople { get; set; }
    }
}
