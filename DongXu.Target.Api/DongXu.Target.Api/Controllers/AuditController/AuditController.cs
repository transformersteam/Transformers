﻿using System;
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
    }
}