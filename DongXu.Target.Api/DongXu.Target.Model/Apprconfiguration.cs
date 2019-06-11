using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Apprconfiguration
    {
        public int ApprConfigurationId { get; set; }
        public int? UserId { get; set; }
        public int? GoalId { get; set; }
        public sbyte? ApprConfigurationIsEnable { get; set; }
        public DateTime? ApprConfigurationCreateTime { get; set; }
        public int? ApprConfigurationNextid { get; set; }
        public int? ApprConfigurationStateid { get; set; }
        public int? RoleId { get; set; }
    }
}
