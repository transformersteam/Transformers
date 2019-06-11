using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? GoalId { get; set; }
        public int? StateId { get; set; }
        public string FeedbackWorkEvolve { get; set; }
        public string FeedbackDayEvolve { get; set; }
        public string FeedbackQuestion { get; set; }
        public string FeedbackMeasure { get; set; }
        public string FeedbackCoordinateMatters { get; set; }
        public int? FeedbackNowEvolve { get; set; }
    }
}
