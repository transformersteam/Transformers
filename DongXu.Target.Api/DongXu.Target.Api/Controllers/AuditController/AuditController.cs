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
        [HttpGet("GetAuditDtoList")]
        public AuditDto GetAuditDtoList(int userId,int goalId)
        {
            AuditDto list = _iauditRepository.GetAuditDtoList(userId, goalId);
            return list;
        }
    }
}