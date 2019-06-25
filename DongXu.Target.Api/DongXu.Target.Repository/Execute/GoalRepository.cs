using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.Execute
{
    public class GoalRepository : IGoalRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 待办事项集合
        /// </summary>
        /// <returns></returns>
        public List<BackLog> GetGoalList(int userid)
        {
            var query = context.BackLog.FromSql(
                    $"select goal.Goal_Name,frequency.Frequency_Name,goaltype.GoalType_Name,indexlevel.IndexLevel_Grade,goal.Goal_ChargePeople, goal.Goal_EndTime,feedback.Feedback_NowEvolve, goalstate.GoalState_Name from goal join goaltype on goal.GoalType_Id = goaltype.GoalType_Id join frequency on goal.Frequency_Id = frequency.Frequency_Id join indexlevel on goal.IndexLevel_Id = indexlevel.IndexLevel_Id join feedback on goal.Feedback_Id = feedback.Feedback_Id join goalstate on goal.GoalState_Id = goalstate.GoalState_Id join attention on goal.Goal_Id = attention.Goal_Id  where attention.User_Id = { userid}").ToList();
            return query;
        }

        //    /// <summary>
        //    /// 待办事项集合
        //    /// </summary>
        //    /// <returns></returns>
        //    public List<BackLog> GetGoalInfo(int userid)
        //    {
        //        var list = (from s in context.Goal
        //                    join Goaltype in context.Goaltype
        //                    on s.GoalTypeId equals Goaltype.GoalTypeId
        //                    join Frequency in context.Frequency
        //                    on s.FrequencyId equals Frequency.FrequencyId
        //                    join Indexlevel in context.Indexlevel
        //                        on s.IndexLevelId equals Indexlevel.IndexLevelId
        //                    join Feedback in context.Feedback
        //                        on s.FeedbackId equals Feedback.FeedbackId
        //                    join Goalstate in context.Goalstate
        //                        on s.GoalStateId equals Goalstate.GoalStateId
        //                    join Role in context.Role
        //                        on s.RoleId equals Role.RoleId
        //                    join Userrole in context.Userrole
        //                        on Role.RoleId equals Userrole.RoleId
        //                    join User in context.User
        //                        on Userrole.UserId equals User.UserId
        //                    where User.UserId == userid
        //                    select new BackLog
        //                    {
        //                        GoalName = s.GoalName,
        //                        FrequencyName = Frequency.FrequencyName,
        //                        GoalTypeName = Goaltype.GoalTypeName,
        //                        IndexLevelGrade = Indexlevel.IndexLevelGrade,
        //                        GoalChargePeople = s.GoalChargePeople,
        //                        GoalEndTime = s.GoalEndTime,
        //                        FeedbackNowEvolve = Feedback.FeedbackNowEvolve,
        //                        GoalStateName = Goalstate.GoalStateName
        //                    }).ToList();
        //        return list;
        //    }

        //    /// <summary>
        //    /// 待办事项显示
        //    /// </summary>
        //    /// <returns></returns>
        //    public GoalPageination GetGoalList(int userid,int pageindex = 1, int pagesize = 3)
        //    {
        //        using (context)
        //        {
        //            var total = GetGoalInfo(userid).Count;//获取总数
        //            var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));//计算最大页数
        //            var goalList = GetGoalInfo(userid).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();//一页显示多少数据

        //            //赋值
        //            var goalpageination = new GoalPageination
        //            {
        //                maxPage = int.Parse(maxpage.ToString()),
        //                total = total,
        //                GoalList = goalList
        //            };
        //            return goalpageination;
        //        }
        //    }
        //}
    }
}
