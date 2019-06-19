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
        public List<GoalQuery> GoalQueryList(string goalname="", int goaltype=0, int goalleave=0, string goalrole="", string goaluser="", string strTime="", string endTime="", int goalstate = 0)
        {
            var query = _target.GoalQueryList( goalname,  goaltype,  goalleave,  goalrole,  goaluser,  strTime,  endTime,goalstate );
            return query;
        }

        /// <summary>
        /// 目标跟踪
        /// </summary>
        /// <returns></returns>
        [HttpGet("TargetTrackList")]
        public List<TargetTrack> TargetTrackList()
        {
            var query = _target.TargetTrackList();
            return query;
        }


    }
}