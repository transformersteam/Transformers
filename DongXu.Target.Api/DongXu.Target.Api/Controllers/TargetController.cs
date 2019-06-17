using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using DongXu.Target.IRepository;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ITargetRepository  _target;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="organization"></param>
        public TargetController(ITargetRepository  targetRepository)
        {
            _target = targetRepository;
        }

        /// <summary>
        /// 目标查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GoalQueryList")]
        public List<GoalQuery> GoalQueryList()
        {
            var query = _target.GoalQueryList();
            return query;
        }

    }
}