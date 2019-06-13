using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IExecute;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.ExecuteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainResponsibilityController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IResponsibilityRepository ResponsibilityRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public MainResponsibilityController(IResponsibilityRepository responsibility)
        {
            ResponsibilityRepository = responsibility;
        }
        

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMainResponsibilityList")]
        public MainResponsibilityPageination GetMainResponsibilityList(int pageindex = 1, int pagesize = 3)
        {
            var list = ResponsibilityRepository.GetMainResponsibilityList(pageindex, pagesize);
            return list;
        }
    }
}