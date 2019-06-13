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
                            GoalId = s.GoalId,
                            GoalName = s.GoalName,
                            GoalStateName = Goalstate.GoalStateName,
                            IndexLevelGrade = Indexlevel.IndexLevelGrade,
                            GoalChargePeople = s.GoalChargePeople,
                            GoalEndTime = s.GoalEndTime,
                            FeedbackNowEvolve = Feedback.FeedbackNowEvolve,
                            FeedbackId = Feedback.FeedbackId
                        }).ToList();
            return list;
        }

        /// <summary>
        /// 根据登录人的id查询用户角色表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Role> GetUserRole(int id)
        {
            int roleid = 0;
            var list = (from s in context.Userrole where s.UserId == id select s).ToList();
            foreach (var item in list)
            {
                roleid = item.RoleId;
            }
            var role = (from s in context.Role where s.RoleId == roleid select s).ToList();
            return role;
        }

        /// <summary>
        /// 获取积分列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<IntergalUser> GetIntegralList(List<int> list)
        {
            //List<Integral> interlist = new List<Integral>();
            //List<Userrole> userrole = new List<Userrole>();
            //var roleid = from s in list select s;   
            //foreach (var item in roleid)
            //{
            //    var user = (from s in context.Userrole
            //                   where s.RoleId == item
            //                   select s).ToList();
            //    foreach (var us in user)
            //    {
            //        int userid = us.UserId;
            //        var userinter = (from s in context.Integral
            //                         join User in context.User on s.UserId equals User.UserId
            //                         where s.UserId == userid
            //                         select new IntergalUser()
            //                         {
            //                             UserId=s.UserId,
            //                             UserName=User.UserName,
            //                             IntegralNum=s.IntegralNum
            //                         }).ToList();
            //    }  
            //}
            List<IntergalUser> interlist = new List<IntergalUser>();
            foreach (var item in list)
            {
                interlist = (from s in context.Integral
                             join User in context.User on s.UserId equals User.UserId
                             join Userrole in context.Userrole on item equals Userrole.RoleId
                             select new IntergalUser
                             {
                                 IntegralNum = s.IntegralNum,
                                 UserName = User.UserName,
                             }).ToList();
            }
            return interlist;
        }
    }
}
