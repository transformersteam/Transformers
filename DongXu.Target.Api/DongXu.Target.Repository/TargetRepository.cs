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
        public List<GoalQuery> GoalQueryList(string goalname, int goaltype, int goalleave, string goalrole, string goaluser, string strTime, string endTime)
        {

            string sql = string.Format("select goal.Goal_Name,indexlevel.IndexLevel_Grade,goaltype.GoalType_Name, " +
                "role.Role_Name,`user`.User_Name, goal.Goal_EndTime, feedback.Feedback_NowEvolve from goal " +
                "join indexlevel on goal.IndexLevel_Id = indexlevel.IndexLevel_Id " +
                "join goaltype on goal.GoalType_Id = goaltype.GoalType_Id " +
                "join role on Goal_DutyCommanyId = role.Role_Id " +
                "join user on Goal_DutyUserId = user.User_Id join feedback on goal.Feedback_Id = feedback.Feedback_Id where 1=1 ");

            if (!string.IsNullOrEmpty(goalname))
            {
                sql += string.Format("  and goal.Goal_Name like '%{0}%'",goalname);
            }
            if (goaltype != 0)
            {
                sql += string.Format(" and goaltype.GoalType_Id={0}",goaltype);
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
            if (!string.IsNullOrEmpty(strTime)&& !string.IsNullOrEmpty(endTime))
            {
                sql += string.Format("  and goal.Goal_EndTime BETWEEN '{0} 00:00:00' and '{1} 23:59:59'", strTime,endTime);
            }




            var query = Context.GoalQuery.FromSql(sql).ToList();

            return query;
        }

    }
}
