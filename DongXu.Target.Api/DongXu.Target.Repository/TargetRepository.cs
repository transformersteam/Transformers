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
        public List<GoalQuery> GoalQueryList()
        {

            string sql = string.Format("select goal.Goal_Name,indexlevel.IndexLevel_Grade,goaltype.GoalType_Name, " +
                "role.Role_Name,`user`.User_Name, goal.Goal_EndTime, feedback.Feedback_NowEvolve from goal " +
                "join indexlevel on goal.IndexLevel_Id = indexlevel.IndexLevel_Id " +
                "join goaltype on goal.GoalType_Id = goaltype.GoalType_Id " +
                "join role on Goal_DutyCommanyId = role.Role_Id " +
                "join user on Goal_DutyUserId = user.User_Id join feedback on goal.Feedback_Id = feedback.Feedback_Id");

            var query = Context.GoalQuery.FromSql(sql).ToList();

            return query;
        }

    }
}
