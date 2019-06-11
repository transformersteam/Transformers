using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Feedbackloop
    {
        public int FeedbackLoopId { get; set; }
        public DateTime? FeedbackLoopTimes { get; set; }
        public string FeedbackLoopContent { get; set; }
        public DateTime? FeedbackLoopUpdateTime { get; set; }
        public DateTime? FeedbackLoopCreateTime { get; set; }
    }
}
