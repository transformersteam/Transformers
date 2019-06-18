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
        /// 第一个子公司红绿灯
        /// </summary>
        List<TrafficLight> GetTrafficLightOneList();

        /// <summary>
        /// 第二个子公司红绿灯
        /// </summary>
        List<TrafficLight> GetTrafficLightTwoList();

        /// <summary>
        /// 第三个子公司红绿灯
        /// </summary>
        List<TrafficLight> GetTrafficLightThreeList();

        /// <summary>
        /// 第四个子公司红绿灯
        /// </summary>
        List<TrafficLight> GetTrafficLightFourList(); 
    }
}
