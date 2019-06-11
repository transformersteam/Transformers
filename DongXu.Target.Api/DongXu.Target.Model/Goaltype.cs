using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Goaltype
    {
        public int GoalTypeId { get; set; }
        public string GoalTypeName { get; set; }
        public int? GoalTypePid { get; set; }
        public sbyte? GoalTypeIsUse { get; set; }
        public DateTime? GoalTypeCreateTime { get; set; }
    }
}
