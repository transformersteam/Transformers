using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
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
        /// 目标下达
        /// </summary>
        /// <param name="goal"></param>
        int GoalAdd(Goal goal);

        /// <summary>
        /// 目标文件 添加
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        int GoalFileAdd(Files files);

        /// <summary>
        /// 添加指标分解表
        /// </summary>
        /// <param name="indexs"></param>
        /// <returns></returns>
        int GoalIndexsAdd(Indexs indexs);

        /// <summary>
        /// 批量插入 关注人
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int AddAttentionUser(List<Attention> list);

        /// <summary>
        /// 查询公司列表
        /// </summary>
        /// <returns></returns>
        List<Role> GetCommanyList();

        /// <summary>
        /// 查询公司列表  责任单位
        /// </summary>
        /// <returns></returns>
        List<Role> GetDutyCommanyList();

        /// <summary>
        /// 查询指标类别类型  父级
        /// </summary>
        /// <returns></returns>
        List<Goaltype> GetParentType();

        /// <summary>
        /// 查询指标类别类型 子集
        /// <returns></returns>
        List<Goaltype> GetChildType();

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

        /// <summary>
        /// 根据目标id获取指标分解表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Indexs> GetIndexsByGoalId(int id);

        /// <summary>
        /// 根据目标id获取目标审核人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<AuditUser> GetUserNameByGoalId(int id);
    } 
}
