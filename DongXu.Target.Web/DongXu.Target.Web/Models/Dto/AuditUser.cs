using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web
{
    public class AuditUser
    {
        public int apprActivity_Id { get; set; }

        /// <summary>
        /// 主键id
        /// </summary>
        public int goal_Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int user_Id { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string user_RealName { get; set; }
    }
}
