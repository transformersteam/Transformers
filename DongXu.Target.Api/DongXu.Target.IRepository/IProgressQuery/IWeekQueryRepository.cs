using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IProgressQuery
{
    public interface IWeekQueryRepository
    {
        /// <summary>
        /// 周报查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="goalName"></param>
        /// <param name="typeId"></param>
        /// <param name="leaveId"></param>
        /// <param name="stateId"></param>
        /// <param name="dutyCommanyName"></param>
        /// <param name="dutyUserName"></param>
        /// <param name="goaltime"></param>
        /// <returns></returns>
        PageData<WeekData> GetWeekList(int pageIndex, int pageSize, string goalName, int typeId, int leaveId, int stateId, string dutyCommanyName, string dutyUserName, string begintime, string endtime);

        /// <summary>
        /// 绑定目标类型
        /// </summary>
        /// <returns></returns>
        List<Goalstate> GetStateList();
    }
}
