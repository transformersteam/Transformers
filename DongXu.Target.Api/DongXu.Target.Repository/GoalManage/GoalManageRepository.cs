using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.GoalManage
{
    /// <summary>
    /// 目标管理
    /// </summary>
    public class GoalManageRepository : IGoalManageRepository
    {
        dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        public List<Goal> GetGoalList()
        {
            var list = context.Goal.ToList();
            return list;
        }
    }
}
