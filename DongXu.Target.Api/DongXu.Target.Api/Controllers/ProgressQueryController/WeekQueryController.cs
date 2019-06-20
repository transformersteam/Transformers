using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IProgressQuery;
using DongXu.Target.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.ProgressQueryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekQueryController : ControllerBase
    {
        public IWeekQueryRepository iWeekQueryRepository = null;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="commodityTypeRepository"></param>
        public WeekQueryController(IWeekQueryRepository _iWeekQueryRepository)
        {
            iWeekQueryRepository = _iWeekQueryRepository;
        }

        [HttpGet("GetWeekList")]
        public PageData<WeekData> GetWeekList(int pageIndex, int pageSize, string goalName, int typeId, int leaveId, int stateId, string dutyCommanyName, string dutyUserName, DateTime goaltime)
        {
            var list = iWeekQueryRepository.GetWeekList(pageIndex, pageSize, goalName, typeId, leaveId, stateId, dutyCommanyName, dutyUserName, goaltime);
            return list;
        }
    }
}