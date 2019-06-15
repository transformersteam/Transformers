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
        public string IndexLevel_Grade { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Frequency_Name { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string Goal_ChargePeople { get; set; }

        /// <summary>
        /// 填报人
        /// </summary>
        public string Goal_Informant { get; set; }

        /// <summary>
        /// 协办人名称
        /// </summary>
        public string Goal_Organiser { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Goal_CreateTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? Goal_EndTime { get; set; }

        /// <summary>
        /// 考核权重
        /// </summary>
        public int? Goal_Weight { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string File_Name { get; set; }     
    }
}
