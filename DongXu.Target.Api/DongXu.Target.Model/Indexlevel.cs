using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Indexlevel
    {
        public int IndexLevelId { get; set; }
        public string IndexLevelGrade { get; set; }
        public DateTime? IndexLevelCreateTime { get; set; }
        public sbyte? IndexLevelIsUse { get; set; }
    }
}
