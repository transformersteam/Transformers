using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;
using System.Linq;
using DongXu.Target.IRepository;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace DongXu.Target.Repository
{
    public class AuditRepository : IAuditRepository
    {
        public AuditDto GetAuditDtoList(int userId,int goalId)
        {
            dxdatabaseContext db = new dxdatabaseContext();

            AuditDto auditDtoList = db.AuditDto.FromSql($"select a.Goal_Id,a.Goal_Name,a.GoalState_Id,a.Role_Id,a.GoalType_Id,a.IndexLevel_Id,a.Frequency_Id,a.Goal_StartTime,a.Goal_EndTime,a.Goal_Period,a.Goal_Unit,a.Goal_ChargePeople,a.Goal_Weight,a.Goal_Informant,a.Goal_Organiser,a.Goal_Formula,a.Goal_Sources,a.File_Id,a.Goal_CreateTime,a.Business_State,a.Feedback_Id,a.Goal_DutyUserId,a.Goal_DutyCommanyId,a.Goal_ParentId,b.GoalType_Name,c.IndexLevel_Grade,d.Frequency_Name,e.Role_Name,f.Feedback_WorkEvolve,f.Feedback_DayEvolve,f.Feedback_Question,f.Feedback_Measure,f.Feedback_CoordinateMatters,f.Feedback_NowEvolve,h.File_Name,h.File_Url,g.ApprActivity_CreateTime,i.GoalState_Name,i.GoalState_Explain,i.GoalState_CreateTime from goal a inner join goaltype b on a.GoalType_Id = b.GoalType_Id INNER JOIN indexlevel c on a.IndexLevel_Id = c.IndexLevel_Id INNER JOIN frequency d on a.Frequency_Id= d.Frequency_Id INNER JOIN role e on a.Goal_DutyCommanyId = e.Role_Id INNER JOIN feedback f on a.Feedback_Id =f.Feedback_Id INNER JOIN appractivity g on a.Goal_Id = g.Goal_Id inner join files h on a.Goal_Id = h.Goal_Id INNER JOIN goalstate i on a.GoalState_Id = i.GoalState_Id where g.User_Id = {userId} and a.Goal_Id = {goalId}").FirstOrDefault();
            return auditDtoList;
        }
    }
}
