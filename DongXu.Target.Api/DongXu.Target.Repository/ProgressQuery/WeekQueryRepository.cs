using DongXu.Target.IRepository.IProgressQuery;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.ProgressQuery
{
    /// <summary>
    /// 周报查询
    /// </summary>
    public class WeekQueryRepository : IWeekQueryRepository
    {
        dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 周报查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goalName"></param>
        /// <param name="typeId"></param>
        /// <param name="leaveId"></param>
        /// <param name="stateId"></param>
        /// <param name="dutyCommanyName"></param>
        /// <param name="dutyUserName"></param>
        /// <param name="goaltime"></param>
        /// <returns></returns>
        public PageData<WeekData> GetWeekList(int pageIndex,int pageSize,string goalName,int typeId,int leaveId,int stateId,string dutyCommanyName,string dutyUserName,string goaltime)
        {
            string sql = "SELECT a.goal_id,a.goal_name,b.indexlevel_grade,d.goaltype_name,c.goaltype_name as GoalChildName,a.frequency_id,a.GoalState_Id,e.role_name,f.user_name,YEAR(a.goal_createtime) as goalyear,a.Goal_StartTime,g.Feedback_DayEvolve,a.Goal_EndTime FROM goal a INNER JOIN indexlevel b on a.IndexLevel_Id = b.IndexLevel_Id INNER JOIN goaltype c on a.GoalType_Id = c.GoalType_PId INNER JOIN goaltype d on c.GoalType_PId = d.GoalType_Id INNER JOIN role e on a.Goal_DutyCommanyId=e.Role_Id INNER JOIN `user` f on a.Goal_DutyUserId = f.User_Id INNER JOIN feedback g on a.Feedback_Id = g.Feedback_Id WHERE a.Frequency_Id=1";
            string sqlCount= "SELECT count(a.goal_id) FROM goal a INNER JOIN indexlevel b on a.IndexLevel_Id = b.IndexLevel_Id INNER JOIN goaltype c on a.GoalType_Id = c.GoalType_PId INNER JOIN goaltype d on c.GoalType_PId = d.GoalType_Id INNER JOIN role e on a.Goal_DutyCommanyId e.Role_Id INNER JOIN `user` f on a.Goal_DutyUserId = f.User_Id INNER JOIN feedback g on a.Feedback_Id = g.Feedback_Id WHERE a.Frequency_Id=1";
            if(!string.IsNullOrWhiteSpace(goalName))
            {
                sql += $" and a.Goal_name like '%{goalName}%'";
                sqlCount+= $" and a.Goal_name like '%{goalName}%'";
            }
            if(typeId != 0)
            {
                sql+= $" and c.GoalType_Id={typeId}";
                sqlCount += $" and c.GoalType_Id={typeId}";
            }
            if(leaveId!=0)
            {
                sql += $" and b.IndexLevel_Id={leaveId}";
                sqlCount += $" and b.IndexLevel_Id={leaveId}";
            }
            if(stateId!=0)
            {
                sql += $" and a.GoalState_Id={stateId}";
                sqlCount += $" and a.GoalState_Id={stateId}";
            }
            if(!string.IsNullOrWhiteSpace(dutyCommanyName))
            {
                sql += $" and e.Role_Name like '%{dutyCommanyName}%'";
                sqlCount += $" and e.Role_Name like '%{dutyCommanyName}%'";
            }
            if(!string.IsNullOrWhiteSpace(dutyUserName))
            {
                sql += $" and f.User_Name like '%{dutyUserName}%'";
                sqlCount += $" and e.User_Name like '%{dutyUserName}%'";
            }
            if(!string.IsNullOrWhiteSpace(goaltime))
            {
                sql += $" and {goaltime} between a.Goal_StartTime and a.Goal_EndTime";
                sqlCount += $" and {goaltime} between a.Goal_StartTime and a.Goal_EndTime'";
            }
            sql += $" and a.Goal_Id>({pageIndex-1}*{pageSize}) order by a.Goal_Id asc limit {pageSize}";
            PageData<WeekData> pageData = new PageData<WeekData>();
            var list = context.WeekData.FromSql(sql.ToString()).ToList();
            var count = context.WeekData.FromSql(sqlCount);
            pageData.GetData = list;
            pageData.TotalCount = list.Count();
            return pageData;
        }
    }
}
