using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web
{
    public class AuditUser
    {
        public int ApprActivityId { get; set; }

        /// <summary>
        /// 主键id
        /// </summary>
        public int GoalId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserRealName { get; set; }
    }
}
