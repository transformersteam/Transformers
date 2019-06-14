using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using DongXu.Target.Model;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.IRepository.IWaitRead
{
    public interface IWaitReadRepository
    {
        /// <summary>
        /// 根据登录人的id查看待阅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<WaitRead> GetWaitReadList(int id);

        DataTable GetUserIntergal(int id);

        List<GoalStateGoal> GetRunConditionList();
    }
}
