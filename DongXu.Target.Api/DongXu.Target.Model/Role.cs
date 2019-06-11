using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? RolePid { get; set; }
        public string RoleContent { get; set; }
        public sbyte? RoleIsEnable { get; set; }
        public DateTime? RoleCreateTime { get; set; }
        public string RoleCreatePeople { get; set; }
        public string RoleModifyPeople { get; set; }
        public DateTime? RoleModifyTime { get; set; }
    }
}
