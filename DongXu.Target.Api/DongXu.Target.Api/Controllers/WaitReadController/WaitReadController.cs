using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DongXu.Target.Api.Controllers.WaitReadController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitReadController : ControllerBase
    {
        /// <summary>
        /// 根据登录人的id查询待办列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Attention> GetWaitReadList(int id)
        {
            using (dxdatabaseContext context = new dxdatabaseContext())
            {
                var list = context.Attention.Include("Goal").Where(m => m.UserId == id).ToList();
                return list;
            }
        }
    }
}