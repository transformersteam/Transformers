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
        List<WaitRead> GetWaitReadList(int id,int state);

        /// <summary>
        /// 积分详情柱状图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTable GetUserIntergal(int id);

        /// <summary>
        /// 运行情况
        /// </summary>
        /// <returns></returns>
        List<GoalStateGoal> GetRunConditionList();

        /// <summary>
        /// 根据目标id查看目标详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TargetDetails> GetTargetDetailById(int id);

        /// <summary>
        /// 红绿灯状态表格
        /// </summary>
        /// <returns></returns>
        List<BusinessStateTable> GetBusinessStateTable();
    }
}
