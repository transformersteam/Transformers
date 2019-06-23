using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
namespace DongXu.Target.IRepository
{
    public interface IAuditRepository
    {
        /// <summary>
        /// 审批详情
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goalId"></param>
        /// <returns></returns>
        AuditDto GetAuditDtoList(int userId,int goalId);
        /// <summary>
        /// 确认流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        List<ApprDto> GetApprDtoList(int goalId);
        /// <summary>
        /// 审批意见
        /// </summary>
        /// <param name="goalId">目标id</param>
        /// <param name="isExecute">审批状态</param>
        /// <returns></returns>
        List<ApprOpinion> GetApprOpinionList(int goalId);
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="appractivity"></param>
        /// <returns></returns>
        int Audit(AuditauditDto appractivity);
        /// <summary>
        /// 添加到配置表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        int AddrConfiguration(int[] User_Id,int Goal_Id);
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        List<ApprOpinion> GetApprFlowList(int goalId);
        /// <summary>
        /// 添加进展表
        /// </summary>
        /// <returns></returns>
        int AddFeedBack(Feedback feedback);
        /// <summary>
        /// 绑定左侧
        /// </summary>
        /// <returns></returns>
        List<Power> GetPowersByPid(int Power_PId);
    }
}
