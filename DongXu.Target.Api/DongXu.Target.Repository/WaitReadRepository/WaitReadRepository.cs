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

        /// <summary>
        /// 运行情况
        /// </summary>
        /// <returns></returns>
        public List<GoalStateGoal> GetRunConditionList()
        {
            var list = context.GoalStateGoal.FromSql("SELECT ROUND(COUNT(a.GoalState_Id)/6*100,2) as percent,COUNT(a.GoalState_Id) as count ,b.GoalState_Name,b.GoalState_Explain FROM goal a INNER JOIN goalstate b on a.GoalState_Id = b.GoalState_Id GROUP BY b.GoalState_Name").ToList();
            return list;
        }

        public List<IntergalUser> GetIntergalData(int id)
        {
            //var tmpuser = (from s in context.Userrole where s.UserId == id select s).ToList();  //获取到用户角色
            //int roleid = 0;
            //foreach (var item in tmpuser)
            //{
            //    roleid = item.RoleId;
            //}
            //var idenmodel = (from s in context.Role where s.RoleId == id select s).ToList();
            //int idenid = 0;
            //foreach (var item in idenmodel)
            //{
            //    idenid = item.RoleIdentify;
            //}
            //var list = (from s in context.Role where s.RoleIdentify > idenid select s).ToList();  //获取到下属角色信息
            //List<int> roleidlist = new List<int>();

            //foreach (var item in list)
            //{
            //    roleidlist.Add(item.RoleId);  //获取到角色id
            //}
            //List<int> useridlist = new List<int>();

            //foreach (var item in roleidlist)
            //{
            //    useridlist.Add(from s in context.Userrole where s.RoleId == item select s.UserId);
            //}
            //string userid = "";
            //foreach (var item in useridlist)
            //{
            //    userid += item;  //获取到用户id
            //}
            //List<IntergalUser> intergalUsers = new List<IntergalUser>();        
            //foreach (var item in userid)
            //{
            //    IntergalUser intergalUser = new IntergalUser();
            //    intergalUser.UserName = (from s in context.User where s.UserId == item select s.UserName).ToString();
            //    intergalUser.IntegralNum = Convert.ToInt32((from s in context.Integral where s.UserId == item select s.IntegralNum));
            //    intergalUser.UserId = item;
            //    intergalUsers.Add(intergalUser);
            //}
            //return intergalUsers;
            return null;


            //for (int i = 0; i < userid.Length; i++)
            //{
            //    //var interlist = (from s in context.Integral
            //    //                 join User in context.User on s.UserId equals User.UserId
            //    //                 where s.UserId == userid[i]
            //    //                 select new IntergalUser
            //    //                 {
            //    //                      UserName=User.UserName,
            //    //                      IntegralNum=s.IntegralNum,

            //    //                 })
            //}

        }
    }
}
