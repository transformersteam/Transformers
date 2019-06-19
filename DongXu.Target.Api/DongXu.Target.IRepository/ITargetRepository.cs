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
        List<GoalQuery> GoalQueryList(string goalname, int goaltype, int goalleave, string goalrole, string goaluser, string strTime, string endTime, int goalstate = 0);
    }
}
