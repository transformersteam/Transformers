using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.Excute
{
    public class GoalRepository : IGoalRepository
    {
        dxdatabaseContext db = new dxdatabaseContext();

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        public List<Goal> GetGoalList()
        {
            using (db)
            {
                var list = db.Goal.ToList();
                return list;
            }
        }
    }
}
