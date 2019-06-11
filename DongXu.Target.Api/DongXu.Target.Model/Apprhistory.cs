using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Apprhistory
    {
        public int ApprHistoryId { get; set; }
        public int? ApprActivityId { get; set; }
        public DateTime? ApprHistoryCreateTime { get; set; }
    }
}
