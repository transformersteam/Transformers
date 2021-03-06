﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
   public class AddUser
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserRealName { get; set; }

        /// <summary>
        /// 用户角色名称
        /// </summary>
        public string UserRoleName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool UserIsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? UserCreateTime { get; set; }

        public int userRoleid { get; set; }
    }
}
