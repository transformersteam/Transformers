using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.GoalManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalManageController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoalManageRepository iGoalManageRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public GoalManageController(IGoalManageRepository _iGoalManageRepository)
        {
            iGoalManageRepository = _iGoalManageRepository;
        }

        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGoalList")]
        public List<Goal> GetGoalList()
        {
            var list = iGoalManageRepository.GetGoalList();
            return list;
        }
    }
}