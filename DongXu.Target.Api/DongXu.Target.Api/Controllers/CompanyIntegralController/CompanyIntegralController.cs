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
        [HttpGet("GetTrafficLightSSSList")]
        public List<TrafficLight> GetTrafficLightSSSList()   
        {
            var list = CompanyIntegralRepository.GetTrafficLightSSSList();
            return list;
        }

        /// <summary>
        /// 第二个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightSSList")]
        public List<TrafficLight> GetTrafficLightSSList()
        {
            var list = CompanyIntegralRepository.GetTrafficLightSSList();
            return list;
        }

        /// <summary>
        /// 第三个公司红绿灯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrafficLightSList")]
        public List<TrafficLight> GetTrafficLightSList()
        {
            var list = CompanyIntegralRepository.GetTrafficLightSList();
            return list;
        }

    }
}