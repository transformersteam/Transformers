using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
        /// 根据登录人的id获取积分列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetUserIntergal(int id)
        {
            MySqlParameter sqlParameters = new MySqlParameter("@User_Id", MySqlDbType.Int32);
            sqlParameters.Value = id;
            var model = DbProcedureHelper.ExecuteDt("P_IntegralList", sqlParameters);
            return model;
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

        /// <summary>
        /// 根据目标id查询目标详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TargetDetails> GetTargetDetailById(int id)
        {
            var list = context.TargetDetails.FromSql($"SELECT c.GoalType_Name,d.Integral_Num,h.IndexLevel_Grade,g.Frequency_Name,e.Role_Name,a.Goal_ChargePeople,a.Goal_Informant,a.Goal_Organiser, a.Goal_CreateTime, a.Goal_EndTime, a.Goal_Weight,f.File_Name FROM goal a INNER JOIN goaltype b on a.GoalType_Id = b.GoalType_Id INNER JOIN goaltype c on c.GoalType_PId = b.GoalType_Id INNER JOIN Integral d on a.IndexLevel_Id = d.Integral_Id INNER JOIN IndexLevel h on h.IndexLevel_Id = a.IndexLevel_Id INNER JOIN role e on a.Goal_DutyCommanyId = e.Role_Id INNER JOIN files f on f.Goal_Id = a.File_Id INNER JOIN Frequency g on g.Frequency_Id = a.Frequency_Id WHERE a.Goal_Id = {id}").ToList();
            return list;
        }

        /// <summary>
        /// 红绿灯状态表格
        /// </summary>
        /// <returns></returns>
        public List<BusinessStateTable> GetBusinessStateTable()
        {
            var list = context.BusinessStateTable.FromSql("SELECT a.goal_id ,b.role_Name,a.goalstate_id,COUNT(a.goalstate_id) as statecount FROM goal a INNER JOIN role b on a.Goal_DutyCommanyId = b.role_id WHERE a.goalstate_id = 1 || a.goalstate_id = 3 || a.goalstate_id = 5").ToList();
            return list;
        }
    }
}
