using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.ICompany;
using DongXu.Target.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.CompanyIntegralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyIntegralController : ControllerBase
    {

        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ICompanyIntegralRepository CompanyIntegralRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        public CompanyIntegralController(ICompanyIntegralRepository companyintegral)
        {
            CompanyIntegralRepository = companyintegral;
        }

        /// <summary>
        /// 积分获取
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCompanyIntegralList")]
        public List<CompanyIntegral> GetCompanyIntegralList() 
        {
            var list = CompanyIntegralRepository.GetCompanyIntegralList();
            return list;
        }

        /// <summary>
        /// 第一个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightOneList")]
        public List<TrafficLight> GetTrafficLightOnelList() 
        {
            var list = CompanyIntegralRepository.GetTrafficLightOneList();
            return list;
        }

        /// <summary>
        /// 第二个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightTwolList")]
        public List<TrafficLight> GetTrafficLightTwolList()
        {
            var list = CompanyIntegralRepository.GetTrafficLightOneList();
            return list;
        }

        /// <summary>
        /// 第三个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightThreelList")]
        public List<TrafficLight> GetTrafficLightThreelList()
        {
            var list = CompanyIntegralRepository.GetTrafficLightOneList();
            return list;
        }

        /// <summary>
        /// 第四个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightFourlList")] 
        public List<TrafficLight> GetTrafficLightFourlList()
        {
            var list = CompanyIntegralRepository.GetTrafficLightOneList();
            return list;
        }
    }
}