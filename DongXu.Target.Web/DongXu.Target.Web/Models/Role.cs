﻿using System;
using System.Collections.Generic;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public int RolePid { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string RoleContent { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public sbyte? RoleIsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? RoleCreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string RoleCreatePeople { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string RoleModifyPeople { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? RoleModifyTime { get; set; }
        
        //标识列
        public int RoleIdentify { get; set; }
    }
}
