﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.ExecuteController 
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoalRepository GoalRepository; 
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public GoalController(IGoalRepository goal)
        { 
            GoalRepository = goal;
        }

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGoalList")]
        public List<BackLog> GetGoalList(int userid)
        {
            var list = GoalRepository.GetGoalList(userid);
            return list;  
        }
    }
}