using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
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
        public List<BackLog> GetGoalInfo()
        {
            var list = (from s in context.Goal
                        join Goaltype in context.Goaltype
                        on s.GoalTypeId equals Goaltype.GoalTypeId
                        join Frequency in context.Frequency
                        on s.FrequencyId equals Frequency.FrequencyId
                        join Indexlevel in context.Indexlevel
                            on s.IndexLevelId equals Indexlevel.IndexLevelId
                        join Feedback in context.Feedback
                            on s.FeedbackId equals Feedback.FeedbackId
                        join Goalstate in context.Goalstate
                            on s.GoalStateId equals Goalstate.GoalStateId
                        select new BackLog
                        {
                            GoalName=s.GoalName,
                            FrequencyName= Frequency.FrequencyName,
                            GoalTypeName= Goaltype.GoalTypeName,
                            IndexLevelGrade= Indexlevel.IndexLevelGrade,
                            GoalChargePeople=s.GoalChargePeople,
                            GoalEndTime=s.GoalEndTime,
                            FeedbackNowEvolve= Feedback.FeedbackNowEvolve,
                            GoalStateName= Goalstate.GoalStateName
                        }).ToList();
            return list;
        }

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        public GoalPageination GetGoalList(int pageindex = 1, int pagesize = 3)
        {
            using (context)
            {
                var total = GetGoalInfo().Count;//获取总数
                var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));//计算最大页数
                var goalList = GetGoalInfo().Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();//一页显示多少数据

                //赋值
                var goalpageination = new GoalPageination
                {
                    maxPage = int.Parse(maxpage.ToString()),
                    total = total,
                    GoalList = goalList
                };
                return goalpageination;
            }
        }
    }
}
