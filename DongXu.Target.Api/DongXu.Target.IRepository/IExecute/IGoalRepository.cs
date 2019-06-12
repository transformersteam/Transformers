using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IExecute
{
    public interface IGoalRepository
    {
        /// <summary>
        /// 待办事项集合
        /// </summary>
        /// <returns></returns>
        List<Goal> GetGoalInfo();

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        GoalPageination GetGoalList(int pageindex = 1, int pagesize = 3);

    }
}
