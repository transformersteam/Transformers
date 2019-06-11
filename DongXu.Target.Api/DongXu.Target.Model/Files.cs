using System;
using System.Collections.Generic;

namespace DongXu.Target.Model
{
    public partial class Files
    {
        public int FilesId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int? GoalId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
