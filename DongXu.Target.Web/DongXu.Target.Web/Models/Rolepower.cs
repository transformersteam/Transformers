using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public partial class Rolepower
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int RolePowerId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public int? PowerId { get; set; }
    }
}
