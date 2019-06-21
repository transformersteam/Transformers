using DongXu.Target.IRepository.IDecision;
using DongXu.Target.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.Decision
{
    public class TLPercentageRepository: ITLPercentageRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 子公司红绿灯总百分比饼图
        /// </summary>
        /// <returns></returns>
        public List<Model.Dto.TLPercentage> GetITLPercentageList()
        {
            var query = context.TLPercentage.FromSql("select   s.RedLight,s.YellowLight,s.GreenLight,s.TargetNumber  from (select t.Role_Name, t.RedLight, t.YellowLight, t.GreenLight,SUM(t.RedLight + t.YellowLight + t.GreenLight) as 'TargetNumber' from(select role.Role_Name,SUM(CASE goal.GoalState_Id WHEN 1 or 2 THEN 1 ELSE 0 END) as 'RedLight',SUM(CASE goal.GoalState_Id WHEN 3 THEN 1 ELSE 0 END) as 'YellowLight',SUM(CASE goal.GoalState_Id WHEN 6 or 5 THEN 1 ELSE 0 END) as 'GreenLight' from role join goal on role.Role_Id = goal.Role_Id join goalstate on goalstate.GoalState_Id = goal.GoalState_Id join indexlevel on indexlevel.IndexLevel_Id = goal.IndexLevel_Id where role.Role_Id >= 2 and role.Role_Id <= 5 ) t ) s").ToList();
            return query;
        }
    }
}
