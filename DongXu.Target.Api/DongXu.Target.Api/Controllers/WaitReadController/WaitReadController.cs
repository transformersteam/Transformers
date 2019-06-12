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
    }
}