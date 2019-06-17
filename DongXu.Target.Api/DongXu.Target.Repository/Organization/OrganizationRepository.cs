using DongXu.Target.Model;
using System.Collections.Generic;
using System.Linq;
using DongXu.Target.IRepository.IOrganization;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace DongXu.Target.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        dxdatabaseContext db = new dxdatabaseContext();
        //组织管理添加
        public int AddRolesO(Role model)
        {
            db.Role.Add(model);
            db.SaveChanges();
            return model.RoleId;
        }

        //组织管理删除
        public int DeleteRolesO(int id)
        {
            var roleo = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            db.Role.Remove(roleo);
            //1.0 先按照条件查询
            var list = db.Role.Where(m => m.RolePid == id).ToList();
            //2.0 遍历集合，将 要删除的 对象 的代理对象的State 设置为 Deleted
            list.ForEach(u => db.Role.Remove(u));
            //3.0 执行更新
            int resCount = db.SaveChanges();

            return resCount;
        }

        //组织管理反填
        public Role GetRolesById(int id)
        {
            Role role = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            return role;
        }

        //组织管理显示
        public List<Role> GetRolesOList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify != 3).ToList();
            return list;
        }

        //组织管理 根据id显示
        public Role GetRolesOListById(int RoleId)
        {
            Role list = db.Role.Where(m => m.RoleIdentify != 3 && m.RoleId == RoleId).FirstOrDefault();
            return list;
        }

        // 组织管理 修改
        public int UpdateRolesO(Role model)
        {
            var oldrole = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if (oldrole != null)
            {
                oldrole.RoleName = model.RoleName;
                oldrole.RoleIdentify = model.RoleIdentify;
                oldrole.RoleIsEnable = model.RoleIsEnable;
                oldrole.RoleModifyPeople = model.RoleModifyPeople;
                oldrole.RoleModifyTime = model.RoleModifyTime;
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        // 组织管理 修改
        public int UpdateRolesOName(Role model)
        {
            var oldrole = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if (oldrole != null)
            {
                oldrole.RoleName = model.RoleName;
                oldrole.RoleModifyPeople = model.RoleModifyPeople;
                oldrole.RoleModifyTime = model.RoleModifyTime;
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 角色
        /// </summary>
        /// <returns></returns>
        // 岗位 显示
        public List<Role> GetRolesGList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify < 4).ToList();
            return list;
        }

        //显示 岗位下 显示用户
        public RoleUserQuery GetRoleUserQueryList(int RoleId)
        {
            RoleUserQuery role = db.RoleUserQuery.FromSql("SELECT * from role a INNER JOIN userrole b on a.Role_Id=b.Role_Id INNER JOIN `user` c on b.User_Id=c.User_Id WHERE a.Role_Identify=3").FirstOrDefault();
            return role;
        }

        // 角色 显示
        /// <summary>
        /// 岗位维护
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesRList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify == 3).ToList();
            return list;
        }

        //人员显示
        public List<User> GetUsersList()
        {
            throw new System.NotImplementedException();
        }

        //public RoleUserQuery GetRoleUserQueryListById(int RoleId)
        //{
        //    RoleUserQuery roleuser = db.RoleUserQuery.FromSql("").FirstOrDefault();
        //}
        /// <summary>
        /// 岗位维护，当前部门下的角色
        /// </summary>
        /// <returns></returns>
        public DataTable ChlidrenUserByRole(int id)
        {
            MySqlParameter sqlParameters = new MySqlParameter("@RoleId", MySqlDbType.Int32);
            sqlParameters.Value = id;

            var model = DbProcedureHelper.ExecuteDt("P_GetChildrenUserByRole", sqlParameters);
            return model;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteUser(int userid)
        {
               User user = db.User.Where(u => u.UserId == userid).FirstOrDefault();
               user.UserIsEnable = false;
               var query = db.SaveChanges();
              return query;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public int AddUser(User user)
        {
            db.User.Add(user);
            var query=db.SaveChanges();
            return query;
        }
        
        //查询所有权限
        public List<Power> GetPowerList()
        {
            List<Power> list = db.Power.ToList();
            return list;
        }
        //添加角色
        public int AddRole(Role model)
        {
            db.Role.Add(model);
            db.SaveChanges();
            return model.RoleId;
        }
        //添加角色 关联
        public int AddRolepower(int rid,int[] power)
        {
            for(int i=0;i<power.Length;i++)
            {
                Rolepower rp = new Rolepower();
                rp.RoleId = rid;
                rp.RolePowerId = power[i];
                db.Rolepower.Add(rp);
            }
            return db.SaveChanges();
        }
    }
}
