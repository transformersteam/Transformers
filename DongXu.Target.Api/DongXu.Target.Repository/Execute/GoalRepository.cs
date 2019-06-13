﻿using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.Execute 
{
    public class GoalRepository : IGoalRepository
    {
        
        /// <summary>
        /// 待办事项集合
        /// </summary>
        /// <returns></returns>
        public List<Goal> GetGoalInfo()
        {
            using (dxdatabaseContext db = new dxdatabaseContext())
            {
                var list = db.Goal.ToList();
                return list;
            }
        }

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        public GoalPageination GetGoalList(int pageindex = 1, int pagesize = 3)
        {
            using (dxdatabaseContext db = new dxdatabaseContext())
            {
                var total = GetGoalInfo().Count;//获取总数
                var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));//计算最大页数
                var goalList = GetGoalInfo().Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();//一页显示多少数据

                //赋值
                var goalpageination = new GoalPageination 
                {
                    maxPage = int.Parse(maxpage.ToString()),
                    total = total,
                    GoalList = goalList
                };
                return goalpageination;
            }
        }
    }
}