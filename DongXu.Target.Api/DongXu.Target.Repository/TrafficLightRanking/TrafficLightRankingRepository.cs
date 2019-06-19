using DongXu.Target.IRepository.TrafficLightRanking;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.TrafficLightRanking
{
    public class TrafficLightRankingRepository : ITrafficLightRankingRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 各公司红绿灯百分比排名
        /// </summary>
        /// <returns></returns>
        public List<Model.Dto.TrafficLightRanking> GetTrafficLightRankingList()
        {
            var query = context.TrafficLightRanking.FromSql("select t.Role_Name,t.RedLight,t.YellowLight,t.GreenLight,SUM(t.RedLight + t.YellowLight + t.GreenLight) as 'TargetNumber' from(select role.Role_Name,SUM(CASE goalstate.GoalState_Name WHEN '未完成(到期)' or '预计延期' THEN 1 ELSE 0 END) as 'RedLight',SUM(CASE goalstate.GoalState_Name WHEN '已完成(延期)' THEN 1 ELSE 0 END) as 'YellowLight',SUM(CASE goalstate.GoalState_Name WHEN '正常推进' or '已完成(按期)' THEN 1 ELSE 0 END) as 'GreenLight' from role join goal on role.Role_Id = goal.Role_Id join goalstate on goalstate.GoalState_Id = goal.GoalState_Id join indexlevel on indexlevel.IndexLevel_Id = goal.IndexLevel_Id where role.Role_Id >= 2 and role.Role_Id <= 5 GROUP BY role.Role_Name ) t group by t.Role_Name").ToList();
            return query;
        }
    }
}
