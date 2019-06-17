using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.IRepository.IGoalManage
{
    /// <summary>
    /// 目标管理
    /// </summary>
    public interface IGoalManageRepository
    {
        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        List<Goal> GetGoalList();

        /// <summary>
        /// 查询公司列表
        /// </summary>
        /// <returns></returns>
        List<Role> GetCommanyList();

        /// <summary>
        /// 查询指标类别类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Goaltype> GetParentType(int id);

        /// <summary>
        /// 查询责任人
        /// </summary>
        /// <returns></returns>
        List<User> GetDutyUserList();

        /// <summary>
        /// 查询协办人
        /// </summary>
        /// <returns></returns>
        List<User> GetDothingUserList();

        /// <summary>
        /// 查询指标等级
        /// </summary>
        /// <returns></returns>
        List<Indexlevel> GetIndexlevelList();

        /// <summary>
        /// 查询反馈频次
        /// </summary>
        /// <returns></returns>
        List<Frequency> GetFrequencieList();
    } 
}
