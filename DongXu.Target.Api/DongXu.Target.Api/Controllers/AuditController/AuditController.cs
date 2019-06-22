using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DongXu.Target.IRepository;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using MySql.Data.MySqlClient;
using System.Data;
namespace DongXu.Target.Api.Controllers.AuditController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IAuditRepository _iauditRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="organization"></param>
        public AuditController(IAuditRepository auditRepository)
        {
            _iauditRepository = auditRepository;
        }
        /// <summary>
        /// 审批详情
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goalId"></param>
        /// <returns></returns>
        [HttpGet("GetAuditDtoList")]
        public AuditDto GetAuditDtoList(int userId,int goalId)
        {
            AuditDto list = _iauditRepository.GetAuditDtoList(userId, goalId);
            return list;
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        [HttpGet("GetApprDtoList")]
        public List<ApprDto> GetApprDtoList(int goalId)
        {
            return _iauditRepository.GetApprDtoList(goalId);
        }
        /// <summary>
        /// 审批意见
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        [HttpGet("GetApprOpinionList")]
        public List<ApprOpinion> GetApprOpinionList(int goalId)
        {
            return _iauditRepository.GetApprOpinionList(goalId);
        }
        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("Audit")]
        public int Audit([FromBody]string json)
        {
            Appractivity appractivity = Newtonsoft.Json.JsonConvert.DeserializeObject<Appractivity>(json);
            return _iauditRepository.Audit(appractivity);
        }
        /// <summary>
        /// 添加到配置表
        /// </summary>
        /// <param name="User_Id"></param>
        /// <param name="Goal_Id"></param>
        /// <returns></returns>
        [HttpPost("AddrConfiguration")]
        public int AddrConfiguration([FromBody]string json)
        {
            ApprconfigurationDto apprconfigurationDto = Newtonsoft.Json.JsonConvert.DeserializeObject<ApprconfigurationDto>(json);
            string s = apprconfigurationDto.AuditValue;
            string userId = s.Substring(0, s.Length - 1);
            string[] SuserId=userId.Split(',');
            int[] User_Id = new int[SuserId.Length];
            for (int i = 0; i < SuserId.Length; i++)
            {
                User_Id[i] = int.Parse(SuserId[i]);
            }
            int Goal_Id = apprconfigurationDto.GoalId;
            return _iauditRepository.AddrConfiguration(User_Id, Goal_Id);
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        [HttpPost("GetApprFlowList")]
        public List<ApprOpinion> GetApprFlowList(int goalId)
        {
            return _iauditRepository.GetApprFlowList(goalId);
        }
    }
}