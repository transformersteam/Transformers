using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.TrafficLightRanking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.TrafficLightRankingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficLightRankingController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ITrafficLightRankingRepository TrafficLightRankingRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        public TrafficLightRankingController(ITrafficLightRankingRepository trafficlightranking) 
        {
            TrafficLightRankingRepository = trafficlightranking;  
        }

        /// <summary>
        /// 各子公司红绿灯百分比
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightRankingList")]
        public DataTable GetTrafficLightRankingList()
        {
            var list = TrafficLightRankingRepository.GetTrafficLightRankingList();
            return list; 
        }
    }
}