using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DongXu.Target.IRepository;

namespace DongXu.Target.Repository
{
    public class TargetRepository : ITargetRepository
    {
        dxdatabaseContext Context = new dxdatabaseContext();

        /// <summary>
        /// 目标查询
        /// </summary>
        /// <param name="goalname"></param>
        /// <param name="goaltype"></param>
        /// <param name="goalleave"></param>
        /// <param name="goalrole"></param>
        /// <param name="goaluser"></param>
        /// <param name="strTime"></param>
        /// <param name="endTime"></param>
        /// <param name="goalstate"></param>
        /// <returns></returns>
        public List<GoalQuery> GoalQueryList(string goalname, int goaltype, int goalleave, string goalrole, string goaluser, string strTime, string endTime, int goalstate = 0)
        {

            string sql = string.Format("select goal.Goal_Name,indexlevel.IndexLevel_Grade,goaltype.GoalType_Name, " +
                "role.Role_Name,`user`.User_Name, goal.Goal_EndTime, feedback.Feedback_NowEvolve from goal " +
                "join indexlevel on goal.IndexLevel_Id = indexlevel.IndexLevel_Id " +
                "join goaltype on goal.GoalType_Id = goaltype.GoalType_Id " +
                "join role on Goal_DutyCommanyId = role.Role_Id " +
                "join user on Goal_DutyUserId = user.User_Id join feedback on goal.Feedback_Id = feedback.Feedback_Id where 1=1 ");

            if (goalstate != 0)
            {
                sql += string.Format("  and goal.GoalState_Id={0}", goalstate);
            }
            if (!string.IsNullOrEmpty(goalname))
            {
                sql += string.Format("  and goal.Goal_Name like '%{0}%'", goalname);
            }
            if (goaltype != 0)
            {
                sql += string.Format(" and goaltype.GoalType_Id={0}", goaltype);
            }
            if (goalleave != 0)
            {
                sql += string.Format(" and indexlevel.IndexLevel_Id={0}", goalleave);
            }
            if (!string.IsNullOrEmpty(goalrole))
            {
                sql += string.Format("  and role.Role_Name like '%{0}%'", goalrole);
            }
            if (!string.IsNullOrEmpty(goaluser))
            {
                sql += string.Format("  and user.User_Name like '%{0}%'", goaluser);
            }
            if (!string.IsNullOrEmpty(strTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += string.Format("  and goal.Goal_EndTime BETWEEN '{0} 00:00:00' and '{1} 23:59:59'", strTime, endTime);
            }





            var query = Context.GoalQuery.FromSql(sql).ToList();

            return query;
        }

        /// <summary>
        /// 获取目标跟踪所需数据
        /// </summary>
        /// <returns></returns>
        public List<TargetTrack> TargetTrackList()
        {
            var query = Context.TargetTracks.FromSql("select role.Role_Id, role.Role_Name," +
                          "SUM(case when goalstate.GoalState_Id = 5 or goalstate.GoalState_Id = 3  then 1 ELSE 0 END) AS Done,COUNT(*) as Num," +
                          "(SUM(case when  goalstate.GoalState_Id = 5 or goalstate.GoalState_Id = 3  then 1 ELSE 0 END) / COUNT(*) * 100) as Percentage " +
                          "from goal join role on goal.Role_Id = role.Role_Id join goalstate on goal.GoalState_Id = goalstate.GoalState_Id GROUP BY role.Role_Id  ORDER BY Percentage DESC;").ToList();


            return query;
        }


    }
}
