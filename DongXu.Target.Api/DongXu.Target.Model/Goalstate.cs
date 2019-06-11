using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Goalstate
    {
        public int GoalStateId { get; set; }
        public string GoalStateName { get; set; }
        public string GoalStateExplain { get; set; }
        public sbyte? GoalStateIsUse { get; set; }
        public DateTime? GoalStateCreateTime { get; set; }
    }
}
