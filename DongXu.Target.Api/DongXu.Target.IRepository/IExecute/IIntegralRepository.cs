using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IExecute
{
    public interface IIntegralRepository
    {
        /// <summary>
        /// 根据Id获取子公司总积分
        /// </summary>
        /// <returns></returns>
        List<NumQuery> GetIntegralList();   
    }
}
