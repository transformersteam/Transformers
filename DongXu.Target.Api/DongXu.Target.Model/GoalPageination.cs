using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model
{
    public class GoalPageination
    {
        /// <summary>
        /// 最大页数
        /// </summary>
        public int maxPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 状态集合
        /// </summary>
        public List<Goal> GoalList { get; set; }
    }
}
