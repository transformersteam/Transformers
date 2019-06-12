using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace DongXu.Target.Repository.WaitReadRepository
{
    public class WaitReadRepository : IWaitReadRepository
    {
        dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 根据登录人的id查询待办列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WaitRead> GetWaitReadList(int id)
        {
            var list = (from s in context.Goal
                        join Attention in context.Attention on s.GoalId equals Attention.GoalId
                        join User in context.User on Attention.UserId equals User.UserId
                        join Indexlevel in context.Indexlevel on s.IndexLevelId equals Indexlevel.IndexLevelId
                        join Goalstate in context.Goalstate on s.GoalStateId equals Goalstate.GoalStateId
                        join Feedback in context.Feedback on s.GoalId equals Feedback.GoalId
                        where Attention.UserId == id
                        select new WaitRead
                        {
                            GoalId= s.GoalId,
                            GoalName=s.GoalName,
                            GoalStateName=Goalstate.GoalStateName,
                            IndexLevelGrade=Indexlevel.IndexLevelGrade,
                            GoalChargePeople=s.GoalChargePeople,
                            GoalEndTime=s.GoalEndTime,
                            FeedbackNowEvolve=Feedback.FeedbackNowEvolve,
                            FeedbackId=Feedback.FeedbackId
                        }).ToList();
            return list;
        }
    }
}
