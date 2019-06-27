using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IProgressQuery;
using DongXu.Target.Model;
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

        [HttpPost("GetWeekList")]
        public PageData<WeekData> GetWeekList([FromBody]WeekQueryData data)
        {
            var list = iWeekQueryRepository.GetWeekList(data.pageIndex, data.pageSize, data.goalName, data.typeId, data.leaveId, data.stateId, data.dutyCommanyName, data.dutyUserName, data.begintime,data.endtime);
            return list;
        }

        /// <summary>
        /// 绑定目标类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStateList")]
        public List<Goalstate> GetStateList()
        {
            var list = iWeekQueryRepository.GetStateList();
            return list;
        }
    }
}