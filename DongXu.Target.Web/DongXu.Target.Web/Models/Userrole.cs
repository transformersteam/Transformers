using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public partial class Userrole
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int? RoleId { get; set; }
    }
}
