using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IGoalManage
{
    /// <summary>
    /// 目标管理
    /// </summary>
    public interface IGoalManageRepository
    {
        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        List<Goal> GetGoalList();
    } 
}
