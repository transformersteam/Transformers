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
    public class CompanyIntegralRepository : ICompanyIntegralRepository
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

        /// <summary>
        /// 子公司红绿灯-SSS
        /// </summary>
        /// /// <returns></returns>
        public List<TrafficLight> GetTrafficLightSSSList()
        { 
            var query = context.TrafficLight.FromSql("select role.Role_Name,SUM(CASE goalstate.GoalState_Name WHEN '未完成(到期)' or '预计延期' THEN 1 ELSE 0 END) as 'RedLight',SUM(CASE goalstate.GoalState_Name WHEN '已完成(延期)' THEN 1 ELSE 0 END) as 'YellowLight',SUM(CASE goalstate.GoalState_Name WHEN '正常推进' or '已完成(按期)' THEN 1 ELSE 0 END) as 'GreenLight' from role join goal on role.Role_Id = goal.Role_Id join goalstate on goalstate.GoalState_Id = goal.GoalState_Id join indexlevel on indexlevel.IndexLevel_Id = goal.IndexLevel_Id where role.Role_Id >= 2 and role.Role_Id <= 5 and indexlevel.IndexLevel_Id =1 GROUP BY role.Role_Name").ToList();
            return query;
        }

        /// <summary>
        /// 子公司红绿灯-SS
        /// </summary>
        /// <returns></returns>
        public List<TrafficLight> GetTrafficLightSSList()
        {
            var query = context.TrafficLight.FromSql("select role.Role_Name,SUM(CASE goalstate.GoalState_Name WHEN '未完成(到期)' or '预计延期' THEN 1 ELSE 0 END) as 'RedLight',SUM(CASE goalstate.GoalState_Name WHEN '已完成(延期)' THEN 1 ELSE 0 END) as 'YellowLight',SUM(CASE goalstate.GoalState_Name WHEN '正常推进' or '已完成(按期)' THEN 1 ELSE 0 END) as 'GreenLight' from role join goal on role.Role_Id = goal.Role_Id join goalstate on goalstate.GoalState_Id = goal.GoalState_Id join indexlevel on indexlevel.IndexLevel_Id = goal.IndexLevel_Id where role.Role_Id >= 2 and role.Role_Id <= 5 and indexlevel.IndexLevel_Id =2 GROUP BY role.Role_Name").ToList();
            return query;
        }

        /// <summary>
        /// 子公司红绿灯-S
        /// </summary>
        /// <returns></returns>
        public List<TrafficLight> GetTrafficLightSList()
        {
            var query = context.TrafficLight.FromSql("select role.Role_Name,SUM(CASE goalstate.GoalState_Name WHEN '未完成(到期)' or '预计延期' THEN 1 ELSE 0 END) as 'RedLight',SUM(CASE goalstate.GoalState_Name WHEN '已完成(延期)' THEN 1 ELSE 0 END) as 'YellowLight',SUM(CASE goalstate.GoalState_Name WHEN '正常推进' or '已完成(按期)' THEN 1 ELSE 0 END) as 'GreenLight' from role join goal on role.Role_Id = goal.Role_Id join goalstate on goalstate.GoalState_Id = goal.GoalState_Id join indexlevel on indexlevel.IndexLevel_Id = goal.IndexLevel_Id where role.Role_Id >= 2 and role.Role_Id <= 5 and indexlevel.IndexLevel_Id =3 GROUP BY role.Role_Name").ToList();
            return query;
        }

    }
}
