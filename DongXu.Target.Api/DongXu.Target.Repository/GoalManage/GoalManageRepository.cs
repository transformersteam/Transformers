using DongXu.Target.IRepository.IGoalManage;
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
        /// 查询公司列表
        /// </summary>
        /// <returns></returns>
        public List<Role> GetCommanyList()
        {
            var list = context.Role.Where(m => m.RoleIdentify == 1).ToList();
            return list;
        }

        /// <summary>
        /// 查询指标类型类别
        /// </summary>
        /// <returns></returns>
        public List<Goaltype> GetParentType(int id)
        {
            if(!string.IsNullOrWhiteSpace(id.ToString()) && id!=0)   //子节点
            {
                var list = context.Goaltype.Where(m => m.GoalTypePid ==id).ToList();
                return list;
            }
            else       //父节点
            {
                var list = context.Goaltype.Where(m => m.GoalTypePid == 0).ToList();
                return list;
            }
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
    }
}
