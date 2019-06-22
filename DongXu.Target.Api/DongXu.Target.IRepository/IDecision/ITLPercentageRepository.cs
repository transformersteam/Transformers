using DongXu.Target.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IDecision
{
    public interface ITLPercentageRepository
    {
        /// <summary>
        /// 子公司红绿灯总百分比饼图
        /// </summary>
        /// <returns></returns>
        List<TLPercentage> GetITLPercentageList();

    }
}
