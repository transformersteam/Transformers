﻿using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IExecute
{
    public interface IGoalRepository
    {
        /// <summary>
        /// 待办事项集合
        /// </summary>
        /// <returns></returns>
        List<BackLog> GetGoalList(int userid); 

        ///// <summary>
        ///// 待办事项显示
        ///// </summary>
        ///// <returns></returns>
        //GoalPageination GetGoalList(int userid, int pageindex = 1, int pagesize = 3);

    }
}
