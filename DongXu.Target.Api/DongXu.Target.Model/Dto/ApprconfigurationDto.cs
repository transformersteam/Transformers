using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class ApprconfigurationDto
    {
        /// <summary>
        /// 审批人员id
        /// </summary>
        public string AuditValue { get; set; }
        /// <summary>
        /// 目标表id
        /// </summary>
        public int GoalId { get; set; }

    }
}
