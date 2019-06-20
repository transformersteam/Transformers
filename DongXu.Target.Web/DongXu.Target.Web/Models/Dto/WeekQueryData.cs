using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web
{
    public class WeekQueryData
    {
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public string goalName { get; set; }

        public int typeId { get; set; }

        public int leaveId { get; set; }

        public int stateId { get; set; }

        public string dutyCommanyName { get; set; }

        public string dutyUserName { get; set; }

        public string begintime { get; set; }

        public string endtime { get; set; }
    }
}
