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
    }
}
