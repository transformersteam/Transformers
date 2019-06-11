using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Power
    {
        public int PowerId { get; set; }
        public string PowerName { get; set; }
        public string PowerUrl { get; set; }
        public int? PowerPid { get; set; }
        public int? PowerSortId { get; set; }
        public sbyte? PowerIsEnable { get; set; }
        public DateTime? PowerCreateTime { get; set; }
    }
}
