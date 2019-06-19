using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.TrafficLightRanking
{
    public interface ITrafficLightRankingRepository
    {
        /// <summary>
        /// 各公司红绿灯百分比排名
        /// </summary>
        /// <returns></returns>
        List<Model.Dto.TrafficLightRanking> GetTrafficLightRankingList();

    }
}
