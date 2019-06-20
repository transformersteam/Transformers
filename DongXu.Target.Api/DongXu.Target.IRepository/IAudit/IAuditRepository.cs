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
        int Audit(Appractivity appractivity);
    }
}
