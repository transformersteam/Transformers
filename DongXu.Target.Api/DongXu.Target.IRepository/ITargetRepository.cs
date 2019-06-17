using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model.Dto;

namespace DongXu.Target.IRepository
{
   public interface ITargetRepository
    {
        /// <summary>
        /// 目标查询列表
        /// </summary>
        /// <returns></returns>
        List<GoalQuery> GoalQueryList();
    }
}
