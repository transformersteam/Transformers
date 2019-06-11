using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserRealName { get; set; }
        public string UserRoleName { get; set; }
        public sbyte? UserIsEnable { get; set; }
        public DateTime? UserCreateTime { get; set; }
    }
}
