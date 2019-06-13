using DongXu.Target.IRepository.IExecute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.Repository.Execute
{
    public class ResponsibilityRepository: IResponsibilityRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 主责事项显示
        /// </summary>
        /// <returns></returns>
        public List<MainResponsibility> GetMainResponsibilityInfo()
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
                select new MainResponsibility
                {
                    GoalName = s.GoalName,
                    IndexLevelGrade = Indexlevel.IndexLevelGrade,
                    GoalChargePeople = s.GoalChargePeople,
                    GoalEndTime = s.GoalEndTime,
                    FeedbackNowEvolve = Feedback.FeedbackNowEvolve,
                    GoalStateName = Goalstate.GoalStateName
                }).ToList();
            return list;
        }

        /// <summary>
        /// 主责事项分页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public MainResponsibilityPageination GetMainResponsibilityList(int pageindex = 1, int pagesize = 3)
        {
            using (context)
            {
                var total = GetMainResponsibilityInfo().Count;//获取总数
                var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));//计算最大页数
                var mainresponsibilityList = GetMainResponsibilityInfo().Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();//一页显示多少数据
                 
                //赋值
                var mainresponsibilitypageination = new MainResponsibilityPageination
                {
                    maxPage = int.Parse(maxpage.ToString()),
                    total = total,
                    MainResponsibilityList = mainresponsibilityList
                };
                return mainresponsibilitypageination;
            }
        }
    }
}
