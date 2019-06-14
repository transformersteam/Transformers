using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web
{
    public class EchartModel
    {
        public string name { get; set; }

        public int value { get; set; }

        public List<int> datacount { get; set; }

        public List<string> dataname { get; set; }
    }
}
