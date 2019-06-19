using DongXu.Target.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.ICompany
{
    public interface ICompanyIntegralRepository
    { 
        /// <summary>
        /// 各子公司积分
        /// </summary>
        /// <returns></returns>
        List<CompanyIntegral> GetCompanyIntegralList();

        /// <summary>
        /// 子公司红绿灯-SSS
        /// </summary>
        List<TrafficLight> GetTrafficLightSSSList();

        /// <summary>
        /// 子公司红绿灯-SS
        /// </summary>
        List<TrafficLight> GetTrafficLightSSList();

        /// <summary>
        /// 子公司红绿灯-S
        /// </summary>
        List<TrafficLight> GetTrafficLightSList(); 
    }
}
