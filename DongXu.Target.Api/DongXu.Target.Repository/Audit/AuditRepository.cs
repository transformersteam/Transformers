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
        dxdatabaseContext db = new dxdatabaseContext();
        /// <summary>
        /// 审批详情
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public AuditDto GetAuditDtoList(int userId,int goalId)
        {
            AuditDto auditDtoList = db.AuditDto.FromSql($"select a.Goal_Id,a.Goal_Name,a.GoalState_Id,a.Role_Id,a.GoalType_Id,a.IndexLevel_Id,a.Frequency_Id,a.Goal_StartTime,a.Goal_EndTime,a.Goal_Period,a.Goal_Unit,a.Goal_ChargePeople,a.Goal_Weight,a.Goal_Informant,a.Goal_Organiser,a.Goal_Formula,a.Goal_Sources,a.File_Id,a.Goal_CreateTime,a.Business_State,a.Feedback_Id,a.Goal_DutyUserId,a.Goal_DutyCommanyId,a.Goal_ParentId,b.GoalType_Name,c.IndexLevel_Grade,d.Frequency_Name,e.Role_Name,f.Feedback_WorkEvolve,f.Feedback_DayEvolve,f.Feedback_Question,f.Feedback_Measure,f.Feedback_CoordinateMatters,f.Feedback_NowEvolve,h.File_Name,h.File_Url,g.State_Id,g.ApprActivity_Opinion,g.Next_Id,g.ApprActivity_CreateTime,g.ApprConfiguration_Id,g.ApprActivity_IsExecute,g.ApprActivity_Id,i.GoalState_Name,i.GoalState_Explain,i.GoalState_CreateTime from goal a inner join goaltype b on a.GoalType_Id = b.GoalType_Id INNER JOIN indexlevel c on a.IndexLevel_Id = c.IndexLevel_Id INNER JOIN frequency d on a.Frequency_Id= d.Frequency_Id INNER JOIN role e on a.Goal_DutyCommanyId = e.Role_Id INNER JOIN feedback f on a.Feedback_Id =f.Feedback_Id INNER JOIN appractivity g on a.Goal_Id = g.Goal_Id inner join files h on a.Goal_Id = h.Goal_Id INNER JOIN goalstate i on a.GoalState_Id = i.GoalState_Id where g.User_Id = {userId} and a.Goal_Id = {goalId}").FirstOrDefault();
            return auditDtoList;
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public List<ApprDto> GetApprDtoList(int goalId)
        {
            List<ApprDto> apprtoList = db.ApprDto.FromSql($"select b.User_Name,a.ApprActivity_IsExecute,a.Next_Id from appractivity a inner join `user` b on a.User_Id=b.User_Id where a.Goal_Id={goalId} ORDER BY a.ApprActivity_Id ").ToList();
            return apprtoList;
        }
        /// <summary>
        /// 审批意见
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public List<ApprOpinion> GetApprOpinionList(int goalId)
        {
            List<ApprOpinion> apprOpinion = db.ApprOpinion.FromSql($"select b.User_Name,a.ApprActivity_IsExecute,a.ApprActivity_Opinion,a.ApprActivity_CreateTime from appractivity a inner join `user` b on a.User_Id=b.User_Id where a.Goal_Id={goalId} and a.ApprActivity_IsExecute=1 ORDER BY a.ApprActivity_Id ").ToList();
            return apprOpinion;
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public List<ApprOpinion> GetApprFlowList(int goalId)
        {
            List<ApprOpinion> apprOpinion = db.ApprOpinion.FromSql($"select b.User_Name,a.ApprActivity_IsExecute,a.ApprActivity_Opinion,a.ApprActivity_CreateTime from appractivity a inner join `user` b on a.User_Id=b.User_Id where a.Goal_Id={goalId} ORDER BY a.ApprActivity_Id ").ToList();
            return apprOpinion;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="appractivity"></param>
        /// <returns></returns>
        public int Audit(Appractivity appractivity)
        {
            if(appractivity.ApprActivityIsExecute==1)
            {
                var oldappra = db.Appractivity.Where(m => m.ApprActivityId == appractivity.ApprActivityId).FirstOrDefault();
                if (oldappra != null)
                {
                    oldappra.ApprActivityOpinion = appractivity.ApprActivityOpinion;
                    oldappra.ApprActivityIsExecute = appractivity.ApprActivityIsExecute;
                    oldappra.StateId = 0;
                    var newappra = db.Appractivity.Where(m => m.ApprConfigurationId == appractivity.NextId).FirstOrDefault();
                    if (newappra != null)
                    {
                        newappra.StateId = 1;
                    }
                    //if(appractivity.ApprActivityIsExecute==0)
                    //{
                    //     db.Appractivity.Where(m => m.ApprActivityId >= appractivity.ApprActivityId && m.GoalId == appractivity.GoalId);
                    //    int i = db.Database.ExecuteSqlCommand("update Appractivity set  where ApprActivityId");

                    //}
                    return db.SaveChanges();
                }
            }
            else
            {
                var oldappra = db.Appractivity.Where(m => m.ApprActivityId == appractivity.ApprActivityId).FirstOrDefault();
                if (oldappra != null)
                {
                    oldappra.ApprActivityOpinion = appractivity.ApprActivityOpinion;
                    oldappra.ApprActivityIsExecute = appractivity.ApprActivityIsExecute;
                    oldappra.StateId = 0;
                    //if(appractivity.ApprActivityIsExecute==0)
                    //{
                    //     db.Appractivity.Where(m => m.ApprActivityId >= appractivity.ApprActivityId && m.GoalId == appractivity.GoalId);
                    //    int i = db.Database.ExecuteSqlCommand("update Appractivity set  where ApprActivityId");

                    //}
                    int i = db.Database.ExecuteSqlCommand($"update Appractivity set  ApprActivityIsExecute=0 where ApprActivityId>{appractivity.ApprActivityId} and GoalId={appractivity.GoalId}");
                    return db.SaveChanges();
                }
            }
            return 0;
        }
        /// <summary>
        /// 添加到配置表
        /// </summary>
        /// <param name="apprconfigurationDto"></param>
        /// <returns></returns>
        public int AddrConfiguration(int[] User_Id, int Goal_Id)
        {
            int addrConfigurationId = 0;
            var GoalCreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd"));
            for (int i=0;i< User_Id.Length;i++)
            {
                if(i==0)
                {
                    Apprconfiguration apprconfiguration = new Apprconfiguration();
                    apprconfiguration.UserId = User_Id[i];
                    apprconfiguration.GoalId = Goal_Id;
                    apprconfiguration.ApprConfigurationStateid = 1;
                    apprconfiguration.RoleId = 0;
                    apprconfiguration.ApprConfigurationIsEnable = 1;
                    apprconfiguration.ApprConfigurationCreateTime = GoalCreateTime;
                    db.Apprconfiguration.Add(apprconfiguration);
                    db.SaveChanges();
                    addrConfigurationId = apprconfiguration.ApprConfigurationId;
                    
                }
                else
                {
                    Apprconfiguration apprconfiguration = new Apprconfiguration();
                    apprconfiguration.UserId = User_Id[i];
                    apprconfiguration.GoalId = Goal_Id;
                    apprconfiguration.ApprConfigurationStateid = 0;
                    apprconfiguration.ApprConfigurationNextid = 0;
                    apprconfiguration.RoleId = 0;
                    apprconfiguration.ApprConfigurationIsEnable = 1;
                    apprconfiguration.ApprConfigurationCreateTime = GoalCreateTime;
                    db.Apprconfiguration.Add(apprconfiguration);
                    db.SaveChanges();
                    int j = db.Database.ExecuteSqlCommand($"update apprconfiguration set ApprConfiguration_Nextid={apprconfiguration.ApprConfigurationId} WHERE Goal_Id={Goal_Id} and ApprConfiguration_Id={addrConfigurationId}");
                    if(j==0)
                    {
                        return 0;
                    }
                    addrConfigurationId = apprconfiguration.ApprConfigurationId;
                }
                
            }
            int f=db.Database.ExecuteSqlCommand($"insert into appractivity(User_Id, Goal_Id, Next_Id, State_Id,ApprConfiguration_Id) select User_Id, Goal_Id, ApprConfiguration_Nextid, ApprConfiguration_Stateid, ApprConfiguration_Id from apprconfiguration where Goal_Id={Goal_Id}");
            return f;
        }
    }
}
