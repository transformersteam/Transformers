using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Goal
    {
        public int GoalId { get; set; }
        public string GoalName { get; set; }
        public int? GoalStateId { get; set; }
        public int? RoleId { get; set; }
        public int? GoalTypeId { get; set; }
        public int? IndexLevelId { get; set; }
        public int? FrequencyId { get; set; }
        public DateTime? GoalStartTime { get; set; }
        public DateTime? GoalEndTime { get; set; }
        public DateTime? GoalPeriod { get; set; }
        public string GoalUnit { get; set; }
        public string GoalChargePeople { get; set; }
        public int? GoalWeight { get; set; }
        public string GoalInformant { get; set; }
        public string GoalOrganiser { get; set; }
        public string GoalFormula { get; set; }
        public string GoalSources { get; set; }
        public int? FileId { get; set; }
        public DateTime? GoalCreateTime { get; set; }
    }
}
