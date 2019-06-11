using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Userrole
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
