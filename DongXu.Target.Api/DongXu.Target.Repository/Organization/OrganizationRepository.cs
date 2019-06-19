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
        
        /// <summary>
        /// 组织管理添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddRolesO(Role model)
        {
            db.Role.Add(model);
            db.SaveChanges();
            return model.RoleId;
        }

        
        /// <summary>
        /// 组织管理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// 组织管理反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRolesById(int id)
        {
            Role role = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            return role;
        }

        
        /// <summary>
        /// 组织管理显示
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesOList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify != 3).ToList();
            return list;
        }

        /// <summary>
        /// 组织管理 根据id显示
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public Role GetRolesOListById(int RoleId)
        {
            Role list = db.Role.Where(m => m.RoleIdentify != 3 && m.RoleId == RoleId).FirstOrDefault();
            return list;
        }

        /// <summary>
        /// 组织管理 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
            return 0;
        }

        /// <summary>
        /// 组织管理 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// 角色岗位 显示
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesGList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify < 4).ToList();
            return list;
        }

        /// <summary>
        /// 显示 岗位下 显示用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public RoleUserQuery GetRoleUserQueryList(int RoleId)
        {
            RoleUserQuery role = db.RoleUserQuery.FromSql("SELECT * from role a INNER JOIN userrole b on a.Role_Id=b.Role_Id INNER JOIN `user` c on b.User_Id=c.User_Id WHERE a.Role_Identify=3").FirstOrDefault();
            return role;
        }

        /// <summary>
        /// 角色 显示
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesRList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify == 3).ToList();
            return list;
        }

        /// <summary>
        /// 人员显示
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersList()
        {
            throw new System.NotImplementedException();
        }

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
        public int AddUser(AddUser adduser) 
        {
            User user = new User();
            user.UserId = adduser.UserId;
            user.UserName = adduser.UserName;
            user.UserPass = adduser.UserPass;
            user.UserRealName = adduser.UserRealName;
            user.UserRoleName = adduser.UserRoleName;
            user.UserIsEnable = adduser.UserIsEnable;
            user.UserCreateTime = adduser.UserCreateTime; 
            
            Userrole userrole = new Userrole();
            db.User.Add(user);
            var query = db.SaveChanges();
            userrole.UserId = user.UserId;
            userrole.RoleId = adduser.userRoleid;
            db.Userrole.Add(userrole);
            db.SaveChanges();
            return query;
        }

        /// <summary>
        /// 获取该部门下所有职业
        /// </summary>
        /// <param name="Role_Id"></param>
        /// <returns></returns>
        public DataTable ChildrenJobByRole(int Role_Id)
        {
            MySqlParameter sqlParameters = new MySqlParameter("@RoleId", MySqlDbType.Int32);
            sqlParameters.Value = Role_Id;
            var query = DbProcedureHelper.ExecuteDt("P_GetChildrenJobByRoleId", sqlParameters);
            return query;
        }
        
        /// <summary>
        /// 查询所有权限
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowerList()
        {
            List<Power> list = db.Power.ToList();
            return list;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddRole(Role model)
        {
            db.Role.Add(model);
            db.SaveChanges();
            return model.RoleId;
        }
        
        /// <summary>
        /// 添加角色 关联
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int AddRolepower(int rid,int[] power)
        {
            List<Rolepower> rplist = new List<Rolepower>();
            for(int i=0;i<power.Length;i++)
            {
                Rolepower rp = new Rolepower();
                rp.RoleId = rid;
                rp.PowerId = power[i];
                rplist.Add(rp);
            }
            db.Rolepower.AddRange(rplist);
            //db.Database.ExecuteSqlCommand("insert into rolepower(Role_Id,Power_Id) values(@RoleId,@RolePowerId)", rplist);
            return db.SaveChanges();
        }
        
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRolesR(int id)
        {
            var roleo = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            db.Role.Remove(roleo);
            //1.0 先按照条件查询
            var list = db.Rolepower.Where(m => m.RoleId == id).ToList();
            //2.0 遍历集合，将 要删除的 对象 的代理对象的State 设置为 Deleted
            list.ForEach(u => db.Rolepower.Remove(u));
            //3.0 执行更新
            int resCount = db.SaveChanges();

            return resCount;
        }
        
        /// <summary>
        /// 反填角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Role GetRoleById(int roleId)
        {
            Role role = db.Role.Where(m => m.RoleId == roleId).FirstOrDefault();
            return role;
        }

        /// <summary>
        /// 反填权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<Rolepower> GetRolepowerById(int roleId)
        {
            List<Rolepower> rolepower = db.Rolepower.Where(m => m.RoleId == roleId).ToList();
            return rolepower;
        }
        
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="model"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int UpdateRoles(Role model,int[] power)
        {
            var role = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if (role != null)
            {
                role.RoleName = model.RoleName;
                role.RoleContent = model.RoleContent;
                role.RolePid = model.RolePid;
                role.RoleModifyPeople = model.RoleModifyPeople;
                role.RoleModifyTime = model.RoleModifyTime;
                db.Database.ExecuteSqlCommand($"DELETE from rolepower where Role_Id={model.RoleId}");
                List<Rolepower> rplist = new List<Rolepower>();
                for (int i = 0; i<power.Length; i++)
                {
                    Rolepower rp = new Rolepower();
                    rp.RoleId = model.RoleId;
                    rp.PowerId = power[i];
                    rplist.Add(rp);
                }
                db.Rolepower.AddRange(rplist);
                return db.SaveChanges();
            }
                return 0;
        }

    }
}
