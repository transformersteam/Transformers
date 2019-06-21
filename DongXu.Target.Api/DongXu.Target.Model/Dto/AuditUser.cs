using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model
{
    public class AuditUser
    {
        public int ApprActivity_Id { get; set; }

        /// <summary>
        /// 主键id
        /// </summary>
        public int Goal_Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int User_Id { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string User_RealName { get; set; }
    }
}
