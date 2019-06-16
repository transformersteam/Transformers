using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Model.Dto;
using System.Data;

namespace DongXu.Target.Api.Controllers.WaitReadController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitReadController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IWaitReadRepository _iWaitReadRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public WaitReadController(IWaitReadRepository iWaitReadRepository)
        {
            _iWaitReadRepository = iWaitReadRepository;
        }

        /// <summary>
        /// 根据登录人的id查询待办列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetWaitReadList")]
        public List<WaitRead> GetWaitReadList(int id)
        {
            var list = _iWaitReadRepository.GetWaitReadList(id);
            return list;
        }

        /// <summary>
        /// 根据登录人的id获取积分列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserIntergal")]
        public DataTable GetUserIntergal(int id)
        {
            var list = _iWaitReadRepository.GetUserIntergal(id);
            return list;
        }

        /// <summary>
        /// 运行情况
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRunConditionList")]
        public List<GoalStateGoal> GetRunConditionList()
        {
            var list = _iWaitReadRepository.GetRunConditionList();
            return list;
        }

        /// <summary>
        /// 根据目标id查看目标详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTargetDetailById")]
        public List<TargetDetails> GetTargetDetailById(int id)
        {
            var list = _iWaitReadRepository.GetTargetDetailById(id);
            return list;
        }

        /// <summary>
        /// 红绿灯状态表格
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBusinessStateTable")]
        public List<BusinessStateTable> GetBusinessStateTable()
        {
            var list = _iWaitReadRepository.GetBusinessStateTable();
            return list;
        }
    }
}