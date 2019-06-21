﻿using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongXu.Target.Repository.GoalManage
{
    /// <summary>
    /// 目标管理
    /// </summary>
    public class GoalManageRepository : IGoalManageRepository
    {
        dxdatabaseContext context = new dxdatabaseContext();

        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        public List<Goal> GetGoalList()
        {
            var list = context.Goal.ToList();
            return list;
        }

        /// <summary>
        /// 目标下达
        /// </summary>
        /// <param name="goal"></param>
        /// <returns></returns>
        public int GoalAdd(Goal goal)
        {
            context.Goal.Add(goal);
            int i = context.SaveChanges();
            int id = goal.GoalId;
            return id;
        }

        /// <summary>
        /// 目标文件 添加
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public int GoalFileAdd(Files files)
        {
            context.Files.Add(files);
            int i = context.SaveChanges();
            return i;
        }

        /// <summary>
        /// 批量插入 关注人
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int AddAttentionUser(List<Attention> list)
        {
            context.Attention.AddRange(list);
            int i = context.SaveChanges();
            return i;
        }

        /// <summary>
        /// 查询公司列表  指标单位
        /// </summary>
        /// <returns></returns>
        public List<Role> GetCommanyList()
        {
            var list = context.Role.Where(m => m.RoleIdentify == 1).ToList();
            return list;
        }

        /// <summary>
        /// 查询公司列表  责任单位
        /// </summary>
        /// <returns></returns>
        public List<Role> GetDutyCommanyList()
        {
            var list = context.Role.Where(m => m.RoleIdentify==2).ToList();
            return list;
        }

        /// <summary>
        /// 查询指标类型  父集
        /// </summary>
        /// <returns></returns>
        public List<Goaltype> GetParentType()
        {
            var list = context.Goaltype.Where(m => m.GoalTypePid == 0).ToList();
            return list;
        }

        /// <summary>
        /// 查询指标类型  子集
        /// </summary>
        /// <returns></returns>
        public List<Goaltype> GetChildType()
        {
            var list = context.Goaltype.Where(m => m.GoalTypePid != 0).ToList();
            return list;
        }
        
        /// <summary>
        /// 查询责任人
        /// </summary>
        /// <returns></returns>
        public List<User> GetDutyUserList()
        {
            var list = context.User.Where(m => m.User_IdentityId == 0 || m.User_IdentityId == 1).ToList();
            return list;
        }

        /// <summary>
        /// 查询协办人
        /// </summary>
        /// <returns></returns>
        public List<User> GetDothingUserList()
        {
            var list = context.User.ToList();
            return list;
        }

        /// <summary>
        /// 查询指标等级
        /// </summary>
        /// <returns></returns>
        public List<Indexlevel> GetIndexlevelList()
        {
            var list = context.Indexlevel.ToList();
            return list;
        }

        /// <summary>
        /// 查询反馈频次
        /// </summary>
        /// <returns></returns>
        public List<Frequency> GetFrequencieList()
        {
            var list = context.Frequency.ToList();
            return list;
        }
    }
}
