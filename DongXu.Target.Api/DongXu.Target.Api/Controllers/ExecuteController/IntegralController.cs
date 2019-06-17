using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.ExecuteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegralController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IIntegralRepository IntegralRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        public IntegralController(IIntegralRepository integral)  
        {
            IntegralRepository = integral;
        }

        /// <summary>
        /// 积分获取
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetIntegralList")]
        public List<NumQuery> GetIntegralList()
        {
            var list = IntegralRepository.GetIntegralList();
            return list;
        }
    }
}