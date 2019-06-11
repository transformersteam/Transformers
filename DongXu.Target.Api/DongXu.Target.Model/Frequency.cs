using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Frequency
    {
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public DateTime? FrequencyCreateTime { get; set; }
        public sbyte? FrequencyIsUse { get; set; }
    }
}
