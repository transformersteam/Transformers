using DongXu.Target.IRepository.TrafficLightRanking;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.TrafficLightRanking
{
    public class TrafficLightRankingRepository : ITrafficLightRankingRepository
    {
        private dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 各公司红绿灯百分比排名
        /// </summary>
        /// <returns></returns>
        public DataTable GetTrafficLightRankingList()
        {
            var model = DbProcedureHelper.ExecuteDt("P_RedGreen", null);
            return model;
        }
    }
}
