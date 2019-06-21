using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web.Models.Dto
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
