using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Appractivity
    {
        public int ApprActivityId { get; set; }
        public int? UserId { get; set; }
        public int? GoalId { get; set; }
        public int? NextId { get; set; }
        public int? StateId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ApprConfigurationId { get; set; }
        public string ApprActivityOpinion { get; set; }
        public sbyte? ApprActivityIsExecute { get; set; }
        public sbyte? ApprActivityIsUse { get; set; }
        public DateTime? ApprActivityCreateTime { get; set; }
    }
}
