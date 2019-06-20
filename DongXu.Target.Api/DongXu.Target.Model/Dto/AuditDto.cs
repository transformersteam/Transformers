using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class AuditDto
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Goal_Id { get; set; }

        /// <summary>
        /// 目标名称
        /// </summary>
        public string Goal_Name { get; set; }

        /// <summary>
        /// 指标单位id
        /// </summary>
        public int? Role_Id { get; set; }

        /// <summary>
        /// 指标等级id
        /// </summary>
        public int? IndexLevel_Id { get; set; }

        /// <summary>
        /// 反馈频次id
        /// </summary>
        public int? Frequency_Id { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Goal_StartTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? Goal_EndTime { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        public DateTime? Goal_Period { get; set; }

        /// <summary>
        /// 责任单位（只是部门）
        /// </summary>
        public string Goal_Unit { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string Goal_ChargePeople { get; set; }

        /// <summary>
        /// 考核权重
        /// </summary>
        public int? Goal_Weight { get; set; }

        /// <summary>
        /// 填报人
        /// </summary>
        public string Goal_Informant { get; set; }

        /// <summary>
        /// 协办人名称
        /// </summary>
        public string Goal_Organiser { get; set; }

        /// <summary>
        /// 计算公式
        /// </summary>
        public string Goal_Formula { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string Goal_Sources { get; set; }

        /// <summary>
        /// 文件id
        /// </summary>
        public int? File_Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Goal_CreateTime { get; set; }

        /// <summary>
        /// 待办状态 待办已办
        /// </summary>
        public int Business_State { get; set; }

        /// <summary>
        /// 进度百分比
        /// </summary>
        public int Feedback_Id { get; set; }

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
        /// <summary>
        /// 名称
        /// </summary>
        public string GoalType_Name { get; set; }

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
        /// 累计工作进展
        /// </summary>
        public string Feedback_WorkEvolve { get; set; }

        /// <summary>
        /// 当日周进展
        /// </summary>
        public string Feedback_DayEvolve { get; set; }

        /// <summary>
        /// 存在问题
        /// </summary>
        public string Feedback_Question { get; set; }

        /// <summary>
        /// 解决措施
        /// </summary>
        public string Feedback_Measure { get; set; }

        /// <summary>
        /// 需集团协调事项
        /// </summary>
        public string Feedback_CoordinateMatters { get; set; }

        /// <summary>
        /// 当前进展
        /// </summary>
        public int? Feedback_NowEvolve { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ApprActivity_CreateTime { get; set; } 

        /// <summary>
        /// 文件名称
        /// </summary>
        public string File_Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string File_Url { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string GoalState_Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string GoalState_Explain { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GoalState_CreateTime { get; set; }
        /// <summary>
        /// 下一步id
        /// </summary>
        public int Next_Id { get; set; }
        /// <summary>
        /// 活动id
        /// </summary>
        public int State_Id { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        public string ApprActivity_Opinion { get; set; }
        /// <summary>
        /// 配置表id
        /// </summary>
        public int ApprConfiguration_Id { get; set; }
        /// <summary>
        /// 活动表id
        /// </summary>
        public int ApprActivity_Id { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public int ApprActivity_IsExecute { get; set; }
    }
}
