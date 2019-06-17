using DongXu.Target.IRepository.ICompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DongXu.Target.Model.Dto;
using DongXu.Target.Model;
using Microsoft.EntityFrameworkCore;

namespace DongXu.Target.Repository.Company
{
    public class CompanyIntegralRepository: ICompanyIntegralRepository 
    {

        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 各公司积分
        /// </summary>
        /// <returns></returns>
        public List<CompanyIntegral> GetCompanyIntegralList()
        {
            var query = context.CompanyIntegral.FromSql("select role.Role_Id,SUM(Integral.Integral_Num) as num,role.Role_Name from Integral join role on Integral.Role_Id = role.Role_Id  where role.Role_Pid =1 group by role.Role_Id order by SUM(Integral.Integral_Num) desc").ToList();
            return query;
        }
    }
}
