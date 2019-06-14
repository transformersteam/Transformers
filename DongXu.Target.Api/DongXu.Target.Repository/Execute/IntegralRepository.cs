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
        /// 根据Id获取各人员积分
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<NumQuery> GetIntegralList()
        {
            var query = context.NumQuery.FromSql("select User.User_Id,SUM(Integral.Integral_Num) as num, User.User_RealName from Integral join User on Integral.User_Id = User.User_Id  group by User.User_Id order by SUM(Integral.Integral_Num) desc").ToList();
            return query;
        }
    }
}
