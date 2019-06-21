using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IDecision;
using DongXu.Target.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.DecisionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TLPercentageController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ITLPercentageRepository TLPercentageRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public TLPercentageController(ITLPercentageRepository tlpercentage)
        { 
            TLPercentageRepository = tlpercentage;
        }

        /// <summary>
        /// 各子公司红绿灯百分比
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetITLPercentageList")]
        public List<TLPercentage> GetITLPercentageList()
        {
            var list = TLPercentageRepository.GetITLPercentageList();
            return list; 
        }

    }
}