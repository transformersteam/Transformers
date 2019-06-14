using DongXu.Target.IRepository.IExecute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace DongXu.Target.Repository.Execute
{
    public class IntegralRepository: IIntegralRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 根据Id获取子公司积分
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<NumQuery> GetIntegralList()
        {
            var query = context.NumQuery.FromSql("select Role.Role_Id,COUNT(Integral.Integral_Num) as num,Role.Role_Name from Integral join Role on Integral.Role_Id = Role.Role_Id  group by Role.Role_Id  order by COUNT(Integral.Integral_Num) desc").ToList();
            return query;
        }
    }
}
